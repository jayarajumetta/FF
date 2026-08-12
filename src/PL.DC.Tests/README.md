# PL-DC Standalone Automation — Playwright C# + ReqnRoll v34

v34 is the compile-clean dual-regression release. It preserves all source-order, runtime, locator, nested-object, recovery, and data-flow learning from earlier versions while adding a stricter generated-code contract.

## Generated runtime

```text
Feature / Scenario Outline
  -> one effective ReqnRoll binding
      -> PageMethod(data)
          -> Playwright-native locator
```

## v34 structural gates

- No duplicate binding in the same scope.
- Truly identical cross-feature bindings are consolidated into `SharedBusinessSteps.cs`.
- No stale/legacy StepDefinition source tree is kept under the SDK project root.
- Every constructed Page type exists.
- Every awaited Page method exists.
- No locator/property member can have the same identifier as its enclosing C# type.
- Feature-to-binding coverage is complete and non-ambiguous.
- Data is loaded before data-dependent navigation.
- Browser navigation is explicit through `GotoAsync`/`NavigateAsync`.
- Source execution order and ModuleAttribute order rules remain enforced.
- Locator selection remains source-driven and Playwright-oriented.

See `Reports/STATIC-COMPILER-CONTRACT-V34.json` and `Docs/ARCHITECTURE.html`.

## Client acceptance

```powershell
.\RunScripts\setup.ps1
dotnet restore
dotnet build
.\RunScripts\run.ps1
```

A .NET SDK is not installed in this generation environment, so v34 uses a static compiler-contract gate. `dotnet build` remains the final client-environment acceptance gate.
