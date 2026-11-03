using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public enum FormsMonitorEventType
    {
        NewFile,
        ContentModified,
        SharePointVersionChanged,
        Renamed,
        Replaced,
        MetadataChanged
    }

    public enum FormsMonitorSourceFamily
    {
        SFP,
        Common
    }

    public enum FormsMonitorReceiptStatus
    {
        Accepted,
        AcquisitionPending,
        DuplicateIgnored,
        MetadataOnly,
        NewContentState,
        InvalidEvent
    }

    public static class FormsDeltaPipelineContract
    {
        public const string ContractVersion = "1.0";
        public const string PipelineYaml =
            "Pipelines/pnc-automated-regression.yml";
        public const string ResultFileName = "forms-delta-result.json";

        public static readonly IReadOnlyList<string> RequiredQueueParameters =
            new[]
            {
                "pipelineMode"
            };

        public static readonly IReadOnlyList<string> RequiredQueueVariables =
            new[]
            {
                "FORMS_DELTA_SOURCE_FAMILY",
                "FORMS_DELTA_EVENT_ID",
                "FORMS_DELTA_CORRELATION_ID",
                "FORMS_DELTA_PREVIOUS_SOURCE_IDENTITY",
                "FORMS_DELTA_PREVIOUS_SOURCE_REFERENCE",
                "FORMS_DELTA_PREVIOUS_SOURCE_SHA256",
                "FORMS_DELTA_CURRENT_SOURCE_IDENTITY",
                "FORMS_DELTA_CURRENT_SOURCE_REFERENCE",
                "FORMS_DELTA_CURRENT_SOURCE_SHA256",
                "FORMS_DELTA_COUNTERPART_SOURCE_IDENTITY",
                "FORMS_DELTA_COUNTERPART_SOURCE_REFERENCE",
                "FORMS_DELTA_COUNTERPART_SOURCE_SHA256",
                "FORMS_DELTA_APPROVED_BASELINE_SHA256",
                "FORMS_DELTA_EXPECTED_BRANCH"
            };

        public static readonly IReadOnlyList<string> OutputVariables =
            new[]
            {
                "FormsDeltaStatus",
                "FormsDeltaNotificationWorthy",
                "FormsDeltaResultPath",
                "FormsDeltaPackageCorrelationId",
                "FormsDeltaAffectedIdentitySha256",
                "FormsDeltaCandidateSha256",
                "FormsDeltaReportSha256"
            };
    }

    public sealed class FormsMonitorHandoffEvent
    {
        public string ContractVersion { get; init; } = "";
        public string EventId { get; init; } = "";
        public string CorrelationId { get; init; } = "";
        public FormsMonitorEventType EventType { get; init; }
        public FormsMonitorSourceFamily SourceFamily { get; init; }
        public string SiteId { get; init; } = "";
        public string LibraryId { get; init; } = "";
        public string FolderIdentity { get; init; } = "";
        public string ItemId { get; init; } = "";
        public string SharePointVersion { get; init; }
        public string SharePointChangeToken { get; init; }
        public string ETag { get; init; }
        public string CurrentFileName { get; init; } = "";
        public string PriorFileName { get; init; }
        public string CurrentLogicalVersion { get; init; } = "";
        public string PriorLogicalVersion { get; init; }
        public Uri CanonicalSourceLink { get; init; }
        public DateTimeOffset DetectedAt { get; init; }
        public DateTimeOffset? ModifiedAt { get; init; }
        public string Modifier { get; init; }
        public string CurrentContentHash { get; init; }
        public string PriorContentHash { get; init; }
        public bool HashPending { get; init; }
        public string ExpectedArtifact { get; init; } = "";
        public string RetrievalMechanism { get; init; } = "";
        public string RetrievalReference { get; init; } = "";
        public string RecommendedNextAction { get; init; } = "";
    }

    public sealed class FormsMonitorReceipt
    {
        public string ProcessingKey { get; init; } = "";
        public string ProcessingContractVersion { get; init; } = "";
        public FormsMonitorReceiptStatus Status { get; init; }
        public string EventId { get; init; } = "";
        public string CorrelationId { get; init; } = "";
        public FormsMonitorEventType? EventType { get; init; }
        public FormsMonitorSourceFamily? SourceFamily { get; init; }
        public string ItemId { get; init; } = "";
        public string SourceRevision { get; init; } = "";
        public string CurrentContentHash { get; init; } = "";
        public bool ContentAnalysisRequired { get; init; }
        public string ExistingProcessingKey { get; init; }
        public string RecommendedNextAction { get; init; } = "";
        public IReadOnlyList<string> ValidationErrors { get; init; } = Array.Empty<string>();
    }

    public interface IFormsMonitorReceiptStore
    {
        FormsMonitorReceipt FindByProcessingKey(string processingKey);
        FormsMonitorReceipt FindByContent(
            FormsMonitorSourceFamily sourceFamily,
            string itemId,
            string contentHash,
            string processingContractVersion);
        FormsMonitorReceipt FindLatestForItem(
            FormsMonitorSourceFamily sourceFamily,
            string itemId,
            string processingContractVersion);
        void Save(FormsMonitorReceipt receipt);
    }

    public sealed class InMemoryFormsMonitorReceiptStore : IFormsMonitorReceiptStore
    {
        private readonly List<FormsMonitorReceipt> _receipts = new();
        private readonly object _sync = new();

        public FormsMonitorReceipt FindByProcessingKey(string processingKey)
        {
            lock (_sync)
                return _receipts.LastOrDefault(receipt => receipt.ProcessingKey == processingKey);
        }

        public FormsMonitorReceipt FindByContent(
            FormsMonitorSourceFamily sourceFamily,
            string itemId,
            string contentHash,
            string processingContractVersion)
        {
            lock (_sync)
            {
                return _receipts.LastOrDefault(receipt =>
                    receipt.SourceFamily == sourceFamily
                    && receipt.ItemId.Equals(itemId, StringComparison.OrdinalIgnoreCase)
                    && receipt.CurrentContentHash.Equals(contentHash, StringComparison.OrdinalIgnoreCase)
                    && receipt.ProcessingContractVersion == processingContractVersion
                    && receipt.Status is FormsMonitorReceiptStatus.Accepted
                        or FormsMonitorReceiptStatus.NewContentState
                        or FormsMonitorReceiptStatus.MetadataOnly);
            }
        }

        public FormsMonitorReceipt FindLatestForItem(
            FormsMonitorSourceFamily sourceFamily,
            string itemId,
            string processingContractVersion)
        {
            lock (_sync)
            {
                return _receipts.LastOrDefault(receipt =>
                    receipt.SourceFamily == sourceFamily
                    && receipt.ItemId.Equals(itemId, StringComparison.OrdinalIgnoreCase)
                    && receipt.ProcessingContractVersion == processingContractVersion
                    && receipt.Status is FormsMonitorReceiptStatus.Accepted
                        or FormsMonitorReceiptStatus.NewContentState
                        or FormsMonitorReceiptStatus.MetadataOnly);
            }
        }

        public void Save(FormsMonitorReceipt receipt)
        {
            lock (_sync)
                _receipts.Add(receipt);
        }
    }

    public sealed class FormsMonitorHandoffService
    {
        private static readonly Regex ContractVersionPattern =
            new(@"^\d+\.\d+$", RegexOptions.Compiled);
        private static readonly Regex Sha256Pattern =
            new(@"^[A-Fa-f0-9]{64}$", RegexOptions.Compiled);
        private static readonly string[] SecretFieldFragments =
            new[]
            {
                "password", "secret", "credential", "credentials", "cookie",
                "authorization", "apikey", "accessToken", "refreshToken",
                "clientSecret", "connectionString", "serviceConnection"
            };
        private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

        private readonly IFormsMonitorReceiptStore _store;

        public FormsMonitorHandoffService(
            IFormsMonitorReceiptStore store,
            string processingContractVersion = "1.0")
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
            if (!ContractVersionPattern.IsMatch(processingContractVersion))
                throw new ArgumentException(
                    "Processing contract version must use numeric major.minor format.",
                    nameof(processingContractVersion));
            ProcessingContractVersion = processingContractVersion;
        }

        public string ProcessingContractVersion { get; }

        public FormsMonitorReceipt ProcessJson(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
                return Invalid("Payload is required.");

            FormsMonitorHandoffEvent handoffEvent;
            try
            {
                using var document = JsonDocument.Parse(payload);
                var secretFields = FindSecretFields(document.RootElement).ToArray();
                if (secretFields.Length > 0)
                {
                    return Invalid(
                        $"Secret-like fields are not allowed: {string.Join(", ", secretFields)}.");
                }
                var missingEnumFields = new[] { "eventType", "sourceFamily" }
                    .Where(name => !document.RootElement.TryGetProperty(name, out _))
                    .Select(name => $"{name} is required.")
                    .ToArray();
                if (missingEnumFields.Length > 0)
                    return Invalid(missingEnumFields);

                handoffEvent = JsonSerializer.Deserialize<FormsMonitorHandoffEvent>(
                    document.RootElement.GetRawText(),
                    JsonOptions);
            }
            catch (Exception exception) when (exception is JsonException or NotSupportedException)
            {
                return Invalid($"Invalid event JSON: {exception.Message}");
            }

            if (handoffEvent == null)
                return Invalid("Event payload could not be deserialized.");

            var errors = Validate(handoffEvent);
            if (errors.Count > 0)
                return Invalid(errors.ToArray());

            var currentHash = handoffEvent.HashPending
                ? "HASH_PENDING"
                : handoffEvent.CurrentContentHash.ToUpperInvariant();
            var processingKey = ComputeProcessingKey(handoffEvent, currentHash);
            var existingKeyReceipt = _store.FindByProcessingKey(processingKey);
            if (existingKeyReceipt != null)
                return Duplicate(handoffEvent, processingKey, currentHash, existingKeyReceipt);

            if (handoffEvent.HashPending)
            {
                var pending = CreateReceipt(
                    handoffEvent,
                    processingKey,
                    currentHash,
                    FormsMonitorReceiptStatus.AcquisitionPending,
                    contentAnalysisRequired: false);
                _store.Save(pending);
                return pending;
            }

            var existingContent = _store.FindByContent(
                handoffEvent.SourceFamily,
                handoffEvent.ItemId,
                currentHash,
                ProcessingContractVersion);
            if (existingContent != null)
            {
                if (handoffEvent.EventType == FormsMonitorEventType.MetadataChanged)
                {
                    var metadataOnly = CreateReceipt(
                        handoffEvent,
                        processingKey,
                        currentHash,
                        FormsMonitorReceiptStatus.MetadataOnly,
                        contentAnalysisRequired: false,
                        existingContent.ProcessingKey);
                    _store.Save(metadataOnly);
                    return metadataOnly;
                }
                return Duplicate(handoffEvent, processingKey, currentHash, existingContent);
            }

            var priorItemState = _store.FindLatestForItem(
                handoffEvent.SourceFamily,
                handoffEvent.ItemId,
                ProcessingContractVersion);
            var status = priorItemState != null
                ? FormsMonitorReceiptStatus.NewContentState
                : FormsMonitorReceiptStatus.Accepted;
            var receipt = CreateReceipt(
                handoffEvent,
                processingKey,
                currentHash,
                status,
                contentAnalysisRequired: true);
            _store.Save(receipt);
            return receipt;
        }

        public static string SerializeReceipt(FormsMonitorReceipt receipt) =>
            JsonSerializer.Serialize(receipt, JsonOptions);

        private string ComputeProcessingKey(FormsMonitorHandoffEvent handoffEvent, string currentHash)
        {
            var identity = string.Join(
                "|",
                handoffEvent.EventId.Trim(),
                handoffEvent.SourceFamily,
                handoffEvent.ItemId.Trim(),
                currentHash,
                ProcessingContractVersion);
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(identity)));
        }

        private FormsMonitorReceipt CreateReceipt(
            FormsMonitorHandoffEvent handoffEvent,
            string processingKey,
            string currentHash,
            FormsMonitorReceiptStatus status,
            bool contentAnalysisRequired,
            string existingProcessingKey = null) =>
            new()
            {
                ProcessingKey = processingKey,
                ProcessingContractVersion = ProcessingContractVersion,
                Status = status,
                EventId = handoffEvent.EventId,
                CorrelationId = handoffEvent.CorrelationId,
                EventType = handoffEvent.EventType,
                SourceFamily = handoffEvent.SourceFamily,
                ItemId = handoffEvent.ItemId,
                SourceRevision = FirstValue(
                    handoffEvent.SharePointVersion,
                    handoffEvent.SharePointChangeToken,
                    handoffEvent.ETag,
                    handoffEvent.CurrentLogicalVersion),
                CurrentContentHash = currentHash,
                ContentAnalysisRequired = contentAnalysisRequired,
                ExistingProcessingKey = existingProcessingKey,
                RecommendedNextAction = handoffEvent.RecommendedNextAction
            };

        private FormsMonitorReceipt Duplicate(
            FormsMonitorHandoffEvent handoffEvent,
            string processingKey,
            string currentHash,
            FormsMonitorReceipt existing) =>
            CreateReceipt(
                handoffEvent,
                processingKey,
                currentHash,
                FormsMonitorReceiptStatus.DuplicateIgnored,
                contentAnalysisRequired: false,
                existing.ProcessingKey);

        private FormsMonitorReceipt Invalid(params string[] errors) =>
            new()
            {
                ProcessingContractVersion = ProcessingContractVersion,
                Status = FormsMonitorReceiptStatus.InvalidEvent,
                ValidationErrors = errors.OrderBy(error => error, StringComparer.Ordinal).ToArray()
            };

        private static List<string> Validate(FormsMonitorHandoffEvent handoffEvent)
        {
            var errors = new List<string>();
            Require(handoffEvent.ContractVersion, "contractVersion", errors);
            if (!string.IsNullOrWhiteSpace(handoffEvent.ContractVersion)
                && !ContractVersionPattern.IsMatch(handoffEvent.ContractVersion))
            {
                errors.Add("contractVersion must use numeric major.minor format.");
            }
            Require(handoffEvent.EventId, "eventId", errors);
            Require(handoffEvent.CorrelationId, "correlationId", errors);
            Require(handoffEvent.SiteId, "siteId", errors);
            Require(handoffEvent.LibraryId, "libraryId", errors);
            Require(handoffEvent.FolderIdentity, "folderIdentity", errors);
            Require(handoffEvent.ItemId, "itemId", errors);
            Require(handoffEvent.CurrentFileName, "currentFileName", errors);
            Require(handoffEvent.CurrentLogicalVersion, "currentLogicalVersion", errors);
            Require(handoffEvent.ExpectedArtifact, "expectedArtifact", errors);
            Require(handoffEvent.RetrievalMechanism, "retrievalMechanism", errors);
            Require(handoffEvent.RetrievalReference, "retrievalReference", errors);
            Require(handoffEvent.RecommendedNextAction, "recommendedNextAction", errors);

            if (handoffEvent.CanonicalSourceLink == null
                || !handoffEvent.CanonicalSourceLink.IsAbsoluteUri
                || handoffEvent.CanonicalSourceLink.Scheme != Uri.UriSchemeHttps)
            {
                errors.Add("canonicalSourceLink must be an absolute HTTPS URI.");
            }
            if (handoffEvent.DetectedAt == default)
                errors.Add("detectedAt must be a valid timestamp.");
            if (handoffEvent.ModifiedAt == default && handoffEvent.Modifier != null)
                errors.Add("modifiedAt is required when modifier is supplied.");
            if (handoffEvent.ModifiedAt > handoffEvent.DetectedAt)
                errors.Add("modifiedAt cannot be later than detectedAt.");

            if (handoffEvent.HashPending)
            {
                if (!string.IsNullOrWhiteSpace(handoffEvent.CurrentContentHash))
                    errors.Add("currentContentHash must be omitted when hashPending is true.");
            }
            else if (!Sha256Pattern.IsMatch(handoffEvent.CurrentContentHash ?? ""))
            {
                errors.Add("currentContentHash must be a 64-character SHA-256 value.");
            }
            if (!string.IsNullOrWhiteSpace(handoffEvent.PriorContentHash)
                && !Sha256Pattern.IsMatch(handoffEvent.PriorContentHash))
            {
                errors.Add("priorContentHash must be a 64-character SHA-256 value.");
            }
            return errors;
        }

        private static IEnumerable<string> FindSecretFields(JsonElement element, string path = "$")
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in element.EnumerateObject())
                {
                    var propertyPath = $"{path}.{property.Name}";
                    if (IsSecretFieldName(property.Name))
                    {
                        yield return propertyPath;
                    }
                    foreach (var nested in FindSecretFields(property.Value, propertyPath))
                        yield return nested;
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                var index = 0;
                foreach (var item in element.EnumerateArray())
                {
                    foreach (var nested in FindSecretFields(item, $"{path}[{index}]"))
                        yield return nested;
                    index++;
                }
            }
        }

        private static void Require(string value, string name, ICollection<string> errors)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{name} is required.");
        }

        private static string FirstValue(params string[] values) =>
            values.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value)) ?? "";

        private static bool IsSecretFieldName(string fieldName)
        {
            var normalized = new string(fieldName
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLowerInvariant)
                .ToArray());
            if (normalized == "sharepointchangetoken")
                return false;
            return SecretFieldFragments.Any(fragment =>
                normalized.Contains(
                    new string(fragment
                        .Where(char.IsLetterOrDigit)
                        .Select(char.ToLowerInvariant)
                        .ToArray()),
                    StringComparison.Ordinal));
        }

        private static JsonSerializerOptions CreateJsonOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = false,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
