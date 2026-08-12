using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPAdditionalCoveragesDeleteEPLILocators
{
        public static ILocator DeleteEPLICoverage(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "delete", Exact = true });

        public static ILocator EmploymentRelatedPracticesExclusion(IPage page) =>
        page.Locator("id=undefined");

}
