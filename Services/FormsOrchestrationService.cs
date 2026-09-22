#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.Clients;
using PnCTestAutomation.Models;
using PnCTestAutomation.Parsers;

namespace PnCTestAutomation.Services
{
    public sealed record FormsValidationRequest(
        string QuoteId,
        string State,
        string Lob,
        string TestCase);

    public sealed record FormsValidationRunResult(
        FormsValidationSummary Summary,
        IReadOnlyList<ArtifactRecord> Evidence);

    public sealed class FormsValidationException : Exception
    {
        public FormsValidationException(string stage, string message)
            : base($"Forms validation failed during {stage}: {message}")
        {
            Stage = stage;
        }

        public string Stage { get; }
    }

    public interface IFormsOrchestrationService
    {
        Task PrepareSessionAsync(string quoteId);
        Task<FormsValidationRunResult> ValidateAsync(
            FormsValidationRequest request);
    }

    public sealed class FormsOrchestrationService : IFormsOrchestrationService
    {
        private static readonly ArtifactKind[] RequiredEvidence =
        [
            ArtifactKind.FormsXml,
            ArtifactKind.FormsCsv,
            ArtifactKind.FormsHtml,
            ArtifactKind.FormsMarkdown,
            ArtifactKind.FormsTrx
        ];

        private readonly IFormsSessionProvider _sessionProvider;
        private readonly IFormsApiClient _formsClient;
        private readonly IFormsValidationService _validationService;
        private readonly IFormsEvidenceWriter _evidenceWriter;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _capture;
        private readonly IBusinessOutcomeVerifier _businessOutcomes;
        private readonly DuckCreekFormsConfig _config;
        private string? _preparedQuoteId;
        private string? _preparedSessionId;

        public FormsOrchestrationService(
            IFormsSessionProvider sessionProvider,
            IFormsApiClient formsClient,
            IFormsValidationService validationService,
            IFormsEvidenceWriter evidenceWriter,
            IArtifactContext artifacts,
            IArtifactCaptureService capture,
            IBusinessOutcomeVerifier businessOutcomes,
            DuckCreekFormsConfig config)
        {
            _sessionProvider = sessionProvider;
            _formsClient = formsClient;
            _validationService = validationService;
            _evidenceWriter = evidenceWriter;
            _artifacts = artifacts;
            _capture = capture;
            _businessOutcomes = businessOutcomes;
            _config = config;
        }

        public async Task PrepareSessionAsync(string quoteId)
        {
            ValidateIdentifier(quoteId, nameof(quoteId), 128);
            try
            {
                var session =
                    await _sessionProvider.PrepareSessionAsync(quoteId);
                if (string.IsNullOrWhiteSpace(session.SessionId))
                {
                    throw new FormsValidationException(
                        "session acquisition",
                        "DuckCreek did not provide a session.");
                }

                await _businessOutcomes.VerifyQuoteIdentityAsync(
                    quoteId,
                    session.DisplayedQuoteIdentity,
                    "forms-session");
                _preparedQuoteId = quoteId;
                _preparedSessionId = session.SessionId;
            }
            catch (FormsValidationException)
            {
                throw;
            }
            catch
            {
                throw new FormsValidationException(
                    "session acquisition",
                    "DuckCreek session setup did not complete.");
            }
        }

        public async Task<FormsValidationRunResult> ValidateAsync(
            FormsValidationRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            ValidateRequest(request);
            _artifacts.Require(RequiredEvidence);

            try
            {
                if (!string.Equals(
                        _preparedQuoteId,
                        request.QuoteId,
                        StringComparison.Ordinal) ||
                    string.IsNullOrWhiteSpace(_preparedSessionId))
                {
                    await PrepareSessionAsync(request.QuoteId);
                }

                var manuscript = _config.GetManuscriptForLob(request.Lob);
                var printJob = _config.GetPrintJobForLob(request.Lob);
                ValidateIdentifier(manuscript, "manuscript", 256);
                ValidateIdentifier(printJob, "printJob", 128);

                FormsBaselineSnapshot baseline;
                try
                {
                    baseline = _validationService.LoadExpectedBaseline(
                        request.Lob,
                        request.State,
                        request.TestCase);
                    if (baseline.Entries.Count == 0)
                    {
                        throw new FormsValidationException(
                            "baseline resolution",
                            "The resolved forms baseline contains no expectations.");
                    }
                }
                catch (FormsValidationException)
                {
                    throw;
                }
                catch
                {
                    throw new FormsValidationException(
                        "baseline resolution",
                        "A valid forms baseline was not available.");
                }

                string responseXml;
                try
                {
                    responseXml = await _formsClient.GetFormsAsync(
                        _preparedSessionId!,
                        manuscript,
                        printJob);
                }
                catch
                {
                    throw new FormsValidationException(
                        "Forms API request",
                        "DuckCreek did not return a usable response.");
                }

                await _capture.CaptureAsync(
                    ArtifactKind.FormsXml,
                    "forms-response",
                    ".xml",
                    path => File.WriteAllTextAsync(path, responseXml));

                List<ActualFormEntry> actualForms;
                FormsResponseMetadata metadata;
                try
                {
                    actualForms = FormsXmlParser.Parse(responseXml);
                    metadata = FormsXmlParser.ParseMetadata(responseXml);
                    ValidateResponse(actualForms);
                }
                catch (FormsValidationException)
                {
                    throw;
                }
                catch
                {
                    throw new FormsValidationException(
                        "response parsing",
                        "DuckCreek returned invalid forms XML.");
                }

                await _businessOutcomes.VerifyFormsContractAsync(
                    baseline,
                    metadata,
                    manuscript,
                    printJob);

                var summary = _validationService.Validate(
                    baseline.Entries.ToList(),
                    actualForms,
                    request.Lob,
                    request.State,
                    request.QuoteId);
                summary.ResponseMetadata = metadata;
                summary.TestCaseName = $"{request.Lob}_{request.TestCase}";

                FormsValidationService.PrintSummary(summary);
                await WriteEvidenceAsync(summary);

                _artifacts.RecordComponentOutcome(
                    "forms-validation",
                    summary.AllPassed);
                if (!summary.AllPassed)
                {
                    throw new FormsValidationException(
                        "business comparison",
                        $"{summary.Failed} mismatch(es) and {summary.Issues} invalid result(s) were detected.");
                }

                return new FormsValidationRunResult(
                    summary,
                    _artifacts.Records
                        .Where(record => RequiredEvidence.Contains(record.Kind))
                        .ToList());
            }
            catch
            {
                _artifacts.RecordComponentOutcome(
                    "forms-validation",
                    succeeded: false);
                throw;
            }
        }

        private async Task WriteEvidenceAsync(FormsValidationSummary summary)
        {
            await _capture.CaptureAsync(
                ArtifactKind.FormsCsv,
                "forms-results",
                ".csv",
                path =>
                {
                    _evidenceWriter.WriteCsv(summary, path);
                    return Task.CompletedTask;
                });
            await _capture.CaptureAsync(
                ArtifactKind.FormsHtml,
                "forms-report",
                ".html",
                path =>
                {
                    _evidenceWriter.WriteHtml(summary, path);
                    return Task.CompletedTask;
                });
            await _capture.CaptureAsync(
                ArtifactKind.FormsMarkdown,
                "forms-summary",
                ".md",
                path =>
                {
                    _evidenceWriter.WriteMarkdown(summary, path);
                    return Task.CompletedTask;
                });
            await _capture.CaptureAsync(
                ArtifactKind.FormsTrx,
                "forms-results",
                ".trx",
                path =>
                {
                    _evidenceWriter.WriteTrx(summary, path);
                    return Task.CompletedTask;
                });
        }

        private static void ValidateResponse(
            IReadOnlyCollection<ActualFormEntry> actualForms)
        {
            if (actualForms.Count == 0)
            {
                throw new FormsValidationException(
                    "response validation",
                    "DuckCreek returned no forms.");
            }

        }

        private static void ValidateRequest(FormsValidationRequest request)
        {
            ValidateIdentifier(request.QuoteId, nameof(request.QuoteId), 128);
            ValidateIdentifier(request.State, nameof(request.State), 3);
            ValidateIdentifier(request.Lob, nameof(request.Lob), 20);
            ValidateIdentifier(request.TestCase, nameof(request.TestCase), 20);
        }

        private static void ValidateIdentifier(
            string value,
            string field,
            int maximumLength)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Length > maximumLength ||
                value.Any(char.IsControl))
            {
                throw new FormsValidationException(
                    "input validation",
                    $"{field} is required and exceeds its safe input contract.");
            }
        }
    }
}
