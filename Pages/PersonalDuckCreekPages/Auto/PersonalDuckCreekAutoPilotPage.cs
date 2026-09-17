#nullable enable
using System;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Controls;
using PnCTestAutomation.DataProfiles;

namespace PnCTestAutomation.Pages.PersonalDuckCreekPages.Auto
{
    public sealed record PersonalDuckCreekPolicySelections(
        string State,
        string WritingCompany,
        string MaritalStatus);

    public sealed record PersonalDuckCreekConditionalOutcomes(
        bool InvalidAddressShown,
        bool SsnWarningShown,
        bool ConfirmSsnShown,
        bool ExistingClientShown);

    public sealed record PersonalDuckCreekSavedQuote(
        string QuoteIdentity,
        string Status);

    public sealed record PersonalDuckCreekReopenedQuote(
        string QuoteIdentity,
        string SearchStatus,
        string ReopenStatus);

    public sealed record PersonalDuckCreekAccountSelections(
        string State,
        string MaritalStatus,
        string PageIdentity);

    public interface IPersonalDuckCreekAutoPilotRuntime
    {
        Task<PersonalDuckCreekPolicySelections> ApplySmokeSelectionsAsync(
            PersonalDuckCreekAutoSmokePilotData data,
            CancellationToken cancellationToken = default);
        Task<PersonalDuckCreekConditionalOutcomes>
            ResolveConditionalProposalAsync(
                PersonalDuckCreekAutoSmokePilotData data,
                CancellationToken cancellationToken = default);
        Task<PersonalDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default);
        Task<PersonalDuckCreekReopenedQuote> SearchAndReopenQuoteAsync(
            string quoteIdentity,
            CancellationToken cancellationToken = default);
        Task<PersonalDuckCreekAccountSelections>
            ApplyStateAndMaritalAsync(
                PersonalDuckCreekStateMaritalPilotData data,
                CancellationToken cancellationToken = default);
        Task CaptureScreenshotAsync(
            string destinationPath,
            CancellationToken cancellationToken = default);
    }

    public sealed class PersonalDuckCreekAutoPilotPage :
        IPersonalDuckCreekAutoPilotRuntime
    {
        private readonly IFrameScopeHintProvider _frameHints;
        private readonly ISemanticControlActions _actions;

        public PersonalDuckCreekAutoPilotPage(
            IFrameScopeHintProvider frameHints,
            ISemanticControlActions actions)
        {
            _frameHints = frameHints;
            _actions = actions;
            PersonalDuckCreekControlContracts.Validate();
        }

        public Task<PersonalDuckCreekPolicySelections>
            ApplySmokeSelectionsAsync(
                PersonalDuckCreekAutoSmokePilotData data,
                CancellationToken cancellationToken = default) =>
            Blocked<PersonalDuckCreekPolicySelections>(
                "approved PLDC test IDs and frame scopes");

        public Task<PersonalDuckCreekConditionalOutcomes>
            ResolveConditionalProposalAsync(
                PersonalDuckCreekAutoSmokePilotData data,
                CancellationToken cancellationToken = default) =>
            Blocked<PersonalDuckCreekConditionalOutcomes>(
                "deterministic conditional proposal controls");

        public Task<PersonalDuckCreekSavedQuote> SaveQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Blocked<PersonalDuckCreekSavedQuote>(
                "approved quote capture controls");

        public Task<PersonalDuckCreekReopenedQuote>
            SearchAndReopenQuoteAsync(
                string quoteIdentity,
                CancellationToken cancellationToken = default) =>
            Blocked<PersonalDuckCreekReopenedQuote>(
                "approved quote search and reopen controls");

        public Task<PersonalDuckCreekAccountSelections>
            ApplyStateAndMaritalAsync(
                PersonalDuckCreekStateMaritalPilotData data,
                CancellationToken cancellationToken = default) =>
            Blocked<PersonalDuckCreekAccountSelections>(
                "approved Married data and corrected state/marital controls");

        public Task CaptureScreenshotAsync(
            string destinationPath,
            CancellationToken cancellationToken = default) =>
            Blocked("an approved runnable PLDC profile");

        private Task Blocked(string boundary)
        {
            _ = _frameHints.Hints;
            _ = _actions;
            throw new PersonalDuckCreekPilotBoundaryException(
                $"The Personal DuckCreek pilot is blocked on {boundary}.");
        }

        private Task<T> Blocked<T>(string boundary)
        {
            _ = _frameHints.Hints;
            _ = _actions;
            throw new PersonalDuckCreekPilotBoundaryException(
                $"The Personal DuckCreek pilot is blocked on {boundary}.");
        }
    }

    public sealed class PersonalDuckCreekPilotBoundaryException : Exception
    {
        public PersonalDuckCreekPilotBoundaryException(string message)
            : base(message)
        {
        }
    }
}
