using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class BrowserSession : IAsyncDisposable
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;
    private string _artifactDirectory = string.Empty;

    public bool IsStarted => _page is not null;

    public IPage Page => _page ?? throw new InvalidOperationException(
        "Browser session is not open. Ensure the Feature Background contains: Given I open a browser session.");

    public string? TracePath { get; private set; }
    public string? VideoPath { get; private set; }

    public void SetArtifactDirectory(string artifactDirectory)
    {
        _artifactDirectory = artifactDirectory;
        Directory.CreateDirectory(_artifactDirectory);
    }

    public async Task OpenAsync(RunLogger logger)
    {
        if (IsStarted)
        {
            return;
        }

        _artifactDirectory = string.IsNullOrWhiteSpace(_artifactDirectory)
            ? Path.Combine("Artifacts", DateTime.Now.ToString("yyyyMMdd_HHmmss"))
            : _artifactDirectory;

        var videos = Path.Combine(_artifactDirectory, "video");
        Directory.CreateDirectory(videos);

        var headless = ReadBool("HEADLESS", false);
        var traceEnabled = ReadBool("TRACE_ENABLED", true);
        var videoEnabled = ReadBool("VIDEO_ENABLED", true);
        var channel = Environment.GetEnvironmentVariable("BROWSER_CHANNEL")?.Trim();
        channel = string.IsNullOrWhiteSpace(channel) ? "msedge" : channel;

        _playwright = await Playwright.CreateAsync();

        logger.Info($"Opening browser. Channel={channel}; Headless={headless}; Trace={traceEnabled}; Video={videoEnabled}");

        _browser = await LaunchAsync(channel, headless, logger);
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = videoEnabled ? videos : null,
            IgnoreHTTPSErrors = ReadBool("IGNORE_HTTPS_ERRORS", true),
            ViewportSize = new ViewportSize
            {
                Width = ReadInt("VIEWPORT_WIDTH", 1440),
                Height = ReadInt("VIEWPORT_HEIGHT", 900)
            }
        });

        _context.SetDefaultTimeout(ReadInt("PLAYWRIGHT_TIMEOUT_MS", 30000));
        _context.SetDefaultNavigationTimeout(ReadInt("NAVIGATION_TIMEOUT_MS", 60000));

        if (traceEnabled)
        {
            await _context.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        _page = await _context.NewPageAsync();
        _page.Console += (_, message) => logger.Info($"BROWSER CONSOLE [{message.Type}]: {message.Text}");
        _page.PageError += (_, error) => logger.Error($"BROWSER PAGE ERROR: {error}");
    }

    private async Task<IBrowser> LaunchAsync(string channel, bool headless, RunLogger logger)
    {
        var options = new BrowserTypeLaunchOptions { Headless = headless };

        if (channel.Equals("msedge", StringComparison.OrdinalIgnoreCase) ||
            channel.Equals("chrome", StringComparison.OrdinalIgnoreCase))
        {
            options.Channel = channel.ToLowerInvariant();
            try
            {
                return await _playwright!.Chromium.LaunchAsync(options);
            }
            catch (PlaywrightException ex)
            {
                logger.Warn($"Unable to launch installed {channel}: {ex.Message}");
                logger.Warn("Falling back to Playwright Chromium.");
            }
        }

        try
        {
            return await _playwright!.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
        }
        catch (PlaywrightException firstFailure) when (ReadBool("AUTO_INSTALL_PLAYWRIGHT_BROWSER", true))
        {
            logger.Warn("Playwright Chromium is not installed. Installing Chromium automatically once.");
            var exitCode = Microsoft.Playwright.Program.Main(["install", "chromium"]);
            if (exitCode != 0)
            {
                throw new InvalidOperationException(
                    "Playwright browser installation failed. Run scripts\\install-browsers.ps1 once, or use an installed Edge browser with BROWSER_CHANNEL=msedge.",
                    firstFailure);
            }

            return await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
        }
    }

    public async Task<string?> CaptureScreenshotAsync(string fileName)
    {
        if (_page is null)
        {
            return null;
        }

        var directory = Path.Combine(_artifactDirectory, "screenshots");
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, fileName);
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path, FullPage = true });
        return path;
    }

    public async Task CloseAsync(RunLogger logger)
    {
        if (_context is null && _browser is null && _playwright is null)
        {
            return;
        }

        try
        {
            if (_context is not null && ReadBool("TRACE_ENABLED", true))
            {
                TracePath = Path.Combine(_artifactDirectory, "trace.zip");
                await _context.Tracing.StopAsync(new TracingStopOptions { Path = TracePath });
            }
        }
        finally
        {
            var video = _page?.Video;
            if (_context is not null)
            {
                await _context.CloseAsync();
            }

            if (video is not null)
            {
                try { VideoPath = await video.PathAsync(); } catch { VideoPath = null; }
            }

            if (_browser is not null)
            {
                await _browser.CloseAsync();
            }

            _playwright?.Dispose();
            _page = null;
            _context = null;
            _browser = null;
            _playwright = null;
            logger.Info("Browser session closed.");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_context is not null || _browser is not null || _playwright is not null)
        {
            using var logger = new RunLogger(Path.Combine("Artifacts", "dispose"));
            await CloseAsync(logger);
        }
    }

    private static bool ReadBool(string name, bool fallback) =>
        bool.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;

    private static int ReadInt(string name, int fallback) =>
        int.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;
}
