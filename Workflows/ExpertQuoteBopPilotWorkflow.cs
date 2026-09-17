#nullable enable
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.BusinessOutcomes;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Pages.ExpertQuotePages.BOP;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.Workflows
{
    public interface IExpertQuoteBopPilotWorkflow
    {
        Task CreateClientAsync(CancellationToken cancellationToken = default);
        Task ApplyAccountAddressAsync(
            CancellationToken cancellationToken = default);
        Task StartProposalAsync(CancellationToken cancellationToken = default);
        Task CaptureAndCloseQuoteAsync(
            CancellationToken cancellationToken = default);
        Task RetrieveAndVerifyQuoteAsync(
            CancellationToken cancellationToken = default);
    }

    public sealed class ExpertQuoteBopPilotWorkflow :
        IExpertQuoteBopPilotWorkflow
    {
        private readonly IPilotDataContext _dataContext;
        private readonly IExpertQuoteBopPilotRuntime _runtime;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IBusinessOutcomeVerifier _outcomes;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _capture;

        public ExpertQuoteBopPilotWorkflow(
            IPilotDataContext dataContext,
            IExpertQuoteBopPilotRuntime runtime,
            IQuoteHandoff quoteHandoff,
            IBusinessOutcomeVerifier outcomes,
            IArtifactContext artifacts,
            IArtifactCaptureService capture)
        {
            _dataContext = dataContext;
            _runtime = runtime;
            _quoteHandoff = quoteHandoff;
            _outcomes = outcomes;
            _artifacts = artifacts;
            _capture = capture;
        }

        public async Task CreateClientAsync(
            CancellationToken cancellationToken = default)
        {
            await _runtime.ApplyClientIdentityAsync(Data(), cancellationToken);
            await ScreenshotAsync("client-created", cancellationToken);
        }

        public async Task ApplyAccountAddressAsync(
            CancellationToken cancellationToken = default)
        {
            await _runtime.ApplyAccountAddressAsync(Data(), cancellationToken);
            await ScreenshotAsync("account-address", cancellationToken);
        }

        public async Task StartProposalAsync(
            CancellationToken cancellationToken = default)
        {
            await _runtime.StartProposalAsync(Data(), cancellationToken);
            await ScreenshotAsync("proposal-started", cancellationToken);
        }

        public async Task CaptureAndCloseQuoteAsync(
            CancellationToken cancellationToken = default)
        {
            var quoteIdentity = (await _runtime.CaptureAndCloseQuoteAsync(
                cancellationToken)).Trim();
            if (string.IsNullOrWhiteSpace(quoteIdentity) ||
                !Regex.IsMatch(
                    quoteIdentity,
                    Data().QuoteIdentityPattern,
                    RegexOptions.CultureInvariant,
                    TimeSpan.FromSeconds(1)))
            {
                throw new BusinessOutcomeException(
                    "quote identity",
                    "The captured quote identity was missing or did not match the approved format.");
            }

            _quoteHandoff.Publish(quoteIdentity);
            _artifacts.RecordMarker(
                ArtifactKind.QuoteHandoff,
                "eq-bop-quote-captured");
            await ScreenshotAsync("quote-closed", cancellationToken);
        }

        public async Task RetrieveAndVerifyQuoteAsync(
            CancellationToken cancellationToken = default)
        {
            var expected = _quoteHandoff.Require(
                "expertquote-bop-pilot-retrieve");
            var actual = await _runtime.RetrieveQuoteAsync(
                expected.QuoteNumber,
                cancellationToken);
            await _outcomes.VerifyQuoteIdentityAsync(
                expected.QuoteNumber,
                actual,
                "eq-bop-retrieved");
            await ScreenshotAsync("quote-retrieved", cancellationToken);
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

        private ExpertQuoteBopPilotData Data() =>
            ExpertQuoteBopPilotData.From(_dataContext.Require());
    }
}
