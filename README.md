# Enterprise Playwright C# / ReqnRoll Test Automation

This repository contains the executable UI automation framework and test suites for:

- Commercial Lines Duck Creek (`CLDC`)
- Commercial Lines ExpertQuote (`CLEQ`)
- Personal Lines Duck Creek (`PLDC`)

The solution uses .NET 8, Microsoft Playwright, ReqnRoll and NUnit.

## Prerequisites

- Windows 10/11 or Windows Server build agent
- .NET 8 SDK
- PowerShell 7+ recommended
- Microsoft Edge or Playwright Chromium
- Python 3.x only for the repository quality gate
- Azure DevOps Test Plans access when using Test Plan execution

## Local setup

From the repository root:

```powershell
.\setup.cmd
```

The setup script restores NuGet packages, builds the solution and installs Playwright Chromium.

Configure runtime settings in:

```text
config/framework.json
```

For a different config file, set:

```powershell
$env:TEST_FRAMEWORK_CONFIG = "C:\path\framework.json"
```

## Credentials

Do not store credentials in source control. Configure them as environment variables or secure CI/CD variables:

```powershell
$env:CL_DC_USERNAME = ""
$env:CL_DC_PASSWORD = ""
$env:CL_EQ_USERNAME = ""
$env:CL_EQ_PASSWORD = ""
$env:PL_DC_USERNAME = ""
$env:PL_DC_PASSWORD = ""
```

CLDC flows that require the UW Director role also use:

```powershell
$env:CL_DC_UW_DIRECTOR_USERNAME = ""
$env:CL_DC_UW_DIRECTOR_PASSWORD = ""
```

`credentials.example.ps1` contains an empty template.

## Running tests

Run every application:

```powershell
.\run.cmd -Project ALL
```

Run one application:

```powershell
.\run.cmd -Project CLDC
.\run.cmd -Project CLEQ
.\run.cmd -Project PLDC
```

Run by ReqnRoll/NUnit tag:

```powershell
.\run.cmd -Project CLDC -Filter "TestCategory=smoke_test"
.\run.cmd -Project CLDC -Filter "TestCategory=BAP"
.\run.cmd -Project CLDC -Filter "TestCategory=smoke_test&TestCategory=UMB"
```

Run directly with `dotnet test` when required:

```powershell
dotnet test .\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj -c Debug --filter "TestCategory=smoke_test"
```

TRX and NUnit output are written under `TestResults` by the supplied run script.

## Test structure

Each application follows the same separation:

```text
Features/
StepDefinitions/
Pages/
Pages/Locators/
Hooks/
TestData/
```

Feature files remain business-readable. Step definitions own workflow and runtime data decisions. Page classes expose reusable business interactions. Locator classes contain only control identity. Common browser, action, data and reporting behavior is implemented in `src/InsuranceAutomation.Core`.

## CLDC locators

CLDC locator classes use direct Playwright locators. They do not call a shared associated-label locator helper.

For Duck Creek data controls, raw Tosca `Tag=INPUT`, `TEXTAREA` or `SELECT` plus a literal technical DuckCreekId is mapped to the rendered DOM `fieldref`:

```csharp
_page.Locator("input[fieldref=\"PolicyInput.EffectiveDate\"]")
_page.Locator("input[fieldref=\"AccountSSNRetrievalInput.SSNInput\"]")
_page.Locator("input[fieldref=\"PolicyOutputNonShredded.QuoteQuick\"]")
```

This rule includes checkbox controls because Duck Creek renders them as `input` elements. `NoKnownLosses` remains an exact checkbox-role locator because the supplied raw Tosca record contains `Tag=INPUT` but no DuckCreekId, fieldref, id or name. Generic action text is not converted to fieldref. Raw `Tag=A` controls use exact link semantics, such as Login, Start, Next and OK. Stable raw HTML `id` or `name` is used only when it is source-backed and not a generated ExtJS identifier.

When the same technical fieldref is repeated for multiple controls on one rendered module, the direct locator combines fieldref with the exact source label relationship. It does not select an arbitrary occurrence. Controls on mutually exclusive pages that share the same technical fieldref reuse one locator property.

Raw frame information is treated only as a scope hint. Runtime resolution briefly probes a known frame and, when it is not present, resolves the same control in the top document. Successful scope is cached for the Page/Control during the scenario.

## Dropdowns and comboboxes

Dropdown interaction is centralized in `ComponentAwareControlActions`:

1. exact visible option match;
2. unique controlled partial match;
3. controlled Enter commit for an editable combobox when the requested value is actually present in the input;
4. read-only controls may use Enter only when a single active option is related to the requested value.

Native `<select>` controls never guess an arbitrary option. Tab is not used to walk dropdown values.

## Readiness and interaction highlighting

Before an action, the framework performs a bounded best-effort visibility wait. A readiness timeout is logged but is not itself the business assertion; the subsequent Playwright action determines whether the step succeeds.

Interactive controls are highlighted briefly before the action. The original element styling is restored automatically after the configured highlight duration.

## CLDC smoke test data

CLDC smoke tests use one base file per LOB plus one state override file:

```text
TestData/Smoke/BAP.json
TestData/Smoke/CP.json
TestData/Smoke/GL.json
TestData/Smoke/IM.json
TestData/Smoke/WC.json
TestData/Smoke/CPP.json
TestData/Smoke/UMB.json
TestData/Smoke/StateOverrides.json
```

State identity comes from the Scenario Outline. Only values that genuinely differ from the LOB base are placed in `StateOverrides.json`.

Other flows use their referenced `TestData/Scenarios/*.json` files. External/environment-specific values are read from `TestData/ExternalDataOverrides.json` and secure environment variables.

## Runtime description value

CLDC quote descriptions are generated at runtime in the following form:

```text
STATE_LOB_RANDOM4_yyyyMMdd_HHmmss
```

The value entered into Duck Creek is captured from the UI and stored in scenario runtime data. Every protected CLDC Smoke flow navigates back to Policy Info and validates the captured description. The uploaded Smoke feature and step-definition files remain byte-for-byte unchanged in this revision, including temporarily commented Examples rows.

## Verification operators

Verification supports ordinary equality plus generated operator prefixes in the property specification:

```text
Regex:value
Regex:InnerText
NotEqual:Value
NotEqual:InnerText
```

For example, a ZIP validation using `Regex:value` applies the supplied regular expression to the actual input value rather than comparing the pattern as plain text.

## Evidence and reports

Evidence settings are in `config/framework.json`.

The framework can collect:

- failed/passed screenshots according to policy;
- execution log;
- HTML scenario report;
- Playwright video;
- Playwright trace;
- HAR;
- browser console/page errors;
- request/response/request-failure log;
- runtime locator evidence where applicable;
- evidence bundle.

`reporting.passed` and `reporting.failed` independently control what is attached for passed and failed cases. Failure screenshots are always captured when the browser is available.

Playwright context closure occurs before evidence publication so video, trace and HAR are finalized. Evidence is copied into the NUnit test-result evidence directory, checked for readability and registered using `TestContext.AddTestAttachment`.

## Browser lifecycle

Headed Chromium/Edge execution starts maximized when `browser.maximize` is enabled. A new browser context is created per scenario and is closed after the scenario. Trace/video/HAR finalization happens during scenario cleanup.

## Azure DevOps

Pipeline files:

```text
.azuredevops/build.yml
.azuredevops/release.yml
```

Both pipelines use run names in the form:

```text
yyyyMMdd.increment
```

### Build pipeline

The build pipeline:

1. installs .NET 8 and Python;
2. restores and builds the solution;
3. validates the Playwright browser installation;
4. runs `tools/package_gate.py`;
5. publishes the executable `testpackage` pipeline artifact.

### Release/execution pipeline

The release pipeline downloads the compiled `testpackage` artifact and can independently execute:

- one selected Azure DevOps Test Plan case;
- one complete Test Plan suite;
- compiled test DLLs with an optional VSTest tag/filter expression.

The appropriate boolean parameters select which execution stages run. Test Plan IDs, suite IDs, configuration IDs and optional filter are pipeline parameters.

Every execution stage publishes TRX results with run attachments and also publishes the raw evidence directory as a pipeline artifact.

### Email report

The final email stage downloads available evidence artifacts and sends an HTML summary using secure SMTP variables:

```text
SMTP_HOST
SMTP_PORT
SMTP_FROM
SMTP_TO
SMTP_USER
SMTP_PASSWORD
```

Each scenario writes `scenario-result.json` beside its individual HTML report. The final release stage combines all available scenario results into Robot Framework-inspired `report.html`, `log.html`, `output.xml` and `summary.json`, publishes them as `consolidated-test-report`, and sends the same report set through SMTP when the secure SMTP variables are configured.

## Repository quality gate

Before committing or packaging changes, run:

```powershell
python .\tools\package_gate.py
```

The gate checks JSON/YAML/project syntax, C# structural balance, all active feature-step bindings, feature/test-data references, exact layered-data reconstruction, EQ Smoke state lineage, Page-to-Locator references, ExpertQuote locator restrictions, protected CLDC Smoke/NUnit checksums, report generation and package cleanliness. A real `dotnet restore`, `dotnet build` and `dotnet test` remains authoritative and is performed by the Azure build/execution pipelines.


## Layered scenario test data

All application suites retain the original `TestData/Scenarios/*.json` files as Tosca lineage. Runtime loading now also supports:

```text
TestData/Layered/manifest.json
TestData/Layered/<flow>/Base.json
TestData/Layered/<flow>/StateOverrides.json
```

`ScenarioData` reconstructs the requested scenario using JSON Merge Patch semantics. The package gate compares every reconstruction with its original scenario JSON before the package is accepted. This provides the same base-plus-state-override maintenance approach across CLDC Basic/Extended/Miscellaneous, ExpertQuote and PLDC without discarding the source records.

## ExpertQuote state coverage and locators

ExpertQuote BOP Smoke contains 45 active state examples. ExpertQuote SFP Smoke contains the 35 states supported by the supplied SFP Basic records. Existing Smoke records are retained; missing state-specific Smoke records are generated only from the supplied Smoke workflow template plus the corresponding raw-Tosca Basic Policy state record. The full donor and checksum lineage is stored in `Artifacts/Validation/eq-smoke-state-lineage.json`.

ExpertQuote locator classes do not use Duck Creek `fieldref`, `duckcreekid` or `data-duckcreekid` selectors. They use source-backed Angular/stable contracts such as `data-testid`, stable `id`/`name`, ARIA role and exact action text. PLDC retains its own project/page classes while using the same Angular-style selector format where the supplied PLDC/EQ flow exposes those controls.

Root Azure entry points are also included for easier pipeline selection:

```text
azure-pipelines-ci.yml
azure-pipelines-cd.yml
```
