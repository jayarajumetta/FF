using System.Text.Json;

namespace ToscaModernized.Core.Locators;

public sealed class LocatorRepository
{
    private readonly IReadOnlyDictionary<string, IReadOnlyList<LocatorDefinition>> _byName;

    private LocatorRepository(IReadOnlyDictionary<string, IReadOnlyList<LocatorDefinition>> byName) => _byName = byName;

    public static LocatorRepository Load(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException($"Locator repository not found: '{path}'.", path);
        var document = JsonSerializer.Deserialize<LocatorDocument>(File.ReadAllText(path), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidDataException($"Locator repository '{path}' deserialized to null.");
        var groups = document.Definitions
            .GroupBy(d => Normalize(d.Name), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => (IReadOnlyList<LocatorDefinition>)g.ToArray(), StringComparer.OrdinalIgnoreCase);
        return new LocatorRepository(groups);
    }

    public IReadOnlyList<LocatorDefinition> Find(string target, string? moduleHint = null)
    {
        var key = Normalize(target);
        if (!_byName.TryGetValue(key, out var definitions)) return Array.Empty<LocatorDefinition>();
        if (string.IsNullOrWhiteSpace(moduleHint)) return definitions;
        var scoped = definitions.Where(d => d.Module.Contains(moduleHint, StringComparison.OrdinalIgnoreCase)).ToArray();
        return scoped.Length > 0 ? scoped : definitions;
    }

    public static string Normalize(string value) =>
        new(value.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());
}
