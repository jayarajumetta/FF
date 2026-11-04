using Microsoft.Playwright;
using PnCTestAutomation.Pages;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages.ExpressPages
{
    public class ExpressHomePage : BasePage
    {
        public ExpressHomePage(IPage page) : base(page) { }

        #region Locators
        private ILocator ExpandSearchTypeDropDown => _page.Locator("button[data-toggle*='SearchType']");
        internal static ILocator SearchBarInput(IPage page) => page.Locator(
            "input[name='quickSearchText']:visible, input[fieldref='PolicyHeaderInput.SearchText']:visible");
        private ILocator SearchButton => _page.Locator("a#id_quickSearch");
        private ILocator LegacySearchButton => _page.Locator("button[title*='Search']:visible");

        private ILocator GetSearchTypeOption(string searchType) => _page.Locator($"a:has-text('{searchType}')");
        #endregion

        public async Task SelectSearchTypeAsync(string searchType)
        {
            await ExpandSearchTypeDropDown.ClickAsync();
            var optionLocator = GetSearchTypeOption(searchType);
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task EnterQuoteNumber(string quoteNumber)
        {
            await SearchBarInput(_page).FillAsync(quoteNumber);
        }

        public async Task ClickSearchButtonAsync()
        {
            if (await SearchButton.IsVisibleAsync())
                await SearchButton.ClickAsync();
            else
                await LegacySearchButton.ClickAsync();
        }
    }
}

