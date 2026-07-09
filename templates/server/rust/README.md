# Rust server templates

This tree generates the Rust backend — the full peer of `templates/server/dotnet`. Server/shared templates are inventoried in `templates/server-rust.csv`; test projects live under `templates/test/rust` (`test-rust.csv`) and tools under `templates/tools/rust` (`tools-rust.csv`). The .NET equivalents follow the same split (`server-dotnet.csv`, `test-dotnet.csv`, `tools-dotnet.csv`).

User-facing documentation for the Rust backend is in `docs/rust/`; this file records template-level design notes.

## Coverage

| Layer | Templates | Notes |
|-------|-----------|-------|
| Common | `shared/rust/common` | Config, BaseObject, Logger, DB providers, Auth0 |
| Domain | `shared/rust/domain` | per-table structs + core enums |
| Persist | `shared/rust/persist` | audited / basic / import strategies |
| Logic | `shared/rust/logic` | dispatch + interception (AOP) |
| Scripting | `shared/rust/script` | Rhai engine + logic bridge |
| API | `server/rust/api` | rouille; full REST parity |
| Scheduler | `server/rust/scheduler` | cron crate; dispatches to agents |
| Script agent | `server/rust/scriptagent` | runs scripts via ScriptHost |
| Tests | `test/rust/test-{persist,script,scriptagent,scheduler}` | `test-api` port is still TODO |
| Tools | `tools/rust/{import,export}` | CSV ↔ DB |

## Design notes carried across all layers

- **Dictionary-backed objects.** `BaseObject` keeps the shared design: a
  `HashMap<String, serde_json::Value>` plus metadata. Generated domain types
  add statically typed accessors over it, so the persistence contract is
  identical to .NET (every value round-trips through `data`).
- **No runtime reflection.** `ColumnInfoAttribute` / `ClassInfoAttribute`
  become explicit `ColumnInfo` / `ClassInfo` metadata emitted by the generator
  and exposed via `DomainObject::columns()` / `class_label()`.
- **Partial classes → split modules.** A `<Obj>.generated.rs` (FORCE=TRUE, in
  `gen/`) and a `<Obj>.user.rs` (FORCE=FALSE, in `usr/`) are `include!`d into
  one module by the crate root `lib.generated.rs`, giving the generated +
  hand-editable pair.
- **Type mapping** (`DotNetType` → Rust): `int`→`i32`, `long`→`i64`,
  `short`→`i16`, `bool`→`bool`, `float`→`f32`, `double`→`f64`,
  `decimal`→`rust_decimal::Decimal`, `DateTime`→`chrono::NaiveDateTime`,
  `Guid`→`uuid::Uuid`, `string`→`String`, `byte[]`→`Vec<u8>`, else
  `serde_json::Value`.
- **DB dialect** lives in the `DatabaseProvider` trait (Postgres `$N` params,
  SQL Server `@PN` params); connection handling belongs to the persist layer.

## Persist-layer notes

- `insert`/`update` dispatch to the audit or basic strategy on
  `BaseObject.is_audited`, matching the .NET `DBPersist.GetPersist`. The shared
  `put`/`get`/SQL builders sit on `DBPersist`; the divergent `insert`/`update`
  live in `db_persist_audit` / `db_persist_basic` as free functions (Rust trait
  objects can't hold the generic methods). A third strategy,
  `db_persist_import`, preserves pre-assigned `id`/`txn_id` values; it is
  enabled process-wide by `DBPersist::set_import_mode(true)` and used only by
  the `import` tool.
- **Columns, not reflection.** `insert_sql` enumerates `T::columns()` instead of
  reflecting over `ColumnInfoAttribute`.
- **Literal SQL.** Values are rendered as escaped SQL literals via
  `DatabaseProvider::format_value` (the approach the .NET update/filter path
  already used). This sidesteps per-type `ToSql` binding and round-trips the
  string-backed timestamp/decimal/uuid values. A future hardening pass can move
  inserts to bound `$N` parameters.
- **Connection.** `db_connection` wraps the synchronous `postgres` driver to
  match the sync API; opens one connection per operation as the .NET layer
  does. SQL Server (tiberius, async) is deferred — `DbConnection::open` returns
  `Unsupported` for it.

## Logic-layer notes

- **AOP via a dispatch chokepoint (not reflection).** .NET uses a reflective
  `DispatchProxy`. Rust has no reflection, so interception is centralised in
  `LogicExec::call` (`logic_exec.core.rs`): it runs the before hooks → a
  generated `dispatch` → the after hooks. Each logic type implements
  `LogicDispatch` with a generated `match method { ... }` that routes a method
  name to a normal `pub(crate)` operation (`select`/`get`/`insert`/...). The
  before/after hook registry and default wiring (logging + authorization) live
  in `proxy.core.rs`.
- **Uniform context.** Every call carries a `LogicContext` (the record + args),
  threaded through `LogicExec` → `dispatch` → the hooks. Call sites use
  `<Obj>Logic::exec("insert", &mut ctx)`; results come back as
  `serde_json::Value`. `<Obj>Logic::exec_unchecked` is the explicit auth bypass
  (import/export, tests, server self-registration).
- **Authorization can't be bypassed accidentally.** `dispatch` requires an
  `ExecProof` whose constructor is private to `logic_exec`, and the raw
  operations are `pub(crate)`. External crates can only reach logic through
  `LogicExec` (which runs the auth hook); the only bypass is the named
  `_unchecked` path.
- **User operations.** Hand-written methods go in `<Obj>Logic.user.rs` and are
  surfaced to dispatch (and thus to auth/events/scripts) via the `dispatch_user`
  hook (the generated `dispatch` routes unknown names there).
- **`current_user`** uses a thread-local with an OS-user fallback (the .NET
  `AsyncLocal`), set by API middleware per request.
- **Pre/post event-service hooks** are plumbed but not yet wired: the hooks
  carry the `LogicContext`, so an event hook can build an `EventContext` from
  `ctx.transaction` and run scripts via the `script` crate's `ScriptHost` —
  pending a callback-registry indirection, since `script` depends on `logic`.

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
  Unmatched routes fall through to the `usr/server/api/user_api.rs` hook
  (a `FORCE=FALSE` stub), which returns `Some(Response)` to handle a custom
  route or `None` to 404.
- **JSON parity.** Responses serialize the object's data map. `numeric`/`decimal`
  columns — stored internally as strings for precision — are coerced back to JSON
  numbers via `common::to_typed_json` + per-column `ColumnInfo.data_type`, so the
  wire format matches the .NET serializer. (Child-collection rows, which have no
  static type at the call site, are the one place numerics aren't coerced.)
- **Auth.** Inbound requests are authenticated with an Auth0 RS256 JWT
  (`common::auth0::authenticate_inbound("api", ...)` — JWKS-verified signature,
  audience, issuer, expiry; email/`sub` claim becomes the principal), mirroring
  the .NET `AddJwtBearer` pipeline. Domain/audience are read at runtime from
  the app's own `~/.<namespace>.json` (an `auth0` section alongside
  `datasources`/`loglevel`/`logwriters` — see `common::Config::auth0_settings`),
  not baked in at generation time, since one jumpstart install generates many
  applications from a single `~/.jumpstart.json`. If the "api" audience is
  absent, Auth0 is treated as unconfigured and the server falls back to an
  optional `X-User` request header (absent that, the OS user) — matching .NET
  running without Auth0, and keeping local development / `jumptest` working
  without a tenant. The API's own outbound call to the Scheduler attaches an
  M2M bearer token via `common::auth0::m2m_token("scheduler")` — see
  docs/auth0-m2m.md.
- **Self-registration.** On startup the server registers itself in
  `core.server_node` (type `ApiServer`, status `Online`) via `register_api_server`,
  mirroring the .NET `RegisterApiServer` task. It runs on a spawned thread (so a
  slow DB never blocks serving) and writes through `ServerNodeLogic::exec_unchecked`
  — the unchecked path is correct here because there is no security principal at
  startup. Host/user/OS fields come from `Util::populate_session_info`.
- **Real-time notifications (SSE).** The logic proxy's after-hook fires on
  `insert`/`update`/`put` and calls `logic::notification::publish` with
  `{DomainObjectName, InstanceId, JsonData}`. Delivery has two paths: the API
  server registers an in-process sink (`set_local_delivery`) at startup, so its
  own notifications go **straight to the local SSE registry** — no loopback
  HTTP, so it works regardless of whether the registered hostname resolves. Any
  *other* online API server in `core.server_node` (e.g. a change made by the
  scheduler/scriptagent) is reached over HTTP at `POST /api/Notification/publish`,
  and the fan-out skips this node's own URL to avoid double-delivery. Clients
  connect to `GET /api/Notification/stream` and receive `PropertyUpdated`
  Server-Sent Events; both web clients filter by domain object name with the
  browser `EventSource`. Connections are pruned via a 20s heartbeat;
  cross-instance scale-out would move fan-out to Postgres `LISTEN`/`NOTIFY` or a
  message bus.
- **SSE + rouille gotcha:** rouille buffers reader-backed response bodies (it
  computes `Content-Length` by reading to EOF, which never comes for a stream),
  so `ResponseBody::from_reader` cannot stream. The stream endpoint uses
  rouille's `Upgrade` trait to take over the socket and write/flush event frames
  manually on a per-connection thread.
- **`GET /api/Workflow/run/{id}`.** Resolves an online `Scheduler` node from
  `core.server_node` and POSTs the workflow id to its `/api/scheduler/execute`
  (mirrors `SchedulerClient.ExecuteAsync`), attaching an M2M bearer token when
  configured. Returns 503 if no Scheduler is registered, 502 if the dispatch
  call itself fails.
- **Deferred logic modules** (need un-ported infra): `EventServiceLogic`,
  `WorkflowLogic`, `HealthMonitorThread`. The `SchedulerLogic`/`ScriptAgentClient`
  dispatch and cron handling are folded into the scheduler/agent servers;
  `M2MTokenProvider` is folded into `common::auth0`.

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
  agent's `/api/scriptagent/execute` (attaching an M2M bearer token via
  `common::auth0::m2m_token("scriptagent")` when configured); a `Folder` child
  is re-queued to the scheduler. Each workflow is set to `Dispatched` first
  (and `Failed` on a dispatch error), and every change is published so the web
  UI updates live.
- **REST surface.** `POST /api/scheduler/execute` (body = workflow id),
  `cancel`/`abort`/`status` (stubs, as in .NET), `register`/`unregister`, plus
  `ping`/`health`. Every route is gated by an M2M JWT against this app's
  "scheduler" audience (`common::auth0::authenticate_inbound("scheduler", ...)`)
  — unauthenticated if that audience isn't configured, see docs/auth0-m2m.md.
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
  (the agent fans out over HTTP to the registered API servers). Inbound requests
  (from the Scheduler) are gated by an M2M JWT against this app's "scriptagent"
  audience — unauthenticated if that audience isn't configured. The agent never
  calls another service, so it has no outbound M2M client of its own — see
  docs/auth0-m2m.md.
- **Not yet ported:** the process-control verbs (stop/kill/pause/…) are stubs, as
  they are in .NET; and scripts that perform DB access run through the *checked*
  logic path, so they need a seeded principal to be authorized.

## Test-persist notes

- A binary crate (`[[bin]]`) whose root is `main.generated.rs`; it wires in
  `base_test` and each per-object `<Obj>Test` module, then runs the persistence
  smoke test (seed admin role/principal, then insert/update each non-core
  object twice, selecting the data back after each write to verify it).
- **Test data as `Value`.** `BaseTest::get_test_data` returns `serde_json::Value`
  written straight into the object's backing map via `base.set(...)`, matching
  the dictionary-backed design (the .NET version uses typed setters +
  `Convert.*`).
- **No `rand` dependency.** A small inline xorshift PRNG replaces
  `System.Random`. `TestDataType` keeps the .NET (non-PascalCase) variant names
  so the `TestDataType::<set>` substitution from the CSV `TEST_DATA_SET` column
  works unchanged.
- The unused per-object `last<Obj>`/`map<Obj>` collections from the .NET
  `BaseTest` are omitted.

## Scripting notes (`shared/rust/script`)

- Where the .NET in-process script engine hosts Roslyn C# / PowerShell / Python,
  the Rust backend embeds **Rhai** — sandboxed, no runtime toolchain, instant
  execution, and scripts can do nothing the host doesn't register.
  `ScriptProviderFactory` keeps the door open for other engines.
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
- **Deferred:** wiring `ScriptHost` into the pre/post **event-service** hooks
  (see Logic-layer notes above).
