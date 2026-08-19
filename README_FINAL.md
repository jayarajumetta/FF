# Tosca C# Standalone v46.1 — KISS / Source-Traced

## Scope
Only the selected 32 Tosca business flows are executable. Their TemplateInstance/TestCaseDesign applicability expands to 1,074 source-derived state/carrier Example rows.

## Runtime path
`Feature -> Scenario Outline/Examples -> StepDefinition -> thin Page method -> page locator -> UiActions -> Playwright`

Business Features do not contain Tosca buffers, TBox waits, browser cleanup, or loading-indicator implementation steps.

## Configuration first
Edit `config/framework.json` before execution. It controls browser, timeouts, trace/video/screenshots, reporting, strict condition handling, and LLM self-heal.

Self-heal is enabled by default. Set the API key named by `selfHeal.apiKeyEnvironmentVariable` (default `TEST_LLM_API_KEY`). The configured endpoint must be OpenAI-compatible with `chat/completions` multimodal message content.

On locator/actionability failure only, the healer sends: current Feature/Scenario/Step, previous business steps, page/control intent, failed locator/error, sanitized DOM, visible interactive candidates, and optional screenshot. It accepts only a structured locator proposal, validates uniqueness/visibility/actionability on the live page, then retries the original action.

## Credentials
Source credentials are not shipped. Set the application credentials before execution:

```powershell
$env:CL_DC_USERNAME="..."
$env:CL_DC_PASSWORD="..."
$env:CL_EQ_USERNAME="..."
$env:CL_EQ_PASSWORD="..."
$env:PL_DC_USERNAME="..."
$env:PL_DC_PASSWORD="..."
$env:TEST_LLM_API_KEY="..."   # only needed when LLM healing is invoked
```

External/TDM values that were not present in the Tosca export remain `SYNTHETIC_REPLACE_ME` in each project's `TestData/ExternalDataOverrides.json`; replace them with approved environment data before executing affected scenarios.

## Setup
The solution targets .NET 8 and pins SDK 8.0.423 in `global.json`.

```powershell
.\scripts\setup.ps1
```

This restores/builds the solution and installs Playwright Chromium fallback after build. The default configured browser is installed Microsoft Edge (`msedge`), with Chromium as fallback.

## Run
```powershell
.\scripts\run.ps1 -Project CLEQ
.\scripts\run.ps1 -Project CLDC
.\scripts\run.ps1 -Project PLDC
```

## Evidence
Each scenario writes execution logging, HTML report, screenshots on failure, Playwright trace, and video under the configured `reporting.artifactRoot`.

## Validation
See:
- `Artifacts/V46FinalValidation.json`
- `Artifacts/V46SourceTraceability.json`
- `Artifacts/V46FinalRandomDataTrace.json`
- `Artifacts/StateApplicabilityMatrix.json`

The generation environment did not expose the .NET SDK, so an actual `dotnet build` could not be executed here. `scripts/setup.ps1` / `scripts/build.ps1` are the compiler gates on the target VDI/CI agent.
