# v57 — Runtime Contract Hardening on v56

v57 keeps the v56 raw-Tosca / ReqnRoll / NUnit solution and the same three application streams, but changes the runtime contracts that were most likely to pass static validation and then fail in the browser:

- `CommercialLines.ExpertQuote` (EQ)
- `CommercialLines.DuckCreek` (CL|DC)
- `PersonalLines.DuckCreek` (PL|DC)

Scope remains **32 Features / 1,074 raw concrete Tosca examples**. v57 is not a feature regeneration. It is a locator, interaction, frame, reuse, keyboard and evidence-finalization hardening release.

## 1. Setup

Prerequisites:

- .NET SDK 8.0.x (the repository `global.json` targets `8.0.423` with latest-patch roll-forward)
- PowerShell 7+ or Windows PowerShell for the supplied scripts
- Playwright browser dependencies for the execution host
- application credentials supplied through environment/secret configuration; never commit them

Typical local bootstrap:

```powershell
./scripts/setup.ps1
./scripts/install-browsers.ps1
./scripts/build.ps1
```

or:

```powershell
./setup.cmd
./run.cmd
```

The solution entry point is `ToscaCanonicalSimple.sln`. Framework runtime options are under `config/framework.json`.

## 2. Architecture and ownership

The execution chain remains:

`Feature -> StepDefinition -> Page method -> canonical Page locator -> UiActions -> deterministic fallback -> Playwright`

Raw Tosca remains the ordering/source authority for migrated test semantics. v57 does **not** treat a generated selector string as physical control identity. Reuse is keyed by the physical Tosca `moduleAttributeGuid` where raw identity is available.

For CL|DC, repeated references to the same physical ModuleAttribute are centralized in:

`tests/CommercialLines.DuckCreek.Tests/Pages/Locators/CanonicalDuckCreekLocatorFactory.cs`

Different raw ModuleAttributes are not aliased merely because an earlier generator happened to produce the same selector text. This prevents unrelated controls such as different Add links or underwriting questions from collapsing onto one locator.

Application fallback catalogs remain isolated:

- `Artifacts/LocatorFallbackCatalogs/CommercialLines.ExpertQuote.json`
- `Artifacts/LocatorFallbackCatalogs/CommercialLines.DuckCreek.json`
- `Artifacts/LocatorFallbackCatalogs/PersonalLines.DuckCreek.json`

No fallback candidate may cross application source boundaries.

## 3. CL|DC locator priority

The v57 Duck Creek hierarchy is deliberately evidence-first:

1. **unique raw `fieldref`**
2. **stable raw HTML `id`**
3. **stable raw HTML `name`**
4. **application-supported test id / AutomationId**
5. **label -> associated actual input/select/textarea/checkbox/radio/combobox**
6. **role + accessible name only when the raw/rendered DOM semantics support that role**
7. **source-backed parent/sibling/component relationship**
8. **source-backed occurrence/index**

`DuckCreekId` is **not** promoted merely because a Tosca metadata record contains such a value. CL|DC v57 primary locators and its generated fallback catalog contain no raw-only `DuckCreekId` selector. Generic Core support remains only for legacy/application catalogs that already have browser-backed evidence.

### Login contract

CL|DC is explicit:

- username -> raw HTML id `username-inputEl`
- password -> raw HTML id `password-inputEl`
- Login -> link semantics (`<a>` / `AriaRole.Link`), not a generated DuckCreekId button

EQ login locator code is intentionally unchanged from v56. PL|DC login is changed only for its own raw evidence: `username`, `password`, and the `signInBtn` anchor.

## 4. Label resolution

A label is not assumed to be the control. `LocatorResolution.ByAssociatedLabel(...)` resolves label text to the associated technical control through:

- `label[for] -> element[id]`
- form controls nested inside the label
- supported sibling form-control layouts

This applies to input/select/textarea and checkbox/radio/combobox semantics. `GetByText(label)` is not used as a substitute for the target form control.

## 5. Button versus link semantics

Tosca BusinessType names do not override the actual raw tag. If Tosca calls a control a Button but raw evidence has `Tag=A`, v57 treats it as a link. Click behavior is technical-element/role based rather than forcing `AriaRole.Button`.

The final raw-semantic audit corrected 45 generated button-role properties to link semantics where raw field evidence unanimously reported `Tag=A`. It also remapped two reused `OK` physical controls (four Page-property references) away from incorrectly inherited heading GUIDs to their actual raw ModuleAttribute GUIDs; primary and fallback catalogs use the corrected identities.

## 6. Frame resolution — HtmlFrame is a hint

v56 could force `FrameLocator` from raw HtmlFrame classification. v57 makes raw frame ancestry a runtime hint.

```text
Control intent
    |
Raw Tosca HtmlFrame evidence?
    | yes
Brief probe of matching frame (default 600 ms)
    |-- frame exists -> resolve/action inside frame
    |-- frame absent -> resolve/action in normal document
    |
Cache the scope that actually succeeded for Page.Control
```

Important behavior:

- `LocatorResolution.Build(IPage, spec)` always builds against the top document.
- `BuildInFrame(...)` is called only after the resolver has established that a frame candidate is present.
- successful scope is cached by `Application|Page|Control`, not by action, so later Fill/Click/Verify calls do not repeatedly pay the wrong-scope cost.
- a cached document success prevents unnecessary frame probing for the same control.
- frame-aware dropdown options use `FrameExecutionContext` so rendered options are searched in the scope that actually succeeded.

This means a stale/false Tosca HtmlFrame classification no longer makes the current rendered control unreachable.

## 7. Dropdown / autocomplete algorithm and timing

v57 uses one bounded semantic selection kernel for native selects and rendered combo/autocomplete controls:

```text
open/fill component
    -> exact normalized option match
    -> unique controlled partial match
    -> controlled Enter commit only when combo/autocomplete semantics prove Enter is meaningful
    -> otherwise fail deterministically
```

Rules:

- native `<select>` reads its option text once and uses `SelectOptionAsync` with the matched label.
- rendered options are collected in **one browser round-trip per poll** (`EvaluateAllAsync`) rather than `IsVisible/InnerText` calls for every option.
- exact duplicate labels are rejected rather than arbitrarily picking one.
- partial matching uses starts-with / contains / token coverage and accepts only one best result; score ties are rejected.
- popup scope uses `aria-controls` / `aria-owns` when available.
- default rendered-option probe is **1,200 ms** with **75 ms polling**; this is intentionally much smaller than the normal 15 s action timeout.
- **Tab is never used to walk dropdown options.**
- Enter is retained only for a real combo/list/autocomplete selection/commit meaning.

The settings are under `waits.dropdownOptionTimeoutMs` and `waits.dropdownPollIntervalMs` in `config/framework.json`.

## 8. Conditions and keyboard operations

v57 preserves the raw Tosca condition-expression sequence from v56. `Artifacts/V57ConditionSourceOrderBaseline.json` records the source-order baseline and the v57 release gate compares every condition sequence against it.

Only exact adjacent duplicate **state actions** are removed when there is no `if`, `else`, condition, or other business statement between them. Timing/logging calls (`PauseAsync`, `NoteAsync`) are not deduplicated as state actions.

Keyboard contract:

- no generated `Press...Async("CLICK")`
- CLICK is represented as click behavior
- DOUBLECLICK remains mouse double-click behavior
- redundant Tab after semantic set/select/fill is suppressed
- dropdown navigation does not use Tab
- Enter is suppressed after a semantic action already committed a selection; otherwise it is allowed only where the control exposes commit semantics

## 9. Page-object consistency

Page classes use `_page` consistently. Locators do not mix `page` and `_page`, and generated locator repositories do not call `Page.Locator(...)` from an instance that owns `_page`.

A test case should call an existing Page method for a physical control. Do not introduce `Control2`, `ControlCopy`, or renamed locator copies to work around locator generation. If raw Tosca points to the same `moduleAttributeGuid`, reuse the canonical locator definition.

## 10. Evidence finalization and NUnit attachment

v57 removes the sample/dummy attachment pattern. Real evidence is registered only after Playwright has finalized it.

Scenario finalization order:

1. capture final scenario screenshot while the page is still open;
2. stop Playwright trace;
3. close the browser context;
4. resolve and persist the finalized Playwright video;
5. write/finalize `report.html` and flush `execution.log`;
6. build the scenario evidence bundle when enabled;
7. copy evidence into NUnit `WorkDirectory/TestResults/TestEvidence/...`;
8. existence/readability-check the copied file;
9. only then call `TestContext.AddTestAttachment`.

The publisher explicitly checks the expected real evidence before registration:

- `report.html`
- `execution.log`
- at least one scenario screenshot when configured
- finalized video when video is configured

Trace is attached when enabled and present. A `test-evidence-manifest.json` records hashes and categories.

### Console and HAR in v57

Per request, browser console/request-response collection and HAR execution are disabled in this release. Their implementation remains in `BrowserSession` for a later controlled re-enable:

- `WireEvidence(...)` remains implemented but is not invoked.
- HAR context options remain implemented but are guarded by the v57 disabled constant.
- `framework.json` defaults `browser.har=false`, `reporting.includeConsoleErrors=false`, and `includeNetworkErrors=false`.

Do not treat missing HAR/console files as missing v57 evidence.

## 11. Azure DevOps execution

The repository keeps build and execution separated:

- `.azuredevops/build-test-artifact.yml` restores/builds/packages the immutable test artifact.
- `.azuredevops/execute-test-artifact.yml` downloads that artifact and executes it without rebuilding.

Supported execution modes remain:

- all automated cases
- one ADO Test Plan case via a temporary static suite containing exactly one test point
- a requested Test Suite under the supplied Plan/Configuration

The Azure Test Case must retain its automated-test association (`AutomatedTestName`, `AutomatedTestStorage`, `AutomatedTestType`). `VSTest@3` publishes per-test attachments; the framework also stages its own persistent NUnit evidence so VS Test Explorer and pipeline runs receive the same finalized artifacts.

Use Azure secret variables / variable groups for application credentials. The temporary-suite lifecycle uses `System.AccessToken`; do not commit a PAT.

## 12. Contribution rules

When changing a migrated control or runtime contract:

1. prove the physical source identity (`moduleAttributeGuid`, module and field) before changing a canonical locator;
2. prefer raw browser-exposed technical evidence in the v57 hierarchy; do not promote a metadata-only property;
3. do not infer frame scope solely because the historical Tosca object sits under HtmlFrame;
4. never weaken runtime uniqueness to make a locator “pass” static coverage;
5. keep CL|DC, PL|DC and EQ fallback catalogs isolated;
6. do not replace raw source-order conditions with reordered “cleaner” logic;
7. use semantic selection for dropdowns; do not add Tab-based option walking;
8. do not attach placeholder evidence;
9. add/reuse the canonical Page method rather than cloning a physical control under another name;
10. run `python tools/v57_release_gate.py` before packaging.

CL|DC exact raw fallback regeneration is available through:

```text
python tools/build_exact_raw_fallbacks_v57.py
```

The supporting audit artifacts are under `Artifacts/V57*.json`.

## 13. v57 release gate

`tools/v57_release_gate.py` validates the runtime contracts above, including raw example counts, application isolation, zero CL|DC DuckCreekId generation, login semantics, fieldref ordering, frame probe/cache behavior, dropdown algorithm/timing, condition source order, no duplicate adjacent state actions, keyboard rules, canonical reuse, evidence finalization, JSON/XML integrity and C# structural checks.

A real .NET compilation is still the compiler authority. `Artifacts/V57ReleaseValidation.json` records whether compilation could be executed in the packaging environment; Azure DevOps/Visual Studio should always retain `dotnet build` as a mandatory release gate.
