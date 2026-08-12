using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPLocationsAddEditCopyLocationSelection
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPLocationsAddEditCopyLocationSelection(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AddLocationButton => EQBOPLocationsAddEditCopyLocationSelectionLocators.AddLocationButton(_page);

    public Task PressAddLocationButtonAsync(string key) => AddLocationButton.PressAsync(key);

    public Task DoubleClickAddLocationButtonAsync() => AddLocationButton.DblClickAsync();

    public Task ClickAddLocationButtonAsync() => AddLocationButton.ClickAsync();

}
