using System.Text.Json.Serialization;
namespace InsuranceAutomation.Core.SelfHealing;

public sealed record DomElementSnapshot(
    string Tag, string Role, string Id, string Name, string AriaLabel,
    string Placeholder, string Text, string TestId, string DuckCreekId, string Type);

public sealed record HealingRequest(
    string Feature, string Scenario, string Step, string Action, string ControlExpression,
    string PrimaryLocator, string Url, string Title, string Failure,
    IReadOnlyList<DomElementSnapshot> Elements);

public sealed class LocatorProposal
{
    [JsonPropertyName("strategy")] public string Strategy { get; set; } = "";
    [JsonPropertyName("value")] public string Value { get; set; } = "";
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("exact")] public bool Exact { get; set; } = true;
    [JsonPropertyName("confidence")] public double Confidence { get; set; }
    [JsonPropertyName("reason")] public string Reason { get; set; } = "";
}

public sealed record HealingAudit(
    DateTimeOffset Timestamp, string Feature, string Scenario, string Step, string Action,
    string ControlExpression, string PrimaryLocator, string? HealedLocator,
    string Provider, double Confidence, string Outcome, string Reason);
