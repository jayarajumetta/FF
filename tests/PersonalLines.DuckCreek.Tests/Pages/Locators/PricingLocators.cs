using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator HeaderPricingDetails => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Pricing Details" });

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator PricingDetailsNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });
    public ILocator PricingDetailsNav => _page.GetByTestId("Pricing-nav");
}
