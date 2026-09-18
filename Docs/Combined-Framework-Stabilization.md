# Combined Framework Stabilization and Readiness

Package/runtime contract 1.4.0 is frozen by
`Resources/Contracts/combined-framework-contract.json`,
`Resources/Contracts/integration-readiness.json`, and the immutable package
manifest. `Scripts/CI/Invoke-StabilizationVerification.ps1` is the single
source-free verification entry point. It validates the extracted package,
compiled discovery/modules, shard ownership, all current NonRunnable SFP and
canonical result/evidence parity, credential-free Test Plans dry-run
reconciliation, profile checksums, and emits a
checksummed stabilization report.

## Current readiness

| Workflow | Stable automation ID | State | Primary gates |
|----------|----------------------|-------|---------------|
| SFP Basic | `SFP-BASIC-POLICY:<STATE>` | Gated | QA outcome profiles, runtime/security approval, ADO mappings, topology decision |
| SFP Country Estate | `SFP-COUNTRY-ESTATE:<STATE>` | Gated | QA outcome profiles, runtime/security approval, ADO mappings, topology decision |
| SFP forms | `SFP-FORMS-VALIDATION:<STATE>` | Gated | approved quote/baseline metadata, Forms access, ADO mapping, topology decision |

The JSON readiness matrix is authoritative for detailed business assertions,
evidence, package paths, blockers, approval evidence, and accountable roles.
The validator rejects missing workflows, duplicate identities/ownership,
module/evidence/profile disagreement, stale checksums, incomplete package
inventory, unowned gates, or a Runnable state without every approval.

## Retain, change, retire

| Area | Retain | Change/adapt | Retire/do not copy |
|------|--------|--------------|--------------------|
| Controls | Business intent and component-aware operations | Destination `ControlDefinition`, semantic actions, exact enabled/selected/checked/value postconditions | SGS `UiActions`, generated pages, visibility-as-equality, empty selections, direct DOM clicks |
| Frames | Logical frame intent and diagnostic evidence | Versioned exact page/frame paths carried through action and evidence | Generic `iframe`, dropped scope, top-document fallback |
| Profiles | Scenario/profile/environment precedence and source provenance | Typed, checksummed, collision-safe, fail-closed profiles with explicit missing keys | Silent empty values, stale layered manifests, synthetic required data, copied PII/credentials |
| Reporting | Scenario reports, evidence manifests, finalizer/publisher boundaries | One destination artifact root, unique checkpoints, fatal required evidence, canonical outcome parity | Cached `scenario.png`, success-shaped missing evidence, duplicate reporters/finalizers |
| Packaging | Clean .NET 8 restore/build, explicit binaries/Playwright validation, one artifact | Immutable complete 1.4.0 inventory, source-free discovery and stabilization report | Partial release bundles, per-shard rebuilds, missing-result success |
| Test Plans | Stable automation identity and publisher boundary | Checksummed external mappings, idempotent dry-run/publish/reconcile, attachment parity | Numeric IDs in features/code, duplicate TRX publication, credentials in artifacts |
| Hooks/retry/pipelines | Private agents, browser caching, sharding, schedules, DataPool, result publication | One destination hook set, one classified CI retry boundary, disjoint compiled ownership | SGS hooks/browser factories/retry generator/pipelines and state-changing replay without rollback |
| SFP Basic/CE/forms | Existing business-readable reference workflows and domain assertions | Versioned expected outcomes, strict quote/premium/forms/transmit-readiness evidence | Treating availability as transmission, missing-baseline success, duplicate forms orchestration |

## Approval path

- **Architecture/David:** decide physical topology and approve exact selector
  and frame contracts.
- **QA:** approve sanitized data, versioned expected outcomes, and baselines.
- **Security/Operations:** approve credentials/runtime access, PII redaction,
  evidence retention, dependent services, and mutation cleanup.
- **DevOps/ADO:** provide secure numeric mappings, permissions, branch
  validation, and schedule ownership.

No workflow may move from `Gated` to `Runnable` by editing the matrix alone.
The underlying profile, selector/frame, business-outcome, package, mapping,
and approval contracts must all agree first.
