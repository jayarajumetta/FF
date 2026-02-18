// Pages/AddVehicleInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using NUnit.Framework;

namespace Playwright_POC.Pages
{
    public class AddVehicleInfoPage : BasePage
    {
        public AddVehicleInfoPage(IPage page) : base(page) { }

        #region Locators
        private ILocator SelectVehiclesButton => _page.Locator("button[id*='unlistedVehicle']");
        private ILocator Vehicle1Header => _page.Locator("div:has-text('Vehicle 1')");
        private ILocator VINNumberInput => _page.GetByLabel("VIN");
        private ILocator VehicleYearInput => _page.GetByLabel("Model Year");
        private ILocator MakeInput => _page.GetByLabel("Make");
        private ILocator ModelInput => _page.GetByLabel("Model");
        private ILocator TrimInput => _page.GetByLabel("Trim");
        private ILocator PurchaseDateInput => _page.GetByLabel("Purchase Date");
        private ILocator OdometerReadingInput => _page.GetByLabel("Odometer Reading");
        private ILocator TotalAnnualMileageInput => _page.Locator("[data-testid*='annualMileage']");
        private ILocator SaveAndContinueButton => _page.GetByTestId("fields.line.save_and_Continue");

        // Read-only fields
        private ILocator VehicleYearReadOnly => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Year')) >> span.readonly-value");
        private ILocator MakeReadOnly => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Make')) >> span.readonly-value");
        private ILocator ModelReadOnly => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Model')) >> span.readonly-value");
        private ILocator TrimReadOnly => _page.Locator("div.readonly-field:has(span.readonly-label:has-text('Trim')) >> span.readonly-value");

        // Dynamic locators
        private ILocator GetVehicleSelectButton(string value) =>
            _page.Locator("[id*='vehicle']").GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetVehicleTypeButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetVehicleOwnershipButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetCustomizedEquipmentButton(string yesOrNo) =>
            _page.GetByRole(AriaRole.Button, new() { Name = yesOrNo });

        private ILocator GetVehicleUsageButton(string usageType) =>
            _page.GetByRole(AriaRole.Button, new() { Name = usageType });

        private ILocator GetDriverStatusButton(string value) =>
            _page.Locator("[id*='assignmentType']").GetByRole(AriaRole.Button, new() { Name = value });
        #endregion

        public async Task WaitForVehiclePageReadyAsync()
        {
            await _page.WaitForTimeoutAsync(3000);
        }

        public async Task SelectUnlistedVehicleIfVisibleAsync()
        {
            if (await SelectVehiclesButton.IsVisibleAsync())
            {
                await SelectVehiclesButton.ClickAsync();
                await ClickNextAsync();
            }
        }

        public async Task EnterVINAndSelectVehicleAsync(ScenarioContextData contextData)
        {
            await VINNumberInput.FillAsync(contextData.VINNumber);
            await Vehicle1Header.ClickAsync();
            await _page.WaitForTimeoutAsync(2000);

            var vehicleButton = GetVehicleSelectButton(contextData.VehicleMake);
            await vehicleButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 3000 });
            await vehicleButton.ClickAsync();
            await _page.WaitForTimeoutAsync(3000);
        }

        public async Task SelectVehicleTypeAsync(string vehicleType)
        {
            await ClickIfNotSelectedAsync(GetVehicleTypeButton(vehicleType));
        }

        public async Task ValidateVehicleDetailsAsync(ScenarioContextData contextData)
        {
            var yearText = await VehicleYearReadOnly.InnerTextAsync();
            Assert.That(yearText, Is.EqualTo(contextData.VehicleYear));

            var makeText = await MakeReadOnly.InnerTextAsync();
            Assert.That(makeText, Is.EqualTo(contextData.VehicleMake).IgnoreCase);

            var modelText = await ModelReadOnly.InnerTextAsync();
            Assert.That(modelText, Is.EqualTo(contextData.VehicleModel).IgnoreCase);

            var trimText = await TrimReadOnly.InnerTextAsync();
            Assert.That(trimText, Is.EqualTo(contextData.VehicleTrim).IgnoreCase);
        }

        public async Task SelectVehicleOptionsAsync(ScenarioContextData contextData)
        {
            await ClickIfNotSelectedAsync(GetVehicleOwnershipButton(contextData.VehicleOwnership));
            await ClickIfNotSelectedAsync(GetCustomizedEquipmentButton(contextData.CustomizedEquipment));
            await ClickIfNotSelectedAsync(GetVehicleUsageButton(contextData.VehicleUsage));
        }

        public async Task FillPurchaseAndMileageFieldsAsync(ScenarioContextData contextData)
        {
            await PurchaseDateInput.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 2000 });
            await _page.WaitForTimeoutAsync(2000);

            await PurchaseDateInput.FillAsync(contextData.PurchaseDate);
            await _page.WaitForTimeoutAsync(2000);

            await OdometerReadingInput.FillAsync(contextData.OdometerReading);
            await TotalAnnualMileageInput.FillAsync(contextData.AnnualMileage);
        }

        public async Task SaveAndContinueVehicleAsync()
        {
            await SaveAndContinueButton.ClickAsync();
            await ClickNextAsync();
        }

        public async Task AssignVehicleToDriverAsync(string vehicle, string driverStatus)
        {
            await GetVehicleSelectButton(vehicle).ClickAsync();
            await GetDriverStatusButton(driverStatus).ClickAsync();
            await ClickNextAsync();
        }
    }
}
