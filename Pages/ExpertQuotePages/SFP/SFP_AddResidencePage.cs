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
        // Occupancy
        public ILocator OwnerButton => _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-0");
        public ILocator TenantButton => _page.GetByTestId("fields.building.rows[0].buildingInput$occupancy.value-1");

        // Number of Families
        public ILocator SingleFamilyButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-0");
        public ILocator DuplexButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-1");
        public ILocator TriplexButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-2");
        public ILocator FourplexButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-3");

        // Service Panel
        public ILocator MainBreakerButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQServicePanel.value-0");
        public ILocator FuseBlockButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQServicePanel.value-1");

        // Condition Rating (1/2/3)
        public ILocator ConditionRating1Button => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-0");
        public ILocator ConditionRating2Button => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-1");
        public ILocator ConditionRating3Button => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-2");

        // Vacant/Seasonal
        public ILocator NotVacantSeasonalButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-0");
        public ILocator SeasonalButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-1");
        public ILocator VacantButton => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-2");

        // Solid Fuel Heating Devices
        public ILocator SolidFuelNoButton => _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-0");
        public ILocator SolidFuelYesButton => _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-1");
        #endregion

        #region Coverage Checkboxes (TestId-based)
        public ILocator LightningRodCreditCheckbox => _page.GetByTestId("fields.building.rows[0].buildingInput$lightningRodCredit.value");
        public ILocator NonSmokersCreditCheckbox => _page.GetByTestId("fields.building.rows[0].buildingInput$nonSmokersCredit.value");
        public ILocator OrdinanceOrLawCheckbox => _page.GetByTestId("fields.building.rows[0].buildingInput$ordinanceOrLaw.value");
        public ILocator ProtectiveDeviceCreditCheckbox => _page.GetByTestId("fields.building.rows[0].buildingInput$protectiveDeviceCreditControl.value");
        public ILocator BuildersRiskCoverageCheckbox => _page.GetByTestId("fields.risk.rows[0].riskInput$eqCovResidenceBuildersRisk.value");
        public ILocator ResidenceCoverageCheckbox => _page.GetByTestId("fields.risk.rows[0].riskInput$eQResidenceCoverage.value");
        public ILocator ContentsCoverageCheckbox => _page.GetByTestId("fields.risk.rows[0].riskInput$eQResidenceContentsCoverage.value");
        public ILocator OptionalCoverageCheckbox => _page.GetByTestId("fields.risk.rows[0].riskInput$eQOptionalCoveragesCatalog.value");
        #endregion

        #region Actions
        public ILocator SaveButton => _page.GetByTestId("fields.data.save");

        /// <summary>
        /// Get the Number of Families button by value (Single, Duplex, Triplex, Fourplex)
        /// </summary>
        public ILocator GetNumberOfFamiliesButton(string value) => value?.ToLower() switch
        {
            var s when s.Contains("single") => SingleFamilyButton,
            var s when s.Contains("duplex") => DuplexButton,
            var s when s.Contains("triplex") => TriplexButton,
            var s when s.Contains("fourplex") => FourplexButton,
            _ => SingleFamilyButton
        };

        /// <summary>
        /// Get the Condition Rating button by rating (1, 2, 3)
        /// </summary>
        public ILocator GetConditionRatingButton(string rating) => rating?.Trim() switch
        {
            "2" => ConditionRating2Button,
            "3" => ConditionRating3Button,
            _ => ConditionRating1Button
        };

        /// <summary>
        /// Get the Vacant/Seasonal button by value
        /// </summary>
        public ILocator GetVacantSeasonalButton(string value) => value?.ToLower() switch
        {
            "seasonal" => SeasonalButton,
            "vacant" => VacantButton,
            _ => NotVacantSeasonalButton
        };

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
            await OwnerButton.ClickAsync();
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
                var btn = contextData.ResidenceSolidFuelQuestion.ToLower() is "yes" or "true"
                    ? SolidFuelYesButton
                    : SolidFuelNoButton;
                await btn.ClickAsync();
            }
        }
        #endregion
    }
}
