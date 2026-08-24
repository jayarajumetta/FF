using System.Collections.Concurrent;
using System.Text.Json;

namespace InsuranceAutomation.Core;

/// <summary>
/// A page/control-scoped deterministic locator candidate compiled from Tosca ModuleAttribute/XParam evidence.
/// The Page Object keeps one readable primary locator; this sidecar catalog retains the alternative source evidence
/// without duplicating Page classes or exposing locator noise to business code.
/// </summary>
public sealed record LocatorFallbackCandidate
{
    public string Strategy { get; init; } = "";
    public string Value { get; init; } = "";
    public string Role { get; init; } = "";
    public bool Exact { get; init; } = true;
    public string Pick { get; init; } = "unique";
    public int Index { get; init; }
    public string HasText { get; init; } = "";
    public string AnchorStrategy { get; init; } = "";
    public string AnchorValue { get; init; } = "";
    public string ExpectedTag { get; init; } = "";
    public string BusinessType { get; init; } = "";
    public string SourceFile { get; init; } = "";
    public string SourceModule { get; init; } = "";
    public string SourceField { get; init; } = "";
    public string SourceProperty { get; init; } = "";
    public int MatchScore { get; init; }
    public double Confidence { get; init; }
    public string Reason { get; init; } = "";

    public LocatorSpec ToLocatorSpec()
    {
        var pick = Pick.ToLowerInvariant() switch
        {
            "first" => LocatorPick.First,
            "last" => LocatorPick.Last,
            "nth" => LocatorPick.Nth,
            _ => LocatorPick.Unique
        };
        return new LocatorSpec(
            Strategy,
            Value,
            string.IsNullOrWhiteSpace(Role) ? null : Role,
            string.IsNullOrWhiteSpace(AnchorStrategy) ? null : AnchorStrategy,
            string.IsNullOrWhiteSpace(AnchorValue) ? null : AnchorValue,
            pick,
            Index,
            Exact,
            SourceModule,
            SourceField,
            string.IsNullOrWhiteSpace(HasText) ? null : HasText);
    }

    public string Signature => string.Join("|", new[]
    {
        Strategy, Value, Role, AnchorStrategy, AnchorValue, Pick, Index.ToString(), Exact.ToString(), HasText
    }).ToLowerInvariant();
}

public sealed record LocatorFallbackControlEntry
{
    public string Page { get; init; } = "";
    public string Control { get; init; } = "";
    public string CanonicalControl { get; init; } = "";
    public string AliasOf { get; init; } = "";
    public int SourceEvidenceCount { get; init; }
    public IReadOnlyList<LocatorFallbackCandidate> Candidates { get; init; } = Array.Empty<LocatorFallbackCandidate>();
}

public sealed record LocatorFallbackApplicationCatalog
{
    public string Version { get; init; } = "";
    public string Application { get; init; } = "";
    public int SourceCatalogEntries { get; init; }
    public int PageLocatorProperties { get; init; }
    public int Aliases { get; init; }
    public int CanonicalControls { get; init; }
    public int CanonicalControlsWithFallback { get; init; }
    public double CanonicalFallbackCoverage { get; init; }
    public IReadOnlyList<LocatorFallbackControlEntry> Controls { get; init; } = Array.Empty<LocatorFallbackControlEntry>();
}

public interface ILocatorFallbackProvider
{
    LocatorFallbackControlEntry? Find(ControlIntent intent);
    LocatorFallbackApplicationCatalog Metadata { get; }
}

public sealed class LocatorFallbackCatalogStore : ILocatorFallbackProvider
{
    private static readonly ConcurrentDictionary<string, CatalogIndex> Cache = new(StringComparer.OrdinalIgnoreCase);
    private readonly CatalogIndex _index;

    public LocatorFallbackCatalogStore(FrameworkConfig config, string applicationName)
    {
        var path = ResolveCatalogPath(config.LocatorFallback.CatalogDirectory, applicationName);
        _index = Cache.GetOrAdd(path, Load);
    }

    public LocatorFallbackControlEntry? Find(ControlIntent intent)
    {
        var key = Key(intent.Page, intent.Control);
        if (_index.ByControl.TryGetValue(key, out var found) && found.Candidates.Count > 0) return found;

        // Aliases normally inherit candidates during catalog compilation. This secondary lookup is deliberately
        // retained so a hand-maintained alias can still reuse the canonical control's source-backed candidate set.
        if (found is not null && !string.IsNullOrWhiteSpace(found.CanonicalControl) &&
            _index.ByControl.TryGetValue(Key(intent.Page, found.CanonicalControl), out var canonical))
            return canonical;
        return found;
    }

    public LocatorFallbackApplicationCatalog Metadata => _index.Catalog;

    private static CatalogIndex Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Tosca locator fallback catalog was not found: {path}");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var catalog = JsonSerializer.Deserialize<LocatorFallbackApplicationCatalog>(File.ReadAllText(path), options)
                      ?? throw new InvalidOperationException($"Unable to parse locator fallback catalog: {path}");
        var map = new Dictionary<string, LocatorFallbackControlEntry>(StringComparer.OrdinalIgnoreCase);
        foreach (var c in catalog.Controls) map[Key(c.Page, c.Control)] = c;
        return new CatalogIndex(catalog, map);
    }

    private static string ResolveCatalogPath(string directory, string applicationName)
    {
        var filename = applicationName + ".json";
        if (Path.IsPathRooted(directory)) return Path.Combine(directory, filename);
        foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            var current = new DirectoryInfo(start);
            while (current is not null)
            {
                var candidate = Path.Combine(current.FullName, directory.Replace('/', Path.DirectorySeparatorChar), filename);
                if (File.Exists(candidate)) return Path.GetFullPath(candidate);
                current = current.Parent;
            }
        }
        return Path.GetFullPath(Path.Combine(directory, filename));
    }

    private static string Key(string page, string control) => $"{page}|{control}";
    private sealed record CatalogIndex(LocatorFallbackApplicationCatalog Catalog, IReadOnlyDictionary<string, LocatorFallbackControlEntry> ByControl);
}
