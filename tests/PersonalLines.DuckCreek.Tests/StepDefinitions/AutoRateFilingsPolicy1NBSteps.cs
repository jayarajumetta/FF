using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Auto Rate Filings Policy 1 NB")]
public sealed class AutoRateFilingsPolicy1NBSteps
{
    private readonly ScenarioContext _scenario;
    public AutoRateFilingsPolicy1NBSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start New Quote$")]
    [When(@"^I start New Quote$")]
    [Then(@"^I start New Quote$")]
    public async Task StartNewQuoteAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartNewQuoteAsync8();
    }

    [Given(@"^I select or create the policy client$")]
    [When(@"^I select or create the policy client$")]
    [Then(@"^I select or create the policy client$")]
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectOrCreateThePolicyClientAsync8();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAccountDetailsAsync8();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartThePolicyProposalAsync8();
    }

    [Given(@"^I complete prequalification$")]
    [When(@"^I complete prequalification$")]
    [Then(@"^I complete prequalification$")]
    public async Task CompletePrequalificationAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompletePrequalificationAsync6();
    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CaptureTheProposalNumberAsync8();
    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDriverInformationAsync6();
    }

    [Given(@"^I open the configured policy application$")]
    [When(@"^I open the configured policy application$")]
    [Then(@"^I open the configured policy application$")]
    public async Task OpenTheConfiguredPolicyApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenTheConfiguredPolicyApplicationAsync6();
    }

    [Given(@"^I approve Level 9B$")]
    [When(@"^I approve Level 9B$")]
    [Then(@"^I approve Level 9B$")]
    public async Task ApproveLevel9BAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ApproveLevel9BAsync6();
    }

    [Given(@"^I complete driver information for txt quote policy search$")]
    [When(@"^I complete driver information for txt quote policy search$")]
    [Then(@"^I complete driver information for txt quote policy search$")]
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDriverInformationForTxtQuotePolicySearchAsync6();
    }

    [Given(@"^I complete driver information for existing client 1$")]
    [When(@"^I complete driver information for existing client 1$")]
    [Then(@"^I complete driver information for existing client 1$")]
    public async Task CompleteDriverInformationForExistingClient1Async()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDriverInformationForExistingClient1Async6();
    }

    [Given(@"^I review the driver information summary$")]
    [When(@"^I review the driver information summary$")]
    [Then(@"^I review the driver information summary$")]
    public async Task ReviewTheDriverInformationSummaryAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ReviewTheDriverInformationSummaryAsync6();
    }

    [Given(@"^I review household\\-driver prefill results$")]
    [When(@"^I review household\\-driver prefill results$")]
    [Then(@"^I review household\\-driver prefill results$")]
    public async Task ReviewHouseholdDriverPrefillResultsAsync()
    {
        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ReviewHouseholdDriverPrefillResultsAsync6();
    }

    [Given(@"^I navigate using the policy side menu$")]
    [When(@"^I navigate using the policy side menu$")]
    [Then(@"^I navigate using the policy side menu$")]
    public async Task NavigateUsingThePolicySideMenuAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateUsingThePolicySideMenuAsync();
    }

    [Given(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [When(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [Then(@"^I complete vehicle Summary Automobile Rate Filing$")]
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteVehicleSummaryAutomobileRateFilingAsync3();
    }

    [Given(@"^I complete driver Assignment$")]
    [When(@"^I complete driver Assignment$")]
    [Then(@"^I complete driver Assignment$")]
    public async Task CompleteDriverAssignmentAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDriverAssignmentAsync6();
    }

    [Given(@"^I complete multiple Driver Assignment$")]
    [When(@"^I complete multiple Driver Assignment$")]
    [Then(@"^I complete multiple Driver Assignment$")]
    public async Task CompleteMultipleDriverAssignmentAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteMultipleDriverAssignmentAsync6();
    }

    [Given(@"^I complete claims/Violations$")]
    [When(@"^I complete claims/Violations$")]
    [Then(@"^I complete claims/Violations$")]
    public async Task CompleteClaimsViolationsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteClaimsViolationsAsync6();
    }

    [Given(@"^I complete editClaimsViolations$")]
    [When(@"^I complete editClaimsViolations$")]
    [Then(@"^I complete editClaimsViolations$")]
    public async Task CompleteEditClaimsViolationsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEditClaimsViolationsAsync6();
    }

    [Given(@"^I complete discount 1$")]
    [When(@"^I complete discount 1$")]
    [Then(@"^I complete discount 1$")]
    public async Task CompleteDiscount1Async()
    {
        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDiscount1Async6();
    }

    [Given(@"^I complete coverages$")]
    [When(@"^I complete coverages$")]
    [Then(@"^I complete coverages$")]
    public async Task CompleteCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCoveragesAsync6();
    }

    [Given(@"^I complete auto AddlCov policy coveragess$")]
    [When(@"^I complete auto AddlCov policy coveragess$")]
    [Then(@"^I complete auto AddlCov policy coveragess$")]
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAutoAddlCovPolicyCoveragessAsync6();
    }

    [Given(@"^I complete auto AddlCov PIP$")]
    [When(@"^I complete auto AddlCov PIP$")]
    [Then(@"^I complete auto AddlCov PIP$")]
    public async Task CompleteAutoAddlCovPIPAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAutoAddlCovPIPAsync6();
    }

    [Given(@"^I complete auto AddlCov Vehicle Coverages$")]
    [When(@"^I complete auto AddlCov Vehicle Coverages$")]
    [Then(@"^I complete auto AddlCov Vehicle Coverages$")]
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAutoAddlCovVehicleCoveragesAsync6();
    }

    [Given(@"^I complete auto AddlCov Next$")]
    [When(@"^I complete auto AddlCov Next$")]
    [Then(@"^I complete auto AddlCov Next$")]
    public async Task CompleteAutoAddlCovNextAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAutoAddlCovNextAsync6();
    }

    [Given(@"^I complete pricing and verify the premium$")]
    [When(@"^I complete pricing and verify the premium$")]
    [Then(@"^I complete pricing and verify the premium$")]
    public async Task CompletePricingAndVerifyThePremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompletePricingAndVerifyThePremiumAsync6();
    }

    [Given(@"^I complete underwriting Page Auto$")]
    [When(@"^I complete underwriting Page Auto$")]
    [Then(@"^I complete underwriting Page Auto$")]
    public async Task CompleteUnderwritingPageAutoAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteUnderwritingPageAutoAsync4();
    }

    [Given(@"^I complete additional Interest Page$")]
    [When(@"^I complete additional Interest Page$")]
    [Then(@"^I complete additional Interest Page$")]
    public async Task CompleteAdditionalInterestPageAsync()
    {
        var page = new AdditionalInterestsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAdditionalInterestPageAsync6();
    }

    [Given(@"^I configure direct\\-pay billing$")]
    [When(@"^I configure direct\\-pay billing$")]
    [Then(@"^I configure direct\\-pay billing$")]
    public async Task ConfigureDirectPayBillingAsync()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ConfigureDirectPayBillingAsync6();
    }

    [Given(@"^I complete the Level 9 underwriting bypass$")]
    [When(@"^I complete the Level 9 underwriting bypass$")]
    [Then(@"^I complete the Level 9 underwriting bypass$")]
    public async Task CompleteTheLevel9UnderwritingBypassAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheLevel9UnderwritingBypassAsync5();
    }

    [Given(@"^I open the configured policy application for openurl$")]
    [When(@"^I open the configured policy application for openurl$")]
    [Then(@"^I open the configured policy application for openurl$")]
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenTheConfiguredPolicyApplicationForOpenurlAsync6();
    }

    [Given(@"^I approve the underwriting referral in Express$")]
    [When(@"^I approve the underwriting referral in Express$")]
    [Then(@"^I approve the underwriting referral in Express$")]
    public async Task ApproveTheUnderwritingReferralInExpressAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ApproveTheUnderwritingReferralInExpressAsync5();
    }

    [Given(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [When(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    [Then(@"^I complete the Level 9 underwriting bypass for txt quote policy search$")]
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync5();
    }

    [Given(@"^I complete submission underwriting comments and review$")]
    [When(@"^I complete submission underwriting comments and review$")]
    [Then(@"^I complete submission underwriting comments and review$")]
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteSubmissionUnderwritingCommentsAndReviewAsync6();
    }

    [Given(@"^I open the configured policy application for 15 submission$")]
    [When(@"^I open the configured policy application for 15 submission$")]
    [Then(@"^I open the configured policy application for 15 submission$")]
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.OpenTheConfiguredPolicyApplicationFor15SubmissionAsync4();
    }

    [Given(@"^I complete the Express underwriting review$")]
    [When(@"^I complete the Express underwriting review$")]
    [Then(@"^I complete the Express underwriting review$")]
    public async Task CompleteTheExpressUnderwritingReviewAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheExpressUnderwritingReviewAsync6();
    }

    [Given(@"^I recall the quote in ExpertQuote$")]
    [When(@"^I recall the quote in ExpertQuote$")]
    [Then(@"^I recall the quote in ExpertQuote$")]
    public async Task RecallTheQuoteInExpertQuoteAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RecallTheQuoteInExpertQuoteAsync6();
    }

    [Given(@"^I complete the submission checklist$")]
    [When(@"^I complete the submission checklist$")]
    [Then(@"^I complete the submission checklist$")]
    public async Task CompleteTheSubmissionChecklistAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheSubmissionChecklistAsync6();
    }

    [Given(@"^I transmit the policy$")]
    [When(@"^I transmit the policy$")]
    [Then(@"^I transmit the policy$")]
    public async Task TransmitThePolicyAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.TransmitThePolicyAsync6();
    }

    [Given(@"^I verify policy transmission confirmation$")]
    [When(@"^I verify policy transmission confirmation$")]
    [Then(@"^I verify policy transmission confirmation$")]
    public async Task VerifyPolicyTransmissionConfirmationAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyPolicyTransmissionConfirmationAsync6();
    }

}