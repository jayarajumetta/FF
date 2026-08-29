using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator LoggedInUser => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Logged In User");

    public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });

    public ILocator Password => _page.Locator("[id=\"password-inputEl\"]");

    public ILocator UserName => _page.Locator("[id=\"username-inputEl\"]");
}
