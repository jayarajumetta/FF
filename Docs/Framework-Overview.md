# PnC Test Automation Framework Overview

## Tech Stack
| Component | Technology |
|-----------|------------|
| Language | C# / .NET 8 |
| Browser Automation | Microsoft Playwright |
| BDD Framework | Reqnroll (SpecFlow successor) |
| Test Runner | NUnit |
| DI Container | Microsoft.Extensions.DependencyInjection |

---

## Architecture Layers

```
┌─────────────────────────────────────────────────────────────┐
│                    Feature Files (.feature)                 │
│         Gherkin scenarios with DataTables                   │
└─────────────────────────────────────────────────────────────┘
                              ↓
┌─────────────────────────────────────────────────────────────┐
│                   Step Definitions                          │
│    Maps Gherkin steps to C# code                           │
│    Located in: StepDefinitions/{Product}Steps/             │
└─────────────────────────────────────────────────────────────┘
                              ↓
┌─────────────────────────────────────────────────────────────┐
│                      Page Objects                           │
│    Encapsulates UI elements and interactions               │
│    Located in: Pages/ExpertQuotePages/, Pages/ExpressPages │
└─────────────────────────────────────────────────────────────┘
                              ↓
┌─────────────────────────────────────────────────────────────┐
│                        Helpers                              │
│    Reusable utilities (dropdowns, waits, generators)       │
└─────────────────────────────────────────────────────────────┘
```

---

## Key Components

### 1. Dependency Injection (Startup.cs + DependencyInjection.cs)

```csharp
// DependencyInjection.cs - Reqnroll's entry point
[ScenarioDependencies]
public static IServiceCollection CreateServices()
{
    var services = new ServiceCollection();
    var startup = new Startup();
    startup.ConfigureServices(services);  // Calls your config
    return services;
}
```

**Services registered:**
- `IConfiguration` - loads `appsettings.json`
- `CredentialsConfig` - login credentials
- `BrowserFactory` - creates browser instances
- `TestContext` - holds IPage, HttpClient references
- `PingSecretProvider` - OAuth/secrets integration

### 2. Test Hooks (TestHooks.cs)

Controls test lifecycle:

| Hook | Purpose |
|------|---------|
| `[BeforeTestRun]` | Register global dependencies, create TestResults folder |
| `[BeforeScenario]` | Launch browser, create page, initialize `ScenarioContextData` |
| `[AfterScenario]` | Capture screenshots on failure, close browser |

```csharp
[BeforeScenario]
public async Task BeforeScenarioAsync()
{
    _browser = await _browserFactory.GetBrowserAsync("edge");
    _page = await _browser.NewPageAsync();
    _context.Page = _page;
    _scenarioContext["ContextData"] = new ScenarioContextData();
}
```

### 3. ScenarioContextData (Data Carrier)

Central object that flows through the entire scenario:

```csharp
public class ScenarioContextData
{
    // Domain models (preferred for new code)
    public ClientData Client { get; set; } = new();
    public AddressData Address { get; set; } = new();
    public PolicyData Policy { get; set; } = new();
    public FarmData Farm { get; set; } = new();
    // ... more models

    // Legacy properties (backward compatible, delegate to models)
    public string ClientFirstName { 
        get => Client.FirstName; 
        set => Client.FirstName = value; 
    }
}
```

### 4. BasePage (Page Object Base)

All page objects inherit from this:

```csharp
public abstract class BasePage
{
    protected readonly IPage _page;

    protected BasePage(IPage page) { _page = page; }

    // Common methods all pages can use
    public async Task WaitForSpinnerAsync(int timeoutMs = 60000);
    public async Task ClickNextAsync();  // Tries multiple button locators
    public async Task ClickSaveAsync();
}
```

### 5. TableMappingHelpers

Maps Gherkin DataTables to `ScenarioContextData`:

```csharp
// In feature file:
| Question  | Answer    |
| FirstName | John      |
| LastName  | Smith     |

// In helper:
public static void ClientSearchFields(Table table, ScenarioContextData data)
{
    foreach (var row in table.Rows)
    {
        switch (row["Question"])
        {
            case "FirstName": data.ClientFirstName = row["Answer"]; break;
            case "LastName":  data.ClientLastName = row["Answer"];  break;
        }
    }
}
```

---

## Data Flow Example

```
Feature File (SFPHappyPath.feature)
    │
    │  When user enters client information
    │      | Question  | Answer        |
    │      | FirstName | {{firstName}} |  ← Template placeholder
    │
    ▼
Step Definition (SharedEQSteps.cs)
    │
    │  [When("user enters client information")]
    │  public async Task EnterClientInfo(Table table)
    │  {
    │      TableMappingHelpers.ClientSearchFields(table, _contextData);
    │      await clientPage.EnterFirstName(_contextData.ClientFirstName);
    │  }
    │
    ▼
Page Object (NewClientPage.cs)
    │
    │  public async Task EnterFirstName(string name)
    │  {
    │      var input = _page.Locator("input[data-testid='firstName']");
    │      await input.FillAsync(name);
    │  }
    │
    ▼
Browser (Playwright IPage)
```

---

## Dynamic Data with Placeholders

The framework uses `{{placeholders}}` that get resolved at runtime:

| Placeholder | Resolved To |
|-------------|-------------|
| `{{firstName}}` | Random first name |
| `{{lastName}}` | Random last name |
| `{{randomDOB}}` | Random valid DOB |
| `{{randomPhone}}` | Random phone number |
| `{{tomorrow}}` | Tomorrow's date |
| `{{randomSSN}}` | Random SSN |

Resolved in `TestHooks.cs` or `RandomGenerators.cs`.

---

## Angular Material Handling

The app uses Angular Material components which need special handling:

```csharp
// Dropdown selection (mat-select)
public async Task SelectFeetFromHydrant(string value)
{
    var select = _page.Locator("mat-select[data-testid*='feetFromHydrant']");
    await select.ClickAsync();  // Open dropdown
    
    var option = _page.Locator(".cdk-overlay-pane mat-option")
                      .GetByText(value, new() { Exact = true });
    await option.ClickAsync();
}

// Toggle buttons (mat-button-toggle)
var btn = _page.GetByRole(AriaRole.Button, new() { Name = "Both" });
await btn.ClickAsync(new() { Force = true });
```

**Key patterns:**
- `mat-select` → Click to open, find option in `.cdk-overlay-pane`
- `mat-checkbox` → Use `.IsCheckedAsync()` before clicking
- Spinners → Wait for `.ngx-spinner-overlay` to hide

---

## Folder Structure

```
PnC-TestAutomation/
├── Features/                    # Gherkin .feature files
│   ├── BOP/
│   ├── PA/
│   └── SFP/
├── StepDefinitions/             # Step definition classes
│   ├── BOPSteps/
│   ├── PASteps/
│   ├── SFPSteps/
│   └── SharedSteps/             # Reusable steps across products
├── Pages/                       # Page Object Model
│   ├── BasePage.cs
│   ├── ExpertQuotePages/
│   │   ├── SFP/                 # SFP-specific pages
│   │   └── PA/                  # PA-specific pages
│   └── ExpressPages/
├── Helpers/                     # Utilities
│   ├── Helpers.cs               # Dropdown, button helpers
│   ├── ScenarioContextData.cs   # Test data container
│   ├── TableMappingHelpers.cs   # DataTable → Model mapping
│   ├── RandomGenerators.cs      # Random data generation
│   └── BrowserFactory.cs        # Browser instantiation
├── Models/                      # Data models
│   ├── ClientData.cs
│   ├── PolicyData.cs
│   └── FarmData.cs
├── Configuration/               # Config classes
├── Hooks/                       # Test lifecycle hooks
│   └── TestHooks.cs
├── Context/                     # Test context
│   └── TestContext.cs
└── appsettings.json             # Configuration
```

---

## Interview Quick Hits

1. **Why Playwright over Selenium?**
   - Auto-waits, better async support, built-in assertions, Trace Viewer

2. **Why Reqnroll?**
   - SpecFlow successor, better .NET 8 support, BDD with Gherkin

3. **Page Object Pattern benefits?**
   - Encapsulation, reusability, maintainability, single place to update locators

4. **How is test data managed?**
   - `ScenarioContextData` flows through scenario, populated via DataTables

5. **How to handle Angular Material?**
   - Direct locators on overlays (`.cdk-overlay-pane`), wait for spinners, force clicks when needed

---

## Common Playwright Patterns Used

### Locator Strategies
```csharp
// By data-testid (preferred)
_page.Locator("[data-testid='fieldName']")
_page.GetByTestId("fieldName")

// By role (accessibility)
_page.GetByRole(AriaRole.Button, new() { Name = "Save" })

// By text
_page.GetByText("Submit", new() { Exact = true })

// CSS selectors
_page.Locator("mat-select.my-class")
```

### Waiting Strategies
```csharp
// Wait for element state
await element.WaitForAsync(new() { State = WaitForSelectorState.Visible });

// Wait for spinner
await WaitForSpinnerAsync();

// Explicit timeout
await element.ClickAsync(new() { Timeout = 30000 });
```

### Assertions (built-in)
```csharp
using static Microsoft.Playwright.Assertions;

await Expect(element).ToBeVisibleAsync();
await Expect(element).ToHaveTextAsync("Expected Text");
await Expect(element).ToBeEnabledAsync();
```
