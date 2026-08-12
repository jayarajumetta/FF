using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingBuildingDetailsRoofYearBurglarAlarmLocators
{
        public static ILocator RoofYear(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$roofYear.value\"");

        public static ILocator SprinklerYes(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingInput$sprinkler.value-chip-wrapper\"");

        public static ILocator AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        public static ILocator WiringTypeOther(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Other", Exact = true });

        public static ILocator ElectricalPanelTypeOther(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Other", Exact = true });

        public static ILocator AmperageOfTheMainCircuitBreaker100AmpsOrGreater(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "100 Amps or greater", Exact = true });

        public static ILocator IsAnyHeatSourceThermostaticallyControlledYes(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingInput$thermostaticallyControlled.value-chip-wrapper\"");

}
