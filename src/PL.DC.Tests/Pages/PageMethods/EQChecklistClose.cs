using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQChecklistClose
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQChecklistClose(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BtnOk => EQChecklistCloseLocators.BtnOk(_page);

    public Task PressBtnOkAsync(string key) => BtnOk.PressAsync(key);

    public Task DoubleClickBtnOkAsync() => BtnOk.DblClickAsync();

    public Task ClickBtnOkAsync() => BtnOk.ClickAsync();

}
