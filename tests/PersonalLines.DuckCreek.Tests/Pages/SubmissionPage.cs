using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    public Task ClickAutoCycleRVApplicationAsync() =>
        _ui.ClickAsync(_locators.AutoCycleRVApplication, new ControlIntent("Submission", "AutoCycleRVApplication"));

    public Task<bool> IsAutoCycleRVApplicationPresentAsync() =>
        _ui.ExistsAsync(_locators.AutoCycleRVApplication);

    public Task EnterButtonAsync(string value) =>
        _ui.FillAsync(_locators.Button, value, new ControlIntent("Submission", "Button"));

    public Task EnterCaptionAsync(string value) =>
        _ui.FillAsync(_locators.Caption, value, new ControlIntent("Submission", "Caption"));

    public Task<bool> IsCaptionPresentAsync() =>
        _ui.ExistsAsync(_locators.Caption);

    public Task VerifyChecklist1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.Checklist1, expected, property, new ControlIntent("Submission", "Checklist1"));

    public Task ClickChecklist1Async() =>
        _ui.ClickAsync(_locators.Checklist1, new ControlIntent("Submission", "Checklist1"));

    public Task<bool> IsChecklist1PresentAsync() =>
        _ui.ExistsAsync(_locators.Checklist1);

    public Task ClickChecklistCloseOkAsync() =>
        _ui.ClickAsync(_locators.ChecklistCloseOk, new ControlIntent("Submission", "ChecklistCloseOk"));

    public Task VerifyCommentsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Comments, expected, property, new ControlIntent("Submission", "Comments"));

    public Task EnterCommentsAsync(string value) =>
        _ui.FillAsync(_locators.Comments, value, new ControlIntent("Submission", "Comments"));

    public Task<bool> IsCommentsPresentAsync() =>
        _ui.ExistsAsync(_locators.Comments);

    public Task VerifyCorrectionNeededStep1Async(string expected, string property) =>
        _ui.VerifyAsync(_locators.CorrectionNeededStep1, expected, property, new ControlIntent("Submission", "CorrectionNeededStep1"));

    public Task<bool> IsCorrectionNeededStep1PresentAsync() =>
        _ui.ExistsAsync(_locators.CorrectionNeededStep1);

    public Task<string> CaptureDIVAgentDocumentsCountAsync(string property = "") =>
        _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, property, new ControlIntent("Submission", "DIVAgentDocumentsCount"));

    public Task ClickDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync() =>
        _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer, new ControlIntent("Submission", "DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer"));

    public Task<bool> IsDIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerPresentAsync() =>
        _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);

    public Task ClickDIVSubmissionAsync() =>
        _ui.ClickAsync(_locators.DIVSubmission, new ControlIntent("Submission", "DIVSubmission"));

    public Task<bool> IsDIVSubmissionPresentAsync() =>
        _ui.ExistsAsync(_locators.DIVSubmission);

    public Task VerifyEQCommonLoadingIndicatorWaitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, expected, property, new ControlIntent("Submission", "EQCommonLoadingIndicatorWait"));

    public Task EnterFilePathAsync(string value) =>
        _ui.FillAsync(_locators.FilePath, value, new ControlIntent("Submission", "FilePath"));

    public Task ClickNewQuoteSearchAsync() =>
        _ui.ClickAsync(_locators.NewQuoteSearch, new ControlIntent("Submission", "NewQuoteSearch"));

    public Task WaitForPolicyNumberAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyNumber, expected, new ControlIntent("Submission", "PolicyNumber"));

    public Task<string> CapturePolicyNumberAsync(string property = "") =>
        _ui.CaptureAsync(_locators.PolicyNumber, property, new ControlIntent("Submission", "PolicyNumber"));

    public Task EnterQuotePolicySearchAsync(string value) =>
        _ui.FillAsync(_locators.QuotePolicySearch, value, new ControlIntent("Submission", "QuotePolicySearch"));

    public Task PressQuotePolicySearchAsync(string key) =>
        _ui.PressAsync(_locators.QuotePolicySearch, key, new ControlIntent("Submission", "QuotePolicySearch"));

    public Task<bool> IsQuotePolicySearchPresentAsync() =>
        _ui.ExistsAsync(_locators.QuotePolicySearch);

    public Task VerifyReferUWAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReferUW, expected, property, new ControlIntent("Submission", "ReferUW"));

    public Task ClickReferUWAsync() =>
        _ui.ClickAsync(_locators.ReferUW, new ControlIntent("Submission", "ReferUW"));

    public Task<bool> IsReferUWPresentAsync() =>
        _ui.ExistsAsync(_locators.ReferUW);

    public Task ClickSaveExit1Async() =>
        _ui.ClickAsync(_locators.SaveExit1, new ControlIntent("Submission", "SaveExit1"));

    public Task<bool> IsSaveExit1PresentAsync() =>
        _ui.ExistsAsync(_locators.SaveExit1);

    public Task WaitForSubmission1Async(string expected) =>
        _ui.WaitAsync(_locators.Submission1, expected, new ControlIntent("Submission", "Submission1"));

    public Task WaitForTransmitAsync(string expected) =>
        _ui.WaitAsync(_locators.Transmit, expected, new ControlIntent("Submission", "Transmit"));

    public Task ClickTransmitAsync() =>
        _ui.ClickAsync(_locators.Transmit, new ControlIntent("Submission", "Transmit"));

    public Task EnterTransmitConfirmationAsync(string value) =>
        _ui.FillAsync(_locators.TransmitConfirmation, value, new ControlIntent("Submission", "TransmitConfirmation"));

    public Task NavigateAsync(string url) =>
        _browser.Page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

}
