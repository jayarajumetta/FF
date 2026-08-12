using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPreQualificationAddClassCodesSearchAddClassCodesLocators
{
        public static ILocator FindAClassCode(IPage page) =>
        page.GetByText("Find a Class Code", new() { Exact = true });

        public static ILocator ClassFilter(IPage page) =>
        page.Locator("id=temp.filter");

        public static ILocator Search(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "search", Exact = true });

        public static ILocator On(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

        public static ILocator YouHaveSelected1ClassCodes(IPage page) =>
        page.GetByText("You have selected 1 Class Codes", new() { Exact = true });

        public static ILocator Add(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true });

}
