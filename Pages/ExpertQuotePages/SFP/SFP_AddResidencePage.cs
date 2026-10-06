using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Add Residence form - appears when clicking "Add Residence" on the Locations page.
    /// </summary>
    public class SFP_AddResidencePage : BasePage
    {
        public SFP_AddResidencePage(IPage page) : base(page) { }

        #region Form Fields
        public ILocator AdditionalDescriptionInput => _page.GetByTestId("fields.building.rows[0].buildingInput$additionalDescription.value");
        public ILocator YearBuiltInput => _page.GetByTestId("fields.building.rows[0].buildingInput$yearBuilt.value");
        public ILocator YearRenovatedInput => _page.GetByTestId("fields.building.rows[0].buildingInput$yearRenovated.value");
        public ILocator WiringYearInput => _page.GetByTestId("fields.building.rows[0].buildingInput$wiringYear.value");
        public ILocator HeatingYearInput => _page.GetByTestId("fields.building.rows[0].buildingInput$heatingYear.value");
        public ILocator PlumbingYearInput => _page.GetByTestId("fields.building.rows[0].buildingInput$plumbingYear.value");
        public ILocator RoofYearInput => _page.GetByTestId("fields.building.rows[0].buildingInput$roofYear.value");
        public ILocator FrameSelect => _page.GetByTestId("fields.building.rows[0].buildingInput$constructionCode.value");
        public ILocator RoofTypeSelect => _page.GetByTestId("fields.building.rows[0].buildingInput$roofType.value");
        public ILocator RoofImpactResistanceSelect => _page.GetByTestId("fields.building.rows[0].buildingInput$roofImpactResistance.value");
        #endregion

        #region Toggle Buttons
        // Occupancy (Owner / Tenant)
        private ILocator GetOccupancyButton(string value) =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-chip-item-wrapper")
                 .Filter(new() { HasText = value }).First;

        // Number of Families (Single Family / Duplex / Triplex / Fourplex)
        public ILocator GetNumberOfFamiliesButton(string value) =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-chip-item-wrapper")
                 .Filter(new() { HasText = value }).First;

        // Service Panel (Main Breaker / Fuse Block)
        private ILocator GetServicePanelButton(string value) =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$eQServicePanel.value-chip-item-wrapper")
                 .Filter(new() { HasText = value }).First;

        // Condition Rating (1 / 2 / 3)
        public ILocator GetConditionRatingButton(string rating) =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-chip-item-wrapper")
                 .Filter(new() { HasText = rating }).First;

        // Vacant/Seasonal (No / Seasonal / Vacant)
        public ILocator GetVacantSeasonalButton(string value) =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-chip-item-wrapper")
                 .Filter(new() { HasText = value?.Trim() ?? "No" }).First;

        // Some states/products render Vacant/Seasonal as a dropdown instead of chips
        public ILocator VacantSeasonalSelect =>
            _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value").First;

        // Solid Fuel Heating Devices (No / Yes)
        private ILocator GetSolidFuelButton(string yesOrNo) =>
            _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;
        #endregion

        #region Coverage Checkboxes (TestId-based)
        // DuckCreek renders checkboxes with both a <label> and <input> sharing the same data-testid.
        // Target the label element specifically to avoid strict mode violations.
        public ILocator LightningRodCreditCheckbox => _page.Locator("label[data-testid='fields.building.rows[0].buildingInput$lightningRodCredit.value']");
        public ILocator NonSmokersCreditCheckbox => _page.Locator("label[data-testid='fields.building.rows[0].buildingInput$nonSmokersCredit.value']");
        public ILocator OrdinanceOrLawCheckbox => _page.Locator("label[data-testid='fields.building.rows[0].buildingInput$ordinanceOrLaw.value']");
        public ILocator ProtectiveDeviceCreditCheckbox => _page.Locator("label[data-testid='fields.building.rows[0].buildingInput$protectiveDeviceCreditControl.value']");
        public ILocator BuildersRiskCoverageCheckbox => _page.Locator("label[data-testid='fields.risk.rows[0].riskInput$eqCovResidenceBuildersRisk.value']");
        public ILocator ResidenceCoverageCheckbox => _page.Locator("label[data-testid='fields.risk.rows[0].riskInput$eQResidenceCoverage.value']");
        public ILocator ContentsCoverageCheckbox => _page.Locator("label[data-testid='fields.risk.rows[0].riskInput$eQResidenceContentsCoverage.value']");
        public ILocator OptionalCoverageCheckbox => _page.Locator("label[data-testid='fields.risk.rows[0].riskInput$eQOptionalCoveragesCatalog.value']");
        #endregion

        #region Actions
        public ILocator SaveButton => _page.GetByTestId("fields.data.save");

        public async Task AddRatePolicyContentsAndSaveAsync(
            ScenarioContextData data, IReadOnlyDictionary<string, string> values)
        {
            SfpRequiredTable.RequireValue("CoverageType", values["CoverageType"], "Mobile Home Contents");
            SfpRequiredTable.RequireValue("RateType", data.ResidenceRateType, "Mobile Home");
            await SfpFieldAssertions.SelectionAsync(FrameSelect, "Mobile Home");
            var form = new SFP_NativeFormPage(_page);
            var previousLimits = await form.FieldIdsAsync("CoverageInput.Limit");
            await form.CheckAsync("RiskInput.EQResidenceContentsCoverage");
            // Use the newly returned coverage path, not an assumed contents collection or row index.
            var section = await form.AdditionalSectionAsync("CoverageInput.Limit", previousLimits);
            await form.SetSectionAsync(section, "CoverageInput.Limit", values["InsuranceAmount"], number: true);
            await form.SetSectionAsync(section, "CoverageInput.PerilGroup", values["Perils"]);
            await form.SetSectionAsync(section, "CoverageInput.ReplacementCost", values["ReplacementCost"]);
            var coverage = new SFP_ResidenceCoveragePage(_page);
            await coverage.VerifyPositiveAcvAsync();
            await VerifyResidenceFormAsync(data);
            await SfpFieldAssertions.NumberAsync(coverage.InsuranceAmountInput, data.ResidenceInsuranceAmount);
            await SaveButton.ClickAsync();
            await WaitForSpinnerAsync();
            var locations = new SFP_LocationsResidencesBuildingsPage(_page);
            await locations.WaitUntilReadyAsync();

            await locations.OpenResidenceAsync();
            await VerifyResidenceFormAsync(data);
            await coverage.VerifyPositiveAcvAsync();
            await SfpFieldAssertions.NumberAsync(coverage.InsuranceAmountInput, data.ResidenceInsuranceAmount);
            await form.VerifyControlAsync(form.SectionField(section, "CoverageInput.Limit"), values["InsuranceAmount"], number: true);
            await form.VerifyControlAsync(form.SectionField(section, "CoverageInput.PerilGroup"), values["Perils"]);
            await form.VerifyControlAsync(form.SectionField(section, "CoverageInput.ReplacementCost"), values["ReplacementCost"]);
            await locations.LocationsNavigation.ClickAsync();
            await WaitForSpinnerAsync();
            await locations.WaitUntilReadyAsync();
        }

        /// <summary>
        /// Fill the residence form using context data
        /// </summary>
        public async Task FillResidenceFormAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceAdditionalDesc))
                await AdditionalDescriptionInput.FillAsync(contextData.ResidenceAdditionalDesc);

            if (!string.IsNullOrEmpty(contextData.ResidenceYearBuilt))
                await YearBuiltInput.FillAsync(contextData.ResidenceYearBuilt);

            await WaitForSpinnerAsync();

            // Set Occupancy first — NumberOfFamilies depends on it being set
            await GetOccupancyButton("Owner").ClickAsync();
            await WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceNumberOfFamilies))
                await GetNumberOfFamiliesButton(contextData.ResidenceNumberOfFamilies).ClickAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceRateType))
            {
                await FrameSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidenceRateType }).First.ClickAsync();
                await WaitForSpinnerAsync(); // RateType change triggers recalculation; subsequent dropdowns fail if we don't wait
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceConditionRating))
                await GetConditionRatingButton(contextData.ResidenceConditionRating).ClickAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceRoofYear))
                await RoofYearInput.FillAsync(contextData.ResidenceRoofYear);

            if (!string.IsNullOrEmpty(contextData.Farm.ResidenceHeatingYear))
                await FillRenovationYearAsync(HeatingYearInput, contextData.Farm.ResidenceHeatingYear);
            if (!string.IsNullOrEmpty(contextData.Farm.ResidencePlumbingYear))
                await FillRenovationYearAsync(PlumbingYearInput, contextData.Farm.ResidencePlumbingYear);
            if (!string.IsNullOrEmpty(contextData.Farm.ResidenceElectricalYear))
                await FillRenovationYearAsync(WiringYearInput, contextData.Farm.ResidenceElectricalYear);

            if (!string.IsNullOrEmpty(contextData.ResidenceRoofType))
            {
                await RoofTypeSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidenceRoofType }).First.ClickAsync();
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceRoofImpact))
            {
                await RoofImpactResistanceSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidenceRoofImpact }).First.ClickAsync();
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceSeasonalOrVacant))
                await SelectVacantSeasonalAsync(contextData.ResidenceSeasonalOrVacant);

            if (!string.IsNullOrEmpty(contextData.ResidenceSolidFuelQuestion))
            {
                var yesOrNo = contextData.ResidenceSolidFuelQuestion.ToLower() is "yes" or "true" ? "Yes" : "No";
                await GetSolidFuelButton(yesOrNo).ClickAsync();
            }
        }

        private async Task FillRenovationYearAsync(ILocator input, string year)
        {
            await input.FillAsync(year);
            await input.PressAsync("Tab");
            await WaitForSpinnerAsync();
            await Expect(input).ToHaveValueAsync(year);
        }

        public Task VerifyResidenceFormAsync(ScenarioContextData data) =>
            VerifyResidenceFormAsync(data, countryEstate: false);

        public Task VerifyCountryEstateResidenceFormAsync(ScenarioContextData data)
        {
            if (data.ResidenceSeasonalOrVacant != null)
                throw new ArgumentException("Country Estate cannot verify a supplied SeasonalOrVacant value.");

            return VerifyResidenceFormAsync(data, countryEstate: true);
        }

        private async Task VerifyResidenceFormAsync(ScenarioContextData data, bool countryEstate)
        {
            await Expect(AdditionalDescriptionInput).ToHaveValueAsync(data.ResidenceAdditionalDesc);
            await Expect(YearBuiltInput).ToHaveValueAsync(data.ResidenceYearBuilt);
            await Expect(RoofYearInput).ToHaveValueAsync(data.ResidenceRoofYear);
            if (data.Farm.ResidenceHeatingYear != null)
                await Expect(HeatingYearInput).ToHaveValueAsync(data.Farm.ResidenceHeatingYear);
            if (data.Farm.ResidencePlumbingYear != null)
                await Expect(PlumbingYearInput).ToHaveValueAsync(data.Farm.ResidencePlumbingYear);
            if (data.Farm.ResidenceElectricalYear != null)
                await Expect(WiringYearInput).ToHaveValueAsync(data.Farm.ResidenceElectricalYear);
            await SfpFieldAssertions.SelectionAsync(FrameSelect, data.ResidenceRateType);
            await SfpFieldAssertions.SelectionAsync(RoofTypeSelect, data.ResidenceRoofType);
            await SfpFieldAssertions.SelectionAsync(RoofImpactResistanceSelect, data.ResidenceRoofImpact);
            await Expect(GetNumberOfFamiliesButton(data.ResidenceNumberOfFamilies)
                .Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            await Expect(GetConditionRatingButton(data.ResidenceConditionRating)
                .Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            await Expect(GetSolidFuelButton(data.ResidenceSolidFuelQuestion)
                .Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            if (countryEstate)
            {
                var controls = _page.GetByTestId(new Regex(
                    @"^fields\.building\.rows\[0\]\.buildingInput\$eQVacantSeasonal\.value(?:-chip-item-wrapper)?$",
                    RegexOptions.IgnoreCase)).And(_page.Locator(":visible"));
                await Expect(controls).ToHaveCountAsync(0);
            }
            else
            {
                var vacantChip = GetVacantSeasonalButton(data.ResidenceSeasonalOrVacant);
                if (await vacantChip.IsVisibleAsync())
                    await Expect(vacantChip.Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
                else
                    await SfpFieldAssertions.SelectionAsync(VacantSeasonalSelect, data.ResidenceSeasonalOrVacant);
            }
        }

        private async Task SelectVacantSeasonalAsync(string value)
        {
            var normalized = (value ?? "No").Trim();

            // 1) Preferred: chip control
            var chipOption = GetVacantSeasonalButton(normalized);
            if (await chipOption.CountAsync() > 0 && await chipOption.IsVisibleAsync())
            {
                await chipOption.ClickAsync();
                await WaitForSpinnerAsync();
                return;
            }

            // 2) Fallback: mat-select dropdown
            if (await VacantSeasonalSelect.CountAsync() > 0 && await VacantSeasonalSelect.IsVisibleAsync())
            {
                await PnCTestAutomation.Helpers.Helpers.SelectByTextAsync(_page, VacantSeasonalSelect, normalized, timeoutMs: 15000, blurAfterSelect: false);
                await WaitForSpinnerAsync();
                return;
            }

            // 3) Optional/hidden in some variants - continue
            System.Console.WriteLine($"[Residence] Vacant/Seasonal control not found. Requested='{normalized}'. Skipping.");
        }
        #endregion
    }
}
