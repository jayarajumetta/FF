using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVehicleSummaryAutoMotorHomeUseLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnLoan(IPage page) =>
        page.GetByTestId("\"fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnLeased(IPage page) =>
        page.GetByTestId("\"fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnOwn(IPage page) =>
        page.GetByTestId("\"fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NativeAmericanRegisterNO(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ILCategory1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Category 1 Without Lock", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator CategoryI(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Category I", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ActiveDisablingDevice(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Active Disabling Device", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PleasureCANYFFCIC(IPage page) =>
        page.GetByTestId("\"fields.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item1Day(IPage page) =>
        page.GetByText("1", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator NYFFCICTotalAnnualMiles(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$howManyTotalAnnualMiles.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator WorkMilesDay(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$howManyMilesPerDayOneWay.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator NonWorkAnnualMiles(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$howManyAnnualMilesDrivenOutside.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator MoreOptionsFarmUse(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Farm Use", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtPurchaseDate(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$purchaseDate.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtOdometer(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$odometer.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSaveContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtAnnualMileage(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"");

}
