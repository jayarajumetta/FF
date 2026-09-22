#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PnCTestAutomation.Reporting;

public sealed class ScenarioReportRecorder
{
    private readonly object _gate = new();
    private readonly TimeProvider _clock;
    private readonly ReportRedactor _redactor;
    private readonly Dictionary<int, (ReportStep Step, long Timestamp)> _active = [];
    private readonly List<ReportStep> _steps = [];
    private readonly List<DeferredReportFailure> _deferred = [];
    private readonly List<ReportDiagnostic> _diagnostics = [];
    private int _sequence;

    public ScenarioReportRecorder(TimeProvider? clock = null, ReportRedactor? redactor = null)
    {
        _clock = clock ?? TimeProvider.System;
        _redactor = redactor ?? new ReportRedactor();
    }

    public bool HasFailures
    {
        get
        {
            lock (_gate)
                return _deferred.Count > 0 || _steps.Any(step => step.Status == ReportStatus.Fail);
        }
    }

    public ImmutableArray<ReportDiagnostic> ReadDiagnostics()
    {
        lock (_gate)
            return _diagnostics.ToImmutableArray();
    }

    public int StartStep(string text, ReportBinding? binding = null, int? parentOrder = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        lock (_gate)
        {
            if (parentOrder is { } parent && !_active.ContainsKey(parent))
                throw new InvalidOperationException("A parent step must be active.");
            var order = ++_sequence;
            _active.Add(order, (new ReportStep(
                order, _redactor.Text(text), ReportStatus.Unknown, _clock.GetUtcNow(), 0)
            {
                Binding = binding,
                ParentOrder = parentOrder
            }, _clock.GetTimestamp()));
            return order;
        }
    }

    public void EndStep(
        int order,
        ReportStatus status,
        string? error = null,
        ImmutableDictionary<string, string>? displayData = null,
        ImmutableArray<string> screenshots = default,
        ImmutableArray<string> consoleErrors = default,
        ImmutableArray<string> networkErrors = default,
        ReportBinding? binding = null)
    {
        if (!Enum.IsDefined(status) || status == ReportStatus.Unknown)
            throw new ArgumentOutOfRangeException(nameof(status), "A completed step needs an explicit status.");
        lock (_gate)
        {
            if (!_active.TryGetValue(order, out var current))
                throw new InvalidOperationException("The step was not started or was already completed.");
            if (_active.Values.Any(item => item.Step.ParentOrder == order))
                throw new InvalidOperationException("Complete child steps before their parent.");
            _steps.Add(current.Step with
            {
                Status = status,
                Binding = binding ?? current.Step.Binding,
                DurationMilliseconds = _clock.GetElapsedTime(current.Timestamp).TotalMilliseconds,
                Data = _redactor.Data(displayData ?? ImmutableDictionary<string, string>.Empty),
                Error = _redactor.Text(error),
                Screenshots = screenshots.IsDefault ? [] : screenshots,
                ConsoleErrors = consoleErrors.IsDefault ? [] : consoleErrors.Select(_redactor.Text).ToImmutableArray(),
                NetworkErrors = networkErrors.IsDefault ? [] : networkErrors.Select(_redactor.Text).ToImmutableArray()
            });
            _active.Remove(order);
        }
    }

    public void RecordDeferredVerification(DeferredReportFailure failure)
    {
        ArgumentNullException.ThrowIfNull(failure);
        lock (_gate)
            _deferred.Add(failure with
            {
                BusinessStep = _redactor.Text(failure.BusinessStep),
                Page = _redactor.Text(failure.Page),
                Control = _redactor.Text(failure.Control),
                Property = _redactor.Text(failure.Property),
                Expected = _redactor.Value(failure.Control + "." + failure.Property, failure.Expected),
                Error = _redactor.Text(failure.Error)
            });
    }

    public void RecordDiagnostic(string component, string level, string message)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(component);
        ArgumentException.ThrowIfNullOrWhiteSpace(level);
        lock (_gate)
            _diagnostics.Add(new ReportDiagnostic(
                _clock.GetUtcNow(), _redactor.Text(component), _redactor.Text(level), _redactor.Text(message)));
    }

    public ScenarioReportMetadata Snapshot(ScenarioReportMetadata identity)
    {
        ArgumentNullException.ThrowIfNull(identity);
        lock (_gate)
        {
            if (_active.Count != 0)
                throw new InvalidOperationException("All started steps must be ended before taking a report snapshot.");
            return identity with
            {
                Steps = _steps.OrderBy(step => step.Order).ToImmutableArray(),
                DeferredVerifications = _deferred.ToImmutableArray(),
                Diagnostics = _diagnostics.ToImmutableArray()
            };
        }
    }
}
