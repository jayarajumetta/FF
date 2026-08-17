using System.Text.RegularExpressions;
using InsuranceAutomation.Core;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ApplicationPage
{
    private readonly BrowserSession _browser;
    private readonly UiActions _ui;

    public ApplicationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _ui = ui;
    }

    private ILocator Username => _browser.Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameRegex = new Regex("User ?Name|Username", RegexOptions.IgnoreCase) });
    private ILocator Password => _browser.Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameRegex = new Regex("Password", RegexOptions.IgnoreCase) });
    private ILocator SignIn => _browser.Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameRegex = new Regex("Sign On|Sign In|Login", RegexOptions.IgnoreCase) });

    public async Task NavigateAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Application URL is required.", nameof(url));
        await _browser.Page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
    }

    public async Task SignInAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username is required.", nameof(username));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password is required.", nameof(password));
        await _ui.FillAsync(Username, username);
        await _ui.FillAsync(Password, password);
        await _ui.ClickAsync(SignIn);
    }
}
