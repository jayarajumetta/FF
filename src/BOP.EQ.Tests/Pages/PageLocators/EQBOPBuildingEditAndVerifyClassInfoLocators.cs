using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingEditAndVerifyClassInfoLocators
{
        public static ILocator AddInventory(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "+ Add Inventory", Exact = true });

        public static ILocator ClassCodeTABLE(IPage page) =>
        page.GetByText(" Class CodeIndustryDescriptionOccupancy SQ FT *", new() { Exact = true });

}
