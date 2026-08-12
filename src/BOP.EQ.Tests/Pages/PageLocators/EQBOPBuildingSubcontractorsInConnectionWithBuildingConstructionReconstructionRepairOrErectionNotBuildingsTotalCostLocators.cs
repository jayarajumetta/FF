using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostLocators
{
        public static ILocator SubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost(IPage page) =>
        page.Locator("id=\"fields.data.account.occupancy.rows[2].occupancyOutput$bOP_TotalCost.value\"");

}
