using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonReviewRequiredPopUp
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonReviewRequiredPopUp(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator KeepGoing => EQCommonReviewRequiredPopUpLocators.KeepGoing(_page);

    public Task PressKeepGoingAsync(string key) => KeepGoing.PressAsync(key);

    public Task DoubleClickKeepGoingAsync() => KeepGoing.DblClickAsync();

    public Task ClickKeepGoingAsync() => KeepGoing.ClickAsync();

}
