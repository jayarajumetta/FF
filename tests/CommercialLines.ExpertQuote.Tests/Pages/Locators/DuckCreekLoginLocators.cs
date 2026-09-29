using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class DuckCreekLoginLocators
{
    private readonly IPage _page;
    public DuckCreekLoginLocators(IPage page) => _page = page;

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });

    public ILocator Password => _page.Locator("[id=\"password-inputEl\"]");

    public ILocator UserName => _page.Locator("[id=\"username-inputEl\"]");
}
