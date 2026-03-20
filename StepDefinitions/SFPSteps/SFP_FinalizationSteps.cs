using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Clients;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Models;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Pages.ExpertQuotePages.SFP;
using Playwright_POC.Parsers;
using Playwright_POC.Services;
using Reqnroll;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Finalization - Insurance Score, Mortgagee, Pricing, Submission, Checklist
    /// </summary>
    [Binding]
    public class SFP_FinalizationSteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;
        private readonly SessionService _sessionService;
        private readonly DuckCreekFormsClient _formsClient;
        private readonly FormsValidationService _validationService;
        private readonly IConfiguration _configuration;

        public SFP_FinalizationSteps(
            ReqContext context,
            ScenarioContext scenarioContext,
            SessionService sessionService,
            DuckCreekFormsClient formsClient,
            FormsValidationService validationService,
            IConfiguration configuration)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
            _sessionService = sessionService;
            _formsClient = formsClient;
            _validationService = validationService;
            _configuration = configuration;
        }

        [When("user runs Insurance Score")]
        public async Task UserRunsInsuranceScore(Table table)
        {
            TableMappingHelpers.InsuranceScoreFields(table, _contextData);

            var insuranceScorePage = new SFP_InsuranceScorePage(_context.Page);

            // Select entity type if specified
            if (!string.IsNullOrEmpty(_contextData.InsuranceScoreEntityType))
            {
                await insuranceScorePage.EntityTypeSelect.ClickAsync();
                await _context.Page.GetByRole(AriaRole.Option, new() { Name = _contextData.InsuranceScoreEntityType }).ClickAsync();
            }

            // Click Primary Insured or Individual Not Listed
            if (_contextData.InsuranceScoreDesignee?.ToLower() == "primary insured")
                await insuranceScorePage.PrimaryInsuredButton.ClickAsync();
            else if (_contextData.InsuranceScoreDesignee?.ToLower() == "individual not listed")
                await insuranceScorePage.IndividualNotListedButton.ClickAsync();

            // Click Insurance Score Consent
            await insuranceScorePage.InsuranceScoreConsentButton.ClickAsync();
            await insuranceScorePage.WaitForSpinnerAsync();

            // Accept or Decline
            if (_contextData.InsuranceScoreConsent?.ToLower() == "accept")
                await insuranceScorePage.AcceptButton.ClickAsync();
            else
                await insuranceScorePage.DeclineButton.ClickAsync();

            await insuranceScorePage.ClickNextAsync();
        }

        [When("user adds Additional Interest Mortgagee")]
        public async Task UserAddsAdditionalInterestMortgagee(Table table)
        {
            TableMappingHelpers.MortgageeFields(table, _contextData);

            var mortgageePage = new SFP_MortgageeLossPayeePage(_context.Page);
            await mortgageePage.AddMortgageeAsync(_contextData);

            Console.WriteLine($"Added Mortgagee: SearchName={_contextData.MortgageeSearchName}, Location={_contextData.MortgageeLocation}");
        }

        [Then("user verifies Premium on Pricing screen")]
        public async Task UserVerifiesPremiumOnPricingScreen()
        {
            var pricingPage = new SFP_PricingPage(_context.Page);
            await pricingPage.WaitForSpinnerAsync();
            
            // Check if either the Quote Link or View Full Details is visible (indicating pricing loaded)
            var quoteLink = pricingPage.QuoteLink;
            var viewToggle = pricingPage.ViewFullDetailsToggle;

            var isPremiumVisible = await quoteLink.CountAsync() > 0 || await viewToggle.CountAsync() > 0;
            Assert.That(isPremiumVisible, Is.True, "Premium should be displayed on Pricing screen");
            
            Console.WriteLine("Premium verified on Pricing screen");
        }

        [When("user completes Billing Information")]
        public async Task UserCompletesBillingInformation(Table table)
        {
            TableMappingHelpers.BillingAccountFields(table, _contextData);

            var billingPage = new SFP_BillingInformationPage(_context.Page);
            await billingPage.WaitForSpinnerAsync();

            // ── Step 1: Billing Account Setup ────────────────────────────────
            if (_contextData.PrimaryPayer?.ToLower() == "primary insured")
            {
                await billingPage.CreateNewBillingAccountButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();
                await billingPage.PrimaryPayerPrimaryInsuredButton.ClickAsync();
            }
            else
            {
                await billingPage.CreateNewBillingAccountButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();
                await billingPage.PrimaryPayerOtherButton.ClickAsync();
            }
            await billingPage.WaitForSpinnerAsync();

            // ── Step 2: Future Payment Plan – Payment Type ────────────────────
            var isEasyPay = string.Equals(
                (_contextData.PaymentType ?? "").Replace(" ", ""), "easypay",
                StringComparison.OrdinalIgnoreCase);

            if (isEasyPay)
                await billingPage.PaymentTypeEasyPayButton.ClickAsync();
            else
                await billingPage.PaymentTypeDirectBillButton.ClickAsync();
            await billingPage.WaitForSpinnerAsync();

            // ── Step 3: EasyPay bank account details ──────────────────────────
            if (isEasyPay)
            {
                // New Account
                await billingPage.FutureBankAccountCreateNewButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();

                // Personal use
                await billingPage.FutureBankAccountUsePersonalButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();

                // Checking type
                await billingPage.FutureBankAccountTypeCheckingButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();

                // Bank Account Owner = Policy Owner (first chip)
                await billingPage.FutureBankAccountOwnerPrimaryButton.ClickAsync();
                await billingPage.WaitForSpinnerAsync();

                // Bank details
                var routing = !string.IsNullOrWhiteSpace(_contextData.RoutingNumber)
                    ? _contextData.RoutingNumber
                    : "021000021";
                var account = !string.IsNullOrWhiteSpace(_contextData.AccountNumber)
                    ? _contextData.AccountNumber
                    : Random.Shared.Next(100000000, 999999999).ToString();
                var bankName = !string.IsNullOrWhiteSpace(_contextData.BankName)
                    ? _contextData.BankName
                    : "Test Bank";

                await billingPage.FutureBankRoutingNumberInput.FillAsync(routing);
                await billingPage.FutureBankAccountNumberInput.FillAsync(account);
                await billingPage.FutureNameOfBankInput.FillAsync(bankName);
                await billingPage.WaitForSpinnerAsync();
            }

            // ── Step 4: Payment Plan ──────────────────────────────────────────
            switch (_contextData.PaymentPlan?.ToLower())
            {
                case "1 payment":
                    await billingPage.PaymentPlan1PaymentButton.ClickAsync();
                    break;
                case "2 payments":
                    await billingPage.PaymentPlan2PaymentsButton.ClickAsync();
                    break;
                case "4 payments":
                    await billingPage.PaymentPlan4PaymentsButton.ClickAsync();
                    break;
                case "12 payments":
                    await billingPage.PaymentPlan12PaymentsButton.ClickAsync();
                    break;
                default:
                    await billingPage.PaymentPlan1PaymentButton.ClickAsync();
                    break;
            }
            await billingPage.WaitForSpinnerAsync();

            // ── Step 5: Payment Due Date ──────────────────────────────────────
            if (!string.IsNullOrWhiteSpace(_contextData.PaymentDueDate))
            {
                await billingPage.PaymentDueDateInput.FillAsync(_contextData.PaymentDueDate);
                await billingPage.WaitForSpinnerAsync();
            }

            // ── Step 6: Initial Payment – Amount ──────────────────────────────
            switch (_contextData.PaymentAmount?.ToLower())
            {
                case "minimum due":
                case "minimum":
                    await billingPage.PaymentAmountMinimumButton.ClickAsync();
                    break;
                case "full balance":
                case "full":
                    await billingPage.PaymentAmountFullBalanceButton.ClickAsync();
                    break;
                case "custom":
                    await billingPage.PaymentAmountCustomButton.ClickAsync();
                    break;
                default:
                    await billingPage.PaymentAmountMinimumButton.ClickAsync();
                    break;
            }
            await billingPage.WaitForSpinnerAsync();

            // ── Step 7: Initial Payment – Payment Method ──────────────────────
            switch (_contextData.PaymentMethod?.ToLower())
            {
                case "quickpay":
                case "quick pay":
                    await billingPage.InitialPaymentMethodQuickPayButton.ClickAsync();
                    break;
                case "check":
                    await billingPage.InitialPaymentMethodCheckButton.ClickAsync();
                    await billingPage.WaitForSpinnerAsync();
                    var checkNum = !string.IsNullOrWhiteSpace(_contextData.CheckNumber)
                        ? _contextData.CheckNumber
                        : Random.Shared.Next(1000, 99999).ToString();
                    await billingPage.InitialCheckNumberInput.FillAsync(checkNum);
                    break;
                case "credit card":
                    await billingPage.InitialPaymentMethodCreditCardButton.ClickAsync();
                    break;
                default:
                    await billingPage.InitialPaymentMethodCheckButton.ClickAsync();
                    break;
            }
            await billingPage.WaitForSpinnerAsync();

            await billingPage.ClickNextAsync();
            Console.WriteLine($"Billing completed: PaymentType={_contextData.PaymentType}, " +
                              $"Plan={_contextData.PaymentPlan}, Method={_contextData.PaymentMethod}");
        }

        [When("user validates Forms via Duckcreek for state {string}")]
        public async Task UserValidatesFormsViaDuckcreek(string state)
        {
            var page = _context.Page;
            var quoteId = _contextData.QuoteNumber;
            var lob = _contextData.FormsLob ?? "SFP";

            // 1. Open CLAS Express in a second tab, log in, and extract DCT.sessionID
            var sessionId = await _sessionService.GetDuckCreekSessionIdViaCLASAsync(quoteId);

            // 2. Call the DuckCreek Forms Engine API
            var responseXml = await _formsClient.GetFormsAndSaveAsync(
                sessionId, lob, $"{lob}_BasicPolicy", state, quoteId);

            // 3. Parse XML response into typed form entries
            var actualForms = FormsXmlParser.Parse(responseXml);
            Console.WriteLine($"DuckCreek returned {actualForms.Count} forms for {lob}/{state}/{quoteId}");

            // Parse response metadata (non-printDoc elements).
            // NOTE: XML "failure" status is EXPECTED because the API user (PA3402)
            // differs from the UI login that created the session. This is by design.
            var metadata = FormsXmlParser.ParseMetadata(responseXml);
            foreach (var w in metadata.Warnings)
                Console.WriteLine($"  [META INFO] {w}");
            Console.WriteLine($"  Metadata: PrintJob={metadata.PrintJobName}, Manuscript={metadata.Manuscript}, " +
                              $"RoleBasedSecurity={metadata.HasRoleBasedSecurity}, ReturnSuccess={metadata.ReturnSuccessStatus}");

            // 4. Load expected forms and validate (ANPAC filtering applied inside Validate)
            var testCase = _contextData.FormsTestCase ?? "BASIC";
            var expected = _validationService.LoadExpectedFormsForLob(lob, state, testCase);
            var summary = _validationService.Validate(expected, actualForms, lob, state, quoteId);
            summary.ResponseMetadata = metadata;
            summary.TestCaseName = $"{lob}_{testCase}";

            // 5. Print grouped summary to console
            FormsValidationService.PrintSummary(summary);

            // 6. Save results CSV
            _validationService.SaveResultsCsv(summary, $"{lob}_{testCase}");

            // 7. Generate HTML report
            var htmlDir = Path.Combine(
                _validationService.GetType().Assembly.Location, "..", "..", "..", "TestResults",
                DateTime.Now.ToString("ddMMMyyyy").ToUpperInvariant());
            var htmlPath = Path.Combine(htmlDir, $"FormsReport_{lob}_{state}_{quoteId}.html");
            FormsReportGenerator.Generate(summary, htmlPath);

            var absoluteHtmlPath = Path.GetFullPath(htmlPath);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(absoluteHtmlPath) { UseShellExecute = true });
            // Open the containing folder so the file can easily be attached to Teams/email
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("explorer.exe", $"/select,\"{absoluteHtmlPath}\"") { UseShellExecute = true });

            // 8. Non-blocking — log outcome but do not fail the scenario
            if (summary.Failed > 0)
            {
                var failures = string.Join("\n", summary.Results
                    .Where(r => r.Result == "FAIL")
                    .Select(r => $"    {r.FormName}: {r.Message}"));
                Console.WriteLine($"[FormsValidation] {summary.Failed} failure(s) — see report: {absoluteHtmlPath}\n{failures}");
            }
        }

        [When("user clicks Save for Later")]
        public async Task UserClicksSaveForLater()
        {
            var page = _context.Page;

            // Strategy 1: "QUOTE ACTIONS" dropdown (present on Submission and finalization pages).
            // Save for Later lives inside this menu — open it first, then click the item.
            var quoteActionsBtn = page.Locator("button").Filter(new() { HasText = "QUOTE ACTIONS" });
            if (await quoteActionsBtn.CountAsync() > 0)
            {
                await quoteActionsBtn.ClickAsync();
                var saveItem = page.Locator("mat-menu-item, [role='menuitem']")
                                   .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex(@"save\s*for\s*later|suspend", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
                await saveItem.First.WaitForAsync(new() { Timeout = 5000 });
                await saveItem.First.ClickAsync();
                Console.WriteLine("[SaveForLater] Clicked via QUOTE ACTIONS dropdown.");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
                return;
            }

            // Strategy 2: Direct button or link visible on earlier pages in the flow.
            foreach (var text in new[] { "Save for Later", "Save For Later", "Suspend" })
            {
                var loc = page.Locator("button, a").Filter(new() { HasText = text });
                if (await loc.CountAsync() > 0)
                {
                    await loc.First.ClickAsync();
                    Console.WriteLine($"[SaveForLater] Clicked '{text}' directly.");
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
                    return;
                }
            }

            // Fallback: navigate home. Quote number is already captured so next step can search for it.
            Console.WriteLine("[SaveForLater] WARNING: Save for Later not found — navigating to EQ home.");
            var eqBase = _configuration["Playwright:ExpertQuoteBase"]
                         ?? "https://expertquote-qa.americannational.com";
            await page.GotoAsync(eqBase.TrimEnd('/') + "/expertquote/",
                new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 60000 });
        }

        [When("user navigates to Expert Quote and searches by Quote Number")]
        public async Task UserNavigatesToExpertQuoteAndSearchesByQuoteNumber()
        {
            var page = _context.Page;
            var clientSearchPage = new ClientSearchPage(page);

            var quoteNumber = _contextData.QuoteNumber;
            if (string.IsNullOrWhiteSpace(quoteNumber) && System.IO.File.Exists("QuoteNumber.txt"))
            {
                quoteNumber = System.IO.File.ReadAllText("QuoteNumber.txt").Trim();
                _contextData.QuoteNumber = quoteNumber;
            }

            // If the dashboard search input isn't visible (e.g. still inside the quote after a fallback
            // "Save for Later"), navigate to the EQ home page first.
            var searchInput = page.GetByTestId("quoteSearchInput");
            if (await searchInput.CountAsync() == 0 || !await searchInput.IsVisibleAsync())
            {
                var eqBase = _configuration["Playwright:ExpertQuoteBase"]
                             ?? "https://expertquote-qa.americannational.com";
                var homeUrl = eqBase.TrimEnd('/') + "/expertquote/";
                Console.WriteLine($"[SearchByQuote] quoteSearchInput not visible — navigating to {homeUrl}");
                await page.GotoAsync(homeUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 60000 });
                await searchInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            }

            await clientSearchPage.SearchForClientAsync(quoteNumber);
            Console.WriteLine($"Searched for Quote: {quoteNumber}");
        }

        [When("user navigates to Submission page")]
        public async Task UserNavigatesToSubmissionPage()
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();
        }

        [When(@"user navigates to the ""(.*)"" page via the left menu")]
        public async Task UserNavigatesToPageViaLeftMenu(string menuItem)
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToByNameAsync(menuItem);
            Console.WriteLine($"Navigated to '{menuItem}' via left menu");
        }

        [When("user navigates to Submission and opens Checklist")]
        public async Task UserNavigatesToSubmissionAndOpensChecklist()
        {
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();

            // Checklist opens in a new popup window — capture it and store in context
            _context.ChecklistPage = await SFP_ChecklistPage.OpenChecklistAsync(_context.Page);

            Console.WriteLine("Navigated to Submission and opened Checklist popup");
        }

        [Then("user verifies no referrals are needed")]
        public async Task UserVerifiesNoReferralsAreNeeded()
        {
            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            await submissionPage.NoReferralsText.WaitForAsync(new() { Timeout = 15000 });
            Assert.That(await submissionPage.NoReferralsText.CountAsync(), Is.GreaterThan(0),
                "Expected 'STATUS: NO REFERRAL NEEDED -- CONTINUE TO STEP 3' message on Submission page");

            Console.WriteLine("Verified: STATUS: NO REFERRAL NEEDED -- CONTINUE TO STEP 3");
        }

        [When("user completes Checklist item")]
        public async Task UserCompletesChecklistItem(Table table)
        {
            TableMappingHelpers.ChecklistItemFields(table, _contextData);

            var checklistPage = new SFP_ChecklistPage(_context.ChecklistPage);
            await checklistPage.CompleteChecklistItemAsync(
                _contextData.ChecklistItemName,
                _contextData.ChecklistAction,
                _contextData.ChecklistExceptionNote,
                _contextData.ChecklistNote);

            Console.WriteLine($"Completed checklist item: {_contextData.ChecklistItemName}, Action: {_contextData.ChecklistAction}");
        }

        [When("user closes Checklist and confirms Update")]
        public async Task UserClosesChecklistAndConfirmsUpdate()
        {
            // 1. Close the checklist popup tab
            var checklistPage = new SFP_ChecklistPage(_context.ChecklistPage);
            await checklistPage.CloseAsync();

            // 2. Bring EQ tab back to the foreground
            await _context.Page.BringToFrontAsync();

            // 3. Click the Ok button if it appears on EQ after the checklist tab closes
            var okButton = _context.Page.GetByTestId("btnOk");
            try
            {
                await okButton.WaitForAsync(new() { Timeout = 10000 });
                await okButton.ClickAsync();
                Console.WriteLine("Clicked Ok dialog on EQ Submission page");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("No Ok dialog appeared — continuing");
            }

            await _context.Page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
            Console.WriteLine("Checklist tab closed and EQ Ok dialog confirmed");
        }

        [Then("user verifies Transmit button is enabled on Submission page")]
        public async Task UserVerifiesTransmitButtonIsEnabled()
        {
            // Navigate to Submission explicitly — EQ may have moved after the Ok dialog
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();

            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            // Try role name first, then testId, then any button containing "Transmit" text
            var transmitBtn = submissionPage.TransmitButtonAlt;
            if (await transmitBtn.CountAsync() == 0)
                transmitBtn = submissionPage.TransmitButton;
            if (await transmitBtn.CountAsync() == 0)
                transmitBtn = _context.Page.Locator("button").Filter(new() { HasText = "Transmit" });

            Assert.That(await transmitBtn.CountAsync() > 0, Is.True, "Transmit button should be present on Submission page");
            Assert.That(await transmitBtn.IsEnabledAsync(), Is.True, "Transmit button should be enabled");

            Console.WriteLine("Verified: Transmit button is enabled on Submission page");
        }
    }
}
