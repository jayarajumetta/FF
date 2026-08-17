# v43 Copilot Locator Healing — C#

The v42 page-first ReqnRoll/Playwright repository is preserved. Locator execution is hardened with a controlled GitHub Copilot SDK fallback.

Enable: `COPILOT_SELF_HEAL=true`

Order: primary Playwright locator -> validated cache -> deterministic sanitized-DOM match -> GitHub Copilot locator proposal -> uniqueness/actionability validation -> retry original action.

Copilot is never allowed to change the business action, expected result, scenario data, branch decision, or browser command. It returns only a locator descriptor. See `Docs/SELF_HEALING.md`.
