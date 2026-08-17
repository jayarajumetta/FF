using System.Threading;
namespace InsuranceAutomation.Core.SelfHealing;

public static class ExecutionIntentContext
{
    static readonly AsyncLocal<State?> CurrentState = new();
    public sealed record State(string Feature, string Scenario, string Step);
    public static State Current => CurrentState.Value ?? new("Unknown feature", "Unknown scenario", "Unknown step");
    public static void Set(string feature, string scenario, string step) => CurrentState.Value = new(feature, scenario, step);
    public static void Clear() => CurrentState.Value = null;
}
