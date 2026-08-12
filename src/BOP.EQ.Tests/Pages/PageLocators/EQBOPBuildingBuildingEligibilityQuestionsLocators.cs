using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingBuildingEligibilityQuestionsLocators
{
        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

}
