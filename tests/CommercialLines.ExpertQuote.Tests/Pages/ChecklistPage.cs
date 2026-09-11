using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class ChecklistPage
{
    private readonly BrowserSession _browser;
    private readonly ChecklistLocators _locators;
    private readonly UiActions _ui;

    public ChecklistPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new ChecklistLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickBuildingPhoto1Async() =>
        _ui.ClickAsync(_locators.BuildingPhoto1, new ControlIntent("Checklist", "BuildingPhoto1"));

    public async Task<bool> IsSignaturePageVisibleAsync()
    {
        // The checklist item list can still be rendering after the exception-note loop above,
        // so wait for the "Current Items" heading to settle first, then give the Signature Page
        // item a bounded wait instead of an instantaneous, non-waiting visibility check.
        try
        {
            await _locators.CurrentItemsHeading.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 15000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { }

        try
        {
            await _locators.SignaturePage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 5000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.SignaturePage.IsVisibleAsync();
    }

    public Task ClickSignaturePageAsync() =>
        _ui.ClickAsync(_locators.SignaturePage, new ControlIntent("Checklist", "SignaturePage"));

    // Returns true when the Signature Page item is already open (its item-name span is showing),
    // meaning the checklist list link does not need to be clicked again before attaching the file.
    // Instead of an instantaneous, non-waiting visibility check, poll for up to 15 seconds so the
    // element is given a real chance to appear if the page/section is still rendering.
    public async Task<bool> IsSignaturePageItemAlreadyOpenAsync()
    {
        try
        {
            await _locators.SignaturePageItemName.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 15000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.SignaturePageItemName.IsVisibleAsync();
    }

    public Task ClickExceptionAsync() =>
        _ui.ClickAsync(_locators.Exception, new ControlIntent("Checklist", "Exception"));

    public Task WaitForExceptionVisibleAsync() =>
        _locators.Exception.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

    public Task EnterRequireNoteAsync(string value) =>
        _ui.FillAsync(_locators.RequireNote, value, new ControlIntent("Checklist", "RequireNote"));

    public Task TypeRequireNoteAsync(string value) =>
        _ui.PressSequentiallyAsync(_locators.RequireNote, value, new ControlIntent("Checklist", "RequireNote"));

    public Task ClickRequireNoteAsync() =>
        _ui.ClickAsync(_locators.RequireNote, new ControlIntent("Checklist", "RequireNote"));

    public Task PressRequireNoteAsync(string key) =>
        _ui.PressAsync(_locators.RequireNote, key, new ControlIntent("Checklist", "RequireNote"));

    public Task ClickExceptionNoteConfirmOKAsync() =>
        _ui.ClickAsync(_locators.ExceptionNoteConfirmOK, new ControlIntent("Checklist", "ExceptionNoteConfirmOK"));

    public async Task UploadSignatureFileAsync(string filePath)
    {
        // Some Dropzone.js configurations (like this one) do not keep a persistent hidden
        // <input class="dz-hidden-input"> attached to the DOM; they only invoke the native OS
        // file picker when the dropzone element is clicked. Waiting for that input to attach
        // silently times out and no file ever gets uploaded, so use Playwright's file chooser
        // interception instead: click the dropzone and supply the file to the resulting chooser.
        await _locators.FileUploadDropzone.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        var fileChooserTask = _browser.Page.WaitForFileChooserAsync();
        await _locators.FileUploadDropzone.ClickAsync();
        var fileChooser = await fileChooserTask;
        await fileChooser.SetFilesAsync(filePath);
    }

    public Task WaitForCurrentItemsVisibleAsync() =>
        _locators.CurrentItemsHeading.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

    public Task ClickExceptionNoteCancelAsync() =>
        _ui.ClickAsync(_locators.ExceptionNoteCancel, new ControlIntent("Checklist", "ExceptionNoteCancel"));
}
