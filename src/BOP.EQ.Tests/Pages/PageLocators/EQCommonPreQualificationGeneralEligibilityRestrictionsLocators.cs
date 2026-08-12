using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPreQualificationGeneralEligibilityRestrictionsLocators
{
        public static ILocator UncheckedNoneOfTheAbove(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "check_box_outline_blankNone Of The Above", Exact = true });

        public static ILocator ResponseRequiredToContinue(IPage page) =>
        page.GetByText("Response required to continue", new() { Exact = true });

        public static ILocator UncheckedConvictedOfAnyOtherTypeOfCrime(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankConvicted of any other type of crime", Exact = true });

        public static ILocator Rule92005FelonyRule(IPage page) =>
        page.GetByText("2005: Risk ineligible due to any 'other' type of Felony.", new() { Exact = true });

        public static ILocator GeneralEligibilityQuestions(IPage page) =>
        page.Locator("id=ExpertQuoteCaptions.GeneralEligibilityQuestions-0-layout");

        public static ILocator CheckedConvictedOfAnyOtherTypeOfCrime(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_boxConvicted of any other type of crime", Exact = true });

}
