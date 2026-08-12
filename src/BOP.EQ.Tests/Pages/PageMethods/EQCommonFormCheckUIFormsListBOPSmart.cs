using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonFormCheckUIFormsListBOPSmart
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonFormCheckUIFormsListBOPSmart(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator FORM => EQCommonFormCheckUIFormsListBOPSmartLocators.FORM(_page);

    public Task PressFORMAsync(string key) => FORM.PressAsync(key);

    public Task DoubleClickFORMAsync() => FORM.DblClickAsync();

    public Task VerifyFORMAsync(string expected) =>
        Expect(FORM).ToContainTextAsync(_data.Resolve(expected));

    public async Task StoreFORMAsync(string key)
    {
        var value = await FORM.TextContentAsync() ?? await FORM.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator FormNumber => EQCommonFormCheckUIFormsListBOPSmartLocators.FormNumber(_page);

    public Task PressFormNumberAsync(string key) => FormNumber.PressAsync(key);

    public Task DoubleClickFormNumberAsync() => FormNumber.DblClickAsync();

    public Task VerifyFormNumberAsync(string expected) =>
        Expect(FormNumber).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Close => EQCommonFormCheckUIFormsListBOPSmartLocators.Close(_page);

    public Task PressCloseAsync(string key) => Close.PressAsync(key);

    public Task DoubleClickCloseAsync() => Close.DblClickAsync();

    public Task ClickCloseAsync() => Close.ClickAsync();

}
