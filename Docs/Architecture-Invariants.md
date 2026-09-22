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
   controls and multiple visible matches are fatal. A required product frame
   scope maps to one exact runtime frame by stable name, page index, and depth;
   bare `iframe`, wildcard, missing, and ambiguous mappings are rejected and
   never fall back to the top document.
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
13. **Product modules register capabilities, not infrastructure.** One
    `IProductModule` descriptor owns each stable automation family and declares
    its data profile, selector exceptions, evidence, frame, quote, and
    publication contracts. Product adapters reuse the existing lifecycle,
    semantic controls, artifact context, quote handoff, retry policy, and
    canonical results; they do not add parallel hooks or factories.
14. **Product controls prove business state.** State,
    writing-company, and marital actions target the actual logical control,
    wait for that control to be enabled, and verify its selected value. A
    navigation button, generic page heading, or differently named marital
    option cannot substitute for the requested control or postcondition.
15. **Physical product separation is an explicit architecture decision.**
    Package 1.4.0 retains the in-assembly `IProductModule` topology only as a
    provisional boundary. See
    `Docs/Decisions/ADR-001-Provisional-Module-Topology.md`; no project split
    occurs without Architecture/David approval and discovery/package parity.

## SGS adaptation contract

The SGS inventory includes required executable business coverage, not only
design ideas or retained feature files. Adapt every delivered business binding,
workflow, page/locator dependency, and assertion behind the contracts owned here.
Reuse correct PnC behavior and useful SGS contracts for control intent, data
precedence, reporting, and evidence. Do not transplant SGS lifecycle owners,
browser factories, retry engines, or pipelines.

`sgs-execution-ledger.json` preserves source/import/adaptation provenance
separately and accounts for every active and source-disabled example. Unknown
cases or stale profile payloads fail before browser work. A provenance tag is
not an unconditional skip; per-case readiness records explicit unfinished work
and requires the shared runtime, selected-value/frame assertions, and rich
evidence before local execution can be enabled.

- Selected-value checks assert the actual selected value. `True` means
  checked/selected and `Enabled` means enabled; neither is a visibility alias.
- Semantic operations distinguish click, fill, select, and toggle. Each
  operation verifies the corresponding enabled, selected, checked, or value
  state instead of treating visibility as success.
- Modal action buttons such as Insurance Score Accept/Decline are not toggles.
  Their completion requires an application response and disappearance of the
  resolved decision control; `Visible(false)` never substitutes for selection.
- Native button keyboard activation is a single trusted Enter key, with the
  same enabled-state, scope, and evidence contracts as click. Insurance Score
  consent uses it because focus-related reflow can change the pointer target
  between mouse-down and mouse-up. It is not a click retry or DOM event injection.
- Capture supports value, checked, and selected semantics.
- A resolved frame scope must be passed through to the action that uses it and
  recorded in redacted runtime-locator evidence. Nested depth and the logical
  scope ID remain attached through postcondition verification. Product
  adapters cannot silently fall back to the top page.
- Every checkpoint screenshot has a unique ordinal/name. A cached
  `scenario.png` is not sufficient evidence.
- Forms-only and full-SFP validation use the same orchestration service. Missing
  baselines, Forms API/session failures, metadata mismatches, invalid output,
  comparison failures, and missing XML/CSV/HTML/Markdown/TRX evidence are fatal.
  Baseline generation is an explicitly separate tool, never a validation fallback.
- Missing required reports, logs, traces, videos, manifests, test results, or
  attachments fail the run rather than producing a success-shaped outcome.
  SGS report HTML/JSON, logs, and optional HAR/bundles use the same
  `IArtifactContext` as existing evidence. A file artifact cannot be satisfied
  by an in-memory marker. Skipped execution remains skipped in the manifest;
  skipping does not conceal a previously declared missing required artifact.
  Report projection runs inside artifact completion against one frozen manifest,
  including reserved report paths and timestamps. A failed or incomplete writer
  removes its partial projections, persists a failed manifest, and fails
  execution. Later component success cannot erase an earlier failure.
- Required data never resolves to an empty string. Ambiguous flattened keys and
  stale or missing profile checksums fail before UI execution.
- State-changing UI actions are not retried unless the operation is proven
  idempotent or includes rollback.
- The versioned package inventory includes runtime configuration, scripts,
  tools, runsettings, resources, Playwright assets, test binaries, DataPool, and
  a checksum manifest.
