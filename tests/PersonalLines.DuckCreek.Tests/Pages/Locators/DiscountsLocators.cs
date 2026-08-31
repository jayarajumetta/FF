using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    public ILocator CommercialAuto => _page.Locator("[id=\"\"fields.data.policy.line.driver.rows[0].driverInput$isMemberOfBenefitsExpressGroup_DuplicatePath.value-0\"\"]");

    public ILocator DiscountNEWNext => _page.Locator("[id=\"fields.data.next\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });


    public ILocator N1500030000 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");


    public ILocator On => _page.Locator("[id=\"fields.data.policy.line.multiCarDiscount$selected.value-checkbox\"]");

    public ILocator ResidentiaProperty1 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-wrapper");

    public ILocator RiderGroupDiscount => _page.Locator("[id=\"\"fields.data.policy.line.driverRiderGroup.rows[0].riderGroupDiscount$selected.value-0\"\"]");

    public ILocator SafeCycleDiscount => _page.Locator("[id=\"\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscount$selected.value-0\"\"]");

    public ILocator SafeCycleDiscountDate => _page.Locator("input[id=\"\\\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\\\"\"][name=\"\\\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\\\"\"]");


    public ILocator StateMD => _page.GetByText("State == \"MD", new() { Exact = true });

}
