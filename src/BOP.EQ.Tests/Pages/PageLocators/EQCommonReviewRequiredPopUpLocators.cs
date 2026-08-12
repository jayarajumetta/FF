using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonReviewRequiredPopUpLocators
{
        public static ILocator KeepGoing(IPage page) =>
        page.GetByTestId("btnConfirmYes").Filter(new() { HasText = "Keep Going" });

}
