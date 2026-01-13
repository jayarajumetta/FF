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
            await _page.WaitForTimeoutAsync(2000); // Small wait to ensure dropdown is expanded
            await _page.ClickAsync(ExpressLocatorFactory.ExpressDashboardLocators.SelectSearchTypeFromDropDown(searchType));
            
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



