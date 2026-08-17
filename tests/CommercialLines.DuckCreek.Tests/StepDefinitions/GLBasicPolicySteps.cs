using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "GL Basic Policy")]
public sealed class GLBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public GLBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

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
        await page.EnterIndividualClientInformationAsync();
    }

    [Given(@"^I complete Underwriting Info from Client Screen$")]
    [When(@"^I complete Underwriting Info from Client Screen$")]
    [Then(@"^I complete Underwriting Info from Client Screen$")]
    public async Task CompleteUnderwritingInfoFromClientScreenAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteUnderwritingInfoFromClientScreenAsync();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredPolicyInformationAsync2();
    }

    [Given(@"^I complete CGL Fields$")]
    [When(@"^I complete CGL Fields$")]
    [Then(@"^I complete CGL Fields$")]
    public async Task CompleteCGLFieldsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteCGLFieldsAsync();
    }

    [Given(@"^I add Class$")]
    [When(@"^I add Class$")]
    [Then(@"^I add Class$")]
    public async Task AddClassAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddClassAsync();
    }

    [Given(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    [When(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    [Then(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddCG0435EmployeeBenefitsLiabilityEndorsementAsync();
    }

    [Given(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    [When(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    [Then(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync();
    }

    [Given(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    [When(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    [Then(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddCG2149TotalPollutionExclusionEndorsementAsync();
    }

    [Given(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [When(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [Then(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync();
    }

    [Given(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    [When(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    [Then(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestCG2007EngineersAsync();
    }

    [Given(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    [When(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    [Then(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync();
    }

    [Given(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    [When(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    [Then(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestCG2023AddLInsuredExecutorsAsync();
    }

    [Given(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    [When(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    [Then(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync();
    }

    [Given(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    [When(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    [Then(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AddNotepadCommentAsync2();
    }

    [Given(@"^I answer GL UW Questions OR \\& WA$")]
    [When(@"^I answer GL UW Questions OR \\& WA$")]
    [Then(@"^I answer GL UW Questions OR \\& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.AnswerGLUWQuestionsORWAAsync();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredBillingInformationAsync2();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteRequiredSubmissionInformationAsync2();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.RunStoplightAsync2();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.VerifyValuesInPremiumFieldsAsync();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.CompleteFormsVerificationAsync();
    }

    [Given(@"^I sign out of the application$")]
    [When(@"^I sign out of the application$")]
    [Then(@"^I sign out of the application$")]
    public async Task SignOutOfTheApplicationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<UiActions>());
        await page.SignOutOfTheApplicationAsync2();
    }

}
