using System.Text.Json;

namespace ToscaModernized.Core.Data;

public sealed class StaticDataStore
{
    private readonly IReadOnlyDictionary<string, string> _values;

    private StaticDataStore(IReadOnlyDictionary<string, string> values) => _values = values;

    public static StaticDataStore Load(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Static test-data file was not found: '{path}'.", path);
        }
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        if (!document.RootElement.TryGetProperty("values", out var valuesElement) || valuesElement.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidDataException($"Static test-data file '{path}' does not contain a JSON object named 'values'.");
        }
        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in valuesElement.EnumerateObject())
        {
            values[property.Name] = property.Value.ValueKind == JsonValueKind.String
                ? property.Value.GetString() ?? string.Empty
                : property.Value.GetRawText();
        }
        return new StaticDataStore(values);
    }

    public string GetRequired(string key)
    {
        if (!_values.TryGetValue(key, out var value))
        {
            throw new KeyNotFoundException($"Static test-data key '{key}' was not found.");
        }
        return value;
    }
}
