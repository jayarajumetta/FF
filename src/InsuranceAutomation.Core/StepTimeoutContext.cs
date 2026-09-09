using System.Threading;

namespace InsuranceAutomation.Core;

/// <summary>
/// Carries an optional business-step timeout through asynchronous step definitions,
/// page objects and Playwright actions without adding timeout parameters to every method.
/// </summary>
public static class StepTimeoutContext
{
    private static readonly AsyncLocal<int?> CurrentValue = new();

    public static int? CurrentTimeoutMs => CurrentValue.Value;

    public static int Resolve(int configuredTimeoutMs) =>
        Math.Max(1, CurrentValue.Value ?? configuredTimeoutMs);

    public static IDisposable Push(int? timeoutMs)
    {
        var previous = CurrentValue.Value;
        CurrentValue.Value = timeoutMs;
        return new Scope(previous);
    }

    private sealed class Scope(int? previous) : IDisposable
    {
        private int _disposed;

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1)
                return;
            CurrentValue.Value = previous;
        }
    }
}
