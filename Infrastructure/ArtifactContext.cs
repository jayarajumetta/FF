#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace PnCTestAutomation.Artifacts
{
    public enum ArtifactKind
    {
        Screenshot,
        Trace,
        Video,
        FormsXml,
        FormsCsv,
        FormsHtml,
        FormsMarkdown,
        FormsTrx,
        BusinessOutcome,
        TrxMetadata,
        TimingSummary,
        QuoteHandoff,
        RuntimeLocator,
        ScenarioReportHtml,
        ScenarioResultJson,
        ExecutionLog,
        ConsoleLog,
        NetworkLog,
        Har,
        EvidenceBundle
    }

    public enum ArtifactOutcome
    {
        Passed,
        Failed,
        Skipped
    }

    public static class ArtifactReportPaths
    {
        public const string Report = "reports/report.html";
        public const string Result = "reports/scenario-result.json";
    }

    public sealed class ArtifactOptions
    {
        public string RootPath { get; set; } = "TestResults";
        public string ProfileName { get; set; } = "standard";
        public List<ArtifactKind> RequiredOnFailure { get; set; } =
            [ArtifactKind.Screenshot];

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(RootPath))
                throw new InvalidOperationException("Artifacts:RootPath is required.");
            if (string.IsNullOrWhiteSpace(ProfileName) || ProfileName.Length > 64)
                throw new InvalidOperationException(
                    "Artifacts:ProfileName must contain between 1 and 64 characters.");
            if (RequiredOnFailure == null ||
                RequiredOnFailure.Any(kind => !Enum.IsDefined(kind)))
            {
                throw new InvalidOperationException(
                    "Artifacts:RequiredOnFailure contains an invalid artifact kind.");
            }

            _ = Path.GetFullPath(RootPath);
        }
    }

    public sealed record ArtifactRecord(
        ArtifactKind Kind,
        string Checkpoint,
        string? RelativePath,
        DateTimeOffset CapturedAtUtc);

    public sealed record ArtifactManifest(
        int Version,
        string RunId,
        string ScenarioId,
        string? AutomationId,
        string? TestIdentity,
        string ProfileName,
        ArtifactOutcome Outcome,
        bool AuthoritativeScenarioFailed,
        IReadOnlyDictionary<string, bool> ComponentOutcomes,
        IReadOnlyList<ArtifactKind> RequiredEvidence,
        IReadOnlyList<string> EvidenceErrors,
        IReadOnlyList<ArtifactRecord> Artifacts,
        string TrxMetadataPath,
        string TimingSummaryPath,
        DateTimeOffset StartedAtUtc,
        DateTimeOffset CompletedAtUtc);

    public sealed class ArtifactEvidenceException : Exception
    {
        public ArtifactEvidenceException(string message)
            : base(message)
        {
        }
    }

    public interface IArtifactContext
    {
        string RunId { get; }
        string ScenarioId { get; }
        string RunRoot { get; }
        string ScenarioRoot { get; }
        IReadOnlyList<ArtifactRecord> Records { get; }

        string GetArtifactDirectory(ArtifactKind kind);

        string CreateArtifactPath(
            ArtifactKind kind,
            string checkpoint,
            string extension);

        ArtifactRecord RecordFile(
            ArtifactKind kind,
            string checkpoint,
            string absolutePath);

        ArtifactRecord RecordMarker(
            ArtifactKind kind,
            string checkpoint);

        void Require(params ArtifactKind[] kinds);
        void RequireFailureEvidence();
        void RecordComponentOutcome(string component, bool succeeded);
        ArtifactManifest Complete(bool authoritativeScenarioFailed);
        ArtifactManifest Complete(ArtifactOutcome authoritativeOutcome);
        ArtifactManifest Complete(
            ArtifactOutcome authoritativeOutcome,
            Action<ArtifactManifest> writeReports);
    }

    public interface IArtifactCaptureService
    {
        Task<ArtifactRecord> CaptureAsync(
            ArtifactKind kind,
            string checkpoint,
            string extension,
            Func<string, Task> capture,
            bool required = true);
    }

    public sealed class ArtifactCaptureService : IArtifactCaptureService
    {
        private readonly IArtifactContext _context;

        public ArtifactCaptureService(IArtifactContext context)
        {
            _context = context;
        }

        public async Task<ArtifactRecord> CaptureAsync(
            ArtifactKind kind,
            string checkpoint,
            string extension,
            Func<string, Task> capture,
            bool required = true)
        {
            ArgumentNullException.ThrowIfNull(capture);
            if (required)
                _context.Require(kind);

            var path = _context.CreateArtifactPath(kind, checkpoint, extension);
            await capture(path);
            return _context.RecordFile(kind, checkpoint, path);
        }
    }

    public sealed class ArtifactContext : IArtifactContext
    {
        public const int CurrentManifestVersion = 2;

        private static readonly JsonSerializerOptions ManifestJsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private readonly ArtifactOptions _options;
        private readonly Func<DateTimeOffset> _utcNow;
        private readonly string? _automationId;
        private readonly string? _testIdentity;
        private readonly DateTimeOffset _startedAtUtc;
        private readonly object _gate = new();
        private readonly List<ArtifactRecord> _records = [];
        private readonly HashSet<ArtifactKind> _required = [];
        private readonly Dictionary<string, bool> _componentOutcomes =
            new(StringComparer.OrdinalIgnoreCase);
        private int _sequence;
        private bool _completed;
        private bool _finalizing;

        public ArtifactContext(
            ArtifactOptions options,
            string runId,
            string scenarioId,
            Func<DateTimeOffset>? utcNow = null,
            string? automationId = null,
            string? testIdentity = null)
        {
            options.Validate();
            _options = options;
            _utcNow = utcNow ?? (() => DateTimeOffset.UtcNow);
            _startedAtUtc = _utcNow();

            RunId = RequireSafeLabel(runId, nameof(runId));
            ScenarioId = RequireSafeLabel(scenarioId, nameof(scenarioId));
            if (string.IsNullOrWhiteSpace(automationId) !=
                string.IsNullOrWhiteSpace(testIdentity))
            {
                throw new ArgumentException(
                    "Automation ID and test identity must be supplied together.");
            }
            _automationId = string.IsNullOrWhiteSpace(automationId)
                ? null
                : automationId.Trim();
            _testIdentity = string.IsNullOrWhiteSpace(testIdentity)
                ? null
                : testIdentity.Trim();

            var outputRoot = ResolveOutputRoot(options);
            RunRoot = ArtifactPathGuard.EnsureSafe(
                outputRoot,
                Path.Combine(outputRoot, $"run-{StableSegment(RunId)}"));
            ScenarioRoot = ArtifactPathGuard.EnsureSafe(
                RunRoot,
                Path.Combine(RunRoot, $"scenario-{StableSegment(ScenarioId)}"));

            Directory.CreateDirectory(ScenarioRoot);
            ArtifactPathGuard.EnsureSafe(ScenarioRoot, ScenarioRoot);
        }

        public static string ResolveOutputRoot(ArtifactOptions options)
        {
            options.Validate();
            var configuredRoot = Path.IsPathRooted(options.RootPath)
                ? options.RootPath
                : Path.Combine(Directory.GetCurrentDirectory(), options.RootPath);
            return Path.GetFullPath(configuredRoot);
        }

        public string RunId { get; }
        public string ScenarioId { get; }
        public string RunRoot { get; }
        public string ScenarioRoot { get; }

        public IReadOnlyList<ArtifactRecord> Records
        {
            get
            {
                lock (_gate)
                    return new ReadOnlyCollection<ArtifactRecord>(_records.ToList());
            }
        }

        public string CreateArtifactPath(
            ArtifactKind kind,
            string checkpoint,
            string extension)
        {
            EnsureNotCompleted();
            var safeCheckpoint = RequireSafeLabel(checkpoint, nameof(checkpoint));
            var safeExtension = NormalizeExtension(extension);
            var ordinal = Interlocked.Increment(ref _sequence);
            var directory = GetArtifactDirectory(kind);

            return ArtifactPathGuard.EnsureSafe(
                ScenarioRoot,
                Path.Combine(
                    directory,
                    $"{ordinal:D4}-{StableSegment(safeCheckpoint)}{safeExtension}"));
        }

        public string GetArtifactDirectory(ArtifactKind kind)
        {
            EnsureNotCompleted();
            var directory = ArtifactPathGuard.EnsureSafe(
                ScenarioRoot,
                Path.Combine(ScenarioRoot, DirectoryFor(kind)));
            Directory.CreateDirectory(directory);
            return ArtifactPathGuard.EnsureSafe(ScenarioRoot, directory);
        }

        public ArtifactRecord RecordFile(
            ArtifactKind kind,
            string checkpoint,
            string absolutePath)
        {
            EnsureNotCompleted();
            var safeCheckpoint = RequireSafeLabel(checkpoint, nameof(checkpoint));
            var resolved = ArtifactPathGuard.EnsureSafe(ScenarioRoot, absolutePath);
            if (!File.Exists(resolved) || new FileInfo(resolved).Length == 0)
            {
                throw new ArtifactEvidenceException(
                    $"Required {kind} evidence was not created or was empty.");
            }

            var record = new ArtifactRecord(
                kind,
                safeCheckpoint,
                NormalizeRelativePath(Path.GetRelativePath(ScenarioRoot, resolved)),
                _utcNow());
            lock (_gate)
                _records.Add(record);
            return record;
        }

        public ArtifactRecord RecordMarker(
            ArtifactKind kind,
            string checkpoint)
        {
            EnsureNotCompleted();
            if (kind != ArtifactKind.QuoteHandoff)
            {
                throw new ArgumentException(
                    "Only a scenario-owned quote handoff can use a marker; " +
                    "file evidence must be recorded with a nonempty file.",
                    nameof(kind));
            }
            var record = new ArtifactRecord(
                kind,
                RequireSafeLabel(checkpoint, nameof(checkpoint)),
                null,
                _utcNow());
            lock (_gate)
                _records.Add(record);
            return record;
        }

        public void Require(params ArtifactKind[] kinds)
        {
            EnsureNotCompleted();
            ArgumentNullException.ThrowIfNull(kinds);
            if (kinds.Any(kind => !Enum.IsDefined(kind)))
                throw new ArgumentException("Required evidence contains an invalid kind.", nameof(kinds));
            lock (_gate)
            {
                foreach (var kind in kinds)
                    _required.Add(kind);
            }
        }

        public void RequireFailureEvidence() =>
            Require(_options.RequiredOnFailure.ToArray());

        public void RecordComponentOutcome(string component, bool succeeded)
        {
            EnsureNotCompleted();
            var safeComponent = RequireSafeLabel(component, nameof(component));
            lock (_gate)
            {
                _componentOutcomes[safeComponent] =
                    (!_componentOutcomes.TryGetValue(safeComponent, out var previous) || previous) && succeeded;
            }
        }

        public ArtifactManifest Complete(bool authoritativeScenarioFailed) =>
            Complete(authoritativeScenarioFailed
                ? ArtifactOutcome.Failed
                : ArtifactOutcome.Passed);

        public ArtifactManifest Complete(ArtifactOutcome authoritativeOutcome) =>
            CompleteCore(authoritativeOutcome, null);

        public ArtifactManifest Complete(
            ArtifactOutcome authoritativeOutcome,
            Action<ArtifactManifest> writeReports)
        {
            ArgumentNullException.ThrowIfNull(writeReports);
            return CompleteCore(authoritativeOutcome, writeReports);
        }

        private ArtifactManifest CompleteCore(
            ArtifactOutcome authoritativeOutcome,
            Action<ArtifactManifest>? writeReports)
        {
            EnsureNotCompleted();
            if (!Enum.IsDefined(authoritativeOutcome))
                throw new ArgumentOutOfRangeException(nameof(authoritativeOutcome));
            var authoritativeScenarioFailed = authoritativeOutcome == ArtifactOutcome.Failed;
            var pendingReports = new List<ArtifactRecord>();
            if (writeReports != null)
            {
                pendingReports.Add(ReserveReport(
                    ArtifactKind.ScenarioReportHtml, "scenario-report", ArtifactReportPaths.Report));
                pendingReports.Add(ReserveReport(
                    ArtifactKind.ScenarioResultJson, "scenario-result", ArtifactReportPaths.Result));
            }
            WriteTimingSummary(authoritativeScenarioFailed);
            WriteTrxMetadata();
            var completedAt = _utcNow();
            var manifest = BuildManifest(
                authoritativeOutcome,
                completedAt,
                pendingReports.Select(record => record.Kind).ToHashSet());
            _finalizing = true;
            var finalized = false;
            try
            {
                writeReports?.Invoke(manifest);
                var verified = BuildManifest(authoritativeOutcome, completedAt, new HashSet<ArtifactKind>());
                if (JsonSerializer.Serialize(manifest, ManifestJsonOptions) !=
                    JsonSerializer.Serialize(verified, ManifestJsonOptions))
                {
                    throw new ArtifactEvidenceException(
                        "Report projection did not produce complete evidence for the frozen scenario outcome.");
                }
                WriteAndVerifyManifest(manifest);
                finalized = true;
            }
            finally
            {
                try
                {
                    if (!finalized)
                    {
                        // A partial success projection must not survive a failed finalization.
                        foreach (var report in pendingReports)
                        {
                            File.Delete(ArtifactPathGuard.EnsureSafe(
                                ScenarioRoot, Path.Combine(ScenarioRoot, report.RelativePath!)));
                        }
                        _componentOutcomes["artifact-finalization"] = false;
                        WriteAndVerifyManifest(BuildManifest(
                            authoritativeOutcome, completedAt, new HashSet<ArtifactKind>()));
                    }
                }
                finally
                {
                    _completed = true;
                    _finalizing = false;
                }
            }

            if (!authoritativeScenarioFailed && manifest.EvidenceErrors.Count > 0)
                throw new ArtifactEvidenceException(string.Join(" ", manifest.EvidenceErrors));
            if (!authoritativeScenarioFailed && manifest.ComponentOutcomes.Any(item => !item.Value))
            {
                throw new ArtifactEvidenceException(
                    "Scenario outcome disagrees with a failed required component.");
            }
            return manifest;
        }

        private ArtifactRecord ReserveReport(
            ArtifactKind kind,
            string checkpoint,
            string relativePath)
        {
            if (_records.Any(record => record.Kind == kind))
                throw new ArtifactEvidenceException("Report projections already belong to this scenario.");
            var path = ArtifactPathGuard.EnsureSafe(
                ScenarioRoot, Path.Combine(ScenarioRoot, relativePath));
            if (File.Exists(path))
                throw new ArtifactEvidenceException("A report projection would overwrite existing scenario evidence.");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            var record = new ArtifactRecord(kind, checkpoint, relativePath, _utcNow());
            _required.Add(kind);
            _records.Add(record);
            return record;
        }

        private ArtifactManifest BuildManifest(
            ArtifactOutcome authoritativeOutcome,
            DateTimeOffset completedAt,
            IReadOnlySet<ArtifactKind> pendingReports)
        {
            var authoritativeScenarioFailed = authoritativeOutcome == ArtifactOutcome.Failed;
            var missing = _required
                .Where(kind => _records.All(record => record.Kind != kind))
                .OrderBy(kind => kind)
                .ToList();
            var corrupt = _records
                .Where(record =>
                    record.RelativePath != null &&
                    !pendingReports.Contains(record.Kind) &&
                    !IsValidRecordedFile(record))
                .Select(record => record.Kind)
                .Distinct()
                .OrderBy(kind => kind)
                .ToList();
            var componentFailed = _componentOutcomes.Any(item => !item.Value);
            var evidenceErrors = missing
                .Select(kind => $"Missing required evidence: {kind}.")
                .Concat(corrupt.Select(
                    kind => $"Required evidence is missing or corrupt: {kind}."))
                .ToList();
            var outcome = authoritativeScenarioFailed ||
                          componentFailed ||
                          evidenceErrors.Count > 0
                ? ArtifactOutcome.Failed
                : authoritativeOutcome;

            return new ArtifactManifest(
                CurrentManifestVersion,
                RunId,
                ScenarioId,
                _automationId,
                _testIdentity,
                _options.ProfileName,
                outcome,
                authoritativeScenarioFailed,
                new ReadOnlyDictionary<string, bool>(
                    new Dictionary<string, bool>(
                        _componentOutcomes,
                        StringComparer.OrdinalIgnoreCase)),
                _required.OrderBy(kind => kind).ToList().AsReadOnly(),
                evidenceErrors.AsReadOnly(),
                _records.OrderBy(record => record.CapturedAtUtc).ToList().AsReadOnly(),
                _records.Single(record => record.Kind == ArtifactKind.TrxMetadata)
                    .RelativePath!,
                _records.Single(record => record.Kind == ArtifactKind.TimingSummary)
                    .RelativePath!,
                _startedAtUtc,
                completedAt);
        }

        private void WriteTimingSummary(bool authoritativeScenarioFailed)
        {
            var completedAt = _utcNow();
            var path = CreateArtifactPath(
                ArtifactKind.TimingSummary,
                "scenario-timing",
                ".json");
            var payload = JsonSerializer.Serialize(
                new
                {
                    startedAtUtc = _startedAtUtc,
                    completedAtUtc = completedAt,
                    durationMilliseconds =
                        Math.Max(0, (completedAt - _startedAtUtc).TotalMilliseconds),
                    authoritativeScenarioFailed
                },
                ManifestJsonOptions);
            WriteAtomic(path, payload);
            RecordFile(ArtifactKind.TimingSummary, "scenario-timing", path);
        }

        private void WriteTrxMetadata()
        {
            var path = CreateArtifactPath(
                ArtifactKind.TrxMetadata,
                "trx-attachments",
                ".json");
            var attachments = _records
                .Where(record => record.RelativePath != null)
                .Select(record => new
                {
                    kind = record.Kind.ToString(),
                    checkpoint = record.Checkpoint,
                    relativePath = record.RelativePath
                })
                .Append(new
                {
                    kind = "Manifest",
                    checkpoint = "scenario-manifest",
                    relativePath = (string?)"manifest.json"
                })
                .ToList();
            var payload = JsonSerializer.Serialize(
                new
                {
                    version = CurrentManifestVersion,
                    runId = RunId,
                    scenarioId = ScenarioId,
                    automationId = _automationId,
                    attachments
                },
                ManifestJsonOptions);
            WriteAtomic(path, payload);
            RecordFile(ArtifactKind.TrxMetadata, "trx-attachments", path);
        }

        private void WriteAndVerifyManifest(ArtifactManifest manifest)
        {
            var path = ArtifactPathGuard.EnsureSafe(
                ScenarioRoot,
                Path.Combine(ScenarioRoot, "manifest.json"));
            WriteAtomic(path, JsonSerializer.Serialize(manifest, ManifestJsonOptions));

            try
            {
                var saved = JsonSerializer.Deserialize<ArtifactManifest>(
                    File.ReadAllText(path),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                if (saved == null ||
                    saved.Version != CurrentManifestVersion ||
                    !string.Equals(saved.RunId, manifest.RunId, StringComparison.Ordinal) ||
                    !string.Equals(saved.ScenarioId, manifest.ScenarioId, StringComparison.Ordinal) ||
                    !string.Equals(saved.AutomationId, manifest.AutomationId, StringComparison.Ordinal) ||
                    !string.Equals(saved.TestIdentity, manifest.TestIdentity, StringComparison.Ordinal) ||
                    !string.Equals(saved.ProfileName, manifest.ProfileName, StringComparison.Ordinal) ||
                    saved.Outcome != manifest.Outcome ||
                    saved.AuthoritativeScenarioFailed !=
                    manifest.AuthoritativeScenarioFailed ||
                    saved.ComponentOutcomes.Count != manifest.ComponentOutcomes.Count ||
                    saved.Artifacts.Count != manifest.Artifacts.Count ||
                    saved.RequiredEvidence.Count != manifest.RequiredEvidence.Count ||
                    saved.EvidenceErrors.Count != manifest.EvidenceErrors.Count ||
                    string.IsNullOrWhiteSpace(saved.TrxMetadataPath) ||
                    string.IsNullOrWhiteSpace(saved.TimingSummaryPath))
                {
                    throw new ArtifactEvidenceException(
                        "The artifact manifest is incomplete.");
                }
            }
            catch (JsonException)
            {
                throw new ArtifactEvidenceException(
                    "The artifact manifest is corrupt.");
            }
        }

        private bool IsValidRecordedFile(ArtifactRecord record)
        {
            try
            {
                var path = ArtifactPathGuard.EnsureSafe(
                    ScenarioRoot,
                    Path.Combine(ScenarioRoot, record.RelativePath!));
                if (!File.Exists(path) || new FileInfo(path).Length == 0)
                    return false;

                return record.Kind switch
                {
                    ArtifactKind.FormsXml => IsXml(path),
                    ArtifactKind.FormsTrx => IsXml(path, "TestRun"),
                    ArtifactKind.FormsCsv => File.ReadLines(path)
                        .FirstOrDefault()?
                        .StartsWith(
                            "Form,Expected,Actual,Result,Code,Message",
                            StringComparison.Ordinal) == true,
                    ArtifactKind.FormsHtml or
                    ArtifactKind.ScenarioReportHtml => File.ReadAllText(path)
                        .Contains("<html", StringComparison.OrdinalIgnoreCase),
                    ArtifactKind.FormsMarkdown => File.ReadLines(path)
                        .FirstOrDefault()?
                        .StartsWith(
                            "# Forms Validation",
                            StringComparison.Ordinal) == true,
                    ArtifactKind.TrxMetadata or
                    ArtifactKind.TimingSummary or
                    ArtifactKind.RuntimeLocator or
                    ArtifactKind.ScenarioResultJson or
                    ArtifactKind.Har => IsJson(path),
                    _ => true
                };
            }
            catch
            {
                return false;
            }
        }

        private static bool IsXml(string path, string? rootName = null)
        {
            var document = XDocument.Load(path);
            return document.Root != null &&
                   (rootName == null ||
                    document.Root.Name.LocalName.Equals(
                        rootName,
                        StringComparison.Ordinal));
        }

        private static bool IsJson(string path)
        {
            using var document = JsonDocument.Parse(File.ReadAllText(path));
            return document.RootElement.ValueKind == JsonValueKind.Object;
        }

        private static void WriteAtomic(string path, string content)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            var temporaryPath = $"{path}.{Guid.NewGuid():N}.tmp";
            try
            {
                using (var stream = new FileStream(
                           temporaryPath,
                           FileMode.CreateNew,
                           FileAccess.Write,
                           FileShare.None,
                           4096,
                           FileOptions.WriteThrough))
                using (var writer = new StreamWriter(
                           stream,
                           new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
                {
                    writer.Write(content);
                    writer.Flush();
                    stream.Flush(flushToDisk: true);
                }

                if (File.Exists(path))
                    File.Replace(temporaryPath, path, null);
                else
                    File.Move(temporaryPath, path);
            }
            finally
            {
                if (File.Exists(temporaryPath))
                    File.Delete(temporaryPath);
            }
        }

        private void EnsureNotCompleted()
        {
            if (_completed || _finalizing)
                throw new InvalidOperationException(
                    "The scenario artifact manifest has already been completed.");
        }

        private static string NormalizeExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentException("An artifact extension is required.", nameof(extension));
            var normalized = extension.StartsWith('.') ? extension : $".{extension}";
            if (normalized.Length > 12 ||
                normalized.Skip(1).Any(character => !char.IsLetterOrDigit(character)))
            {
                throw new ArgumentException(
                    "Artifact extensions may contain only letters and numbers.",
                    nameof(extension));
            }

            return normalized.ToLowerInvariant();
        }

        private static string RequireSafeLabel(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > 256 ||
                value.Contains("..", StringComparison.Ordinal) ||
                value.IndexOfAny([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar]) >= 0 ||
                value.Any(char.IsControl))
            {
                throw new ArgumentException(
                    "Artifact labels cannot be empty, contain traversal, path separators, or control characters.",
                    parameterName);
            }

            return value.Trim();
        }

        private static string StableSegment(string value)
        {
            var normalized = new string(value
                .Select(character =>
                    char.IsLetterOrDigit(character) || character is '-' or '_'
                        ? character
                        : '-')
                .Take(72)
                .ToArray())
                .Trim('-');
            if (normalized.Length == 0)
                normalized = "artifact";

            var hash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(value)))[..10];
            return $"{normalized}-{hash}";
        }

        private static string DirectoryFor(ArtifactKind kind) => kind switch
        {
            ArtifactKind.Screenshot => "screenshots",
            ArtifactKind.Trace => "traces",
            ArtifactKind.Video => "video",
            ArtifactKind.FormsXml => Path.Combine("forms", "xml"),
            ArtifactKind.FormsCsv => Path.Combine("forms", "csv"),
            ArtifactKind.FormsHtml => Path.Combine("forms", "html"),
            ArtifactKind.FormsMarkdown => Path.Combine("forms", "markdown"),
            ArtifactKind.FormsTrx => Path.Combine("forms", "trx"),
            ArtifactKind.BusinessOutcome => "business-outcomes",
            ArtifactKind.TrxMetadata => "metadata",
            ArtifactKind.TimingSummary => "metadata",
            ArtifactKind.QuoteHandoff => "metadata",
            ArtifactKind.RuntimeLocator => Path.Combine(
                "metadata",
                "runtime-locators"),
            ArtifactKind.ScenarioReportHtml or ArtifactKind.ScenarioResultJson => "reports",
            ArtifactKind.ExecutionLog or ArtifactKind.ConsoleLog or ArtifactKind.NetworkLog => "logs",
            ArtifactKind.Har => "network",
            ArtifactKind.EvidenceBundle => "bundles",
            _ => "other"
        };

        private static string NormalizeRelativePath(string path) =>
            path.Replace(Path.DirectorySeparatorChar, '/');
    }

    public static class ArtifactPathGuard
    {
        public static string EnsureSafe(
            string root,
            string candidate,
            Func<string, FileAttributes?>? getAttributes = null)
        {
            var fullRoot = Path.GetFullPath(root)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var fullCandidate = Path.GetFullPath(candidate);
            var comparison = OperatingSystem.IsWindows()
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;
            if (!fullCandidate.Equals(fullRoot, comparison) &&
                !fullCandidate.StartsWith(
                    fullRoot + Path.DirectorySeparatorChar,
                    comparison))
            {
                throw new ArtifactEvidenceException(
                    "Artifact path escapes the owned output root.");
            }

            getAttributes ??= path =>
            {
                if (!File.Exists(path) && !Directory.Exists(path))
                    return null;
                return File.GetAttributes(path);
            };

            var current = fullRoot;
            RejectReparse(current, getAttributes);
            var relative = Path.GetRelativePath(fullRoot, fullCandidate);
            foreach (var segment in relative.Split(
                         [Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar],
                         StringSplitOptions.RemoveEmptyEntries))
            {
                current = Path.Combine(current, segment);
                RejectReparse(current, getAttributes);
            }

            return fullCandidate;
        }

        private static void RejectReparse(
            string path,
            Func<string, FileAttributes?> getAttributes)
        {
            var attributes = getAttributes(path);
            if (attributes.HasValue &&
                attributes.Value.HasFlag(FileAttributes.ReparsePoint))
            {
                throw new ArtifactEvidenceException(
                    "Artifact paths cannot traverse reparse points.");
            }
        }
    }

    public static class ArtifactRunIdentity
    {
        private static readonly Lazy<string> CurrentValue = new(Create);

        public static string Current => CurrentValue.Value;

        private static string Create()
        {
            var supplied = Environment.GetEnvironmentVariable("TEST_RUN_ID")
                           ?? Environment.GetEnvironmentVariable("BUILD_BUILDID");
            if (!string.IsNullOrWhiteSpace(supplied))
                return supplied;

            return $"{DateTime.UtcNow:yyyyMMdd-HHmmss}-{Environment.ProcessId}";
        }
    }
}
