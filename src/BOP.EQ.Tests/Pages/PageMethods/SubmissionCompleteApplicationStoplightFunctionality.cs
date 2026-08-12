using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class SubmissionCompleteApplicationStoplightFunctionality
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public SubmissionCompleteApplicationStoplightFunctionality(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CompleteApplication => SubmissionCompleteApplicationStoplightFunctionalityLocators.CompleteApplication(_page);

    public Task PressCompleteApplicationAsync(string key) => CompleteApplication.PressAsync(key);

    public Task DoubleClickCompleteApplicationAsync() => CompleteApplication.DblClickAsync();

    public Task ClickCompleteApplicationAsync() => CompleteApplication.ClickAsync();

    private ILocator StoplightWaitingWindow => SubmissionCompleteApplicationStoplightFunctionalityLocators.StoplightWaitingWindow(_page);

    public Task PressStoplightWaitingWindowAsync(string key) => StoplightWaitingWindow.PressAsync(key);

    public Task DoubleClickStoplightWaitingWindowAsync() => StoplightWaitingWindow.DblClickAsync();

    public Task WaitForStoplightWaitingWindowAsync() =>
        StoplightWaitingWindow.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => SubmissionCompleteApplicationStoplightFunctionalityLocators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs(_page);

    public Task PressAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(string key) => AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs.PressAsync(key);

    public Task DoubleClickAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync() => AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs.DblClickAsync();

    public Task VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(string expected) =>
        Expect(AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync() =>
        AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
