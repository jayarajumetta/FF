using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestionsLocators
{
        public static ILocator IndustryClassCodeQuestionsHeading(IPage page) =>
        page.Locator("id=IndustryClassCodeQuestions-0-layout");

        public static ILocator NoneOfTheAboveCheckbox(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

}
