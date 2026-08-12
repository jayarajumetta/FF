using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAddCycleNextLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator AddAdditionalVehicle(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Add Additional Vehicle", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
