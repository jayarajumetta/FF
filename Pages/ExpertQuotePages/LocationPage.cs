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
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(miles);
            await _page.WaitForTimeoutAsync(3000);
        }

        private ILocator FeetFromHydrantSelect() =>
            _page.Locator("[data-testid*='locationInput$feetFromHydrant.value']").First;

        public async Task SelectFeetFromHydrant(string value)
        {
            var select = FeetFromHydrantSelect();
            await _page.WaitForTimeoutAsync(3000);
            await Helpers.Helpers.SelectByTextAsync(
                page: _page,
                matSelect: select,
                optionText: value,
                timeoutMs: 30000,
                blurAfterSelect: true);

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