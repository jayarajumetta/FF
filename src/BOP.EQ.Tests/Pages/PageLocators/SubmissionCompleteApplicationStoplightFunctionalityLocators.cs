using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class SubmissionCompleteApplicationStoplightFunctionalityLocators
{
        public static ILocator CompleteApplication(IPage page) =>
        page.Locator("[data-duckcreek-id=\"Complete Application\"]");

        public static ILocator StoplightWaitingWindow(IPage page) =>
        page.Locator("id=stoplightWaitingWindow");

        public static ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs(IPage page) =>
        page.Locator("[data-duckcreek-id=\"All required fields have not been completed. *complete *highlighted*.\"]");

}
