---
layout: default
title: Agent Server
parent: Generated Application
nav_order: 4
---

# Agent Server

The Script Agent is a standalone service that executes workflow processes — running database-stored scripts. Script engines differ by backend:

| Backend | Script engines |
|---------|----------------|
| .NET | C# (Roslyn, `script_type_id=1`), PowerShell (`2`), Python (`3`) |
| Rust | Rhai — embedded, sandboxed, no external toolchain (see [Scripting with Rhai](../rust/scripting.md)) |

Scripts are stored as source in `core.script` and selected per script via `script_type_id`; a `ScriptProviderFactory` in each backend picks the engine.

## Architecture

```
Scheduler                       Agent
    |                             |
    |  POST /scriptagent/execute  |
    |---------------------------->|
    |                             |  Queue workflow id
    |                             |  Execution thread:
    |                             |    load workflow → process → script
    |                             |    status → Executing, node → Busy
    |                             |    run script via ScriptHost
    |                             |    status → Completed / Failed
    |                             |    write ExecLog
    |                             |    publish notification (SSE fan-out)
```

## Startup

The agent:

1. **Binds the first free port** in the range **5100-5200**
2. **Registers itself** in `core.server_node` with type `Agent`, status `Online`
3. Starts (or lazily starts) the **execution thread** that drains the job queue
4. On shutdown, sets its status to **Offline**

## Agent API

The full route set lives under `/api/scriptagent/...`. The load-bearing route is `POST /api/scriptagent/execute` (body = workflow id); most others are stubs returning placeholder shapes, in both backends:

| Category | Endpoints |
|----------|-----------|
| **Job execution** | execute, validate, prepare, cleanup, retry |
| **Process management** | stop, kill, restart, pause, resume (stubs) |
| **Status & reporting** | status, heartbeat, report, log, metrics |
| **System** | ping, health, diagnose, capabilities |

Inbound requests (from the Scheduler) are gated by an M2M JWT when configured — see [M2M Authentication](../auth0-m2m.md).

## Execution Pipeline

`ExecuteWorkflow(workflowId)`:

1. **Load the workflow**, its **process**, and the process's **script**
2. Set workflow status to `Executing`, set the node `Busy`
3. Build a script context carrying workflow metadata and run the script through **ScriptHost**
4. Determine the outcome: engine error or non-zero return code → `Failed`; otherwise `Completed`
5. Update the workflow with end time and final status; set the node back to `Online`
6. Write the **ExecLog** entry (deactivate prior active entries on start; stamp `end_time` and status on finish)
7. **Publish a notification** so watching web clients update live

## Auth and the Unchecked Path

The agent runs as a trusted process with no security principal, so its own reads/writes use the *unchecked* logic path (`exec_unchecked`), which bypasses authorization — and also bypasses the notification after-hook. The agent therefore publishes notifications explicitly after each status change, fanning out over HTTP to the online API servers.

Scripts themselves are different: script DB access goes through the **checked** logic path, so a script needs a seeded principal to be authorized (see [Scripting with Rhai](../rust/scripting.md) for the Rust capability model).

## Real-Time Notifications

Status changes reach browsers over **Server-Sent Events**:

1. Agent updates a workflow → publishes `{DomainObjectName: "Workflow", InstanceId, JsonData}` to each online API server's `POST /api/Notification/publish`
2. Each API server forwards to its connected `GET /api/Notification/stream` clients as a `PropertyUpdated` event
3. List pages watching that domain object re-fetch the changed record and update in place — live dashboard behavior without polling

Both the Blazor and React clients use the browser `EventSource` API, so one client implementation works against both backends.

## Multi-Instance Deployment

Schedulers and agents support multi-instance deployment:

- Each instance binds a unique port via dynamic port scanning and registers as a separate `ServerNode`
- The scheduler selects online agents from the registry for dispatch
- Graceful shutdown marks the instance `Offline`
