using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPreQualificationIndustryClassCodeRestrictionsLocators
{
        public static ILocator IndustryClassCodeRestrictions(IPage page) =>
        page.Locator("id=UnderwritingQuestions.Constant_IndustryClassCodeRestrictions-0-layout");

        public static ILocator CheckBoxOutlineBlankNoneOfTheAbove(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankNone Of The Above", Exact = true });

        public static ILocator ResponseRequiredToContinue(IPage page) =>
        page.GetByText("Response required to continue", new() { Exact = true });

        public static ILocator NextPrimaryInsuredDetails(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next: Primary Insured Details", Exact = true });

}
