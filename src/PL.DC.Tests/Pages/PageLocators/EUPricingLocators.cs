using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EUPricingLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtUnderwritingNotes(IPage page) =>
        page.GetByLabel("\"Underwriting Notes *\"", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnApprove(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Approve", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkHome(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Home", Exact = true });

}
