using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPBuildingSnowAndIceRemovalQuestionLocators
{
        public static ILocator No(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

}
