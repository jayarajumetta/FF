using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLEQ.Pages;

namespace InsuranceAutomation.CLEQ.StepDefinitions;

[Binding, Scope(Feature = "EQ SFP Smoke Test")]
public sealed class EQSFPSmokeTestSteps
{
    private readonly ScenarioContext _scenario;
    public EQSFPSmokeTestSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter client search information$")]
    [When(@"^I enter client search information$")]
    [Then(@"^I enter client search information$")]
    public async Task EnterClientSearchInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterClientSearchInformationAsync2();
    }

    [Given(@"^I create a new client$")]
    [When(@"^I create a new client$")]
    [Then(@"^I create a new client$")]
    public async Task CreateANewClientAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CreateANewClientAsync2();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAccountDetailsAsync2();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartThePolicyProposalAsync2();
    }

    [Given(@"^I enter and validate the insured social security number$")]
    [When(@"^I enter and validate the insured social security number$")]
    [Then(@"^I enter and validate the insured social security number$")]
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        var page = new SocialSecurityPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAndValidateTheInsuredSocialSecurityNumberAsync2();
    }

    [Given(@"^I navigate to the required policy screen$")]
    [When(@"^I navigate to the required policy screen$")]
    [Then(@"^I navigate to the required policy screen$")]
    public async Task NavigateToTheRequiredPolicyScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenAsync2();
    }

    [Given(@"^I complete quote Identifying and Close Quote$")]
    [When(@"^I complete quote Identifying and Close Quote$")]
    [Then(@"^I complete quote Identifying and Close Quote$")]
    public async Task CompleteQuoteIdentifyingAndCloseQuoteAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteQuoteIdentifyingAndCloseQuoteAsync();
    }

    [Given(@"^I search by QuoteNum$")]
    [When(@"^I search by QuoteNum$")]
    [Then(@"^I search by QuoteNum$")]
    public async Task SearchByQuoteNumAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SearchByQuoteNumAsync();
    }

    [Given(@"^I navigate to the required policy screen for screen$")]
    [When(@"^I navigate to the required policy screen for screen$")]
    [Then(@"^I navigate to the required policy screen for screen$")]
    public async Task NavigateToTheRequiredPolicyScreenForScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToTheRequiredPolicyScreenForScreenAsync2();
    }

    [Given(@"^I complete verifying Quote$")]
    [When(@"^I complete verifying Quote$")]
    [Then(@"^I complete verifying Quote$")]
    public async Task CompleteVerifyingQuoteAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteVerifyingQuoteAsync();
    }

}