using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonCreateNewClientLocators
{
        public static ILocator ExistingClientMatch(IPage page) =>
        page.GetByText("Existing Client Matches", new() { Exact = true });

        public static ILocator CreateNewClient1(IPage page) =>
        page.GetByTestId("customer.selected-new-chip");

        public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
