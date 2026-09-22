using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.Reporting;
using PnCTestAutomation.TestPlanPublisher;

namespace PnCTestAutomation.SgsReport;

public sealed record SgsReportOptions(
    string EvidenceRoot,
    string CanonicalResultPath,
    string OutputDirectory)
{
    public ImmutableArray<string> ScenarioRoots { get; init; } = [];
    public ReportLimits Limits { get; init; } = new();
}

public sealed record SgsReportResult(int ExitCode, string ReportPath, ConsolidatedReport Report);

public sealed class ReportAggregator
{
    private readonly ReportRedactor _redactor;

    public ReportAggregator(ReportRedactor? redactor = null) =>
        _redactor = redactor ?? new ReportRedactor();

    public SgsReportResult Generate(SgsReportOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        options.Limits.Validate();
        var root = ReportPaths.SafeRoot(options.EvidenceRoot);
        var output = ArtifactPathGuard.EnsureSafe(root, Path.GetFullPath(options.OutputDirectory));
        var canonicalPath = ReportPaths.SafeRoot(options.CanonicalResultPath);
        var outputNames = new[] { "report.html", "log.html", "output.xml", "summary.json" };
        if (outputNames.Any(name => SamePath(Path.Combine(output, name), canonicalPath)))
            throw new ArtifactEvidenceException("Report output cannot overwrite the canonical execution input.");

        var issues = ImmutableArray.CreateBuilder<ReportIssue>();
        IReadOnlyList<CanonicalReportResult> canonical = [];
        try
        {
            canonical = new CanonicalResultLoader().LoadReportResults(canonicalPath);
        }
        catch (TestPlanPublicationException exception)
        {
            issues.Add(new ReportIssue("canonical-input", _redactor.Text(exception.Message)));
        }

        var roots = ScenarioRoots(options, root, issues);
        var reader = new ReportEvidenceReader(options.Limits, _redactor);
        var candidates = new List<Candidate>();
        var copies = ImmutableArray.CreateBuilder<string>();
        foreach (var scenarioRoot in FindScenarioDirectories(roots, root, output, issues)
                     .OrderBy(path => path.Length).ThenBy(path => path, StringComparer.OrdinalIgnoreCase))
        {
            if (SamePath(Path.GetDirectoryName(ReportPaths.Resolve(scenarioRoot, ScenarioReportWriter.ReportRelativePath))!, output))
                throw new ArtifactEvidenceException("Consolidated output cannot overwrite an individual scenario report.");
            var source = Path.GetRelativePath(root, Path.Combine(scenarioRoot, "manifest.json")).Replace('\\', '/');
            try
            {
                var manifest = ReportJson.Deserialize<ArtifactManifest>(
                    ReportEvidenceReader.ReadJson(scenarioRoot, "manifest.json", options.Limits.MaxInputJsonBytes));
                var projectionJson = ReportEvidenceReader.ReadJson(
                    scenarioRoot, ScenarioReportWriter.ResultRelativePath, options.Limits.MaxInputJsonBytes);
                var saved = ReportJson.Deserialize<ScenarioReportProjection>(projectionJson);
                var projection = ScenarioReportProjector.Project(manifest, saved.ToMetadata(), _redactor);
                var displayIdentity = Safe(saved.TestFullName);
                var validDisplayIdentity = IsRedactedIdentity(projection.TestFullName, displayIdentity);
                projection = projection with
                {
                    RunId = RedactedDisplay(projection.RunId, saved.RunId),
                    ScenarioId = RedactedDisplay(projection.ScenarioId, saved.ScenarioId),
                    AutomationId = RedactedDisplay(projection.AutomationId, saved.AutomationId),
                    ProfileName = RedactedDisplay(projection.ProfileName, saved.ProfileName),
                    TestFullName = validDisplayIdentity ? displayIdentity : projection.TestFullName
                };
                var projectionMatches = validDisplayIdentity && JsonNode.DeepEquals(
                    JsonNode.Parse(projectionJson), JsonNode.Parse(ReportJson.Serialize(projection)));
                if (!validDisplayIdentity)
                    projection = projection with { TestFullName = $"Execution {projection.TestIdentityHash[..12]}" };
                if (!projectionMatches)
                    issues.Add(new ReportIssue("projection-mismatch",
                        $"Scenario projection does not match its finalized manifest: {Safe(source)}.", projection.TestFullName));

                var duplicate = candidates.FirstOrDefault(item =>
                    item.Projection.ManifestFingerprint == projection.ManifestFingerprint);
                if (duplicate != null && SameEvidence(duplicate.Directory, scenarioRoot, manifest))
                {
                    copies.Add(Safe(source));
                    continue;
                }
                var evidence = reader.Read(projection, scenarioRoot, root, output);
                if (!projectionMatches)
                    evidence = evidence with
                    {
                        Files = evidence.Files.Select(file => file.Kind is "ScenarioReportHtml" or "ScenarioResultJson"
                            ? file with { Href = null } : file).ToImmutableArray()
                    };
                issues.AddRange(evidence.Issues);
                RequireOutput(projection, evidence, "ScenarioReportHtml", ScenarioReportWriter.ReportRelativePath);
                RequireOutput(projection, evidence, "ScenarioResultJson", ScenarioReportWriter.ResultRelativePath);
                candidates.Add(new Candidate(
                    scenarioRoot, manifest, new ScenarioReportView(projection, evidence, Safe(source))));
            }
            catch (Exception exception) when (exception is JsonException or IOException or UnauthorizedAccessException
                or ArgumentException or InvalidOperationException or ArtifactEvidenceException)
            {
                issues.Add(new ReportIssue("scenario-input",
                    $"Cannot use scenario evidence {Safe(source)}: {Safe(exception.Message)}"));
            }
        }
        if (candidates.Count == 0)
            issues.Add(new ReportIssue("missing-scenarios", "No finalized canonical scenario manifests and report projections were available."));
        var canonicalHashes = canonical.Select(item => ScenarioReportProjector.IdentityHash(item.TestIdentity))
            .ToHashSet(StringComparer.Ordinal);
        var unmatched = candidates.Where(item => !canonicalHashes.Contains(item.Projection.TestIdentityHash)).ToArray();
        foreach (var candidate in unmatched)
            issues.Add(new ReportIssue("unexpected-scenario",
                $"Evidence is absent from the canonical result: {candidate.View.SourcePath}.", candidate.Projection.TestFullName));
        var tests = ImmutableArray.CreateBuilder<ReportTestResult>();
        foreach (var result in canonical)
        {
            var hash = ScenarioReportProjector.IdentityHash(result.TestIdentity);
            var matches = candidates.Where(item => item.Projection.TestIdentityHash == hash)
                .OrderBy(item => item.Projection.AttemptNumber).ToArray();
            var identity = matches.LastOrDefault()?.Projection.TestFullName ?? $"Unmatched execution {hash[..12]}";
            if (matches.Length == 0)
                issues.Add(new ReportIssue("missing-scenario", "Canonical execution has no finalized manifest/report projection.", identity));
            else
                Reconcile(result, matches, issues);
            tests.Add(new ReportTestResult(identity, Status(result.Outcome), result.Duration.TotalMilliseconds,
                matches.Select(item => item.View).ToImmutableArray(), FailureMessage(result, matches)));
        }
        var duplicateIds = candidates.GroupBy(item => item.Manifest.AutomationId, StringComparer.Ordinal)
            .Where(group => group.Select(item => item.Projection.TestIdentityHash).Distinct().Count() > 1);
        foreach (var group in duplicateIds)
            issues.Add(new ReportIssue("duplicate-automation-id",
                $"Multiple canonical identities share automation ID {Safe(group.Key)}."));
        var report = new ConsolidatedReport(DateTimeOffset.UtcNow, tests.ToImmutable(), issues.ToImmutable(),
            unmatched.Select(item => item.View).ToImmutableArray())
        {
            DuplicateCopies = copies.ToImmutable()
        };
        var documents = ConsolidatedReportRenderer.Render(report, options.Limits, _redactor);
        ReportPaths.WriteAtomic(root, Path.GetRelativePath(root, Path.Combine(output, "report.html")), documents.Html);
        ReportPaths.WriteAtomic(root, Path.GetRelativePath(root, Path.Combine(output, "log.html")), documents.LogHtml);
        ReportPaths.WriteAtomic(root, Path.GetRelativePath(root, Path.Combine(output, "output.xml")), documents.OutputXml);
        ReportPaths.WriteAtomic(root, Path.GetRelativePath(root, Path.Combine(output, "summary.json")), documents.SummaryJson);
        var exit = report.Issues.Length > 0 ? 2 :
            report.Tests.Any(item => item.Status != ReportStatus.Pass) ? 1 : 0;
        return new SgsReportResult(exit, Path.Combine(output, "report.html"), report);

        void RequireOutput(ScenarioReportProjection projection, ScenarioReportEvidence evidence, string kind, string path)
        {
            if (!evidence.Files.Any(file => file.Kind == kind && file.RelativePath == path))
                issues.Add(new ReportIssue("required-projection",
                    $"Required scenario output is missing or unregistered: {path}.", projection.TestFullName));
        }
    }

    private static ImmutableArray<string> ScenarioRoots(
        SgsReportOptions options, string root, ImmutableArray<ReportIssue>.Builder issues)
    {
        var supplied = options.ScenarioRoots.IsDefaultOrEmpty ? [root] : options.ScenarioRoots;
        var roots = ImmutableArray.CreateBuilder<string>();
        foreach (var input in supplied)
        {
            try
            {
                var candidate = ArtifactPathGuard.EnsureSafe(root,
                    Path.IsPathRooted(input) ? Path.GetFullPath(input) : ReportPaths.Resolve(root, input));
                if (!Directory.Exists(candidate))
                    throw new ArtifactEvidenceException("A selected scenario root does not exist.");
                if (roots.Any(previous => Contains(previous, candidate) || Contains(candidate, previous)))
                    throw new ArtifactEvidenceException("Selected scenario roots must not overlap.");
                roots.Add(candidate);
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or ArtifactEvidenceException or ArgumentException)
            {
                issues.Add(new ReportIssue("scenario-root", "A selected scenario root is missing, unsafe or overlaps another root."));
            }
        }
        return roots.ToImmutable();
    }

    private static IEnumerable<string> FindScenarioDirectories(
        ImmutableArray<string> roots, string packageRoot, string output, ImmutableArray<ReportIssue>.Builder issues)
    {
        var pending = new Stack<string>(roots);
        while (pending.TryPop(out var directory))
        {
            string[] directories;
            bool found;
            try
            {
                _ = ArtifactPathGuard.EnsureSafe(packageRoot, directory);
                if (SamePath(directory, output) && !SamePath(directory, packageRoot))
                    continue;
                found = File.Exists(Path.Combine(directory, "manifest.json"));
                directories = Directory.GetDirectories(directory);
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or ArtifactEvidenceException)
            {
                issues.Add(new ReportIssue("unsafe-directory", "Evidence discovery encountered an unreadable directory or reparse point."));
                continue;
            }
            if (found)
            {
                yield return directory;
                // Artifact subdirectories are not independent scenario owners.
                continue;
            }
            foreach (var child in directories)
                pending.Push(child);
        }
    }

    private void Reconcile(CanonicalReportResult canonical, Candidate[] candidates,
        ImmutableArray<ReportIssue>.Builder issues)
    {
        var identity = candidates[^1].Projection.TestFullName;
        if (candidates.Select(item => item.Manifest.RunId).Distinct(StringComparer.Ordinal).Count() != 1 ||
            candidates.Select(item => item.Projection.ExecutionId).Distinct(StringComparer.Ordinal).Count() != 1)
            issues.Add(new ReportIssue("ambiguous-execution", "Scenario evidence mixes separate runs or execution groups.", identity));
        var numbers = candidates.Select(item => item.Projection.AttemptNumber).ToArray();
        if (numbers.Distinct().Count() != numbers.Length)
            issues.Add(new ReportIssue("duplicate-attempt",
                "Duplicate actual attempt numbers; files: " + string.Join("; ", candidates.Select(item => item.View.SourcePath)), identity));
        if (!numbers.SequenceEqual(Enumerable.Range(1, numbers.Length)))
            issues.Add(new ReportIssue("missing-attempt", "Actual attempt numbers must be contiguous starting at one; no missing attempt is synthesized.", identity));
        for (var index = 1; index < candidates.Length; index++)
        {
            if (candidates[index].Projection.StartedAtUtc < candidates[index - 1].Projection.CompletedAtUtc)
                issues.Add(new ReportIssue("attempt-timing", "Sequential retry attempts overlap or are chronologically reversed.", identity));
        }
        if (candidates[^1].Projection.Status != Status(canonical.Outcome))
            issues.Add(new ReportIssue("outcome-mismatch",
                $"Final manifest outcome {candidates[^1].Projection.Status.Text()} differs from canonical {Status(canonical.Outcome).Text()}; no result is repaired.", identity));
    }

    private string FailureMessage(CanonicalReportResult canonical, Candidate[] candidates)
    {
        if (canonical.Outcome == CanonicalReportOutcome.Passed)
            return "";
        // Only the scenario process knows generated PII and runtime tokens. Do not republish raw TRX assertion text.
        var projection = candidates.LastOrDefault()?.Projection;
        var diagnostic = projection?.Diagnostics.LastOrDefault(item =>
            item.Component is "scenario" or "preflight" && item.Level is "error" or "skip")?.Message;
        var stepError = projection?.Steps.LastOrDefault(item => item.Status == ReportStatus.Fail)?.Error;
        return Safe(new[] { diagnostic, stepError }.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value))
            ?? "Canonical execution did not pass; no scenario-redacted failure detail was recorded.");
    }

    private static bool IsRedactedIdentity(string canonical, string display)
    {
        // The scenario knows PII unavailable to the later CLI. Only additional masking is permitted.
        var parts = display.Split(ReportRedactor.Mask, StringSplitOptions.None);
        if (parts.Length == 1)
            return canonical.Equals(display, StringComparison.Ordinal);
        if (!canonical.StartsWith(parts[0], StringComparison.Ordinal))
            return false;
        var offset = parts[0].Length;
        foreach (var part in parts.Skip(1).SkipLast(1))
        {
            var next = canonical.IndexOf(part, offset, StringComparison.Ordinal);
            if (next < 0)
                return false;
            offset = next + part.Length;
        }
        return canonical.Length - offset >= parts[^1].Length &&
            canonical.EndsWith(parts[^1], StringComparison.Ordinal);
    }

    private string RedactedDisplay(string canonical, string saved)
    {
        var display = Safe(saved);
        return IsRedactedIdentity(canonical, display) ? display : canonical;
    }

    private static bool SameEvidence(string first, string second, ArtifactManifest manifest)
    {
        var paths = manifest.Artifacts.Where(item => item.RelativePath != null).Select(item => item.RelativePath!)
            .Append("manifest.json").Append(ScenarioReportWriter.ResultRelativePath).Append(ScenarioReportWriter.ReportRelativePath)
            .Distinct(StringComparer.OrdinalIgnoreCase);
        foreach (var relative in paths)
        {
            var left = ReportPaths.Resolve(first, relative);
            var right = ReportPaths.Resolve(second, relative);
            if (!File.Exists(left) || !File.Exists(right))
                return false;
            var a = new FileInfo(left);
            var b = new FileInfo(right);
            if (a.Length == 0 || a.Length != b.Length)
                return false;
            using var leftStream = File.OpenRead(left);
            using var rightStream = File.OpenRead(right);
            if (!SHA256.HashData(leftStream).AsSpan().SequenceEqual(SHA256.HashData(rightStream)))
                return false;
        }
        return true;
    }

    private static bool Contains(string parent, string child) =>
        SamePath(parent, child) || child.StartsWith(
            Path.TrimEndingDirectorySeparator(parent) + Path.DirectorySeparatorChar, PathComparison);
    private static bool SamePath(string left, string right) =>
        Path.TrimEndingDirectorySeparator(left).Equals(Path.TrimEndingDirectorySeparator(right), PathComparison);
    private static StringComparison PathComparison => OperatingSystem.IsWindows()
        ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    private string Safe(string? text) => _redactor.Text(text);
    private static ReportStatus Status(CanonicalReportOutcome outcome) => outcome switch
    {
        CanonicalReportOutcome.Passed => ReportStatus.Pass,
        CanonicalReportOutcome.Failed => ReportStatus.Fail,
        CanonicalReportOutcome.Skipped => ReportStatus.Skip,
        _ => throw new ArgumentOutOfRangeException(nameof(outcome))
    };
    private sealed record Candidate(string Directory, ArtifactManifest Manifest, ScenarioReportView View)
    {
        internal ScenarioReportProjection Projection => View.Projection;
    }
}
