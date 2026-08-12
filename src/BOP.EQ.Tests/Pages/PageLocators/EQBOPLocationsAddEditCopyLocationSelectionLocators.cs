using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPLocationsAddEditCopyLocationSelectionLocators
{
        public static ILocator AddLocationButton(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "+ Add Location", Exact = true });

}
