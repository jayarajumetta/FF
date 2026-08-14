# Tosca Canonical Artifact Automation Framework v38

This repository is a standalone **C# / Playwright / ReqnRoll / NUnit** modernization package generated only for the **32 attached eligible business flows**.

It uses the explicit artifact architecture retained from the v29-v35 line:

```text
Feature / Scenario Outline / Examples
    -> feature-scoped StepDefinition in Feature order
        -> typed Flow PageMethod
            -> source-ordered CanonicalAction artifact
                -> typed PageLocator key + application locator catalog
                    -> Playwright
```

No catch-all ReqnRoll binding and no natural-language JSON plan interpreter is used.

## Scope

| Application | Attached flows |
|---|---:|
| Commercial Lines Duck Creek | 18 |
| Commercial Lines ExpertQuote | 5 |
| Personal Lines Duck Creek | 9 |
| **Total** | **32** |

The package contains **11,650 source-ordered business/data actions**. Another **1,217 technical, session, resource, cleanup, and recovery actions** are separated from PageLocators and represented by Hooks/SystemAction evidence.

## Data handling

- Scenario Outline `Examples` hold business dimensions and dataset selection.
- Fixed values are stored in scenario JSON files.
- Random patterns are stored in scenario JSON and generated once into scenario-scoped runtime aliases before the first consuming PageMethod.
- Buffers and captured values are isolated per scenario and also recorded in run evidence.
- Unavailable TDM/reusable parameters are declared in `ExternalDataOverrides.json` with `SYNTHETIC_REPLACE_ME`; execution fails until approved values replace them.
- Credentials are supplied only through environment variables.

## Evidence and reporting

Hooks capture manual-equivalent step logs, screenshots, DOM on failure, Playwright trace, video, runtime-data snapshots, and a self-contained HTML report. Optional SMTP summary email is configuration-driven and disabled by default.

## Run

```bash
./scripts/setup.sh
./scripts/quality-gate.sh
./scripts/run.sh all
```

PowerShell equivalents and Azure Pipelines/GitHub Actions definitions are included.

## Validation boundary

Generation performs JSON/XML parsing, Feature/StepDefinition/PageMethod order reconciliation, canonical action contracts, duplicate signature/type audits, locator/system separation, C# lexical/delimiter checks, and ZIP CRC/SHA-256 validation. The generation container does not expose the .NET SDK, so Roslyn compilation and test discovery must run through the supplied CI gate before application execution.
