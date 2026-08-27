using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// Captures per-action DOM evidence and maintains a page-scoped, cross-scenario memory.
/// The master document is a merge of stable controls observed over time; it is never
/// implemented as "the last page HTML wins".
/// </summary>
public sealed class DomEvidenceCollector
{
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> PageLocks = new(StringComparer.OrdinalIgnoreCase);
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

    private readonly BrowserSession _browser;
    private readonly FrameworkConfig _config;
    private readonly RunLogger _logger;

    public DomEvidenceCollector(BrowserSession browser, FrameworkConfig config, RunLogger logger)
    {
        _browser = browser;
        _config = config;
        _logger = logger;
    }

    public async Task CaptureAsync(ControlIntent intent, string action)
    {
        if (!_config.SelfHeal.CaptureDomAfterActions || !_browser.IsStarted) return;

        var pageRoot = Path.Combine(ResolveGlobalPath(_config.SelfHeal.DomEvidenceDirectory), Safe(intent.Page));
        var gate = PageLocks.GetOrAdd(pageRoot, _ => new SemaphoreSlim(1, 1));
        await gate.WaitAsync();
        try
        {
            var page = _browser.Page;
            var currentHtml = Sanitize(await page.ContentAsync());
            var title = await page.TitleAsync();
            var observationsDirectory = Path.Combine(pageRoot, "observations");
            Directory.CreateDirectory(observationsDirectory);

            var stamp = $"{DateTimeOffset.Now:yyyyMMdd_HHmmss_fff}_{Safe(intent.Control)}_{Safe(action)}";
            await File.WriteAllTextAsync(Path.Combine(observationsDirectory, stamp + ".html"), currentHtml);

            var currentControls = await CaptureControlsAsync(page);
            await File.WriteAllTextAsync(
                Path.Combine(observationsDirectory, stamp + ".controls.json"),
                JsonSerializer.Serialize(currentControls, JsonOptions));

            var merged = LoadMergedControls(Path.Combine(pageRoot, "controls.json"));
            foreach (var observation in currentControls) Merge(merged, observation, page.Url, title);
            var stable = merged.Values
                .OrderByDescending(x => x.SeenCount)
                .ThenBy(x => x.Tag, StringComparer.OrdinalIgnoreCase)
                .ThenBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                .ToList();

            Directory.CreateDirectory(pageRoot);
            await File.WriteAllTextAsync(Path.Combine(pageRoot, "controls.json"), JsonSerializer.Serialize(stable, JsonOptions));
            await File.WriteAllTextAsync(Path.Combine(pageRoot, "master-page-dom.html"), BuildMasterDom(intent.Page, stable));
            await WriteLocatorHistoryAsync(pageRoot, intent.Page);

            // Own the execution evidence inside the current scenario directory as well as
            // updating the persistent page memory. This makes every test result self-contained:
            // Visual Studio/NUnit/ADO can attach the exact DOM observed by that test instead of
            // only receiving a pointer to a shared cross-scenario store.
            if (!string.IsNullOrWhiteSpace(_browser.ArtifactDirectory))
            {
                var scenarioPageRoot = Path.Combine(_browser.ArtifactDirectory, "DOM", Safe(intent.Page));
                var scenarioObservations = Path.Combine(scenarioPageRoot, "observations");
                Directory.CreateDirectory(scenarioObservations);

                var scenarioHtml = Path.Combine(scenarioObservations, stamp + ".html");
                var scenarioControls = Path.Combine(scenarioObservations, stamp + ".controls.json");
                await File.WriteAllTextAsync(scenarioHtml, currentHtml);
                await File.WriteAllTextAsync(scenarioControls, JsonSerializer.Serialize(currentControls, JsonOptions));

                // Snapshot the merged page memory as it existed after this action. These are copies,
                // not links, so the completed test result remains immutable even when later tests
                // continue improving the global page memory.
                await File.WriteAllTextAsync(Path.Combine(scenarioPageRoot, "master-page-dom.html"), BuildMasterDom(intent.Page, stable));
                var persistentControls = Path.Combine(pageRoot, "controls.json");
                var persistentHistory = Path.Combine(pageRoot, "locator-history.json");
                if (File.Exists(persistentControls)) File.Copy(persistentControls, Path.Combine(scenarioPageRoot, "controls.json"), true);
                if (File.Exists(persistentHistory)) File.Copy(persistentHistory, Path.Combine(scenarioPageRoot, "locator-history.json"), true);

                var pointer = new
                {
                    page = intent.Page,
                    control = intent.Control,
                    action,
                    persistentPageMemory = Path.GetFullPath(pageRoot),
                    scenarioObservation = Path.GetFullPath(scenarioHtml),
                    capturedAt = DateTimeOffset.Now
                };
                await File.WriteAllTextAsync(Path.Combine(scenarioPageRoot, $"{stamp}.evidence.json"), JsonSerializer.Serialize(pointer, JsonOptions));
            }
        }
        catch (Exception ex)
        {
            _logger.Warn($"DOM evidence capture failed: {ex.Message}");
        }
        finally
        {
            gate.Release();
        }
    }

    private static async Task<List<ControlObservation>> CaptureControlsAsync(IPage page)
    {
        var json = await page.EvaluateAsync<string>("""
            () => JSON.stringify(Array.from(document.querySelectorAll([
              'input','button','select','textarea','a','label',
              'mat-select','mat-option','mat-autocomplete','mat-radio-button','mat-radio-group',
              'mat-checkbox','mat-datepicker-toggle','mat-chip','mat-chip-option','mat-chip-listbox',
              'table','[role=grid]','[role=gridcell]','[role=dialog]','mat-dialog-container',
              '[role=tab]','mat-tab-group','mat-expansion-panel','mat-expansion-panel-header',
              '[role]','[data-testid]','[data-test-id]','[data-automation-id]',
              '[duckcreekid]','[data-duckcreekid]'
            ].join(','))).map((e, occurrence) => {
              const clean = v => (v || '').toString().trim().replace(/\s+/g,' ').slice(0,220);
              const tag = e.tagName.toLowerCase();
              const cls = clean(e.getAttribute('class'));
              let component = 'generic';
              if (tag === 'select') component = 'native-select';
              else if (tag === 'mat-select') component = 'material-select';
              else if (tag === 'mat-autocomplete' || e.getAttribute('aria-autocomplete')) component = 'autocomplete';
              else if (tag === 'mat-radio-group' || tag === 'mat-radio-button' || e.getAttribute('role') === 'radiogroup' || e.getAttribute('role') === 'radio') component = 'radio';
              else if (tag === 'mat-checkbox' || e.getAttribute('type') === 'checkbox' || e.getAttribute('role') === 'checkbox') component = 'checkbox';
              else if (tag.includes('datepicker') || e.getAttribute('type') === 'date' || e.hasAttribute('matdatepicker')) component = 'date-picker';
              else if (tag === 'table' || e.getAttribute('role') === 'grid' || e.getAttribute('role') === 'gridcell') component = 'table-grid';
              else if (tag === 'mat-dialog-container' || e.getAttribute('role') === 'dialog') component = 'dialog';
              else if (tag === 'mat-tab-group' || e.getAttribute('role') === 'tab') component = 'tabs';
              else if (tag.startsWith('mat-expansion-panel')) component = 'expansion-panel';
              else if (tag.includes('chip') || cls.includes('chip-set')) component = 'chip-group';
              return {
                tag,
                id: clean(e.id),
                name: clean(e.getAttribute('name')),
                testId: clean(e.getAttribute('data-testid') || e.getAttribute('data-test-id')),
                automationId: clean(e.getAttribute('data-automation-id')),
                duckCreekId: clean(e.getAttribute('duckcreekid') || e.getAttribute('data-duckcreekid')),
                role: clean(e.getAttribute('role')),
                type: clean(e.getAttribute('type')),
                ariaLabel: clean(e.getAttribute('aria-label')),
                placeholder: clean(e.getAttribute('placeholder')),
                title: clean(e.getAttribute('title')),
                text: clean(e.innerText || e.textContent),
                componentType: component,
                occurrence,
                outerHtml: clean(e.outerHTML).slice(0,1200)
              };
            }))
            """);
        return JsonSerializer.Deserialize<List<ControlObservation>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
    }

    private static Dictionary<string, MergedControl> LoadMergedControls(string path)
    {
        try
        {
            if (!File.Exists(path)) return new Dictionary<string, MergedControl>(StringComparer.OrdinalIgnoreCase);
            var rows = JsonSerializer.Deserialize<List<MergedControl>>(File.ReadAllText(path), JsonOptions) ?? [];
            return rows.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToDictionary(x => x.Key, StringComparer.OrdinalIgnoreCase);
        }
        catch
        {
            // V48 wrote the most recent raw control array. Treat it as non-authoritative and
            // start a true merged index instead of failing the test action.
            return new Dictionary<string, MergedControl>(StringComparer.OrdinalIgnoreCase);
        }
    }

    private static void Merge(Dictionary<string, MergedControl> merged, ControlObservation observation, string url, string title)
    {
        var key = StableKey(observation);
        if (!merged.TryGetValue(key, out var item))
        {
            item = new MergedControl
            {
                Key = key,
                Tag = observation.Tag,
                ComponentType = observation.ComponentType,
                FirstSeen = DateTimeOffset.Now,
                SeenCount = 0
            };
            merged[key] = item;
        }

        item.SeenCount++;
        item.LastSeen = DateTimeOffset.Now;
        item.LastUrl = url;
        item.LastTitle = title;
        item.Tag = Prefer(item.Tag, observation.Tag);
        item.ComponentType = Prefer(item.ComponentType, observation.ComponentType);
        Add(item.Ids, observation.Id);
        Add(item.Names, observation.Name);
        Add(item.TestIds, observation.TestId);
        Add(item.AutomationIds, observation.AutomationId);
        Add(item.DuckCreekIds, observation.DuckCreekId);
        Add(item.Roles, observation.Role);
        Add(item.Types, observation.Type);
        Add(item.AriaLabels, observation.AriaLabel);
        Add(item.Placeholders, observation.Placeholder);
        Add(item.Titles, observation.Title);
        Add(item.Texts, observation.Text);
        Add(item.Occurrences, observation.Occurrence.ToString());
        if (!string.IsNullOrWhiteSpace(observation.OuterHtml)) item.RepresentativeOuterHtml = Sanitize(observation.OuterHtml);
    }

    private async Task WriteLocatorHistoryAsync(string pageRoot, string pageName)
    {
        var events = new List<JsonElement>();
        var auditPath = ResolveGlobalPath(_config.SelfHeal.AuditFile);
        if (File.Exists(auditPath))
        {
            foreach (var line in File.ReadLines(auditPath).TakeLast(1000))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                try
                {
                    using var doc = JsonDocument.Parse(line);
                    if (doc.RootElement.TryGetProperty("Page", out var page) && page.GetString()?.Equals(pageName, StringComparison.OrdinalIgnoreCase) == true)
                        events.Add(doc.RootElement.Clone());
                    else if (doc.RootElement.TryGetProperty("page", out var pageLower) && pageLower.GetString()?.Equals(pageName, StringComparison.OrdinalIgnoreCase) == true)
                        events.Add(doc.RootElement.Clone());
                }
                catch { }
            }
        }

        var cacheRows = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);
        var cachePath = ResolveGlobalPath(_config.SelfHeal.CacheFile);
        if (File.Exists(cachePath))
        {
            try
            {
                using var doc = JsonDocument.Parse(await File.ReadAllTextAsync(cachePath));
                if (doc.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (var property in doc.RootElement.EnumerateObject())
                        if (property.Name.StartsWith(pageName + "|", StringComparison.OrdinalIgnoreCase)) cacheRows[property.Name] = property.Value.Clone();
                }
            }
            catch { }
        }

        var history = new
        {
            page = pageName,
            generatedAt = DateTimeOffset.Now,
            acceptedLocatorCache = cacheRows,
            healingEvents = events
        };
        await File.WriteAllTextAsync(Path.Combine(pageRoot, "locator-history.json"), JsonSerializer.Serialize(history, JsonOptions));
    }

    private static string BuildMasterDom(string pageName, IReadOnlyList<MergedControl> controls)
    {
        var b = new StringBuilder();
        b.AppendLine("<!doctype html><html><head><meta charset=\"utf-8\"><title>Persistent page DOM memory</title></head>");
        b.Append("<body data-page=\"").Append(WebUtility.HtmlEncode(pageName)).AppendLine("\">");
        b.AppendLine("<!-- Synthetic merged control index. Each section represents a stable control observed across one or more executions. -->");
        foreach (var c in controls)
        {
            b.Append("<section data-control-key=\"").Append(WebUtility.HtmlEncode(c.Key))
             .Append("\" data-seen-count=\"").Append(c.SeenCount)
             .Append("\" data-component-type=\"").Append(WebUtility.HtmlEncode(c.ComponentType)).AppendLine("\">");
            b.Append("<meta data-first-seen=\"").Append(WebUtility.HtmlEncode(c.FirstSeen.ToString("O")))
             .Append("\" data-last-seen=\"").Append(WebUtility.HtmlEncode(c.LastSeen.ToString("O"))).AppendLine("\">");
            if (!string.IsNullOrWhiteSpace(c.RepresentativeOuterHtml)) b.AppendLine(c.RepresentativeOuterHtml);
            b.AppendLine("</section>");
        }
        b.AppendLine("</body></html>");
        return b.ToString();
    }

    private static string StableKey(ControlObservation c)
    {
        if (!string.IsNullOrWhiteSpace(c.Id)) return $"id:{c.Id}";
        if (!string.IsNullOrWhiteSpace(c.DuckCreekId)) return $"duckcreekid:{c.DuckCreekId}";
        if (!string.IsNullOrWhiteSpace(c.Name)) return $"name:{c.Name}";
        if (!string.IsNullOrWhiteSpace(c.TestId)) return $"testid:{c.TestId}|role:{c.Role}|text:{c.Text}";
        if (!string.IsNullOrWhiteSpace(c.AutomationId)) return $"automation:{c.AutomationId}";
        if (!string.IsNullOrWhiteSpace(c.AriaLabel)) return $"role:{c.Role}|aria:{c.AriaLabel}|tag:{c.Tag}";
        if (!string.IsNullOrWhiteSpace(c.Placeholder)) return $"placeholder:{c.Placeholder}|tag:{c.Tag}";
        return $"tag:{c.Tag}|role:{c.Role}|type:{c.Type}|text:{c.Text}|occurrence:{c.Occurrence}";
    }

    private static string ResolveGlobalPath(string path) => Path.IsPathRooted(path) ? path : Path.GetFullPath(path);
    private static string Prefer(string current, string candidate) => string.IsNullOrWhiteSpace(current) ? candidate : current;
    private static void Add(List<string> target, string value) { if (!string.IsNullOrWhiteSpace(value) && !target.Contains(value, StringComparer.OrdinalIgnoreCase)) target.Add(value); }
    private static string Safe(string value) => string.Concat(value.Select(c => char.IsLetterOrDigit(c) || c is '_' or '-' ? c : '_'));

    private static string Sanitize(string document)
    {
        document = Regex.Replace(document, @"<script\b[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
        document = Regex.Replace(document, @"<style\b[^>]*>[\s\S]*?</style>", "", RegexOptions.IgnoreCase);
        document = Regex.Replace(document, "\\svalue=(?:\"[^\"]*\"|'[^']*')", "", RegexOptions.IgnoreCase);
        document = Regex.Replace(document, @"<textarea\b([^>]*)>[\s\S]*?</textarea>", "<textarea$1></textarea>", RegexOptions.IgnoreCase);
        return document;
    }

    private sealed record ControlObservation(
        string Tag = "", string Id = "", string Name = "", string TestId = "", string AutomationId = "",
        string DuckCreekId = "", string Role = "", string Type = "", string AriaLabel = "", string Placeholder = "",
        string Title = "", string Text = "", string ComponentType = "generic", int Occurrence = 0, string OuterHtml = "");

    private sealed class MergedControl
    {
        public string Key { get; set; } = "";
        public string Tag { get; set; } = "";
        public string ComponentType { get; set; } = "generic";
        public DateTimeOffset FirstSeen { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public int SeenCount { get; set; }
        public string LastUrl { get; set; } = "";
        public string LastTitle { get; set; } = "";
        public string RepresentativeOuterHtml { get; set; } = "";
        public List<string> Ids { get; set; } = [];
        public List<string> Names { get; set; } = [];
        public List<string> TestIds { get; set; } = [];
        public List<string> AutomationIds { get; set; } = [];
        public List<string> DuckCreekIds { get; set; } = [];
        public List<string> Roles { get; set; } = [];
        public List<string> Types { get; set; } = [];
        public List<string> AriaLabels { get; set; } = [];
        public List<string> Placeholders { get; set; } = [];
        public List<string> Titles { get; set; } = [];
        public List<string> Texts { get; set; } = [];
        public List<string> Occurrences { get; set; } = [];
    }
}
