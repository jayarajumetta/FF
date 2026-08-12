using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVehicleSummaryAutoAdditionalLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator VIN(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator VehicleMoreOptions(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-menu-trigger\"").Filter(new() { HasText = "MORE OPTIONS" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator CollectorCar(IPage page) =>
        page.GetByText("Collector Car", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator CollectorCarTypeMoreOptions(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger\"").Filter(new() { HasText = "MORE OPTIONS" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Classic(IPage page) =>
        page.GetByText("Classic", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AgreedValue(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Own(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator Continue(IPage page) =>
        page.Locator("#btnConfirmYes");

        // REVIEW: source field not uniquely resolved.
    public static ILocator CONTINUE(IPage page) =>
        page.GetByText("CONTINUE", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RestrictedUse(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AppraisalDate(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TotalAnnualMileage(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator SaveContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ModernClassic(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator Odometer(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator PurchaseDate(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$purchaseDate.value\"");

}
