using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPAddABuildingButton
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPAddABuildingButton(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AddBuildingBPP => EQBOPAddABuildingButtonLocators.AddBuildingBPP(_page);

    public Task PressAddBuildingBPPAsync(string key) => AddBuildingBPP.PressAsync(key);

    public Task DoubleClickAddBuildingBPPAsync() => AddBuildingBPP.DblClickAsync();

    public Task ClickAddBuildingBPPAsync() => AddBuildingBPP.ClickAsync();

}
