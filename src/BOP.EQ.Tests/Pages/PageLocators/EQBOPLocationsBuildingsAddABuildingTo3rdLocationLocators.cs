using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPLocationsBuildingsAddABuildingTo3rdLocationLocators
{
        public static ILocator Location3(IPage page) =>
        page.GetByLabel("Lost Forty Brewing", new() { Exact = true });

}
