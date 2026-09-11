using System.Collections.Concurrent;
using System.Text.Json;
using InsuranceAutomation.Core;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Runtime;

public sealed class DuckCreekFrameScopeResolver
{
    private readonly IPage _page;
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;
    private readonly Dictionary<string, FrameHint[]> _hints;
    private readonly ConcurrentDictionary<string, ScopeChoice> _cache = new(StringComparer.OrdinalIgnoreCase);

    public DuckCreekFrameScopeResolver(IPage page, FrameworkConfig config, RunLogger logger)
    {
        _page = page; _config = config; _logger = logger;
        _hints = LoadHints();
    }

    public async Task<ResolvedScope> ResolveAsync(ILocator documentLocator, ControlIntent intent)
    {
        var key = $"{intent.Page}|{intent.Control}";
        if (_cache.TryGetValue(key, out var cached))
        {
            var hit = await BuildCachedAsync(documentLocator, cached);
            if (hit is not null) return hit;
            _cache.TryRemove(key, out _);
        }

        if (_hints.TryGetValue(key, out var hints))
        {
            var selector = TryExtractSelector(documentLocator);
            if (!string.IsNullOrWhiteSpace(selector))
            {
                foreach (var hint in hints)
                {
                    var frameHost = _page.Locator(FrameSelector(hint));
                    if (!await IsPresentAsync(frameHost, _config.Waits.FrameProbeTimeoutMs)) continue;
                    var frame = _page.FrameLocator(FrameSelector(hint));
                    var candidate = frame.Locator(selector);
                    if (!await IsPresentAsync(candidate, _config.Waits.FrameProbeTimeoutMs)) continue;
                    _cache[key] = new ScopeChoice(true, hint, selector);
                    _logger.Info($"FRAME SCOPE: {key} resolved in hinted frame {hint.Strategy}:{hint.Value}");
                    return new ResolvedScope(candidate, frame);
                }
            }
        }

        await BestEffortPresentAsync(documentLocator, _config.Waits.ElementReadyTimeoutMs);
        _cache[key] = new ScopeChoice(false, null, string.Empty);
        return new ResolvedScope(documentLocator, null);
    }

    private async Task<ResolvedScope?> BuildCachedAsync(ILocator documentLocator, ScopeChoice choice)
    {
        if (!choice.InFrame) return await IsPresentAsync(documentLocator, 150) ? new ResolvedScope(documentLocator, null) : null;
        if (choice.Hint is null || string.IsNullOrWhiteSpace(choice.Selector)) return null;
        var hostSelector = FrameSelector(choice.Hint);
        if (!await IsPresentAsync(_page.Locator(hostSelector), 150)) return null;
        var frame = _page.FrameLocator(hostSelector);
        var candidate = frame.Locator(choice.Selector);
        return await IsPresentAsync(candidate, 150) ? new ResolvedScope(candidate, frame) : null;
    }

    private async Task BestEffortPresentAsync(ILocator locator, int timeout)
    {
        try { await locator.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = timeout }); }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { _logger.Warn($"ELEMENT ATTACH WAIT CONTINUING: {ex.Message}"); }
    }

    private static async Task<bool> IsPresentAsync(ILocator locator, int timeout)
    {
        try { await locator.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = timeout }); return await locator.CountAsync() > 0; }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { return false; }
    }

    private static string? TryExtractSelector(ILocator locator)
    {
        var text = locator.ToString();
        var at = text.IndexOf("Locator@", StringComparison.Ordinal);
        if (at >= 0) return text[(at + 8)..].Trim();
        var marker = "Locator(\"";
        var i = text.IndexOf(marker, StringComparison.Ordinal);
        if (i >= 0)
        {
            var begin = i + marker.Length;
            var end = text.LastIndexOf("\")", StringComparison.Ordinal);
            if (end > begin) return text[begin..end];
        }
        return null;
    }

    private static string FrameSelector(FrameHint h) => h.Strategy.ToLowerInvariant() switch
    {
        "id" => $"iframe[id=\"{Css(h.Value)}\"]",
        "name" => $"iframe[name=\"{Css(h.Value)}\"]",
        "css" => h.Value,
        _ => h.Value
    };

    private Dictionary<string, FrameHint[]> LoadHints()
    {
        try
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Runtime", "DuckCreekFrameHints.json");
            if (!File.Exists(path)) path = Path.Combine(AppContext.BaseDirectory, "DuckCreekFrameHints.json");
            return File.Exists(path)
                ? JsonSerializer.Deserialize<Dictionary<string, FrameHint[]>>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new()
                : new();
        }
        catch { return new(); }
    }
    private static string Css(string v) => v.Replace("\\", "\\\\").Replace("\"", "\\\"");
    private sealed record ScopeChoice(bool InFrame, FrameHint? Hint, string Selector);
    private sealed record FrameHint(string Strategy, string Value);
}

public sealed record ResolvedScope(ILocator Locator, IFrameLocator? Frame);
