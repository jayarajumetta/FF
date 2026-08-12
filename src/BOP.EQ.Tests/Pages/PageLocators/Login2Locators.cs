using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class Login2Locators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator UserName(IPage page) =>
        page.Locator("id=username-inputEl");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Password(IPage page) =>
        page.Locator("id=password-inputEl");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Login(IPage page) =>
        page.Locator("[data-duckcreek-id=\"Login\"]");

}
