
// Pages/ClientSearchPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace Playwright_POC.Pages
{
    public class ClientSearchPage
    {
        private readonly IPage _page;

        public ClientSearchPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterNameAndSearchAsync(string name)
        {
            await ClientSearchLocators.IndividualSearchField(_page).FillAsync(name);
            await ClientSearchLocators.ClientSearchButton(_page).ClickAsync();
        }

        public async Task<bool> IsClientSearchPageVisibleAsync()
        {
            return await ClientSearchLocators.ClientSearchPage(_page).IsVisibleAsync();
        }

        // Table assertion 
        public async Task AssertNameNotInTableAsync(string tableSelector, string clientName)
        {
            await Playwright_POC.Helpers.TableAssertions.AssertNameNotInTableAsync(_page, tableSelector, clientName);
        }

        public async Task SelectRecentlyAccessedAsync(string clientName)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.SearchRecentlyAccessedListLocators.SelectRecentlyAccessedClient(clientName));
        }
    }
}
