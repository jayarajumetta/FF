using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Dynamically set by buffer AD&D Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator ADDCoverage => _page.GetByTestId("fields.policy.*ccidentalDeathInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Driver_1
    public ILocator ADDDriver1 => _page.Locator("button[id=\"\\\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\\\"\"][data-testid=\"\\\"fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value\\\"\"]");

    // Dynamically set by buffer Driver_2

    // Dynamically set by buffer Driver_3

    // Dynamically set by buffer Driver_4

    // Dynamically set by buffer Driver_5

    public ILocator AdditionalCoveragesNextNewNext => _page.Locator("[id=\"fields.policy.next\"]");

    // Dynamically set by buffer Extraordinary Medical Benefit in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages

    public ILocator H1AdditionalCoverages => _page.Locator("div[id=\"fields.policy.line.uninsuredMotoristsPDInput$limit.value-2\"][data-testid=\"fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper\"]");

    // Dynamically set by buffer Inc Liab Claims Fam Mem in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages

    // Dynamically set by buffer Income Loss Coverage in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator IncomeLossCoverage => _page.GetByTestId("fields.policy.line.incomeLossInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Driver_1
    public ILocator LossOfIncomeDriver1 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[0].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_2
    public ILocator LossOfIncomeDriver2 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[1].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_3
    public ILocator LossOfIncomeDriver3 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[2].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_4
    public ILocator LossOfIncomeDriver4 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[3].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Driver_5
    public ILocator LossOfIncomeDriver5 => _page.GetByTestId("fields.policy.line.driverIncomeLoss.rows[4].driverInput$incomeLossOperator.value");

    // Dynamically set by buffer Tort Option in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator TortOption => _page.GetByTestId("fields.policy.line.tortInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Driver_1

    // Dynamically set by buffer UIMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UIMPD => _page.Locator("[id=\"fields.policy.line.uninsuredMotoristsPDInput$deductible.value-0\"]");

    // Dynamically set by buffer UMPD in RTB Auto | 10.1 EQ | Auto_AddlCov Policy Coverages
    public ILocator UMPD => _page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper");


}
