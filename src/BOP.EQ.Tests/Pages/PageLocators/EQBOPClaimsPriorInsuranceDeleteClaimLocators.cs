using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPClaimsPriorInsuranceDeleteClaimLocators
{
        public static ILocator DeleteTrashCan(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "delete", Exact = true });

        public static ILocator Confirm(IPage page) =>
        page.GetByText("Confirm", new() { Exact = true });

        public static ILocator DELETE(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "DELETE", Exact = true });

}
