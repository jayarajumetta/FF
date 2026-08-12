using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonFormCheckUIFormsListBOPSmartLocators
{
        // REVIEW: no stronger source locator.
    public static ILocator FORM(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "FORM #", Exact = true });

        // REVIEW: no stronger source locator.
    public static ILocator FormNumber(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "X48451217", Exact = true });

        public static ILocator Close(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Close", Exact = true });

}
