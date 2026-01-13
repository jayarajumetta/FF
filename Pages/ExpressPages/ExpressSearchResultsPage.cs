
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
            await _page.WaitForTimeoutAsync(2000); // Small wait to ensure dropdown is expanded
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SearchFiltersPolicySelection(searchFiltersPolicy));
        }

        public async Task SelectFromOperatorDropdown(string operatorSelection)
        {
            await _page.ClickAsync(ExpressSearchResultsPageConstLocators.ExpandOperatorDropdown);
            await _page.WaitForTimeoutAsync(2000); // Small wait to ensure dropdown is expanded
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.OperatorSelectionFromDropdown(operatorSelection));
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
            await _page.WaitForTimeoutAsync(2000); // Small wait to ensure dropdown is expanded
            await _page.ClickAsync(ExpressLocatorFactory.ExpressSearchResultsPageLocators.SelectSearchInFromDropdown(searchInSelection));
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