using Microsoft.Playwright;

namespace Playwright_POC.Pages
{
    public class SFP_LocationsResidencesBuildingsPage : BasePage
    {
        public SFP_LocationsResidencesBuildingsPage(IPage page) : base(page) { }

        // Locators
        public ILocator AddLocationButton => _page.GetByTestId("fields.data.account.location.addLocationButton");
        public ILocator NextButton => _page.GetByTestId("fields.data_Rules.next");

        public ILocator MainFarmLocationSwitch(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$mainFarmLocationSelected.value");

        public ILocator EditLocationButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].editLocation");

        public ILocator DeleteLocationButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].deleteLocation");

        public ILocator AddResidenceButton(int row = 0) =>
            _page.GetByTestId("HD1Residence-nav");

        public ILocator AddResidenceButtonByRole =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Add Residence" });

        public ILocator AddBuildingButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].addBuildingButton");

        // Add Location Form
        public ILocator Address2Input(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$address2.value");

        public ILocator CityInput(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$city.value");

        public ILocator StateSelect(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$state.value");

        public ILocator ZipCodeInput(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$zipCode.value");

        public ILocator CountySelect(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$county.value");

        public ILocator ValidateAddressButton(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].validateAddress");

        public ILocator NoFarmingCheckbox => _page.GetByLabel("There is no farming at this Location");
    }
}
