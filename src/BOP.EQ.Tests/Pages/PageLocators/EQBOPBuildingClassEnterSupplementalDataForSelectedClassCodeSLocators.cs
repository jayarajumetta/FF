using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators
{
        public static ILocator ClassCodes(IPage page) =>
        page.Locator("id=NAICSSearchPrivate.ClassCodesHeader-0-layout");

        public static ILocator OccupancySQFTHeading(IPage page) =>
        page.Locator("id=undefined");

        public static ILocator OccupancySqFtLimit(IPage page) =>
        page.Locator("id=\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\"");

        public static ILocator OccupancySqFootageTotal(IPage page) =>
        page.Locator("id=\"fields.data.account.building.rows[0].buildingPrivate$occupancySqFtTotal.value\"");

        public static ILocator PersonalPropertyLimitCheckBoxAngular(IPage page) =>
        page.GetByTestId("\"fields.data.account.occupancy.rows[0].occupancyInput$includeBPP.value\"");

        public static ILocator PersonalPropertyLimit(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].covPersonalProperty.rows[0].covPersonalPropertyInput$limit.value\"");

        public static ILocator GrossSalesReceipts(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].covRiskLiability.rows[0].covRiskLiabilityInput$grossSalesReceipts.value\"");

}
