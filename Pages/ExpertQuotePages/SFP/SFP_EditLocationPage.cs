// Pages/ExpertQuotePages/SFP/SFP_EditLocationPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// SFP Edit Location modal - for editing location details including
    /// location type, fire department distance, hydrant distance, and farm-specific fields.
    /// </summary>
    public class SFP_EditLocationPage : BasePage
    {
        public SFP_EditLocationPage(IPage page) : base(page) { }

        #region Locators - Navigation
        /// <summary> Side nav: Locations, Residences & Buildings </summary>
        public ILocator LocationsBuildingsNav => _page.GetByTestId("LocationsBuildings-nav");
        #endregion

        #region Locators - Location Details
        /// <summary> Input: Additional Description for the location </summary>
        public ILocator AdditionalDescriptionInput => _page.GetByTestId("fields.data.account.location.rows[0].locationInput$additionalDescription.value");

        /// <summary> Button: Location Type - Property </summary>
        public ILocator LocationTypePropertyButton => _page.GetByTestId("fields.data.account.location.rows[0].locationOutput$locationType.value-0");

        /// <summary> Button: Location Type - Liability </summary>
        public ILocator LocationTypeLiabilityButton => _page.GetByTestId("fields.data.account.location.rows[0].locationOutput$locationType.value-1");

        /// <summary> Button: Location Type - Both (Property and Liability) </summary>
        public ILocator LocationTypeBothButton => _page.GetByTestId("fields.data.account.location.rows[0].locationOutput$locationType.value-2");

        /// <summary> Input: Miles from Fire Department </summary>
        public ILocator MilesFromFireDepartmentInput => _page.GetByTestId("fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value");

        /// <summary> Select: Feet from Hydrant dropdown </summary>
        public ILocator FeetFromHydrantSelect => _page.GetByTestId("fields.data.account.location.rows[0].locationInput$feetFromHydrant.value");
        #endregion

        #region Locators - Farm-Specific Fields
        /// <summary> Checkbox: Tower question (Excess Power, Light Poles, Windmills, Frost Protection Towers) </summary>
        public ILocator TowerQuestionCheckbox => _page.GetByTestId("fields.data.account.location2.rows[0].locationInput$towerQuestion.value");

        /// <summary> Label for tower question (for GetByLabel interactions) </summary>
        public ILocator TowerQuestionLabel => _page.GetByLabel("Do you want to add optional coverage for Excess Power, Light Poles, Windmills and Frost Protection Towers?");

        /// <summary> Checkbox: No farming at this location </summary>
        public ILocator NoFarmingCheckbox => _page.GetByTestId("fields.data.account.location2.rows[0].locationInput$farmingIndicator.value");

        /// <summary> Checkbox role locator for No Farming (alternative) </summary>
        public ILocator NoFarmingCheckboxRole => _page.GetByRole(AriaRole.Checkbox, new() { Name = "There is no farming at this Location" });

        /// <summary> Input: Acreage </summary>
        public ILocator AcreageInput => _page.GetByTestId("fields.data.account.location2.rows[0].locationInput$acreage.value");
        #endregion

        #region Locators - Modal Actions
        /// <summary> Button: Cancel changes </summary>
        public ILocator CancelButton => _page.GetByTestId("fields.data_Next.cancelChanges");

        /// <summary> Button: Save location </summary>
        public ILocator SaveButton => _page.GetByTestId("fields.data_Next.saveLocation");
        #endregion

        #region Actions - Location Type Selection
        /// <summary>
        /// Select location type (Property, Liability, or Both)
        /// </summary>
        public async Task SelectLocationTypeAsync(string locationType)
        {
            var button = locationType.ToLower() switch
            {
                "property" => LocationTypePropertyButton,
                "liability" => LocationTypeLiabilityButton,
                "both" => LocationTypeBothButton,
                _ => throw new System.ArgumentException($"Unknown location type: {locationType}")
            };
            await button.ClickAsync();
        }
        #endregion

        #region Actions - Fire Protection
        /// <summary>
        /// Enter miles from fire department
        /// </summary>
        public async Task EnterMilesFromFireDepartmentAsync(string miles)
        {
            await MilesFromFireDepartmentInput.FillAsync(miles);
        }

        /// <summary>
        /// Select feet from hydrant option
        /// </summary>
        public async Task SelectFeetFromHydrantAsync(string option)
        {
            await FeetFromHydrantSelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = option }).ClickAsync();
        }
        #endregion

        #region Actions - Farm Fields
        /// <summary>
        /// Check/uncheck the "No farming at this location" checkbox
        /// </summary>
        public async Task SetNoFarmingAsync(bool noFarming)
        {
            await NoFarmingCheckbox.SetCheckedAsync(noFarming);
        }

        /// <summary>
        /// Enter acreage value
        /// </summary>
        public async Task EnterAcreageAsync(string acreage)
        {
            await AcreageInput.FillAsync(acreage);
        }

        /// <summary>
        /// Check/uncheck the tower question checkbox
        /// </summary>
        public async Task SetTowerQuestionAsync(bool addCoverage)
        {
            await TowerQuestionCheckbox.SetCheckedAsync(addCoverage);
        }
        #endregion

        #region Actions - Modal Navigation
        /// <summary>
        /// Save the location and close modal
        /// </summary>
        public async Task SaveLocationAsync()
        {
            await SaveButton.ClickAsync();
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }

        /// <summary>
        /// Cancel changes and close modal
        /// </summary>
        public async Task CancelLocationAsync()
        {
            await CancelButton.ClickAsync();
        }
        #endregion
    }
}
