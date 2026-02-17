---
layout: default
title: Metadata Specification
nav_order: 3
---

# Metadata Specification

Jumpstart applications are defined by CSV metadata files. Each row describes a single column in a database table. The generator reads these rows, builds an in-memory model, and generates the full application stack.

## CSV Column Reference

| Column | Required | Description |
|--------|----------|-------------|
| `TABLE_CATALOG` | First row | Application namespace (e.g., `myapp`). Set on the first row of the first table. |
| `TABLE_SCHEMA` | First row | Database schema name: `app`, `core`, `sec` |
| `TABLE_NAME` | First row | Table name in snake_case (e.g., `customer`, `order_item`) |
| `TABLE_LABEL` | First row | Display name for UI (e.g., `Customer`, `Order Items`) |
| `NAV_MENU` | First row | Navigation menu group (e.g., `Admin`, `Sales`, `System`) |
| `COLUMN_NAME` | Yes | Column name in snake_case (e.g., `id`, `first_name`, `org_id`) |
| `COLUMN_LABEL` | Yes | Display label for the column (e.g., `First Name`) |
| `FK_TYPE` | No | Foreign key type: `enum`, `parent`, `map`, or empty |
| `FK_TABLE` | No | Referenced table name (when FK_TYPE is set) |
| `TEST_DATA_SET` | No | Test data group name for seeding (e.g., `companies`, `emailAddresses`) |
| `ORDINAL_POSITION` | No | Display order of the column |
| `COLUMN_DEFAULT` | No | SQL default value (e.g., `NULL`, `(getdate())`) |
| `RWK` | Yes | Real World Key flag: `0` or `1`. Columns with `1` appear in list views and form a unique index. |
| `IS_NULLABLE` | Yes | `YES`/`NO` or `1`/`0` |
| `DATA_TYPE` | Yes | PostgreSQL data type (e.g., `BIGINT`, `VARCHAR`, `TIMESTAMP`) |
| `MSSQL_DATA_TYPE` | No | SQL Server equivalent (e.g., `bigint`, `nvarchar`, `datetime`) |
| `CHARACTER_MAXIMUM_LENGTH` | No | String length (e.g., `255`, `50`) |
| `URI` | No | Custom URL path for routing (e.g., `core/workflow`) |

## Table Definition Pattern

Each table is defined by multiple rows. The first row carries the table-level metadata:

```csv
TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_LABEL,NAV_MENU,COLUMN_NAME,...
myapp,app,customer,Customer,Sales,id,...
myapp,app,customer,,,name,...
myapp,app,customer,,,email,...
```

- Row 1: Sets `TABLE_CATALOG`, `TABLE_SCHEMA`, `TABLE_NAME`, `TABLE_LABEL`, and `NAV_MENU`
- Row 2+: Only `COLUMN_NAME` and column-level fields are needed (table fields are inherited)

Every table must have an `id` column of type `BIGINT` as its primary key.

## Foreign Key Types

### Enum (Lookup Tables)

Enum relationships reference static lookup tables. The generator synthesizes a display name column from the referenced table's RWK column.

```csv
# Lookup table definition
,core,workflow_type,Workflow Type,,id,Workflow Type ID,,,,1,NULL,0,NO,BIGINT,bigint,NULL
,core,workflow_type,,,name,Name,,,,2,NULL,1,NO,VARCHAR,nvarchar,255

# Referencing column
,core,workflow,,,workflow_type_id,Workflow Type,enum,workflow_type,,4,1,1,NO,BIGINT,bigint,NULL
```

The generator:
1. Finds `workflow_type`'s RWK column (`name`)
2. Synthesizes a `workflow_type_name` column on the view
3. Generates a dropdown/select control in edit forms
4. Provides an `/api/workflowtype/enum` endpoint returning id-name pairs

### Parent (Hierarchical Relationships)

Parent relationships define one-to-many hierarchies. The child table has a foreign key to the parent.

```csv
# Child table with parent FK
,core,exec_log,,,workflow_id,Workflow ID,parent,workflow,,2,NULL,1,NO,BIGINT,bigint,NULL
```

The generator:
1. Registers `exec_log` as a child of `workflow`
2. Generates a `/api/workflow/children/{id}?child=execlog` endpoint
3. Displays child records in tabs on the parent's edit page

### Map (Junction/Many-to-Many)

Map relationships define junction tables for many-to-many associations.

```csv
# Junction table
,app,principal_org,Principals,,id,Principal Org ID,,,,1,NULL,0,YES,BIGINT,bigint,NULL
,app,principal_org,,,org_id,Organization ID,map,org,,1,NULL,1,YES,BIGINT,bigint,NULL
,app,principal_org,,,principal_id,Principal ID,map,principal,,2,NULL,1,YES,BIGINT,bigint,NULL
```

Map FKs are used to generate:
1. Composite unique indexes on the mapping columns
2. Navigation between related entities in the UI

## Core CSV

Jumpstart includes `templates/core/core.csv` which defines built-in system tables. These are automatically merged with your application model:

| Schema | Table | Purpose |
|--------|-------|---------|
| `app` | `org` | Organizations |
| `app` | `principal` | Users/principals |
| `app` | `principal_org` | User-to-org mapping |
| `sec` | `principal_password` | Password credentials |
| `sec` | `operation` | Permissioned operations |
| `sec` | `op_role` | Authorization roles |
| `sec` | `op_role_map` | Operation-to-role mapping |
| `sec` | `op_role_member` | Role membership |
| `core` | `script` | Executable scripts (C#, PowerShell, Python) |
| `core` | `event_service` | Event-driven script triggers |
| `core` | `workflow` | Workflow definitions |
| `core` | `exec_log` | Execution history |
| `core` | `process` | Process definitions |
| `core` | `schedule` | Scheduling configuration |
| `core` | `server_node` | Registered server nodes |
| `core` | `nav_menu` | Navigation menu structure |
| `core` | `data_source` | Database connection definitions |
| `core` | `sql` | Named SQL queries |

Static lookup tables (enums):
`exec_status`, `agent_status`, `on_failure`, `script_type`, `server_node_type`, `workflow_type`, `server_node_status`

## Global CSV (Audit Columns)

`templates/core/global.csv` defines columns automatically added to every non-view table:

| Column | Type | Description |
|--------|------|-------------|
| `is_active` | `integer` | Soft delete flag (1=active, 0=deleted) |
| `created_by` | `varchar(50)` | Username who created the record |
| `last_updated` | `timestamp` | Last modification timestamp |
| `last_updated_by` | `varchar(50)` | Username who last modified |
| `version` | `integer` | Optimistic concurrency version |

These columns are managed automatically by the persistence layer on insert and update operations.

## Type Mapping

### PostgreSQL to .NET

| PostgreSQL | .NET Type | Convert Method |
|-----------|-----------|---------------|
| `integer` | `int` | `Convert.ToInt32` |
| `bigint` | `long` | `Convert.ToInt64` |
| `smallint` | `short` | `Convert.ToInt16` |
| `boolean` | `bool` | `Convert.ToBoolean` |
| `varchar` | `string` | `Convert.ToString` |
| `text` | `string` | `Convert.ToString` |
| `date` | `DateTime` | `Convert.ToDateTime` |
| `timestamp` | `DateTime` | `Convert.ToDateTime` |
| `numeric` | `decimal` | `Convert.ToDecimal` |
| `uuid` | `Guid` | `Guid.Parse` |
| `bytea` | `byte[]` | -- |
| `json` | `string` | -- |

### PostgreSQL to SQL Server

| PostgreSQL | SQL Server |
|-----------|-----------|
| `integer` | `INT` |
| `bigint` | `BIGINT` |
| `smallint` | `SMALLINT` |
| `serial` | `INT IDENTITY(1,1)` |
| `varchar` | `VARCHAR` |
| `text` | `NVARCHAR(MAX)` |
| `timestamp` | `DATETIME2` |
| `numeric` | `DECIMAL` |
| `boolean` | `BIT` |
| `uuid` | `UNIQUEIDENTIFIER` |
| `json` | `NVARCHAR(MAX)` |

### PostgreSQL to UI Input Type

| PostgreSQL | Input Control |
|-----------|--------------|
| `integer`, `bigint`, `numeric` | Number |
| `boolean` | Radio |
| `varchar`, `char` | Text |
| `text` | TextArea |
| `date`, `timestamp` | Date |

## Views

Tables ending with `_view` are treated as SQL views. The generator:

1. Identifies all FK columns in the view definition
2. Recursively follows FKs to gather RWK columns from referenced tables
3. Synthesizes display columns (e.g., `org_name` from `org.name`)
4. Generates a `CREATE VIEW` with `LEFT OUTER JOIN` clauses
5. Creates a corresponding `View` domain class

Views are used for list pages and API response DTOs that include human-readable display values for foreign key references.

## URI Field

The optional `URI` column allows custom URL paths for navigation and routing. When specified, it overrides the default URL (which uses the lowercase domain object name).

```csv
# In core.csv, the workflow table specifies a custom URI
,core,workflow,...,URI
...                ,core/workflow
```

This causes:
- Navigation menu entries to link to `/core/workflow` instead of `/workflow`
- The MetaObject's `Uri` property to return `core/workflow`

If `URI` is not specified, the MetaObject's `Uri` property falls back to `DomainVar` (the lowercase domain object name).

App-specific CSVs do not need to include the `URI` column -- the generator handles missing fields gracefully.
