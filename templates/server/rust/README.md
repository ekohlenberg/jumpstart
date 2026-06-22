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
| Logic | `shared/dotnet/logic` | `shared/rust/logic` | Foundation done |
| API | `server/dotnet/api` | `server/rust/api` | TODO |
| Scheduler | `server/dotnet/scheduler` | `server/rust/scheduler` | TODO |
| Script agent | `server/dotnet/scriptagent` | `server/rust/scriptagent` | TODO |
| Tests (persist) | `test/dotnet/test-persist` | `test/rust/test-persist` | Done |
| Tests (api/scheduler/scriptagent) | `test/dotnet/test-*` | `test/rust/test-*` | TODO |

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

- **AOP without reflection.** .NET used a `DispatchProxy` to intercept every
  interface method. Rust trait objects can't carry generic methods and there is
  no reflection, so each generated `<Obj>LogicProxy` wraps an inner
  `Box<dyn I<Obj>Logic>` and calls `proxy::run_before` / `run_after` around each
  method explicitly. The shared before/after hook registry and the default
  wiring live in `proxy.core.rs`.
- **Default hooks wired:** structured logging and authorization
  (`OpRoleMemberLogic::authorized`). The pre/post **event-service** hooks are
  deferred because `EventServiceLogic` needs the script-execution engine
  (C#/PowerShell/Python), which was intentionally not ported into `common`.
- **Object-safe trait surface.** `I<Obj>Logic` exposes the concretely-typed
  methods the API calls (`select`, `get`, `view`, `history`, `children`,
  `insert`, `update`, `put`, `delete`). The generic `select_query<T>` stays an
  inherent method on the concrete type. `children` returns `Vec<BaseObject>`.
- **`current_user`** uses a thread-local with an OS-user fallback (the .NET
  `AsyncLocal`), set by API middleware once that layer exists.
- **Deferred logic modules** (need un-ported infra — script engine, HTTP,
  SignalR, Quartz, Auth0): `EventServiceLogic`, `WorkflowLogic`,
  `SchedulerLogic`, `ScriptAgentLogic`, `SchedulerClient`, `ScriptAgentClient`,
  `DispatcherThread`, `HealthMonitorThread`, `M2MTokenProvider`,
  `NotificationRegistrar`. These come online with the api/scheduler/scriptagent
  layers.

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
