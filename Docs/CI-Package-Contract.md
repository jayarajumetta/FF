# CI Package and Result Contract

Phase 5 makes one immutable archive the boundary between build agents and
private execution agents. Test jobs do not check out source or rebuild.

## Entry points

| Path | Contract |
|------|----------|
| `Pipelines/build-package-validation.yml` | Manual-only package validation on the `Playwright` pool; uses only the build/package stage, with no UI shards, schedules or DataPool installation. |
| `Pipelines/sfp-smoke-adhoc.yml` | Canonical manual entry point plus the existing Development schedules; CI/PR triggers are disabled during cutover. |
| `Pipelines/sfp-smoke-vm.yml` | Compatibility entry point retaining the existing main-branch schedules. |
| `Pipelines/forms-check-scheduled.yml` | Compatibility entry point for the one discovered SFP forms-only case. |
| `Pipelines/setup-datapool-service.yml` | One-time compatibility entry point that installs DataPool from the validated package. |
| `Scripts/CI/New-TestPackage.ps1` | Locked restore, Release build, full unit tests, package assembly, shard validation, checksum manifest, archive, and extraction smoke. |
| `Scripts/CI/Invoke-TestShard.ps1` | The only CI test/retry/result reconciliation path. |
| `Scripts/CI/Invoke-PackageSuite.ps1` | Local and Task Scheduler package execution. |

The YAML files share `Pipelines/templates/build-package-stage.yml`,
`test-shards-stage.yml`, and `setup-datapool-stage.yml`. Package version is
owned by `Pipelines/package-version.txt`.
The final integration baseline is frozen at `1.4.0`; changing it requires a
new reviewed package-contract milestone rather than an ad hoc build override.

### First cutover validation

Manually queue `Pipelines/build-package-validation.yml` on the integration
branch first. It reuses the existing clean checkout, locked restore, Release
build, offline unit/contract checks, immutable package validation and artifact
publication. It does not include `test-shards-stage.yml` or
`setup-datapool-stage.yml`, and it does not require application credentials.

Keep `sfp-smoke-adhoc.yml` at `trigger: none` and `pr: none` while validating
the cutover. Its two existing Development schedules and manual queue parameters
are unchanged; branch commits and PRs must not automatically start all seven
UI shards. Do not activate NonRunnable outcome profiles, invent QA expectations,
install DataPool, or change Azure resources as part of this repository-only step.

CI triggers, PR validation and Azure Repos build-validation branch policies
should be enabled only after package and authorized execution validation.
Branch policies can queue builds independently of YAML `pr: none`; administrators
must keep automatic UI validation disabled during this cutover. This change
does not create or update pipeline definitions, policies, variable groups,
agent pools or schedules in Azure DevOps.

### Execution environment and secret variables

Azure DevOps secret variables are not automatically available to scripts.
`test-shards-stage.yml` explicitly maps the following variables into the
`Execute and reconcile shard` step's environment. Configure the values through
the authorized pipeline/variable-group mechanism, marking credentials and
secrets as secret; commit only variable references, never values. These mappings
do not copy local `appsettings.json` credentials into Azure or into the package.

| Azure DevOps variable | Test process environment key |
|----------------------|------------------------------|
| `EQ_USERNAME`, `EQ_PASSWORD` | Same names |
| `EXPRESS_USERNAME`, `EXPRESS_PASSWORD` | Same names |
| `DUCKCREEK_FORMS_USERNAME` | `DuckCreekForms__Username` |
| `DUCKCREEK_FORMS_PASSWORD` | `DuckCreekForms__Password` |
| `DUCKCREEK_FORMS_CLAS_USERNAME` | `DuckCreekForms__CLASUsername` |
| `DUCKCREEK_FORMS_CLAS_PASSWORD` | `DuckCreekForms__CLASPassword` |
| `OAUTH_TOKEN_URL`, `OAUTH_CLIENT_ID`, `PING_SECRET_ID` | Same names |
| `PING_TOKEN_ENDPOINT`, `PING_SECRET_ENDPOINT` | Same names |
| `PING_BOOTSTRAP_CLIENT_ID`, `PING_BOOTSTRAP_CLIENT_SECRET` | Same names |
| `EXPERT_QUOTE_API_BASE_URL` | Same name |
| `DATAPOOL_BASE_URL`, `DATAPOOL_API_KEY` | Same names; existing mappings retained |

The double underscores bind the Forms credentials to the existing .NET
`DuckCreekForms` configuration section. Ping/OAuth/API settings apply when the
selected scenarios use those existing services. Existing DataPool requiredness
and `DATAPOOL_AUTO_START: "false"` behavior are unchanged.

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
- `tools/SgsReport/`: complete .NET reporting runtime, including its main
  assembly/publisher dependencies and compiled offline presentation assets;
- `tools/reports/`: existing report/cleanup utilities;
- `config/testplans-mapping.template.json`: non-secret external mapping schema;
- `metadata/`: compiled test inventory plus validated full/debug ownership;
- `package-manifest.json`.
- `test/Resources/Contracts/integration-readiness.json`;
- `scripts/CI/Invoke-StabilizationVerification.ps1` and
  `Test-IntegrationReadiness.ps1`.

The manifest records schema/package version, commit, build ID/number, target
framework, package dependencies, and every file's relative path, size, and
SHA-256 checksum. Validation rejects missing/unmanifested/tampered files,
duplicate inventory paths, secret-like literals, private-key formats, TRX
files, test-run seed files, `QuoteNumber.txt`, and DataPool `quotes.json`.

An existing archive is never overwritten. A new version, commit, or clean
output directory is required.

DataPool's `data/` directory is runtime-owned, not package content.
`DataPool.csproj` disables both build-output and publish copying for its
`Content` and `None` items. This boundary matters for the inventory and report
tools: `ReferenceOutputAssembly="false"` on the framework's DataPool build
dependency does not suppress transitive content copying. Without the explicit
exclusion, the Web SDK's default JSON copy rules also place `data/quotes.json`
under those tools.

The package's forbidden-file scan still rejects `quotes.json` anywhere,
including every tool subtree and nested or future tool directories. A valid
checksum manifest does not exempt runtime data. DataPool continues to create
its runtime store when needed; no existing source or service-local quote data
is deleted or seeded by this exclusion. Clean Release output roots remain
required so files from an older build cannot survive incremental compilation.

## Build and execution

1. Azure performs a clean, full-history checkout and installs .NET 8. The
   package builder clears all Release output roots before compiling so deleted
   or renamed build products cannot leak into a later package.
2. NuGet restores the committed `packages.lock.json` files in locked mode.
3. The Release solution build and full unit/contract suite must pass. The
   builder ensures Chromium is available using that build's Playwright
   installer and the existing browser cache. `BrowserContract` cases exercise
   native/Material controls and reporting lifecycle evidence against in-memory
   HTML only; they use no product
   endpoints, credentials, quotes, or DataPool. Missing browser/runtime files
   fail rather than skipping those contracts.
4. The compiled inventory tool enumerates NUnit cases and case-level
   categories directly from `TestAutomation.dll`.
5. Full/debug shard ownership must be a nonempty, exact, disjoint partition.
6. The package is checksummed, zipped, extracted into a clean directory, and
   validated again. Source-free `dotnet test --list-tests` must equal the
   compiled inventory by exact test identity, not only by count. Discovery and
   execution use disposable copies of the test runtime so adapter-generated
   files cannot mutate the validated package.
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

Initial and retry TRX files are diagnostic attempts. The runner reconciles
them into exactly one `*-final.trx`, rejects unexpected or duplicate retry
results, validates initial and retry evidence in separate attempt roots, and
emits one `result-manifest.json` containing the final TRX checksum and the
path, size, and checksum of every published evidence attachment.
The runner explicitly sets/restores `TEST_ATTEMPT_NUMBER` for actual initial
and retry attempts. A unique invocation ID is shared only by those attempts;
separate reruns of the same package are not the same execution group.
Genuine `NotExecuted` results remain skipped in the final
TRX and counts; they fail the execution gate and are never retried or promoted
to executed/passing cases.

After canonical TRX consolidation, the shared `Invoke-CanonicalReport` helper
runs the packaged .NET utility and requires nonempty `report.html`, `log.html`,
`output.xml` and `summary.json` in `report/`. The result manifest records this
gate and its summary checksum. Exit 1 means actual failure/skip; exit 2 means
invalid/missing evidence, input or reporting output. Either prevents a passing
shard. The local SFP Alabama wrapper uses the same helper after its one
non-retried execution and verifies reporting runtime availability beforehand.
Raw `dotnet test` produces scenario reports; consolidate only after its TRX
has been written. See `Docs/SGS-Reporting.md`.

## Fail-closed gates

Execution fails on any of the following:

- package, checksum, secret, extraction, or source-free startup failure;
- zero tests, duplicate tests, shard overlap, unassigned cases, or count drift;
- missing, empty, malformed, zero-test, duplicate, or count-mismatched TRX;
- a non-passing canonical result or exhausted retry;
- missing/corrupt scenario manifests or aggregate TRX/evidence disagreement;
- missing reporting runtime/output, stale projections or canonical report disagreement;
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

During cutover, YAML does not declare CI or PR triggers for any branch. After
validation and approval, repository administrators can enable the intended
CI/PR coverage and required Azure Repos build-validation policies, and point
the appropriate scheduled/manual definitions at the reviewed entry-point paths.
Until then, retain the established manual/scheduled behavior. Organization/project
settings cannot be changed from this repository.

Phase 6 adds opt-in Azure DevOps Test Plans publication. It is `Off` by default
and consumes only canonical final TRX/result/evidence inputs. See
`Docs/Azure-Test-Plans-Publishing.md`.

## Stabilization verification

Run the credential-free source-free gate against an extracted package or its
archive:

```powershell
pwsh .\scripts\CI\Invoke-StabilizationVerification.ps1 `
  -PackageRoot . `
  -OutputPath C:\results\stabilization-report.json
```

The command validates package checksums/secrets, compiled discovery and module
contracts, exact shard ownership, the current NonRunnable SFP Basic/CE/forms
gates, canonical TRX/evidence parity,
Test Plans dry-run reconciliation, and source-free reporting startup with an
explicitly rejected missing-canonical fixture. This utility fixture is not a
business execution or evidence of application readiness. Its JSON report carries a SHA-256 over
the canonical report body.
