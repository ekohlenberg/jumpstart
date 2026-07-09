---
layout: default
title: Scheduling Server
parent: Generated Application
nav_order: 3
---

# Scheduling Server

The Scheduler is a standalone service — a .NET worker or a Rust binary, depending on the backend you generate — that fires workflows on cron schedules and orchestrates their execution across distributed agents.

## Architecture

```
API Server                    Scheduler                     Agent(s)
    |                            |                             |
    |  POST /scheduler/execute   |                             |
    |--------------------------->|                             |
    |                            |  Expand child workflows     |
    |                            |  Group by sequence          |
    |                            |                             |
    |                            |  POST /scriptagent/execute  |
    |                            |---------------------------->|
    |                            |                             | Execute script
    |                            |   status → DB + notify      |
    |                            |<----------------------------|
    |                            |  Next sequence...           |
```

## Startup

The scheduler:

1. **Binds the first free port** in the range **5000-5100**
2. **Registers itself** in `core.server_node` with type `Scheduler`, status `Online`
3. **Starts the dispatcher** that processes the job queue
4. **Starts the cron thread** that fires scheduled workflows
5. On shutdown (SIGINT/SIGTERM), sets its status to **Offline**

## Cron Scheduling

Schedules are data, not code: each `core.schedule` row references the cron component lookup tables (`cron_minute`, `cron_hour`, `cron_dom`, `cron_month`, `cron_dow`, `cron_every`). The cron thread:

1. Loads every active workflow whose schedule has its cron component FKs populated
2. Assembles a Quartz-style 7-field expression (`sec min hour dom month dow year`), applying the `Every`/`Exactly` modifier and reconciling day-of-month vs day-of-week
3. Computes the next fire time (Quartz scheduling on .NET; the `cron` crate on Rust) and calls `execute(workflow_id)` when due
4. Reloads schedules every 5 minutes

Day-of-week numbering is Quartz-compatible (1-7, Sun=1).

## Scheduler API

All routes are gated by an M2M JWT when an audience is configured (see [M2M Authentication](../auth0-m2m.md)); unauthenticated otherwise.

| Method | Route | Description |
|--------|-------|-------------|
| `POST` | `/api/scheduler/execute` | Queue a workflow for immediate execution (body = workflow id) |
| `POST` | `/api/scheduler/cancel/{id}` / `abort/{id}` | Cancel/abort (stubs in both backends) |
| `GET` | `/api/scheduler/status/{id}` | Execution status |
| `POST` | `/api/scheduler/register` / `unregister/{id}` | Instance registration |
| `GET` | `/api/scheduler/ping` / `health` | Liveness checks |

## Dispatch

`execute(workflowId)` implements the orchestration:

1. **Load the workflow.** A `Process` workflow is dispatched directly; a `Folder` workflow is expanded into its child workflows recursively (via `parent_id`).
2. **Group children by sequence number** — children sharing a `seq` value run in parallel; groups run in order.
3. **Dispatch each `Process` child** to an online agent's `POST /api/scriptagent/execute`, attaching an M2M bearer token when configured. A `Folder` child is re-queued to the scheduler.
4. **Track status.** Each workflow is set to `Dispatched` before the call and `Failed` on a dispatch error; every change is published so the web UI updates live over SSE.
5. **Handle failures** per the workflow's `on_failure` action: stop remaining sequences, or continue.

### Status Transitions

```
Idle --> Dispatched --> Executing --> Completed
                                  --> Failed / Cancelled / Timeout / Interrupted / Suspended
```

## Server Node Discovery

The API server finds a scheduler (and the scheduler finds agents) by querying the registry:

```sql
SELECT * FROM core.server_node
WHERE server_node_type_id = 2       -- Scheduler (1 = Agent, 3 = ApiServer)
  AND server_node_status_id = 2     -- Online
  AND is_active = 1
```

`GET /api/Workflow/run/{id}` on the API server resolves an online scheduler this way and POSTs to its execute route — returning 503 if none is registered, 502 if dispatch fails. Multiple scheduler instances can register for high availability.

## Not Yet Ported (Rust)

`cancel`/`abort` remain stubs (as in .NET), and the .NET `HealthMonitorThread` (periodic memory/thread-pool checks) has no Rust equivalent yet.
