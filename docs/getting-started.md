---
layout: default
title: Getting Started
nav_order: 2
---

# Getting Started

## Prerequisites

- **.NET 9 SDK** -- [Download](https://dotnet.microsoft.com/download)
- **PostgreSQL 15+** or **SQL Server 2019+**
- **Git** -- [Download](https://git-scm.com/downloads)

## Installation

### Clone and Build

```bash
git clone https://github.com/your-org/jumpstart.git
cd jumpstart/src
dotnet build
```

The build produces the `jumpstart` executable along with the `templates/` directory.

## Configuration

### ~/.jumpstart.json

Jumpstart reads its configuration from `~/.jumpstart.json` in your home directory:

```json
{
  "modelpath": "~/projects/myapp/model.csv",
  "templatedefs": ["server-dotnet", "web-blazor", "database-pgsql"]
}
```

| Field | Description |
|-------|-------------|
| `modelpath` | Path to your application's metadata CSV file (supports `~` expansion) |
| `templatedefs` | Array of template definition names to generate |

Available template definitions:
- `server-dotnet` -- .NET backend (API, logic, persist, tests, scheduler, agent)
- `web-blazor` -- Blazor WebAssembly frontend
- `database-pgsql` -- PostgreSQL DDL and data scripts
- `database-mssql` -- SQL Server DDL and data scripts

## Creating a Metadata CSV

Your application model is defined in a CSV file. Each row describes a column in a table. Here is a minimal example:

```csv
TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_LABEL,NAV_MENU,COLUMN_NAME,COLUMN_LABEL,FK_TYPE,FK_TABLE,TEST_DATA_SET,ORDINAL_POSITION,COLUMN_DEFAULT,RWK,IS_NULLABLE,DATA_TYPE,MSSQL_DATA_TYPE,CHARACTER_MAXIMUM_LENGTH
myapp,app,customer,Customer,Sales,id,Customer ID,,,companies,1,NULL,0,NO,BIGINT,bigint,NULL
myapp,app,customer,,,name,Name,,,companies,2,NULL,1,NO,VARCHAR,nvarchar,255
myapp,app,customer,,,email,Email,,,emailAddresses,3,NULL,1,NO,VARCHAR,nvarchar,100
myapp,app,customer,,,created_date,Created,,,,4,(getdate()),0,YES,TIMESTAMP,datetime,NULL
```

Key points:
- `TABLE_CATALOG` is set on the first row of each table and becomes the application namespace
- `TABLE_SCHEMA` groups tables into database schemas (e.g., `app`, `core`, `sec`)
- `TABLE_LABEL` and `NAV_MENU` are set on the first row of each table
- Subsequent rows for the same table only need `COLUMN_NAME` and its properties
- `RWK=1` marks columns as "Real World Keys" -- displayed in list views and used for unique indexes

See the [Metadata Specification](metadata.md) for the complete column reference.

## Running the Generator

### Using ~/.jumpstart.json (recommended)

```bash
jumpstart
```

### Using command-line arguments

```bash
jumpstart model.csv server-dotnet
```

The generator will:
1. Load your metadata CSV and merge it with `core.csv` (built-in system tables)
2. Add global audit columns from `global.csv`
3. Process relationships (parent, enum, map, views)
4. Generate output files for each template definition

## Generated Output Structure

```
./
├── database/
│   ├── ddl/              # CREATE TABLE, sequences, indexes, views
│   └── data/             # Seed data, navigation menus, static lookups
├── server/
│   ├── api/              # REST API controllers
│   ├── logic/            # Business logic layer
│   ├── persist/          # Data access layer
│   ├── scheduler/        # Workflow scheduler service
│   ├── agent/            # Script execution agent
│   └── server.sln        # Solution file
├── shared/
│   ├── common/           # Utilities, config, database providers
│   └── domain/           # Domain model classes
├── test/
│   ├── test-api/         # API integration tests
│   ├── test-persist/     # Persistence tests
│   ├── test-scheduler/   # Scheduler tests
│   └── test-agent/       # Agent tests
└── web/
    ├── Pages/            # List and Edit pages per domain object
    ├── Components/       # DataTable, TabControl, etc.
    ├── Layout/           # MainLayout, NavMenuLayout
    └── wwwroot/          # Static assets (HTML, CSS, JS)
```

## Running the Generated Application

### 1. Create the Database

```bash
cd database/ddl
# Run the build script for your database
./build.sh        # PostgreSQL
./build.ps1       # SQL Server

cd ../data
./load.sh         # Load seed data
```

### 2. Start the API Server

```bash
cd server/api
dotnet run
```

The API server starts on the configured port (default: 5200).

### 3. Start the Web Frontend

```bash
cd web
dotnet run
```

The Blazor WebAssembly app starts and connects to the API server.

### 4. (Optional) Start the Scheduler and Agent

```bash
# In separate terminals:
cd server/scheduler
dotnet run

cd server/agent
dotnet run
```

The scheduler binds to ports 5000-5100; agents bind to ports 5100-5200. Both register themselves as `ServerNode` entries in the database.

## Application Settings

The generated `appsettings.json` configures the runtime:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "appsettings": {
    "logwriters": "MyApp.LogFileWriter,MyApp.LogConsoleWriter",
    "loglevel": "debug",
    "db.type": "pgsql"
  }
}
```

| Setting | Description |
|---------|-------------|
| `db.type` | Database provider: `pgsql` or `mssql` |
| `logwriters` | Comma-separated log writer classes |
| `loglevel` | Logging level: `debug`, `info`, `warning`, `error` |

## Running Tests

```bash
# API integration tests
cd test/test-api
dotnet test

# Persistence layer tests
cd test/test-persist
dotnet test
```

## Next Steps

- [Metadata Specification](metadata.md) -- Full CSV column reference and relationship types
- [Generator](generator.md) -- How the code generator processes templates
- [Generated Application](generated-application/) -- Detailed documentation of each generated layer
