# New Hire Onboarding Guide — PnC Test Automation

Welcome to the team. This guide gets you from zero to running and writing tests.
It assumes you know how to write C# but have **never used Playwright, Reqnroll, or BDD before**.

---

## Table of Contents

1. [What This Framework Does](#1-what-this-framework-does)
2. [Concepts You Need First (5-minute primers)](#2-concepts-you-need-first)
3. [Environment Setup](#3-environment-setup)
4. [Your First Test Run](#4-your-first-test-run)
5. [Reading the Code — A Guided Tour](#5-reading-the-code--a-guided-tour)
6. [How to Triage a Failed Test](#6-how-to-triage-a-failed-test)
7. [How to Add a Test](#7-how-to-add-a-test)
8. [Common Mistakes](#8-common-mistakes)
9. [How to Submit a PR](#9-how-to-submit-a-pr)
10. [Where to Get Help](#10-where-to-get-help)

---

## 1. What This Framework Does

This framework automates end-to-end tests for insurance quoting applications:

| App | What it is | URL |
|-----|-----------|-----|
| **ExpertQuote** | Web app where agents create quotes for SFP, BOP, and PA policies | `expertquote-qa.americannational.com` |
| **ExpertService** | Agent service portal | `expertservice.qa.americannational.com` |
| **Express (CLAS)** | Legacy forms and policy issuance system | `dcpqa.dnanico1.aniconet.com` |

The tests simulate an agent's workflow: log in → create a client → fill out a quote → answer underwriting questions → submit for issuance.

---

## 2. Concepts You Need First

### 2a. What is Playwright?

Playwright is a browser automation library. It lets C# code open a real Chrome/Edge browser, click buttons, fill forms, and read content — exactly the way a human would, but automated.

```csharp
// This is what Playwright code looks like:
await page.GetByTestId("submit-button").ClickAsync();
await page.GetByLabel("First Name").FillAsync("Jane");
await Expect(page.GetByText("Quote Created")).ToBeVisibleAsync();
```

**Key Playwright concepts you'll use daily:**

| Concept | What it is | Example |
|---------|-----------|---------|
| `IPage` | A browser tab | `_page.GotoAsync(url)` |
| `ILocator` | A "pointer" to an element — lazy, not resolved until you call an action | `_page.GetByTestId("next-btn")` |
| `GetByTestId` | Find element by `data-testid` HTML attribute — most stable selector | `_page.GetByTestId("fields.account.firstName")` |
| `GetByRole` | Find element by ARIA role + name | `_page.GetByRole(AriaRole.Button, new(){ Name = "Save" })` |
| `FillAsync` | Type into a text input | `locator.FillAsync("value")` |
| `ClickAsync` | Click an element | `locator.ClickAsync()` |
| `SelectOptionAsync` | Choose from a dropdown | `locator.SelectOptionAsync("Minnesota")` |
| `WaitForAsync` | Wait for an element to become visible / hidden | `locator.WaitForAsync(new(){ State = WaitForSelectorState.Visible })` |

**Important:** Locators are **lazy** — they don't search the DOM until you call an action like `.ClickAsync()`. This means you won't get an error from just *defining* a locator to a non-existent element.

### 2b. What is BDD / Gherkin / Reqnroll?

**BDD (Behavior-Driven Development)** means writing tests in plain English first, then wiring them to code.

**Gherkin** is the plain-English format:

```gherkin
Feature: Create SFP Quote

  Scenario: Agent creates a quote in Minnesota
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn
    And user clicks New Quote button
    Then user verifies the quote exists in search results
```

**Reqnroll** (a .NET port of SpecFlow/Cucumber) reads these `.feature` files and calls your C# methods for each line.

The connection looks like this:

```
Gherkin step:   "When I enter valid credentials and Click LogIn"
                           ↓ matched by
C# attribute:   [When("I enter valid credentials and Click LogIn")]
C# method body: { ... your automation code ... }
```

**Key Gherkin keywords:**

| Keyword | Meaning |
|---------|---------|
| `Given` | Set up a precondition (navigate, log in) |
| `When` | Perform the action being tested |
| `And` | Continue the previous step type |
| `Then` | Assert a result |
| `Scenario Outline` | A scenario template with examples table — runs once per row |
| `Examples:` | The data table for a `Scenario Outline` |

### 2c. What is a Page Object?

A Page Object is a C# class that represents one page in the application. It:
- Defines locators (pointers to UI elements) as private properties
- Exposes methods that represent actions a user can take on that page

```csharp
public class ClientSearchPage : BasePage
{
    public ClientSearchPage(IPage page) : base(page) { }

    // Locators — private, defined once
    private ILocator SearchInput => _page.GetByTestId("clientSearchInput");
    private ILocator NewQuoteButton => _page.GetByTestId("newQuoteButton");

    // Actions — public, used by step definitions
    public async Task SearchForClientAsync(string name)
    {
        await SearchInput.FillAsync(name);
        await SearchInput.PressAsync("Enter");
        await WaitForSpinnerAsync();  // inherited from BasePage
    }

    public async Task ClickNewQuoteAsync()
    {
        await NewQuoteButton.ClickAsync();
        await WaitForSpinnerAsync();
    }
}
```

This pattern keeps browser interaction code out of the step definitions, making both easier to maintain.

---

## 3. Environment Setup

### 3.1 Install tools

1. **Install .NET 8.0 SDK:** https://dotnet.microsoft.com/download
   Verify: `dotnet --version` should show `8.0.x`

2. **Install PowerShell 7+:**
   ```powershell
   winget install Microsoft.PowerShell
   ```

3. **Install VS Code or Visual Studio 2022+** (both work)

   VS Code extensions to install:
   - C# Dev Kit
   - .NET Install Tool
   - Playwright Test for VS Code (optional but helpful)

4. **Clone the repository:**
   ```powershell
   git clone https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_git/PnC-TestAutomation
   cd PnC-TestAutomation
   ```

### 3.2 Restore and build

```powershell
dotnet restore TestAutomation.csproj
dotnet build TestAutomation.csproj
```

The build should complete with 0 errors and 0 warnings.

### 3.3 Install Playwright browsers

This step downloads Chrome, Firefox, and WebKit binaries that Playwright controls. Run it once after cloning, and again after any Playwright version upgrade.

```powershell
pwsh bin/Debug/net8.0/playwright.ps1 install
```

### 3.4 Set credentials

`appsettings.json` contains only `"PLACEHOLDER"` values — **no real passwords are stored in the repository.**
You must set credentials as environment variables. Ask your team lead for the actual values.

```powershell
# Required for all UI tests
$env:EQ_USERNAME = "your-eq-username"
$env:EQ_PASSWORD = "your-eq-password"

# Required for Forms validation tests
$env:DUCKCREEK_PASSWORD = "your-duckcreek-password"
```

Environment variables only persist for the current PowerShell session. You will need to re-set them
each time you open a new terminal, or add them to your Windows user environment variables via
System Properties → Advanced → Environment Variables.

> 🚨 **If you see real usernames or passwords anywhere in `appsettings.json` or any tracked file,
> report it to the QA lead immediately. Do not use those credentials and do not commit anything
> that contains them.**

### 3.5 Verify everything works

```powershell
dotnet test TestAutomation.csproj --filter "Category=Smoke" --no-build
```

You should see a Chrome browser open, navigate to the login page, and start filling forms.

---

## 4. Your First Test Run

### Run one Smoke test

```powershell
dotnet test TestAutomation.csproj --filter "FullyQualifiedName~SFP_BasicPolicy"
```

Watch the browser. The test will:
1. Open Chrome
2. Navigate to ExpertQuote
3. Log in
4. Create a random client
5. Fill out a Special Farm Package quote through all workflow steps
6. Verify the quote was created

### Run in headless mode (no visible browser)

```powershell
$env:PLAYWRIGHT_HEADLESS = "true"
dotnet test TestAutomation.csproj --filter "Category=Smoke"
```

Useful for faster runs when you don't need to watch.

### See test results

After a run, open the `TestResults/` folder. For every **failed** scenario, you'll find:
- `trace.zip` — upload to https://trace.playwright.dev to replay the test step-by-step with DOM snapshots
- `Step__xxx.png` — screenshot at the point of failure
- A video file

For **passing** scenarios, only `pass-records.csv` is written (no artifacts).

---

## 5. Reading the Code — A Guided Tour

Open [Features/SFP/SFP_BasicPolicy.feature](../Features/SFP/SFP_BasicPolicy.feature) first.

### 5.1 Feature file

```gherkin
@SFP @ExpertQuote
Feature: SFP Basic Policy

  @Smoke
  Scenario Outline: SFP Basic Policy - <State>
    Given I navigate to the Expert Quote login page
    ...
    Examples:
      | State     | StateFull | ...
      | Minnesota | Minnesota | ...
```

- `@SFP @ExpertQuote` — feature-level tags inherited by all scenarios in this file
- `@Smoke` — run type tag on this specific scenario
- `Scenario Outline` + `Examples:` — this runs once per row in the examples table
- `<State>` in the scenario title is replaced by the column value from the examples table

### 5.2 Find a step definition

Click any step text in VS Code and press `F12` (Go to Definition), or search for the step text in the repo.

For example, `When I enter valid credentials and Click LogIn` is in [StepDefinitions/SharedSteps/SharedEQSteps.cs](../StepDefinitions/SharedSteps/SharedEQSteps.cs):

```csharp
[When("I enter valid credentials and Click LogIn")]
public async Task WhenIEnterValidCredentials()
{
    string username = _credentials.Username;
    string password = _credentials.Password;
    var loginPage = new ExpertQuoteLoginPage(_context.Page);
    await loginPage.LoginAsync(username, password);
    Assert.That(await loginPage.IsDashboardVisibleAsync(), Is.True);
    // ...
}
```

### 5.3 Follow into the page object

`ExpertQuoteLoginPage` is in [Pages/ExpertQuotePages/ExpertQuoteLoginPage.cs](../Pages/ExpertQuotePages/ExpertQuoteLoginPage.cs). It defines locators and action methods. Notice it inherits from `BasePage`.

### 5.4 Understand TestContext

`_context` is of type `TestContext` (in [Context/TestContext.cs](../Context/TestContext.cs)). It holds:
- `_context.Page` — the active Playwright `IPage` (the browser tab)
- `_context.HttpClient` — for API scenarios

It's created once per scenario by `TestHooks.BeforeScenario` and injected into every step class via the DI container.

### 5.5 Understand ScenarioContextData

`_contextData` holds all the data collected during a scenario — client name, address, quote number, etc.

It's stored in `ScenarioContext["ContextData"]` (Reqnroll's key-value bag for the current scenario) and retrieved in every step class constructor:

```csharp
_contextData = _scenarioContext["ContextData"] as ScenarioContextData;
```

When a step like `And user enters account owner information and clicks Next` fills in the `StreetAddress`, that value is stored in `_contextData.StreetAddress` and is available to any later step.

---

## 6. How to Triage a Failed Test

### Step 1 — Read the error message

In the Test Explorer or console output, find the step that failed and the exception message. Look for:
- `TimeoutException` → an element wasn't found or didn't change state
- `ArgumentException: Unknown question: ...` → a Gherkin table key isn't handled by `TableMappingHelpers`
- `AssertionException` → something was found but didn't match what was expected
- `InvalidOperationException: Page is not initialized` → browser setup failed in `BeforeScenario`

### Step 2 — Open the Playwright trace

1. Find the `trace.zip` in `TestResults/{timestamp}/{ScenarioName}/`
2. Go to https://trace.playwright.dev
3. Upload the zip
4. Click through each step — you can see exactly what the page looked like at each point

### Step 3 — Check for UI changes

The most common cause of a `TimeoutException` is that a `data-testid` attribute changed in a recent DuckCreek or ANi deployment.

1. Open the application manually and navigate to the failing page
2. Right-click the element → Inspect
3. Look for `data-testid="..."` in the HTML
4. Compare to the locator in the page object

If the testId changed, update the locator in the page object. If no `data-testid` exists, use the LocatorScan tool (see [README.md](../README.md#locatorscan)).

### Step 4 — Check for workflow changes

DuckCreek may have added a new required page or popup that the test doesn't handle. Signs:
- Test fails at a `ClickSaveAsync()` or `ClickNextAsync()` with a timeout
- The screenshot shows an unexpected modal or form

Check the SSN popup handling as a reference pattern (`SFP_PrimaryInsuredPage.SavePrimaryInsuredAsync()`).

### Step 5 — Run with `PauseOnFailure`

Temporarily set this in `appsettings.json` (local only — don't commit):
```json
"Debugging": {
  "PauseOnFailure": true
}
```
When running in **Debug mode** (VS: right-click test → Debug), the browser will pause when the test fails, leaving it open for inspection.

---

## 7. How to Add a Test

### Scenario: Adding a new step to an existing feature

1. Find the feature file in `Features/`
2. Add your step in Gherkin
3. Check if a matching step definition already exists in `SharedSteps/` or the LOB-specific steps
4. If not, add the step definition in the appropriate file
5. Add the page object method if needed

### Scenario: Adding a brand-new test scenario

1. Decide which feature file to add to (or create a new one if it's a different feature)
2. Write the Gherkin scenario with correct tags
3. Wire up steps as above
4. Run it locally: `dotnet test --filter "FullyQualifiedName~YourNewFeature"`

### Rules for new step definitions

- Place shared steps (cross-LOB) in `SharedSteps/SharedEQSteps.cs`
- Place LOB-specific steps in `SFPSteps/`, `BOPSteps/`, `PASteps/`
- Always construct page objects inline: `new SFP_XPage(_context.Page)`
- Retrieve context data from: `_scenarioContext["ContextData"] as ScenarioContextData`
- Use `{{randomXxx}}` tokens in feature tables — never hardcode real PII

### Rules for new page objects

- Inherit from `BasePage`
- Define all locators as private `ILocator` properties (lazy — no `await` needed in the property)
- Expose action methods as `public async Task`
- Call `WaitForSpinnerAsync()` after any action that triggers a page reload or Angular update
- File naming: match the page name, prefix with LOB for LOB-specific pages (`SFP_`, `PA_`, etc.)

---

## 8. Common Mistakes

| Mistake | Why it's wrong | What to do instead |
|---------|---------------|-------------------|
| Hardcoding credentials in `appsettings.json` | File is committed to git — credentials become visible to everyone and the build history | Use environment variables (see section 3.4) |
| Replacing a `"PLACEHOLDER"` value and committing it | Same risk as above | Set the env var; do not edit the placeholder |
| Injecting a page object from DI (e.g. constructor parameter `AccountOwnerInfoPage page`) | Page objects are registered as singletons but `IPage` is scenario-scoped — you will get a stale page reference after the first test | Construct page objects inline: `new AccountOwnerInfoPage(_context.Page)` |
| Using `Thread.Sleep()` or `Task.Delay()` to wait | Fragile — too short fails, too long wastes time | Use `WaitForSpinnerAsync()`, `WaitForAsync()`, or Playwright `Expect` |
| `IsVisibleAsync()` in a loop to wait | No auto-retry — will burn CPU and still fail | Use `locator.WaitForAsync(new(){ State = WaitForSelectorState.Visible })` |
| Complex CSS selector like `div.container > ul > li:nth-child(3)` | Breaks on any layout change | Use `data-testid` or ARIA role |
| Writing assertions with `Assert.That(await locator.IsVisibleAsync(), Is.True)` | No auto-retry — flaky on slow renders | Use `await Expect(locator).ToBeVisibleAsync()` (auto-retries for 5 s) |
| Creating a page object in a `BeforeScenario` hook | Page doesn't exist yet | Create page objects inside step methods |
| Committing with tabs/trailing whitespace | Fails `.editorconfig` checks | Save in VS Code — it trims automatically. Run `dotnet format` before committing |
| Adding a scenario without tags | Won't be selected by any filter | Add at minimum `@Smoke` or `@Regression` + the LOB tag |
| Duplicating a step definition text | Reqnroll throws `AmbiguousMatchException` at runtime | Search for existing steps before adding new ones |

---

## 9. How to Submit a PR

1. **Create a feature branch from `Development`:**
   ```powershell
   git checkout Development
   git pull
   git checkout -b SFP_YourFeature
   ```

2. **Make your changes and commit:**
   ```powershell
   git add -A
   git commit -m "feat(SFP): add new coverage validation step"
   ```

3. **Run the build and format check:**
   ```powershell
   dotnet build TestAutomation.csproj
   dotnet format TestAutomation.csproj --verify-no-changes
   ```

4. **Run the relevant tests and confirm two consecutive passes:**
   ```powershell
   dotnet test TestAutomation.csproj --filter "Category=Smoke&Category=SFP"
   # Run it again
   dotnet test TestAutomation.csproj --filter "Category=Smoke&Category=SFP"
   ```

5. **Push and open a PR to `Development`:**
   ```powershell
   git push -u origin SFP_YourFeature
   ```
   Then open the PR in Azure DevOps.

6. **PR checklist:**
   - [ ] Build passes with 0 errors
   - [ ] `dotnet format --verify-no-changes` passes
   - [ ] New scenarios have correct tags
   - [ ] No secrets/credentials in any file
   - [ ] Two consecutive local passing runs

---

## 10. Where to Get Help

| Question | Who to ask |
|----------|-----------|
| Credentials / access | QA Lead |
| DuckCreek `data-testid` values changed | Use LocatorScan tool (README), or ask senior dev |
| Application workflow changed | Application team / business analyst |
| Framework question not answered here | Senior developer on the team |
| PR rejected — why? | See [Docs/Contractor-Guide.md](Contractor-Guide.md) for common reasons |

**Useful links:**
- [Playwright .NET docs](https://playwright.dev/dotnet/docs/intro)
- [Reqnroll docs](https://docs.reqnroll.net)
- [Playwright trace viewer](https://trace.playwright.dev)
- [ADO repo](https://dev.azure.com/ANCollection/PnC%20Test%20Automation/_git/PnC-TestAutomation)
