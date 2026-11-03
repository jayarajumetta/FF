using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum CanonicalWorkbookDeltaKind
    {
        Added,
        Removed,
        Modified
    }

    public enum CanonicalFormsDeltaStatus
    {
        NoChanges,
        Generated,
        Blocked,
        Failed
    }

    public sealed record CanonicalFormsDeltaSource(
        string Identity,
        string Path,
        string ExpectedSha256,
        string AcquisitionReference);

    public sealed record CanonicalFormsDeltaRequest
    {
        public FormsMonitorSourceFamily ChangedSourceFamily { get; init; }
        public CanonicalFormsDeltaSource PreviousChangedSource { get; init; }
        public CanonicalFormsDeltaSource CurrentChangedSource { get; init; }
        public CanonicalFormsDeltaSource CurrentCounterpartSource { get; init; }
        public string ApprovedBaselinePath { get; init; } = "";
        public string ExpectedApprovedBaselineSha256 { get; init; } = "";
        public string BasicFeaturePath { get; init; } = "";
        public string CountryEstateFeaturePath { get; init; } = "";
        public string OutputDirectory { get; init; }
        public string Lob { get; init; } = "SFP";
        public DateOnly EffectiveDate { get; init; } = new(2027, 4, 3);
        public string GeneratorVersion { get; init; } = "";
        public IReadOnlyDictionary<string, string> RuleVersions { get; init; } =
            new Dictionary<string, string>(StringComparer.Ordinal);
    }

    public sealed class CanonicalFormsDeltaOptions
    {
        public bool WritePackage { get; init; }
        public bool OverwriteExisting { get; init; }
        public DateTimeOffset? GenerationTimestampUtc { get; init; }
        internal Action AfterWorkbookParse { get; init; }
        internal bool InjectAtomicWriteFailure { get; init; }
    }

    public sealed class CanonicalWorkbookRowDelta
    {
        public CanonicalWorkbookDeltaKind Kind { get; init; }
        public string StableIdentity { get; init; } = "";
        public string AffectedFormIdentity { get; init; } = "";
        public IReadOnlyList<string> AffectedStates { get; init; } = Array.Empty<string>();
        public CanonicalFormSourceRow Before { get; init; }
        public CanonicalFormSourceRow After { get; init; }
        public IReadOnlyList<string> ChangedDimensions { get; init; } =
            Array.Empty<string>();
    }

    public sealed class CanonicalFormsDeltaFinding
    {
        public string FindingId { get; init; } = "";
        public CanonicalSemanticSeverity Severity { get; init; }
        public string Category { get; init; } = "";
        public string Scenario { get; init; } = "";
        public string State { get; init; } = "";
        public string Form { get; init; } = "";
        public string OldMeaning { get; init; } = "";
        public string NewMeaning { get; init; } = "";
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> RuleIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalFormSourceRow> BeforeEvidence { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
        public IReadOnlyList<CanonicalFormSourceRow> AfterEvidence { get; init; } =
            Array.Empty<CanonicalFormSourceRow>();
    }

    public sealed class CanonicalFormsDeltaManifest
    {
        public string SchemaVersion { get; init; } = "1.0";
        public string DeltaRuleVersion { get; init; } =
            CanonicalFormsDeltaPipeline.RuleVersion;
        public FormsMonitorSourceFamily ChangedSourceFamily { get; init; }
        public string PreviousSourceSha256 { get; init; } = "";
        public string CurrentSourceSha256 { get; init; } = "";
        public string CounterpartSourceSha256 { get; init; } = "";
        public string ApprovedBaselineSha256 { get; init; } = "";
        public string AffectedIdentitySha256 { get; init; } = "";
        public string CandidateSha256 { get; init; } = "";
        public string ReportSha256 { get; init; } = "";
        public string PackageCorrelationId { get; init; } = "";
        public string GeneratorVersion { get; init; } = "";
        public IReadOnlyDictionary<string, string> RuleVersions { get; init; } =
            new SortedDictionary<string, string>(StringComparer.Ordinal);
        public DateTimeOffset GeneratedAtUtc { get; init; }
    }

    public sealed class CanonicalFormsDeltaPackagePaths
    {
        public string PackageDirectory { get; init; } = "";
        public string CandidatePath { get; init; } = "";
        public string ManifestPath { get; init; } = "";
        public string ReportJsonPath { get; init; } = "";
        public string ReportMarkdownPath { get; init; } = "";
    }

    public sealed class CanonicalFormsDeltaResult
    {
        public CanonicalFormsDeltaStatus Status { get; init; }
        public bool NotificationWorthy { get; init; }
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public IReadOnlyList<CanonicalWorkbookRowDelta> RowDeltas { get; init; } =
            Array.Empty<CanonicalWorkbookRowDelta>();
        public IReadOnlyList<CanonicalFormsDeltaFinding> Findings { get; init; } =
            Array.Empty<CanonicalFormsDeltaFinding>();
        public string AffectedIdentitySha256 { get; init; }
        public string CandidateJson { get; init; }
        public string CandidateSha256 { get; init; }
        public string ReportJson { get; init; }
        public string ReportMarkdown { get; init; }
        public string ReportSha256 { get; init; }
        public string ManifestJson { get; init; }
        public string PackageCorrelationId { get; init; }
        public CanonicalFormsDeltaPackagePaths Paths { get; init; }
    }

    public static class CanonicalFormsDeltaPipeline
    {
        public const string RuleVersion = "1.0";
        public const string CandidateFileName = "SFP_DELTA_CANDIDATE.json";
        public const string ManifestFileName = "SFP_DELTA_CANDIDATE.manifest.json";
        public const string ReportJsonFileName = "delta-semantic-report.json";
        public const string ReportMarkdownFileName = "delta-semantic-report.md";

        private static readonly JsonSerializerOptions ReportJsonOptions =
            CreateJsonOptions(indented: true);

        public static CanonicalFormsDeltaResult Run(
            CanonicalFormsDeltaRequest request,
            CanonicalFormsDeltaOptions options = null)
        {
            options ??= new CanonicalFormsDeltaOptions();
            try
            {
                ValidateRequest(request);
                var previous = CapturePinned(request.PreviousChangedSource, "previous snapshot");
                var current = CapturePinned(request.CurrentChangedSource, "current workbook");
                var counterpart = CapturePinned(
                    request.CurrentCounterpartSource,
                    "current counterpart workbook");
                var approved = CapturePinned(
                    new CanonicalFormsDeltaSource(
                        Path.GetFileName(request.ApprovedBaselinePath),
                        request.ApprovedBaselinePath,
                        request.ExpectedApprovedBaselineSha256,
                        "Repository approved baseline"),
                    "approved baseline");
                if (previous.Sha256.Equals(current.Sha256, StringComparison.OrdinalIgnoreCase))
                {
                    return new CanonicalFormsDeltaResult
                    {
                        Status = CanonicalFormsDeltaStatus.NoChanges,
                        NotificationWorthy = false,
                        Reasons = new[] { "Previous and current workbook content hashes are identical." }
                    };
                }

                var basicProfiles = ScenarioProfileLoader.LoadBasic(
                    request.BasicFeaturePath,
                    request.EffectiveDate);
                var ceProfiles = ScenarioProfileLoader.LoadCountryEstate(
                    request.CountryEstateFeaturePath,
                    request.EffectiveDate);
                var profiles = basicProfiles.Concat(ceProfiles).ToArray();
                var parserOptions = new ParserOptions
                {
                    RecognizedStateColumns = profiles.Select(profile => profile.State)
                        .Distinct(StringComparer.Ordinal)
                        .OrderBy(state => state, StringComparer.Ordinal)
                        .ToArray()
                };
                var previousRows = Parse(
                    request.ChangedSourceFamily,
                    previous.Path,
                    request.Lob,
                    parserOptions);
                var currentChangedRows = Parse(
                    request.ChangedSourceFamily,
                    current.Path,
                    request.Lob,
                    parserOptions);
                var counterpartFamily = request.ChangedSourceFamily
                    == FormsMonitorSourceFamily.SFP
                    ? FormsMonitorSourceFamily.Common
                    : FormsMonitorSourceFamily.SFP;
                var counterpartRows = Parse(
                    counterpartFamily,
                    counterpart.Path,
                    request.Lob,
                    parserOptions);
                options.AfterWorkbookParse?.Invoke();
                EnsureUnchanged(previous);
                EnsureUnchanged(current);
                EnsureUnchanged(counterpart);

                var rowDeltas = CompareRows(previousRows, currentChangedRows);
                if (rowDeltas.Count == 0)
                {
                    return new CanonicalFormsDeltaResult
                    {
                        Status = CanonicalFormsDeltaStatus.NoChanges,
                        NotificationWorthy = false,
                        Reasons = new[]
                        {
                            "Workbook bytes changed, but canonical row meaning is unchanged."
                        }
                    };
                }

                var affected = BuildAffectedIdentities(rowDeltas, profiles);
                var affectedHash = Sha256(JsonSerializer.Serialize(affected));
                var blockedFindings = BuildIdentityBlockers(rowDeltas);
                if (blockedFindings.Count > 0)
                {
                    return Blocked(
                        rowDeltas,
                        blockedFindings,
                        affectedHash,
                        "A changed identity cannot be parsed deterministically.");
                }

                var affectedFamilies = affected.Select(item => item.FormFamily)
                    .ToHashSet(StringComparer.Ordinal);
                var currentEvidence = currentChangedRows
                    .Concat(counterpartRows)
                    .Where(row => affectedFamilies.Contains(FormFamily(row)))
                    .ToArray();
                var affectedStates = affected.Select(item => item.State)
                    .ToHashSet(StringComparer.Ordinal);
                var candidates = new List<CanonicalEditionCandidate>();
                foreach (var aggregate in currentEvidence
                             .GroupBy(row => row.SourceFamily)
                             .OrderBy(group => group.Key)
                             .SelectMany(group =>
                                 CanonicalFormAggregator.Aggregate(group)))
                {
                    var interpretation =
                        CanonicalApplicabilityInterpreter.Interpret(aggregate);
                    foreach (var profile in profiles.Where(profile =>
                                 affectedStates.Contains(profile.State)))
                    {
                        candidates.Add(new CanonicalEditionCandidate(
                            aggregate,
                            CanonicalScenarioEligibilityEvaluator.Evaluate(
                                aggregate,
                                interpretation,
                                profile)));
                    }
                }
                var projection = CanonicalExpectedRecordProjector.Project(
                    CanonicalEditionLifecycleResolver.Resolve(candidates));
                var relevantBlocked = projection.BlockedRecords
                    .Where(record => affectedFamilies.Contains(
                        FormFamily(record.NormalizedIdentifier)))
                    .ToArray();
                if (relevantBlocked.Length > 0)
                {
                    var findings = relevantBlocked.Select((record, index) =>
                        new CanonicalFormsDeltaFinding
                        {
                            FindingId = $"D{index + 1:D4}",
                            Severity = CanonicalSemanticSeverity.ApprovalBlocking,
                            Category = record.Kind.ToString(),
                            Scenario = string.Join(",", record.ImpactedDestinations),
                            State = string.Join(",", record.States),
                            Form = record.NormalizedIdentifier,
                            OldMeaning = "Approved runtime meaning retained",
                            NewMeaning = "Changed identity is indeterminate",
                            Reasons = record.Reasons,
                            RuleIds = record.RuleIds,
                            AfterEvidence = record.SourceRows
                        }).ToArray();
                    return Blocked(
                        rowDeltas,
                        findings,
                        affectedHash,
                        "At least one changed identity is canonically ambiguous.");
                }

                var approvedJson = File.ReadAllText(request.ApprovedBaselinePath);
                var approvedModel = ApprovedBaselineModel.Load(approvedJson);
                var candidateModel = approvedModel.Clone();
                ApplyAffectedProjection(
                    candidateModel,
                    projection,
                    affected,
                    basicProfiles,
                    ceProfiles);
                var candidateJson = candidateModel.Serialize();
                ValidateStrictCandidate(candidateJson, candidateModel.States);
                var semanticFindings = CompareAffectedMeaning(
                    approvedModel,
                    candidateModel,
                    affected,
                    rowDeltas);
                if (semanticFindings.Count == 0)
                {
                    return new CanonicalFormsDeltaResult
                    {
                        Status = CanonicalFormsDeltaStatus.NoChanges,
                        NotificationWorthy = false,
                        Reasons = new[]
                        {
                            "Material workbook rows changed, but approved runtime meaning did not."
                        },
                        RowDeltas = rowDeltas,
                        AffectedIdentitySha256 = affectedHash
                    };
                }

                var report = new
                {
                    schemaVersion = "1.0",
                    deltaRuleVersion = RuleVersion,
                    changedSourceFamily = request.ChangedSourceFamily,
                    previousSourceSha256 = previous.Sha256,
                    currentSourceSha256 = current.Sha256,
                    counterpartSourceSha256 = counterpart.Sha256,
                    approvedBaselineSha256 = approved.Sha256,
                    affectedIdentitySha256 = affectedHash,
                    rowDeltaCounts = Enum.GetValues<CanonicalWorkbookDeltaKind>()
                        .ToDictionary(
                            kind => kind.ToString(),
                            kind => rowDeltas.Count(delta => delta.Kind == kind)),
                    findings = semanticFindings
                };
                var reportJson = JsonSerializer.Serialize(report, ReportJsonOptions) + "\n";
                var reportMarkdown = RenderMarkdown(
                    request.ChangedSourceFamily,
                    rowDeltas,
                    semanticFindings);
                var candidateHash = Sha256(candidateJson);
                var reportHash = Sha256(reportJson);
                var correlationId = Sha256(string.Join(
                    "|",
                    request.ChangedSourceFamily,
                    previous.Sha256,
                    current.Sha256,
                    counterpart.Sha256,
                    approved.Sha256,
                    affectedHash,
                    candidateHash,
                    reportHash,
                    request.GeneratorVersion));
                var manifest = new CanonicalFormsDeltaManifest
                {
                    ChangedSourceFamily = request.ChangedSourceFamily,
                    PreviousSourceSha256 = previous.Sha256,
                    CurrentSourceSha256 = current.Sha256,
                    CounterpartSourceSha256 = counterpart.Sha256,
                    ApprovedBaselineSha256 = approved.Sha256,
                    AffectedIdentitySha256 = affectedHash,
                    CandidateSha256 = candidateHash,
                    ReportSha256 = reportHash,
                    PackageCorrelationId = correlationId,
                    GeneratorVersion = request.GeneratorVersion,
                    RuleVersions = new SortedDictionary<string, string>(
                        request.RuleVersions.ToDictionary(
                            pair => pair.Key,
                            pair => pair.Value,
                            StringComparer.Ordinal),
                        StringComparer.Ordinal),
                    GeneratedAtUtc =
                        options.GenerationTimestampUtc ?? DateTimeOffset.UtcNow
                };
                var manifestJson =
                    JsonSerializer.Serialize(manifest, ReportJsonOptions) + "\n";
                CanonicalFormsDeltaPackagePaths paths = null;
                if (options.WritePackage)
                {
                    paths = WriteAtomicPackage(
                        request,
                        options,
                        candidateJson,
                        manifestJson,
                        reportJson,
                        reportMarkdown);
                }
                return new CanonicalFormsDeltaResult
                {
                    Status = CanonicalFormsDeltaStatus.Generated,
                    NotificationWorthy = true,
                    RowDeltas = rowDeltas,
                    Findings = semanticFindings,
                    AffectedIdentitySha256 = affectedHash,
                    CandidateJson = candidateJson,
                    CandidateSha256 = candidateHash,
                    ReportJson = reportJson,
                    ReportMarkdown = reportMarkdown,
                    ReportSha256 = reportHash,
                    ManifestJson = manifestJson,
                    PackageCorrelationId = correlationId,
                    Paths = paths
                };
            }
            catch (Exception exception) when (
                exception is InvalidOperationException
                    or IOException
                    or UnauthorizedAccessException
                    or JsonException
                    or ArgumentException)
            {
                return new CanonicalFormsDeltaResult
                {
                    Status = CanonicalFormsDeltaStatus.Failed,
                    NotificationWorthy = true,
                    Reasons = new[] { exception.Message }
                };
            }
        }

        private static CanonicalFormsDeltaResult Blocked(
            IReadOnlyList<CanonicalWorkbookRowDelta> rowDeltas,
            IReadOnlyList<CanonicalFormsDeltaFinding> findings,
            string affectedHash,
            string reason) =>
            new()
            {
                Status = CanonicalFormsDeltaStatus.Blocked,
                NotificationWorthy = true,
                Reasons = new[] { reason },
                RowDeltas = rowDeltas,
                Findings = findings,
                AffectedIdentitySha256 = affectedHash
            };

        private static IReadOnlyList<CanonicalFormSourceRow> Parse(
            FormsMonitorSourceFamily family,
            string path,
            string lob,
            ParserOptions options)
        {
            var parser = new ExcelFormsParser();
            return family == FormsMonitorSourceFamily.SFP
                ? parser.ParseCanonical(path, options)
                : parser.ParseCommonFormsCanonical(path, lob, options);
        }

        private static IReadOnlyList<CanonicalWorkbookRowDelta> CompareRows(
            IReadOnlyList<CanonicalFormSourceRow> previous,
            IReadOnlyList<CanonicalFormSourceRow> current)
        {
            var result = new List<CanonicalWorkbookRowDelta>();
            var keys = previous.Select(RowIdentity)
                .Concat(current.Select(RowIdentity))
                .Distinct(StringComparer.Ordinal)
                .OrderBy(value => value, StringComparer.Ordinal);
            foreach (var key in keys)
            {
                var before = previous.Where(row => RowIdentity(row) == key)
                    .OrderBy(RowSemanticSignature, StringComparer.Ordinal)
                    .ToList();
                var after = current.Where(row => RowIdentity(row) == key)
                    .OrderBy(RowSemanticSignature, StringComparer.Ordinal)
                    .ToList();
                RemoveEquivalentRows(before, after);
                while (before.Count > 0 && after.Count > 0)
                {
                    var oldRow = before[0];
                    var newRow = after[0];
                    before.RemoveAt(0);
                    after.RemoveAt(0);
                    result.Add(CreateDelta(
                        CanonicalWorkbookDeltaKind.Modified,
                        key,
                        oldRow,
                        newRow));
                }
                result.AddRange(before.Select(row => CreateDelta(
                    CanonicalWorkbookDeltaKind.Removed,
                    key,
                    row,
                    null)));
                result.AddRange(after.Select(row => CreateDelta(
                    CanonicalWorkbookDeltaKind.Added,
                    key,
                    null,
                    row)));
            }
            return result
                .OrderBy(delta => delta.StableIdentity, StringComparer.Ordinal)
                .ThenBy(delta => delta.Kind)
                .ThenBy(delta => delta.Before?.SourceRowNumber ?? int.MaxValue)
                .ThenBy(delta => delta.After?.SourceRowNumber ?? int.MaxValue)
                .ToArray();
        }

        private static void RemoveEquivalentRows(
            List<CanonicalFormSourceRow> before,
            List<CanonicalFormSourceRow> after)
        {
            for (var index = before.Count - 1; index >= 0; index--)
            {
                var signature = RowSemanticSignature(before[index]);
                var match = after.FindIndex(row =>
                    RowSemanticSignature(row) == signature);
                if (match < 0)
                    continue;
                before.RemoveAt(index);
                after.RemoveAt(match);
            }
        }

        private static CanonicalWorkbookRowDelta CreateDelta(
            CanonicalWorkbookDeltaKind kind,
            string stableIdentity,
            CanonicalFormSourceRow before,
            CanonicalFormSourceRow after)
        {
            var states = AffectedStates(before, after);
            return new CanonicalWorkbookRowDelta
            {
                Kind = kind,
                StableIdentity = stableIdentity,
                AffectedFormIdentity =
                    after?.NormalizedFormIdentifier
                    ?? before?.NormalizedFormIdentifier
                    ?? "",
                AffectedStates = states,
                Before = before,
                After = after,
                ChangedDimensions = ChangedDimensions(before, after)
            };
        }

        private static string RowIdentity(CanonicalFormSourceRow row) =>
            string.Join(
                "|",
                row.SourceFamily,
                row.Worksheet.Trim().ToUpperInvariant(),
                row.NormalizedFormIdentifier.Trim().ToUpperInvariant(),
                row.LegacySection.Trim().ToUpperInvariant());

        private static string RowSemanticSignature(CanonicalFormSourceRow row) =>
            string.Join(
                "\u001e",
                row.NormalizedFormIdentifier,
                row.ParsedFormNumber ?? "",
                row.ParsedEdition ?? "",
                row.TitleDescription,
                row.LegacySection,
                string.Join(",", row.SourceDivisionProductHints
                    .OrderBy(value => value, StringComparer.Ordinal)),
                string.Join(",", row.StateMarkers
                    .OrderBy(marker => marker.NormalizedState, StringComparer.Ordinal)
                    .ThenBy(marker => marker.RawHeader, StringComparer.Ordinal)
                    .Select(marker =>
                        $"{marker.RawHeader}:{marker.NormalizedState}:{marker.RawValue}:"
                        + $"{marker.IsConfiguredState}:{marker.IsCompanySpecific}")),
                row.RawSelection,
                row.RawRules,
                row.RawPrintRules,
                row.RawMultipleSelectionCriteria,
                row.RawAdditionalSelectionCriteria,
                row.RawAdditionalRequirements,
                row.RawNotes,
                row.RawStartDate,
                row.RawStopDate,
                row.RawEffectiveDate,
                row.RawTransactionRules,
                row.RawLifecycle,
                row.RawWithdrawn,
                row.RawReplacement);

        private static IReadOnlyList<string> AffectedStates(
            CanonicalFormSourceRow before,
            CanonicalFormSourceRow after)
        {
            var rows = new[] { before, after }.Where(row => row != null).ToArray();
            if (before == null
                || after == null
                || NonStateSignature(before) != NonStateSignature(after))
            {
                return rows.SelectMany(row => row.StateMarkers)
                    .Select(marker => marker.NormalizedState)
                    .Where(state => !string.IsNullOrWhiteSpace(state))
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(state => state, StringComparer.Ordinal)
                    .ToArray();
            }
            var states = before.StateMarkers.Select(marker => marker.NormalizedState)
                .Concat(after.StateMarkers.Select(marker => marker.NormalizedState))
                .Distinct(StringComparer.Ordinal);
            return states.Where(state =>
                    MarkerSignature(before, state) != MarkerSignature(after, state))
                .OrderBy(state => state, StringComparer.Ordinal)
                .ToArray();
        }

        private static string NonStateSignature(CanonicalFormSourceRow row) =>
            string.Join(
                "\u001e",
                row.NormalizedFormIdentifier,
                row.ParsedFormNumber ?? "",
                row.ParsedEdition ?? "",
                row.TitleDescription,
                row.LegacySection,
                string.Join(",", row.SourceDivisionProductHints),
                row.RawSelection,
                row.RawRules,
                row.RawPrintRules,
                row.RawMultipleSelectionCriteria,
                row.RawAdditionalSelectionCriteria,
                row.RawAdditionalRequirements,
                row.RawNotes,
                row.RawStartDate,
                row.RawStopDate,
                row.RawEffectiveDate,
                row.RawTransactionRules,
                row.RawLifecycle,
                row.RawWithdrawn,
                row.RawReplacement);

        private static string MarkerSignature(
            CanonicalFormSourceRow row,
            string state) =>
            string.Join(
                "|",
                row.StateMarkers
                    .Where(marker => marker.NormalizedState == state)
                    .OrderBy(marker => marker.RawHeader, StringComparer.Ordinal)
                    .Select(marker =>
                        $"{marker.RawHeader}:{marker.RawValue}:"
                        + $"{marker.IsConfiguredState}:{marker.IsCompanySpecific}"));

        private static IReadOnlyList<string> ChangedDimensions(
            CanonicalFormSourceRow before,
            CanonicalFormSourceRow after)
        {
            if (before == null)
                return new[] { "RowAdded" };
            if (after == null)
                return new[] { "RowRemoved" };
            var dimensions = new List<string>();
            AddIfChanged(
                dimensions,
                "FormIdentity",
                before.NormalizedFormIdentifier,
                after.NormalizedFormIdentifier);
            AddIfChanged(dimensions, "Title", before.TitleDescription, after.TitleDescription);
            AddIfChanged(dimensions, "Product", before.LegacySection, after.LegacySection);
            AddIfChanged(dimensions, "Selection", before.RawSelection, after.RawSelection);
            AddIfChanged(dimensions, "Rules", before.RawRules, after.RawRules);
            AddIfChanged(dimensions, "PrintRules", before.RawPrintRules, after.RawPrintRules);
            AddIfChanged(
                dimensions,
                "AdditionalRequirements",
                before.RawAdditionalRequirements,
                after.RawAdditionalRequirements);
            AddIfChanged(
                dimensions,
                "Lifecycle",
                string.Join("|", before.RawStartDate, before.RawStopDate,
                    before.RawEffectiveDate, before.RawLifecycle, before.RawWithdrawn,
                    before.RawReplacement),
                string.Join("|", after.RawStartDate, after.RawStopDate,
                    after.RawEffectiveDate, after.RawLifecycle, after.RawWithdrawn,
                    after.RawReplacement));
            if (string.Join("|", before.StateMarkers.Select(marker =>
                    $"{marker.RawHeader}:{marker.RawValue}"))
                != string.Join("|", after.StateMarkers.Select(marker =>
                    $"{marker.RawHeader}:{marker.RawValue}")))
            {
                dimensions.Add("StateApplicability");
            }
            return dimensions.Count == 0
                ? new[] { "OtherCanonicalValue" }
                : dimensions;
        }

        private static void AddIfChanged(
            ICollection<string> dimensions,
            string name,
            string before,
            string after)
        {
            if (!string.Equals(before ?? "", after ?? "", StringComparison.Ordinal))
                dimensions.Add(name);
        }

        private static IReadOnlyList<AffectedIdentity> BuildAffectedIdentities(
            IEnumerable<CanonicalWorkbookRowDelta> deltas,
            IEnumerable<ScenarioProfile> profiles)
        {
            var configured = profiles
                .GroupBy(profile => profile.State, StringComparer.Ordinal)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(profile => profile.Product)
                        .Distinct(StringComparer.Ordinal)
                        .OrderBy(value => value, StringComparer.Ordinal)
                        .ToArray(),
                    StringComparer.Ordinal);
            var result = new List<AffectedIdentity>();
            foreach (var delta in deltas)
            {
                var family = FormFamily(delta.After ?? delta.Before);
                foreach (var state in delta.AffectedStates.Where(configured.ContainsKey))
                {
                    foreach (var product in configured[state])
                    {
                        result.Add(new AffectedIdentity(
                            family,
                            state,
                            product,
                            delta.AffectedFormIdentity));
                    }
                }
            }
            return result.Distinct()
                .OrderBy(item => item.FormFamily, StringComparer.Ordinal)
                .ThenBy(item => item.State, StringComparer.Ordinal)
                .ThenBy(item => item.Product, StringComparer.Ordinal)
                .ThenBy(item => item.SourceFormIdentity, StringComparer.Ordinal)
                .ToArray();
        }

        private static IReadOnlyList<CanonicalFormsDeltaFinding> BuildIdentityBlockers(
            IEnumerable<CanonicalWorkbookRowDelta> deltas) =>
            deltas.Where(delta =>
                    string.IsNullOrWhiteSpace((delta.After ?? delta.Before).ParsedFormNumber)
                    || string.IsNullOrWhiteSpace((delta.After ?? delta.Before).ParsedEdition))
                .Select((delta, index) => new CanonicalFormsDeltaFinding
                {
                    FindingId = $"D{index + 1:D4}",
                    Severity = CanonicalSemanticSeverity.ApprovalBlocking,
                    Category = "ChangedIdentityAmbiguous",
                    Scenario = "BASIC/CE",
                    State = string.Join(",", delta.AffectedStates),
                    Form = delta.AffectedFormIdentity,
                    OldMeaning = "Approved runtime meaning retained",
                    NewMeaning = "Changed source identity is not safely parseable",
                    Reasons = new[]
                    {
                        "Only the changed identity is blocked; unrelated approved expectations "
                        + "remain untouched."
                    },
                    RuleIds = new[] { "V1-DELTA-IDENTITY-AMBIGUOUS" },
                    BeforeEvidence = delta.Before == null
                        ? Array.Empty<CanonicalFormSourceRow>()
                        : new[] { delta.Before },
                    AfterEvidence = delta.After == null
                        ? Array.Empty<CanonicalFormSourceRow>()
                        : new[] { delta.After }
                })
                .ToArray();

        private static void ApplyAffectedProjection(
            ApprovedBaselineModel candidate,
            CanonicalExpectedProjection projection,
            IReadOnlyList<AffectedIdentity> affected,
            IReadOnlyList<ScenarioProfile> basicProfiles,
            IReadOnlyList<ScenarioProfile> ceProfiles)
        {
            foreach (var item in affected)
            {
                candidate.States[item.Product].Add(item.State);
                var keys = candidate.Expectations.Keys
                    .Where(key =>
                        key.Product == item.Product
                        && key.State == item.State
                        && FormFamily(key.Form) == item.FormFamily)
                    .ToArray();
                foreach (var key in keys)
                    candidate.Expectations.Remove(key);

                foreach (var record in projection.QualifiedRecords.Where(record =>
                             record.States.Contains(item.State)
                             && FormFamily(record.NormalizedIdentifier)
                                == item.FormFamily
                             && DestinationApplies(record.Destination, item.Product)))
                {
                    candidate.Expectations[
                        new RuntimeExpectationKey(
                            item.Product,
                            item.State,
                            record.NormalizedIdentifier)] =
                        record.ProvisionalRuntimeStatus;
                }
            }
        }

        private static bool DestinationApplies(
            CanonicalExpectedDestination destination,
            string product) =>
            destination == CanonicalExpectedDestination.BASE
            || destination.ToString() == product;

        private static IReadOnlyList<CanonicalFormsDeltaFinding> CompareAffectedMeaning(
            ApprovedBaselineModel approved,
            ApprovedBaselineModel candidate,
            IReadOnlyList<AffectedIdentity> affected,
            IReadOnlyList<CanonicalWorkbookRowDelta> rowDeltas)
        {
            var findings = new List<CanonicalFormsDeltaFinding>();
            foreach (var item in affected)
            {
                var before = approved.Expectations
                    .Where(pair =>
                        pair.Key.Product == item.Product
                        && pair.Key.State == item.State
                        && FormFamily(pair.Key.Form) == item.FormFamily)
                    .ToDictionary(pair => pair.Key.Form, pair => pair.Value);
                var after = candidate.Expectations
                    .Where(pair =>
                        pair.Key.Product == item.Product
                        && pair.Key.State == item.State
                        && FormFamily(pair.Key.Form) == item.FormFamily)
                    .ToDictionary(pair => pair.Key.Form, pair => pair.Value);
                if (DictionaryEqual(before, after))
                    continue;
                var category = before.Count == 0
                    ? "FormAdded"
                    : after.Count == 0
                        ? "FormRemoved"
                        : before.Keys.OrderBy(value => value, StringComparer.Ordinal)
                            .SequenceEqual(
                                after.Keys.OrderBy(value => value, StringComparer.Ordinal),
                                StringComparer.Ordinal)
                            ? "StatusChanged"
                            : "EditionOrRoutingChanged";
                var evidence = rowDeltas.Where(delta =>
                    FormFamily(delta.After ?? delta.Before) == item.FormFamily).ToArray();
                findings.Add(new CanonicalFormsDeltaFinding
                {
                    FindingId = $"D{findings.Count + 1:D4}",
                    Severity = category == "FormRemoved"
                        ? CanonicalSemanticSeverity.PotentiallyBreaking
                        : CanonicalSemanticSeverity.ReviewRequired,
                    Category = category,
                    Scenario = item.Product,
                    State = item.State,
                    Form = item.FormFamily,
                    OldMeaning = Meaning(before),
                    NewMeaning = Meaning(after),
                    Reasons = new[]
                    {
                        "Only this changed form family/state/scenario was patched; "
                        + "all unrelated approved meaning was carried forward."
                    },
                    RuleIds = new[] { "V1-DELTA-AFFECTED-SEMANTIC-CHANGE" },
                    BeforeEvidence = evidence.Where(delta => delta.Before != null)
                        .Select(delta => delta.Before)
                        .ToArray(),
                    AfterEvidence = evidence.Where(delta => delta.After != null)
                        .Select(delta => delta.After)
                        .ToArray()
                });
            }
            return findings;
        }

        private static bool DictionaryEqual(
            IReadOnlyDictionary<string, string> first,
            IReadOnlyDictionary<string, string> second) =>
            first.Count == second.Count
            && first.All(pair =>
                second.TryGetValue(pair.Key, out var value)
                && value == pair.Value);

        private static string Meaning(IReadOnlyDictionary<string, string> values) =>
            values.Count == 0
                ? "Implicit N"
                : string.Join(
                    ", ",
                    values.OrderBy(pair => pair.Key, StringComparer.Ordinal)
                        .Select(pair => $"{pair.Key}={pair.Value}"));

        private static void ValidateStrictCandidate(
            string candidateJson,
            IReadOnlyDictionary<string, SortedSet<string>> states)
        {
            var service = new FormsValidationService(new DuckCreekFormsConfig());
            foreach (var product in new[] { "BASIC", "CE" })
            {
                foreach (var state in states[product])
                    _ = service.ParseSfpJson(candidateJson, state, product);
            }
        }

        private static string RenderMarkdown(
            FormsMonitorSourceFamily family,
            IReadOnlyList<CanonicalWorkbookRowDelta> deltas,
            IReadOnlyList<CanonicalFormsDeltaFinding> findings)
        {
            var builder = new StringBuilder();
            builder.AppendLine("# Forms baseline delta review");
            builder.AppendLine();
            builder.AppendLine($"- Changed source: {family}");
            builder.AppendLine($"- Material row changes: {deltas.Count}");
            builder.AppendLine($"- Runtime findings: {findings.Count}");
            builder.AppendLine();
            builder.AppendLine("| Severity | Category | Scenario | State | Form | Old | New |");
            builder.AppendLine("|---|---|---|---|---|---|---|");
            foreach (var finding in findings)
            {
                builder.AppendLine(
                    $"| {finding.Severity} | {finding.Category} | {finding.Scenario} | "
                    + $"{finding.State} | {finding.Form} | {finding.OldMeaning} | "
                    + $"{finding.NewMeaning} |");
            }
            return builder.ToString();
        }

        private static CanonicalFormsDeltaPackagePaths WriteAtomicPackage(
            CanonicalFormsDeltaRequest request,
            CanonicalFormsDeltaOptions options,
            string candidateJson,
            string manifestJson,
            string reportJson,
            string reportMarkdown)
        {
            var projectRoot = DefaultProjectRoot();
            var output = Path.GetFullPath(
                request.OutputDirectory
                ?? Path.Combine(
                    projectRoot,
                    "TestResults",
                    "FormsBaseline",
                    "CanonicalDeltaReviewPackage"));
            var approvedDirectory = Path.GetFullPath(
                Path.GetDirectoryName(Path.GetFullPath(
                    request.ApprovedBaselinePath))!);
            if (output.Equals(approvedDirectory, StringComparison.OrdinalIgnoreCase)
                || output.StartsWith(
                    approvedDirectory + Path.DirectorySeparatorChar,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Delta review package output cannot be inside the approved baseline directory.");
            }
            if ((Directory.Exists(output) || File.Exists(output))
                && !options.OverwriteExisting)
            {
                throw new InvalidOperationException(
                    "Delta review package already exists; explicit overwrite is required.");
            }
            var parent = Path.GetDirectoryName(output);
            if (string.IsNullOrWhiteSpace(parent))
                throw new InvalidOperationException("Delta package output directory is invalid.");
            Directory.CreateDirectory(parent);
            var temporary = output + ".tmp-" + Guid.NewGuid().ToString("N");
            var backup = output + ".backup-" + Guid.NewGuid().ToString("N");
            var backedUp = false;
            var committed = false;
            try
            {
                Directory.CreateDirectory(temporary);
                File.WriteAllText(
                    Path.Combine(temporary, CandidateFileName),
                    candidateJson,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, ManifestFileName),
                    manifestJson,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, ReportJsonFileName),
                    reportJson,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    Path.Combine(temporary, ReportMarkdownFileName),
                    reportMarkdown,
                    new UTF8Encoding(false));
                if (options.InjectAtomicWriteFailure)
                    throw new IOException("Injected delta package write failure.");
                if (Directory.Exists(output))
                {
                    Directory.Move(output, backup);
                    backedUp = true;
                }
                Directory.Move(temporary, output);
                committed = true;
                if (backedUp)
                    Directory.Delete(backup, recursive: true);
            }
            catch
            {
                if (committed && Directory.Exists(output))
                    Directory.Delete(output, recursive: true);
                if (backedUp && Directory.Exists(backup))
                    Directory.Move(backup, output);
                throw;
            }
            finally
            {
                if (Directory.Exists(temporary))
                    Directory.Delete(temporary, recursive: true);
                if (Directory.Exists(backup) && !backedUp)
                    Directory.Delete(backup, recursive: true);
            }
            return new CanonicalFormsDeltaPackagePaths
            {
                PackageDirectory = output,
                CandidatePath = Path.Combine(output, CandidateFileName),
                ManifestPath = Path.Combine(output, ManifestFileName),
                ReportJsonPath = Path.Combine(output, ReportJsonFileName),
                ReportMarkdownPath = Path.Combine(output, ReportMarkdownFileName)
            };
        }

        private static void ValidateRequest(CanonicalFormsDeltaRequest request)
        {
            if (request == null)
                throw new InvalidOperationException("Delta pipeline request is required.");
            ValidateSource(request.PreviousChangedSource, "previous changed-source snapshot");
            ValidateSource(request.CurrentChangedSource, "current changed-source workbook");
            ValidateSource(request.CurrentCounterpartSource, "current counterpart workbook");
            RequireFile(request.ApprovedBaselinePath, "approved baseline");
            RequireHash(request.ExpectedApprovedBaselineSha256, "approved baseline hash");
            RequireFile(request.BasicFeaturePath, "BASIC feature");
            RequireFile(request.CountryEstateFeaturePath, "CE feature");
            if (string.IsNullOrWhiteSpace(request.GeneratorVersion))
                throw new InvalidOperationException("GeneratorVersion is required.");
            if (request.RuleVersions == null || request.RuleVersions.Count == 0)
                throw new InvalidOperationException("RuleVersions are required.");
            if (string.IsNullOrWhiteSpace(request.Lob))
                throw new InvalidOperationException("LOB is required.");
        }

        private static void ValidateSource(
            CanonicalFormsDeltaSource source,
            string label)
        {
            if (source == null)
                throw new InvalidOperationException($"{label} is required.");
            RequireFile(source.Path, label);
            RequireHash(source.ExpectedSha256, $"{label} hash");
            if (string.IsNullOrWhiteSpace(source.Identity))
                throw new InvalidOperationException($"{label} identity is required.");
            if (string.IsNullOrWhiteSpace(source.AcquisitionReference))
                throw new InvalidOperationException($"{label} acquisition reference is required.");
        }

        private static void RequireFile(string path, string label)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                throw new InvalidOperationException($"{label} file not found: '{path}'.");
        }

        private static void RequireHash(string hash, string label)
        {
            if (string.IsNullOrWhiteSpace(hash)
                || hash.Length != 64
                || !hash.All(Uri.IsHexDigit))
            {
                throw new InvalidOperationException(
                    $"{label} must be an exact SHA-256 value.");
            }
        }

        private static PinnedFile CapturePinned(
            CanonicalFormsDeltaSource source,
            string label)
        {
            var path = Path.GetFullPath(source.Path);
            var info = new FileInfo(path);
            var hash = Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));
            if (!hash.Equals(source.ExpectedSha256, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"{label} hash mismatch for '{source.Identity}'.");
            }
            return new PinnedFile(path, info.Length, info.LastWriteTimeUtc, hash);
        }

        private static void EnsureUnchanged(PinnedFile file)
        {
            var info = new FileInfo(file.Path);
            var hash = Convert.ToHexString(
                SHA256.HashData(File.ReadAllBytes(file.Path)));
            if (file.Length != info.Length
                || file.LastWriteTimeUtc != info.LastWriteTimeUtc
                || !file.Sha256.Equals(hash, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"Input workbook changed during delta parsing: {Path.GetFileName(file.Path)}.");
            }
        }

        private static string FormFamily(CanonicalFormSourceRow row) =>
            !string.IsNullOrWhiteSpace(row.ParsedFormNumber)
                ? row.ParsedFormNumber
                : row.NormalizedFormIdentifier;

        private static string FormFamily(string form)
        {
            if (string.IsNullOrWhiteSpace(form))
                return "";
            return form.Length > 4
                   && form[^4..].All(char.IsDigit)
                ? form[..^4]
                : form;
        }

        private static string Sha256(string value) =>
            Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(value)));

        private static string DefaultProjectRoot()
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory != null
                   && !File.Exists(Path.Combine(
                       directory.FullName,
                       "TestAutomation.csproj")))
            {
                directory = directory.Parent;
            }
            return directory?.FullName
                ?? throw new InvalidOperationException(
                    "Cannot locate TestAutomation.csproj.");
        }

        private static JsonSerializerOptions CreateJsonOptions(bool indented)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = indented
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }

        private sealed record PinnedFile(
            string Path,
            long Length,
            DateTime LastWriteTimeUtc,
            string Sha256);

        private sealed record AffectedIdentity(
            string FormFamily,
            string State,
            string Product,
            string SourceFormIdentity);

        private sealed record RuntimeExpectationKey(
            string Product,
            string State,
            string Form);

        private sealed class ApprovedBaselineModel
        {
            public Dictionary<string, SortedSet<string>> States { get; } =
                new(StringComparer.Ordinal)
                {
                    ["BASIC"] = new(StringComparer.Ordinal),
                    ["CE"] = new(StringComparer.Ordinal)
                };

            public Dictionary<RuntimeExpectationKey, string> Expectations { get; } =
                new();

            public static ApprovedBaselineModel Load(string json)
            {
                using var document = JsonDocument.Parse(
                    json,
                    new JsonDocumentOptions
                    {
                        CommentHandling = JsonCommentHandling.Skip
                    });
                var model = new ApprovedBaselineModel();
                var stateMap = document.RootElement.GetProperty("STATES");
                foreach (var product in new[] { "BASIC", "CE" })
                {
                    foreach (var state in stateMap.GetProperty(product).EnumerateArray())
                        model.States[product].Add(state.GetString()!);
                }
                var service = new FormsValidationService(new DuckCreekFormsConfig());
                foreach (var product in new[] { "BASIC", "CE" })
                {
                    foreach (var state in model.States[product])
                    {
                        foreach (var form in service.ParseSfpJson(json, state, product)
                                     .Where(form => form.ExpectedStatus != "N"))
                        {
                            model.Expectations[
                                new RuntimeExpectationKey(
                                    product,
                                    state,
                                    form.FormName)] = form.ExpectedStatus;
                        }
                    }
                }
                return model;
            }

            public ApprovedBaselineModel Clone()
            {
                var clone = new ApprovedBaselineModel();
                foreach (var product in States)
                    clone.States[product.Key].UnionWith(product.Value);
                foreach (var expectation in Expectations)
                    clone.Expectations.Add(expectation.Key, expectation.Value);
                return clone;
            }

            public string Serialize()
            {
                var sections = BuildSections();
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(
                           stream,
                           new JsonWriterOptions { Indented = true }))
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("STATES");
                    writer.WriteStartObject();
                    foreach (var product in new[] { "BASIC", "CE" })
                    {
                        writer.WritePropertyName(product);
                        writer.WriteStartArray();
                        foreach (var state in States[product])
                            writer.WriteStringValue(state);
                        writer.WriteEndArray();
                    }
                    writer.WriteEndObject();
                    foreach (var section in new[] { "BASE", "BASIC", "CE" })
                    {
                        writer.WritePropertyName(section);
                        writer.WriteStartObject();
                        foreach (var form in sections[section]
                                     .OrderBy(pair => pair.Key, StringComparer.Ordinal))
                        {
                            writer.WritePropertyName(form.Key);
                            WriteStatuses(writer, form.Value);
                        }
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
                return Encoding.UTF8.GetString(stream.ToArray()) + "\n";
            }

            private Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                BuildSections()
            {
                var result = new Dictionary<
                    string,
                    Dictionary<string, Dictionary<string, string>>>(
                    StringComparer.Ordinal)
                {
                    ["BASE"] = new(StringComparer.Ordinal),
                    ["BASIC"] = new(StringComparer.Ordinal),
                    ["CE"] = new(StringComparer.Ordinal)
                };
                foreach (var form in Expectations.Keys.Select(key => key.Form)
                             .Distinct(StringComparer.Ordinal)
                             .OrderBy(value => value, StringComparer.Ordinal))
                {
                    var basic = ValuesFor(form, "BASIC");
                    var ce = ValuesFor(form, "CE");
                    if (EquivalentAcrossKnownStates(basic, ce))
                    {
                        result["BASE"][form] = basic;
                    }
                    else
                    {
                        if (basic.Count > 0)
                            result["BASIC"][form] = basic;
                        if (ce.Count > 0)
                            result["CE"][form] = ce;
                    }
                }
                return result;
            }

            private Dictionary<string, string> ValuesFor(string form, string product) =>
                Expectations.Where(pair =>
                        pair.Key.Form == form && pair.Key.Product == product)
                    .ToDictionary(
                        pair => pair.Key.State,
                        pair => pair.Value,
                        StringComparer.Ordinal);

            private bool EquivalentAcrossKnownStates(
                IReadOnlyDictionary<string, string> basic,
                IReadOnlyDictionary<string, string> ce)
            {
                var states = States["BASIC"].Concat(States["CE"])
                    .Distinct(StringComparer.Ordinal);
                return states.All(state =>
                    basic.GetValueOrDefault(state, "N")
                    == ce.GetValueOrDefault(state, "N"));
            }

            private static void WriteStatuses(
                Utf8JsonWriter writer,
                IReadOnlyDictionary<string, string> statuses)
            {
                if (statuses.Values.All(status => status == "YM"))
                {
                    writer.WriteStartArray();
                    foreach (var state in statuses.Keys
                                 .OrderBy(value => value, StringComparer.Ordinal))
                    {
                        writer.WriteStringValue(state);
                    }
                    writer.WriteEndArray();
                    return;
                }
                writer.WriteStartObject();
                foreach (var status in statuses
                             .OrderBy(pair => pair.Key, StringComparer.Ordinal))
                {
                    writer.WriteString(status.Key, status.Value);
                }
                writer.WriteEndObject();
            }
        }
    }
}
