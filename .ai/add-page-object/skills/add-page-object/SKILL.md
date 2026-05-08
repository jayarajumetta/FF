---
name: add-page-object
description: Scaffold a new Playwright page object for this framework, following the BasePage inheritance pattern, async method conventions, and DI singleton registration.
---

# Add Page Object

When asked to create a new page object, follow these rules exactly.

## File Location
Place the file in the correct product folder:
- SFP pages: `Pages/ExpertQuotePages/SFP/`
- Express pages: `Pages/ExpressPages/`
- ExpertService pages: `Pages/ExpertServicePages/`

## Class Template

```csharp
using Microsoft.Playwright;

namespace TestAutomation.Pages.{ProductFolder};

public class {PageName}Page : BasePage
{
    public {PageName}Page(IPage page) : base(page) { }

    // Example method — all methods must be async Task with Async suffix
    public async Task Fill{FieldName}Async(string value)
    {
        await Page.GetByTestId("{testid}").FillAsync(value);
    }
}
```

## Rules
- Always inherit from `BasePage`
- Constructor takes only `IPage page` — no other parameters
- All methods are `async Task` (never `void` or synchronous)
- Method names always end in `Async`
- Use Playwright locator methods in this order of preference:
  1. `GetByTestId("id")`
  2. `GetByRole(AriaRole.X, new() { Name = "label" })`
  3. `GetByText("visible text")`
  4. `Locator("css-or-xpath")`
- Call `WaitForSpinnerAsync()` after actions that trigger loading
- Call `ClickNextAsync()` / `ClickSaveAsync()` from BasePage for navigation buttons

## After Creating the File
Always remind the user to register the new page object in `Startup.cs` as a singleton:

```csharp
services.AddSingleton<{PageName}Page>();
```
