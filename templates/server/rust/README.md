# Rust server templates

This tree is the Rust counterpart to `templates/server/dotnet`. The Rust
migration is being landed layer by layer. Server/shared templates are
inventoried in `templates/server-rust.csv`; the test projects are managed
separately under `templates/test/rust` and inventoried in
`templates/test-rust.csv` (the .NET tests likewise live in `templates/test/dotnet`
with `templates/test-dotnet.csv`). Test output still lands under `gen/test/`.

## Status

| Layer | .NET source | Rust templates | State |
|-------|-------------|----------------|-------|
| Common | `shared/dotnet/common` | `shared/rust/common` | Done |
| Domain | `shared/dotnet/domain` | `shared/rust/domain` | Done |
| Persist | `shared/dotnet/persist` | `shared/rust/persist` | Done |
| Logic | `shared/dotnet/logic` | `shared/rust/logic` | Done (dispatch + AOP) |
| Scripting | `shared/dotnet/common` (ScriptHost / providers) | `shared/rust/script` | Done (Rhai) |
| API | `server/dotnet/api` | `server/rust/api` | Done (rouille; REST parity) |
| Scheduler | `server/dotnet/scheduler` | `server/rust/scheduler` | Done (cron crate; dispatches) |
| Script agent | `server/dotnet/scriptagent` | `server/rust/scriptagent` | Done (rouille; runs scripts) |
| Tests (persist) | `test/dotnet/test-persist` | `test/rust/test-persist` | Done |
| Tests (script) | `test/dotnet/test-script` | `test/rust/test-script` | Done (Rhai) |
| Tests (scriptagent) | `test/dotnet/test-scriptagent` | `test/rust/test-scriptagent` | Done (drives /execute) |
| Tests (scheduler) | `test/dotnet/test-scheduler` | `test/rust/test-scheduler` | Done (workflow trees) |
| Tools (import/export) | `tools/dotnet/{import,export}` | `tools/rust/{import,export}` (`tools-rust.csv`) | Done (CSV ↔ DB) |
| Tests (api) | `test/dotnet/test-*` | `test/rust/test-*` | TODO |

## Design notes carried across all layers

- **Dictionary-backed objects.** `BaseObject` keeps the .NET design: a
  `HashMap<String, serde_json::Value>` plus metadata. Generated domain types
  add statically typed accessors over it, so the persistence contract is
  unchanged (every value round-trips through `data`).
- **No runtime reflection.** `ColumnInfoAttribute` / `ClassInfoAttribute`
  become explicit `ColumnInfo` / `ClassInfo` metadata emitted by the generator
  and exposed via `DomainObject::columns()` / `class_label()`.
- **Partial classes → split modules.** A `<Obj>.generated.rs` (FORCE=TRUE) and a
  `<Obj>.user.rs` (FORCE=FALSE) are `include!`d into one module by the crate
  root `lib.generated.rs`, giving the generated + hand-editable pair.
- **Type mapping** (`DotNetType` → Rust): `int`→`i32`, `long`→`i64`,
  `short`→`i16`, `bool`→`bool`, `float`→`f32`, `double`→`f64`,
  `decimal`→`rust_decimal::Decimal`, `DateTime`→`chrono::NaiveDateTime`,
  `Guid`→`uuid::Uuid`, `string`→`String`, `byte[]`→`Vec<u8>`, else
  `serde_json::Value`.
- **DB dialect** lives in the `DatabaseProvider` trait (Postgres `$N` params,
  SQL Server `@PN` params); connection/pool handling belongs to the persist
  layer (sqlx / tokio-postgres / tiberius), not the provider.

## Persist-layer notes

- `insert`/`update` dispatch to the audit or basic strategy on
  `BaseObject.is_audited`, just like the .NET `DBPersist.GetPersist`. The
  shared `put`/`get`/SQL builders sit on `DBPersist`; the divergent
  `insert`/`update` live in `db_persist_audit` / `db_persist_basic` as free
  functions (Rust trait objects can't hold the generic methods).
- **Columns, not reflection.** `insert_sql` enumerates `T::columns()` instead of
  reflecting over `ColumnInfoAttribute`.
- **Literal SQL.** Values are rendered as escaped SQL literals via
  `DatabaseProvider::format_value` (the approach the .NET update/filter path
  already used). This sidesteps per-type `ToSql` binding and round-trips the
  string-backed timestamp/decimal/uuid values. A future hardening pass can move
  inserts to bound `$N` parameters.
- **Connection.** `db_connection` is new (ADO.NET supplied this in .NET). It
  wraps the synchronous `postgres` driver to match the sync API; opens one
  connection per operation as the .NET layer did. SQL Server (tiberius, async)
  is deferred — `DbConnection::open` returns `Unsupported` for it.

## Logic-layer notes

- **AOP via a dispatch chokepoint (not reflection).** .NET used a reflective
  `DispatchProxy`. Rust has no reflection, so interception is centralised in
  `LogicExec::call` (`logic_exec.core.rs`): it runs the before hooks → a
  generated `dispatch` → the after hooks. Each logic type implements
  `LogicDispatch` with a generated `match method { ... }` that routes a method
  name to a normal `pub(crate)` operation (`select`/`get`/`insert`/...). The
  business logic lives in those methods; the match is just the string→method
  router that reflection gave .NET for free. The before/after hook registry and
  default wiring (logging + authorization) live in `proxy.core.rs`.
- **Uniform context.** Every call carries a `LogicContext` (the record +
  args), threaded through `LogicExec` → `dispatch` → the hooks — so auth,
  logging, and (once wired) event scripts all see the transaction. Call sites
  use `<Obj>Logic::exec("insert", &mut ctx)`; results come back as
  `serde_json::Value`. `<Obj>Logic::exec_unchecked` is the explicit auth bypass
  (import/export, tests).
- **Authorization can't be bypassed accidentally.** `dispatch` requires an
  `ExecProof` whose constructor is private to `logic_exec`, and the raw
  operations are `pub(crate)`. So external crates can only reach logic through
  `LogicExec` (which runs the auth hook) — there's no way to call a raw method
  and skip authorization except the named `_unchecked` path.
- **User operations.** Hand-written methods go in `<Obj>Logic.user.rs` and are
  surfaced to dispatch (and thus to auth/events/scripts) by adding a `match` arm
  in `dispatch_user` (the generated `dispatch` routes unknown names there).
- **`current_user`** uses a thread-local with an OS-user fallback (the .NET
  `AsyncLocal`), set by API middleware once that layer exists.
- **Pre/post event-service hooks** are still a TODO, but now unblocked: the
  hooks carry the `LogicContext`, so an event hook can build an `EventContext`
  from `ctx.transaction` and run scripts via the `script` crate's `ScriptHost`
  (pending the callback-registry indirection, since `script` depends on `logic`).

## API-layer notes (`server/rust/api`)

- The REST interface is byte-for-byte the .NET contract, but implemented as a
  **single generic router** instead of generated per-object controllers — every
  route maps onto `logic::object_exec(obj, method, ctx)`. The web framework is
  **rouille** (synchronous, thread-per-request), which fits the synchronous
  persist layer and the thread-local `current_user`.
- **Routes** (object name matched case-insensitively against the domain or table
  name): `GET /api/<obj>` (list), `/{id}` (get), `/view/{id}`, `/enum`,
  `POST /api/<obj>`, `PUT /api/<obj>/{id}`, `DELETE /api/<obj>/{id}`,
  `/{id}/history`, `/{id}/<child>_<role>` (children), plus
  `GET /api/NavMenu/byparent`, `POST /api/Notification/publish`,
  `GET /api/Notification/stream` (SSE), `GET /api/Workflow/run/{id}`.
- **JSON parity.** Responses serialize the object's data map. `numeric`/`decimal`
  columns — stored internally as strings for precision — are coerced back to JSON
  numbers via `common::to_typed_json` + per-column `ColumnInfo.data_type`, so the
  wire format matches the .NET serializer. (Child-collection rows, which have no
  static type at the call site, are the one place numerics aren't coerced.)
- **Auth.** Auth0 / JWT validation is removed. An optional `X-User` request
  header sets the principal for the (still enforced) logic-layer authorization
  check; absent it, the OS user is used — matching .NET running without Auth0.
- **Self-registration.** On startup the server registers itself in
  `core.server_node` (type `ApiServer`, status `Online`) via `register_api_server`,
  mirroring the .NET `RegisterApiServer` task. It runs on a spawned thread (so a
  slow DB never blocks serving) and writes through `ServerNodeLogic::exec_unchecked`
  — the unchecked path is correct here because there is no security principal at
  startup. Host/user/OS fields come from `Util::populate_session_info`.
- **Real-time notifications (SSE).** Replaces SignalR. The logic proxy's
  after-hook fires on `insert`/`update`/`put` and calls `logic::notification::publish`
  with `{DomainObjectName, InstanceId, JsonData}`. Delivery has two paths: the API
  server registers an in-process sink (`set_local_delivery`) at startup, so its own
  notifications go **straight to the local SSE registry** — no loopback HTTP, so it
  works regardless of whether the registered hostname resolves. Any *other* online
  API server in `core.server_node` (e.g. a separate scheduler/scriptagent that made
  the change) is reached over HTTP at `POST /api/Notification/publish`, and the
  fan-out skips this node's own URL to avoid double-delivery. Clients connect to
  `GET /api/Notification/stream` and receive `PropertyUpdated` Server-Sent Events;
  the Blazor `EventSource` client filters by domain object name. Same publish
  contract/distribution model as the .NET version — only the browser transport
  changed from SignalR to SSE, so one client works against both backends.
  Connections are pruned via a 20s heartbeat; cross-instance scale-out would move
  fan-out to Postgres `LISTEN`/`NOTIFY` or a message bus.
- **Deferred:** Auth0 M2M. `GET /api/Workflow/run/{id}` returns 503 until the
  workflow engine (scheduler) is ported.
- **Deferred logic modules** (need un-ported infra — HTTP, Auth0):
  `EventServiceLogic`, `WorkflowLogic`, `HealthMonitorThread`, `M2MTokenProvider`.
  The `SchedulerLogic`/`ScriptAgentClient` dispatch and cron handling are folded
  into the scheduler/agent servers below.

## Scheduler (`server/rust/scheduler`)

The cron engine: it fires workflows on schedule and dispatches them to agents.

- **Self-registration.** Binds the first free port in **5000-5100** and registers
  as a `Scheduler` node (status `Online`); `ctrlc` marks it `Offline` on shutdown.
- **Cron thread** (port of `QuartzSchedulerThread`). Loads every active workflow
  whose `core.schedule` has its cron component FKs populated (the same JOIN query),
  assembles a cron expression from the parts — applying the `Every`/`Exactly`
  modifier (`ApplyEvery`) and the Quartz dom/dow reconciliation (`ReconcileDomDow`)
  — and parses it with the `cron` crate (Quartz-style `sec min hour dom month dow
  year`). When a schedule is due it calls `execute(workflow_id)`. Schedules reload
  every 5 minutes. Quartz's separate seconds field is fixed at `0`; `?` is mapped
  to `*` after reconciliation (the `cron` crate ANDs dom/dow, and reconciliation
  leaves at most one restricted, so the firing days match).
- **Dispatch** (port of `SchedulerLogic.execute` / `ExecuteWorkflowInternal`).
  Expands a `Folder` workflow into its child workflows recursively (via `parent_id`),
  groups them by `seq`, and in seq order dispatches each `Process` child to its
  agent's `/api/scriptagent/execute`; a `Folder` child is re-queued to the
  scheduler. Each workflow is set to `Dispatched` first (and `Failed` on a dispatch
  error), and every change is published so the web UI updates live.
- **REST surface.** `POST /api/scheduler/execute` (body = workflow id),
  `cancel`/`abort`/`status` (stubs, as in .NET), `register`/`unregister`, plus
  `ping`/`health`.
- **Caveats.** Numeric day-of-week values are assumed Quartz-compatible (1-7,
  Sun=1), which the `cron` crate shares; the `cron_*` lookup data should match.
  `cancel`/`abort` and the health-monitor thread are not yet ported.

## Script agent (`server/rust/scriptagent`)

A standalone node that runs workflow scripts, structurally a sibling of the API
server.

- **Self-registration.** Binds the first free port in **5100-5200** and registers
  in `core.server_node` as type `Agent`, status `Online` (reusing the API server's
  registration pattern). On SIGINT/SIGTERM a `ctrlc` handler marks the node
  `Offline` — the equivalent of the .NET `ApplicationStopping` unregister.
- **REST surface.** The full `ScriptAgentController` route set under
  `/api/scriptagent/...` (stop/kill/restart/pause/resume, status/heartbeat/report,
  capabilities, ping/health/diagnose, execution CRUD, …). As in .NET, most are
  stubs returning the same placeholder shapes; the load-bearing route is
  `POST /api/scriptagent/execute` (body = workflow id), which queues the id.
- **Execution engine.** A single background thread drains the queue and runs
  `execute_workflow` (port of `ScriptAgentLogic.ExecuteWorkflow`): load the
  workflow → its process → its script, run the script through the shared `script`
  crate's `ScriptHost` (Rhai), then write `exec_status` back (`Executing` →
  `Completed`/`Failed`) and set the node `Busy`/`Online` around the run.
- **Auth.** The agent runs as a trusted process with no security principal, so its
  reads/writes use `logic::object_exec_unchecked`. Because that bypasses the
  proxy's notification hook, the agent calls `logic::notification::publish`
  explicitly after a status change, so web clients watching `Workflow` update live
  (the agent fans out over HTTP to the registered API servers). Auth0 inbound
  validation is removed, as on the API.
- **Not yet ported:** the process-control verbs (stop/kill/pause/…) are stubs, as
  they are in .NET; and scripts that perform DB access run through the *checked*
  logic path, so they need a seeded principal to be authorized.

## Test-persist notes

- A binary crate (`[[bin]]`) whose root is `main.generated.rs`; it wires in
  `base_test` and each per-object `<Obj>Test` module, then runs the persistence
  smoke test (seed admin role/principal, then insert/update each non-core
  object twice) — the `Program.cs` logic.
- **Test data as `Value`.** `BaseTest::get_test_data` returns `serde_json::Value`
  written straight into the object's backing map via `base.set(...)`, matching
  the dictionary-backed design (the .NET version used typed setters +
  `Convert.*`).
- **No `rand` dependency.** A small inline xorshift PRNG replaces
  `System.Random`. `TestDataType` keeps the .NET (non-PascalCase) variant names
  so the `TestDataType::<set>` substitution from the CSV `TEST_DATA_SET` column
  works unchanged.
- The unused per-object `last<Obj>`/`map<Obj>` collections from the .NET
  `BaseTest` are omitted.

## Scripting notes (`shared/rust/script`)

- The .NET in-process script engine (Roslyn C# / PowerShell / Python) is
  replaced by **Rhai**, an embedded, sandboxed scripting language. No runtime
  toolchain, instant execution, and scripts can do nothing the host doesn't
  register. `ScriptProviderFactory` keeps the door open for other engines.
- Same shape as .NET: `ScriptContext`, `ScriptProvider` trait,
  `ScriptProviderFactory`, `ScriptHost::invoke(ctx, script_row)` (reads
  `source` / `name` / `script_type_id` off a `core.script` record).
- **Capabilities registered** on the engine: `log_info/debug/error`;
  `http_get(url)` / `http_post(url, body)` (blocking, via `ureq`);
  `db_get/db_select/db_put/db_update/db_delete`; and the triggering record as a
  mutable `ctx` plus inputs as `args`. Sandbox caps (max ops / call depth /
  string + array sizes) guard against runaway scripts.
- **DB access goes through the Logic layer**, not raw SQL. `logic_bridge.generated.rs`
  is a generated name→`<Obj>Logic` dispatch (Rust has no reflection), and every
  call uses `<Obj>Logic::create()` (the proxied logic), so scripts inherit
  authorization (`OpRoleMemberLogic`) and audit stamping for free.
- Errors percolate: a failed host call surfaces as a Rhai eval error →
  `ScriptError` → the caller; a non-zero `ret_code` is also an error.
- **Deferred:** wiring `ScriptHost` into the proxy's pre/post **event-service**
  hooks. `EventServiceLogic` lives in `logic`, but `script` depends on `logic`,
  so calling scripts from `logic` would be a dependency cycle — that hook needs
  a small callback-registry indirection, to be added with the event layer.
