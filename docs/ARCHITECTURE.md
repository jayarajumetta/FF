# Architecture

## Repository boundary

One solution contains a reusable Core library and three isolated ReqnRoll/NUnit test assemblies. The isolation prevents identical business wording in CL|DC, CL|EQ and PL|DC from creating cross-application binding ambiguity while retaining one framework, one quality gate and one reporting model.

## Execution path

1. A business-readable Feature selects a single attached flow and one representative Examples row.
2. Shared bindings configure the application and load JSON data.
3. The RANDOM-data binding generates all declared source patterns into scenario/run context.
4. Feature-scoped StepDefinitions appear in the exact Feature order and call one typed PageMethod each.
5. The PageMethod executes the corresponding compiled CanonicalAction segment in strictly increasing source order.
6. LocatorResolver selects source-derived candidates by application, module similarity, confidence and live uniqueness.
7. Hooks own clean browser contexts, authentication preparation, screenshots, traces, video, DOM evidence, cleanup, HTML reporting and optional email.

## No generic plan interpreter

Canonical mappings are generated as C# source. There is no catch-all `Given/When/Then (.*)` binding and no runtime JSON instruction switch. JSON is used only for test data, locator catalogs, settings, suites and evidence.

## Parallel safety

Runtime values are scoped to each scenario. A concurrent run store is keyed by scenario ID, so names, quote numbers, policy numbers, buffers and random values cannot overwrite another parallel scenario.
