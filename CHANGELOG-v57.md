# v57 change log

## Runtime and locators

- Added PLDC/CLDC FieldRef-first candidate generation.
- Added exact attribute ID selectors so IDs containing `.`, `:`, `[`, and similar characters remain valid.
- Added raw Tosca `Occurrence` support with one-based-to-zero-based conversion.
- Removed implicit `.first()` behavior for ambiguous locators.
- Added unique-visible resolution before moving to the next candidate.
- Added automatic link/button role alternatives for Tosca Link/Button controls.
- Added deterministic frame hints, main-frame traversal, and recursive nested-frame traversal.
- Added action retry across locator candidates and frames after an interaction failure.
- Added final frame-local DOM action fallback with CSS, XPath, role, label, text, shadow-root traversal, native setters, and input/change events.
- Added structured diagnostics and `ResilientActionError`.

## Dropdowns

- Split native select, Angular Material/custom select, and input-backed combobox logic.
- Added exact role-option selection before keyboard fallback.
- Removed fixed sleeps and automatic Tab after dropdown selection.
- Added native-select DOM fallback and custom trigger/option DOM fallback.
- Removed an empty Select step only when immediately superseded by a real selection on the same locator and condition.

## Conversion and conditions

- Added a tokenizer/parser for equality, inequality, numeric comparisons, AND/OR/NOT, parentheses, contains, starts-with, ends-with, regex matching, `in`, and empty/not-empty checks.
- Added case-insensitive data-key lookup and nested dot/bracket path lookup.
- Preserved every repeated LOB/state/data conditional action in raw order.
- Prohibited grouping equal conditions into `else if` chains.
- Added dependency-aware data footer planning.
- Added conservative generated-Tab and generated-duplicate-click removal.
- Added executable locator registry deduplication with alias audit.

## Tosca input

- Added outer GZip TSU decoding.
- Added JSON parsing and GUID-indexed entity collection.
- Added nested Base64/GZip (`H4sI`) payload expansion.
- Added tolerant XML/JSON evidence extraction for FieldRef, ID, tag, control type, occurrence, custom XPath, action mode, value, condition, and order.
- Added duplicate GUID warnings.
- Added raw-evidence-to-scenario mapping and a direct TSU-to-Playwright CLI while preserving order and repeated conditions.

## v56 integration

- Added a structural compatibility adapter for legacy selector strings and locator objects.
- Added `safeClick`, `safeFill`, `safePress`, and `chooseDropdownOption` bridge functions.
- Added CLDC login and PLDC FieldRef helper factories.
- Added a non-destructive installer with package backup and migration scan report.
