using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class LoginLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator Username(IPage page) =>
        page.Locator("id=username");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Password(IPage page) =>
        page.Locator("id=password");

        // REVIEW: source field not uniquely resolved.
    public static ILocator SignOn(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Sign On", Exact = true });

}
