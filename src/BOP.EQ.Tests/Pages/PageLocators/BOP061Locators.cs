using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class BOP061Locators
{
        public static ILocator BOPRestaurantQuestionnaireHeader(IPage page) =>
        page.Locator("id=checklist-item-name");

        public static ILocator Exception(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Exception", Exact = true });

        public static ILocator OK(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

}
