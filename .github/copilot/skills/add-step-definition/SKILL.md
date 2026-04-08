---
name: add-step-definition
description: Scaffold a new Reqnroll step definition class for this framework, with correct Binding attribute, constructor injection of ScenarioContextData and page objects, and TableMappingHelpers usage.
---

# Add Step Definition

When asked to create a new step definition class, follow these rules exactly.

## File Location
- SFP steps: `StepDefinitions/SFPSteps/`
- PA steps: `StepDefinitions/PASteps/`
- BOP steps: `StepDefinitions/BOPSteps/`
- Shared steps: `StepDefinitions/SharedSteps/`

## Class Template

```csharp
using Reqnroll;
using TestAutomation.Helpers;
using TestAutomation.Pages.{ProductFolder};

namespace TestAutomation.StepDefinitions.{ProductFolder};

[Binding]
public class {Name}Steps
{
    private readonly ScenarioContextData _contextData;
    private readonly {PageName}Page _{pageName}Page;

    public {Name}Steps(ScenarioContextData contextData, {PageName}Page {pageName}Page)
    {
        _contextData = contextData;
        _{pageName}Page = {pageName}Page;
    }

    [When(@"I fill in the {name} details")]
    public async Task WhenIFillInThe{Name}Details(Table table)
    {
        TableMappingHelpers.Map{Name}Data(table, _contextData);
        await _{pageName}Page.Fill{Field}Async(_contextData.{Model}.{Property});
    }
}
```

## Rules
- Class must have `[Binding]` attribute
- Use constructor injection only — never service locator or static access
- Always inject `ScenarioContextData` for test data access
- Inject page objects and services as needed
- Table parameters use `TableMappingHelpers` static methods to populate `_contextData`
- Step methods are `async Task` when calling page object methods
- Step regex uses `@"..."` verbatim strings
- Access test data via domain models: `_contextData.Client.FirstName`, `_contextData.Vehicle.Make`, etc.

## Token Values in Tables
When writing step bindings that accept tables with token values, the tokens are resolved automatically:
- `{{firstName}}`, `{{lastName}}` → random names
- `{{randomPhone}}` → random phone number
- `{{randomEmail}}` → random email
- `{{randomDOB}}` → random date of birth
- `{{randomSSN}}` → random SSN
