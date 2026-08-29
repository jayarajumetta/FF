using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Discount(NEW) | BeneX_Yes | Id
    public ILocator CommercialAuto => _page.Locator("[id=\"\"fields.data.policy.line.driver.rows[0].driverInput$isMemberOfBenefitsExpressGroup_DuplicatePath.value-0\"\"]");

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Discount(NEW) | Next | Id
    public ILocator DiscountNEWNext => _page.Locator("[id=\"fields.data.next\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Discount(NEW) | BeneX_Yes | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialAuto
    public ILocator MultiCarDiscount => CommercialAuto;

    // Source modules: EQ||Discount - Rate Tier Questions(NEW) | confidence=High score=130
    public ILocator N1500030000 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=83
    // v56 raw Tosca primary: EQ||Discount(NEW) | BeneX_Yes | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialAuto
    public ILocator NoDefensiveDriverDiscount => CommercialAuto;

    // Source modules:  | confidence=High score=97
    // v56 raw Tosca primary:  | on | Id
    public ILocator On => _page.Locator("[id=\"fields.data.policy.line.multiCarDiscount$selected.value-checkbox\"]");

    // Source modules: EQ||Discount - Rate Tier Questions(NEW) | confidence=High score=100
    public ILocator ResidentiaProperty1 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-wrapper");

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    // v56 raw Tosca primary: EQ||Discount(NEW) | Rider Group Discount | Id
    public ILocator RiderGroupDiscount => _page.Locator("[id=\"\"fields.data.policy.line.driverRiderGroup.rows[0].riderGroupDiscount$selected.value-0\"\"]");

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    // v56 raw Tosca primary: EQ||Discount(NEW) | Safe Cycle Discount | Id
    public ILocator SafeCycleDiscount => _page.Locator("[id=\"\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscount$selected.value-0\"\"]");

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    // v56 raw Tosca primary: EQ||Discount(NEW) | Safe Cycle Discount Date | Id+Name
    public ILocator SafeCycleDiscountDate => _page.Locator("input[id=\"\\\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\\\"\"][name=\"\\\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\\\"\"]");

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Discount(NEW) | BeneX_Yes | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialAuto
    public ILocator SpecialFarmPackage => CommercialAuto;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator StateMD => _page.GetByText("State == \"MD", new() { Exact = true });

}
