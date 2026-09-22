#nullable enable
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Reporting;

public static class ScenarioReportProjector
{
    public static ScenarioReportProjection Project(
        ArtifactManifest manifest,
        ScenarioReportMetadata metadata,
        ReportRedactor? redactor = null)
    {
        ArgumentNullException.ThrowIfNull(manifest);
        ArgumentNullException.ThrowIfNull(metadata);
        redactor ??= new ReportRedactor();
        Validate(manifest, metadata);
        var paths = manifest.Artifacts.Where(item => item.RelativePath != null).Select(item => item.RelativePath!)
            .Concat(metadata.Steps.SelectMany(item => item.Screenshots))
            .Concat(metadata.DeferredVerifications.Where(item => item.Screenshot != null).Select(item => item.Screenshot!));
        if (paths.Any(path => redactor.Text(path) != path))
            throw new ArtifactEvidenceException("Sensitive artifact filenames cannot be published; use neutral checkpoint paths.");

        return new ScenarioReportProjection
        {
            SchemaVersion = ScenarioReportProjection.CurrentSchemaVersion,
            ManifestVersion = manifest.Version,
            RunId = redactor.Text(manifest.RunId),
            ScenarioId = redactor.Text(manifest.ScenarioId),
            AutomationId = redactor.Text(manifest.AutomationId),
            TestFullName = redactor.Text(manifest.TestIdentity),
            TestIdentityHash = IdentityHash(manifest.TestIdentity!),
            ManifestFingerprint = ManifestFingerprint(manifest),
            ProfileName = redactor.Text(manifest.ProfileName),
            Status = Status(manifest),
            AuthoritativeScenarioFailed = manifest.AuthoritativeScenarioFailed,
            ComponentOutcomes = manifest.ComponentOutcomes.ToImmutableDictionary(
                item => redactor.Text(item.Key), item => item.Value, StringComparer.Ordinal),
            RequiredEvidence = manifest.RequiredEvidence
                .Select(item => item.ToString()).OrderBy(item => item, StringComparer.Ordinal)
                .ToImmutableArray(),
            EvidenceErrors = manifest.EvidenceErrors.Select(redactor.Text).ToImmutableArray(),
            StartedAtUtc = manifest.StartedAtUtc,
            CompletedAtUtc = manifest.CompletedAtUtc,
            ExecutionId = redactor.Text(metadata.ExecutionId),
            AttemptNumber = metadata.AttemptNumber,
            Feature = redactor.Text(metadata.Feature),
            Scenario = redactor.Text(metadata.Scenario),
            Application = redactor.Text(metadata.Application),
            State = redactor.Text(metadata.State),
            Lob = redactor.Text(metadata.Lob),
            Tags = metadata.Tags.Select(redactor.Text).ToImmutableArray(),
            Steps = metadata.Steps.Select(step => step with
            {
                Text = redactor.Text(step.Text),
                Binding = step.Binding is { } binding
                    ? binding with
                    {
                        Method = redactor.Text(binding.Method),
                        SourceFile = redactor.Text(binding.SourceFile)
                    }
                    : null,
                Data = redactor.Data(step.Data),
                Error = redactor.Text(step.Error),
                ConsoleErrors = step.ConsoleErrors.Select(redactor.Text).ToImmutableArray(),
                NetworkErrors = step.NetworkErrors.Select(redactor.Text).ToImmutableArray()
            }).ToImmutableArray(),
            DeferredVerifications = metadata.DeferredVerifications.Select(item => item with
            {
                BusinessStep = redactor.Text(item.BusinessStep),
                Page = redactor.Text(item.Page),
                Control = redactor.Text(item.Control),
                Property = redactor.Text(item.Property),
                Expected = redactor.Value(item.Control + "." + item.Property, item.Expected),
                Error = redactor.Text(item.Error)
            }).ToImmutableArray(),
            Diagnostics = metadata.Diagnostics.Select(item => item with
            {
                Component = redactor.Text(item.Component),
                Level = redactor.Text(item.Level),
                Message = redactor.Text(item.Message)
            }).ToImmutableArray(),
            Artifacts = manifest.Artifacts.Select(item => new ReportArtifactReference(
                item.Kind.ToString(),
                redactor.Text(item.Checkpoint),
                item.RelativePath,
                item.CapturedAtUtc)).ToImmutableArray()
        };
    }

    public static string IdentityHash(string identity) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(identity)));

    public static string ManifestFingerprint(ArtifactManifest manifest) =>
        IdentityHash(ReportJson.Serialize(manifest));

    public static ImmutableArray<ReportIssue> FindConsistencyIssues(
        ScenarioReportProjection projection)
    {
        var issues = ImmutableArray.CreateBuilder<ReportIssue>();
        if (projection.Status != ReportStatus.Fail &&
            (projection.AuthoritativeScenarioFailed ||
             projection.ComponentOutcomes.Any(item => !item.Value) ||
             projection.EvidenceErrors.Length > 0 ||
             projection.DeferredVerifications.Length > 0 ||
             projection.Steps.Any(item => item.Status == ReportStatus.Fail)))
        {
            issues.Add(new ReportIssue(
                "outcome-inconsistent",
                "The manifest does not declare failure despite failed scenario, component, step, deferred assertion or evidence records.",
                projection.TestFullName));
        }
        foreach (var error in projection.EvidenceErrors)
            issues.Add(new ReportIssue("manifest-evidence-error", error, projection.TestFullName));
        if (projection.Status == ReportStatus.Pass &&
            projection.Steps.Any(item => item.Status == ReportStatus.Skip))
            issues.Add(new ReportIssue(
                "step-skipped", "A passed manifest contains skipped business steps.", projection.TestFullName));
        return issues.ToImmutable();
    }

    private static ReportStatus Status(ArtifactManifest manifest) => manifest.Outcome switch
    {
        ArtifactOutcome.Passed => ReportStatus.Pass,
        ArtifactOutcome.Failed => ReportStatus.Fail,
        ArtifactOutcome.Skipped => ReportStatus.Skip,
        _ => throw new ArgumentException("Unsupported canonical artifact outcome.", nameof(manifest))
    };

    private static void Validate(ArtifactManifest manifest, ScenarioReportMetadata metadata)
    {
        if (manifest.Version != 2 || string.IsNullOrWhiteSpace(manifest.RunId) ||
            string.IsNullOrWhiteSpace(manifest.ScenarioId) ||
            string.IsNullOrWhiteSpace(manifest.AutomationId) ||
            string.IsNullOrWhiteSpace(manifest.TestIdentity) ||
            string.IsNullOrWhiteSpace(manifest.ProfileName) ||
            string.IsNullOrWhiteSpace(manifest.TrxMetadataPath) ||
            string.IsNullOrWhiteSpace(manifest.TimingSummaryPath) ||
            manifest.CompletedAtUtc < manifest.StartedAtUtc ||
            manifest.StartedAtUtc == default ||
            manifest.Artifacts == null || manifest.RequiredEvidence == null ||
            manifest.EvidenceErrors == null || manifest.ComponentOutcomes == null)
            throw new ArgumentException("The canonical artifact manifest is incomplete.", nameof(manifest));
        if (manifest.Artifacts.Any(item => item == null || !Enum.IsDefined(item.Kind)) ||
            manifest.RequiredEvidence.Any(item => !Enum.IsDefined(item)))
            throw new ArgumentException("The manifest contains an unsupported artifact kind.", nameof(manifest));
        foreach (var artifact in manifest.Artifacts.Where(item => item.RelativePath != null))
            _ = ReportPaths.NormalizeRelative(artifact.RelativePath!);
        if (manifest.Artifacts.Count(item => item.Kind == ArtifactKind.TrxMetadata &&
                item.RelativePath == manifest.TrxMetadataPath) != 1 ||
            manifest.Artifacts.Count(item => item.Kind == ArtifactKind.TimingSummary &&
                item.RelativePath == manifest.TimingSummaryPath) != 1)
            throw new ArgumentException("The manifest must reference its canonical timing and TRX metadata records.", nameof(manifest));
        if (metadata.AttemptNumber < 1 || string.IsNullOrWhiteSpace(metadata.ExecutionId) ||
            string.IsNullOrWhiteSpace(metadata.Feature) || string.IsNullOrWhiteSpace(metadata.Scenario) ||
            string.IsNullOrWhiteSpace(metadata.Application) || string.IsNullOrWhiteSpace(metadata.State) ||
            string.IsNullOrWhiteSpace(metadata.Lob) || metadata.Steps.IsDefault || metadata.Tags.IsDefault ||
            metadata.DeferredVerifications.IsDefault || metadata.Diagnostics.IsDefault)
            throw new ArgumentException("Scenario report metadata is incomplete.", nameof(metadata));

        var seen = new System.Collections.Generic.HashSet<int>();
        var depths = new System.Collections.Generic.Dictionary<int, int>();
        foreach (var step in metadata.Steps)
        {
            if (step == null || step.Order < 1 || !seen.Add(step.Order) ||
                string.IsNullOrWhiteSpace(step.Text) ||
                !double.IsFinite(step.DurationMilliseconds) || step.DurationMilliseconds < 0 ||
                step.StartedAtUtc == default || step.Data == null ||
                step.ConsoleErrors.IsDefault || step.NetworkErrors.IsDefault || step.Screenshots.IsDefault ||
                !Enum.IsDefined(step.Status) || step.Status == ReportStatus.Unknown ||
                step.ParentOrder is { } parent && (parent >= step.Order || !seen.Contains(parent)))
                throw new ArgumentException("Step records require unique ordered IDs, valid parents, timing and explicit status.", nameof(metadata));
            var depth = step.ParentOrder is { } parentOrder ? depths[parentOrder] + 1 : 1;
            if (depth > 64)
                throw new ArgumentException("Business step hierarchy exceeds the safe rendering depth.", nameof(metadata));
            depths.Add(step.Order, depth);
            foreach (var screenshot in step.Screenshots)
                _ = ReportPaths.NormalizeRelative(screenshot);
        }
        if (!metadata.Steps.Select(step => step.Order).SequenceEqual(metadata.Steps.Select(step => step.Order).Order()))
            throw new ArgumentException("Business step records must be ordered.", nameof(metadata));
        foreach (var failure in metadata.DeferredVerifications)
        {
            if (failure == null || failure.Timestamp == default)
                throw new ArgumentException("Deferred failures require timestamps.", nameof(metadata));
            if (failure.Screenshot != null)
                _ = ReportPaths.NormalizeRelative(failure.Screenshot);
        }
        if (metadata.Diagnostics.Any(item => item == null || item.Timestamp == default))
            throw new ArgumentException("Diagnostics require timestamps.", nameof(metadata));
    }
}
