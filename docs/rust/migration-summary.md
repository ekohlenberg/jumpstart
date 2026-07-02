---
layout: default
title: Migration Summary
parent: Rust Runtime
nav_order: 9
---

# Rust Migration — Summary & Reference

This document captures the end-to-end migration of the Jumpstart-generated
application stack from .NET to **Rust**, including the architecture, the key
design decisions, the non-obvious gotchas discovered along the way, and the
self-testing application (`jumptest`) built to exercise the result.

It is intended as a future-reference orientation doc. For deeper dives, see
[Logic Dispatch](logic-dispatch.md) and [Scripting](scripting.md).

---

## 1. Goal

Make the Jumpstart code generator emit a **Rust backend** in addition to .NET,
mirroring the .NET architecture layer-for-layer but adapting to Rust where
reflection, runtime code generation, and class inheritance are unavailable. The
generated Rust app had to reach feature parity: CRUD, authorization, pre/post
triggers, parent/enum relationships, scripting, scheduled + interactive
workflows, a script agent, and real-time UI updates.

Templates live under `templates/shared/rust` and `templates/server/rust`, driven
by template-inventory CSVs: `server-rust.csv` (libraries + servers),
`test-rust.csv` (test harnesses), `tools-rust.csv` (import/export tools).

---

## 2. Crate layout

The runtime is a workspace of layered crates (lowest → highest):

| Crate | Role | Depends on |
|-------|------|-----------|
| `common` | `BaseObject`, `DomainObject` trait, `Config`, `Logger`, DB providers, `Util`, attributes/column metadata | — |
| `persist` | `DBPersist` (insert/update/put/get/select), audited vs basic strategies, `DbConnection` | `common` |
| `domain` | One generated struct per table (`TestRun`, etc.) + `columns()` metadata | `common` |
| `logic` | Per-object `…Logic` with dispatch, AOP proxy hooks, `LogicContext`, notifications | `common`, `persist`, `domain` |
| `script` | Rhai scripting engine + host bridge | `common`, `persist`, `domain`, `logic` |
| servers | `api` (rouille REST), `scheduler` (cron), `scriptagent` | `common`, `domain`, `logic` (+ `persist` for scheduler) |

**Generated vs. user code split.** Each layer separates regenerated files
(`*.generated.rs` / `*.core.rs`, `FORCE=TRUE`, overwritten every run) from
hand-editable user partials (`*.user.rs`, `FORCE=FALSE`, created once). The
`logic` crate splices them with `include!`, e.g. each object module includes
both `…Logic.generated.rs` and `usr/shared/logic/…Logic.user.rs`, so custom
operations compile into the same module as the generated type.

---

## 3. Patterns that replaced .NET mechanisms

**Reflection → generated metadata.** .NET reflected over `ColumnInfoAttribute`;
Rust generates `T::columns()` returning column descriptors, used by the persist
SQL builders and JSON typing (`to_typed_json`).

**String dispatch (AOP).** `LogicExec::call` wraps every operation with
before/after proxy hooks. `object_exec(domain, method, ctx)` /
`object_exec_unchecked(...)` map a string object name to
`…Logic::exec`/`exec_unchecked`. The `_unchecked` path bypasses authorization
and event hooks — used by servers acting on their own behalf at startup (e.g.
self-registration) and by internal logic that must not re-trigger hooks. An
`ExecProof` token gates privileged calls.

**Persistence.** `DBPersist::insert` dispatches to an audited or basic strategy
on `is_audited`. **Audited tables version rows**, so their primary key is
`txn_id`, not `id` (`id` carries only a non-unique index). Sequences are
`<schema>.<table>_identity`, starting at 1000; static/seed data uses explicit
ids `< 1000` to avoid collisions. Values are rendered as escaped SQL literals
(Postgres casts quoted literals), which round-trips string-backed
temporal/decimal/uuid values.

**Connections are per-operation.** `DbConnection::open` calls
`postgres::Client::connect` each time and drops it after — there is no pool.
(Relevant to the logging story below.)

---

## 4. Real-time updates (SignalR → SSE)

The .NET stack used SignalR; the proxy intercepted inserts/updates and published
domain-object/method notifications that web pages subscribed to. We chose
**Server-Sent Events (SSE)** as a single transport common to both the Rust and
Blazor sides.

- Publish: the proxy `run_after` hook on insert/update/put calls
  `logic::notification::publish(...)` (fire-and-forget thread). Because
  `exec_unchecked` bypasses hooks, agent/scheduler code publishes explicitly.
- Delivery: an **in-process sink** (`logic::notification::set_local_delivery`)
  lets the API deliver its own notifications directly to its SSE registry,
  avoiding loopback HTTP + hostname-resolution fragility on macOS. Cross-node
  fan-out is an HTTP POST to peer `core.server_node` URLs (skipping self).
- Blazor client subscribes with `EventSource` per domain object.

**The key SSE gotcha:** rouille buffers reader-backed response bodies (it
computes `Content-Length` up front by reading to EOF, which never comes for a
stream), so `ResponseBody::from_reader` cannot stream and the request just
hangs. The fix is rouille's `Upgrade` trait — take over the socket
(`fn build(&mut self, socket: Box<dyn ReadWrite + Send>)`) and write/flush event
frames manually on a per-connection thread.

---

## 5. Servers & ops

- **Self-registration:** each server registers a `core.server_node` row at
  startup (types Agent=1/Scheduler=2/ApiServer=3; status Online=2/Offline=4/
  Busy=3) on a background thread, and flips to Offline on `ctrlc` shutdown. Port
  ranges: api 5200–5300, agent 5100–5200, scheduler 5000–5100. `find_port` picks
  the first free port in range — **note** the Blazor client is pinned to
  `http://localhost:5200`, so a stray instance holding 5200 pushes the API to
  5201 and the UI then can't reach it.
- **Scheduler:** `cron` crate 0.17, Quartz-style 7-field expressions
  (`sec min hour dom month dow year`), `Schedule::from_str(...).after(&now).next()`.
- **Statically linked:** the release binaries are self-contained — copying the
  executable alone is sufficient (no sidecar files required at runtime).
- Build/run ergonomics: server makefiles copy the built binary plus `*.sh`/`*.cmd`
  launchers into the project `bin/`; launchers open each server in its own
  terminal window.

---

## 6. Logging (console / file / database writers)

Ported the .NET `loglevel` / `logwriters` configuration model. The Rust `Logger`
reads both from `~/.<namespace>.json` (the Rust analogue of appsettings) via a
non-panicking `Config::log_settings()`. Three writers:

- **console** → stderr.
- **file** → day-rolling `<program>.log`.
- **database** → `core.log`, supplied as a **pluggable sink** because `common`
  (where the Logger lives) may not depend on `persist`. The `logic` crate
  registers the sink via `logic::register_db_log_writer()`, called from each
  server's `init_logging`.

Level is a threshold (`debug` enables all; `error` only errors); `JUMPSTART_LOG`
overrides at runtime. With no `logwriters` set, the default is `console,file`
(database off), preserving prior behavior.

**Two hard-won lessons here:**

1. **Never do real work on the caller's logging thread.** The first version ran
   the DB insert synchronously inside `write()`. Because `DBPersist` →
   `DbConnection::open` → `Config::load_namespace_config` **panics** on a
   malformed/empty config, the very first startup log line could crash the
   server on the main thread. The fix: the DB writer is now a **background
   worker fed by a channel** — callers only enqueue a `LogRecord`; a single
   dedicated thread owns the DB work, each insert wrapped in `catch_unwind`. A
   thread-local re-entrancy guard (`IN_DB_SINK`, set for the whole worker
   thread) stops the worker's own SQL logging from re-enqueueing.
2. **A per-line synchronous DB writer is a self-inflicted load problem** given
   the no-pool connection model — at `debug` level every SQL statement spawned a
   fresh connect→insert→disconnect. Async/buffered is the correct design.

---

## 7. Self-testing app: `jumptest`

A Jumpstart metamodel that captures the software-testing domain so Jumpstart can
generate an app that tests itself (`jumptest/rust-pg`). Domain objects:

- **test_plan** → contains **test_case**s (parent FK). A test_case mirrors the
  structure of the `docs/rust-test-cases.csv` rows (code/area/title/
  preconditions/steps/expected_result/priority/component).
- **test_run** (parent: test_plan) → has **test_result**s.
- **test_result** (parents: test_run + test_case; enum: **test_result_status** =
  Unexecuted/Pass/Fail; RWK on test_run_id + test_case_id).

**Generate behavior (user code, not folded into core generation):**
Right-click a plan on the **ListTestPlan** page → **Generate** →
`TestPlanLogic::generate(plan_id)` creates a new `test_run`, then one
*Unexecuted* `test_result` per active case. Wired through:

- `usr/shared/logic/TestPlanLogic.user.rs` — the `generate` op.
- `usr/server/api/user_api.rs` — custom route `POST /api/testplan/generate/{id}`,
  exposed via the API's user-route hook (a `FORCE=FALSE` stub the generated
  router falls through to).
- `usr/web/pages/ListTestPlan.razor` — `DataTableContextMenu` convention copied
  from `ListWorkflowCore`; the table's nav menu is pointed at the custom page via
  the `test_plan` **URI override** in the metadata.
- `usr/database/data/test-data.sql` — seeds the three statuses (+ sample plan/
  cases/run).

---

## 8. Gotchas worth remembering

- **RazorLight templating:** `@@` → `@`, `&at;` → `@`; a lone `@` is a directive,
  so stray `@` in generated Rust (e.g. `println!("{}@{}")`) gets eaten — escape
  as `@@`. Always check templates for unintended `@`.
- **Audited PK is `txn_id`.** `ON CONFLICT (id)` fails with "no unique or
  exclusion constraint matching"; use `ON CONFLICT (txn_id)` for idempotent
  seeds.
- **Reference/enum data isn't auto-seeded.** `app.test_result_status` had no
  generated static data, and the loader only loads generated files — so the
  hand-written `usr/database/data` seed must be applied explicitly. It is now
  wired into `make database` and available standalone via `make seed`
  (`load-usr.sh`/`load-usr.py`, reusing the same `~/.jumptest.json` config).
- **`config` JSON shape:** `loglevel`/`logwriters` are **siblings** of
  `datasources`, not nested inside it. A broken edit makes
  `load_namespace_config` panic on first DB use.
- **Launcher terminals hide crashes.** The `*.sh`/`*.cmd` launchers open a
  window that closes on exit; run the binary directly (`./api`) to see a panic.
- **`build.py` runs the monolithic `…database.create.generated.sql`**, which is
  where `core.log` (and other core tables) are actually created — individual
  `*.table.generated.sql` files don't include the core schema.

---

## 9. Status

The Rust stack compiles and the generated `jumptest` application is functional:
CRUD, menus, authorization, scripting, scheduled + interactive workflows, the
script agent, server self-registration, real-time SSE updates, and the
plan→run→result generate flow all work. The architecture carries a noted TODO to
make notification fan-out and the DB log writer more horizontally scalable
(buffered/queued delivery, connection reuse).
