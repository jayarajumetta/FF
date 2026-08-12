using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonSubmissionReferToUW
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonSubmissionReferToUW(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator UnderwritingRulesAgentComments => EQCommonSubmissionReferToUWLocators.UnderwritingRulesAgentComments(_page);

    public Task PressUnderwritingRulesAgentCommentsAsync(string key) => UnderwritingRulesAgentComments.PressAsync(key);

    public Task DoubleClickUnderwritingRulesAgentCommentsAsync() => UnderwritingRulesAgentComments.DblClickAsync();

    public Task SetUnderwritingRulesAgentCommentsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, UnderwritingRulesAgentComments, _data.Resolve(value));

    public Task TypeUnderwritingRulesAgentCommentsAsync(string value, float delayMs = 40) =>
        UnderwritingRulesAgentComments.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ReferToUW => EQCommonSubmissionReferToUWLocators.ReferToUW(_page);

    public Task PressReferToUWAsync(string key) => ReferToUW.PressAsync(key);

    public Task DoubleClickReferToUWAsync() => ReferToUW.DblClickAsync();

    public Task ClickReferToUWAsync() => ReferToUW.ClickAsync();

}
