# Current final release — v54

Use **`README_V54.md`** as the authoritative guide.

v54 regenerates and cross-validates the selected automation estate from the **raw Tosca exports for each application**. Manual conversion CSV/XLSX/HTML files are deliberately excluded as ordering/generation sources.

Release gates currently validate:

- 32 selected Features;
- 1,074 raw TemplateInstance-derived examples, all matched back to Tosca concrete TestCases;
- clean CL|DC authentication semantics without leaked reusable-login internals;
- corrected raw EQ account/address ordering;
- default page/element/verification waits;
- deterministic Tosca fallback before AI healing;
- >95% canonical fallback maturity for every application;
- deferred non-fatal Tosca verifications with final scenario failure after evidence publication;
- NUnit WorkDirectory-based Visual Studio attachments;
- screenshot, HTML, execution log, console/network logs, trace, HAR and video evidence;
- build-only and execute-only ADO pipelines, with three execution stages.

The generation environment does not contain the .NET SDK, so compilation is deliberately enforced by Visual Studio or the included Azure DevOps build pipeline before an executable artifact is published.
