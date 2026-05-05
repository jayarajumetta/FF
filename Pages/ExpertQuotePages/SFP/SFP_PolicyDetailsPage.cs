using Microsoft.Playwright;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_PolicyDetailsPage : BasePage
    {
        public SFP_PolicyDetailsPage(IPage page) : base(page) { }

        #region Locators

        private ILocator GetPrimaryFarmCategoryButton(string category) =>
            _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-item-wrapper")
                 .Filter(new() { HasText = category }).First;

        // Sub-type indices re-index per category, so match by GetByTestId regex + exact text
        private ILocator GetPrimaryFarmSubTypeRadio(string subType) =>
            _page.GetByTestId(new Regex(@"^fields\.account\.policyInput\$farmType\.value-\d+$"))
                 .Filter(new() { Has = _page.GetByText(subType, new() { Exact = true }) });

        // ANi aa-toggle component — role="switch" with aria-checked for state.
        // The toggle is an <input type="checkbox"> inside a custom aa-toggle component.
        // The native input is CSS-hidden — use Attached (not Visible) to wait for it.
        // Click goes to the visible <label for=...> which wraps the visual track.
        private ILocator SecondaryFarmTypeToggleInput =>
            _page.Locator("[data-testid='fields.account.policyInput$secondaryFarmTypeApplicable.value'] input[type='checkbox']");
        private ILocator SecondaryFarmTypeToggleLabel =>
            _page.Locator("label[for='fields.account.policyInput$secondaryFarmTypeApplicable.value']");

        private ILocator GetSecondaryFarmCategoryButton(string category) =>
            _page.GetByTestId("fields.account.policyInput$farmTypeSecondaryCategory.value-chip-item-wrapper")
                 .Filter(new() { HasText = category }).First;

        private ILocator GetSecondaryFarmSubTypeRadio(string subType) =>
            _page.GetByTestId(new Regex(@"^fields\.account\.policyInput\$farmTypeSecondary\.value-\d+$"))
                 .Filter(new() { Has = _page.GetByText(subType, new() { Exact = true }) });

        private ILocator GrossFarmIncomeInput =>
            _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

        private ILocator GetGrowIndustrialHempButton(string yesOrNo) =>
            _page.GetByTestId("fields.account.policyInput$industrialHemp.value-chip-wrapper")
                 .Filter(new() { HasText = yesOrNo });

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

            // Focus dance: click into GrossFarmIncome then blur it.
            // This mirrors the Tosca workaround — Angular's change detection on this screen
            // is triggered by focus/blur events; without it the secondary farm type section
            // may remain in an unrendered/unattached state.
            try
            {
                await GrossFarmIncomeInput.ClickAsync();
                await _page.Keyboard.PressAsync("Tab");
                await WaitForSpinnerAsync();
            }
            catch (PlaywrightException ex)
            {
                Console.WriteLine($"[PolicyDetails] Focus/blur nudge failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Enables or disables the secondary farm type toggle when the control is present.
        /// </summary>
        /// <returns>True if the toggle was found and set; false if the toggle was not present (skip secondary farm type).</returns>
        public async Task<bool> SetSecondaryFarmTypeAsync(bool enable)
        {
            await WaitForSpinnerAsync();

            var input = SecondaryFarmTypeToggleInput;
            var label = SecondaryFarmTypeToggleLabel;

            // Input is CSS-hidden (ANi toggle pattern) — wait for Attached, not Visible.
            // Label wraps the visual track and IS visible; used for clicking.
            try
            {
                await input.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 25000 });
            }
            catch (TimeoutException)
            {
                Console.WriteLine("[PolicyDetails] Secondary farm type toggle not found after 25s — skipping.");
                return false;
            }

            await label.ScrollIntoViewIfNeededAsync();

            var isChecked = await input.IsCheckedAsync();

            if (enable != isChecked)
            {
                await label.ClickAsync();
                // Focus dance after toggle click: tab through to nudge Angular into rendering
                // the secondary category buttons (same Tosca workaround pattern).
                try
                {
                    await _page.Keyboard.PressAsync("Tab");
                    await GrossFarmIncomeInput.ClickAsync();
                    await _page.Keyboard.PressAsync("Tab");
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine($"[PolicyDetails] Secondary toggle focus nudge failed: {ex.Message}");
                }
                await WaitForSpinnerAsync();
            }
            return true;
        }

        public async Task<bool> SelectSecondaryFarmCategoryAsync(string category)
        {
            await WaitForSpinnerAsync();

            // Strategy 1: dedicated secondary testid (most states)
            var btn = GetSecondaryFarmCategoryButton(category);
            try
            {
                await btn.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                await btn.ClickAsync();
                Console.WriteLine($"[PolicyDetails] Secondary farm category '{category}' selected via secondary testid.");
                return true;
            }
            catch (TimeoutException) { }

            // Strategy 2: some states (e.g. TN) reuse the primary farmTypeCategory testid for both
            // sections — the secondary section renders a second set of the same buttons.
            // Nth(1) targets the second chip with matching text = the secondary category row.
            var primaryBtn = _page.GetByTestId("fields.account.policyInput$farmTypeCategory.value-chip-item-wrapper")
                                  .Filter(new() { HasText = category });
            try
            {
                var count = await primaryBtn.CountAsync();
                if (count > 2)
                {
                    await primaryBtn.Nth(2).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                    await primaryBtn.Nth(2).ClickAsync();
                    Console.WriteLine($"[PolicyDetails] Secondary farm category '{category}' selected via Nth(1) fallback.");
                    return true;
                }
            }
            catch (TimeoutException) { }

            // Strategy 3: text-based button click scoped to the secondary farm type section.
            // Finds any visible button with the category text that is NOT the already-active primary button.
            var textBtn = _page.GetByRole(AriaRole.Button, new() { Name = category.ToUpper(), Exact = true })
                               .Or(_page.GetByRole(AriaRole.Button, new() { Name = category, Exact = true }));
            try
            {
                var count = await textBtn.CountAsync();
                // Skip index 0 (primary) — click the next available visible one
                for (var i = 1; i < count; i++)
                {
                    if (await textBtn.Nth(i).IsVisibleAsync())
                    {
                        await textBtn.Nth(i).ClickAsync();
                        Console.WriteLine($"[PolicyDetails] Secondary farm category '{category}' selected via text button Nth({i}).");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PolicyDetails] Text-button strategy failed: {ex.Message}");
            }

            Console.WriteLine($"[PolicyDetails] Secondary farm category '{category}' could not be selected — skipping.");
            return false;
        }

        public async Task<bool> SelectSecondaryFarmSubTypeAsync(string subType)
        {
            await WaitForSpinnerAsync();
            var radio = GetSecondaryFarmSubTypeRadio(subType);
            try
            {
                await radio.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                await radio.First.ClickAsync();
                return true;
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[PolicyDetails] Secondary farm sub-type '{subType}' radio not visible — skipping.");
                return false;
            }
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
