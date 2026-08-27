# Azure DevOps: build once, execute the immutable artifact

This repository deliberately separates compilation from UI execution.

## Pipeline 1 — `.azuredevops/build-test-artifact.yml`

Creates the executable artifact only:

1. restores .NET packages;
2. builds `ToscaCanonicalSimple.sln` in `Release`;
3. runs the v51 static/source-order/framework gate;
4. packages the exact repository plus compiled `bin/obj` output;
5. writes `build-artifact-manifest.json` with SHA-256 for each test assembly;
6. publishes `Tosca-Playwright-TestArtifact` and a downloadable ZIP.

The build pipeline **does not execute application tests**.

## Pipeline 2 — `.azuredevops/execute-test-artifact.yml`

Downloads the artifact created by Pipeline 1. It never recompiles the tests.

It has exactly three execution stages:

### Stage 1 — AllCases

Uses `VSTest@3` with `testSelector: testAssemblies` and runs all three compiled ReqnRoll/NUnit projects.

### Stage 2 — SingleTestPlanCase

Azure's Test Plan selector accepts plan + suite + configuration, not a direct test-case ID. To guarantee that only one case executes while still retaining Test Plan semantics, the stage:

1. verifies the requested Test Case exists under the configured Test Plan/suite branch and is automated;
2. creates a temporary static suite under that plan;
3. adds exactly that Test Case with exactly one configuration;
4. validates that exactly one automated test point exists;
5. runs `VSTest@3` using the temporary suite;
6. deletes the temporary suite in an `always()` cleanup task.

The build service identity therefore needs Test Plans read/write/manage-suite permission. The job uses `System.AccessToken`; do not place a PAT in the repository.

### Stage 3 — TestSuite

Uses `VSTest@3` with the supplied plan, suite and configuration IDs and runs the associated automated tests.

## Required execution-pipeline parameters

- `buildPipelineDefinitionId`: definition ID of Pipeline 1.
- `artifactBuildVersion`: `latest` or `specific`.
- `artifactBuildId`: required only when `specific` is selected.
- `testPlanId`: Azure Test Plan ID.
- `singleCaseParentSuiteId`: parent/root suite branch in which the requested Test Case already exists.
- `singleTestCaseId`: the one Azure Test Case to execute in stage 2.
- `testConfigurationId`: Test Configuration used for stages 2 and 3.
- `suiteId`: suite executed in stage 3.

The Test Case work item must be associated with the generated ReqnRoll/NUnit automated test (`AutomatedTestName`, `AutomatedTestStorage`, `AutomatedTestType`).

## Evidence and result publishing

The framework calls NUnit `TestContext.AddTestAttachment` only after the Playwright context is finalized and the real evidence has been copied into NUnit `WorkDirectory/TestResults/TestEvidence`. In v57 HAR and browser console/network collection are intentionally disabled while their implementation is retained for later re-enablement. Each scenario can therefore attach its own:

- final/failure screenshots;
- Playwright video;
- Playwright `trace.zip`;
- `execution.log`;
- HTML execution report;
- self-healing evidence;
- evidence manifest and evidence bundle.

`VSTest@3` publishes test results and has `publishRunAttachments: true`, so result attachments are retained in Azure DevOps. Every stage additionally publishes its raw evidence directory as a Pipeline Artifact for bulk forensic download.

## Video strategy

Playwright per-browser-context recording is the primary video mechanism because the recording belongs naturally to one scenario and is finalized before NUnit attachments are registered.

Two runsettings files are included:

- `.azuredevops/runsettings/vstest.runsettings` — normal/default.
- `.azuredevops/runsettings/vstest-mediarecorder.runsettings` — optional VSTest MediaRecorder fallback. It records failed tests only (`sendRecordedMediaForPassedTestCase="false"`). Use this only on a Windows agent with an interactive desktop. It is intentionally off by default to avoid duplicate videos; Playwright video remains enabled.

## Hosted vs self-hosted agents

The execution pipeline defaults `headless=true` so it works on Microsoft-hosted Windows agents. For visible UI or VSTest MediaRecorder, use an interactive self-hosted Windows agent and run the pipeline with `headless=false`.

## Secrets

Store application credentials and `TEST_LLM_API_KEY` in Azure DevOps secret variables/variable groups. Do not commit them. `System.AccessToken` is used only for the temporary Test Plan suite lifecycle.
