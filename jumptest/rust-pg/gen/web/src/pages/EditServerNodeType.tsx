import { useEffect, useMemo, useState, type FormEvent, type ReactNode } from "react";
import { useNavigate, useParams, useLocation } from "react-router-dom";
import { useApiClient, type ApiClient } from "../api/apiClient";
import DataTable, { type DataTableColumn } from "../components/DataTable";
import TabControl, { type TabItem } from "../components/TabControl";
import "../styles/editForm.css";

// Raw shape sent/received by GET|POST|PUT /api/servernodetype[/{id}] -- matches
// the ServerNodeType domain class generated for the dotnet/rust servers (every
// attribute, unlike the *View interface the list page works with).
export interface ServerNodeType {
  id: number;
  name: string;
  is_active: number;
  created_by: string;
  last_updated: string;
  last_updated_by: string;
  txn_id: number;
}

// History rows are the same shape as the live record (see
// shared/dotnet/domain/template.generated.cs.cshtml's "ServerNodeTypeHistory : ServerNodeType").
export type ServerNodeTypeHistory = ServerNodeType;


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
  { key: "id", label: "Server Node Type ID", kind: "number", fkVar: "" },
  { key: "name", label: "Name", kind: "string", fkVar: "" },
  { key: "is_active", label: "Active", kind: "number", fkVar: "" },
  { key: "created_by", label: "Created By", kind: "string", fkVar: "" },
  { key: "last_updated", label: "Last Updated", kind: "date", fkVar: "" },
  { key: "last_updated_by", label: "Last Updated By", kind: "string", fkVar: "" },
  { key: "txn_id", label: "Txn Id", kind: "number", fkVar: "" },
];

const OWN_COLUMNS: DataTableColumn[] = [
  { key: "id", label: "Server Node Type ID" },
  { key: "name", label: "Name" },
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

function createEmptyServerNodeType(): ServerNodeType {
  const obj: Record<string, unknown> = {};
  for (const field of FORM_FIELDS) {
    obj[field.key] = defaultValueForKind(field.kind);
  }
  return obj as unknown as ServerNodeType;
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

  const [formData, setFormData] = useState<ServerNodeType>(() => createEmptyServerNodeType());
  const [historyList, setHistoryList] = useState<ServerNodeTypeHistory[] | null>(null);
  const [enumOptions, setEnumOptions] = useState<Record<string, EnumOption[]>>({});
  const [activeTab, setActiveTab] = useState(0);
  const [activeChildTab, setActiveChildTab] = useState(0);

  // Loads the record (plus history/children) when editing an existing row;
  // resets to a blank record when navigating to the "create" route.
  useEffect(() => {
    let cancelled = false;

    async function load() {
      if (id == null) {
        setFormData(createEmptyServerNodeType());
        setHistoryList(null);
        return;
      }

      try {
        const record = await api.get<ServerNodeType>(`/api/servernodetype/${id}`);
        if (!cancelled) setFormData(record);
      } catch (err) {
        console.error("EditServerNodeType: error loading record", err);
      }

      try {
        const history = await api.get<ServerNodeTypeHistory[]>(`/api/servernodetype/${id}/history`);
        if (!cancelled) setHistoryList(history);
      } catch (err) {
        console.error("EditServerNodeType: error loading history", err);
        if (!cancelled) setHistoryList([]);
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
      .catch((err) => console.error("EditServerNodeType: error loading enum options", err));

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
        await api.post<ServerNodeType>("/api/servernodetype", formData);
      } else {
        await api.put<ServerNodeType>(`/api/servernodetype/${id}`, formData);
      }
    } catch (err) {
      console.error("EditServerNodeType: error saving servernodetype", err);
    }
    navigate(returnUrl ?? "/servernodetype");
  }

  function handleCancel() {
    navigate(returnUrl ?? "/servernodetype");
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


  return (
    <>
      {id == null ? <h3>Create Server Node Type</h3> : <h3>Edit Server Node Type {rwkString}</h3>}

      <TabControl id="editTabs" tabs={editTabs} activeTab={activeTab} onTabChanged={setActiveTab} />
    </>
  );
}
