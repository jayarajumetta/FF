# v58 Architecture

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
