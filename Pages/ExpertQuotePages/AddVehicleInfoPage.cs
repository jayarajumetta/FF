// Pages/AddVehicleInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages
{
    public class AddVehicleInfoPage
    {
        private readonly IPage _page;

        public AddVehicleInfoPage(IPage page)
        {
            _page = page;
        }


        public async Task WaitForVehiclePageReadyAsync()
        {
            // Wait for vehicle page to be ready
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }

        public async Task SelectUnlistedVehicleIfVisibleAsync()
        {
            if (await _page.IsVisibleAsync(Locators.VehicleSummaryConstLocators.SelectVehicles))
            {
                await _page.ClickAsync(Locators.VehicleSummaryConstLocators.SelectVehicles);
                await Locators.GlobalLocators.NextButton(_page).ClickAsync();
            }
        }

        public async Task EnterVINAndSelectVehicleAsync(ScenarioContextData contextData)
        {
            await Locators.VehicleSummaryConstLocators.VINNumber(_page).FillAsync(contextData.VINNumber);
            await _page.ClickAsync(Locators.VehicleSummaryConstLocators.Vehicle1Header);
            
            // Wait for VIN lookup results
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);

            var vehicleButton = ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(_page, contextData.VehicleMake, StringComparison.OrdinalIgnoreCase);
            await Assertions.Expect(vehicleButton).ToBeVisibleAsync(new() { Timeout = 10000 });
            await vehicleButton.ClickAsync();
            
            // Wait for vehicle selection to be processed
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }

        public async Task SelectVehicleTypeAsync(string vehicleType)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleTypeButton(_page, vehicleType));
        }

        public async Task ValidateVehicleDetailsAsync(ScenarioContextData contextData)
        {
            await Expect(Locators.VehicleSummaryConstLocators.VehicleYearReadOnly(_page))
                .ToHaveTextAsync(contextData.VehicleYear);

            await Expect(Locators.VehicleSummaryConstLocators.MakeReadOnly(_page))
                .ToHaveTextAsync(new System.Text.RegularExpressions.Regex(contextData.VehicleMake, System.Text.RegularExpressions.RegexOptions.IgnoreCase));

            await Expect(Locators.VehicleSummaryConstLocators.ModelReadOnly(_page))
                .ToHaveTextAsync(new System.Text.RegularExpressions.Regex(contextData.VehicleModel, System.Text.RegularExpressions.RegexOptions.IgnoreCase));

            await Expect(Locators.VehicleSummaryConstLocators.TrimReadOnly(_page))
                .ToHaveTextAsync(new System.Text.RegularExpressions.Regex(contextData.VehicleTrim, System.Text.RegularExpressions.RegexOptions.IgnoreCase));
        }

        public async Task SelectVehicleOptionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleOwnershipButton(_page, contextData.VehicleOwnership));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetCustomizedEquipmentButton(_page, contextData.CustomizedEquipment));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleUsageButton(_page, contextData.VehicleUsage));
        }

        public async Task FillPurchaseAndMileageFieldsAsync(ScenarioContextData contextData)
        {
            // Wait for purchase date field to be ready
            await Assertions.Expect(Locators.VehicleSummaryConstLocators.PurchaseDateInput(_page)).ToBeVisibleAsync();

            await Locators.VehicleSummaryConstLocators.PurchaseDateInput(_page).FillAsync(contextData.PurchaseDate);
            // Tab out to trigger validation
            await Locators.VehicleSummaryConstLocators.PurchaseDateInput(_page).PressAsync("Tab");

            await Locators.VehicleSummaryConstLocators.OdometerReadingInput(_page).FillAsync(contextData.OdometerReading);
            await Locators.VehicleSummaryConstLocators.TotalAnnualMileageInput(_page).FillAsync(contextData.AnnualMileage);
        }

        public async Task SaveAndContinueVehicleAsync()
        {
            await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
            await Locators.GlobalLocators.NextButton(_page).WaitForAsync(new() { Timeout = 3000 });
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task AssignVehicleToDriverAsync(string vehicle, string driverStatus)
        {
            await ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(_page, vehicle, StringComparison.OrdinalIgnoreCase).ClickAsync();
            await ExpertQuoteLocatorFactory.VehicleDriverAssignmentPageLocators.DriverStatusButton(_page, driverStatus).ClickAsync();
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }


    }
}
