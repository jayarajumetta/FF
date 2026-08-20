using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class LlmLocatorHealer
{
    private readonly BrowserSession _browser;
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;
    private readonly ILocatorHealingProvider _provider;
    private readonly ToscaLocatorEvidenceStore _toscaEvidence;
    private readonly Dictionary<string, LocatorProposal> _cache;
    private readonly List<HealingEvent> _sessionHistory = [];
    private readonly string _cachePath;
    private readonly string _auditPath;
    private readonly object _cacheGate = new();

    public LlmLocatorHealer(BrowserSession browser, FrameworkConfig config, RunLogger logger)
    {
        _browser = browser;
        _config = config;
        _logger = logger;
        _provider = LocatorHealingProviderFactory.Create(config);
        _toscaEvidence = new ToscaLocatorEvidenceStore(config);
        _cachePath = ResolvePath(_config.SelfHeal.CacheFile);
        _auditPath = ResolvePath(_config.SelfHeal.AuditFile);
        _cache = LoadCache(_cachePath);
    }

    public async Task<ILocator?> TryHealAsync(ILocator failedLocator, ControlIntent control, string action, Exception failure)
    {
        if (!_config.SelfHeal.Enabled) return null;
        var key = CacheKey(control, action);

        if (_cache.TryGetValue(key, out var cached))
        {
            var cachedLocator = CreateLocator(cached);
            if (await IsUsableAsync(cachedLocator, action))
            {
                RecordHistory(key, control, action, cached, "cache", "accepted", "Previously validated cached locator reused.");
                _logger.Info($"SELF-HEAL cache hit. Control={control}; Action={action}; Strategy={cached.Strategy}; Value={cached.Value}");
                return cachedLocator;
            }
            RecordHistory(key, control, action, cached, "cache", "stale", "Cached locator no longer unique/visible/actionable.");
        }

        var deterministic = await TryDeterministicAsync(control, action);
        if (deterministic is not null)
        {
            _logger.Info($"SELF-HEAL deterministic recovery succeeded. Control={control}; Action={action}");
            return deterministic;
        }

        if (!_provider.IsAvailable(out var providerReason))
        {
            _logger.Warn($"SELF-HEAL skipped provider '{_provider.Name}': {providerReason}");
            return null;
        }

        try
        {
            var evidence = await CollectEvidenceAsync();
            var prompt = BuildPrompt(failedLocator, control, action, failure, evidence.Candidates, evidence.Dom, evidence.Title, _toscaEvidence.Render(control));
            var evidenceDirectory = Path.Combine(_browser.ArtifactDirectory, "self-heal");
            var response = await _provider.ProposeAsync(new LocatorHealingProviderRequest(prompt, evidence.Screenshot, evidenceDirectory));
            var proposal = ParseProposal(response);
            if (proposal is null)
            {
                RecordHistory(key, control, action, null, _provider.Name, "rejected", "Provider response did not satisfy locator JSON/confidence constraints.");
                return null;
            }

            var locator = CreateLocator(proposal);
            if (!await IsUsableAsync(locator, action))
            {
                _logger.Warn($"SELF-HEAL rejected LLM locator because it was not unique/visible/actionable. Strategy={proposal.Strategy}; Value={proposal.Value}");
                RecordHistory(key, control, action, proposal, _provider.Name, "rejected", "Proposed locator failed live uniqueness/visibility/actionability validation.");
                return null;
            }

            lock (_cacheGate)
            {
                _cache[key] = proposal;
                SaveCache(_cachePath, _cache);
            }
            RecordHistory(key, control, action, proposal, _provider.Name, "accepted", proposal.Reason);
            _logger.Info($"SELF-HEAL accepted locator. Control={control}; Action={action}; Strategy={proposal.Strategy}; Value={proposal.Value}; Confidence={proposal.Confidence:F2}");
            return locator;
        }
        catch (Exception ex)
        {
            _logger.Warn($"SELF-HEAL LLM request failed: {ex.Message}");
            RecordHistory(key, control, action, null, _provider.Name, "error", ex.Message);
            return null;
        }
    }

    private async Task<(string Dom, string Candidates, byte[] Screenshot, string Title)> CollectEvidenceAsync()
    {
        var page = _browser.Page;
        var dom = await page.ContentAsync();
        dom = Regex.Replace(dom, @"<script\b[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
        dom = Regex.Replace(dom, @"<style\b[^>]*>[\s\S]*?</style>", "", RegexOptions.IgnoreCase);
        dom = Regex.Replace(dom, @"\svalue=(['""]).?\1", "", RegexOptions.IgnoreCase);
        dom = Regex.Replace(dom, @"<textarea\b([^>]*)>[\s\S]*?</textarea>", "<textarea$1></textarea>", RegexOptions.IgnoreCase);
        if (dom.Length > _config.SelfHeal.DomMaxChars) dom = dom[.._config.SelfHeal.DomMaxChars];

        var candidates = await page.EvaluateAsync<string>($$"""
            () => JSON.stringify(Array.from(document.querySelectorAll('input,button,select,textarea,a,label,[role],[data-testid],[data-test-id],[data-automation-id]'))
              .filter(e => {
                const r=e.getBoundingClientRect(); const s=getComputedStyle(e);
                return r.width>0 && r.height>0 && s.visibility!=='hidden' && s.display!=='none';
              })
              .slice(0, {{_config.SelfHeal.CandidateLimit}})
              .map(e => ({
                tag:e.tagName.toLowerCase(), role:e.getAttribute('role')||'', type:e.getAttribute('type')||'',
                id:e.id||'', name:e.getAttribute('name')||'', testid:e.getAttribute('data-testid')||e.getAttribute('data-test-id')||'',
                automationId:e.getAttribute('data-automation-id')||'', duckCreekId:e.getAttribute('duckcreekid')||e.getAttribute('data-duckcreekid')||'',
                aria:e.getAttribute('aria-label')||'', placeholder:e.getAttribute('placeholder')||'', title:e.getAttribute('title')||'',
                text:(e.innerText||e.textContent||'').trim().replace(/\s+/g,' ').slice(0,160)
              })))
            """);
        var screenshot = _config.SelfHeal.IncludeScreenshot ? await _browser.CaptureScreenshotBytesAsync() : Array.Empty<byte>();
        var title = await page.TitleAsync();
        return (dom, candidates, screenshot, title);
    }

    private string BuildPrompt(ILocator failedLocator, ControlIntent control, string action, Exception failure, string candidates, string dom, string title, string toscaEvidence)
    {
        var state = ExecutionIntent.Current;
        var previous = state.PreviousSteps.Count == 0 ? "<none>" : string.Join(" -> ", state.PreviousSteps);
        var cacheContext = BuildCacheContext(control.Page);
        var sessionContext = BuildSessionContext(control.Page);
        return $$"""
You are a locator recovery component for a Playwright insurance test. Recover ONLY the failed control locator.
Do not alter the business flow, action, test data, expected result, state, scenario, or current step.
Return exactly one JSON object and no markdown.
Allowed strategies: testid, duckcreekid, role, label, placeholder, name, id, text, css. Never use XPath or JavaScript.
If the candidate is duplicated, use anchorStrategy/anchorValue and/or pick=first|last|nth with an evidence-supported index. Never choose an index arbitrarily.
Prefer stable source/application attributes: DuckCreekId / stable id / name / data-testid, then role+accessible name, label, placeholder, exact text, concise CSS.
For Duck Creek screens, strongly prefer stable Duck Creek/application IDs, data-testid, id, or name when present.
For Commercial ExpertQuote, prefer source HTML name/id/data-testid/role/label evidence from the current DOM.

Feature: {{state.Feature}}
Scenario: {{state.Scenario}}
Previous business steps: {{previous}}
Current business step: {{state.Step}}
Page object: {{control.Page}}
Control intent: {{control.Control}}
Control description: {{control.BusinessDescription ?? ""}}
Requested action: {{action}}
Failed Playwright locator: {{failedLocator}}
Failure: {{failure.Message}}
URL: {{_browser.Page.Url}}
Page title: {{title}}

Previously validated locator cache for this page (may include prior runs):
{{cacheContext}}

Previous locator-healing outcomes in this scenario/page:
{{sessionContext}}

Source Tosca ModuleAttribute locator evidence for this control (ordered by semantic match and property strength):
{{toscaEvidence}}

Visible interactive DOM candidates:
{{candidates}}

Sanitized current HTML DOM:
{{dom}}

Use the attached screenshot when present to disambiguate visually.
The proposed locator must identify exactly the control required by the CURRENT business step. Do not merely reuse a previous cached locator unless the DOM evidence confirms it is the same intended control.
JSON schema:
{"strategy":"name","value":"customer.name.first","role":"textbox","exact":true,"pick":"unique","index":0,"anchorStrategy":"","anchorValue":"","confidence":0.95,"reason":"brief source-grounded reason"}
""";
    }

    private LocatorProposal? ParseProposal(string response)
    {
        try
        {
            var start = response.IndexOf('{');
            var end = response.LastIndexOf('}');
            if (start < 0 || end <= start) return null;
            var p = JsonSerializer.Deserialize<LocatorProposal>(response[start..(end + 1)], new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (p is null || string.IsNullOrWhiteSpace(p.Value) || p.Confidence < _config.SelfHeal.MinimumConfidence) return null;
            if (p.Strategy.Equals("xpath", StringComparison.OrdinalIgnoreCase) || p.Value.StartsWith("//")) return null;
            return p;
        }
        catch { return null; }
    }

    private async Task<ILocator?> TryDeterministicAsync(ControlIntent control, string action)
    {
        var page = _browser.Page;
        var raw = control.Control;
        var friendly = Regex.Replace(raw, "([a-z0-9])([A-Z])", "$1 $2").Trim();
        var candidates = new List<ILocator>();
        // First try source-derived Tosca ModuleAttribute alternatives. ConstraintIndex is
        // honored only when it exists in the source catalog; no arbitrary First/Nth is invented.
        candidates.AddRange(_toscaEvidence.BuildDeterministicCandidates(page, control));
        if (raw.Contains('.') || raw.Contains('_'))
        {
            candidates.Add(page.Locator($"[name=\"{EscapeAttribute(raw)}\"]"));
            candidates.Add(page.Locator($"[id=\"{EscapeAttribute(raw)}\"]"));
        }
        candidates.Add(page.GetByTestId(raw));
        candidates.Add(page.Locator($"[duckcreekid=\"{EscapeAttribute(raw)}\"], [data-duckcreekid=\"{EscapeAttribute(raw)}\"]"));
        candidates.Add(page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = true }));
        candidates.Add(page.GetByLabel(friendly, new PageGetByLabelOptions { Exact = false }));
        candidates.Add(page.GetByPlaceholder(friendly, new PageGetByPlaceholderOptions { Exact = false }));
        foreach (var candidate in candidates) if (await IsUsableAsync(candidate, action)) return candidate;
        return null;
    }

    private ILocator CreateLocator(LocatorProposal p)
    {
        var pick=p.Pick.ToLowerInvariant() switch { "first"=>LocatorPick.First, "last"=>LocatorPick.Last, "nth"=>LocatorPick.Nth, _=>LocatorPick.Unique };
        return LocatorResolution.Build(_browser.Page,new LocatorSpec(p.Strategy,p.Value,p.Role,p.AnchorStrategy,p.AnchorValue,pick,p.Index,p.Exact));
    }

    private async Task<bool> IsUsableAsync(ILocator locator, string action)
    {
        try
        {
            if (await locator.CountAsync() != 1 || !await locator.IsVisibleAsync()) return false;
            if (action is "click" or "fill" or "set" or "select" or "press") if (!await locator.IsEnabledAsync()) return false;
            if (action == "fill" && !await locator.IsEditableAsync()) return false;
            return true;
        }
        catch { return false; }
    }

    private string BuildCacheContext(string page)
    {
        var rows = _cache
            .Where(kv => kv.Key.StartsWith(page + "|", StringComparison.OrdinalIgnoreCase))
            .Take(_config.SelfHeal.CacheContextLimit)
            .Select(kv => $"{kv.Key} => {kv.Value.Strategy}:{kv.Value.Value} (confidence={kv.Value.Confidence:F2})")
            .ToArray();
        return rows.Length == 0 ? "<none>" : string.Join("\n", rows);
    }

    private string BuildSessionContext(string page)
    {
        var rows = _sessionHistory
            .Where(x => x.Page.Equals(page, StringComparison.OrdinalIgnoreCase))
            .TakeLast(_config.SelfHeal.CacheContextLimit)
            .Select(x => $"{x.Control}/{x.Action}: {x.Provider}/{x.Outcome} => {x.Strategy}:{x.Value} :: {x.Reason}")
            .ToArray();
        return rows.Length == 0 ? "<none>" : string.Join("\n", rows);
    }

    private void RecordHistory(string key, ControlIntent control, string action, LocatorProposal? proposal, string provider, string outcome, string reason)
    {
        var item = new HealingEvent(DateTimeOffset.Now, key, control.Page, control.Control, action, provider, outcome, proposal?.Strategy ?? "", proposal?.Value ?? "", proposal?.Confidence ?? 0, reason);
        _sessionHistory.Add(item);
        try
        {
            var json = JsonSerializer.Serialize(item) + Environment.NewLine;
            Directory.CreateDirectory(Path.GetDirectoryName(_auditPath)!);
            File.AppendAllText(_auditPath, json);

            // Keep an immutable scenario-owned copy so a healed test carries its own evidence
            // into NUnit/Visual Studio/Azure DevOps rather than depending on a global audit file.
            if (!string.IsNullOrWhiteSpace(_browser.ArtifactDirectory))
            {
                var scenarioHealDirectory = Path.Combine(_browser.ArtifactDirectory, "self-heal");
                Directory.CreateDirectory(scenarioHealDirectory);
                File.AppendAllText(Path.Combine(scenarioHealDirectory, "healing-events.jsonl"), json);
            }
        }
        catch (Exception ex) { _logger.Warn($"Unable to write self-heal audit: {ex.Message}"); }
    }

    private static Dictionary<string, LocatorProposal> LoadCache(string path)
    {
        try
        {
            if (!File.Exists(path)) return new Dictionary<string, LocatorProposal>(StringComparer.OrdinalIgnoreCase);
            return JsonSerializer.Deserialize<Dictionary<string, LocatorProposal>>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                   ?? new Dictionary<string, LocatorProposal>(StringComparer.OrdinalIgnoreCase);
        }
        catch { return new Dictionary<string, LocatorProposal>(StringComparer.OrdinalIgnoreCase); }
    }

    private static void SaveCache(string path, Dictionary<string, LocatorProposal> cache)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(cache, new JsonSerializerOptions { WriteIndented = true }));
    }

    private string ResolvePath(string path) => Path.IsPathRooted(path) ? path : Path.GetFullPath(path);
    private static string CacheKey(ControlIntent control, string action) => $"{control.Page}|{control.Control}|{action}";

    private static AriaRole ParseRole(string? role) => (role ?? "").ToLowerInvariant() switch
    {
        "button" => AriaRole.Button,
        "textbox" => AriaRole.Textbox,
        "checkbox" => AriaRole.Checkbox,
        "radio" => AriaRole.Radio,
        "combobox" => AriaRole.Combobox,
        "link" => AriaRole.Link,
        "heading" => AriaRole.Heading,
        "option" => AriaRole.Option,
        "tab" => AriaRole.Tab,
        "menuitem" => AriaRole.Menuitem,
        "switch" => AriaRole.Switch,
        _ => AriaRole.Generic
    };

    private static string EscapeAttribute(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    private sealed record LocatorProposal(string Strategy, string Value, string Role, bool Exact, double Confidence, string Reason, string Pick = "unique", int Index = 0, string AnchorStrategy = "", string AnchorValue = "");
    private sealed record HealingEvent(DateTimeOffset Timestamp, string Key, string Page, string Control, string Action, string Provider, string Outcome, string Strategy, string Value, double Confidence, string Reason);
}
