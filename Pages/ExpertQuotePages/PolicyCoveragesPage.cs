// Pages/PolicyCoveragesPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PolicyCoveragesPage
    {
        private readonly IPage _page;

        public PolicyCoveragesPage(IPage page)
        {
            _page = page;
        }


        public async Task SelectPolicyCoverageAsync(string policyCoverage)
        {
            await ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetPolicyCoverageSelectionButton(_page, policyCoverage).ClickAsync();
        }

        public async Task SelectCompCollOnlyAsync(string compCollOnly)
        {

            var locator = ExpertQuoteLocatorFactory.CoverageSelectionPageLocators
                    .GetCompCollOnlyButton(_page, compCollOnly);

            await Helpers.Helpers.ClickIfNotSelectedAsync(locator);

        }

        public async Task SelectCompDeductibleAsync(string compDeductible)
        {
            await ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetCompDeductibleButton(_page, compDeductible).ClickAsync();
        }

        public async Task SelectCollDeductibleAsync(string collDeductible)
        {
            await ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetCollDeductibleButton(_page, collDeductible).ClickAsync();
        }


        public async Task ClickViewPriorCarrierDetails()
        {
                       await _page.ClickAsync(Locators.PolicyCoveragesConstLocators.ViewPriorCarrierDetailsButton);
        }
    }
}
