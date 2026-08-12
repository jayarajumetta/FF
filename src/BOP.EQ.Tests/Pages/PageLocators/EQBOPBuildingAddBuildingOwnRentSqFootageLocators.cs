using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingAddBuildingOwnRentSqFootageLocators
{
        public static ILocator SelectIfClientOwnsOrRentsTheBuilding(IPage page) =>
        page.GetByText("Select if client owns or rents the building", new() { Exact = true });

        public static ILocator OwnButton(IPage page) =>
        page.GetByTestId("\"fields.data.account.building.rows[0].buildingInput$buildingOccupiedEQ.value-chip-wrapper\"");

        public static ILocator TotalBuildingSqFootage(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\"");

        public static ILocator InsuredOccupancySqFt(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\"");

        public static ILocator OwnButtonOld(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Own", Exact = true });

        public static ILocator RentButton(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Rent", Exact = true });

}
