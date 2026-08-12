using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAdditionalInterestLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator H1AdditionalInterestSummary(IPage page) =>
        page.GetByText("Additional Interest Summary", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
