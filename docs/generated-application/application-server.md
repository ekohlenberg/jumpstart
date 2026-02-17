---
layout: default
title: Application Server
parent: Generated Application
nav_order: 2
---

# Application Server

The application server is an ASP.NET Core 9 application composed of three layers: API, Logic, and Persistence.

## API Layer

The API layer generates REST controllers for each domain object with full CRUD operations plus specialized endpoints.

### Generated Controller

Each domain object produces a partial class controller:

```csharp
[Route("api/[controller]")]
[ApiController]
public partial class CustomerController : ControllerBase
{
    // GET api/customer
    [HttpGet]
    public IEnumerable<CustomerView> Get() { ... }

    // GET api/customer/{id}
    [HttpGet("{id}")]
    public Customer Get(long id) { ... }

    // GET api/customer/view/{id}
    [HttpGet("view/{id}")]
    public CustomerView View(long id) { ... }

    // GET api/customer/enum
    [HttpGet("enum")]
    public List<EnumHelper> GetEnum() { ... }

    // POST api/customer
    [HttpPost]
    public void Post([FromBody] Customer customer) { ... }

    // PUT api/customer/{id}
    [HttpPut("{id}")]
    public void Put(long id, [FromBody] Customer customer) { ... }

    // DELETE api/customer/{id}
    [HttpDelete("{id}")]
    public void Delete(long id) { ... }

    // GET api/customer/history/{id}
    [HttpGet("history/{id}")]
    public List<CustomerHistory> GetHistory(long id) { ... }

    // GET api/customer/children/{id}?child=order
    [HttpGet("children/{id}")]
    public object GetChildren(long id, [FromQuery] string child) { ... }
}
```

### Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| `GET` | `/api/{entity}` | List all (returns View objects with resolved enums) |
| `GET` | `/api/{entity}/{id}` | Get by ID (raw domain object) |
| `GET` | `/api/{entity}/view/{id}` | Get view by ID (with resolved FK display values) |
| `GET` | `/api/{entity}/enum` | Get enum list `[{id, rwkString}]` for dropdowns |
| `POST` | `/api/{entity}` | Create new record |
| `PUT` | `/api/{entity}/{id}` | Update existing record |
| `DELETE` | `/api/{entity}/{id}` | Delete record |
| `GET` | `/api/{entity}/history/{id}` | Get audit history |
| `GET` | `/api/{entity}/children/{id}?child={name}` | Get child records |

### Custom API Endpoints

Since controllers are `partial class`, you can add custom endpoints without modifying generated code. Core API extensions follow the `{DomainObj}.api.core.cs.cshtml` naming pattern:

```csharp
// Workflow.api.core.cs -- custom endpoint added to WorkflowController
public partial class WorkflowController
{
    [HttpGet("run/{id}")]
    public async Task<IActionResult> Run(long id) { ... }
}
```

### Notification Publishing

When records are created, updated, or deleted, the API publishes real-time notifications through SignalR:

```csharp
// In the generated Post/Put methods:
EventAggregator.PublishAsync(domainObjectName, instanceId, jsonData);
```

Blazor clients subscribe to these notifications for live list updates.

## Logic Layer

The logic layer provides business operations for each domain object, wrapped in a proxy for cross-cutting concerns.

### Generated Logic

Each domain object generates an interface and implementation:

```csharp
public interface ICustomerLogic
{
    List<Customer> select();
    List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
    List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
    Customer get(long id);
    List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
    List<CustomerHistory> history(long id);
    void insert(Customer customer);
    void update(long id, Customer customer);
    void put(Customer customer);
    void delete(long id);
    CustomerView view(long id);
}

public partial class CustomerLogic : BaseLogic, ICustomerLogic
{
    public static ICustomerLogic Create()
    {
        var customer = new CustomerLogic();
        var proxy = DispatchProxy.Create<ICustomerLogic, Proxy<ICustomerLogic>>();
        ((Proxy<ICustomerLogic>)proxy).Initialize();
        ((Proxy<ICustomerLogic>)proxy).Target = customer;
        ((Proxy<ICustomerLogic>)proxy).DomainObj = "Customer";
        return proxy;
    }

    public virtual List<Customer> select() { ... }
    public virtual Customer get(long id) { ... }
    public virtual void insert(Customer customer) { ... }
    public virtual void update(long id, Customer customer) { ... }
    public virtual void delete(long id) { ... }
    // ...
}
```

### Logic Factory Pattern

Logic classes are always obtained through the `Create()` factory method:

```csharp
var logic = CustomerLogic.Create();  // Returns a proxied instance
var customers = logic.select<CustomerView>();
```

The factory creates a `DispatchProxy` wrapper around the real logic class, enabling the proxy/AOP pipeline.

### User Logic Extension

The user partial class (`CustomerLogic.user.cs`, FORCE=FALSE) allows overriding any virtual method:

```csharp
public partial class CustomerLogic
{
    public override void insert(Customer customer)
    {
        // Custom pre-insert logic
        base.insert(customer);
        // Custom post-insert logic
    }
}
```

### Named Queries

The logic layer supports named SQL queries stored in the `core.sql` table:

```csharp
// Uses the query registered as "core.workflow-select"
var workflows = logic.select<WorkflowView>("core.workflow-select");
```

## Persistence Layer

### DBPersist

The `DBPersist` class is the central data access component. All database operations flow through it.

#### Core Operations

```csharp
// Select with callback
DBPersist.select(callback, sql);

// Select returning typed list
List<T> results = DBPersist.select<T>(sql);

// Select with template substitution
DBPersist.select(callback, sqlTemplate, filterObject);

// Insert (auto-assigns id, audit columns, writes history)
long id = DBPersist.insert(baseObject);

// Update by id (auto-updates audit columns, writes history)
DBPersist.update(baseObject);

// Update by filter (bulk update matching filter criteria)
DBPersist.update(baseObject, filterObject);

// Execute raw SQL
DBPersist.execCmd(sql);
DBPersist.execCmd(filterObject, sqlTemplate);
```

#### Insert Behavior

Every `insert` call automatically:
1. Obtains the next sequence ID via `identity()`
2. Sets `version` via `version()`
3. Sets `created_by` to `Environment.UserName`
4. Sets `last_updated` to `DateTime.UtcNow`
5. Sets `last_updated_by` to `Environment.UserName`
6. Executes the INSERT
7. Writes an audit record to the history table

#### Update Behavior

Every `update` call automatically:
1. Increments `version`
2. Sets `last_updated` and `last_updated_by`
3. Executes the UPDATE
4. Writes an audit record to the history table

#### Database Provider Abstraction

DBPersist uses `IDatabaseProvider` to abstract database differences:

```csharp
IDatabaseProvider provider = DatabaseProviderFactory.CreateProvider(connectionName);
```

| Provider | Class | Description |
|----------|-------|-------------|
| PostgreSQL | `PostgreSQLProvider` | Uses Npgsql |
| SQL Server | `SqlServerProvider` | Uses Microsoft.Data.SqlClient |

The provider is selected via the `db.type` setting in `appsettings.json` (`pgsql` or `mssql`).

#### Auto-Assign

`DBPersist.autoAssign(reader, baseObject)` uses reflection to map database columns to domain object properties, handling type conversion automatically.

## Proxy Aspect

The proxy layer implements aspect-oriented programming (AOP) using .NET's `DispatchProxy`. Every logic method call passes through the proxy pipeline.

### Pipeline

```
Client Code
    |
    v
Proxy.Invoke()
    |
    +---> Before Actions (in order):
    |       1. Logging: "Invoking Customer.insert"
    |       2. Authorization: Check RBAC permissions
    |       3. Pre-Event Service: Run "pre" event scripts
    |
    +---> Target Method: CustomerLogic.insert()
    |
    +---> After Actions (in order):
    |       1. Logging: "After invoking insert"
    |       2. Post-Event Service: Run "post" event scripts
    |
    v
Result
```

### Before Actions

Three built-in before actions execute before every logic method:

1. **Logging** -- Logs the domain object and method name
2. **Authorization** -- Calls `OpRoleMemberLogic.Authorized(domainObj, methodName)` to verify RBAC permissions. Throws an exception if unauthorized.
3. **Pre-Event Service** -- Executes any scripts registered in `core.event_service` with matching `event_type="pre"`, `objectname_filter`, and `methodname_filter`

### After Actions

Two built-in after actions execute after every logic method:

1. **Logging** -- Logs completion
2. **Post-Event Service** -- Executes any scripts registered with `event_type="post"`

### ProxyAction

The `ProxyAction` static class manages the before/after action collections using `ConcurrentBag` for thread safety:

```csharp
// Add custom before action
ProxyAction.AddBeforeAction((domainObj, method, args) =>
{
    // Custom cross-cutting logic
});

// Add custom after action
ProxyAction.AddAfterAction((domainObj, method, result, args) =>
{
    // Custom post-processing
});
```

### Initialization

`ProxyCallbackInitializer.Initialize()` registers the default before/after actions. This is called once per application via a thread-safe `Interlocked.CompareExchange` guard.

## Auth

Jumpstart generates a complete role-based access control (RBAC) system.

### Security Model

```
Principal (User)
    |
    +---> OpRoleMember (membership)
              |
              +---> OpRole (role)
                       |
                       +---> OpRoleMap (assignment)
                                 |
                                 +---> Operation (objectname + methodname)
```

### Database Tables

| Table | Schema | Purpose |
|-------|--------|---------|
| `principal` | `app` | User accounts (username, email) |
| `principal_password` | `sec` | Password hashes |
| `operation` | `sec` | Named operations (`objectname` + `methodname`) |
| `op_role` | `sec` | Named roles |
| `op_role_map` | `sec` | Maps operations to roles |
| `op_role_member` | `sec` | Maps users to roles |

### Authorization Check

Authorization is performed by `OpRoleMemberLogic.Authorized()`, which is called by the proxy's before action on every logic method:

```sql
SELECT 1 FROM
    sec.operation op
    INNER JOIN sec.op_role_map orm ON orm.op_id = op.id
    INNER JOIN sec.op_role r ON r.id = orm.op_role_id
    INNER JOIN sec.op_role_member m ON m.op_role_id = r.id
    INNER JOIN app.principal p ON p.id = m.principal_id
WHERE
    op.objectname = '{objectName}'
    AND op.methodname = '{methodName}'
    AND p.username = '{currentUser}'
```

If the query returns a row, the user is authorized. Results are cached in a thread-safe dictionary to avoid repeated database lookups.

### Configuration

To authorize operations:

1. Create an `operation` record for each object/method pair
2. Create an `op_role` record
3. Map operations to roles via `op_role_map`
4. Assign users to roles via `op_role_member`

The admin user created by the seed data scripts has full access by default.
