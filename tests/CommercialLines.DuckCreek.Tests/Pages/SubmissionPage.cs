using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

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

    public Task VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, expected, property, new ControlIntent("Submission", "AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs"));

    public Task ClickCompleteApplicationAsync() =>
        _ui.ClickAsync(_locators.CompleteApplication, new ControlIntent("Submission", "CompleteApplication"));

    public Task VerifyIsThisCoverageBoundAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IsThisCoverageBound, expected, property, new ControlIntent("Submission", "IsThisCoverageBound"));

    public Task EnterIsThisCoverageBoundAsync(string value) =>
        _ui.FillAsync(_locators.IsThisCoverageBound, value, new ControlIntent("Submission", "IsThisCoverageBound"));

    public Task PressIsThisCoverageBoundAsync(string key) =>
        _ui.PressAsync(_locators.IsThisCoverageBound, key, new ControlIntent("Submission", "IsThisCoverageBound"));

    public Task EnterJavaScriptAsync(string value) =>
        _ui.FillAsync(_locators.JavaScript, value, new ControlIntent("Submission", "JavaScript"));

    public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Submission", "LoadingMessage"));

    public Task VerifyResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Result, expected, property, new ControlIntent("Submission", "Result"));

    public Task WaitForStoplightWaitingWindowAsync(string expected) =>
        _ui.WaitAsync(_locators.StoplightWaitingWindow, expected, new ControlIntent("Submission", "StoplightWaitingWindow"));

    public Task VerifyStoplightWaitingWindowCloseAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, expected, property, new ControlIntent("Submission", "StoplightWaitingWindowClose"));

    public Task ClickStoplightWaitingWindowCloseAsync() =>
        _ui.ClickAsync(_locators.StoplightWaitingWindowClose, new ControlIntent("Submission", "StoplightWaitingWindowClose"));

    public Task VerifyStoplightWaitingWindowErrorAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.StoplightWaitingWindowError, expected, property, new ControlIntent("Submission", "StoplightWaitingWindowError"));

    public Task ClickStoplightWaitingWindowFirstCloseButtonOnErrorAsync() =>
        _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError, new ControlIntent("Submission", "StoplightWaitingWindowFirstCloseButtonOnError"));

    public Task EnterTitleAsync(string value) =>
        _ui.FillAsync(_locators.Title, value, new ControlIntent("Submission", "Title"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
