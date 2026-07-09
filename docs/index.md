---
layout: default
title: Home
nav_order: 1
---

# Jumpstart Documentation

**Jumpstart** is a metadata-driven code generation framework that transforms CSV metadata specifications into complete, production-ready full-stack applications — in your choice of backend (.NET or Rust) and frontend (Blazor or React).

## Architecture Overview

```
                         +------------------+
                         |   Metadata CSV   |
                         |   (your model)   |
                         +--------+---------+
                                  |
                         +--------v---------+
                         |    Generator     |
                         |   (RazorLight)   |
                         +--------+---------+
                                  |
            +---------------------+---------------------+
            |                     |                     |
   +--------v--------+  +--------v--------+  +---------v-------+
   |    Database     |  |     Server      |  |      Web        |
   |  PostgreSQL /   |  | .NET 9 or Rust  |  |  Blazor WASM or |
   |  SQL Server     |  | API/Logic/Auth  |  |  React + Vite   |
   +--------+--------+  +--------+--------+  +---------+-------+
            |                    |                     |
            |           +--------v--------+            |
            |           |   Scheduler     |            |
            |           |   Agent(s)      |            |
            |           +-----------------+            |
            +------------------------------------------+
                        Generated Application
```

## What Gets Generated

From a single CSV metadata file, Jumpstart generates:

| Layer | .NET target | Rust target | Description |
|-------|-------------|-------------|-------------|
| **Database** | PostgreSQL / SQL Server | PostgreSQL / SQL Server | DDL, sequences, RWK indexes, views, seed data |
| **Domain** | C# classes | `domain` crate | Dictionary-backed domain objects with typed accessors |
| **Persistence** | ADO.NET `DBPersist` | `persist` crate | CRUD with audited row-versioning or basic strategies |
| **Logic** | `DispatchProxy` AOP | `logic` crate dispatch model | Business logic with interception: logging, RBAC, events |
| **API** | ASP.NET Core controllers | rouille generic router | Identical REST contract: CRUD, views, enums, children, history |
| **Web** | Blazor WebAssembly | React + TypeScript (Vite) | List/edit pages, data tables, navigation, live updates (SSE) |
| **Scheduling** | .NET worker | `scheduler` binary (cron crate) | Distributed workflow scheduler |
| **Agent** | .NET worker | `scriptagent` binary | Script execution: C#/PowerShell/Python (.NET), Rhai (Rust) |
| **Testing** | test-api, test-persist, ... | test-persist, test-script, ... | Generated integration test harnesses |
| **Tools** | import / export | import / export | CSV data import/export utilities |

Either frontend works against either backend: both implement the same REST and Server-Sent Events contracts.

## Documentation

- [Getting Started](getting-started.md) -- Install, configure, and generate your first application
- [Metadata Specification](metadata.md) -- CSV format reference, column definitions, relationship types
- [Generator](generator.md) -- How the code generator works: MetaModel, templates, RazorLight, the `gen`/`usr` split
- [Testing & Tools](testing.md) -- Generated test harnesses, import/export tools, and the `jumptest` self-testing app
- [Auth0 Setup](auth0-setup.md) -- Browser login, API JWT validation, email claims
- [M2M Authentication](auth0-m2m.md) -- Server-to-server JWTs between API, Scheduler, and ScriptAgent
- [Operations Notes](operations.md) -- Ports, runtime config, logging, troubleshooting
- **Generated Application**
  - [Overview](generated-application/) -- Output structure and layer diagram
  - [Database](generated-application/database.md) -- Naming conventions, keys, audited row-versioning, indexes, views
  - [Application Server](generated-application/application-server.md) -- API, logic, persistence, interception, auth (both backends)
  - [Scheduling Server](generated-application/scheduling-server.md) -- Workflow orchestration and dispatch
  - [Agent Server](generated-application/agent-server.md) -- Script execution and real-time notifications
  - [Web Client](generated-application/web-client.md) -- Blazor and React frontends
- **Rust Backend Reference**
  - [Overview](rust/) -- Crate layout, the dictionary-backed object model, type mapping, build
  - [Logic & the Dispatch Model](rust/logic-dispatch.md) -- Interception, authorization, and extending the model from `usr/` code
  - [Scripting with Rhai](rust/scripting.md) -- In-process database-stored scripts and sample calls

## Technology Stack

| Component | Technology |
|-----------|-----------|
| Generator | .NET 9, RazorLight, CsvHelper |
| Backend (.NET) | ASP.NET Core 9, ADO.NET |
| Backend (Rust) | rouille, `postgres`, `rust_decimal` / `chrono` / `uuid`, Rhai |
| Database | PostgreSQL 15+ / SQL Server 2019+ |
| Frontend (Blazor) | Blazor WebAssembly |
| Frontend (React) | React 18, TypeScript, Vite, react-router, auth0-react |
| Real-time | Server-Sent Events (SSE) |
| Scripting | C#, PowerShell, Python (.NET) / Rhai (Rust) |
| Auth | Auth0 (OIDC + PKCE for SPAs, client-credentials M2M between servers) |
