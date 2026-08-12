using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAgentListCountCaptureLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator DIVAgentDocumentsCount(IPage page) =>
        page.GetByText("*", new() { Exact = true });

}
