---
layout: default
title: M2M Authentication
nav_order: 6
---

# M2M Authentication

This guide covers machine-to-machine (M2M) authentication between the generated servers: the API, the Scheduler, and the ScriptAgent. For the browser-facing SPA login flow, see [Auth0 Setup](auth0-setup.md).

---

## Overview

Three Auth0 resource servers (audiences) are registered, one per service:

| Audience | Identifier |
|----------|------------|
| API | `https://{AppName}-api` |
| Scheduler | `https://{AppName}-scheduler` |
| ScriptAgent | `https://{AppName}-scriptagent` |

Two M2M (`non_interactive`) Auth0 applications are created to call between these services:

| M2M Application | Calls | Target Audience |
|------------------|-------|------------------|
| `{AppName}-api-server-m2m-{env}` | API → Scheduler | `https://{AppName}-scheduler` |
| `{AppName}-scheduler-m2m-{env}` | Scheduler → ScriptAgent | `https://{AppName}-scriptagent` |

ScriptAgent only receives calls — it does not need its own M2M client.

---

## Automated Setup

The `setup-auth0` tool (`templates/tools/setup-auth0`) automates all of the above:

```bash
dotnet run -- --token <AUTH0_MGMT_TOKEN> --env dev --domain your-tenant.auth0.com
```

It performs, in order:

1. Registers the three resource servers/audiences.
2. Registers the Blazor SPA application.
3. Registers the two M2M applications above.
4. Creates client grants: API-server M2M → Scheduler audience, Scheduler M2M → ScriptAgent audience.
5. Writes `credentials-<env>.json` containing all client IDs/secrets and audiences.

Paste the values from `credentials-<env>.json` into the appsettings files described below.

---

## Configuration — .NET (`appsettings.json`)

### API Server (`usr/server/api/appsettings.json`)

```json
{
  "Auth0": {
    "Domain": "your-tenant.auth0.com",
    "Audience": "https://{AppName}-api"
  },
  "M2MClients": {
    "Scheduler": {
      "TokenEndpoint": "https://your-tenant.auth0.com/oauth/token",
      "ClientId":      "API_SERVER_M2M_CLIENT_ID",
      "ClientSecret":  "API_SERVER_M2M_CLIENT_SECRET",
      "Audience":      "https://{AppName}-scheduler"
    }
  }
}
```

### Scheduler Server (`usr/server/scheduler/appsettings.json`)

```json
{
  "Auth0": {
    "Domain": "your-tenant.auth0.com",
    "Audience": "https://{AppName}-scheduler"
  },
  "M2MClients": {
    "ScriptAgent": {
      "TokenEndpoint": "https://your-tenant.auth0.com/oauth/token",
      "ClientId":      "SCHEDULER_M2M_CLIENT_ID",
      "ClientSecret":  "SCHEDULER_M2M_CLIENT_SECRET",
      "Audience":      "https://{AppName}-scriptagent"
    }
  }
}
```

`ClientId`/`ClientSecret` come from the corresponding M2M application; `Audience` is the *target* service's audience (the one being called), not the caller's own audience.

---

## Configuration — Rust (`~/.<namespace>.json`)

The Rust servers read everything at **runtime** from this application's own `~/.<namespace>.json` — the same per-app file that already holds `datasources` for the database connection (see [Auth0 Setup](auth0-setup.md) for why this file, not `~/.jumpstart.json`, is the right place). One `auth0` section covers all three servers, since they share a tenant:

```json
{
  "namespace": "my-app",
  "datasources": { "default": { "...": "..." } },
  "auth0": {
    "domain": "your-tenant.auth0.com",
    "audiences": {
      "api":         "https://my-app-api",
      "scheduler":   "https://my-app-scheduler",
      "scriptagent": "https://my-app-scriptagent"
    },
    "m2m_clients": {
      "scheduler": {
        "client_id":     "API_SERVER_M2M_CLIENT_ID",
        "client_secret": "API_SERVER_M2M_CLIENT_SECRET"
      },
      "scriptagent": {
        "client_id":     "SCHEDULER_M2M_CLIENT_ID",
        "client_secret": "SCHEDULER_M2M_CLIENT_SECRET"
      }
    }
  }
}
```

- **`audiences`** — each service's own inbound audience, keyed by service name (`api`, `scheduler`, `scriptagent`). Every service reads only its own entry when validating inbound tokens.
- **`m2m_clients`** — credentials for calling *another* service, keyed by the **called** service: `scheduler` is the API's credentials for calling the Scheduler; `scriptagent` is the Scheduler's credentials for calling a ScriptAgent. There's no `api` entry — nothing calls the API over M2M — and no client for ScriptAgent to use, since it never calls out.
- Unlike the .NET layout, there's no separate `TokenEndpoint` or duplicated target `Audience` per M2M client: the token endpoint is derived from `domain` (`https://{domain}/oauth/token`), and the target audience is looked up from `audiences[<called service>]` — so it can't drift out of sync with what that service actually validates against.
- If a service's `audiences` entry is absent, its inbound requests are allowed through unauthenticated (matching .NET's "no Auth0 configured" fallback, for local development / `jumptest`). If an `m2m_clients` entry is absent for a target, that outbound call is made unauthenticated instead of failing.

---

## How It Works at Runtime

### .NET

`M2MTokenProvider` (singleton, initialized via `M2MTokenProvider.Initialize(builder.Configuration)` in `Program.cs`) implements the OAuth2 client-credentials flow:

- For each configured service key (`Scheduler`, `ScriptAgent`), it POSTs `grant_type=client_credentials` with `client_id`, `client_secret`, and `audience` to `TokenEndpoint`.
- Tokens are cached per service key and refreshed once they're within 60 seconds of expiry. Concurrent requests for the same key share a lock so only one refresh hits Auth0 at a time.
- `M2MAuthHandler` (a `DelegatingHandler`) attaches the cached token as a `Bearer` header to every outgoing request made by `SchedulerClient` and `ScriptAgentClient`.

If the `M2MClients` configuration section is absent or empty, `M2MTokenProvider.Instance` is `null` and `SchedulerClient`/`ScriptAgentClient` fall back to making unauthenticated calls — useful for local development without Auth0.

### Rust

`common::auth0` (in `templates/shared/rust/common/auth0.rs.cshtml`, shared by all three servers) implements the same flow:

- **Inbound.** `authenticate_inbound(service, auth_header)` looks up `Config::auth0_settings(service)`; if present, it validates the bearer token's RS256 signature against the tenant's JWKS (`https://{domain}/.well-known/jwks.json`, cached 10 minutes, force-refreshed once on an unrecognized `kid` to handle key rotation), plus audience/issuer/expiry. The API's main loop maps `AuthOutcome::Authenticated` to the request's principal (email/`sub`) for the logic-layer authorization check; the Scheduler and ScriptAgent, which have no per-user principal, just use it as an allow/deny gate.
- **Outbound.** `m2m_token(target_service)` looks up `Config::m2m_client_settings(target_service)`; if present, it POSTs `grant_type=client_credentials` to `https://{domain}/oauth/token` and caches the token, refreshed 60 seconds before expiry (mirroring the .NET provider). The API's `workflow_run` handler and the Scheduler's dispatch-to-agent call both attach the returned token as a `Bearer` header; if `m2m_token` returns `Ok(None)` (unconfigured), they log nothing and simply call unauthenticated.

---

## Troubleshooting

| Error | Cause | Fix |
|-------|-------|-----|
| Inter-service calls return 401 | M2M client not granted access to the target audience | Re-run `setup-auth0`, or manually create the client grant in Auth0 (Applications → APIs → target API → Machine to Machine Applications) |
| `M2MTokenProvider: M2MClients config section not found` (.NET) | `M2MClients` section missing from appsettings.json | Add the section as shown above; calls proceed unauthenticated until then |
| `M2MTokenProvider: token fetch failed` (.NET) | Wrong `TokenEndpoint`, `ClientId`, or `ClientSecret` | Verify values against `credentials-<env>.json` |
| Audience mismatch (.NET) | `Audience` in `M2MClients:*` doesn't match the target service's `Auth0:Audience` | Ensure `M2MClients:Scheduler:Audience` equals the Scheduler's own `Auth0:Audience`, and likewise for ScriptAgent |
| `scheduler: JWT validation failed: ...` / `scriptagent: JWT validation failed: ...` (Rust, logged) | Bad signature, wrong audience/issuer, or expired token reaching that server | Verify the caller used `m2m_client_settings` for the right target (`scheduler` or `scriptagent`), and that tenant/audience match the receiving service's `auth0.audiences` entry |
| `workflow run {id}: M2M token fetch failed, calling unauthenticated: ...` / `scheduler: M2M token fetch failed, dispatching workflow {id} unauthenticated: ...` (Rust, logged) | Wrong `client_id`/`client_secret` in `auth0.m2m_clients`, or the token endpoint is unreachable | Verify `auth0.m2m_clients.<target>` against `credentials-<env>.json`; the call still proceeds unauthenticated, so this degrades to the same 401 as an unconfigured M2M client rather than failing outright |
| Rust API returns 503 for `GET /api/Workflow/run/{id}` | No online `Scheduler` row in `core.server_node` | Start (or check the registration of) a Scheduler process for this namespace |
