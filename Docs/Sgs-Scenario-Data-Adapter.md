# SGS scenario-data adapter

`PnCTestAutomation.DataProfiles.ISgsScenarioData` adapts retained SGS business
inputs, not SGS lifecycle or state ownership. `Startup` registers
`SgsScenarioData` in the existing scenario scope with the exact
`ScenarioContextData` and `IQuoteHandoff` already owned by that scope. Hook
preflight, business bindings and live execution remain separate integration
work; adapter registration alone does not make a workflow executable.

## Public contract

```csharp
new SgsScenarioData(
    ScenarioContextData scenarioData,
    IQuoteHandoff quoteHandoff,
    SgsScenarioDataOptions? options = null);

new SgsScenarioDataRequest(
    string ProductCode,
    string ProfilePath,
    string? StateVariant = null,
    string? ExternalDataPath = null,
    IReadOnlyDictionary<string, string?>? RuntimeOverrides = null);
```

The request also has init-only `IReadOnlyList<string> LayerPaths` (empty by
default) and `string? StateOverridesPath`. Options expose `ResourcesRootPath`,
defaulting to `Path.Combine(AppContext.BaseDirectory, "Resources")`, and
`TimeProvider`, defaulting to `TimeProvider.System`. A custom resource root must
be absolute. There is no repository-root search, environment-root fallback or
alternate-product fallback.

The interface provides:

```csharp
void Load(SgsScenarioDataRequest request);
string GetRequired(string key);
string ResolveRequired(string expression);
void ValidateRequiredInputs(IEnumerable<string> keys);
bool TryGetOptional(string key, out string? value);
void CaptureBuffer(string key, string value);
string GetRequiredBuffer(string key);
```

For CLEQ Alabama smoke, load `CLEQ`,
`TestData\Scenarios\Smoke\03_eq_bop_smoke_test_al.json`, state variant `AL`, and
`TestData\ExternalDataOverrides.json`. Use qualified keys such as
`values.street_address_18`, `values.effective_date` and `values.state_21`.
Validate only the inputs actually consumed by the selected workflow, before UI
mutations. A successful load does not certify business applicability, expected
outcomes, credentials, browser readiness or successful execution.

## Integrity and selection

Only exact product codes `CLDC`, `CLEQ` and `PLDC` are accepted. Paths may be
`TestData`-relative, source-relative
`tests\<matching product>.Tests\TestData\...`, or destination-relative
`Resources\SGS\<matching product>\TestData\...`. Both source JSON slash styles
are normalized. Absolute paths, traversal, alternate data streams, invalid
Windows path components, cross-product paths and symbolic links/reparse points
(including ancestors of the root) are rejected.

Every selected profile, layer, state override and external patch must have a
matching product/source/destination entry in
`Resources\Contracts\sgs-data-inventory.json`. The adapter hashes the exact
bytes it parses and requires the current `importedSha256` and `importedSize`,
not `sourceSha256` or a hash of reserialized JSON. Duplicate inventory entries,
duplicate/case-colliding JSON properties, missing files and invalid JSON fail
explicitly. Each input and the inventory are limited to 5 MiB.

The active retained data is the imported flattened profile set. Imported
provenance remains pinned to `ecd9019ab991028341ad76de11cff06aa43cb32f`.
The source refresh to `d1fa9404f1a245722879e523626beb72e68d033b` on
2026-09-22 reported no changes to these data files or `ScenarioData` semantics.
This adapter does not repair, automatically discover, reconstruct from, or
accept stale SGS `Layered\manifest.json` files. Explicit legacy manifest input
is rejected. It does not regenerate production hashes.

The approved 2026-09-23 package correction replaces only known non-secret
application credential sentinels with empty external-credential slots.
`credentialDataPolicy` records that adaptation. Original `sourceSha256` and
`sourceSize` remain intact; `previousImportedSha256` and `previousImportedSize`
retain each affected profile's prior imported representation. Current imported
hashes/sizes and the execution ledger's profile checksums track the new bytes.
Regression coverage reconstructs the prior credential representation and checks
its exact hash, proving that business data did not change. Prior run artifacts
and execution states are not rewritten or promoted by this correction.

## Precedence and key semantics

1. Load the verified flattened profile and apply explicit verified `LayerPaths`
   in order as JSON Merge Patches.
2. If requested, apply `StateOverridesPath`'s
   `overrides[StateVariant]` object. This explicit reviewed format does not
   infer a state from a filename or search a stale layered manifest.
3. Apply the verified external JSON Merge Patch.
4. Apply explicit runtime overrides, copying the caller's values. A null
   runtime override removes its input.
5. Resolve expressions when an input is used, through existing PnC identity
   generation and the scenario's current buffers/environment.

Object patches merge recursively; null deletes; arrays/scalars replace.
External `values` wrappers with `value`, `replaceRequired`, `source` and `note`
are unwrapped to their explicit value. A placeholder override wins as an
invalid value; it does not silently fall back to the prior profile value.
This matters for the retained PL external override file. Do not use it
unconditionally as if its required synthetic entries were approved data.

Only `application`, `dimensions` and `values` are runtime input sections.
`_canonical`, `_rawTosca`, `_meta`, random-pattern definitions and other
provenance do not supply or override runtime inputs. In particular, CLEQ AL's
`values.effective_date` remains `03-01-2025`, not a different provenance date.
The adapter does not manufacture a newer date; applicability requires a
reviewed explicit override or a reported blocker.

Full dotted keys such as `values.insured.city` are authoritative. Bare leaf
or section-relative aliases are allowed only when unambiguous, even if
colliding values are equal. `dimensions.state` and `values.state` therefore
require explicit qualification when both exist. A literal dotted key and a
nested object cannot occupy the same qualified path.

Required values reject absence, null, whitespace, empty quoted strings,
placeholder markers, arrays, unresolved/unsupported expressions and cyclic
references. Unused non-credential placeholders do not block unrelated required inputs.
`TryGetOptional` returns false/null only for an absent key; a present invalid
value still throws. It is not a blank-success or synthetic-data fallback.
The state variant, when supplied, must match the effective declared variant.

## Expressions and state ownership

Supported expressions:

- `{{data:key}}` and `{{external:key}}` read the effective merged input.
- `{{runtime:key}}`, `{{buffer:key}}`, `{B[key]}` and `{PL[key]}` read known
  domain/captured buffers first, then effective input for other keys.
- `{{env:VARIABLE_NAME}}` reads the current process environment without caching
  the resulting value in scenario data. Missing or invalid values fail.
- Existing `RandomGenerators.ResolveRuntimeTokens` identity tokens retain
  their PnC behavior and use the exact injected context.
- `{STRINGTOUPPER[input]}` and `{STRINGREPLACE[input][old][new]}` support
  nested expressions, quoted arguments and the source `\)` replacement
  escape. Replacement is ordinal; an empty search string is invalid.
- `{DATE[base][offset][format]}` uses the scenario load's local date only for
  an explicitly empty base. A nonempty base must parse exactly. Offsets are
  signed integer `d`, `m` or `y`; an empty offset means zero. Formats are
  `MM/dd/yyyy`, `MM-dd-yyyy`, `yyyy-MM-dd` and `yyyyMMdd`, with `MM-dd-yyyy`
  the explicit empty-format default. Invalid arguments never become today,
  zero or a literal-format success.

Unknown functions, SGS random regex generation and condition/UI execution
are not supported. Resolution is bounded to 32 active data references,
256 expansion steps and 65,536 characters.

`ScenarioContextData.SgsData` is the typed owner of loaded input and capture
state. Repeated adapter instances over the same injected context see the same
state, not independent stores. A load resets adapter inputs/captures; failed
loads are not readable. Existing PnC identity and quote state are not reset.

`Quote_Num`, `QuoteNumber` and `ProposalNumber` capture/read aliases use
`IQuoteHandoff`; runtime input overrides cannot inject these actual identities.
Rendered labels such as `Quote_NameNum`, `QNum` and `QuoteNumber2` remain
explicit raw capture buffers, not another authoritative quote store.
`FirstName`, `LastName`, `MiddleName`/`MiddleInitial`, `DOB`/`DateOfBirth`,
`OwnerPhone`, `OwnerEmail` and `SSN`/`InsuredSSN` map to existing client state.
Reading those identity aliases delegates generation to `RandomGenerators`.
`EffDate`/`EffectiveDate` maps to the existing policy effective-date property.
Spaces, underscores and casing are equivalent for these documented domain
buffer aliases. Other captures are case-insensitive named literal values.

Credentials stay with the existing external provider/process environment.
Literal credential profile/runtime overrides, credential-looking placeholders,
and credential capture buffers are rejected. Imported credential slots remain
empty; explicit environment references may be resolved for a consuming caller.
Errors never echo input
values, expression text, malformed JSON payloads or credential values.

## Focused checks

```powershell
dotnet test TestAutomation.UnitTests\TestAutomation.UnitTests.csproj --no-restore --filter "FullyQualifiedName~SgsScenarioDataTests"
```

The dedicated fixture exercises real CLEQ/CLDC Alabama smoke and PL Arizona
company variants, precedence/merge patches, required-input failures,
ambiguous keys, current raw hashes, product/path isolation, real reparse
points, expressions/cycles, credential redaction and existing scenario identity
and quote ownership. Fixtures use temporary, independently checksummed test
inputs; they never rewrite the retained inventory or imported profiles.
Unit coverage does not satisfy the workflow's two-live-runs acceptance gate.
