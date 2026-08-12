using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonQuoteIdentifyingLocators
{
        // REVIEW: no stronger source locator.
    public static ILocator NameAndQuote(IPage page) =>
        page.GetByText("{{buffer:LastName}}*", new() { Exact = true });

        public static ILocator CloseQuote(IPage page) =>
        page.GetByText("clear", new() { Exact = true });

}
