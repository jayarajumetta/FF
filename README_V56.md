# v56 — Raw-Tosca Frame-Aware Playwright Architecture

v56 uses v55 as its baseline and keeps the three application streams isolated:

- CommercialLines.ExpertQuote
- CommercialLines.DuckCreek
- PersonalLines.DuckCreek

## Source of truth

Generation and validation use the raw Tosca `.tsu` object graph only for execution semantics: Template/TemplateInstance → reusable references → XTestStep → XTestStepValue → XModuleAttribute/XParam. Manual CSV/XLSX/HTML exports are not ordering authorities.

## Iframe / popup conversion

Raw Tosca `XModuleAttribute` nodes with `BusinessType=HtmlFrame` or `Tag=IFRAME` are now preserved as locator ancestry. `tools/extract_tosca_frame_contexts_v56.py` produces `Artifacts/ToscaFrameContexts.v56.json`. A control below a Tosca frame is resolved in Playwright through `IPage.FrameLocator(...)`; it is never searched only in the top document.

Runtime identity is:

`Application → Page/Module → Frame → Control`

The same frame metadata is copied onto deterministic fallback candidates. Frame-scoped dropdown/autocomplete options are searched inside the same frame, not on the parent page. Dynamic Tosca frame ids ending in `*` become source-backed prefix selectors such as `[id^="dctPopup_dctPopupWindow"]`.

Raw frame analysis in this release found explicit frame ancestry in CL|DC and CL|EQ. PL|DC had no explicit HtmlFrame ModuleAttribute in the supplied raw pack, so v56 does not invent frame context for PL|DC.

## Locator preference

Within an application only:

1. source-backed unique `fieldref` / `data-fieldref` when present and stable enough to identify the model-bound control;
2. DuckCreekId / `data-duckcreekid`;
3. stable source `id`;
4. stable `name` / test id;
5. correctly associated label;
6. role + exact accessible name;
7. source-backed parent/sibling/relative relationship;
8. exact source XPath as deterministic last resort.

A visual label is not assumed to be the actual input. `fieldref` is locator evidence, not proof that a control is a dropdown. Component semantics are determined independently.

Fallback catalogs are application-isolated. CL|DC cannot use CL|EQ evidence, and vice versa.

## Component actions

- native `<select>` → `SelectOptionAsync`
- Material/MDC select → trigger click → exact option click
- Duck Creek/ExtJS input-backed combo → open component → exact rendered option click
- autocomplete → type only when needed → exact option click
- checkbox/radio/toggle → establish current state, then mutate only when required
- normal input/textarea → Fill + controlled blur
- popup/dialog → scoped action
- frame popup → FrameLocator-scoped action

Exact normalized option text is required. Broad partial option matching is not the default.

## Keyboard steering

Playwright addresses the target control directly, so Tosca focus-navigation Tab actions are suppressed in generated StepDefinitions. Enter/Tab following a semantic set/fill is suppressed at runtime because the semantic action already commits/blurs/selects the control. Tosca CLICK and DOUBLECLICK tokens passed through Press methods are dispatched as mouse actions rather than invalid keyboard keys. Genuine standalone keyboard operations remain available.

## Conditions and state flows

Conditions use readable Tosca expressions such as `State!="CA"`. State/product conditions stay in source order and are evaluated by `ScenarioData.Condition`. Feature order is cross-validated against the raw Tosca concrete instances; reusable login internals are not leaked into Feature steps.

## Waits

Condition-driven defaults:

- page readiness: 15s
- element readiness: 15s
- action timeout: 15s
- verification readiness: 15s
- fallback probe: 2.5s
- navigation: 30s

A raw frame-scoped control does not spend the full top-document wait before frame fallback is allowed.

## Evidence

Each NUnit scenario stages immutable evidence under the test assembly `TestEvidence/<test-id>` directory before `TestContext.AddTestAttachment` is called. Files are reopened to verify existence before registration. Context closure finalizes video/HAR/trace before attachment. Evidence includes HTML report, logs, screenshots, video, HAR, trace, console/network errors, locator fallback trace and evidence bundle according to configuration.

The HTML fallback trace now records frame selector information for recovered frame-scoped controls.

## Maintenance

Regenerate raw locator and frame metadata after Tosca changes:

```text
python tools/extract_raw_tosca_locator_catalog_v54.py <CL_EQ raw> <CL-DC raw> <PL_DC raw>
python tools/extract_tosca_frame_contexts_v56.py <CL_EQ raw> <CL-DC raw> <PL_DC raw>
python tools/build_locator_fallback_catalog.py
python tools/enrich_fallback_frames_v56.py
```

Do not replace a human/runtime-validated locator merely to improve a percentage. Source identity, frame ancestry, uniqueness and runtime actionability are more important than nominal coverage.
