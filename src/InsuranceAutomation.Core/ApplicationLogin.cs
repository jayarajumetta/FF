using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class ApplicationLogin
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public ApplicationLogin(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;
        _data = data;
        _ui = ui;
    }

    public async Task SignInAsync(string application)
    {
        var username = _data.Get("username", _data.Get("UserName"));
        var password = _data.Get("password", _data.Get("Password"));

        if (ScenarioData.IsSynthetic(username))
        {
            username = Environment.GetEnvironmentVariable($"{application}_USERNAME") ?? string.Empty;
        }

        if (ScenarioData.IsSynthetic(password))
        {
            password = Environment.GetEnvironmentVariable($"{application}_PASSWORD") ?? string.Empty;
        }

        if (ScenarioData.IsSynthetic(username) || ScenarioData.IsSynthetic(password))
        {
            throw new InvalidOperationException($"Username/password are missing for {application}.");
        }

        var page = _browser.Page;
        var user = page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = "Username", Exact = true });
        var pass = page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = "Password", Exact = true });
        var signIn = page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameRegex = new Regex("Sign On|Sign In|Login", RegexOptions.IgnoreCase) });

        await _ui.FillAsync(user, username);
        await _ui.FillAsync(pass, password);
        await _ui.ClickAsync(signIn);
    }
}
