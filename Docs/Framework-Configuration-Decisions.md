# PnC Test Automation Framework - Configuration Decisions & Improvements

**Date:** February 3, 2026  
**Prepared by:** [Your Name]  
**Document Purpose:** Framework standardization decisions and implemented improvements

---

## Executive Summary

Following a comprehensive analysis of the Playwright/Reqnroll test automation framework, I've established standardized configurations and implemented key improvements to increase reliability, maintainability, and developer experience. This document outlines all decisions made and their technical rationale.

---

## 1. Test Execution & Environment Configuration

### 1.1 Primary Execution Method
**Decision:** Visual Studio Test Explorer  
**Rationale:** Provides integrated debugging, test filtering by tags, and immediate feedback during development. CLI execution via `dotnet test` remains available for CI/CD pipelines.

### 1.2 CI/CD Tag Strategy
**Decision:** `@Smoke`, `@Regression`, `@DataGen`  
**Rationale:** 
- `@Smoke` - Fast, critical-path tests for build verification (~5-10 min)
- `@Regression` - Full test suite for nightly/release validation
- `@DataGen` - Tests that create test data in environments (run on-demand)

### 1.3 Test Artifacts Location
**Decision:** `./TestResults/{timestamp}/{ScenarioName}/`  
**Implementation:** Updated `TestHooks.cs` to organize artifacts by test run and scenario name.  
**Rationale:** 
- Timestamps prevent artifact overwrites between runs
- Scenario-named folders make debugging specific failures faster
- Consistent structure enables easy artifact retrieval in CI/CD

### 1.4 Automatic Cleanup Policy
**Decision:** 7-day retention with automatic cleanup  
**Implementation:** `CleanupOldTestResults()` method in `TestHooks.cs` runs before each test session.  
**Rationale:** 
- Prevents disk space exhaustion from accumulated traces/videos
- 7 days provides sufficient time for investigation
- Aligns with typical sprint cycle for debugging

### 1.5 Timeout Configuration
**Decision:** 30 seconds (element) / 60 seconds (navigation)  
**Implementation:** Configured in `TestHooks.cs` via `SetDefaultTimeout()` and `SetDefaultNavigationTimeout()`.  
**Rationale:**
- 30s element timeout accounts for Angular rendering and API response delays
- 60s navigation timeout handles slow page loads in lower environments
- Exceeds typical response times while failing fast on genuine issues

### 1.6 Tracing Strategy
**Decision:** On failure only  
**Implementation:** `Tracing.StartAsync()` at scenario start, `StopAsync(save)` only when `TestContext.CurrentContext.Result.Outcome != Passed`.  
**Rationale:**
- Full traces provide complete debugging information (DOM snapshots, network, console logs)
- Recording all tests would generate excessive data (~50-100MB per test)
- Failure-only capture provides maximum value with minimal overhead

### 1.7 Video Recording
**Decision:** On failure only  
**Implementation:** Browser context created with `RecordVideoDir`, video retained only on test failure.  
**Rationale:**
- Videos provide visual evidence of what went wrong
- Recording adds minimal runtime overhead
- Deleting passed test videos conserves storage

---

## 2. Loading & Synchronization Strategy

### 2.1 Wait Strategy
**Decision:** Multi-layered approach with dedicated helpers  
**Implementation:** Enhanced `LoadingHelpers.cs` with:
- `WaitForAngularSpinnerAsync()` - Waits for ngx-spinner overlay to disappear
- `DismissPopupsAsync()` - Handles unexpected modal dialogs
- `WaitForElementEnabledAsync()` - Waits for disabled buttons to become enabled
- `FillAndTabAsync()` - Fills input and tabs out to trigger Angular validation

**Rationale:**
- Expert Quote is an Angular application with asynchronous rendering
- Multiple wait conditions address different timing scenarios
- Centralized helpers ensure consistent wait behavior across all tests
- Tab-after-fill is essential for Material form validation triggers

---

## 3. Locator Architecture

### 3.1 Locator Location
**Decision:** Keep in separate factory files now; migrate into Page Objects later  
**Current State:** `ExpertQuoteLocators.cs`, `ExpertQuoteLocatorFactory.cs`  
**Rationale:**
- Immediate refactoring would delay current testing priorities
- Separate files provide single source of truth during transition
- Future migration to Page Objects will improve encapsulation

### 3.2 Locator Priority
**Decision:** Hybrid strategy - TestId preferred, Role as fallback  
**Implementation:** 
```csharp
// Preferred - uses data-testid attribute
Page.GetByTestId("fields.account.policyInput$grossFarmIncome.value")

// Fallback - semantic role-based
Page.GetByRole(AriaRole.Button, new() { Name = "Next" })
```
**Rationale:**
- `data-testid` attributes are stable, developer-controlled, and decoupled from UI changes
- Role-based locators provide accessibility testing and semantic clarity
- Avoids brittle CSS selectors and XPath

---

## 4. Page Object Design

### 4.1 Navigation Method Returns
**Decision:** Keep `void` returns (no fluent chaining)  
**Rationale:**
- Simpler debugging - each step is discrete
- Clearer stack traces on failures
- Matches existing codebase patterns
- Fluent APIs can obscure which step failed

### 4.2 Assertions in Page Objects
**Decision:** Allow lightweight ensure/guard methods  
**Example:**
```csharp
public async Task EnsurePageLoadedAsync()
{
    await Expect(PageHeader).ToBeVisibleAsync();
}
```
**Rationale:**
- Guard methods validate preconditions before actions
- Keeps step definitions focused on business logic
- Fails fast with clear error messages

---

## 5. Assertion Strategy

### 5.1 Assertion Library
**Decision:** Migrate to Playwright `Expect` for all UI assertions  
**Before:**
```csharp
Assert.That(await element.IsVisibleAsync(), Is.True, "Element should be visible");
```
**After:**
```csharp
await Expect(element).ToBeVisibleAsync();
```
**Rationale:**
- Playwright Expect has built-in auto-retry (up to 5 seconds by default)
- Eliminates explicit waits before assertions
- Better error messages with actual vs expected values
- Reduces flaky tests caused by timing issues

---

## 6. Gherkin Standards

### 6.1 Given/When/Then Semantics
**Decision:** Enforce proper BDD semantics  
**Implementation:** Updated all feature files to use correct keywords.

| Keyword | Purpose | Example |
|---------|---------|---------|
| **Given** | Preconditions, setup | `Given I navigate to the login page` |
| **When** | Action being tested | `When I enter valid credentials` |
| **And** | Continuation of previous | `And user clicks New Quote button` |
| **Then** | Assertion/verification | `Then user verifies the quote exists` |

**Before:**
```gherkin
Then user enters a Random Name...
Then user clicks New Quote button
Then user verifies the quote exists
```

**After:**
```gherkin
And user enters a Random Name...
And user clicks New Quote button
Then user verifies the quote exists
```

**Rationale:**
- Improves scenario readability and intent
- Aligns with BDD best practices
- Makes it clear which steps are setup vs verification
- Better communication with non-technical stakeholders

### 6.2 Scenario Length
**Decision:** No strict limit  
**Rationale:** Insurance quoting workflows are inherently long; artificial splitting would reduce test value.

### 6.3 Background Usage
**Decision:** Allowed when helpful  
**Rationale:** Common setup steps (login, navigation) can be shared via Background to reduce duplication.

### 6.4 Tag Standards
**Decision:** Standardized tag categories
- `@Smoke`, `@Regression` - Test suite membership
- `@UI`, `@API` - Test type
- `@WIP` - Work in progress (exclude from CI)
- `@ExpertQuote`, `@ExpertService` - Application under test
- `@DataGen` - Data generation tests

---

## 7. Test Data Token System

### 7.1 Token Naming Convention
**Decision:** Rename tokens to be self-documenting

| Old Token | New Token | Description |
|-----------|-----------|-------------|
| `{{male}}` | `{{firstName}}` | Random first name |
| `{{random}}` | `{{lastName}}` | Random last name |
| (new) | `{{today}}` | Today's date |
| (new) | `{{tomorrow}}` | Tomorrow's date |
| (new) | `{{futureDate:+Xd}}` | X days in future |
| (new) | `{{pastDate:-Xd}}` | X days in past |
| (new) | `{{randomSSN}}` | Random SSN |

**Implementation:** Updated `DateHelpers.cs`, `RandomGenerators.cs`, and `SharedEQSteps.cs`.  
**Backward Compatibility:** Legacy tokens (`{{male}}`, `{{random}}`) still work.

**Rationale:**
- `{{firstName}}` is clearer than `{{male}}` 
- Date tokens enable dynamic effective dates (no hardcoded dates that expire)
- Reduces test maintenance when dates become invalid

### 7.2 Feature File Example
```gherkin
And user enters a Random Name in the search field
  | Question  | Answer        |
  | FirstName | {{firstName}} |
  | LastName  | {{lastName}}  |

And user selects Quote Details
  | Question      | Answer                 |
  | EffectiveDate | {{futureDate:+30d}}    |
  | SSN           | {{randomSSN}}          |
```

---

## 8. Credentials Management

### 8.1 Current State
**Decision:** Keep in `appsettings.json` for now  
**Future:** Migrate to `PingSecretProvider` integration

**Rationale:**
- Current approach works for local development
- Secret provider integration requires infrastructure work
- Planned for future sprint when CI/CD is implemented

---

## 9. Codebase Cleanup

### 9.1 Deleted Files
| File/Folder | Reason |
|-------------|--------|
| `Tests/TestRunner.cs` | Orphaned - no references, duplicates Reqnroll test discovery |
| `Features/PA/PA_Smoke_NewQuoteRecall.feature.cs` | Orphaned generated file - no matching .feature |
| `MigrationData/` | Empty folder |
| `Docs/` | Empty folder (recreated for this document) |

### 9.2 Retained Files
| File | Reason |
|------|--------|
| `FormsValidation.cs` | Future utility for form validation helpers |

---

## 10. Files Modified

| File | Changes |
|------|---------|
| `Hooks/TestHooks.cs` | Tracing, video, cleanup, timeouts, folder structure |
| `Helpers/DateHelpers.cs` | New date tokens (`{{today}}`, `{{futureDate}}`, `{{pastDate}}`) |
| `Helpers/RandomGenerators.cs` | `{{randomSSN}}` token, documentation |
| `Helpers/LoadingHelpers.cs` | New helpers: `WaitForElementEnabledAsync`, `DismissPopupsAsync`, `FillAndTabAsync`, `ClickAndWaitForNavigationAsync` |
| `StepDefinitions/SharedSteps/SharedEQSteps.cs` | Updated token handling with backward compatibility |
| `Features/SFP/EQ_SFP_Smoke.feature` | Gherkin semantics, new tokens |
| `Features/SFP/SFPHappyPath.feature` | Gherkin semantics, new tokens, dynamic dates |
| `Features/PA/PersonalAutoHappyPathPOC.feature` | Gherkin semantics, new tokens, dynamic dates |
| `Features/BOP/BOPHappyPathPOC.feature` | Gherkin semantics, new tokens, dynamic dates |

---

## 11. Expected Benefits

| Improvement | Benefit |
|-------------|---------|
| Failure-only tracing/video | 90%+ reduction in artifact storage |
| Auto-cleanup | Zero manual maintenance of TestResults |
| Standardized timeouts | Consistent behavior, faster failure detection |
| Loading helpers | Reduced flaky tests from timing issues |
| Playwright Expect | Built-in retry reduces assertion flakiness |
| Gherkin standards | Improved readability, better stakeholder communication |
| Dynamic date tokens | Tests won't fail due to expired hardcoded dates |
| Token renaming | Self-documenting feature files |

---

## 12. Next Steps (Recommended)

1. **Gradual Expect Migration** - Replace `Assert.That()` with `Expect()` as tests are touched
2. **Locator Migration** - Move locators into Page Objects during page-specific work
3. **Secret Provider** - Integrate PingSecretProvider when CI/CD pipeline is established
4. **CI/CD Setup** - Configure pipeline with tag-based test filtering

---

## Appendix: Quick Reference - Configuration Decisions

```
═══════════════════════════════════════════════════════════════════════════════
                    PnC TEST AUTOMATION - CONFIGURATION SUMMARY
═══════════════════════════════════════════════════════════════════════════════

EXECUTION & ENVIRONMENT
───────────────────────────────────────────────────────────────────────────────
• Primary Execution:      Visual Studio Test Explorer
• CI Tag Strategy:        @Smoke, @Regression, @DataGen
• Artifacts Location:     ./TestResults/{timestamp}/{ScenarioName}/
• Artifact Retention:     7 days (auto-cleanup)
• Timeouts:               30s element / 60s navigation
• Tracing:                On failure only
• Video Recording:        On failure only

LOCATORS & PAGE OBJECTS
───────────────────────────────────────────────────────────────────────────────
• Locator Location:       Separate files now → Page Objects later
• Locator Priority:       TestId preferred, Role as fallback
• Navigation Returns:     void (no chaining)
• PO Assertions:          Lightweight ensure/guard methods allowed

ASSERTIONS & GHERKIN
───────────────────────────────────────────────────────────────────────────────
• Assertion Library:      Playwright Expect (migrate gradually)
• Gherkin Semantics:      Enforce Given/When/Then properly
• Scenario Length:        No strict limit
• Background:             Allowed when helpful

DATA TOKENS
───────────────────────────────────────────────────────────────────────────────
• {{firstName}}           Random first name
• {{lastName}}            Random last name
• {{today}}               Today's date
• {{tomorrow}}            Tomorrow's date
• {{futureDate:+Xd}}      X days in future
• {{pastDate:-Xd}}        X days in past
• {{randomSSN}}           Random SSN (XXX-XX-XXXX)
• {{randomDOB}}           Random DOB (21-65 years)
• {{randomPhone}}         Random US phone
• {{randomEmail}}         Random email

═══════════════════════════════════════════════════════════════════════════════
```

---

**Questions?** Contact me for clarification on any decisions or implementations.
