using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPAddABuildingButtonLocators
{
        public static ILocator AddBuildingBPP(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "+ Add Building / BPP", Exact = true });

}
