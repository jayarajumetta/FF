namespace InsuranceAutomation.Core;

public sealed record ControlIntent(string Page, string Control)
{
    public override string ToString() => $"{Page}.{Control}";
}

public static class ExecutionIntent
{
    private static readonly AsyncLocal<State?> CurrentState = new();

    public static State Current => CurrentState.Value ?? new State("", "", "");

    public static void Set(string feature, string scenario, string step) =>
        CurrentState.Value = new State(feature, scenario, step);

    public sealed record State(string Feature, string Scenario, string Step);
}
