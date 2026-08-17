using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.PLDC.Pages;

namespace InsuranceAutomation.PLDC.StepDefinitions;

[Binding, Scope(Feature = "Smoke Test Auto")]
public sealed class SmokeTestAutoSteps
{
    private readonly ScenarioContext _scenario;
    public SmokeTestAutoSteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I start New Quote$")]
    [When(@"^I start New Quote$")]
    [Then(@"^I start New Quote$")]
    public async Task StartNewQuoteAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartNewQuoteAsync9();
    }

    [Given(@"^I select or create the policy client$")]
    [When(@"^I select or create the policy client$")]
    [Then(@"^I select or create the policy client$")]
    public async Task SelectOrCreateThePolicyClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectOrCreateThePolicyClientAsync9();
    }

    [Given(@"^I enter account details$")]
    [When(@"^I enter account details$")]
    [Then(@"^I enter account details$")]
    public async Task EnterAccountDetailsAsync()
    {
        var page = new AccountInformationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterAccountDetailsAsync9();
    }

    [Given(@"^I start the policy proposal$")]
    [When(@"^I start the policy proposal$")]
    [Then(@"^I start the policy proposal$")]
    public async Task StartThePolicyProposalAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.StartThePolicyProposalAsync9();
    }

    [Given(@"^I capture the proposal number$")]
    [When(@"^I capture the proposal number$")]
    [Then(@"^I capture the proposal number$")]
    public async Task CaptureTheProposalNumberAsync()
    {
        var page = new ProposalPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CaptureTheProposalNumberAsync9();
    }

    [Given(@"^I complete tabs$")]
    [When(@"^I complete tabs$")]
    [Then(@"^I complete tabs$")]
    public async Task CompleteTabsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTabsAsync3();
    }

}