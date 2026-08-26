# Source and raw-evidence audit

## Materials available

The implementation used the technical context exposed by the three shared ChatGPT conversations supplied with the request. The first shared conversation exposed the v56 artifact name and raw-source filenames, plus concrete failure examples and prior generated snippets. The second exposed broader Tosca parser and framework architecture. The third did not expose additional converter implementation content through the public share renderer.

Known filenames recovered from the shared history include:

- `FF-bop-complete-e2e-v56.zip`
- `FF-bop2.tsu`
- `Original_Raw_TestCases.xml`
- `Raw.txt`
- `bop_test_locators.ts`
- `bop_test_locators_FINAL.ts`
- `cl-dc-logins.xlsx`
- `cl-dc-logins_irs.xlsx`
- `Tosca Playwright Conversion Consolidated Special Cases.xlsx`

## Binary-attachment boundary

No file was present in the current conversation file store, Library, `/mnt/data`, or the mounted share directories. The public share renderer returned conversation text and artifact names but did not return a usable attachment ID or download URL for the v56 ZIP or latest TSU. Therefore:

- no claim is made that the packaged source is a byte-level patch of that ZIP;
- no claim is made that every locator was executed against the actual PLDC/CLDC applications;
- v57 is supplied as a complete tested overlay and generator/runtime replacement;
- `scripts/apply-v57-to-v56.mjs` is included to install it over the real unpacked v56 tree without unsafe bulk rewrites;
- `scripts/audit-tsu.mjs` is included to generate a deterministic evidence report when the raw TSU is locally available.

## Raw evidence carried into v57

The shared history contained these concrete raw/generated mismatches:

| Control / behavior | Raw or contextual evidence | v56 issue | v57 treatment |
|---|---|---|---|
| `txtCribCircumference` | TextBox, exact ID `txtCribCircumference`, `INPUT`, occurrence `2` | generated form-control selector or incorrect high `.nth()` | exact ID candidate with raw occurrence `2`; FieldRef first when present |
| `cmbState` | ComboBox, ID `cmbState`, `MAT-SELECT`, occurrence `2`, custom scoped XPath, option elements `MAT-OPTION` | treated like an input/native select; fixed delay; automatic Tab | Material trigger + exact option path; keyboard fallback; no automatic Tab |
| CLDC login | Tosca control represented as Link; request requires exact ID | role-only mismatch between link and rendered button | FieldRef then exact ID, followed by link and button role alternatives |
| Repeated LOB conditions | same LOB condition controls different ordered actions | equal conditions flattened or merged | one independent ordered `if` per action |
| Repeated state conditions | same state condition controls different ordered actions | equal conditions flattened or merged | same independent-branch rule |
| Data conditions | values resolved from Tosca test data/buffers | raw expression injected or simplified | parsed AST and explicit data resolution |
| Duplicate locators | same executable locator emitted more than once | duplicate constants and drift | locator registry deduplication with alias manifest |
| `data.set` placement | request requires footer placement | writes scattered through output | safe writes captured then emitted at footer; reads prevent unsafe movement |
| iframe recovery | locator can be inside unknown nested iframe | main frame or single expected frame only | expected hint, full deterministic frame loop, then per-frame DOM fallback |

## Standards boundary

Normal Playwright locators and actions remain the primary path. The DOM path is intentionally last because direct DOM actions bypass Playwright actionability checks. Fallback use is included in the returned trace and diagnostics so it cannot remain invisible.
