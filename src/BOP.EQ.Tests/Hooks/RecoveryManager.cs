using System.Text.Json;

namespace InsuranceAutomation.Hooks;

public sealed class RecoveryManager
{
    private readonly BrowserSession _browser;
    private readonly RecoveryOptions _options;

    public RecoveryManager(BrowserSession browser)
    {
        _browser = browser;
        _options = LoadOptions();
    }

    public async Task AttemptFailureRecoveryAsync()
    {
        if (!_options.AttemptSafeLogout || _browser.Page is null)
            return;

        foreach (var selector in _options.SafeLogoutSelectors)
        {
            try
            {
                var locator = _browser.Page.Locator(selector).First;
                if (await locator.IsVisibleAsync(new() { Timeout = 750 }))
                {
                    await locator.ClickAsync(new() { Timeout = 2_000 });
                    return;
                }
            }
            catch
            {
                // Recovery is best-effort and must not replace the original failure.
            }
        }
    }

    private static RecoveryOptions LoadOptions()
    {
        var candidates = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "Integration", "recovery-policy.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "Integration", "recovery-policy.json")
        };

        var path = candidates.FirstOrDefault(File.Exists);
        if (path is null)
            return new RecoveryOptions();

        using var document = JsonDocument.Parse(File.ReadAllText(path));
        var root = document.RootElement;
        return new RecoveryOptions
        {
            AttemptSafeLogout = root
                .GetProperty("default")
                .GetProperty("attemptSafeLogout")
                .GetBoolean(),
            SafeLogoutSelectors = root
                .GetProperty("safeLogoutSelectors")
                .EnumerateArray()
                .Select(item => item.GetString() ?? string.Empty)
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToArray()
        };
    }

    private sealed class RecoveryOptions
    {
        public bool AttemptSafeLogout { get; init; } = true;
        public IReadOnlyList<string> SafeLogoutSelectors { get; init; } = [];
    }
}
