using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// SFP Add Coverage: Country Estate Endorsement panel.
    /// Uses the CE-specific defaults required by the CE scenario.
    /// </summary>
    public class SFP_AddCountryEstateCoveragePage : BasePage
    {
        public SFP_AddCountryEstateCoveragePage(IPage page) : base(page) { }

        public sealed class CountryEstateCoverageSelection
        {
            public string DivisionIWaterDamage { get; init; } = "$5,000";
            public string DivisionIIUnscheduledStructures { get; init; } = "$5,000";
            public string DivisionIIIBlanketFppSublimit { get; init; } = "5000";
            public string DivisionIIIBlanketFppDeductible { get; init; } = "$1,000";
            public string DivisionVLiabilityLimit { get; init; } = "$500,000/$1,000,000";
        }

        private ILocator PageHeader => _page.GetByText("Country Estate Endorsement Selection", new() { Exact = true }).First;

        private ILocator CountryEstateTypeSelectRadio =>
            _page.GetByTestId("fields.line.lineCoverages$countryEstateType.value-2").First;

        private ILocator WaterDamageDivisionISelect =>
            _page.GetByTestId("fields.line.covCountryEstate_D1.waterDamage_2.value").First;

        private ILocator WaterDamageDivisionIISelect =>
            _page.GetByTestId("fields.line.covCountryEstate_D2.unschedStructures_3.value").First;

        private ILocator BlanketFppDivisionIIISublimitInput =>
            _page.GetByTestId("fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_2.value").First;

        private ILocator BlanketFppDivisionIIIDeductibleSelect =>
            _page.GetByTestId("fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_3.value").First;

        private ILocator LiabilityDivisionVSelect =>
            _page.GetByTestId("fields.line.liability_D5.liabilityLimit_2.value").First;

        public async Task AddCoverageAsync(CountryEstateCoverageSelection selection = null)
        {
            selection ??= new CountryEstateCoverageSelection();

            await PageHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });

            await SelectCountryEstateTypeAsync();
            await SelectWaterDamageDivisionIAsync(selection.DivisionIWaterDamage);
            await SelectWaterDamageDivisionIIAsync(selection.DivisionIIUnscheduledStructures);
            await EnterBlanketFppDivisionIIISublimitAsync(selection.DivisionIIIBlanketFppSublimit);
            await SelectBlanketFppDivisionIIIDeductibleAsync(selection.DivisionIIIBlanketFppDeductible);
            await SelectLiabilityDivisionVAsync(selection.DivisionVLiabilityLimit);
            await ClickSaveAsync();
            await WaitForSpinnerAsync();
        }

        public async Task SelectCountryEstateTypeAsync()
        {
            var radio = CountryEstateTypeSelectRadio;
            await radio.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });

            var cls = await radio.GetAttributeAsync("class") ?? string.Empty;
            if (!cls.Contains("mat-mdc-radio-checked", StringComparison.OrdinalIgnoreCase))
            {
                await radio.ScrollIntoViewIfNeededAsync();
                await radio.ClickAsync(new() { Force = true });
                await WaitForSpinnerAsync();
            }
        }

        public async Task SelectWaterDamageDivisionIAsync(string value)
        {
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, WaterDamageDivisionISelect, value, timeoutMs: 30000, blurAfterSelect: false);
            await WaitForSpinnerAsync();
        }

        public async Task SelectWaterDamageDivisionIIAsync(string value)
        {
            await WaterDamageDivisionIISelect.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, WaterDamageDivisionIISelect, value, timeoutMs: 30000, blurAfterSelect: false);
            await WaitForSpinnerAsync();
        }

        public async Task EnterBlanketFppDivisionIIISublimitAsync(string amount)
        {
            await BlanketFppDivisionIIISublimitInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            await BlanketFppDivisionIIISublimitInput.ScrollIntoViewIfNeededAsync();
            await BlanketFppDivisionIIISublimitInput.FillAsync(amount);
            await BlanketFppDivisionIIISublimitInput.PressAsync("Tab");
            await WaitForSpinnerAsync();
        }

        public async Task SelectBlanketFppDivisionIIIDeductibleAsync(string value)
        {
            await BlanketFppDivisionIIIDeductibleSelect.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, BlanketFppDivisionIIIDeductibleSelect, value, timeoutMs: 30000, blurAfterSelect: false);
            await WaitForSpinnerAsync();
        }

        public async Task SelectLiabilityDivisionVAsync(string value)
        {
            await LiabilityDivisionVSelect.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, LiabilityDivisionVSelect, value, timeoutMs: 30000, blurAfterSelect: false);
            await WaitForSpinnerAsync();
        }

    }
}
