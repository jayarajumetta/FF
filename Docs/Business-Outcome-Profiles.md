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

## Values awaiting QA approval

All default SFP entries are currently `NonRunnable`. QA must provide exact
profiles for each runnable environment/state/company combination:

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

The legacy `ExpectedPremiums` values were intentionally removed because they
did not carry QA provenance, tolerance, validity, or integrity metadata.

## Evidence

Business assertions write redacted JSON under the scenario-owned
`business-outcomes` artifact directory. Quote and transmission identities are
stored only as SHA-256 hashes. The scenario manifest records component pass/fail
state and artifact paths; it does not include raw quote identities, credentials,
session IDs, or response bodies.
