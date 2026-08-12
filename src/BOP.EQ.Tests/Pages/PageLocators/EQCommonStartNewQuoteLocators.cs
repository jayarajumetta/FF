using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonStartNewQuoteLocators
{
        public static ILocator NewQuote(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "New Quote", Exact = true });

}
