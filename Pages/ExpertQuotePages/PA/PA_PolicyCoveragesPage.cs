// Pages/ExpertQuotePages/PA_PolicyCoveragesPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PA_PolicyCoveragesPage : BasePage
    {
        public PA_PolicyCoveragesPage(IPage page) : base(page) { }

        #region Locators
        private ILocator ViewPriorCarrierDetailsButton => _page.Locator("button:has-text('VIEW PRIOR CARRIER DETAILS')");

        // Dynamic locators
        private ILocator GetPolicyCoverageSelectionButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetCompCollOnlyButton(string yesOrNo) =>
            _page.GetByRole(AriaRole.Button, new() { Name = yesOrNo })
                .Filter(new() { Has = _page.Locator("[id*='COMPCOLLBothOnly']") });

        private ILocator GetCompDeductibleButton(string value) =>
            _page.Locator("[id*='comp_Option']")
                .GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetCollDeductibleButton(string value) =>
            _page.Locator("[id*='coll_Option']")
                .GetByRole(AriaRole.Button, new() { Name = value });
        #endregion

        public async Task SelectPolicyCoverageAsync(string policyCoverage)
        {
            await GetPolicyCoverageSelectionButton(policyCoverage).ClickAsync();
        }

        public async Task SelectCompCollOnlyAsync(string compCollOnly)
        {
            var locator = GetCompCollOnlyButton(compCollOnly);
            await ClickIfNotSelectedAsync(locator);
        }

        public async Task SelectCompDeductibleAsync(string compDeductible)
        {
            await GetCompDeductibleButton(compDeductible).ClickAsync();
        }

        public async Task SelectCollDeductibleAsync(string collDeductible)
        {
            await GetCollDeductibleButton(collDeductible).ClickAsync();
        }

        public async Task ClickViewPriorCarrierDetails()
        {
            await ViewPriorCarrierDetailsButton.ClickAsync();
        }
    }
}
