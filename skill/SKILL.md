---
name: jumpstart
description: Generate full-stack applications (PostgreSQL/SQL Server + .NET 9 API + Blazor WASM) from a CSV metadata specification using the Jumpstart code generator. Use when the user wants to scaffold a new data-driven app, add tables/entities to an existing Jumpstart model, or understand/extend a Jumpstart-generated project.
---

# Jumpstart Code Generator

Jumpstart turns a CSV metadata file describing your data model into a complete
application: PostgreSQL/SQL Server DDL, a .NET 9 REST API, business logic and
persistence layers, a Blazor WebAssembly frontend, and test suites.

## When to use this skill

- The user wants to scaffold a new app from a data model ("generate a CRM",
  "create an app with Customer and Order tables", etc.)
- The user wants to add a table/entity to an existing Jumpstart `model.csv`
- The user wants to regenerate an app after editing the metadata
- The user is asking about the structure of a Jumpstart-generated app

## Workflow

### 1. Build or confirm the metadata CSV

Each row describes one column of one table. Help the user design their schema,
then write it as `model.csv`. Key rules:

- First row of each table sets `TABLE_CATALOG` (app namespace, set once for
  the whole file), `TABLE_SCHEMA` (`app`, `core`, or `sec`), `TABLE_NAME`
  (snake_case), `TABLE_LABEL` (display name), `NAV_MENU` (sidebar group).
- Every table needs an `id BIGINT` primary key as its first column.
- Subsequent rows for the same table only need `COLUMN_NAME` + column fields.
- `RWK=1` marks "real world key" columns shown in list views and used for
  unique indexes (e.g., a customer's name or email).
- `FK_TYPE` controls relationships:
  - `enum` — dropdown to a lookup table (`FK_TABLE` = lookup table name)
  - `parent` — one-to-many hierarchy (child tab on parent's edit page)
  - `map` — many-to-many junction table
- Tables named `*_view` become SQL views with auto-joined display columns.
- Don't redefine audit columns (`is_active`, `created_by`, `last_updated`,
  `last_updated_by`, `version`) or core system tables (`org`, `principal`,
  `workflow`, etc.) — these are merged in automatically.

CSV header (full column list):
```
TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_LABEL,NAV_MENU,COLUMN_NAME,COLUMN_LABEL,FK_TYPE,FK_TABLE,TEST_DATA_SET,ORDINAL_POSITION,COLUMN_DEFAULT,RWK,IS_NULLABLE,DATA_TYPE,MSSQL_DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,URI
```

For full details, syntax, and examples, read the reference docs in this repo:
- `docs/getting-started.md` — quick start, config file, output structure
- `docs/metadata.md` — complete CSV column reference and relationship types
- `docs/generator.md` — how the generator/templates work internally

### 2. Configure `~/.jumpstart.json`

```json
{
  "modelpath": "~/projects/myapp/model.csv",
  "templatedefs": ["server-dotnet", "web-blazor", "database-pgsql"]
}
```

Use `database-mssql` instead of `database-pgsql` for SQL Server. Drop
`web-blazor` and/or `server-dotnet` if the user only wants a subset.

### 3. Build and run the generator

```bash
cd src
dotnet build
./jumpstart                      # uses ~/.jumpstart.json
# or
./jumpstart model.csv server-dotnet web-blazor database-pgsql --output ./my-app
```

### 4. Explain / verify the output

Generated layout:
```
database/{ddl,data}/
server/{api,logic,persist,scheduler,agent,test-*}/
shared/{common,domain}/
web/{Pages,Components,Layout,wwwroot}/
```

`*.generated.cs` files are always overwritten on regen; `*.user.cs` files are
created once and safe to hand-edit (generated + user partial class pattern).

After generating, run `dotnet build` on `server/server.sln` and `web/` to
confirm the output compiles before handing it back to the user.

## Notes

- Requires the .NET 9 SDK to build the generator and the generated app.
- PostgreSQL 15+ or SQL Server 2019+ is needed to actually run the generated
  app (DDL scripts are in `database/ddl`).
- When adding to an existing model, append rows to `model.csv` rather than
  rewriting it, and re-run the generator — it's idempotent for `*.generated.*`
  files.
</content>
