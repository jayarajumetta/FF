using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQ1stCycleLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator VIN(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$vIN.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator PleaseSelectTheVehicle(IPage page) =>
        page.GetByText("Please select the vehicle", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Cycle1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "2013 Harley Davidson FLHTCU UL CLSC FLHTCU UL CLSC EL GLIDE 220596", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PleasureUse(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Pleasure Use", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator NotPleasureUse(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Not Pleasure Use", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UnderConstruction(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Under Construction", Exact = true });

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
    public static ILocator NoRegisteredFedTribe(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications(IPage page) =>
        page.GetByText("Does this vehicle have any Non-Factory Additions, Alterations, or Modifications?", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Yes(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator No(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator DescriptionOfMods(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CurrentValue(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$currentValue.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AnnualMileage(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator SaveAndContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

}
