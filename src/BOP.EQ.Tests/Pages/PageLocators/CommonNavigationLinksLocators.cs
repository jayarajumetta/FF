using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class CommonNavigationLinksLocators
{
        public static ILocator Submission(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Submission", Exact = true });

        public static ILocator SaveForLater(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true });

        public static ILocator ReturnToAdmin(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Return * Admin", Exact = true });

        public static ILocator Billing(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Billing", Exact = true });

        public static ILocator NewQuote(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "New Quote", Exact = true });

        public static ILocator UnderwritingInfo(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

        public static ILocator ReturnToQuote(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

        public static ILocator PolicyInfo(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Policy Info", Exact = true });

        public static ILocator Notepad(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Notepad", Exact = true });

        public static ILocator ReturnToPolicy(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Return to Policy", Exact = true });

}
