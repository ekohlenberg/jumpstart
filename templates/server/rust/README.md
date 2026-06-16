# Rust server templates

This tree is the Rust counterpart to `templates/server/dotnet`. The Rust
migration is being landed layer by layer; the template registry is
`templates/server-rust.csv`.

## Status

| Layer | .NET source | Rust templates | State |
|-------|-------------|----------------|-------|
| Common | `shared/dotnet/common` | `shared/rust/common` | Done |
| Domain | `shared/dotnet/domain` | `shared/rust/domain` | Done |
| Persist | `shared/dotnet/persist` | `shared/rust/persist` | TODO |
| Logic | `shared/dotnet/logic` | `shared/rust/logic` | TODO |
| API | `server/dotnet/api` | `server/rust/api` | TODO |
| Scheduler | `server/dotnet/scheduler` | `server/rust/scheduler` | TODO |
| Script agent | `server/dotnet/scriptagent` | `server/rust/scriptagent` | TODO |
| Tests | `server/dotnet/test-*` | `server/rust/test-*` | TODO |

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
