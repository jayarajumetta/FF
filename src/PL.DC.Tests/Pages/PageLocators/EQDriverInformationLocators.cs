using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQDriverInformationLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator IneligibleQuote(IPage page) =>
        page.Locator("id=undefined");

        // REVIEW: source field not uniquely resolved.
    public static ILocator CLOSEQUOTE(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "CLOSE QUOTE", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ExistingClient1(IPage page) =>
        page.GetByTestId("_cifClientDriversChips-_cifClientDriversChips-driver0-chip-chip");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNext(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
