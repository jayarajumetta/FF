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

        // ANi aa-toggle component — role="switch" with aria-checked for state.
        // GetByTestId targets the outer host element; GetByRole is preferred as it
        // also validates the element is interactive (not just present in the DOM).
        private ILocator SecondaryFarmTypeToggle =>
            _page.GetByRole(AriaRole.Switch, new() { Name = "Add Secondary Farm Type" });

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
            // Wait for Policy Details page to be fully loaded before interacting
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await WaitForSpinnerAsync();

            var btn = GetPrimaryFarmCategoryButton(category);
            await btn.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await btn.ClickAsync();
            // Wait for DuckCreek's XHR spinner to appear then clear
            var overlay = _page.Locator(".ngx-spinner-overlay");
            try { await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 3000 }); }
            catch (TimeoutException) { }
            await WaitForSpinnerAsync();
        }

        public async Task SelectPrimaryFarmSubTypeAsync(string subType)
        {
            await WaitForSpinnerAsync();
            await GetPrimaryFarmSubTypeRadio(subType).ClickAsync();
            // DuckCreek fires an XHR after radio click — spinner appears ~200ms later, so wait for it to appear first
            var overlay = _page.Locator(".ngx-spinner-overlay");
            try { await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 3000 }); }
            catch (TimeoutException) { }
            await WaitForSpinnerAsync();
            // Wait for DuckCreek to finish re-rendering the form section.
            // GrossFarmIncome and the secondary farm type toggle render in the same XHR pass;
            // confirming GrossFarmIncome is visible means the whole section is ready.
            try
            {
                await GrossFarmIncomeInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            }
            catch (TimeoutException)
            {
                Console.WriteLine("[PolicyDetails] GrossFarmIncome not visible after 15s — page may still be rendering.");
            }
        }

        /// <returns>True if the toggle was found and set; false if the toggle was not present (skip secondary farm type).</returns>
        public async Task<bool> SetSecondaryFarmTypeAsync(bool enable)
        {
            await WaitForSpinnerAsync();

            var toggle = SecondaryFarmTypeToggle;

            // The toggle appears after DuckCreek re-renders following the subtype XHR.
            // Use a 15s window; if the toggle never becomes visible the current
            // farm type/state combination does not offer secondary farm type — skip.
            try
            {
                await toggle.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            }
            catch (TimeoutException)
            {
                Console.WriteLine("[PolicyDetails] Secondary farm type toggle not visible — skipping.");
                return false;
            }

            await toggle.ScrollIntoViewIfNeededAsync();

            // ANi aa-toggle uses aria-checked (not an <input>) to expose its state.
            var ariaChecked = await toggle.GetAttributeAsync("aria-checked");
            var isChecked = string.Equals(ariaChecked, "true", StringComparison.OrdinalIgnoreCase);

            if (enable != isChecked)
            {
                await toggle.ClickAsync();
                await WaitForSpinnerAsync();
            }
            return true;
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