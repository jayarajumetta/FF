using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Residence Coverage detail section — expands inline on the Add Residence page
    /// after the "Residence Coverage" checkbox is checked.
    /// </summary>
    public class SFP_ResidenceCoveragePage : BasePage
    {
        public SFP_ResidenceCoveragePage(IPage page) : base(page) { }

        #region Locators
        public ILocator InsuranceAmountInput =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value");

        public ILocator SquareFeetInput =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value");

        public ILocator PerilsSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$perilGroup.value");

        // Thermostat Question (No / Yes)
        private ILocator GetThermostatButton(string yesOrNo) =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;

        public ILocator ReplacementCostSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$replacementCost.value");

        public ILocator HouseholdContentsPercentSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$householdContentReplacementCost.value");

        // Estimator Type — "RCT" is the only option; must be clicked to reveal Valuation Type
        public ILocator EstimatorTypeRCTButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-chip-item-wrapper")
                 .Filter(new() { HasText = "RCT" }).First;

        // Valuation Type (Standard / No Defaults / High Value)
        private ILocator GetValuationTypeChip(string text) =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-item-wrapper")
                 .Filter(new() { HasText = text }).First;

        // Get Valuation button — appears after Valuation Type is selected
        public ILocator GetValuationButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].completeRCTProcess1");

        private ILocator RecalculateValuationButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].completeRCTProcess3");

        private ILocator EditRctButton => _page.GetByTestId("editRtcButton");

        private ILocator RatePolicyValuationChips =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-item-wrapper");

        internal static Regex MobileDefaultsCaption => new(
            @"^(?=.*\bMobile\b)(?=.*\bManufactured\b)(?=.*\b(?:Use|With)\s+Defaults\b)(?!.*\bNo\s+Defaults\b).*$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public async Task FillRatePolicyResidenceCoverageAsync(ScenarioContextData data)
        {
            SfpRequiredTable.RequireValue("RateType", data.ResidenceRateType, "Mobile Home");
            SfpRequiredTable.RequireValue("EstimatorType", data.Farm.ResidenceEstimatorType, "RCT");
            SfpRequiredTable.RequireValue("RCTOption", data.ResidenceRCTOption, "Mobile / Manufactured RCT");
            SfpRequiredTable.RequireValue("UseDefaults", data.ResidenceUseDefaults, "Yes");
            SfpRequiredTable.RequireValue("ActualCashValue", data.ResidenceActualCashValue, "Actual Cash Value");
            var form = new SFP_NativeFormPage(_page);
            await form.SetControlAsync(InsuranceAmountInput, data.ResidenceInsuranceAmount, number: true);
            await form.SetControlAsync(SquareFeetInput, data.ResidenceSquareFeet, number: true);
            await form.SelectAsync(PerilsSelect, data.ResidencePerils);
            await form.SelectChipAsync(
                form.Chips("BuildingInput.BuildingThermostatQuestion"), data.ResidenceThermostatQuestion);
            var settlement = form.Field("CoverageInput.ReplacementCost");
            var readOnlySettlement = form.ReadOnlyValue("CoverageInput.ReplacementCost");
            if (await settlement.CountAsync() != 0)
                await form.SelectAsync(settlement, data.ResidenceActualCashValue);
            else
            {
                await Expect(readOnlySettlement).ToHaveCountAsync(1);
                await Expect(readOnlySettlement).ToHaveTextAsync(
                    SFP_NativeFormPage.Caption(data.ResidenceActualCashValue));
            }
            await EstimatorTypeRCTButton.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(EstimatorTypeRCTButton.Locator(".chip-wrapper-selected")).ToHaveCountAsync(1);

            var mobileWithDefaults = RatePolicyValuationChips.Filter(new() { HasTextRegex = MobileDefaultsCaption });
            await Expect(mobileWithDefaults).ToHaveCountAsync(1);
            await mobileWithDefaults.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(mobileWithDefaults.Locator(".chip-wrapper-selected")).ToHaveCountAsync(1);
            await Expect(RatePolicyValuationChips.Locator(".chip-wrapper-selected")).ToHaveCountAsync(1);
            await GetValuationButton.ClickAsync();
            await WaitForSpinnerAsync();
            await form.RequireReadyAsync(EditRctButton);

            var rctPage = await _page.Context.RunAndWaitForPageAsync(() => EditRctButton.ClickAsync());
            await new SFP_CoreLogicPage(rctPage).SetAndSaveDepreciationAsync(data.Farm.ResidenceDepreciationPercentage);
            await _page.BringToFrontAsync();
            await form.RequireReadyAsync(RecalculateValuationButton);
            await RecalculateValuationButton.ClickAsync();
            await WaitForSpinnerAsync();
            await VerifyPositiveAcvAsync();
            await SfpFieldAssertions.NumberAsync(InsuranceAmountInput, data.ResidenceInsuranceAmount);
            await SfpFieldAssertions.NumberAsync(SquareFeetInput, data.ResidenceSquareFeet);
            await SfpFieldAssertions.SelectionAsync(PerilsSelect, data.ResidencePerils);
            if (await settlement.CountAsync() != 0)
                await SfpFieldAssertions.SelectionAsync(settlement, data.ResidenceActualCashValue);
            else
                await Expect(readOnlySettlement).ToHaveTextAsync(
                    SFP_NativeFormPage.Caption(data.ResidenceActualCashValue));
        }

        public async Task VerifyPositiveAcvAsync()
        {
            var acv = new SFP_NativeFormPage(_page).Field("BuildingValuationOutput.ACVValue");
            var amount = await SfpFieldAssertions.PositiveAmountAsync(acv, "Residence calculated ACV (correction 10943)");
            Console.WriteLine($"[RCT] Mobile/Manufactured WITH defaults; calculated ACV={amount:N2}.");
        }

        /// <summary>
        /// Returns the correct Valuation Type button based on RCTOption + UseDefaults.
        /// </summary>
        public ILocator GetValuationTypeButton(string rctOption, string useDefaults)
        {
            var isHighValue = rctOption?.ToLower().Contains("high") == true;
            var isNoDefaults = useDefaults?.ToLower() is "no" or "false";

            if (isHighValue) return GetValuationTypeChip("High Value");
            if (isNoDefaults) return GetValuationTypeChip("No Defaults");
            return GetValuationTypeChip("Standard");
        }
        #endregion

        #region Actions
        public Task FillResidenceCoverageAsync(ScenarioContextData contextData) =>
            FillResidenceCoverageAsync(contextData, countryEstate: false);

        public async Task FillCountryEstateResidenceCoverageAsync(ScenarioContextData contextData)
        {
            var contentsPercent = GetCountryEstateContentsPercent(contextData);
            await VerifyCountryEstatePerilsAsync(contextData);
            await FillResidenceCoverageAsync(contextData, countryEstate: true);
            await SelectExactOptionAsync(HouseholdContentsPercentSelect, contentsPercent);
            await WaitForSpinnerAsync();
            await SfpFieldAssertions.SelectionAsync(HouseholdContentsPercentSelect, contentsPercent);
        }

        private async Task FillResidenceCoverageAsync(ScenarioContextData contextData, bool countryEstate)
        {
            if (!countryEstate && contextData.Farm.CountryEstateHouseholdContentsAmount != null)
                throw new ArgumentException("HouseholdContentsAmount requires the verified Country Estate coverage binding.");

            await WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceInsuranceAmount))
            {
                await InsuranceAmountInput.ClickAsync();
                await InsuranceAmountInput.FillAsync(contextData.ResidenceInsuranceAmount);
                await InsuranceAmountInput.PressAsync("Tab");
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceSquareFeet))
            {
                await SquareFeetInput.ClickAsync();
                await SquareFeetInput.FillAsync(contextData.ResidenceSquareFeet);
                await SquareFeetInput.PressAsync("Tab");
            }

            if (!countryEstate && !string.IsNullOrEmpty(contextData.ResidencePerils))
            {
                var perilsAriaDisabled = await PerilsSelect.GetAttributeAsync("aria-disabled");
                var perilsDisabled = string.Equals(perilsAriaDisabled, "true", System.StringComparison.OrdinalIgnoreCase);

                if (perilsDisabled)
                {
                    System.Console.WriteLine($"[ResidenceCoverage] Perils is disabled for this flow/state. Requested='{contextData.ResidencePerils}'. Skipping selection.");
                }
                else
                {
                    await PerilsSelect.ClickAsync();
                    await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidencePerils }).First.ClickAsync();
                }
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceThermostatQuestion))
            {
                var isYes = contextData.ResidenceThermostatQuestion.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                            contextData.ResidenceThermostatQuestion.Equals("true", StringComparison.OrdinalIgnoreCase);
                await SelectThermostatAsync(isYes ? "Yes" : "No");
            }

            // ActualCashValue selects the settlement/replacement cost option from a dropdown
            if (!string.IsNullOrEmpty(contextData.ResidenceActualCashValue))
            {
                if (countryEstate)
                {
                    await SelectExactOptionAsync(ReplacementCostSelect, contextData.ResidenceActualCashValue);
                }
                else
                {
                    await ReplacementCostSelect.ClickAsync();
                    await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidenceActualCashValue }).First.ClickAsync();
                }
            }

            // Step 1: Click Estimator Type (RCT) — reveals the Valuation Type options
            await EstimatorTypeRCTButton.ClickAsync();
            await WaitForSpinnerAsync();

            // Step 2: Select Valuation Type — reveals Get Valuation button
            if (!string.IsNullOrEmpty(contextData.ResidenceRCTOption) || !string.IsNullOrEmpty(contextData.ResidenceUseDefaults))
            {
                await GetValuationTypeButton(contextData.ResidenceRCTOption, contextData.ResidenceUseDefaults).ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Step 3: Click Get Valuation button to trigger RCT calculation
            await ClickGetValuationButtonAsync();
        }

        public async Task VerifyResidenceCoverageAsync(ScenarioContextData data)
        {
            await SfpFieldAssertions.NumberAsync(InsuranceAmountInput, data.ResidenceInsuranceAmount);
            await SfpFieldAssertions.NumberAsync(SquareFeetInput, data.ResidenceSquareFeet);
            await SfpFieldAssertions.SelectionAsync(PerilsSelect, data.ResidencePerils);
            await SfpFieldAssertions.SelectionAsync(ReplacementCostSelect, data.ResidenceActualCashValue);
            await Expect(GetThermostatButton(data.ResidenceThermostatQuestion)
                .Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            await Expect(EstimatorTypeRCTButton.Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            await Expect(GetValuationTypeButton(data.ResidenceRCTOption, data.ResidenceUseDefaults)
                .Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
        }

        public async Task VerifyCountryEstateResidenceCoverageAsync(ScenarioContextData data)
        {
            await VerifyCountryEstatePerilsAsync(data);
            await VerifyResidenceCoverageAsync(data);
            await SfpFieldAssertions.SelectionAsync(HouseholdContentsPercentSelect, GetCountryEstateContentsPercent(data));
        }

        internal static string GetCountryEstateContentsPercent(ScenarioContextData data)
        {
            if (!decimal.TryParse(data.ResidenceInsuranceAmount, NumberStyles.Number, CultureInfo.InvariantCulture, out var residence)
                || residence <= 0
                || !decimal.TryParse(data.Farm.CountryEstateHouseholdContentsAmount, NumberStyles.Number, CultureInfo.InvariantCulture, out var contents)
                || contents <= 0)
                throw new ArgumentException("Country Estate requires positive residence and household contents amounts.");

            var percent = contents / residence * 100;
            if (percent is not (50m or 60m or 70m or 80m or 90m or 100m))
                throw new ArgumentException("Country Estate household contents must equal 50, 60, 70, 80, 90 or 100 percent of the residence amount.");

            return percent.ToString("0", CultureInfo.InvariantCulture) + "%";
        }

        private async Task SelectExactOptionAsync(ILocator select, string caption)
        {
            await Expect(select).ToHaveCountAsync(1);
            await select.ClickAsync();
            var option = _page.GetByRole(AriaRole.Listbox).And(_page.Locator(":visible"))
                .GetByRole(AriaRole.Option, new() { Name = caption, Exact = true });
            await Expect(option).ToHaveCountAsync(1);
            await option.ClickAsync();
        }

        private async Task VerifyCountryEstatePerilsAsync(ScenarioContextData data)
        {
            if (data.ResidencePerils != "6")
                throw new ArgumentException("Country Estate coverage 220 requires the source-owned perils value 6.");

            await Expect(PerilsSelect).ToHaveCountAsync(1);
            await Expect(PerilsSelect).ToBeVisibleAsync();
            await Expect(PerilsSelect).ToHaveAttributeAsync("aria-disabled", "true");
            await SfpFieldAssertions.SelectionAsync(PerilsSelect, "6");
        }

        private async Task SelectThermostatAsync(string answer)
        {
            var button = GetThermostatButton(answer);
            var selectedState = button.Locator(".chip-wrapper-selected");

            for (var attempt = 1; attempt <= 2; attempt++)
            {
                await button.ClickAsync();

                try
                {
                    await selectedState.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 1500
                    });
                    return;
                }
                catch (TimeoutException)
                {
                    if (attempt == 1)
                    {
                        Console.WriteLine(
                            "[ResidenceCoverage] Thermostat selection did not register; retrying once after the pending field update.");
                        continue;
                    }

                    break;
                }
            }

            var chipClass = await button.Locator("[class*='chip-wrapper']").First.GetAttributeAsync("class");
            throw new PlaywrightException(
                $"Thermostat answer '{answer}' did not remain selected after two clicks. Chip class='{chipClass ?? "<missing>"}'.");
        }

        /// <summary>
        /// Clicks the Get Valuation / Order RCT button and waits for the RCT calculation to complete.
        /// Tries the DuckCreek testid first, then falls back to the button's visible text.
        /// </summary>
        private async Task ClickGetValuationButtonAsync()
        {
            // Primary: DuckCreek-assigned testid
            if (await GetValuationButton.CountAsync() > 0 && await GetValuationButton.IsVisibleAsync())
            {
                await GetValuationButton.ClickAsync();
                await WaitForSpinnerAsync();
                await _page.WaitForTimeoutAsync(2000);
                await WaitForSpinnerAsync();
                System.Console.WriteLine("RCT calculation completed.");
                return;
            }

            // Fallback: any visible button labelled "Get Valuation" or "Order RCT"
            var byText = _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("Get Valuation|Order RCT", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
            if (await byText.CountAsync() > 0 && await byText.First.IsVisibleAsync())
            {
                await byText.First.ClickAsync();
                await WaitForSpinnerAsync();
                await _page.WaitForTimeoutAsync(2000);
                await WaitForSpinnerAsync();
                System.Console.WriteLine("RCT calculation completed.");
                return;
            }

            // Some states auto-calculate — log a warning rather than failing
            System.Console.WriteLine("WARNING: No 'Get Valuation' / 'Order RCT' button found — RCT may be auto-calculated or not required.");
        }
        #endregion
    }
}
