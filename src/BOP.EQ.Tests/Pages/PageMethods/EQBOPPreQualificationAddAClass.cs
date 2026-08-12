using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPreQualificationAddAClass
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPreQualificationAddAClass(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PreQualificationHeading => EQBOPPreQualificationAddAClassLocators.PreQualificationHeading(_page);

    public Task PressPreQualificationHeadingAsync(string key) => PreQualificationHeading.PressAsync(key);

    public Task DoubleClickPreQualificationHeadingAsync() => PreQualificationHeading.DblClickAsync();

    public Task WaitForPreQualificationHeadingAsync() =>
        PreQualificationHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SearchAddClassCode => EQBOPPreQualificationAddAClassLocators.SearchAddClassCode(_page);

    public Task PressSearchAddClassCodeAsync(string key) => SearchAddClassCode.PressAsync(key);

    public Task DoubleClickSearchAddClassCodeAsync() => SearchAddClassCode.DblClickAsync();

    public Task ClickSearchAddClassCodeAsync() => SearchAddClassCode.ClickAsync();

    private ILocator AddClassTablePopup => EQBOPPreQualificationAddAClassLocators.AddClassTablePopup(_page);

    public Task PressAddClassTablePopupAsync(string key) => AddClassTablePopup.PressAsync(key);

    public Task DoubleClickAddClassTablePopupAsync() => AddClassTablePopup.DblClickAsync();

    public Task SelectAddClassTablePopupAsync(string value) =>
        AddClassTablePopup.SelectOptionAsync(_data.Resolve(value));

    public Task WaitForAddClassTablePopupAsync() =>
        AddClassTablePopup.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TABLE => EQBOPPreQualificationAddAClassLocators.TABLE(_page);

    public Task PressTABLEAsync(string key) => TABLE.PressAsync(key);

    public Task DoubleClickTABLEAsync() => TABLE.DblClickAsync();

    public Task WaitForTABLEAsync() =>
        TABLE.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
