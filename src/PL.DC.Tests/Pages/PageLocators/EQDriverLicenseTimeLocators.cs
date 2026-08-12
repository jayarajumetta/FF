using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQDriverLicenseTimeLocators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator YrsLicensedCurrentState(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator MonthsLicensedCurrentState(IPage page) =>
        page.Locator("id=\"fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator No(IPage page) =>
        page.GetByTestId("\"fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-wrapper\"");

}
