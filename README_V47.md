# v47 KISS Evidence + AI Locator Healing

Business architecture is unchanged from v46.1:

`Feature -> Scenario Outline/Examples -> StepDefinition -> thin Page method -> PageLocator -> UiActions -> Playwright`

v47 hardens only execution evidence and locator recovery.

## Evidence per scenario

- `execution.log`
- `report.html`
- `screenshots/` (failure by default; optional every step)
- `trace.zip`
- `video/`
- `network.har.zip` (full Playwright HAR)
- `evidence-bundle.zip` (all scenario artifacts packaged together)

Each HTML report row includes the business step, status, duration, resolved data, browser console/page errors, HTTP/request failures, test error and screenshot link.

## AI locator healing

Self-heal is enabled by default in `config/framework.json`.

Set the configured key environment variable, for example:

```powershell
$env:TEST_LLM_API_KEY="..."
```

On a locator/actionability failure the framework:

1. Checks a persistent validated locator cache.
2. Tries deterministic source-friendly alternatives (`name`, `id`, `data-testid`, DuckCreek IDs, labels/placeholders).
3. Captures sanitized HTML DOM + visible interactive control metadata + full-page screenshot.
4. Sends Feature, Scenario, previous business steps, current step, page/control/action, failed locator/error, cached page locators and prior healing outcomes to the configured LLM.
5. Accepts only a structured locator proposal.
6. Validates exactly one live visible/actionable element.
7. Retries only the failed original action, then proceeds normally.
8. Persists the accepted locator in `Artifacts/SelfHealing/locator-cache.json` and audit events in `healing-audit.jsonl`.

The LLM cannot change scenario flow, test data, assertion or action.

## Locator preservation

The page-first locator inventory remains the source-traced v46.1 inventory. `Artifacts/V47FinalValidation.json` cross-checks every entry in each application `PageLocatorEvidence.json` against the generated page locator classes. Current result: 1,836 evidence-backed locator entries, 0 missing page locator files and 0 missing locator properties.
