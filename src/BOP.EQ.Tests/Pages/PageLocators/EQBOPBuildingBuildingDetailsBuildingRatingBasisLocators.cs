using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingBuildingDetailsBuildingRatingBasisLocators
{
        public static ILocator BuildingDetailsHeading(IPage page) =>
        page.Locator("id=BuildingPrivate.BuildingDetailsHeader-0-layout");

        public static ILocator ActualCashValue(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper\"");

        public static ILocator ReplacementCost(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper\"");

        public static ILocator YearBuiltRenovated(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$yearRenovated.value\"");

        public static ILocator WiringYear(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].propertyInformation$wiringYear.value\"");

        public static ILocator HeatingYear(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].propertyInformation$heatingYear.value\"");

        public static ILocator PlumbingYear(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].propertyInformation$plumbingYear.value\"");

        public static ILocator MainBreaker(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Main Breaker", Exact = true });

}
