using Microsoft.Playwright;
using ToscaModernized.Core.Configuration;

namespace ToscaModernized.Core.Runtime;

public sealed class BrowserSession : IAsyncDisposable
{
    private readonly IPlaywright _playwright;
    private readonly IBrowser _browser;
    private readonly IBrowserContext _context;
    public IPage Page { get; }

    private BrowserSession(IPlaywright playwright, IBrowser browser, IBrowserContext context, IPage page)
    {
        _playwright = playwright;
        _browser = browser;
        _context = context;
        Page = page;
    }

    public static async Task<BrowserSession> CreateAsync(FrameworkSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);
        var playwright = await Playwright.CreateAsync().ConfigureAwait(false);
        var browserType = settings.Browser.Name.ToLowerInvariant() switch
        {
            "firefox" => playwright.Firefox,
            "webkit" => playwright.Webkit,
            _ => playwright.Chromium
        };
        var browser = await browserType.LaunchAsync(new()
        {
            Headless = settings.Browser.Headless,
            Channel = string.IsNullOrWhiteSpace(settings.Browser.Channel) ? null : settings.Browser.Channel,
            SlowMo = settings.Browser.SlowMoMs
        }).ConfigureAwait(false);
        var viewport = ParseViewport(settings.Browser.Viewport);
        var context = await browser.NewContextAsync(new()
        {
            IgnoreHTTPSErrors = settings.Browser.IgnoreHttpsErrors,
            ViewportSize = viewport
        }).ConfigureAwait(false);
        var page = await context.NewPageAsync().ConfigureAwait(false);
        page.SetDefaultTimeout(settings.Browser.TimeoutMs);
        page.SetDefaultNavigationTimeout(settings.Browser.NavigationTimeoutMs);
        return new BrowserSession(playwright, browser, context, page);
    }

    private static ViewportSize ParseViewport(string value)
    {
        var parts = value.Split('x', 'X');
        return parts.Length == 2 && int.TryParse(parts[0], out var width) && int.TryParse(parts[1], out var height)
            ? new ViewportSize { Width = width, Height = height }
            : new ViewportSize { Width = 1600, Height = 1000 };
    }

    public async ValueTask DisposeAsync()
    {
        await _context.CloseAsync().ConfigureAwait(false);
        await _browser.CloseAsync().ConfigureAwait(false);
        _playwright.Dispose();
    }
}
