# v50 — Test-Result Evidence Attachments

v50 extends the source-ordered/locator-mature v49 release with **scenario-scoped evidence publication**.

## What changed

Every ReqnRoll scenario owns one artifact directory. At `AfterScenario`, the browser context is closed first so Playwright finalizes trace, HAR and video. The framework then writes the final HTML report/evidence bundle and calls `NUnitEvidencePublisher` while the NUnit test context is still active.

`NUnitEvidencePublisher` uses `NUnit.Framework.TestContext.AddTestAttachment` for every scenario-owned artifact (default `reporting.attachmentMode = all`). This includes:

- `execution.log`
- `report.html`
- failure/per-step screenshots when configured
- scenario-owned HTML DOM observations and control JSON
- scenario snapshot of merged `master-page-dom.html`, `controls.json`, and `locator-history.json`
- `trace.zip`
- `network.har.zip`
- Playwright video files
- self-healing provider/evidence/history files
- `evidence-bundle.zip`
- `test-evidence-manifest.json` with SHA-256 and size for each file
- `nunit-attachment-result.json` proving which files were attached/skipped/failed

DOM capture still updates the persistent cross-scenario page memory under `Artifacts/DOM`, but it now also copies the exact DOM observations into the scenario directory. A completed test therefore remains self-contained and immutable.

## Visual Studio Test Explorer

The projects use NUnit + NUnit3TestAdapter. Run/debug normally from **Test Explorer**. Attachments are registered against the current NUnit test result at scenario completion; adapter/Visual Studio versions that expose result attachments can display/open them from that test result.

## Azure DevOps

`.azuredevops/azure-pipelines.yml` executes each project with both a TRX logger and the NUnit adapter's native `NUnit.TestOutputXml`. Azure DevOps publishes the **NUnit 3 XML** with `PublishTestResults@2`, `testResultsFormat: NUnit`, and `publishRunAttachments: true`. `TestContext.AddTestAttachment` is serialized as `<test-case><attachments>...`, which Azure DevOps maps to the individual test result. TRX is retained for Visual Studio/vstest diagnostics; the pipeline also publishes the raw `Artifacts` tree for bulk forensic retention.

## Configuration

```json
"reporting": {
  "attachEvidenceToTestResult": true,
  "attachmentMode": "all",
  "maxSingleAttachmentBytes": 536870912,
  "maxAttachmentCount": 5000
}
```

Use `attachmentMode: key` only when an environment imposes strict attachment-count limits. `all` is the default for this release because the requirement is complete per-test evidence.

## Important ordering guarantee

Evidence attachment happens **after** `BrowserSession.CloseAsync`, so video/HAR/trace paths are finalized, but **before** the ReqnRoll scenario returns to NUnit, so `TestContext.AddTestAttachment` still targets the correct test.
