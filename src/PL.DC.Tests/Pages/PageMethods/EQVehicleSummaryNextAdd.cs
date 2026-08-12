using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQVehicleSummaryNextAdd
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQVehicleSummaryNextAdd(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnNext => EQVehicleSummaryNextAddLocators.BtnNext(_page);

    public Task PressBtnNextAsync(string key) => BtnNext.PressAsync(key);

    public Task DoubleClickBtnNextAsync() => BtnNext.DblClickAsync();

    public Task ClickBtnNextAsync() => BtnNext.ClickAsync();

    public Task WaitForBtnNextAsync() =>
        BtnNext.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
