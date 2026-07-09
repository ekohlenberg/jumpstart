---
layout: default
title: Scripting with Rhai
parent: Rust Backend
nav_order: 2
---

# Scripting with Rhai

The .NET backend executes database-stored scripts in process using Roslyn (C#),
PowerShell, and Python. The Rust backend uses **[Rhai](https://rhai.rs)**,
an embedded scripting language written in Rust. Rhai is compiled into the
binary, needs no external toolchain, runs instantly (it is interpreted), and is
**sandboxed**: a script can do nothing the host does not explicitly grant it.

Scripts are stored in the `core.script` table (the `source`, `name`, and
`script_type_id` columns) and run by the `script` crate.

## The host surface

| Type | Role |
|------|------|
| `ScriptContext` | The execution context: the `transaction` record, `args`, the captured `script_result`, an optional `script_exception`, and a `ret_code`. |
| `ScriptProvider` | Trait for an engine that compiles + executes a script. |
| `RhaiProvider` | The Rhai implementation: builds a sandboxed engine, registers the capabilities, runs the script. |
| `ScriptProviderFactory` | Selects a provider for a script type (Rhai today; other engines can be added). |
| `ScriptHost` | Runs a `core.script` record against a `ScriptContext`. |

## Running a script

```rust
use common::BaseObject;
use script::{ScriptContext, ScriptHost};
use serde_json::json;

// A core.script-shaped record (normally loaded from the database):
let mut script = BaseObject::new();
script.set("name", json!("greet"));
script.set("source", json!(r#"log_info("hello from rhai"); 40 + 2"#));
script.set("script_type_id", json!(0));

let mut ctx = ScriptContext::new();
ScriptHost::invoke(&mut ctx, &script)?;

// ctx.script_result == Some(json!(42))
```

`ScriptHost::invoke` resets the context's result/exception/ret_code, selects a
provider, executes, and surfaces failures: an engine error propagates as a
`ScriptError`, and a non-zero `ret_code` set by the script is also treated as an
error.

## Capabilities

A bare Rhai engine has **no** I/O. The host registers exactly the following
functions; a script can call these and nothing else.

### Logging

```rhai
log_info("informational message");
log_debug("debug detail");
log_error("something went wrong");
```

### Web requests

Blocking HTTP via the `ureq` client:

```rhai
let body = http_get("https://api.example.com/rates/latest");
log_info(`fetched ${body.len()} bytes`);

let response = http_post("https://hooks.example.com/notify", "{\"event\":\"settled\"}");
```

### Database access — through the Logic layer

Database functions route through `<Obj>Logic::exec`, so every script DB call is
**authorized and audited** exactly like application code (see
[Logic & the Dispatch Model](logic-dispatch.md)). Objects are addressed by
their PascalCase domain name or snake_case table name; records are object maps.

```rhai
// read one record by id (returns an object map, or () if not found)
let c = db_get("Customer", 42);
if c != () {
    log_info(`customer name: ${c.name}`);
}

// read all active records (returns an array of object maps)
let rows = db_select("OpRole");
log_info(`role count: ${rows.len()}`);

// insert-or-update; returns the saved record (with its assigned id)
let saved = db_put("Customer", #{ name: "Acme", org_id: 1001, is_active: 1 });
log_info(`saved id: ${saved.id}`);

// update an existing record by id
db_update("Customer", 42, #{ notes: "touched by script" });

// soft-delete by id
db_delete("Customer", 42);
```

### The trigger context

The record that triggered the script is exposed as a mutable `ctx`, and inputs
as `args`. Mutations to `ctx` are written back to the `ScriptContext` after the
run:

```rhai
log_info(`processing ${ctx.contract_ref}`);
ctx.status = "reviewed";        // written back to ctx.transaction
let key = args.lookup_key;      // a value placed in ScriptContext.args by the host
```

A script can also signal a controlled failure with a return code:

```rhai
if ctx.quantity <= 0 {
    log_error("quantity must be positive");
    let ret_code = 1;           // ScriptHost::invoke returns Err for ret_code != 0
}
```

## A worked example

A script that enriches a contract from an external price feed and records the
result — using logging, HTTP, the context, and the database together:

```rhai
log_info(`enriching contract ${ctx.contract_ref}`);

// pull a reference price from an external service
let price_json = http_get(`https://prices.example.com/${ctx.commodity_id}`);

// look up the related commodity through the Logic layer (authorized)
let commodity = db_get("Commodity", ctx.commodity_id);
if commodity == () {
    log_error("unknown commodity");
    let ret_code = 1;
} else {
    // write an audit row, again through the Logic layer
    db_put("MtmSnapshot", #{
        contract_id: ctx.id,
        commodity_name: commodity.name,
        source_price: price_json,
        is_active: 1
    });
    ctx.enriched = true;
    log_info("enrichment complete");
}
```

## Safety

The engine is configured with sandbox limits so a runaway or hostile script
cannot hang the host or exhaust memory: bounded operation count, call depth, and
string/array sizes. Combined with the capability model (no ambient I/O; DB
access is authorized through the Logic layer), this makes it safe to run scripts
authored and stored by users.

## Language notes

Rhai's syntax resembles Rust and JavaScript: `let`, `fn`, `if`, `for`,
closures, arrays (`[1, 2, 3]`), object maps (`#{ a: 1 }`), and backtick template
strings (`` `value is ${x}` ``). It is dynamically typed and is **not** Rust —
it has no borrow checker, no access to crates, and only the host functions listed
above. See the [Rhai language reference](https://rhai.rs/book/) for the full
language.
