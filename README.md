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

Use `run.cmd` for normal execution. It applies repository run settings, initializes a safe owned results folder, and writes per-project TRX/NUnit output.

### Run command flavors

```powershell
# 1) All applications
.\run.cmd -Project ALL

# 2) Single application
.\run.cmd -Project CLDC
.\run.cmd -Project CLEQ
.\run.cmd -Project PLDC

# 3) Configuration flavor
.\run.cmd -Project CLDC -Configuration Debug
.\run.cmd -Project CLDC -Configuration Release

# 4) Smoke runs
.\run.cmd -Project ALL -Filter "TestCategory=smoke_test"
.\run.cmd -Project CLDC -Filter "TestCategory=smoke_test"

# 5) LOB smoke + app smoke tag flavor
.\run.cmd -Project CLDC -Filter "TestCategory=smoke_test&TestCategory=cp_smoke_test"
.\run.cmd -Project CLDC -Filter "TestCategory=smoke_test&TestCategory=cldc_smoke_test"
.\run.cmd -Project PLDC -Filter "TestCategory=smoke_test&TestCategory=cycle_smoke_test"

# 6) Product/LOB flavor
.\run.cmd -Project CLDC -Filter "TestCategory=BAP"
.\run.cmd -Project CLEQ -Filter "TestCategory=SFP"
.\run.cmd -Project PLDC -Filter "TestCategory=AUTO"

# 7) Custom output root
.\run.cmd -Project ALL -ResultsDirectory "TestResults"
.\run.cmd -Project CLDC -ResultsDirectory "ClientA_Run_2026_09_11"
```

### Direct dotnet test flavor (advanced)

Use this only when you intentionally bypass `run.cmd` output orchestration:

```powershell
dotnet test .\tests\CommercialLines.DuckCreek.Tests\CommercialLines.DuckCreek.Tests.csproj -c Debug --settings .\Tosca.runsettings --filter "TestCategory=smoke_test"
dotnet test .\tests\CommercialLines.ExpertQuote.Tests\CommercialLines.ExpertQuote.Tests.csproj -c Release --settings .\Tosca.runsettings --filter "TestCategory=smoke_test"
dotnet test .\tests\PersonalLines.DuckCreek.Tests\PersonalLines.DuckCreek.Tests.csproj -c Release --settings .\Tosca.runsettings --filter "TestCategory=smoke_test"
```

### Results produced by `run.cmd`

- Root: `TestResults` (or `-ResultsDirectory` override)
- TRX: `<ResultsRoot>\CLDC.trx`, `<ResultsRoot>\CLEQ.trx`, `<ResultsRoot>\PLDC.trx`
- NUnit xml work area: `<ResultsRoot>\NUnit`, `<ResultsRoot>\NUnitWork\<Project>`
- Scenario evidence: `<ResultsRoot>\Artifacts\<TestAssembly>\<Feature>\<ScenarioTimestampGuid>`

`run.cmd` cleans only the owned results root for the current run and protects it using `.automation-run.lock`.

### Failed-test retries and attempt evidence

Set `execution.retryCount` in `config/framework.json` (or the configuration selected by `TEST_FRAMEWORK_CONFIG`):

- `0` (default): execute once, without retrying.
- `1`: retry a failed scenario once, at most two attempts.
- `2`: retry a failed scenario twice, at most three attempts.

This applies to generated Reqnroll scenarios in CLDC, CLEQ, and PLDC, including Test Explorer, `run.cmd`, and pipeline execution. Each retry repeats scenario setup and teardown with a fresh browser/scenario context. Passing, skipped, and canceled tests are not retried. Assembly/feature initialization failures are outside scenario retry scope. Application-side changes are not rolled back: enable retries only when repeating the scenario is safe.

Every attempt retains its own evidence folder. In the consolidated report, expand a test case and click **1**, **2**, **3** under **Attempts** to view that attempt's steps, logs, screenshots, and errors. The final attempt is selected initially; totals count logical test cases by their final result, while earlier failures remain visible. Standalone scenario reports also link to the other attempt reports. Regenerate the consolidated report after execution using the existing report command.

Offline regression checks (no browser execution): `dotnet test tools/InsuranceAutomation.Retry.Tests/InsuranceAutomation.Retry.Tests.csproj` and `python -B -m unittest discover -s tools -p test_retry_report.py -v`.

### Consolidated report generation

After execution completes:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\Generate-ConsolidatedReport.ps1 -ResultsDirectory "TestResults"
```

Output:

- `TestResults\ConsolidatedReport\report.html`
- `TestResults\ConsolidatedReport\log.html`
- `TestResults\ConsolidatedReport\output.xml`
- `TestResults\ConsolidatedReport\summary.json`

In each test card, attempt buttons `1`, `2`, `3` switch the displayed evidence for that attempt.

### Common execution troubleshooting

- **Credentials missing**: set required `CL_DC_*`, `CL_EQ_*`, `PL_DC_*` environment variables.
- **Parallel appears capped at 2**: `Tosca.runsettings` has `MaxCpuCount=2` and `NumberOfTestWorkers=2`.
- **`state_44` mismatch in PLDC Cycle smoke data**: ensure `state_44` equals uppercase `state_name` in `212_smoke_test_cycle_*.json`.
- **Results lock errors**: avoid manually deleting files under active `TestResults` while a run is in progress.
- **Playwright/browser failures after cleanup**: rerun `.\setup.cmd` to rebuild and reinstall browser dependencies.

### One-time maintenance commands

```powershell
# Clear all bin folders in this repository and rebuild
Get-ChildItem -Path . -Directory -Recurse -Force | Where-Object Name -eq 'bin' | Remove-Item -Recurse -Force
dotnet build .\ToscaCanonicalSimple.sln -c Debug

# Quality gate
python .\tools\package_gate.py
```

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

Video exclusion is controlled in `config/framework.json` and takes precedence over the attachment video switches:

| `reporting.excludeVideos` | `reporting.excludePassedVideos` | Behavior |
| --- | --- | --- |
| `true` (default) | either value | No video recording, report videos, test video attachments or published video files. |
| `false` | `true` (default) | Record when `browser.video` is enabled; remove passed-attempt videos before reporting/publication, retain failed-attempt videos even if a later retry passes. |
| `false` | `false` | Retain recorded videos for all outcomes; existing attachment policies still apply. |

Passed-only filtering cannot prevent recording because the outcome is not known until the attempt ends. Publication filtering also covers video copies and nested evidence ZIPs. Unknown outcomes are not treated as passed. Logs, scenario results, screenshots and traces remain included; result ZIPs use DEFLATE compression. Build a new CI package after changing these settings so Release uses the same policy throughout execution and collection.

Playwright context closure occurs before evidence publication so video, trace and HAR are finalized. Evidence is copied into the NUnit test-result evidence directory, checked for readability and registered using `TestContext.AddTestAttachment`.

## Browser lifecycle

Headed Chromium/Edge execution starts maximized when `browser.maximize` is enabled. A new browser context is created per scenario and is closed after the scenario. Trace/video/HAR finalization happens during scenario cleanup.

## Azure DevOps

Pipeline files:

```text
azure-pipelines-ci.yml
azure-pipelines-cd.yml
azure_pipelines_release_pipeline.json
```

Both pipelines use run names in the form:

```text
yyyyMMdd.increment
```

### Build pipeline

The build pipeline:

1. installs .NET 8;
2. restores and builds the solution;
3. validates and packages compiled binaries, runtime scripts, configuration and report binding sources;
4. publishes the version-2 `testpackage` **Build Artifact**. CI does not run browser tests.

### Release/execution pipeline

The release pipeline downloads the compiled `testpackage` artifact and can independently execute:

- one selected Azure DevOps Test Plan case;
- one complete Test Plan suite;
- compiled test DLLs with an optional VSTest tag/filter expression.

For YAML execution, supply `buildPipelineDefinitionId` and **`ciBuildId`** from one successful CI build. Every job downloads that exact build, not independently selected latest builds. Set `buildConfiguration` to the packaged configuration. Boolean parameters select execution modes; suite and assembly modes use `agentCount` VSTest slices, while a single selected case uses one agent. Test Plan IDs, suite IDs, configuration IDs and the assembly filter are parameters.

Set `agentPool` to your self-hosted Windows pool name in both YAML pipelines. The default `Azure Pipelines` selects a Microsoft-hosted image. For Classic Release, select your actual agent pool in **both** execution and collector phases; the JSON's queue ID is a deployment-time placeholder. Provide sufficient online agents and parallel-job entitlement for VSTest distributed execution; do not rely on multi-agent jobs running correctly with insufficient capacity. Self-hosted agents need .NET/tool download access and Python 3.11 available to `UsePythonVersion` (populate the agent tool cache if automatic installation is unavailable). Configure application credentials as secret pipeline variables.

All execution and collection jobs use `checkout: none` in YAML; Classic consumes only the linked CI artifact. Runtime/results directories are unique per job. **Agent temp directories can be cleaned between jobs**: safety comes from uploading each shard before the execution job ends, not from keeping files on the agent. Each agent service must have its own work directory. Collectors download server-side evidence and never read a previous job's local results.

### Test results and consolidated artifacts

VSTest publishes test results and individual test attachments to the Tests view. This is separate from publishing downloadable result archives; the YAML no longer republishes the same TRX through a second `PublishTestResults` task.

- **YAML:** each agent publishes `evidence-<mode>-<position>-<stageAttempt>` containing `agent-<position>.zip`, checksum-verified chunks and a manifest. The collector waits for every selected execution job, verifies every expected shard, and publishes `consolidated-test-report-<stageAttempt>-<collectorJobAttempt>`.
- **Classic:** each execution job uploads its `agent-<position>.zip` as a task log attachment plus manifest/chunk attachments for the collector. The collector downloads these through the Release API using OAuth (`View releases` permission required). These are **Release task attachments, not named Build/Pipeline Artifacts**.
- Both collectors retain `RawTestResults.zip` before attempting HTML generation. A successful collection also publishes `FinalConsolidatedReport.zip`, containing `ConsolidatedReport/report.html`, `log.html`, `output.xml`, `summary.json`, the collection manifest, and all agents' raw TRX/NUnit/evidence files, including videos and traces that were recorded.
- Extract the complete final ZIP and open `ConsolidatedReport/report.html`; keep its adjacent `Artifacts` directory so evidence links work. Individual test attachment settings do not replace this full evidence handoff.
- Missing, duplicate, stale or corrupt shards fail collection rather than producing a misleading complete report. Previously uploaded per-agent archives remain available for investigation. Force-cancelled/offline agents cannot guarantee an upload; the collector reports missing evidence.
- Rerun the **whole YAML stage**, not selected failed execution jobs: artifact names are immutable and attempt-scoped. A new Classic deployment similarly collects only that deployment's evidence.

Queue a new CI build after changing runtime scripts, then select that build in a new release. Classic definitions are not synchronized from repository JSON automatically. The YAML publishing path is artifact-based; it does not send SMTP email automatically.

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
