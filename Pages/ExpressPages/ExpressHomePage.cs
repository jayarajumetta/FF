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
        private ILocator SearchBarInput => _page.Locator("input[fieldref='PolicyHeaderInput.SearchText']");
        private ILocator SearchButton => _page.Locator("button[title*='Search']");

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
            await SearchBarInput.FillAsync(quoteNumber);
        }

        public async Task ClickSearchButtonAsync()
        {
            await SearchButton.ClickAsync();
        }
    }
}



