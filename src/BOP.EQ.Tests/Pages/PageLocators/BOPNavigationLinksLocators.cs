using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class BOPNavigationLinksLocators
{
        public static ILocator PolicyCoverage(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Policy Coverage", Exact = true });

        public static ILocator Location(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Location", Exact = true });

        public static ILocator Building(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Building", Exact = true });

        public static ILocator CompanyEndorsements(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Company Endorsements", Exact = true });

        public static ILocator Pricing(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

        public static ILocator BOPUWQuestions(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "BOP UW Questions", Exact = true });

}
