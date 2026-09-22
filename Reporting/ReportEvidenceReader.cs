#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Reporting;

public sealed class ReportEvidenceReader
{
    private readonly ReportLimits _limits;
    private readonly ReportRedactor _redactor;
    private long _remainingImageBytes;

    public ReportEvidenceReader(ReportLimits? limits = null, ReportRedactor? redactor = null)
    {
        _limits = limits ?? new ReportLimits();
        _limits.Validate();
        _redactor = redactor ?? new ReportRedactor();
        _remainingImageBytes = _limits.MaxEmbeddedImageBytes;
    }

    public ScenarioReportEvidence Read(
        ScenarioReportProjection projection,
        string scenarioRoot,
        string packageRoot,
        string documentDirectory,
        bool generatingScenarioDocuments = false)
    {
        ArgumentNullException.ThrowIfNull(projection);
        var root = ReportPaths.SafeRoot(packageRoot);
        scenarioRoot = ArtifactPathGuard.EnsureSafe(root, Path.GetFullPath(scenarioRoot));
        _ = ArtifactPathGuard.EnsureSafe(root, Path.GetFullPath(documentDirectory));
        var files = ImmutableArray.CreateBuilder<ReportEvidenceFile>();
        var issues = ImmutableArray.CreateBuilder<ReportIssue>();
        issues.AddRange(ScenarioReportProjector.FindConsistencyIssues(projection));
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var imageCount = 0;

        foreach (var reference in projection.Artifacts)
        {
            if (reference.RelativePath == null)
                continue;
            var relative = ReportPaths.NormalizeRelative(reference.RelativePath);
            if (!seen.Add(relative))
            {
                AddIssue("duplicate-evidence", "Multiple artifact records point at the same file.");
                continue;
            }
            if (generatingScenarioDocuments && IsGeneratedDocument(reference.Kind, relative))
                continue;
            try
            {
                var path = ReportPaths.Resolve(scenarioRoot, relative);
                var info = new FileInfo(path);
                if (!info.Exists || info.Length == 0)
                {
                    AddIssue("missing-evidence", $"Recorded {reference.Kind} evidence is missing or empty: {relative}.");
                    continue;
                }
                var href = ReportPaths.Href(root, documentDirectory, path);
                string? image = null;
                string? text = null;
                var truncated = false;
                if (reference.Kind == "ScenarioReportHtml")
                {
                    var html = Encoding.UTF8.GetString(ReadBounded(path, _limits.MaxReportHtmlBytes));
                    if (!html.Contains(ManifestMarker(projection), StringComparison.Ordinal))
                    {
                        AddIssue("html-projection-mismatch", "Individual report HTML is corrupt or belongs to another canonical manifest.");
                        href = null;
                    }
                }
                if (reference.Kind == "Screenshot" && ImageMime(path) == null ||
                    reference.Kind == "Video" && !new[] { ".webm", ".mp4", ".ogg", ".mov" }
                        .Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase))
                {
                    AddIssue("unsupported-media", "Recorded screenshot or video has an unsupported media extension.");
                    continue;
                }
                if (reference.Kind == "Screenshot" && imageCount < _limits.MaxImagesPerScenario &&
                    info.Length <= _limits.MaxImageBytes && info.Length <= _remainingImageBytes)
                {
                    var mime = ImageMime(path);
                    if (mime != null)
                    {
                        var bytes = ReadBounded(path, _limits.MaxImageBytes);
                        image = $"data:{mime};base64,{Convert.ToBase64String(bytes)}";
                        _remainingImageBytes -= bytes.Length;
                        imageCount++;
                    }
                }
                if (reference.Kind is "ExecutionLog" or "ConsoleLog" or "NetworkLog" ||
                    reference.Kind == "Trace" && Path.GetExtension(path).Equals(".log", StringComparison.OrdinalIgnoreCase))
                {
                    var bytes = ReadPrefix(path, _limits.MaxLogBytes, out truncated);
                    var original = Encoding.UTF8.GetString(bytes);
                    text = _redactor.Text(original);
                    // Never expose a direct link to an unredacted or only partially inspected log.
                    if (truncated || text != original)
                        href = null;
                }
                files.Add(new ReportEvidenceFile(
                    reference.Kind, _redactor.Text(reference.Checkpoint), relative, href,
                    info.Length, image, text, truncated));
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or ArtifactEvidenceException)
            {
                AddIssue("unreadable-evidence", $"Cannot safely read {reference.Kind} evidence: {relative} ({exception.GetType().Name}).");
            }
        }
        foreach (var kind in projection.RequiredEvidence)
        {
            if (generatingScenarioDocuments && kind is "ScenarioReportHtml" or "ScenarioResultJson")
                continue;
            if (!files.Any(item => item.Kind == kind))
                AddIssue("required-evidence", $"Missing required evidence: {kind}.");
        }
        var screenshots = files.Where(item => item.Kind == "Screenshot")
            .Select(item => item.RelativePath).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var references = projection.Steps.SelectMany(item => item.Screenshots)
            .Concat(projection.DeferredVerifications
                .Where(item => item.Screenshot != null).Select(item => item.Screenshot!));
        foreach (var screenshot in references.Distinct(StringComparer.OrdinalIgnoreCase))
            if (!screenshots.Contains(ReportPaths.NormalizeRelative(screenshot)))
                AddIssue("step-evidence", "A business step or deferred failure references an unavailable screenshot.");
        return new ScenarioReportEvidence(files.ToImmutable(), issues.ToImmutable());

        void AddIssue(string code, string message) =>
            issues.Add(new ReportIssue(code, _redactor.Text(message), projection.TestFullName));
    }

    public static bool IsGeneratedDocument(string kind, string relative) =>
        kind == "ScenarioReportHtml" && relative == ScenarioReportWriter.ReportRelativePath ||
        kind == "ScenarioResultJson" && relative == ScenarioReportWriter.ResultRelativePath;

    public static string ManifestMarker(ScenarioReportProjection projection) =>
        $"data-pnc-manifest=\"{WebUtility.HtmlEncode(projection.ManifestFingerprint)}\" data-pnc-status=\"{projection.Status.Text()}\"";

    public static string ReadJson(string root, string relative, int limit)
    {
        var path = ReportPaths.Resolve(root, relative);
        return Encoding.UTF8.GetString(ReadBounded(path, limit));
    }

    private static byte[] ReadBounded(string path, int maximum)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream.Length == 0 || stream.Length > maximum)
            throw new IOException("The evidence file is empty or exceeds the reporting input limit.");
        var bytes = new byte[checked((int)stream.Length)];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1)
            throw new IOException("The evidence file changed while being read.");
        return bytes;
    }

    private static byte[] ReadPrefix(string path, int maximum, out bool truncated)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        truncated = stream.Length > maximum;
        var bytes = new byte[(int)Math.Min(stream.Length, maximum)];
        stream.ReadExactly(bytes);
        if (!truncated)
            return bytes;
        // Drop the partial final line rather than risk retaining a severed credential value.
        var lastNewline = Array.LastIndexOf(bytes, (byte)'\n');
        return lastNewline < 0 ? [] : bytes[..(lastNewline + 1)];
    }

    private static string? ImageMime(string path) => Path.GetExtension(path).ToLowerInvariant() switch
    {
        ".png" => "image/png",
        ".jpg" or ".jpeg" => "image/jpeg",
        ".gif" => "image/gif",
        ".webp" => "image/webp",
        _ => null
    };
}
