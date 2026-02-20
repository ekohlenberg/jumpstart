---
layout: default
title: Scheduling Server
parent: Generated Application
nav_order: 3
---

# Scheduling Server

The Scheduler is a standalone .NET service that orchestrates workflow execution across distributed agents.

## Architecture

```
API Server                    Scheduler                     Agent(s)
    |                            |                             |
    |  POST /scheduler/execute   |                             |
    |-------------------------->|                             |
    |                            |  Queue workflow              |
    |                            |  DispatcherThread            |
    |                            |      |                      |
    |                            |      | Load child workflows  |
    |                            |      | Group by sequence     |
    |                            |      |                      |
    |                            |      | POST /agent/execute   |
    |                            |      |--------------------->|
    |                            |      |                      | Execute script
    |                            |      |                      |
    |                            |      |  Status: Completed   |
    |                            |      |<---------------------|
    |                            |      |                      |
    |  200 OK (executionId)      |      | Next sequence...     |
    |<--------------------------|      |                      |
```

## Startup

The scheduler service:

1. **Binds to a dynamic port** in the range 5000-5100
2. **Registers itself** as a `ServerNode` in the database with `server_node_type_id = Scheduler`
3. **Starts the DispatcherThread** for processing the job queue
4. **Starts the HealthMonitorThread** for periodic system checks
5. **Sets status to Online** when ready to accept work

On shutdown, it sets its status to **Offline** and waits for in-flight jobs to complete.

## Scheduler API

| Method | Route | Description |
|--------|-------|-------------|
| `POST` | `/api/scheduler/execute` | Queue a workflow for immediate execution |
| `POST` | `/api/scheduler/schedule` | Schedule a workflow |
| `POST` | `/api/scheduler/cancel/{id}` | Cancel a queued/running workflow |
| `POST` | `/api/scheduler/abort/{id}` | Abort execution immediately |
| `POST` | `/api/scheduler/pause/{id}` | Pause a running workflow |
| `POST` | `/api/scheduler/resume/{id}` | Resume a paused workflow |
| `POST` | `/api/scheduler/retry/{id}` | Retry a failed workflow |
| `GET` | `/api/scheduler/status/{id}` | Get execution status |
| `GET` | `/api/scheduler/health` | Health check |
| `POST` | `/api/scheduler/register` | Register scheduler instance |
| `POST` | `/api/scheduler/unregister/{id}` | Unregister on shutdown |

## SchedulerLogic

The core orchestration engine managing workflow dispatch.

### Job Queue

```csharp
ConcurrentQueue<long> + ManualResetEventSlim
```

- Thread-safe concurrent queue for workflow IDs
- `ManualResetEventSlim` for efficient signaling when new jobs arrive
- The DispatcherThread blocks on the signal when the queue is empty

### Execution Flow

`ExecuteWorkflowInternal(workflowId)`:

1. **Load parent workflow** from database
2. **Collect child workflows** recursively
3. **Group children by sequence number** -- children with the same sequence run in parallel
4. **For each sequence group** (in order):
   - Execute all workflows in the group concurrently
   - Wait for all to complete before advancing to the next sequence
5. **Handle failures** according to `on_failure_action_id`:
   - **Stop** -- abort remaining sequences
   - **Continue** -- proceed to next sequence despite failures

### Workflow Types

| Type | Behavior |
|------|----------|
| **Process** | Dispatched to an Agent via `AgentClient.ExecuteAsync()` |
| **Folder** | Contains child workflows; dispatched back to Scheduler for recursive execution |

### Status Transitions

```
Idle  -->  Dispatched  -->  Executing  -->  Completed
                                       -->  Failed
                                       -->  Cancelled
                                       -->  Timeout
                                       -->  Interrupted
                                       -->  Suspended
```

## DispatcherThread

A background thread that processes the job queue:

```csharp
BlockingCollection<long> Queue
```

- Consumes workflow IDs from the blocking collection
- Calls `ProcessJob(jobId)` for each item
- Handles errors without stopping the thread
- Supports graceful shutdown via `Queue.CompleteAdding()`

## HealthMonitorThread

A periodic monitoring thread that runs every 30 seconds:

- **Memory check**: Warns if process memory exceeds 1000 MB
- **Thread pool check**: Warns if fewer than 10% of worker threads are available
- **Queue status**: Reports on pending jobs
- Continues monitoring even if individual checks fail
- Stops gracefully via volatile `_running` flag

## SchedulerClient

The `SchedulerClient` is a REST client used by the API server (and other services) to communicate with the scheduler:

```csharp
var serverNode = /* query for online Scheduler node */;
using var client = new SchedulerClient(serverNode);
var executionId = await client.ExecuteAsync(workflowId);
```

The client reads the scheduler's URL from the `ServerNode` record and uses `HttpClient` with a 30-second timeout.

### Advanced Operations

Beyond basic execution, the `SchedulerClient` supports:

| Category | Methods |
|----------|---------|
| **Job Control** | Cancel, Abort, Pause, Resume, Retry |
| **Scheduling** | Schedule, Queue, Repeat |
| **Workflow Patterns** | Chain, Fork, Join, Batch |
| **Resource Management** | Allocate, Deallocate, Balance, Scale |
| **Lifecycle** | Migrate, Configure, Validate |

## Server Node Discovery

The API server locates an available scheduler by querying the database:

```sql
SELECT * FROM core.server_node
WHERE server_node_type_id = 2       -- Scheduler
  AND server_node_status_id = 2     -- Online
  AND is_active = 1
ORDER BY registered_at DESC
```

The most recently registered online scheduler is selected. This pattern supports multiple scheduler instances for high availability.
