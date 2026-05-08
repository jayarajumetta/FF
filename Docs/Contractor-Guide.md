# Contractor Enablement Guide — PnC Test Automation

This document is for contractors working in this repository. Read it in full before writing or committing any code.

---

## Table of Contents

1. [What You Can and Cannot Do](#1-what-you-can-and-cannot-do)
2. [Definition of Done](#2-definition-of-done)
3. [Working Layers Explained](#3-working-layers-explained)
4. [How to Get Started](#4-how-to-get-started)
5. [Coding Standards](#5-coding-standards)
6. [PR Requirements](#6-pr-requirements)
7. [CI Targets (Recommended)](#7-ci-targets-recommended)
8. [Escalation Path](#8-escalation-path)
9. [Quick Reference: Do / Don't](#9-quick-reference-do--dont)

---

## 1. What You Can and Cannot Do

### You CAN change without prior approval

| Layer | Files |
|-------|-------|
| Feature files | `Features/**/*.feature` |
| Step definitions | `StepDefinitions/**/*.cs` |
| Page objects | `Pages/**/*.cs` |
| Models | `Models/**/*.cs` |
| Helpers | `Helpers/**/*.cs` |
| Tools | `Tools/**/*.cs` |
| Docs | `Docs/**/*.md` |

### You NEED approval before changing

| Layer | Files | Why |
|-------|-------|-----|
| DI configuration | `Startup.cs`, `Configuration/DependancyInjection.cs` | Service lifetime changes can break all tests |
| Test lifecycle hooks | `Hooks/TestHooks.cs` | AfterScenario/BeforeScenario run for every test |
| CI pipeline definitions | `Pipelines/**/*.yml` | Affects CI/CD for the whole team |
| `appsettings.json` | root | Environment and credential configuration |
| `TestAutomation.csproj` | root | NuGet dependencies, build config |

**How to request approval:** Assign the PR to the QA lead and add the label `needs-approval`.

---

## 2. Definition of Done

A test scenario is **done** when it:

1. **Passes in two consecutive local runs** — back-to-back, same machine, without any manual intervention between runs
2. Has the correct **tags** (`@Smoke` or `@Regression`, LOB tag, App tag — see [Docs/Tagging-Convention.md](Tagging-Convention.md))
3. **`dotnet build` exits with 0 errors**
4. **`dotnet format --verify-no-changes` exits with 0 issues**
5. PR is approved by the QA lead

One pass is not enough. If a scenario passes and then fails on the second run, it is flaky and must be fixed before the PR is merged.

---

## 3. Working Layers Explained

The framework has a strict layering rule: **each layer talks only to the layer directly below it**.

```
Feature Files (.feature)
       ↓
Step Definitions (.cs in StepDefinitions/)
       ↓
Page Objects (.cs in Pages/)
       ↓
BasePage / Playwright IPage
```

### Feature Files

Plain English, written in Gherkin. These are the **source of truth** for what the tests cover. They must be readable by a business analyst without any C# knowledge.

**You write here:** new scenarios, new examples rows, new coverage

**You do not write:** implementation logic, assertions, selectors

### Step Definitions

C# methods that bind to Gherkin lines. They orchestrate page objects and populate `ScenarioContextData`.

**You write here:** the glue between Gherkin and page objects

**You do not write:** Playwright locator code (belongs in page objects), business rules

### Page Objects

One class per application page. They define locators and expose task-oriented action methods.

**You write here:** locators, action methods, page-specific waits

**You do not write:** test data manipulation, assertions (unless it's a page-specific assertion like "verify save succeeded")

---

## 4. How to Get Started

```powershell
# Clone and set up (see README.md for full setup)
git clone https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_git/PnC-TestAutomation
cd PnC-TestAutomation
dotnet restore TestAutomation.csproj
dotnet build TestAutomation.csproj
pwsh bin/Debug/net8.0/playwright.ps1 install

# Set credentials (ask QA lead for values)
$env:EQ_USERNAME = "..."
$env:EQ_PASSWORD = "..."

# Create your feature branch
git checkout Development
git pull
git checkout -b YourName_TaskDescription

# Verify you can run the baseline
dotnet test TestAutomation.csproj --filter "Category=Smoke"
```

If the baseline run fails before you make any changes, **stop and escalate** — you are not starting from a clean state.

---

## 5. Coding Standards

### Selectors

Use this priority order:

1. `GetByTestId("fields.data.testid")` — preferred for DuckCreek form fields
2. `GetByRole(AriaRole.Button, new(){ Name = "Submit" })` — for buttons and interactive elements
3. `GetByLabel("Field Label")` — for labeled inputs
4. `GetByText("exact text", new(){ Exact = true })` — for static text elements
5. CSS/XPath — **last resort only** — document why no stable selector is available

**Never** use:
- Positional selectors (`.nth-child`, `.first`, `.last`) on dynamic lists
- Class names that look auto-generated (`ng-valid`, `mat-mdc-xxx`)
- Internal Angular component references

### Waits

| Situation | Correct approach |
|-----------|-----------------|
| Page loads / Angular spinner | `await WaitForSpinnerAsync()` (inherited from BasePage) |
| Element must be visible before click | `await locator.WaitForAsync(new(){ State = WaitForSelectorState.Visible })` |
| Element must be enabled before click | `await Expect(locator).ToBeEnabledAsync()` |
| Verifying a result | `await Expect(locator).ToBeVisibleAsync()` or `ToHaveTextAsync()` |

**Never** use `Thread.Sleep()`, `Task.Delay()`, or polling loops.

### Data in Feature Files

- Use `{{random*}}` tokens — never hardcode names, dates, phones, or emails
- Never use real SSNs, never use real customer data
- Keep test addresses realistic for the state being tested (correct state/zip combination)

### Naming

| Item | Convention | Example |
|------|-----------|---------|
| Feature files | `{LOB}_{Description}.feature` | `SFP_BasicPolicy.feature` |
| Page object classes | `{App}_{PageName}Page` | `SFP_PrimaryInsuredPage` |
| Step text (Gherkin) | 3rd person, present tense | `user clicks Save and continues` |
| Step methods | PascalCase, match Gherkin text | `UserClicksSaveAndContinues()` |
| Private locators | PascalCase, descriptive | `SaveButton`, `FirstNameInput` |

### Security

`appsettings.json` contains only `"PLACEHOLDER"` values. **Real credentials are never stored in any tracked file.**

You must set credentials as environment variables before running tests:

| Env Var | Purpose |
|---------|---------|
| `EQ_USERNAME` | ExpertQuote login username |
| `EQ_PASSWORD` | ExpertQuote login password |
| `EXPRESS_USERNAME` | Express/CLAS login username |
| `EXPRESS_PASSWORD` | Express/CLAS login password |
| `DUCKCREEK_PASSWORD` | DuckCreek Forms service password |
| `OAUTH_CLIENT_SECRET` | OAuth client secret (API tests) |
| `PING_SECRET_ID` | Ping secret ID (API tests) |

**Do not commit any of the following to any tracked file:**

- Passwords or usernames
- OAuth client secrets
- API keys or tokens
- Personal information (real names, real SSNs, real addresses)
- Internal server hostnames or IP addresses

If you discover any of these already in a file, **report it to the QA lead immediately** — do not include them in your own commits, and do not assume it is intentional.

---

## 6. PR Requirements

Every PR must meet **all** of the following before requesting review:

### Technical requirements

- [ ] `dotnet build TestAutomation.csproj` — **0 errors, 0 warnings**
- [ ] `dotnet format TestAutomation.csproj --verify-no-changes` — **0 issues**
- [ ] No credentials, secrets, or real PII in any committed file
- [ ] No `@UI,` trailing commas on feature tags
- [ ] No new duplicate step binding texts

### Test requirements

- [ ] Two consecutive passing runs for the scenarios you added or changed
- [ ] All new scenarios have at least: one run-type tag, one LOB tag, one app tag
- [ ] No hardcoded DOB, phone, email, or SSN values in feature tables

### Code quality requirements

- [ ] New page objects inherit `BasePage`
- [ ] **New page objects registered as `Transient` in `Startup.cs`, never `Singleton`** (prevents state bleed between scenarios)
- [ ] Locators are private properties, not created inline inside methods
- [ ] `await WaitForSpinnerAsync()` called after actions that trigger page transitions
- [ ] No `Thread.Sleep` / `Task.Delay`

### PR description

Include in the PR description:
- What the test covers
- States/scenarios tested
- Two screenshots or a short description of each run passing

### Review process

1. Submit PR targeting the `Development` branch
2. Assign QA lead as reviewer
3. If changes touch approval-required files, add label `needs-approval`
4. Address all review comments before re-requesting review
5. Do not merge your own PR

---

## 7. CI Targets (Recommended)

These are targets for healthy CI operation. They are recommendations, not hard gates.

| Metric | Recommended Target |
|--------|-------------------|
| `@Smoke` pass rate | ≥ 95% per run |
| `@Regression` pass rate | ≥ 90% per run |
| Single `@Smoke` scenario runtime | < 5 minutes |
| Retry before marking as fail | 1 retry |
| Flake rate (passes on retry only) | Report and track; target < 5% |

If a scenario passes only on retry, it is **flaky** and must be investigated. Flaky tests reduce team confidence in the entire suite.

---

## 8. Escalation Path

| Situation | Who to contact | How |
|-----------|---------------|-----|
| Baseline tests failing before you started | QA Lead | Teams message, same day |
| Application changed — page no longer matches test | QA Lead | Teams message, same day |
| Not sure if a change needs approval | QA Lead | Ask before making the change |
| PR open > 2 business days with no review | QA Lead | Teams message or PR comment |
| Security concern (credentials exposure, etc.) | QA Lead | **Immediate** — Teams message |
| Framework question not in this doc | Senior developer | Teams or PR comment |

**Do not guess** on approval-required changes. The cost of a wrong DI lifetime or a broken hook is all tests failing for the entire team.

---

## 9. Quick Reference: Do / Don't

| DO | DON'T |
|----|-------|
| Use `GetByTestId()` for DuckCreek form fields | Use positional CSS selectors |
| Use `WaitForSpinnerAsync()` after page transitions | Use `Task.Delay()` or `Thread.Sleep()` |
| Use `{{random*}}` tokens for all test data | Hardcode names, DOBs, or phones |
| Inherit from `BasePage` for all page objects | Access `_page` directly from step definitions |
| Construct page objects inline: `new SFP_XPage(_context.Page)` | Inject page objects via constructor parameters (they are not scenario-scoped in DI) |
| Run tests twice before submitting a PR | Submit a PR with only one passing run |
| Add correct tags to every new scenario | Submit scenarios with no run-type or LOB tags |
| Ask before changing `Startup.cs` or hooks | Edit lifecycle hooks without approval |
| Report credentials exposure immediately | Include any password in any file |
| Target `Development` branch in your PR | Open PRs to `main` directly |
| Use `await Expect(locator).ToBeVisibleAsync()` for assertions | Use `Assert.That(await locator.IsVisibleAsync(), Is.True)` |
| Set credentials via environment variables | Replace `"PLACEHOLDER"` values in `appsettings.json` and commit |
