using System.IO.Compression;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class BrowserSession : IAsyncDisposable
{
    private readonly FrameworkConfig _config;
    private readonly object _evidenceGate = new();
    private readonly List<string> _stepConsoleErrors = [];
    private readonly List<string> _stepNetworkErrors = [];
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;
    private string _artifactDirectory = string.Empty;
    private string _consoleLogPath = string.Empty;
    private string _networkLogPath = string.Empty;

    public BrowserSession(FrameworkConfig config) => _config = config;

    public bool IsStarted => _page is not null;
    public IPage Page => _page ?? throw new InvalidOperationException("Browser is not open. Ensure the Feature Background contains: Given I open a browser session.");
    public string ArtifactDirectory => _artifactDirectory;
    public string? TracePath { get; private set; }
    public string? VideoPath { get; private set; }
    public string? HarPath { get; private set; }
    public string? EvidenceBundlePath { get; private set; }

    public void SetArtifactDirectory(string artifactDirectory)
    {
        _artifactDirectory = artifactDirectory;
        Directory.CreateDirectory(_artifactDirectory);
        _consoleLogPath = Path.Combine(_artifactDirectory, "console.log");
        _networkLogPath = Path.Combine(_artifactDirectory, "network.log");
        // v57: do not create empty placeholder console/network evidence while collection is disabled.
    }

    public async Task OpenAsync(RunLogger logger)
    {
        if (IsStarted) return;
        _playwright = await Playwright.CreateAsync();
        _browser = await LaunchAsync(logger);

        var videoDirectory = Path.Combine(_artifactDirectory, "video");
        if (_config.Browser.Video) Directory.CreateDirectory(videoDirectory);
        HarPath = _config.Browser.Har ? Path.Combine(_artifactDirectory, "network.har.zip") : null;

        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = _config.Browser.IgnoreHttpsErrors,
            ViewportSize = _config.Browser.Maximize ? ViewportSize.NoViewport : new ViewportSize { Width = _config.Browser.ViewportWidth, Height = _config.Browser.ViewportHeight },
            RecordVideoDir = _config.Browser.Video ? videoDirectory : null,
            RecordHarPath = HarPath,
            RecordHarMode = _config.Browser.Har ? HarMode.Full : null,
            RecordHarContent = _config.Browser.Har ? HarContentPolicy.Attach : null
        });
        _context.SetDefaultTimeout(_config.Browser.ActionTimeoutMs);
        _context.SetDefaultNavigationTimeout(_config.Browser.NavigationTimeoutMs);

        if (_config.Browser.Trace)
        {
            await _context.Tracing.StartAsync(new TracingStartOptions { Screenshots = true, Snapshots = true, Sources = true });
        }

        _page = await _context.NewPageAsync();
        if (_config.Reporting.CollectConsole || _config.Reporting.CollectNetwork) WireEvidence(logger, _page);
        logger.Info($"Browser session opened. Channel={_config.Browser.Channel}; Headless={_config.Browser.Headless}; HAR={_config.Browser.Har}; Console={_config.Reporting.CollectConsole}; Network={_config.Reporting.CollectNetwork}");
    }

    public void BeginStepEvidence()
    {
        lock (_evidenceGate)
        {
            _stepConsoleErrors.Clear();
            _stepNetworkErrors.Clear();
        }
    }

    public StepEvidence EndStepEvidence()
    {
        lock (_evidenceGate)
        {
            return new StepEvidence(_stepConsoleErrors.ToArray(), _stepNetworkErrors.ToArray());
        }
    }

    public async Task<string?> CaptureScreenshotAsync(string fileName)
    {
        if (_page is null) return null;
        var path = Path.Combine(_artifactDirectory, "screenshots", Safe(fileName));
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path, FullPage = true });
        return path;
    }

    public async Task<byte[]> CaptureScreenshotBytesAsync()
    {
        if (_page is null) return Array.Empty<byte>();
        return await _page.ScreenshotAsync(new PageScreenshotOptions { FullPage = true });
    }

    public async Task CloseAsync(RunLogger logger)
    {
        if (_context is null && _browser is null && _playwright is null) return;

        IVideo? video = null;
        try { video = _page?.Video; } catch { }

        if (_context is not null && _config.Browser.Trace)
        {
            TracePath = Path.Combine(_artifactDirectory, "trace.zip");
            try { await _context.Tracing.StopAsync(new TracingStopOptions { Path = TracePath }); }
            catch (Exception ex) { logger.Warn($"Unable to stop trace: {ex.Message}"); }
        }

        // Video is finalized when the context closes (HAR collection is disabled in v57). Resolve Video.PathAsync only after close;
        // resolving it before close can leave Visual Studio with no completed video attachment.
        try { if (_context is not null) await _context.CloseAsync(); }
        catch (Exception ex) { logger.Warn($"Unable to close browser context cleanly: {ex.Message}"); }

        try
        {
            if (video is not null)
            {
                var resolvedVideoPath = await video.PathAsync();
                VideoPath = PersistFinalizedVideo(resolvedVideoPath, logger);
                logger.Info($"Playwright video finalized: {VideoPath}");
            }
        }
        catch (Exception ex) { logger.Warn($"Unable to resolve finalized Playwright video path: {ex.Message}"); }

        try { if (_browser is not null) await _browser.CloseAsync(); } catch { }
        _playwright?.Dispose();
        _page = null; _context = null; _browser = null; _playwright = null;
    }

    private string PersistFinalizedVideo(string resolvedPath, RunLogger logger)
    {
        if (string.IsNullOrWhiteSpace(resolvedPath) || !File.Exists(resolvedPath))
            return resolvedPath;
        var videoDirectory = Path.Combine(_artifactDirectory, "video");
        Directory.CreateDirectory(videoDirectory);
        var full = Path.GetFullPath(resolvedPath);
        var persistent = Path.GetFullPath(Path.Combine(videoDirectory, Path.GetFileName(full)));
        if (full.Equals(persistent, StringComparison.OrdinalIgnoreCase)) return full;
        try
        {
            File.Copy(full, persistent, true);
            using (File.Open(persistent, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
            return persistent;
        }
        catch (Exception ex)
        {
            logger.Warn($"Unable to copy finalized Playwright video into scenario artifact directory: {ex.Message}");
            return full;
        }
    }

    public string? CreateEvidenceBundle(RunLogger logger)
    {
        if (!_config.Reporting.CreateEvidenceBundle || string.IsNullOrWhiteSpace(_artifactDirectory) || !Directory.Exists(_artifactDirectory)) return null;
        var path = Path.Combine(_artifactDirectory, "evidence-bundle.zip");
        try
        {
            if (File.Exists(path)) File.Delete(path);
            using var archive = ZipFile.Open(path, ZipArchiveMode.Create);
            foreach (var file in Directory.EnumerateFiles(_artifactDirectory, "*", SearchOption.AllDirectories))
            {
                if (Path.GetFullPath(file).Equals(Path.GetFullPath(path), StringComparison.OrdinalIgnoreCase)) continue;
                archive.CreateEntryFromFile(file, Path.GetRelativePath(_artifactDirectory, file), CompressionLevel.Optimal);
            }
            EvidenceBundlePath = path;
            return path;
        }
        catch (Exception ex)
        {
            logger.Warn($"Unable to create evidence bundle: {ex.Message}");
            return null;
        }
    }

    private void WireEvidence(RunLogger logger, IPage page)
    {
        // When collection is re-enabled, initialize the real log files at wiring time.
        File.WriteAllText(_consoleLogPath, string.Empty);
        File.WriteAllText(_networkLogPath, string.Empty);
        page.Console += (_, message) =>
        {
            var line = $"{DateTimeOffset.Now:O} BROWSER {message.Type}: {message.Text}";
            AppendEvidenceLine(_consoleLogPath, line);
            logger.Info(line);
            if (_config.Reporting.CollectConsole && (message.Type.Equals("error", StringComparison.OrdinalIgnoreCase) || message.Type.Equals("warning", StringComparison.OrdinalIgnoreCase)))
            {
                lock (_evidenceGate) _stepConsoleErrors.Add(line);
            }
        };
        page.PageError += (_, error) =>
        {
            var line = $"{DateTimeOffset.Now:O} PAGE ERROR: {error}";
            AppendEvidenceLine(_consoleLogPath, line);
            logger.Error(line);
            if (_config.Reporting.CollectConsole) lock (_evidenceGate) _stepConsoleErrors.Add(line);
        };
        page.Request += (_, request) =>
        {
            AppendEvidenceLine(_networkLogPath, $"{DateTimeOffset.Now:O} REQUEST {request.Method} {request.Url}");
        };
        page.RequestFailed += (_, request) =>
        {
            var line = $"{DateTimeOffset.Now:O} REQUEST FAILED: {request.Method} {request.Url} :: {request.Failure}";
            AppendEvidenceLine(_networkLogPath, line);
            logger.Error(line);
            if (_config.Reporting.CollectNetwork) lock (_evidenceGate) _stepNetworkErrors.Add(line);
        };
        page.Response += (_, response) =>
        {
            var line = $"{DateTimeOffset.Now:O} RESPONSE {response.Status}: {response.Request.Method} {response.Url}";
            AppendEvidenceLine(_networkLogPath, line);
            if (response.Status < 400) return;
            logger.Warn(line);
            if (_config.Reporting.CollectNetwork) lock (_evidenceGate) _stepNetworkErrors.Add(line);
        };
    }

    private void AppendEvidenceLine(string path, string line)
    {
        if (string.IsNullOrWhiteSpace(path)) return;
        lock (_evidenceGate)
        {
            try { File.AppendAllText(path, line + Environment.NewLine); } catch { }
        }
    }

    private async Task<IBrowser> LaunchAsync(RunLogger logger)
    {
        var options = new BrowserTypeLaunchOptions { Headless = _config.Browser.Headless, Args = _config.Browser.Maximize && !_config.Browser.Headless ? new[] { "--start-maximized" } : null };
        if (!string.IsNullOrWhiteSpace(_config.Browser.Channel)) options.Channel = _config.Browser.Channel;
        try { return await _playwright!.Chromium.LaunchAsync(options); }
        catch (PlaywrightException ex) when (!string.IsNullOrWhiteSpace(_config.Browser.FallbackBrowser))
        {
            logger.Warn($"Configured browser channel '{_config.Browser.Channel}' could not launch: {ex.Message}. Falling back to '{_config.Browser.FallbackBrowser}'.");
            return _config.Browser.FallbackBrowser.ToLowerInvariant() switch
            {
                "firefox" => await _playwright!.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Browser.Headless }),
                "webkit" => await _playwright!.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Browser.Headless }),
                _ => await _playwright!.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _config.Browser.Headless })
            };
        }
    }

    public async ValueTask DisposeAsync()
    {
        try { if (_context is not null) await _context.CloseAsync(); } catch { }
        try { if (_browser is not null) await _browser.CloseAsync(); } catch { }
        _playwright?.Dispose();
    }

    private static string Safe(string value) => string.Concat(value.Select(c => char.IsLetterOrDigit(c) || c is '.' or '_' or '-' ? c : '_'));
}

public sealed record StepEvidence(IReadOnlyList<string> ConsoleErrors, IReadOnlyList<string> NetworkErrors);
