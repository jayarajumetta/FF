using System.Text.Json;
using ToscaArtifactAutomation.Core.Configuration;

namespace ToscaArtifactAutomation.Core.Locators;

public sealed class LocatorCatalog
{
    public string Application { get; set; } = string.Empty;
    public int DefinitionCount { get; set; }
    public List<LocatorDefinition> Definitions { get; set; } = new();
}

public sealed class LocatorDefinition
{
    public string Id { get; set; } = string.Empty;
    public string Application { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
    public string BusinessType { get; set; } = string.Empty;
    public string SourceSurrogate { get; set; } = string.Empty;
    public string Confidence { get; set; } = string.Empty;
    public int QualityScore { get; set; }
    public List<LocatorCandidate> Candidates { get; set; } = new();
}

public sealed class LocatorCandidate
{
    public string Strategy { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int Score { get; set; }
    public string SourceProperty { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public sealed class LocatorCatalogProvider
{
    public LocatorCatalogProvider(RootSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);
        var path = Path.Combine(AppContext.BaseDirectory, settings.Framework.LocatorCatalog.Replace('/', Path.DirectorySeparatorChar));
        if (!File.Exists(path)) throw new FileNotFoundException("Locator catalog was not copied to the test output directory.", path);
        Catalog = JsonSerializer.Deserialize<LocatorCatalog>(File.ReadAllText(path), FrameworkSettingsLoader.JsonOptions())
                  ?? throw new InvalidOperationException($"Locator catalog '{path}' deserialized to null.");
        if (Catalog.Definitions.Count == 0) throw new InvalidOperationException($"Locator catalog '{path}' contains no definitions.");
    }

    public LocatorCatalog Catalog { get; }
}
