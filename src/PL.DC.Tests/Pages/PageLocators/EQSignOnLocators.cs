using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQSignOnLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtUsername1(IPage page) =>
        page.Locator("id=username");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtPassword(IPage page) =>
        page.Locator("id=password");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSignOn1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Sign On", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtUsername(IPage page) =>
        page.Locator("id=username");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtPassword1(IPage page) =>
        page.Locator("id=password");

}
