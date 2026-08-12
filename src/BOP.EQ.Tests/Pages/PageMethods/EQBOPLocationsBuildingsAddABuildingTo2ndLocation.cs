using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPLocationsBuildingsAddABuildingTo2ndLocation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPLocationsBuildingsAddABuildingTo2ndLocation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Location2Location2Secondary => EQBOPLocationsBuildingsAddABuildingTo2ndLocationLocators.Location2Location2Secondary(_page);

    public Task PressLocation2Location2SecondaryAsync(string key) => Location2Location2Secondary.PressAsync(key);

    public Task DoubleClickLocation2Location2SecondaryAsync() => Location2Location2Secondary.DblClickAsync();

    public Task VerifyLocation2Location2SecondaryAsync(string expected) =>
        Expect(Location2Location2Secondary).ToContainTextAsync(_data.Resolve(expected));

    private ILocator AddBuildingBPP1 => EQBOPLocationsBuildingsAddABuildingTo2ndLocationLocators.AddBuildingBPP1(_page);

    public Task PressAddBuildingBPP1Async(string key) => AddBuildingBPP1.PressAsync(key);

    public Task DoubleClickAddBuildingBPP1Async() => AddBuildingBPP1.DblClickAsync();

    public Task ClickAddBuildingBPP1Async() => AddBuildingBPP1.ClickAsync();

}
