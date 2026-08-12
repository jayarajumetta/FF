using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class QueueInCLASQLTYLocators
{
        public static ILocator Queue(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Queue*", Exact = true });

        public static ILocator ClearAll(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Clear All", Exact = true });

}
