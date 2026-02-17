---
layout: default
title: Generator
nav_order: 4
---

# Generator

The Jumpstart generator reads CSV metadata, builds an in-memory model, and renders Razor templates to produce the application output.

## Pipeline

```
~/.jumpstart.json
       |
       v
 +-----+------+     +----------+     +----------+
 | CSVLoader   | --> | CoreLoader| --> |GlobalCSV |
 | (model.csv) |     |(core.csv)|     |(global.csv)|
 +-----+------+     +-----+----+     +-----+----+
       |                   |                |
       +-------------------+----------------+
                           |
                    +------v------+
                    |  MetaModel  |
                    |  .Process() |
                    +------+------+
                           |
                    +------v------+
                    | Generator   |
                    | (RazorLight)|
                    +------+------+
                           |
              +------------+------------+
              |            |            |
         model types  object types  build types
         (1 file)    (1 per table)  (1 file)
```

### Loading Sequence

1. **CSVLoader** reads your application's metadata CSV into `MetaModel`
2. **CoreLoader** reads `templates/core/core.csv`, adding built-in system tables
3. **GlobalCSVLoader** reads `templates/core/global.csv`, adding audit columns to every table
4. **MetaModel.Process()** resolves relationships:
   - `ProcessChildren()` -- finds parent FK references and registers child collections
   - `ProcessEnumObjects()` -- finds enum FK references and synthesizes display name columns
   - `ProcessView()` -- for `*_view` tables, builds JOIN structures and synthesizes RWK columns
5. **SortMetaObjectsByReference()** -- topological sort using Tarjan's SCC algorithm to ensure parent tables generate before children

### Generation Sequence

```
GenerateApp()       -->  model-type templates (one output file each)
GenerateSchemas()   -->  schema-type templates (one per database schema)
GenerateObjects()   -->  object-type templates (one per domain object)
GenerateBuild()     -->  build-type templates (build artifacts)
```

## Meta Model

The MetaModel is the in-memory representation of your application.

### Class Hierarchy

```
MetaBaseElement          (base: Name, FileName)
  |
  +-- MetaAttribute      (column definition)
  +-- MetaObject          (table/entity definition)
  +-- MetaSchema          (database schema grouping)
  +-- MetaModel           (root: all schemas, objects, relationships)
  +-- MetaBuild           (build output tracking)
```

### MetaModel

The root container for the entire application model.

| Property | Type | Description |
|----------|------|-------------|
| `Namespace` | `string` | Application namespace (from `TABLE_CATALOG`) |
| `Schemas` | `Dictionary<string, MetaSchema>` | All schemas by name |
| `Objects` | `List<MetaObject>` | Flat list of all tables |
| `NavMenus` | `Dictionary<string, List<MetaObject>>` | Objects grouped by nav menu |
| `GlobalAttributes` | `List<MetaAttribute>` | Audit columns from global.csv |
| `build` | `MetaBuild` | Output file tracking |

### MetaObject

Represents a single database table or view.

| Property | Type | Description |
|----------|------|-------------|
| `Namespace` | `string` | Parent namespace |
| `TableName` | `string` | Database table name (`customer`) |
| `DomainObj` | `string` | PascalCase class name (`Customer`) |
| `DomainVar` | `string` | Lowercase variable name (`customer`) |
| `DomainConst` | `string` | Uppercase constant (`CUSTOMER`) |
| `DomainObjView` | `string` | View class name (`CustomerView`) |
| `SchemaName` | `string` | Database schema (`app`, `core`, `sec`) |
| `Label` | `string` | Display label |
| `NavMenu` | `string` | Navigation menu group |
| `Uri` | `string` | Custom URL path (falls back to `DomainVar`) |
| `IsView` | `bool` | True if table name ends with `_view` |
| `Attributes` | `List<MetaAttribute>` | All columns |
| `UserAttributes` | `List<MetaAttribute>` | Non-global columns |
| `GlobalAttributes` | `List<MetaAttribute>` | Audit columns |
| `Children` | `List<ChildRelationship>` | Child table relationships |
| `EnumAttributes` | `List<EnumRelationship>` | Enum FK relationships |
| `ViewRelationships` | `List<ViewRelationship>` | JOIN structure for views |

### MetaAttribute

Represents a single column in a table.

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | Column name (`org_id`) |
| `PascalName` | `string` | PascalCase name (`OrgId`) |
| `Label` | `string` | Display label |
| `SqlDataType` | `string` | PostgreSQL type (`VARCHAR`, `BIGINT`) |
| `MSSQLDataType` | `string` | SQL Server equivalent |
| `DotNetType` | `string` | .NET type (`string`, `long`) |
| `InputType` | `string` | UI input type (`Text`, `Number`, `Date`) |
| `ConvertMethod` | `string` | Conversion method (`ToString`, `ToInt64`) |
| `Length` | `string` | Character length |
| `RWK` | `string` | Real World Key flag (`0` or `1`) |
| `IsNullable` | `bool` | Whether the column allows nulls |
| `FkType` | `string` | FK type: `enum`, `parent`, `map`, or empty |
| `FkTable` | `string` | Referenced table name |
| `FkObject` | `string` | Referenced PascalCase class name |
| `TestDataSet` | `string` | Test data seed name |

## Templates

### Template Types

| Type | Model Class | Execution | Description |
|------|------------|-----------|-------------|
| `model` | `MetaModel` | Once per application | Shared infrastructure, config files, project files |
| `schema` | `MetaSchema` | Once per schema | Schema-level DDL |
| `object` | `MetaObject` | Once per table/entity | Domain classes, controllers, logic, tests |
| `build` | `MetaBuild` | Once at end | Build scripts, solution files |

### Template Definition CSV

Template definitions are CSV files that declare which templates to run and where to write output:

```csv
COMMENT,TEMPLATE_TYPE,TEMPLATE_PATH,OUTPUT_DIR,FORCE
dotnet server templates-domain,object,shared/dotnet/domain/template.generated.cs.cshtml,./shared/domain,TRUE
dotnet server templates-domain,object,shared/dotnet/domain/template.user.cs.cshtml,./shared/domain,FALSE
```

| Column | Description |
|--------|-------------|
| `COMMENT` | Descriptive label (ignored by generator) |
| `TEMPLATE_TYPE` | `model`, `schema`, `object`, or `build` |
| `TEMPLATE_PATH` | Path to `.cshtml` template, relative to `templates/` |
| `OUTPUT_DIR` | Destination directory for generated files |
| `FORCE` | `TRUE` = always overwrite; `FALSE` = create only if missing |

### Filename Convention

Output filenames are derived from template filenames:

```
targetFile = templateFile.Replace("template", model.FileName).Replace(".cshtml", "")
```

Examples:

| Template File | Model | Output File |
|---------------|-------|-------------|
| `template.generated.cs.cshtml` | `Customer` | `Customer.generated.cs` |
| `templateLogic.generated.cs.cshtml` | `Order` | `OrderLogic.generated.cs` |
| `template.api.generated.cs.cshtml` | `Product` | `Product.api.generated.cs` |
| `Config.core.cs.cshtml` | (model) | `Config.core.cs` |
| `ListWorkflowCore.razor.cshtml` | (model) | `ListWorkflowCore.razor` |

Note: Files without "template" in their name keep their original name (minus `.cshtml`).

### FORCE Flag

The FORCE flag controls overwrite behavior:

- **FORCE=TRUE** -- File is always regenerated. Used for generated code that should never be hand-edited (e.g., `*.generated.cs`).
- **FORCE=FALSE** -- File is only created if it doesn't exist. Used for user-customizable files (e.g., `*.user.cs`, `appsettings.json`).

This pattern enables the **generated + user partial class** convention:
- `Customer.generated.cs` (FORCE=TRUE) -- regenerated every time
- `Customer.user.cs` (FORCE=FALSE) -- created once, then hand-editable

### Template Syntax

Templates use RazorLight, a Razor-based templating engine. Key syntax:

| Syntax | Meaning |
|--------|---------|
| `@Model.PropertyName` | Access model property |
| `@(Model.DomainObj)` | Parenthesized expression (avoids ambiguity) |
| `@@` | Escaped `@` in output (literal `@` sign) |
| `@foreach (var x in collection) { }` | Loop |
| `@if (condition) { }` | Conditional |
| `@{ var x = value; }` | Code block |
| `<text>...</text>` | Literal text output inside code blocks |

**Post-processing escapes** (handled by the generator after rendering):

| Template Syntax | Output |
|----------------|--------|
| `&at;` | `@` (for Blazor `@` directives) |
| `&lt;` | `<` |
| `&gt;` | `>` |

### Template Registries

#### server-dotnet.csv (Server Templates)

The server template registry defines ~100 templates across these layers:

| Layer | Key Templates | Type |
|-------|--------------|------|
| **Common** | Config, BaseObject, Logger, DatabaseProviders, ScriptHost | model |
| **Domain** | `template.generated.cs`, `template.user.cs` | object |
| **Domain Core** | Workflow, Execution, Script, ServerNode enums | model |
| **Persist** | DBPersist, persist.csproj | model |
| **Logic** | `templateLogic.generated.cs`, `templateLogic.user.cs` | object |
| **Logic Core** | BaseLogic, Proxy, Scheduler/Agent/Workflow logic | model |
| **API** | `template.api.generated.cs`, Program.cs, NotificationHub | object/model |
| **Scheduler** | scheduler.api.core.cs, Program.cs | model |
| **Agent** | agent.api.core.cs, Program.cs | model |
| **Tests** | test-persist, test-api, test-agent, test-scheduler | object/model |

#### web-blazor.csv (Web Templates)

| Layer | Key Templates | Type |
|-------|--------------|------|
| **Pages** | `Listtemplate.razor`, `Edittemplate.razor` | object |
| **Pages Core** | ListWorkflowCore.razor | model |
| **Components** | DataTable, DataTableContextMenu, TabControl | model |
| **Layout** | MainLayout, NavMenuLayout | model |
| **Root** | App.razor, _Imports.razor, Program.cs | model |
| **Assets** | index.html, CSS, Bootstrap | model |

#### database-pgsql.csv / database-mssql.csv (Database Templates)

| Layer | Key Templates | Type |
|-------|--------------|------|
| **DDL** | table, sequence, rwkindex, view, audit, schema | model/object |
| **Data** | static data, nav_menu, admin, queries | model |

## Relationship Processing

### ProcessChildren

For each MetaObject, scans all attributes for `FK_TYPE="parent"`:

```
exec_log.workflow_id (FK_TYPE=parent, FK_TABLE=workflow)
  --> workflow.Children.Add(new ChildRelationship("workflow", "Execution Log", exec_log))
```

This enables the API's `/api/workflow/children/{id}?child=execlog` endpoint.

### ProcessEnumObjects

For each `FK_TYPE="enum"` attribute, finds the referenced table's RWK column and synthesizes a name column:

```
workflow.workflow_type_id (FK_TYPE=enum, FK_TABLE=workflow_type)
  --> workflow_type has RWK column "name"
  --> Synthesizes "workflow_type_name" on WorkflowView
```

### ProcessView

For `*_view` tables, recursively follows FK chains to build JOIN structures:

```
customer_view has FK to customer
  customer has FK org_id -> org
    org has RWK column "name"
  --> Synthesizes customer_view.org_name
  --> Generates LEFT OUTER JOIN org ON customer.org_id = org.id
```

## Topological Sort

The generator uses **Tarjan's strongly connected components** algorithm to sort MetaObjects by dependency order. This ensures parent tables are generated before their children, which matters for:

- Database DDL (CREATE TABLE order)
- Static data loading (parent records inserted before child records)
- Test data that respects referential integrity
