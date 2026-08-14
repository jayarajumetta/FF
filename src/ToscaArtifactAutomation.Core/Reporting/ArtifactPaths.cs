using System.Text.RegularExpressions;
using ToscaArtifactAutomation.Core.Configuration;

namespace ToscaArtifactAutomation.Core.Reporting;

public static class ArtifactPaths
{
    public static string RunId { get; } = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss-fff");

    public static string RunRoot(FrameworkSettings settings)
    {
        var configured = settings.ArtifactsRoot.Replace('/', Path.DirectorySeparatorChar);
        var basePath = Path.IsPathRooted(configured) ? configured : Path.Combine(AppContext.BaseDirectory, configured);
        var path = Path.Combine(basePath, RunId);
        Directory.CreateDirectory(path);
        return path;
    }

    public static string CreateScenarioDirectory(FrameworkSettings settings, string scenarioId, string title)
    {
        var path = Path.Combine(RunRoot(settings), SafeName(title) + "-" + SafeName(scenarioId)[..Math.Min(8, SafeName(scenarioId).Length)]);
        Directory.CreateDirectory(path);
        return path;
    }

    public static string SafeName(string value)
    {
        value ??= "artifact";
        var safe = Regex.Replace(value, @"[^A-Za-z0-9._-]+", "_").Trim('_');
        return string.IsNullOrWhiteSpace(safe) ? "artifact" : safe;
    }
}
