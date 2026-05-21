---
layout: default
title: Auth0 Setup
nav_order: 5
---

# Auth0 Setup Guide

Jumpstart-generated applications use [Auth0](https://auth0.com) for authentication and authorization. This guide walks through configuring Auth0 from a fresh account to a working login flow.

---

## Overview

The generated application uses two Auth0 application types:

| Type | Purpose |
|------|---------|
| **Single Page Application (SPA)** | Browser-based OIDC login for the Blazor WASM front end |
| **Machine to Machine (M2M)** | Server-to-server JWT tokens between the API, Scheduler, and ScriptAgent |

This guide covers the SPA setup. M2M setup is covered in [M2M Authentication](auth0-m2m.md).

---

## Step 1 — Create an Auth0 Account

Go to [auth0.com](https://auth0.com) and sign up for a free account. Note your **tenant domain** — it will look like:

```
dev-xxxxxxxxxxxx.us.auth0.com
```

The `.us.` regional segment is important. Make sure to use the full domain including the region when configuring your application.

---

## Step 2 — Create a Single Page Application

1. In the Auth0 Dashboard, go to **Applications → Applications**
2. Click **Create Application**
3. Give it a name (e.g. `My App`)
4. Select **Single Page Application** as the application type
5. Click **Create**

> ⚠️ **Application type matters.** Selecting "Regular Web Application" or "Native" will cause login to fail. The Blazor WASM OIDC library requires the SPA type to use the Authorization Code + PKCE flow.

---

## Step 3 — Configure the SPA Application

In your new application's **Settings** tab, fill in the following fields. Replace `http://localhost:5063` with your actual front-end URL if running on a different port.

### Allowed Callback URLs
```
http://localhost:5063/authentication/login-callback
```

### Allowed Logout URLs
```
http://localhost:5063/authentication/logout-callback
```

### Allowed Web Origins
```
http://localhost:5063
```

> These must include the full path for callback and logout URLs — Auth0 does exact matching. The web origin (domain only) is used for silent token renewal via a hidden iframe.

Scroll down and click **Save Changes**.

---

## Step 4 — Create an API

Auth0 needs a registered API resource in order to issue JWT access tokens with your audience. Without this, login will fail with `invalid_request`.

1. Go to **Applications → APIs**
2. Click **Create API**
3. Fill in:
   - **Name**: `My App API` (or any descriptive name)
   - **Identifier**: a URI uniquely identifying your API, e.g. `https://my-app-api`. This becomes the `audience` value referenced in your appsettings.
   - **Signing Algorithm**: `RS256`
4. Click **Create**

---

## Step 5 — Authorize the SPA to Access the API

1. In **Applications → APIs**, click on your new API
2. Go to the **Machine to Machine Applications** tab
3. Find your SPA application in the list and toggle it to **Authorized**
4. Click **Update**

> Even though the tab is labelled "Machine to Machine", this authorization step is required for SPA applications in newer Auth0 tenants. Without it, login fails with `"Client is not authorized to access resource server"`.

---

## Step 6 — Allow Skipping User Consent

For first-party applications (where your app and your Auth0 tenant are the same organization), you should disable the user consent prompt.

1. In **Applications → APIs**, click on your API
2. Go to the **Settings** tab
3. Enable **Allow Skipping User Consent**
4. Save

---

## Step 7 — Add Email to the Access Token

By default, Auth0 does not include the user's email in the access token (only in the ID token). The generated API uses the email claim to identify users in the authorization system. A Post-Login Action adds it.

### Create the Action

1. Go to **Actions → Library**
2. Click **Create Action → Build from scratch**
3. Name it `Add Email to Access Token`
4. Set the trigger to **Login / Post Login**
5. Click **Create**
6. Replace the code with:

```javascript
exports.onExecutePostLogin = async (event, api) => {
  api.accessToken.setCustomClaim('https://claims/email', event.user.email);
};
```

7. Click **Deploy**

### Add the Action to the Login Flow

1. Go to **Actions → Flows → Login**
2. In the right panel, find your new action
3. Drag it into the flow between **Start** and **Complete**
4. Click **Apply**

---

## Step 8 — Configure the Generated Application

### Blazor WASM (`gen/web/wwwroot/appsettings.json`)

```json
{
  "ApiBaseUrl": "http://localhost:5200",
  "Auth0": {
    "Authority": "https://your-tenant.us.auth0.com",
    "ClientId": "YOUR_SPA_CLIENT_ID",
    "Audience": "https://my-app-api"
  }
}
```

- **Authority**: your full Auth0 tenant URL including the regional segment (`.us.`, `.eu.`, etc.)
- **ClientId**: from the SPA application's Settings tab
- **Audience**: the API Identifier you chose in Step 4

### API Server (`usr/server/api/appsettings.json`)

```json
{
  "Auth0": {
    "Domain": "your-tenant.us.auth0.com",
    "Audience": "https://my-app-api"
  }
}
```

- **Domain**: bare domain only — no `https://` prefix, no trailing slash
- **Audience**: must exactly match the API Identifier from Step 4

> The API `Program.cs` constructs the JWT authority as `https://{Domain}/`. Including `https://` in the Domain value will break JWT validation.

---

## Step 9 — Add a User to the Principal Table

The generated authorization system checks the `core.principal` table against the authenticated user's email. A user must have a row there before they can be authorized for any operations.

Insert a row for your user:

```sql
INSERT INTO core.principal (first_name, last_name, email)
VALUES ('Your', 'Name', 'you@example.com');
```

Then assign them a role via `core.op_role_member`. See [Application Server](generated-application/application-server.md) for details on the role/permission schema.

---

## Troubleshooting

| Error | Cause | Fix |
|-------|-------|-----|
| `There was an error signing in` | Application type is not SPA | Change to Single Page Application in Auth0 |
| `Client is not authorized to access resource server` | SPA not authorized for the API | Step 5 — authorize in M2M Applications tab |
| `consent_required` | User consent not skipped | Step 6 — enable Allow Skipping User Consent |
| `The logout was not initiated from within the page` | `SignOutSessionStateManager.SetSignOutState()` not called before logout | Already handled in generated `LoginDisplay.razor` |
| `redirect_uri_mismatch` | Callback URL not registered in Auth0 | Add full callback URL path to Allowed Callback URLs |
| JWT claims not reaching API | Email not in access token | Step 7 — add Post-Login Action |
| `https://` in Auth0:Domain appsetting | Double-prefix breaks JWT authority | Use bare domain only in `usr/server/api/appsettings.json` |
