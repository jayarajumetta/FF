from pathlib import Path
import json,hashlib,datetime,os
root=Path('/mnt/data/FF-bop-complete-e2e-v58')

def sha(p):
 h=hashlib.sha256()
 with open(p,'rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()
def human(n):
 for u in ['B','KiB','MiB','GiB']:
  if n<1024:return f'{n:.1f} {u}'
  n/=1024
 return f'{n:.1f} TiB'
try:validation=json.loads((root/'reports/full-export-validation.json').read_text())
except:validation={'passed':False,'exports':[],'criticalIssues':['validation report unavailable']}
rows=[]
for e in validation.get('exports',[]):
 m=e.get('metrics',{});a=e.get('audit',{}).get('metrics',{})
 rows.append(f"| {e.get('name')} | {m.get('entities',0)} | {m.get('testCases',0)} | {m.get('actions',0)} | {m.get('controls',0)} | {m.get('locators',0)} | {m.get('fieldRefLocators',0)} | {a.get('errors',0)} | {a.get('warnings',0)} |")
table='\n'.join(rows) or '| No export result | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |'
inputs=[]
for label,p in [('v57 baseline',Path('/mnt/data/FF-bop-complete-e2e-v57.zip')),('CL-DC export',Path('/mnt/data/CL-DC.zip')),('PL-DC export',Path('/mnt/data/PL_DC.zip')),('CL_EQ export',Path('/mnt/data/CL_EQ.zip'))]:
 if p.exists():inputs.append((label,p.name,p.stat().st_size,sha(p)))
input_table='\n'.join(f'| {a} | `{b}` | {human(c)} | `{d}` |' for a,b,c,d in inputs)
status='PASS' if validation.get('passed') else 'REVIEW REQUIRED'
critical='\n'.join(f'- {x}' for x in validation.get('criticalIssues',[])) or '- None.'
readme=f'''# FF BOP Tosca-to-Playwright v58

v58 is an evidence-driven conversion and execution layer for Duck Creek PLDC, CLDC and CL_EQ Tosca exports. It is built on the supplied v57 package, but replaces the generic flattening path with a native GUID-linked entity graph and a single deduplicated locator registry.

## Release status

**Full-export structural gate: {status}**

| Export | Entities | Test cases | Ordered actions | Controls | Unique locators | FieldRef locators | Audit errors | Audit warnings |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
{table}

Critical gate findings:
{critical}

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
npm run v58:convert -- \\
  --input /absolute/path/CL-DC.zip \\
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
import {{
  DataContext,
  PlanExecutor,
  ResilientInteractionEngine,
  hydratePlan,
}} from 'ff-bop-complete-e2e-v58/v58';

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
'''
(root/'README-V58.md').write_text(readme)
arch='''# v58 Architecture

## 1. Transport and source evidence

`decode.ts` recursively detects ZIP, GZip, JSON, XML and nested Base64 transport layers. ZIP entries are read from the central directory; GZip payloads are recursively decoded. Every decoded document keeps its SHA-256, byte length, depth and source name.

`tools/normalize_tosca_export.py` is an optional transport fallback for exports whose entities are encoded as GUID-keyed dictionaries or non-standard property collections. It does not invent actions. It emits a normalized entity graph with source order, explicit references and inheritance. The CLI scores the native and normalized maps and chooses the one with stronger testcase/action/control coverage.

## 2. Native entity graph

`graph.ts` creates one entity per strong Tosca identity, indexes GUIDs, infers hierarchy from `Parent*` properties and child GUID collections, and resolves `DerivedFrom` chains before any locator or action decision. Duplicate GUID evidence is merged and reported.

Only descendants of an identified TestCase are eligible to become executable plan actions. Module and control metadata can supply locator evidence but cannot become an interaction.

## 3. Source-order plan mapping

`mapper.ts` walks children in explicit Position/Order/Sequence when supplied, otherwise in original discovery order. Reusable blocks are expanded with cycle protection. It preserves repeated IF expressions as separate nodes. No branch is converted to `else if` because its text matches another branch.

`optimizer.ts` is conservative: raw Tosca Tab/click actions are retained. Only converter-generated Tab immediately following a dropdown and provably duplicated generated clicks may be removed. The optimizer does not sort and does not move `data.set`.

## 4. Locator registry

Locator evidence is inherited before scoring. Candidate order is:

1. FieldRef;
2. stable exact ID (including dotted IDs via `[id="..."]`);
3. test ID;
4. exact label plus FieldRef/ID;
5. exact associated label;
6. role plus accessible name, with link/button aliases when DOM semantics differ from appearance;
7. form-control name;
8. source CSS;
9. exact text fallback;
10. source XPath.

Occurrence becomes `nth(occurrence - 1)` only when raw Tosca evidence explicitly supplies an occurrence. Ambiguous candidates without occurrence evidence are rejected.

A canonical fingerprint deduplicates executable locator contracts. Plans serialize `locatorId`; generated pages resolve that ID from a single module registry.

## 5. Frame-safe resolution

`frame-runtime.ts` gathers the main frame and nested child frames using a bounded deterministic traversal. Explicit Tosca frame hints receive priority. Hidden, blank and analytics/service frames receive penalties but are not blindly excluded if they contain the unique target.

Resolution is candidate-major, not frame-major: FieldRef is checked across the entire frame tree before ID, label, role, text or XPath. This prevents a weak match in the main page from hiding a strong FieldRef inside the Duck Creek application frame.

## 6. Interaction and dropdown strategy

Normal Playwright interactions are always attempted first. Native `<select>` uses `selectOption`; input-backed and ARIA comboboxes use editable fill/click plus exact options; Angular Material and Duck Creek overlays are searched in the control frame first, then other usable frames. Keyboard ArrowDown/Enter is last. No automatic Tab is appended.

A failed candidate does not terminate the action: the runtime continues with the next reliable candidate/frame pair. The final fallback executes inside each frame with `frame.evaluate`, traverses open shadow roots, matches FieldRef/ID/label/role/text/CSS/XPath, uses native value setters, and dispatches input/change events.

## 7. Conditions, data and navigation

`condition.ts` parses into an AST and resolves Tosca buffer/data references case-insensitively. `PlanExecutor` maintains an independent branch stack and writes buffers at their original plan position.

Navigation actions use `goto(..., waitUntil: "domcontentloaded")`. Clicks marked as navigation-sensitive register a URL-change wait before interaction and only wait for DOM readiness when the URL actually changes. There are no fixed `waitForTimeout` calls.

## 8. Generated artifacts and audit

Every testcase receives a mapping-index entry, feature projection, compressed/uncompressed machine plan and test-data file. Modules receive a deduplicated locator file and page class. The audit measures FieldRef, labels, role aliases, frame hints, repeated conditions, data-set ordering, unresolved evidence and locator coverage.
'''
(root/'ARCHITECTURE-V58.md').write_text(arch)
source=f'''# v58 Source Audit

Generated: {datetime.datetime.now(datetime.timezone.utc).isoformat()}

## Local source inputs

| Purpose | File | Size | SHA-256 |
|---|---|---:|---|
{input_table}

The v57 archive was used as the filesystem baseline. v58 source, tests, reports and scripts were added non-destructively.

## Shared-thread context

The three supplied ChatGPT share URLs were requested during the build. Their public responses did not reliably expose the complete transcript or downloadable attachments in this execution environment. Consequently, no unseen message or attachment was treated as verified evidence. Requirements were taken from the current conversation, the supplied v57 package, and the three attached export archives.

## Export validation

Structural gate: **{status}**

| Export | Entities | Test cases | Ordered actions | Controls | Unique locators | FieldRef locators | Audit errors | Audit warnings |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
{table}

Critical findings:
{critical}

Validation includes archive integrity, nested payload decoding, GUID graph creation, inheritance, testcase/action ordering, locator deduplication, condition/data ordering, generated artifact coverage, TypeScript build, Node syntax checks, automated unit/integration tests and npm package dry-run.

## Boundaries

- No live Duck Creek environment, URL, credentials or authenticated browser session was supplied.
- Structural FieldRef/ID/label/role evidence was cross-checked against Tosca exports; live DOM uniqueness and business completion still require execution in the target environment.
- The direct-DOM fallback is intentionally last. It is logged and never replaces Playwright's normal actionability path by default.
- Unresolved UI evidence is reported and configured to fail explicitly; the converter does not fabricate a broad selector.
'''
(root/'SOURCE-AUDIT.md').write_text(source)
changelog='''# v58 Changelog

## Native Tosca graph
- Added recursive ZIP/GZip/Base64/JSON/XML decoding.
- Added GUID-keyed normalization fallback and quality-based mapper selection.
- Added parent/child reference inference, reusable-block traversal and `DerivedFrom` property inheritance.
- Prevented module metadata from becoming executable steps.

## Locator reliability
- Added FieldRef-first PLDC/CLDC strategy, exact dotted IDs, label+attribute disambiguation, link/button semantic aliases and occurrence-only nth handling.
- Added one canonical locator registry shared by plans, generated page locators and methods.
- Removed silent `.first()` behavior.

## Runtime
- Added strongest-candidate-across-frame-tree resolution, false-frame penalties, nested-frame recovery and shadow-root DOM fallback.
- Added native select, ARIA/Angular/Duck Creek combo handling and no automatic Tab.
- Added page-level explicit keyboard support for raw Tosca Tab/Enter actions.
- Added navigation-aware click waiting without fixed sleeps.

## Logic and ordering
- Added condition AST and case-insensitive data context.
- Preserved repeated same-expression IF branches and source-position buffer writes.
- Restricted redundancy removal to converter-generated actions with provable equivalence.

## Generation and audit
- Added executable feature/scenario-outline projection, examples, plans, test data, Cucumber bridge, page methods, locator classes, mapping index and evidence audit.
- Added full CL-DC, PL-DC and CL_EQ structural validation.
'''
(root/'CHANGELOG-V58.md').write_text(changelog)
migration='''# v57 to v58 Migration

1. Back up or commit the v57 checkout.
2. Run `node scripts/apply-v58-to-v57.mjs <v57-root>`.
3. Run `npm install` using the existing lock policy.
4. Run `npm run v58:verify`.
5. Convert one export into a new output directory and review `reports/v58-mapping-audit.json` before replacing business tests.
6. Execute against the Duck Creek QA environment with tracing enabled. Resolve any `UNRESOLVED_LOCATOR_EVIDENCE` finding by adding raw module evidence or a reviewed locator override; do not replace it with a broad text selector.

The overlay does not rewrite existing v57 business features, page objects or test data. `package.json.v57-backup` and `V58-MIGRATION-REPORT.json` support rollback and audit.
'''
(root/'MIGRATION-V57-TO-V58.md').write_text(migration)
