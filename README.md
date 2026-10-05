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
uses the source-derived row-scoped `editResidence` test ID (no `.value` suffix),
restricted to the native `button`. The captured Alabama QA DOM contains a nested
`aa-icons > div` sharing that test ID with its enclosing button. Exactly one
matching native button is required; missing or duplicate buttons fail rather
than opening another row or silently skipping readback.

QA still needs to supply replacement Basic location addresses/ZIPs distinct from
Rate and CE for the 38 legacy examples; those rows remain unchanged. MD, PA and VT
are represented in both Basic and CE with approved public working-farm fixtures:
Agricultural History Farm Park in Derwood, MD; Landis Valley Village & Farm Museum
in Lancaster, PA; and Billings Farm & Museum in Woodstock, VT. Their optional
AddressLine2 values are empty rather than fabricated, and their five-digit ZIP
strings are preserved, including VT `05091`. These six example rows are
`@DevOnly`: the states are not available in QA.

The DEV rows carry the reviewed source inputs used during qualification rather
than inheriting the legacy scenario default: territory `007` / all-peril `$1,000`
/ Wind-Hail `2%` / optional-if-exposed Hurricane `2%` for MD; territory `001` /
all-peril `$2,000` with no Wind-Hail or Hurricane for PA; and territory `031` /
all-peril `$2,500` / Wind-Hail `1%` with no Hurricane for VT. The automation waits
for address-driven controls and enumerates live options. The 2026-09-29 DEV runs
confirmed that this SFP Location view does not expose an all-peril control, so the
reviewed all-peril value remains explicit capture context and is logged rather
than fabricated through another control. MD continues to require and persist its
exact `2%` Wind-Hail value. DEV currently exposes PA Wind-Hail despite the checked-in
product source: when exposed, automation requires and persists `N/A`, never a
percentage; absence is also accepted and logged. DEV currently omits VT Wind-Hail:
absence after location refresh is accepted only for VT with an explicit deployment-
drift diagnostic; if exposed, the exact `1%` option remains mandatory.
Alabama's SFP premium baseline is $6,489.00, promoted with user approval on
2026-09-23 from QA quote 02081297, passing input-to-pricing qualification attempt 3.
That run captured the amount with premium comparison and forms excluded; it did
not qualify the full workflow or deferred pollution/ZIP requirements. The committed
premium assertion remains enabled. Other state/product baselines are unchanged
and await approved recalibration; missing baselines are not newly populated.

**Limited Farm Pollution:** Coverage 146 is source-enabled only for CT, DE, GA,
MA, ME, NH and RI; unsupported states leave it unselected without state-specific
C# branching. The Basic workflow uses occurrence/aggregate 50000/300000 with a
base liability aggregate of 300000, total onsite capacity 8000000 gallons,
maximum distance 23 miles, 550 waste trips/year, one aboveground tank, and fixed
construction date 03/31/2024. Tank capacity is 10000 gallons, the largest value
that does not trigger Level-9 rule 11128 (`Capacity > 10000`). Coverage 146 still
raises the expected Level-8 underwriting referral under rule 11125. The workflow
uses the server-provided Keep Going action, asserts Referral Required on Submission,
completes the checklist, and verifies the runtime-enabled Transmit action; it never
bypasses an Ineligible Quote. Pollution-tagged pricing is treated as a separate
baseline variant; DEV Delaware quotes 01069461 and 01069463 captured $6,248.00
versus the non-pollution $5,752.00 baseline.

The 41 examples are AL, AR, AZ, CO, DE, GA, ID, IL, IN, IA, KS, KY, LA,
CT, MS, MO, MA, ME, MN, MT, NE, NV, NH, NM, ND, OK, NJ, OH, OR, SC, SD, TN, TX,
UT, WA, WI, WY, RI, MD, PA and VT. All 38 legacy states have current SFP premium
baselines from the later qualification work documented below. MD, PA and VT have
no premium baselines. Qualifying them requires DEV execution with
final approved inputs (including compatible pollution scope and distinct location
data) plus actual quote evidence; no additional amounts are inferred.

Contract references: CLAS changeset 308935,
`Source\DuckCreekTechnologies\ManuScripts\CarrierSpecialFarmPackage\US-INH\Carrier_SpecialFarmPackage_Data_US_4_0_0_0.xml`
(`BuildingInput` renovation/roof fields, `CovLimitedFarmPollutionLiabilityInput`,
`LimitedPollutionTank`, aggregate eligibility at lines 34437-34482);
EQ UI `origin/develop` 9b9b292 and `origin/qa` 9bbd84e agree on the relevant
SFP builders. Electrical year maps to `BuildingInput.WiringYear`. Code 464
description metadata supports uppercase normalization, but the captured Alabama
QA pre-save input retains its entered casing. The feature keeps the business
input `Bose Sound Bars`; pre-save verification accepts exactly that value or
`BOSE SOUND BARS`, not changed wording or additional text. Limit and deductible
checks remain unchanged.
Code identity is matched only in the source-defined `CoverageID` column
(`mat-column-column1`), with its `Coverage Code` header asserted first. A value
of 464 in another row's name/description/amount cell cannot select that row or
make the real code ambiguous. This column contract comes from
`cl-sfp-farm-coverages-page-builder.service.ts` lines 990-1045 and
`table-builder.ts` lines 103-125, not a guessed cell position.
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

### SFP Country Estate workbook update

CE's strict residence-coverage binding verifies the source-owned disabled perils
6 control before entry and again after saving/reopening Location #1 / Residence
#1. It never selects or enables that control; missing, enabled, incorrect, or
unavailable saved values fail. Basic's perils selection path is unchanged.
CE settlement selection requires one exact matching option. Alabama qualification
quote 02081333 exposed a prefix collision: `Expanded Replacement Cost w/ACV Roof`
precedes `Expanded Replacement Cost`. The CE selector must not choose the former
or weaken saved-value verification to accept it.
Year built and roof year remain fixed at 2022, with Asphalt / UL 2, AOI 375000
and Expanded Replacement Cost. CE does not inherit Basic's renovation years or
rolling roof.

CE intentionally hides `BuildingInput.EQVacantSeasonal` through
`HideResidenceDetailsFields = IsCountryEstateStartedOrTypeSelected`. The CE
feature therefore omits the former `SeasonalOrVacant = No` input. Its strict
path rejects supplied seasonal/vacant values and verifies UI non-applicability
before saving and after reopening, separately from the other residence values.
Absence does **not** prove saved No: the normal default is raw `0`, but CE does
not force or clear existing storage, and no authorized saved-value output was
established. The workbook's No requirement remains unverified. Basic/non-CE
visible chips and value verification are unchanged.

CE perils 6 was explicitly user-approved on 2026-09-23: groups 5 and 6 both
include all perils, meeting the workbook's intended full-peril coverage scope.
Residence coverage 220 defaults to 6, disables that control for CE, and offers
groups 1-5 only for other coverage types. The canonical feature asserts the
approved source-owned 6 instead of its stale request for 3; it does not force
group 5 into CE or claim that rate calculations have been validated.
Separate Residence Contents is hidden for CE; household contents instead derives
from coverage 220's limit and its replacement-cost percentage. On 2026-09-23,
the user approved **187500 household contents** in place of the worksheet's
120000. The CE feature now explicitly requests that amount with the unchanged
375000 residence and perils 6. The binding selects the native **50%** option and
verifies it before saving and after exact Residence #1 / Location #1 reopening,
alongside the residence amount. This verifies the inputs that derive 187500,
not a separately entered or independently displayed contents limit.

Supported percentages are 50/60/70/80/90/100; unsupported requested amounts fail
rather than rounding or changing the residence value. The exact
`coverageInput$householdContentReplacementCost.value` control and `50%` caption
were observed in the existing quote 02081373 trace. No separate 211 coverage is
added. The revised amount resolves the residence-contents amount/attachment
conflict, but not the separate Division II Farm Contents host dependency below.

The workbook's separate **CE Policy Feature File** worksheet contains highlighted
goals beyond the **Proposed CE Policy** summary sheet. The following Division II
items remain deferred; neither is an executable step in `SFP_CE.feature`:

- **Greenhouse: unknown true-CE completion.** Greenhouse / rate type 1 / plastic
  thickness 5 triggers the generic invalid-rate predicate and rule 12811, but CE
  suppresses the legacy Division II stoplight. A mandatory headless save failure
  is not proven. The FarmBuilding / description 249 exception does not apply to
  Greenhouse; do not substitute coverage type, rate type or thickness. Roof year
  and vacancy may require missing inputs or actual saved defaults; BVS Processes
  and result 9050 require the runtime service catalog. Installation date is fixed
  at 04/25/2025 (Excel serial 45772, 1900 date system).
  Provenance: **CE Policy Feature File!B164/B173** name Greenhouse and **B174**
  requests 75000. This is not an implemented greenhouse workflow or a new
  requirement inferred from the source review.
- **Farm Contents: host dependency.** Coverage 601 supports AOI 25000, perils 5,
  replacement cost Yes and description 249 on a valid Division II building.
  There is no proven attachment to Residence #1; its greenhouse host is unresolved.

The following inputs are now explicitly approved and implemented in the CE
feature. Alabama quote 02081797 verified the updated inputs through Pricing;
the other state examples have not yet been live-qualified:

- **Division IV:** 409 **Stamp Collections / 5000** and 411 **Auto Trailer Home
  Personal Effects / 10000**, with unattended-vehicle theft **Yes** for both.
  These are item descriptions, not merely catalog search labels; readback accepts
  the entered description or its application-normalized uppercase form.
  The unattended fields are respectively
  `CovStampCollectionsInput.UnattendedVehicle` (singular) and
  `CovAutoTrailerHomePersonalEffectsInput.UnattendedVehicles` (plural).
  The CE-only binding validates both item rows before navigation, selects exact
  coverage-code cells, requires category-specific Add/Edit actions, and verifies
  descriptions, amounts and selected Yes chips before Save and after reopening.
  Missing, ambiguous, disabled or incorrectly persisted controls fail explicitly;
  the older non-CE SPP binding is unchanged. No appraisal year is invented for the
  approved 5000 stamp amount.
  Coverage 411 also requires **NamedPersonNames**, separate from the generic item
  description. The CE scenario resolves `{{fullName}}` to its existing generated
  primary insured and explicitly retains **NamedPersonCount 0 (None)**; it does
  not add a named-person extension. Both fields are checked before Save and after
  reopening. Blank names are invalid even at count 0. Other explicit counts must
  be integers 0-9; names have the source maximum of 85 characters.
- **Location data:** the 38 legacy CE state examples use the user's replacement
  Address / AddressLine2 / City / Zip / County records, with five-digit ZIP strings
  (including leading zeros), AddressLine2 111 and existing shard/state inventory
  preserved. All 38 ZIPs differ from their previous CE values. This records the
  supplied data exactly; it does not certify geocoding, deliverability or
  city/ZIP/county consistency. The County example column remains informational;
  the existing workflow obtains location resolution from the application.
  Basic and Rate data are unchanged. No replacement wind/hail deductible was
  supplied, so the existing 1% request remains and may need runtime reconciliation
  for the new locations.
  MD, PA and VT add the supplied official public institutional addresses to both
  workflows with empty optional AddressLine2 values. They are distributed by the
  existing state ranges: MD in the middle shard and PA/VT in the final shard,
  yielding 14/14/13 total rows per workflow.

Division IV amount rules, inspected read-only in the CLAS Dev-ST source snapshot
synced 2026-09-23:

| Coverage | Amount / appraisal contract |
| --- | --- |
| 409 - Stamp Collections | Integer amount required. Above 25000 requires Year of Last Appraisal; exactly 25000 does not trigger that requirement. The year cannot exceed the current year. This is an appraisal threshold, not a maximum insured amount. |
| 411 - Auto Trailer Home Personal Effects | Integer amount required. The appraisal field is not displayed. Its internal appraisal-table sentinel 9999999 is not a supported coverage maximum or recommended amount. |

The reviewed shared `LimitMin` / `LimitMax` rules impose no coverage-specific
minimum or maximum on 409/411. This does not establish unlimited insurability,
permit invalid numeric input, or guarantee underwriting acceptance. The amount
is now explicitly chosen as 5000 / 10000; no appraisal years have been invented.

Separate Division IV **non-new-business audit** rules flag added amounts above
25000, or modified limits above 25000. Another predicate flags an added item
above 35000 with an appraisal older than five years (both comparisons are strict
`>`). These are audit conditions, not input maxima or proven blockers for this
new-business Pricing qualification. Actual deployed underwriting disposition
remains unverified. The inspected rating paths use amount divided by 100;
no amount-band breakpoint was found for these two categories in those paths or
Alabama's `SPPBaseRates` table. Residence perils 6 does not change these separate
Division IV amount/appraisal rules.

The earlier Alabama CE Pricing pass (quote 02081373) predates the explicit
household-contents binding, these scheduled items and the replacement addresses.
The subsequent quote 02081797 matched the explicitly approved Alabama CE premium
baseline of 3089, but failed opening eChecklist with "Checklist Not Found."
Alabama Basic quote 02081808 completed Checklist using the same shared bindings.

Per the user's 2026-09-23 clarification, CE now uses exactly Basic's finalization
sequence and table inputs from Pricing onward: Billing, Submission/Checklist,
no-referral check, Residence Photo #1, UL Roof Type Credit, optional Easy Pay,
Loss Runs, close/update, Transmit-enabled assertion, then nonblocking Forms.
The CE-only Save for Later/reopen detour and optional Signature Page step have
been removed. A canonical-feature regression compares every binding, order and
table value with Basic. This alignment is not proof of the earlier error's root
cause. No Transmit click, issuance, binding or payment execution is added;
premium assertions and Forms expectations remain unchanged by this alignment.

The original and aligned CE failures (02081797 and 02081820) both reported the
missing scheduled-property **Name** field and launched `cldc_SFP00`. Source and
captured responses identify the missing 411 field, rather than Save/reopen, as
the blocker: Submission cannot advance an incomplete Quote to Application, so
no valid Checklist ID is assigned. The shared Checklist step now rejects a
visible incomplete-required-fields message before opening the popup. A successful
Pricing assertion or visible Checklist button alone does not establish readiness.

After filling and verifying the 411 name, Alabama CE quote **02081833** passed
the full canonical workflow on 2026-09-23 with the unchanged **3089** premium.
Checklist **cldc_sfp3388818** opened successfully, required items completed, and
close/update and Transmit-enabled checks passed. Optional Easy Pay was absent
and skipped. Forms ran last and retained two nonblocking missing-mandatory-form
discrepancies (**X42960309**, **X43061125**). No Transmit click, issue, bind or
payment was performed. The remaining 37 CE states have not been live-qualified.

Source references: carrier Data lines 24014-24082 (required integer amount and
description), 25734-25782 (limit bounds/default lookup), 26104-26121 and
103711-103713 (appraisal visibility); carrier States Base `DropdownDefault`
at 14025 (409/411 default-state limit cells blank; no Alabama table override);
Pages 4550-4586 and 45639-45681 (strict appraisal threshold), 7495-7514 (year
validation). `CarrierSpecialFarmPackageUnderwritingRules_4_0_0_0.xml`
250-252, 1851-1873, 3018-3075 and 6399-6478 distinguish audit thresholds and
transaction routing. Carrier RatingControl 2279-2325, 2526-2589 and Alabama
7049-7131 establish the amount-based rating paths, not a live premium prediction.

CE input-only qualification must stop after visible Pricing and current-quote
confirmation, before Step 24 Forms. The full canonical scenario also performs
Save for Later/reopen and Checklist updates; it is not an input-only test.
Premium comparison and forms exclusion in a partial qualification does not
qualify those outputs or authorize baseline recording.

Contract references: `Carrier_SpecialFarmPackage_Data_US_4_0_0_0.xml`
lines 8625-8699 and 9410 (CE type 220/perils), 8815-8830 and 19818-19844
(household contents percentage/amount), 13361-13389 and 13472-13484
(plastic greenhouse eligibility), 17890-17904 (CE stoplight suppression);
headless Pages lines 1763-1776 and 66167
(hidden separate contents), 66284 (disabled CE perils), 66358 (percentage field).
Seasonal/vacant visibility is Pages 65972-65977 and carrier Data 82208-82216;
the normal default is base Data 15632-15644, not an absence-to-value guarantee.
Offline fixture checks characterize these controls; they do not execute CLAS
rules or certify deployed behavior.

```powershell
dotnet test TestAutomation.csproj --filter "FullyQualifiedName~PnCTestAutomation.Tests.SfpCountryEstate|FullyQualifiedName~PnCTestAutomation.Tests.SfpBasic"
```

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

### SFP Basic and CE forms baselines

`Resources\ExpectedForms\SFP\SFP.json` is the **only SFP runtime baseline**.
On 2026-10-05 it was refreshed from the current user-designated Tosca masters,
both last modified on 2026-10-01. **Basic and CE now both cover all 41 Example states.**
All required-form sets in the 38 legacy states remain unchanged.
The retired scenario CSVs are removed from source and cleaned from build output.
SFP never falls back to a CSV, even if a stale file is copied back.

The familiar `BASE`, `BASIC` and `CE` sections remain. `STATES` explicitly lists
approved states for each scenario; unsupported states produce an error rather
than an empty successful comparison. A form's state array means `YM` in those
states and `N` elsewhere in that approved scenario. `"all"` means `YM` in all
approved states. Explicit maps such as `{"MD":"YS","PA":"YU"}` support other
selection statuses. `N` requires absence, even unchecked; an entirely unlisted
form remains informational. Blank/invalid statuses and duplicate IDs are rejected.

The current state/edition mappings come from:
`\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\SFP\SFP_BASIC.csv`
and `SFP_CE.csv`. These are read-only source material, **not runtime dependencies**.
The refresh replaces the older September import and the October 2 run-derived
positive lists with the current master mappings. JSON contains the 162 shared
forms in `BASE`, with scenario-specific forms in `BASIC` and `CE`.

Basic includes all 199 master rows plus explicit `N` definitions for the two
previously observed, non-master editions `SF01570726` and `SF07120826` (201 total).
CE includes all 186 master rows plus the existing approved `SF04010120` requirement
for the scenario's Division IV scheduled-property items 409 and 411 (187 total).
That coverage correction is supported by SFP v9's
`Division 4 Masterlist!BG5` (attach when any Division IV coverage is present)
and `BJ5` (mandatory); it is not an automatic promotion from run output.

The uploaded SFP v9/Common v80 Excel files remain supporting catalogs. They are
not interchangeable with the newer complete Tosca scenario matrices: for example,
SFP `Division 0 Masterlist!B7,AV7,AW7` still lists `SF00030120` for PA/MD and has
blank VT company/core cells. The current Tosca masters provide the state/edition
mappings instead of inferring values from those blanks. No newer live SharePoint
Excel revision was verified or claimed.

The workbook catalog is not itself a scenario baseline. Its coverage, company,
effective-date and transaction/output rules still apply. In particular, the local
SFP workbook's `Policy Admin Forms Print Order!A2,B8,B9,B11` separates X-4296,
X-4306 and SM-1703 from customer policy output. Do not merge these administration
forms indiscriminately into the policy-output matrices from the Common catalog.
The older `SFP_BASIC.xlsx` beside the network CSV is not the source of this refresh.

Current master SHA-256 values, checked on 2026-10-05:

| Master | SHA-256 |
|--------|---------|
| `SFP_BASIC.csv` | `F17152E6B26F0626D2CFB086EE9760A441BF139BACF3EEE43262712C156108E7` |
| `SFP_CE.csv` | `68122197C6E5ECFAEC5D4BF485CA08F0EB1820558281F6CD240C22953C5AF961` |

The saved October 2 Basic responses intentionally no longer pass against the
refreshed masters. All actual forms have `selected="2"`; these are missing/extra
forms, not selection-status mismatches:

| State / quote | JSON required | Saved actual | Missing | Unexpected |
|---------------|---------------|--------------|---------|------------|
| VT / 01069487 | 27 | 25 | 5 | 3 |
| MD / 01069492 | 33 | 34 | 3 | 4 |
| PA / 01069493 | 30 | 26 | 4 | 0 |

The focused regressions preserve these differences instead of making expectations
fit the observed runs. Future baseline changes still require review.

After building in Visual Studio, offline coverage exercises the deployed runtime
loader and evaluator for every supported baseline state, verifies the shared
legacy matrix, and checks missing mandatory and explicitly prohibited forms:

```powershell
dotnet test TestAutomation.csproj --no-build --no-restore --filter "FullyQualifiedName~SfpFormsBaselineTests"
```

Review saved XML without making a live quote (PowerShell 7.4+, after a Debug build):

```powershell
pwsh .\Scripts\FormsCheck.ps1 `
  -BaselinePath .\Resources\ExpectedForms\SFP\SFP.json `
  -XmlPath .\bin\Debug\net8.0\TestResults\FormsCheck\SFP\SFP_BASIC_MD_01069492.xml `
  -State MD -QuoteID 01069492 -TestCase BASIC
```

The JSON reader is shared with runtime validation; results go to
`TestResults\FormsCheck\SFP`. Result CSV/HTML reports are not baselines.
Masterlist extraction now writes a review candidate under `TestResults\FormsBaseline`,
never directly over `SFP.json`; its limited state/rule handling is not sufficient
for automatic scenario qualification.

The migration does not change premium assertions, Checklist steps, Forms
nonblocking configuration, or other LOBs' existing loaders.
`Debugging:FailOnFormsValidationError=false` remains unchanged, so a UI pass is
not proof that forms matched. Future run output must not be silently promoted.

### SFP premium recalibration and live qualification

The 2026-09-24 QA batch attempted all 38 Basic states, then all 38 CE states.
It used one worker, headless execution, process-only premium-assertion bypass,
and the then-active scenario forms CSVs. Forms comparison remained enabled and
nonblocking; forms recording remained disabled. No policies were transmitted,
issued, bound, or paid. Normal runs retain `SkipPremiumBaselineAssertion: false`.

The first pass completed 27 Basic and 13 CE workflows, producing 39 qualified
captures: 26 Basic and 13 CE. This changed or added 37 state amounts; both Alabama
amounts were already correct. A qualified capture requires a completed workflow, one
unambiguous positive annual premium and quote number, and a completed comparison
against the correct forms CSV. Forms findings remain separate from premium
qualification; a premium update does not approve its forms result.

Basic Washington's original $9,920 is **not** promoted: the old binding silently
skipped its required code-401 Road Bike, and the Division IV form was missing.
The binding now explicitly navigates to Scheduled Personal Property and fails if
the requested category cannot be found, rather than returning a false pass.
The later complete retry qualified $9,926 (quote `02082192`) with clean forms,
confirming the repaired workflow. CE New Jersey's $2,100 remains held:
Submission's saved Required Fields response
identifies `Liability / Workers' Compensation - Residence Employees`.
Failed or otherwise unqualified states retain their old amounts, or remain
unconfigured where no prior baseline existed.

The completed forms comparisons exposed the following outstanding differences;
the matrices have not been changed just to match live output:

| Workflow/state | Finding |
|----------------|---------|
| Basic OH | Informational extras `OHMSI10709` and `OHMSI20913` |
| Basic MS | Required `SF06200510` and `X35690422` missing |
| Basic TN and CE TN | `SF06200510` and `X35690422` present despite `N` expectations |
| CE LA | Required `SF16300123` and `SF36191224` missing; unlisted `SF26990124` present |
| CE SC | Required `SF06131125` missing |

Developer forms predicates depend on selected wind/hail, hurricane and named-storm
deductibles, Louisiana wind zone, and Ohio mine-subsidence conditions. State/date
coverage alone does not settle these findings, especially after CE address changes.

Other CE qualification blockers are the Potential Invalid Address dialog in
AR, CO, ID, IL, IN, KY, MO, ME, MN, MT, NE, ND, OK, OH, SD and UT, and missing or
incompatible ZIP-specific wind/hail expectations in DE, MS, NH, OR, RI, TX and WA.
The supplied addresses and deductible inputs have not been changed or warnings
dismissed to force a pass. Original TRX, forms reports, failure diagnostics and the
premium-promotion ledger are preserved in the session's recalibration artifacts.

One bounded recovery pass retried the 11 Basic sign-in/session failures and CE WY;
all 12 encountered `DC-500` Duck Creek integration errors before pricing. A single
Basic WA attempt with the guarded SPP binding encountered the same upstream error.
No recovery premiums were promoted. The SPP binding's navigation, required-category
failure and saved input flow are covered by offline browser tests.

A subsequent user-requested retry attempted all 41 workflow/forms failures,
Basic first: 13 Basic and 28 CE. All 13 Basic workflows passed, with 11 clean
forms results and findings in MS/TN. Four CE workflows passed: LA/SC/TN retained
their forms findings and prior premium amounts; WY passed with clean forms and
qualified $4,623 (quote `02082292`). The other 24 CE workflows failed: 16 at the
Potential Invalid Address dialog, seven on ZIP-specific wind/hail expectations,
and NJ on incomplete required fields. These failures were not bypassed.

The 17 independently verified retry captures change or add 13 amounts: 12 Basic
and CE WY; four amounts already matched. Together with the earlier qualified
captures, `ExpectedPremiums:SFP` has updated premiums for all 38 legacy Basic states,
and `ExpectedPremiums:CE` has 14 qualified legacy states. CE DE/ME retain their older,
unqualified amounts; other unsuccessful CE states remain unconfigured. The CE
matrix is therefore still incomplete. MD, PA and VT are unconfigured for both
products and require live DEV premium qualification; no values were copied or
estimated. A clean premium capture is not approval of the outstanding forms
findings.

Run only the new states against DEV:

```powershell
$env:TEST_ENVIRONMENT = "Dev"
dotnet test TestAutomation.csproj --filter "TestCategory=DevOnly"
```

Use `TestCategory=DevOnly&TestCategory=Shard2` or `Shard3` for Basic MD or PA/VT,
and `Shard5` or `Shard6` for CE MD or PA/VT. The QA SFP pipelines explicitly add
`TestCategory!=DevOnly` to every shard filter, and the runtime hook also skips a
`@DevOnly` scenario unless `TEST_ENVIRONMENT=Dev`.

The combined capture/promotion workflow below predates the 41-state master
refresh. Its existing-state guard prevents overwriting the current Basic or CE
expectations; do not bypass it. Premium qualification remains separate work.
The dedicated capture profile records review proposals instead of doing a
normal validation run:

```powershell
.\Scripts\record-new-states.ps1 -ResetProposed
```

`appsettings.RecordBaseline.json` identifies the target as DEV, restricts state
execution to MD/PA/VT, and enables forms record mode. The script still filters on
`TestCategory=DevOnly`, so it runs exactly six cases: Basic and CE for each state.
Missing premium baselines only produce explicit capture messages; they are not
treated as expected values. Forms are exported as proposals rather than compared
or silently promoted.

Each run writes `TestResults\DevQualification\<timestamp>\` containing:

- `SFP_DEV_Qualification.trx` with per-case output and quote evidence;
- `SFP_DEV_Qualification.premiums.csv`;
- `SFP_BASIC_PROPOSED.json` and `SFP_CE_PROPOSED.json`;
- `FormsXml\` with the raw DuckCreek responses from that run.

Raw forms responses can originate under either the repository `TestResults` tree
or the test host's `bin\Debug\net8.0\TestResults` tree. Postprocessing matches each
successful variant/state/quote to its XML and requires exactly one preserved
response per successful baseline case.

Review all six quotes, positive premium captures, and every proposed `YM`/`YS`/
`YU`/`N` value. Then validate the promotion without writing:

```powershell
pwsh .\Scripts\Promote-SFPDevQualification.ps1 `
  -QualificationDirectory ".\TestResults\DevQualification\<timestamp>"
```

After approval, rerun with `-Approve`. The script refuses incomplete/failed
captures, missing quotes, blank statuses, overwrites, and unclassified new forms.
It writes approved premiums under `ExpectedPremiums` in `appsettings.Dev.json`
and adds reviewed scenario states to `SFP.json`. JSON proposal validation requires
PowerShell 7.4+ and the Debug assembly, and uses the same parser as live validation.
Conflicting shared-form expectations require manual scenario classification.
Review the git diff, update the baseline inventory assertions from “unqualified”
to qualified, run the targeted tests, and commit those versioned expectations.
`Scripts\Update-SFPBaseline.ps1` is an INFO-only legacy updater and refuses to
modify the reviewed JSON format; runtime observations alone are not authority.

The new DEV ZIPs have explicit qualification behavior. MD `20855` requires its
row-specific `2%` Wind-Hail option. For PA `17601`, an absent control is accepted;
when DEV exposes it, `N/A` must be offered, selected, and verified after refresh.
For VT `05091`, an absent control is accepted only with an explicit deployment-
drift diagnostic; when present, `1%` must be offered, selected, and verified.
Diagnostics include state, ZIP, offered options, and page identity. Any exposed
all-peril control is handled before Wind-Hail because the live option set is
form/zone/all-peril dependent. Territory is verified when exposed. The MD
Hurricane value is selected only when the live manuscript exposes that optional
control. No percentage is substituted for PA and no generic skip applies to
other states because these inputs affect premiums and forms.

### Forms Baseline Generator

Generates legacy expected-forms JSON. It does not update the scenario-specific
SFP CSVs above. The current generator supports only 23 states and does not evaluate
all workbook attachment conditions or preserve explicit negative expectations;
do not use its output to replace the reviewed Basic/CE matrices.

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
