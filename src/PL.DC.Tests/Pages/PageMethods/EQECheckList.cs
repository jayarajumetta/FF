using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQECheckList
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQECheckList(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LnkAutoCycleRVApplication => EQECheckListLocators.LnkAutoCycleRVApplication(_page);

    public Task PressLnkAutoCycleRVApplicationAsync(string key) => LnkAutoCycleRVApplication.PressAsync(key);

    public Task DoubleClickLnkAutoCycleRVApplicationAsync() => LnkAutoCycleRVApplication.DblClickAsync();

    public Task ClickLnkAutoCycleRVApplicationAsync() => LnkAutoCycleRVApplication.ClickAsync();

}
