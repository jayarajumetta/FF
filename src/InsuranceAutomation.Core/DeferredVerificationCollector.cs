namespace InsuranceAutomation.Core;

public sealed record DeferredVerificationFailure(
    DateTimeOffset Timestamp,
    string BusinessStep,
    string Page,
    string Control,
    string Property,
    string Expected,
    string Error,
    string? Screenshot);

/// <summary>
/// Scenario-scoped collector for mature soft verification. A verification is deferred only after
/// the canonical locator and configured wait have
/// all been exhausted. Fatal navigation/browser/action failures are never collected here.
/// </summary>
public sealed class DeferredVerificationCollector
{
    private readonly List<DeferredVerificationFailure> _failures = [];
    private readonly object _gate = new();

    public void Add(DeferredVerificationFailure failure)
    {
        lock (_gate) _failures.Add(failure);
    }

    public IReadOnlyList<DeferredVerificationFailure> Failures
    {
        get { lock (_gate) return _failures.ToArray(); }
    }

    public bool HasFailures { get { lock (_gate) return _failures.Count > 0; } }

    public string BuildSummary()
    {
        var items = Failures;
        if (items.Count == 0) return string.Empty;
        return string.Join(Environment.NewLine, items.Select((x, i) =>
            $"{i + 1}. {x.BusinessStep} :: {x.Page}.{x.Control} expected '{x.Expected}' ({x.Property}) :: {x.Error}"));
    }
}
