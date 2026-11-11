using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class RegressionIssuancePage
{
    private readonly BrowserSession _browser;
    private readonly UiActions _ui;

    private RegressionIssuanceLocators L => new(_browser.Page);

    public RegressionIssuancePage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _ui = ui;
    }

    private static async Task<bool> VisibleAsync(ILocator locator) =>
        await locator.CountAsync() > 0 && await locator.IsVisibleAsync();

    private static async Task<bool> WaitForVisibleAsync(ILocator locator, int timeout = 20000)
    {
        try
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeout });
        }
        catch (TimeoutException)
        {
            // Fall through to the visibility check below, which will no-op if still not visible.
        }

        return await VisibleAsync(locator);
    }

    public async Task ClickReferAsync()
    {
        try
        {
            await L.Refer.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
        }
        catch (TimeoutException)
        {
            // Fall through to the visibility check below, which will no-op if still not visible.
        }

        if (await VisibleAsync(L.Refer))
            await _ui.ClickAsync(L.Refer, new ControlIntent("RegressionIssuance", "Refer"));
    }

    public async Task ClickReferButtonAsync()
    {
        if (await VisibleAsync(L.SubmissionNavigation))
            await _ui.ClickAsync(L.SubmissionNavigation, new ControlIntent("RegressionIssuance", "SubmissionNavigation"));

        if (await WaitForVisibleAsync(L.ReferButton, 15000))
            await _ui.ClickAsync(L.ReferButton, new ControlIntent("RegressionIssuance", "ReferButton"));

        await _browser.Page.WaitForTimeoutAsync(6000);

        if (await WaitForVisibleAsync(L.PopupOK, 15000))
            await _ui.ClickAsync(L.PopupOK, new ControlIntent("RegressionIssuance", "PopupOK"));

        await _browser.Page.WaitForTimeoutAsync(8000);
    }

    public async Task ClickPopupOkAsync()
    {
        if (await L.PopupOK.CountAsync() > 0)
            await _ui.ClickAsync(L.PopupOK, new ControlIntent("RegressionIssuance", "PopupOK"));
    }

    public async Task ClickApproveAsync()
    {
        await WaitForVisibleAsync(L.Approve, 20000);

        if (await VisibleAsync(L.Approve))
            await _ui.ClickAsync(L.Approve, new ControlIntent("RegressionIssuance", "Approve"));

        if (await VisibleAsync(L.PopupOK))
            await _ui.ClickAsync(L.PopupOK, new ControlIntent("RegressionIssuance", "PopupOK"));
    }

    public async Task<string> ClickViewPolicyAsync()
    {
        if (await VisibleAsync(L.ViewPolicy))
            await _ui.ClickAsync(L.ViewPolicy, new ControlIntent("RegressionIssuance", "ViewPolicy"));

        try
        {
            await L.PolicyNumberLabel.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        }
        catch (TimeoutException)
        {
            // Fall through to the visibility check below, which will no-op if still not visible.
        }

        var policyNumber = string.Empty;
        if (await VisibleAsync(L.ActivePolicyNumber))
            policyNumber = (await L.ActivePolicyNumber.TextContentAsync())?.Trim() ?? string.Empty;

        return policyNumber;
    }

    public async Task<bool> WaitForExceptionVisibleAsync() =>
        await WaitForVisibleAsync(L.Exception, 20000);

    public Task ClickExceptionAsync() =>
        _ui.ClickAsync(L.Exception, new ControlIntent("RegressionIssuance", "Exception"));

    public Task TypeRequireNoteAsync(string value) =>
        _ui.PressSequentiallyAsync(L.RequireNote, value, new ControlIntent("RegressionIssuance", "RequireNote"));

    public Task ClickExceptionNoteConfirmOKAsync() =>
        _ui.ClickAsync(L.ExceptionNoteConfirmOK, new ControlIntent("RegressionIssuance", "ExceptionNoteConfirmOK"));

    public async Task NavigateToPolicyInfoAsync()
    {
        await WaitForVisibleAsync(L.PolicyInfo, 20000);

        if (await VisibleAsync(L.PolicyInfo))
            await _ui.ClickAsync(L.PolicyInfo, new ControlIntent("RegressionIssuance", "PolicyInfo"));
    }

    public async Task<string> CaptureEffectiveDateAsync()
    {
        try
        {
            await L.EffectiveDateLabel.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 20000 });
        }
        catch (TimeoutException)
        {
            // Fall through to the visibility check below, which will no-op if still not visible.
        }

        if (await VisibleAsync(L.PolicyEffectiveDate))
        {
            var effectiveDate = (await L.PolicyEffectiveDate.InputValueAsync())?.Trim() ?? string.Empty;
            Console.WriteLine($"Captured policy effective date: {effectiveDate}");
            return effectiveDate;
        }

        return string.Empty;
    }

    public async Task ClickCompleteIssuanceAsync()
    {
        await _browser.Page.WaitForTimeoutAsync(3000);

        if (await VisibleAsync(L.SubmissionNavigation))
            await _ui.ClickAsync(L.SubmissionNavigation, new ControlIntent("RegressionIssuance", "SubmissionNavigation"));

        if (await WaitForVisibleAsync(L.CompleteIssuance, 10000))
            await _ui.ClickAsync(L.CompleteIssuance, new ControlIntent("RegressionIssuance", "CompleteIssuance"));

        await _browser.Page.WaitForTimeoutAsync(10000);

        if (await WaitForVisibleAsync(L.ESubmitChecklistQuestion, 20000))
            await _ui.ClickAsync(L.ESubmitChecklistOK, new ControlIntent("RegressionIssuance", "ESubmitChecklistOK"));

        if (await WaitForVisibleAsync(L.ReturnToDashboard))
            await _ui.ClickAsync(L.ReturnToDashboard, new ControlIntent("RegressionIssuance", "ReturnToDashboard"));

        await _browser.Page.WaitForTimeoutAsync(5000);
    }

    public async Task ClickCompleteApplicationAsync()
    {
        var page = new NavigationPage(_browser, _ui);

        await page.WaitForSubmissionAsync("Visible");
        await page.ClickSubmissionAsync();
        await page.PauseAsync(4000);
        await page.WaitForCompleteApplicationAsync("Exists");
        await page.ClickCompleteApplicationAsync();
        await page.WaitForStoplightWaitingResultsAsync("Visible");
        await page.ClickStoplightCloseButtonAsync();
        await page.PauseAsync(1000);

        if (await VisibleAsync(L.Approve))
            await _ui.ClickAsync(L.Approve, new ControlIntent("RegressionIssuance", "Approve"));

        if (await L.PopupOK.CountAsync() > 0)
            await _ui.ClickAsync(L.PopupOK, new ControlIntent("RegressionIssuance", "PopupOK"));
    }

    public async Task<string> CompleteIssuanceAndCapturePolicyNumberAsync()
    {
        if (await VisibleAsync(L.Submission))
            await _ui.ClickAsync(L.Submission, new ControlIntent("RegressionIssuance", "Submission"));

        if (await VisibleAsync(L.ReferOrRequestIssuance))
            await _ui.ClickAsync(L.ReferOrRequestIssuance, new ControlIntent("RegressionIssuance", "RequestIssuance"));

        if (await VisibleAsync(L.Approve))
            await _ui.ClickAsync(L.Approve, new ControlIntent("RegressionIssuance", "Approve"));

        if (await VisibleAsync(L.RunStoplight))
        {
            await _ui.ClickAsync(L.RunStoplight, new ControlIntent("RegressionIssuance", "RunStoplight"));

            if (await L.StoplightWindow.CountAsync() > 0)
                await L.StoplightWindow.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 120000 });
        }

        if (await VisibleAsync(L.CompleteIssuance))
            await _ui.ClickAsync(L.CompleteIssuance, new ControlIntent("RegressionIssuance", "CompleteIssuance"));

        await _browser.Page.WaitForTimeoutAsync(1000);

        var value = string.Empty;
        if (await L.PolicyNumber.CountAsync() > 0)
        {
            value = await L.PolicyNumber.InputValueAsync().ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(value))
                value = (await L.PolicyNumber.TextContentAsync().ConfigureAwait(false)) ?? string.Empty;
        }

        if (await VisibleAsync(L.BackToAgent))
            await _ui.ClickAsync(L.BackToAgent, new ControlIntent("RegressionIssuance", "BackToAgent"));

        return value.Trim();
    }

    public async Task VerifyChecklistAsync(string policyNumber)
    {
        if (await VisibleAsync(L.Submission))
            await _ui.ClickAsync(L.Submission, new ControlIntent("RegressionIssuance", "Submission"));

        if (!await VisibleAsync(L.Checklist))
            throw new InvalidOperationException("Checklist link was not available after opening Submission.");

        try
        {
            await _browser.SwitchToNewPageAsync(() => _ui.ClickAsync(L.Checklist, new ControlIntent("RegressionIssuance", "Checklist")), 20000);

            if (await L.ChecklistSummary.CountAsync() > 0)
                await Microsoft.Playwright.Assertions.Expect(L.ChecklistSummary).ToBeVisibleAsync();

            await Microsoft.Playwright.Assertions.Expect(_browser.Page.Locator("body"))
                .ToContainTextAsync(policyNumber, new() { Timeout = 30000 });
        }
        finally
        {
            if (!_browser.Page.IsClosed)
                await _browser.Page.CloseAsync();

            await _browser.SwitchToFirstPageAsync();
        }
    }

    public async Task VerifyInspireAsync(string policyNumber)
    {
        if (!await VisibleAsync(L.LaunchInspire))
            throw new InvalidOperationException("Launch Inspire link was not available.");

        try
        {
            await _browser.SwitchToNewPageAsync(() => _ui.ClickAsync(L.LaunchInspire, new ControlIntent("RegressionIssuance", "LaunchInspire")), 20000);

            await Microsoft.Playwright.Assertions.Expect(L.InspireHeader)
                .ToContainTextAsync(policyNumber, new() { Timeout = 30000 });
        }
        finally
        {
            if (!_browser.Page.IsClosed)
                await _browser.Page.CloseAsync();

            await _browser.SwitchToFirstPageAsync();
        }
    }

    public async Task ClickLaunchInspireAsync()
    {
        if (await VisibleAsync(L.LaunchInspire))
            await _browser.SwitchToNewPageAsync(() => _ui.ClickAsync(L.LaunchInspire, new ControlIntent("RegressionIssuance", "LaunchInspire")), 20000);
    }

    public async Task SignInToInspireAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username is required.", nameof(username));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required.", nameof(password));

        if (await WaitForVisibleAsync(L.InspireUsername, 20000))
        {
            await _ui.FillAsync(L.InspireUsername, username, new ControlIntent("RegressionIssuance", "InspireUsername"));
            await _ui.FillAsync(L.InspirePassword, password, new ControlIntent("RegressionIssuance", "InspirePassword"));
            await _ui.ClickAsync(L.InspireSignIn, new ControlIntent("RegressionIssuance", "InspireSignIn"));
            await _browser.Page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions { Timeout = 60000 });
        }
    }

    public async Task LaunchToChecklistAsync()
    {
        if (await VisibleAsync(L.SubmissionNavigation))
            await _ui.ClickAsync(L.SubmissionNavigation, new ControlIntent("RegressionIssuance", "SubmissionNavigation"));

        await _browser.Page.WaitForTimeoutAsync(6000);

        await WaitForVisibleAsync(L.LaunchToChecklist, 20000);

        if (await VisibleAsync(L.LaunchToChecklist))
        {
            await _browser.SwitchToNewPageAsync(async () =>
            {
                await _ui.ClickAsync(L.LaunchToChecklist, new ControlIntent("RegressionIssuance", "LaunchToChecklist"));
            });
            await _browser.Page.WaitForTimeoutAsync(2000);

        

            if (await WaitForVisibleAsync(L.InspireUsername, 20000) && await VisibleAsync(L.InspirePassword))
                await SignInToInspireAsync("YDH040", "Anico456");

            await L.ChecklistCurrentItemsHeading.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _browser.Page.WaitForTimeoutAsync(2000);
            await _ui.ClickAsync(L.FirstChecklistItem, new ControlIntent("RegressionIssuance", "FirstChecklistItem"));
            await _browser.Page.WaitForTimeoutAsync(2000);

            while (await _ui.ExistsAsync(L.ChecklistAddNote))
            {
                await _browser.Page.WaitForTimeoutAsync(2000);
                await _ui.FillAsync(L.ChecklistNoteTextArea, "TestChecklistforUW", new ControlIntent("RegressionIssuance", "ChecklistNoteTextArea"));
                await _browser.Page.WaitForTimeoutAsync(2000);

                if (await WaitForExceptionVisibleAsync())
                {
                    await ClickExceptionAsync();
                    await _browser.Page.WaitForTimeoutAsync(2000);
                    await TypeRequireNoteAsync("TestChecklistforUW");
                    await _browser.Page.WaitForTimeoutAsync(2000);
                    await ClickExceptionNoteConfirmOKAsync();
                    await _browser.Page.WaitForTimeoutAsync(5000);
                }

                if (await VisibleAsync(L.ChecklistValidFileTypesText))
                {
                    var documentFilePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Assets", "Test.png");
                    await L.ChecklistDocumentDropzoneContainer.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                    var fileChooserTask = _browser.Page.WaitForFileChooserAsync();
                    await L.ChecklistDocumentDropzoneMessage.ClickAsync(new LocatorClickOptions { Force = true, Timeout = 30000 });
                    var fileChooser = await fileChooserTask;
                    await fileChooser.SetFilesAsync(documentFilePath);
                    await _browser.Page.WaitForTimeoutAsync(6000);
                }
            }
            await _browser.Page.WaitForTimeoutAsync(2000);
            await L.ChecklistCurrentItemsHeading.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _browser.Page.WaitForTimeoutAsync(2000);

            // Always attempt to return to the original DuckCreek window and dismiss the
            // "Checklist Opened" modal, even if a checklist action above failed, so the
            // outer scenario is not left stuck on the checklist popup.
            await _browser.Page.WaitForTimeoutAsync(8000);
            await _browser.SwitchToFirstPageAsync();
            await _browser.Page.WaitForTimeoutAsync(5000);
            if (await VisibleAsync(L.ChecklistOpenedOK))
                await _ui.ClickAsync(L.ChecklistOpenedOK, new ControlIntent("RegressionIssuance", "ChecklistOpenedOK"));
            await _browser.Page.WaitForTimeoutAsync(7000);
        }
    }

    public async Task<bool> IsConfirmBusinessOwnersHeaderVisibleAsync()
    {
        try
        {
            return await WaitForVisibleAsync(L.ConfirmBusinessOwnersHeader, 20000);
        }
        finally
        {
            if (!_browser.Page.IsClosed)
                await _browser.Page.CloseAsync();

            await _browser.SwitchToFirstPageAsync();
        }
    }
}
