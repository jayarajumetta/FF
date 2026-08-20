# v48 — KISS Source-Ordered + Locator Maturity

This build starts from the compilation-corrected `FF-bop_desc` overlay and retains the 32 selected source-traced Features / 1,074 applicable state-carrier Examples.

## Runtime path
Feature → ordered StepDefinition → thin Page field method → page locator → UiActions → Playwright.

## Locator rules
- Exact Tosca `Id`, `Name`, `DuckCreekId`, `data-testid`, tag, relative/index evidence are retained in `Artifacts/ToscaLocatorPropertyCatalog.json`.
- A duplicate test id is not silently converted to `.First`; strict mode is allowed to fail and healing must disambiguate with page/section context and evidence-supported first/last/nth.
- Exact duplicate locator definitions inside a page are semantic aliases to one property, avoiding duplicate locator definitions.
- ExpertQuote technical fields such as `customer.name.first` use their exact exported HTML id.
- Native `<select>` uses `SelectOptionAsync`; Angular Material/ARIA dropdowns click the trigger and then click the matching `mat-option` / role=option.

## Self healing
`config/framework.json` supports `openai-compatible` or `github-copilot`.
- OpenAI-compatible: set the configured API-key environment variable.
- GitHub Copilot: set `provider` to `github-copilot` and authenticate Copilot CLI once on the execution machine.

Healing receives Feature, Scenario, previous steps, current step, page/control/action, failure, current DOM candidates, sanitized DOM, screenshot, prior locator cache, and prior healing outcomes. It may return a locator only. Accepted locators are validated live and cached before retrying only the failed action.

## Evidence
Trace, video, HAR, screenshots, step console/network errors, HTML report, evidence bundle, and per-action DOM/control observations are captured. `DOM/<Page>/master-page-dom.html` and `controls.json` provide the latest consolidated page observation; timestamped observations remain alongside it.
