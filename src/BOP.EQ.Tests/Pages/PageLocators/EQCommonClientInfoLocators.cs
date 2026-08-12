using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonClientInfoLocators
{
        public static ILocator ClientInfo(IPage page) =>
        page.GetByText("Client Info", new() { Exact = true });

        public static ILocator NewExistingClientSearch(IPage page) =>
        page.GetByText("New/Existing Client Search", new() { Exact = true });

        public static ILocator CustomerNameFirst(IPage page) =>
        page.Locator("id=customer.name.first");

        public static ILocator CustomerNameLast(IPage page) =>
        page.Locator("id=customer.name.last");

        public static ILocator CustomerDateOfBirth(IPage page) =>
        page.Locator("id=customer.dateOfBirth");

        public static ILocator Search(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

}
