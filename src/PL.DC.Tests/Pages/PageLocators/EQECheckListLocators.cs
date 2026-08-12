using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQECheckListLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkAutoCycleRVApplication(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Auto/Cycle/RV Application", Exact = true });

}
