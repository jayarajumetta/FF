using System.Threading;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>Async-local frame scope used only while executing a raw-Tosca frame-scoped locator.</summary>
public static class FrameExecutionContext
{
    private static readonly AsyncLocal<IFrameLocator?> CurrentValue = new();
    public static IFrameLocator? Current => CurrentValue.Value;
    public static IDisposable Push(IFrameLocator? frame)
    {
        var prior = CurrentValue.Value;
        CurrentValue.Value = frame;
        return new Restore(() => CurrentValue.Value = prior);
    }
    private sealed class Restore(Action restore) : IDisposable { public void Dispose() => restore(); }
}
