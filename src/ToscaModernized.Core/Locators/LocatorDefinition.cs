namespace ToscaModernized.Core.Locators;

public sealed class LocatorDocument
{
    public string Application { get; init; } = string.Empty;
    public int DefinitionCount { get; init; }
    public IReadOnlyList<LocatorDefinition> Definitions { get; init; } = Array.Empty<LocatorDefinition>();
}

public sealed class LocatorDefinition
{
    public string Id { get; init; } = string.Empty;
    public string Application { get; init; } = string.Empty;
    public string Module { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string NormalizedName { get; init; } = string.Empty;
    public string BusinessType { get; init; } = string.Empty;
    public string Confidence { get; init; } = string.Empty;
    public IReadOnlyList<LocatorCandidate> Candidates { get; init; } = Array.Empty<LocatorCandidate>();
}

public sealed class LocatorCandidate
{
    public string Strategy { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
    public int Score { get; init; }
    public string SourceProperty { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
}
