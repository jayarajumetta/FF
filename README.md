# Tosca Canonical Simple Framework v39

This release intentionally returns to the proven v29/v32 architecture:

```text
Business Feature / Scenario Outline
  -> explicit ReqnRoll StepDefinition
     -> direct module PageMethod calls in source order
        -> centralized app locator namespace
           -> Playwright
```

Hooks own browser lifecycle and evidence only. They do not execute business flow.

Generated from the 32 attached eligible manual-flow artifacts and the v38 source-derived canonical mapping/locator evidence.

- Features: 32
- Business Gherkin steps: 875
- Direct module PageMethods: 4873
- Canonical source actions preserved under those methods: 11650
- Review-only locator fallbacks: 1165

Test data lives in `TestData/Scenarios`. Random patterns generate once per scenario key. Protected/third-party values use `SYNTHETIC_REPLACE_ME` and fail until replaced.

## Run
```powershell
dotnet restore ToscaCanonicalSimple.sln
dotnet build ToscaCanonicalSimple.sln
dotnet test ToscaCanonicalSimple.sln
```


## v41 state-driven expansion

The 32 selected business flows are expanded from Tosca TestCaseTemplateInstance.Items into 1074 concrete source examples. Each example has a scenario JSON whose values are reconciled through stable DerivedFrom lineage. See `Artifacts/StateApplicabilityMatrix.json` and `Artifacts/CanonicalFieldCatalog.json`.
