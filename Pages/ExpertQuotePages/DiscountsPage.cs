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
            await Locators.GlobalLocators.NextButton(_page).WaitForAsync(new() { Timeout = 2000 });
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task SelectPolicyDiscountAsync(ScenarioContextData contextData)
        {
            await ExpertQuoteLocatorFactory.DiscountsPageLocators.GetPolicyDiscountCheckbox(_page, contextData.PolicyDiscount).ClickAsync();
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
            await ExpertQuoteLocatorFactory.DiscountsPageLocators.GetAccountCompositionCheckbox(_page, contextData.AccountCompositionDiscount).ClickAsync();
        }
    }
}
