using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQDiscountNEWLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator MultiCarDiscount(IPage page) =>
        page.GetByText("Multi-Car Discount", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator RiderGroupDiscount(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator CommercialAuto(IPage page) =>
        page.GetByText("Commercial Auto", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator SpecialFarmPackage(IPage page) =>
        page.GetByText("Special Farm Package", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator SafeCycleDiscount(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator SafeCycleDiscountDate(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.driverSafeCycle.rows[0].safeCycleDiscountRiskFactor$value.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NoDefensiveDriverDiscount(IPage page) =>
        page.GetByText("None", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
