using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class SubmissionRequiredAndOptionalFields
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public SubmissionRequiredAndOptionalFields(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SubmissionHeading => SubmissionRequiredAndOptionalFieldsLocators.SubmissionHeading(_page);

    public Task PressSubmissionHeadingAsync(string key) => SubmissionHeading.PressAsync(key);

    public Task DoubleClickSubmissionHeadingAsync() => SubmissionHeading.DblClickAsync();

    public Task VerifySubmissionHeadingAsync(string expected) =>
        Expect(SubmissionHeading).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForSubmissionHeadingAsync() =>
        SubmissionHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator IsThisCoverageBound => SubmissionRequiredAndOptionalFieldsLocators.IsThisCoverageBound(_page);

    public Task PressIsThisCoverageBoundAsync(string key) => IsThisCoverageBound.PressAsync(key);

    public Task DoubleClickIsThisCoverageBoundAsync() => IsThisCoverageBound.DblClickAsync();

    public Task SetIsThisCoverageBoundAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IsThisCoverageBound, _data.Resolve(value));

    public Task TypeIsThisCoverageBoundAsync(string value, float delayMs = 40) =>
        IsThisCoverageBound.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyIsThisCoverageBoundAsync(string expected) =>
        Expect(IsThisCoverageBound).ToContainTextAsync(_data.Resolve(expected));

    private ILocator DoesThisChangeRepresentAReductionInCoverage => SubmissionRequiredAndOptionalFieldsLocators.DoesThisChangeRepresentAReductionInCoverage(_page);

    public Task PressDoesThisChangeRepresentAReductionInCoverageAsync(string key) => DoesThisChangeRepresentAReductionInCoverage.PressAsync(key);

    public Task DoubleClickDoesThisChangeRepresentAReductionInCoverageAsync() => DoesThisChangeRepresentAReductionInCoverage.DblClickAsync();

    public Task SetDoesThisChangeRepresentAReductionInCoverageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DoesThisChangeRepresentAReductionInCoverage, _data.Resolve(value));

    public Task TypeDoesThisChangeRepresentAReductionInCoverageAsync(string value, float delayMs = 40) =>
        DoesThisChangeRepresentAReductionInCoverage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OrderAudit => SubmissionRequiredAndOptionalFieldsLocators.OrderAudit(_page);

    public Task PressOrderAuditAsync(string key) => OrderAudit.PressAsync(key);

    public Task DoubleClickOrderAuditAsync() => OrderAudit.DblClickAsync();

    public Task SetOrderAuditAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OrderAudit, _data.Resolve(value));

    public Task TypeOrderAuditAsync(string value, float delayMs = 40) =>
        OrderAudit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyOrderAuditAsync(string expected) =>
        Expect(OrderAudit).ToContainTextAsync(_data.Resolve(expected));

}
