using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EUHomeLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtSearchType(IPage page) =>
        page.GetByLabel("Search Type", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtSearchText(IPage page) =>
        page.GetByLabel("Search Text", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSearch(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

}
