using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "IM Basic Policy")]
public sealed class IMBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public IMBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterBusinessClientInformationAsync7();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync7();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAJAXErrorCheckAsync7();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync11();
    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheAssociatedClientInfoAsync7();
    }

    [Given(@"^I complete Underwring Questions from Client Screen$")]
    [When(@"^I complete Underwring Questions from Client Screen$")]
    [Then(@"^I complete Underwring Questions from Client Screen$")]
    public async Task CompleteUnderwringQuestionsFromClientScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteUnderwringQuestionsFromClientScreenAsync();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync14();
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunInsuranceScoreAsync6();
    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAccountsReceivableCoverageAsync2();
    }

    [Given(@"^I add Bailees Customers Coverage$")]
    [When(@"^I add Bailees Customers Coverage$")]
    [Then(@"^I add Bailees Customers Coverage$")]
    public async Task AddBaileesCustomersCoverageAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBaileesCustomersCoverageAsync2();
    }

    [Given(@"^I add Contractors Equipment$")]
    [When(@"^I add Contractors Equipment$")]
    [Then(@"^I add Contractors Equipment$")]
    public async Task AddContractorsEquipmentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddContractorsEquipmentAsync2();
    }

    [Given(@"^I add Computer Systems$")]
    [When(@"^I add Computer Systems$")]
    [Then(@"^I add Computer Systems$")]
    public async Task AddComputerSystemsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddComputerSystemsAsync2();
    }

    [Given(@"^I add Motor Truck Cargo$")]
    [When(@"^I add Motor Truck Cargo$")]
    [Then(@"^I add Motor Truck Cargo$")]
    public async Task AddMotorTruckCargoAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddMotorTruckCargoAsync2();
    }

    [Given(@"^I add Signs$")]
    [When(@"^I add Signs$")]
    [Then(@"^I add Signs$")]
    public async Task AddSignsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddSignsAsync2();
    }

    [Given(@"^I add Accounts Receivable$")]
    [When(@"^I add Accounts Receivable$")]
    [Then(@"^I add Accounts Receivable$")]
    public async Task AddAccountsReceivableAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAccountsReceivableAsync2();
    }

    [Given(@"^I add Bailees Customers$")]
    [When(@"^I add Bailees Customers$")]
    [Then(@"^I add Bailees Customers$")]
    public async Task AddBaileesCustomersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBaileesCustomersAsync2();
    }

    [Given(@"^I add Computer Systems for risk$")]
    [When(@"^I add Computer Systems for risk$")]
    [Then(@"^I add Computer Systems for risk$")]
    public async Task AddComputerSystemsForRiskAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddComputerSystemsForRiskAsync2();
    }

    [Given(@"^I add Signs for risk$")]
    [When(@"^I add Signs for risk$")]
    [Then(@"^I add Signs for risk$")]
    public async Task AddSignsForRiskAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddSignsForRiskAsync2();
    }

    [Given(@"^I add CM 66 01 Exclude Named Customer$")]
    [When(@"^I add CM 66 01 Exclude Named Customer$")]
    [Then(@"^I add CM 66 01 Exclude Named Customer$")]
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCM6601ExcludeNamedCustomerAsync2();
    }

    [Given(@"^I add IF 00 02 Waterborne Equipment$")]
    [When(@"^I add IF 00 02 Waterborne Equipment$")]
    [Then(@"^I add IF 00 02 Waterborne Equipment$")]
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddIF0002WaterborneEquipmentAsync2();
    }

    [Given(@"^I complete Accounts Receivable Questions$")]
    [When(@"^I complete Accounts Receivable Questions$")]
    [Then(@"^I complete Accounts Receivable Questions$")]
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAccountsReceivableQuestionsAsync2();
    }

    [Given(@"^I complete Bailees Customers Questions$")]
    [When(@"^I complete Bailees Customers Questions$")]
    [Then(@"^I complete Bailees Customers Questions$")]
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteBaileesCustomersQuestionsAsync2();
    }

    [Given(@"^I complete Computer Systems Questions$")]
    [When(@"^I complete Computer Systems Questions$")]
    [Then(@"^I complete Computer Systems Questions$")]
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteComputerSystemsQuestionsAsync2();
    }

    [Given(@"^I complete Contractors Equipment Questions$")]
    [When(@"^I complete Contractors Equipment Questions$")]
    [Then(@"^I complete Contractors Equipment Questions$")]
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteContractorsEquipmentQuestionsAsync2();
    }

    [Given(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteMotorTruckCargoQuestionsOwnerAsync2();
    }

    [Given(@"^I complete Signs Questions$")]
    [When(@"^I complete Signs Questions$")]
    [Then(@"^I complete Signs Questions$")]
    public async Task CompleteSignsQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteSignsQuestionsAsync2();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync6();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync10();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync10();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync10();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyValuesInPremiumFieldsAsync8();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationAsync8();
    }

}