using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonSearchByQuoteNumLocators
{
        public static ILocator QuoteSearchInput(IPage page) =>
        page.Locator("id=quoteSearchInput");

        public static ILocator Search(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

}
