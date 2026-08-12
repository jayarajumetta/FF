using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonEsignatureClickOK
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonEsignatureClickOK(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator OkToUpdateFromChecklist => EQCommonEsignatureClickOKLocators.OkToUpdateFromChecklist(_page);

    public Task PressOkToUpdateFromChecklistAsync(string key) => OkToUpdateFromChecklist.PressAsync(key);

    public Task DoubleClickOkToUpdateFromChecklistAsync() => OkToUpdateFromChecklist.DblClickAsync();

    public Task ClickOkToUpdateFromChecklistAsync() => OkToUpdateFromChecklist.ClickAsync();

}
