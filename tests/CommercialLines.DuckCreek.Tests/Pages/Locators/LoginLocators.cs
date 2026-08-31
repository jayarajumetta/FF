using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class LoginLocators
{
    private readonly IPage _page;
    public LoginLocators(IPage page) => _page = page;

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator LoggedInUser => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Logged In User']/@for] | //label[normalize-space(string(.))='Logged In User']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Logged In User']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator Login => _page.GetByRole(AriaRole.Link, new() { Name = "Login", Exact = true });

    public ILocator Password => _page.Locator("[id=\"password-inputEl\"]");

    public ILocator UserName => _page.Locator("[id=\"username-inputEl\"]");
}
