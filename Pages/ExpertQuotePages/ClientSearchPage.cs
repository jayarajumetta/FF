// Pages/ExpertQuotePages/ClientSearchPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    /// <summary>
    /// Page Object for ExpertQuote Client Search / Dashboard page
    /// This is the landing page after login where you search for or create clients
    /// </summary>
    public class ClientSearchPage : BasePage
    {
        public ClientSearchPage(IPage page) : base(page) { }

        #region Locators
        // Dashboard/Search page
        private ILocator DashboardElement => _page.Locator("strong").GetByText("Quote", new() { Exact = true }).First;
        private ILocator PageHeader => _page.GetByText("Search / Recently Accessed");
        private ILocator SearchInput => _page.GetByTestId("quoteSearchInput");
        private ILocator SearchButton => _page.GetByTestId("quoteSearchButton");
        private ILocator NewQuoteButton => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote" });
        
        // Client Search/Suggestions panel (within quote flow)
        private ILocator ClientSearchSuggestionNav => _page.GetByTestId("ClientSearchSuggestion-nav");
        private ILocator ClientSearchInputGroup => _page.GetByTestId("temp.clientSearchInputGroup");
        private ILocator CreateNewClientCheckbox => _page.GetByTestId("temp.createNewClient");
        private ILocator CancelButton => _page.GetByTestId("fields.data.account.client.cancel");
        #endregion

        #region Actions
        /// <summary>
        /// Enter client name in search and click search button
        /// </summary>
        public async Task SearchForClientAsync(string name)
        {
            await SearchInput.FillAsync(name);
            await SearchButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        /// <summary>
        /// Click the New Quote button to start a new quote
        /// </summary>
        public async Task ClickNewQuoteAsync()
        {
            await NewQuoteButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        /// <summary>
        /// Check if the search/dashboard page is visible
        /// </summary>
        public async Task<bool> IsVisibleAsync()
        {
            return await PageHeader.IsVisibleAsync();
        }

        /// <summary>
        /// Wait for the page to be ready
        /// </summary>
        public async Task WaitForPageReadyAsync()
        {
            await SearchInput.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }

        /// <summary>
        /// Select a client from the recently accessed table
        /// </summary>
        public async Task SelectRecentlyAccessedClientAsync(string clientName)
        {
            var row = _page.Locator($"table tr:has-text('{clientName}')").First;
            await row.Locator("button").First.ClickAsync();
            await WaitForSpinnerAsync();
        }

        /// <summary>
        /// Assert that a client name is NOT in the search results table
        /// </summary>
        public async Task AssertClientNotInResultsAsync(string clientName)
        {
            await Playwright_POC.Helpers.TableAssertions.AssertNameNotInTableAsync(_page, "table", clientName);
        }

        /// <summary>
        /// Check the "Create New Client" checkbox in the client search panel
        /// </summary>
        public async Task CheckCreateNewClientAsync()
        {
            await CreateNewClientCheckbox.CheckAsync();
        }

        /// <summary>
        /// Click Cancel button in client search panel
        /// </summary>
        public async Task ClickCancelAsync()
        {
            await CancelButton.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion

        #region Legacy Compatibility
        [System.Obsolete("Use SearchForClientAsync instead")]
        public async Task EnterNameAndSearchAsync(string name) => await SearchForClientAsync(name);

        [System.Obsolete("Use IsVisibleAsync instead")]
        public async Task<bool> IsClientSearchPageVisibleAsync() => await IsVisibleAsync();

        [System.Obsolete("Use ClickNewQuoteAsync instead")]
        public async Task ClickNewQuoteButtonAsync() => await ClickNewQuoteAsync();

        [System.Obsolete("Use AssertClientNotInResultsAsync instead")]
        public async Task AssertNameNotInTableAsync(string tableSelector, string clientName) =>
            await AssertClientNotInResultsAsync(clientName);
        #endregion
    }
}
