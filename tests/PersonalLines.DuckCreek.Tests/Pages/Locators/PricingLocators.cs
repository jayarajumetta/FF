using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator HeaderPricingDetails => _page.GetByText("Header Pricing Details", new() { Exact = true });

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator PricingDetailsNewNext => _page.Locator("[id=\"mat-tab-content-0-1\"]");

}
