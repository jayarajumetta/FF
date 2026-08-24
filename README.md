# Tosca → Playwright C# / ReqnRoll Migration Factory v52

**Current release: v52 — source-ordered, component-aware, deterministic Tosca locator fallback, per-test evidence, split Azure DevOps pipelines.**

Start with **`README_V52.md`** for setup, stack, architecture, execution, locator-fallback behavior and contribution rules.

Key architecture:

`Feature → Scenario Outline/Examples → StepDefinition → Page method → primary Page locator → UiActions → deterministic Tosca fallback (failure only) → LLM/Copilot healing (last resort)`

The selected automation scope remains **32 Tosca-derived business Features / 1,074 source-applicable examples** across Commercial Lines ExpertQuote, Commercial Lines Duck Creek and Personal Lines Duck Creek.

Important references:

- `README_V52.md`
- `docs/LOCATOR-FALLBACK-ARCHITECTURE.md`
- `docs/AZURE-DEVOPS-PIPELINES.md`
- `docs/TEST-EVIDENCE-ATTACHMENTS.md`
- `Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json`
- `Artifacts/V52FinalValidation.json`

Historical release notes remain in `README_V45.md` through `README_V51.md`.
