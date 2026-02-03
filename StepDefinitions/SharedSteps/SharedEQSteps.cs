using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TestAutomation.Pages.ExpertQuotePages;
using static Microsoft.Playwright.Assertions;
using ReqContext = Playwright_POC.Context.TestContext;


[Binding]

public class SharedEQSteps
{
    private readonly ReqContext _context;
    private readonly ScenarioContextData _contextData;
    private readonly CredentialsConfig _credentials;
    private readonly IConfiguration _configuration;

    public SharedEQSteps(ReqContext context, ScenarioContextData contextData, CredentialsConfig credentials, IConfiguration configuration)
    {
        _context = context;
        _contextData = contextData;
        _credentials = credentials;
        _configuration = configuration;
    }


    [StepDefinition("I enter valid credentials and Click LogIn")]
    public async Task EnterCredentialsAndLogin()
    {
        string username = _credentials.Username;
        string password = _credentials.Password;

        var loginPage = new ExpertQuoteLoginPage(_context.Page);
        await loginPage.LoginAsync(username, password);

        // Wait for login to complete and assert dashboard is visible
        await Expect(ClientSearchLocators.DashboardElement(_context.Page)).ToBeVisibleAsync();
    }



    [StepDefinition("user enters a name in the search field and clicks search")]
    public async Task UserEntersNameAndSearches(Table table)
    {
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        // Uncomment if you want to use the assertion
        // string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";
        // await clientSearchPage.AssertNameNotInTableAsync("table", clientName);
    }

    [StepDefinition("user enters a Random Name in the search field and clicks search")]
    public async Task UserEntersRandomNameAndSearches(Table table)
    {
        // Keep current mapping to _contextData
        TableMappingHelpers.ClientSearchFields(table, _contextData);

        // Replace tokens with generated values
        // Supports: {{firstName}} for first names; {{lastName}} for last names
        // Legacy tokens {{male}}, {{female}}, {{random}} still supported for backward compatibility
        if (string.Equals(_contextData.ClientFirstName, "{{firstName}}", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(_contextData.ClientFirstName, "{{male}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFirstName();

        if (string.Equals(_contextData.ClientFirstName, "{{female}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientFirstName = RandomGenerators.GenerateRandomFemaleFirstName();

        if (string.Equals(_contextData.ClientLastName, "{{lastName}}", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(_contextData.ClientLastName, "{{random}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientLastName = RandomGenerators.GenerateRandomLastName();

        // Build full name and perform the search
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
        var clientSearchPage = new ClientSearchPage(_context.Page);

        await clientSearchPage.EnterNameAndSearchAsync(name);

        // Keep follow-on format for assertions
        string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";


    }


    [StepDefinition("user clicks New Quote button")]
    public async Task UserClicksNewQuoteButton()
    {
        await ClientSearchLocators.NewQuoteButton(_context.Page).ClickAsync();
    }



    [StepDefinition("user enters client information and clicks search")]
    public async Task UserEntersClientInformationAndClicksSearch(Table table)
    {
        TableMappingHelpers.NewExistingClientFields(table, _contextData);

        // Replace tokens with generated values
        // Supports: {{randomDOB}} for DOB (21-65 years old), {{randomPhone}} for phone, {{randomEmail}} for email
        if (string.Equals(_contextData.ClientDOB, "{{randomDOB}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientDOB = RandomGenerators.GenerateRandomDOB();

        if (string.Equals(_contextData.ClientPhoneNumber, "{{randomPhone}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientPhoneNumber = RandomGenerators.GenerateRandomPhoneNumber();

        if (string.Equals(_contextData.ClientEmail, "{{randomEmail}}", StringComparison.OrdinalIgnoreCase))
            _contextData.ClientEmail = RandomGenerators.GenerateRandomEmail(_contextData.ClientFirstName, _contextData.ClientLastName);

        var newClientPage = new NewClientPage(_context.Page);

        await newClientPage.WaitForFirstNameInputAsync();
        await newClientPage.FillFirstNameAsync(_contextData.ClientFirstName);
        await newClientPage.FillLastNameAsync(_contextData.ClientLastName);
        await newClientPage.FillDOBAsync(_contextData.ClientDOB);
        await newClientPage.FillBestPhoneAsync(_contextData.ClientPhoneNumber);
        await newClientPage.FillEmailAsync(_contextData.ClientEmail);
        await newClientPage.ClickSearchAsync();
        await newClientPage.WaitForNextButtonAsync();
    }


    [StepDefinition("user selects Create New Client and clicks the Next button")]
    public async Task UserCreatesNewClientAndClicksNext()
    {
        await NewExistingClientSearchLocators.CreateNewClientButton(_context.Page).ClickAsync();
        await GlobalLocators.NextButton(_context.Page).ClickAsync();

        //Wait for the next page to load
        await _context.Page.WaitForLoadStateAsync(LoadState.Load);
        await AccountInformationConstLocators.PageHeader(_context.Page).WaitForAsync(new LocatorWaitForOptions { Timeout = 10000 });
    }


    [StepDefinition("user enters account owner information and clicks Next")]
    public async Task EnterAccountOwnerInfo(Table table)
    {
        TableMappingHelpers.AccountOwnerFields(table, _contextData);

        var accountInformationPage = new AccountOwnerInfoPage(_context.Page);

        // Modular, explicit calls for each logical segment:
        await accountInformationPage.WaitForPageReadyAsync();
        await accountInformationPage.ValidateAndFillNameFieldsAsync(_contextData);
        await accountInformationPage.ValidateAndFillContactFieldsAsync(_contextData);
        await accountInformationPage.SelectMaritalStatusAsync(_contextData.MaritalStatus);
        await accountInformationPage.FillAddressFieldsAsync(_contextData);
        await accountInformationPage.WaitForAddressDetailsAsync();
        await accountInformationPage.AnswerMailAndResidenceQuestionsAsync(_contextData);
        await accountInformationPage.ClickNextAsync();
    }

    [StepDefinition("user creates a new Billing Account and Submits payment")]
    public async Task UserCreatesBillingAccountAndSubmitsPaymentAsync(Table table)
    {
        TableMappingHelpers.BillingAccountFields(table, _contextData);

        var billingPage = new BillingPage(_context.Page);
        string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";

        await billingPage.ClickCreateNewBillingAccountAsync();
        await billingPage.SelectPrimaryPayerAsync(name);
        await billingPage.SelectPaymentTypeAsync(_contextData.PaymentType);
        await billingPage.WaitForPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.SelectPaymentPlanAsync(_contextData.PaymentPlan);
        await billingPage.WaitForPaymentDueDateInputAsync();
        await billingPage.EnterPaymentDueDateAsync(_contextData.PaymentDueDate);
        await billingPage.SelectPaymentAmountAsync(_contextData.PaymentAmount);
        await billingPage.SelectPaymentMethodAsync(_contextData.PaymentMethod);
        await billingPage.EnterCheckNumberAsync(_contextData.CheckNumber);
        await billingPage.SelectPaperlessCommunicationAsync(_contextData.Paperless);
        await billingPage.ClickNextAsync();
        billingPage.DisplayQuoteNumber(_contextData.QuoteNumber);
        System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber ?? "");
    }


    [StepDefinition("user captures the quote number")]
    public async Task UserCapturesTheQuoteNumber()
    {
        // Wait for the page to stabilize after quote creation
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        // Wait for the quote number element to be visible using Expect (has auto-retry)
        var quoteNumberLocator = _context.Page.Locator(GlobalLocators.QuoteNumber);
        await Expect(quoteNumberLocator).ToBeVisibleAsync(new() { Timeout = 15000 });
        
        // Read the full text which contains multiple lines (e.g., "PERSONAL AUTO\n(PA123456789)")
        var fullText = await quoteNumberLocator.InnerTextAsync();
        Console.WriteLine($"Raw Quote Label Text: '{fullText}'");
        
        // Split by newlines and look for the quote number pattern
        var lines = fullText.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        
        string rawQuoteNumber = string.Empty;
        
        // Look for a line that contains a quote number pattern (letters followed by numbers, or in parentheses)
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            // Quote numbers typically look like: (PA123456789) or PA123456789 or contain digits
            if (trimmed.Contains("(") || System.Text.RegularExpressions.Regex.IsMatch(trimmed, @"[A-Z]{2,}\d+"))
            {
                rawQuoteNumber = trimmed;
                break;
            }
        }
        
        // Fallback: if no pattern found, use the last line (often the quote number)
        if (string.IsNullOrEmpty(rawQuoteNumber) && lines.Length > 1)
        {
            rawQuoteNumber = lines[lines.Length - 1].Trim();
        }
        else if (string.IsNullOrEmpty(rawQuoteNumber))
        {
            rawQuoteNumber = fullText.Trim();
        }
        
        // Normalize: remove parentheses if present
        var normalized = rawQuoteNumber.Replace("(", "").Replace(")", "").Trim();
        
        if (string.IsNullOrWhiteSpace(normalized) || !System.Text.RegularExpressions.Regex.IsMatch(normalized, @"\d"))
        {
            throw new Exception($"Failed to capture a valid quote number. Raw text was: '{fullText}'");
        }
        
        _contextData.QuoteNumber = normalized;
        Console.WriteLine($"Captured Quote Number: {normalized}");
    }

    [StepDefinition("user searches for the captured quote and opens it for edit")]
    public async Task UserSearchesForCapturedQuoteAndOpensForEdit()
    {
        var quoteNumber = _contextData.QuoteNumber;
        
        if (string.IsNullOrWhiteSpace(quoteNumber))
            throw new Exception("No quote number was captured to search for.");

        // Handle browser "Leave site?" dialog if it appears
        _context.Page.Dialog += async (_, dialog) =>
        {
            Console.WriteLine($"Dialog appeared: {dialog.Type} - {dialog.Message}");
            await dialog.AcceptAsync();
        };

        // Navigate back to the Expert Quote search page using direct URL navigation
        var expertQuoteUrl = _configuration["Playwright:ExpertQuote"] ?? "https://expertquote-qa.americannational.com/expertquote/#/quote";
        
        try
        {
            await _context.Page.GotoAsync(expertQuoteUrl, new PageGotoOptions 
            { 
                Timeout = 30000,
                WaitUntil = WaitUntilState.DOMContentLoaded 
            });
        }
        catch (TimeoutException)
        {
            // If navigation times out, try accepting any dialogs and retry
            Console.WriteLine("Navigation timed out, retrying...");
            await _context.Page.GotoAsync(expertQuoteUrl, new PageGotoOptions 
            { 
                Timeout = 30000,
                WaitUntil = WaitUntilState.DOMContentLoaded 
            });
        }
        
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        // Wait for search input to be available using Expect with auto-retry
        await Expect(ClientSearchLocators.IndividualSearchField(_context.Page)).ToBeVisibleAsync(new() { Timeout = 20000 });
        
        var clientSearchPage = new ClientSearchPage(_context.Page);
        
        // Search for the quote by quote number
        await clientSearchPage.EnterNameAndSearchAsync(quoteNumber);
        
        // Wait for results to load
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        // Wait for results and click on the quote to open it
        var quoteResultLocator = _context.Page.Locator($"//td[contains(text(), '{quoteNumber}')] | //a[contains(text(), '{quoteNumber}')] | //*[contains(text(), '{quoteNumber}')]");
        await Expect(quoteResultLocator.First).ToBeVisibleAsync(new() { Timeout = 10000 });
        await quoteResultLocator.First.ClickAsync();
        
        // Wait for the quote to load
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        Console.WriteLine($"Opened quote: {quoteNumber}");
    }

    [StepDefinition("the recalled quote number equals the captured quote number")]
    public async Task TheRecalledQuoteNumberEqualsTheCapturedQuoteNumber()
    {
        // Wait for the quote number element
        await _context.Page.WaitForSelectorAsync(GlobalLocators.QuoteNumber, new() { Timeout = 10000 });
        
        // Read the full text and extract quote number (same logic as capture)
        var fullText = await _context.Page.InnerTextAsync(GlobalLocators.QuoteNumber);
        var lines = fullText.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var displayedRaw = lines.Length > 1 ? lines[1].Trim() : fullText.Trim();
        var displayedNormalized = displayedRaw.Replace("(", "").Replace(")", "").Trim();
        
        var expected = _contextData.QuoteNumber;
        
        if (!string.Equals(displayedNormalized, expected, StringComparison.OrdinalIgnoreCase))
            throw new Exception($"Quote number mismatch. Expected '{expected}', got '{displayedNormalized}'.");
        
        Console.WriteLine($"Quote number verified: {displayedNormalized}");
    }

    /// <summary>
    /// Normalizes a quote number by removing common prefixes and parentheses.
    /// Examples: "PERSONAL AUTO (PA-12345)" → "PA-12345"
    /// </summary>
    private static string NormalizeQuoteNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return string.Empty;

        var normalized = raw.Trim();

        // Remove common prefixes
        string[] prefixes = { "PERSONAL AUTO ", "SPECIAL FARM PACKAGE ", "BOP " };
        foreach (var prefix in prefixes)
        {
            if (normalized.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                normalized = normalized.Substring(prefix.Length);
                break;
            }
        }

        // Remove parentheses
        normalized = normalized.Replace("(", "").Replace(")", "").Trim();

        return normalized;
    }

    [StepDefinition("user closes the browser")]
    public async Task UserClosesTheBrowser()
    {
        // Close the browser context to clear the session
        var browserContext = _context.Page.Context;
        await browserContext.CloseAsync();
        Console.WriteLine("Browser context closed - session cleared");
    }

    [StepDefinition("user launches a new browser and logs in to Expert Quote")]
    public async Task UserLaunchesNewBrowserAndLogsInToExpertQuote()
    {
        // Create a new browser instance
        var browserFactory = new BrowserFactory();
        var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chromium";
        var browser = await browserFactory.GetBrowserAsync(browserType);
        
        // Create new context and page
        var newContext = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1900,
                Height = 1080
            }
        });
        
        var newPage = await newContext.NewPageAsync();
        newPage.SetDefaultTimeout(60000);
        newPage.SetDefaultNavigationTimeout(90000);
        
        // Update the test context with the new page
        _context.Page = newPage;
        Console.WriteLine("New browser instance created");
        
        // Navigate to Expert Quote
        var expertQuoteUrl = _configuration["Playwright:ExpertQuote"] ?? "https://expertquote-qa.americannational.com/expertquote/#/quote";
        await _context.Page.GotoAsync(expertQuoteUrl, new PageGotoOptions 
        { 
            Timeout = 30000,
            WaitUntil = WaitUntilState.Load 
        });
        
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Login with credentials
        await LoginLocators.LoginButton(_context.Page).WaitForAsync(new() { Timeout = 10000 });
        
        string username = _credentials.Username;
        string password = _credentials.Password;

        var loginPage = new ExpertQuoteLoginPage(_context.Page);
        await loginPage.LoginAsync(username, password);

        await Expect(ClientSearchLocators.DashboardElement(_context.Page)).ToBeVisibleAsync();
        Console.WriteLine("Logged in to Expert Quote with fresh session");
        
        // Wait for search page to be ready
        await ClientSearchLocators.IndividualSearchField(_context.Page).WaitForAsync(new() { Timeout = 20000 });
        Console.WriteLine("Search page is ready");
    }

    [StepDefinition("user verifies the quote exists in search results")]
    public async Task UserVerifiesTheQuoteExistsInSearchResults()
    {
        var quoteNumber = _contextData.QuoteNumber;
        
        if (string.IsNullOrWhiteSpace(quoteNumber))
            throw new Exception("No quote number was captured to verify.");

        var clientSearchPage = new ClientSearchPage(_context.Page);
        
        // Search for the quote by quote number
        await clientSearchPage.EnterNameAndSearchAsync(quoteNumber);
        
        // Wait for results to load
        await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        // Verify the quote appears in search results using Playwright Expect
        var quoteResultLocator = _context.Page.Locator($"//td[contains(text(), '{quoteNumber}')] | //a[contains(text(), '{quoteNumber}')] | //*[contains(text(), '{quoteNumber}')]");
        
        await Expect(quoteResultLocator.First).ToBeVisibleAsync();
        Console.WriteLine($"Quote '{quoteNumber}' verified in search results");
    }

}