# Tosca Canonical → Simple C# Playwright / ReqnRoll Standalone Tests — v44

This package intentionally keeps the runtime architecture small:

`Feature / Scenario Outline / Examples -> StepDefinition -> PageMethod -> PageLocator -> Playwright`

## What is different from v43

- Browser startup is a visible **Background** step: `Given I open a browser session`.
- Browser lifecycle is one `BrowserSession` class. No `_auth` or hidden browser service dependency is required for the normal application login path.
- Default browser is installed Microsoft Edge (`BROWSER_CHANNEL=msedge`), headed mode.
- If Edge is unavailable, Playwright Chromium is attempted; missing Chromium can auto-install once (`AUTO_INSTALL_PLAYWRIGHT_BROWSER=true`).
- Self-healing is **enabled by default** (`COPILOT_SELF_HEAL=true`). It first tries deterministic Playwright fallbacks, then GitHub Copilot CLI if installed and authenticated.
- Static/external dataset file references are explicit in every Scenario Outline Example and are loaded in a Feature step.
- Random data is generated in the **StepDefinition** and stored in scenario runtime data before the PageMethod is called.
- PageMethods preserve canonical source field/action order and use page-specific Playwright locators.
- Trace, video, console/page errors, execution log, failure screenshots and an HTML scenario report are generated under `Artifacts/`.

## .NET SDK

`global.json` is pinned to **8.0.423** with `rollForward: latestPatch`. As of 17-Aug-2026, 8.0.423 is the currently published .NET 8 SDK. If 8.0.424 is installed later, the roll-forward policy can use that later patch.

## First setup

```powershell
.\setup.cmd
```

The package uses installed Microsoft Edge by default. `setup.cmd` also provisions Playwright Chromium as a fallback so the suite is not left without a browser. To run that provisioning directly:

```powershell
.\scripts\setup.ps1 -InstallChromium
```

## Run

```powershell
# One application
.\scripts\run.ps1 -Project CLEQ
.\scripts\run.ps1 -Project CLDC
.\scripts\run.ps1 -Project PLDC

# Everything
.\scripts\run.ps1 -Project ALL
```

Useful environment variables:

```powershell
$env:BROWSER_CHANNEL='msedge'       # default
$env:HEADLESS='false'               # default
$env:COPILOT_SELF_HEAL='true'       # default
$env:TRACE_ENABLED='true'           # default
$env:VIDEO_ENABLED='true'           # default
$env:SCREENSHOT_EACH_STEP='false'   # failure screenshot always captured
```

## Evidence

Each scenario creates:

- `execution.log`
- `report.html`
- `trace.zip`
- Playwright video
- failure screenshots

## Self-heal

Self-heal runs only after a locator/actionability failure. It never changes business data, expected values, or test flow. The Copilot fallback uses the `copilot -p ... -s` programmatic CLI mode; if the CLI is not available, deterministic fallbacks are still attempted and the original failure is preserved if no valid unique locator is found.
