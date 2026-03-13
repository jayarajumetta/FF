using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_PolicyDetailsPage : BasePage
    {
        public SFP_PolicyDetailsPage(IPage page) : base(page) { }

        #region TestId Lookup

        // Category indices are stable (always Animals=0, Crops=1, Other=2)
        private static readonly Dictionary<string, int> FarmCategoryIndex = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Animals"] = 0, ["Crops"] = 1, ["Other"] = 2
        };

        #endregion

        #region Locators

        private ILocator GetPrimaryFarmCategoryButton(string category) =>
            _page.GetByTestId($"fields.account.policyInput$farmTypeCategory.value-{FarmCategoryIndex[category]}");

        // Sub-type indices re-index per category, so match by GetByTestId regex + exact text
        private ILocator GetPrimaryFarmSubTypeRadio(string subType) =>
            _page.GetByTestId(new Regex(@"^fields\.account\.policyInput\$farmType\.value-\d+$"))
                 .Filter(new() { Has = _page.GetByText(subType, new() { Exact = true }) });

        private ILocator SecondaryFarmTypeToggle =>
            _page.GetByTestId("fields.account.policyInput$secondaryFarmTypeApplicable.value");

        private ILocator GetSecondaryFarmCategoryButton(string category) =>
            _page.GetByTestId($"fields.account.policyInput$farmTypeSecondaryCategory.value-{FarmCategoryIndex[category]}");

        private ILocator GetSecondaryFarmSubTypeRadio(string subType) =>
            _page.GetByTestId(new Regex(@"^fields\.account\.policyInput\$farmTypeSecondary\.value-\d+$"))
                 .Filter(new() { Has = _page.GetByText(subType, new() { Exact = true }) });

        private ILocator GrossFarmIncomeInput =>
            _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

        private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
            _page.GetByTestId($"fields.account.policyInput$industrialHemp.value-{(yesOrNo.Equals("No", StringComparison.OrdinalIgnoreCase) ? "0" : "1")}");

        #endregion

        #region Public Methods

        public async Task SelectPrimaryFarmCategoryAsync(string category)
        {
            var btn = GetPrimaryFarmCategoryButton(category);
            await btn.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await btn.ClickAsync();
        }

        public async Task SelectPrimaryFarmSubTypeAsync(string subType)
        {
            await WaitForSpinnerAsync();
            await GetPrimaryFarmSubTypeRadio(subType).ClickAsync();
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

        public async Task SelectSecondaryFarmCategoryAsync(string category)
        {
            await WaitForSpinnerAsync();
            await GetSecondaryFarmCategoryButton(category).ClickAsync();
        }

        public async Task SelectSecondaryFarmSubTypeAsync(string subType)
        {
            await WaitForSpinnerAsync();
            await GetSecondaryFarmSubTypeRadio(subType).ClickAsync();
        }

        public async Task EnterGrossFarmIncomeAsync(string grossFarmIncome)
        {
            await WaitForSpinnerAsync();
            await GrossFarmIncomeInput.ScrollIntoViewIfNeededAsync();
            await GrossFarmIncomeInput.ClearAsync();
            await GrossFarmIncomeInput.FillAsync(grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHempAsync(string growHemp)
        {
            await WaitForSpinnerAsync();
            var hempButton = GetGrowIndustrialHempButton(growHemp);
            await hempButton.ScrollIntoViewIfNeededAsync();
            await ClickIfNotSelectedAsync(hempButton);
        }

        #endregion
    }
}