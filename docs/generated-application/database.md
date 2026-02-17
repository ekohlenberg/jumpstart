---
layout: default
title: Database
parent: Generated Application
nav_order: 1
---

# Database

Jumpstart generates complete database DDL scripts for both PostgreSQL and SQL Server.

## Naming Conventions

All database identifiers use **snake_case**:

| Element | Convention | Example |
|---------|-----------|---------|
| Schemas | lowercase | `app`, `core`, `sec`, `history` |
| Tables | snake_case | `principal_org`, `exec_log` |
| Columns | snake_case | `first_name`, `workflow_type_id` |
| Sequences | `{schema}_{table}_identity` | `app.customer_identity` |
| Indexes | `rwk_{schema}_{table}` | `rwk_app_customer` |
| Views | `{table}_view` | `customer_view` |
| History tables | `history.{schema}_{table}` | `history.app_customer` |

### Schemas

Generated applications use these database schemas:

| Schema | Purpose |
|--------|---------|
| `app` | Application domain tables (your business entities) |
| `core` | System framework tables (workflows, scripts, server nodes) |
| `sec` | Security tables (operations, roles, role members) |
| `history` | Audit trail tables (one per regular table) |

## Table Design

Every table follows a consistent structure:

```sql
CREATE TABLE app.customer (
    id BIGINT PRIMARY KEY,
    name VARCHAR(255),
    email VARCHAR(100),
    created_date TIMESTAMP,
    -- Global audit columns (auto-added):
    is_active INTEGER,
    created_by VARCHAR(50),
    last_updated TIMESTAMP,
    last_updated_by VARCHAR(50),
    version INTEGER
);
```

Key conventions:
- Every table has an `id` column as its primary key
- All audit columns are automatically added from `global.csv`
- Foreign key columns follow the pattern `{referenced_table}_id`

## Primary Keys

Every table uses a `BIGINT` primary key named `id`. The value is generated from a per-table sequence (not auto-increment), which allows the application to obtain the ID before the INSERT.

```sql
CREATE TABLE app.customer (
    id BIGINT PRIMARY KEY,
    ...
);
```

## Data Types

Jumpstart uses PostgreSQL as the canonical type system and maps to SQL Server equivalents:

| PostgreSQL | SQL Server | .NET | Description |
|-----------|-----------|------|-------------|
| `BIGINT` | `BIGINT` | `long` | 64-bit integer (PKs, FKs) |
| `INTEGER` | `INT` | `int` | 32-bit integer |
| `SMALLINT` | `SMALLINT` | `short` | 16-bit integer |
| `VARCHAR(n)` | `VARCHAR(n)` | `string` | Variable-length string |
| `TEXT` | `NVARCHAR(MAX)` | `string` | Unlimited text |
| `TIMESTAMP` | `DATETIME2` | `DateTime` | Date and time |
| `NUMERIC` | `DECIMAL(18,4)` | `decimal` | Fixed-point decimal |
| `BOOLEAN` | `BIT` | `bool` | True/false |
| `UUID` | `UNIQUEIDENTIFIER` | `Guid` | Globally unique identifier |
| `JSON` | `NVARCHAR(MAX)` | `string` | JSON data |

## Sequences

Each non-view table gets a dedicated identity sequence:

```sql
CREATE SEQUENCE app.customer_identity AS BIGINT START WITH 1000 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.customer_identity TO myapp;
```

The persistence layer calls `nextval()` (PostgreSQL) or equivalent to obtain the next ID before insert. Starting at 1000 reserves low IDs for seed/static data.

## Real World Keys (RWK)

Columns marked with `RWK=1` in the metadata CSV are **Real World Keys** -- the human-readable business identifiers for an entity. They serve multiple purposes:

1. **List views**: RWK columns are displayed in data tables and list pages
2. **Unique indexes**: All RWK columns form a composite unique index
3. **Enum display**: When a table is referenced as an `enum` FK, its RWK column provides the display name
4. **View synthesis**: RWK columns from referenced tables are automatically pulled into views

Example:
```csv
,app,customer,,,name,Name,,,,2,NULL,1,NO,VARCHAR,nvarchar,255
,app,customer,,,email,Email,,,,3,NULL,1,NO,VARCHAR,nvarchar,100
```

Both `name` and `email` have `RWK=1`, so they appear in list views and together form a unique constraint.

## Unique Index

A composite unique index is generated from all RWK columns on each table:

```sql
CREATE UNIQUE INDEX rwk_app_customer ON app.customer (name, email);
```

This ensures that the combination of business-meaningful columns is unique across the table.

## Foreign Keys

Jumpstart supports three types of foreign key relationships, each producing different generated behavior.

### Enum

Enum relationships reference static lookup tables. These are small tables with an `id` and a display `name`.

```csv
# Lookup table
,core,workflow_type,Workflow Type,,id,...
,core,workflow_type,,,name,Name,,,,2,NULL,1,NO,VARCHAR,...

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
- A **`/api/workflow/children/{id}?child=execlog`** endpoint
- **Tab** in the parent's edit page showing child records
- Topological ordering ensures parent DDL is generated before child DDL

### Map

Map relationships define many-to-many associations via junction tables.

```csv
,app,principal_org,,,org_id,Organization ID,map,org,...
,app,principal_org,,,principal_id,Principal ID,map,principal,...
```

Map FKs identify the junction table's composite key. The two `map` columns together form the unique constraint that prevents duplicate associations.

## Core Data Model

Jumpstart includes a built-in core data model in `templates/core/core.csv` that provides framework infrastructure:

### Application Tables (`app` schema)

| Table | Purpose |
|-------|---------|
| `org` | Organizations |
| `principal` | Users/principals (username, email, name) |
| `principal_org` | User-to-organization mapping (many-to-many) |

### Security Tables (`sec` schema)

| Table | Purpose |
|-------|---------|
| `principal_password` | Password hashes and expiry |
| `operation` | Named operations (objectname + methodname) |
| `op_role` | Authorization roles |
| `op_role_map` | Which operations belong to which roles |
| `op_role_member` | Which users belong to which roles |

### Core Framework Tables (`core` schema)

| Table | Purpose |
|-------|---------|
| `workflow` | Workflow definitions with type, schedule, server assignment |
| `process` | Individual process steps within workflows |
| `exec_log` | Execution history (start/end times, status) |
| `script` | Executable scripts (C#, PowerShell, Python source) |
| `event_service` | Event-driven script triggers (pre/post method hooks) |
| `schedule` | Scheduling configuration |
| `server_node` | Registered scheduler and agent instances |
| `nav_menu` | Navigation menu hierarchy (parent/child structure) |
| `data_source` | Named database connections |
| `sql` | Named SQL query templates |

### Lookup/Enum Tables

`exec_status`, `agent_status`, `on_failure`, `script_type`, `server_node_type`, `workflow_type`, `server_node_status`

## History Schema

Every regular (non-view) table has a corresponding audit table in the `history` schema:

```sql
CREATE SCHEMA history;

CREATE TABLE history.app_customer (
    id BIGINT PRIMARY KEY,
    customer_id BIGINT,          -- FK back to original record
    name VARCHAR(255),
    email VARCHAR(100),
    created_date TIMESTAMP,
    is_active INTEGER,
    created_by VARCHAR(50),
    last_updated TIMESTAMP,
    last_updated_by VARCHAR(50),
    version INTEGER
);
```

Key differences from the source table:
- The original `id` column is renamed to `{table}_id` (e.g., `customer_id`)
- The history table gets its own `id` primary key
- Every insert and update to the source table automatically writes a history record

The history log table is also created:

```sql
CREATE TABLE history.log (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    timestamp TIMESTAMPTZ NOT NULL,
    level TEXT NOT NULL,
    principalname TEXT NOT NULL,
    program TEXT NOT NULL,
    filepath TEXT NOT NULL,
    linenumber INTEGER NOT NULL,
    membername TEXT NOT NULL,
    message TEXT NOT NULL
);
```

This provides a complete audit trail for regulatory compliance, debugging, and change tracking.
