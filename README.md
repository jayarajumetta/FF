# Client Automation — BOP/EQ + PL-DC v35

This is the final **single client repository** containing both standalone automation domains.

```text
ClientAutomation.sln
├─ src/BOP.EQ.Tests/
└─ src/PL.DC.Tests/
```

They are two test projects, not two repositories. `dotnet test ClientAutomation.sln` runs both.

## Why two projects inside one repo?

BOP/EQ and PL-DC contain overlapping generated names such as Login, State, Billing, Next,
Proposal, and common business phrases. Keeping them in separate test assemblies removes C#
type collisions and ReqnRoll binding ambiguity while preserving one client codebase, one root
README, one set of run scripts, and one pipeline boundary.

## Run

```powershell
.\RunScripts\setup.ps1
.\RunScripts\run.ps1 -Domain all
.\RunScripts\run.ps1 -Domain bop-eq
.\RunScripts\run.ps1 -Domain pl-dc
```

Optional:

```powershell
.\RunScripts\run.ps1 -Domain all -Filter "TestCategory=smoke"
```

## Duplicate/syntax release gate

Both domain repositories retain the v34 zero-error static compiler contracts.

Combined v35 checks also ensure:

- no stale/backup StepDefinition source directories compile;
- both projects have unique assembly names;
- all Features are explicitly tagged with their domain;
- JSON and project XML are valid;
- BOP/EQ and PL-DC remain isolated from cross-assembly binding/type collisions.

Current result:

```text
BOP/EQ static compiler-contract errors: 0
PL-DC static compiler-contract errors:  0
BOP/EQ combined sanity errors:          0
PL-DC combined sanity errors:           0
```

Run the root gate:

```powershell
.\RunScripts\quality-gate.ps1
```

## Quick cross-check of the latest TSUs

Yes — the latest PL-DC files contain a consideration that is not present in the BOP/EQ source:
`XModuleAttribute.UIParent/UIChildren`. The combined audit now treats those as additional UI
hierarchy/context for locator grouping.

The inverse also exists: BOP/EQ has `ApiModule`/`ApiParameter` objects plus Module
reference/generalization/specialization relations not present in the latest PL-DC source.

Other considerations handled holistically across the two domains are:

- PL-DC's dense `DerivedFrom` inheritance;
- nested TestStepFolder trees;
- nested `XTestStepValue.SubValues`;
- TestSheet/TestCase Design/template instances;
- recovery and cleanup scenarios;
- owning `Items` execution order and TestStep reordering;
- effective Module/submodule locator resolution.

See `Reports/CROSS-SOURCE-CONSIDERATION-AUDIT-V35.json`.

## Acceptance on the client machine

A real .NET compiler is not available in this environment, so the final client-side acceptance is:

```bash
dotnet restore ClientAutomation.sln
dotnet build ClientAutomation.sln --no-restore
dotnet test ClientAutomation.sln --no-build
```
