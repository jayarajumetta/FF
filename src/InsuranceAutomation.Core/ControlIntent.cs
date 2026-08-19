namespace InsuranceAutomation.Core;

public sealed record ControlIntent(string Page, string Control, string? BusinessDescription = null)
{
    public override string ToString() => $"{Page}.{Control}";
}

public static class ExecutionIntent
{
    private static readonly AsyncLocal<State?> CurrentState = new();

    public static State Current => CurrentState.Value ?? new State("", "", "", Array.Empty<string>());

    public static void StartStep(string feature, string scenario, string step, int previousLimit)
    {
        var old = CurrentState.Value;
        var previous = old?.PreviousSteps.ToList() ?? new List<string>();
        if (old is not null && !string.IsNullOrWhiteSpace(old.Step)) previous.Add(old.Step);
        if (previous.Count > previousLimit) previous = previous.Skip(previous.Count - previousLimit).ToList();
        CurrentState.Value = new State(feature, scenario, step, previous);
    }

    public sealed record State(string Feature, string Scenario, string Step, IReadOnlyList<string> PreviousSteps);
}
