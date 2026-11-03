using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public sealed record CanonicalFormsDeltaOperationSettings
    {
        public string EventId { get; init; } = "";
        public string CorrelationId { get; init; } = "";
        public CanonicalFormsDeltaRequest Request { get; init; }
        public string ResultPath { get; init; } = "";
        public bool AllowReviewedChanges { get; init; }
        public bool WritePackage { get; init; }
        public bool OverwriteExisting { get; init; }
    }

    public sealed class CanonicalFormsDeltaOperationResult
    {
        public string ContractVersion { get; init; } =
            FormsDeltaPipelineContract.ContractVersion;
        public string EventId { get; init; } = "";
        public string CorrelationId { get; init; } = "";
        public FormsMonitorSourceFamily SourceFamily { get; init; }
        public string PreviousSourceIdentity { get; init; } = "";
        public string PreviousSourceReference { get; init; } = "";
        public string PreviousSourceSha256 { get; init; } = "";
        public string CurrentSourceIdentity { get; init; } = "";
        public string CurrentSourceReference { get; init; } = "";
        public string CurrentSourceSha256 { get; init; } = "";
        public string CounterpartSourceIdentity { get; init; } = "";
        public string CounterpartSourceReference { get; init; } = "";
        public string CounterpartSourceSha256 { get; init; } = "";
        public string ApprovedBaselineSha256 { get; init; } = "";
        public CanonicalFormsDeltaStatus Status { get; init; }
        public bool NotificationWorthy { get; init; }
        public bool WriteRequested { get; init; }
        public bool ReviewedChangesAllowed { get; init; }
        public IReadOnlyList<string> Reasons { get; init; } = Array.Empty<string>();
        public int RowDeltaCount { get; init; }
        public int FindingCount { get; init; }
        public string AffectedIdentitySha256 { get; init; }
        public string CandidateSha256 { get; init; }
        public string ReportSha256 { get; init; }
        public string PackageCorrelationId { get; init; }
        public CanonicalFormsDeltaPackagePaths Paths { get; init; }
    }

    public static class CanonicalFormsDeltaOperation
    {
        private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

        public static CanonicalFormsDeltaOperationSettings ReadSettings(
            Func<string, string> parameter,
            Func<string, string> environment,
            string projectRoot)
        {
            string Read(string name, string defaultValue = "")
            {
                var parameterValue = parameter(name);
                if (!string.IsNullOrWhiteSpace(parameterValue))
                    return parameterValue.Trim();
                var environmentValue = environment(name);
                return string.IsNullOrWhiteSpace(environmentValue)
                    ? defaultValue
                    : environmentValue.Trim();
            }

            var sourceFamilyText = Required(Read("DELTA_SOURCE_FAMILY"), "DELTA_SOURCE_FAMILY");
            if (!Enum.TryParse<FormsMonitorSourceFamily>(
                    sourceFamilyText,
                    ignoreCase: true,
                    out var sourceFamily))
            {
                throw new InvalidOperationException(
                    "DELTA_SOURCE_FAMILY must be SFP or Common.");
            }

            var eventId = SafeMetadata(
                Required(Read("DELTA_EVENT_ID"), "DELTA_EVENT_ID"),
                "DELTA_EVENT_ID");
            var correlationId = SafeMetadata(
                Required(Read("DELTA_CORRELATION_ID"), "DELTA_CORRELATION_ID"),
                "DELTA_CORRELATION_ID");
            var writePackage = Bool(Read("DELTA_WRITE_PACKAGE"), false);
            var allowReviewed = Bool(Read("DELTA_ALLOW_REVIEWED_CHANGES"), false);
            if (writePackage && !allowReviewed)
            {
                throw new InvalidOperationException(
                    "DELTA_WRITE_PACKAGE requires DELTA_ALLOW_REVIEWED_CHANGES=true.");
            }

            CanonicalFormsDeltaSource Source(string prefix, string label) =>
                new(
                    SafeMetadata(
                        Required(Read($"{prefix}_IDENTITY"), $"{prefix}_IDENTITY"),
                        $"{prefix}_IDENTITY"),
                    Required(Read($"{prefix}_PATH"), $"{prefix}_PATH"),
                    ExactHash(
                        Required(Read($"{prefix}_SHA256"), $"{prefix}_SHA256"),
                        $"{prefix}_SHA256"),
                    SafeAcquisitionReference(
                        Required(Read($"{prefix}_REFERENCE"), $"{prefix}_REFERENCE"),
                        $"{prefix}_REFERENCE"));

            var approvedPath = Required(
                Read("DELTA_APPROVED_BASELINE"),
                "DELTA_APPROVED_BASELINE");
            var outputDirectory = Read(
                "DELTA_OUTPUT_DIRECTORY",
                Path.Combine(
                    projectRoot,
                    "TestResults",
                    "FormsBaseline",
                    "CanonicalDeltaReviewPackage"));
            var resultPath = Read(
                "DELTA_RESULT_PATH",
                Path.Combine(
                    projectRoot,
                    "TestResults",
                    "FormsBaseline",
                    FormsDeltaPipelineContract.ResultFileName));

            return new CanonicalFormsDeltaOperationSettings
            {
                EventId = eventId,
                CorrelationId = correlationId,
                AllowReviewedChanges = allowReviewed,
                WritePackage = writePackage,
                OverwriteExisting = Bool(Read("DELTA_OVERWRITE"), false),
                ResultPath = resultPath,
                Request = new CanonicalFormsDeltaRequest
                {
                    ChangedSourceFamily = sourceFamily,
                    PreviousChangedSource = Source(
                        "DELTA_PREVIOUS_SOURCE",
                        "previous changed source"),
                    CurrentChangedSource = Source(
                        "DELTA_CURRENT_SOURCE",
                        "current changed source"),
                    CurrentCounterpartSource = Source(
                        "DELTA_COUNTERPART_SOURCE",
                        "current counterpart source"),
                    ApprovedBaselinePath = approvedPath,
                    ExpectedApprovedBaselineSha256 = ExactHash(
                        Required(
                            Read("DELTA_APPROVED_BASELINE_SHA256"),
                            "DELTA_APPROVED_BASELINE_SHA256"),
                        "DELTA_APPROVED_BASELINE_SHA256"),
                    BasicFeaturePath = Read(
                        "DELTA_BASIC_FEATURE",
                        Path.Combine(
                            projectRoot,
                            "Features",
                            "SFP",
                            "SFP_BasicPolicy.feature")),
                    CountryEstateFeaturePath = Read(
                        "DELTA_CE_FEATURE",
                        Path.Combine(
                            projectRoot,
                            "Features",
                            "SFP",
                            "SFP_CE.feature")),
                    OutputDirectory = outputDirectory,
                    EffectiveDate = new DateOnly(2027, 4, 3),
                    GeneratorVersion = Read(
                        "DELTA_GENERATOR_VERSION",
                        "CanonicalFormsDeltaPipeline-1.0"),
                    RuleVersions = new SortedDictionary<string, string>(
                        StringComparer.Ordinal)
                    {
                        ["Aggregation"] = "1.0",
                        ["Applicability"] =
                            CanonicalApplicabilityInterpreter.RuleVersion,
                        ["ScenarioEligibility"] =
                            CanonicalScenarioEligibilityEvaluator.RuleVersion,
                        ["EditionLifecycle"] =
                            CanonicalEditionLifecycleResolver.RuleVersion,
                        ["Projection"] =
                            CanonicalExpectedRecordProjector.RuleVersion,
                        ["Delta"] = CanonicalFormsDeltaPipeline.RuleVersion
                    }
                }
            };
        }

        public static CanonicalFormsDeltaOperationResult Run(
            CanonicalFormsDeltaOperationSettings settings)
        {
            if (settings == null)
                throw new InvalidOperationException("Delta operation settings are required.");
            var result = CanonicalFormsDeltaPipeline.Run(
                settings.Request,
                new CanonicalFormsDeltaOptions
                {
                    WritePackage = settings.WritePackage,
                    OverwriteExisting = settings.OverwriteExisting
                });
            var operationResult = new CanonicalFormsDeltaOperationResult
            {
                EventId = settings.EventId,
                CorrelationId = settings.CorrelationId,
                SourceFamily = settings.Request.ChangedSourceFamily,
                PreviousSourceIdentity =
                    settings.Request.PreviousChangedSource.Identity,
                PreviousSourceReference =
                    settings.Request.PreviousChangedSource.AcquisitionReference,
                PreviousSourceSha256 =
                    settings.Request.PreviousChangedSource.ExpectedSha256.ToUpperInvariant(),
                CurrentSourceIdentity =
                    settings.Request.CurrentChangedSource.Identity,
                CurrentSourceReference =
                    settings.Request.CurrentChangedSource.AcquisitionReference,
                CurrentSourceSha256 =
                    settings.Request.CurrentChangedSource.ExpectedSha256.ToUpperInvariant(),
                CounterpartSourceIdentity =
                    settings.Request.CurrentCounterpartSource.Identity,
                CounterpartSourceReference =
                    settings.Request.CurrentCounterpartSource.AcquisitionReference,
                CounterpartSourceSha256 =
                    settings.Request.CurrentCounterpartSource.ExpectedSha256.ToUpperInvariant(),
                ApprovedBaselineSha256 =
                    settings.Request.ExpectedApprovedBaselineSha256.ToUpperInvariant(),
                Status = result.Status,
                NotificationWorthy = result.NotificationWorthy,
                WriteRequested = settings.WritePackage,
                ReviewedChangesAllowed = settings.AllowReviewedChanges,
                Reasons = result.Reasons,
                RowDeltaCount = result.RowDeltas.Count,
                FindingCount = result.Findings.Count,
                AffectedIdentitySha256 = result.AffectedIdentitySha256,
                CandidateSha256 = result.CandidateSha256,
                ReportSha256 = result.ReportSha256,
                PackageCorrelationId = result.PackageCorrelationId,
                Paths = result.Paths
            };
            WriteResult(settings.ResultPath, operationResult);
            EmitAzureDevOpsVariables(settings.ResultPath, operationResult);
            return operationResult;
        }

        internal static void WriteResult(
            string path,
            CanonicalFormsDeltaOperationResult result)
        {
            var fullPath = Path.GetFullPath(
                Required(path, "DELTA_RESULT_PATH"));
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
            var json = JsonSerializer.Serialize(result, JsonOptions) + "\n";
            foreach (var fragment in new[]
                     {
                         "password",
                         "secret",
                         "credential",
                         "authorization",
                         "accesstoken",
                         "refreshtoken",
                         "clientsecret",
                         "connectionstring",
                         "sig="
                     })
            {
                if (json.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "Delta operation result contains prohibited credential material.");
                }
            }
            File.WriteAllText(fullPath, json);
        }

        private static void EmitAzureDevOpsVariables(
            string resultPath,
            CanonicalFormsDeltaOperationResult result)
        {
            SetVariable("FormsDeltaStatus", result.Status.ToString());
            SetVariable(
                "FormsDeltaNotificationWorthy",
                result.NotificationWorthy.ToString().ToLowerInvariant());
            SetVariable("FormsDeltaResultPath", Path.GetFullPath(resultPath));
            SetVariable(
                "FormsDeltaPackageCorrelationId",
                result.PackageCorrelationId);
            SetVariable(
                "FormsDeltaAffectedIdentitySha256",
                result.AffectedIdentitySha256);
            SetVariable("FormsDeltaCandidateSha256", result.CandidateSha256);
            SetVariable("FormsDeltaReportSha256", result.ReportSha256);
        }

        private static void SetVariable(string name, string value)
        {
            var safeValue = (value ?? "")
                .Replace("%", "%25", StringComparison.Ordinal)
                .Replace("\r", "%0D", StringComparison.Ordinal)
                .Replace("\n", "%0A", StringComparison.Ordinal)
                .Replace(";", "%3B", StringComparison.Ordinal)
                .Replace("]", "%5D", StringComparison.Ordinal);
            Console.WriteLine(
                $"##vso[task.setvariable variable={name};isOutput=true]{safeValue}");
        }

        private static string Required(string value, string name) =>
            !string.IsNullOrWhiteSpace(value)
                ? value
                : throw new InvalidOperationException($"{name} is required.");

        private static string ExactHash(string value, string name)
        {
            if (value.Length != 64 || !value.All(Uri.IsHexDigit))
                throw new InvalidOperationException($"{name} must be an exact SHA-256 value.");
            return value.ToUpperInvariant();
        }

        private static string SafeMetadata(string value, string name)
        {
            if (value.Any(char.IsControl))
                throw new InvalidOperationException($"{name} contains control characters.");
            return value;
        }

        private static string SafeAcquisitionReference(string value, string name)
        {
            SafeMetadata(value, name);
            if (value.Contains("://", StringComparison.Ordinal)
                || value.Contains('?', StringComparison.Ordinal)
                || value.Contains('#', StringComparison.Ordinal))
            {
                throw new InvalidOperationException(
                    $"{name} must be an opaque SharePoint identity/version reference, not a URL.");
            }
            return value;
        }

        private static bool Bool(string value, bool defaultValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;
            return bool.TryParse(value, out var parsed)
                ? parsed
                : throw new InvalidOperationException(
                    $"Boolean value '{value}' must be true or false.");
        }

        private static JsonSerializerOptions CreateJsonOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
