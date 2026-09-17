# Combined Framework Architecture Invariants

These constraints apply while PnC-TestAutomation evolves into the combined
framework. They protect existing business behavior and prevent SGS adaptations
from introducing parallel infrastructure.

1. **PnC-TestAutomation is the reference architecture.** SGS components are
   adapted behind shared contracts; repositories are not merged wholesale.
2. **`ScenarioContextData` owns scenario state.** A scenario has one instance,
   resolved through the Reqnroll service provider. Files and static state are
   not used for same-scenario handoffs. `IQuoteHandoff` is the typed boundary
   over that state. A genuine cross-process transfer must use a run/scenario-
   qualified, versioned envelope with producer and intended-consumer identity;
   missing, stale, or mismatched payloads are fatal.
3. **One lifecycle owns resources.** `TestHooks` owns browser/API setup,
   screenshots, results, and disposal. `IArtifactContext` owns the deterministic
   run/scenario output root and all evidence paths. Product modules do not add
   competing hooks, browser factories, or output-path conventions.
4. **Features remain business-readable.** Product knowledge stays in Reqnroll
   features and business-focused step/page methods rather than pipeline scripts.
5. **Selectors are contract-first.** Use `GetByTestId` for DuckCreek controls.
   ANi HTML `id` and other fallbacks require a documented exception in the
   locator audit. Locator rescue diagnoses drift; it does not turn missing
   required controls into passing tests.
   Shared resolution returns a `ResolvedControl` that carries its page/frame
   scope into the action, semantic postcondition, and evidence record. Missing
   controls and multiple visible matches are fatal.
6. **Retries have one owner per boundary.** Page actions use Playwright
   auto-waiting and shared control helpers. `IApiService` is the only HTTP
   transient-retry path, and callers must explicitly mark a request as
   idempotent. CI alone may retry explicitly classified transient test
   failures; product code must not add another retry system.
7. **Results are explicit.** Failed tests, zero discovered tests, missing final
   TRX, and missing promised business artifacts are failures. Reporting and
   publication cannot convert failed execution into success. The versioned
   scenario manifest derives its outcome from the authoritative Reqnroll/NUnit
   failure plus declared component outcomes and verifies all required evidence.
8. **Packages are immutable.** Test jobs consume one versioned package produced
   by a clean, locked .NET 8 restore/build, rather than rebuilding or
   assembling partial artifacts per shard. Its manifest inventories every file
   with size and SHA-256 and excludes secrets, result files, and runtime quote
   data. Extraction must prove source-free test discovery before execution.
9. **DataPool outcomes are explicit.** Required profiles fail when quote
   persistence is unavailable or rejected. Optional profiles emit a visible
   non-success result. The service binds to loopback by default, fails closed
   for remote exposure without HTTPS and external authentication, validates
   state transitions, and atomically replaces validated JSON without resetting
   corrupt storage.
10. **Business outcomes are profile-owned.** Gated SFP scenarios resolve one
    approved, versioned environment/state/company profile before browser work.
    Provenance, validity, and checksums are mandatory. Missing, ambiguous,
    stale, synthetic, or inapplicable expectations fail; explicit
    `NonRunnable` profiles are ignored before execution and cannot pass a gate.
    Quote identity is scenario-owned, premiums use typed currency/tolerance
    comparison, forms bind to a versioned baseline and response metadata, and
    transmit availability never substitutes for a completed transmission.
11. **A compiled inventory owns sharding.** CI enumerates NUnit/Reqnroll cases
    and case categories from the packaged assembly before execution. The
    selected gated set must equal the disjoint union of nonempty shard sets.
    Initial/retry attempts reconcile to one canonical final TRX and one result
    manifest; only non-parameterized `RetrySafe` transient failures can retry.
12. **Test Plans consumes canonical evidence only.** Stable automation IDs
    come from explicit feature tags plus stable data qualifiers, never feature
    prose or Azure DevOps numeric IDs. A versioned checksummed external catalog
    owns ADO mappings. Publication is idempotent, resumable, redacted, and
    cannot publish initial/retry attempts as separate final results.
13. **Product pilots register capabilities, not infrastructure.** One
    `IProductModule` descriptor owns each stable automation family and declares
    its data profile, selector exceptions, evidence, frame, quote, and
    publication contracts. Adapted products reuse the existing lifecycle,
    semantic controls, artifact context, quote handoff, retry policy, and
    canonical results; they do not add parallel hooks or factories.

## SGS adaptation contract

The SGS inventory is design input, not source to copy. Adapt useful concepts
such as control intent, runtime locator resolution, semantic UI actions, data
precedence, output paths, evidence manifests, finalizers, and publishers behind
the contracts owned here.

- Selected-value checks assert the actual selected value. `True` means
  checked/selected and `Enabled` means enabled; neither is a visibility alias.
- Semantic operations distinguish click, fill, select, and toggle. Each
  operation verifies the corresponding enabled, selected, checked, or value
  state instead of treating visibility as success.
- Capture supports value, checked, and selected semantics.
- A resolved frame scope must be passed through to the action that uses it and
  recorded in evidence. Product adapters cannot silently fall back to the top
  page.
- Every checkpoint screenshot has a unique ordinal/name. A cached
  `scenario.png` is not sufficient evidence.
- Forms-only and full-SFP validation use the same orchestration service. Missing
  baselines, Forms API/session failures, metadata mismatches, invalid output,
  comparison failures, and missing XML/CSV/HTML/Markdown/TRX evidence are fatal.
  Baseline generation is an explicitly separate tool, never a validation fallback.
- Missing required reports, logs, traces, videos, manifests, test results, or
  attachments fail the run rather than producing a success-shaped outcome.
- Required data never resolves to an empty string. Ambiguous flattened keys and
  stale or missing profile checksums fail before UI execution.
- State-changing UI actions are not retried unless the operation is proven
  idempotent or includes rollback.
- The versioned package inventory includes runtime configuration, scripts,
  tools, runsettings, resources, Playwright assets, test binaries, DataPool, and
  a checksum manifest.
