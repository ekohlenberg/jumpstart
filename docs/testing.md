---
layout: default
title: Testing & Tools
nav_order: 8
---

# Testing & Tools

Jumpstart generates its test tooling alongside the application: the `test-dotnet` / `test-rust` definitions produce per-layer integration harnesses, the `tools-dotnet` / `tools-rust` definitions produce CSV data utilities, and the repository includes `jumptest` — an application Jumpstart generates in order to test itself.

## Generated Test Harnesses

Each harness is a small executable in `gen/test/<name>` with a makefile that builds and runs it against your configured database (`~/.<namespace>.json`).

| Harness | .NET | Rust | What it exercises |
|---------|------|------|-------------------|
| `test-persist` | ✓ | ✓ | Seeds an admin role/principal, then inserts and updates every non-core domain object twice with generated test data, selecting each record back after write to verify round-trips (types, audit columns, row-versioning) |
| `test-script` | ✓ | ✓ | The script host: compiles/runs stored scripts (C# on .NET, Rhai on Rust) and verifies results, errors, and return codes |
| `test-scheduler` | ✓ | ✓ | Builds workflow trees (folders, sequences) and drives the scheduler's dispatch REST surface |
| `test-scriptagent` | ✓ | ✓ | Drives the agent's `/api/scriptagent/execute` end to end |
| `test-api` | ✓ | -- | HTTP integration tests against every generated REST endpoint (Rust port is on the roadmap) |
| `test-impexp` | ✓ | -- | Round-trips data through the import/export tools |

```bash
make -C gen/test/test-persist
```

### Generated test data

The metadata's `TEST_DATA_SET` column drives value generation: each named set (e.g. `companies`, `emailAddresses`) produces realistic values for that column in `test-persist`. Objects are seeded in topological (parent-first) order so foreign keys always resolve.

## Data Tools: import / export

`gen/tools/` contains CSV utilities generated in both languages:

- **`export --table <name> [--output <path>]`** — dumps all rows of a table to CSV (RFC 4180), including id and audit columns.
- **`import`** — loads CSV files into tables. Import runs the persistence layer in **import mode** (`set_import_mode(true)`): pre-assigned `id`/`txn_id` values in the files are preserved rather than replaced from the identity sequence, so foreign key references baked into the data stay valid. No other binary enables this mode.

The .NET tools additionally include `setup-auth0`, which automates Auth0 tenant configuration (see [M2M Authentication](auth0-m2m.md)).

## jumptest: the Self-Testing Application

[`jumptest/`](../jumptest/) is a Jumpstart metamodel of the software-testing domain — so Jumpstart can generate an application that tests Jumpstart. It doubles as the reference example of a complete project, including every customization pattern.

### Domain model (`jumptest/rust-pg/jumptest.csv`)

- **test_plan** — contains **test_case**s (parent FK); each case carries code, area, title, preconditions, steps, expected result, priority, component
- **test_run** (parent: test_plan) — has **test_result**s
- **test_result** (parents: test_run + test_case; enum: **test_result_status** = Unexecuted / Pass / Fail)

### Build pipeline (`jumptest/rust-pg/makefile`)

```makefile
build:                       # generate everything
	@jumpstart ./jumptest.csv database-pgsql
	@jumpstart ./jumptest.csv server-rust
	@jumpstart ./jumptest.csv web-nodejs
	@jumpstart ./jumptest.csv tools-rust
	@jumpstart ./jumptest.csv test-rust

database:                    # DDL + generated seed + usr/ seed
seed:                        # apply only the hand-written seed (idempotent)
server: web: test: tools:    # build each piece into bin/
```

### The custom "Generate" flow

Right-clicking a plan on the test-plan list page and choosing **Generate** creates a new `test_run` with one *Unexecuted* `test_result` per active case. It demonstrates every `usr/` extension point working together:

| Piece | File |
|-------|------|
| Custom logic operation | `usr/shared/logic/TestPlanLogic.user.rs` — the `generate` op |
| Custom API route | `usr/server/api/user_api.rs` — `POST /api/testplan/generate/{id}` |
| Custom page + context menu | `usr/web/` list page, following the `ListWorkflowCore` convention |
| Route override | the `test_plan` `URI` column in the metadata points the nav menu at the custom page |
| Hand-written seed | `usr/database/data` — statuses + sample plan/cases (applied by `make seed`) |

Manual regression cases for the platform itself live in `jumptest/test-data/` (testplan.csv, testcase.csv), importable with the import tool.
