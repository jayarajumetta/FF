using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQSubmissionLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator LblValueTotalPolicyPremium(IPage page) =>
        page.GetByText("*", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LblValueEffectiveDate(IPage page) =>
        page.GetByText("*", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LblValuePolicyNumber(IPage page) =>
        page.GetByText("*", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LblValueChecklistId(IPage page) =>
        page.GetByText("*", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSaveAndExit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save and Exit", Exact = true });

}
