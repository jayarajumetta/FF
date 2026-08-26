# FF BOP Tosca-to-Playwright v57

v57 is a TypeScript runtime, generator hardening layer, and v56 migration overlay for Tosca-to-Playwright projects. It addresses the failure modes discussed for v56 without hard-coding one page or one line of business.

## What v57 changes

- **FieldRef-first locator evidence for PLDC and CLDC.** When a raw Tosca FieldRef exists, v57 tries exact FieldRef attributes before other strategies. It then falls back through test ID, exact HTML ID, role, label, name/form control name, CSS, text, and XPath.
- **Exact IDs, including IDs containing dots.** v57 emits `[id="cl.dc.login.submit"]`, not an invalid or misleading `#cl.dc.login.submit` selector.
- **Strict uniqueness.** A locator that matches multiple elements is not silently reduced to `.first()`. A raw, one-based Tosca `Occurrence` can select `nth(occurrence - 1)`; otherwise v57 looks for one visible element or continues to a stronger unique candidate.
- **Nested iframe recovery.** The expected frame hint is tried first, followed by deterministic main-frame and depth-first nested-frame traversal. Frame objects are used directly, including for cross-origin frames.
- **Audited DOM fallback.** Only after normal Playwright locator/actionability attempts fail, v57 evaluates selectors inside each frame. The fallback supports CSS, XPath, FieldRef, ID, role, label, text, open shadow roots, native value setters, and browser events.
- **Dropdown specialization.** Native `<select>`, Angular Material `mat-select`, role-based listboxes/options, and input-backed comboboxes have separate paths. There is no automatic `Tab` after a selection.
- **CLDC login role mismatch.** A Tosca `Link` can resolve as either ARIA `link` or `button`, while exact ID and FieldRef remain higher-confidence contracts.
- **Repeated conditions stay repeated.** Equal LOB, state, or data expressions are emitted as independent ordered `if` blocks. v57 never turns them into one branch or `else if` merely because the text is the same.
- **Safe condition AST.** Tosca expressions are parsed into data, comparison, predicate, and logical nodes rather than injected as JavaScript strings.
- **Conservative cleanup.** Generated Tab actions, empty dropdown priming immediately superseded by a real value, and provably duplicated generated clicks are removed. Raw repeated clicks remain unless duplicate evidence is explicit.
- **Locator registry deduplication.** Equal executable locator definitions share one constant while retaining all semantic aliases in the audit manifest.
- **`data.set` footer.** Writes that are not read by a later action are captured at their original point and emitted at the bottom. Dependency-sensitive writes remain in place to preserve behavior.

## Package layout

```text
src/
  compat/                 v56 bridge and CLDC/PLDC helpers
  contracts/              structural Playwright interfaces
  converter/              condition parser, normalizer, footer planner, generator
  locator/                evidence model, candidate builder, strict locator registry
  runtime/                frame search, resolver, actions, DOM fallback, diagnostics
  tosca/                  GZip/JSON/embedded-XML TSU reader and raw evidence extractor
scripts/
  apply-v57-to-v56.mjs    installs this package into an unpacked v56 project
  audit-tsu.mjs           extracts raw locator/action evidence
  convert-tsu-to-playwright.mjs builds a scenario and spec directly from raw evidence
  generate-v57.mjs        generates a Playwright spec from normalized scenario JSON
  verify-package.mjs      static and generated-output quality gate
tests/                    Node unit/integration-style tests with Playwright fakes
examples/                 raw evidence fixture, normalized input, generated output
reports/                  verification and generation audit output
```

## Verify v57

```bash
npm install
npm run verify
```

The repository itself has no browser download requirement for its unit tests. `@playwright/test` is a peer dependency for the consuming project.

## Apply v57 on top of v56

Unpack the v56 ZIP, then run:

```bash
node scripts/apply-v57-to-v56.mjs /absolute/path/to/unpacked-v56
cd /absolute/path/to/unpacked-v56
npm install
npm run v57:verify-runtime
```

The installer:

1. preserves `package.json` as `package.json.v56-backup`;
2. vendors v57 under `vendor/ff-bop-complete-e2e-v57`;
3. adds a local package dependency and verification scripts;
4. creates `src/v57-bridge.ts`;
5. writes `V57-MIGRATION-REPORT.json` with v56 fixed waits, automatic Tabs, `.nth()` usage, direct document access, and legacy dropdown helper occurrences;
6. does **not** blindly rewrite business tests.

The last point is intentional. Repeated raw clicks and conditional steps can be meaningful; automatic regex replacement would recreate the v56 ordering defects.

## Use the runtime in generated or hand-migrated tests

```ts
import { ResilientActions, type LocatorSpec } from 'ff-bop-complete-e2e-v57';

const state: LocatorSpec = {
  key: 'siteState',
  app: 'PLDC',
  controlType: 'ComboBox',
  fieldRef: 'PLDC.Site.State',
  id: 'cmbState',
  role: { role: 'combobox', name: 'State', exact: true },
  occurrence: 2,
  xpath: "//site-location//mat-select[@id='cmbState']",
};

const ui = new ResilientActions(page);
await ui.select(state, data.get('STATE'));
```

CLDC login with exact ID, FieldRef, and role alternatives:

```ts
import { cldcLoginLocator, ResilientActions } from 'ff-bop-complete-e2e-v57';

const login = cldcLoginLocator({
  fieldRef: 'CLDC.Login.Submit',
  id: 'cl.dc.login.submit',
  accessibleName: 'Login',
});

await new ResilientActions(page).click(login);
```

## Audit a raw TSU

The reader supports the TSU structure described in the shared history: an outer GZip payload containing JSON, plus nested Base64/GZip (`H4sI…`) JSON or XML payloads.

```bash
npm run build
node scripts/audit-tsu.mjs /path/to/FF-bop2.tsu reports/FF-bop2.v57-evidence.json
```

The output includes GUID-indexed entities, embedded payload paths, raw locator evidence, raw action evidence, and duplicate-GUID warnings.


For a direct evidence-to-spec pass:

```bash
npm run build
node scripts/convert-tsu-to-playwright.mjs \
  /path/to/FF-bop2.tsu \
  generated/ff-bop-v57.spec.ts \
  PLDC \
  "FF BOP converted flow"
```

The converter maps raw ActionModes to click/fill/select/press/check/wait/verify/data actions, matches controls by raw name/FieldRef/ID, preserves action order and repeated conditions, and emits a full audit sidecar. Unmatched controls are retained as reviewable text fallbacks instead of being silently dropped.

## Generate a hardened spec

```bash
npm run build
node scripts/generate-v57.mjs \
  examples/normalized-scenario.json \
  generated/pldc-cldc-v57.spec.ts \
  ff-bop-complete-e2e-v57
```

The `.audit.json` beside the generated spec records every retained, removed, immediate, or deferred action and the deduplicated locator manifest.

## Locator decision order

For PLDC/CLDC, the default score order is:

1. FieldRef attributes (`data-fieldref`, `data-field-ref`, `fieldref`, and configured variants)
2. test ID
3. exact HTML ID
4. accessible role/name, including link/button alternatives
5. label or `aria-label`
6. placeholder, name, Angular `formcontrolname`, and title
7. scoped CSS
8. exact visible text/aliases
9. raw/custom XPath

Every candidate is tried with Playwright first. The DOM fallback uses the same evidence and remains strict about ambiguity.

## Failure behavior

A failed action throws `ResilientActionError` with recent frame, candidate, match-count, selected-index, and error details. The returned `ActionTrace` records whether the final DOM fallback was used. This makes fallback usage visible rather than silently masking fragile locators.

## Verification included

The package gate currently verifies:

- strict TypeScript compilation;
- FieldRef priority and dotted-ID correctness;
- role link/button alternatives;
- raw occurrence handling;
- unique fallback after ambiguous locators;
- nested iframe discovery and interaction retry;
- final per-frame DOM fallback;
- native, Material, and input-backed dropdown behavior without Tab;
- complex LOB/state/data conditions;
- independent repeated conditional actions;
- conservative click/Tab/dropdown cleanup;
- locator deduplication;
- safe `data.set` footer placement;
- outer GZip and nested `H4sI` TSU extraction.

## Source boundary

The current chat did not expose a mountable v56 ZIP or TSU attachment. The public shared conversation exposed technical context and filenames but not the attachment bytes. Consequently, this ZIP is a complete, tested v57 overlay/reconstructed implementation rather than a byte-for-byte edit of the inaccessible v56 archive. See `SOURCE-AUDIT.md` for the exact boundary and the evidence used.
