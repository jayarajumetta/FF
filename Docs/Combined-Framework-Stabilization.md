# Combined Framework Stabilization and Readiness

Package/runtime contract 1.4.0 is frozen by
`Resources/Contracts/combined-framework-contract.json`,
`Resources/Contracts/integration-readiness.json`, and the immutable package
manifest. `Scripts/CI/Invoke-StabilizationVerification.ps1` is the single
source-free verification entry point. It validates the extracted package,
compiled discovery/modules, shard ownership, all current NonRunnable SFP and
pilot probes, canonical result/evidence parity, credential-free Test Plans
dry-run reconciliation, profile/frame/source checksums, and emits a
checksummed stabilization report.

## Current readiness

| Workflow | Stable automation ID | State | Primary gates |
|----------|----------------------|-------|---------------|
| SFP Basic | `SFP-BASIC-POLICY:<STATE>` | Gated | QA outcome profiles, runtime/security approval, ADO mappings, topology decision |
| SFP Country Estate | `SFP-COUNTRY-ESTATE:<STATE>` | Gated | QA outcome profiles, runtime/security approval, ADO mappings, topology decision |
| SFP forms | `SFP-FORMS-VALIDATION:<STATE>` | Gated | approved quote/baseline metadata, Forms access, ADO mapping, topology decision |
| EQ BOP AL | `EQ-BOP-SMOKE:AL` | Gated | safe data/outcomes, selector/frame approval, credentials/PII policy, ADO mapping |
| CLDC BAP AL | `CLDC-BAP-SMOKE:AL` | Gated | safe data/outcomes, exact frame/test-ID evidence, credentials/services/PII policy, ADO mapping |
| PLDC Auto AZ ANG | `PLDC-AUTO-SMOKE:AZ` | Gated | safe data/outcomes, exact controls/frames, credentials/PII policy, ADO mapping |
| PLDC state/marital AL | `PLDC-AUTO-STATE-MARITAL:AL` | Gated | approved Married row, exact state/Married controls, credentials/cleanup/PII policy, ADO mapping |

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
| EQ BOP AL | Selected AL BOP intent and quote round trip | Destination module/profile/control/evidence/Test Plans contracts | SGS bindings/pages/infrastructure and unapproved selectors/data |
| CLDC BAP AL | Selected BAP field/score/quote intent | Exact frame propagation, redacted runtime locator evidence, typed profile | Generic frames, fieldref/role rescue, source retry/hooks/pipeline |
| PLDC pilots | AZ ANG quote round trip and AL state/Married proof intent | Correct state/Married targets, control readiness, selected-value assertions, deterministic outcomes | Wrong Next/Divorced targets, heading waits, empty selects, fixed delays, broad `.First`, unsupported business claims |

## Approval path

- **Architecture/David:** decide physical topology and approve exact selector
  and frame contracts.
- **QA:** approve sanitized data, versioned expected outcomes, baselines, and
  the missing AL Married case.
- **Security/Operations:** approve credentials/runtime access, PII redaction,
  evidence retention, dependent services, and mutation cleanup.
- **DevOps/ADO:** provide secure numeric mappings, permissions, branch
  validation, and schedule ownership.

No workflow may move from `Gated` to `Runnable` by editing the matrix alone.
The underlying profile, selector/frame, business-outcome, package, mapping,
and approval contracts must all agree first.
