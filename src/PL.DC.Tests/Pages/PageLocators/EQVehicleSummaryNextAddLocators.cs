using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVehicleSummaryNextAddLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNext(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
