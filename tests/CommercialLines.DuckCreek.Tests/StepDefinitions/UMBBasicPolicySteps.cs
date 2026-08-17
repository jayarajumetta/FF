using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Basic Policy")]
public sealed class UMBBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public UMBBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var data = _scenario.Get<ScenarioData>();
        data.GenerateRandom("PrimaryPhone_0041", "[0-9]{10}");
        data.GenerateRandom("FEIN_0044", "486[0-9]{6}");
        data.GenerateRandom("InspectionTelephone_0045", "[0-9]{10}");

        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.EnterBusinessClientInformationAsync5();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync5();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteAJAXErrorCheckAsync5();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationAsync9();
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
        await page.CompleteTheAssociatedClientInfoAsync5();
    }

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToUnderwritingInfoScreenAsync2();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredPolicyInformationAsync12();
    }

    [Given(@"^I complete required policy covg information$")]
    [When(@"^I complete required policy covg information$")]
    [Then(@"^I complete required policy covg information$")]
    public async Task CompleteRequiredPolicyCovgInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredPolicyCovgInformationAsync2();
    }

    [Given(@"^I add Commercial Auto Underlying LOB$")]
    [When(@"^I add Commercial Auto Underlying LOB$")]
    [Then(@"^I add Commercial Auto Underlying LOB$")]
    public async Task AddCommercialAutoUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddCommercialAutoUnderlyingLOBAsync2();
    }

    [Given(@"^I add General Liability Underlying LOB$")]
    [When(@"^I add General Liability Underlying LOB$")]
    [Then(@"^I add General Liability Underlying LOB$")]
    public async Task AddGeneralLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddGeneralLiabilityUnderlyingLOBAsync2();
    }

    [Given(@"^I add Businessowners Underlying LOB$")]
    [When(@"^I add Businessowners Underlying LOB$")]
    [Then(@"^I add Businessowners Underlying LOB$")]
    public async Task AddBusinessownersUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddBusinessownersUnderlyingLOBAsync2();
    }

    [Given(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [When(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [Then(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    public async Task AddSFP10LiabilityFarmUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddSFP10LiabilityFarmUnderlyingLOBAsync2();
    }

    [Given(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [When(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [Then(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    public async Task AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync2();
    }

    [Given(@"^I add Employers Liability Underlying LOB$")]
    [When(@"^I add Employers Liability Underlying LOB$")]
    [Then(@"^I add Employers Liability Underlying LOB$")]
    public async Task AddEmployersLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddEmployersLiabilityUnderlyingLOBAsync2();
    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredLocationInformationAsync4();
    }

    [Given(@"^I complete required commercial auto information$")]
    [When(@"^I complete required commercial auto information$")]
    [Then(@"^I complete required commercial auto information$")]
    public async Task CompleteRequiredCommercialAutoInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredCommercialAutoInformationAsync2();
    }

    [Given(@"^I complete required general liability information$")]
    [When(@"^I complete required general liability information$")]
    [Then(@"^I complete required general liability information$")]
    public async Task CompleteRequiredGeneralLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredGeneralLiabilityInformationAsync2();
    }

    [Given(@"^I complete required businessowners information$")]
    [When(@"^I complete required businessowners information$")]
    [Then(@"^I complete required businessowners information$")]
    public async Task CompleteRequiredBusinessownersInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBusinessownersInformationAsync2();
    }

    [Given(@"^I complete required employers liability information$")]
    [When(@"^I complete required employers liability information$")]
    [Then(@"^I complete required employers liability information$")]
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredEmployersLiabilityInformationAsync2();
    }

    [Given(@"^I complete required cpp information$")]
    [When(@"^I complete required cpp information$")]
    [Then(@"^I complete required cpp information$")]
    public async Task CompleteRequiredCppInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredCppInformationAsync2();
    }

    [Given(@"^I complete required sfp 10 information$")]
    [When(@"^I complete required sfp 10 information$")]
    [Then(@"^I complete required sfp 10 information$")]
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredSfp10InformationAsync2();
    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredEndorsementInformationAsync3();
    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredUnderwritingQuestionInformationAsync4();
    }

    [Given(@"^I navigate to Pricing Screen$")]
    [When(@"^I navigate to Pricing Screen$")]
    [Then(@"^I navigate to Pricing Screen$")]
    public async Task NavigateToPricingScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.NavigateToPricingScreenAsync();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync4();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddNotepadCommentAsync8();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredSubmissionInformationAsync8();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunStoplightAsync8();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyValuesInPremiumFieldsAsync6();
    }

    [Given(@"^I complete forms verification UMB$")]
    [When(@"^I complete forms verification UMB$")]
    [Then(@"^I complete forms verification UMB$")]
    public async Task CompleteFormsVerificationUMBAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationUMBAsync2();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationAsync9();
    }

}
