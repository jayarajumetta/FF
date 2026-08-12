using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonLoadingIndicatorWait2
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonLoadingIndicatorWait2(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Loading => EQCommonLoadingIndicatorWait2Locators.Loading(_page);

    public Task PressLoadingAsync(string key) => Loading.PressAsync(key);

    public Task DoubleClickLoadingAsync() => Loading.DblClickAsync();

    public Task VerifyLoadingAsync(string expected) =>
        Expect(Loading).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForLoadingAsync() =>
        Loading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
