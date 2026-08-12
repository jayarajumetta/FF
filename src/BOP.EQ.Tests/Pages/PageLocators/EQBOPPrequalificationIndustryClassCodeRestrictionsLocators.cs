using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPrequalificationIndustryClassCodeRestrictionsLocators
{
        public static ILocator IndustryClassCodeRestrictionsHeading(IPage page) =>
        page.Locator("id=UnderwritingQuestions.Constant_IndustryClassCodeRestrictions-0-layout");

        public static ILocator NoneOfTheAbove(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

}
