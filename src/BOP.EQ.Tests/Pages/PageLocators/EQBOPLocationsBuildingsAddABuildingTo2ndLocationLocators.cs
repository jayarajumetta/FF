using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPLocationsBuildingsAddABuildingTo2ndLocationLocators
{
        public static ILocator Location2Location2Secondary(IPage page) =>
        page.Locator("id=LocationOutputNonShredded.LocationCaptionPrimarySecondary-1-layout");

        public static ILocator AddBuildingBPP1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "+ Add Building / BPP", Exact = true });

}
