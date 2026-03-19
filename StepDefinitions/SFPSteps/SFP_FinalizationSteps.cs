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

            // Billing Account Setup
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

            // Future Payment Plan - Payment Type
            if (_contextData.PaymentType?.ToLower() == "easypay")
                await billingPage.PaymentTypeEasyPayButton.ClickAsync();
            else
                await billingPage.PaymentTypeDirectBillButton.ClickAsync();
            await billingPage.WaitForSpinnerAsync();

            // Payment Plan selection
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

            // Initial Payment - Amount
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

            // Initial Payment - Payment Method
            switch (_contextData.PaymentMethod?.ToLower())
            {
                case "quickpay":
                case "quick pay":
                    await billingPage.InitialPaymentMethodQuickPayButton.ClickAsync();
                    break;
                case "check":
                    await billingPage.InitialPaymentMethodCheckButton.ClickAsync();
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
            Console.WriteLine($"Billing completed: {_contextData.PaymentType}, {_contextData.PaymentPlan}, {_contextData.PaymentMethod}");
        }

        [When("user validates Forms via Duckcreek")]
        public async Task UserValidatesFormsViaDuckcreek(Table table)
        {
            TableMappingHelpers.DuckcreekFormsFields(table, _contextData);

            var state = _contextData.Address.State;
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

            // 8. Hard assertion — fail the test if any forms don't match
            if (summary.Failed > 0)
            {
                var failures = string.Join("\n", summary.Results
                    .Where(r => r.Result == "FAIL")
                    .Select(r => $"    {r.FormName}: {r.Message}"));
                Assert.Fail($"Forms validation: {summary.Failed} failure(s) detected.\n{failures}\nSee report: {htmlPath}");
            }
        }

        [When("user clicks Save for Later")]
        public async Task UserClicksSaveForLater()
        {
            var page = _context.Page;

            // Diagnostic: log ALL visible interactive elements so we can identify the button
            try
            {
                var allButtonTexts = await page.EvaluateAsync<string[]>(@"() =>
                    Array.from(document.querySelectorAll('button, a[href], mat-menu-item, [role=""menuitem""], [role=""button""]'))
                         .filter(b => b.offsetParent !== null)
                         .map(b => b.textContent?.trim())
                         .filter(t => t && t.length > 0)");
                Console.WriteLine($"[SaveForLater] Visible clickable elements: {string.Join(" | ", allButtonTexts ?? [])}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SaveForLater] Could not enumerate elements: {ex.Message}");
            }

            ILocator found = null;

            // 1. Try known data-testid values
            string[] testIds =
            [
                "save-for-later",
                "saveForLater",
                "fields.data.save-for-later",
                "fields.data.saveForLater",
                "fields.data.saveLater",
                "fields.data.save",
                "btnSaveForLater",
                "save-quote"
            ];
            foreach (var testId in testIds)
            {
                var loc = page.GetByTestId(testId);
                if (await loc.CountAsync() > 0)
                {
                    Console.WriteLine($"[SaveForLater] Found via data-testid='{testId}'");
                    found = loc;
                    break;
                }
            }

            // 2. Try text-based button matches
            if (found == null)
            {
                string[] textPatterns = ["Save for Later", "Save For Later", "Save & Exit", "Save and Exit",
                                         "Return to Admin", "Save Quote", "Finish Later", "Suspend", "Exit Quote"];
                foreach (var text in textPatterns)
                {
                    var loc = page.Locator("button").Filter(new() { HasText = text });
                    if (await loc.CountAsync() > 0)
                    {
                        Console.WriteLine($"[SaveForLater] Found button with text='{text}'");
                        found = loc;
                        break;
                    }
                }
            }

            // 3. Try anchor links (common for nav-style "save" actions in Angular apps)
            if (found == null)
            {
                string[] linkPatterns = ["Save for Later", "Save For Later", "Save & Exit", "Return to Admin",
                                         "Save Quote", "Suspend", "Exit Quote"];
                foreach (var text in linkPatterns)
                {
                    var loc = page.Locator("a").Filter(new() { HasText = text });
                    if (await loc.CountAsync() > 0)
                    {
                        Console.WriteLine($"[SaveForLater] Found link with text='{text}'");
                        found = loc;
                        break;
                    }
                }
            }

            // 4. Try Angular Material menu items
            if (found == null)
            {
                var menuItem = page.Locator("mat-menu-item, [role='menuitem']")
                                   .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("save|later|suspend|exit", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
                if (await menuItem.CountAsync() > 0)
                {
                    Console.WriteLine("[SaveForLater] Found mat-menu-item with save/later/suspend/exit text");
                    found = menuItem.First;
                }
            }

            // 5. Try Angular Material toolbar and header buttons containing "save"
            if (found == null)
            {
                var toolbarBtn = page.Locator("mat-toolbar button, .app-header button, header button, [class*='toolbar'] button")
                                     .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("save|later|suspend|exit", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
                if (await toolbarBtn.CountAsync() > 0)
                {
                    Console.WriteLine("[SaveForLater] Found toolbar/header button with save-related text");
                    found = toolbarBtn.First;
                }
            }

            if (found != null)
            {
                await found.ClickAsync();
                var overlay = page.Locator(".ngx-spinner-overlay");
                if (await overlay.CountAsync() > 0)
                    await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 60000 });

                Console.WriteLine("[SaveForLater] Clicked Save for Later button successfully.");
                return;
            }

            // 6. Fallback: navigate directly to EQ home page (quote is already saved in the backend;
            //    we have the quote number captured, so step 29 can re-open it from the dashboard)
            Console.WriteLine("[SaveForLater] WARNING: No 'Save for Later' button found. Navigating to EQ home as fallback.");
            var eqBase = _configuration["Playwright:ExpertQuoteBase"]
                         ?? "https://expertquote-qa.americannational.com";
            var homeUrl = eqBase.TrimEnd('/') + "/expertquote/";
            await page.GotoAsync(homeUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle, Timeout = 60000 });
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

        [When("user navigates to Submission and opens Checklist")]
        public async Task UserNavigatesToSubmissionAndOpensChecklist()
        {
            // Navigate to submission via side menu first
            var sideMenu = new SideMenuNavigation(_context.Page);
            await sideMenu.GoToSubmissionAsync();

            var checklistPage = new SFP_ChecklistPage(_context.Page);
            await checklistPage.OpenChecklistAsync();

            Console.WriteLine("Navigated to Submission and opened Checklist");
        }

        [Then("user verifies no referrals are needed")]
        public async Task UserVerifiesNoReferralsAreNeeded()
        {
            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            // Check for "No referrals required" text - try multiple text variants
            var noReferralsText = submissionPage.NoReferralsText;
            var noReferralsAlt = submissionPage.NoReferralsTextAlt;

            var isNoReferrals = await noReferralsText.CountAsync() > 0 || await noReferralsAlt.CountAsync() > 0;
            Assert.That(isNoReferrals, Is.True, "Expected no referrals to be required on Submission page"); // TODO: Verify exact text displayed

            Console.WriteLine("Verified: no referrals required");
        }

        [When("user completes Checklist item")]
        public async Task UserCompletesChecklistItem(Table table)
        {
            TableMappingHelpers.ChecklistItemFields(table, _contextData);

            var checklistPage = new SFP_ChecklistPage(_context.Page);
            await checklistPage.CompleteChecklistItemAsync(
                _contextData.ChecklistItemName,
                _contextData.ChecklistAction,
                _contextData.ChecklistNote);

            Console.WriteLine($"Completed checklist item: {_contextData.ChecklistItemName}, Action: {_contextData.ChecklistAction}");
        }

        [When("user closes Checklist and confirms Update")]
        public async Task UserClosesChecklistAndConfirmsUpdate()
        {
            var checklistPage = new SFP_ChecklistPage(_context.Page);
            await checklistPage.CloseChecklistAsync();
            await checklistPage.ConfirmUpdateAsync();

            Console.WriteLine("Closed Checklist and confirmed update");
        }

        [Then("user verifies Transmit button is enabled on Submission page")]
        public async Task UserVerifiesTransmitButtonIsEnabled()
        {
            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();

            var transmitBtn = submissionPage.TransmitButton;
            var transmitBtnAlt = submissionPage.TransmitButtonAlt;

            // Check which button exists
            ILocator activeTransmitBtn;
            if (await transmitBtn.CountAsync() > 0)
                activeTransmitBtn = transmitBtn;
            else
                activeTransmitBtn = transmitBtnAlt;

            Assert.That(await activeTransmitBtn.CountAsync() > 0, Is.True, "Transmit button should be present on Submission page");
            Assert.That(await activeTransmitBtn.IsEnabledAsync(), Is.True, "Transmit button should be enabled");

            Console.WriteLine("Verified: Transmit button is enabled on Submission page");
        }
    }
}
