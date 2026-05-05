// Pages/ExpertQuotePages/PA_DiscountsPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PA_DiscountsPage : BasePage
    {
        public PA_DiscountsPage(IPage page) : base(page) { }

        #region Locators
        // Dynamic locators
        private ILocator GetPolicyDiscountCheckbox(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetBenefitXpressDiscountButton(string value) =>
            _page.Locator($"div[id*='IsMemberOfBenefitesExpressGroup'] button:has-text('{value}')");

        private ILocator GetAccountCompositionCheckbox(string yesOrNo) =>
            _page.Locator("div[id*='AccountCompositionOverride']")
                .GetByRole(AriaRole.Button, new() { Name = yesOrNo });
        #endregion

        public async Task SelectPolicyDiscountAsync(ScenarioContextData contextData)
        {
            await GetPolicyDiscountCheckbox(contextData.PolicyDiscount).ClickAsync();
        }

        public async Task SelectBenifitXpressDiscount(ScenarioContextData contextData)
        {
            await GetBenefitXpressDiscountButton(contextData.BenefitXpressDiscount).ClickAsync();
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
            await GetAccountCompositionCheckbox(contextData.AccountCompositionDiscount).ClickAsync();
        }
    }
}
