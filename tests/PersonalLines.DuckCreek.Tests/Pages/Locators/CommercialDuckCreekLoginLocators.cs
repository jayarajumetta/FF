using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CommercialDuckCreekLoginLocators
{
    private readonly IPage _page;
    public CommercialDuckCreekLoginLocators(IPage page) => _page = page;

    public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });

    public ILocator Password => _page.Locator("[id=\"password-inputEl\"]");

    public ILocator UserName => _page.Locator("[id=\"username-inputEl\"]");
}
