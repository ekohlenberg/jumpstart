---
layout: default
title: Agent Server
parent: Generated Application
nav_order: 4
---

# Agent Server

The Agent is a standalone .NET service that executes individual workflow processes -- running C#, PowerShell, or Python scripts.

## Architecture

```
Scheduler                     Agent
    |                            |
    |  POST /agent/execute       |
    |-------------------------->|
    |                            |  Queue workflow
    |                            |  ExecutionThread
    |                            |      |
    |                            |      | Load Workflow
    |                            |      | Load Process
    |                            |      | Load Script
    |                            |      |
    |                            |      | Create ScriptHost
    |                            |      | Execute script
    |                            |      |
    |                            |      | Update status
    |                            |      | Write ExecLog
    |                            |      | Publish notification
    |                            |      |
    |  Status updated in DB      |      |
    |<..........................|      |
```

## Startup

The agent service:

1. **Binds to a dynamic port** in the range 5100-5200
2. **Registers itself** as a `ServerNode` in the database with `server_node_type_id = Agent`
3. **Sets status to Online** when ready to accept work
4. The **ExecutionThread** is started on-demand when the first job arrives

On shutdown, it sets its status to **Offline**.

## Agent API

| Category | Endpoints |
|----------|-----------|
| **Job Execution** | execute, validate, prepare, cleanup, retry |
| **Process Management** | stop, kill, restart, pause, resume |
| **Status & Reporting** | status, heartbeat, report, log, metrics |
| **Resource Management** | allocate, release, capabilities |
| **Communication** | ping, acknowledge, notify, request |
| **System Operations** | shutdown, reload, update, diagnose, health |
| **Security** | authenticate, authorize |
| **CRUD** | select, get, create, update, delete |

## AgentLogic

The core execution engine for running scripts.

### Job Queue

```csharp
ConcurrentQueue<long>
```

Thread-safe queue for incoming workflow IDs. The `ExecutionThread` processes items sequentially.

### Script Execution Pipeline

`ExecuteWorkflow(workflowId)`:

1. **Load Workflow** from database
2. **Load Process** referenced by the workflow's `process_id`
3. **Load Script** referenced by the process's `script_id`
4. **Update workflow status** to `Executing`
5. **Create ScriptHost** with a `ScriptContext` containing workflow metadata
6. **Execute the script** synchronously via `ScriptHost.InvokeSync<ScriptContext>()`
7. **Check results**:
   - If script threw an exception --> status = `Failed`
   - If script returned error code --> status = `Failed`
   - Otherwise --> status = `Completed`
8. **Update workflow** with end time and final status
9. **Write ExecLog** entry
10. **Publish notification** for real-time UI updates

### Script Types

| Type | Enum Value | Provider | Description |
|------|-----------|----------|-------------|
| C# | `ScriptType.CSharp = 1` | `CSharpCompiler` | Dynamically compiled and executed |
| PowerShell | `ScriptType.PowerShell = 2` | `PowerShellProvider` | Executed via PowerShell runtime |
| Python | `ScriptType.Python = 3` | `PythonProvider` | Executed via Python process |

Scripts are stored as source code in the `core.script` table. The `ScriptProviderFactory` selects the appropriate provider based on the script's `script_type_id`.

### Status Management

The agent tracks its own status as a singleton `ServerNode`:

```csharp
static ServerNode _thisServerNode;
```

| Transition | When |
|-----------|------|
| `Online` | Agent is idle, ready for work |
| `Busy` | Agent is executing a script |
| `Online` | Script execution completed |
| `Offline` | Agent is shutting down |

Thread-safe getters/setters with locking protect the singleton state.

## Execution Status Lifecycle

The `WorkflowCoreLogic` class handles status transitions and side effects:

```csharp
Dictionary<long, ExecutionStatusHandler> _executionStatusHandlers = {
    ExecStatus.Executing  --> OnExecuting,
    ExecStatus.Completed  --> OnCompleted,
    ExecStatus.Failed     --> OnFailed,
    ExecStatus.Cancelled  --> OnFailed,
    ExecStatus.Timeout    --> OnFailed,
    ExecStatus.Interrupted --> OnFailed,
    ExecStatus.Suspended  --> OnFailed
};
```

### OnExecuting

When a workflow begins executing:
1. Deactivate any existing active `ExecLog` records for this workflow
2. Create a new `ExecLog` record with `is_active = 1`, recording `start_time`

### OnCompleted / OnFailed

When a workflow finishes:
1. Update the active `ExecLog` record with `end_time` and final `exec_status_id`

## Real-Time Notifications

### SignalR Hub

The `NotificationHub` provides WebSocket-based real-time communication:

```csharp
public class NotificationHub : Hub
{
    // Client subscribes to updates for a domain object type
    Task SubscribeToDomainObject(string domainObjectName);

    // Client unsubscribes
    Task UnsubscribeFromDomainObject(string domainObjectName);
}
```

Clients are organized into **groups** by domain object name (e.g., `"Workflow"`, `"Customer"`). When a record changes, only clients subscribed to that domain object type receive the notification.

### EventAggregator

The `EventAggregator` routes property updates to SignalR clients:

```csharp
await EventAggregator.PublishAsync(domainObjectName, instanceId, jsonData);
```

This sends a `PropertyUpdateMessage` to all clients in the matching group:

```csharp
class PropertyUpdateMessage
{
    string DomainObjectName;   // e.g., "Workflow"
    long InstanceId;           // e.g., 42
    string JsonData;           // Serialized updated properties
    DateTime Timestamp;
}
```

### NotificationController

External services (like the Agent) can publish notifications via REST:

```
POST /api/notification/publish
{
    "domainObjectName": "Workflow",
    "instanceId": 42,
    "jsonData": "{...}"
}
```

### Client-Side Integration

Blazor pages subscribe to real-time updates:

```csharp
// Connect to SignalR hub
_hubConnection = new HubConnectionBuilder()
    .WithUrl($"{baseAddress}/notificationHub")
    .Build();

// Handle property updates
_hubConnection.On<PropertyUpdateMessage>("PropertyUpdated", async (message) =>
{
    if (message.DomainObjectName == "Workflow")
    {
        // Fetch updated record from API
        var updated = await client.GetFromJsonAsync<WorkflowView>(
            $"api/workflow/view/{message.InstanceId}");

        // Update local list and refresh UI
        workflowList[index] = updated;
        await InvokeAsync(StateHasChanged);
    }
});

// Subscribe to domain object updates
await _hubConnection.InvokeAsync("SubscribeToDomainObject", "Workflow");
```

This enables live dashboard behavior -- when a workflow starts executing or completes, the list page updates in real time without polling.

## AgentClient

The `AgentClient` is a REST client used by the Scheduler to dispatch work to agents:

```csharp
var agentNode = /* query for online Agent node */;
using var client = new AgentClient(agentNode);
await client.ExecuteAsync(workflowId);
```

Agent discovery uses the same pattern as scheduler discovery:

```sql
SELECT * FROM core.server_node
WHERE server_node_type_id = 1       -- Agent
  AND server_node_status_id = 2     -- Online
  AND is_active = 1
```

## Multi-Instance Deployment

Both schedulers and agents support multi-instance deployment:

- Each instance binds to a unique port via dynamic port scanning
- Each instance registers as a separate `ServerNode` in the database
- The scheduler selects available agents for load distribution
- Health monitoring tracks instance availability
- Graceful shutdown deregisters the instance
