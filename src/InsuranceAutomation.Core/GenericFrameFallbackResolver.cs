using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// Generic, project-agnostic iframe fallback used by <see cref="UiActions"/> whenever a locator is not
/// attached to the top-level document within the configured presence timeout. Unlike a hint-file-driven
/// resolver, this requires no pre-seeded knowledge of which control lives in which frame: it extracts the
/// raw selector text from the seed locator and re-probes it against every iframe currently on the page,
/// returning the first frame-scoped locator that resolves to at least one attached element.
/// </summary>
public sealed class GenericFrameFallbackResolver
{
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;

    public GenericFrameFallbackResolver(FrameworkConfig config, RunLogger logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task<ILocator?> ResolveAsync(IPage page, ILocator seed, ControlIntent intent, string action)
    {
        var selector = TryExtractSelector(seed);
        if (string.IsNullOrWhiteSpace(selector)) return null;

        var frameHosts = page.Locator("iframe, frame");
        int frameCount;
        try { frameCount = await frameHosts.CountAsync(); }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { return null; }

        for (var i = 0; i < frameCount; i++)
        {
            IFrameLocator frameLocator;
            try { frameLocator = page.FrameLocator($":nth-match(iframe, {i + 1}), :nth-match(frame, {i + 1})"); }
            catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { continue; }

            var candidate = frameLocator.Locator(selector);
            if (await IsPresentAsync(candidate, _config.Waits.GenericFramePresenceTimeoutMs))
            {
                _logger.Info($"GENERIC FRAME FALLBACK: {intent} resolved in iframe #{i + 1} for action '{action}'.");
                return candidate;
            }
        }

        return null;
    }

    private static async Task<bool> IsPresentAsync(ILocator locator, int timeoutMs)
    {
        try
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached, Timeout = timeoutMs });
            return await locator.CountAsync() > 0;
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
    }

    private static string? TryExtractSelector(ILocator locator)
    {
        var text = locator.ToString();
        if (string.IsNullOrEmpty(text)) return null;

        var at = text.IndexOf("Locator@", StringComparison.Ordinal);
        if (at >= 0) return text[(at + 8)..].Trim();

        const string marker = "Locator(\"";
        var i = text.IndexOf(marker, StringComparison.Ordinal);
        if (i >= 0)
        {
            var begin = i + marker.Length;
            var end = text.LastIndexOf("\")", StringComparison.Ordinal);
            if (end > begin) return text[begin..end];
        }

        return null;
    }
}
