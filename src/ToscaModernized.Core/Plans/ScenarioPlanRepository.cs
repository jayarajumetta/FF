using System.Text.Json;
using ToscaModernized.Core.Models;

namespace ToscaModernized.Core.Plans;

public sealed class ScenarioPlanRepository
{
    private readonly string _plansRoot;
    private readonly IReadOnlyDictionary<string, PlanIndexEntry> _entries;
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public ScenarioPlanRepository(string plansRoot)
    {
        _plansRoot = plansRoot;
        var indexPath = Path.Combine(plansRoot, "PlanIndex.json");
        if (!File.Exists(indexPath)) throw new FileNotFoundException($"Plan index not found: '{indexPath}'.", indexPath);
        var document = JsonSerializer.Deserialize<PlanIndexDocument>(File.ReadAllText(indexPath), _jsonOptions)
            ?? throw new InvalidDataException($"Plan index '{indexPath}' deserialized to null.");
        _entries = document.Entries.ToDictionary(BuildKey, StringComparer.OrdinalIgnoreCase);
    }

    public ScenarioPlan Load(string featureTitle, string scenarioTitle)
    {
        var key = BuildKey(featureTitle, scenarioTitle);
        if (!_entries.TryGetValue(key, out var entry))
        {
            throw new KeyNotFoundException($"No ScenarioPlan is bound to Feature '{featureTitle}' and Scenario '{scenarioTitle}'.");
        }
        var path = Path.GetFullPath(Path.Combine(_plansRoot, entry.PlanFile));
        if (!path.StartsWith(Path.GetFullPath(_plansRoot), StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Plan path escapes the Plans root: '{entry.PlanFile}'.");
        }
        var plan = JsonSerializer.Deserialize<ScenarioPlan>(File.ReadAllText(path), _jsonOptions)
            ?? throw new InvalidDataException($"ScenarioPlan '{path}' deserialized to null.");
        if (!string.Equals(plan.FeatureTitle, featureTitle, StringComparison.Ordinal) ||
            !string.Equals(plan.ScenarioTitle, scenarioTitle, StringComparison.Ordinal))
        {
            throw new InvalidDataException($"ScenarioPlan '{path}' does not match the executing Feature/Scenario.");
        }
        return plan;
    }

    private static string BuildKey(PlanIndexEntry entry) => BuildKey(entry.FeatureTitle, entry.ScenarioTitle);
    private static string BuildKey(string featureTitle, string scenarioTitle) => $"{featureTitle}\u001f{scenarioTitle}";
}
