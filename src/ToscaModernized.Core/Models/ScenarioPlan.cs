namespace ToscaModernized.Core.Models;

public sealed class ScenarioPlan
{
    public string SchemaVersion { get; init; } = "1.0";
    public string Application { get; init; } = string.Empty;
    public string SourceFeatureFile { get; init; } = string.Empty;
    public string FeatureTitle { get; init; } = string.Empty;
    public string ScenarioTitle { get; init; } = string.Empty;
    public string StaticDataFile { get; init; } = string.Empty;
    public IReadOnlyList<PlanInstruction> BackgroundInstructions { get; init; } = Array.Empty<PlanInstruction>();
    public IReadOnlyList<PlanInstruction> ScenarioInstructions { get; init; } = Array.Empty<PlanInstruction>();
}

public sealed class PlanIndexDocument
{
    public IReadOnlyList<PlanIndexEntry> Entries { get; init; } = Array.Empty<PlanIndexEntry>();
}

public sealed class PlanIndexEntry
{
    public string Application { get; init; } = string.Empty;
    public string FeatureTitle { get; init; } = string.Empty;
    public string ScenarioTitle { get; init; } = string.Empty;
    public string PlanFile { get; init; } = string.Empty;
}
