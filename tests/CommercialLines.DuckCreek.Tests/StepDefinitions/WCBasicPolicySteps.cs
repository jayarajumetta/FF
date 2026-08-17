using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "WC Basic Policy")]
public sealed class WCBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public WCBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterBusinessClientInformationAsync6();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync6();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAJAXErrorCheckAsync6();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync10();
    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheAssociatedClientInfoAsync6();
    }

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToUnderwritingInfoScreenAsync3();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync13();
    }

    [Given(@"^I complete WC Specific Fields$")]
    [When(@"^I complete WC Specific Fields$")]
    [Then(@"^I complete WC Specific Fields$")]
    public async Task CompleteWCSpecificFieldsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteWCSpecificFieldsAsync2();
    }

    [Given(@"^I complete Estimated premium$")]
    [When(@"^I complete Estimated premium$")]
    [Then(@"^I complete Estimated premium$")]
    public async Task CompleteEstimatedPremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEstimatedPremiumAsync();
    }

    [Given(@"^I complete coverage Information$")]
    [When(@"^I complete coverage Information$")]
    [Then(@"^I complete coverage Information$")]
    public async Task CompleteCoverageInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCoverageInformationAsync();
    }

    [Given(@"^I complete Address 1$")]
    [When(@"^I complete Address 1$")]
    [Then(@"^I complete Address 1$")]
    public async Task CompleteAddress1Async()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAddress1Async();
    }

    [Given(@"^I complete rating Information$")]
    [When(@"^I complete rating Information$")]
    [Then(@"^I complete rating Information$")]
    public async Task CompleteRatingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRatingInformationAsync();
    }

    [Given(@"^I add Class Codes$")]
    [When(@"^I add Class Codes$")]
    [Then(@"^I add Class Codes$")]
    public async Task AddClassCodesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddClassCodesAsync();
    }

    [Given(@"^I navigate to Entity Schedule$")]
    [When(@"^I navigate to Entity Schedule$")]
    [Then(@"^I navigate to Entity Schedule$")]
    public async Task NavigateToEntityScheduleAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToEntityScheduleAsync();
    }

    [Given(@"^I complete endorsements$")]
    [When(@"^I complete endorsements$")]
    [Then(@"^I complete endorsements$")]
    public async Task CompleteEndorsementsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEndorsementsAsync();
    }

    [Given(@"^I complete WC UW Questions$")]
    [When(@"^I complete WC UW Questions$")]
    [Then(@"^I complete WC UW Questions$")]
    public async Task CompleteWCUWQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteWCUWQuestionsAsync();
    }

    [Given(@"^I navigate to Pricing Screen$")]
    [When(@"^I navigate to Pricing Screen$")]
    [Then(@"^I navigate to Pricing Screen$")]
    public async Task NavigateToPricingScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToPricingScreenAsync2();
    }

    [Given(@"^I verify Class Codes on Policy are Valid$")]
    [When(@"^I verify Class Codes on Policy are Valid$")]
    [Then(@"^I verify Class Codes on Policy are Valid$")]
    public async Task VerifyClassCodesOnPolicyAreValidAsync()
    {
        var page = new BusinessClassificationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyClassCodesOnPolicyAreValidAsync();
    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyPremiumAsync();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync5();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync9();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync9();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync9();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyValuesInPremiumFieldsAsync7();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationAsync7();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SignOutOfTheApplicationAsync10();
    }

}