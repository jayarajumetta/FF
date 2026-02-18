using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class PolicyDetailsPage : BasePage
    {
        public PolicyDetailsPage(IPage page) : base(page) { }

        #region Locators
        // SFP Policy Details locators
        private ILocator GetFarmTypeButton(string value) => _page.GetByRole(AriaRole.Button, new() { Name = value });
        
        private ILocator GetLivestockTypeRadioButton(string value) => 
            _page.Locator("mat-radio-button").Filter(new() { HasText = value }).Locator("label").First;
        
        private ILocator GrossFarmIncomeInput => 
            _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");
        
        private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
            _page.GetByTestId($"fields.account.policyInput$industrialHemp.value-{(yesOrNo.Equals("No", System.StringComparison.OrdinalIgnoreCase) ? "0" : "1")}");

        private ILocator SecondaryFarmTypeToggle =>
            _page.GetByTestId("fields.account.policyInput$secondaryFarmTypeApplicable.value");
        #endregion

        public async Task SelectPrimaryFarmType(string farmType)
        {
            await WaitForSpinnerAsync();
            await GetFarmTypeButton(farmType).ClickAsync();
        }

        public async Task SelectLivestockType(string livestockType)
        {
            await WaitForSpinnerAsync();
            await GetLivestockTypeRadioButton(livestockType).ClickAsync();
        }

        public async Task EnterGrossFarmIncome(string grossFarmIncome)
        {
            await WaitForSpinnerAsync();
            await GrossFarmIncomeInput.ScrollIntoViewIfNeededAsync();
            await GrossFarmIncomeInput.ClearAsync();
            await GrossFarmIncomeInput.FillAsync(grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHemp(string growHemp)
        {
            await WaitForSpinnerAsync();
            var hempButton = GetGrowIndustrialHempButton(growHemp);
            await hempButton.ScrollIntoViewIfNeededAsync();
            await ClickIfNotSelectedAsync(hempButton);
        }

        public async Task SetSecondaryFarmTypeAsync(bool enable)
        {
            await WaitForSpinnerAsync();
            var toggle = SecondaryFarmTypeToggle;
            await toggle.ScrollIntoViewIfNeededAsync();
            
            // mat-slide-toggle has 'mat-checked' class when enabled
            var isChecked = await toggle.GetAttributeAsync("class") is string cls && cls.Contains("mat-checked");
            
            if (enable != isChecked)
            {
                await toggle.ClickAsync();
            }
        }
    }
}