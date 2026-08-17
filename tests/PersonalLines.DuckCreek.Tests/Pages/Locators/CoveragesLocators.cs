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
    public ILocator ADDDriver1 => _page.GetByRole(AriaRole.Button, new() { Name = "AD&D_Driver1", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_2
    public ILocator ADDDriver2 => _page.GetByRole(AriaRole.Button, new() { Name = "AD&D_Driver2", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_3
    public ILocator ADDDriver3 => _page.GetByRole(AriaRole.Button, new() { Name = "AD&D_Driver3", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_4
    public ILocator ADDDriver4 => _page.GetByRole(AriaRole.Button, new() { Name = "AD&D_Driver4", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Driver_5
    public ILocator ADDDriver5 => _page.GetByRole(AriaRole.Button, new() { Name = "AD&D_Driver5", Exact = true });

    // Source modules: EQ || Additional Coverages Next (New) | confidence=Medium score=113
    public ILocator AdditionalCoveragesNextNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Extraordinary Medical Benefit in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator ExtraordinaryMedicalBenefit => _page.GetByRole(AriaRole.Button, new() { Name = "Extraordinary Medical Benefit", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=78
    public ILocator H1AdditionalCoverages => _page.GetByLabel("H1_Additional Coverages", new() { Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer Inc Liab Claims Fam Mem in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator IncLiabilityClaimsOfFamilyMembers => _page.GetByRole(AriaRole.Button, new() { Name = "Inc Liability Claims of Family Members", Exact = true });

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
    public ILocator TotalDisabilityCoverageDriver1 => _page.GetByRole(AriaRole.Button, new() { Name = "Total Disability Coverage_Driver1", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=113
    // Dynamically set by buffer UIMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UIMPD => _page.GetByRole(AriaRole.Button, new() { Name = "UIMPD", Exact = true });

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=High score=130
    // Dynamically set by buffer UMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UMPD => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules: EQ || Other Policy Coverages Section (New) | confidence=Medium score=83
    public ILocator WorkLossNo => _page.GetByRole(AriaRole.Button, new() { Name = "Work_Loss_No", Exact = true });

}