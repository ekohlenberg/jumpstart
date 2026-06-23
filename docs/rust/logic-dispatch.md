---
layout: default
title: Logic & the Dispatch Model
parent: Rust Runtime
nav_order: 1
---

# Logic & the Dispatch Model

The logic layer is where Jumpstart enforces **aspect-oriented interception** —
logging, authorization, and (pluggably) event triggering — around every business
operation. In .NET this was done with a reflection-based `DispatchProxy` that
intercepted every interface method. Rust has no reflection and its trait objects
cannot carry generic methods, so the Rust runtime replaces the reflective proxy
with an explicit **dispatch model**: a single interception chokepoint plus a
generated string→method router.

## The pieces

| Type | Role |
|------|------|
| `LogicContext` | The uniform context for a call: the `transaction` record + scalar `args`. It threads through every layer so the hooks can see it. |
| `LogicDispatch` | A trait each `<Obj>Logic` implements with a generated `match method { ... }` that routes a method name to a real operation. |
| `LogicExec` | The single chokepoint. `LogicExec::call` runs the before hooks → `dispatch` → the after hooks. |
| `ExecProof` | A capability token (private constructor) that gates `dispatch`, so operations can only be reached through `LogicExec`. |
| `proxy` | The thread-safe before/after hook registry and the default wiring (logging + authorization). |

### LogicContext

```rust
pub struct LogicContext {
    pub transaction: BaseObject,        // the record an op reads / writes
    pub args: HashMap<String, Value>,   // scalar args, e.g. "id", "child_suffix"
}
```

Helpers: `LogicContext::for_record(obj)` (insert / put / update),
`LogicContext::for_id(id)` (get / view / history / delete), `ctx.id()`,
`ctx.arg_i64(key)`, `ctx.arg_str(key)`, `ctx.set_arg(key, value)`.

### The generated dispatch

Each object's logic exposes its operations as ordinary `pub(crate)` methods —
the real business logic lives there — and a generated `dispatch` routes a method
name to them:

```rust
impl LogicDispatch for CustomerLogic {
    const DOMAIN: &'static str = "Customer";

    fn dispatch(&self, method: &str, ctx: &mut LogicContext, _proof: &ExecProof)
        -> Result<Value, LogicError>
    {
        match method {
            "get"    => { let r = self.get(ctx.id())?; /* marshal to Value */ }
            "insert" => { let mut o = Customer::from_base(ctx.transaction.clone());
                          self.insert(&mut o)?; ctx.transaction = o.base; /* ... */ }
            // select / view / history / children / update / put / delete ...
            _ => Err(LogicError::Event(format!("unknown method '{}' on Customer", method))),
        }
    }
}
```

The `match` is just the string→method glue that reflection gave .NET for free;
the work happens in `self.get(...)`, `self.insert(...)`, etc. Results are
returned as `serde_json::Value` (a record map, an array of maps, or null).

### Calling logic

Every call goes through the authorized entry point:

```rust
let mut ctx = LogicContext::for_id(42);
let customer = CustomerLogic::exec("get", &mut ctx)?;     // -> serde_json::Value

let mut ctx = LogicContext::for_record(record);           // record: BaseObject
CustomerLogic::exec("insert", &mut ctx)?;
let new_id = ctx.transaction.get("id").as_i64().unwrap_or_default();
```

`<Obj>Logic::exec(method, ctx)` calls `LogicExec::call`, which runs the hooks
and then dispatches. The standard methods are: `select`, `get`, `view`,
`history`, `children`, `insert`, `update`, `put`, `delete`.

## Authorization cannot be bypassed by accident

This is the security-critical property. `LogicDispatch::dispatch` requires an
`ExecProof`, and `ExecProof`'s constructor is **private to the `logic_exec`
module** — only `LogicExec` can mint one. The raw operations (`get`, `insert`,
…) are `pub(crate)`. Together this means:

- External crates (api, web, scripts) **cannot** call a raw operation or
  `dispatch` directly. The only way in is `LogicExec` / `<Obj>Logic::exec`,
  which always runs the authorization hook.
- The single, explicit bypass is `<Obj>Logic::exec_unchecked` (→
  `LogicExec::call_unchecked`), which skips the hooks. It exists for contexts
  with no security principal — import/export, tests — and is intentionally named
  to make a bypass obvious in code review.

The default authorization hook calls `OpRoleMemberLogic::authorized(domain,
method)`, which runs the same `core.operation` / `op_role` / `op_role_map` /
`op_role_member` / `principal` join the .NET layer used, caches the result, and
returns `LogicError::Unauthorized` (short-circuiting the call) when the current
principal lacks the operation. The current principal is tracked in a
thread-local (`OpRoleMemberLogic::set_current_user` / `current_user`), the Rust
equivalent of the .NET `AsyncLocal`, set by API middleware per request.

## The hook registry

`proxy.core.rs` holds the before/after hook lists. Hooks receive the full
`LogicContext`, so they can inspect (and pre-process) the record and arguments:

```rust
pub type BeforeAction =
    Box<dyn Fn(&str, &str, &mut LogicContext) -> Result<(), LogicError> + Send + Sync>;
pub type AfterAction =
    Box<dyn Fn(&str, &str, &mut LogicContext, Option<&Value>) -> Result<(), LogicError> + Send + Sync>;
```

`proxy::initialize()` installs the defaults once per process: structured
logging, then authorization. You can register additional hooks at startup:

```rust
use logic::ProxyAction;

ProxyAction::add_before_action(Box::new(|domain, method, _ctx| {
    metrics::increment(&format!("logic.{domain}.{method}"));
    Ok(())
}));
```

> **Event triggering.** The .NET proxy also fired pre/post *event-service*
> scripts. In the Rust runtime the hook plumbing is in place and carries the
> context, but the event hook itself is not yet wired, because `EventServiceLogic`
> lives in `logic` while the script engine lives in the `script` crate (which
> depends on `logic`) — wiring it directly would be a dependency cycle. It will
> be connected through a small callback-registry indirection.

---

# Extending the model from `usr/` code

Custom, app-specific logic goes in the per-object **user file**,
`usr/shared/logic/<Obj>Logic.user.rs` (`FORCE=FALSE` — created once, never
overwritten). It is compiled into the same module as the generated logic, so the
generated type and its imports are already in scope.

## 1. A plain helper method

The simplest extension: add a method and call it directly from your own code. It
can reuse the generated `pub(crate)` operations and `DBPersist`:

```rust
// usr/shared/logic/CustomerLogic.user.rs
impl CustomerLogic {
    pub fn deactivate_stale(&self, days: i64) -> Result<u64, LogicError> {
        let sql = format!(
            "UPDATE app.customer SET is_active = 0 \
             WHERE last_updated < now() - interval '{} days' AND is_active = 1",
            days
        );
        Ok(DBPersist::exec_cmd(&sql, "default")?)
    }
}

// call site (anywhere in the crate or a dependent crate):
let n = CustomerLogic::new().deactivate_stale(30)?;
```

A plain method like this does **not** run the proxy hooks — no authorization or
audit. Use it for internal composition, or when you want to run the checks
yourself.

## 2. An authorized custom operation

To make a custom operation behave like a built-in one — authorized and audited
under its own `(domain, method)` name — wrap its body in `LogicExec::call_with`.
It runs the same before/after pipeline as the generated operations:

```rust
// usr/shared/logic/CustomerLogic.user.rs
impl CustomerLogic {
    pub fn recalculate(&self, ctx: &mut LogicContext) -> Result<Value, LogicError> {
        LogicExec::call_with("Customer", "recalculate", ctx, |ctx| {
            // Runs only if the principal is authorized for Customer.recalculate.
            if let Some(mut customer) = self.get(ctx.id())? {
                // ... custom work; reuse the raw ops, DBPersist, etc. ...
                self.put(&mut customer)?;
            }
            Ok(Value::Null)
        })
    }
}

// call site:
let mut ctx = LogicContext::for_id(42);
let result = CustomerLogic::new().recalculate(&mut ctx)?;
```

Because the closure captures `&self`, it can call the generated `pub(crate)`
operations (`self.get`, `self.put`, …). Those raw calls do **not** re-run the
hooks, which is what you want for composition — authorization is checked once,
at the `call_with` boundary. To authorize `Customer.recalculate`, add an
`operation` row (objectname `Customer`, methodname `recalculate`) and grant it to
the appropriate role, exactly as for the built-in methods.

## 3. Exposing a custom operation to string dispatch

The generated `dispatch` handles the standard CRUD method names. If you need a
custom operation reachable **by name** (from the API by route, or from a Rhai
script), give it a stable public method (pattern 2 above) and route to it from
your own surface — for example a thin match in an API handler, or by calling
`CustomerLogic::new().recalculate(&mut ctx)` from a script-exposed host function.
The generated dispatch deliberately does not call into the user file, so that the
generated logic always compiles regardless of user-file state.

## What not to do

- **Do not edit `<Obj>Logic.generated.rs`** (or anything under `gen/`) — it is
  overwritten every generation.
- **Do not call the raw `pub(crate)` operations from outside the `logic` crate**
  to skip authorization — you can't (they're crate-private), and the supported
  bypass is the explicit `exec_unchecked`.
