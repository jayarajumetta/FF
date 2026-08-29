# v58 — CL|DC Fieldref, Canonical Page API and Per-Test Evidence

v58 is built directly on `Tosca_CSharp_Standalone_v57_Final_RuntimeContracts`. It keeps the same 32 ReqnRoll Features and the same raw concrete scenario inventory. The release changes the CL|DC runtime/page-object contracts rather than regenerating business Features.

## 1. What changed

The CL|DC generated page layer now follows one rule:

`one physical control -> one locator property -> one reusable Page API per interaction`

The v57 CL|DC locator layer contained 987 locator properties. v58 contains 833. The 154 removed properties were duplicate/alias definitions rather than removed business coverage.

v58 also removes generated numeric/hex suffix names from CL|DC locator and Page APIs, removes duplicate Page action APIs, removes redundant `EntityType` clicks and removes generated `Press...(\"CLICK\")` steering.

Feature files are byte-identical to v57.

## 2. Duck Creek locator priority

For CL|DC the runtime priority is:

1. unique live `fieldref`
2. stable live HTML `id`
3. stable live HTML `name`
4. application-supported `data-testid` / `data-test-id` / `data-test`
5. label -> associated actual control
6. DOM-supported accessible semantics
7. source-backed relationship
8. source-backed occurrence/index

`DuckCreekId` is not generated as a CL|DC fallback unless browser evidence proves that the rendered frontend actually exposes it.

Raw Tosca `attributes_fieldref` remains the first source-backed fallback where it exists. The v58 CL|DC fallback catalog contains 51 raw fieldref candidates and zero DuckCreekId candidates.

## 3. Live technical locator promotion

Some Client Search controls expose `fieldref` in the rendered Duck Creek DOM even though the supplied raw Tosca module export does not contain that fieldref. v58 does not invent a value.

`DuckCreekRuntimeLocatorResolver` starts from the source/semantic Page locator, identifies the single visible element and reads its actual rendered identity:

- direct `fieldref` / `data-fieldref`
- nearest ancestor `fieldref`
- `id`
- `name`
- supported test id
- associated label
- `aria-label`
- actual link/button text where the DOM tag supports it

The strongest unique visible technical recipe is cached by `Page|Control`. A cached recipe is reused only while it is still unique and visible; otherwise it is discarded and rediscovered. The selected strategy and discovered DOM identity are written to `runtime-locators.jsonl` for the individual test.

This is particularly important on Client Search dropdown/textbox components: once the live DOM exposes a unique `fieldref`, subsequent interactions use that technical identity instead of repeatedly relying on the semantic seed.

## 4. Client Search cleanup

Client Search no longer has two Page properties/methods for the same `Address1` control. `Address` is the canonical control and its Fill/Press methods are reused in the relevant contexts.

The inherited v57 raw fallback for Client Search `Address` was also removed because its GUID belonged to `CM 66 01 Exclude Named Customer | Address`, not the Client Search Named Insured address. Until the actual Client Search fieldref is observed at runtime, the Page uses its own semantic `Address1` seed and promotes the rendered technical identity as described above.

No generated numeric or hex suffix remains in CL|DC Page/locator API names.

## 5. LOB conditions

A Feature already carries its fixed product/LOB in scenario data. v58 primes `Product (LOB)`, `State` and primary-rating-state aliases from the Feature data, so generated Page flow does not need repeated outer `Product (LOB)` / `Product:*` guards merely to decide which Feature is executing.

Those feature-constant guards were removed/inlined.

The remaining `CPP LOB` conditions are intentionally retained because they represent real CP/GL/IM sub-section decisions inside the CPP business flow rather than selection of the test Feature itself.

## 6. Action order and redundant steering

v58 removes redundant `EntityType` clicks and keeps the Entity Type set operation with its associated client/insured interaction rather than splitting click and entry around unrelated actions.

Generated `Press...(\"CLICK\")` calls are removed. Click is a mouse/link interaction. Enter remains only where it has a real commit/selection meaning. Dropdown option navigation does not use Tab.

## 7. Dropdown selection

The v57 fast semantic dropdown kernel remains:

`exact normalized match -> unique controlled partial match -> controlled Enter commit when the component proves Enter is meaningful`

Rendered options are collected with one `EvaluateAllAsync` browser round-trip per poll. Default option probing remains bounded to 1,200 ms with 75 ms polling instead of spending the normal action timeout on option enumeration.

## 8. Interaction highlight

CL|DC interactions can briefly pulse the resolved control before the Playwright action. The highlight is temporary and its original inline outline/box-shadow/transition values are restored before the action continues.

Configuration:

```json
"browser": {
  "highlightInteractions": true,
  "highlightDurationMs": 120
}
```

Set `highlightInteractions` to `false` for completely headless/non-visual runs or set `highlightDurationMs` to a smaller positive value if execution speed is more important than visible debugging.

## 9. ReqnRoll/NUnit evidence attachment

v58 captures the current NUnit test identity in `BeforeScenario`, while the ReqnRoll scenario is executing inside the actual generated NUnit test case.

Finalization order is:

1. capture the final screenshot while the page is open;
2. close the Playwright context/browser so trace/video are finalized;
3. finalize the HTML report and execution log;
4. enumerate the real scenario artifacts;
5. copy them to `NUnit WorkDirectory/TestResults/TestEvidence/<test-id>__<feature>__<scenario>`;
6. verify each copied file exists and is readable;
7. call `TestContext.AddTestAttachment` from that same NUnit scenario/test context.

Key evidence includes:

- `report.html`
- `execution.log`
- screenshots
- finalized video when enabled
- trace when enabled
- `runtime-locators.jsonl`
- evidence bundle/manifest when enabled
- `nunit-attachment-result.json`, including the test ID captured at scenario start and the test ID at publication

This avoids attaching evidence to a generic Feature container or a dummy/sample test result.

## 10. Console and HAR

Console/network collection and HAR execution remain disabled in v58 as requested. The implementation remains available for a later controlled re-enable.

## 11. Validation

Run:

```text
python tools/v58_release_gate.py
python tools/quality_gate.py
```

The v58 release gate validates, among other contracts:

- no duplicate CL|DC locator expressions;
- no duplicate raw ModuleAttribute GUID exposed twice on one Page;
- no duplicate Page action API for the same canonical control;
- no generated/positional numeric or hex suffix API names;
- Page method -> locator validity;
- StepDefinition -> Page method validity;
- byte-identical CL|DC Feature files;
- exact CL|DC fallback catalog/API key alignment;
- no CL|DC DuckCreekId fallback;
- runtime fieldref/id/name/test-id promotion and cache revalidation;
- Client Search Address source isolation;
- brief interaction highlight and style restoration;
- direct same-test NUnit evidence attachment after Playwright finalization;
- dropdown exact/partial/controlled-Enter behavior;
- console/HAR disabled;
- CL|DC login raw IDs and link semantics.

`Artifacts/V58ReleaseValidation.json` contains the packaged result.

## 12. Build/runtime authority

A real .NET 8 compiler and the target Duck Creek environment remain the final authorities. The packaging environment used for this v58 artifact does not contain `dotnet`, `csc` or `mcs`, so `dotnet build` and live Duck Creek execution could not be performed here. The release validation records that limitation explicitly rather than reporting a static gate as a live runtime pass.

Before promoting v58, run a clean `dotnet build`, then representative Client Search and full smoke scenarios in Visual Studio Test Explorer/Azure DevOps and confirm `runtime-locators.jsonl` shows the expected live fieldrefs and the corresponding NUnit test result contains the screenshot/log/report/video attachments.
