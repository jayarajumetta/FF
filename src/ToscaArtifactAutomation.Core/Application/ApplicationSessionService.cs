using System.Diagnostics;
using Serilog;
using ToscaArtifactAutomation.Core.Actions;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Locators;

namespace ToscaArtifactAutomation.Core.Application;

public sealed class ApplicationSessionService
{
    private sealed record AuthenticationProfile(
        string Code,
        string UsernameEnvironmentVariable,
        string PasswordEnvironmentVariable,
        IReadOnlyList<string> UsernameControls,
        IReadOnlyList<string> PasswordControls,
        IReadOnlyList<string> SignInControls,
        IReadOnlyList<string> ReadyControls,
        IReadOnlyList<string> LoadingControls);

    private readonly RootSettings _settings;
    private readonly BrowserSession _browser;
    private readonly LocatorResolver _resolver;
    private readonly UiActions _actions;
    private readonly UiAssertions _assertions;

    public ApplicationSessionService(RootSettings settings, BrowserSession browser, LocatorResolver resolver, UiActions actions, UiAssertions assertions)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _browser = browser ?? throw new ArgumentNullException(nameof(browser));
        _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        _actions = actions ?? throw new ArgumentNullException(nameof(actions));
        _assertions = assertions ?? throw new ArgumentNullException(nameof(assertions));
    }

    public void ValidateApplication(string applicationCode, string browser)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationCode);
        ArgumentException.ThrowIfNullOrWhiteSpace(browser);
        if (!string.Equals(applicationCode, _settings.Application.Code, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"Feature requested application '{applicationCode}', but this test assembly is configured for '{_settings.Application.Code}'.");
        if (!browser.Contains("Edge", StringComparison.OrdinalIgnoreCase) && !browser.Contains("Chromium", StringComparison.OrdinalIgnoreCase))
            Log.Warning("Feature browser '{Browser}' differs from the source configuration's Microsoft Edge expectation.", browser);
    }

    public async Task EnsureAuthenticatedAsync(string applicationCode)
    {
        ValidateApplication(applicationCode, "Microsoft Edge");
        if (string.IsNullOrWhiteSpace(_browser.Page.Url) || _browser.Page.Url == "about:blank")
            await _browser.Page.GotoAsync(_settings.Application.BaseUrl, new Microsoft.Playwright.PageGotoOptions { WaitUntil = Microsoft.Playwright.WaitUntilState.DOMContentLoaded });
        await AuthenticateCurrentPageAsync(applicationCode, waitForReady: true);
    }

    public async Task AuthenticateCurrentPageAsync(string applicationCode, bool waitForReady = false)
    {
        var profile = BuildProfile(applicationCode);
        var usernameControl = await FindVisibleControlAsync(profile.UsernameControls);
        if (usernameControl is null)
        {
            Log.Information("No visible {ApplicationCode} login form was found; treating the current page as an existing authenticated session.", profile.Code);
            if (waitForReady) await WaitForReadyAsync(profile);
            return;
        }

        var passwordControl = await FindVisibleControlAsync(profile.PasswordControls)
            ?? throw new InvalidOperationException($"The {profile.Code} username control is visible, but no password control could be resolved.");
        var signInControl = await FindVisibleControlAsync(profile.SignInControls)
            ?? throw new InvalidOperationException($"The {profile.Code} login form is visible, but no sign-in control could be resolved.");

        var username = Environment.GetEnvironmentVariable(profile.UsernameEnvironmentVariable);
        var password = Environment.GetEnvironmentVariable(profile.PasswordEnvironmentVariable);
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new InvalidOperationException($"Authentication for '{profile.Code}' requires environment variables '{profile.UsernameEnvironmentVariable}' and '{profile.PasswordEnvironmentVariable}'.");

        await _actions.SmartSetAsync(usernameControl, username, "Login", Array.Empty<string>());
        await _actions.SmartSetAsync(passwordControl, password, "Login", Array.Empty<string>());
        await _actions.ClickAsync(signInControl, "Login", Array.Empty<string>());

        foreach (var loadingControl in profile.LoadingControls)
        {
            if (string.IsNullOrWhiteSpace(loadingControl)) continue;
            try
            {
                await _assertions.WaitAsync(loadingControl, string.Empty, "Absent", string.Empty, string.Empty, 30000);
                break;
            }
            catch (TimeoutException) { Log.Debug("Loading control {LoadingControl} remained visible or was not applicable for {ApplicationCode}.", loadingControl, profile.Code); }
        }
        if (waitForReady) await WaitForReadyAsync(profile);
    }

    private async Task<string?> FindVisibleControlAsync(IEnumerable<string> candidates)
    {
        foreach (var candidate in candidates.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase))
            if (await _resolver.TryResolveAsync(candidate, "Login") is not null) return candidate;
        return null;
    }

    private async Task WaitForReadyAsync(AuthenticationProfile profile)
    {
        var timer = Stopwatch.StartNew();
        while (timer.ElapsedMilliseconds < _settings.Framework.DefaultTimeoutMs)
        {
            foreach (var candidate in profile.ReadyControls.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase))
                if (await _resolver.TryResolveAsync(candidate) is not null) return;
            await Task.Delay(250);
        }
        throw new TimeoutException($"Authenticated {profile.Code} session did not expose any configured ready control: {string.Join(", ", profile.ReadyControls)}.");
    }

    private AuthenticationProfile BuildProfile(string applicationCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationCode);
        var code = applicationCode.Trim().ToUpperInvariant();
        var profile = code switch
        {
            "CL_EQ" => new AuthenticationProfile("CL_EQ", "CL_EQ_USERNAME", "CL_EQ_PASSWORD",
                new[] { "Username", "UserName" }, new[] { "Password" }, new[] { "Sign On", "Login" },
                new[] { "New Quote", "Start New Quote" }, new[] { "Loading ..." }),
            "CL_DC" => new AuthenticationProfile("CL_DC", "CL_DC_USERNAME", "CL_DC_PASSWORD",
                new[] { "UserName", "Username", "Txt_Username" }, new[] { "Password", "Txt_Password" },
                new[] { "Login", "Sign On", "Btn_Sign On" }, new[] { "New Quote", "Policy Search", "Client Search" },
                new[] { "Loading ...", "Please Wait" }),
            "PL_DC" => new AuthenticationProfile("PL_DC", "PL_DC_USERNAME", "PL_DC_PASSWORD",
                new[] { "Txt_Username", "UserName", "Username" }, new[] { "Txt_Password", "Password" },
                new[] { "Btn_Sign On", "Sign On", "Login" }, new[] { "Btn_New Quote", "New Quote" },
                new[] { "Loading ...", "Please Wait" }),
            _ => throw new ArgumentOutOfRangeException(nameof(applicationCode), applicationCode, "Supported authentication profiles are CL_EQ, CL_DC, and PL_DC.")
        };

        if (!string.Equals(code, _settings.Application.Code, StringComparison.OrdinalIgnoreCase)) return profile;
        return profile with
        {
            UsernameEnvironmentVariable = _settings.Application.UsernameEnvironmentVariable,
            PasswordEnvironmentVariable = _settings.Application.PasswordEnvironmentVariable,
            UsernameControls = Merge(_settings.Application.UsernameControl, profile.UsernameControls),
            PasswordControls = Merge(_settings.Application.PasswordControl, profile.PasswordControls),
            SignInControls = Merge(_settings.Application.SignInControl, profile.SignInControls),
            ReadyControls = Merge(_settings.Application.ReadyControl, profile.ReadyControls),
            LoadingControls = Merge(_settings.Application.LoadingControl, profile.LoadingControls)
        };
    }

    private static IReadOnlyList<string> Merge(string first, IReadOnlyList<string> remaining) =>
        new[] { first }.Concat(remaining).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
}
