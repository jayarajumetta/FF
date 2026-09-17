# Combined Framework Architecture Invariants

These constraints apply while PnC-TestAutomation evolves into the combined
framework. They protect existing business behavior and prevent SGS adaptations
from introducing parallel infrastructure.

1. **PnC-TestAutomation is the reference architecture.** SGS components are
   adapted behind shared contracts; repositories are not merged wholesale.
2. **`ScenarioContextData` owns scenario state.** A scenario has one instance,
   resolved through the Reqnroll service provider. Files and static state are
   not used for same-scenario handoffs.
3. **One lifecycle owns resources.** `TestHooks` owns browser/API setup,
   screenshots, results, and disposal. Product modules do not add competing
   hooks or browser factories.
4. **Features remain business-readable.** Product knowledge stays in Reqnroll
   features and business-focused step/page methods rather than pipeline scripts.
5. **Selectors are contract-first.** Use `GetByTestId` for DuckCreek controls.
   ANi HTML `id` and other fallbacks require a documented exception in the
   locator audit. Locator rescue diagnoses drift; it does not turn missing
   required controls into passing tests.
6. **Retries have one owner per boundary.** Page actions use Playwright
   auto-waiting and shared control helpers. `IApiService` is the only HTTP
   transient-retry path, and callers must explicitly mark a request as
   idempotent. CI alone may retry explicitly classified transient test
   failures; product code must not add another retry system.
7. **Results are explicit.** Failed tests, zero discovered tests, missing final
   TRX, and missing promised business artifacts are failures. Reporting and
   publication cannot convert failed execution into success.
8. **Packages are immutable.** Test jobs consume one versioned package produced
   by a clean .NET 8 build, rather than rebuilding or assembling partial
   artifacts per shard.

## SGS adaptation contract

The SGS inventory is design input, not source to copy. Adapt useful concepts
such as control intent, runtime locator resolution, semantic UI actions, data
precedence, output paths, evidence manifests, finalizers, and publishers behind
the contracts owned here.

- Selected-value checks assert the actual selected value. `True` means
  checked/selected and `Enabled` means enabled; neither is a visibility alias.
- Capture supports value, checked, and selected semantics.
- A resolved frame scope must be passed through to the action that uses it and
  recorded in evidence. Product adapters cannot silently fall back to the top
  page.
- Every checkpoint screenshot has a unique ordinal/name. A cached
  `scenario.png` is not sufficient evidence.
- Missing required reports, logs, traces, videos, manifests, test results, or
  attachments fail the run rather than producing a success-shaped outcome.
- Required data never resolves to an empty string. Ambiguous flattened keys and
  stale or missing profile checksums fail before UI execution.
- State-changing UI actions are not retried unless the operation is proven
  idempotent or includes rollback.
- The versioned package inventory includes runtime configuration, scripts,
  tools, runsettings, resources, Playwright assets, test binaries, DataPool, and
  a checksum manifest.
