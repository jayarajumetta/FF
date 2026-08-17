using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator HeaderPricingDetails => _page.GetByText("Header Pricing Details", new() { Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ || Pricing Details (New) | confidence=Medium score=113
    public ILocator PricingDetailsNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}