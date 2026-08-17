# v43 — Page-first + GitHub Copilot locator healing

This release layers controlled GitHub Copilot self-healing on v42. Page locators remain ordinary Playwright locators. `PageUiActions` intercepts only locator failures, builds a sanitized intent/DOM context, asks Copilot for one locator descriptor, validates it, then retries the original action.

Default is OFF. Enable with `COPILOT_SELF_HEAL=true`. See `Docs/SELF_HEALING.md`.
