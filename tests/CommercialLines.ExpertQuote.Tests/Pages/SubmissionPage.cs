using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class SubmissionPage
{
    private readonly BrowserSession _browser;
    private readonly SubmissionLocators _locators;
    private readonly UiActions _ui;

    public SubmissionPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new SubmissionLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(string expected) =>
        _ui.WaitAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, expected, new ControlIntent("Submission", "AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs"));

    public Task VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, expected, property, new ControlIntent("Submission", "AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs"));

    public Task<bool> IsAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsPresentAsync() =>
        _ui.ExistsAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs);

    public Task VerifyCloseAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Close, expected, property, new ControlIntent("Submission", "Close"));

    public Task ClickCloseAsync() =>
        _ui.ClickAsync(_locators.Close, new ControlIntent("Submission", "Close"));

    public Task<bool> IsClosePresentAsync() =>
        _ui.ExistsAsync(_locators.Close);

    public Task ClickCompleteApplicationAsync() =>
        _ui.ClickAsync(_locators.CompleteApplication, new ControlIntent("Submission", "CompleteApplication"));

    public Task<bool> IsCompleteApplicationPresentAsync() =>
        _ui.ExistsAsync(_locators.CompleteApplication);

    public Task VerifyIsThisCoverageBoundAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IsThisCoverageBound, expected, property, new ControlIntent("Submission", "IsThisCoverageBound"));

    public Task PressIsThisCoverageBoundAsync(string key) =>
        _ui.PressAsync(_locators.IsThisCoverageBound, key, new ControlIntent("Submission", "IsThisCoverageBound"));

    public Task<bool> IsIsThisCoverageBoundPresentAsync() =>
        _ui.ExistsAsync(_locators.IsThisCoverageBound);

    public Task ClickLaunchToChecklistButtonAsync() =>
        _ui.ClickAsync(_locators.LaunchToChecklistButton, new ControlIntent("Submission", "LaunchToChecklistButton"));
public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Submission", "LoadingMessage"));

    public Task<bool> IsLoadingMessagePresentAsync() =>
        _ui.ExistsAsync(_locators.LoadingMessage);

    public Task VerifyNoReferralNeededVerificationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LaunchToChecklistButton, expected, property, new ControlIntent("Submission", "NoReferralNeededVerification"));

    public Task ClickReferToUWAsync() =>
        _ui.ClickAsync(_locators.ReferToUW, new ControlIntent("Submission", "ReferToUW"));

    public Task WaitForStoplightWaitingWindowAsync(string expected) =>
        _ui.WaitAsync(_locators.StoplightWaitingWindow, expected, new ControlIntent("Submission", "StoplightWaitingWindow"));

    public Task<bool> IsStoplightWaitingWindowPresentAsync() =>
        _ui.ExistsAsync(_locators.StoplightWaitingWindow);

    public Task VerifyStoplightWaitingWindowErrorAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.StoplightWaitingWindowError, expected, property, new ControlIntent("Submission", "StoplightWaitingWindowError"));

    public Task<bool> IsStoplightWaitingWindowErrorPresentAsync() =>
        _ui.ExistsAsync(_locators.StoplightWaitingWindowError);

    public Task ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync() =>
        _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError, new ControlIntent("Submission", "StoplightWaitingWindowFirstCloseButtonOnError"));

    public Task<bool> IsStoplightWaitingWindowFirstCloseButtonOnErrorPresentAsync() =>
        _ui.ExistsAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);

    public Task WaitForSubmissionScreenHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.SubmissionScreenHeading, expected, new ControlIntent("Submission", "SubmissionScreenHeading"));

    public Task VerifyTABLERowCellExplicitName1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName1, expected, property, new ControlIntent("Submission", "TABLERowCellExplicitName1"));

    public Task VerifyTABLERowCellExplicitName2Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName2, expected, property, new ControlIntent("Submission", "TABLERowCellExplicitName2"));

    public Task VerifyTABLERowCellExplicitName4Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName4, expected, property, new ControlIntent("Submission", "TABLERowCellExplicitName4"));

    public Task VerifyTABLERowCellExplicitName5Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.TABLERowCellExplicitName5, expected, property, new ControlIntent("Submission", "TABLERowCellExplicitName5"));

    public Task ClickTransmitAsync() =>
        _ui.ClickAsync(_locators.LaunchToChecklistButton, new ControlIntent("Submission", "Transmit"));

    public Task PressUnderwritingRulesAgentCommentsAsync(string key) =>
        _ui.PressAsync(_locators.ReferToUW, key, new ControlIntent("Submission", "UnderwritingRulesAgentComments"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
