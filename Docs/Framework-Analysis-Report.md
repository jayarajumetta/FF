# PnC Test Automation – Framework Analysis Report

**Date:** May 8, 2026
**Branch reviewed:** `SFP_WorkflowUpgrades` (at HEAD)
**Scope:** All layers — Features, Steps, Pages, Helpers, Configuration, Services, Hooks, Tools
**Audience:** Development team, QA leads, management

---

## Executive Summary

The framework has a solid architectural foundation: Playwright + Reqnroll + NUnit, a clean Page Object Model, Dependency Injection via `Startup.cs`, and well-structured domain models. Recent additions (LocatorRescue, video/trace capture, pass telemetry, Dev state filtering) show genuine investment in reliability.

However, several categories of issues block the framework from scaling safely. The most urgent are a **security exposure** (credentials in source control), a **runtime-breaking bug** (duplicate step binding), and **DI configuration drift** (Singleton page objects that receive stale `IPage`). Below, findings are ranked by category and severity.

---

## Table of Contents

1. [CRITICAL — Security](#1-critical--security)
2. [HIGH — Runtime Bugs](#2-high--runtime-bugs)
3. [HIGH — DI / Lifecycle Errors](#3-high--di--lifecycle-errors)
4. [MEDIUM — BDD / Feature File Quality](#4-medium--bdd--feature-file-quality)
5. [MEDIUM — Architecture & Design](#5-medium--architecture--design)
6. [LOW — Code Hygiene](#6-low--code-hygiene)
7. [LOW — Tooling Gaps](#7-low--tooling-gaps)
8. [Positive Patterns Worth Preserving](#8-positive-patterns-worth-preserving)
9. [Recommended Immediate Actions (Prioritized)](#9-recommended-immediate-actions-prioritized)

---

## 1. CRITICAL — Security

### 1.1 Plaintext credentials committed to source control

| File | Lines | What is exposed |
|------|-------|-----------------|
| `appsettings.json` | ~30–45 | EQ username + password (`YDH040 / Anico456`) |
| `appsettings.json` | ~30–45 | Express credentials (`AQ7314` + 26-char password) |
| `appsettings.json` | ~30–45 | DuckCreek server + CLAS passwords |
| `appsettings.json` | ~30–45 | OAuth `ClientSecret` (`Anico1234`) |

**Why it matters:** Anyone with read access to the ADO repo has login credentials to QA systems. If the repo is ever cloned by a contractor, audited, or leaked, those credentials are compromised immediately.

**Fix:**
1. Rotate all exposed credentials now.
2. Move all secrets to environment variables (Azure DevOps pipeline variables or local `.env` files that are `.gitignore`-d).
3. Replace the values in `appsettings.json` with placeholder comments:
   ```json
   "Password": "SET_VIA_ENV_VAR_EQ_PASSWORD"
   ```
4. Use `IConfiguration` binding from env vars (already wired — just need the values removed from the file).
5. Add a pre-commit hook or pipeline scan (e.g. `trufflesecurity/trufflehog` or ADO secret scanning) to prevent re-introduction.

**Pattern to follow (already used for DUCKCREEK_PASSWORD in Startup.cs):**
```csharp
var envPassword = Environment.GetEnvironmentVariable("DUCKCREEK_PASSWORD");
if (!string.IsNullOrEmpty(envPassword))
    formsConfig.Password = envPassword;
```
Apply this same override pattern to all credential fields.

---

## 2. HIGH — Runtime Bugs

### 2.1 Duplicate step binding causes Reqnroll binding exception

**File:** `StepDefinitions/SFPSteps/SFP_InsuredSteps.cs`

```csharp
// Both methods have the exact same binding text:
[When("user Validates Primary Insured Information for SFP and continues")]
public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues() { ... }

[When("user Validates Primary Insured Information for SFP and continues")]
public async Task UserValidatesPrimaryInsuredInformationForSFPAndContinues(Table table) { ... }
```

Reqnroll treats these as an ambiguous binding and will throw at runtime for any scenario that uses this step. The `Table`-overload body comment says "Table captured for future use" but the table isn't actually consumed.

**Fix:** Remove the table-overload entirely, or if table support is needed later, rename the step text:
```csharp
// Remove the unused table overload — it duplicates the binding and breaks matching
```

### 2.2 Literal placeholder in TestHooks will break all API tests

**File:** `Hooks/TestHooks.cs`, line ~148

```csharp
var clientSecret = await _pingSecretProvider.GetSecretAsync("<your-secret-id>");
```

The string `"<your-secret-id>"` is a placeholder that was never replaced. Any scenario tagged `@API` will request this literal secret from Ping and either get a 404/error or return null, followed by the explicit throw:
```csharp
if (string.IsNullOrWhiteSpace(clientSecret))
    throw new Exception("Failed to retrieve ClientSecret from Ping.");
```

**Fix:** Replace with the actual Ping secret identifier, or move it to configuration:
```json
"OAuthConfig": {
  "PingSecretId": "your-actual-secret-id"
}
```
```csharp
var secretId = _oauthConfig.PingSecretId
    ?? throw new InvalidOperationException("OAuthConfig:PingSecretId is not configured.");
var clientSecret = await _pingSecretProvider.GetSecretAsync(secretId);
```

### 2.3 BrowserFactory uses `.Result` on an async call (deadlock risk)

**File:** `Helpers/BrowserFactory.cs`

```csharp
public BrowserFactory(IConfiguration configuration)
{
    _playwright = Playwright.CreateAsync().Result;  // ← sync-over-async
    _configuration = configuration;
}
```

`.Result` on a `Task` blocks the calling thread and can cause deadlocks in environments with a synchronization context (e.g. some test runners, ASP.NET). Playwright's own docs warn against this.

**Fix:** Initialize lazily or use `AsyncLazy<IPlaywright>`:
```csharp
private IPlaywright _playwright;

public async Task<IBrowser> GetBrowserAsync(string browserType)
{
    _playwright ??= await Playwright.CreateAsync();
    // ... rest of method
}
```

---

## 3. HIGH — DI / Lifecycle Errors

### 3.1 Page objects registered as Singleton but receive `IPage` which changes per scenario

**File:** `Startup.cs`, lines ~55–75

```csharp
services.AddSingleton<AccountOwnerInfoPage>();
services.AddSingleton<PA_AddAdditionalInterestPage>();
services.AddSingleton<BillingPage>();
// ... 12 more page objects as Singleton
```

Every page object's constructor takes `IPage`. When the first scenario runs, these singletons capture that scenario's `IPage`. On the second scenario, the `IPage` is replaced in `TestContext.Page`, but the singleton page objects still hold the original (now-closed) page. Any test that uses the DI-resolved page objects on the second-or-later scenario will interact with a closed browser context.

**Observed mitigation:** Most step definitions bypass DI entirely and instantiate pages with `new SFP_XPage(_context.Page)` — so in practice this bug is dormant but the DI registrations are incorrect and misleading.

**Fix:** Either:
- Change all page object registrations to `AddScoped<>` (one per scenario), or
- Remove the page object registrations from `Startup.cs` entirely (they're unused) and document that pages are always constructed inline.

The simpler and more honest option is **removal from DI**, since the framework pattern is clearly `new Page(_context.Page)` in step constructors. This removes dead code and eliminates confusion.

### 3.2 `ScenarioContextData` dual-registration creates a split-brain scenario

`ScenarioContextData` is registered in DI as `AddTransient` in `Startup.cs`, but all step definitions retrieve it via:
```csharp
_contextData = _scenarioContext["ContextData"] as ScenarioContextData;
```
(set in `BeforeScenario` in TestHooks).

The DI-registered instance is never used. If a developer writes new steps using constructor injection (`IScenarioContext` is not the same thing), they'll get a different `ScenarioContextData` object than the one being populated by the existing steps — a classic "where did my data go?" bug.

**Fix:** Remove the `AddTransient<ScenarioContextData>()` line from `Startup.cs`, or add a comment making the convention explicit:
```csharp
// ScenarioContextData is NOT resolved from DI. It is stored in ScenarioContext["ContextData"]
// by TestHooks.BeforeScenario. All step definitions must retrieve it via:
//   _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
```

### 3.3 Mixed service lifetimes on interdependent services

`NavigationService` is `AddScoped` (correct — one per scenario). `TestContext` is `AddSingleton`. `NavigationService` takes `TestContext` as a dependency — this is OK since `TestContext.Page` is a mutable property. But if a Scoped service depends on a Singleton, the Scoped service gets the Singleton's state, not a fresh copy. Watch for this pattern when adding new services.

---

## 4. MEDIUM — BDD / Feature File Quality

### 4.1 Invalid Gherkin — trailing comma on `@UI,`

**Files:** `SFPHappyPath.feature`, `BOPHappyPathPOC.feature`, `PersonalAutoHappyPathPOC.feature`

```gherkin
@UI,           ← invalid — commas are not part of Gherkin tag syntax
Feature: ...
```

Reqnroll is lenient about this (it strips the comma), but it's not valid Gherkin and may cause issues with tag filters or external reporting tools.

**Fix:** Remove the trailing comma: `@UI`

### 4.2 Inconsistent step person/voice within the same scenario

Many scenarios mix `Given I navigate...`, `When I enter credentials...` with `And user enters...`, `When user selects...`. Gherkin best practice is to pick one voice (1st person "I" or 3rd person "user") and apply it consistently across all feature files.

Current state:
```gherkin
Given I navigate to the Expert Quote login page    ← 1st person
When I enter valid credentials and Click LogIn     ← 1st person
And user enters a Random Name...                   ← 3rd person
And user clicks New Quote button                   ← 3rd person
```

**Fix:** Standardize on **3rd person ("user")** for new steps (aligns with most existing steps), or do a batch rename to 1st person. Either is valid; consistency is what matters.

### 4.3 No tagging convention — tags are arbitrary and incomplete

Current tags in use: `@UI`, `@ExpertQuote`, `@Smoke`, `@Regression`, `@API`

Issues:
- `SFPHappyPath.feature` has `@ExpertQuote` but no `@Smoke` or `@Regression` — it won't be selected by either standard filter.
- `BOPHappyPathPOC.feature` and `PersonalAutoHappyPathPOC.feature` have `@ExpertQuote` only.
- No LOB tags (`@SFP`, `@BOP`, `@PA`).
- No environment restriction tags.
- No owner/team tags.
- `@UI` is used as a feature-level tag but not consistently queried.

This is addressed in Phase 2 of the documentation project.

### 4.4 `SFPHappyPath.feature` is incomplete

The scenario ends mid-step without a closing `Examples` block or a final step. The last line is:
```gherkin
     | WindHailDeductible      | 2%      |
```
The feature has no `Examples:` table, so it's a non-parameterized `Scenario` (not `Scenario Outline`). But the scenario is missing all remaining workflow steps (locations, residences, coverages, pricing, submission). It appears to be a work-in-progress that was committed unfinished.

**Fix:** Either complete the scenario or mark it `@Ignore` and file a tracking ticket.

### 4.5 Hardcoded test data in BOP and PA feature files

`BOPHappyPathPOC.feature` and `PersonalAutoHappyPathPOC.feature` have literal DOB (`08/08/1944`), phone (`(907) 227-0664`), and email (`fake@email.com`) values. SFP correctly uses `{{randomDOB}}`, `{{randomPhone}}`, and `{{randomEmail}}` tokens.

Hardcoded data causes test collisions (a client with DOB `08/08/1944` may already exist), and the DOB `1944` makes the test client 81 years old — edge-case territory for many insurance products.

**Fix:** Replace BOP and PA hardcoded values with the same token pattern as SFP.

### 4.6 `MiddleName` field hijacked as `StateAbbv` carrier

**File:** `SFP_CE.feature`, line ~38

```gherkin
| MiddleName | <StateAbbv> |
```

The CE scenario passes the state abbreviation in the `MiddleName` field as a workaround. This is a data integrity issue: the client's middle name in the application will be set to the state abbreviation (e.g. "MN", "TX"). If this appears in any assertion or report, it will be wrong.

**Fix:** If the CE workflow requires the state abbreviation elsewhere, pass it through a dedicated step parameter or store it in `ScenarioContextData.Policy.RatingState` which already carries `<StateFull>`.

### 4.7 Commented-out scenario rows without explanation

**File:** `EQ_SFP_Smoke.feature`, Examples table

```gherkin
Examples:
  | State     | ...
  | Minnesota | ...
  #| Nebraska  | ...   ← why commented out?
  #| South Dakota | ...
  #| Wisconsin | ...
```

Commented-out examples with no tracking annotation create ambiguity: are these known failures? Unimplemented states? Budget-controlled runs?

**Fix:** Add an inline comment or, better, split into a separate `@Ignore` outline with a comment explaining the status.

---

## 5. MEDIUM — Architecture & Design

### 5.1 Page objects constructed with `new` in step definitions — inconsistent with DI pattern

Every step definition in the framework creates page objects inline:
```csharp
var primaryInsuredPage = new SFP_PrimaryInsuredPage(_context.Page);
var claimsPriorInsurancePage = new ClaimsPriorInsurancePage(_context.Page);
```

This is a coherent pattern (and simpler than DI for page objects), but it conflicts with the `Startup.cs` DI registrations of those same page objects. The framework appears to have started with DI injection of page objects and then migrated toward inline construction without cleaning up the DI registrations.

**Recommendation:** Commit to one approach. The inline pattern is simpler and more readable. Remove unused DI registrations for page objects.

### 5.2 Browser re-launched inside a step definition

**File:** `StepDefinitions/SharedSteps/SharedEQSteps.cs` — `UserLaunchesNewBrowserAndLogsInToExpertQuote()`

```csharp
var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chromium";
var browser = await browserFactory.GetBrowserAsync(browserType);
```

This step creates a new browser directly, bypassing `BrowserFactory.ResolveBrowserType()`, hardcoding `"chromium"` as fallback, and not registering the new browser/context/page in the DI container. The new page is assigned to `_context.Page`, but the browser and context are orphaned — they won't be closed by `AfterScenario`.

**Fix:** Centralize browser management in `TestHooks`. If a test needs to close and reopen a browser mid-scenario, add a `ReopenBrowserAsync()` method to `TestHooks` or `NavigationService`.

### 5.3 UW Questions mixed into the Primary Insured page object

`SFP_PrimaryInsuredPage.cs` contains both primary insured validation logic AND UW question answering (`AnswerUwQuestionsAsync`). These are two separate pages in the application. The file has grown to encompass multiple pages' worth of responsibility, violating Single Responsibility.

`SFP_UWQuestionsPage.cs` exists as a separate file but some UW logic is still in the Primary Insured page. The two should be cleanly separated.

### 5.4 `TableMappingHelpers` throws on unknown question keys

```csharp
default:
    throw new ArgumentException($"Unknown question: {question}");
```

Every mapper method throws on unknown questions. This means: adding a new row to a Gherkin table without updating the mapper will produce a `System.ArgumentException` at runtime rather than a helpful "unmapped field" warning. It blocks incremental development.

**Recommendation:** Log and skip unknown keys instead of throwing, or throw with more context identifying which mapper and which feature file is the source. Alternatively, keep the throw but the error message should include the file and step context.

### 5.5 `NavigationService` is registered as `AddScoped` but rarely used

`NavigationService` provides `GoToExpertQuoteAsync()` and `GoToQAExpressAsync()`. The step for navigation (`Given I navigate to the Expert Quote login page`) doesn't use it — it navigates inline in the login page's `LoginAsync`. The service is constructed per-scenario but never called by most scenarios. It should either be used consistently for navigation or removed.

---

## 6. LOW — Code Hygiene

### 6.1 Typos in class and file names

| Location | Current | Should Be |
|----------|---------|-----------|
| `Configuration/DependancyInjection.cs` | `DependancyInjection` | `DependencyInjection` |
| `Helpers/ScenarioContextData.cs` | `RecievedMail` property | `ReceivedMail` |

The typo in `DependancyInjection` exists in both the filename and the class name. Fixing it requires a rename commit, which is non-breaking since the class is not referenced by external consumers.

### 6.2 Unused `using` statements in step definitions

**File:** `StepDefinitions/SharedSteps/SharedEQSteps.cs`

Imports that have no usage in the file:
- `using System.Runtime.CompilerServices;`
- `using System.Runtime.InteropServices;`
- `using System.Net;`
- `using System.Collections.Generic;` (verify)

These increase compile time marginally and add noise. The `.editorconfig` should already flag these as warnings.

### 6.3 `Console.WriteLine` used for all diagnostic output

The codebase uses `Console.WriteLine(...)` extensively for status output. This works in NUnit (output is captured per-test), but:
- It's not structured (no severity, no category)
- It can't be filtered or redirected without code changes
- Some important operational messages (e.g. credential retrieval failure) are buried alongside trivial trace messages (e.g. `Console.WriteLine(_contextData.ClientFirstName)` called multiple times after each step)

**Recommendation:** Keep `Console.WriteLine` for now, but establish a convention for log levels:
- `Console.WriteLine($"[Info] ...")` — normal progress
- `Console.WriteLine($"[Warning] ...")` — non-fatal degraded path (already partially done)
- `Console.WriteLine($"[Debug] ...")` — verbose diagnostic that may be removed

### 6.4 File I/O for quote number passing is fragile

**Files:** `SharedEQSteps.cs`

```csharp
System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber ?? "");
```
```csharp
quoteNumber = System.IO.File.ReadAllText("QuoteNumber.txt").Trim();
```

Writing a quote number to a text file in the working directory to pass it between two test steps is fragile: it fails if tests run in parallel, and the stale-file risk exists despite the cleanup in `BeforeScenario`. `ScenarioContextData.QuoteNumber` is already in-memory — the file write/read is redundant unless the test genuinely closes and reopens the browser (which only `EQ_SFP_Smoke.feature` does).

**Fix:** Only write the file in scenarios that actually close and reopen the browser. For all others, rely on the in-memory value.

### 6.5 `BasePage.cs` has a redundant null-safe Playwright call pattern

Several locators use:
```csharp
if (await overlay.CountAsync() > 0)
    await overlay.First.WaitForAsync(...)
```
This is fine for optional elements, but in some pages this pattern is applied to required elements as a way to avoid `TimeoutException`. The result is that a missing required element silently passes, making the test unreliable. Reserve the `CountAsync()` guard for genuinely optional elements.

---

## 7. LOW — Tooling Gaps

### 7.1 LocatorScan tool exists but is not integrated into the CI pipeline

The `Tools/LocatorScan/` toolchain can scan the repo for stale test IDs. It is wired into a `.runsettings` file (`locatorscan.runsettings`) for manual execution. It is not part of any scheduled or PR-triggered pipeline.

**Recommendation:** Add a weekly or PR-triggered pipeline step that runs the locator scan and posts results as a PR comment or ADO work item. This converts a manual tool into active protection.

### 7.2 `FormsBaselineGenerator` tool is not documented

`Tools/FormsBaselineGenerator/` and the associated `generate-baseline.ps1` script are powerful utilities with no visible documentation beyond code comments. New developers will not discover them.

**Recommendation:** Add a one-page Tools guide to `Docs/`. Covered in Phase 3b (onboarding guide).

### 7.3 `Pipelines/forms-check-scheduled.yml` only covers forms validation

There is no pipeline definition for running the UI regression suite on a schedule. The forms check pipeline exists, but the main test suites (`@Smoke`, `@Regression`) have no automated scheduled execution defined in the repo.

**Recommendation:** Add a `ui-regression-scheduled.yml` that runs `@Smoke` tests nightly and `@Regression` tests weekly. (CI thresholds are recommendations only per project scope.)

---

## 8. Positive Patterns Worth Preserving

These are well-implemented — do not change them without strong justification.

| Pattern | Location | Why it's good |
|---------|----------|---------------|
| **Domain model composition** in `ScenarioContextData` | `Helpers/ScenarioContextData.cs` | Clean separation of concern, legacy aliases maintain backward compat |
| **LocatorRescueService** | `Helpers/LocatorRescueService.cs` | Proactive failure diagnosis, toggleable, non-breaking |
| **Playwright tracing + video on failure** | `Hooks/TestHooks.cs` | Industry-standard failure artifact collection |
| **State filter for Dev runs** | `Hooks/TestHooks.cs` | Prevents irrelevant tests from running against Dev — smart |
| **`BasePage.WaitForSpinnerAsync()`** | `Pages/BasePage.cs` | Centralized, reused across all pages — correct abstraction |
| **Token replacement in feature files** (`{{randomDOB}}` etc.) | `StepDefinitions/SharedSteps/SharedEQSteps.cs` | Prevents data collisions, readable in Gherkin |
| **Multi-env config via `appsettings.{env}.json`** | `Startup.cs` | Standard .NET pattern, works with DI correctly |
| **`NavigationService.GotoWithRetryAsync`** | `Services/NavigationService.cs` | SSO retry is the right call for flaky network auth flows |
| **Selector strategy documented in `BasePage`** | `Pages/BasePage.cs` — XML doc comment | Documents DuckCreek vs ANi selector distinction clearly |
| **Pass telemetry CSV** | `Hooks/TestHooks.cs` | Low-overhead, non-blocking, useful for trend tracking |
| **Auto-cleanup of old test results** | `Hooks/TestHooks.cs` | Prevents disk fill on long-running CI agents |

---

## 9. Recommended Immediate Actions (Prioritized)

> Items marked **BLOCK** should be resolved before any external contractor is given repo access.

| Priority | Item | Effort | Impact |
|----------|------|--------|--------|
| **BLOCK** | Remove all plaintext passwords from `appsettings.json`, rotate credentials | 2h | Security |
| **BLOCK** | Fix duplicate step binding in `SFP_InsuredSteps.cs` | 15m | Runtime crash |
| **BLOCK** | Replace `<your-secret-id>` placeholder in `TestHooks.cs` | 15m | Runtime crash |
| High | Fix Singleton page object DI registrations (`Startup.cs`) | 1h | Correctness |
| High | Remove `AddTransient<ScenarioContextData>` or document the pattern | 30m | Clarity |
| High | Add `@UI,` trailing comma fix to all feature files | 15m | Parser hygiene |
| Medium | Standardize BOP/PA to use `{{random*}}` tokens | 1h | Data integrity |
| Medium | Remove `MiddleName`-as-`StateAbbv` hack in CE feature | 30m | Data integrity |
| Medium | Complete or `@Ignore` the unfinished `SFPHappyPath.feature` | 1h | Test completeness |
| Medium | Fix `BrowserFactory` sync-over-async `.Result` call | 30m | Reliability |
| Medium | Fix browser re-launch in `SharedEQSteps` to use `BrowserFactory` | 1h | Resource leak |
| Low | Rename `DependancyInjection` → `DependencyInjection` | 15m | Readability |
| Low | Fix `RecievedMail` typo | 10m | Readability |
| Low | Clean up unused `using` statements in `SharedEQSteps` | 10m | Hygiene |
| Low | Restrict file write to quote number only in cross-browser scenarios | 30m | Reliability |
| Phase 2 | Implement tagging convention | — | Test management |
| Phase 3 | Documentation suite | — | Enablement |

---

*Report generated by automated analysis + manual code review. All line references are approximate and should be verified against the current branch.*
