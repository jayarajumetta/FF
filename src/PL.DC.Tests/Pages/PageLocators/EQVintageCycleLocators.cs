using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVintageCycleLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleVIN(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator PleaseSelectTheVehicle(IPage page) =>
        page.GetByText("Please select the vehicle", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator VehicleType(IPage page) =>
        page.GetByText("Vehicle Type", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Vintage(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Vintage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator IsThisVehicleOwnedOrFinanced(IPage page) =>
        page.GetByText("Is this vehicle owned or financed?", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Loan(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Loan", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Leased(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Leased", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Own(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Own", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications(IPage page) =>
        page.GetByText("Does this vehicle have any Non-Factory Additions, Alterations, or Modifications?", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator No(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AgreedValue(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AppraisalDate(IPage page) =>
        page.Locator("id=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator SaveAndContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

}
