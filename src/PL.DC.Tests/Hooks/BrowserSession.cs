using Microsoft.Playwright;

namespace InsuranceAutomation.Hooks;

public sealed class BrowserSession : IAsyncDisposable
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private bool _traceStopped;

    public IPage Page { get; private set; } = null!;
    public List<string> ConsoleMessages { get; } = [];
    public List<string> PageErrors { get; } = [];
    public List<string> FailedRequests { get; } = [];
    public List<string> HttpErrors { get; } = [];

    public async Task StartAsync(string scenarioName)
    {
        _playwright = await Playwright.CreateAsync();

        var browserName =
            Environment.GetEnvironmentVariable("BROWSER")?.Trim().ToLowerInvariant()
            ?? "chromium";

        var browserType = browserName switch
        {
            "firefox" => _playwright.Firefox,
            "webkit" => _playwright.Webkit,
            _ => _playwright.Chromium
        };

        _browser = await browserType.LaunchAsync(new()
        {
            Headless = !string.Equals(
                Environment.GetEnvironmentVariable("HEADED"),
                "true",
                StringComparison.OrdinalIgnoreCase)
        });

        _context = await _browser.NewContextAsync(new()
        {
            RecordVideoDir = Path.Combine("Reports", "Videos"),
            IgnoreHTTPSErrors = false,
            ViewportSize = new() { Width = 1440, Height = 900 }
        });

        await _context.Tracing.StartAsync(new()
        {
            Title = scenarioName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        Page = await _context.NewPageAsync();

        Page.Console += (_, message) =>
            ConsoleMessages.Add($"{message.Type}: {message.Text}");
        Page.PageError += (_, error) =>
            PageErrors.Add(error);
        Page.RequestFailed += (_, request) =>
            FailedRequests.Add($"{request.Method} {request.Url} - {request.Failure}");
        Page.Response += (_, response) =>
        {
            if (response.Status >= 400)
                HttpErrors.Add($"{response.Status} {response.Url}");
        };
    }


    public async Task NavigateAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new InvalidOperationException("Application URL is empty. Provide BaseUrl in scenario data or BASE_URL in the environment.");

        await Page.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
    }

    public async Task CaptureFailureAsync(string scenarioName)
    {
        Directory.CreateDirectory(Path.Combine("Reports", "Screenshots"));
        Directory.CreateDirectory(Path.Combine("Reports", "Dom"));
        Directory.CreateDirectory(Path.Combine("Reports", "Traces"));
        Directory.CreateDirectory("Logs");

        var safeName = string.Concat(
            scenarioName.Select(character =>
                char.IsLetterOrDigit(character) ? character : '_'));

        try
        {
            await Page.ScreenshotAsync(new()
            {
                Path = Path.Combine("Reports", "Screenshots", safeName + ".png"),
                FullPage = true
            });
        }
        catch { }

        try
        {
            await File.WriteAllTextAsync(
                Path.Combine("Reports", "Dom", safeName + ".html"),
                await Page.ContentAsync());
        }
        catch { }

        await File.WriteAllTextAsync(
            Path.Combine("Logs", safeName + ".log"),
            string.Join(
                Environment.NewLine,
                ConsoleMessages
                    .Concat(PageErrors)
                    .Concat(FailedRequests)
                    .Concat(HttpErrors)));

        await StopTraceAsync(
            Path.Combine("Reports", "Traces", safeName + ".zip"));
    }

    private async Task StopTraceAsync(string? outputPath = null)
    {
        if (_context is null || _traceStopped)
            return;

        _traceStopped = true;
        try
        {
            await _context.Tracing.StopAsync(
                outputPath is null ? null : new() { Path = outputPath });
        }
        catch { }
    }

    public async ValueTask DisposeAsync()
    {
        await StopTraceAsync();

        if (_context is not null)
            await _context.CloseAsync();
        if (_browser is not null)
            await _browser.CloseAsync();

        _playwright?.Dispose();
    }
}
