using System.Collections.ObjectModel;

namespace ToscaArtifactAutomation.Core.Canonical;

public enum CanonicalOperation
{
    Navigate,
    Authenticate,
    Constraint,
    Input,
    SmartSet,
    Click,
    Select,
    Press,
    Wait,
    Verify,
    Capture,
    SetRuntime,
    GenerateRandom,
    Evaluate,
    ExternalValue,
    ExternalInput,
    SystemAction,
    SourceInstruction
}

public enum ConditionPolicy
{
    Always,
    Expression,
    OptionalTarget
}

public sealed class CanonicalAction
{
    public string Id { get; init; } = string.Empty;
    public int Sequence { get; init; }
    public string SourceStep { get; init; } = string.Empty;
    public string SourceName { get; init; } = string.Empty;
    public string SourceXTestStep { get; init; } = string.Empty;
    public string SourceSentence { get; init; } = string.Empty;
    public string Module { get; init; } = string.Empty;
    public CanonicalOperation Operation { get; init; }
    public string Target { get; init; } = string.Empty;
    public string ValueExpression { get; init; } = string.Empty;
    public string ExpectedExpression { get; init; } = string.Empty;
    public string PropertyName { get; init; } = string.Empty;
    public string Alias { get; init; } = string.Empty;
    public string Condition { get; init; } = string.Empty;
    public ConditionPolicy ConditionPolicy { get; init; } = ConditionPolicy.Always;
    public int TimeoutMs { get; init; }
    public IReadOnlyList<string> Commands { get; init; } = Array.Empty<string>();
    public bool Optional { get; init; }
    public string ExternalKey { get; init; } = string.Empty;
    public string Notes { get; init; } = string.Empty;
}
