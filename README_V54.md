# Tosca → Playwright C# / ReqnRoll v54

## 1. Release objective

v54 treats the original Tosca exports as executable specification data. It fixes the class of defects caused by flattening Tosca into an intermediate manual representation: repeated login/logout internals, misplaced navigation, verification before data entry, and control actions inferred from business wording rather than module semantics.

**Source-of-truth order:**

`Template / TemplateInstance → concrete TestCase → reusable block reference → recursively expanded Items → XTestStep → XTestStepValue → ModuleAttribute / XParam`

Manual CSV, XLSX and generated HTML are not used to decide flow order, test data, conditions, locator semantics or enabled/disabled execution.

## 2. Scope and raw contract

The selected estate contains:

- Commercial Lines ExpertQuote: **5 Features / 120 examples**
- Commercial Lines Duck Creek: **18 Features / 515 examples**
- Personal Lines Duck Creek: **9 Features / 439 examples**
- Total: **32 Features / 1,074 examples**

`tools/v54_raw_tosca_contract.py` validates all 1,074 examples against raw TemplateInstance-derived concrete TestCases. The latest snapshot is `Artifacts/V54RawToscaContract.json` and reports `RAW_TOSCA_ONLY`, `manualCsvXlsxHtmlUsed=false`, and 1,074/1,074 matches.

Every generated `.feature` carries raw TestCase/TemplateInstance provenance comments. Every scenario JSON carries `_meta.sourceTruth=RAW_TOSCA`, `manualArtifactsUsed=false`, and raw GUID lineage.

## 3. Stack

- .NET 8
- C#
- Microsoft Playwright for .NET
- ReqnRoll
- NUnit 4 + NUnit3TestAdapter
- Azure DevOps VSTest/Test Plans integration
- Python quality/contract tooling

## 4. Clean business Feature policy

Features represent business journeys, not the implementation details inside reusable Tosca blocks.

For CL|DC, for example, `Common|General|Log In to DuckCreek` is emitted as one business login operation. Internal restart-popup, verify-user, retry-login and internal logout operations remain inside the implementation layer and do not appear as repeated Feature steps.

Raw-enabled secondary authentication transitions are preserved when they are genuinely part of the business execution path. Examples include:

- CP Basic authenticated-session refresh;
- CPP/GL conditional UW Director transitions for applicable states;
- GL conditional switch-back where Tosca enables it;
- post-condition logout only when the raw reusable reference is enabled.

Disabled Tosca references never become executable Feature steps.

## 5. Corrected ExpertQuote account flow

The raw reusable account block proves that address entry precedes map/satellite verification. The page operation is therefore:

`Account → owner data → Married → Address1 → Address2 → City → State → ZIP → County → Map → Satellite → 90-day Yes → residence Yes → Next`

All five selected ExpertQuote flows use this source-backed sequence. Address values are read from the raw-lineage canonical reusable parameters rather than simulated by Tab/Enter steering.

## 6. Component-aware actions

Action selection is based on Tosca ModuleAttribute technical semantics plus rendered component behavior, not the English verb alone.

- native `<select>` → `SelectOptionAsync`
- `mat-select`/MDC combobox → click trigger, then click matching option
- Yes/No DIV/chip/button → click
- checkbox/radio → state-aware check/click
- autocomplete → fill + option selection
- date picker → date-component handling
- table/grid/dialog/tab/expansion → component-aware handling
- heading/navigation/container controls are not allowed to silently become `FillAsync`

Exact dotted HTML IDs are emitted using safe attribute selectors rather than CSS `#a.b` interpretation.

## 7. Default synchronization and verification

Synchronization is centralized in the core framework. Current defaults are defined in `config/framework.json`:

- page-ready: 30 s
- normal element readiness: 20 s
- verification readiness: 20 s
- deterministic fallback candidate probe: 4 s
- navigation timeout: 60 s
- Playwright action timeout: 30 s

Before normal actions the framework best-effort waits for `DOMContentLoaded` and then the intended control state. A primary locator is not treated as broken merely because the page is still rendering.

### Deferred verification

A verification runs through:

`wait → primary → deterministic Tosca fallback → optional AI healing → record deferred verify failure`

Non-fatal verification failures are recorded, screenshot evidence is taken, the test may continue collecting useful evidence, and the scenario is failed at finalization after the evidence has been attached. Browser/context-closed and other fatal execution errors are not swallowed.

## 8. Primary and fallback locators

Readable primary locators remain under:

`tests/<application>/Pages/Locators/`

Typed application/page fallback views live in parallel under:

`tests/<application>/Pages/FallbackLocators/`

The raw locator source catalog is:

`Artifacts/ToscaLocatorPropertyCatalog.v54.raw.json`

The runtime order is:

`primary → previously successful deterministic candidate → remaining ranked Tosca candidates → AI healing → final failure`

Candidates are accepted only when visible/action-compatible and unique, unless Tosca itself supplied a literal occurrence/index. v54 does not invent `.First`/`.Nth` merely to silence strict mode.

Latest canonical fallback maturity:

- ExpertQuote: **97.56%**
- Commercial Duck Creek: **99.12%**
- Personal Duck Creek: **99.23%**
- Overall: **98.75%**

More than 98% overall have at least two deterministic alternatives.

## 9. Logging, reporting and evidence

Each scenario has its own artifact identity. Evidence can include:

- execution log;
- browser console log and page errors;
- request/response/network-failure log;
- screenshots, including final and failure screenshots;
- Playwright trace;
- HAR;
- Playwright video;
- HTML execution report;
- deterministic fallback trace;
- healing evidence;
- evidence bundle and checksum manifest.

The browser context is closed before final video/HAR paths are collected, ensuring those files are finalized.

### Visual Studio Test Explorer attachments

`NUnitEvidencePublisher` stages selected evidence beneath:

`TestContext.CurrentContext.WorkDirectory/TestEvidence/<test>/`

and attaches those staged files using `TestContext.AddTestAttachment`. A small start marker is attached in `BeforeScenario`, so even an early browser-start failure has a test-result attachment. `Tosca.runsettings` and `Directory.Build.props` configure the NUnit work directory for Visual Studio/vstest.

## 10. Local setup

Requirements:

1. .NET 8 SDK
2. Visual Studio 2022 or `dotnet` CLI
3. Playwright browser dependencies
4. access to the target test environments

PowerShell:

```powershell
.\scripts\setup.ps1
.\scripts\install-browsers.ps1
.\scripts\build.ps1
```

Run from Visual Studio Test Explorer using `Tosca.runsettings`, or use:

```powershell
.\scripts\run.ps1
```

Keep credentials in environment variables/secret stores. Do not commit real credentials. See `credentials.example.ps1`.

## 11. Azure DevOps

Two separate pipelines are included.

### Build pipeline

`.azuredevops/build-test-artifact.yml`

Performs restore, compile, v54 structural/maturity gates, and publishes the immutable compiled test artifact. It does not execute UI tests.

### Execution pipeline

`.azuredevops/execute-test-artifact.yml`

Consumes the compiled artifact without rebuilding and has exactly three execution stages:

1. `AllCases` — all selected tests;
2. `SingleTestPlanCase` — exactly one configured Test Plan case via a temporary static suite;
3. `TestSuite` — the selected Test Plan suite.

Each execution stage publishes test-result attachments and retains raw scenario evidence as a pipeline artifact.

## 12. Regeneration and validation

Raw-source contract validation:

```powershell
python .\tools\v54_raw_tosca_contract.py
```

This requires access to the raw exports in the locations expected/configured by the tool. It must never be replaced by a manual CSV/XLSX source.

Repository release gates:

```powershell
python .\tools\quality_gate.py .
python .\tools\v54_maturity_gate.py
```

Raw locator extraction/regeneration tooling is under `tools/`.

## 13. Contribution rules

1. Raw Tosca object identity and association order wins over any derived manual representation.
2. Preserve TemplateInstance/concrete TestCase lineage.
3. Expand reusable blocks recursively and preserve `Items`, `XTestStep` and `XTestStepValue` order.
4. Respect source-enabled/source-disabled references and control-flow conditions.
5. Keep Features business-readable; reusable login/recovery internals do not become duplicate Gherkin steps.
6. Keep one primary Page locator plus typed deterministic fallback evidence.
7. Never invent index/`First`/`Nth` to hide ambiguous selectors.
8. Do not map `Select` to HTML `SelectOptionAsync` unless the rendered/source control is a native select.
9. Do not turn navigation/verification into `FillAsync` merely because a source value exists.
10. Wait before deciding a locator is broken.
11. Verification failures may be deferred; fatal execution errors may not.
12. Evidence finalization must complete before the scenario is finally failed for accumulated verification defects.
13. No duplicate Page classes, Feature sentences, bindings or Page methods for the same semantic responsibility.
14. Run the v54 gates before merging.

## 14. Validation status and compiler boundary

`Artifacts/V54FinalValidation.json` is the release validation snapshot. The current static/raw contract gate is PASS with 32 Features, 1,074 raw example matches, mature waits/evidence/fallbacks, and no manual generation inputs.

The artifact-generation environment used to prepare this repository does not provide `dotnet`, `csc` or `msbuild`; therefore it cannot honestly claim a local compile. Visual Studio and the included Azure build pipeline are the mandatory compiler/runtime gates.
