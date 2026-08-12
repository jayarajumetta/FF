using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAutoTabs
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAutoTabs(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DIVSubmission => EQAutoTabsLocators.DIVSubmission(_page);

    public Task PressDIVSubmissionAsync(string key) => DIVSubmission.PressAsync(key);

    public Task DoubleClickDIVSubmissionAsync() => DIVSubmission.DblClickAsync();

    public Task SetDIVSubmissionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DIVSubmission, _data.Resolve(value));

    public Task TypeDIVSubmissionAsync(string value, float delayMs = 40) =>
        DIVSubmission.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickDIVSubmissionAsync() => DIVSubmission.ClickAsync();
}
