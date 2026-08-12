# Recursive ObjectClass Coverage

The mapper treats nesting as a general rule across all exported ObjectClasses. Feature annotations are only added when the executing Step Definition maps strongly to the corresponding source reusable block.

| ObjectClass | Count | Recursive owned associations | Recursive/reference associations |
|---|---:|---|---|
| `ApiModule` | 4 | Attributes | — |
| `ApiParameter` | 2 | — | — |
| `FileContent` | 46 | — | — |
| `OwnedFile` | 43 | EmbeddedContent | — |
| `Parameter` | 339 | — | — |
| `ParameterLayer` | 102 | Parameters | — |
| `ParameterLayerReference` | 3476 | AllParameterReferences | DerivedFrom |
| `ParameterReference` | 7926 | — | DerivedFrom, Parameter, ParameterLayerReference |
| `RecoveryScenario` | 208 | Items | DerivedFrom |
| `RecoveryScenarioCollection` | 52 | Scenarios | DerivedFrom, TestCase |
| `ReuseableTestStepBlock` | 205 | Items | — |
| `TCComponentFolder` | 2 | Items | — |
| `TCConfiguration` | 2 | — | — |
| `TCConfigurationLink` | 2 | — | — |
| `TCFolder` | 114 | Items | — |
| `TCProject` | 1 | Items | — |
| `TDAttribute` | 345 | Instances, Items, Values | — |
| `TDClass` | 16 | Attributes, Instances | — |
| `TDInstance` | 1618 | Instances, Values | — |
| `TDInstanceValue` | 7764 | — | Element, ValueInstance |
| `TDInstances` | 85 | Items | DefiningItem |
| `TestCase` | 50 | Items | DerivedFrom, TemplateDetail |
| `TestCaseControlFlowFolder` | 325 | Items | DerivedFrom |
| `TestCaseControlFlowItem` | 155 | ControlFlowFolders | DerivedFrom, TestCase |
| `TestCaseTemplateDetail` | 4 | Instances | SchemaDefinition, TestCase |
| `TestCaseTemplateInstance` | 2 | Items | DataSourceDefinition, TemplateDetail |
| `TestSheet` | 8 | Instances, Items | — |
| `TestStepFolder` | 723 | Items | DerivedFrom, TestCase |
| `TestStepFolderReference` | 5295 | — | DerivedFrom, ParameterLayerReference, ReusedItem |
| `TestStepLibrary` | 6 | ReusableItems | — |
| `XModule` | 254 | AttachedFiles, Attributes, Specializations | Generalization |
| `XModuleAttribute` | 4034 | Attributes, TestStepValues | DefaultSpecializationModule, Module, ParentAttribute, ReferencedModule |
| `XModuleAttributeFile` | 3 | EmbeddedContent | ModuleAttribute |
| `XParam` | 17661 | — | — |
| `XTestStep` | 2009 | TestStepValues | DerivedFrom, Module, TestCase |
| `XTestStepValue` | 5540 | SubValues | DerivedFrom, ModuleAttribute, SpecializationModule |
