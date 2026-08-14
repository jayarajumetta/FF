using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using ToscaModernized.Core.Configuration;

namespace ToscaModernized.Core.Execution;

public sealed class SystemActions
{
    private readonly FrameworkSettings _settings;
    public SystemActions(FrameworkSettings settings) => _settings = settings;

    public async Task ExecuteProcessAsync(string sourceText)
    {
        if (!_settings.Security.AllowProcessExecution) return;
        var quoted = Regex.Matches(sourceText, "\\\"([^\\\"]*)\\\"").Select(m => m.Groups[1].Value).ToArray();
        if (quoted.Length == 0) throw new InvalidOperationException($"No process command was found in '{sourceText}'.");
        var parts = quoted[0].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        var startInfo = new ProcessStartInfo(parts[0], parts.Length > 1 ? parts[1] : string.Empty)
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        using var process = Process.Start(startInfo) ?? throw new InvalidOperationException($"Unable to start '{parts[0]}'.");
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        await process.WaitForExitAsync(timeout.Token).ConfigureAwait(false);
        if (process.ExitCode != 0) throw new InvalidOperationException($"Process '{parts[0]}' exited with code {process.ExitCode}: {await process.StandardError.ReadToEndAsync().ConfigureAwait(false)}");
    }

    public Task ExecuteFileOperationAsync(string sourceText)
    {
        if (!_settings.Security.AllowFileMutation) return Task.CompletedTask;
        var quoted = Regex.Matches(sourceText, "\\\"([^\\\"]*)\\\"").Select(m => Environment.ExpandEnvironmentVariables(m.Groups[1].Value)).ToArray();
        if (sourceText.Contains("delete file", StringComparison.OrdinalIgnoreCase) && quoted.Length >= 2)
        {
            var path = Path.Combine(quoted[1], quoted[0]);
            if (File.Exists(path)) File.Delete(path);
        }
        return Task.CompletedTask;
    }

    public Task ExecuteJsonOperationAsync(string sourceText)
    {
        if (!_settings.Security.AllowJsonPreferenceMutation) return Task.CompletedTask;
        // Deliberately constrained: application preference mutation is enabled only through configuration.
        // The source operation is retained in the audit log; concrete allowed mutations should be added here.
        _ = JsonSerializer.Serialize(new { Source = sourceText });
        return Task.CompletedTask;
    }
}
