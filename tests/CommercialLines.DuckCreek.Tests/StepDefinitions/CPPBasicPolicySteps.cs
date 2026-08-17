using InsuranceAutomation.Core;
using Reqnroll;
using InsuranceAutomation.CLDC.Pages;

namespace InsuranceAutomation.CLDC.StepDefinitions;

[Binding, Scope(Feature = "CPP Basic Policy")]
public sealed class CPPBasicPolicySteps
{
    private readonly ScenarioContext _scenario;
    public CPPBasicPolicySteps(ScenarioContext scenario) => _scenario = scenario;

    [Given(@"^I enter business client information$")]
    [When(@"^I enter business client information$")]
    [Then(@"^I enter business client information$")]
    public async Task EnterBusinessClientInformationAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.EnterBusinessClientInformationAsync3();
    }

    [Given(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [When(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    [Then(@"^I add a new Associated Client \\- Business Owner Type \\- Click Add Client$")]
    public async Task AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddANewAssociatedClientBusinessOwnerTypeClickAddClientAsync3();
    }

    [Given(@"^I complete aJAX Error Check$")]
    [When(@"^I complete aJAX Error Check$")]
    [Then(@"^I complete aJAX Error Check$")]
    public async Task CompleteAJAXErrorCheckAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAJAXErrorCheckAsync3();
    }

    [Given(@"^I complete required billing information$")]
    [When(@"^I complete required billing information$")]
    [Then(@"^I complete required billing information$")]
    public async Task CompleteRequiredBillingInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationAsync6();
    }

    [Given(@"^I complete the Associated Client Info$")]
    [When(@"^I complete the Associated Client Info$")]
    [Then(@"^I complete the Associated Client Info$")]
    public async Task CompleteTheAssociatedClientInfoAsync()
    {
        var page = new ClientSearchPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteTheAssociatedClientInfoAsync3();
    }

    [Given(@"^I complete required policy information$")]
    [When(@"^I complete required policy information$")]
    [Then(@"^I complete required policy information$")]
    public async Task CompleteRequiredPolicyInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredPolicyInformationAsync9();
    }

    [Given(@"^I run insurance score$")]
    [When(@"^I run insurance score$")]
    [Then(@"^I run insurance score$")]
    public async Task RunInsuranceScoreAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunInsuranceScoreAsync3();
    }

    [Given(@"^I select CPP Coverage \\- GL$")]
    [When(@"^I select CPP Coverage \\- GL$")]
    [Then(@"^I select CPP Coverage \\- GL$")]
    public async Task SelectCPPCoverageGLAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectCPPCoverageGLAsync2();
    }

    [Given(@"^I select CPP Coverage \\- CP$")]
    [When(@"^I select CPP Coverage \\- CP$")]
    [Then(@"^I select CPP Coverage \\- CP$")]
    public async Task SelectCPPCoverageCPAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectCPPCoverageCPAsync2();
    }

    [Given(@"^I select CPP Coverage \\- IM$")]
    [When(@"^I select CPP Coverage \\- IM$")]
    [Then(@"^I select CPP Coverage \\- IM$")]
    public async Task SelectCPPCoverageIMAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectCPPCoverageIMAsync();
    }

    [Given(@"^I select CP Detail$")]
    [When(@"^I select CP Detail$")]
    [Then(@"^I select CP Detail$")]
    public async Task SelectCPDetailAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectCPDetailAsync();
    }

    [Given(@"^I complete CP Fields$")]
    [When(@"^I complete CP Fields$")]
    [Then(@"^I complete CP Fields$")]
    public async Task CompleteCPFieldsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCPFieldsAsync();
    }

    [Given(@"^I complete mask Error Recovery$")]
    [When(@"^I complete mask Error Recovery$")]
    [Then(@"^I complete mask Error Recovery$")]
    public async Task CompleteMaskErrorRecoveryAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteMaskErrorRecoveryAsync();
    }

    [Given(@"^I complete CP Fields for policy coverage$")]
    [When(@"^I complete CP Fields for policy coverage$")]
    [Then(@"^I complete CP Fields for policy coverage$")]
    public async Task CompleteCPFieldsForPolicyCoverageAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCPFieldsForPolicyCoverageAsync();
    }

    [Given(@"^I complete CP Fields for location$")]
    [When(@"^I complete CP Fields for location$")]
    [Then(@"^I complete CP Fields for location$")]
    public async Task CompleteCPFieldsForLocationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCPFieldsForLocationAsync();
    }

    [Given(@"^I complete CP Fields for building$")]
    [When(@"^I complete CP Fields for building$")]
    [Then(@"^I complete CP Fields for building$")]
    public async Task CompleteCPFieldsForBuildingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCPFieldsForBuildingAsync();
    }

    [Given(@"^I add a Rating Group$")]
    [When(@"^I add a Rating Group$")]
    [Then(@"^I add a Rating Group$")]
    public async Task AddARatingGroupAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddARatingGroupAsync();
    }

    [Given(@"^I complete Structure Questions$")]
    [When(@"^I complete Structure Questions$")]
    [Then(@"^I complete Structure Questions$")]
    public async Task CompleteStructureQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteStructureQuestionsAsync();
    }

    [Given(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [When(@"^I complete ensure Property of Others Rating Group has been entered$")]
    [Then(@"^I complete ensure Property of Others Rating Group has been entered$")]
    public async Task CompleteEnsurePropertyOfOthersRatingGroupHasBeenEnteredAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEnsurePropertyOfOthersRatingGroupHasBeenEnteredAsync();
    }

    [Given(@"^I add Addl Interests$")]
    [When(@"^I add Addl Interests$")]
    [Then(@"^I add Addl Interests$")]
    public async Task AddAddlInterestsAsync()
    {
        var page = new LossHistoryPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestsAsync();
    }

    [Given(@"^I complete Property UW Questions$")]
    [When(@"^I complete Property UW Questions$")]
    [Then(@"^I complete Property UW Questions$")]
    public async Task CompletePropertyUWQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompletePropertyUWQuestionsAsync();
    }

    [Given(@"^I return to CPP Navigation$")]
    [When(@"^I return to CPP Navigation$")]
    [Then(@"^I return to CPP Navigation$")]
    public async Task ReturnToCPPNavigationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ReturnToCPPNavigationAsync();
    }

    [Given(@"^I select GL Detail$")]
    [When(@"^I select GL Detail$")]
    [Then(@"^I select GL Detail$")]
    public async Task SelectGLDetailAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectGLDetailAsync();
    }

    [Given(@"^I complete CGL Fields$")]
    [When(@"^I complete CGL Fields$")]
    [Then(@"^I complete CGL Fields$")]
    public async Task CompleteCGLFieldsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteCGLFieldsAsync();
    }

    [Given(@"^I add Class$")]
    [When(@"^I add Class$")]
    [Then(@"^I add Class$")]
    public async Task AddClassAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddClassAsync2();
    }

    [Given(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    [When(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    [Then(@"^I add \\[CG0435\\] Employee Benefits Liability Endorsement$")]
    public async Task AddCG0435EmployeeBenefitsLiabilityEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCG0435EmployeeBenefitsLiabilityEndorsementAsync2();
    }

    [Given(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    [When(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    [Then(@"^I add \\[CG2142\\] Exclusion \\- Explosion, Collapse and Underground Property Damage Hazard \\(Specified Operations\\)$")]
    public async Task AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCG2142ExclusionExplosionCollapseAndUndergroundPropertyDamageHazardSpecifiedOperationsAsync2();
    }

    [Given(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    [When(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    [Then(@"^I add \\[CG 2149\\] Total Pollution Exclusion Endorsement$")]
    public async Task AddCG2149TotalPollutionExclusionEndorsementAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCG2149TotalPollutionExclusionEndorsementAsync2();
    }

    [Given(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [When(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    [Then(@"^I verify and Fill out \\[FG0055\\] Employment Practices Liability Insurance Coverage Endorsement$")]
    public async Task VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyAndFillOutFG0055EmploymentPracticesLiabilityInsuranceCoverageEndorsementAsync2();
    }

    [Given(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    [When(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    [Then(@"^I add Addl Interest \\[CG2007\\] \\- Engineers$")]
    public async Task AddAddlInterestCG2007EngineersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestCG2007EngineersAsync2();
    }

    [Given(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    [When(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    [Then(@"^I add Addl Interest \\[CG2020\\] Add'l Insured\\-Charitable Institution$")]
    public async Task AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestCG2020AddLInsuredCharitableInstitutionAsync2();
    }

    [Given(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    [When(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    [Then(@"^I add Addl Interest \\[CG2023\\] Add'l Insured\\-Executors$")]
    public async Task AddAddlInterestCG2023AddLInsuredExecutorsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestCG2023AddLInsuredExecutorsAsync2();
    }

    [Given(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    [When(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    [Then(@"^I add Addl Interest \\[CG2025\\] Add'l Insured\\-Executive Officers$")]
    public async Task AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestCG2025AddLInsuredExecutiveOfficersAsync2();
    }

    [Given(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    [When(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    [Then(@"^I add Addl Interest \\[CG2034\\] Add'l Insured\\-Leased Equipment Automatic$")]
    public async Task AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAddlInterestCG2034AddLInsuredLeasedEquipmentAutomaticAsync2();
    }

    [Given(@"^I answer GL UW Questions OR \\& WA$")]
    [When(@"^I answer GL UW Questions OR \\& WA$")]
    [Then(@"^I answer GL UW Questions OR \\& WA$")]
    public async Task AnswerGLUWQuestionsORWAAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerGLUWQuestionsORWAAsync3();
    }

    [Given(@"^I return to CPP Navigation for return to cpp$")]
    [When(@"^I return to CPP Navigation for return to cpp$")]
    [Then(@"^I return to CPP Navigation for return to cpp$")]
    public async Task ReturnToCPPNavigationForReturnToCppAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ReturnToCPPNavigationForReturnToCppAsync();
    }

    [Given(@"^I select IM Detail$")]
    [When(@"^I select IM Detail$")]
    [Then(@"^I select IM Detail$")]
    public async Task SelectIMDetailAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectIMDetailAsync();
    }

    [Given(@"^I add Accounts Receivable Coverage$")]
    [When(@"^I add Accounts Receivable Coverage$")]
    [Then(@"^I add Accounts Receivable Coverage$")]
    public async Task AddAccountsReceivableCoverageAsync()
    {
        var page = new CoveragesPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAccountsReceivableCoverageAsync();
    }

    [Given(@"^I add Bailees Customers Coverage$")]
    [When(@"^I add Bailees Customers Coverage$")]
    [Then(@"^I add Bailees Customers Coverage$")]
    public async Task AddBaileesCustomersCoverageAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBaileesCustomersCoverageAsync();
    }

    [Given(@"^I add Computer Systems$")]
    [When(@"^I add Computer Systems$")]
    [Then(@"^I add Computer Systems$")]
    public async Task AddComputerSystemsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddComputerSystemsAsync();
    }

    [Given(@"^I add Contractors Equipment$")]
    [When(@"^I add Contractors Equipment$")]
    [Then(@"^I add Contractors Equipment$")]
    public async Task AddContractorsEquipmentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddContractorsEquipmentAsync();
    }

    [Given(@"^I add Motor Truck Cargo$")]
    [When(@"^I add Motor Truck Cargo$")]
    [Then(@"^I add Motor Truck Cargo$")]
    public async Task AddMotorTruckCargoAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddMotorTruckCargoAsync();
    }

    [Given(@"^I add Signs$")]
    [When(@"^I add Signs$")]
    [Then(@"^I add Signs$")]
    public async Task AddSignsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddSignsAsync();
    }

    [Given(@"^I add Accounts Receivable$")]
    [When(@"^I add Accounts Receivable$")]
    [Then(@"^I add Accounts Receivable$")]
    public async Task AddAccountsReceivableAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddAccountsReceivableAsync();
    }

    [Given(@"^I complete if search result Alert exists$")]
    [When(@"^I complete if search result Alert exists$")]
    [Then(@"^I complete if search result Alert exists$")]
    public async Task CompleteIfSearchResultAlertExistsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteIfSearchResultAlertExistsAsync();
    }

    [Given(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [When(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    [Then(@"^I complete ensure Class has been entered for Accounts Receivable$")]
    public async Task CompleteEnsureClassHasBeenEnteredForAccountsReceivableAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEnsureClassHasBeenEnteredForAccountsReceivableAsync();
    }

    [Given(@"^I add Bailees Customers$")]
    [When(@"^I add Bailees Customers$")]
    [Then(@"^I add Bailees Customers$")]
    public async Task AddBaileesCustomersAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddBaileesCustomersAsync();
    }

    [Given(@"^I complete if search result Alert exists for show me$")]
    [When(@"^I complete if search result Alert exists for show me$")]
    [Then(@"^I complete if search result Alert exists for show me$")]
    public async Task CompleteIfSearchResultAlertExistsForShowMeAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteIfSearchResultAlertExistsForShowMeAsync();
    }

    [Given(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [When(@"^I complete ensure Class has been entered for Bailees Customers$")]
    [Then(@"^I complete ensure Class has been entered for Bailees Customers$")]
    public async Task CompleteEnsureClassHasBeenEnteredForBaileesCustomersAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEnsureClassHasBeenEnteredForBaileesCustomersAsync();
    }

    [Given(@"^I add Computer Systems for risk$")]
    [When(@"^I add Computer Systems for risk$")]
    [Then(@"^I add Computer Systems for risk$")]
    public async Task AddComputerSystemsForRiskAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddComputerSystemsForRiskAsync();
    }

    [Given(@"^I complete if search result Alert exists for duck creek policy$")]
    [When(@"^I complete if search result Alert exists for duck creek policy$")]
    [Then(@"^I complete if search result Alert exists for duck creek policy$")]
    public async Task CompleteIfSearchResultAlertExistsForDuckCreekPolicyAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteIfSearchResultAlertExistsForDuckCreekPolicyAsync();
    }

    [Given(@"^I complete ensure Class has been entered for Computer Systems$")]
    [When(@"^I complete ensure Class has been entered for Computer Systems$")]
    [Then(@"^I complete ensure Class has been entered for Computer Systems$")]
    public async Task CompleteEnsureClassHasBeenEnteredForComputerSystemsAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteEnsureClassHasBeenEnteredForComputerSystemsAsync();
    }

    [Given(@"^I add Signs for risk$")]
    [When(@"^I add Signs for risk$")]
    [Then(@"^I add Signs for risk$")]
    public async Task AddSignsForRiskAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddSignsForRiskAsync();
    }

    [Given(@"^I add CM 66 01 Exclude Named Customer$")]
    [When(@"^I add CM 66 01 Exclude Named Customer$")]
    [Then(@"^I add CM 66 01 Exclude Named Customer$")]
    public async Task AddCM6601ExcludeNamedCustomerAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddCM6601ExcludeNamedCustomerAsync();
    }

    [Given(@"^I add IF 00 02 Waterborne Equipment$")]
    [When(@"^I add IF 00 02 Waterborne Equipment$")]
    [Then(@"^I add IF 00 02 Waterborne Equipment$")]
    public async Task AddIF0002WaterborneEquipmentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddIF0002WaterborneEquipmentAsync();
    }

    [Given(@"^I complete Accounts Receivable Questions$")]
    [When(@"^I complete Accounts Receivable Questions$")]
    [Then(@"^I complete Accounts Receivable Questions$")]
    public async Task CompleteAccountsReceivableQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteAccountsReceivableQuestionsAsync();
    }

    [Given(@"^I complete Bailees Customers Questions$")]
    [When(@"^I complete Bailees Customers Questions$")]
    [Then(@"^I complete Bailees Customers Questions$")]
    public async Task CompleteBaileesCustomersQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteBaileesCustomersQuestionsAsync();
    }

    [Given(@"^I complete Computer Systems Questions$")]
    [When(@"^I complete Computer Systems Questions$")]
    [Then(@"^I complete Computer Systems Questions$")]
    public async Task CompleteComputerSystemsQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteComputerSystemsQuestionsAsync();
    }

    [Given(@"^I complete Contractors Equipment Questions$")]
    [When(@"^I complete Contractors Equipment Questions$")]
    [Then(@"^I complete Contractors Equipment Questions$")]
    public async Task CompleteContractorsEquipmentQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteContractorsEquipmentQuestionsAsync();
    }

    [Given(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [When(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    [Then(@"^I complete Motor Truck Cargo Questions \\(Owner\\)$")]
    public async Task CompleteMotorTruckCargoQuestionsOwnerAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteMotorTruckCargoQuestionsOwnerAsync();
    }

    [Given(@"^I complete Signs Questions$")]
    [When(@"^I complete Signs Questions$")]
    [Then(@"^I complete Signs Questions$")]
    public async Task CompleteSignsQuestionsAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteSignsQuestionsAsync();
    }

    [Given(@"^I return to CPP policy navigation$")]
    [When(@"^I return to CPP policy navigation$")]
    [Then(@"^I return to CPP policy navigation$")]
    public async Task ReturnToCPPPolicyNavigationAsync()
    {
        var page = new PolicyWorkflowPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.ReturnToCPPPolicyNavigationAsync();
    }

    [Given(@"^I select GL Available Classiifcation$")]
    [When(@"^I select GL Available Classiifcation$")]
    [Then(@"^I select GL Available Classiifcation$")]
    public async Task SelectGLAvailableClassiifcationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.SelectGLAvailableClassiifcationAsync();
    }

    [Given(@"^I navigate to Underwriting Info Screens$")]
    [When(@"^I navigate to Underwriting Info Screens$")]
    [Then(@"^I navigate to Underwriting Info Screens$")]
    public async Task NavigateToUnderwritingInfoScreensAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateToUnderwritingInfoScreensAsync();
    }

    [Given(@"^I answer General UW Questions$")]
    [When(@"^I answer General UW Questions$")]
    [Then(@"^I answer General UW Questions$")]
    public async Task AnswerGeneralUWQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerGeneralUWQuestionsAsync();
    }

    [Given(@"^I answer General Liability History Questions$")]
    [When(@"^I answer General Liability History Questions$")]
    [Then(@"^I answer General Liability History Questions$")]
    public async Task AnswerGeneralLiabilityHistoryQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerGeneralLiabilityHistoryQuestionsAsync();
    }

    [Given(@"^I answer Commercial Property History Questions$")]
    [When(@"^I answer Commercial Property History Questions$")]
    [Then(@"^I answer Commercial Property History Questions$")]
    public async Task AnswerCommercialPropertyHistoryQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerCommercialPropertyHistoryQuestionsAsync();
    }

    [Given(@"^I answer Other Insurance History Questions$")]
    [When(@"^I answer Other Insurance History Questions$")]
    [Then(@"^I answer Other Insurance History Questions$")]
    public async Task AnswerOtherInsuranceHistoryQuestionsAsync()
    {
        var page = new UnderwritingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AnswerOtherInsuranceHistoryQuestionsAsync();
    }

    [Given(@"^I navigate back to CPP Main$")]
    [When(@"^I navigate back to CPP Main$")]
    [Then(@"^I navigate back to CPP Main$")]
    public async Task NavigateBackToCPPMainAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.NavigateBackToCPPMainAsync();
    }

    [Given(@"^I complete required billing information for billing$")]
    [When(@"^I complete required billing information for billing$")]
    [Then(@"^I complete required billing information for billing$")]
    public async Task CompleteRequiredBillingInformationForBillingAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredBillingInformationForBillingAsync2();
    }

    [Given(@"^I add notepad comment$")]
    [When(@"^I add notepad comment$")]
    [Then(@"^I add notepad comment$")]
    public async Task AddNotepadCommentAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.AddNotepadCommentAsync5();
    }

    [Given(@"^I complete required submission information$")]
    [When(@"^I complete required submission information$")]
    [Then(@"^I complete required submission information$")]
    public async Task CompleteRequiredSubmissionInformationAsync()
    {
        var page = new NavigationPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteRequiredSubmissionInformationAsync5();
    }

    [Given(@"^I run Stoplight$")]
    [When(@"^I run Stoplight$")]
    [Then(@"^I run Stoplight$")]
    public async Task RunStoplightAsync()
    {
        var page = new SubmissionPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.RunStoplightAsync5();
    }

    [Given(@"^I verify values in premium fields$")]
    [When(@"^I verify values in premium fields$")]
    [Then(@"^I verify values in premium fields$")]
    public async Task VerifyValuesInPremiumFieldsAsync()
    {
        var page = new PricingPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.VerifyValuesInPremiumFieldsAsync4();
    }

    [Given(@"^I complete forms verification$")]
    [When(@"^I complete forms verification$")]
    [Then(@"^I complete forms verification$")]
    public async Task CompleteFormsVerificationAsync()
    {
        var page = new FormsPage(_scenario.Get<BrowserSession>(), _scenario.Get<ScenarioData>(), _scenario.Get<PageUiActions>());
        await page.CompleteFormsVerificationAsync4();
    }

}