using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQClientSelectionLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtFirst(IPage page) =>
        page.Locator("id=customer.name.first");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtLast(IPage page) =>
        page.Locator("id=customer.name.last");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSearch(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnCreateNewClient(IPage page) =>
        page.GetByTestId("customer.selected-new-chip");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNext(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
