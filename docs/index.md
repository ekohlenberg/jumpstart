---
layout: default
title: Home
nav_order: 1
---

# Jumpstart Documentation

**Jumpstart** is an enterprise-grade code generation framework that transforms CSV metadata specifications into complete, production-ready full-stack applications.

## Architecture Overview

```
                         +------------------+
                         |   Metadata CSV   |
                         |  (your model)    |
                         +--------+---------+
                                  |
                         +--------v---------+
                         |    Generator     |
                         |  (RazorLight)    |
                         +--------+---------+
                                  |
            +---------------------+---------------------+
            |                     |                     |
   +--------v--------+  +--------v--------+  +---------v-------+
   |    Database      |  |     Server      |  |      Web        |
   |  PostgreSQL /    |  |   .NET 9 API    |  |  Blazor WASM    |
   |  SQL Server      |  |  Logic / Auth   |  |  Components     |
   +---------+--------+  +--------+--------+  +---------+-------+
             |                     |                     |
             |            +--------v--------+            |
             |            |   Scheduler     |            |
             |            |   Agent(s)      |            |
             |            +-----------------+            |
             +---------------------------------------------+
                          Generated Application
```

## What Gets Generated

From a single CSV metadata file, Jumpstart generates:

| Layer | Technology | Description |
|-------|-----------|-------------|
| **Database** | PostgreSQL / SQL Server | DDL scripts, sequences, indexes, audit tables, seed data |
| **Domain** | C# (.NET 9) | Domain model classes with partial class extensibility |
| **Persistence** | ADO.NET | Database access layer with provider abstraction |
| **Logic** | C# | Business logic with proxy-based AOP (logging, auth, events) |
| **API** | ASP.NET Core | REST controllers with full CRUD, views, enums, children, history |
| **Web** | Blazor WebAssembly | List/edit pages, data tables, navigation, real-time updates |
| **Testing** | .NET Test | API and persistence layer integration tests |
| **Scheduling** | .NET Worker | Distributed workflow scheduler service |
| **Agent** | .NET Worker | Script execution agent (C#, PowerShell, Python) |

## Documentation

- [Getting Started](getting-started.md) -- Install, configure, and generate your first application
- [Metadata Specification](metadata.md) -- CSV format reference, column definitions, relationship types
- [Generator](generator.md) -- How the code generator works: MetaModel, templates, RazorLight
- **Generated Application**
  - [Overview](generated-application/) -- Output structure and layer diagram
  - [Database](generated-application/database.md) -- Naming conventions, table design, keys, indexes, foreign keys, history
  - [Application Server](generated-application/application-server.md) -- API, logic, persistence, proxy/AOP, auth
  - [Scheduling Server](generated-application/scheduling-server.md) -- Workflow orchestration and dispatch
  - [Agent Server](generated-application/agent-server.md) -- Script execution and real-time notifications

## Technology Stack

| Component | Technology |
|-----------|-----------|
| Generator | .NET 9, RazorLight, CsvHelper |
| Backend | ASP.NET Core 9, ADO.NET |
| Database | PostgreSQL 15+ / SQL Server 2019+ |
| Frontend | Blazor WebAssembly |
| Real-time | SignalR |
| Scripting | C#, PowerShell, Python |
