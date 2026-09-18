# Framework Review Report
**Date:** 2026-05-08  
**Reviewer:** Principal Test Automation Architect  
**Scope:** Full architecture, code quality, security, DI lifecycle, BDD integrity, selector strategy, documentation accuracy  

---

## Summary

The framework is well-structured and reflects deliberate architectural choices. The BDD layer is clean, feature files are readable, and the page-object hierarchy is sound. The documentation ecosystem (README, Onboarding Guide, Contractor Guide, Tagging Convention) is above average for an enterprise QA project.

**Two issues require immediate action before contractors are granted access:**

1. Real credentials and internal server hostnames were committed to `appsettings.json`. These have been replaced with `PLACEHOLDER` values in this review pass.
2. A hardcoded `"<your-secret-id>"` placeholder in `TestHooks.cs` caused all API scenarios to fail silently.

The remaining findings are HIGH/MEDIUM/LOW and should be addressed in priority order during the next sprint.

---

## Findings by Severity

### 🔴 BLOCK — Must fix before contractor access

---

#### BLOCK-1: Real credentials committed to `appsettings.json`

**What's wrong:**  
`appsettings.json` contained live usernames, passwords, and an OAuth client secret for four distinct credential sets: ExpertQuote, Express/CLAS, OAuth, and DuckCreek Forms. The `.gitignore` did not exclude `appsettings.json`.

**Why it matters:**  
Any developer who clones the repo, and any contractor with read access to Azure DevOps, immediately has credentials to production-adjacent QA systems. Credential rotation alone does not fully mitigate this — the pattern must be eliminated.

**Fix applied:**  
- All credential values in `appsettings.json` replaced with `"PLACEHOLDER"`.
- `Startup.cs` updated to read env-var overrides for all credential types:

| Setting | Env Var |
|---------|---------|
| `Credentials:Username` | `EQ_USERNAME` |
| `Credentials:Password` | `EQ_PASSWORD` |
| `QAExpressCreds:Username` | `EXPRESS_USERNAME` |
| `QAExpressCreds:Password` | `EXPRESS_PASSWORD` |
| `OAuthConfig:ClientSecret` | `OAUTH_CLIENT_SECRET` |
| `DuckCreekForms:Password` | `DUCKCREEK_PASSWORD` (already existed) |

**Action required:**  
- Rotate all committed credentials immediately.
- Verify the git history does not expose credentials to contractors (consider a repo filter-branch or BFG Repo Cleaner pass if contractors have history access).
- Each developer sets their own env vars locally. CI pipeline injects via pipeline secret variables.

---

#### BLOCK-2: `"<your-secret-id>"` placeholder left in `TestHooks.cs`

**What's wrong:**  
Line 143 of `TestHooks.cs`:
```csharp
var clientSecret = await _pingSecretProvider.GetSecretAsync("<your-secret-id>");
```
This literal string was passed to Ping as the secret ID. Every API scenario in CI silently fails at this call.

**Fix applied:**  
- `OAuthConfig` model gained a `PingSecretId` property.
- `TestHooks.cs` now reads from `configuration["OAuthConfig:PingSecretId"]` with an `PING_SECRET_ID` env-var fallback. A clear `InvalidOperationException` is thrown if neither is set.
- `appsettings.json` has `"PingSecretId": "PLACEHOLDER"`.

---

### 🟠 HIGH — Fix in current sprint

---

#### HIGH-1: Page objects registered as Singletons in DI — dead and dangerous

**What's wrong:**  
`Startup.cs` registers 15+ page objects (e.g. `AccountOwnerInfoPage`, `ClientSearchPage`) as `AddSingleton`. However, every step definition constructs page objects inline:
```csharp
var clientSearchPage = new ClientSearchPage(_context.Page);
```
The DI registrations are never resolved. They are dead code.

**Why it matters — two risks:**
1. **Confusion:** Newcomers and contractors may believe they can inject page objects and receive working instances. If someone removes the inline construction and injects instead, they will get a page object pointing to a stale `IPage` (from the first scenario), because Singletons are created once per DI scope but `IPage` is replaced per scenario.
2. **Maintenance trap:** As the team grows, someone will eventually "fix" the inline construction to use DI injection — and intermittent, hard-to-diagnose state-sharing bugs will result.

**Recommendation:**  
Remove all page-object singleton registrations from `Startup.cs`. Page objects are ephemeral, scenario-scoped objects. They do not belong in DI. Document the inline-construction pattern explicitly (done in the updated Onboarding Guide).

---

#### HIGH-2: `BrowserFactory` blocks on async in constructor

**What's wrong:**  
```csharp
public BrowserFactory(IConfiguration configuration)
{
    _playwright = Playwright.CreateAsync().Result;  // ← blocks
```
Calling `.Result` on a `Task` in a constructor blocks the calling thread and can cause deadlocks in contexts with a synchronization context (e.g., some test runners and ASP.NET-derived hosts).

**Why it matters:**  
While NUnit + Reqnroll happens to avoid the specific deadlock scenario today, this pattern is fragile. It will fail silently in some CI environments or if the runner is updated.

**Recommendation:**  
Use lazy initialization:
```csharp
private IPlaywright _playwright;
private readonly SemaphoreSlim _lock = new(1, 1);

public async Task<IBrowser> GetBrowserAsync(string browserType)
{
    if (_playwright == null)
    {
        await _lock.WaitAsync();
        try { _playwright ??= await Playwright.CreateAsync(); }
        finally { _lock.Release(); }
    }
    // ...
}
```
Or make `BrowserFactory` non-injectable and construct it in `BeforeScenario` where async is available.

---

#### HIGH-3: `LoadingHelpers` contains polling loops — contradicts documented standards

**What's wrong:**  
`LoadingHelpers.WaitForElementEnabledAsync` and the former `WaitForElementClickableAsync` used `while(DateTime.Now < timeout) { await Task.Delay(100); }` — the exact anti-pattern the Contractor Guide prohibits. The framework's own code broke its own documented rule.

**Fix applied:**  
Both methods now delegate to `Playwright.Assertions.Expect(locator).ToBeEnabledAsync(...)`, which uses Playwright's built-in auto-retry engine.

Additionally, `LoadingHelpers.WaitForAngularSpinnerAsync` contains two `Task.Delay()` calls (500 ms and 300 ms) for "stability." These are fragile fixed waits. Consider replacing the 500 ms pre-check delay with `locator.WaitForAsync(State.Visible, timeout: 1500)` and removing the post-spinner 300 ms delay entirely — if the app needs it, there is a missing wait somewhere downstream.

---

#### HIGH-4: `SharedEQSteps.UserVerifiesTheQuoteExistsInSearchResults` uses `Task.Delay(2000)`

**What's wrong:**  
A hardcoded 2-second delay after triggering a search.

**Fix applied:**  
Replaced with `WaitForLoadStateAsync(NetworkIdle)` which was already called immediately above it (deduplicated).

---

### 🟡 MEDIUM — Fix before next contractor intake

---

#### MEDIUM-1: README documentation of env-var overrides was inaccurate

**What's wrong:**  
The README claimed `EQ_USERNAME` and `EQ_PASSWORD` override credentials, but `Startup.cs` had no code to read those variables. Only `DUCKCREEK_PASSWORD` was actually wired.

**Fix applied:**  
`Startup.cs` now reads all env vars (see BLOCK-1 fix). README Configuration table updated to reflect reality.

---

#### MEDIUM-2: Internal server hostnames committed to `appsettings.json`

**What's wrong:**  
`DuckCreekForms:ServerBaseUrl`, `ServerBaseUrlDev`, and `CLASBaseUrlDev` pointed to internal server hostnames (`svqw-clas21`, `svdw-clas03`). These reveal internal network topology and are inaccessible to contractors.

**Fix applied:**  
Values replaced with `"PLACEHOLDER"`. These should be set via env var or `appsettings.Dev.json` on each developer's machine and in CI pipeline variables.

---

#### MEDIUM-3: Dual `ScenarioContextData` registration — confusing lifecycle

**What's wrong:**  
`ScenarioContextData` is registered in two places:
1. `BeforeTestRun` in `TestHooks.cs`: `container.RegisterFactoryAs<ScenarioContextData>().InstancePerContext()`
2. `BeforeScenario` in `TestHooks.cs`: `_scenarioContext["ContextData"] = new ScenarioContextData()`

Step classes retrieve it exclusively via `_scenarioContext["ContextData"]`. The DI factory registration (item 1) is therefore dead code.

**Why it matters:**  
Contractors or new hires who see the DI registration will assume they can inject `ScenarioContextData` into a step class constructor and get the correct instance. They will get a *different* instance (from DI) that is empty.

**Recommendation:**  
Remove the `RegisterFactoryAs<ScenarioContextData>` from `BeforeTestRun`. Keep `_scenarioContext["ContextData"]` as the single source of truth. Document the retrieval pattern (already in Onboarding Guide).

---

#### MEDIUM-4: Typo in filename `Configuration/DependancyInjection.cs`

**What's wrong:**  
File is named `DependancyInjection.cs` (missing 'e' in "Dependency").

**Recommendation:**  
Rename to `DependencyInjection.cs`. Low risk — internal file, not a public API. Rename in one commit with a clear message to avoid confusion in git blame.

---

#### MEDIUM-5: Typo in `ScenarioContextData` — `RecievedMail`

**What's wrong:**  
The legacy property is named `RecievedMail` (transposed 'i' and 'e') while the underlying model uses the correct `ReceivesMail`.

**Recommendation:**  
Add `[Obsolete]` to `RecievedMail` and add the correctly spelled `ReceivedMail` alias pointing to the same model property. This avoids breaking existing step bindings while fixing the spelling.

---

#### MEDIUM-6: `BrowserFactory.GetPageAsync` is unused dead code

**What's wrong:**  
A static method `GetPageAsync(IBrowser browser, string url)` exists on `BrowserFactory` but is never called. It creates a browser context without tracing, video, or the correct timeout configuration established by `BeforeScenario`.

**Recommendation:**  
Remove it. It exists as a POC artifact and creates a maintenance surface — someone may call it expecting full test infrastructure and get a context with no diagnostics.

---

#### MEDIUM-7: Stray files committed to the repo root

**What's wrong:**  
`Oklahoma_QuoteIDs_20260430_090553.txt` and `TestReport.html` were committed at the repository root. The first is a data export from a test run; the second is a generated test report.

**Fix applied:**  
`.gitignore` updated to exclude `*.txt` and `TestReport.html`.

**Action required:**  
Remove the files from git tracking:
```powershell
git rm --cached "Oklahoma_QuoteIDs_20260430_090553.txt"
git rm --cached "TestReport.html"
git commit -m "chore: remove stray run artifacts from repo root"
```

---

#### MEDIUM-8: `SFPHappyPath.feature` has `@Ignore` without a ticket reference

**What's wrong:**  
```gherkin
# TODO: Scenario is incomplete — missing steps from location entry onward. Tracked for completion.
@Regression @Ignore
Scenario: Create a SFP Quote and Submit for Issuance
```

The Tagging Convention requires `@Ignore` comments to include a tracking ticket reference.

**Recommendation:**  
Update the comment to reference the ADO work item: `# TODO: Scenario incomplete — tracked in AB#XXXX`.

---

### 🔵 LOW — Address when convenient

---

#### LOW-1: Solution and namespace still named `Playwright_POC`

The solution was originally named `Playwright_POC.sln`, which made the production framework appear experimental. The primary solution is now `PnC-TestAutomation.sln`; historical namespaces remain unchanged to avoid an unrelated broad refactor.

**Recommendation:**  
Rename to `PnCTestAutomation` in a dedicated refactor commit. Low urgency but worth tracking.

---

#### LOW-2: `NavigationService.GotoWithRetryAsync` uses `WaitUntilState.NetworkIdle`

`NetworkIdle` is documented by Playwright as unreliable for SPAs with background polling. It is the right choice *here* because the apps are Angular SPAs and the team has deliberately chosen 90 s navigation timeouts to absorb SSO redirect chains. This is acceptable and documented but should be noted as a known trade-off.

---

#### LOW-3: Unused imports in `SharedEQSteps.cs`

`using System.Runtime.CompilerServices` and `using System.Runtime.InteropServices` are imported but unused. Run `dotnet format` to clean these up automatically.

---

#### LOW-4: `FormsValidation.cs` at solution root

A file named `FormsValidation.cs` exists at the root of the project directory outside any folder. Confirm it belongs in `Services/` or `Helpers/` and move it to the appropriate directory.

---

## Pre-Contractor Readiness Checklist

| Check | Status |
|-------|--------|
| Real credentials removed from all committed files | ✅ Fixed |
| `<your-secret-id>` placeholder replaced | ✅ Fixed |
| Env-var overrides wired for all credential types | ✅ Fixed |
| Stray files excluded from git tracking | ✅ `.gitignore` updated |
| Polling loops replaced with Playwright Expect | ✅ Fixed |
| `Task.Delay` in SharedEQSteps removed | ✅ Fixed |
| Page object Singleton DI dead-code removed | ⬜ Pending (MEDIUM-3 and HIGH-1 — next sprint) |
| `BrowserFactory` async-in-constructor fixed | ⬜ Pending (HIGH-2 — next sprint) |
| Stray files removed from git history | ⬜ Requires manual `git rm --cached` |
| Committed credentials rotated | ⬜ Requires manual action by QA lead |

---

## Architecture Assessment

### What is working well

- **BDD layer integrity:** Feature files read cleanly without requiring C# knowledge. Gherkin step vocabulary is consistent across LOBs.
- **Selector strategy:** `GetByTestId` is used correctly for DuckCreek fields. `GetByRole` fallbacks are used appropriately. Positional selectors are rare and justified.
- **Lifecycle management:** Browser, context, and page are correctly created fresh per scenario in `BeforeScenario` and fully closed in `AfterScenario`. No stale-page risk from the hooks layer.
- **Failure diagnostics:** Trace, video, and per-step screenshot on failure is excellent. The 7-day auto-cleanup prevents disk exhaustion. The debugger-attached pause is a nice DX touch.
- **LocatorRescue:** Gated behind a feature flag and diagnostic-only; candidate locators are logged without replacing a failed required locator.
- **`ScenarioContextData` domain model:** The composition approach (domain models + legacy aliases) is a clean migration path. The comment explaining the dual structure is appropriate.
- **Multi-environment support:** `TEST_ENVIRONMENT` → config file selection → state filter logic is clean and consistent.
- **NavigationService:** Clean abstraction over navigation with retry, timeout configuration, and env-aware URL selection.
- **Documentation:** The README, Onboarding Guide, Contractor Guide, and Tagging Convention are genuinely useful and accurate (post-fixes). This is above average for a QA automation project.
