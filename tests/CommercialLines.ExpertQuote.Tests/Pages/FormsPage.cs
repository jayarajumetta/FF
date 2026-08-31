using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class FormsPage
{
    private readonly BrowserSession _browser;
    private readonly FormsLocators _locators;
    private readonly UiActions _ui;

    public FormsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new FormsLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterFormsAPIRequest01660Async(string value) =>
        _ui.FillAsync(_locators.FormsAPIRequest01660, value, new ControlIntent("Forms", "FormsAPIRequest01660"));

    public Task EnterFormsAPIRequestB50D4Async(string value) =>
        _ui.FillAsync(_locators.FormsAPIRequest01660, value, new ControlIntent("Forms", "FormsAPIRequestB50D4"));

    public Task EnterFormsAPIResponse3FBAFAsync(string value) =>
        _ui.FillAsync(_locators.FormsAPIResponse3FBAF, value, new ControlIntent("Forms", "FormsAPIResponse3FBAF"));

    public Task EnterFormsAPIResponse53891Async(string value) =>
        _ui.FillAsync(_locators.FormsAPIResponse3FBAF, value, new ControlIntent("Forms", "FormsAPIResponse53891"));
public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("Forms", "LoadingMessage"));

    public Task<bool> IsLoadingMessagePresentAsync() =>
        _ui.ExistsAsync(_locators.LoadingMessage);

    public Task WaitForN1ResultsFoundCurrentlyShowing11Async(string expected) =>
        _ui.WaitAsync(_locators.N1ResultsFoundCurrentlyShowing11, expected, new ControlIntent("Forms", "N1ResultsFoundCurrentlyShowing11"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("Forms", "QuickSearchButton"));

    public Task EnterSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.SearchText, value, new ControlIntent("Forms", "SearchText"));

    public Task PressSearchTextAsync(string key) =>
        _ui.PressAsync(_locators.SearchText, key, new ControlIntent("Forms", "SearchText"));

    public Task WaitForViewPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.ViewPolicy, expected, new ControlIntent("Forms", "ViewPolicy"));

    public Task VerifyViewPolicyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ViewPolicy, expected, property, new ControlIntent("Forms", "ViewPolicy"));

    public Task ClickViewPolicyAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("Forms", "ViewPolicy"));

    public Task<bool> IsViewPolicyPresentAsync() =>
        _ui.ExistsAsync(_locators.ViewPolicy);

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task NoteAsync(string note) =>
        _ui.ReviewRequiredAsync(note);


    public Task<bool> IsFormsAPIRequest01660PresentAsync() => _ui.ExistsAsync(_locators.FormsAPIRequest01660);

    public Task<bool> IsFormsAPIResponse53891PresentAsync() => _ui.ExistsAsync(_locators.FormsAPIResponse3FBAF);

}
