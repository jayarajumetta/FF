using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPLocationsBuildingsAddABuildingTo3rdLocation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPLocationsBuildingsAddABuildingTo3rdLocation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Location3 => EQBOPLocationsBuildingsAddABuildingTo3rdLocationLocators.Location3(_page);

    public Task PressLocation3Async(string key) => Location3.PressAsync(key);

    public Task DoubleClickLocation3Async() => Location3.DblClickAsync();

    public Task SetLocation3Async(string value) =>
        Location3.SelectOptionAsync(_data.Resolve(value));

}
