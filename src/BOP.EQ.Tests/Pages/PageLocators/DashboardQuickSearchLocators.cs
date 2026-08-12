using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class DashboardQuickSearchLocators
{
        public static ILocator SearchText(IPage page) =>
        page.Locator("id=quickSearchTextId-inputEl");

        public static ILocator QuickSearchButton(IPage page) =>
        page.Locator("id=id_quickSearch");

        public static ILocator SearchMode(IPage page) =>
        page.Locator("id=quickSearchModeId-inputEl");

}
