using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
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

        public async Task SelectPrimaryFarmType(string farmType)
        {
            // Wait for any loading to complete
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            
            await _page.ClickAsync(ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectFarmTypeButton(farmType));
            
            // Wait for the next section to load
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }

        public async Task SelectLivestockType(string livestockType)
        {
            // Wait for page to be fully ready (spinner + network idle)
            await LoadingHelpers.WaitForPageFullyReadyAsync(_page);
            
            var locator = _page.Locator(ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectLivestockTypeRadioButton(livestockType));
            
            // Wait for element to be attached
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 10000 });
            
            // Force click to bypass any intercepting elements
            await locator.ClickAsync(new() { Force = true, Timeout = 15000 });
            
            // Verify selection if needed
            // await Task.Delay(500);
        }

        public async Task EnterGrossFarmIncome(string grossFarmIncome)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.GrossFarmIncomeInput, grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHemp(string growHemp)
        {
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            
            var testId = growHemp.Equals("Yes", StringComparison.OrdinalIgnoreCase)
                ? ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.IndustrialHempYesTestId
                : ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.IndustrialHempNoTestId;
            
            var button = _page.GetByTestId(testId);
            
            if (!await button.EvaluateAsync<bool>("el => el.classList.contains('mat-button-toggle-checked')"))
            {
                await button.ClickAsync();
            }
        }
    }
}