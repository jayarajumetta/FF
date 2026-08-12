using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class TransACTPolicyDetailsAttachmentsLocators
{
        public static ILocator ViewPolicyDetails(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "View Policy Details", Exact = true });

        public static ILocator PolicyDetails(IPage page) =>
        page.Locator("id=pageTitle");

        public static ILocator AttachmentsListGrid(IPage page) =>
        page.Locator("id=attachmentsListGrid");

}
