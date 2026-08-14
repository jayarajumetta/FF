using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.RegularExpressions;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Utils;

namespace ToscaArtifactAutomation.Core.Runtime;

public sealed class RandomDefinition
{
    public string Pattern { get; set; } = "[A-Za-z0-9]{10}";
    public string SourceSentence { get; set; } = string.Empty;
    public string SourceStep { get; set; } = string.Empty;
}

public sealed class ScenarioDataDocument
{
    public Dictionary<string, JsonElement> Dimensions { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, JsonElement> Values { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, RandomDefinition> Random { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class ExternalOverrideEntry
{
    public string Value { get; set; } = string.Empty;
    public bool ReplaceRequired { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public sealed class ExternalOverrideDocument
{
    public Dictionary<string, ExternalOverrideEntry> Values { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class RunDataStore
{
    private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _scenarios = new(StringComparer.OrdinalIgnoreCase);

    public void Set(string scenarioId, string key, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(scenarioId);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        _scenarios.GetOrAdd(scenarioId, _ => new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase))[key] = value;
    }

    public bool TryGet(string scenarioId, string key, out string value)
    {
        value = string.Empty;
        return _scenarios.TryGetValue(scenarioId, out var data) && data.TryGetValue(key, out value!);
    }

    public IReadOnlyDictionary<string, string> Snapshot(string scenarioId) =>
        _scenarios.TryGetValue(scenarioId, out var data)
            ? new Dictionary<string, string>(data, StringComparer.OrdinalIgnoreCase)
            : new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public void Remove(string scenarioId) => _scenarios.TryRemove(scenarioId, out _);
}

public sealed class ScenarioDataContext
{
    private static readonly Regex TokenRegex = new(@"\{\{(?<kind>data|runtime|env|external):(?<key>[^}]+)\}\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly RootSettings _settings;
    private readonly RunDataStore _runStore;
    private readonly ToscaExpressionResolver _tosca;
    private readonly Dictionary<string, string> _data = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> _runtime = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, ExternalOverrideEntry> _external = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, RandomDefinition> _random = new(StringComparer.OrdinalIgnoreCase);

    public ScenarioDataContext(RootSettings settings, RunDataStore runStore, ToscaExpressionResolver tosca)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _runStore = runStore ?? throw new ArgumentNullException(nameof(runStore));
        _tosca = tosca ?? throw new ArgumentNullException(nameof(tosca));
    }

    public string ScenarioId { get; private set; } = string.Empty;
    public string DataSet { get; private set; } = string.Empty;
    public IReadOnlyDictionary<string, RandomDefinition> RandomDefinitions => _random;

    public void Initialize(string scenarioId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(scenarioId);
        ScenarioId = scenarioId;
    }

    public async Task LoadAsync(string dataSet, CancellationToken cancellationToken = default)
    {
        EnsureInitialized();
        ArgumentException.ThrowIfNullOrWhiteSpace(dataSet);
        var scenarioPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Scenarios", dataSet + ".json");
        if (!File.Exists(scenarioPath))
            throw new FileNotFoundException($"Scenario data '{dataSet}' was not found.", scenarioPath);

        await using var stream = File.OpenRead(scenarioPath);
        var document = await JsonSerializer.DeserializeAsync<ScenarioDataDocument>(stream, FrameworkSettingsLoader.JsonOptions(), cancellationToken)
            ?? throw new InvalidOperationException($"Scenario data '{scenarioPath}' deserialized to null.");

        _data.Clear();
        foreach (var item in document.Dimensions)
            _data[item.Key] = JsonValue(item.Value);
        foreach (var item in document.Values)
            _data[item.Key] = JsonValue(item.Value);
        _random.Clear();
        foreach (var item in document.Random)
            _random[item.Key] = item.Value ?? new RandomDefinition();
        DataSet = dataSet;
        LoadExternalOverrides();
    }

    public string Resolve(string? expression)
    {
        if (string.IsNullOrEmpty(expression))
            return string.Empty;
        EnsureInitialized();
        var resolved = TokenRegex.Replace(expression, match =>
        {
            var kind = match.Groups["kind"].Value.ToLowerInvariant();
            var key = match.Groups["key"].Value.Trim();
            return kind switch
            {
                "data" => GetRequired(_data, key, "scenario data"),
                "runtime" => GetRuntimeRequired(key),
                "env" => Environment.GetEnvironmentVariable(key)
                         ?? throw new InvalidOperationException($"Environment variable '{key}' is required."),
                "external" => GetExternalRequired(key),
                _ => throw new InvalidOperationException($"Unsupported expression kind '{kind}'.")
            };
        });
        return _tosca.Resolve(resolved, this);
    }

    public void SetRuntime(string key, string value)
    {
        EnsureInitialized();
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        value ??= string.Empty;
        _runtime[key] = value;
        _runStore.Set(ScenarioId, key, value);
    }

    public bool TryGetRuntime(string key, out string value)
    {
        EnsureInitialized();
        if (_runtime.TryGetValue(key, out value!))
            return true;
        return _runStore.TryGet(ScenarioId, key, out value!);
    }

    public string GetRuntimeRequired(string key) =>
        TryGetRuntime(key, out var value)
            ? value
            : throw new KeyNotFoundException($"Runtime value '{key}' has not been generated or captured for scenario '{ScenarioId}'.");

    public bool TryGetSymbol(string key, out string value)
    {
        EnsureInitialized();
        if (_runtime.TryGetValue(key, out value!)) return true;
        if (_data.TryGetValue(key, out value!)) return true;
        if (_runStore.TryGet(ScenarioId, key, out value!)) return true;
        value = string.Empty;
        return false;
    }

    public IReadOnlyDictionary<string, string> RuntimeSnapshot() => _runStore.Snapshot(ScenarioId);

    public void Release()
    {
        if (!string.IsNullOrWhiteSpace(ScenarioId))
            _runStore.Remove(ScenarioId);
        _data.Clear(); _runtime.Clear(); _external.Clear(); _random.Clear();
    }

    private string GetExternalRequired(string key)
    {
        if (!_external.TryGetValue(key, out var entry))
            throw new KeyNotFoundException($"External/TDM key '{key}' is not declared in the override file.");
        if (_settings.Framework.FailOnSyntheticExternalData &&
            (entry.ReplaceRequired || string.Equals(entry.Value, "SYNTHETIC_REPLACE_ME", StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"External/TDM key '{key}' still contains synthetic placeholder data. Replace it in '{_settings.Framework.ExternalOverrides}'.");
        return entry.Value ?? string.Empty;
    }

    private void LoadExternalOverrides()
    {
        _external.Clear();
        var path = Path.Combine(AppContext.BaseDirectory, _settings.Framework.ExternalOverrides.Replace('/', Path.DirectorySeparatorChar));
        if (!File.Exists(path)) return;
        var doc = JsonSerializer.Deserialize<ExternalOverrideDocument>(File.ReadAllText(path), FrameworkSettingsLoader.JsonOptions())
                  ?? new ExternalOverrideDocument();
        foreach (var item in doc.Values)
            _external[item.Key] = item.Value ?? new ExternalOverrideEntry();
    }

    private static string GetRequired(IReadOnlyDictionary<string, string> dictionary, string key, string kind) =>
        dictionary.TryGetValue(key, out var value)
            ? value
            : throw new KeyNotFoundException($"Required {kind} key '{key}' was not found.");

    private static string JsonValue(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.String => value.GetString() ?? string.Empty,
        JsonValueKind.Null => string.Empty,
        _ => value.GetRawText()
    };

    private void EnsureInitialized()
    {
        if (string.IsNullOrWhiteSpace(ScenarioId))
            throw new InvalidOperationException("ScenarioDataContext.Initialize must be called by BeforeScenario before data is used.");
    }
}
