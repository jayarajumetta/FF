using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public sealed record CanonicalSourceWorkbookInput(
        string Identity,
        string FileName,
        string Sha256);

    public sealed record CanonicalManifestSourceWorkbook(
        string Identity,
        string FileName,
        string Sha256);

    public sealed record CanonicalManifestProfileVersion(
        string ProfileId,
        string ProfileVersion);

    public sealed record CanonicalManifestSeverityCount(
        CanonicalSemanticSeverity Severity,
        int Count);

    public sealed record CanonicalInputArtifact(
        string Role,
        string Identity,
        string Sha256);

    public sealed class CanonicalCandidateManifestIdentity
    {
        public string CandidateSha256 { get; init; } = "";
        public string ApprovedBaselineSha256 { get; init; } = "";
        public string ComparisonReportSha256 { get; init; } = "";
        public string ProjectionSha256 { get; init; } = "";
        public string PackageCorrelationId { get; init; } = "";
        public IReadOnlyList<CanonicalManifestSourceWorkbook> SourceWorkbooks { get; init; } =
            Array.Empty<CanonicalManifestSourceWorkbook>();
        public IReadOnlyList<CanonicalInputArtifact> InputArtifacts { get; init; } =
            Array.Empty<CanonicalInputArtifact>();
        public string GeneratorVersion { get; init; } = "";
        public string ProjectionRuleSetId { get; init; } = "";
        public string ProjectionRuleVersion { get; init; } = "";
        public string ComparisonRuleVersion { get; init; } = "";
        public IReadOnlyDictionary<string, string> RuleVersions { get; init; } =
            new SortedDictionary<string, string>(StringComparer.Ordinal);
        public IReadOnlyList<CanonicalManifestProfileVersion> ProfileVersions { get; init; } =
            Array.Empty<CanonicalManifestProfileVersion>();
        public IReadOnlyDictionary<string, string[]> ConfiguredStates { get; init; } =
            new SortedDictionary<string, string[]>(StringComparer.Ordinal);
        public IReadOnlyList<CanonicalManifestSeverityCount> SemanticSeverityCounts { get; init; } =
            Array.Empty<CanonicalManifestSeverityCount>();
        public string CompletenessStatus { get; init; } = "";
    }

    public sealed class CanonicalCandidateManifest
    {
        public string SchemaVersion { get; init; } = "";
        public CanonicalCandidateManifestIdentity DeterministicIdentity { get; init; } = new();
        public DateTimeOffset GeneratedAtUtc { get; init; }
    }

    public sealed class CanonicalCandidateEmissionRequest
    {
        public CanonicalExpectedProjection Projection { get; init; }
        public IReadOnlyList<ScenarioProfile> BasicProfiles { get; init; } =
            Array.Empty<ScenarioProfile>();
        public IReadOnlyList<ScenarioProfile> CountryEstateProfiles { get; init; } =
            Array.Empty<ScenarioProfile>();
        public CanonicalSemanticComparisonReport ComparisonReport { get; init; }
        public IReadOnlyList<CanonicalSourceWorkbookInput> SourceWorkbooks { get; init; } =
            Array.Empty<CanonicalSourceWorkbookInput>();
        public IReadOnlyList<CanonicalInputArtifact> InputArtifacts { get; init; } =
            Array.Empty<CanonicalInputArtifact>();
        public string GeneratorVersion { get; init; } = "";
        public IReadOnlyDictionary<string, string> RuleVersions { get; init; } =
            new Dictionary<string, string>(StringComparer.Ordinal);
    }

    public sealed class CanonicalCandidateEmissionOptions
    {
        public bool AllowReviewedChanges { get; init; }
        public bool OverwriteExisting { get; init; }
        public string CandidatePath { get; init; }
        public string ProjectRoot { get; init; }
        public DateTimeOffset? GenerationTimestampUtc { get; init; }
    }

    public sealed class CanonicalCandidateEmissionResult
    {
        public string CandidateJson { get; init; } = "";
        public string ManifestJson { get; init; } = "";
        public string CandidateSha256 { get; init; } = "";
        public string ComparisonReportSha256 { get; init; } = "";
        public string ProjectionSha256 { get; init; } = "";
        public string PackageCorrelationId { get; init; } = "";
        public string CandidatePath { get; init; }
        public string ManifestPath { get; init; }
    }

    public static class CanonicalCandidateEmitter
    {
        public const string ManifestSchemaVersion = "1.0";
        public const string CompletenessStatus = "Complete";

        private static readonly CanonicalExpectedDestination[] SectionOrder =
        {
            CanonicalExpectedDestination.BASE,
            CanonicalExpectedDestination.BASIC,
            CanonicalExpectedDestination.CE
        };

        private static readonly Regex StrictFormIdentifier =
            new("^[A-Z0-9]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static CanonicalCandidateEmissionResult CreateCandidate(
            CanonicalCandidateEmissionRequest request,
            CanonicalCandidateEmissionOptions options = null)
        {
            options ??= new CanonicalCandidateEmissionOptions();
            var profiles = ValidateRequestAndBuildProfiles(request, options);
            var sectionValues = BuildSectionValues(request.Projection, profiles);
            var candidateJson = SerializeCandidate(profiles, sectionValues);
            ValidateWithStrictRuntimeParser(candidateJson, profiles);

            var candidateHash = Sha256(candidateJson);
            var comparisonJson =
                CanonicalSemanticComparisonService.SerializeJson(request.ComparisonReport);
            var comparisonHash = Sha256(comparisonJson);
            var projectionHash =
                CanonicalProjectionFingerprint.Compute(request.Projection);
            if (!request.ComparisonReport.ProjectionSha256.Equals(
                    projectionHash,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Step 8 semantic comparison report does not match the supplied projection.");
            }
            var packageCorrelationId = CreatePackageCorrelationId(
                request,
                candidateHash,
                comparisonHash,
                projectionHash);
            var manifest = BuildManifest(
                request,
                profiles,
                candidateHash,
                comparisonHash,
                projectionHash,
                packageCorrelationId,
                options.GenerationTimestampUtc ?? DateTimeOffset.UtcNow);
            return new CanonicalCandidateEmissionResult
            {
                CandidateJson = candidateJson,
                ManifestJson = SerializeManifest(manifest),
                CandidateSha256 = candidateHash,
                ComparisonReportSha256 = comparisonHash,
                ProjectionSha256 = projectionHash,
                PackageCorrelationId = packageCorrelationId
            };
        }

        public static CanonicalCandidateEmissionResult WriteCandidate(
            CanonicalCandidateEmissionRequest request,
            CanonicalCandidateEmissionOptions options = null)
        {
            options ??= new CanonicalCandidateEmissionOptions();
            var content = CreateCandidate(request, options);
            var projectRoot = string.IsNullOrWhiteSpace(options.ProjectRoot)
                ? DefaultProjectRoot()
                : Path.GetFullPath(options.ProjectRoot);
            var candidatePath = Path.GetFullPath(options.CandidatePath
                ?? Path.Combine(
                    projectRoot,
                    "TestResults",
                    "FormsBaseline",
                    "SFP_CANONICAL_CANDIDATE.json"));
            RejectApprovedBaselinePath(candidatePath, projectRoot);
            var manifestPath = Path.ChangeExtension(candidatePath, ".manifest.json");
            if (!options.OverwriteExisting
                && (File.Exists(candidatePath) || File.Exists(manifestPath)))
            {
                throw new InvalidOperationException(
                    "Canonical candidate or manifest already exists. "
                    + "Set OverwriteExisting=true only for an explicitly reviewed replacement.");
            }

            var directory = Path.GetDirectoryName(candidatePath);
            if (string.IsNullOrWhiteSpace(directory))
                throw new InvalidOperationException("Candidate output directory is invalid.");
            Directory.CreateDirectory(directory);

            var candidateTemp = candidatePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            var manifestTemp = manifestPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllText(candidateTemp, content.CandidateJson, new UTF8Encoding(false));
                File.WriteAllText(manifestTemp, content.ManifestJson, new UTF8Encoding(false));
                File.Move(candidateTemp, candidatePath, options.OverwriteExisting);
                File.Move(manifestTemp, manifestPath, options.OverwriteExisting);
            }
            finally
            {
                if (File.Exists(candidateTemp))
                    File.Delete(candidateTemp);
                if (File.Exists(manifestTemp))
                    File.Delete(manifestTemp);
            }

            return new CanonicalCandidateEmissionResult
            {
                CandidateJson = content.CandidateJson,
                ManifestJson = content.ManifestJson,
                CandidateSha256 = content.CandidateSha256,
                ComparisonReportSha256 = content.ComparisonReportSha256,
                ProjectionSha256 = content.ProjectionSha256,
                PackageCorrelationId = content.PackageCorrelationId,
                CandidatePath = candidatePath,
                ManifestPath = manifestPath
            };
        }

        private static IReadOnlyDictionary<string, ProfileDefinition>
            ValidateRequestAndBuildProfiles(
                CanonicalCandidateEmissionRequest request,
                CanonicalCandidateEmissionOptions options)
        {
            if (request?.Projection == null)
                throw new InvalidOperationException("Canonical projection is required.");
            if (request.ComparisonReport == null)
                throw new InvalidOperationException("Step 8 semantic comparison report is required.");
            if (string.IsNullOrWhiteSpace(request.GeneratorVersion))
                throw new InvalidOperationException("GeneratorVersion is required.");
            if (string.IsNullOrWhiteSpace(request.Projection.RuleSetId)
                || string.IsNullOrWhiteSpace(request.Projection.RuleVersion))
            {
                throw new InvalidOperationException(
                    "Canonical projection rule-set identity and version are required.");
            }
            if (request.Projection.BlockedRecords.Count > 0)
            {
                throw new InvalidOperationException(
                    "Candidate emission is blocked because the canonical projection "
                    + "contains unresolved blocked or source-conflict records.");
            }

            ValidateComparisonReport(request.ComparisonReport, options);
            ValidateVersionMap(request.RuleVersions);
            var profiles = new SortedDictionary<string, ProfileDefinition>(
                StringComparer.Ordinal)
            {
                ["BASIC"] = BuildProfile("BASIC", request.BasicProfiles),
                ["CE"] = BuildProfile("CE", request.CountryEstateProfiles)
            };
            ValidateProjectionCoverage(request.Projection, profiles);
            ValidateSourceWorkbooks(request);
            ValidateInputArtifacts(request.InputArtifacts);
            return profiles;
        }

        private static void ValidateComparisonReport(
            CanonicalSemanticComparisonReport report,
            CanonicalCandidateEmissionOptions options)
        {
            if (report.SchemaVersion != CanonicalSemanticComparisonService.SchemaVersion
                || report.ComparisonRuleVersion
                != CanonicalSemanticComparisonService.ComparisonRuleVersion)
            {
                throw new InvalidOperationException(
                    "Step 8 semantic comparison schema or rule version is unsupported.");
            }
            ValidateSha256(report.ApprovedBaselineSha256, "approved baseline");
            foreach (var severity in Enum.GetValues<CanonicalSemanticSeverity>())
            {
                var declaredCounts = report.SeverityCounts
                    .Where(count => count.Severity == severity)
                    .ToArray();
                if (declaredCounts.Length != 1)
                {
                    throw new InvalidOperationException(
                        $"Semantic severity count is missing or duplicated for {severity}.");
                }
                var declared = declaredCounts[0].Count;
                var actual = report.Findings.Count(finding => finding.Severity == severity);
                if (declared != actual)
                {
                    throw new InvalidOperationException(
                        $"Semantic severity count mismatch for {severity}.");
                }
            }
            if (report.Findings.Any(finding =>
                    finding.Category == CanonicalSemanticChangeCategory.StateRemoved))
            {
                throw new InvalidOperationException(
                    "Candidate emission is blocked because configured scenario/state "
                    + "coverage is incomplete.");
            }
            if (report.Findings.Any(finding =>
                    finding.RuleIds.Contains(
                        "V1-DUPLICATE-RUNTIME-IDENTITY",
                        StringComparer.Ordinal)))
            {
                throw new InvalidOperationException(
                    "Candidate emission is blocked by a duplicate runtime identity.");
            }
            if (report.Findings.Any(finding =>
                    finding.Severity == CanonicalSemanticSeverity.ApprovalBlocking))
            {
                throw new InvalidOperationException(
                    "Candidate emission is blocked by ApprovalBlocking semantic findings.");
            }
            var reviewedChanges = report.Findings
                .Where(finding =>
                    finding.Severity is CanonicalSemanticSeverity.ReviewRequired
                        or CanonicalSemanticSeverity.PotentiallyBreaking)
                .ToArray();
            if (reviewedChanges.Length > 0 && !options.AllowReviewedChanges)
            {
                throw new InvalidOperationException(
                    "ReviewRequired or PotentiallyBreaking semantic findings require "
                    + "the explicit AllowReviewedChanges=true opt-in.");
            }
        }

        private static ProfileDefinition BuildProfile(
            string expectedProduct,
            IReadOnlyList<ScenarioProfile> profiles)
        {
            if (profiles == null || profiles.Count == 0)
            {
                throw new InvalidOperationException(
                    $"Configured {expectedProduct} scenario profiles are required.");
            }
            var states = new HashSet<string>(StringComparer.Ordinal);
            var profileIds = new HashSet<string>(StringComparer.Ordinal);
            var profileVersions = new HashSet<string>(StringComparer.Ordinal);
            var companies = new HashSet<string>(StringComparer.Ordinal);
            var effectiveDates = new HashSet<DateOnly>();
            foreach (var profile in profiles)
            {
                if (profile == null
                    || profile.Product != expectedProduct
                    || profile.Scenario != "New Business"
                    || profile.Transaction != "New Business"
                    || string.IsNullOrWhiteSpace(profile.Company)
                    || string.IsNullOrWhiteSpace(profile.ProfileId)
                    || string.IsNullOrWhiteSpace(profile.ProfileVersion)
                    || profile.State == null
                    || !Regex.IsMatch(profile.State, "^[A-Z]{2}$")
                    || !states.Add(profile.State))
                {
                    throw new InvalidOperationException(
                        $"Configured {expectedProduct} scenario profiles are incomplete, "
                        + "invalid, or contain duplicate states.");
                }
                profileIds.Add(profile.ProfileId);
                profileVersions.Add(profile.ProfileVersion);
                companies.Add(profile.Company);
                effectiveDates.Add(profile.EffectiveDate);
            }
            if (profileIds.Count != 1
                || profileVersions.Count != 1
                || companies.Count != 1
                || effectiveDates.Count != 1)
            {
                throw new InvalidOperationException(
                    $"Configured {expectedProduct} profiles require one profile ID, "
                    + "version, company, and effective date.");
            }
            return new ProfileDefinition(
                expectedProduct,
                profileIds.Single(),
                profileVersions.Single(),
                states.OrderBy(state => state, StringComparer.Ordinal).ToArray());
        }

        private static void ValidateProjectionCoverage(
            CanonicalExpectedProjection projection,
            IReadOnlyDictionary<string, ProfileDefinition> profiles)
        {
            var configured = profiles.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.States.ToHashSet(StringComparer.Ordinal),
                StringComparer.Ordinal);
            var covered = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal)
            {
                ["BASIC"] = new(StringComparer.Ordinal),
                ["CE"] = new(StringComparer.Ordinal)
            };
            foreach (var record in projection.QualifiedRecords)
            {
                foreach (var scenario in Scenarios(record.Destination))
                    ValidateAndAddStates(record.States, scenario, configured, covered);
            }
            foreach (var record in projection.ImplicitNEvidence)
            {
                var scenario = record.ScenarioDestination == CanonicalExpectedDestination.CE
                    ? "CE"
                    : "BASIC";
                ValidateAndAddStates(record.States, scenario, configured, covered);
            }
            foreach (var profile in profiles)
            {
                var missing = profile.Value.States
                    .Except(covered[profile.Key], StringComparer.Ordinal)
                    .ToArray();
                if (missing.Length > 0)
                {
                    throw new InvalidOperationException(
                        $"Configured {profile.Key} state coverage is incomplete: "
                        + string.Join(", ", missing));
                }
            }
        }

        private static void ValidateAndAddStates(
            IEnumerable<string> states,
            string scenario,
            IReadOnlyDictionary<string, HashSet<string>> configured,
            IReadOnlyDictionary<string, HashSet<string>> covered)
        {
            foreach (var state in states)
            {
                if (!configured[scenario].Contains(state))
                {
                    throw new InvalidOperationException(
                        $"Projection state '{state}' is not configured for {scenario}.");
                }
                covered[scenario].Add(state);
            }
        }

        private static void ValidateSourceWorkbooks(
            CanonicalCandidateEmissionRequest request)
        {
            if (request.SourceWorkbooks == null || request.SourceWorkbooks.Count == 0)
                throw new InvalidOperationException("At least one source workbook is required.");
            var declared = new Dictionary<string, CanonicalSourceWorkbookInput>(
                StringComparer.Ordinal);
            foreach (var workbook in request.SourceWorkbooks)
            {
                if (workbook == null
                    || string.IsNullOrWhiteSpace(workbook.Identity)
                    || string.IsNullOrWhiteSpace(workbook.FileName))
                {
                    throw new InvalidOperationException(
                        "Source workbook identity and filename are required.");
                }
                ValidateSha256(workbook.Sha256, $"source workbook '{workbook.Identity}'");
                var key = workbook.Identity + "|" + workbook.Sha256;
                if (!declared.TryAdd(key, workbook))
                    throw new InvalidOperationException("Duplicate source workbook declaration.");
            }

            if (request.Projection.QualifiedRecords.Any(record =>
                    record.SourceRows == null || record.SourceRows.Count == 0))
            {
                throw new InvalidOperationException(
                    "Every qualified canonical record requires source workbook provenance.");
            }
            var rows = request.Projection.QualifiedRecords
                .SelectMany(record => record.SourceRows)
                .Concat(request.Projection.ImplicitNEvidence
                    .SelectMany(record => record.SourceRows))
                .ToArray();
            if (request.Projection.QualifiedRecords.Count > 0 && rows.Length == 0)
            {
                throw new InvalidOperationException(
                    "Qualified canonical records require source workbook provenance.");
            }
            foreach (var row in rows)
            {
                var key = row.Workbook.Identity + "|" + row.Workbook.Sha256;
                if (!declared.ContainsKey(key))
                {
                    throw new InvalidOperationException(
                        $"Projection source workbook is not declared: {row.Workbook.Identity}.");
                }
            }
        }

        private static void ValidateVersionMap(
            IReadOnlyDictionary<string, string> versions)
        {
            if (versions == null || versions.Count == 0)
                throw new InvalidOperationException("RuleVersions are required.");
            if (versions.Any(pair =>
                    string.IsNullOrWhiteSpace(pair.Key)
                    || string.IsNullOrWhiteSpace(pair.Value)))
            {
                throw new InvalidOperationException(
                    "RuleVersions cannot contain blank keys or values.");
            }
        }

        private static void ValidateInputArtifacts(
            IReadOnlyList<CanonicalInputArtifact> artifacts)
        {
            if (artifacts == null)
                throw new InvalidOperationException("InputArtifacts cannot be null.");
            var identities = new HashSet<string>(StringComparer.Ordinal);
            foreach (var artifact in artifacts)
            {
                if (artifact == null
                    || string.IsNullOrWhiteSpace(artifact.Role)
                    || string.IsNullOrWhiteSpace(artifact.Identity)
                    || !identities.Add(artifact.Role + "|" + artifact.Identity))
                {
                    throw new InvalidOperationException(
                        "Input artifacts require unique role and identity values.");
                }
                ValidateSha256(
                    artifact.Sha256,
                    $"input artifact '{artifact.Role}/{artifact.Identity}'");
            }
        }

        private static IReadOnlyDictionary<CanonicalExpectedDestination,
            IReadOnlyDictionary<string, CandidateValue>> BuildSectionValues(
                CanonicalExpectedProjection projection,
                IReadOnlyDictionary<string, ProfileDefinition> profiles)
        {
            var duplicateProperties = projection.QualifiedRecords
                .GroupBy(
                    record => $"{record.Destination}|{record.NormalizedIdentifier}",
                    StringComparer.Ordinal)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToArray();
            if (duplicateProperties.Length > 0)
            {
                throw new InvalidOperationException(
                    "Duplicate BASE/BASIC/CE candidate property: "
                    + string.Join(", ", duplicateProperties));
            }

            var runtimeKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var record in projection.QualifiedRecords)
            {
                if (string.IsNullOrWhiteSpace(record.NormalizedIdentifier)
                    || !StrictFormIdentifier.IsMatch(record.NormalizedIdentifier))
                {
                    throw new InvalidOperationException(
                        $"Invalid canonical form identifier '{record.NormalizedIdentifier}'.");
                }
                if (record.States.Count == 0
                    || record.States.Count
                    != record.States.Distinct(StringComparer.Ordinal).Count())
                {
                    throw new InvalidOperationException(
                        $"Qualified record '{record.NormalizedIdentifier}' has no states "
                        + "or contains duplicate states.");
                }
                if (record.ProvisionalRuntimeStatus is not ("YM" or "YS" or "YU"))
                {
                    throw new InvalidOperationException(
                        $"Qualified record '{record.NormalizedIdentifier}' has unsupported "
                        + $"runtime status '{record.ProvisionalRuntimeStatus}'.");
                }
                foreach (var scenario in Scenarios(record.Destination))
                foreach (var state in record.States)
                {
                    var runtimeKey =
                        $"{scenario}|{state}|{record.NormalizedIdentifier}";
                    if (!runtimeKeys.Add(runtimeKey))
                    {
                        throw new InvalidOperationException(
                            $"Duplicate runtime identity '{runtimeKey}'.");
                    }
                }
            }

            var result = new SortedDictionary<CanonicalExpectedDestination,
                IReadOnlyDictionary<string, CandidateValue>>();
            foreach (var section in SectionOrder)
            {
                var supportedStates = section switch
                {
                    CanonicalExpectedDestination.BASE => profiles.Values
                        .SelectMany(profile => profile.States)
                        .Distinct(StringComparer.Ordinal)
                        .OrderBy(state => state, StringComparer.Ordinal)
                        .ToArray(),
                    CanonicalExpectedDestination.BASIC => profiles["BASIC"].States,
                    CanonicalExpectedDestination.CE => profiles["CE"].States,
                    _ => Array.Empty<string>()
                };
                var values = new SortedDictionary<string, CandidateValue>(
                    StringComparer.Ordinal);
                foreach (var record in projection.QualifiedRecords
                             .Where(record => record.Destination == section)
                             .OrderBy(
                                 record => record.NormalizedIdentifier,
                                 StringComparer.Ordinal))
                {
                    if (record.States.Except(supportedStates, StringComparer.Ordinal).Any())
                    {
                        throw new InvalidOperationException(
                            $"Qualified record '{record.NormalizedIdentifier}' contains "
                            + $"a state outside the {section} configured profile.");
                    }
                    values.Add(
                        record.NormalizedIdentifier,
                        CandidateValue.Create(
                            record.States,
                            record.ProvisionalRuntimeStatus,
                            supportedStates));
                }
                result.Add(section, values);
            }
            return result;
        }

        private static string SerializeCandidate(
            IReadOnlyDictionary<string, ProfileDefinition> profiles,
            IReadOnlyDictionary<CanonicalExpectedDestination,
                IReadOnlyDictionary<string, CandidateValue>> sectionValues)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(
                       stream,
                       new JsonWriterOptions { Indented = true }))
            {
                writer.WriteStartObject();
                writer.WritePropertyName("STATES");
                writer.WriteStartObject();
                foreach (var scenario in new[] { "BASIC", "CE" })
                {
                    writer.WritePropertyName(scenario);
                    writer.WriteStartArray();
                    foreach (var state in profiles[scenario].States)
                        writer.WriteStringValue(state);
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();

                foreach (var section in SectionOrder)
                {
                    writer.WritePropertyName(section.ToString());
                    writer.WriteStartObject();
                    foreach (var pair in sectionValues[section])
                    {
                        writer.WritePropertyName(pair.Key);
                        pair.Value.Write(writer);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }
            return Encoding.UTF8.GetString(stream.ToArray()) + "\n";
        }

        private static void ValidateWithStrictRuntimeParser(
            string candidateJson,
            IReadOnlyDictionary<string, ProfileDefinition> profiles)
        {
            var service = new FormsValidationService(new DuckCreekFormsConfig());
            foreach (var profile in profiles)
            foreach (var state in profile.Value.States)
            {
                _ = service.ParseSfpJson(candidateJson, state, profile.Key);
            }
        }

        private static CanonicalCandidateManifest BuildManifest(
            CanonicalCandidateEmissionRequest request,
            IReadOnlyDictionary<string, ProfileDefinition> profiles,
            string candidateHash,
            string comparisonHash,
            string projectionHash,
            string packageCorrelationId,
            DateTimeOffset timestamp)
        {
            var sourceWorkbooks = request.SourceWorkbooks
                .OrderBy(workbook => workbook.Identity, StringComparer.Ordinal)
                .ThenBy(workbook => workbook.FileName, StringComparer.Ordinal)
                .ThenBy(workbook => workbook.Sha256, StringComparer.Ordinal)
                .Select(workbook => new CanonicalManifestSourceWorkbook(
                    workbook.Identity,
                    workbook.FileName,
                    workbook.Sha256))
                .ToArray();
            var ruleVersions = new SortedDictionary<string, string>(
                StringComparer.Ordinal);
            foreach (var version in request.RuleVersions)
                ruleVersions.Add(version.Key, version.Value);
            var configuredStates = new SortedDictionary<string, string[]>(
                StringComparer.Ordinal);
            foreach (var profile in profiles)
                configuredStates.Add(profile.Key, profile.Value.States);
            return new CanonicalCandidateManifest
            {
                SchemaVersion = ManifestSchemaVersion,
                DeterministicIdentity = new CanonicalCandidateManifestIdentity
                {
                    CandidateSha256 = candidateHash,
                    ApprovedBaselineSha256 =
                        request.ComparisonReport.ApprovedBaselineSha256,
                    ComparisonReportSha256 = comparisonHash,
                    ProjectionSha256 = projectionHash,
                    PackageCorrelationId = packageCorrelationId,
                    SourceWorkbooks = sourceWorkbooks,
                    InputArtifacts = request.InputArtifacts
                        .OrderBy(artifact => artifact.Role, StringComparer.Ordinal)
                        .ThenBy(artifact => artifact.Identity, StringComparer.Ordinal)
                        .ThenBy(artifact => artifact.Sha256, StringComparer.Ordinal)
                        .ToArray(),
                    GeneratorVersion = request.GeneratorVersion,
                    ProjectionRuleSetId = request.Projection.RuleSetId,
                    ProjectionRuleVersion = request.Projection.RuleVersion,
                    ComparisonRuleVersion =
                        request.ComparisonReport.ComparisonRuleVersion,
                    RuleVersions = ruleVersions,
                    ProfileVersions = profiles.Values
                        .OrderBy(profile => profile.Product, StringComparer.Ordinal)
                        .Select(profile => new CanonicalManifestProfileVersion(
                            profile.ProfileId,
                            profile.ProfileVersion))
                        .ToArray(),
                    ConfiguredStates = configuredStates,
                    SemanticSeverityCounts = Enum
                        .GetValues<CanonicalSemanticSeverity>()
                        .Select(severity => new CanonicalManifestSeverityCount(
                            severity,
                            request.ComparisonReport.Findings.Count(finding =>
                                finding.Severity == severity)))
                        .ToArray(),
                    CompletenessStatus = CompletenessStatus
                },
                GeneratedAtUtc = timestamp.ToUniversalTime()
            };
        }

        private static string SerializeManifest(CanonicalCandidateManifest manifest)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(manifest, options) + "\n";
        }

        private static void RejectApprovedBaselinePath(
            string candidatePath,
            string projectRoot)
        {
            var protectedPaths = new[] { projectRoot, DefaultProjectRoot() }
                .Select(Path.GetFullPath)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .SelectMany(root =>
                {
                    var approvedDirectory = Path.Combine(
                        root,
                        "Resources",
                        "ExpectedForms",
                        "SFP");
                    return new[]
                    {
                        Path.Combine(approvedDirectory, "SFP.json"),
                        Path.Combine(approvedDirectory, "SFP_RATEPOLICY.json")
                    };
                });
            if (protectedPaths.Any(path =>
                    Path.GetFullPath(path).Equals(
                        candidatePath,
                        StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException(
                    "Canonical candidate emission cannot overwrite an approved Forms baseline.");
            }
        }

        private static string DefaultProjectRoot() =>
            Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                ".."));

        private static IEnumerable<string> Scenarios(
            CanonicalExpectedDestination destination) =>
            destination switch
            {
                CanonicalExpectedDestination.BASE => new[] { "BASIC", "CE" },
                CanonicalExpectedDestination.BASIC => new[] { "BASIC" },
                CanonicalExpectedDestination.CE => new[] { "CE" },
                _ => Array.Empty<string>()
            };

        private static string Sha256(string value) =>
            Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));

        private static string CreatePackageCorrelationId(
            CanonicalCandidateEmissionRequest request,
            string candidateHash,
            string comparisonHash,
            string projectionHash)
        {
            var binding = string.Join(
                "\n",
                candidateHash,
                comparisonHash,
                projectionHash,
                request.ComparisonReport.ApprovedBaselineSha256,
                request.GeneratorVersion,
                request.Projection.RuleSetId,
                request.Projection.RuleVersion,
                request.ComparisonReport.ComparisonRuleVersion,
                string.Join(
                    ";",
                    request.RuleVersions
                        .OrderBy(pair => pair.Key, StringComparer.Ordinal)
                        .Select(pair => $"{pair.Key}={pair.Value}")),
                string.Join(
                    ";",
                    request.InputArtifacts
                        .OrderBy(artifact => artifact.Role, StringComparer.Ordinal)
                        .ThenBy(artifact => artifact.Identity, StringComparer.Ordinal)
                        .Select(artifact =>
                            $"{artifact.Role}:{artifact.Identity}:{artifact.Sha256}")));
            return "FORMS-" + Sha256(binding)[..24];
        }

        private static void ValidateSha256(string hash, string label)
        {
            if (hash == null
                || hash.Length != 64
                || hash.Any(character =>
                    !Uri.IsHexDigit(character)))
            {
                throw new InvalidOperationException(
                    $"Invalid SHA-256 for {label}.");
            }
        }

        private sealed record ProfileDefinition(
            string Product,
            string ProfileId,
            string ProfileVersion,
            string[] States);

        private sealed class CandidateValue
        {
            private CandidateValue(
                string scalar,
                string[] states,
                IReadOnlyDictionary<string, string> statuses)
            {
                Scalar = scalar;
                States = states;
                Statuses = statuses;
            }

            private string Scalar { get; }
            private string[] States { get; }
            private IReadOnlyDictionary<string, string> Statuses { get; }

            public static CandidateValue Create(
                IReadOnlyList<string> recordStates,
                string status,
                IReadOnlyList<string> supportedStates)
            {
                var states = recordStates
                    .OrderBy(state => state, StringComparer.Ordinal)
                    .ToArray();
                if (status == "YM"
                    && states.SequenceEqual(
                        supportedStates.OrderBy(
                            state => state,
                            StringComparer.Ordinal)))
                {
                    return new CandidateValue("all", null, null);
                }
                if (status == "YM")
                    return new CandidateValue(null, states, null);
                var statuses = new SortedDictionary<string, string>(
                    StringComparer.Ordinal);
                foreach (var state in states)
                    statuses.Add(state, status);
                return new CandidateValue(null, null, statuses);
            }

            public void Write(Utf8JsonWriter writer)
            {
                if (Scalar != null)
                {
                    writer.WriteStringValue(Scalar);
                    return;
                }
                if (States != null)
                {
                    writer.WriteStartArray();
                    foreach (var state in States)
                        writer.WriteStringValue(state);
                    writer.WriteEndArray();
                    return;
                }
                writer.WriteStartObject();
                foreach (var status in Statuses)
                    writer.WriteString(status.Key, status.Value);
                writer.WriteEndObject();
            }
        }
    }
}
