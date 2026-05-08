---
name: duckcreek-forms-debug
description: Debug and work with the DuckCreek Forms API in this framework. Covers the dual-user architecture, valid HTTP response codes, XML status handling, and session extraction pattern.
---

# DuckCreek Forms API

This is the most important thing to understand about the DuckCreek integration — it behaves in ways that look like failures but are completely normal and expected.

## Dual-User Architecture

There are TWO separate user accounts involved and they **never match by design**:

| Role | Account | Purpose |
|------|---------|---------|
| UI Login User | e.g. `CLAS_UI_USER` | Logs into CLAS browser, opens quotes, generates the DuckCreek session ID |
| API Service Account | e.g. `DC_API_USER` | Used ONLY for Basic Auth on `/duckcreek/dctserver.aspx` calls |

These users are different on purpose. Do not try to make them match.

## Session ID Extraction

1. Playwright logs into CLAS with the UI user
2. Opens a quote page (DuckCreek nav menu must be visible)
3. Extract `DuckCreek_SessionId` cookie via Playwright: `context.CookiesAsync()` → find `DuckCreek_SessionId`
4. Cookie format is colon-separated hex: `9CFEB9B9:33C24A91:8152E654:...`
5. Use this exact format in `Session.resumeRq` — do NOT strip the colons

## Valid HTTP Response Codes

| Code | Meaning | Action |
|------|---------|--------|
| `200` | Success — forms XML returned | Parse and validate |
| `500` | Session user mismatch (API user ≠ UI user) — still contains forms XML | Parse and validate |
| `400` | XML or manuscript mismatch | Investigate manuscript name |
| `401` | Bad username/password | Real auth failure — fail the test |
| `403` | API user lacks permission | Real auth failure — fail the test |

**Both 200 AND 500 are valid.** Both contain the `printDoc` forms output needed for validation. Only fail on 401/403.

## XML Status Handling

`Session.resumeRs status='failure'` in the XML response does NOT mean the call failed. It means the API service account is not the same user who generated the session ID — which is always true and always expected.

The XML **still contains the printDoc forms output**. Parse it regardless of the status attribute.

Common XML messages that are EXPECTED and should NOT trigger test failures:
- `Session.resumeRs status='failure'`
- `DataStoreMissing`
- `User not logged in`

## API Call Structure

```xml
POST {DuckCreekForms:ServerBaseUrl}/duckcreek/dctserver.aspx
Authorization: Basic {DuckCreekForms:Username credentials}

<Session.resumeRq sessionID="9CFEB9B9:33C24A91:8152E654:..." />
```

## Config Locations

- API credentials: `appsettings.json` → `DuckCreekForms` section (`Username` / `Password` — set via env var)
- UI login credentials: `appsettings.json` → `QAExpressCreds` section (set via env var)

## Rules for Automation Code

- Accept HTTP 200 AND 500 as valid — never fail on 500
- Always parse `printDoc` elements regardless of XML `status` attribute
- Never log a warning or assertion failure on `Session.resumeRs status='failure'`
- Only fail on HTTP 401 or 403
- Session ID must come from the CLAS browser cookie — `Session.loginRq` is not supported on this server
