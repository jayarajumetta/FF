using System.Text.Json;
using System.Text.RegularExpressions;

namespace InsuranceAutomation.Core;

public sealed class ScenarioData
{
    private readonly Dictionary<string, string> _static = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _runtime = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _external = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _randomPatterns = new(StringComparer.OrdinalIgnoreCase);

    public string CurrentFile { get; private set; } = string.Empty;
    public bool IsLoaded => !string.IsNullOrWhiteSpace(CurrentFile);

    public void Load(string scenarioFile, string externalFile)
    {
        _static.Clear();
        _runtime.Clear();
        _external.Clear();
        _randomPatterns.Clear();

        CurrentFile = scenarioFile;
        using var document = JsonDocument.Parse(File.ReadAllText(scenarioFile));
        var root = document.RootElement;

        ReadFlatObject(root, "application", _static);
        ReadFlatObject(root, "dimensions", _static);
        ReadFlatObject(root, "values", _static);

        if (root.TryGetProperty("random", out var random) && random.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in random.EnumerateObject())
            {
                if (property.Value.TryGetProperty("pattern", out var pattern))
                {
                    _randomPatterns[property.Name] = pattern.GetString() ?? string.Empty;
                }
            }
        }

        if (File.Exists(externalFile))
        {
            using var externalDocument = JsonDocument.Parse(File.ReadAllText(externalFile));
            Flatten(externalDocument.RootElement, string.Empty, _external);
        }
    }

    public string GetRequired(string key)
    {
        var value = Get(key);
        if (string.IsNullOrWhiteSpace(value) || IsSynthetic(value))
        {
            throw new InvalidOperationException($"Required test data '{key}' is missing or still synthetic. Scenario data: {CurrentFile}");
        }

        return value;
    }

    public string Get(string key, string fallback = "")
    {
        if (_runtime.TryGetValue(key, out var runtimeValue)) return runtimeValue;

        // An explicit external override wins over the source/static value.
        if (_external.TryGetValue(key, out var externalValue) && !IsSynthetic(externalValue))
        {
            return externalValue;
        }

        if (_static.TryGetValue(key, out var staticValue)) return staticValue;
        return fallback;
    }

    public static bool IsSynthetic(string? value) =>
        string.IsNullOrWhiteSpace(value) || value.Equals("SYNTHETIC_REPLACE_ME", StringComparison.OrdinalIgnoreCase);

    public void SetRuntime(string key, string value) => _runtime[key] = value;

    // Kept as a compatibility alias for source-derived runtime captures.
    public void Set(string key, string value) => SetRuntime(key, value);

    public string GenerateRandom(string key, string? pattern = null)
    {
        if (_runtime.TryGetValue(key, out var existing))
        {
            return existing;
        }

        var effectivePattern = string.IsNullOrWhiteSpace(pattern) && _randomPatterns.TryGetValue(key, out var configured)
            ? configured
            : pattern ?? string.Empty;

        var value = RandomData.Generate(effectivePattern);
        _runtime[key] = value;
        return value;
    }

    // Compatibility alias. Page objects should not call this in v44; random data is created in StepDefinitions.
    public string Random(string key, string pattern) => GenerateRandom(key, pattern);

    public string Resolve(string expression)
    {
        if (string.IsNullOrEmpty(expression)) return string.Empty;

        var resolved = Regex.Replace(
            expression,
            @"\{\{(data|runtime|external|env):([^}]+)\}\}",
            match => match.Groups[1].Value.Equals("env", StringComparison.OrdinalIgnoreCase)
                ? Environment.GetEnvironmentVariable(match.Groups[2].Value) ?? string.Empty
                : Get(match.Groups[2].Value));

        resolved = Regex.Replace(resolved, @"\{B\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));
        resolved = Regex.Replace(resolved, @"\{PL\[([^\]]+)\]\}", match => Get(match.Groups[1].Value));
        return resolved;
    }

    public bool Condition(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) return true;

        var normalized = expression.Trim();
        var comparison = Regex.Match(normalized, @"^['""]?(.+?)['""]?\s*(==|!=)\s*['""]?(.*?)['""]?$");
        if (!comparison.Success)
        {
            // Tosca control-flow labels that are not data comparisons are retained as source trace but should not crash the run.
            return true;
        }

        var key = comparison.Groups[1].Value.Trim();
        var op = comparison.Groups[2].Value;
        var expected = comparison.Groups[3].Value.Trim();
        if (expected.Equals("NULL", StringComparison.OrdinalIgnoreCase)) expected = string.Empty;

        var actual = Get(key);
        var equals = string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
        return op == "==" ? equals : !equals;
    }

    public IReadOnlyDictionary<string, string> Snapshot()
    {
        var result = new Dictionary<string, string>(_static, StringComparer.OrdinalIgnoreCase);
        foreach (var item in _runtime) result[item.Key] = item.Value;

        foreach (var key in result.Keys.Where(key =>
                     key.Contains("password", StringComparison.OrdinalIgnoreCase) ||
                     key.Contains("secret", StringComparison.OrdinalIgnoreCase)))
        {
            result[key] = "***";
        }

        return result;
    }

    private static void ReadFlatObject(JsonElement root, string name, IDictionary<string, string> target)
    {
        if (!root.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.Object) return;
        foreach (var property in value.EnumerateObject())
        {
            target[property.Name] = property.Value.ValueKind == JsonValueKind.String
                ? property.Value.GetString() ?? string.Empty
                : property.Value.ToString();
        }
    }

    private static void Flatten(JsonElement element, string prefix, IDictionary<string, string> target)
    {
        if (element.ValueKind != JsonValueKind.Object) return;
        foreach (var property in element.EnumerateObject())
        {
            var key = string.IsNullOrWhiteSpace(prefix) ? property.Name : $"{prefix}.{property.Name}";
            if (property.Value.ValueKind == JsonValueKind.Object)
            {
                Flatten(property.Value, key, target);
            }
            else
            {
                var value = property.Value.ValueKind == JsonValueKind.String
                    ? property.Value.GetString() ?? string.Empty
                    : property.Value.ToString();
                target[property.Name] = value;
                target[key] = value;
            }
        }
    }
}

public static class RandomData
{
    private static readonly Random Random = new();

    public static string Generate(string pattern)
    {
        pattern = (pattern ?? string.Empty).Trim().TrimStart('^').TrimEnd('$');
        if (string.IsNullOrWhiteSpace(pattern))
        {
            return Guid.NewGuid().ToString("N")[..10];
        }

        var output = new System.Text.StringBuilder();
        for (var index = 0; index < pattern.Length;)
        {
            if (pattern[index] == '\\' && index + 1 < pattern.Length)
            {
                output.Append(pattern[index + 1]);
                index += 2;
                continue;
            }

            if (pattern[index] == '[')
            {
                var close = pattern.IndexOf(']', index);
                if (close < 0)
                {
                    output.Append(pattern[index++]);
                    continue;
                }

                var characterClass = pattern[(index + 1)..close];
                var count = 1;
                var countMatch = Regex.Match(pattern[(close + 1)..], @"^\{(\d+)\}");
                if (countMatch.Success)
                {
                    count = int.Parse(countMatch.Groups[1].Value);
                    close += countMatch.Length;
                }

                for (var item = 0; item < count; item++)
                {
                    output.Append(characterClass.Contains("A-Z", StringComparison.Ordinal)
                        ? (char)('A' + Random.Next(26))
                        : characterClass.Contains("a-z", StringComparison.Ordinal)
                            ? (char)('a' + Random.Next(26))
                            : (char)('0' + Random.Next(10)));
                }

                index = close + 1;
                continue;
            }

            output.Append(pattern[index++]);
        }

        return output.ToString();
    }
}
