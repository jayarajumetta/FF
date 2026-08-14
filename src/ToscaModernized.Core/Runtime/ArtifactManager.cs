using System.Text.Json;
using Microsoft.Playwright;

namespace ToscaModernized.Core.Runtime;

public sealed class ArtifactManager
{
    private readonly string _runDirectory;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = false };

    public ArtifactManager(string artifactRoot, string runId, string featureTitle, string scenarioTitle)
    {
        _runDirectory = Path.Combine(artifactRoot, Sanitize(featureTitle), Sanitize(scenarioTitle), runId);
        Directory.CreateDirectory(_runDirectory);
    }

    public async Task WriteAuditAsync(object entry)
    {
        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
            await File.AppendAllTextAsync(Path.Combine(_runDirectory, "execution.jsonl"), JsonSerializer.Serialize(entry, _jsonOptions) + Environment.NewLine).ConfigureAwait(false);
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task WriteRunDataAsync(IReadOnlyDictionary<string, string> values)
    {
        var redacted = values.ToDictionary(
            pair => pair.Key,
            pair => pair.Key.Contains("password", StringComparison.OrdinalIgnoreCase) ? "***" : pair.Value,
            StringComparer.OrdinalIgnoreCase);
        await File.WriteAllTextAsync(Path.Combine(_runDirectory, "run-data.json"), JsonSerializer.Serialize(redacted, new JsonSerializerOptions { WriteIndented = true })).ConfigureAwait(false);
    }

    public async Task ScreenshotAsync(IPage page, string name)
    {
        await page.ScreenshotAsync(new() { Path = Path.Combine(_runDirectory, Sanitize(name) + ".png"), FullPage = true }).ConfigureAwait(false);
    }

    private static string Sanitize(string value)
    {
        var invalid = Path.GetInvalidFileNameChars();
        var chars = value.Select(ch => invalid.Contains(ch) ? '_' : ch).ToArray();
        var result = new string(chars).Trim();
        return string.IsNullOrWhiteSpace(result) ? "unnamed" : result[..Math.Min(result.Length, 120)];
    }
}
