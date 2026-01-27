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
                ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(contextData.VehicleMake, StringComparison.OrdinalIgnoreCase),
                new() { State = WaitForSelectorState.Visible, Timeout = 3000 }
            );

            await _page.ClickAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(contextData.VehicleMake, StringComparison.OrdinalIgnoreCase));
            await _page.WaitForTimeoutAsync(3000);
        }

        public async Task SelectVehicleTypeAsync(string vehicleType)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleTypeButton(_page, vehicleType));
        }

        public async Task ValidateVehicleDetailsAsync(ScenarioContextData contextData)
        {
            var yearText = await _page.Locator(Locators.VehicleSummaryConstLocators.VehicleYearReadOnly).InnerTextAsync();
            Assert.That(yearText, Is.EqualTo(contextData.VehicleYear));

            var makeText = await _page.Locator(Locators.VehicleSummaryConstLocators.MakeReadOnly).InnerTextAsync();
            Assert.That(makeText, Is.EqualTo(contextData.VehicleMake).IgnoreCase);

            var modelText = await _page.Locator(Locators.VehicleSummaryConstLocators.ModelReadOnly).InnerTextAsync();
            Assert.That(modelText, Is.EqualTo(contextData.VehicleModel).IgnoreCase);

            var trimText = await _page.Locator(Locators.VehicleSummaryConstLocators.TrimReadOnly).InnerTextAsync();
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
            await _page.FillAsync(Locators.VehicleSummaryConstLocators.TotalAnnualMileageInput, contextData.AnnualMileage);
        }

        public async Task SaveAndContinueVehicleAsync()
        {
            await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
            await _page.WaitForSelectorAsync(Locators.GlobalLocators.NextButton(_page).ToString(), new() { Timeout = 3000 });
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task AssignVehicleToDriverAsync(string vehicle, string driverStatus)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.VehicleSummaryPageLocators.GetVehicleSelectButton(vehicle, StringComparison.OrdinalIgnoreCase));
            await _page.ClickAsync(ExpertQuoteLocatorFactory.VehicleDriverAssignmentPageLocators.GetDriverStatusButton(driverStatus));
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }


    }
}
