using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAddAdditionalDriver1Locators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator Driver1(IPage page) =>
        page.Locator("id=Driver_Headless.FullName-0-layout");

}
