---
layout: default
title: Database
parent: Generated Application
nav_order: 1
---

# Database

Jumpstart generates complete database DDL scripts for both PostgreSQL and SQL Server. The design is identical regardless of which backend (.NET or Rust) consumes it.

## Naming Conventions

All database identifiers use **snake_case**:

| Element | Convention | Example |
|---------|-----------|---------|
| Schemas | lowercase | `app`, `core`, `sec` |
| Tables | snake_case | `principal_org`, `exec_log` |
| Columns | snake_case | `first_name`, `workflow_type_id` |
| Sequences | `{schema}.{table}_identity` | `app.customer_identity` |
| Indexes | `rwk_{schema}_{table}` | `rwk_app_customer` |
| Views | `{table}_view` | `customer_view` |

### Schemas

| Schema | Purpose |
|--------|---------|
| `app` | Application domain tables (your business entities) |
| `core` | Framework tables: users, security, workflows, scripts, server nodes, log |

Schemas come from the metadata's `TABLE_SCHEMA` column, so your model can define additional schemas.

## Table Design

Every table follows a consistent structure:

```sql
CREATE TABLE app.customer (
    id BIGINT,
    name VARCHAR(255),
    email VARCHAR(100),
    created_date TIMESTAMP,
    -- Global columns (auto-added from global.csv):
    is_active INTEGER,
    created_by VARCHAR(50),
    last_updated TIMESTAMP,
    last_updated_by VARCHAR(50),
    txn_id BIGINT PRIMARY KEY
);
CREATE INDEX ON app.customer (id, is_active);
```

Key conventions:
- Every table has an `id` column identifying the *logical record*
- `txn_id` identifies the *row version* and is the physical primary key of audited tables
- Global columns are automatically added from `global.csv`
- Foreign key columns follow the pattern `{referenced_table}_id`

## Audited Tables and Row-Versioning

Tables marked `IS_AUDITED=1` in the metadata keep their full history **in place** — there is no separate audit store. The persistence layer implements this in both backends (`DBPersistAudit` in .NET, `db_persist_audit` in Rust):

- **Insert** — assigns a fresh identity value used as both `id` and `txn_id`, stamps the audit columns, and inserts with `is_active=1`.
- **Update** — marks the current row `is_active=0`, then inserts a **new row** with the same `id`, a fresh `txn_id`, and updated audit columns.
- **History** — `SELECT ... WHERE id = ? ORDER BY txn_id DESC` returns every version of the record, newest first. This backs the `/api/{entity}/{id}/history` endpoint and the History tab in the UI.
- **Current version** — reads filter on `is_active=1`; the `(id, is_active)` index keeps this fast.

Because `id` is not unique on an audited table, idempotent seed scripts must use `ON CONFLICT (txn_id)` — not `(id)`.

Tables marked `IS_AUDITED=0` are simple: `insert` and `update` behave conventionally (update-in-place), via the basic persistence strategy.

A third strategy, **import**, is used only by the generated `import` tool: it preserves pre-assigned `id`/`txn_id` values from the data files instead of minting new ones, so foreign key references baked into seed CSVs stay valid. See [Testing & Tools](../testing.md).

## Primary Keys and Sequences

Identity values come from a per-table sequence (not auto-increment), which lets the application obtain the ID before the INSERT:

```sql
CREATE SEQUENCE app.customer_identity AS BIGINT START WITH 1000 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.customer_identity TO myapp;
```

Sequences start at 1000: IDs below 1000 are reserved for seed/static data, so generated lookup rows never collide with runtime inserts.

## Data Types

Jumpstart uses PostgreSQL as the canonical type system and maps to SQL Server and both language targets:

| PostgreSQL | SQL Server | .NET | Rust | Description |
|-----------|-----------|------|------|-------------|
| `BIGINT` | `BIGINT` | `long` | `i64` | 64-bit integer (ids, FKs) |
| `INTEGER` | `INT` | `int` | `i32` | 32-bit integer |
| `SMALLINT` | `SMALLINT` | `short` | `i16` | 16-bit integer |
| `VARCHAR(n)` | `VARCHAR(n)` | `string` | `String` | Variable-length string |
| `TEXT` | `NVARCHAR(MAX)` | `string` | `String` | Unlimited text |
| `TIMESTAMP` | `DATETIME2` | `DateTime` | `chrono::NaiveDateTime` | Date and time |
| `NUMERIC` | `DECIMAL(18,4)` | `decimal` | `rust_decimal::Decimal` | Fixed-point decimal |
| `BOOLEAN` | `BIT` | `bool` | `bool` | True/false |
| `UUID` | `UNIQUEIDENTIFIER` | `Guid` | `uuid::Uuid` | Globally unique identifier |
| `JSON` | `NVARCHAR(MAX)` | `string` | `String` | JSON data |

## Real World Keys (RWK)

Columns marked with `RWK=1` in the metadata CSV are **Real World Keys** -- the human-readable business identifiers for an entity. They serve multiple purposes:

1. **List views**: RWK columns are displayed in data tables and list pages
2. **Unique indexes**: All RWK columns form a composite unique index
3. **Enum display**: When a table is referenced as an `enum` FK, its RWK column provides the display name
4. **View synthesis**: RWK columns from referenced tables are automatically pulled into views

```sql
CREATE UNIQUE INDEX rwk_app_customer ON app.customer (name, email);
```

## Foreign Keys

Jumpstart supports three types of foreign key relationships, each producing different generated behavior.

### Enum

Enum relationships reference static lookup tables (small tables with an `id` and a display `name`).

```csv
# FK reference
,core,workflow,,,workflow_type_id,Workflow Type,enum,workflow_type,...
```

What gets generated:
- A **synthesized name column** (`workflow_type_name`) on the view
- A **dropdown/select** control in edit forms
- An **`/api/workflowtype/enum`** endpoint returning `[{id, rwkString}]`
- **JOIN** in the view to resolve the display name

### Parent

Parent relationships define one-to-many hierarchies where a child record belongs to a parent.

```csv
,core,exec_log,,,workflow_id,Workflow ID,parent,workflow,...
```

What gets generated:
- The parent object (`Workflow`) gains a `Children` collection containing `ExecLog`
- A **children endpoint** on the parent's API
- **Tab** in the parent's edit page showing child records
- Topological ordering ensures parent DDL is generated before child DDL

### Map

Map relationships define many-to-many associations via junction tables.

```csv
,core,principal_org,,,org_id,Organization ID,map,org,...
,core,principal_org,,,principal_id,Principal ID,map,principal,...
```

Map FKs identify the junction table's composite key. The two `map` columns together form the unique constraint that prevents duplicate associations.

## Core Data Model

Jumpstart includes a built-in core data model in `templates/core/core.csv` that provides framework infrastructure:

All core tables live in the `core` schema.

### Users & Security

| Table | Purpose |
|-------|---------|
| `org` | Organizations |
| `principal` | Users/principals (username, email, name) |
| `principal_org` | User-to-organization mapping (many-to-many) |
| `operation` | Named operations (objectname + methodname) |
| `op_role` | Authorization roles |
| `op_role_map` | Which operations belong to which roles |
| `op_role_member` | Which users belong to which roles |

### Workflow & Framework

| Table | Purpose |
|-------|---------|
| `workflow` | Workflow definitions with type, schedule, server assignment |
| `process` | Individual process steps within workflows |
| `exec_log` | Execution history (start/end times, status) |
| `script` | Executable scripts (source + script type) |
| `event_service` | Event-driven script triggers (pre/post method hooks) |
| `schedule` | Scheduling configuration (references the `cron_*` component tables) |
| `server_node` | Registered API server, scheduler, and agent instances |
| `nav_menu` | Navigation menu hierarchy (parent/child structure) |
| `data_source` | Named database connections |
| `sql` | Named SQL query templates (including the generated get/select/history queries) |
| `log` | Database log sink for the `database` log writer (created by the monolithic database-create script) |

### Lookup/Enum Tables

`exec_status`, `agent_status`, `on_failure`, `script_type`, `server_node_type`, `server_node_status`, `workflow_type`, and the cron component lookups: `cron_minute`, `cron_hour`, `cron_dom`, `cron_month`, `cron_dow`, `cron_every`

## Build and Load Scripts

The `database-*` template definitions also generate build tooling into `gen/database/`:

- **`ddl/build.sh` / `build.py` / `build.ps1`** — create the database, schemas, tables, sequences, indexes, and views. The monolithic `<namespace>.database.create.generated.sql` is what actually creates the core schema tables (including `core.log`); the per-table files cover only your application tables.
- **`data/load.sh` / `load.py`** — load generated seed data: static lookup rows, navigation menus, the current user's admin bootstrap, and named queries.
- **Hand-written seed data** belongs in `usr/database/data` with its own `load-usr.sh` — the generated loader only loads generated files. Wire it into your project makefile (see `jumptest/rust-pg/makefile`, targets `database` and `seed`).

Connection parameters for all scripts come from `~/.<namespace>.json`.
