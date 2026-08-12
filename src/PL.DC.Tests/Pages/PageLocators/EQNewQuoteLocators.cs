using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQNewQuoteLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNewQuote(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "New Quote", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtQuoteSearchInput(IPage page) =>
        page.Locator("id=quoteSearchInput");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSearch1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtQuotePolicySearch(IPage page) =>
        page.Locator("id=quoteSearchInput");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSearch(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

}
