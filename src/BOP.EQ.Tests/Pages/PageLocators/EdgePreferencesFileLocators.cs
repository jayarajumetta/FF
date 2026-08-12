using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EdgePreferencesFileLocators
{
        public static ILocator RootObject(IPage page) =>
        page.Locator("[name=\"RootObject\"]");

}
