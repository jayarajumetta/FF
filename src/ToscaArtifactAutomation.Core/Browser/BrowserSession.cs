using Microsoft.Playwright;
using Serilog;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Reporting;

namespace ToscaArtifactAutomation.Core.Browser;

public sealed class BrowserSession : IAsyncDisposable
{
    private readonly RootSettings _settings;
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;
    private bool _traceStarted;

    public BrowserSession(RootSettings settings) => _settings = settings ?? throw new ArgumentNullException(nameof(settings));

    public IPage Page => _page ?? throw new InvalidOperationException("BrowserSession.StartAsync has not created a page.");
    public IBrowserContext Context => _context ?? throw new InvalidOperationException("BrowserSession.StartAsync has not created a context.");
    public string ScenarioArtifactDirectory { get; private set; } = string.Empty;

    public async Task StartAsync(string scenarioId, string scenarioTitle)
    {
        if (_browser is not null) throw new InvalidOperationException("Browser session is already started.");
        ScenarioArtifactDirectory = ArtifactPaths.CreateScenarioDirectory(_settings.Framework, scenarioId, scenarioTitle);
        _playwright = await Playwright.CreateAsync();
        var browserType = _settings.Framework.Browser.ToLowerInvariant() switch
        {
            "firefox" => _playwright.Firefox,
            "webkit" => _playwright.Webkit,
            _ => _playwright.Chromium
        };
        var launch = new BrowserTypeLaunchOptions
        {
            Headless = _settings.Framework.Headless,
            SlowMo = _settings.Framework.SlowMoMs,
            Channel = string.IsNullOrWhiteSpace(_settings.Framework.Channel) ? null : _settings.Framework.Channel
        };
        _browser = await browserType.LaunchAsync(launch);
        var contextOptions = new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true,
            RecordVideoDir = _settings.Framework.RecordVideo ? Path.Combine(ScenarioArtifactDirectory, "video") : null,
            RecordVideoSize = _settings.Framework.RecordVideo ? new RecordVideoSize { Width = 1440, Height = 900 } : null,
            ViewportSize = new ViewportSize { Width = 1440, Height = 900 }
        };
        _context = await _browser.NewContextAsync(contextOptions);
        _context.SetDefaultTimeout(_settings.Framework.DefaultTimeoutMs);
        _context.SetDefaultNavigationTimeout(_settings.Framework.NavigationTimeoutMs);
        if (_settings.Framework.RecordTrace)
        {
            await _context.Tracing.StartAsync(new TracingStartOptions { Screenshots = true, Snapshots = true, Sources = true });
            _traceStarted = true;
        }
        _page = await _context.NewPageAsync();
        Log.Information("Started browser session {ScenarioId} in {ArtifactDirectory}", scenarioId, ScenarioArtifactDirectory);
    }

    public async Task<string> CaptureScreenshotAsync(string name, bool fullPage = true)
    {
        if (_page is null || _page.IsClosed) return string.Empty;
        var path = Path.Combine(ScenarioArtifactDirectory, "screenshots", ArtifactPaths.SafeName(name) + ".png");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path, FullPage = fullPage });
        return path;
    }

    public async Task<string> CaptureDomAsync(string name)
    {
        if (_page is null || _page.IsClosed) return string.Empty;
        var path = Path.Combine(ScenarioArtifactDirectory, ArtifactPaths.SafeName(name) + ".html");
        await File.WriteAllTextAsync(path, await _page.ContentAsync());
        return path;
    }

    public async Task CloseExtraPagesAsync()
    {
        if (_context is null) return;
        foreach (var page in _context.Pages.Skip(1).ToArray())
            if (!page.IsClosed) await page.CloseAsync(new PageCloseOptions { RunBeforeUnload = false });
    }

    public async Task ClearCookiesAsync()
    {
        if (_context is not null) await _context.ClearCookiesAsync();
    }

    public async Task StopAsync()
    {
        if (_context is not null && _traceStarted)
        {
            try
            {
                await _context.Tracing.StopAsync(new TracingStopOptions { Path = Path.Combine(ScenarioArtifactDirectory, "trace.zip") });
            }
            catch (Exception ex) { Log.Warning(ex, "Unable to stop Playwright trace cleanly."); }
            _traceStarted = false;
        }
        if (_context is not null)
        {
            try { await _context.CloseAsync(); } catch (Exception ex) { Log.Warning(ex, "Unable to close browser context cleanly."); }
        }
        if (_browser is not null)
        {
            try { await _browser.CloseAsync(); } catch (Exception ex) { Log.Warning(ex, "Unable to close browser cleanly."); }
        }
        _context = null; _page = null; _browser = null;
        _playwright?.Dispose(); _playwright = null;
    }

    public async ValueTask DisposeAsync() => await StopAsync();
}
