using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPreQualificationAddClassCodes
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPreQualificationAddClassCodes(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AddClassCodesHeader => EQCommonPreQualificationAddClassCodesLocators.AddClassCodesHeader(_page);

    public Task PressAddClassCodesHeaderAsync(string key) => AddClassCodesHeader.PressAsync(key);

    public Task DoubleClickAddClassCodesHeaderAsync() => AddClassCodesHeader.DblClickAsync();

    public Task WaitForAddClassCodesHeaderAsync() =>
        AddClassCodesHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SearchAddClassCode => EQCommonPreQualificationAddClassCodesLocators.SearchAddClassCode(_page);

    public Task PressSearchAddClassCodeAsync(string key) => SearchAddClassCode.PressAsync(key);

    public Task DoubleClickSearchAddClassCodeAsync() => SearchAddClassCode.DblClickAsync();

    public Task ClickSearchAddClassCodeAsync() => SearchAddClassCode.ClickAsync();

}
