# FF BOP Tosca-to-Playwright v58

v58 is an evidence-driven conversion and execution layer for Duck Creek PLDC, CLDC and CL_EQ Tosca exports. It is built on the supplied v57 package, but replaces the generic flattening path with a native GUID-linked entity graph and a single deduplicated locator registry.

## Release status

**Full-export structural gate: REVIEW REQUIRED**

| Export | Entities | Test cases | Ordered actions | Controls | Unique locators | FieldRef locators | Audit errors | Audit warnings |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| CL-DC | 189861 | 1950 | 0 | 12823 | 3185 | 0 | 0 | 0 |
| PL-DC | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| CL-EQ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

Critical gate findings:
- CL-DC: no actions reconstructed
- PL-DC: mapping metrics missing
- CL-EQ: no entities reconstructed

The detailed evidence is in `reports/full-export-validation.json`, `reports/raw-export-probe.json`, and each export's `validation-exports/<LOB>/reports/v58-mapping-audit.json`.

## What changed from v57

- Native ZIP, GZip, nested Base64/GZip, JSON and XML transport decoding.
- Optional source-only Python normalizer for opaque GUID-indexed containers; the higher-quality native/normalized graph is selected by measured testcase/action/control coverage.
- `DerivedFrom` inheritance resolution before locator scoring.
- TestCase → folder/reusable/control-flow → TestStep/TestStepValue traversal with deterministic source order.
- One locator registry; plans and page methods refer to locators by ID instead of embedding duplicates.
- PLDC/CLDC FieldRef-first locator contracts, followed by stable ID, test ID, label+attribute, label, role/name, control name, CSS, text and XPath.
- Anchor elements that look like buttons expose both `link` and `button` role candidates, with the source tag controlling priority.
- Strongest-candidate-across-all-frames resolution; false/hidden/analytics frames are penalized and ambiguous matches are never changed to `.first()`.
- Native select, ARIA combobox, Angular Material and Duck Creek custom-dropdown handling without injected Tab presses.
- Source-position `data.set`; repeated identical LOB/state conditions remain independent branches.
- Condition AST for Tosca buffers, nested boolean logic, comparison, `contains`, `startsWith`, `endsWith`, regex, `in`, and empty predicates. No expression `eval`.
- Navigation-aware clicks and `goto` use URL/load-state contracts without fixed sleeps.
- Final direct-DOM fallback searches every usable frame and open shadow root, then performs native input/change/click/select behavior.

## Build and verify

```bash
npm install
npm run v58:verify
```

## Convert one export

```bash
npm run v58:convert -- \
  --input /absolute/path/CL-DC.zip \
  --output generated-v58/CL-DC
```

The output contains:

- `features/<lob>/*.feature` — executable feature/scenario-outline projection plus a source-ordered action map;
- `plans/<lob>/*.plan.json` and `.gz` — machine execution plans referencing locator IDs;
- `test-data/<lob>/*.examples.json` — example rows;
- `step-definitions/tosca-v58.steps.ts` — generic Cucumber execution bridge;
- `pages/*.page.ts` — page methods;
- `page-locators/*.locators.ts` and `locator-registry.json` — unique locator contracts and aliases;
- `mapping-index.json` — every mapped testcase and generated artifact;
- `reports/v58-mapping-audit.json` — evidence and reliability findings.

## Execute a hydrated plan

```ts
import {
  DataContext,
  PlanExecutor,
  ResilientInteractionEngine,
  hydratePlan,
} from 'ff-bop-complete-e2e-v58/v58';

const engine = new ResilientInteractionEngine(page);
const executor = new PlanExecutor(engine, new DataContext(testData));
const plan = hydratePlan(serializedPlan, Object.values(locatorRegistry));
const result = await executor.execute(plan, exampleRow);

if (!result.passed) throw new Error(result.error);
```

## Apply over another v57 checkout

```bash
node scripts/apply-v58-to-v57.mjs /absolute/path/to/unpacked-v57
cd /absolute/path/to/unpacked-v57
npm install
npm run v58:verify
```

The installer backs up `package.json`, copies only the v58 layer, preserves existing business tests, and writes `V58-MIGRATION-REPORT.json`.

## Reliability boundary

The three supplied Tosca exports were decoded, mapped and audited locally. A live Duck Creek URL, credentials and environment-specific DOM were not supplied, so the package does not claim a live-browser pass. v58 deliberately fails on unresolved UI evidence instead of generating a broad selector that could act on the wrong control.
