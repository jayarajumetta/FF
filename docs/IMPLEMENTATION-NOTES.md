# CLDC, ExpertQuote and PLDC implementation notes

## Baseline protection

This revision is built on the uploaded `FF-main(2).zip` structure. The seven CLDC Smoke feature files, seven CLDC Smoke step-definition files and four NUnit evidence implementation files are protected by SHA-256 and remain unchanged. The checksum contract is in `Artifacts/Validation/uploaded-protected-baseline.sha256.json` and is enforced by `tools/package_gate.py`.

The temporarily commented CLDC Smoke Examples rows are intentionally retained. They are counted as available variants by the gate but are not activated automatically.

## Implemented source changes

- Retained the existing CLDC Basic, Expanded and other non-Smoke feature matrices and made all original scenario data available through base-plus-state override files.
- Expanded ExpertQuote BOP Smoke to 45 active state examples and SFP Smoke to the 35 states evidenced by supplied SFP Basic Tosca records.
- Removed Duck Creek selector assumptions from the ExpertQuote locator repository and corrected malformed quoted Angular selectors in ExpertQuote and relevant PLDC locator files.
- Added transparent JSON Merge Patch reconstruction in `ScenarioData`; every reconstructed record is checked against the original source JSON.
- Added per-scenario machine-readable `scenario-result.json` output without changing the NUnit attachment implementation.
- Added Robot Framework-inspired consolidated `report.html`, `log.html`, `output.xml` and `summary.json` generation, plus SMTP delivery through protected environment variables.
- Added Azure DevOps build and execution pipelines under `.azuredevops` and root aliases.

## Validation boundary

`tools/package_gate.py` performs deterministic source checks and report-generator self-tests. It does not claim live browser execution. The authoritative .NET compilation, ReqnRoll discovery, NUnit execution and application validation must run on a Windows workstation or Azure DevOps agent with .NET 8, network access to CLDC/CLEQ/PLDC and valid credentials.
