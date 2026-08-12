using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQChecklistCloseLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnOk(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Ok", Exact = true });

}
