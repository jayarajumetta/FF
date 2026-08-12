using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EditCoverageOptionNewLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator SupplementalUMUIMOptIn(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator SupplementalUMUIMCov(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UMCoverage(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Standard", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator SaveAndContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

}
