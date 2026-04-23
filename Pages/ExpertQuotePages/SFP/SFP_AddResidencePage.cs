using Microsoft.Playwright;
using Playwright_POC.Helpers;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
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
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceConditionRating))
                await GetConditionRatingButton(contextData.ResidenceConditionRating).ClickAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceRoofYear))
                await RoofYearInput.FillAsync(contextData.ResidenceRoofYear);

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
                await GetVacantSeasonalButton(contextData.ResidenceSeasonalOrVacant).ClickAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceSolidFuelQuestion))
            {
                var yesOrNo = contextData.ResidenceSolidFuelQuestion.ToLower() is "yes" or "true" ? "Yes" : "No";
                await GetSolidFuelButton(yesOrNo).ClickAsync();
            }
        }
        #endregion
    }
}
