namespace PnCTestAutomation.TestPlanPublisher;

public enum CanonicalReportOutcome
{
    Passed,
    Failed,
    Skipped
}

public sealed record CanonicalReportResult(
    string TestIdentity,
    CanonicalReportOutcome Outcome,
    TimeSpan Duration,
    string? FailureMessage);
