using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EUHomeMotorcyclePersonalAutoLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkMotorcycle(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkPersonalAuto(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "PA387239Q2025", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LnkRV(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "PersonalAuto", Exact = true });

}
