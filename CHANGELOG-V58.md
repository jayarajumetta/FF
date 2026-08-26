# v58 Changelog

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
