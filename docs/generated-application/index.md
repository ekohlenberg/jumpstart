---
layout: default
title: Generated Application
nav_order: 5
---

# Generated Application

The generator produces a complete, layered .NET 9 application with clear separation of concerns.

## Architecture

```
+------------------+
|   Blazor WASM    |     Browser
|   (Web Client)   |
+--------+---------+
         | HTTP / SignalR
+--------v---------+
|   ASP.NET Core   |     API Server (port 5200)
|   REST API       |
+--------+---------+
         |
+--------v---------+
|   Logic Layer    |     Business logic + Proxy/AOP
+--------+---------+
         |
+--------v---------+
|   Persist Layer  |     DBPersist (ADO.NET)
+--------+---------+
         |
+--------v---------+
| PostgreSQL / SQL |     Database
|     Server       |
+---------+--------+

+------------------+     +------------------+
|   Scheduler      |     |   Agent(s)       |
|  (port 5000+)    |<--->|  (port 5100+)    |
+------------------+     +------------------+
  Workflow orchestration    Script execution
```

## Layer Diagram

| Layer | Project | Responsibility |
|-------|---------|---------------|
| **Database** | `database/ddl/`, `database/data/` | Schema creation, seed data |
| **Domain** | `shared/domain/` | C# domain model classes |
| **Common** | `shared/common/` | Config, logging, database providers, script execution |
| **Persistence** | `server/persist/` | DBPersist -- SQL execution, CRUD, audit |
| **Logic** | `server/logic/` | Business rules, proxy interceptors, auth |
| **API** | `server/api/` | REST controllers, SignalR hub, notifications |
| **Web** | `web/` | Blazor WebAssembly pages, components, navigation |
| **Scheduler** | `server/scheduler/` | Workflow dispatch and sequencing |
| **Agent** | `server/agent/` | Script execution (C#, PowerShell, Python) |
| **Tests** | `test/test-api/`, `test/test-persist/` | Integration test suites |

## Partial Class Convention

Generated code uses C#'s `partial class` feature to separate generated and hand-written code:

```
Customer.generated.cs    (FORCE=TRUE  -- always regenerated)
Customer.user.cs         (FORCE=FALSE -- created once, then yours to edit)
```

This applies to domain classes, logic classes, and test classes. You can safely re-run the generator without losing your customizations.

## Sections

- [Database](database.md) -- Table design, keys, indexes, foreign keys, history
- [Application Server](application-server.md) -- API, logic, persistence, proxy/AOP, auth
- [Scheduling Server](scheduling-server.md) -- Workflow orchestration and dispatch
- [Agent Server](agent-server.md) -- Script execution and real-time notifications
