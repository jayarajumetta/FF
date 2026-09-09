# Enterprise Playwright C# / ReqnRoll Test Automation

This repository contains the executable UI automation framework and test suites for:

- Commercial Lines Duck Creek (`CLDC`)
- Commercial Lines ExpertQuote (`CLEQ`)
- Personal Lines Duck Creek (`PLDC`)

The solution uses .NET 8, Microsoft Playwright, ReqnRoll and NUnit.

## Prerequisites

- Windows 10/11 or a Windows Server build agent
- .NET 8 SDK
- PowerShell 7+ recommended
- Microsoft Edge or Playwright Chromium
- Python 3.x for the repository quality gate and consolidated HTML report
- Azure DevOps Test Plans access when Test Plan execution is required

## Local setup

From the repository root:

```powershell
.\setup.cmd
```

The setup script restores NuGet packages, builds the solution and installs Playwright Chromium. Runtime settings are read from:

```text
config/framework.json
```

To use another framework configuration:

```powershell
$env:TEST_FRAMEWORK_CONFIG = "C:\path\framework.json"
```

## Credentials and environment overrides

Do not store real credentials in source control. Configure them as secure environment or pipeline variables:

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

Each application has one `TestData/ExternalDataOverrides.json`. It is intentionally restricted to:

```json
{
  "application": {
    "url": "https://approved-test-environment/",
    "username": "SYNTHETIC_REPLACE_ME",
    "password": "SYNTHETIC_REPLACE_ME"
  }
}
```

Business inputs, state data, LOB data and expected values are not accepted in the external override file. They belong in the direct state files described below. `credentials.example.ps1` contains an empty local template.

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

Direct `dotnet test` execution is also supported:

```powershell
dotnet test .\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj -c Debug --filter "TestCategory=smoke_test"
```

TRX and NUnit output are written under `TestResults` by the supplied run script.

## Project structure

Each application uses the same separation:

```text
Features/
StepDefinitions/
Pages/
Pages/Locators/
Hooks/
TestData/
```

Feature files remain business-readable. Step definitions own workflow and runtime-data decisions. Page classes expose reusable business interactions. Locator classes contain control identity. Common browser, interaction, data, evidence and reporting behaviour is implemented under `src/InsuranceAutomation.Core`.

## Direct shared-state test data

The previous layered merge model, state override manifests and one-file-per-LOB/per-state scenario files have been removed. Every application now uses one direct file for each **test category and state variant**:

```text
TestData/Smoke/AL.json
TestData/Basic/AL.json
TestData/Extended/AL.json
```

The sharing rule is deterministic:

- every Smoke LOB for the same application and state references the same `Smoke/<state>.json`;
- every Basic LOB references the separate but shared `Basic/<state>.json`;
- Extended/Expanded flows reference `Extended/<state>.json`;
- a state variant such as `MA_AUTO` or `UT_ANP` has its own direct file because it is a distinct executable variant.

A direct state file contains shared values once and only genuinely flow-specific values beneath the feature name:

```json
{
  "schemaVersion": "2.0-direct-state",
  "state": {
    "code": "AL",
    "name": "Alabama",
    "variant": "AL"
  },
  "values": {
    "state": "AL",
    "transaction": "Smoke Test"
  },
  "random": {
    "SharedReference": {
      "pattern": "^[A-Z0-9]{6}$"
    }
  },
  "flows": {
    "BAP Smoke Test": {
      "values": {
        "product_lob": "BAP"
      },
      "random": {
        "InsuredSSN": {
          "pattern": "125[0-9]{6}"
        }
      }
    },
    "UMB Smoke Test": {
      "values": {
        "product_lob": "UMB"
      }
    }
  }
}
```

`ScenarioData` selects the flow using the current ReqnRoll feature title. There is no merge manifest and no hidden state patch. Common and flow sections are checked for duplicate keys by the package gate.

### Data precedence

The effective value order is deliberately small and visible:

1. values captured or generated during the current scenario;
2. approved external `url`, `username` and `password` values;
3. the selected feature-flow values in the direct state file;
4. the shared values in that state file;
5. `state.code`, `state.name` and `state.variant` as defaults when an equivalent business value is not already present.

Runtime captures use `SetRuntime`/`Set`. Random values are generated once per scenario and then retained in runtime data. The framework continues to resolve existing `{B[...]}`, `{PL[...]}` and `{{runtime:...}}` expressions so the working feature and page flows are not broken while names are gradually made more business-readable.

## Optional per-business-step timeout

Each application has one:

```text
TestData/StepTimeouts.json
```

Leave `features` empty to use the standard framework timeouts. To increase or reduce the timeout for one business step, add the exact feature title and exact Gherkin step text without the `Given`, `When`, `Then` or `And` keyword:

```json
{
  "features": {
    "BAP Smoke Test": {
      "I complete Business Auto policy-specific fields": "90s"
    }
  }
}
```

Accepted values are positive milliseconds, `45s` or `2m`. `*` may be used in a step expression, and feature `*` may be used for a cross-feature default.

The hook establishes the timeout before the step starts. The value flows through asynchronous step definitions, page methods, UI actions, Playwright page/context defaults and CLDC frame/control waits. Defaults are restored in `AfterStep`, including when a step fails. Existing `PauseAsync` calls remain fixed, deliberate stabilisation delays; the step timeout controls how long actions and readiness checks may wait and does not silently multiply those pauses.

## Runtime quote descriptions

CLDC quote descriptions are generated at runtime in the following form:

```text
STATE_LOB_RANDOM4_yyyyMMdd_HHmmss
```

The entered value can be captured from the UI and reused through scenario runtime data for later validation.

## Locator and interaction policy

CLDC locator classes use direct Playwright locators. Stable Duck Creek data controls use rendered DOM `fieldref` selectors where the application exposes a reliable technical field identity:

```csharp
_page.Locator("input[fieldref=\"PolicyInput.EffectiveDate\"]")
_page.Locator("input[fieldref=\"AccountSSNRetrievalInput.SSNInput\"]")
```

Links and buttons use stable semantic identity where appropriate. Generated framework IDs are avoided. When a technical identifier is repeated in the same rendered module, the locator also uses a stable section/label relationship rather than selecting an arbitrary occurrence.

Frame information is treated as a scope hint. Runtime resolution probes the configured frame and falls back to the top document when the control is not present there. The successful scope is cached for the Page/Control during the scenario.

ExpertQuote locator classes do not use Duck Creek `fieldref`, `duckcreekid` or `data-duckcreekid` selectors. They use Angular and stable browser contracts such as `data-testid`, stable `id`/`name`, ARIA role and exact action text. PLDC retains its own project/page classes while using the same Angular-style selector format where its ExpertQuote execution flow exposes those controls.

### Dropdowns and comboboxes

Dropdown interaction is centralized in `ComponentAwareControlActions`:

1. exact visible option match;
2. unique controlled partial match;
3. controlled Enter commit for an editable combobox when the requested value is present;
4. read-only controls may use Enter only when a single active option is related to the requested value.

Native `<select>` controls do not guess an arbitrary option. Tab is not used to walk dropdown values.

### Readiness and highlighting

Before an action, the framework performs a bounded visibility/readiness wait. A readiness timeout is diagnostic; the subsequent Playwright action remains authoritative. Interactive controls are highlighted briefly before the action and their original styling is restored automatically.

## Verification operators

Verification supports ordinary equality and these property prefixes:

```text
Regex:value
Regex:InnerText
NotEqual:Value
NotEqual:InnerText
```

For example, `Regex:value` applies the supplied expression to the actual input value rather than comparing the pattern as plain text.

## Evidence and consolidated reporting

Evidence settings are in `config/framework.json`. Depending on policy, the framework can collect:

- failed/passed screenshots;
- execution log;
- individual HTML scenario report;
- Playwright video, trace and HAR;
- browser console/page errors;
- request/response/request-failure log;
- runtime locator evidence;
- evidence bundle.

Each scenario writes `scenario-result.json` beside its evidence. `tools/generate_consolidated_report.py` recursively combines all scenario-result files into:

```text
report.html
log.html
output.xml
summary.json
```

The consolidated HTML includes feature/scenario/step hierarchy, resolved bindings, test data, failure details, embedded failure screenshots and embedded execution logs. Binary artifacts remain linked to avoid excessively large report files.

## Azure DevOps

Canonical pipeline files:

```text
.azuredevops/build.yml
.azuredevops/release.yml
```

Root aliases are also supplied:

```text
azure-pipelines-ci.yml
azure-pipelines-cd.yml
```

The build pipeline installs .NET 8 and Python, restores/builds the solution, validates Playwright installation, runs `tools/package_gate.py` and publishes the compiled test package. The release pipeline supports selected Test Plan case execution, suite execution and compiled DLL/tag/filter execution. It publishes TRX plus raw evidence and generates the consolidated report.

SMTP delivery uses secure variables:

```text
SMTP_HOST
SMTP_PORT
SMTP_FROM
SMTP_TO
SMTP_USER
SMTP_PASSWORD
```

## Repository quality gate

Run before committing or packaging:

```powershell
python .\tools\package_gate.py
```

The gate checks:

- JSON, YAML and project XML syntax;
- C# structural balance;
- all feature-step bindings;
- direct-state references and shared-file ownership;
- absence of layered/scenario override artifacts and historical metadata;
- external override restrictions;
- timeout configuration and propagation contracts;
- page-to-locator member references;
- Python report generation;
- package cleanliness.

A real `dotnet restore`, `dotnet build`, `dotnet test` and live browser execution remain authoritative and are performed on a workstation or Azure DevOps agent with .NET 8 and access to the customer applications.
