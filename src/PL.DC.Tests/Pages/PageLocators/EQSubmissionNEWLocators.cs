using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQSubmissionNEWLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CorrectionNeededStep1(IPage page) =>
        page.Locator("id=undefined");

        // REVIEW: source field not uniquely resolved.
    public static ILocator SaveExit1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Exit", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ReferUW(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Refer to UW", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Checklist1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Launch To Checklist", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Transmit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Transmit", Exact = true });

}
