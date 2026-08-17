using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "BAP Basic Policy")]
public sealed class BAPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public BAPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("LastName_0040", "^[a-z]{4}$");
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("InsuredSSN", "125[0-9]{6}");
        data.GenerateRandom("AuditTelephone_0048", "[0-9]{10}");
        data.GenerateRandom("InspectionTelephone_0048", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterIndividualClientInformationAsync5();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredPolicyInformationAsync6();
    }

    [Given(@"^I complete Business Auto policy\\-specific fields$")]
    [When(@"^I complete Business Auto policy\\-specific fields$")]
    [Then(@"^I complete Business Auto policy\\-specific fields$")]
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        var page = new DiscountsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteBusinessAutoPolicySpecificFieldsAsync2();
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunInsuranceScoreAsync2();
    }

    [Given(@"^I complete underwriting information from the policy information screen$")]
    [When(@"^I complete underwriting information from the policy information screen$")]
    [Then(@"^I complete underwriting information from the policy information screen$")]
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        var page = new PolicyInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteUnderwritingInformationFromThePolicyInformationScreenAsync();
    }

    [Given(@"^I navigate to policy coverages$")]
    [When(@"^I navigate to policy coverages$")]
    [Then(@"^I navigate to policy coverages$")]
    public async Task NavigateToPolicyCoveragesAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToPolicyCoveragesAsync();
    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredLocationInformationAsync2();
    }

    [Given(@"^I navigate to state details$")]
    [When(@"^I navigate to state details$")]
    [Then(@"^I navigate to state details$")]
    public async Task NavigateToStateDetailsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToStateDetailsAsync();
    }

    [Given(@"^I complete vehicle information$")]
    [When(@"^I complete vehicle information$")]
    [Then(@"^I complete vehicle information$")]
    public async Task CompleteVehicleInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteVehicleInformationAsync();
    }

    [Given(@"^I complete driver information$")]
    [When(@"^I complete driver information$")]
    [Then(@"^I complete driver information$")]
    public async Task CompleteDriverInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteDriverInformationAsync();
    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredEndorsementInformationAsync2();
    }

    [Given(@"^I add endorsement$")]
    [When(@"^I add endorsement$")]
    [Then(@"^I add endorsement$")]
    public async Task AddEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddEndorsementAsync();
    }

    [Given(@"^I complete required additional\\-interest information$")]
    [When(@"^I complete required additional\\-interest information$")]
    [Then(@"^I complete required additional\\-interest information$")]
    public async Task CompleteRequiredAdditionalInterestInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredAdditionalInterestInformationAsync();
    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredUnderwritingQuestionInformationAsync2();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationAsync4();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddNotepadCommentAsync4();
    }

    [Given(@"^I verify premium$")]
    [When(@"^I verify premium$")]
    [Then(@"^I verify premium$")]
    public async Task VerifyPremiumAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyPremiumAsync();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredSubmissionInformationAsync4();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunStoplightAsync4();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyValuesInPremiumFieldsAsync3();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationAsync3();
    }

}
