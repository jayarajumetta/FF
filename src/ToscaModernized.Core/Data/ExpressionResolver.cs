using System.Text.Json;
using System.Text.RegularExpressions;

namespace ToscaModernized.Core.Data;

public sealed partial class ExpressionResolver
{
    private readonly RunDataContext _runData;
    private readonly StaticDataStore _staticData;
    private readonly IReadOnlyDictionary<string, string> _tdm;
    private readonly IReadOnlyDictionary<string, string> _sourceOverrides;

    public ExpressionResolver(RunDataContext runData, StaticDataStore staticData, string tdmPath, string sourceOverridePath)
    {
        _runData = runData;
        _staticData = staticData;
        _tdm = LoadMap(tdmPath);
        _sourceOverrides = LoadMap(sourceOverridePath);
    }

    public string Resolve(string? raw, string? dataRef = null)
    {
        var value = !string.IsNullOrWhiteSpace(dataRef) ? _staticData.GetRequired(dataRef) : raw ?? string.Empty;
        for (var pass = 0; pass < 10; pass++)
        {
            var previous = value;
            value = EnvToken().Replace(value, match => RequiredEnvironment(match.Groups["key"].Value));
            value = GenericToken().Replace(value, match => ResolveToken(match.Groups["kind"].Value, match.Groups["key"].Value));
            if (value == previous) break;
        }
        return value;
    }

    private string ResolveToken(string kind, string key) => kind.ToLowerInvariant() switch
    {
        "data" => _staticData.GetRequired(key),
        "runtime" or "buffer" => _runData.GetRequired(key),
        "env" => RequiredEnvironment(key),
        "tdm" => RequiredMappedValue(_tdm, key, "TDM", "TestData/TdmOverrides.json"),
        "source" => RequiredMappedValue(_sourceOverrides, key, "source override", "TestData/SourceValueOverrides.json"),
        _ => throw new InvalidOperationException($"Unsupported expression token kind '{kind}'.")
    };

    private static string RequiredEnvironment(string key) =>
        Environment.GetEnvironmentVariable(key) is { Length: > 0 } value
            ? value
            : throw new InvalidOperationException($"Required environment variable '{key}' is not configured.");

    private static string RequiredMappedValue(IReadOnlyDictionary<string, string> map, string key, string kind, string file)
    {
        if (!map.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
        {
            var envKey = $"{kind}_{Regex.Replace(key, "[^A-Za-z0-9]+", "_").Trim('_').ToUpperInvariant()}";
            var environment = Environment.GetEnvironmentVariable(envKey);
            if (!string.IsNullOrWhiteSpace(environment)) return environment;
            throw new InvalidOperationException($"Unresolved {kind} value '{key}'. Populate '{key}' in {file} or set environment variable '{envKey}'.");
        }
        return value;
    }

    private static IReadOnlyDictionary<string, string> LoadMap(string path)
    {
        if (!File.Exists(path)) return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var values = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path))
            ?? new Dictionary<string, string>();
        return new Dictionary<string, string>(values, StringComparer.OrdinalIgnoreCase);
    }

    [GeneratedRegex(@"\$\{ENV:(?<key>[^}]+)\}", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex EnvToken();

    [GeneratedRegex(@"\{\{(?<kind>data|runtime|buffer|env|tdm|source):(?<key>[^}]+)\}\}", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex GenericToken();
}
