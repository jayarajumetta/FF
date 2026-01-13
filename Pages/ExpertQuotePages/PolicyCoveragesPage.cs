
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
            await _page.ClickAsync(ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetPolicyCoverageSelectionButton(policyCoverage));
        }

        public async Task SelectCompCollOnlyAsync(string compCollOnly)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetCompCollOnlyButton(compCollOnly));
        }

        public async Task SelectCompDeductibleAsync(string compDeductible)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetCompDeductibleButton(compDeductible));
        }

        public async Task SelectCollDeductibleAsync(string collDeductible)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.CoverageSelectionPageLocators.GetCollDeductibleButton(collDeductible));
        }

        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

        public async Task ClickViewPriorCarrierDetails()
        {
                       await _page.ClickAsync(Locators.PolicyCoveragesConstLocators.ViewPriorCarrierDetailsButton);
        }
    }
}
