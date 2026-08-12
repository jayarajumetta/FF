using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPrimaryInsuredDetailsSnowplowQuestionsLocators
{
        public static ILocator SnowplowQuestions(IPage page) =>
        page.Locator("id=UnderwritingQuestions.Constant_SnowplowQuestions-0-layout");

        public static ILocator NoneOfTheAbove(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_boxNone of the Above", Exact = true });

        public static ILocator NextClaimsPriorInsurance(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next: Claims/Prior Insurance", Exact = true });

}
