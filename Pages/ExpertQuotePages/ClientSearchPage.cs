// Pages/ClientSearchPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class ClientSearchPage
    {
        private readonly IPage _page;

        public ClientSearchPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        // Client search locators - moved from ClientSearchLocators static class
        public ILocator DashboardElement => _page.Locator("strong").GetByText("Quote", new() { Exact = true }).First;
        public ILocator ClientSearchPageHeader => _page.GetByText("Search / Recently Accessed");
        public ILocator IndividualSearchField => _page.GetByTestId("quoteSearchInput");
        public ILocator ClientSearchButton => _page.GetByTestId("quoteSearchButton");
        public ILocator NewQuoteButton => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote" });
        #endregion

        public async Task EnterNameAndSearchAsync(string name)
        {
            await IndividualSearchField.FillAsync(name);
            await ClientSearchButton.ClickAsync();
        }

        public async Task<bool> IsClientSearchPageVisibleAsync()
        {
            return await ClientSearchPageHeader.IsVisibleAsync();
        }

        // Table assertion 
        public async Task AssertNameNotInTableAsync(string tableSelector, string clientName)
        {
            await Playwright_POC.Helpers.TableAssertions.AssertNameNotInTableAsync(_page, tableSelector, clientName);
        }

        public async Task SelectRecentlyAccessedAsync(string clientName)
        {
            var selector = $"xpath=.//table//tr[td[contains(text(), '{clientName}')]]//button";
            await _page.ClickAsync(selector);
        }

        public async Task ClickNewQuoteButtonAsync()
        {
            await NewQuoteButton.ClickAsync();
        }
    }
}
