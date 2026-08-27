using System.Collections.Concurrent;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// v57 deterministic fallback resolver. Raw Tosca HtmlFrame is treated as a scope hint, never as an unconditional
/// FrameLocator. The resolver briefly probes the hinted frame, falls back to the normal document when absent, and
/// caches the scope that actually completed the Page.Control action.
/// </summary>
public sealed class DeterministicLocatorFallbackResolver
{
    private static readonly ConcurrentDictionary<string, LocatorFallbackCandidate> SuccessfulCandidateCache = new(StringComparer.OrdinalIgnoreCase);
    private static readonly ConcurrentDictionary<string, SuccessfulScope> SuccessfulScopeCache = new(StringComparer.OrdinalIgnoreCase);
    private readonly BrowserSession _browser;
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;
    private readonly ScenarioReport? _report;
    private readonly string _applicationName;
    private readonly ILocatorFallbackProvider _catalog;

    public DeterministicLocatorFallbackResolver(
        BrowserSession browser,
        FrameworkConfig config,
        RunLogger logger,
        ScenarioReport? report,
        string applicationName,
        ILocatorFallbackProvider? provider = null)
    {
        _browser = browser;
        _config = config;
        _logger = logger;
        _report = report;
        _applicationName = applicationName;
        _catalog = provider ?? new LocatorFallbackCatalogStore(config, applicationName);
    }

    public bool HasFrameCandidates(ControlIntent intent) =>
        _catalog.Find(intent)?.Candidates.Any(c => c.Confidence >= _config.LocatorFallback.MinimumCandidateConfidence && !string.IsNullOrWhiteSpace(c.FrameValue)) == true;

    /// <summary>Returns only a frame scope previously proven by a successful runtime action.</summary>
    public IFrameLocator? PreferredFrame(ControlIntent intent)
    {
        if (!SuccessfulScopeCache.TryGetValue(ScopeKey(intent), out var scope) || scope.Kind != ScopeKind.Frame || string.IsNullOrWhiteSpace(scope.FrameValue))
            return null;
        return LocatorResolution.BuildFrame(_browser.Page, scope.FrameStrategy, scope.FrameValue);
    }

    public void RecordDocumentSuccess(ControlIntent intent) =>
        SuccessfulScopeCache[ScopeKey(intent)] = new SuccessfulScope(ScopeKind.Document, string.Empty, string.Empty);

    /// <summary>
    /// Fast path used before a top-document primary locator. If raw Tosca says HtmlFrame, probe the frame briefly and
    /// execute a source-backed locator there. If no matching frame/control exists, return immediately so normal document
    /// resolution proceeds without burning a full action timeout.
    /// </summary>
    public async Task<bool> TryExecuteFrameHintFirstAsync(ControlIntent intent, string action, Func<ILocator, Task> operation)
    {
        if (!_config.LocatorFallback.Enabled || !HasFrameCandidates(intent)) return false;
        if (SuccessfulScopeCache.TryGetValue(ScopeKey(intent), out var cached) && cached.Kind == ScopeKind.Document) return false;
        var entry = _catalog.Find(intent);
        if (entry is null) return false;

        var candidates = OrderedCandidates(entry, intent, action)
            .Where(c => !string.IsNullOrWhiteSpace(c.FrameValue))
            .Take(Math.Min(8, _config.LocatorFallback.MaxCandidatesPerFailure))
            .ToArray();
        var attempt = 0;
        var frameProbe = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        foreach (var candidate in candidates)
        {
            attempt++;
            if (!await FrameExistsOncePerActionAsync(candidate, frameProbe)) continue;
            var spec = candidate.ToLocatorSpec();
            var locator = LocatorResolution.BuildInFrame(_browser.Page, spec);
            var probe = await ProbeAsync(locator, candidate, action, _config.Waits.FrameProbeTimeoutMs);
            if (!probe.Usable) continue;
            try
            {
                var frame = LocatorResolution.FrameFor(_browser.Page, spec);
                using var scope = FrameExecutionContext.Push(frame);
                await operation(locator);
                CacheSuccess(intent, action, candidate, ScopeKind.Frame);
                Trace(intent, action, attempt, candidate, "frame-hint-success", probe.MatchCount, true,
                    "Raw Tosca frame hint was present and the source-backed control action succeeded inside it.", "");
                return true;
            }
            catch (Exception ex) when (IsRecoverable(ex))
            {
                Trace(intent, action, attempt, candidate, "frame-hint-action-failed", probe.MatchCount, false, Compact(ex.Message), "");
            }
        }
        return false;
    }

    public async Task<LocatorFallbackValueResult<T>> TryExecuteFrameHintFirstAsync<T>(ControlIntent intent, string action, Func<ILocator, Task<T>> operation)
    {
        if (!_config.LocatorFallback.Enabled || !HasFrameCandidates(intent)) return LocatorFallbackValueResult<T>.Failed;
        if (SuccessfulScopeCache.TryGetValue(ScopeKey(intent), out var cached) && cached.Kind == ScopeKind.Document) return LocatorFallbackValueResult<T>.Failed;
        var entry = _catalog.Find(intent);
        if (entry is null) return LocatorFallbackValueResult<T>.Failed;
        var candidates = OrderedCandidates(entry, intent, action)
            .Where(c => !string.IsNullOrWhiteSpace(c.FrameValue))
            .Take(Math.Min(8, _config.LocatorFallback.MaxCandidatesPerFailure))
            .ToArray();
        var frameProbe = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        foreach (var candidate in candidates)
        {
            if (!await FrameExistsOncePerActionAsync(candidate, frameProbe)) continue;
            var spec = candidate.ToLocatorSpec();
            var locator = LocatorResolution.BuildInFrame(_browser.Page, spec);
            var probe = await ProbeAsync(locator, candidate, action, _config.Waits.FrameProbeTimeoutMs);
            if (!probe.Usable) continue;
            try
            {
                using var scope = FrameExecutionContext.Push(LocatorResolution.FrameFor(_browser.Page, spec));
                var value = await operation(locator);
                CacheSuccess(intent, action, candidate, ScopeKind.Frame);
                return new LocatorFallbackValueResult<T>(true, value);
            }
            catch (Exception ex) when (IsRecoverable(ex)) { }
        }
        return LocatorFallbackValueResult<T>.Failed;
    }

    public async Task<bool> TryExecuteAsync(ControlIntent intent, string action, Func<ILocator, Task> operation, Exception primaryFailure)
    {
        if (!_config.LocatorFallback.Enabled) return false;
        var entry = _catalog.Find(intent);
        if (entry is null || entry.Candidates.Count == 0)
        {
            Trace(intent, action, 0, null, "catalog-miss", 0, false, "No Tosca-derived fallback candidates are cataloged for this Page.Control.", primaryFailure.Message);
            return false;
        }

        var candidates = OrderedCandidates(entry, intent, action).Take(_config.LocatorFallback.MaxCandidatesPerFailure).ToArray();
        _logger.Warn($"LOCATOR FALLBACK START Application={_applicationName}; Control={intent}; Action={action}; Candidates={candidates.Length}; PrimaryFailure={Compact(primaryFailure.Message)}");
        var attempt = 0;
        var frameProbe = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        foreach (var candidate in candidates)
        {
            foreach (var kind in ScopeOrder(intent, candidate))
            {
                attempt++;
                if (kind == ScopeKind.Frame && !await FrameExistsOncePerActionAsync(candidate, frameProbe)) continue;
                var spec = candidate.ToLocatorSpec();
                var locator = kind == ScopeKind.Frame ? LocatorResolution.BuildInFrame(_browser.Page, spec) : LocatorResolution.Build(_browser.Page, spec);
                var probe = await ProbeAsync(locator, candidate, action, _config.Waits.FallbackCandidateTimeoutMs);
                if (!probe.Usable)
                {
                    Trace(intent, action, attempt, candidate, probe.Outcome, probe.MatchCount, false, $"scope={kind}; {probe.Reason}", primaryFailure.Message);
                    continue;
                }
                try
                {
                    using var frameScope = FrameExecutionContext.Push(kind == ScopeKind.Frame ? LocatorResolution.FrameFor(_browser.Page, spec) : null);
                    await operation(locator);
                    CacheSuccess(intent, action, candidate, kind);
                    Trace(intent, action, attempt, candidate, "success", probe.MatchCount, true,
                        $"Fallback executed '{action}' successfully in {kind} scope.", primaryFailure.Message);
                    _logger.Warn($"LOCATOR FALLBACK SUCCESS Application={_applicationName}; Control={intent}; Action={action}; Scope={kind}; Strategy={candidate.Strategy}; Value={candidate.Value}; Source={candidate.SourceModule} :: {candidate.SourceField} :: {candidate.SourceProperty}; Confidence={candidate.Confidence:F3}");
                    return true;
                }
                catch (Exception ex) when (IsRecoverable(ex))
                {
                    Trace(intent, action, attempt, candidate, "action-failed", probe.MatchCount, false,
                        $"scope={kind}; {Compact(ex.Message)}", primaryFailure.Message);
                }
            }
        }
        _logger.Warn($"LOCATOR FALLBACK EXHAUSTED Application={_applicationName}; Control={intent}; Action={action}; Tried={attempt}.");
        return false;
    }

    public async Task<LocatorFallbackValueResult<T>> TryExecuteAsync<T>(ControlIntent intent, string action, Func<ILocator, Task<T>> operation, Exception primaryFailure)
    {
        if (!_config.LocatorFallback.Enabled) return LocatorFallbackValueResult<T>.Failed;
        var entry = _catalog.Find(intent);
        if (entry is null || entry.Candidates.Count == 0) return LocatorFallbackValueResult<T>.Failed;
        var candidates = OrderedCandidates(entry, intent, action).Take(_config.LocatorFallback.MaxCandidatesPerFailure).ToArray();
        var frameProbe = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
        foreach (var candidate in candidates)
        {
            foreach (var kind in ScopeOrder(intent, candidate))
            {
                if (kind == ScopeKind.Frame && !await FrameExistsOncePerActionAsync(candidate, frameProbe)) continue;
                var spec = candidate.ToLocatorSpec();
                var locator = kind == ScopeKind.Frame ? LocatorResolution.BuildInFrame(_browser.Page, spec) : LocatorResolution.Build(_browser.Page, spec);
                var probe = await ProbeAsync(locator, candidate, action, _config.Waits.FallbackCandidateTimeoutMs);
                if (!probe.Usable) continue;
                try
                {
                    using var frameScope = FrameExecutionContext.Push(kind == ScopeKind.Frame ? LocatorResolution.FrameFor(_browser.Page, spec) : null);
                    var value = await operation(locator);
                    CacheSuccess(intent, action, candidate, kind);
                    return new LocatorFallbackValueResult<T>(true, value);
                }
                catch (Exception ex) when (IsRecoverable(ex)) { }
            }
        }
        return LocatorFallbackValueResult<T>.Failed;
    }

    private IEnumerable<LocatorFallbackCandidate> OrderedCandidates(LocatorFallbackControlEntry entry, ControlIntent intent, string action)
    {
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (_config.LocatorFallback.PreferPreviouslySuccessfulCandidate &&
            SuccessfulCandidateCache.TryGetValue(CacheKey(intent, action), out var prior) && seen.Add(prior.Signature))
            yield return prior;

        foreach (var candidate in entry.Candidates
                     .Where(x => x.Confidence >= _config.LocatorFallback.MinimumCandidateConfidence)
                     .Where(x => _config.LocatorFallback.AllowSourceXPath || !x.Strategy.Equals("xpath", StringComparison.OrdinalIgnoreCase))
                     .OrderByDescending(StrategyPriority)
                     .ThenByDescending(x => x.MatchScore)
                     .ThenByDescending(x => x.Confidence))
            if (seen.Add(candidate.Signature)) yield return candidate;
    }

    // Duck Creek hierarchy: fieldref -> id -> name -> test-id -> associated label -> semantic role -> relationship -> source occurrence/index.
    private static int StrategyPriority(LocatorFallbackCandidate c)
    {
        var s = c.Strategy.ToLowerInvariant();
        if (s == "fieldref") return 1000;
        if (s == "id") return 900;
        if (s == "name") return 800;
        if (s is "testid" or "automationid") return 700;
        if (s is "associatedlabel" or "label") return 600;
        if (s == "role") return 500;
        if (!string.IsNullOrWhiteSpace(c.AnchorStrategy)) return 400;
        if (s == "css" && c.Pick.Equals("unique", StringComparison.OrdinalIgnoreCase)) return 350;
        if (c.Pick is "first" or "nth" or "last") return 250;
        if (s == "xpath") return 200;
        if (s == "text") return 150;
        if (s == "duckcreekid") return 50; // legacy support only; v57 CL|DC generation does not emit raw-only DuckCreekId.
        return 100;
    }

    private IEnumerable<ScopeKind> ScopeOrder(ControlIntent intent, LocatorFallbackCandidate candidate)
    {
        if (string.IsNullOrWhiteSpace(candidate.FrameValue)) { yield return ScopeKind.Document; yield break; }
        if (SuccessfulScopeCache.TryGetValue(ScopeKey(intent), out var cached))
        {
            if (cached.Kind == ScopeKind.Document) { yield return ScopeKind.Document; yield return ScopeKind.Frame; yield break; }
            yield return ScopeKind.Frame; yield return ScopeKind.Document; yield break;
        }
        // No cache yet: raw HtmlFrame is a hint, so try the frame briefly first, then normal document.
        yield return ScopeKind.Frame;
        yield return ScopeKind.Document;
    }


    private async Task<bool> FrameExistsOncePerActionAsync(LocatorFallbackCandidate candidate, IDictionary<string, bool> probeCache)
    {
        var key = $"{candidate.FrameStrategy}|{candidate.FrameValue}";
        if (probeCache.TryGetValue(key, out var exists)) return exists;
        exists = await FrameExistsAsync(candidate);
        probeCache[key] = exists;
        return exists;
    }

    private async Task<bool> FrameExistsAsync(LocatorFallbackCandidate candidate)
    {
        if (string.IsNullOrWhiteSpace(candidate.FrameValue)) return false;
        try
        {
            var selector = LocatorResolution.FrameSelector(candidate.FrameStrategy, candidate.FrameValue);
            var host = _browser.Page.Locator(selector).First;
            await host.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached, Timeout = _config.Waits.FrameProbeTimeoutMs });
            return await host.CountAsync() > 0;
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { return false; }
    }

    private async Task<CandidateProbe> ProbeAsync(ILocator locator, LocatorFallbackCandidate candidate, string action, int timeoutMs)
    {
        try
        {
            try { await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeoutMs }); }
            catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { }
            var count = await locator.CountAsync();
            if (count == 0) return new(false, 0, "no-match", "Locator matched zero controls.");
            if (count != 1) return new(false, count, "non-unique", $"Locator matched {count} controls; no arbitrary selection allowed.");
            if (!await locator.IsVisibleAsync()) return new(false, 1, "not-visible", "Unique match is not visible.");
            if (action is "click" or "fill" or "set" or "select" or "press" or "activate-tab" or "dialog-action" or "grid-cell" or "expansion-panel")
                if (!await locator.IsEnabledAsync()) return new(false, 1, "not-enabled", "Unique match is disabled.");
            if (action == "fill" && !await locator.IsEditableAsync()) return new(false, 1, "not-editable", "Unique match is not editable.");
            var actualTag = "";
            try { actualTag = (await locator.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")) ?? ""; } catch { }
            return new(true, 1, "usable", $"Unique visible/action-compatible match (runtime tag={actualTag}, source tag={candidate.ExpectedTag}).");
        }
        catch (Exception ex) { return new(false, 0, "probe-error", Compact(ex.Message)); }
    }

    private void CacheSuccess(ControlIntent intent, string action, LocatorFallbackCandidate candidate, ScopeKind kind)
    {
        if (_config.LocatorFallback.PreferPreviouslySuccessfulCandidate) SuccessfulCandidateCache[CacheKey(intent, action)] = candidate;
        SuccessfulScopeCache[ScopeKey(intent)] = kind == ScopeKind.Frame
            ? new SuccessfulScope(kind, candidate.FrameStrategy, candidate.FrameValue)
            : new SuccessfulScope(kind, string.Empty, string.Empty);
    }

    private void Trace(ControlIntent intent, string action, int attempt, LocatorFallbackCandidate? candidate, string outcome, int matchCount, bool success, string reason, string primaryFailure)
    {
        var trace = new LocatorFallbackTrace(DateTimeOffset.Now, _applicationName, ExecutionIntent.Current.Step, intent.Page, intent.Control, action, attempt,
            candidate?.Strategy ?? "", candidate?.Value ?? "", candidate?.Role ?? "", candidate?.HasText ?? "", candidate?.Pick ?? "", candidate?.Index ?? 0,
            matchCount, success, outcome, candidate?.Confidence ?? 0, candidate?.SourceFile ?? "", candidate?.SourceModule ?? "", candidate?.SourceField ?? "",
            candidate?.SourceProperty ?? "", candidate?.FrameStrategy ?? "", candidate?.FrameValue ?? "", reason, primaryFailure);
        _report?.RecordLocatorFallback(trace);
        if (!_config.LocatorFallback.LogEveryAttempt && !success && outcome != "catalog-miss") return;
        _logger.Info($"LOCATOR FALLBACK {(success ? "MATCH" : "TRY")} #{attempt} Control={intent}; Action={action}; Outcome={outcome}; Matches={matchCount}; Candidate={(candidate is null ? "<none>" : candidate.Strategy + ":" + candidate.Value)}; Reason={Compact(reason)}");
    }

    private string CacheKey(ControlIntent intent, string action) => $"{_applicationName}|{intent.Page}|{intent.Control}|{action}";
    private string ScopeKey(ControlIntent intent) => $"{_applicationName}|{intent.Page}|{intent.Control}";
    private static bool IsRecoverable(Exception ex) => ex is PlaywrightException or TimeoutException;
    private static string Compact(string value) => string.Join(" ", (value ?? "").Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)).Trim();
    private enum ScopeKind { Document, Frame }
    private sealed record SuccessfulScope(ScopeKind Kind, string FrameStrategy, string FrameValue);
    private sealed record CandidateProbe(bool Usable, int MatchCount, string Outcome, string Reason);
}

public sealed record LocatorFallbackValueResult<T>(bool Success, T? Value)
{
    public static LocatorFallbackValueResult<T> Failed { get; } = new(false, default);
}
