using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// Runtime view over the source-derived Tosca ModuleAttribute locator catalog.
/// It is intentionally read-only: source properties are evidence, never silently
/// rewritten into global selectors.
/// </summary>
public sealed class ToscaLocatorEvidenceStore
{
    private readonly IReadOnlyList<ToscaLocatorEvidence> _entries;

    public ToscaLocatorEvidenceStore(FrameworkConfig config)
    {
        _entries = Load(ResolvePath(config.SelfHeal.LocatorCatalogFile));
    }

    public IReadOnlyList<ToscaLocatorEvidence> Find(ControlIntent control, int limit = 12)
    {
        var controlKey = Normalize(control.Control);
        var descriptionKey = Normalize(control.BusinessDescription ?? string.Empty);
        return _entries
            .Select(x => new { Evidence = x, Score = Score(x, controlKey, descriptionKey) })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .ThenByDescending(x => x.Evidence.Properties.Count)
            .Take(limit)
            .Select(x => x.Evidence)
            .ToArray();
    }

    public string Render(ControlIntent control, int limit = 12) =>
        JsonSerializer.Serialize(Find(control, limit), new JsonSerializerOptions { WriteIndented = true });

    public IEnumerable<ILocator> BuildDeterministicCandidates(IPage page, ControlIntent control)
    {
        foreach (var evidence in Find(control))
        {
            var p = evidence.Properties;
            var pick = ParsePick(p);
            if (TryValue(p, "Id", out var id)) yield return LocatorResolution.Build(page, new LocatorSpec("id", id, Pick: pick.Pick, Index: pick.Index, SourceModule: evidence.Module, SourceField: evidence.Field));
            if (TryValue(p, "Name", out var name)) yield return LocatorResolution.Build(page, new LocatorSpec("name", name, Pick: pick.Pick, Index: pick.Index, SourceModule: evidence.Module, SourceField: evidence.Field));
            if (TryAny(p, new[] { "DuckCreekId", "duckcreekid", "data-duckcreekid" }, out var dc)) yield return LocatorResolution.Build(page, new LocatorSpec("duckcreekid", dc, Pick: pick.Pick, Index: pick.Index, SourceModule: evidence.Module, SourceField: evidence.Field));
            if (TryAny(p, new[] { "data-testid", "DataTestId", "TestId" }, out var testId)) yield return LocatorResolution.Build(page, new LocatorSpec("testid", testId, Pick: pick.Pick, Index: pick.Index, SourceModule: evidence.Module, SourceField: evidence.Field));
        }
    }

    private static (LocatorPick Pick, int Index) ParsePick(IReadOnlyDictionary<string,string> properties)
    {
        if (!TryValue(properties, "ConstraintIndex", out var raw) || !int.TryParse(Regex.Match(raw, @"\d+").Value, out var oneBased) || oneBased <= 0)
            return (LocatorPick.Unique, 0);
        var zeroBased = oneBased - 1;
        return zeroBased == 0 ? (LocatorPick.First, 0) : (LocatorPick.Nth, zeroBased);
    }

    private static int Score(ToscaLocatorEvidence e, string control, string description)
    {
        if (string.IsNullOrWhiteSpace(control)) return 0;
        var field = Normalize(e.Field);
        var desc = Normalize(e.Description);
        var module = Normalize(e.Module);
        var score = 0;
        if (field == control) score += 100;
        else if (field.Contains(control, StringComparison.Ordinal) || control.Contains(field, StringComparison.Ordinal)) score += 35;
        if (!string.IsNullOrWhiteSpace(description) && (desc.Contains(description, StringComparison.Ordinal) || description.Contains(desc, StringComparison.Ordinal))) score += 20;
        if (module.Contains(control, StringComparison.Ordinal)) score += 5;
        if (e.Properties.ContainsKey("Id")) score += 8;
        if (e.Properties.ContainsKey("Name")) score += 7;
        if (e.Properties.Keys.Any(k => k.Equals("data-testid", StringComparison.OrdinalIgnoreCase))) score += 6;
        if (e.Properties.Keys.Any(k => k.Contains("duckcreek", StringComparison.OrdinalIgnoreCase))) score += 8;
        return score;
    }

    private static string Normalize(string value) => Regex.Replace(value ?? string.Empty, "[^A-Za-z0-9]+", string.Empty).ToLowerInvariant();
    private static bool TryValue(IReadOnlyDictionary<string,string> properties, string key, out string value)
    {
        var row = properties.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
        value = row.Value ?? string.Empty;
        return !string.IsNullOrWhiteSpace(row.Key) && !string.IsNullOrWhiteSpace(value);
    }
    private static bool TryAny(IReadOnlyDictionary<string,string> properties, IEnumerable<string> keys, out string value)
    {
        foreach (var key in keys) if (TryValue(properties, key, out value)) return true;
        value = string.Empty; return false;
    }

    private static IReadOnlyList<ToscaLocatorEvidence> Load(string path)
    {
        try
        {
            if (!File.Exists(path)) return Array.Empty<ToscaLocatorEvidence>();
            return JsonSerializer.Deserialize<List<ToscaLocatorEvidence>>(File.ReadAllText(path), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
        }
        catch { return Array.Empty<ToscaLocatorEvidence>(); }
    }

    private static string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path)) return path;
        foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            var current = new DirectoryInfo(start);
            while (current is not null)
            {
                var candidate = Path.Combine(current.FullName, path.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(candidate)) return candidate;
                current = current.Parent;
            }
        }
        return Path.GetFullPath(path);
    }
}

public sealed record ToscaLocatorEvidence(
    string SourceFile,
    string Module,
    string Field,
    string Description,
    string BusinessType,
    Dictionary<string,string> Properties);
