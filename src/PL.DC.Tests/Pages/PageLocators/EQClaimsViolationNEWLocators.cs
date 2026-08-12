using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQClaimsViolationNEWLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator ClaimDriverNotInHousehold(IPage page) =>
        page.GetByTestId("\"fields.losses.loss.rows[0].lossInput$driverID.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator ClaimViolationDoesNotApply(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Does Not Apply", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ClaimViolationSaveAndContinue(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator ComboBox(IPage page) =>
        page.Locator("id=\"fields.violations.violation.rows[0].violationInput$internalCode.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator CONTINUEDoesnTApply(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
