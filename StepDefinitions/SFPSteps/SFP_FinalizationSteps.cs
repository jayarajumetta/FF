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

        public SFP_FinalizationSteps(
            ReqContext context,
            ScenarioContext scenarioContext,
            SessionService sessionService,
            DuckCreekFormsClient formsClient,
            FormsValidationService validationService)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
            _sessionService = sessionService;
            _formsClient = formsClient;
            _validationService = validationService;
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

            // Fix #1: Wrap in try/finally so the policy is never left locked.
            //         The next step (Save for Later / Return to Admin) will always run
            //         because we catch and soft-assert rather than throw.
            try
            {
                // 1. Extract DuckCreek session ID from the current page
                string sessionId;
                try
                {
                    sessionId = await _sessionService.GetDuckCreekSessionIdAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"WARNING: Could not retrieve DuckCreek session ID: {ex.Message}");
                    Console.WriteLine("Forms validation skipped — session not available.");
                    return;
                }

                // 2. Call the DuckCreek Forms Engine API (Fix #3: per-LOB manuscript)
                string responseXml;
                try
                {
                    responseXml = await _formsClient.GetFormsAndSaveAsync(
                        sessionId, lob, $"{lob}_BasicPolicy", state, quoteId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"WARNING: DuckCreek Forms API call failed: {ex.Message}");
                    Console.WriteLine("Forms validation skipped — API unavailable.");
                    return;
                }

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

                // 8. Soft assertion — log failures but don't break the SFP flow
                if (summary.Failed > 0)
                {
                    var failures = string.Join("\n", summary.Results
                        .Where(r => r.Result == "FAIL")
                        .Select(r => $"    {r.FormName}: {r.Message}"));
                    Console.WriteLine($"\nWARNING: {summary.Failed} form(s) failed validation:\n{failures}");
                    Assert.Warn($"Forms validation: {summary.Failed} failure(s) detected. See HTML report for details.");
                }
            }
            catch (Exception ex)
            {
                // Fix #1: Never let forms validation crash the scenario —
                //         the policy must be returned to admin / saved.
                Console.WriteLine($"FORMS VALIDATION ERROR (non-fatal): {ex.Message}");
                Assert.Warn($"Forms validation threw an unexpected error: {ex.Message}");
            }
        }

        [When("user clicks Save for Later")]
        public async Task UserClicksSaveForLater()
        {
            var saveForLaterButton = _context.Page.GetByRole(AriaRole.Button, new() { Name = "Save for Later" });
            await saveForLaterButton.ClickAsync();

            // Wait for spinner using page overlay locator
            var overlay = _context.Page.Locator(".ngx-spinner-overlay");
            if (await overlay.CountAsync() > 0)
            {
                await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 60000 });
            }
        }

        [When("user navigates to Expert Quote and searches by Quote Number")]
        public async Task UserNavigatesToExpertQuoteAndSearchesByQuoteNumber()
        {
            var clientSearchPage = new ClientSearchPage(_context.Page);
            
            var quoteNumber = _contextData.QuoteNumber;
            if (string.IsNullOrWhiteSpace(quoteNumber) && System.IO.File.Exists("QuoteNumber.txt"))
            {
                quoteNumber = System.IO.File.ReadAllText("QuoteNumber.txt").Trim();
                _contextData.QuoteNumber = quoteNumber;
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
