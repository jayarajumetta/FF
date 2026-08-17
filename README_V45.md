# Standalone C# v45 — Simple Step-Orchestrated Playwright

Execution shape:

`Feature -> StepDefinition field orchestration -> thin Page field method -> UiActions -> direct Playwright locator`

## Key rules
- Background contains the single browser-session open step.
- Static/external data is loaded from the Feature Examples and resolved in StepDefinitions.
- Random data is generated in StepDefinitions only.
- Page classes do not own scenario data. They expose small field-level methods only.
- `UiActions` is the only generic browser-action layer.
- Locator healing is enabled by default. A failed locator first gets deterministic alternatives, then GitHub Copilot SDK receives sanitized HTML DOM + a full-page screenshot + Feature/Scenario/Step/Page/Control intent. The returned locator is validated before the original action is retried.
- Healing cannot change data, action, assertion, or business flow.

## Copilot authentication
Run GitHub Copilot login once on the execution machine, or provide a supported token via Copilot SDK authentication. The SDK uses the logged-in user by default.

## First execution
1. `setup.cmd`
2. Set application credentials in `TestData/ExternalDataOverrides.json` or environment variables.
3. Run one smoke test using `scripts/run.ps1`.

Self-heal defaults ON. Set `COPILOT_SELF_HEAL=false` only when you explicitly want to disable it.
