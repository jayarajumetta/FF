# Tosca canonical mapping

| Tosca source concept | Generated artifact |
|---|---|
| TestCase / Template | Feature |
| TemplateInstance and TestCase-Design row | Scenario Outline and Examples row |
| XTestStep / TestStep | Stable source-ordered CanonicalAction group |
| XTestStepValue / TestStepValue | Action, value, verification, capture, wait or condition |
| XModule / Module | PageMethod module context |
| XModuleAttribute / ModuleAttribute | PageLocator target and candidate metadata |
| ActionMode Input | Input, SmartSet, Select, Click or Press |
| ActionMode Verify | Exact property-aware Verify |
| ActionMode WaitOn | Positive or negative Wait |
| ActionMode Buffer / Output | Scenario/run-level capture |
| `{PL[...]}` / `{XL[...]}` | Resolved scenario JSON value from the attached iteration |
| `{TDS[...]}` / TDM reference | ExternalDataOverrides key |
| `{B[...]}` / runtime buffer | ScenarioDataContext runtime value |
| RANDOM/RND/RANDOMREGEX | Random definition generated before business PageMethods |
| TBox Set/Partial Buffer | Runtime data service, never a PageLocator |
| TBox Wait | Hook synchronization or typed Wait |
| process/file/JSON/window/browser modules | Hooks/SystemActions, never the Page layer |
| RecoveryScenario | failure screenshot/DOM/trace/video and cleanup Hooks |

## Ordering rule

Source sequence is never regrouped across a later action. Business stages are contiguous segments. Every compiled action has a monotonically increasing sequence and source step reference; the quality gate rejects reordering, duplicate IDs or omissions.

## Locator rule

Resolve application and effective module first, then the field/control. Candidate priority is test id, stable id/Duck Creek id, role, label/ARIA, name, scoped text/CSS and XPath only as fallback. Negative assertions do not require a positive locator match before evaluating absence.
