using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace TestAutomation.Pages.ExpressPages
{
    public class ExpressHomePage
    {
        private readonly IPage _page;

        public ExpressHomePage(IPage page)
        {
            _page = page;
        }

        public async Task SelectSearchTypeAsync(string searchType)
        {
            // Select the search type from the dropdown
            await _page.ClickAsync(ExpressDashboardConstLocators.ExpandSearchTypeDropDown);
            // Wait for dropdown option to be visible before clicking
            var optionLocator = _page.Locator(ExpressLocatorFactory.ExpressDashboardLocators.SelectSearchTypeFromDropDown(searchType));
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task EnterQuoteNumber(string quoteNumber)
        {
            await _page.FillAsync(ExpressDashboardConstLocators.SearchBarInput, quoteNumber);
        }

        public async Task ClickSearchButtonAsync()
        {
            await _page.ClickAsync(ExpressDashboardConstLocators.SearchButton);
        }
    }
}



