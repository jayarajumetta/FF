#nullable enable
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Pages.PersonalDuckCreekPages.Auto;
using PnCTestAutomation.QuoteHandoffs;

namespace PnCTestAutomation.Workflows
{
    public interface IPersonalDuckCreekAutoSmokeWorkflow
    {
        Task ApplySelectionsAsync(
            CancellationToken cancellationToken = default);
        Task ResolveConditionalProposalAsync(
            CancellationToken cancellationToken = default);
        Task SaveAndCaptureQuoteAsync(
            CancellationToken cancellationToken = default);
        Task SearchReopenAndVerifyAsync(
            CancellationToken cancellationToken = default);
    }

    public interface IPersonalDuckCreekStateMaritalWorkflow
    {
        Task ApplyAsync(
            CancellationToken cancellationToken = default);
        Task VerifyAsync(
            CancellationToken cancellationToken = default);
    }

    public sealed class PersonalDuckCreekAutoSmokeWorkflow :
        IPersonalDuckCreekAutoSmokeWorkflow
    {
        private readonly IPilotDataContext _dataContext;
        private readonly IPersonalDuckCreekAutoPilotRuntime _runtime;
        private readonly IQuoteHandoff _quoteHandoff;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _capture;

        public PersonalDuckCreekAutoSmokeWorkflow(
            IPilotDataContext dataContext,
            IPersonalDuckCreekAutoPilotRuntime runtime,
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

        public async Task ApplySelectionsAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var actual = await _runtime.ApplySmokeSelectionsAsync(
                data,
                cancellationToken);
            if (!actual.State.Equals(
                    data.StateName,
                    StringComparison.Ordinal) ||
                !actual.WritingCompany.Equals(
                    data.WritingCompany,
                    StringComparison.Ordinal) ||
                !actual.MaritalStatus.Equals(
                    data.MaritalStatus,
                    StringComparison.Ordinal))
            {
                throw new PersonalDuckCreekPilotOutcomeException(
                    "Selected state, writing company, or marital status did not match.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "pldc-smoke-selection-postconditions");
            await ScreenshotAsync(
                "pldc-smoke-selections",
                cancellationToken);
        }

        public async Task ResolveConditionalProposalAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var actual = await _runtime.ResolveConditionalProposalAsync(
                data,
                cancellationToken);
            if (actual.InvalidAddressShown !=
                    data.InvalidAddressExpected ||
                actual.SsnWarningShown != data.SsnWarningExpected ||
                actual.ConfirmSsnShown != data.ConfirmSsnExpected ||
                actual.ExistingClientShown != data.ExistingClientExpected)
            {
                throw new PersonalDuckCreekPilotOutcomeException(
                    "Conditional proposal outcome did not match the approved profile.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "pldc-smoke-conditional-proposal");
            await ScreenshotAsync(
                "pldc-smoke-conditional-proposal",
                cancellationToken);
        }

        public async Task SaveAndCaptureQuoteAsync(
            CancellationToken cancellationToken = default)
        {
            var data = Data();
            var saved = await _runtime.SaveQuoteAsync(cancellationToken);
            if (!saved.Status.Equals(
                    data.SaveExpectation,
                    StringComparison.Ordinal) ||
                !Matches(
                    saved.QuoteIdentity.Trim(),
                    data.QuoteIdentityPattern))
            {
                throw new PersonalDuckCreekPilotOutcomeException(
                    "Saved quote status or identity did not match.");
            }
            _quoteHandoff.Publish(saved.QuoteIdentity.Trim());
            _artifacts.RecordMarker(
                ArtifactKind.QuoteHandoff,
                "pldc-smoke-quote-captured");
            await ScreenshotAsync(
                "pldc-smoke-quote-saved",
                cancellationToken);
        }

        public async Task SearchReopenAndVerifyAsync(
            CancellationToken cancellationToken = default)
        {
            var expected = _quoteHandoff.Require(
                "personal-duckcreek-auto-smoke-reopen");
            var data = Data();
            var reopened = await _runtime.SearchAndReopenQuoteAsync(
                expected.QuoteNumber,
                cancellationToken);
            if (!reopened.SearchStatus.Equals(
                    data.SearchExpectation,
                    StringComparison.Ordinal) ||
                !reopened.ReopenStatus.Equals(
                    data.ReopenExpectation,
                    StringComparison.Ordinal) ||
                !reopened.QuoteIdentity.Equals(
                    expected.QuoteNumber,
                    StringComparison.Ordinal))
            {
                throw new PersonalDuckCreekPilotOutcomeException(
                    "Reopened quote identity or status did not match.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "pldc-smoke-quote-reopened");
            await ScreenshotAsync(
                "pldc-smoke-quote-reopened",
                cancellationToken);
        }

        private PersonalDuckCreekAutoSmokePilotData Data() =>
            PersonalDuckCreekAutoSmokePilotData.From(
                _dataContext.Require());

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
    }

    public sealed class PersonalDuckCreekStateMaritalWorkflow :
        IPersonalDuckCreekStateMaritalWorkflow
    {
        private readonly IPilotDataContext _dataContext;
        private readonly IPersonalDuckCreekAutoPilotRuntime _runtime;
        private readonly IArtifactContext _artifacts;
        private readonly IArtifactCaptureService _capture;
        private PersonalDuckCreekAccountSelections? _actual;

        public PersonalDuckCreekStateMaritalWorkflow(
            IPilotDataContext dataContext,
            IPersonalDuckCreekAutoPilotRuntime runtime,
            IArtifactContext artifacts,
            IArtifactCaptureService capture)
        {
            _dataContext = dataContext;
            _runtime = runtime;
            _artifacts = artifacts;
            _capture = capture;
        }

        public async Task ApplyAsync(
            CancellationToken cancellationToken = default)
        {
            var data = PersonalDuckCreekStateMaritalPilotData.From(
                _dataContext.Require());
            _actual = await _runtime.ApplyStateAndMaritalAsync(
                data,
                cancellationToken);
        }

        public async Task VerifyAsync(
            CancellationToken cancellationToken = default)
        {
            var data = PersonalDuckCreekStateMaritalPilotData.From(
                _dataContext.Require());
            var actual = _actual
                ?? throw new PersonalDuckCreekPilotOutcomeException(
                    "State and marital selections were not applied.");
            if (!actual.State.Equals(
                    data.StateName,
                    StringComparison.Ordinal) ||
                !actual.MaritalStatus.Equals(
                    data.MaritalStatus,
                    StringComparison.Ordinal) ||
                !actual.PageIdentity.Equals(
                    data.AccountPageExpectation,
                    StringComparison.Ordinal))
            {
                throw new PersonalDuckCreekPilotOutcomeException(
                    "Account state, marital status, or readiness target did not match.");
            }
            _artifacts.RecordMarker(
                ArtifactKind.BusinessOutcome,
                "pldc-state-marital-postconditions");
            await _capture.CaptureAsync(
                ArtifactKind.Screenshot,
                "pldc-account-state-marital",
                ".png",
                path => _runtime.CaptureScreenshotAsync(
                    path,
                    cancellationToken));
        }
    }

    public sealed class PersonalDuckCreekPilotOutcomeException : Exception
    {
        public PersonalDuckCreekPilotOutcomeException(string message)
            : base(message)
        {
        }
    }
}
