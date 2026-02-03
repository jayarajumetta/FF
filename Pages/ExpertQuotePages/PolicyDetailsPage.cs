using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PolicyDetailsPage
    {
        private readonly IPage _page;

        public PolicyDetailsPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        // SFP Policy Details locators - moved from ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators
        private ILocator GetFarmTypeButton(string value) => _page.GetByRole(AriaRole.Button, new() { Name = value });
        
        private ILocator GetLivestockTypeRadioButton(string value) => 
            _page.Locator("mat-radio-button").Filter(new() { HasText = value }).Locator("label").First;
        
        private ILocator GrossFarmIncomeInput => 
            _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");
        
        private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
            _page.GetByTestId($"fields.account.policyInput$industrialHemp.value-{(yesOrNo.Equals("No", System.StringComparison.OrdinalIgnoreCase) ? "0" : "1")}");
        
        // Global locators
        private ILocator NextButton => _page.GetByTestId("next");
        #endregion

        public async Task SelectPrimaryFarmType(string farmType)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await GetFarmTypeButton(farmType).ClickAsync();
        }

        public async Task SelectLivestockType(string livestockType)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await GetLivestockTypeRadioButton(livestockType).ClickAsync();
        }

        public async Task EnterGrossFarmIncome(string grossFarmIncome)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await GrossFarmIncomeInput.ScrollIntoViewIfNeededAsync();
            await GrossFarmIncomeInput.ClearAsync();
            await GrossFarmIncomeInput.FillAsync(grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHemp(string growHemp)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            var hempButton = GetGrowIndustrialHempButton(growHemp);
            await hempButton.ScrollIntoViewIfNeededAsync();
            await Helpers.Helpers.ClickIfNotSelectedAsync(hempButton);
        }

        public async Task ClickNextAsync()
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await NextButton.ClickAsync();
        }
    }
}