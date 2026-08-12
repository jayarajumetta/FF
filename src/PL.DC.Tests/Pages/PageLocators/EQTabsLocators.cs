using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQTabsLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnCloseTab(IPage page) =>
        page.Locator("xpath=\"id('mat-tab-label-0-0')/div[1]/mat-icon[1]\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNewTab(IPage page) =>
        page.Locator("xpath=\"id('mat-tab-label-0-1')/div[1]/mat-icon[1]\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtQuoteSearchInput(IPage page) =>
        page.Locator("id=quoteSearchInput");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSearch(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnEdit(IPage page) =>
        page.GetByText("edit", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator LblQNum(IPage page) =>
        page.Locator("xpath=\"id('mat-tab-content-0-0')/div[1]/app-quote-viewer[1]/section[1]/nav[1]/section[2]/app-personal-auto-nav[1]/div[1]/div[1]/span[1]\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator LblQuote(IPage page) =>
        page.GetByText("*", new() { Exact = true });

}
