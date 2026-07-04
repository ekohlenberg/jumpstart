import { useCallback, useEffect, useRef, useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { useApiClient, type ApiClient } from "../api/apiClient";
import DataTable, { type DataTableColumn } from "../components/DataTable";

// Row shape returned by GET /api/script and /api/script/view/{id}
// -- matches the ScriptView class generated for the dotnet/rust servers.
export interface ScriptView {
  id: number;
  name: string;
  source: string;
  script_type_id: number;
  is_active: number;
  created_by: string;
  last_updated: string;
  last_updated_by: string;
  txn_id: number;
  script_type_name: string;
}

const DOMAIN_OBJECT_NAME = "Script";

const columns: DataTableColumn[] = [
  { key: "id", label: "Script ID" },
  { key: "name", label: "Name" },
  { key: "source", label: "Source Code" },
  { key: "is_active", label: "Active" },
  { key: "created_by", label: "Created By" },
  { key: "last_updated", label: "Last Updated" },
  { key: "last_updated_by", label: "Last Updated By" },
  { key: "script_type_name", label: "Script Type" },
];

// Matches the server's PropertyUpdateMessage (see
// server/dotnet/api/EventAggregator.core.cs.cshtml and
// shared/rust/logic/notification.core.rs.cshtml) -- PascalCase field names
// and all, since it is serialized once and shared verbatim by every client,
// Blazor included.
interface PropertyUpdateMessage {
  DomainObjectName: string;
  InstanceId: number;
  JsonData: string;
  Timestamp: string;
}

async function fetchList(api: ApiClient): Promise<ScriptView[]> {
  return api.get<ScriptView[]>("/api/script");
}

export default function ListScript() {
  const api = useApiClient();
  const navigate = useNavigate();
  const location = useLocation();

  const [list, setList] = useState<ScriptView[] | null>(null);
  const sseRef = useRef<EventSource | null>(null);

  // Mirrors the current `list` state so the SSE handler below (registered
  // once per `api` change, not per render) always sees the latest data
  // instead of the value captured when the effect first ran.
  const listRef = useRef<ScriptView[] | null>(null);
  useEffect(() => {
    listRef.current = list;
  }, [list]);

  const reloadList = useCallback(async () => {
    try {
      setList(await fetchList(api));
    } catch (err) {
      console.error("ListScript: error reloading list", err);
    }
  }, [api]);

  useEffect(() => {
    let cancelled = false;

    fetchList(api)
      .then((data) => {
        if (!cancelled) setList(data);
      })
      .catch((err) => console.error("ListScript: error loading list", err));

    return () => {
      cancelled = true;
    };
  }, [api]);

  // Real-time updates arrive over Server-Sent Events -- the same
  // GET /api/Notification/stream the Blazor client's notifications.js
  // interop connects to. The browser's native EventSource needs no interop
  // layer here and reconnects on its own; we just clean up on unmount.
  useEffect(() => {
    const source = new EventSource(`${api.baseUrl}/api/Notification/stream`);
    sseRef.current = source;

    source.addEventListener("PropertyUpdated", async (event: MessageEvent<string>) => {
      try {
        const message: PropertyUpdateMessage = JSON.parse(event.data);
        if (message.DomainObjectName !== DOMAIN_OBJECT_NAME) return;

        const index = (listRef.current ?? []).findIndex((item) => item.id === message.InstanceId);
        if (index >= 0) {
          const updated = await api.get<ScriptView>(`/api/script/view/${message.InstanceId}`);
          setList((current) => {
            if (!current) return current;
            const next = [...current];
            const i = next.findIndex((item) => item.id === message.InstanceId);
            if (i >= 0) next[i] = updated;
            return next;
          });
        } else {
          await reloadList();
        }
      } catch (err) {
        console.error("ListScript: error handling notification", err);
      }
    });

    return () => {
      source.close();
      sseRef.current = null;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [api]);

  function onAdd() {
    const returnUrl = encodeURIComponent(location.pathname);
    navigate(`/edit-script?returnUrl=${returnUrl}`);
  }

  function onEdit(item: ScriptView) {
    const returnUrl = encodeURIComponent(location.pathname);
    navigate(`/edit-script/${item.id}?returnUrl=${returnUrl}`);
  }

  return (
    <>
      <h1>Scripts</h1>
      <p>This page demonstrates fetching Scripts data from the server.</p>

      <DataTable data={list} columns={columns} showActions showAddButton onEdit={onEdit} onAdd={onAdd} />
    </>
  );
}
