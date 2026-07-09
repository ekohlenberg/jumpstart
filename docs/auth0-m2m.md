---
layout: default
title: M2M Authentication
nav_order: 6
---
			
# M2M Authentication

This guide covers machine-to-machine (M2M) authentication between the generated servers: the API, the Scheduler, and the ScriptAgent. For the browser-facing SPA login flow, see [Auth0 Setup](auth0-setup.md).

---

## Overview

> **Simplified model (recommended).** All server components — API, Scheduler, ScriptAgent — share **one audience** and **one M2M application**. Every server validates inbound tokens against the single audience, and every server-to-server call (API → Scheduler, Scheduler → ScriptAgent, and notification publishing → API) requests a token for that same audience using that same client. This is the shape the Rust runtime now uses; the per-service model below is still supported as a fallback but is no longer necessary.

**One Auth0 resource server (audience)** for the whole application:

| Audience | Identifier         |
| -------- | ------------------ |
| Service  | `https://{AppName}` |

**One M2M (`non_interactive`) Auth0 application**, granted access to that audience, used by every server for every outbound call:

| M2M Application            | Used by                        | Target Audience     |
| -------------------------- | ------------------------------ | ------------------- |
| `{AppName}-m2m-{env}`      | API, Scheduler, ScriptAgent    | `https://{AppName}` |

Every server-to-server direction — API → Scheduler, Scheduler → ScriptAgent, and **real-time notification publishing** (any process POSTs data changes to `POST /api/Notification/publish` on each online API node, which fans them out to browsers over SSE — see [Rust Runtime](rust/index.md)) — is authenticated with a token for this one audience. Because the audience and client are shared, there is nothing to key per service: the same credentials work everywhere.

<details>
<summary><strong>Legacy per-service model</strong> (still supported)</summary>

The original design registered three audiences (`https://{AppName}-api`, `-scheduler`, `-scriptagent`) and multiple M2M applications, keyed per called service. The Rust config still reads those `auth0.audiences` / `auth0.m2m_clients` maps **when the shared `audience` / `m2m_client` fields are absent**, so existing deployments keep working without changes. New setups should prefer the single shared audience + client above.

</details>

---

## Auth0 configuration (simplified model)

For the single shared-credential model, the Auth0 dashboard setup is minimal:

1. **Create one API** (Applications → APIs → Create API). Set its **Identifier** to your chosen audience, e.g. `https://{AppName}` — this becomes `auth0.audience`. Signing algorithm RS256 (the default).
2. **Create one Machine-to-Machine application** (Applications → Applications → Create Application → Machine to Machine), and authorize it for the API from step 1 (no scopes required). Its **Client ID / Client Secret** become `auth0.m2m_client`.
3. **Point the SPA login at the same audience.** The browser app should request user tokens for `https://{AppName}` (the API audience) so the API validates user JWTs and M2M JWTs against the same audience. See [Auth0 Setup](auth0-setup.md).

That's the entire Auth0 side — one API, one M2M app, one grant. You can delete the extra per-service audiences and M2M applications if you created them earlier.

---

## Automated Setup (legacy per-service layout)

The `setup-auth0` tool (`templates/tools/setup-auth0`) automates the legacy multi-audience layout:

```bash
dotnet run -- --token <AUTH0_MGMT_TOKEN> --env dev --domain your-tenant.auth0.com
```

It performs, in order:

1. Registers the three resource servers/audiences.
2. Registers the Blazor SPA application.
3. Registers the M2M applications above.
4. Creates client grants: API-server M2M → Scheduler audience, Scheduler M2M → ScriptAgent audience.
5. Writes `credentials-<env>.json` containing all client IDs/secrets and audiences.

Paste the values from `credentials-<env>.json` into the appsettings files described below.

> **Note — notification grant.** The publisher → API (notification) grant is newer than the two dispatch grants and your `setup-auth0` version may not create it yet. If inter-service dispatch works but real-time notifications return 401, add a client grant from the notification M2M application to the **api** audience manually: Auth0 dashboard → Applications → APIs → the `api` API → **Machine to Machine Applications** → authorize the app (no scopes required). You can reuse an existing M2M application for this rather than creating a dedicated one.

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

If the .NET servers publish real-time notifications to an Auth0-protected API, add an `Api` M2M client the same way — target audience `https://{AppName}-api` — to each publisher's `M2MClients` (the Scheduler and ScriptAgent, plus the API itself in a multi-node deployment), so the notification `HttpClient` carries a bearer token for `/api/Notification/publish`.

---

## Configuration — Rust (`~/.<namespace>.json`)

The Rust servers read everything at **runtime** from this application's own `~/.<namespace>.json` — the same per-app file that already holds `datasources` for the database connection (see [Auth0 Setup](auth0-setup.md) for why this file, not `~/.jumpstart.json`, is the right place). One `auth0` section, with a **single shared audience and a single shared M2M client**, covers all three servers:

```json
{
  "namespace": "my-app",
  "datasources": { "default": { "...": "..." } },
  "auth0": {
    "domain": "your-tenant.auth0.com",
    "audience": "https://my-app",
    "m2m_client": {
      "client_id":     "SHARED_M2M_CLIENT_ID",
      "client_secret": "SHARED_M2M_CLIENT_SECRET"
    }
  }
}
```

Put this **same `auth0` block in every server's config** (or, if they share a home directory / config file, it's literally one file). Every server validates inbound tokens against `audience` and mints outbound M2M tokens with `m2m_client` for that same `audience` — API → Scheduler, Scheduler → ScriptAgent, and notification publishing → API all use it.

- **`audience`** — the one Auth0 API identifier the whole app uses. Every server validates inbound bearer tokens (user *and* M2M) against it, and every outbound M2M call requests a token for it.
- **`m2m_client`** — the one M2M application's `client_id` / `client_secret`, used for every server-to-server call. The token endpoint is derived from `domain` (`https://{domain}/oauth/token`); there's nothing to key per target.
- **Local dev / `jumptest`:** omit the whole `auth0` section (or leave `audience` empty) and every server treats Auth0 as unconfigured — inbound requests fall back to the `X-User` header and outbound calls go unauthenticated, exactly as before.
- **Legacy fallback:** if `audience` / `m2m_client` are absent but the old `audiences` / `m2m_clients` maps are present, those are still read (keyed per service), so existing configs keep working. Prefer the shared fields for new setups.

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

- **Inbound.** `authenticate_inbound(service, auth_header)` looks up `Config::auth0_settings(service)`; if present, it validates the bearer token's RS256 signature against the tenant's JWKS (`https://{domain}/.well-known/jwks.json`, cached 10 minutes, force-refreshed once on an unrecognized `kid` to handle key rotation), plus audience/issuer/expiry. The API's main loop maps `AuthOutcome::Authenticated` to the request's principal (email/`sub`) for the logic-layer authorization check; the Scheduler and ScriptAgent, which have no per-user principal, just use it as an allow/deny gate. With the shared model, `auth0_settings` returns the single `auth0.audience` regardless of the `service` argument.
- **Outbound.** `m2m_token(target_service)` looks up `Config::m2m_client_settings(target_service)`; if present, it POSTs `grant_type=client_credentials` to `https://{domain}/oauth/token` and caches the token, refreshed 60 seconds before expiry (mirroring the .NET provider). Three call sites attach the returned token as a `Bearer` header: the API's `workflow_run` handler, the Scheduler's dispatch-to-agent call, and `logic::notification::publish` when fanning a change out to other API nodes over `POST /api/Notification/publish`. With the shared model, `m2m_client_settings` returns the single `auth0.m2m_client` + `auth0.audience` regardless of the `target_service` argument — so all three call sites use identical credentials — and if it returns `Ok(None)` (unconfigured), the call is simply made unauthenticated. That's why real-time notifications work with Auth0 off but return 401 once the API enforces its audience and the publisher has no client configured.

---

## Troubleshooting

| Error                                                                                                                                                                          | Cause                                                                                          | Fix                                                                                                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Inter-service calls return 401                                                                                                                                                 | M2M client not granted access to the target audience                                           | Re-run `setup-auth0`, or manually create the client grant in Auth0 (Applications → APIs → target API → Machine to Machine Applications)                                                                    |
| `M2MTokenProvider: M2MClients config section not found` (.NET)                                                                                                                 | `M2MClients` section missing from appsettings.json                                             | Add the section as shown above; calls proceed unauthenticated until then                                                                                                                                   |
| `M2MTokenProvider: token fetch failed` (.NET)                                                                                                                                  | Wrong `TokenEndpoint`, `ClientId`, or `ClientSecret`                                           | Verify values against `credentials-<env>.json`                                                                                                                                                             |
| Audience mismatch (.NET)                                                                                                                                                       | `Audience` in `M2MClients:*` doesn't match the target service's `Auth0:Audience`               | Ensure `M2MClients:Scheduler:Audience` equals the Scheduler's own `Auth0:Audience`, and likewise for ScriptAgent                                                                                           |
| `scheduler: JWT validation failed: ...` / `scriptagent: JWT validation failed: ...` (Rust, logged)                                                                             | Bad signature, wrong audience/issuer, or expired token reaching that server                    | Verify the caller used `m2m_client_settings` for the right target (`scheduler` or `scriptagent`), and that tenant/audience match the receiving service's `auth0.audiences` entry                           |
| `workflow run {id}: M2M token fetch failed, calling unauthenticated: ...` / `scheduler: M2M token fetch failed, dispatching workflow {id} unauthenticated: ...` (Rust, logged) | Wrong `client_id`/`client_secret` in `auth0.m2m_client`, or the token endpoint is unreachable | Verify `auth0.m2m_client` credentials against your M2M application; the call still proceeds unauthenticated, so this degrades to the same 401 as an unconfigured M2M client rather than failing outright |
| Rust API returns 503 for `GET /api/Workflow/run/{id}`                                                                                                                          | No online `Scheduler` row in `core.server_node`                                                | Start (or check the registration of) a Scheduler process for this namespace                                                                                                                                |
| `notification: publish to {url} failed: ... status code 401` (Rust, logged) — real-time updates stop working                                                                  | The publishing process (Scheduler / ScriptAgent / other API node) has no `auth0.m2m_client` (or its M2M app isn't granted to the audience), so its publish POST reaches the API's inbound gate with no valid token | Ensure `auth0.audience` and `auth0.m2m_client` are set in that process's `~/.<namespace>.json`, and grant the shared M2M app access to the audience in Auth0. A single API node needs neither — it delivers its own notifications in-process. |
