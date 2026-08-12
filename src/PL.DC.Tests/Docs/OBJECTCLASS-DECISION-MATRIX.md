# ObjectClass decision matrix

| ObjectClass | Count | Disposition | Importance |
|---|---:|---|---|
| `ApiModule` | 4 | executable | Converted to API request/response builder operations. |
| `ApiParameter` | 2 | configuration | API configuration/property metadata. |
| `FileContent` | 237 | asset | Embedded bytes or external-file reference. |
| `OwnedFile` | 232 | asset | Attachment/external-resource manifest. |
| `Parameter` | 642 | data | Business parameter name/range/description. |
| `ParameterLayer` | 145 | data | Defines business parameters. |
| `ParameterLayerReference` | 12049 | data | Creates the per-reference parameter scope. |
| `ParameterReference` | 35077 | data | Concrete value or expression supplied to a shared workflow. |
| `RecoveryScenario` | 830 | recovery | Classified into evidence, safe correction, cleanup, or review. |
| `RecoveryScenarioCollection` | 286 | recovery | Defines inherited recovery/cleanup scope. |
| `ReuseableTestStepBlock` | 274 | executable | Generated once as a reusable workflow. |
| `TCComponentFolder` | 5 | metadata | Infers product area, grouping, and inherited configuration. |
| `TCConfiguration` | 4 | configuration | Converted to environment/runtime configuration when referenced. |
| `TCConfigurationLink` | 4 | configuration | Resolves inherited folder configuration. |
| `TCFolder` | 202 | metadata | Infers tags, groups, configuration scope, and recovery inheritance. |
| `TCProject` | 1 | metadata | Repository boundary; not executable. |
| `TDAttribute` | 1514 | data | Named data dimension and nested structure. |
| `TDClass` | 92 | data | Reusable TestCase Design data class. |
| `TDInstance` | 9420 | data | One concrete example/data combination. |
| `TDInstanceValue` | 27025 | data | Concrete value or referenced data instance. |
| `TDInstances` | 821 | data | Container for concrete data instances. |
| `TestCase` | 590 | executable | Feature/scenario identity and root execution order. |
| `TestCaseControlFlowFolder` | 1743 | executable | Contains condition/loop branch bodies. |
| `TestCaseControlFlowItem` | 855 | executable | Converted to bounded condition or loop. |
| `TestCaseTemplateDetail` | 20 | data/executable | Links a base template to its data schema. |
| `TestCaseTemplateInstance` | 17 | data/executable | Names the generated feature family and contains generated tests. |
| `TestSheet` | 41 | data | Data schema and Scenario Outline family. |
| `TestStepFolder` | 8387 | executable | Business section, prerequisite, postcondition, or grouped workflow. |
| `TestStepFolderReference` | 18388 | executable | Invokes a reusable workflow with scoped parameters. |
| `TestStepLibrary` | 8 | metadata | Library boundary only; shared workflows hold implementation. |
| `XModule` | 503 | executable | Page/component/API capability. |
| `XModuleAttribute` | 8596 | executable | Named field/control used for locator and method naming. |
| `XModuleAttributeFile` | 5 | asset | ModuleAttribute attachment relation. |
| `XParam` | 44656 | locator/configuration | Analyzed by parameter category; only one final locator is emitted. |
| `XTestStep` | 10142 | executable | Named operation linked to a UI or API Module. |
| `XTestStepValue` | 30874 | executable | Field action, value, operator, condition, and nested value. |
