# Azure Test Plans Publishing Contract

Phase 6 publishes only the canonical Phase 5 result and evidence contracts.
Initial and retry attempts are diagnostic inputs and never become separate
Azure DevOps results.

## Stable automation IDs

Publishable Reqnroll features declare one `@AutomationId-<NAME>` tag. The
scenario's stable execution qualifier (currently `StateAbbv`) is appended to
form the published ID:

```text
@AutomationId-SFP-BASIC-POLICY + AL
=> SFP-BASIC-POLICY:AL
```

The ID does not depend on feature prose or Azure DevOps numeric IDs. Artifact
manifest schema 2 records both this ID and NUnit's exact test identity so the
publisher can enforce one-to-one TRX/evidence correlation.

Current families are:

- `SFP-BASIC-POLICY:<STATE>`
- `SFP-COUNTRY-ESTATE:<STATE>`
- `SFP-FORMS-VALIDATION:<STATE>`
- `EQ-BOP-SMOKE:AL` (Phase 7A pilot, explicitly deferred)
- `CLDC-BAP-SMOKE:AL` (Phase 7B pilot, explicitly deferred)

## Mapping catalog

`Pipelines/config/testplans-mapping.template.json` is a non-secret template.
The Azure DevOps owner supplies a versioned catalog as a secure file:

```json
{
  "schemaVersion": 1,
  "catalogVersion": "2026.09.1",
  "provenance": "Approved by QA and Azure DevOps Test Plans owners",
  "checksum": "<SHA-256 OF THE CANONICAL CATALOG>",
  "deferredAutomationIds": [],
  "mappings": [
    {
      "automationId": "SFP-BASIC-POLICY:AL",
      "planId": 1,
      "suiteId": 2,
      "testCaseId": 3,
      "configurationId": 4
    }
  ]
}
```

The checksum is computed over newline-separated schema version, catalog
version, provenance, and mappings sorted by automation ID, where each mapping
is:

```text
automationId|planId|suiteId|testCaseId|configurationId
```

Validation rejects a stale checksum, invalid/non-positive IDs, duplicate
automation IDs, ambiguous Azure targets, mapping drift, and any selected gated
ID without a mapping. Updating the catalog changes the
publication correlation key, preventing an old reconciliation record from
silently targeting new Test Plans objects.

An optional `deferredAutomationIds` array records known pilot identities that
do not yet have approved ADO ownership. Deferred IDs contribute
`deferred|automationId` lines to the checksum. They may not duplicate or
overlap mappings, and a selected gated execution that is still deferred fails
explicitly rather than being published or treated as unmapped success.

## CLI

The run-ready package contains:

```powershell
scripts\CI\Invoke-TestPlanPublication.ps1
tools\TestPlanPublisher\TestPlanPublisher.dll
```

The wrapper supports `validate`, `dry-run`, `publish`, and `reconcile`:

```powershell
pwsh .\scripts\CI\Invoke-TestPlanPublication.ps1 `
  -Mode dry-run `
  -PackageRoot . `
  -ResultsRoot C:\results\Basic1 `
  -MappingCatalog C:\secure\testplans-mapping.json `
  -Environment qa `
  -Browser chromium
```

`validate` performs local package/result/TRX/evidence/mapping parity checks.
`dry-run` atomically writes deterministic publication and reconciliation JSON
without network access. `publish` uses Azure DevOps REST. `reconcile` requires
an existing state file and resumes an interrupted publication.

Credential-bearing requests are restricted to Azure DevOps cloud hosts. When
`System.AccessToken` is used, `AZDO_ORGANIZATION_URL` must exactly match the
agent-provided `System.CollectionUri`; the shared pipeline derives both values
from that predefined variable rather than a queue-time endpoint override.

## Idempotency and failure behavior

The correlation key includes package version, commit, build, mapping catalog
version/checksum, environment, browser, shard, and sorted automation IDs. The
REST adapter:

1. reuses an exactly named run or creates one;
2. resolves exactly one test point from plan/suite/case/configuration;
3. updates an existing stable automation result or creates it once;
4. uploads only safe metadata/business-outcome evidence, keyed by SHA-256;
5. validates remote result identity and outcome parity;
6. completes the run only after every selected result is reconciled.

The reconciliation record is mode-specific and atomically updated after each
remote identity and attachment. Attachment identity combines its safe relative
path and content checksum; exact remote parity rejects missing, duplicate, or
stale publisher-owned attachments. Checksums are streamed, and upload-permitted
metadata is capped at 4 MiB. Unauthorized responses, partial writes,
ambiguous points/runs, attachment failures, malformed responses, or parity
drift fail explicitly.
Response bodies, credentials, authorization headers, attachment contents, and
raw quote/policy identities are never logged or written to publication
metadata. Only existing SHA-256 identity evidence is carried forward.

The optional `ITemporaryTestSuiteManager`/`TemporaryTestSuiteScope` boundary is
available for a future explicitly requested single-case lifecycle. Cleanup is
guaranteed in `finally`; normal mapped publication does not create temporary
suites.

## Pipeline configuration and ownership

Publication defaults to `Off`. Queue `Dry-Run` or `Publish` and supply:

- `testPlanMappingSecureFile`: Azure Pipelines secure-file name;
- `System.CollectionUri`, supplied by the agent and used as the organization
  URL for pipeline publication;
- `AZDO_PROJECT`: project name;
- `System.AccessToken` with Test Management permissions, or secret
  `AZDO_TEST_PAT` when a service token is not available.

Plan, suite, test-case, and configuration IDs belong only in the secure mapping
catalog. Credentials and authorization headers must never be added to YAML,
JSON, logs, artifacts, or repository variables that are not secret.

Azure DevOps administrators must grant the pipeline identity read/write access
to Test Plans/runs/results/attachments and secure-file access. The repository
cannot create those permissions or choose production numeric IDs.

For package CLI use outside Azure Pipelines, a PAT caller supplies
`AZDO_ORGANIZATION_URL`; only `dev.azure.com` and `*.visualstudio.com` hosts are
accepted.

In `Publish` mode the mapped publisher replaces `PublishTestResults@2` for that
shard so a canonical execution creates exactly one Azure DevOps result.
`PublishTestResults@2` remains the fail-closed publisher for `Off` and
`Dry-Run` modes.
