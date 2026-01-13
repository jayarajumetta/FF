
// Pages/DiscountsPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class DiscountsPage
    {
        private readonly IPage _page;

        public DiscountsPage(IPage page)
        {
            _page = page;
        }

        public async Task ClickNextAsync()
        {
            await _page.WaitForSelectorAsync(Locators.GlobalLocators.NextButton, new() { Timeout = 2000 });
            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

        public async Task SelectPolicyDiscountAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.DiscountsPageLocators.GetPolicyDiscountCheckbox(contextData.PolicyDiscount));
        }

        public async Task SelectBenifitXpressDiscount(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.DiscountsPageLocators.GetBenefitXpressDiscountButton(contextData.BenefitXpressDiscount));
        }

        public async Task SelectDriverDistcountsAsync(ScenarioContextData contextData)
        {
            // Will add once Driver Discounts are available in the UI
        }

        public async Task SelectVehicleDistcountsAsync(ScenarioContextData contextData)
        {
            // Will add once Vehicle Discounts are available in the UI
        }

        public async Task SelectAccountCompositionAsync(ScenarioContextData contextData)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.DiscountsPageLocators.GetAccountCompositionCheckbox(contextData.AccountCompositionDiscount));
        }
    }
}
