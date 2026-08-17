using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "CP Basic Policy")]
public sealed class CPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public CPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0045", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterBusinessClientInformationAsync4();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync4();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAJAXErrorCheckAsync4();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationAsync7();
    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("MiddleName_0057", "^[a-z]{1}$");
        data.GenerateRandom("LastName_0057", "^[a-z]{7}$");
        data.GenerateRandom("FirstName_0057", "^[a-z]{4}$");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteTheAssociatedClientInfoAsync4();
    }

    [Given(@"^I complete Underwriting Info from Client Screen$")]
    [When(@"^I complete Underwriting Info from Client Screen$")]
    [Then(@"^I complete Underwriting Info from Client Screen$")]
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteUnderwritingInfoFromClientScreenAsync3();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredPolicyInformationAsync10();
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunInsuranceScoreAsync4();
    }

    [Given(@"^I complete CP Fields$")]
    [When(@"^I complete CP Fields$")]
    [Then(@"^I complete CP Fields$")]
    public async Task CompleteCPFieldsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCPFieldsAsync();
    }

    [Given(@"^I complete mask Error Recovery$")]
    [When(@"^I complete mask Error Recovery$")]
    [Then(@"^I complete mask Error Recovery$")]
    public async Task CompleteMaskErrorRecoveryAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteMaskErrorRecoveryAsync2();
    }

    [Given(@"^I complete CP Fields for policy coverage$")]
    [When(@"^I complete CP Fields for policy coverage$")]
    [Then(@"^I complete CP Fields for policy coverage$")]
    public async Task CompleteCPFieldsForPolicyCoverageAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCPFieldsForPolicyCoverageAsync2();
    }

    [Given(@"^I complete CP Fields for location$")]
    [When(@"^I complete CP Fields for location$")]
    [Then(@"^I complete CP Fields for location$")]
    public async Task CompleteCPFieldsForLocationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCPFieldsForLocationAsync2();
    }

    [Given(@"^I complete CP Fields for building$")]
    [When(@"^I complete CP Fields for building$")]
    [Then(@"^I complete CP Fields for building$")]
    public async Task CompleteCPFieldsForBuildingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCPFieldsForBuildingAsync2();
    }

    [Given(@"^I add a Rating Group$")]
    [When(@"^I add a Rating Group$")]
    [Then(@"^I add a Rating Group$")]
    public async Task AddARatingGroupAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddARatingGroupAsync2();
    }

    [Given(@"^I complete Structure Questions$")]
    [When(@"^I complete Structure Questions$")]
    [Then(@"^I complete Structure Questions$")]
    public async Task CompleteStructureQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteStructureQuestionsAsync2();
    }

    [Given(@"^I add Addl Interests$")]
    [When(@"^I add Addl Interests$")]
    [Then(@"^I add Addl Interests$")]
    public async Task AddAddlInterestsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestsAsync2();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync3();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddNotepadCommentAsync6();
    }

    [Given(@"^I complete Property UW Questions$")]
    [When(@"^I complete Property UW Questions$")]
    [Then(@"^I complete Property UW Questions$")]
    public async Task CompletePropertyUWQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompletePropertyUWQuestionsAsync2();
    }

    [Given(@"^I sign in to Duck Creek$")]
    [When(@"^I sign in to Duck Creek$")]
    [Then(@"^I sign in to Duck Creek$")]
    public async Task SignInToDuckCreekAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekAsync5();
    }

    [Given(@"^I complete restart Edge Popup$")]
    [When(@"^I complete restart Edge Popup$")]
    [Then(@"^I complete restart Edge Popup$")]
    public async Task CompleteRestartEdgePopupAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRestartEdgePopupAsync5();
    }

    [Given(@"^I sign in to Duck Creek for logged in user$")]
    [When(@"^I sign in to Duck Creek for logged in user$")]
    [Then(@"^I sign in to Duck Creek for logged in user$")]
    public async Task SignInToDuckCreekForLoggedInUserAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekForLoggedInUserAsync5();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationAsync8();
    }

    [Given(@"^I sign in to Duck Creek for username$")]
    [When(@"^I sign in to Duck Creek for username$")]
    [Then(@"^I sign in to Duck Creek for username$")]
    public async Task SignInToDuckCreekForUsernameAsync()
    {
        var page = new LoginPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignInToDuckCreekForUsernameAsync5();
    }

    [Given(@"^I search by Desc$")]
    [When(@"^I search by Desc$")]
    [Then(@"^I search by Desc$")]
    public async Task SearchByDescAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SearchByDescAsync();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredSubmissionInformationAsync6();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunStoplightAsync6();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyValuesInPremiumFieldsAsync5();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationAsync5();
    }

}
