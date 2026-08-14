# Tosca Modernized Standalone Framework

A standalone **C# / .NET 8 / ReqnRoll / Microsoft Playwright** framework generated from the supplied Commercial Lines Duck Creek, Commercial Lines ExpertQuote, and Personal Lines Duck Creek Tosca-derived business features.

## What is included

- 248 business-rich `.feature` files.
- One exact ordered ScenarioPlan and one static-data JSON file per feature.
- Source-derived locator repositories ranked by stable HTML IDs, Duck Creek identifiers, test IDs, accessibility metadata, names, text, and XPath fallback.
- Scenario-scoped random/runtime data; no mutable static test state.
- Application-specific Gherkin Background; technical/source Background behavior runs through Hooks.
- Dedicated system-action handling so TBox operations do not become page locators.
- Runtime audit, screenshots, run-data snapshots, strict sequence validation, and central TDM/source overrides.

## First run

```powershell
./scripts/build.ps1
./scripts/install-playwright.ps1
$env:CL_EQ_PASSWORD = "..."
$env:CL_DC_PASSWORD = "..."
$env:PL_DC_PASSWORD = "..."
./scripts/run.ps1
```

Linux/macOS equivalents are under `scripts/*.sh`.

## Required data

Populate unresolved TDM keys in `tests/ToscaModernized.Tests/TestData/TdmOverrides.json` and source-configured values in `SourceValueOverrides.json`. Empty required values fail with the exact missing key; they are never guessed.

## Security defaults

Process execution, source file deletion, and Edge preference mutation are disabled by default. Enable only in an isolated test agent after reviewing `appsettings.json`.

## Design note

The Features remain readable business specifications. The generated plan is the technical traceability and ordering contract. A single non-ambiguous binding delegates each step to the exact plan instruction, preventing duplicated bindings and silent reordering.
