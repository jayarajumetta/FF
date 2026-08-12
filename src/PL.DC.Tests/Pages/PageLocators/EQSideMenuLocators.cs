using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQSideMenuLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator DriverInformation(IPage page) =>
        page.GetByText("Driver Information", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator VehicleSummary(IPage page) =>
        page.GetByText("Vehicle Summary", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Coverages(IPage page) =>
        page.GetByText("Coverages", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator QuoteNumber(IPage page) =>
        page.GetByText("PERSONAL AUTO (*)", new() { Exact = true });

}
