using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Cycle Rate Filings Policy 3 NB Prior Eff Date")]
public sealed class CycleRateFilingsPolicy3NBPriorEffDateSteps
{
    private readonly ScenarioContext _scenario;
    public CycleRateFilingsPolicy3NBPriorEffDateSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start New Quote$")]
    [When(@"^I start New Quote$")]
    [Then(@"^I start New Quote$")]
    public async Task StartNewQuoteAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.StartNewQuoteAsync4();
    }

    [Given(@"^I select or create the policy client$")]
    [When(@"^I select or create the policy client$")]
    [Then(@"^I select or create the policy client$")]
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SelectOrCreateThePolicyClientAsync4();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterAccountDetailsAsync4();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.StartThePolicyProposalAsync4();
    }

    [Given(@"^I complete prequalification$")]
    [When(@"^I complete prequalification$")]
    [Then(@"^I complete prequalification$")]
    public async Task CompletePrequalificationAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompletePrequalificationAsync2();
    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CaptureTheProposalNumberAsync4();
    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDriverInformationAsync2();
    }

    [Given(@"^I open the configured policy application$")]
    [When(@"^I open the configured policy application$")]
    [Then(@"^I open the configured policy application$")]
    public async Task OpenTheConfiguredPolicyApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenTheConfiguredPolicyApplicationAsync2();
    }

    [Given(@"^I approve Level 9B$")]
    [When(@"^I approve Level 9B$")]
    [Then(@"^I approve Level 9B$")]
    public async Task ApproveLevel9BAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ApproveLevel9BAsync2();
    }

    [Given(@"^I complete driver information for txt quote policy search$")]
    [When(@"^I complete driver information for txt quote policy search$")]
    [Then(@"^I complete driver information for txt quote policy search$")]
    public async Task CompleteDriverInformationForTxtQuotePolicySearchAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDriverInformationForTxtQuotePolicySearchAsync2();
    }

    [Given(@"^I complete driver information for existing client 1$")]
    [When(@"^I complete driver information for existing client 1$")]
    [Then(@"^I complete driver information for existing client 1$")]
    public async Task CompleteDriverInformationForExistingClient1Async()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDriverInformationForExistingClient1Async2();
    }

    [Given(@"^I review the driver information summary$")]
    [When(@"^I review the driver information summary$")]
    [Then(@"^I review the driver information summary$")]
    public async Task ReviewTheDriverInformationSummaryAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ReviewTheDriverInformationSummaryAsync2();
    }

    [Given(@"^I review household\\-driver prefill results$")]
    [When(@"^I review household\\-driver prefill results$")]
    [Then(@"^I review household\\-driver prefill results$")]
    public async Task ReviewHouseholdDriverPrefillResultsAsync()
    {
        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ReviewHouseholdDriverPrefillResultsAsync2();
    }

    [Given(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [When(@"^I complete vehicle Summary Automobile Rate Filing$")]
    [Then(@"^I complete vehicle Summary Automobile Rate Filing$")]
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteVehicleSummaryAutomobileRateFilingAsync();
    }

    [Given(@"^I complete driver Assignment$")]
    [When(@"^I complete driver Assignment$")]
    [Then(@"^I complete driver Assignment$")]
    public async Task CompleteDriverAssignmentAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDriverAssignmentAsync2();
    }

    [Given(@"^I complete multiple Driver Assignment$")]
    [When(@"^I complete multiple Driver Assignment$")]
    [Then(@"^I complete multiple Driver Assignment$")]
    public async Task CompleteMultipleDriverAssignmentAsync()
    {
        var page = new DriversPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteMultipleDriverAssignmentAsync2();
    }

    [Given(@"^I complete claims/Violations$")]
    [When(@"^I complete claims/Violations$")]
    [Then(@"^I complete claims/Violations$")]
    public async Task CompleteClaimsViolationsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteClaimsViolationsAsync2();
    }

    [Given(@"^I complete editClaimsViolations$")]
    [When(@"^I complete editClaimsViolations$")]
    [Then(@"^I complete editClaimsViolations$")]
    public async Task CompleteEditClaimsViolationsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteEditClaimsViolationsAsync2();
    }

    [Given(@"^I complete discount 1$")]
    [When(@"^I complete discount 1$")]
    [Then(@"^I complete discount 1$")]
    public async Task CompleteDiscount1Async()
    {
        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDiscount1Async2();
    }

    [Given(@"^I complete coverages$")]
    [When(@"^I complete coverages$")]
    [Then(@"^I complete coverages$")]
    public async Task CompleteCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCoveragesAsync2();
    }

    [Given(@"^I complete auto AddlCov policy coveragess$")]
    [When(@"^I complete auto AddlCov policy coveragess$")]
    [Then(@"^I complete auto AddlCov policy coveragess$")]
    public async Task CompleteAutoAddlCovPolicyCoveragessAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAutoAddlCovPolicyCoveragessAsync2();
    }

    [Given(@"^I complete auto AddlCov PIP$")]
    [When(@"^I complete auto AddlCov PIP$")]
    [Then(@"^I complete auto AddlCov PIP$")]
    public async Task CompleteAutoAddlCovPIPAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAutoAddlCovPIPAsync2();
    }

    [Given(@"^I complete auto AddlCov Vehicle Coverages$")]
    [When(@"^I complete auto AddlCov Vehicle Coverages$")]
    [Then(@"^I complete auto AddlCov Vehicle Coverages$")]
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAutoAddlCovVehicleCoveragesAsync2();
    }

    [Given(@"^I complete auto AddlCov Next$")]
    [When(@"^I complete auto AddlCov Next$")]
    [Then(@"^I complete auto AddlCov Next$")]
    public async Task CompleteAutoAddlCovNextAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAutoAddlCovNextAsync2();
    }

    [Given(@"^I complete pricing and verify the premium$")]
    [When(@"^I complete pricing and verify the premium$")]
    [Then(@"^I complete pricing and verify the premium$")]
    public async Task CompletePricingAndVerifyThePremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompletePricingAndVerifyThePremiumAsync2();
    }

    [Given(@"^I complete underwriting Page Cycle$")]
    [When(@"^I complete underwriting Page Cycle$")]
    [Then(@"^I complete underwriting Page Cycle$")]
    public async Task CompleteUnderwritingPageCycleAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteUnderwritingPageCycleAsync2();
    }

    [Given(@"^I complete additional Interest Page$")]
    [When(@"^I complete additional Interest Page$")]
    [Then(@"^I complete additional Interest Page$")]
    public async Task CompleteAdditionalInterestPageAsync()
    {
        var page = new AdditionalInterestsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAdditionalInterestPageAsync2();
    }

    [Given(@"^I configure direct\\-pay billing$")]
    [When(@"^I configure direct\\-pay billing$")]
    [Then(@"^I configure direct\\-pay billing$")]
    public async Task ConfigureDirectPayBillingAsync()
    {
        var page = new BillingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.ConfigureDirectPayBillingAsync2();
    }

    [Given(@"^I complete submission underwriting comments and review$")]
    [When(@"^I complete submission underwriting comments and review$")]
    [Then(@"^I complete submission underwriting comments and review$")]
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteSubmissionUnderwritingCommentsAndReviewAsync2();
    }

    [Given(@"^I open the configured policy application for openurl$")]
    [When(@"^I open the configured policy application for openurl$")]
    [Then(@"^I open the configured policy application for openurl$")]
    public async Task OpenTheConfiguredPolicyApplicationForOpenurlAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.OpenTheConfiguredPolicyApplicationForOpenurlAsync2();
    }

    [Given(@"^I complete the Express underwriting review$")]
    [When(@"^I complete the Express underwriting review$")]
    [Then(@"^I complete the Express underwriting review$")]
    public async Task CompleteTheExpressUnderwritingReviewAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteTheExpressUnderwritingReviewAsync2();
    }

    [Given(@"^I recall the quote in ExpertQuote$")]
    [When(@"^I recall the quote in ExpertQuote$")]
    [Then(@"^I recall the quote in ExpertQuote$")]
    public async Task RecallTheQuoteInExpertQuoteAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RecallTheQuoteInExpertQuoteAsync2();
    }

    [Given(@"^I complete the submission checklist$")]
    [When(@"^I complete the submission checklist$")]
    [Then(@"^I complete the submission checklist$")]
    public async Task CompleteTheSubmissionChecklistAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteTheSubmissionChecklistAsync2();
    }

    [Given(@"^I transmit the policy$")]
    [When(@"^I transmit the policy$")]
    [Then(@"^I transmit the policy$")]
    public async Task TransmitThePolicyAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.TransmitThePolicyAsync2();
    }

    [Given(@"^I verify policy transmission confirmation$")]
    [When(@"^I verify policy transmission confirmation$")]
    [Then(@"^I verify policy transmission confirmation$")]
    public async Task VerifyPolicyTransmissionConfirmationAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyPolicyTransmissionConfirmationAsync2();
    }

}
