// Pages/AddVehicleInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using NUnit.Framework;

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
            await _page.WaitForTimeoutAsync(3000);
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
            await _page.WaitForTimeoutAsync(2000);

            await _page.WaitForSelectorAsync(
                ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(_page, contextData.VehicleMake, StringComparison.OrdinalIgnoreCase).ToString(),
                new() { State = WaitForSelectorState.Visible, Timeout = 3000 }
            );

            await ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(_page, contextData.VehicleMake, StringComparison.OrdinalIgnoreCase).ClickAsync();
            await _page.WaitForTimeoutAsync(3000);
        }

        public async Task SelectVehicleTypeAsync(string vehicleType)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleTypeButton(_page, vehicleType));
        }

        public async Task ValidateVehicleDetailsAsync(ScenarioContextData contextData)
        {
            var yearText = await Locators.VehicleSummaryConstLocators.VehicleYearReadOnly(_page).InnerTextAsync();
            Assert.That(yearText, Is.EqualTo(contextData.VehicleYear));

            var makeText = await Locators.VehicleSummaryConstLocators.MakeReadOnly(_page).InnerTextAsync();
            Assert.That(makeText, Is.EqualTo(contextData.VehicleMake).IgnoreCase);

            var modelText = await Locators.VehicleSummaryConstLocators.ModelReadOnly(_page).InnerTextAsync();
            Assert.That(modelText, Is.EqualTo(contextData.VehicleModel).IgnoreCase);

            var trimText = await Locators.VehicleSummaryConstLocators.TrimReadOnly(_page).InnerTextAsync();
            Assert.That(trimText, Is.EqualTo(contextData.VehicleTrim).IgnoreCase);
        }

        public async Task SelectVehicleOptionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleOwnershipButton(_page, contextData.VehicleOwnership));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetCustomizedEquipmentButton(_page, contextData.CustomizedEquipment));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleUsageButton(_page, contextData.VehicleUsage));
        }

        public async Task FillPurchaseAndMileageFieldsAsync(ScenarioContextData contextData)
        {

            await Locators.VehicleSummaryConstLocators.PurchaseDateInput(_page)
                .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 2000 });

            await _page.WaitForTimeoutAsync(2000);

            await Locators.VehicleSummaryConstLocators.PurchaseDateInput(_page).FillAsync(contextData.PurchaseDate);
            await _page.WaitForTimeoutAsync(2000);

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
