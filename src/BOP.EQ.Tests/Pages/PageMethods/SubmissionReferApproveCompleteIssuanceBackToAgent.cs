using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class SubmissionReferApproveCompleteIssuanceBackToAgent
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public SubmissionReferApproveCompleteIssuanceBackToAgent(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Approve => SubmissionReferApproveCompleteIssuanceBackToAgentLocators.Approve(_page);

    public Task PressApproveAsync(string key) => Approve.PressAsync(key);

    public Task DoubleClickApproveAsync() => Approve.DblClickAsync();

    public Task ClickApproveAsync() => Approve.ClickAsync();

    public Task WaitForApproveAsync() =>
        Approve.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ReferRequestIssuance => SubmissionReferApproveCompleteIssuanceBackToAgentLocators.ReferRequestIssuance(_page);

    public Task PressReferRequestIssuanceAsync(string key) => ReferRequestIssuance.PressAsync(key);

    public Task DoubleClickReferRequestIssuanceAsync() => ReferRequestIssuance.DblClickAsync();

    public Task ClickReferRequestIssuanceAsync() => ReferRequestIssuance.ClickAsync();

    public Task VerifyReferRequestIssuanceAsync(string expected) =>
        Expect(ReferRequestIssuance).ToContainTextAsync(_data.Resolve(expected));

    private ILocator CompleteIssuance => SubmissionReferApproveCompleteIssuanceBackToAgentLocators.CompleteIssuance(_page);

    public Task PressCompleteIssuanceAsync(string key) => CompleteIssuance.PressAsync(key);

    public Task DoubleClickCompleteIssuanceAsync() => CompleteIssuance.DblClickAsync();

    public Task ClickCompleteIssuanceAsync() => CompleteIssuance.ClickAsync();

    private ILocator BackToAgent => SubmissionReferApproveCompleteIssuanceBackToAgentLocators.BackToAgent(_page);

    public Task PressBackToAgentAsync(string key) => BackToAgent.PressAsync(key);

    public Task DoubleClickBackToAgentAsync() => BackToAgent.DblClickAsync();

    public Task ClickBackToAgentAsync() => BackToAgent.ClickAsync();

    public Task WaitForBackToAgentAsync() =>
        BackToAgent.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
