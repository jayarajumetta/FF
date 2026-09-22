#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Reporting;

[JsonConverter(typeof(ReportStatusConverter))]
public enum ReportStatus
{
    Pass,
    Fail,
    Skip,
    Unknown
}

public sealed class ReportStatusConverter : JsonConverter<ReportStatus>
{
    public override ReportStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) => reader.GetString() switch
        {
            "PASS" => ReportStatus.Pass,
            "FAIL" => ReportStatus.Fail,
            "SKIP" => ReportStatus.Skip,
            "UNKNOWN" => ReportStatus.Unknown,
            _ => throw new JsonException("Unsupported report status.")
        };

    public override void Write(
        Utf8JsonWriter writer,
        ReportStatus value,
        JsonSerializerOptions options) => writer.WriteStringValue(value.Text());
}

public static class ReportStatusText
{
    public static string Text(this ReportStatus status) => status switch
    {
        ReportStatus.Pass => "PASS",
        ReportStatus.Fail => "FAIL",
        ReportStatus.Skip => "SKIP",
        ReportStatus.Unknown => "UNKNOWN",
        _ => throw new ArgumentOutOfRangeException(nameof(status))
    };
}

public sealed record ReportBinding(string Method, string SourceFile, int? Line = null);

public sealed record ReportStep(
    int Order,
    string Text,
    [property: JsonRequired] ReportStatus Status,
    DateTimeOffset StartedAtUtc,
    [property: JsonRequired] double DurationMilliseconds)
{
    public int? ParentOrder { get; init; }
    public ReportBinding? Binding { get; init; }
    public ImmutableDictionary<string, string> Data { get; init; } =
        ImmutableDictionary<string, string>.Empty;
    public string Error { get; init; } = "";
    public ImmutableArray<string> ConsoleErrors { get; init; } = [];
    public ImmutableArray<string> NetworkErrors { get; init; } = [];
    public ImmutableArray<string> Screenshots { get; init; } = [];
}

public sealed record DeferredReportFailure(
    DateTimeOffset Timestamp,
    string BusinessStep,
    string Page,
    string Control,
    string Property,
    string Expected,
    string Error,
    string? Screenshot = null);

public sealed record ReportDiagnostic(
    DateTimeOffset Timestamp,
    string Component,
    string Level,
    string Message);

public sealed record ScenarioReportMetadata(
    string Feature,
    string Scenario,
    string Application,
    string State,
    string Lob,
    string ExecutionId,
    int AttemptNumber = 1)
{
    public ImmutableArray<string> Tags { get; init; } = [];
    public ImmutableArray<ReportStep> Steps { get; init; } = [];
    public ImmutableArray<DeferredReportFailure> DeferredVerifications { get; init; } = [];
    public ImmutableArray<ReportDiagnostic> Diagnostics { get; init; } = [];
}

public sealed record ReportArtifactReference(
    string Kind,
    string Checkpoint,
    string? RelativePath,
    DateTimeOffset CapturedAtUtc);

public sealed record ScenarioReportProjection
{
    public const string CurrentSchemaVersion = "2.0";
    public required string SchemaVersion { get; init; }
    public required int ManifestVersion { get; init; }
    public required string RunId { get; init; }
    public required string ScenarioId { get; init; }
    public required string AutomationId { get; init; }
    public required string TestFullName { get; init; }
    public required string TestIdentityHash { get; init; }
    public required string ManifestFingerprint { get; init; }
    public required string ProfileName { get; init; }
    public required ReportStatus Status { get; init; }
    public required bool AuthoritativeScenarioFailed { get; init; }
    public required ImmutableDictionary<string, bool> ComponentOutcomes { get; init; }
    public required ImmutableArray<string> RequiredEvidence { get; init; }
    public required ImmutableArray<string> EvidenceErrors { get; init; }
    public required DateTimeOffset StartedAtUtc { get; init; }
    public required DateTimeOffset CompletedAtUtc { get; init; }
    public double DurationMilliseconds => (CompletedAtUtc - StartedAtUtc).TotalMilliseconds;
    public required string ExecutionId { get; init; }
    public required int AttemptNumber { get; init; }
    public required string Feature { get; init; }
    public required string Scenario { get; init; }
    public required string Application { get; init; }
    public required string State { get; init; }
    public required string Lob { get; init; }
    public required ImmutableArray<string> Tags { get; init; }
    public required ImmutableArray<ReportStep> Steps { get; init; }
    public required ImmutableArray<DeferredReportFailure> DeferredVerifications { get; init; }
    public required ImmutableArray<ReportDiagnostic> Diagnostics { get; init; }
    public required ImmutableArray<ReportArtifactReference> Artifacts { get; init; }

    public ScenarioReportMetadata ToMetadata() => new(
        Feature, Scenario, Application, State, Lob, ExecutionId, AttemptNumber)
    {
        Tags = Tags,
        Steps = Steps,
        DeferredVerifications = DeferredVerifications,
        Diagnostics = Diagnostics
    };
}

public sealed record ReportIssue(string Code, string Message, string? TestIdentity = null);

public sealed record ReportEvidenceFile(
    string Kind,
    string Checkpoint,
    string RelativePath,
    string? Href,
    long SizeBytes,
    string? ImageDataUri = null,
    string? Text = null,
    bool Truncated = false);

public sealed record ScenarioReportEvidence(
    ImmutableArray<ReportEvidenceFile> Files,
    ImmutableArray<ReportIssue> Issues);

public sealed record ScenarioReportView(
    ScenarioReportProjection Projection,
    ScenarioReportEvidence Evidence,
    string? SourcePath = null);

public sealed record ReportTestResult(
    string TestIdentity,
    ReportStatus Status,
    double DurationMilliseconds,
    ImmutableArray<ScenarioReportView> Attempts,
    string FailureMessage = "");

public sealed record ConsolidatedReport(
    DateTimeOffset GeneratedAtUtc,
    ImmutableArray<ReportTestResult> Tests,
    ImmutableArray<ReportIssue> Issues,
    ImmutableArray<ScenarioReportView> UnmatchedEvidence)
{
    public ImmutableArray<string> DuplicateCopies { get; init; } = [];
}

public sealed record ScenarioReportDocuments(string Html, string Json);
public sealed record ConsolidatedReportDocuments(
    string Html,
    string LogHtml,
    string OutputXml,
    string SummaryJson);

public sealed record ScenarioReportFiles(
    string ReportPath,
    string ResultPath,
    ImmutableArray<ReportIssue> Issues);

public sealed record ReportLimits
{
    public int MaxLogBytes { get; init; } = 2 * 1024 * 1024;
    public int MaxImageBytes { get; init; } = 12 * 1024 * 1024;
    public int MaxImagesPerScenario { get; init; } = 20;
    public int MaxRawJsonBytes { get; init; } = 512 * 1024;
    public long MaxEmbeddedImageBytes { get; init; } = 24 * 1024 * 1024;
    public int MaxInputJsonBytes { get; init; } = 5 * 1024 * 1024;
    public int MaxReportHtmlBytes { get; init; } = 10 * 1024 * 1024;

    public void Validate()
    {
        if (MaxLogBytes < 1 || MaxImageBytes < 1 || MaxImagesPerScenario < 1 ||
            MaxRawJsonBytes < 1 || MaxEmbeddedImageBytes < 1 || MaxInputJsonBytes < 1 || MaxReportHtmlBytes < 1)
            throw new ArgumentOutOfRangeException(nameof(ReportLimits), "Report limits must be positive.");
    }
}

public static class ReportJson
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        WriteIndented = true
    };

    public static string Serialize<T>(T value) => JsonSerializer.Serialize(value, Options);

    public static T Deserialize<T>(string value)
    {
        using var document = JsonDocument.Parse(value);
        RequireUniqueProperties(document.RootElement);
        if (typeof(T) == typeof(ArtifactManifest))
        {
            var required = new[]
            {
                "version", "runId", "scenarioId", "automationId", "testIdentity", "profileName",
                "outcome", "authoritativeScenarioFailed", "componentOutcomes", "requiredEvidence",
                "evidenceErrors", "artifacts", "trxMetadataPath", "timingSummaryPath", "startedAtUtc", "completedAtUtc"
            };
            if (document.RootElement.ValueKind != JsonValueKind.Object)
                throw new JsonException("A canonical artifact manifest must be an object.");
            var properties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in document.RootElement.EnumerateObject())
                properties.Add(property.Name);
            foreach (var name in required)
                if (!properties.Contains(name))
                    throw new JsonException($"Canonical artifact manifest field '{name}' is required.");
        }
        try
        {
            return JsonSerializer.Deserialize<T>(document.RootElement, Options) ??
                throw new JsonException("The reporting JSON root cannot be null.");
        }
        catch (JsonException)
        {
            throw new JsonException("Reporting JSON does not match the required schema.");
        }
    }

    private static void RequireUniqueProperties(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in element.EnumerateObject())
            {
                if (!names.Add(property.Name))
                    throw new JsonException("Reporting JSON contains duplicate object properties.");
                RequireUniqueProperties(property.Value);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
                RequireUniqueProperties(item);
        }
    }
}
