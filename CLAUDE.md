# Jumpstart — CLAUDE.md

## Project Overview

Jumpstart is a **code generation framework** written in C# (.NET 9). It reads CSV-based metadata describing a data model and uses Razor templates to generate a complete application stack: PostgreSQL/SQL Server DDL, a .NET REST API, domain models, and a Blazor WebAssembly frontend.

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Generator | C# / .NET 9 console app |
| Templating | RazorLight 2.3.1 |
| CSV parsing | CsvHelper 33.0.1 |
| Target DB | PostgreSQL 15+ or SQL Server 2019+ |
| Target frontend | Blazor WebAssembly |
| Build | dotnet CLI + make (Unix) / build.cmd (Windows) |

## Repository Structure

```
src/                  # Generator source code (.NET 9)
  Program.cs          # Entry point: arg parsing, orchestration
  metamodel.cs        # Core metadata classes (MetaModel, MetaSchema, MetaObject, MetaAttribute, …)
  generator.cs        # RazorLight engine: compiles templates → files
  csvloader.cs        # Parses user-supplied model CSV into MetadataRecord objects
  coreloader.cs       # Loads core.csv (built-in columns/objects)
  globalcsvloader.cs  # Loads global.csv (columns added to every object)
  templatedefloader.cs# Loads template definition CSVs
  JumpStartParams.cs  # Config model for ~/.jumpstart.json
  jumpstart.csproj
templates/            # Razor (.cshtml) templates + CSV template definitions
  core/               # core.csv, global.csv
  database/pgsql/     # PostgreSQL DDL/DML templates
  database/mssql/     # SQL Server DDL/DML templates
  server/             # .NET API, domain, persist, logic layer templates
  shared/dotnet/      # Common base classes and domain entities
  web/blazor/         # Blazor WebAssembly templates
  *.csv               # Template definition files (database-pgsql, server-dotnet, web-blazor, …)
docs/                 # Jekyll documentation site
```

## Build

```bash
cd src
make          # build + copy templates to bin/
# or
dotnet build
```

Windows: use `build.cmd` from the repo root.

Build output lands in `src/bin/Debug/net9.0/`. The `templates/` directory is copied there automatically post-build.

## Running the Generator

```bash
# Pass model CSV and template sets on the command line:
dotnet run --project src/jumpstart.csproj -- path/to/model.csv database-pgsql server-dotnet web-blazor

# Or configure ~/.jumpstart.json and run with no args:
dotnet run --project src/jumpstart.csproj
```

`~/.jumpstart.json` format:
```json
{
  "modelpath": "path/to/model.csv",
  "templatedefs": ["database-pgsql", "server-dotnet", "web-blazor"]
}
```

## Code Generation Pipeline

1. Parse user model CSV → `MetadataRecord` objects (`csvloader.cs`)
2. Load `core.csv` (built-in objects/columns) and `global.csv` (columns added to every object)
3. Populate `MetaModel` hierarchy and call `MetaModel.Process()` for validation/enrichment
4. Load template definitions from the selected `*.csv` files
5. For each template definition: compile Razor template with RazorLight, pass the `MetaModel` (or `MetaSchema`/`MetaObject`), write output file
6. A `FileWriteEvent` is fired for each generated file; `FORCE` flag in the template definition controls overwrite behavior

## Metadata Object Model

```
MetaModel          — entire application
  MetaSchema[]     — database schema grouping
    MetaObject[]   — table / entity
      MetaAttribute[] — column / property
      ChildRelationship[]
      EnumRelationship[]
      ViewRelationship[]
```

All classes inherit from `MetaBaseElement`.

## Key Conventions

- **Type mapping** lives in large dictionaries in `metamodel.cs`: DB type → C# type, DB type → conversion method (`ToInt32`, etc.), DB type → HTML input type.
- **Template scope** is declared in the template definition CSV: `MetaModel`, `MetaSchema`, `MetaObject`, or `MetaBuild`. The generator iterates appropriately.
- **No test suite** exists yet. Validate changes by running a generation and inspecting output.
- **No CI/CD** configuration is present.

## Development Notes

- The generator is a CLI tool — there is no dev server to start.
- After editing `metamodel.cs` or loader code, rebuild with `make` or `dotnet build`.
- After editing Razor templates under `templates/`, rebuild (post-build step copies them) or copy the changed file manually to `bin/`.
- Use Unix shell syntax in this repo even on Windows (Cygwin environment).
