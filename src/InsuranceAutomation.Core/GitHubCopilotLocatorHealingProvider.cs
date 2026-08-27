using System.Diagnostics;

namespace InsuranceAutomation.Core;

public sealed class GitHubCopilotLocatorHealingProvider : ILocatorHealingProvider
{
    private readonly FrameworkConfig _config;

    public GitHubCopilotLocatorHealingProvider(FrameworkConfig config) => _config = config;

    public string Name => "github-copilot";

    public bool IsAvailable(out string reason)
    {
        if (string.IsNullOrWhiteSpace(_config.SelfHeal.CopilotExecutable))
        {
            reason = "selfHeal.copilotExecutable is not configured.";
            return false;
        }
        reason = string.Empty;
        return true;
    }

    public async Task<string> ProposeAsync(LocatorHealingProviderRequest request, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(request.EvidenceDirectory);
        await File.WriteAllTextAsync(Path.Combine(request.EvidenceDirectory, "copilot-locator-prompt.txt"), request.Prompt, cancellationToken);
        if (request.Screenshot.Length > 0)
            await File.WriteAllBytesAsync(Path.Combine(request.EvidenceDirectory, "current-screen.png"), request.Screenshot, cancellationToken);

        var psi = new ProcessStartInfo
        {
            FileName = _config.SelfHeal.CopilotExecutable,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        psi.ArgumentList.Add("-p");
        psi.ArgumentList.Add(request.Prompt);
        psi.ArgumentList.Add("-s");
        psi.ArgumentList.Add("--no-ask-user");

        using var process = Process.Start(psi) ?? throw new InvalidOperationException("Unable to start GitHub Copilot CLI.");
        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync(cancellationToken);
        var stdout = await stdoutTask;
        var stderr = await stderrTask;
        if (process.ExitCode != 0)
            throw new InvalidOperationException($"GitHub Copilot CLI failed ({process.ExitCode}): {stderr}");
        return stdout;
    }
}
