namespace InsuranceAutomation.Core;

public sealed class ScenarioAttemptContext
{
    private static readonly AsyncLocal<ScenarioAttemptContext?> Slot = new();
    private readonly List<ScenarioReport> _reports = [];

    public static ScenarioAttemptContext? Current { get => Slot.Value; set => Slot.Value = value; }
    public string ExecutionId { get; } = Guid.NewGuid().ToString("N");
    public string TestFullName { get; }
    public int MaxAttempts { get; }
    public int AttemptNumber { get; set; } = 1;
    public IReadOnlyList<ScenarioReport> Reports => _reports;

    public ScenarioAttemptContext(string testFullName, int maxAttempts)
    {
        TestFullName = testFullName;
        MaxAttempts = maxAttempts;
    }

    public void Register(ScenarioReport report) => _reports.Add(report);
}
