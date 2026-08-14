# Tosca mapping

- `TestCase` / instantiated template -> Feature and ScenarioPlan.
- ordered `XTestStep` -> ordered plan instruction and Gherkin source-step comment.
- `XTestStepValue` -> operation, target, value/data reference, expected result, condition, and runtime expression.
- `XModule` + `XModuleAttribute` + `XParam` -> source-derived locator candidates.
- TBox buffer/wait/screenshot/process/file/JSON operations -> framework services, never PageObjects.
- TDM and blank source values -> explicit override keys; unresolved values fail rather than leak Tosca syntax into the browser.
