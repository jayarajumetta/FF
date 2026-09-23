// Pages/ExpertQuotePages/ClientSearchPage.cs
using Microsoft.Playwright;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages.ExpertQuotePages
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
        private ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        private ILocator NewQuoteButton => _page.Locator("#new-quote-button");

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
            // Wait for page to be ready after login - the search input should be visible
            await SearchInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await SearchInput.FillAsync(name);

            // Wait for search button to be visible and clickable
            await SearchButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
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
            await PnCTestAutomation.Helpers.TableAssertions.AssertNameNotInTableAsync(_page, "table", clientName);
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

        public async Task<string> ReadActiveQuoteIdentityAsync()
        {
            var tab = _page.GetByRole(AriaRole.Tab, new() { Selected = true });
            await Assertions.Expect(tab).ToHaveCountAsync(1);
            await Assertions.Expect(tab).ToContainTextAsync(new Regex(@"(?<!\d)\d{8}(?!\d)"));
            return ParseQuoteIdentity(await tab.InnerTextAsync());
        }

        public static string ParseQuoteIdentity(string text)
        {
            var matches = Regex.Matches(text, @"(?<!\d)\d{8}(?!\d)");
            if (matches.Count != 1)
                throw new InvalidOperationException("The active quote header must contain exactly one complete quote identity.");
            return matches[0].Value;
        }

        public async Task CloseActiveQuoteAsync()
        {
            var tab = _page.GetByRole(AriaRole.Tab, new() { Selected = true });
            await Assertions.Expect(tab).ToHaveCountAsync(1);
            var close = tab.GetByText("clear", new() { Exact = true });
            await Assertions.Expect(close).ToHaveCountAsync(1);
            await close.ClickAsync();
            await Assertions.Expect(SearchInput).ToBeVisibleAsync();
            await Assertions.Expect(_page.GetByRole(AriaRole.Tab, new() { Selected = true })).ToHaveCountAsync(0);
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
