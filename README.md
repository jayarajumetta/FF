# PnC Test Automation Framework

End-to-end UI and API test automation for American National P&C (Property & Casualty) insurance applications. Built on Playwright + Reqnroll (BDD/Gherkin) + NUnit, targeting the ExpertQuote, ExpertService, and Express platforms.

> **New to the framework?** Start with [Docs/Onboarding-Guide.md](Docs/Onboarding-Guide.md).
> **Contractor?** Read [Docs/Contractor-Guide.md](Docs/Contractor-Guide.md) before writing any code.
> **Architecture deep-dive:** [Docs/Framework-Overview.md](Docs/Framework-Overview.md)
> **Open issues & findings:** [Docs/Framework-Analysis-Report.md](Docs/Framework-Analysis-Report.md)

---

## Table of Contents

- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Quick Start](#quick-start)
- [Running Tests](#running-tests)
- [Tag Reference](#tag-reference)
- [Configuration](#configuration)
- [Data Tokens](#data-tokens)
- [Writing New Tests](#writing-new-tests)
- [Page Object Model](#page-object-model)
- [Test Artifacts](#test-artifacts)
- [Tools](#tools)
- [Troubleshooting](#troubleshooting)
- [Branching & Contributing](#branching--contributing)

---

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| .NET | 8.0 | Runtime |
| Playwright | 1.57.0 | Browser automation |
| Reqnroll | 3.3.0 | BDD / Gherkin binding |
| NUnit | 4.4.0 | Test runner |
| Microsoft.Extensions.DependencyInjection | — | Service wiring |
| Microsoft.Extensions.Configuration | — | Env-aware settings |

---

## Project Structure

```
PnC-TestAutomation/
├── Features/                    # Gherkin .feature files (source of truth for test coverage)
│   ├── BOP/                     # Business Owners Policy scenarios
│   ├── PA/                      # Personal Auto scenarios
│   └── SFP/                     # Special Farm Package scenarios (primary LOB)
│
├── StepDefinitions/             # C# step bindings
│   ├── SharedSteps/             # Steps shared across all products (login, client search, etc.)
│   ├── BOPSteps/                # BOP-only steps
│   ├── PASteps/                 # PA-only steps
│   └── SFPSteps/                # SFP-only steps
│
├── Pages/                       # Page Object Model — one class per application page
│   ├── BasePage.cs              # Abstract base: spinner wait, rescue, common locators
│   ├── ExpertQuotePages/        # ExpertQuote application pages
│   │   ├── SFP/                 # SFP-specific pages
│   │   └── PA/                  # PA-specific pages
│   ├── ExpressPages/            # CLAS Express pages
│   └── ExpertServicePages/      # ExpertService pages
│
├── Models/                      # Domain data models (ClientData, PolicyData, FarmData, etc.)
├── Helpers/                     # Utility classes (random data, table mapping, wait helpers)
├── Hooks/                       # Reqnroll lifecycle hooks (browser setup, tracing, teardown)
├── Configuration/               # Strongly-typed config classes (CredentialsConfig, OAuthConfig)
├── Context/                     # TestContext — holds IPage and HttpClient per scenario
├── Services/                    # NavigationService, ApiService, FormsValidationService
├── Clients/                     # HTTP clients (DuckCreekFormsClient)
├── Integrations/                # External integrations (PingSecretProvider)
├── Parsers/                     # FormsXmlParser
├── Tools/                       # Developer tools (not test scenarios)
│   ├── LocatorScan/             # Live DOM locator scanner
│   └── FormsBaselineGenerator/  # Generates forms expectation JSON from Excel
├── Docs/                        # Framework documentation
├── Pipelines/                   # Azure DevOps pipeline YAML definitions
├── Resources/                   # Static test data (expected forms JSON)
├── Scripts/                     # PowerShell helper scripts
├── appsettings.json             # Default (QA) configuration
└── appsettings.Dev.json         # Dev environment overrides
```

---

## Prerequisites

| Requirement | How to get it |
|-------------|--------------|
| .NET 8.0 SDK | https://dotnet.microsoft.com/download |
| PowerShell 7+ | `winget install Microsoft.PowerShell` |
| Git | https://git-scm.com |
| Chrome or Edge (latest) | Standard install |
| Playwright browsers | Installed via `playwright.ps1 install` (see below) |
| Access to ADO repo | Request from QA lead |
| QA environment credentials | Provide via environment variables — do **not** hardcode |

---

## Quick Start

```powershell
# 1. Clone
git clone https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_git/PnC-TestAutomation
cd PnC-TestAutomation

# 2. Restore packages
dotnet restore TestAutomation.csproj

# 3. Install Playwright browsers (run once after first clone or Playwright upgrade)
dotnet build TestAutomation.csproj
pwsh bin/Debug/net8.0/playwright.ps1 install

# 4. Set credentials — ask QA lead for values, NEVER commit them
$env:EQ_USERNAME  = "your-eq-username"
$env:EQ_PASSWORD  = "your-eq-password"

# 5. Run Smoke tests
dotnet test TestAutomation.csproj --filter "Category=Smoke"
```

> ⚠️ `appsettings.json` contains only `"PLACEHOLDER"` values for all credentials.
> Tests will fail immediately with a login error until you set the env vars above.

---

## Running Tests

### Visual Studio / Rider — Test Explorer (recommended for local dev)

1. Open `Playwright_POC.sln`
2. Build (`Ctrl+Shift+B`)
3. Open Test Explorer (`Ctrl+E, T` in VS, `Alt+8` in Rider)
4. Filter by tag or run all

### Command Line

```powershell
# Run all Smoke tests
dotnet test TestAutomation.csproj --filter "Category=Smoke"

# Run SFP Regression tests
dotnet test TestAutomation.csproj --filter "Category=SFP&Category=Regression"

# Run a specific feature file (by class name fragment)
dotnet test TestAutomation.csproj --filter "FullyQualifiedName~SFP_BasicPolicy"

# Run in headless mode
$env:PLAYWRIGHT_HEADLESS = "true"
dotnet test TestAutomation.csproj --filter "Category=Smoke"

# Run against Dev environment
$env:TEST_ENVIRONMENT = "Dev"
dotnet test TestAutomation.csproj --filter "Category=Smoke"

# Override browser
$env:BROWSER_TYPE = "edge"
dotnet test TestAutomation.csproj --filter "Category=Smoke"
```

### Using `.runsettings` Files

| File | Purpose |
|------|---------|
| `scan.runsettings` | Generated by `Scripts\scan.ps1` on each run — git-ignored, do not commit |
| `locatorscan.runsettings` | Alternative locator scan configuration |
| `generate-baseline.runsettings` | Generate forms baseline JSON from CLAS |

---

## Tag Reference

See [Docs/Tagging-Convention.md](Docs/Tagging-Convention.md) for the full specification.

| Tag | Meaning | Run when |
|-----|---------|----------|
| `@Smoke` | Critical path, single happy path | Before every deployment |
| `@Regression` | Full workflow + edge cases | Nightly, before releases |
| `@Forms` | Forms-only validation (no UI nav) | Forms check runs |
| `@API` | API-only scenarios | API integration checks |
| `@Ignore` | Temporarily disabled | Never — skipped automatically |
| `@Manual` | Not yet automated | Never — documentation only |
| `@SFP` | Special Farm Package LOB | With SFP-specific runs |
| `@BOP` | Business Owners Policy LOB | With BOP-specific runs |
| `@PA` | Personal Auto LOB | With PA-specific runs |
| `@ExpertQuote` | ExpertQuote application | All EQ tests |
| `@Express` | CLAS Express application | Express tests |
| `@ExpertService` | ExpertService application | ES tests |

---

## Configuration

> ⚠️ **`appsettings.json` contains placeholder values only.** Real credentials must be supplied via
> environment variables. **Never replace a placeholder with a real password and commit it.**

### Environment Variables

Set these before running tests. They override the corresponding `appsettings.json` values.

| Variable | Overrides | Required for |
|----------|-----------|--------------|
| `EQ_USERNAME` | `Credentials:Username` | All UI tests |
| `EQ_PASSWORD` | `Credentials:Password` | All UI tests |
| `EXPRESS_USERNAME` | `QAExpressCreds:Username` | Express/CLAS tests |
| `EXPRESS_PASSWORD` | `QAExpressCreds:Password` | Express/CLAS tests |
| `OAUTH_CLIENT_SECRET` | `OAuthConfig:ClientSecret` | API tests |
| `PING_SECRET_ID` | `OAuthConfig:PingSecretId` | API tests |
| `DUCKCREEK_PASSWORD` | `DuckCreekForms:Password` | Forms validation |
| `TEST_ENVIRONMENT` | `Environment` | Dev environment runs |
| `BROWSER_TYPE` | `Playwright:BrowserType` | Browser override |
| `PLAYWRIGHT_HEADLESS` | `Playwright:Headless` | Headless mode |

```powershell
# Minimum required for UI tests
$env:EQ_USERNAME = "your-eq-username"
$env:EQ_PASSWORD = "your-eq-password"

# For Forms validation tests
$env:DUCKCREEK_PASSWORD = "your-duckcreek-password"

# For API tests
$env:PING_SECRET_ID   = "your-ping-secret-id"
$env:OAUTH_CLIENT_SECRET = "your-oauth-secret"
```

Ask your QA lead for the credential values. Do **not** commit them to any file.

### `appsettings.json` Key Sections

```json
{
  "Environment": "QA",
  "Playwright": {
    "BrowserType": "chrome",
    "Headless": false,
    "ExpertQuote": "https://expertquote-qa.americannational.com/expertquote/#/quote"
  },
  "Debugging": {
    "PauseOnFailure": false,
    "FailOnFormsValidationError": false,
    "SkipPremiumBaselineAssertion": false
  },
  "LocatorRescue": {
    "Enabled": true,
    "AutoHeal": false
  }
}
```

### Multi-Environment

- **QA (default):** `appsettings.json`
- **Dev:** `appsettings.Dev.json` (overrides selected keys; merged at runtime)
- **Env-specific selection:** Set `TEST_ENVIRONMENT=Dev` before running

### State Filtering (Dev environment)

In `appsettings.Dev.json`, `StateFilters:DevAllowedStates` limits which states run:
```json
{
  "StateFilters": {
    "DevAllowedStates": ["MN", "NE"]
  }
}
```
Scenarios whose address state is not in the allowlist are skipped automatically — no tag change needed.

---

## Data Tokens

Use tokens in feature file tables to generate randomized test data at runtime:

### Name & Identity

| Token | Description | Example |
|-------|-------------|---------|
| `{{firstName}}` | Random male first name | `James` |
| `{{female}}` | Random female first name | `Sarah` |
| `{{lastName}}` | Random last name | `Anderson` |
| `{{randomDOB}}` | DOB — 21 to 65 years old | `03/14/1978` |
| `{{randomPhone}}` | US 10-digit phone | `(612) 555-0198` |
| `{{randomEmail}}` | Email from generated name | `james.anderson@test.com` |
| `{{randomSSN}}` | SSN format XXX-XX-XXXX | `401-55-9124` |

### Dates

| Token | Description | Example |
|-------|-------------|---------|
| `{{today}}` | Today's date | `05/08/2026` |
| `{{tomorrow}}` | Tomorrow's date | `05/09/2026` |
| `CURRENT YEAR` / `{{currentYear}}` | Residence `RoofYear` only: current calendar year at execution | `2026` |

### SFP Basic workbook inputs

`Features/SFP/SFP_BasicPolicy.feature` follows the **Proposed Basic Policy** sheet
of *SFP Base Policies (2).xlsx*. Only the roof year rolls forward. Year built
remains 2024; heating/electrical remain 2026 and plumbing remains 2025.
The Basic-only verified steps check entered values and selected options, including
AOI 550000 after RCT, perils 5 (also when disabled), Slate / UL 4, and exact
FPP code 464 with limit 101500 and deductible $1,000. Existing CE steps retain
their prior behavior.
After saving the residence, Basic reopens Location #1 / Residence #1 and checks
the persisted residence and coverage values before proceeding. The edit action
uses the source-derived row-scoped `editResidence` test ID (no `.value` suffix);
a missing/changed action fails rather than opening another row or silently
skipping readback.

QA still needs to supply replacement Basic location addresses/ZIPs distinct from
Rate and CE. The 38 existing examples are deliberately unchanged; do not invent
ZIPs or treat this workbook requirement as complete.
Existing expected premiums and premium assertions are unchanged pending confirmed
inputs and authorized recalibration. Missing premium baselines are not newly
populated.

**Deferred workbook requirements (not QA-approved omissions):** Limited Farm
Pollution is coverage 146, not Special Farm Pollution 145. The requested
occurrence/aggregate 50000/300000 requires a base liability aggregate of at least
300000, incompatible with the workbook's unchanged Basic base 100000/100000.
Reviewed CLAS SD/WI/NE/MN metadata also leaves coverage 146 unavailable; current
runtime eligibility must be confirmed. No mandatory pollution step, eligibility
bypass, base-limit change, or successful skip has been added.
Pending exact inputs are 50000/300000, total onsite manure/chemical capacity
8000000 gallons, maximum distance 23 miles, 550 waste trips/year, aboveground
tank Yes, tank capacity 500000 gallons, and fixed construction date 03/31/2024
(Excel serial 45382, 1900 date system). The tank exceeds the 10000-gallon
threshold for UW rule 11128; genuine applicable referrals must remain visible.

The unchanged 38 examples are AL, AR, AZ, CO, DE, GA, ID, IL, IN, IA, KS, KY, LA,
CT, MS, MO, MA, ME, MN, MT, NE, NV, NH, NM, ND, OK, NJ, OH, OR, SC, SD, TN, TX,
UT, WA, WI, WY, RI. There are 27 existing SFP premium baselines; the 11 without
baselines are IN, IA, CT, MS, MO, NH, NM, OK, NJ, OH, RI. Recalibration requires
final approved inputs (including compatible pollution scope and distinct location
data) plus actual quote evidence; none is inferred from these offline changes.

Contract references: CLAS changeset 308935,
`Source\DuckCreekTechnologies\ManuScripts\CarrierSpecialFarmPackage\US-INH\Carrier_SpecialFarmPackage_Data_US_4_0_0_0.xml`
(`BuildingInput` renovation/roof fields, `CovLimitedFarmPollutionLiabilityInput`,
`LimitedPollutionTank`, aggregate eligibility at lines 34437-34482);
EQ UI `origin/develop` 9b9b292 and `origin/qa` 9bbd84e agree on the relevant
SFP builders. Electrical year maps to `BuildingInput.WiringYear`. Code 464
descriptions are uppercased on change; the feature keeps the business input
`Bose Sound Bars` and verification expects `BOSE SOUND BARS`.
The saved-residence action is defined in
`Headless\US\SpecialFarmPackage_Common_Headless_ViewModels_US_4_0_0_0.xml`
lines 1090-1126. UI `cl-sfp-locations-buildings-page-builders.service.ts`
builds the nested Building row's `EditResidence` action; metadata/action builders
derive its test ID from the response model path. These source references establish
the contract, not deployed-environment availability.

Offline regression checks (no business workflows):

```powershell
dotnet test TestAutomation.csproj --filter "FullyQualifiedName~PnCTestAutomation.Tests.SfpBasic"
```

Page checks use local fixture HTML with network requests blocked, not a live
product-contract certification. A full Basic feature run creates and saves quotes,
orders scores/valuation, proceeds through billing/payment setup and Checklist,
and queries forms. Do not use it as an input-only check or bypass Checklist
outages. No transmission, issuance, binding, payment, or baseline recording is
authorized by the workbook update.

### Usage in Feature Files

```gherkin
And user enters a Random Name in the search field and clicks search
  | Question  | Answer        |
  | FirstName | {{firstName}} |
  | LastName  | {{lastName}}  |

And user enters client information and clicks search
  | Question     | Answer          |
  | DOB          | {{randomDOB}}   |
  | BestPhone    | {{randomPhone}} |
  | EmailAddress | {{randomEmail}} |

And user selects Special Farm Package and inputs Quote Details
  | Question      | Answer       |
  | EffectiveDate | {{tomorrow}} |
```

---

## Writing New Tests

### Step 1 — Feature File

Create a `.feature` file in the appropriate `Features/` subdirectory.

```gherkin
@SFP @ExpertQuote
Feature: SFP New Coverage Type

  @Smoke
  Scenario Outline: SFP New Coverage Smoke - <State>
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn
    And user enters a Random Name in the search field and clicks search
      | Question  | Answer        |
      | FirstName | {{firstName}} |
      | LastName  | {{lastName}}  |
    # ... more steps

    Examples:
      | State     | StateFull | Address       | City   | Zip   |
      | Minnesota | Minnesota | 115 S Main ST | Warren | 56762 |
```

### Step 2 — Reuse or Add Step Definitions

Check `SharedSteps/` first — most common steps (login, client creation, account owner, etc.) are already there.

If adding a new step, put it in the LOB-specific file (e.g. `SFPSteps/SFP_CoverageSteps.cs`):

```csharp
[When("user enters new coverage information and continues")]
public async Task UserEntersNewCoverageInfoAndContinues(Table table)
{
    var page = new SFP_NewCoveragePage(_context.Page);
    await page.WaitForSpinnerAsync();
    // ... fill data from table
    await page.ClickNextAsync();
}
```

### Step 3 — Add a Page Object (if new page)

Inherit from `BasePage`:

```csharp
public class SFP_NewCoveragePage : BasePage
{
    public SFP_NewCoveragePage(IPage page) : base(page) { }

    // Define locators as properties
    private ILocator CoverageInput => _page.GetByTestId("fields.coverage.newInput.value");
    private ILocator NextButton => _page.GetByTestId("next-button");

    public async Task EnterCoverageAmountAsync(string amount)
    {
        await CoverageInput.FillAsync(amount);
    }
}
```

---

## Page Object Model

All page objects inherit from `BasePage` which provides:

| Method / Property | Description |
|-------------------|-------------|
| `_page` | The Playwright `IPage` instance |
| `WaitForSpinnerAsync()` | Waits for Angular loading overlay to clear |
| `ClickNextAsync()` | Clicks the standard "Next" workflow button |
| `ClickSaveAsync()` | Clicks the standard "Save" button |
| `GetById(id)` | Locates element by HTML `id` attribute |
| `RescueAsync(locator, hint)` | Runs locator rescue scan on failure |
| `GetByTestIdRescueAsync(testId)` | `GetByTestId` + automatic rescue on miss |

### Selector Strategy

1. **DuckCreek form fields** — use `GetByTestId("fields.data.*")`. These are DuckCreek-owned IDs; do not change them.
2. **ANi-built UI components** — prefer `GetByTestId()` for elements still in transition; use `GetById()` for elements that have been migrated to `id` attributes.
3. **Navigation / buttons by role** — use `GetByRole(AriaRole.Button, ...)`.
4. **Avoid** complex CSS selectors, XPath, or selectors based on position (`.first`, `:nth-child`) unless there is no stable alternative.

### Locator Rescue

When a `GetByTestId` call finds 0 elements and `LocatorRescue:Enabled = true` in `appsettings.json`, the framework automatically scans the live DOM for similar elements and logs candidates. Set `AutoHeal = true` to automatically substitute the best candidate (use with caution — review logs before enabling in CI).

---

## Test Artifacts

On scenario failure, the following are automatically saved:

```
TestResults/
└── {yyyy-MM-dd_HHmmss}/              ← one folder per test run
    ├── pass-records.csv              ← telemetry for all passing scenarios
    └── {ScenarioName}/               ← one folder per FAILED scenario
        ├── trace.zip                 ← Playwright trace (upload to trace.playwright.dev)
        ├── Videos/                   ← screen recording
        └── Step__{StepText}.png      ← screenshot at point of failure
```

Folders older than 7 days are automatically deleted.

### Viewing a Playwright Trace

1. Go to [trace.playwright.dev](https://trace.playwright.dev)
2. Drag and drop the `trace.zip` file
3. Step through DOM snapshots, network calls, and console logs

---

## Tools

### LocatorScan

Scans a live browser page and generates C# locator code for new or changed elements.

**When to use:** A DuckCreek form page has changed and you need to find the new `data-testid` values.

```powershell
# 1. Open Chrome with DevTools remote debugging enabled
Start-Process "chrome" "--remote-debugging-port=9222"

# 2. Navigate to the page you want to scan in that Chrome window

# 3. Run the scanner
dotnet test TestAutomation.csproj --settings locatorscan.runsettings
```

Output appears in `TestResults/{date}/LocatorScan/`.

### Forms Baseline Generator

Generates the expected-forms JSON files used by `FormsValidationService`.

```powershell
# Run via the dedicated runsettings
dotnet test TestAutomation.csproj --settings generate-baseline.runsettings

# Or via the PowerShell helper
.\Scripts\generate-baseline.ps1
```

See `Tools/FormsBaselineGenerator/` for source and `Resources/ExpectedForms/` for output.

---

## Troubleshooting

| Symptom | Most Likely Cause | Fix |
|---------|------------------|-----|
| `TimeoutException` on first page load | SSO redirect chain exceeded 30 s | Navigation timeout is set to 90 s — check network or VPN |
| `TimeoutException` on element | `data-testid` changed in latest DuckCreek deploy | Run LocatorScan, update the page object locator |
| `AmbiguousMatchException` from Reqnroll | Two step definitions match the same text | Search for duplicate `[When("...")]` bindings |
| `ScenarioContextData` fields are null | Table key in Gherkin doesn't match a mapped case | Check `TableMappingHelpers` for the relevant mapper method |
| Browser not found | Playwright browsers not installed | Run `pwsh bin/Debug/net8.0/playwright.ps1 install` |
| Test passes locally but fails in CI | Headless rendering difference | Reproduce with `$env:PLAYWRIGHT_HEADLESS = "true"` locally |
| "Failed to retrieve ClientSecret from Ping" | API test — Ping secret ID not configured | Set `OAuthConfig:PingSecretId` in config or contact QA lead |
| Quote number not found | Nav element changed | Check `cl-sfp-nav` testId or the tab label XPath in `SharedEQSteps` |
| Video/trace not saved | `AfterScenario` hook error swallowed | Check test output for `[Warning]` lines |

---

## Branching & Contributing

### Branch Strategy

| Branch | Purpose |
|--------|---------|
| `main` | Stable, deployable. Protected — no direct push. |
| `Development` | Integration branch. PRs target this. |
| `{LOB}_{Description}` | Feature branches (e.g. `SFP_WorkflowUpgrades`) |

### Workflow

```
feature branch → PR to Development → review → merge → periodic merge Development → main
```

### Before You PR

- [ ] `dotnet build TestAutomation.csproj` — zero errors
- [ ] `dotnet format TestAutomation.csproj --verify-no-changes` — zero formatting issues
- [ ] New/changed scenarios have appropriate tags (`@Smoke` or `@Regression`, LOB tag, App tag)
- [ ] Page objects use `BasePage` and follow the selector strategy
- [ ] No new credentials, passwords, or secrets added to any committed file
- [ ] **Definition of Done:** scenario passes in two consecutive local runs

See [Docs/Contractor-Guide.md](Docs/Contractor-Guide.md) for contractor-specific rules.
