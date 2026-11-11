using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    public ILocator CommercialAuto => _page.Locator("[id=\"fields.data.policy.line.driver.rows[0].driverInput$isMemberOfBenefitsExpressGroup_DuplicatePath.value-0\"]");

    public ILocator DiscountNEWNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });
    public ILocator DiscountsAdjustmentsNav => _page.GetByTestId("Discounts_Adjustments-nav");

    public ILocator DefensiveDriverCourseBasic => _page.GetByTestId("fields.data.policy.line.driverDefensiveDriver.rows[0].driverInput$defensiveDriverCourse.value-chip-label").Filter(new() { HasText = "Basic" });

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });


    public ILocator N1500030000 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper").Filter(new() { HasText = "Less than $15,000/$30,000" });

    public ILocator GreaterThan25000050000AndLessThan100000300000 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-label").Filter(new() { HasText = "Greater Than $25,000/$50,000 and Less Than $100,000/$300,000" });

    public ILocator NotResidentialPropertyOwner => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-label").Filter(new() { HasText = "Not Residential Property Owner" });


    public ILocator On => _page.Locator("[id=\"fields.data.policy.line.multiCarDiscount$selected.value-checkbox\"]");


    public ILocator AutoHomeDiscountOn => _page.Locator("[id=\"fields.data.policy.line.autoHomeDiscount$selected.value-checkbox\"]");

    public ILocator CommercialAutoOverride => _page.Locator("[id=\"fields.data.policy.line.multiPolicy_RelatedAuto$override.value-checkbox\"]");

    public ILocator SpecialFarmPackageOverride => _page.Locator("[id=\"fields.data.policy.line.multiPolicy_RelatedHome$override.value-checkbox\"]");

    public ILocator ResidentiaProperty1 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-wrapper").Filter(new() { HasText = "Not Residential Property Owner" });




    public ILocator RiderGroupDiscount => _page.Locator("[id=\"fields.data.policy.line.driverRiderGroup.rows[0].riderGroupDiscount$selected.value-0\"]");

    public ILocator SafeCycleDiscountYes => _page
        .GetByTestId("fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscount$selected.value-chip-wrapper")
        .Or(_page.GetByTestId("fields.line.driverSafeCycle.rows[0].safeCycleDiscount$selected.value-chip-wrapper"))
        .First;

    public ILocator SafeCycleDiscountDate => _page
        .Locator("input[id=\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\"][name=\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\"]")
        .Or(_page.Locator("input[id=\"fields.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\"][name=\"fields.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\"]"));


    public ILocator StateMD => _page.GetByText("State == \"MD", new() { Exact = true });

    public ILocator LessThanOrEqualTo30k60k => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-label").Nth(1);

    public ILocator NoDefensiveDriver => _page.GetByTestId("fields.data.policy.line.driverDefensiveDriver.rows[0].driverInput$defensiveDriverCourse.value-chip-wrapper").GetByText("NONE");
    public ILocator DiscountsAdjustmentsHeader => _page.Locator("h1").Filter(new() { HasText = "Discounts / Adjustments" });
}
