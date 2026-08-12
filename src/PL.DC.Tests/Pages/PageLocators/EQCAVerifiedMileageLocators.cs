using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCAVerifiedMileageLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator OptOut(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Opt Out", Exact = true });

}
