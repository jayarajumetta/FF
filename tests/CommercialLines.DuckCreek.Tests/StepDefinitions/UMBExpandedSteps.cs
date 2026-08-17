using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "UMB Expanded")]
public sealed class UMBExpandedSteps
{
    private readonly ScenarioContext _scenario;
    public UMBExpandedSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterBusinessClientInformationAsync();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAJAXErrorCheckAsync();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync();
    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheAssociatedClientInfoAsync();
    }

    [Given(@"^I navigate to Underwriting Info Screen$")]
    [When(@"^I navigate to Underwriting Info Screen$")]
    [Then(@"^I navigate to Underwriting Info Screen$")]
    public async Task NavigateToUnderwritingInfoScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToUnderwritingInfoScreenAsync();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync();
    }

    [Given(@"^I complete required policy covg information$")]
    [When(@"^I complete required policy covg information$")]
    [Then(@"^I complete required policy covg information$")]
    public async Task CompleteRequiredPolicyCovgInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyCovgInformationAsync();
    }

    [Given(@"^I add Commercial Auto Underlying LOB$")]
    [When(@"^I add Commercial Auto Underlying LOB$")]
    [Then(@"^I add Commercial Auto Underlying LOB$")]
    public async Task AddCommercialAutoUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCommercialAutoUnderlyingLOBAsync();
    }

    [Given(@"^I add General Liability Underlying LOB$")]
    [When(@"^I add General Liability Underlying LOB$")]
    [Then(@"^I add General Liability Underlying LOB$")]
    public async Task AddGeneralLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddGeneralLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Businessowners Underlying LOB$")]
    [When(@"^I add Businessowners Underlying LOB$")]
    [Then(@"^I add Businessowners Underlying LOB$")]
    public async Task AddBusinessownersUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBusinessownersUnderlyingLOBAsync();
    }

    [Given(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [When(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    [Then(@"^I add SFP \\- 10 Liability Farm Underlying LOB$")]
    public async Task AddSFP10LiabilityFarmUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddSFP10LiabilityFarmUnderlyingLOBAsync();
    }

    [Given(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [When(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    [Then(@"^I add Commercial Package Policy Liability Underlying LOB$")]
    public async Task AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCommercialPackagePolicyLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Employers Liability Underlying LOB$")]
    [When(@"^I add Employers Liability Underlying LOB$")]
    [Then(@"^I add Employers Liability Underlying LOB$")]
    public async Task AddEmployersLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddEmployersLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Homeowner's Liability Underlying LOB$")]
    [When(@"^I add Homeowner's Liability Underlying LOB$")]
    [Then(@"^I add Homeowner's Liability Underlying LOB$")]
    public async Task AddHomeownerSLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddHomeownerSLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Motorcycle Liability Underlying LOB$")]
    [When(@"^I add Motorcycle Liability Underlying LOB$")]
    [Then(@"^I add Motorcycle Liability Underlying LOB$")]
    public async Task AddMotorcycleLiabilityUnderlyingLOBAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddMotorcycleLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Personal Auto Liability Underlying LOB$")]
    [When(@"^I add Personal Auto Liability Underlying LOB$")]
    [Then(@"^I add Personal Auto Liability Underlying LOB$")]
    public async Task AddPersonalAutoLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddPersonalAutoLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    [When(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    [Then(@"^I add Recreational Vehicle Liability Underlying LOB$")]
    public async Task AddRecreationalVehicleLiabilityUnderlyingLOBAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddRecreationalVehicleLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Rental Owner's Liability Underlying LOB$")]
    [When(@"^I add Rental Owner's Liability Underlying LOB$")]
    [Then(@"^I add Rental Owner's Liability Underlying LOB$")]
    public async Task AddRentalOwnerSLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddRentalOwnerSLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I add Watercraft Liability Underlying LOB$")]
    [When(@"^I add Watercraft Liability Underlying LOB$")]
    [Then(@"^I add Watercraft Liability Underlying LOB$")]
    public async Task AddWatercraftLiabilityUnderlyingLOBAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddWatercraftLiabilityUnderlyingLOBAsync();
    }

    [Given(@"^I complete required location information$")]
    [When(@"^I complete required location information$")]
    [Then(@"^I complete required location information$")]
    public async Task CompleteRequiredLocationInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredLocationInformationAsync();
    }

    [Given(@"^I complete required commercial auto information$")]
    [When(@"^I complete required commercial auto information$")]
    [Then(@"^I complete required commercial auto information$")]
    public async Task CompleteRequiredCommercialAutoInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredCommercialAutoInformationAsync();
    }

    [Given(@"^I complete required general liability information$")]
    [When(@"^I complete required general liability information$")]
    [Then(@"^I complete required general liability information$")]
    public async Task CompleteRequiredGeneralLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredGeneralLiabilityInformationAsync();
    }

    [Given(@"^I complete required businessowners information$")]
    [When(@"^I complete required businessowners information$")]
    [Then(@"^I complete required businessowners information$")]
    public async Task CompleteRequiredBusinessownersInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBusinessownersInformationAsync();
    }

    [Given(@"^I complete required sfp 10 information$")]
    [When(@"^I complete required sfp 10 information$")]
    [Then(@"^I complete required sfp 10 information$")]
    public async Task CompleteRequiredSfp10InformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSfp10InformationAsync();
    }

    [Given(@"^I complete required employers liability information$")]
    [When(@"^I complete required employers liability information$")]
    [Then(@"^I complete required employers liability information$")]
    public async Task CompleteRequiredEmployersLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredEmployersLiabilityInformationAsync();
    }

    [Given(@"^I complete required homeowners liability information$")]
    [When(@"^I complete required homeowners liability information$")]
    [Then(@"^I complete required homeowners liability information$")]
    public async Task CompleteRequiredHomeownersLiabilityInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredHomeownersLiabilityInformationAsync();
    }

    [Given(@"^I complete required motorcycle liability information$")]
    [When(@"^I complete required motorcycle liability information$")]
    [Then(@"^I complete required motorcycle liability information$")]
    public async Task CompleteRequiredMotorcycleLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredMotorcycleLiabilityInformationAsync();
    }

    [Given(@"^I complete required personal auto liability information$")]
    [When(@"^I complete required personal auto liability information$")]
    [Then(@"^I complete required personal auto liability information$")]
    public async Task CompleteRequiredPersonalAutoLiabilityInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPersonalAutoLiabilityInformationAsync();
    }

    [Given(@"^I complete required rental owners liability information$")]
    [When(@"^I complete required rental owners liability information$")]
    [Then(@"^I complete required rental owners liability information$")]
    public async Task CompleteRequiredRentalOwnersLiabilityInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredRentalOwnersLiabilityInformationAsync();
    }

    [Given(@"^I complete required cpp information$")]
    [When(@"^I complete required cpp information$")]
    [Then(@"^I complete required cpp information$")]
    public async Task CompleteRequiredCppInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredCppInformationAsync();
    }

    [Given(@"^I complete required watercraft liability information$")]
    [When(@"^I complete required watercraft liability information$")]
    [Then(@"^I complete required watercraft liability information$")]
    public async Task CompleteRequiredWatercraftLiabilityInformationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredWatercraftLiabilityInformationAsync();
    }

    [Given(@"^I complete required recreational vehicle information$")]
    [When(@"^I complete required recreational vehicle information$")]
    [Then(@"^I complete required recreational vehicle information$")]
    public async Task CompleteRequiredRecreationalVehicleInformationAsync()
    {
        var page = new VehiclesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredRecreationalVehicleInformationAsync();
    }

    [Given(@"^I complete required endorsement information$")]
    [When(@"^I complete required endorsement information$")]
    [Then(@"^I complete required endorsement information$")]
    public async Task CompleteRequiredEndorsementInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredEndorsementInformationAsync();
    }

    [Given(@"^I complete fill in CU2103 if it exists$")]
    [When(@"^I complete fill in CU2103 if it exists$")]
    [Then(@"^I complete fill in CU2103 if it exists$")]
    public async Task CompleteFillInCU2103IfItExistsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFillInCU2103IfItExistsAsync();
    }

    [Given(@"^I complete required underwriting question information$")]
    [When(@"^I complete required underwriting question information$")]
    [Then(@"^I complete required underwriting question information$")]
    public async Task CompleteRequiredUnderwritingQuestionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredUnderwritingQuestionInformationAsync();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync();
    }

    [Given(@"^I complete forms verification UMB$")]
    [When(@"^I complete forms verification UMB$")]
    [Then(@"^I complete forms verification UMB$")]
    public async Task CompleteFormsVerificationUMBAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationUMBAsync();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SignOutOfTheApplicationAsync();
    }

}