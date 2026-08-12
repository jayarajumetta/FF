using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVehicleAutoVin1Locators
{
    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtVIN(IPage page) =>
        page.Locator("id=\"fields.line.risk.rows[0].vehicleInput$vIN.value\"");

}
