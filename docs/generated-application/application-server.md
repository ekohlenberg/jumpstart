---
layout: default
title: Application Server
parent: Generated Application
nav_order: 2
---

# Application Server

The application server is composed of three layers — API, Logic, and Persistence — generated for either backend:

| | .NET | Rust |
|---|------|------|
| Web framework | ASP.NET Core 9 | rouille (synchronous, thread-per-request) |
| API shape | one generated controller per object | one generic router over string dispatch |
| Interception | reflective `DispatchProxy` | `LogicExec` dispatch chokepoint |
| Persistence | ADO.NET (Npgsql / SqlClient) | `postgres` driver |

The REST contract, security model, audit behavior, and notification protocol are identical — clients cannot tell the backends apart.

## REST API Contract

| Method | Route | Description |
|--------|-------|-------------|
| `GET` | `/api/{entity}` | List all (View objects with resolved enum names) |
| `GET` | `/api/{entity}/{id}` | Get by ID (raw domain object) |
| `GET` | `/api/{entity}/view/{id}` | Get view by ID (with resolved FK display values) |
| `GET` | `/api/{entity}/enum` | Enum list `[{id, rwkString}]` for dropdowns |
| `POST` | `/api/{entity}` | Create new record |
| `PUT` | `/api/{entity}/{id}` | Update existing record |
| `DELETE` | `/api/{entity}/{id}` | Delete (soft-delete) record |
| `GET` | `/api/{entity}/{id}/history` | All row versions of an audited record, newest first |
| `GET` | `/api/{entity}/{id}/{child}_{role}` | Child records (parent FK relationships) |
| `GET` | `/api/NavMenu/byparent` | Navigation menu tree |
| `GET` | `/api/Notification/stream` | Server-Sent Events stream (real-time updates) |
| `POST` | `/api/Notification/publish` | Cross-node notification fan-in |
| `GET` | `/api/Workflow/run/{id}` | Dispatch a workflow to the Scheduler |

Entity names are matched case-insensitively against the domain name (`Customer`) or table name (`customer`).

### .NET implementation

Each domain object generates a partial controller (`Customer.api.generated.cs`) with the routes above; core extensions like `Workflow.api.core.cs` add object-specific endpoints to the same partial class.

### Rust implementation

The API is a **single generic router** (`main.generated.rs`): every route is parsed to `(object, method, ctx)` and forwarded to `logic::object_exec(...)`, which maps the object name to the right `<Obj>Logic`. Responses serialize the object's backing data map; `numeric`/`decimal` columns (stored internally as strings for precision) are coerced back to JSON numbers using the generated `ColumnInfo` metadata, so the wire format matches the .NET serializer.

## Custom API Endpoints

- **.NET** — controllers are `partial class`; add endpoints in a user partial file without touching generated code.
- **Rust** — the generated router falls through to `usr/server/api/user_api.rs` (`FORCE=FALSE` stub): return `Some(Response)` to handle a route, `None` to 404. Example: `jumptest` adds `POST /api/testplan/generate/{id}` this way.

## Logic Layer

Every business operation on every domain object flows through an interception pipeline that applies logging, authorization, and (pluggable) event hooks. The standard operations are `select`, `get`, `view`, `history`, `children`, `insert`, `update`, `put`, and `delete`.

### Pipeline (both backends)

```
Caller
  |
  v
Interception entry point            .NET: proxy.Invoke()   Rust: LogicExec::call
  |
  +---> Before hooks (in order):
  |       1. Logging
  |       2. Authorization (RBAC) — throws/short-circuits if denied
  |       3. Pre-event scripts (core.event_service)
  |
  +---> The operation itself        CustomerLogic.insert(...)
  |
  +---> After hooks:
  |       1. Logging
  |       2. Notification publish (on insert/update/put) → SSE
  |       3. Post-event scripts
  v
Result
```

### .NET: DispatchProxy

Logic classes are obtained through a factory that wraps them in a reflective proxy:

```csharp
var logic = CustomerLogic.Create();   // DispatchProxy-wrapped ICustomerLogic
var customers = logic.select<CustomerView>();
```

`ProxyAction.AddBeforeAction(...)` / `AddAfterAction(...)` register additional cross-cutting hooks.

### Rust: the dispatch model

Rust has no reflection, so interception is centralized in a single chokepoint plus a generated string→method router:

```rust
let mut ctx = LogicContext::for_id(42);
let customer = CustomerLogic::exec("get", &mut ctx)?;   // hooks + dispatch
```

`LogicExec::call` runs the before hooks, then the generated `dispatch` match, then the after hooks. An `ExecProof` capability token (mintable only inside `logic_exec`) makes it impossible to reach an operation without going through the pipeline. The explicit bypass — `exec_unchecked` — exists for contexts with no security principal (server self-registration, import/export, tests) and is deliberately named to stand out in review. See [Logic & the Dispatch Model](../rust/logic-dispatch.md) for the full treatment.

## Custom Business Operations

Custom methods are first-class: they run through the same authorization and audit pipeline as generated CRUD.

### .NET

Override any virtual operation, or add new ones, in the user partial class:

```csharp
// usr: CustomerLogic.user.cs
public partial class CustomerLogic
{
    public override void insert(Customer customer)
    {
        // pre-work
        base.insert(customer);
        // post-work
    }
}
```

### Rust

Add methods in `usr/shared/logic/CustomerLogic.user.rs`. To make one authorized and audited under its own name, wrap the body in `LogicExec::call_with`:

```rust
impl CustomerLogic {
    pub fn recalculate(&self, ctx: &mut LogicContext) -> Result<Value, LogicError> {
        LogicExec::call_with("Customer", "recalculate", ctx, |ctx| {
            // runs only if the principal is authorized for Customer.recalculate
            /* ... reuse self.get / self.put / DBPersist ... */
            Ok(Value::Null)
        })
    }
}
```

To reach a custom operation *by name* (from the API or a script), implement the `dispatch_user` hook in the user file — the generated `dispatch` routes unknown method names there.

### Authorizing a custom operation

Identical in both backends: insert an `operation` row (`objectname` = domain, `methodname` = your method), map it to a role via `op_role_map`, and membership does the rest.

## Persistence Layer

`DBPersist` is the central data access component in both backends.

### Core operations

`select` (list, by named query, or by filter), `get`, `insert`, `update`, `put` (insert-or-update), `delete` (soft), `exec_cmd` (raw SQL), plus a named-query cache backed by the `core.sql` table.

### Strategies

`insert`/`update` dispatch on the object's `is_audited` flag:

| Strategy | Tables | Behavior |
|----------|--------|----------|
| **Audited** | `IS_AUDITED=1` | insert assigns `id` + `txn_id`; update soft-deletes the current row and inserts a new version (see [Database](database.md#audited-tables-and-row-versioning)) |
| **Basic** | `IS_AUDITED=0` | conventional insert / update-in-place |
| **Import** | (import tool only) | preserves pre-assigned `id`/`txn_id` from data files; enabled process-wide by `set_import_mode(true)` |

Both strategies stamp `created_by`, `last_updated`, and `last_updated_by` automatically.

### Column metadata

- **.NET** — `autoAssign` maps result-set columns to properties by reflecting over `ColumnInfoAttribute`.
- **Rust** — no reflection: the generator emits `T::columns() -> Vec<ColumnInfo>`, which the SQL builders and JSON typing use.

### Database providers

A provider abstraction handles dialect differences (PostgreSQL vs SQL Server), selected by the datasource's `dbtype` in `~/.<namespace>.json`:

| | PostgreSQL | SQL Server |
|---|-----------|-----------|
| .NET | `PostgreSQLProvider` (Npgsql) | `SqlServerProvider` (Microsoft.Data.SqlClient) |
| Rust | `postgres_provider` (`postgres` crate) | `sqlserver_provider` (connection open currently unsupported) |

Connections are opened per operation (no pool) in both backends.

## Authentication

Inbound API requests are authenticated with **Auth0 RS256 JWTs**: signature (JWKS), audience, issuer, and expiry are verified, and the token's email/`sub` claim becomes the current principal for authorization. Setup is covered in [Auth0 Setup](../auth0-setup.md); server-to-server tokens in [M2M Authentication](../auth0-m2m.md).

Auth0 settings are read at runtime from `~/.<namespace>.json` (an `auth0` section), not baked in at generation time. If no API audience is configured, Auth0 is treated as disabled and the server falls back to an optional `X-User` header (then the OS user) — which keeps local development and test harnesses working without a tenant.

The current principal is carried per-request (an `AsyncLocal` in .NET, a thread-local in Rust) and consumed by the authorization hook.

## Authorization (RBAC)

```
Principal (user)
    └── op_role_member ── op_role ── op_role_map ── operation (objectname + methodname)
```

The authorization hook runs on every logic call and checks the principal against this join:

```sql
SELECT 1 FROM core.operation op
  JOIN core.op_role_map orm  ON orm.op_id = op.id
  JOIN core.op_role r        ON r.id = orm.op_role_id
  JOIN core.op_role_member m ON m.op_role_id = r.id
  JOIN core.principal p      ON p.id = m.principal_id
WHERE op.objectname = '{domain}' AND op.methodname = '{method}'
  AND p.username = '{currentUser}'
```

Results are cached per (user, operation). The seed data bootstraps an admin role with full access for the installing user.

## Real-Time Notifications (SSE)

Record changes propagate to browsers over **Server-Sent Events** — the same protocol in both backends (this replaced the original SignalR design):

- The after-hook on `insert`/`update`/`put` publishes `{DomainObjectName, InstanceId, JsonData}`.
- The API server delivers its own notifications directly to its in-process SSE registry; changes made by *other* nodes (scheduler, agent, another API instance) arrive via `POST /api/Notification/publish`, fanned out across the online API servers registered in `core.server_node` (skipping self to avoid double delivery).
- Browsers connect to `GET /api/Notification/stream` with `EventSource` and receive `PropertyUpdated` events, filtered client-side by domain object name.
- Stale connections are pruned by a heartbeat. Cross-instance scale-out would move fan-out to `LISTEN/NOTIFY` or a message bus.

Code paths that use the unchecked logic path (agent, scheduler) bypass the after-hook, so they publish explicitly after status changes.

## Self-Registration

On startup each API server registers a `core.server_node` row (type `ApiServer`, status `Online`) on a background thread, and marks itself `Offline` on shutdown. This registry drives scheduler/agent discovery and notification fan-out. Port ranges: API 5200-5300, agent 5100-5200, scheduler 5000-5100.
