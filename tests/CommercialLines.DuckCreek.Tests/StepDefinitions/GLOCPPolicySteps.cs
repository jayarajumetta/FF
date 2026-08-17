using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "GL OCP Policy")]
public sealed class GLOCPPolicySteps
{
    private readonly ScenarioContext _scenario;
    public GLOCPPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter individual client information$")]
    [When(@"^I enter individual client information$")]
    [Then(@"^I enter individual client information$")]
    public async Task EnterIndividualClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterIndividualClientInformationAsync2();
    }

    [Given(@"^I complete Underwriting Info from Client Screen$")]
    [When(@"^I complete Underwriting Info from Client Screen$")]
    [Then(@"^I complete Underwriting Info from Client Screen$")]
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteUnderwritingInfoFromClientScreenAsync2();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync3();
    }

    [Given(@"^I complete OCP Fields$")]
    [When(@"^I complete OCP Fields$")]
    [Then(@"^I complete OCP Fields$")]
    public async Task CompleteOCPFieldsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteOCPFieldsAsync();
    }

    [Given(@"^I complete OCP Risk Fields$")]
    [When(@"^I complete OCP Risk Fields$")]
    [Then(@"^I complete OCP Risk Fields$")]
    public async Task CompleteOCPRiskFieldsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteOCPRiskFieldsAsync();
    }

    [Given(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    [When(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    [Then(@"^I complete \\[CG0424\\] Coverage for Injury to Leased Workers$")]
    public async Task CompleteCG0424CoverageForInjuryToLeasedWorkersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG0424CoverageForInjuryToLeasedWorkersAsync();
    }

    [Given(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    [When(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    [Then(@"^I complete \\[CG2401\\] Non\\-Binding Arbitration$")]
    public async Task CompleteCG2401NonBindingArbitrationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG2401NonBindingArbitrationAsync();
    }

    [Given(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    [When(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    [Then(@"^I complete \\[CG2812\\] Pesticide or Herbicide Applicator Coverage$")]
    public async Task CompleteCG2812PesticideOrHerbicideApplicatorCoverageAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG2812PesticideOrHerbicideApplicatorCoverageAsync();
    }

    [Given(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    [When(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    [Then(@"^I complete \\[CG3132\\] Limited Fungi or Bacteria Coverage$")]
    public async Task CompleteCG3132LimitedFungiOrBacteriaCoverageAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG3132LimitedFungiOrBacteriaCoverageAsync();
    }

    [Given(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    [When(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    [Then(@"^I complete \\[CG 20 31\\] Add'l Insured\\-Engineers, Architects OCP$")]
    public async Task CompleteCG2031AddLInsuredEngineersArchitectsOCPAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG2031AddLInsuredEngineersArchitectsOCPAsync();
    }

    [Given(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    [When(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    [Then(@"^I complete \\[CG 29 35\\] Add'l Insured\\-State or Political \\(Permits\\)$")]
    public async Task CompleteCG2935AddLInsuredStateOrPoliticalPermitsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCG2935AddLInsuredStateOrPoliticalPermitsAsync();
    }

    [Given(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    [When(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    [Then(@"^I complete \\[FG0013\\] \\- Automatic Additional Insured \\- Specific$")]
    public async Task CompleteFG0013AutomaticAdditionalInsuredSpecificAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFG0013AutomaticAdditionalInsuredSpecificAsync();
    }

    [Given(@"^I answer GL UW Questions OR \\& WA$")]
    [When(@"^I answer GL UW Questions OR \\& WA$")]
    [Then(@"^I answer GL UW Questions OR \\& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerGLUWQuestionsORWAAsync2();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync3();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync3();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync3();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync3();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyValuesInPremiumFieldsAsync2();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationAsync2();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SignOutOfTheApplicationAsync3();
    }

}