using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPrimaryInsuredDetailsGeneralUWQuestions2
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPrimaryInsuredDetailsGeneralUWQuestions2(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NoneOfTheAboveCheckBox => EQBOPPrimaryInsuredDetailsGeneralUWQuestions2Locators.NoneOfTheAboveCheckBox(_page);

    public Task PressNoneOfTheAboveCheckBoxAsync(string key) => NoneOfTheAboveCheckBox.PressAsync(key);

    public Task DoubleClickNoneOfTheAboveCheckBoxAsync() => NoneOfTheAboveCheckBox.DblClickAsync();

    public Task SetNoneOfTheAboveCheckBoxAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NoneOfTheAboveCheckBox, _data.Resolve(value));

    public Task TypeNoneOfTheAboveCheckBoxAsync(string value, float delayMs = 40) =>
        NoneOfTheAboveCheckBox.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickNoneOfTheAboveCheckBoxAsync() => NoneOfTheAboveCheckBox.ClickAsync();
}
