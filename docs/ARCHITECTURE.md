# Architecture

```text
Feature
  -> ReqnRoll application-context Background
  -> BeforeScenario Hook loads exact ScenarioPlan
  -> Hook executes source technical Background
  -> Universal binding validates next business step
  -> DynamicDataCoordinator prepares RANDOM/runtime data
  -> StepExecutionEngine
       -> PlaywrightUiActions -> LocatorResolver -> source locator repository
       -> SystemActions for TBox/process/file/JSON behavior
  -> AfterScenario validates full plan consumption and writes artifacts
```

All scenario state is instance/scenario scoped. Plans are immutable JSON contracts. No Page, binding, method, or mutable variable is copied per scenario.
