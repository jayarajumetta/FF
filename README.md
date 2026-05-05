# PnC Test Automation Framework

A Playwright-based test automation framework for P&C (Property & Casualty) insurance applications using Reqnroll (SpecFlow) for BDD-style test scenarios.

## Table of Contents
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Running Tests](#running-tests)
- [Test Configuration](#test-configuration)
- [Data Tokens](#data-tokens)
- [Writing Tests](#writing-tests)
- [Best Practices](#best-practices)
- [LocatorScan Tool](#locatorscan-tool)
- [Troubleshooting](#troubleshooting)

---

## Tech Stack

| Component  | Version |      Purpose          |
|------------|---------|-----------------------|
| .NET       | 8.0     | Runtime               |
| Playwright | 1.57.0  | Browser automation    |
| Reqnroll   | 3.3.0   | BDD/Gherkin framework |
| NUnit      | 4.4.0   | Test runner           |

---

## Project Structure

```
PnC-TestAutomation/
├── Features/                    # Gherkin feature files
│   ├── BOP/                     # Business Owners Policy tests
│   ├── PA/                      # Personal Auto tests
│   └── SFP/                     # Special Farm Package tests
├── StepDefinitions/             # Step definition implementations
│   ├── SharedSteps/             # Reusable steps across all products
│   ├── BOPSteps/                # BOP-specific steps
│   ├── PASteps/                 # PA-specific steps
│   └── SFPSteps/                # SFP-specific steps
├── Pages/                       # Page Object Models (inherit BasePage)
│   ├── BasePage.cs              # Base class with common helpers
│   ├── ExpertQuotePages/        # Expert Quote application pages
│   ├── ExpressPages/            # Express application pages
│   └── ExpertServicePages/      # Expert Service pages
├── Models/                      # Domain data models
│   ├── AccountOwnerData.cs      # Account owner information
│   ├── QuoteDetailsData.cs      # Quote details
│   └── ...                      # Other domain models
├── Tools/                       # Development tools
│   └── LocatorScan/             # CDP-based locator scanner
├── Helpers/                     # Utility classes
│   ├── LoadingHelpers.cs        # Wait/sync helpers
│   ├── DateHelpers.cs           # Date token processing
│   ├── RandomGenerators.cs      # Random data generation
│   └── TableMappingHelpers.cs   # Gherkin table mapping
├── Hooks/                       # Test lifecycle hooks
│   └── TestHooks.cs             # Setup, teardown, tracing
├── Configuration/               # Config classes
├── Context/                     # Test context management
├── Services/                    # Navigation and API services
├── Docs/                        # Documentation
└── appsettings.json             # Environment configuration
```

---

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2026 or VS Code
- Playwright browsers installed

### Installation

1. **Clone the repository**
   ```powershell
   git clone <repository-url>
   cd PnC-TestAutomation
   ```

2. **Restore NuGet packages**
   ```powershell
   dotnet restore
   ```

3. **Install Playwright browsers**
   ```powershell
   pwsh bin/Debug/net8.0/playwright.ps1 install
   ```

4. **Configure credentials**
   
   Update `appsettings.json` with your environment URLs and credentials:
   ```json
   {
     "Playwright": {
       "ExpertQuote": "https://expertquote-qa.americannational.com/...",
       "QAExpress": "https://express-qa.americannational.com/..."
     },
     "Credentials": {
       "Username": "your-username",
       "Password": "your-password"
     }
   }
   ```

5. **Build the project**
   ```powershell
   dotnet build
   ```

---

## Running Tests

### Visual Studio Test Explorer (Recommended)
1. Open `Playwright_POC.sln` in Visual Studio
2. Build the solution (`Ctrl+Shift+B`)
3. Open Test Explorer (`Ctrl+E, T`)
4. Run all tests or filter by tags

### Command Line
```powershell
# Run all tests
dotnet test

# Run by tag
dotnet test --filter "Category=Smoke"
dotnet test --filter "Category=Regression"

# Run specific feature
dotnet test --filter "FullyQualifiedName~SFPSmoke"
```

### Tag Strategy
| Tag | Purpose | When to Run |
|-----|---------|-------------|
| `@Smoke` | Critical path tests | Every build |
| `@Regression` | Full test suite | Nightly/Release |
| `@DataGen` | Data generation tests | On-demand |
| `@WIP` | Work in progress | Exclude from CI |

---

## Test Configuration

### Timeouts
| Type | Value | Purpose |
|------|-------|---------|
| Element | 30 seconds | Accounts for Angular rendering |
| Navigation | 60 seconds | Handles slow page loads |

### Test Artifacts
- **Location:** `./TestResults/{timestamp}/{ScenarioName}/`
- **Retention:** 7 days (auto-cleanup)
- **Tracing:** Captured on failure only
- **Video:** Recorded on failure only

### Supported Browsers
Default is set in `appsettings.json` under `Playwright:BrowserType`.

For one-off runs, override via `BROWSER_TYPE` environment variable.

Supported values:
- `chrome`
- `edge`
- `chromium`
- `firefox`
- `webkit`

PowerShell examples:
```powershell
# One session on Edge
$env:BROWSER_TYPE = "edge"
dotnet test

# Switch to Chrome
$env:BROWSER_TYPE = "chrome"
dotnet test

# Clear override and use appsettings default
Remove-Item Env:BROWSER_TYPE
dotnet test
```

---

## Data Tokens

Use tokens in feature files for dynamic test data:

### Name & Contact
| Token | Description | Example Output |
|-------|-------------|----------------|
| `{{firstName}}` | Random first name | John |
| `{{lastName}}` | Random last name | Smith |
| `{{randomDOB}}` | Random DOB (21-65 yrs) | 01/15/1985 |
| `{{randomPhone}}` | US phone number | 555-123-4567 |
| `{{randomEmail}}` | Email address | john.smith@test.com |
| `{{randomSSN}}` | SSN format | 123-45-6789 |

### Dates
| Token | Description | Example Output |
|-------|-------------|----------------|
| `{{today}}` | Today's date | 02/03/2026 |
| `{{tomorrow}}` | Tomorrow's date | 02/04/2026 |
| `{{futureDate:+30d}}` | 30 days from now | 03/05/2026 |
| `{{pastDate:-7d}}` | 7 days ago | 01/27/2026 |

### Example Usage
```gherkin
And user enters a Random Name in the search field
  | Question  | Answer        |
  | FirstName | {{firstName}} |
  | LastName  | {{lastName}}  |

And user enters Quote Details
  | Question      | Answer              |
  | EffectiveDate | {{futureDate:+30d}} |
  | SSN           | {{randomSSN}}       |
```

---

## Writing Tests

### Feature File Structure
```gherkin
@UI @ExpertQuote
Feature: SFP Quote Creation

  @Smoke
  Scenario Outline: Create SFP Quote - <State>
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn
    And user enters a Random Name in the search field
      | Question  | Answer        |
      | FirstName | {{firstName}} |
      | LastName  | {{lastName}}  |
    And user clicks New Quote button
    # ... more steps
    Then user verifies the quote exists in search results

    Examples:
      | State     | Address       | City   | Zip   |
      | Minnesota | 115 S Main ST | Warren | 56762 |
```

### Gherkin Keywords
| Keyword | Purpose | Use For |
|---------|---------|---------|
| `Given` | Preconditions | Setup, navigation |
| `When` | Action | Primary action being tested |
| `And` | Continuation | Additional setup or actions |
| `Then` | Verification | Assertions only |

### Step Definitions
Use `[StepDefinition]` for maximum flexibility. Instantiate page objects with `_context.Page`:
```csharp
[StepDefinition("user clicks New Quote button")]
public async Task UserClicksNewQuoteButton()
{
    var clientSearchPage = new ClientSearchPage(_context.Page);
    await clientSearchPage.ClickNewQuoteAsync();
}
```

### Page Objects
All page objects inherit from `BasePage` which provides common helpers:
```csharp
public class ClientSearchPage : BasePage
{
    public ClientSearchPage(IPage page) : base(page) { }

    #region Locators
    private ILocator SearchInput => _page.GetByTestId("quoteSearchInput");
    private ILocator SearchButton => _page.GetByTestId("quoteSearchButton");
    private ILocator NewQuoteButton => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote" });
    #endregion

    public async Task SearchForClientAsync(string name)
    {
        await SearchInput.FillAsync(name);
        await SearchButton.ClickAsync();
        await WaitForSpinnerAsync();  // Inherited from BasePage
    }

    public async Task ClickNewQuoteAsync()
    {
        await NewQuoteButton.ClickAsync();
        await WaitForSpinnerAsync();
    }
}
```

### BasePage Helpers
All pages inherit these methods from `BasePage`:
| Method | Purpose |
|--------|--------|
| `WaitForSpinnerAsync()` | Wait for Angular loading spinner to disappear |
| `ClickNextAsync()` | Click the standard "Next" button |
| `ClickIfNotSelectedAsync(locator)` | Click only if not already selected |
| `_page` | Protected access to the Playwright IPage |

---

## Best Practices

### Locators
1. **Prefer `data-testid`** - Stable, developer-controlled
   ```csharp
   _page.GetByTestId("fields.account.grossIncome")
   ```

2. **Use Role as fallback** - Semantic and accessible
   ```csharp
   _page.GetByRole(AriaRole.Button, new() { Name = "Submit" })
   ```

3. **Avoid brittle selectors** - No complex XPath or CSS paths

### Assertions
Use Playwright's `Expect` for UI assertions (auto-retry built-in):
```csharp
// ✅ Good - auto-retries for up to 5 seconds
await Expect(element).ToBeVisibleAsync();
await Expect(element).ToHaveTextAsync("Expected Text");

// ❌ Avoid - no auto-retry
Assert.That(await element.IsVisibleAsync(), Is.True);
```

### Waits
Use the `LoadingHelpers` for Angular synchronization:
```csharp
await LoadingHelpers.WaitForAngularSpinnerAsync(page);
await LoadingHelpers.WaitForElementEnabledAsync(page, button);
await LoadingHelpers.FillAndTabAsync(page, input, "value");
```

---

## LocatorScan Tool

A CDP-based tool that scans live application pages and generates locator code.

### Setup
1. Start Chrome with remote debugging:
   ```powershell
   chrome --remote-debugging-port=9222
   ```
2. Navigate to the page you want to scan in Chrome

### Running the Scan
```powershell
# Use the 'scan' alias (defined in scan.runsettings)
scan

# Or run directly
dotnet test --settings scan.runsettings
```

### How It Works
1. Connects to Chrome via CDP (Chrome DevTools Protocol)
2. Scans visible elements for interactable controls
3. Generates C# locator code prioritized by stability:
   - **Gold**: `data-testid` → `GetByTestId()`
   - **Silver**: `aria-label` → `GetByRole()` with accessible name
   - **Bronze**: Angular Material components (mat-checkbox, mat-slide-toggle)
   - **Fallback**: Placeholder or label text

### Output
Generated files appear in:
```
TestResults/{date}/LocatorScan/
└── ExpertQuote_{PageSection}_{timestamp}_Locators.cs
```

### Features
- **Duplicate detection**: Skips locators already in repo
- **Semantic naming**: Extracts meaningful names from testIds
- **Hidden element inclusion**: Includes hidden elements if they have `data-testid`
- **Angular Material support**: Detects mat-select, mat-datepicker, mat-slide-toggle

---

## Troubleshooting

### Test Artifacts Location
Failed tests generate artifacts in:
```
TestResults/{timestamp}/{ScenarioName}/
├── trace.zip          # Playwright trace (view at trace.playwright.dev)
├── video.webm         # Screen recording
└── Step_*.png         # Screenshots
```

### Common Issues

| Issue | Solution |
|-------|----------|
| Timeout waiting for element | Check if `data-testid` is correct; use browser DevTools |
| Element not interactable | Add `WaitForElementEnabledAsync()` before click |
| Angular spinner blocking | Use `WaitForAngularSpinnerAsync()` |
| Test data expired | Use dynamic tokens (`{{futureDate:+30d}}`) |
| Flaky assertions | Migrate to Playwright `Expect()` |

### Viewing Traces
1. Go to [trace.playwright.dev](https://trace.playwright.dev)
2. Upload the `trace.zip` file from TestResults
3. Inspect DOM snapshots, network calls, and console logs

---

## Contributing

1. Create feature branch from `main`
2. Follow existing patterns for new pages/steps
3. Use `[StepDefinition]` attribute for step definitions
4. Add appropriate tags (`@Smoke`, `@Regression`)
5. Ensure tests pass locally before PR
6. Update documentation for new features

---

## Documentation

See [Docs/Framework-Configuration-Decisions.md](Docs/Framework-Configuration-Decisions.md) for detailed framework decisions and rationale.