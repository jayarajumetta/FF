# Tosca → Playwright C# / ReqnRoll v51

## Final FF-bop2 source-ordered, component-aware, test-evidence + Azure DevOps release

v51 treats the user-corrected `FF-bop2` implementation as the authoritative runtime baseline and reconciles it back to the Tosca-derived 32-flow contract rather than regenerating over the corrections.

### Conversion contract

The required generation/execution order is:

`Template/TemplateInstance → scenario sequence → recursively expanded reusable blocks → XTestStep order → XTestStepValue order → ModuleAttribute order → Feature → StepDefinition → Page method → page-scoped locator`

The included `Artifacts/V51SourceOrderContract.json` validates all 32 Features against the source-derived manual expansion. The release gate also validates feature/example counts, binding coverage/order, component semantics, page/locator uniqueness, test evidence, JSON/XML syntax and Azure DevOps pipeline structure.

### Component-aware UI actions

`Select` is no longer treated as a synonym for HTML `SelectOptionAsync`.

- Native `<select>` → `SelectOptionAsync`.
- Angular Material / MDC `mat-select` → click trigger, then click the matching `role=option` / `mat-option`.
- Autocomplete → fill/editable trigger plus option selection.
- Yes/No DIV/chip/radio controls → click/checked semantics.
- Checkbox → checked state semantics.
- Date picker, table/grid, dialogs, tabs and expansion panels use explicit component behavior.
- Non-editable navigation/heading/container controls cannot silently become `FillAsync` operations.
- Page locators retain source-backed Tosca properties, page context and occurrence/index evidence rather than globally choosing the first test-id match.

### Evidence attached to the individual test

Normal post-action DOM harvesting/consolidation is disabled. Failure-time DOM remains available to self-healing.

Each scenario owns its evidence directory and finalizes evidence before NUnit completes the test:

1. final screenshot;
2. Playwright trace/HAR/video finalization;
3. console/network/page-error logs;
4. HTML execution report;
5. evidence bundle and SHA-256 manifest;
6. `NUnit.Framework.TestContext.AddTestAttachment` for the individual test result.

The optional VSTest MediaRecorder `.runsettings` records failed-test media on compatible Windows agents. Playwright per-context video remains the primary recording mechanism.

## Azure DevOps: two pipelines

### 1. `.azuredevops/build-test-artifact.yml`

CI/build-only pipeline. It restores and compiles the .NET solution, runs the v51 quality gate, creates an immutable executable test package containing the exact compiled `bin/obj` output plus source/config/catalogs, and publishes:

- `Tosca-Playwright-TestArtifact`
- `Tosca-Playwright-TestArtifact-Zip`

It intentionally executes no tests.

### 2. `.azuredevops/execute-test-artifact.yml`

Execution-only pipeline. It downloads the selected successful build artifact and never rebuilds code. It has exactly three execution stages:

1. **AllCases** — execute all compiled automated tests.
2. **SingleTestPlanCase** — execute exactly one Azure Test Plans Test Case. Because the VSTest Test Plan selector operates on Plan/Suite/Configuration, the pipeline creates a temporary static suite containing exactly the requested automated Test Case and configuration, validates a single automated test point, executes it, then deletes the temporary suite in cleanup.
3. **TestSuite** — execute the configured Azure Test Plan suite and configuration.

All stages publish VSTest results with `publishRunAttachments: true` and additionally retain the raw evidence directory as a pipeline artifact.

See `docs/AZURE-DEVOPS-PIPELINES.md` for parameter and permission details.

## Local / build commands

```powershell
.\scripts\setup.ps1
.\scripts\build.ps1
.\scripts\run.ps1
```

Release/source-order gates:

```powershell
python .\tools\v49_source_contract_gate.py --root . --source-html <Tosca_Manual_Test_Cases_32.html> --out .\Artifacts\V51SourceOrderContract.json
python .\tools\v51_release_gate.py --root .
```

## Generation-environment limitation

The package-generation environment did not have a .NET SDK, so a fresh `dotnet build/test` was not executed here. The Azure build pipeline is intentionally the compiler gate and fails before publishing the executable artifact if restore/build or the v51 validation gate fails.
