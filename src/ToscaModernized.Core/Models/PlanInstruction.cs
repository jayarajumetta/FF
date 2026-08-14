namespace ToscaModernized.Core.Models;

public sealed class PlanInstruction
{
    public string Id { get; init; } = string.Empty;
    public string Phase { get; init; } = string.Empty;
    public int Sequence { get; init; }
    public string Keyword { get; init; } = string.Empty;
    public string GherkinText { get; init; } = string.Empty;
    public string NormalizedText { get; init; } = string.Empty;
    public string Operation { get; init; } = "ManualAction";
    public string InnerOperation { get; init; } = string.Empty;
    public string Target { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
    public string ValueRef { get; init; } = string.Empty;
    public string Pattern { get; init; } = string.Empty;
    public string Alias { get; init; } = string.Empty;
    public string Condition { get; init; } = string.Empty;
    public string SourceStep { get; init; } = string.Empty;
    public string SourceStepName { get; init; } = string.Empty;
    public string SourceModule { get; init; } = string.Empty;
    public string SourceSection { get; init; } = string.Empty;
    public string ReusableFlow { get; init; } = string.Empty;
    public string ControlFlow { get; init; } = string.Empty;
    public IReadOnlyList<string> DataReferences { get; init; } = Array.Empty<string>();
    public IReadOnlyList<IReadOnlyList<string>> Table { get; init; } = Array.Empty<IReadOnlyList<string>>();
}
