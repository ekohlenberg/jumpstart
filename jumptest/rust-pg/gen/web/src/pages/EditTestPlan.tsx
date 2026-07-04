import { useEffect, useMemo, useState, type FormEvent, type ReactNode } from "react";
import { useNavigate, useParams, useLocation } from "react-router-dom";
import { useApiClient, type ApiClient } from "../api/apiClient";
import DataTable, { type DataTableColumn } from "../components/DataTable";
import TabControl, { type TabItem } from "../components/TabControl";
import "../styles/editForm.css";

// Raw shape sent/received by GET|POST|PUT /api/testplan[/{id}] -- matches
// the TestPlan domain class generated for the dotnet/rust servers (every
// attribute, unlike the *View interface the list page works with).
export interface TestPlan {
  id: number;
  name: string;
  description: string;
  is_active: number;
  created_by: string;
  last_updated: string;
  last_updated_by: string;
  txn_id: number;
}

// History rows are the same shape as the live record (see
// shared/dotnet/domain/template.generated.cs.cshtml's "TestPlanHistory : TestPlan").
export type TestPlanHistory = TestPlan;


// Raw shape returned by GET /api/testplan/{id}/{child}_{role} for the
// "TestCase" child relationship(s) below.
interface TestCaseRow {
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

// Raw shape returned by GET /api/testplan/{id}/{child}_{role} for the
// "TestRun" child relationship(s) below.
interface TestRunRow {
  id: number;
  name: string;
  test_plan_id: number;
  run_at: string;
  run_by: string;
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
  { key: "id", label: "Test Plan ID", kind: "number", fkVar: "" },
  { key: "name", label: "Name", kind: "string", fkVar: "" },
  { key: "description", label: "Description", kind: "string", fkVar: "" },
  { key: "is_active", label: "Active", kind: "number", fkVar: "" },
  { key: "created_by", label: "Created By", kind: "string", fkVar: "" },
  { key: "last_updated", label: "Last Updated", kind: "date", fkVar: "" },
  { key: "last_updated_by", label: "Last Updated By", kind: "string", fkVar: "" },
  { key: "txn_id", label: "Txn Id", kind: "number", fkVar: "" },
];

const OWN_COLUMNS: DataTableColumn[] = [
  { key: "id", label: "Test Plan ID" },
  { key: "name", label: "Name" },
  { key: "description", label: "Description" },
  { key: "is_active", label: "Active" },
  { key: "created_by", label: "Created By" },
  { key: "last_updated", label: "Last Updated" },
  { key: "last_updated_by", label: "Last Updated By" },
];


const TESTCASE_COLUMNS: DataTableColumn[] = [
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

const TESTRUN_COLUMNS: DataTableColumn[] = [
  { key: "id", label: "Test Run ID" },
  { key: "name", label: "Name" },
  { key: "run_at", label: "Run At" },
  { key: "run_by", label: "Run By" },
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

function createEmptyTestPlan(): TestPlan {
  const obj: Record<string, unknown> = {};
  for (const field of FORM_FIELDS) {
    obj[field.key] = defaultValueForKind(field.kind);
  }
  return obj as unknown as TestPlan;
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

  const [formData, setFormData] = useState<TestPlan>(() => createEmptyTestPlan());
  const [historyList, setHistoryList] = useState<TestPlanHistory[] | null>(null);
  const [enumOptions, setEnumOptions] = useState<Record<string, EnumOption[]>>({});
  const [activeTab, setActiveTab] = useState(0);
  const [activeChildTab, setActiveChildTab] = useState(0);
  const [testcase_test_planList, set_testcase_test_planList] = useState<TestCaseRow[] | null>(null);
  const [testrun_test_planList, set_testrun_test_planList] = useState<TestRunRow[] | null>(null);

  // Loads the record (plus history/children) when editing an existing row;
  // resets to a blank record when navigating to the "create" route.
  useEffect(() => {
    let cancelled = false;

    async function load() {
      if (id == null) {
        setFormData(createEmptyTestPlan());
        setHistoryList(null);
        return;
      }

      try {
        const record = await api.get<TestPlan>(`/api/testplan/${id}`);
        if (!cancelled) setFormData(record);
      } catch (err) {
        console.error("EditTestPlan: error loading record", err);
      }

      try {
        const history = await api.get<TestPlanHistory[]>(`/api/testplan/${id}/history`);
        if (!cancelled) setHistoryList(history);
      } catch (err) {
        console.error("EditTestPlan: error loading history", err);
        if (!cancelled) setHistoryList([]);
      }

      try {
        const testcase_test_plan = await api.get<TestCaseRow[]>(
          `/api/testplan/${id}/testcase_test_plan`,
        );
        if (!cancelled) set_testcase_test_planList(testcase_test_plan);
      } catch (err) {
        console.error("EditTestPlan: error loading testcase_test_plan", err);
        if (!cancelled) set_testcase_test_planList([]);
      }

      try {
        const testrun_test_plan = await api.get<TestRunRow[]>(
          `/api/testplan/${id}/testrun_test_plan`,
        );
        if (!cancelled) set_testrun_test_planList(testrun_test_plan);
      } catch (err) {
        console.error("EditTestPlan: error loading testrun_test_plan", err);
        if (!cancelled) set_testrun_test_planList([]);
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
      .catch((err) => console.error("EditTestPlan: error loading enum options", err));

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
        await api.post<TestPlan>("/api/testplan", formData);
      } else {
        await api.put<TestPlan>(`/api/testplan/${id}`, formData);
      }
    } catch (err) {
      console.error("EditTestPlan: error saving testplan", err);
    }
    navigate(returnUrl ?? "/testplan");
  }

  function handleCancel() {
    navigate(returnUrl ?? "/testplan");
  }

  const rwkString = [formData.name]
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
      title: "Test Case",
      content: (
        <div className="mt-3">
          <div className="alert alert-info">
            Test Plan records: {testcase_test_planList?.length ?? 0}
          </div>
          <DataTable
            data={testcase_test_planList}
            columns={TESTCASE_COLUMNS}
            showActions={false}
            showAddButton={false}
          />
        </div>
      ),
    },

    {
      title: "Test Run",
      content: (
        <div className="mt-3">
          <div className="alert alert-info">
            Test Plan records: {testrun_test_planList?.length ?? 0}
          </div>
          <DataTable
            data={testrun_test_planList}
            columns={TESTRUN_COLUMNS}
            showActions={false}
            showAddButton={false}
          />
        </div>
      ),
    },

  ];

  return (
    <>
      {id == null ? <h3>Create Test Plan</h3> : <h3>Edit Test Plan {rwkString}</h3>}

      <TabControl id="editTabs" tabs={editTabs} activeTab={activeTab} onTabChanged={setActiveTab} />

      <div className="mt-4">
        <h4>Related Records</h4>
        <TabControl id="childTabs" tabs={childTabs} activeTab={activeChildTab} onTabChanged={setActiveChildTab} />
      </div>
    </>
  );
}
