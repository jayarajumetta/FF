using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    public ILocator CommercialAuto => _page.GetByLabel("Commercial Auto", new() { Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=113
    public ILocator DiscountNEWNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    public ILocator MultiCarDiscount => _page.GetByLabel("Multi-Car Discount", new() { Exact = true });

    // Source modules: EQ||Discount - Rate Tier Questions(NEW) | confidence=High score=130
    public ILocator N1500030000 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=83
    public ILocator NoDefensiveDriverDiscount => _page.GetByRole(AriaRole.Button, new() { Name = "NoDefensiveDriverDiscount", Exact = true });

    // Source modules:  | confidence=High score=97
    public ILocator On => _page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

    // Source modules: EQ||Discount - Rate Tier Questions(NEW) | confidence=High score=100
    public ILocator ResidentiaProperty1 => _page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-wrapper");

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    public ILocator RiderGroupDiscount => _page.GetByRole(AriaRole.Button, new() { Name = "Rider Group Discount", Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    public ILocator SafeCycleDiscount => _page.GetByRole(AriaRole.Button, new() { Name = "Safe Cycle Discount", Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=High score=127
    public ILocator SafeCycleDiscountDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Safe Cycle Discount Date", Exact = true });

    // Source modules: EQ||Discount(NEW) | confidence=Medium score=108
    public ILocator SpecialFarmPackage => _page.GetByLabel("Special Farm Package", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StateMD => _page.GetByText("State == \"MD", new() { Exact = true });

}