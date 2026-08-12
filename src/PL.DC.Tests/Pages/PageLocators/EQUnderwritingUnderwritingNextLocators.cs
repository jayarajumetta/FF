using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQUnderwritingUnderwritingNextLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
