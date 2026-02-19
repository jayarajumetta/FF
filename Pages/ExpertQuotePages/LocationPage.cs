using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reqnroll;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Playwright_POC.Pages
{
    public class LocationPage
    {
        private readonly IPage _page;
        private readonly ScenarioContextData _contextData;
        public LocationPage(IPage page, ScenarioContextData contextData)
        {
            _page = page;
            _contextData = contextData;
        }

        public async Task EnterLocationInformationAsync()
        {
            await SetLocationNickname(_contextData.LocationNickname);
            await SelectLocationType(_contextData.LocationType);
            await SetMilesFromFireDepartment(_contextData.MilesFromFireDepartment);
            await SelectFeetFromHydrant(_contextData.FeetFromHydrant);
            await SetTotalFarmingAcreage(_contextData.TotalAcreage);

            await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);
        }

        private ILocator LocationNicknameInput() => _page.Locator("input[data-testid*='locationInput$additionalDescription.value']");

        private async Task SetLocationNickname(string nickname)
        {
            var input = LocationNicknameInput();
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(nickname);
        }

        private ILocator LocationTypeButton(string typeText) => _page.GetByRole(AriaRole.Button, new() { Name = typeText });

        public async Task SelectLocationType(string locationType)
        {
            var normalized = (locationType ?? "").Trim();

            var btn = LocationTypeButton(normalized);
            await btn.ScrollIntoViewIfNeededAsync();
            await btn.ClickAsync(new() { Force = true });
        }

        private ILocator MilesFromFireDepartment() => _page.Locator("input[data-testid*='locationInput$milesFromFireDepartment.value']");

        public async Task SetMilesFromFireDepartment(string miles)
        {
            var input = MilesFromFireDepartment().First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(miles);
        }

        private ILocator FeetFromHydrantSelect() => _page.Locator("mat-select[data-testid*='locationInput$feetFromHydrant.value']");

        public async Task SelectFeetFromHydrant(string value)
        {
            var select = FeetFromHydrantSelect().First;
            await select.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await select.ClickAsync(new() { Force = true });

            var option = _page.Locator("mat-option", new() { HasTextString = value }).First;
            await option.ClickAsync(new() { Force = true });
        }

        private ILocator TotalAcreageInput() => _page.Locator("input[data-testid*='locationInput$acreage.value']");

        public async Task SetTotalFarmingAcreage(string acreage)
        {
            var input = TotalAcreageInput().First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(acreage);
        }
    }
}