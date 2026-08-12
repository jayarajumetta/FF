using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAutoTabsLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator DIVSubmission(IPage page) =>
        page.GetByText("Submission", new() { Exact = true });

}
