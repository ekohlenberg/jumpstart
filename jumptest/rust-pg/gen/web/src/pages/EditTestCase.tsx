import { useEffect, useMemo, useState, type FormEvent, type ReactNode } from "react";
import { useNavigate, useParams, useLocation } from "react-router-dom";
import { useApiClient, type ApiClient } from "../api/apiClient";
import DataTable, { type DataTableColumn } from "../components/DataTable";
import TabControl, { type TabItem } from "../components/TabControl";
import "../styles/editForm.css";

// Raw shape sent/received by GET|POST|PUT /api/testcase[/{id}] -- matches
// the TestCase domain class generated for the dotnet/rust servers (every
// attribute, unlike the *View interface the list page works with).
export interface TestCase {
  id: number;
  test_plan_id: number;
  code: string;
  area: string;
  title: string;
  preconditions: string;
  steps: string;
  expected_result: string;
  priority: string;
  component: string;
  is_active: number;
  created_by: string;
  last_updated: string;
  last_updated_by: string;
  txn_id: number;
}

// History rows are the same shape as the live record (see
// shared/dotnet/domain/template.generated.cs.cshtml's "TestCaseHistory : TestCase").
export type TestCaseHistory = TestCase;


// Raw shape returned by GET /api/testcase/{id}/{child}_{role} for the
// "TestResult" child relationship(s) below.
interface TestResultRow {
  id: number;
  test_run_id: number;
  test_case_id: number;
  test_result_status_id: number;
  executed_at: string;
  executed_by: string;
  actual_result: string;
  notes: string;
  is_active: number;
  created_by: string;
  last_updated: string;
  last_updated_by: string;
  txn_id: number;
}

// Matches EnumHelper (shared/dotnet/common/EnumHelper.cs.cshtml): the option
// list behind every FK/enum <select>.
interface EnumOption {
  id: number;
  rwkString: string;
}

interface FormField {
  key: string;
  label: string;
  kind: "string" | "number" | "boolean" | "date" | "enum";
  fkVar: string;
}

const FORM_FIELDS: FormField[] = [
  { key: "id", label: "Test Case ID", kind: "number", fkVar: "" },
  { key: "test_plan_id", label: "Test Plan", kind: "enum", fkVar: "testplan" },
  { key: "code", label: "Code", kind: "string", fkVar: "" },
  { key: "area", label: "Area", kind: "string", fkVar: "" },
  { key: "title", label: "Title", kind: "string", fkVar: "" },
  { key: "preconditions", label: "Preconditions", kind: "string", fkVar: "" },
  { key: "steps", label: "Steps", kind: "string", fkVar: "" },
  { key: "expected_result", label: "Expected Result", kind: "string", fkVar: "" },
  { key: "priority", label: "Priority", kind: "string", fkVar: "" },
  { key: "component", label: "Component", kind: "string", fkVar: "" },
  { key: "is_active", label: "Active", kind: "number", fkVar: "" },
  { key: "created_by", label: "Created By", kind: "string", fkVar: "" },
  { key: "last_updated", label: "Last Updated", kind: "date", fkVar: "" },
  { key: "last_updated_by", label: "Last Updated By", kind: "string", fkVar: "" },
  { key: "txn_id", label: "Txn Id", kind: "number", fkVar: "" },
];

const OWN_COLUMNS: DataTableColumn[] = [
  { key: "id", label: "Test Case ID" },
  { key: "code", label: "Code" },
  { key: "area", label: "Area" },
  { key: "title", label: "Title" },
  { key: "preconditions", label: "Preconditions" },
  { key: "steps", label: "Steps" },
  { key: "expected_result", label: "Expected Result" },
  { key: "priority", label: "Priority" },
  { key: "component", label: "Component" },
  { key: "is_active", label: "Active" },
  { key: "created_by", label: "Created By" },
  { key: "last_updated", label: "Last Updated" },
  { key: "last_updated_by", label: "Last Updated By" },
];


const TESTRESULT_COLUMNS: DataTableColumn[] = [
  { key: "id", label: "Test Result ID" },
  { key: "executed_at", label: "Executed At" },
  { key: "executed_by", label: "Executed By" },
  { key: "actual_result", label: "Actual Result" },
  { key: "notes", label: "Notes" },
  { key: "is_active", label: "Active" },
  { key: "created_by", label: "Created By" },
  { key: "last_updated", label: "Last Updated" },
  { key: "last_updated_by", label: "Last Updated By" },
];

function defaultValueForKind(kind: FormField["kind"]): string | number | boolean {
  switch (kind) {
    case "number":
    case "enum":
      return 0;
    case "boolean":
      return false;
    default:
      return "";
  }
}

function createEmptyTestCase(): TestCase {
  const obj: Record<string, unknown> = {};
  for (const field of FORM_FIELDS) {
    obj[field.key] = defaultValueForKind(field.kind);
  }
  return obj as unknown as TestCase;
}

function chunk<T>(items: T[], size: number): T[][] {
  const rows: T[][] = [];
  for (let i = 0; i < items.length; i += size) {
    rows.push(items.slice(i, i + size));
  }
  return rows;
}

export default function Edit@(domainObj)() {
  const api = useApiClient();
  const navigate = useNavigate();
  const location = useLocation();
  const params = useParams<{ id?: string }>();
  const id = params.id ? Number(params.id) : null;

  const returnUrl = useMemo(() => new URLSearchParams(location.search).get("returnUrl"), [location.search]);

  const [formData, setFormData] = useState<TestCase>(() => createEmptyTestCase());
  const [historyList, setHistoryList] = useState<TestCaseHistory[] | null>(null);
  const [enumOptions, setEnumOptions] = useState<Record<string, EnumOption[]>>({});
  const [activeTab, setActiveTab] = useState(0);
  const [activeChildTab, setActiveChildTab] = useState(0);
  const [testresult_test_caseList, set_testresult_test_caseList] = useState<TestResultRow[] | null>(null);

  // Loads the record (plus history/children) when editing an existing row;
  // resets to a blank record when navigating to the "create" route.
  useEffect(() => {
    let cancelled = false;

    async function load() {
      if (id == null) {
        setFormData(createEmptyTestCase());
        setHistoryList(null);
        return;
      }

      try {
        const record = await api.get<TestCase>(`/api/testcase/${id}`);
        if (!cancelled) setFormData(record);
      } catch (err) {
        console.error("EditTestCase: error loading record", err);
      }

      try {
        const history = await api.get<TestCaseHistory[]>(`/api/testcase/${id}/history`);
        if (!cancelled) setHistoryList(history);
      } catch (err) {
        console.error("EditTestCase: error loading history", err);
        if (!cancelled) setHistoryList([]);
      }

      try {
        const testresult_test_case = await api.get<TestResultRow[]>(
          `/api/testcase/${id}/testresult_test_case`,
        );
        if (!cancelled) set_testresult_test_caseList(testresult_test_case);
      } catch (err) {
        console.error("EditTestCase: error loading testresult_test_case", err);
        if (!cancelled) set_testresult_test_caseList([]);
      }
    }

    load();
    return () => {
      cancelled = true;
    };
  }, [id, api]);

  // Enum/parent dropdown options -- needed for both create and edit, same as
  // Blazor's LoadEnumData() (called unconditionally in OnParametersSetAsync).
  useEffect(() => {
    let cancelled = false;

    Promise.all(
      FORM_FIELDS.filter((f) => f.kind === "enum").map(async (field) => {
        const options = await api.get<EnumOption[]>(`/api/${field.fkVar}/enum`);
        return [field.key, options] as const;
      }),
    )
      .then((entries) => {
        if (!cancelled) setEnumOptions(Object.fromEntries(entries));
      })
      .catch((err) => console.error("EditTestCase: error loading enum options", err));

    return () => {
      cancelled = true;
    };
  }, [api]);

  function setField(key: string, value: string | number | boolean) {
    setFormData((current) => ({ ...current, [key]: value }));
  }

  async function handleSubmit(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    try {
      if (id == null) {
        await api.post<TestCase>("/api/testcase", formData);
      } else {
        await api.put<TestCase>(`/api/testcase/${id}`, formData);
      }
    } catch (err) {
      console.error("EditTestCase: error saving testcase", err);
    }
    navigate(returnUrl ?? "/testcase");
  }

  function handleCancel() {
    navigate(returnUrl ?? "/testcase");
  }

  const rwkString = [formData.code, formData.title]
    .filter((v) => v !== null && v !== undefined && v !== "")
    .join(" ");

  const fieldRows = chunk(FORM_FIELDS, 3);
  const values = formData as unknown as Record<string, unknown>;

  const editTabContent: ReactNode = (
    <form onSubmit={handleSubmit}>
      <div className="form-group">
        <table className="table table-borderless">
          <tbody>
            {fieldRows.map((row, rowIndex) => (
              <tr key={rowIndex}>
                {row.map((field) => (
                  <td key={field.key} style={{ width: "33%", padding: "0.5rem" }}>
                    <div className="mb-2">
                      <label htmlFor={field.key} className="form-label">
                        {field.label}
                      </label>
                      {field.kind === "enum" ? (
                        <select
                          id={field.key}
                          className="form-control"
                          value={String(values[field.key] ?? "")}
                          onChange={(e) => setField(field.key, Number(e.target.value) || 0)}
                        >
                          <option value="">-- Select --</option>
                          {(enumOptions[field.key] ?? []).map((opt) => (
                            <option key={opt.id} value={opt.id}>
                              {opt.rwkString}
                            </option>
                          ))}
                        </select>
                      ) : field.kind === "boolean" ? (
                        <input
                          id={field.key}
                          type="checkbox"
                          className="form-check-input"
                          checked={Boolean(values[field.key])}
                          onChange={(e) => setField(field.key, e.target.checked)}
                        />
                      ) : field.kind === "number" ? (
                        <input
                          id={field.key}
                          type="number"
                          className="form-control"
                          value={String(values[field.key] ?? 0)}
                          onChange={(e) => setField(field.key, Number(e.target.value) || 0)}
                        />
                      ) : field.kind === "date" ? (
                        <input
                          id={field.key}
                          type="date"
                          className="form-control"
                          value={String(values[field.key] ?? "").slice(0, 10)}
                          onChange={(e) => setField(field.key, e.target.value)}
                        />
                      ) : (
                        <input
                          id={field.key}
                          type="text"
                          className="form-control"
                          value={String(values[field.key] ?? "")}
                          onChange={(e) => setField(field.key, e.target.value)}
                        />
                      )}
                    </div>
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="mb-3">
        <button type="submit" className="btn btn-primary">
          Save
        </button>
        <button type="button" className="btn btn-secondary ms-2" onClick={handleCancel}>
          Cancel
        </button>
      </div>
    </form>
  );

  const historyTabContent: ReactNode = (
    <div className="mt-3">
      <div className="alert alert-info">History records: {historyList?.length ?? 0}</div>
      <DataTable data={historyList} columns={OWN_COLUMNS} showActions={false} showAddButton={false} />
    </div>
  );

  const editTabs: TabItem[] = [
    { title: "Edit", content: editTabContent },
    { title: "History", content: historyTabContent },
  ];


  const childTabs: TabItem[] = [

    {
      title: "Test Result",
      content: (
        <div className="mt-3">
          <div className="alert alert-info">
            Test Case records: {testresult_test_caseList?.length ?? 0}
          </div>
          <DataTable
            data={testresult_test_caseList}
            columns={TESTRESULT_COLUMNS}
            showActions={false}
            showAddButton={false}
          />
        </div>
      ),
    },

  ];

  return (
    <>
      {id == null ? <h3>Create Test Case</h3> : <h3>Edit Test Case {rwkString}</h3>}

      <TabControl id="editTabs" tabs={editTabs} activeTab={activeTab} onTabChanged={setActiveTab} />

      <div className="mt-4">
        <h4>Related Records</h4>
        <TabControl id="childTabs" tabs={childTabs} activeTab={activeChildTab} onTabChanged={setActiveChildTab} />
      </div>
    </>
  );
}
