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

For Duck Creek controls where a source DuckCreekId is available and the rendered DOM exposes it as `fieldref`, the primary selector is the actual element tag plus fieldref, for example:

```csharp
_page.Locator("input[fieldref=\"PolicyInput.EffectiveDate\"]")
_page.Locator("input[fieldref=\"data.VersionIDPages\"]")
_page.Locator("a[fieldref=\"Start\"]")
```

When a fieldref is not available, locators use stable raw HTML ID/name, supported test identifiers, actual link/button semantics, or label-to-associated-control resolution.

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

The value entered into Duck Creek is captured from the UI and stored in scenario runtime data. Every CLDC smoke flow navigates back to Policy Info and validates the captured description before sign-out.

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

### Duck Creek locator contract

CL|DC locators distinguish data controls from action/display controls. For rendered `INPUT` controls whose raw Tosca DuckCreekId is a data-binding identifier (for example `AccountInput.*`, `PolicyInput.*`, `data.*`), use `input[fieldref="..."]`. Do not infer fieldref for links, buttons or display DIVs merely because Tosca contains DuckCreekId.

For raw `Tag=A`, use Playwright link semantics with the exact source-backed accessible text. Login is therefore `GetByRole(Link, Name="Login")`; Start, Next, OK, Add Client and similar actions follow the same rule unless a stable raw HTML id/name is proven. Stable raw HTML ids such as `username-inputEl` and `password-inputEl` are used directly. ExtJS generated ids such as `f_<hash>...-inputEl` and `ext-element-<number>` are not treated as stable technical locators. When a stable raw name exists it is preferred over a generated id. Text inputs without a proven technical selector resolve the label to the associated actual control rather than using role+label text blindly.

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

Failed cases appear before passed cases. Failed report detail is embedded in the email body, failed screenshots are resized/compressed and embedded as JPEG data, the combined HTML email report is attached, and failed scenario HTML reports are attached separately. Long passed-case lists are clipped in the email body while complete results remain in Azure DevOps.

## Repository quality gate

Before committing or packaging changes, run:

```powershell
python .\tools\package_gate.py
```

The gate checks feature/test-data references, state dimensions, JSON validity, C# structural balance, locator duplication, Page-to-Locator references, CLDC fieldref contracts, dropdown/verification contracts, smoke description validation, hardcoded credentials and client-package cleanliness.
