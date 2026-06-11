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

## appsettings.json Configuration

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

## How It Works at Runtime

`M2MTokenProvider` (singleton, initialized via `M2MTokenProvider.Initialize(builder.Configuration)` in `Program.cs`) implements the OAuth2 client-credentials flow:

- For each configured service key (`Scheduler`, `ScriptAgent`), it POSTs `grant_type=client_credentials` with `client_id`, `client_secret`, and `audience` to `TokenEndpoint`.
- Tokens are cached per service key and refreshed once they're within 60 seconds of expiry. Concurrent requests for the same key share a lock so only one refresh hits Auth0 at a time.
- `M2MAuthHandler` (a `DelegatingHandler`) attaches the cached token as a `Bearer` header to every outgoing request made by `SchedulerClient` and `ScriptAgentClient`.

If the `M2MClients` configuration section is absent or empty, `M2MTokenProvider.Instance` is `null` and `SchedulerClient`/`ScriptAgentClient` fall back to making unauthenticated calls — useful for local development without Auth0.

---

## Troubleshooting

| Error | Cause | Fix |
|-------|-------|-----|
| Inter-service calls return 401 | M2M client not granted access to the target audience | Re-run `setup-auth0`, or manually create the client grant in Auth0 (Applications → APIs → target API → Machine to Machine Applications) |
| `M2MTokenProvider: M2MClients config section not found` | `M2MClients` section missing from appsettings.json | Add the section as shown above; calls proceed unauthenticated until then |
| `M2MTokenProvider: token fetch failed` | Wrong `TokenEndpoint`, `ClientId`, or `ClientSecret` | Verify values against `credentials-<env>.json` |
| Audience mismatch | `Audience` in `M2MClients:*` doesn't match the target service's `Auth0:Audience` | Ensure `M2MClients:Scheduler:Audience` equals the Scheduler's own `Auth0:Audience`, and likewise for ScriptAgent |
