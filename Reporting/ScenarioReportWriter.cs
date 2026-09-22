#nullable enable
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Reporting;

public static class ScenarioReportWriter
{
    public const string ReportRelativePath = ArtifactReportPaths.Report;
    public const string ResultRelativePath = ArtifactReportPaths.Result;

    public static ScenarioReportFiles Write(
        string scenarioRoot,
        ArtifactManifest manifest,
        ScenarioReportMetadata metadata,
        ReportRedactor? redactor = null,
        ReportLimits? limits = null)
    {
        limits ??= new ReportLimits();
        limits.Validate();
        var projection = ScenarioReportProjector.Project(manifest, metadata, redactor);
        RequireReservation("ScenarioReportHtml", ReportRelativePath);
        RequireReservation("ScenarioResultJson", ResultRelativePath);
        var reportPath = ReportPaths.Resolve(scenarioRoot, ReportRelativePath);
        var resultPath = ReportPaths.Resolve(scenarioRoot, ResultRelativePath);
        var evidence = new ReportEvidenceReader(limits, redactor).Read(
            projection, scenarioRoot, scenarioRoot, Path.GetDirectoryName(reportPath)!,
            generatingScenarioDocuments: true);
        var documents = ScenarioReportRenderer.Render(projection, evidence, limits, redactor);
        if (Encoding.UTF8.GetByteCount(documents.Html) > limits.MaxReportHtmlBytes)
        {
            evidence = evidence with
            {
                Files = evidence.Files.Select(file => file with { ImageDataUri = null }).ToImmutableArray()
            };
            documents = ScenarioReportRenderer.Render(projection, evidence, limits, redactor);
        }
        if (Encoding.UTF8.GetByteCount(documents.Html) > limits.MaxReportHtmlBytes ||
            Encoding.UTF8.GetByteCount(documents.Json) > limits.MaxInputJsonBytes)
            throw new ArtifactEvidenceException("Scenario report output exceeds the configured HTML/JSON limit.");
        ReportPaths.WriteAtomic(scenarioRoot, ResultRelativePath, documents.Json);
        ReportPaths.WriteAtomic(scenarioRoot, ReportRelativePath, documents.Html);
        return new ScenarioReportFiles(reportPath, resultPath, evidence.Issues);

        void RequireReservation(string kind, string relative)
        {
            if (projection.Artifacts.Count(item =>
                    item.Kind == kind && item.RelativePath?.Replace('\\', '/') == relative) != 1)
                throw new ArtifactEvidenceException(
                    $"The canonical manifest must reserve exactly one {kind} at {relative} before rendering.");
        }
    }
}
