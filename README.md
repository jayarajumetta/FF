# Tosca → Playwright C# / ReqnRoll Migration Factory v54

**Current release: v54 — RAW TOSCA source-of-truth, clean business Features, component-aware Playwright actions, deterministic fallback locators, mature waits, deferred verification, per-test evidence, and split Azure DevOps pipelines.**

Start with **`README_V54.md`**.

The only generation/order authority for v54 is the raw Tosca `.tsu` object graph:

`Template/TemplateInstance → concrete TestCase → recursive reusable blocks → XTestStep order → XTestStepValue order → ModuleAttribute/XParam`

Manual CSV/XLSX/HTML artifacts are **not** generation inputs.

Scope: **32 Features / 1,074 raw concrete examples** across Commercial Lines ExpertQuote, Commercial Lines Duck Creek and Personal Lines Duck Creek.

Key references:

- `README_V54.md`
- `docs/RAW-TOSCA-SOURCE-ARCHITECTURE.md`
- `docs/LOCATOR-FALLBACK-ARCHITECTURE.md`
- `docs/TEST-EVIDENCE-ATTACHMENTS.md`
- `docs/AZURE-DEVOPS-PIPELINES.md`
- `Artifacts/V54RawToscaContract.json`
- `Artifacts/V54FinalValidation.json`
- `Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json`

Historical release notes remain available as `README_V45.md` through `README_V52.md`.


> **Current consolidated release documentation:** `README_V56.md`
