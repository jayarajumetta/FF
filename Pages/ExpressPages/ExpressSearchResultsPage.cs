
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;

namespace Playwright_POC.Pages
{
    public class ExpressSearchResultsPage
    {
        private readonly IPage _page;

        public ExpressSearchResultsPage(IPage page) => _page = page;

        // For the "I'm looking for" radio buttons
        public async Task SelectSearchParameters(string searchSelection)
        {
            await _page.WaitForSelectorAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectLookingForRadioButton(searchSelection));
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectLookingForRadioButton(searchSelection));

        }

        public async Task SelectFromSearchFiltersPolicyDropdown(string searchFiltersPolicy)
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandSearchFiltersPolicyDropdown);
            // Wait for dropdown option to be visible before clicking
            var optionLocator = _page.Locator(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SearchFiltersPolicySelection(searchFiltersPolicy));
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task SelectFromOperatorDropdown(string operatorSelection)
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandOperatorDropdown);
            // Wait for dropdown option to be visible before clicking
            var optionLocator = _page.Locator(ExpressLocatorFactory.ExpressSearchResultsPageLocators.OperatorSelectionFromDropdown(operatorSelection));
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task EnterSearchByValue(string searchByValue)
        {
            await _page.FillAsync(ExpressSearchResultsPageConstLocators.ValueInput, searchByValue);
        }

        public async Task ClickAddButton()
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.AddButton);
        }

        public async Task SelectFromSearchInDropdown(string searchInSelection)
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandSearchInDropdown);
            // Wait for dropdown option to be visible before clicking
            var optionLocator = _page.Locator(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectSearchInFromDropdown(searchInSelection));
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task CheckIncludePreviousTerms()
        {
                       await _page.CheckAsync(ExpressSearchResultsPageConstLocators.IncludePreviousTearmsCheckbox);
        }

        public async Task CheckShowOnlyDeletedPolicies()
        {
            await _page.CheckAsync(ExpressSearchResultsPageConstLocators.ShowOnlyDeletedPoliciesCheckbox);
        }

        public async Task ClickSearchButtonAsync()
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.SearchButton);
        }

        public async Task SelectPolicyOrQuoteNumberFromTable(string policyOrQuoteNumber)
        {
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectPolicyOrQuoteNumberFromTable(policyOrQuoteNumber));
        }

        public async Task SelectInsuredNameFromTable(string insuredName)
        {
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectInsuredNameFromTable(insuredName));
        }

        public async Task SelectQuoteOrPolicyFromEllipsisAsync()
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandEllipsisButton);
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.SelectPolicyFromEllipsis);
        }

        public async Task SelectViewPolicyDetailsFromEllipsis()
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandEllipsisButton);
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.SelectViewPolicyDetailsFromEllipsis);
        }
    }
}