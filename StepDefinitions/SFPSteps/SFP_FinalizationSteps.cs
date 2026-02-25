using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
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

        public SFP_FinalizationSteps(ReqContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
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

            // TODO: Implement when SFP_MortgageeLossPayeePage is mapped
            Console.WriteLine("STUB: Add Mortgagee step - page needs to be mapped");
            Console.WriteLine($"  Name: {_contextData.MortgageeName}");
            Console.WriteLine($"  Address: {_contextData.MortgageeAddress}");
            await _context.Page.WaitForTimeoutAsync(500);
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

        [When("user validates Forms via Duckcreek")]
        public async Task UserValidatesFormsViaDuckcreek(Table table)
        {
            TableMappingHelpers.DuckcreekFormsFields(table, _contextData);

            // TODO: Implement Duckcreek integration
            Console.WriteLine("STUB: Duckcreek Forms validation - needs implementation");
            Console.WriteLine($"  Client: {_contextData.Client?.FirstName} {_contextData.Client?.LastName}");
            Console.WriteLine($"  State: {_contextData.Address?.State}");
            await _context.Page.WaitForTimeoutAsync(500);
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

        [When("user navigates to Submission and opens Checklist")]
        public async Task UserNavigatesToSubmissionAndOpensChecklist()
        {
            var submissionPage = new SubmissionPage(_context.Page);
            await submissionPage.WaitForSpinnerAsync();
            
            // TODO: Implement when Checklist locators are added to SubmissionPage
            Console.WriteLine("STUB: Open Checklist - SubmissionPage locators need mapping");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [Then("user verifies no referrals are needed")]
        public async Task UserVerifiesNoReferralsAreNeeded()
        {
            // TODO: Implement when referral locators are added to SubmissionPage
            Console.WriteLine("STUB: Verify no referrals - SubmissionPage locators need mapping");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [When("user completes Checklist item")]
        public async Task UserCompletesChecklistItem(Table table)
        {
            TableMappingHelpers.ChecklistItemFields(table, _contextData);

            // TODO: Implement when ChecklistPage is created
            Console.WriteLine($"STUB: Complete Checklist - {_contextData.ChecklistItemName}");
            Console.WriteLine($"  Action: {_contextData.ChecklistAction}");
            Console.WriteLine($"  Note: {_contextData.ChecklistNote}");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [When("user closes Checklist and confirms Update")]
        public async Task UserClosesChecklistAndConfirmsUpdate()
        {
            // TODO: Implement when ChecklistPage is created
            Console.WriteLine("STUB: Close Checklist and confirm update");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [Then("user verifies Transmit button is enabled on Submission page")]
        public async Task UserVerifiesTransmitButtonIsEnabled()
        {
            // TODO: Implement when Transmit button locator is added to SubmissionPage
            Console.WriteLine("STUB: Verify Transmit button enabled - SubmissionPage locators need mapping");
            await _context.Page.WaitForTimeoutAsync(500);
        }
    }
}
