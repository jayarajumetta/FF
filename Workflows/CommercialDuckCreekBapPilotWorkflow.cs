#nullable enable
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Pages.CommercialDuckCreekPages.BAP;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.Workflows
{
    public interface ICommercialDuckCreekBapPilotWorkflow
    {
        Task ApplyIntendedInputsAsync(
            CancellationToken cancellationToken = default);
        Task VerifyMaskedIdentityAsync(
            CancellationToken cancellationToken = default);
        Task CaptureBusinessCheckpointsAsync(
            CancellationToken cancellationToken = default);
        Task SaveAndCaptureQuoteAsync(
            CancellationToken cancellationToken = default);
        Task SearchReopenAndVerifyAsync(
            CancellationToken cancellationToken = default);
    }

    public sealed class CommercialDuckCreekBapPilotWorkflow :
        ICommercialDuckCreekBapPilotWorkflow
    {
        private readonly IPilotDataContext _dataContext;
        private readonly ICommercialDuckCreekBapPilotRuntime _runtime;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _capture;
        private string? _quoteDescription;

        public CommercialDuckCreekBapPilotWorkflow(
            IPilotDataContext dataContext,
            ICommercialDuckCreekBapPilotRuntime runtime,
            IQuoteHandoff quoteHandoff,
            IArtifactContext artifacts,
            IArtifactCaptureService capture)
        {
            _dataContext = dataContext;
            _runtime = runtime;
            _quoteHandoff = quoteHandoff;
            _artifacts = artifacts;
            _capture = capture;
        }

        public async Task ApplyIntendedInputsAsync(
            CancellationToken cancellationToken = default)
        {
            await _runtime.ApplyIntendedInputsAsync(
                Data(),
                cancellationToken);
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "cldc-bap-input-postconditions");
            await ScreenshotAsync(
                "cldc-bap-inputs-applied",
                cancellationToken);
        }

        public async Task VerifyMaskedIdentityAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var maskedIdentity = (await _runtime.ReadMaskedIdentityAsync(
                cancellationToken)).Trim();
            if (maskedIdentity.Equals(
                    data.SocialSecurityNumber,
                    StringComparison.Ordinal) ||
                !Matches(maskedIdentity, data.MaskedIdentityPattern))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Masked identity did not match the approved format.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "cldc-bap-masked-identity-verified");
            await ScreenshotAsync(
                "cldc-bap-masked-identity",
                cancellationToken);
        }

        public async Task CaptureBusinessCheckpointsAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var checkpoints = await _runtime.CaptureBusinessCheckpointsAsync(
                cancellationToken);
            _quoteDescription = checkpoints.QuoteDescription.Trim();
            if (!Matches(
                    _quoteDescription,
                    data.QuoteDescriptionPattern))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Quote description did not match the approved format.");
            }
            if (!Matches(
                    checkpoints.ScoreReference.Trim(),
                    data.ScoreReferencePattern))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Insurance score reference was missing or invalid.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "cldc-bap-business-checkpoints");
            await ScreenshotAsync(
                "cldc-bap-score-and-description",
                cancellationToken);
        }

        public async Task SaveAndCaptureQuoteAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var saved = await _runtime.SaveQuoteAsync(cancellationToken);
            if (!saved.Status.Equals(
                    data.SaveExpectation,
                    StringComparison.Ordinal))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Quote save status did not match the approved outcome.");
            }
            var identity = saved.QuoteIdentity.Trim();
            if (!Matches(identity, data.QuoteIdentityPattern))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Captured quote identity was missing or invalid.");
            }
            _quoteHandoff.Publish(identity);
            _artifacts.RecordMarker(
                ArtifactKind.QuoteHandoff,
                "cldc-bap-quote-captured");
            await ScreenshotAsync(
                "cldc-bap-quote-saved",
                cancellationToken);
        }

        public async Task SearchReopenAndVerifyAsync(
            CancellationToken cancellationToken = default)
        {
            var expectedQuote = _quoteHandoff.Require(
                "commercial-duckcreek-bap-pilot-reopen");
            var expectedDescription = _quoteDescription
                ?? throw new CommercialDuckCreekPilotOutcomeException(
                    "Quote description was not captured before reopen.");
            var data = Data();
            var reopened = await _runtime.SearchAndReopenQuoteAsync(
                expectedQuote.QuoteNumber,
                cancellationToken);
            if (!reopened.SearchStatus.Equals(
                    data.SearchExpectation,
                    StringComparison.Ordinal) ||
                !reopened.ReopenStatus.Equals(
                    data.ReopenExpectation,
                    StringComparison.Ordinal) ||
                !reopened.QuoteIdentity.Equals(
                    expectedQuote.QuoteNumber,
                    StringComparison.Ordinal) ||
                !reopened.QuoteDescription.Equals(
                    expectedDescription,
                    StringComparison.Ordinal))
            {
                throw new CommercialDuckCreekPilotOutcomeException(
                    "Reopened quote identity, description, or status did not match.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "cldc-bap-quote-reopened");
            await ScreenshotAsync(
                "cldc-bap-quote-reopened",
                cancellationToken);
        }

        private Task ScreenshotAsync(
            string checkpoint,
            CancellationToken cancellationToken) =>
            _capture.CaptureAsync(
                ArtifactKind.Screenshot,
                checkpoint,
                ".png",
                path => _runtime.CaptureScreenshotAsync(
                    path,
                    cancellationToken));

        private static bool Matches(string value, string pattern) =>
            !string.IsNullOrWhiteSpace(value) &&
            Regex.IsMatch(
                value,
                pattern,
                RegexOptions.CultureInvariant,
                TimeSpan.FromSeconds(1));

        private CommercialDuckCreekBapPilotData Data() =>
            CommercialDuckCreekBapPilotData.From(
                _dataContext.Require());
    }

    public sealed class CommercialDuckCreekPilotOutcomeException : Exception
    {
        public CommercialDuckCreekPilotOutcomeException(string message)
            : base(message)
        {
        }
    }
}
