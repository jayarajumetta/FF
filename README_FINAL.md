# Current final release — v52

Use **`README_V52.md`** as the authoritative guide.

v52 preserves the FF-bop2 corrected primary locators and the exact 32-flow Tosca business-order contract, then adds per-application deterministic Tosca backup locator catalogs with >95% canonical-control coverage for every application. On a primary locator/actionability failure, `UiActions` loops ranked source-derived alternatives, validates uniqueness/visibility/action compatibility, retries only the same failed action, records every attempt in the execution log and HTML report, and continues only after the operation itself succeeds. LLM/Copilot healing remains a final fallback after deterministic source evidence is exhausted.

The release also retains component-aware native/Material/dropdown/chip/radio/checkbox/date/grid/dialog/tab handling, source-backed test/random data, NUnit per-test screenshot/video/trace/HAR/log evidence, and the split Azure DevOps build-artifact and three-stage execution pipelines.
