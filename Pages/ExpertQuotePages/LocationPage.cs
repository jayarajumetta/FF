using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reqnroll;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages
{
    public class LocationPage : BasePage
    {
        private readonly ScenarioContextData _contextData;
        public LocationPage(IPage page, ScenarioContextData contextData) : base(page)
        {
            _contextData = contextData;
        }

        public async Task EnterLocationInformationAsync()
        {
            await SetLocationNickname(_contextData.LocationNickname);
            await SelectLocationType(_contextData.LocationType);
            await SetMilesFromFireDepartment(_contextData.MilesFromFireDepartment);
            await SelectFeetFromHydrant(_contextData.FeetFromHydrant);
            await SetTotalFarmingAcreage(_contextData.TotalAcreage);

            await WaitForSpinnerAsync();
        }

        private ILocator LocationNicknameInput() => _page.Locator("input[data-testid*='locationInput$additionalDescription.value']");

        private async Task SetLocationNickname(string nickname)
        {
            var input = LocationNicknameInput();
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(nickname);
            await _page.WaitForTimeoutAsync(3000);
        }

        private ILocator LocationTypeButton(string typeText) => _page.GetByRole(AriaRole.Button, new() { Name = typeText });

        public async Task SelectLocationType(string locationType)
        {
            var normalized = (locationType ?? "").Trim();

            var btn = LocationTypeButton(normalized);
            await btn.ScrollIntoViewIfNeededAsync();

            // Check if already selected
            var cls = await btn.GetAttributeAsync("class") ?? string.Empty;
            if (cls.Contains("mat-button-toggle-checked", StringComparison.OrdinalIgnoreCase))
                return; // already selected, no action needed

            await btn.ClickAsync(new() { Force = true });
            await _page.WaitForTimeoutAsync(3000);
        }

        private ILocator MilesFromFireDepartment() => _page.Locator("input[data-testid*='locationInput$milesFromFireDepartment.value']");

        public async Task SetMilesFromFireDepartment(string miles)
        {
            var input = MilesFromFireDepartment().First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await input.ScrollIntoViewIfNeededAsync();
            await input.ClearAsync();
            await input.FillAsync(miles?.Trim() ?? string.Empty);
            await input.PressAsync("Tab"); // Blur to trigger Angular validation
            await WaitForSpinnerAsync();
        }

        private ILocator FeetFromHydrantSelect() =>
            _page.Locator("mat-select[data-testid*='locationInput$feetFromHydrant.value']").First;

        public async Task SelectFeetFromHydrant(string value)
        {
            var normalizedValue = value?.Trim() ?? string.Empty;
            
            var select = FeetFromHydrantSelect();
            await select.ScrollIntoViewIfNeededAsync();
            await WaitForSpinnerAsync();
            
            // Click to open the dropdown
            await select.ClickAsync(new() { Timeout = 30000 });
            await _page.WaitForTimeoutAsync(500);
            
            // Wait for panel to appear and select option by text
            var option = _page.Locator(".cdk-overlay-pane mat-option").GetByText(normalizedValue, new() { Exact = true });
            await option.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await option.ClickAsync();
            
            // Wait for panel to close
            await _page.WaitForTimeoutAsync(300);
            await _page.Keyboard.PressAsync("Tab");
            await WaitForSpinnerAsync();
        }

        private ILocator TotalAcreageInput() => _page.Locator("input[data-testid*='locationInput$acreage.value']");

        public async Task SetTotalFarmingAcreage(string acreage)
        {
            var input = TotalAcreageInput();
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(acreage);
        }

        private ILocator WindHailScope() => _page.Locator("div:has(button[data-testid*='locationInput$windHailDeductible.value'])").First;
        private ILocator WindHailDeductibleChip(string text) => WindHailScope()
                                        .Locator("button[data-testid*='locationInput$windHailDeductible.value']")
                                        .Filter(new() { HasTextString = text });

        private ILocator WindHailMoreOptionsButton() =>
                WindHailScope().GetByRole(AriaRole.Button, new() { Name = "More Options", Exact = true });
        private ILocator WindHailMenuItem(string text) =>
                _page.Locator(".cdk-overlay-pane .mat-menu.panel, .cdk-overlay-pane .mat-mdc-menu-panel")
                .Last
                .GetByRole(AriaRole.Menuitem, new() { Name = text, Exact = true });


        public async Task SelectWindHailDeductibleAsync(string deductible)
        {
            var choice = (deductible ?? "").Trim().ToUpperInvariant();

            await Helpers.Helpers.SelectButtonAsync(
                page: _page,
                scope: WindHailScope(),
                value: choice,
                moreOptionsButton: WindHailMoreOptionsButton(),
                timeoutMs: 30000);

            await WaitForSpinnerAsync();
        }
    }
}