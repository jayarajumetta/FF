using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class INSPIREMainLocators
{
        public static ILocator ConfirmBusinessOwnersForPolicy(IPage page) =>
        page.Locator("id=ctl00_MainContent_pageHeader");

}
