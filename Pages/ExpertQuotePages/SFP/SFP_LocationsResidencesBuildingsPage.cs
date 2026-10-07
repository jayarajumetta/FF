using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_LocationsResidencesBuildingsPage(IPage page) : BasePage(page)
    {
        // Locators
        public ILocator AddLocationButton => _page.GetByTestId("fields.data.account.location.addLocationButton");
        public ILocator NextButton => _page.GetByTestId("fields.data_Rules.next");
        public ILocator LocationsNavigation => _page.GetByTestId("LocationsBuildings-nav");
        public ILocator EditBuildingButtons => _page.GetByTestId(new Regex(
            @"^fields\.data\.accountDetail\.locationDetail\.rows\[0\]\.building\.rows\[\d+\]\.editBuilding$"))
            .And(_page.Locator("button"));

        public async Task OpenBuildingAsync(string testId)
        {
            var button = EditBuildingButtons.And(_page.GetByTestId(testId));
            await Expect(button).ToHaveCountAsync(1);
            await button.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public Task WaitUntilReadyAsync() => new SFP_NativeFormPage(_page).RequireReadyAsync(AddBuildingButton());

        public ILocator EditResidenceButton(int locationRow = 0, int buildingRow = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{locationRow}].building.rows[{buildingRow}].editResidence")
                .And(_page.Locator("button"));

        public async Task OpenResidenceAsync(int locationRow = 0, int buildingRow = 0)
        {
            await Expect(EditResidenceButton(locationRow, buildingRow)).ToHaveCountAsync(1);
            await EditResidenceButton(locationRow, buildingRow).ClickAsync();
            await WaitForSpinnerAsync();
        }

        public ILocator MainFarmLocationSwitch(int row = 0) =>
            _page.GetByTestId($"fields.data.account.location.rows[{row}].locationInput$mainFarmLocationSelected.value");

        public ILocator EditLocationButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].editLocation");

        public ILocator DeleteLocationButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].deleteLocation");

        public ILocator AddResidenceButton(int row = 0) =>
            _page.GetByTestId($"fields.data.accountDetail.locationDetail.rows[{row}].addResidenceButton");

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
