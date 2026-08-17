using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Expanded")]
public sealed class BAPExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public BAPExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterIndividualClientInformationAsync7();
    }

    [Given(@"^I add Third Party Designee$")]
    [When(@"^I add Third Party Designee$")]
    [Then(@"^I add Third Party Designee$")]
    public async Task AddThirdPartyDesigneeAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddThirdPartyDesigneeAsync();
    }

    [Given(@"^I add Additional Named Insured$")]
    [When(@"^I add Additional Named Insured$")]
    [Then(@"^I add Additional Named Insured$")]
    public async Task AddAdditionalNamedInsuredAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAdditionalNamedInsuredAsync();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync11();
    }

    [Given(@"^I complete Business Auto policy\\-specific fields$")]
    [When(@"^I complete Business Auto policy\\-specific fields$")]
    [Then(@"^I complete Business Auto policy\\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteBusinessAutoPolicySpecificFieldsAsync3();
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunInsuranceScoreAsync5();
    }

    [Given(@"^I complete underwriting information from the policy information screen$")]
    [When(@"^I complete underwriting information from the policy information screen$")]
    [Then(@"^I complete underwriting information from the policy information screen$")]
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteUnderwritingInformationFromThePolicyInformationScreenAsync2();
    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToPolicyCoveragesAsync2();
    }

    [Given(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [When(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    [Then(@"^I complete cT StraightThrough Liability Limit to 1M$")]
    public async Task CompleteCTStraightThroughLiabilityLimitTo1MAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCTStraightThroughLiabilityLimitTo1MAsync();
    }

    [Given(@"^I add NonOwnership Liability$")]
    [When(@"^I add NonOwnership Liability$")]
    [Then(@"^I add NonOwnership Liability$")]
    public async Task AddNonOwnershipLiabilityAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNonOwnershipLiabilityAsync();
    }

    [Given(@"^I add Business Interruption$")]
    [When(@"^I add Business Interruption$")]
    [Then(@"^I add Business Interruption$")]
    public async Task AddBusinessInterruptionAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBusinessInterruptionAsync();
    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredLocationInformationAsync3();
    }

    [Given(@"^I add UM/UIM Coverage$")]
    [When(@"^I add UM/UIM Coverage$")]
    [Then(@"^I add UM/UIM Coverage$")]
    public async Task AddUMUIMCoverageAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddUMUIMCoverageAsync();
    }

    [Given(@"^I add Policy Level Coverages$")]
    [When(@"^I add Policy Level Coverages$")]
    [Then(@"^I add Policy Level Coverages$")]
    public async Task AddPolicyLevelCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddPolicyLevelCoveragesAsync();
    }

    [Given(@"^I add a Risk$")]
    [When(@"^I add a Risk$")]
    [Then(@"^I add a Risk$")]
    public async Task AddARiskAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddARiskAsync();
    }

    [Given(@"^I add Risk Level Interest$")]
    [When(@"^I add Risk Level Interest$")]
    [Then(@"^I add Risk Level Interest$")]
    public async Task AddRiskLevelInterestAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddRiskLevelInterestAsync();
    }

    [Given(@"^I verify Risk Level Coverages$")]
    [When(@"^I verify Risk Level Coverages$")]
    [Then(@"^I verify Risk Level Coverages$")]
    public async Task VerifyRiskLevelCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyRiskLevelCoveragesAsync();
    }

    [Given(@"^I add Risk Level Coverages$")]
    [When(@"^I add Risk Level Coverages$")]
    [Then(@"^I add Risk Level Coverages$")]
    public async Task AddRiskLevelCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddRiskLevelCoveragesAsync();
    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteDriverInformationAsync2();
    }

    [Given(@"^I verify Mandatory Endorsements$")]
    [When(@"^I verify Mandatory Endorsements$")]
    [Then(@"^I verify Mandatory Endorsements$")]
    public async Task VerifyMandatoryEndorsementsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyMandatoryEndorsementsAsync();
    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddEndorsementAsync2();
    }

    [Given(@"^I add Addl Interest$")]
    [When(@"^I add Addl Interest$")]
    [Then(@"^I add Addl Interest$")]
    public async Task AddAddlInterestAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestAsync();
    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredUnderwritingQuestionInformationAsync3();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync8();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync7();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync7();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync7();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationAsync6();
    }

    [Given(@"^I complete save for Later/Return to Admin$")]
    [When(@"^I complete save for Later/Return to Admin$")]
    [Then(@"^I complete save for Later/Return to Admin$")]
    public async Task CompleteSaveForLaterReturnToAdminAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteSaveForLaterReturnToAdminAsync();
    }

}