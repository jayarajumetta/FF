using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalFormsPackageStatus
    {
        Generated,
        Blocked,
        ManualReviewRequired,
        Failed
    }

    internal enum CanonicalPackageWriteStage
    {
        AfterTemporaryPackageWritten,
        AfterExistingPackageBackedUp
    }

    public sealed class CanonicalFormsPipelineRequest
    {
        public string SfpWorkbookPath { get; init; } = "";
        public string CommonWorkbookPath { get; init; } = "";
        public string ApprovedBaselinePath { get; init; } = "";
        public string BasicFeaturePath { get; init; } = "";
        public string CountryEstateFeaturePath { get; init; } = "";
        public string PendingStateProfilePath { get; init; }
        public string OutputDirectory { get; init; }
        public string Lob { get; init; } = "SFP";
        public DateOnly EffectiveDate { get; init; } = new(2027, 4, 3);
        public string GeneratorVersion { get; init; } = "";
        public IReadOnlyDictionary<string, string> RuleVersions { get; init; } =
            new Dictionary<string, string>(StringComparer.Ordinal);
    }

    public sealed class CanonicalFormsPipelineOptions
    {
        public bool AllowReviewedChanges { get; init; }
        public bool OverwriteExisting { get; init; }
        public bool WritePackage { get; init; } = true;
        public DateTimeOffset? GenerationTimestampUtc { get; init; }
        internal Action AfterWorkbookParse { get; init; }
        internal CanonicalPackageWriteStage? InjectFailureAt { get; init; }
    }

    public sealed class CanonicalFormsPackagePaths
    {
        public string PackageDirectory { get; init; }
        public string CandidatePath { get; init; }
        public string ManifestPath { get; init; }
        public string SemanticJsonPath { get; init; }
        public string SemanticMarkdownPath { get; init; }
    }

    public sealed class CanonicalFormsPipelineResult
    {
        public CanonicalFormsPackageStatus Status { get; init; }
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalInputArtifact> InputArtifacts { get; init; } =
            Array.Empty<CanonicalInputArtifact>();
        public string PackageCorrelationId { get; init; }
        public string ProjectionSha256 { get; init; }
        public CanonicalExpectedProjection Projection { get; init; }
        public CanonicalSemanticReportContent SemanticReport { get; init; }
        public CanonicalCandidateEmissionResult Candidate { get; init; }
        public CanonicalFormsPackagePaths Paths { get; init; }
    }

    public static class CanonicalFormsPipeline
    {
        public const string CandidateFileName = "SFP_CANONICAL_CANDIDATE.json";
        public const string ManifestFileName = "SFP_CANONICAL_CANDIDATE.manifest.json";
        public const string SemanticJsonFileName = "semantic-comparison.json";
        public const string SemanticMarkdownFileName = "semantic-comparison.md";

        public static CanonicalFormsPipelineResult Run(
            CanonicalFormsPipelineRequest request,
            CanonicalFormsPipelineOptions options = null)
        {
            options ??= new CanonicalFormsPipelineOptions();
            var artifacts = new List<CanonicalInputArtifact>();
            CanonicalExpectedProjection projection = null;
            CanonicalSemanticReportContent report = null;
            try
            {
                ValidateRequest(request);
                var projectRoot = DefaultProjectRoot();
                var outputDirectory = ResolveOutputDirectory(request, projectRoot);
                if (options.WritePackage)
                    ValidateOutputDirectory(outputDirectory, request.ApprovedBaselinePath);

                var sfpSnapshot = Capture(request.SfpWorkbookPath, "SfpWorkbook");
                var commonSnapshot = Capture(request.CommonWorkbookPath, "CommonWorkbook");
                var approvedSnapshot = Capture(
                    request.ApprovedBaselinePath,
                    "ApprovedBaseline");
                var basicFeatureSnapshot = Capture(
                    request.BasicFeaturePath,
                    "BasicFeature");
                var ceFeatureSnapshot = Capture(
                    request.CountryEstateFeaturePath,
                    "CountryEstateFeature");
                artifacts.AddRange(new[]
                {
                    sfpSnapshot.Artifact,
                    commonSnapshot.Artifact,
                    approvedSnapshot.Artifact,
                    basicFeatureSnapshot.Artifact,
                    ceFeatureSnapshot.Artifact
                });
                if (!string.IsNullOrWhiteSpace(request.PendingStateProfilePath))
                {
                    artifacts.Add(Capture(
                        request.PendingStateProfilePath,
                        "PendingStateProfile").Artifact);
                }

                var basicProfiles = ScenarioProfileLoader.LoadBasic(
                    request.BasicFeaturePath,
                    request.EffectiveDate);
                var ceProfiles = ScenarioProfileLoader.LoadCountryEstate(
                    request.CountryEstateFeaturePath,
                    request.EffectiveDate);
                ValidatePendingStateProfile(
                    request.PendingStateProfilePath,
                    basicProfiles,
                    ceProfiles);
                var configuredStates = basicProfiles
                    .Concat(ceProfiles)
                    .Select(profile => profile.State)
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(state => state, StringComparer.Ordinal)
                    .ToArray();
                var parserOptions = new ParserOptions
                {
                    RecognizedStateColumns = configuredStates
                };
                var parser = new ExcelFormsParser();
                var sourceRows = parser.ParseCanonical(
                        request.SfpWorkbookPath,
                        parserOptions)
                    .Concat(parser.ParseCommonFormsCanonical(
                        request.CommonWorkbookPath,
                        request.Lob,
                        parserOptions))
                    .ToArray();

                options.AfterWorkbookParse?.Invoke();
                EnsureUnchanged(sfpSnapshot);
                EnsureUnchanged(commonSnapshot);

                var candidates = new List<CanonicalEditionCandidate>();
                foreach (var aggregate in CanonicalFormAggregator.Aggregate(sourceRows))
                {
                    var interpretation =
                        CanonicalApplicabilityInterpreter.Interpret(aggregate);
                    foreach (var profile in basicProfiles.Concat(ceProfiles))
                    {
                        candidates.Add(new CanonicalEditionCandidate(
                            aggregate,
                            CanonicalScenarioEligibilityEvaluator.Evaluate(
                                aggregate,
                                interpretation,
                                profile)));
                    }
                }

                var editions = CanonicalEditionLifecycleResolver.Resolve(candidates);
                projection = CanonicalExpectedRecordProjector.Project(editions);
                var approvedJson = File.ReadAllText(request.ApprovedBaselinePath);
                report = CanonicalSemanticComparisonService.CreateReport(
                    approvedJson,
                    projection);
                var packageStatus = GateStatus(
                    projection,
                    report.Report,
                    options.AllowReviewedChanges);
                if (packageStatus != CanonicalFormsPackageStatus.Generated)
                {
                    return new CanonicalFormsPipelineResult
                    {
                        Status = packageStatus,
                        Reasons = GateReasons(
                            projection,
                            report.Report,
                            options.AllowReviewedChanges),
                        InputArtifacts = artifacts,
                        ProjectionSha256 = report.Report.ProjectionSha256,
                        Projection = projection,
                        SemanticReport = report
                    };
                }

                var workbookInputs = new[]
                {
                    new CanonicalSourceWorkbookInput(
                        sfpSnapshot.Artifact.Identity,
                        Path.GetFileName(sfpSnapshot.Path),
                        sfpSnapshot.Artifact.Sha256),
                    new CanonicalSourceWorkbookInput(
                        commonSnapshot.Artifact.Identity,
                        Path.GetFileName(commonSnapshot.Path),
                        commonSnapshot.Artifact.Sha256)
                };
                var candidate = CanonicalCandidateEmitter.CreateCandidate(
                    new CanonicalCandidateEmissionRequest
                    {
                        Projection = projection,
                        BasicProfiles = basicProfiles,
                        CountryEstateProfiles = ceProfiles,
                        ComparisonReport = report.Report,
                        SourceWorkbooks = workbookInputs,
                        InputArtifacts = artifacts,
                        GeneratorVersion = request.GeneratorVersion,
                        RuleVersions = request.RuleVersions
                    },
                    new CanonicalCandidateEmissionOptions
                    {
                        AllowReviewedChanges = options.AllowReviewedChanges,
                        GenerationTimestampUtc = options.GenerationTimestampUtc
                    });

                CanonicalFormsPackagePaths paths = null;
                if (options.WritePackage)
                {
                    paths = WriteAtomicPackage(
                        outputDirectory,
                        candidate,
                        report,
                        options);
                }
                return new CanonicalFormsPipelineResult
                {
                    Status = CanonicalFormsPackageStatus.Generated,
                    InputArtifacts = artifacts,
                    PackageCorrelationId = candidate.PackageCorrelationId,
                    ProjectionSha256 = candidate.ProjectionSha256,
                    Projection = projection,
                    SemanticReport = report,
                    Candidate = candidate,
                    Paths = paths
                };
            }
            catch (InvalidOperationException exception)
            {
                return Failed(exception, artifacts, projection, report);
            }
            catch (IOException exception)
            {
                return Failed(exception, artifacts, projection, report);
            }
            catch (UnauthorizedAccessException exception)
            {
                return Failed(exception, artifacts, projection, report);
            }
            catch (JsonException exception)
            {
                return Failed(exception, artifacts, projection, report);
            }
            catch (ArgumentException exception)
            {
                return Failed(exception, artifacts, projection, report);
            }
        }

        private static CanonicalFormsPipelineResult Failed(
            Exception exception,
            IReadOnlyList<CanonicalInputArtifact> artifacts,
            CanonicalExpectedProjection projection,
            CanonicalSemanticReportContent report) =>
            new()
            {
                Status = CanonicalFormsPackageStatus.Failed,
                Reasons = new[] { exception.Message },
                InputArtifacts = artifacts,
                ProjectionSha256 = projection == null
                    ? null
                    : CanonicalProjectionFingerprint.Compute(projection),
                Projection = projection,
                SemanticReport = report
            };

        private static void ValidateRequest(CanonicalFormsPipelineRequest request)
        {
            if (request == null)
                throw new InvalidOperationException("Canonical pipeline request is required.");
            RequireFile(request.SfpWorkbookPath, "SFP workbook");
            RequireFile(request.CommonWorkbookPath, "Common workbook");
            RequireFile(request.ApprovedBaselinePath, "approved SFP baseline");
            RequireFile(request.BasicFeaturePath, "BASIC feature");
            RequireFile(request.CountryEstateFeaturePath, "CE feature");
            if (!string.IsNullOrWhiteSpace(request.PendingStateProfilePath))
                RequireFile(request.PendingStateProfilePath, "pending-state profile");
            if (string.IsNullOrWhiteSpace(request.Lob))
                throw new InvalidOperationException("LOB is required.");
            if (string.IsNullOrWhiteSpace(request.GeneratorVersion))
                throw new InvalidOperationException("GeneratorVersion is required.");
            if (request.RuleVersions == null || request.RuleVersions.Count == 0)
                throw new InvalidOperationException("RuleVersions are required.");
        }

        private static void RequireFile(string path, string label)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                throw new InvalidOperationException($"{label} file not found: '{path}'.");
        }

        private static FileSnapshot Capture(string path, string role)
        {
            var fullPath = Path.GetFullPath(path);
            var info = new FileInfo(fullPath);
            var hash = Convert.ToHexString(
                SHA256.HashData(File.ReadAllBytes(fullPath)));
            return new FileSnapshot(
                fullPath,
                info.Length,
                info.LastWriteTimeUtc,
                new CanonicalInputArtifact(
                    role,
                    Path.GetFileName(fullPath),
                    hash));
        }

        private static void EnsureUnchanged(FileSnapshot initial)
        {
            var current = Capture(initial.Path, initial.Artifact.Role);
            if (current.Length != initial.Length
                || current.LastWriteTimeUtc != initial.LastWriteTimeUtc
                || !current.Artifact.Sha256.Equals(
                    initial.Artifact.Sha256,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"Input workbook changed during canonical parsing: "
                    + $"{initial.Artifact.Identity}.");
            }
        }

        private static CanonicalFormsPackageStatus GateStatus(
            CanonicalExpectedProjection projection,
            CanonicalSemanticComparisonReport report,
            bool allowReviewedChanges)
        {
            if (projection.BlockedRecords.Count > 0
                || report.Findings.Any(finding =>
                    finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking
                    || finding.Category == CanonicalSemanticChangeCategory.StateRemoved))
            {
                return CanonicalFormsPackageStatus.Blocked;
            }
            if (!allowReviewedChanges
                && report.Findings.Any(finding =>
                    finding.Severity is CanonicalSemanticSeverity.ReviewRequired
                        or CanonicalSemanticSeverity.PotentiallyBreaking))
            {
                return CanonicalFormsPackageStatus.ManualReviewRequired;
            }
            return CanonicalFormsPackageStatus.Generated;
        }

        private static string[] GateReasons(
            CanonicalExpectedProjection projection,
            CanonicalSemanticComparisonReport report,
            bool allowReviewedChanges)
        {
            var reasons = new List<string>();
            if (projection.BlockedRecords.Count > 0)
            {
                reasons.Add(
                    $"Projection contains {projection.BlockedRecords.Count} blocked record(s).");
            }
            reasons.AddRange(report.Findings
                .Where(finding =>
                    finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking
                    || finding.Category == CanonicalSemanticChangeCategory.StateRemoved
                    || (!allowReviewedChanges
                        && finding.Severity
                            is CanonicalSemanticSeverity.ReviewRequired
                                or CanonicalSemanticSeverity.PotentiallyBreaking))
                .Select(finding =>
                    $"{finding.FindingId} {finding.Severity} {finding.Category}: "
                    + string.Join(" ", finding.Reasons)));
            return reasons.Distinct(StringComparer.Ordinal).ToArray();
        }

        private static string ResolveOutputDirectory(
            CanonicalFormsPipelineRequest request,
            string projectRoot) =>
            Path.GetFullPath(request.OutputDirectory
                ?? Path.Combine(
                    projectRoot,
                    "TestResults",
                    "FormsBaseline",
                    "CanonicalReviewPackage"));

        private static void ValidateOutputDirectory(
            string outputDirectory,
            string approvedBaselinePath)
        {
            var approvedDirectory = Path.GetFullPath(
                Path.GetDirectoryName(Path.GetFullPath(approvedBaselinePath))!);
            var output = Path.GetFullPath(outputDirectory);
            if (output.Equals(approvedDirectory, StringComparison.OrdinalIgnoreCase)
                || output.StartsWith(
                    approvedDirectory + Path.DirectorySeparatorChar,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Canonical review package output cannot be inside the approved "
                    + "Forms baseline directory.");
            }
        }

        private static CanonicalFormsPackagePaths WriteAtomicPackage(
            string outputDirectory,
            CanonicalCandidateEmissionResult candidate,
            CanonicalSemanticReportContent report,
            CanonicalFormsPipelineOptions options)
        {
            var parent = Path.GetDirectoryName(outputDirectory);
            if (string.IsNullOrWhiteSpace(parent))
                throw new InvalidOperationException("Package output directory is invalid.");
            Directory.CreateDirectory(parent);
            if ((Directory.Exists(outputDirectory) || File.Exists(outputDirectory))
                && !options.OverwriteExisting)
            {
                throw new InvalidOperationException(
                    "Canonical review package already exists. "
                    + "Set OverwriteExisting=true for an explicitly reviewed replacement.");
            }

            var temporary = outputDirectory + ".tmp-" + Guid.NewGuid().ToString("N");
            var backup = outputDirectory + ".backup-" + Guid.NewGuid().ToString("N");
            var backedUp = false;
            var committed = false;
            try
            {
                Directory.CreateDirectory(temporary);
                File.WriteAllText(
                    Path.Combine(temporary, CandidateFileName),
                    candidate.CandidateJson,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, ManifestFileName),
                    candidate.ManifestJson,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, SemanticJsonFileName),
                    report.Json,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, SemanticMarkdownFileName),
                    report.Markdown,
                    new UTF8Encoding(false));
                ThrowIfInjected(
                    options,
                    CanonicalPackageWriteStage.AfterTemporaryPackageWritten);

                if (Directory.Exists(outputDirectory))
                {
                    Directory.Move(outputDirectory, backup);
                    backedUp = true;
                    ThrowIfInjected(
                        options,
                        CanonicalPackageWriteStage.AfterExistingPackageBackedUp);
                }
                else if (File.Exists(outputDirectory))
                {
                    throw new InvalidOperationException(
                        "Package output path is an existing file.");
                }

                Directory.Move(temporary, outputDirectory);
                committed = true;
                if (backedUp)
                    Directory.Delete(backup, recursive: true);
            }
            catch
            {
                if (committed && backedUp && Directory.Exists(backup))
                {
                    if (Directory.Exists(outputDirectory))
                        Directory.Delete(outputDirectory, recursive: true);
                    Directory.Move(backup, outputDirectory);
                }
                else if (!Directory.Exists(outputDirectory)
                         && backedUp
                         && Directory.Exists(backup))
                {
                    Directory.Move(backup, outputDirectory);
                }
                if (Directory.Exists(temporary))
                    Directory.Delete(temporary, recursive: true);
                throw;
            }
            finally
            {
                if (Directory.Exists(temporary))
                    Directory.Delete(temporary, recursive: true);
                if (Directory.Exists(backup) && Directory.Exists(outputDirectory))
                    Directory.Delete(backup, recursive: true);
            }

            return new CanonicalFormsPackagePaths
            {
                PackageDirectory = outputDirectory,
                CandidatePath = Path.Combine(outputDirectory, CandidateFileName),
                ManifestPath = Path.Combine(outputDirectory, ManifestFileName),
                SemanticJsonPath = Path.Combine(outputDirectory, SemanticJsonFileName),
                SemanticMarkdownPath =
                    Path.Combine(outputDirectory, SemanticMarkdownFileName)
            };
        }

        private static void ThrowIfInjected(
            CanonicalFormsPipelineOptions options,
            CanonicalPackageWriteStage stage)
        {
            if (options.InjectFailureAt == stage)
                throw new IOException($"Injected package write failure at {stage}.");
        }

        private static void ValidatePendingStateProfile(
            string path,
            IReadOnlyList<ScenarioProfile> basic,
            IReadOnlyList<ScenarioProfile> ce)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;
            using var document = JsonDocument.Parse(
                File.ReadAllText(path),
                new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
            if (document.RootElement.ValueKind != JsonValueKind.Object)
                throw new InvalidOperationException("Pending-state profile must be a JSON object.");
            var configured = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal)
            {
                ["BASIC"] = basic.Select(profile => profile.State)
                    .ToHashSet(StringComparer.Ordinal),
                ["CE"] = ce.Select(profile => profile.State)
                    .ToHashSet(StringComparer.Ordinal)
            };
            foreach (var scenario in new[] { "BASIC", "CE" })
            {
                if (!document.RootElement.TryGetProperty(scenario, out var profile)
                    || profile.ValueKind != JsonValueKind.Object
                    || !profile.TryGetProperty("Status", out var status)
                    || status.GetString() != "ApprovedPendingConfiguration"
                    || !profile.TryGetProperty("States", out var states)
                    || states.ValueKind != JsonValueKind.Array)
                {
                    throw new InvalidOperationException(
                        $"Pending-state profile requires {scenario} "
                        + "ApprovedPendingConfiguration states.");
                }
                var pending = new HashSet<string>(StringComparer.Ordinal);
                foreach (var value in states.EnumerateArray())
                {
                    var state = value.ValueKind == JsonValueKind.String
                        ? value.GetString()
                        : null;
                    if (state == null
                        || state.Length != 2
                        || state.Any(character => character is < 'A' or > 'Z')
                        || !pending.Add(state))
                    {
                        throw new InvalidOperationException(
                            $"Invalid or duplicate pending state in {scenario}.");
                    }
                }
                var overlap = pending.Intersect(configured[scenario]).ToArray();
                if (overlap.Length > 0)
                {
                    throw new InvalidOperationException(
                        $"Pending {scenario} states are already configured: "
                        + string.Join(", ", overlap));
                }
            }
        }

        private static string DefaultProjectRoot() =>
            Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                ".."));

        private sealed record FileSnapshot(
            string Path,
            long Length,
            DateTime LastWriteTimeUtc,
            CanonicalInputArtifact Artifact);
    }
}
