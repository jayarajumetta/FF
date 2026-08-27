# Test-scoped evidence publication

## Runtime ownership

Each ReqnRoll scenario gets a unique artifact directory:

`Artifacts/<Feature>/<Scenario>_<timestamp>_<unique-id>/`

The unique suffix prevents parallel Scenario Outline examples from colliding.

## Finalization order

1. ReqnRoll executes the business scenario.
2. `AfterStep` captures configured screenshots and step console/network evidence.
3. Page actions capture sanitized scenario-owned HTML DOM/control observations while also updating persistent page memory.
4. `AfterScenario` closes the Playwright context. This is intentionally first so trace, HAR and video are finalized.
5. The framework writes the HTML report and complete evidence bundle.
6. `NUnitEvidencePublisher` creates `test-evidence-manifest.json` with SHA-256/size/category metadata.
7. Every scenario-owned artifact is registered with `NUnit.Framework.TestContext.AddTestAttachment`.
8. `nunit-attachment-result.json` records attachment attempts/failures and is attached last.
9. The ReqnRoll hook returns to NUnit/Test Explorer only after attachment registration finishes.

Attachment failures are recorded but do not replace the business-test outcome.

## Evidence attached to the individual test

Default `reporting.attachmentMode` is `all`, so every file under the scenario artifact directory is attached. This includes:

- execution log
- HTML scenario report
- screenshots
- HTML DOM observations
- DOM control JSON
- scenario snapshot of merged page DOM memory and locator history
- Playwright trace
- HAR network archive
- Playwright videos
- self-healing provider request/response and healing history when generated
- complete evidence bundle
- evidence SHA-256 manifest
- NUnit attachment publication result

## Visual Studio

The solution uses NUnit + NUnit3TestAdapter. `TestContext.AddTestAttachment` attaches files to the current NUnit test result. The NUnit VS adapter surfaces test execution inside Visual Studio Test Explorer and modern adapter versions carry attachments to the test platform.

NUnit TestContext documentation:
https://docs.nunit.org/articles/nunit/writing-tests/TestContext.html

NUnit VS adapter documentation:
https://docs.nunit.org/articles/vs-test-adapter/Index.html

## Azure DevOps

The supplied `.azuredevops/azure-pipelines.yml` generates native NUnit 3 XML using the adapter's `NUnit.TestOutputXml` setting. NUnit serializes attachments under each `<test-case><attachments>` element. `PublishTestResults@2` publishes those result-specific attachment paths to Azure DevOps with `publishRunAttachments: true`.

NUnit result XML format:
https://docs.nunit.org/articles/nunit/technical-notes/usage/Test-Result-XML-Format.html

NUnit adapter TestOutputXml:
https://docs.nunit.org/articles/nunit/getting-started/dotnet-core-and-dotnet-standard.html

Azure DevOps PublishTestResults@2:
https://learn.microsoft.com/azure/devops/pipelines/tasks/reference/publish-test-results-v2

The pipeline also publishes the raw `Artifacts` directory as a pipeline artifact. That is secondary forensic retention; the NUnit XML path is the mechanism that associates evidence with the individual test result.
