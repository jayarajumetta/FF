using System.Collections.Concurrent;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// Executes deterministic, Tosca-derived fallback locators after the readable Page Object primary locator fails.
/// Candidates are tried in ranked order and are never accepted merely because they match something: the candidate
/// must resolve to one visible/action-compatible element (or use a source-specified index), and the same failed action
/// must complete successfully before the test continues.
/// </summary>
public sealed class DeterministicLocatorFallbackResolver
{
    private static readonly ConcurrentDictionary<string, LocatorFallbackCandidate> SuccessfulCandidateCache = new(StringComparer.OrdinalIgnoreCase);
    private readonly BrowserSession _browser;
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;
    private readonly ScenarioReport? _report;
    private readonly string _applicationName;
    private readonly LocatorFallbackCatalogStore _catalog;

    public DeterministicLocatorFallbackResolver(
        BrowserSession browser,
        FrameworkConfig config,
        RunLogger logger,
        ScenarioReport? report,
        string applicationName)
    {
        _browser = browser;
        _config = config;
        _logger = logger;
        _report = report;
        _applicationName = applicationName;
        _catalog = new LocatorFallbackCatalogStore(config, applicationName);
    }

    public async Task<bool> TryExecuteAsync(
        ControlIntent intent,
        string action,
        Func<ILocator, Task> operation,
        Exception primaryFailure)
    {
        if (!_config.LocatorFallback.Enabled) return false;
        var entry = _catalog.Find(intent);
        if (entry is null || entry.Candidates.Count == 0)
        {
            Trace(intent, action, 0, null, "catalog-miss", 0, false,
                "No Tosca-derived fallback candidates are cataloged for this Page.Control.", primaryFailure.Message);
            return false;
        }

        var candidates = OrderedCandidates(entry, intent, action).Take(_config.LocatorFallback.MaxCandidatesPerFailure).ToArray();
        _logger.Warn($"LOCATOR FALLBACK START Application={_applicationName}; Control={intent}; Action={action}; Candidates={candidates.Length}; PrimaryFailure={Compact(primaryFailure.Message)}");

        var attempt = 0;
        foreach (var candidate in candidates)
        {
            attempt++;
            var locator = LocatorResolution.Build(_browser.Page, candidate.ToLocatorSpec());
            var probe = await ProbeAsync(locator, candidate, action);
            if (!probe.Usable)
            {
                Trace(intent, action, attempt, candidate, probe.Outcome, probe.MatchCount, false, probe.Reason, primaryFailure.Message);
                continue;
            }

            try
            {
                await operation(locator);
                var key = CacheKey(intent, action);
                if (_config.LocatorFallback.PreferPreviouslySuccessfulCandidate)
                    SuccessfulCandidateCache[key] = candidate;

                var successReason = $"Fallback executed the failed '{action}' action successfully after {attempt} candidate attempt(s).";
                Trace(intent, action, attempt, candidate, "success", probe.MatchCount, true, successReason, primaryFailure.Message);
                _logger.Warn(
                    $"LOCATOR FALLBACK SUCCESS Application={_applicationName}; Control={intent}; Action={action}; " +
                    $"Attempt={attempt}/{candidates.Length}; Strategy={candidate.Strategy}; Value={candidate.Value}; " +
                    $"HasText={candidate.HasText}; Source={candidate.SourceModule} :: {candidate.SourceField} :: {candidate.SourceProperty}; " +
                    $"Confidence={candidate.Confidence:F3}. Test continues with the same business step/action.");
                return true;
            }
            catch (Exception ex) when (IsRecoverable(ex))
            {
                Trace(intent, action, attempt, candidate, "action-failed", probe.MatchCount, false,
                    $"Candidate matched and was actionable, but the requested operation still failed: {Compact(ex.Message)}", primaryFailure.Message);
            }
        }

        _logger.Warn($"LOCATOR FALLBACK EXHAUSTED Application={_applicationName}; Control={intent}; Action={action}; Tried={attempt}; no deterministic candidate completed the action. LLM healing may run next if enabled.");
        return false;
    }

    public async Task<LocatorFallbackValueResult<T>> TryExecuteAsync<T>(
        ControlIntent intent,
        string action,
        Func<ILocator, Task<T>> operation,
        Exception primaryFailure)
    {
        if (!_config.LocatorFallback.Enabled) return LocatorFallbackValueResult<T>.Failed;
        var entry = _catalog.Find(intent);
        if (entry is null || entry.Candidates.Count == 0)
        {
            Trace(intent, action, 0, null, "catalog-miss", 0, false,
                "No Tosca-derived fallback candidates are cataloged for this Page.Control.", primaryFailure.Message);
            return LocatorFallbackValueResult<T>.Failed;
        }

        var candidates = OrderedCandidates(entry, intent, action).Take(_config.LocatorFallback.MaxCandidatesPerFailure).ToArray();
        _logger.Warn($"LOCATOR FALLBACK START Application={_applicationName}; Control={intent}; Action={action}; Candidates={candidates.Length}; PrimaryFailure={Compact(primaryFailure.Message)}");

        var attempt = 0;
        foreach (var candidate in candidates)
        {
            attempt++;
            var locator = LocatorResolution.Build(_browser.Page, candidate.ToLocatorSpec());
            var probe = await ProbeAsync(locator, candidate, action);
            if (!probe.Usable)
            {
                Trace(intent, action, attempt, candidate, probe.Outcome, probe.MatchCount, false, probe.Reason, primaryFailure.Message);
                continue;
            }

            try
            {
                var value = await operation(locator);
                if (_config.LocatorFallback.PreferPreviouslySuccessfulCandidate)
                    SuccessfulCandidateCache[CacheKey(intent, action)] = candidate;
                Trace(intent, action, attempt, candidate, "success", probe.MatchCount, true,
                    $"Fallback executed the failed '{action}' action successfully after {attempt} candidate attempt(s).", primaryFailure.Message);
                _logger.Warn(
                    $"LOCATOR FALLBACK SUCCESS Application={_applicationName}; Control={intent}; Action={action}; " +
                    $"Attempt={attempt}/{candidates.Length}; Strategy={candidate.Strategy}; Value={candidate.Value}; " +
                    $"Source={candidate.SourceModule} :: {candidate.SourceField} :: {candidate.SourceProperty}; Confidence={candidate.Confidence:F3}.");
                return new LocatorFallbackValueResult<T>(true, value);
            }
            catch (Exception ex) when (IsRecoverable(ex))
            {
                Trace(intent, action, attempt, candidate, "action-failed", probe.MatchCount, false,
                    $"Candidate matched and was actionable, but the requested operation still failed: {Compact(ex.Message)}", primaryFailure.Message);
            }
        }
        _logger.Warn($"LOCATOR FALLBACK EXHAUSTED Application={_applicationName}; Control={intent}; Action={action}; Tried={attempt}; no deterministic candidate completed the action.");
        return LocatorFallbackValueResult<T>.Failed;
    }

    private IEnumerable<LocatorFallbackCandidate> OrderedCandidates(LocatorFallbackControlEntry entry, ControlIntent intent, string action)
    {
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (_config.LocatorFallback.PreferPreviouslySuccessfulCandidate &&
            SuccessfulCandidateCache.TryGetValue(CacheKey(intent, action), out var prior) &&
            seen.Add(prior.Signature))
        {
            _logger.Info($"LOCATOR FALLBACK PROMOTE previously successful candidate for {intent}/{action}: {prior.Strategy}:{prior.Value}");
            yield return prior;
        }

        foreach (var candidate in entry.Candidates
                     .Where(x => x.Confidence >= _config.LocatorFallback.MinimumCandidateConfidence)
                     .Where(x => _config.LocatorFallback.AllowSourceXPath || !x.Strategy.Equals("xpath", StringComparison.OrdinalIgnoreCase))
                     .OrderByDescending(x => x.Confidence)
                     .ThenByDescending(x => x.MatchScore))
            if (seen.Add(candidate.Signature)) yield return candidate;
    }

    private async Task<CandidateProbe> ProbeAsync(ILocator locator, LocatorFallbackCandidate candidate, string action)
    {
        try
        {
            var count = await locator.CountAsync();
            if (count == 0) return new CandidateProbe(false, 0, "no-match", "Locator matched zero controls.");
            if (count != 1) return new CandidateProbe(false, count, "non-unique", $"Locator matched {count} controls; fallback refuses an arbitrary choice.");
            if (!await locator.IsVisibleAsync()) return new CandidateProbe(false, 1, "not-visible", "The unique match is not visible.");

            if (action is "click" or "fill" or "set" or "select" or "press" or "activate-tab" or "dialog-action" or "grid-cell" or "expansion-panel")
                if (!await locator.IsEnabledAsync()) return new CandidateProbe(false, 1, "not-enabled", "The unique match is disabled.");

            if (action == "fill" && !await locator.IsEditableAsync())
                return new CandidateProbe(false, 1, "not-editable", "The unique match is not editable; fallback will not convert navigation/verification controls into FillAsync.");

            // Source Tag is supporting evidence rather than an absolute constraint: Material/MDC can wrap an INPUT
            // in a richer component between Tosca scan and runtime. Record the actual tag for traceability instead of
            // rejecting a unique/actionable control merely because the wrapper changed.
            var actualTag = "";
            try { actualTag = (await locator.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")) ?? ""; } catch { }
            var reason = string.IsNullOrWhiteSpace(candidate.ExpectedTag) || candidate.ExpectedTag.Equals(actualTag, StringComparison.OrdinalIgnoreCase)
                ? $"Unique visible/action-compatible match (tag={actualTag})."
                : $"Unique visible/action-compatible match; source tag={candidate.ExpectedTag}, runtime tag={actualTag}.";
            return new CandidateProbe(true, 1, "usable", reason);
        }
        catch (Exception ex)
        {
            return new CandidateProbe(false, 0, "probe-error", Compact(ex.Message));
        }
    }

    private void Trace(
        ControlIntent intent,
        string action,
        int attempt,
        LocatorFallbackCandidate? candidate,
        string outcome,
        int matchCount,
        bool success,
        string reason,
        string primaryFailure)
    {
        var trace = new LocatorFallbackTrace(
            DateTimeOffset.Now,
            _applicationName,
            ExecutionIntent.Current.Step,
            intent.Page,
            intent.Control,
            action,
            attempt,
            candidate?.Strategy ?? "",
            candidate?.Value ?? "",
            candidate?.Role ?? "",
            candidate?.HasText ?? "",
            candidate?.Pick ?? "",
            candidate?.Index ?? 0,
            matchCount,
            success,
            outcome,
            candidate?.Confidence ?? 0,
            candidate?.SourceFile ?? "",
            candidate?.SourceModule ?? "",
            candidate?.SourceField ?? "",
            candidate?.SourceProperty ?? "",
            reason,
            primaryFailure);

        _report?.RecordLocatorFallback(trace);
        if (!_config.LocatorFallback.LogEveryAttempt && !success && outcome != "catalog-miss") return;
        var level = success ? "MATCH" : "TRY";
        _logger.Info(
            $"LOCATOR FALLBACK {level} #{attempt} Control={intent}; Action={action}; Outcome={outcome}; Matches={matchCount}; " +
            $"Candidate={(candidate is null ? "<none>" : candidate.Strategy + ":" + candidate.Value)}; " +
            $"Source={(candidate is null ? "<none>" : candidate.SourceModule + " :: " + candidate.SourceField + " :: " + candidate.SourceProperty)}; Reason={Compact(reason)}");
    }

    private string CacheKey(ControlIntent intent, string action) => $"{_applicationName}|{intent.Page}|{intent.Control}|{action}";
    private static bool IsRecoverable(Exception ex) => ex is PlaywrightException or TimeoutException;
    private static string Compact(string value) => string.Join(" ", (value ?? "").Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)).Trim();
    private sealed record CandidateProbe(bool Usable, int MatchCount, string Outcome, string Reason);
}

public sealed record LocatorFallbackValueResult<T>(bool Success, T? Value)
{
    public static LocatorFallbackValueResult<T> Failed { get; } = new(false, default);
}
