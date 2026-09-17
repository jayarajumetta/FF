#nullable enable
using System;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataProfiles;

namespace PnCTestAutomation.Pages.CommercialDuckCreekPages.BAP
{
    public sealed record CommercialDuckCreekBusinessCheckpoints(
        string QuoteDescription,
        string ScoreReference);

    public sealed record CommercialDuckCreekSavedQuote(
        string QuoteIdentity,
        string Status);

    public sealed record CommercialDuckCreekReopenedQuote(
        string QuoteIdentity,
        string QuoteDescription,
        string SearchStatus,
        string ReopenStatus);

    public interface ICommercialDuckCreekBapPilotRuntime
    {
        Task ApplyIntendedInputsAsync(
            CommercialDuckCreekBapPilotData data,
            CancellationToken cancellationToken = default);
        Task<string> ReadMaskedIdentityAsync(
            CancellationToken cancellationToken = default);
        Task<CommercialDuckCreekBusinessCheckpoints>
            CaptureBusinessCheckpointsAsync(
                CancellationToken cancellationToken = default);
        Task<CommercialDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default);
        Task<CommercialDuckCreekReopenedQuote> SearchAndReopenQuoteAsync(
            string quoteIdentity,
            CancellationToken cancellationToken = default);
        Task CaptureScreenshotAsync(
            string destinationPath,
            CancellationToken cancellationToken = default);
    }

    public sealed class CommercialDuckCreekBapPilotPage :
        ICommercialDuckCreekBapPilotRuntime
    {
        private readonly IFrameScopeHintProvider _frameHints;

        public CommercialDuckCreekBapPilotPage(
            IFrameScopeHintProvider frameHints)
        {
            _frameHints = frameHints;
        }

        public Task ApplyIntendedInputsAsync(
            CommercialDuckCreekBapPilotData data,
            CancellationToken cancellationToken = default) =>
            Blocked(
                "approved CLDC test IDs and frame scopes");

        public Task<string> ReadMaskedIdentityAsync(
            CancellationToken cancellationToken = default) =>
            Blocked<string>("approved masked-identity control");

        public Task<CommercialDuckCreekBusinessCheckpoints>
            CaptureBusinessCheckpointsAsync(
                CancellationToken cancellationToken = default) =>
            Blocked<CommercialDuckCreekBusinessCheckpoints>(
                "approved description and score controls");

        public Task<CommercialDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Blocked<CommercialDuckCreekSavedQuote>(
                "approved quote save and identity controls");

        public Task<CommercialDuckCreekReopenedQuote>
            SearchAndReopenQuoteAsync(
                string quoteIdentity,
                CancellationToken cancellationToken = default) =>
            Blocked<CommercialDuckCreekReopenedQuote>(
                "approved quote search and reopen controls");

        public Task CaptureScreenshotAsync(
            string destinationPath,
            CancellationToken cancellationToken = default) =>
            Blocked("an approved runnable CLDC profile");

        private Task Blocked(string boundary)
        {
            _ = _frameHints.Hints;
            throw new CommercialDuckCreekPilotBoundaryException(
                $"The CLDC BAP pilot is blocked on {boundary}.");
        }

        private Task<T> Blocked<T>(string boundary)
        {
            _ = _frameHints.Hints;
            throw new CommercialDuckCreekPilotBoundaryException(
                $"The CLDC BAP pilot is blocked on {boundary}.");
        }
    }

    public sealed class CommercialDuckCreekPilotBoundaryException : Exception
    {
        public CommercialDuckCreekPilotBoundaryException(string message)
            : base(message)
        {
        }
    }
}
