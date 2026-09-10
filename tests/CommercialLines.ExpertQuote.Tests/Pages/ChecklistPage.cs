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

    public Task<bool> IsSignaturePageVisibleAsync() =>
        _locators.SignaturePage.IsVisibleAsync();

    public Task ClickSignaturePageAsync() =>
        _ui.ClickAsync(_locators.SignaturePage, new ControlIntent("Checklist", "SignaturePage"));

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
        // Dropzone.js injects the hidden <input class="dz-hidden-input"> dynamically after
        // initialization, so wait for it to be attached to the DOM before setting the file.
        await _locators.FileUploadInput.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
        await _locators.FileUploadInput.SetInputFilesAsync(filePath);
    }

    public Task WaitForCurrentItemsVisibleAsync() =>
        _locators.CurrentItemsHeading.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

    public Task ClickExceptionNoteCancelAsync() =>
        _ui.ClickAsync(_locators.ExceptionNoteCancel, new ControlIntent("Checklist", "ExceptionNoteCancel"));
}
