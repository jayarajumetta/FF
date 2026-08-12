using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPreQualificationAddClassCodesLocators
{
        public static ILocator AddClassCodesHeader(IPage page) =>
        page.Locator("id=undefined");

        public static ILocator SearchAddClassCode(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search/Add Class Code", Exact = true });

}
