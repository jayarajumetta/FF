# Tosca → Playwright C# / ReqnRoll v52

## Release purpose

v52 builds on the FF-bop2/v51 source-ordered, component-aware framework and adds a mature **deterministic Tosca locator fallback layer** for all three applications. The business layer remains KISS: Feature → StepDefinition → Page method → one primary Page locator. Alternative Tosca evidence is kept outside Page classes in per-application fallback catalogs.

The release retains all v51 capabilities: 32 approved Features / 1,074 source-derived examples, corrected FF-bop2 BOP locators/order, Angular Material/native/component-aware actions, random/test-data lineage, NUnit test-result evidence, Playwright screenshot/video/trace/HAR, console/network capture, self-healing, and split Azure DevOps build/execution pipelines.

## Technology stack

- .NET 8 / C#
- Microsoft.Playwright for .NET
- ReqnRoll BDD
- NUnit 4 + NUnit3TestAdapter
- JSON scenario data and source-trace catalogs
- optional GitHub Copilot or OpenAI-compatible locator healing
- Azure DevOps Pipelines / VSTest
- Python catalog/audit generators used at migration time, not required by normal test execution

## Locator architecture

```text
Primary Page locator
    ↓ failure only
Tosca deterministic fallback catalog
    ↓ candidate loop
unique + visible + action-compatible live validation
    ↓
execute only the failed action
    ├── success → log/report/cache → continue test
    └── exhausted → LLM/Copilot healing → final failure evidence
```

The fallback engine is intentionally inside `UiActions`. An `AfterStep` hook is too late to recover the low-level action cleanly; hooks remain responsible for final failure evidence.

See `docs/LOCATOR-FALLBACK-ARCHITECTURE.md` for the complete model.

## Locator maturity

The v52 enriched Tosca property catalog contains **32,603** source property records. The raw CL-EQ Total export contributed **2,812** unique records not present in the earlier cross-application catalog.

Current canonical-control fallback coverage:

- Commercial Lines ExpertQuote: **96.81%** (395 / 408)
- Commercial Lines Duck Creek: **99.75%** (796 / 798)
- Personal Lines Duck Creek: **99.23%** (387 / 390)
- Overall: **98.87%** (1,578 / 1,596)
- Overall controls with at least two alternatives: **98.06%**

Strategies currently compiled from source evidence include CSS/source-attribute combinations, role, DuckCreekId, text, HTML id, `data-testid`, name, label and exact Tosca XPath. Source `ConstraintIndex` is respected only when literal; v52 never invents `.First`/`.Nth` to hide ambiguity.

## Setup

### Requirements

1. .NET 8 SDK. `global.json` pins the supported SDK used by the repository.
2. Microsoft Edge or Playwright Chromium.
3. Access to the three target test applications as appropriate.
4. Environment credentials/secrets.
5. Python 3 only when regenerating Tosca catalogs/validation artifacts.

### Credentials

```powershell
$env:CL_DC_USERNAME="..."
$env:CL_DC_PASSWORD="..."
$env:CL_EQ_USERNAME="..."
$env:CL_EQ_PASSWORD="..."
$env:PL_DC_USERNAME="..."
$env:PL_DC_PASSWORD="..."
```

LLM locator healing is optional and invoked only after deterministic fallbacks fail. Configure the provider and its credential in `config/framework.json` or use one of the provider example files.

```powershell
$env:TEST_LLM_API_KEY="..."
```

### Local setup

```powershell
.\scripts\setup.ps1
```

or

```bash
./scripts/setup.sh
```

## Configuration

`config/framework.json` is the primary runtime configuration.

The v52 locator block is:

```json
"locatorFallback": {
  "enabled": true,
  "catalogDirectory": "Artifacts/LocatorFallbackCatalogs",
  "maxCandidatesPerFailure": 40,
  "minimumCandidateConfidence": 0.6,
  "allowSourceXPath": true,
  "preferPreviouslySuccessfulCandidate": true,
  "logEveryAttempt": true
}
```

`selfHeal.locatorCatalogFile` points to the enriched `Artifacts/ToscaLocatorPropertyCatalog.v52.json`.

Post-action/scenario DOM consolidation remains **disabled** (`captureDomAfterActions=false`) as requested. Failure-time DOM can still be collected by the final healing/evidence path.

## Execution

```powershell
.\scripts\run.ps1 -Project CLEQ
.\scripts\run.ps1 -Project CLDC
.\scripts\run.ps1 -Project PLDC
```

Run the normal solution/compiler gate before execution:

```powershell
dotnet restore
dotnet build ToscaPlaywright.sln -c Release
```

## Test-result evidence

Each scenario owns its own artifact directory. On completion the framework finalizes and attaches scenario evidence to the NUnit test result, including configured screenshots, Playwright video, trace, HAR, execution log, console/page errors, network calls/failures, HTML report, healing/fallback evidence and evidence bundle/manifest.

A locator recovery appears in both the log and `report.html`. The HTML trace identifies exactly which fallback succeeded and its Tosca provenance.

## Azure DevOps

Two independent pipelines remain in `.azuredevops/`:

1. `build-test-artifact.yml` — restore/build/quality gate/package/publish immutable compiled test artifact. It does not execute tests.
2. `execute-test-artifact.yml` — consumes that artifact without rebuilding and provides three stages:
   - all cases;
   - exactly one automated case from an Azure Test Plan through a temporary one-case static suite;
   - a configured Test Plan suite.

Per-test evidence is published through the VSTest/NUnit result path, while the complete raw `Artifacts/` tree can also be retained as a pipeline artifact.

See `docs/AZURE-DEVOPS-PIPELINES.md` and `docs/TEST-EVIDENCE-ATTACHMENTS.md`.

## Regenerating Tosca locator evidence

The Page classes are not regenerated just to add backup locators. Regeneration is a sidecar operation:

```powershell
python tools/extract_tosca_locator_catalog.py "<raw-tosca-export.tsu>"
python tools/build_locator_fallback_catalog.py
python tools/v52_fallback_gate.py
```

Generated catalogs:

- `Artifacts/ToscaLocatorPropertyCatalog.v52.json`
- `Artifacts/LocatorFallbackCatalogs/CommercialLines.ExpertQuote.json`
- `Artifacts/LocatorFallbackCatalogs/CommercialLines.DuckCreek.json`
- `Artifacts/LocatorFallbackCatalogs/PersonalLines.DuckCreek.json`
- `Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json`

## Contribution rules

1. Preserve exact Tosca/template/reusable-block business order. Do not reorder a Page method to make the UI test appear cleaner.
2. A Page Object has one readable primary locator property per semantic control. Do not duplicate Pages to represent locator alternatives.
3. Human/runtime-validated primary locator corrections take precedence over generated fallback ordering.
4. Put alternative source evidence in the fallback catalog, not in StepDefinitions.
5. Never use arbitrary `.First`/`.Nth` as a fix for locator collision. Index only when source occurrence/index evidence supports it.
6. Do not call `SelectOptionAsync` for Angular Material/MDC or other non-native selects.
7. Do not translate a navigation/verification DIV/heading into `FillAsync` merely because Tosca uses a generic Input/Set semantic.
8. Keep random/static/runtime/captured data lineage in scenario data; do not hide generated data inside Page methods.
9. Keep fallback recovery at the page-action boundary so only the failed action is retried.
10. Any new fallback strategy must remain source-derived and must pass live uniqueness/actionability checks.
11. Run `tools/v52_fallback_gate.py` plus source-order and compiler/runtime gates before merging.
12. Never commit real credentials or customer production data.

## Validation

Primary v52 artifacts:

- `Artifacts/V52ToscaLocatorCatalogMerge.json`
- `Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json`
- `Artifacts/V52FinalValidation.json`
- `Artifacts/V52ReleaseManifest.json`

This generation environment does not expose a .NET compiler. The repository therefore performs exhaustive static/source-contract validation here; `dotnet build/test` and the Azure build pipeline remain the authoritative compiler/runtime gates.
