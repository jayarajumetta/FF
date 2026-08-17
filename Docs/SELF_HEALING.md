# GitHub Copilot locator self-healing

Enable with `COPILOT_SELF_HEAL=true`. Authentication uses the GitHub Copilot SDK/CLI logged-in user or supported GitHub token environment variables.

Execution order: primary page locator -> cached validated heal -> deterministic sanitized-DOM match -> Copilot SDK proposal -> uniqueness/visibility validation -> original action -> audit/cache.

Copilot never executes browser actions. It returns only a locator descriptor. `ExistsAsync` remains a non-healing branch probe so AI cannot flip application business conditions.

Useful settings:
- `COPILOT_HEAL_MODEL=auto`
- `COPILOT_HEAL_PRIMARY_TIMEOUT_MS=5000`
- `COPILOT_HEAL_MAX_CALLS=5`
- `COPILOT_HEAL_MIN_CONFIDENCE=0.72`
- `COPILOT_HEAL_CACHE=Artifacts/SelfHealing/locator-heals.json`

Audit evidence is written to `Artifacts/SelfHealing/healing-audit.jsonl`. Accepted heals are cached for later actions/runs but source files are not modified during execution.
