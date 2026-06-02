using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Configuration;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;

namespace Playwright_POC.StepDefinitions.SharedSteps
{
    [Binding]
    public partial class SharedEQSteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly CredentialsConfig _credentials;
        private readonly IConfiguration _configuration;
        private readonly ScenarioContext _scenarioContext;

        private static readonly char[] NewLineSeparator = ['\n'];

        public SharedEQSteps(ReqContext context, ScenarioContext scenarioContext, CredentialsConfig credentials, IConfiguration configuration)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
            _credentials = credentials;
            _configuration = configuration;
        }


        [When("I enter valid credentials and Click LogIn")]
        public async Task WhenIEnterValidCredentials()
        {
            string username = _credentials.Username;
            string password = _credentials.Password;

            var loginPage = new ExpertQuoteLoginPage(_context.Page);
            await loginPage.LoginAsync(username, password);

            // Wait for login to complete and assert dashboard is visible
            Assert.That(await loginPage.IsDashboardVisibleAsync(), Is.True);

            // Dev environment requires feature flags to be configured after login
            var env = _configuration["Environment"] ?? "QA";
            if (env.Equals("Dev", StringComparison.OrdinalIgnoreCase))
            {
                var flagsPage = new FeatureFlagsPage(_context.Page);
                await flagsPage.ConfigureDevEnvironmentAsync();
            }
        }



        [When("user enters a name in the search field and clicks search")]
        public async Task ThenUserEntersANameInTheSearchField(Table table)
        {
            TableMappingHelpers.ClientSearchFields(table, _contextData);

            string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
            var clientSearchPage = new ClientSearchPage(_context.Page);

            await clientSearchPage.SearchForClientAsync(name);

            // Uncomment if you want to use the assertion
            // string clientName = $"{_contextData.ClientLastName}, {_contextData.ClientFirstName}";
            //await clientSearchPage.AssertNameNotInTableAsync("table", clientName);
        }

        [When("user enters a Random Name in the search field and clicks search")]

        public async Task ThenUserEntersARandomNameInTheSearchField(Table table)
        {
            // Keep current mapping to _contextData
            TableMappingHelpers.ClientSearchFields(table, _contextData);

            // Replace tokens with generated values
            // Supports: {{firstName}}, {{male}}, {{female}} for first names; {{lastName}}, {{random}} for last names
            if (string.Equals(_contextData.ClientFirstName, "{{firstName}}", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(_contextData.ClientFirstName, "{{male}}", StringComparison.OrdinalIgnoreCase))
            {
                _contextData.ClientFirstName = RandomGenerators.GenerateRandomFirstName();
            }

            if (string.Equals(_contextData.ClientFirstName, "{{female}}", StringComparison.OrdinalIgnoreCase))
            {
                _contextData.ClientFirstName = RandomGenerators.GenerateRandomFemaleFirstName();
            }

            if (string.Equals(_contextData.ClientLastName, "{{lastName}}", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(_contextData.ClientLastName, "{{random}}", StringComparison.OrdinalIgnoreCase))
            {
                _contextData.ClientLastName = RandomGenerators.GenerateRandomLastName();
            }

            // Apply consistent automation naming so quote search results are easy to identify.
            // First: "PW <RandomFirst>", Last: "<Basic|CE> <RandomLast>"
            var firstNameBase = _contextData.ClientFirstName ?? string.Empty;
            if (firstNameBase.StartsWith("PW", StringComparison.OrdinalIgnoreCase))
                firstNameBase = firstNameBase[2..].TrimStart();

            var productLabel = GetScenarioProductLabel();
            _contextData.ClientFirstName = $"PW {firstNameBase.Trim()}";
            _contextData.ClientLastName = $"{productLabel} {_contextData.ClientLastName?.Trim()}";

            // Build full name and perform the search
            string name = $"{_contextData.ClientFirstName} {_contextData.ClientLastName}";
            var clientSearchPage = new ClientSearchPage(_context.Page);

            await clientSearchPage.SearchForClientAsync(name);

            // Log for diagnostics
            Console.WriteLine($"Client Name Is: {_contextData.ClientLastName}, {_contextData.ClientFirstName}");

        }


        [When("user clicks New Quote button")]
        public async Task ThenUserClicksNewQuoteButton()
        {
            var clientSearchPage = new ClientSearchPage(_context.Page);
            await clientSearchPage.ClickNewQuoteAsync();
            Console.WriteLine(_contextData.ClientFirstName);
        }



        [When("user enters client information and clicks search")]
        public async Task AndUserEntersClientInformationAndClicksSearch(Table table)
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
            // await newClientPage.WaitForNextButtonAsync();
            Console.WriteLine(_contextData.ClientFirstName);
        }


        [When("user selects Create New Client and clicks the Next button")]
        public async Task UserCreatesNewClientAndClicksNext()
        {
            var createNewClientChip = _context.Page.GetByText("Create New Client", new() { Exact = true });
            await createNewClientChip.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await createNewClientChip.ClickAsync();
            var clientSearchPage = new ClientSearchPage(_context.Page);
            // Wait for Next button to become enabled after chip selection
            await _context.Page.WaitForFunctionAsync("() => !document.querySelector('[data-testid*=\"next\"]')?.hasAttribute('disabled')");
            await clientSearchPage.ClickNextAsync();

            //Wait for the next page to load
            await _context.Page.WaitForLoadStateAsync(LoadState.Load);

            await _context.Page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true })
                .WaitForAsync(new() { Timeout = 15000 });
            Console.WriteLine(_contextData.ClientFirstName);
        }


        [When("user enters account owner information and clicks Next")]
        public async Task EnterAccountOwnerInfo(Table table)
        {
            TableMappingHelpers.AccountOwnerFields(table, _contextData);

            // Standardize middle name to the current state abbreviation (e.g., UT, AR).
            _contextData.ClientMiddleName = ToStateAbbreviation(_contextData.State);

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
            Console.WriteLine(_contextData.ClientFirstName);
        }

        private string GetScenarioProductLabel()
        {
            var tags = _scenarioContext?.ScenarioInfo?.Tags ?? Array.Empty<string>();
            if (tags.Any(t => t.Equals("CE", StringComparison.OrdinalIgnoreCase)))
                return "CE";

            var title = _scenarioContext?.ScenarioInfo?.Title ?? string.Empty;
            if (title.IndexOf("Country Estate", StringComparison.OrdinalIgnoreCase) >= 0)
                return "CE";

            return "Basic";
        }

        private static string ToStateAbbreviation(string state)
        {
            var value = (state ?? string.Empty).Trim();
            if (value.Length == 2)
                return value.ToUpperInvariant();

            return value.ToUpperInvariant() switch
            {
                "ALABAMA" => "AL",
                "ARKANSAS" => "AR",
                "ARIZONA" => "AZ",
                "COLORADO" => "CO",
                "IDAHO" => "ID",
                "IOWA" => "IA",
                "INDIANA" => "IN",
                "ILLINOIS" => "IL",
                "KANSAS" => "KS",
                "KENTUCKY" => "KY",
                "LOUISIANA" => "LA",
                "MINNESOTA" => "MN",
                "MONTANA" => "MT",
                "NEW MEXICO" => "NM",
                "NEBRASKA" => "NE",
                "NEVADA" => "NV",
                "NORTH DAKOTA" => "ND",
                "OKLAHOMA" => "OK",
                "OREGON" => "OR",
                "SOUTH CAROLINA" => "SC",
                "SOUTH DAKOTA" => "SD",
                "TENNESSEE" => "TN",
                "TEXAS" => "TX",
                "UTAH" => "UT",
                "WASHINGTON" => "WA",
                "WISCONSIN" => "WI",
                "WYOMING" => "WY",
                _ => value
            };
        }

        [When("user enters Pre-Qualification information and continues")]
        public async Task WhenUserEntersPreQualificationInfoAndContinuesAsync(Table table)
        {
            TableMappingHelpers.PreQualificationFields(table, _contextData);

            var preQualificationPage = new PreQualificationPage(_context.Page);
            await preQualificationPage.EnterPreQualificationInfoAndContinueAsync(_contextData.EligibilityRestrictions);
        }

        [When("user selects Primary Insured and continues")]
        public async Task UserSelectsPrimaryInsuredAsync()
        {
            var primaryInsuredPage = new SFP_PrimaryInsuredPage(_context.Page);
            // Select existing client and click Next
            await primaryInsuredPage.SelectExistingClientAsPrimaryInsuredAsync(_contextData);
            // Then Save on the Add Primary Insured page
            await primaryInsuredPage.SavePrimaryInsuredAsync();
        }



        [When("user creates a new Billing Account and Submits payment")]
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

        [When("user captures the quote number")]
        public async Task UserCapturesTheQuoteNumber()
        {
            // Primary: Get quote number from the SFP nav menu header (has data-testid)
            // Format: "SFP  (01945221)"
            var sfpNavLocator = _context.Page.GetByTestId("cl-sfp-nav");

            if (await sfpNavLocator.CountAsync() > 0)
            {
                var navText = await sfpNavLocator.InnerTextAsync();
                // Extract 8-digit quote number from parentheses: "SFP  (01945221)" -> "01945221"
                var match = QuoteNumberNavPattern().Match(navText);
                if (match.Success)
                {
                    _contextData.QuoteNumber = match.Groups[1].Value;
                    Console.WriteLine($"Captured Quote Number from nav: {_contextData.QuoteNumber}");
                    System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber);
                    return;
                }
            }

            // Fallback: Try the tab label (older UI structure)
            var tabLocator = _context.Page.Locator("[role='tab'] .mdc-tab__text-label span").First;
            if (await tabLocator.CountAsync() > 0)
            {
                var fullText = await tabLocator.InnerTextAsync();
                var lines = fullText.Split(NewLineSeparator, StringSplitOptions.RemoveEmptyEntries);
                var quoteNumber = lines.Length > 1 ? lines[1].Trim() : fullText.Trim();

                if (QuoteNumberTabPattern().IsMatch(quoteNumber))
                {
                    _contextData.QuoteNumber = quoteNumber;
                    Console.WriteLine($"Captured Quote Number from tab: {_contextData.QuoteNumber}");
                    System.IO.File.WriteAllText("QuoteNumber.txt", _contextData.QuoteNumber);
                    return;
                }
            }

            throw new Exception("Could not find quote number on page. Check UI for changes to cl-sfp-nav or tab labels.");
        }

        [When("user closes the browser")]
        public async Task UserClosesTheBrowser()
        {
            if (_context.Page != null)
            {
                var browserContext = _context.Page.Context;
                var browser = browserContext.Browser;

                try { await _context.Page.CloseAsync(); } catch { /* ignore */ }
                try { await browserContext.CloseAsync(); } catch { /* ignore */ }
                try { if (browser != null) await browser.CloseAsync(); } catch { /* ignore */ }

                _context.Page = null;
                Console.WriteLine("Browser closed successfully.");
            }
        }

        [When("user launches a new browser and logs in to Expert Quote")]
        public async Task UserLaunchesNewBrowserAndLogsInToExpertQuote()
        {
            // Launch new browser
            var browserFactory = new BrowserFactory(_configuration);
            var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chromium";
            var browser = await browserFactory.GetBrowserAsync(browserType);

            var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1900, Height = 1080 }
            });

            var page = await browserContext.NewPageAsync();
            page.SetDefaultTimeout(30000);
            page.SetDefaultNavigationTimeout(60000);

            _context.Page = page;

            // Navigate to Expert Quote
            var expertQuoteUrl = _configuration["Playwright:ExpertQuote"]
                ?? "https://expertquote-qa.americannational.com";
            await page.GotoAsync(expertQuoteUrl, new PageGotoOptions
            {
                Timeout = 90000,
                WaitUntil = WaitUntilState.NetworkIdle
            });

            // Login with credentials
            var loginPage = new ExpertQuoteLoginPage(page);
            await loginPage.LoginAsync(_credentials.Username, _credentials.Password);

            Assert.That(await loginPage.IsDashboardVisibleAsync(), Is.True, "Dashboard should be visible after login");
            Console.WriteLine("New browser launched and logged in successfully.");
        }

        [Then("user verifies the quote exists in search results")]
        public async Task UserVerifiesTheQuoteExistsInSearchResults()
        {
            // Read quote number from context or file
            var quoteNumber = _contextData.QuoteNumber;
            if (string.IsNullOrWhiteSpace(quoteNumber))
            {
                quoteNumber = System.IO.File.ReadAllText("QuoteNumber.txt").Trim();
                _contextData.QuoteNumber = quoteNumber;
            }

            Console.WriteLine($"Searching for quote: {quoteNumber}");

            var searchInput = _context.Page.GetByTestId("quoteSearchInput");
            await searchInput.FillAsync(quoteNumber);

            var searchButton = _context.Page.GetByRole(AriaRole.Button, new() { Name = "Search" });
            await searchButton.ClickAsync();

            // Wait for search results to populate
            await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Try multiple strategies to find the quote
            // Strategy 1: Link with quote number
            var quoteLocator = _context.Page.GetByRole(AriaRole.Link, new() { Name = quoteNumber });
            var isQuoteVisible = await quoteLocator.IsVisibleAsync();

            // Strategy 2: Cell or text containing quote number
            if (!isQuoteVisible)
            {
                var cellLocator = _context.Page.Locator($"td:has-text('{quoteNumber}'), span:has-text('{quoteNumber}')").First;
                isQuoteVisible = await cellLocator.IsVisibleAsync();
            }

            // Strategy 3: Any element containing the quote number
            if (!isQuoteVisible)
            {
                var anyLocator = _context.Page.GetByText(quoteNumber);
                isQuoteVisible = await anyLocator.IsVisibleAsync();
            }

            Assert.That(isQuoteVisible, Is.True, $"Quote {quoteNumber} should be visible in search results");
            Console.WriteLine($"Quote {quoteNumber} verified in search results.");
        }

        [GeneratedRegex(@"\((\d{8})\)")]
        private static partial Regex QuoteNumberNavPattern();

        [GeneratedRegex(@"^\d{8}$")]
        private static partial Regex QuoteNumberTabPattern();
    }
}
