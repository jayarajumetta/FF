using System.Diagnostics;
using Serilog;
using ToscaArtifactAutomation.Core.Configuration;

namespace ToscaArtifactAutomation.Core.Actions;

public sealed class SystemActionService
{
    private readonly RootSettings _settings;

    public SystemActionService(RootSettings settings) => _settings = settings ?? throw new ArgumentNullException(nameof(settings));

    public async Task ExecuteProcessCleanupAsync(CancellationToken cancellationToken = default)
    {
        if (!_settings.Framework.EnableProcessCleanup) return;
        if (!OperatingSystem.IsWindows())
        {
            Log.Information("Source process cleanup is configured but skipped because the agent is not Windows.");
            return;
        }
        foreach (var processName in new[] { "iexplore", "chrome", "firefox", "MicrosoftEdge", "msedge" })
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill(entireProcessTree: true);
                    await process.WaitForExitAsync(cancellationToken);
                }
                catch (Exception ex) { Log.Warning(ex, "Unable to stop process {ProcessName}.", processName); }
                finally { process.Dispose(); }
            }
        }
    }

    public Task RejectBusinessLayerSystemActionAsync(string actionId) =>
        throw new InvalidOperationException($"System/TBox action '{actionId}' reached the Page layer. Canonical mapping requires it to execute through Hooks/SystemActions.");
}
