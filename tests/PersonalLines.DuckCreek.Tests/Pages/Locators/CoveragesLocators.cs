using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=130
    // Dynamically set by buffer AD&D Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator ADDCoverage => _page.GetByTestId("fields.policy.*ccidentalDeathInput$limit.value-chip-wrapper");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_1
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    public ILocator ADDDriver1 => _page.Locator("button[id=\"\\\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\\\"\"][data-testid=\"\\\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\\\"\"]");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_2
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator ADDDriver2 => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_3
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator ADDDriver3 => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_4
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator ADDDriver4 => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_5
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator ADDDriver5 => ADDDriver1;

    // Source modules: EQ || Additional Coverages Next (New) | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Next | Id
    public ILocator AdditionalCoveragesNextNewNext => _page.Locator("[id=\"fields.policy.next\"]");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Extraordinary Medical Benefit in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator ExtraordinaryMedicalBenefit => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | UMPD | Id+attributes_data-testid
    public ILocator H1AdditionalCoverages => _page.Locator("div[id=\"fields.policy.line.uninsuredMotoristsPDInput$limit.value-2\"][data-testid=\"fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper\"]");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Inc Liab Claims Fam Mem in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator IncLiabilityClaimsOfFamilyMembers => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=130
    // Dynamically set by buffer Income Loss Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator IncomeLossCoverage => _page.GetByTestId("fields.policy.line.incomeLossInput$limit.value-chip-wrapper");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Driver_1
    public ILocator LossOfIncomeDriver1 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Driver_2
    public ILocator LossOfIncomeDriver2 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[1].driverInput$incomeLossOperator.value");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Driver_3
    public ILocator LossOfIncomeDriver3 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[2].driverInput$incomeLossOperator.value");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Driver_4
    public ILocator LossOfIncomeDriver4 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[3].driverInput$incomeLossOperator.value");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Driver_5
    public ILocator LossOfIncomeDriver5 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[4].driverInput$incomeLossOperator.value");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=100
    // Dynamically set by buffer Tort Option in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator TortOption => _page.GetByTestId("fields.policy.line.tortInput$limit.value-chip-wrapper");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_1
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator TotalDisabilityCoverageDriver1 => ADDDriver1;

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer UIMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | UIMPD | Id
    public ILocator UIMPD => _page.Locator("[id=\"fields.policy.line.uninsuredMotoristsPDInput$deductible.value-0\"]");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=130
    // Dynamically set by buffer UMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UMPD => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || Other Policy Coverages Section (New) | Loss Of Income_Driver1 | Id+attributes_data-testid
    // v56 semantic alias: same physical raw-Tosca control as ADDDriver1
    public ILocator WorkLossNo => ADDDriver1;

}
