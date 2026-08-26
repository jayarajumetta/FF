# v57 architecture

## Evidence before code

`LocatorSpec` retains semantic key, application family, FieldRef, exact ID, accessibility evidence, native attributes, raw occurrence, scope, frame hint, and raw source evidence. The generator does not collapse this into one selector. Candidate generation happens at runtime so a stronger contract can recover from a changed DOM without discarding raw Tosca facts.

## Resolution pipeline

1. Build and deduplicate scored candidates.
2. Enumerate hinted frame, main frame, and every nested frame.
3. Create a Playwright locator in that frame/scope.
4. Require one match, one visible match, or a valid raw occurrence.
5. Perform the normal Playwright action and actionability checks.
6. On interaction failure, continue with the next candidate/frame rather than pinning the test to a locator that merely existed.
7. Repeat after a short non-fixed retry interval to cover frame attachment/re-render.
8. Run the audited DOM fallback inside each frame only after normal attempts are exhausted.

## Why frame-local DOM evaluation

A top-page `document.querySelector` cannot legally inspect a cross-origin iframe. Playwright can evaluate inside that iframe's own `Frame` context. v57 therefore loops Playwright Frame objects and executes the fallback separately in each context.

## Why occurrence is constrained

Playwright strict mode protects against clicking the wrong element. v57 uses `.nth()` only when the raw Tosca evidence contains a positive occurrence. If there is no such evidence, an ambiguous candidate is rejected and the runtime tries a different strategy.

## Conditions

Conditions are tokenized and parsed into a serializable AST. Evaluation receives a Map or object data source. Equal condition ASTs are not grouped because their associated actions, order, and side effects can differ.

## Data footer

A `dataSet` write can be moved only when no later action reads that key. Its condition and right-hand value are captured at the original position, then the `data.set` call is emitted at the footer. This satisfies output cleanliness without changing the value snapshot.
