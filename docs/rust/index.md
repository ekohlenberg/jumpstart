---
layout: default
title: Rust Runtime
nav_order: 7
has_children: true
---

# Rust Runtime

Jumpstart can generate the application stack as a set of **Rust** crates, as an
alternative to the .NET output. The Rust runtime mirrors the .NET architecture
layer for layer, but adapts the patterns to Rust where reflection, runtime code
generation, and class inheritance are not available.

The Rust templates live under `templates/shared/rust` and `templates/server/rust`,
and are driven by their own template-inventory CSVs (`templates/server-rust.csv`
for the libraries, `templates/test-rust.csv` for the test harnesses).

## Crate layout

Generated output is a Cargo workspace of path-dependent crates:

```
gen/shared/common     -> common      (foundation: BaseObject, Config, Logger, DB providers)
gen/shared/domain     -> domain      (per-table domain objects + core enums)
gen/shared/persist    -> persist     (ADO-style data access over the postgres driver)
gen/shared/logic      -> logic       (business logic, dispatch + AOP interception)
gen/shared/script     -> script      (Rhai runtime scripting)
gen/test/test-persist -> test-persist (persistence smoke test)
gen/test/test-script  -> test-script  (Rhai scripting harness)
```

| Crate | .NET counterpart | Responsibility |
|-------|------------------|----------------|
| `common` | `shared/dotnet/common` | `BaseObject`, `ColumnInfo`/`ClassInfo`, `Config`, `Logger`, `Util`, `JsonHelper`, `EnumHelper`, the `DatabaseProvider` trait + Postgres/SQL Server providers |
| `domain` | `shared/dotnet/domain` | One struct per table with typed accessors, plus `View`/`History` wrappers and the core enum modules (`Workflow`, `Execution`, `Script`, `ServerNode`) |
| `persist` | `shared/dotnet/persist` | `DBPersist` (`select`/`get`/`insert`/`update`/`put`/`exec_cmd`/named-query cache), audit vs. basic strategies, the `postgres`-backed `DbConnection` |
| `logic` | `shared/dotnet/logic` | The dispatch model and AOP interception (`LogicExec`, `LogicDispatch`, `LogicContext`, the proxy hook registry), authorization (`OpRoleMemberLogic`) |
| `script` | `shared/dotnet/common` (script host) | `ScriptHost` running database-stored scripts on the **Rhai** engine |

## The dictionary-backed object model

The single most important design choice carried over from .NET: every domain
object is **dictionary-backed**. `BaseObject` wraps a
`HashMap<String, serde_json::Value>` (the live column values) plus metadata
(table name, schema, RWK columns, audit flag):

```rust
pub struct BaseObject {
    pub data: HashMap<String, Value>,
    pub defaults: HashMap<String, Value>,
    pub domain_name: String,
    pub table_name: String,
    // ...
    pub rwk: Vec<String>,
}
```

Generated domain types are thin typed views over that map. For a `customer`
table the generator emits a `Customer` struct that holds a `BaseObject` and
exposes typed getters/setters that read and write the underlying dictionary:

```rust
pub struct Customer {
    pub base: BaseObject,
}

impl Customer {
    pub fn name(&self) -> String {
        self.base.get("name").as_str().unwrap_or_default().to_string()
    }
    pub fn set_name(&mut self, value: String) {
        self.base.set("name", serde_json::json!(value));
    }
    // ... one pair per column ...
}
```

Because the data lives in a `HashMap<String, Value>`, objects serialize to/from
JSON for free, flow across the API boundary unchanged, and can be handed to
scripts as object maps. Rust has no runtime reflection, so the .NET
`ColumnInfoAttribute` reflection is replaced by generated metadata: each type
provides `columns()` returning `Vec<ColumnInfo>`, which the persistence layer
uses to build SQL.

## Type mapping

Each column's PostgreSQL `DATA_TYPE` maps to a Rust type for the typed
accessors:

| PostgreSQL | .NET | Rust |
|-----------|------|------|
| `bigint` | `long` | `i64` |
| `integer` / `serial` | `int` | `i32` |
| `smallint` | `short` | `i16` |
| `boolean` | `bool` | `bool` |
| `real` | `float` | `f32` |
| `double precision` | `double` | `f64` |
| `numeric` | `decimal` | `rust_decimal::Decimal` |
| `date` / `timestamp` | `DateTime` | `chrono::NaiveDateTime` |
| `uuid` | `Guid` | `uuid::Uuid` |
| `varchar` / `text` | `string` | `String` |
| `bytea` | `byte[]` | `Vec<u8>` |

Temporal, decimal, and uuid values are stored in the backing map **as strings**
(ISO-8601 / decimal / canonical uuid), so they round-trip cleanly through JSON
and the typed accessors parse them on read.

## Partial classes -> generated + user modules

The .NET "generated + user partial class" convention becomes a pair of files
spliced into one Rust module. The crate root `include!`s both a regenerated
`<Obj>.generated.rs` (always overwritten, `FORCE=TRUE`) and a hand-editable
`<Obj>.user.rs` (created once, `FORCE=FALSE`) into the same module, so the user
file's `impl` block extends the generated type:

```rust
pub mod customer {
    include!("Customer.generated.rs");                       // gen/, regenerated
    include!("../../../usr/shared/domain/Customer.user.rs"); // usr/, your code
}
```

The same pattern applies in the `domain` and `logic` crates.

> **`gen/` vs `usr/`.** Files under `gen/` are regenerated on every run — never
> hand-edit them. Files under `usr/` are created once and never overwritten —
> that is where your customizations live. A corollary worth remembering:
> anything the *generated* code calls must be defined in *generated* code,
> because the generator cannot retroactively update an existing `usr/` file.

## Building

Each generated crate is an ordinary Cargo crate with a `makefile` wrapping
`cargo build` / `cargo run`. The shared libraries are path dependencies of the
servers and tests, so building a binary (e.g. `test-persist`) compiles the whole
chain.

Database connection details are read at runtime from `~/.<namespace>.json` by
the `common` `Config` loader (the same per-namespace config file the .NET
runtime uses).

## Continue

- [Logic & the dispatch model](logic-dispatch.md) — how interception,
  authorization, and the AOP pipeline work, and how to extend the model from
  `usr/` code.
- [Scripting with Rhai](scripting.md) — running database-stored scripts in
  process, the capabilities exposed to them, and sample calls.
