using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpressPages
{
    public class ExpressSearchResultsPage : BasePage
    {
        public ExpressSearchResultsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator ExpandSearchFiltersPolicyDropdown => _page.Locator("button[data-toggle='PolicyList']");
        private ILocator ExpandOperatorDropdown => _page.Locator("button[data-toggle='Operator']");
        private ILocator ExpandSearchInDropdown => _page.Locator("button[data-toggle='searchIn']");
        private ILocator ValueInput => _page.Locator("input[fieldref='SearchItemInput.SearchFieldValue']");
        private ILocator AddButton => _page.Locator("button:has-text('Add')");
        private ILocator IncludePreviousTermsCheckbox => _page.Locator("input[fieldref='SearchOptionsInput.IncludePreviousTerms']");
        private ILocator ShowOnlyDeletedPoliciesCheckbox => _page.Locator("input[fieldref='SearchOptionsInput.ShowDeletedPoliciesOnly']");
        private ILocator SearchButton => _page.Locator("button[title*='Search']");
        private ILocator ExpandEllipsisButton => _page.Locator("button[title*='Open More Options']");
        private ILocator SelectPolicyFromEllipsis => _page.Locator("a[title*='Open Quote or Policy']");
        private ILocator SelectViewPolicyDetailsFromEllipsis => _page.Locator("a[title*='View Policy Details']");

        // Dynamic locators
        private ILocator GetLookingForRadioButton(string selection) => _page.Locator($"label:has-text('{selection}')");
        private ILocator GetSearchFiltersPolicyOption(string policy) => _page.Locator($"a:has-text('{policy}')");
        private ILocator GetOperatorOption(string op) => _page.Locator($"a:has-text('{op}')");
        private ILocator GetSearchInOption(string searchIn) => _page.Locator($"a:has-text('{searchIn}')");
        private ILocator GetPolicyOrQuoteNumberInTable(string number) => _page.Locator($"a:has-text('{number}')");
        private ILocator GetInsuredNameInTable(string name) => _page.Locator($"a:has-text('{name}')");
        #endregion

        public async Task SelectSearchParameters(string searchSelection)
        {
            var radioButton = GetLookingForRadioButton(searchSelection);
            await radioButton.WaitForAsync();
            await radioButton.ClickAsync();
        }

        public async Task SelectFromSearchFiltersPolicyDropdown(string searchFiltersPolicy)
        {
            await ExpandSearchFiltersPolicyDropdown.ClickAsync();
            var optionLocator = GetSearchFiltersPolicyOption(searchFiltersPolicy);
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task SelectFromOperatorDropdown(string operatorSelection)
        {
            await ExpandOperatorDropdown.ClickAsync();
            var optionLocator = GetOperatorOption(operatorSelection);
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task EnterSearchByValue(string searchByValue)
        {
            await ValueInput.FillAsync(searchByValue);
        }

        public async Task ClickAddButton()
        {
            await AddButton.ClickAsync();
        }

        public async Task SelectFromSearchInDropdown(string searchInSelection)
        {
            await ExpandSearchInDropdown.ClickAsync();
            var optionLocator = GetSearchInOption(searchInSelection);
            await Assertions.Expect(optionLocator).ToBeVisibleAsync();
            await optionLocator.ClickAsync();
        }

        public async Task CheckIncludePreviousTerms()
        {
            await IncludePreviousTermsCheckbox.CheckAsync();
        }

        public async Task CheckShowOnlyDeletedPolicies()
        {
            await ShowOnlyDeletedPoliciesCheckbox.CheckAsync();
        }

        public async Task ClickSearchButtonAsync()
        {
            await SearchButton.ClickAsync();
        }

        public async Task SelectPolicyOrQuoteNumberFromTable(string policyOrQuoteNumber)
        {
            await GetPolicyOrQuoteNumberInTable(policyOrQuoteNumber).ClickAsync();
        }

        public async Task SelectInsuredNameFromTable(string insuredName)
        {
            await GetInsuredNameInTable(insuredName).ClickAsync();
        }

        public async Task SelectQuoteOrPolicyFromEllipsisAsync()
        {
            await ExpandEllipsisButton.ClickAsync();
            await SelectPolicyFromEllipsis.ClickAsync();
        }

        public async Task ClickViewPolicyDetailsFromEllipsisAsync()
        {
            await ExpandEllipsisButton.ClickAsync();
            await SelectViewPolicyDetailsFromEllipsis.ClickAsync();
        }
    }
}
