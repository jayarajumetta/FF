using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EUApplicantLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BypassLevel9BRules(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "Bypass Level 9B Rules", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator BypassLevel9BRulesComments(IPage page) =>
        page.GetByLabel("Bypass Level 9B Rules Comments", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Home(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Home", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkPricing(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Pricing", Exact = true });

}
