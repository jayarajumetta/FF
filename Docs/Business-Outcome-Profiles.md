# SFP Business Outcome Profiles

SFP Basic Policy, Country Estate, and standalone SFP forms scenarios use a
versioned expected-outcome catalog. The default catalog is
`Resources/ExpectedOutcomes/sfp-outcomes.json`; set
`TEST_OUTCOME_PROFILE_PATH` to use an externally managed catalog.

Profiles are selected by stable scenario profile, environment, state, and
writing company. `@SfpBasicOutcome` maps to `sfp-basic`;
`@SfpCountryEstateOutcome` maps to `sfp-country-estate`. An approved state may
have only one company profile at preflight because the scenario has not entered
the company value yet. The runtime confirms the actual state and company before
business assertions.

## Approval contract

An `Approved` profile must contain:

- a profile ID and version;
- exact environment, state, and company values;
- source, approver, approval timestamp, and future validity timestamp;
- expected USD premium, absolute tolerance, and tolerance rule;
- forms baseline ID, version, SHA-256 checksum, manuscript, print job, accepted
  return statuses, and role-based-security requirement;
- transmission mode. `AvailabilityOnly` proves readiness but does not transmit.
  `TransmitAndVerify` additionally requires approved statuses and currently
  supports a returned `Quote` identity matching the scenario-owned quote;
- a SHA-256 checksum produced by
  `ExpectedOutcomeProfileValidator.ComputeChecksum` after all approved fields
  are populated.

Missing, duplicate, ambiguous, expired, not-yet-valid, synthetic, placeholder,
or checksum-invalid approved profiles fail configuration validation. Forms
execution also compares the loaded baseline's SHA-256 and
`DuckCreekForms:BaselineVersions` value with the selected profile.

`NonRunnable` is the only valid placeholder mode. It must use
`checksum: PENDING-QA`, provide a visible blocked reason, and contain no premium,
forms, or transmission expectations. It is reported as an explicit ignored
scenario before browser startup and cannot satisfy a gated run.

## Development baseline import

On September 24, 2026, PA3402 confirmed that the premiums on
`origin/Development` should be used in the integration branch. The default
catalog now contains 54 approved QA profiles copied from commit
`d91ced656df2652d65aa9b2de3d0f188d0233845`: all 38 Basic amounts and all 16
configured CE amounts. No premium is derived from another state or product.
The source README identifies CE Delaware (2283.00) and Maine (674.00) as
retained older amounts rather than newly qualified captures; those values
are carried forward exactly with that provenance recorded.

The profiles use the scenario's existing writing company, a USD 0.01 absolute
tolerance, the imported `SFP_BASIC.csv` / `SFP_CE.csv` baseline checksums and
`development-d91ced6` version, the existing Forms response contract, and
`AvailabilityOnly` transmission. CSV line endings are pinned to LF so their
checksums survive different Git checkout settings. The pre-existing approval
horizon, October 18, 2026 at 12:44:42.179 UTC, is retained rather than extended.
This is authorization to compare against Development's expectations, not a
claim that these cases or all forms checks have passed on the integration branch.

The 22 CE states without configured Development premiums and all Dev profiles
remain explicitly `NonRunnable`; imported SGS contracts are unchanged.
Additional or renewed profiles still require exact
environment/state/company expectations:

- expected premium amount and explicit absolute tolerance;
- forms baseline version and SHA-256 checksum;
- expected Forms manuscript, print job, accepted return status, and whether
  role-based security is required;
- whether the scenario is availability-only or is contractually expected to
  transmit;
- for transmit-and-verify, the accepted completion status values and returned
  identity contract;
- approval source, approver, approval timestamp, validity horizon, profile
  version, and computed profile checksum.

The integration runtime does not read the legacy `ExpectedPremiums` section.
The imported values instead live in the versioned catalog with provenance,
tolerance, validity, and integrity metadata. The offline regression suite
checks all 54 amounts against the pinned Development values, checks the
deployed forms files and configured versions, and verifies that missing
CE/Dev approvals remain gated.

## Local SFP Basic Alabama verification

`Resources\ExpectedOutcomes\sfp-basic-al-local.json` is an explicit opt-in for
one QA case. It now contains the same updated Alabama profile as the default
catalog: USD 6489.00 with a 0.01 absolute tolerance, and the imported
`SFP:BASIC` CSV forms baseline from `d91ced6`.
The updated canonical feature tables still supply the policy inputs. They
have not been replaced with generated data or migrated into this outcome JSON.

Set `EQ_USERNAME`, `EQ_PASSWORD`, `CLAS_USERNAME`, `CLAS_PASSWORD`,
`DUCKCREEK_USERNAME`, and `DUCKCREEK_PASSWORD` in the process environment using
your local secret source, then run from the repository root:

```powershell
.\Scripts\run-sfp-basic-al.ps1 -InstallBrowser
```

For the user-approved temporary local setup while Key Vault access is pending,
the same runner can read an explicitly selected existing `appsettings.json`:

```powershell
# Checks credential fields only: no build, browser, login or business test.
.\Scripts\run-sfp-basic-al.ps1 `
  -AppSettingsPath 'C:\private-config\appsettings.json' `
  -ValidateCredentialsOnly

# Execute only after application access and business-run prerequisites are approved.
.\Scripts\run-sfp-basic-al.ps1 `
  -AppSettingsPath 'C:\private-config\appsettings.json' `
  -InstallBrowser
```

The file is read-only and is never copied into the integration checkout, build
output, report or package. Only `Credentials.Username/Password` and
`DuckCreekForms.Username/Password/CLASUsername/CLASPassword` are loaded into the
six existing process variables. The previous environment is restored when the
runner exits, including on failure. An explicitly selected file must supply all
six usable string fields; missing files, malformed JSON, empty fields and
placeholder values fail rather than silently using another credential source.
Other settings in that file do not override the approved environment, expected
outcomes, business inputs or Ping authentication configuration.

`-ValidateCredentialsOnly` confirms configuration shape, not that the accounts
can authenticate. Credential values must not be pasted into chat or committed.
This is an explicit local option, not an automatic fallback after Key Vault
denies access, and it does not change private-agent/CI credential delivery.

If the credentials are in Azure Key Vault, use the Key Vault wrapper instead.
It reads the required secrets through the signed-in Azure CLI account, sets
them only for the child test process, and restores the caller environment:

```powershell
az login
.\Scripts\run-sfp-basic-al-keyvault.ps1 -VaultName "<vault-name>" -InstallBrowser
```

The wrapper maps these exact secret names:

| Key Vault secret | Runtime variable |
|------------------|------------------|
| `pnc-testautomation-credentials-username` | `EQ_USERNAME` |
| `pnc-testautomation-credentials-password` | `EQ_PASSWORD` |
| `pnc-test-automation-duckcreek-username` | `DUCKCREEK_USERNAME` |
| `pnc-test-automation-duckcreek-password` | `DUCKCREEK_PASSWORD` |
| `pnc-test-automation-clas-username` | `CLAS_USERNAME` |
| `pnc-test-automation-clas-password` | `CLAS_PASSWORD` |

The script performs a locked restore and Release build, installs Chromium when
requested, and executes exactly the Alabama Basic case. Subsequent runs can use
`-NoBuild` after rebuilding any changed code. It does not require DataPool,
Azure DevOps credentials, or Test Plans mappings for this local verification.
It temporarily selects the local profile, restores the caller's environment,
does not retry, and fails if the expected case is missing, skipped, or failed.
Results and scenario evidence are written to a unique `TestResults\SfpBasicAl-*`
directory, or to the empty directory supplied with `-ResultsDirectory`.

The profile authorizes regression comparison, not a claim that the current
application already passes. It expires on October 18, 2026; renewal or a changed
expectation requires an explicitly reviewed profile and recomputed checksum.
The forms checksum pins the actual baseline file bytes, including line endings.
Do not silently update it, premium, or forms to match an unexpected live result.
`AvailabilityOnly` checks the transmit option without transmitting a policy.
The local runner still selects only Basic Alabama. Other SFP cases use their
own catalog entries; missing approvals and imported SGS scenarios remain gated
by their applicable contracts.

### Verified boundary on September 18, 2026

The local Alabama run applied the original feature inputs, completed Insurance
Score and billing, and verified the quote identity and the exact USD 1540.00
premium. It then failed at the external QA eChecklist application with
`EChecklist/Error/ChecklistNotFound` after SSO. Checklist completion, transmit
availability, and Forms validation were not reached; the full case is **not
passing**. Do not skip those steps or weaken the baseline to make it green.

Source inspection confirms that the Checklist button opens the Duck-provided
`PolicyPrivate.ChecklistURLNoURL` under the configured QA eChecklist launch URL;
it does not create a checklist. The upstream checklist record and environment
mapping must be verified in the test eChecklist store. The accessible ExpertQuote
`develop` and `qa` refs describe an older UI than the deployed bundles, so their
commit IDs do not establish QA deployment parity. Ag-Comm Projects contains no
product implementation with which to verify checklist generation.

## Evidence

Business assertions write redacted JSON under the scenario-owned
`business-outcomes` artifact directory. Quote and transmission identities are
stored only as SHA-256 hashes. The scenario manifest records component pass/fail
state and artifact paths; it does not include raw quote identities, credentials,
session IDs, or response bodies.
