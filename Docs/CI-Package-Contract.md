# CI Package and Result Contract

Phase 5 makes one immutable archive the boundary between build agents and
private execution agents. Test jobs do not check out source or rebuild.

## Entry points

| Path | Contract |
|------|----------|
| `Pipelines/sfp-smoke-adhoc.yml` | Canonical CI/PR/manual entry point plus the existing Development schedules. |
| `Pipelines/sfp-smoke-vm.yml` | Compatibility entry point retaining the existing main-branch schedules. |
| `Pipelines/forms-check-scheduled.yml` | Compatibility entry point for the one discovered SFP forms-only case. |
| `Pipelines/setup-datapool-service.yml` | One-time compatibility entry point that installs DataPool from the validated package. |
| `Scripts/CI/New-TestPackage.ps1` | Locked restore, Release build, full unit tests, package assembly, shard validation, checksum manifest, archive, and extraction smoke. |
| `Scripts/CI/Invoke-TestShard.ps1` | The only CI test/retry/result reconciliation path. |
| `Scripts/CI/Invoke-PackageSuite.ps1` | Local and Task Scheduler package execution. |

The YAML files share `Pipelines/templates/build-package-stage.yml`,
`test-shards-stage.yml`, and `setup-datapool-stage.yml`. Package version is
owned by `Pipelines/package-version.txt`.

## Package layout

The archive name includes package version and commit SHA. It contains:

- `test/`: `TestAutomation` assembly, deps/runtimeconfig, adapters, non-secret
  appsettings templates, Resources, and the matching Playwright script/driver;
- `datapool/`: run-ready DataPool output without `data/quotes.json`;
- `runsettings/ci.runsettings`;
- `config/shards.json`;
- `scripts/CI/`: validation, browser install, ownership, and canonical runner;
- `tools/CiTestInventory/`: compiled NUnit/Reqnroll inventory tool;
- `tools/TestPlanPublisher/`: typed canonical Azure Test Plans publisher CLI;
- `tools/reports/`: existing report/cleanup utilities;
- `config/testplans-mapping.template.json`: non-secret external mapping schema;
- `metadata/`: compiled test inventory plus validated full/debug ownership;
- `package-manifest.json`.

The manifest records schema/package version, commit, build ID/number, target
framework, package dependencies, and every file's relative path, size, and
SHA-256 checksum. Validation rejects missing/unmanifested/tampered files,
duplicate inventory paths, secret-like literals, private-key formats, TRX
files, test-run seed files, `QuoteNumber.txt`, and DataPool `quotes.json`.

An existing archive is never overwritten. A new version, commit, or clean
output directory is required.

## Build and execution

1. Azure performs a clean, full-history checkout and installs .NET 8. The
   package builder clears all Release output roots before compiling so deleted
   or renamed build products cannot leak into a later package.
2. NuGet restores the committed `packages.lock.json` files in locked mode.
3. The Release solution build and full unit/contract suite must pass.
4. The compiled inventory tool enumerates NUnit cases and case-level
   categories directly from `TestAutomation.dll`.
5. Full/debug shard ownership must be a nonempty, exact, disjoint partition.
6. The package is checksummed, zipped, extracted into a clean directory, and
   validated again. Source-free `dotnet test --list-tests` must equal the
   compiled inventory by exact test identity, not only by count. Discovery and
   execution use disposable copies of the test runtime so adapter-generated
   files cannot mutate the validated package.
   The extracted package also executes the isolated ExpertQuote BOP and
   Commercial DuckCreek BAP pilots independently and requires exactly one
   `NotExecuted` result for each while its profile is `NonRunnable`.
7. Test jobs use `checkout: none`, download exactly one archive, validate it,
   cache/install Chromium with the packaged Playwright runtime pair, and invoke
   one shard through `Invoke-TestShard.ps1`.

## Shards and retries

`Pipelines/config/shards.json` owns both VSTest filters and compiled-category
rules. Full `All` currently discovers 77 gated cases:

| Shard | Cases |
|-------|------:|
| Basic1 | 14 |
| Basic2 | 13 |
| Basic3 | 11 |
| BasicMisc | 1 |
| CE4 | 14 |
| CE5 | 13 |
| CE6 | 11 |

`BasicMisc` requires `SfpBasicOutcome` and explicitly excludes every numbered
shard. It therefore cannot overlap numbered SFP or CE cases. Debug mode owns
one case in every shard, including the forms-only unnumbered case.
The runner also compares each shard's actual TRX identities with its packaged
ownership inventory before accepting results.

Only a non-parameterized test explicitly tagged `@RetrySafe` can be retried,
and only for the approved transient network/browser failure classification.
Business/assertion/configuration/locator failures are never retried. Current
parameterized SFP UI workflows are state-changing and are not `@RetrySafe`.

The `ExpertQuotePilot` suite owns exactly one `EqBopAlPilot` shard. It is
validated and packaged but is absent from production scheduled matrices until
its QA profile, selector evidence, and ADO mapping are approved.

The `CommercialDuckCreekPilot` suite similarly owns exactly one
`CldcBapAlPilot` shard. Its complete checksummed source profile and rejected
frame-hint catalog are packaged, but the suite remains absent from production
schedules until data, selectors, exact frame paths, credentials, quote
round-trip expectations, and ADO ownership are approved.

Initial and retry TRX files are diagnostic attempts. The runner reconciles
them into exactly one `*-final.trx`, rejects unexpected or duplicate retry
results, validates initial and retry evidence in separate attempt roots, and
emits one `result-manifest.json` containing the final TRX checksum and the
path, size, and checksum of every published evidence attachment.

## Fail-closed gates

Execution fails on any of the following:

- package, checksum, secret, extraction, or source-free startup failure;
- zero tests, duplicate tests, shard overlap, unassigned cases, or count drift;
- missing, empty, malformed, zero-test, duplicate, or count-mismatched TRX;
- a non-passing canonical result or exhausted retry;
- missing/corrupt scenario manifests or aggregate TRX/evidence disagreement;
- missing result-manifest/publication preparation;
- missing result files, failed test publication, or publication failure.

Publication and evidence upload use `always()` so diagnostics survive failure.
`PublishTestResults` has all fail-on-error switches enabled for `Off` and
`Dry-Run`; live mapped Test Plans mode suppresses that task and uses the typed
publisher instead so a canonical execution is not published twice. Either
publisher failure keeps the job failed.

## Compatibility and Azure administration

- The established `Playwright` and `Default` private pools, schedules,
  suite/debug queue parameters, Chromium cache, and DataPool environment
  variables remain.
- The separate DataPool setup entry now installs package output and preserves
  service-local data; it no longer packages or seeds repository quote data.
- The old CE forms-only job is retired because its filter discovered zero
  cases. Its local `FormsCheck-CE` compatibility command fails with that reason
  instead of reporting a zero-test success.
- The disabled duplicate CE stage and inline retry implementations were
  removed from the compatibility YAML entry points.

YAML declares CI and PR coverage for `main`, `Development`, and
`pa3402-anico-combined-framework-*`. For Azure Repos, repository administrators
must also configure required build-validation branch policies for those
branches/patterns and point existing scheduled/manual pipeline definitions at
the compatibility YAML paths. Organization/project settings cannot be changed
from this repository.

Phase 6 adds opt-in Azure DevOps Test Plans publication. It is `Off` by default
and consumes only canonical final TRX/result/evidence inputs. See
`Docs/Azure-Test-Plans-Publishing.md`.
