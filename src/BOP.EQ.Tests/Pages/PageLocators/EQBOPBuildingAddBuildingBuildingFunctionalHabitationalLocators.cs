using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators
{
        public static ILocator SelectIfClientOwnsOrRentsTheBuilding(IPage page) =>
        page.GetByText("Select if client owns or rents the building", new() { Exact = true });

        public static ILocator FunctionalPersonalPropertyUnchecked(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankInclude Functional Personal Property", Exact = true });

        public static ILocator BuildingContainsHabitationalOccupanciesUnchecked(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankBuilding contains habitational occupancies", Exact = true });

        public static ILocator FunctionalPersonalPropertyChecked(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_boxInclude Functional Personal Property", Exact = true });

        public static ILocator BuildingContainsHabitationalOccupanciesChecked(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_boxBuilding contains habitational occupancies", Exact = true });

        public static ILocator WindstormLossMitigationUnchecked(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankWindstorm Loss Mitigation", Exact = true });

        public static ILocator CertificateTypeBronzeRoof(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Bronze/Roof", Exact = true });

        public static ILocator CertificateTypeGoldFSL(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Gold/FSL", Exact = true });

        public static ILocator RoofShape(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$roofShape.value\"");

        public static ILocator RoofDeckAttachment(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$roofDeckAttachment.value\"");

        public static ILocator RoofToWallConnection(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$roofWallConnection.value\"");

        public static ILocator DoorStrength(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$doorStrength.value\"");

        public static ILocator RoofCovering(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$roofCovering.value\"");

        public static ILocator OpeningProtection(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$openingProtection.value\"");

        public static ILocator SecondaryWaterResistance(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$secondaryWaterResistance.value\"");

}
