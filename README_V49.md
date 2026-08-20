# Tosca → Playwright C# / ReqnRoll — v49 Final Source-Ordered Locator-Mature

This release is the successor to the v48 locator-mature branch and preserves the user-provided `FF-bop_desc.zip` compilation-corrected baseline as the authoritative source overlay.

## Final source contract

The executable business chain is intentionally strict:

`Tosca Template/TemplateInstance → expanded reusable blocks → XTestStep → XTestStepValue → ModuleAttribute → Feature → StepDefinition → Page method → page-scoped locator`.

`Artifacts/V49SourceOrderContract.json` independently compares the source-derived 32-flow manual expansion with the generated Feature files and resolves Feature steps to scoped ReqnRoll bindings. Current result: **PASS — 32/32 exact Feature sequences, zero missing or ambiguous business bindings, declaration order preserved, CL|DC completeness PASS.**

## Corrections beyond v48

- Corrected remaining over-escaped punctuation in ReqnRoll verbatim regex bindings (`\\-`, `\\(`, `\\[`, etc.). These strings can compile while failing to match Gherkin at runtime.
- Added `ToscaLocatorEvidenceStore`: self-heal now reads actual Tosca ModuleAttribute locator properties and honors source `ConstraintIndex` only when present.
- Added explicit `ILocatorHealingProvider` abstraction with OpenAI-compatible HTTP and GitHub Copilot CLI implementations.
- Expanded component semantics before generic fallback: native select, Angular Material/MDC select, autocomplete, radio/chip groups, checkbox, date picker, table/grid, dialog, tabs and expansion panels.
- Removed arbitrary `.First` behavior for duplicate component options: exactly one visible option is required or a strict collision is raised for page/source disambiguation.
- Reworked DOM evidence into cross-scenario page memory under `Artifacts/DOM/<Page>/`: timestamped observations, merged `controls.json`, synthetic merged `master-page-dom.html`, and `locator-history.json` from accepted cache/audit history.
- Fixed `LocatorResolution` so provider proposals using `placeholder` and `title` are executable strategies; anchors and source-backed `First/Last/Nth` remain supported.

## Healing order

1. normal generated locator;
2. previously validated persistent cache;
3. deterministic source Tosca alternatives;
4. failure evidence (Feature, Scenario, previous steps, current step, page/control intent, failed locator, Tosca properties, current DOM, screenshot, page cache/history);
5. configured provider (`openai-compatible` or `github-copilot`);
6. structured locator proposal;
7. live uniqueness/visibility/actionability validation;
8. retry **only the failed action**.

## Validation artifacts

- `Artifacts/V49SourceOrderContract.json` — 32-flow order/binding/CL|DC completeness gate.
- `Artifacts/V49LocatorMaturityAudit.json` — source property/test-id collision audit.
- `Artifacts/V49FinalValidation.json` — final static contract gate.
- `Artifacts/CompilationBaselineOverlay.json` — file-level relationship to `FF-bop_desc.zip`.
- `Artifacts/FILE_INTEGRITY_MANIFEST.json` — per-file size, CRC32 and SHA-256.

The generation environment does **not** expose a .NET SDK, so a fresh `dotnet restore/build/test` cannot be truthfully claimed here. The repository includes setup/run/quality scripts; compilation remains the client VDI/CI compiler gate. All available static/reference/source-order/JSON/XML/archive-integrity gates are run before packaging.
