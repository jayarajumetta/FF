#nullable enable
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Controls;
using PnCTestAutomation.Context;
using PnCTestAutomation.DataProfiles;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages.ExpertQuotePages.BOP
{
    public static class ExpertQuoteBopPilotControls
    {
        public static readonly ControlDefinition NewQuote =
            ControlDefinition.WithDocumentedAniIdFallback(
                "New quote",
                "new-quote-button",
                "new-quote-button",
                "ANI-ID-001");
        public static readonly ControlDefinition ClientFirstName =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Client first name",
                "customer.name.first",
                "customer.name.first",
                "ANI-ID-005");
        public static readonly ControlDefinition ClientLastName =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Client last name",
                "customer.name.last",
                "customer.name.last",
                "ANI-ID-006");
        public static readonly ControlDefinition ClientDateOfBirth =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Client date of birth",
                "customer.dateOfBirth",
                "customer.dateOfBirth",
                "ANI-ID-007");
        public static readonly ControlDefinition CreateNewClient =
            ControlDefinition.ByTestId(
                "Create new client",
                "customer.selected-new-chip");
        public static readonly ControlDefinition Next =
            ControlDefinition.ByTestId("Next", "next");
        public static readonly ControlDefinition OwnerPhone =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Owner phone",
                "owner.phone",
                "owner.phone",
                "ANI-ID-008");
        public static readonly ControlDefinition OwnerEmail =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Owner email",
                "owner.email",
                "owner.email",
                "ANI-ID-009");
        public static readonly ControlDefinition MaritalStatus =
            ControlDefinition.ByTestIdWithExactText(
                "Owner marital status",
                "owner.maritalStatus-chip-wrapper",
                "Married");
        public static readonly ControlDefinition StreetAddress =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Account street address",
                "owner.address.line1",
                "owner.address.line1",
                "ANI-ID-010");
        public static readonly ControlDefinition City =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Account city",
                "owner.address.city",
                "owner.address.city",
                "ANI-ID-011");
        public static readonly ControlDefinition State =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Account state",
                "owner.address.state",
                "owner.address.state",
                "ANI-ID-012");
        public static readonly ControlDefinition Zip =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Account ZIP",
                "owner.address.zip",
                "owner.address.zip",
                "ANI-ID-013");
        public static readonly ControlDefinition ReceivesMail =
            ControlDefinition.ByTestIdWithExactText(
                "Address receives mail",
                "owner.address.resided90days-chip-wrapper",
                "Yes");
        public static readonly ControlDefinition IsResidence =
            ControlDefinition.ByTestIdWithExactText(
                "Account address is residence",
                "owner.address.useAsResidence-chip-wrapper",
                "Yes");
        public static readonly ControlDefinition Product =
            ControlDefinition.ByTestIdWithExactText(
                "Business Owners product",
                "proposal.product-chip-item-wrapper",
                "Business Owners");
        public static readonly ControlDefinition IndividuallyOwned =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Individually owned DBA",
                "business.isIndividualDba",
                "business.isIndividualDba-checkbox",
                "ANI-ID-014");
        public static readonly ControlDefinition DbaName =
            ControlDefinition.WithDocumentedAniIdFallback(
                "DBA name",
                "business.individualDba",
                "business.individualDba",
                "ANI-ID-015");
        public static readonly ControlDefinition EffectiveDate =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Effective date",
                "proposal.effectiveDate",
                "proposal.effectiveDate",
                "ANI-ID-016");
        public static readonly ControlDefinition AccountAddress =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Account risk address",
                "proposal.riskAddressSelection-0-input",
                "proposal.riskAddressSelection-0-input",
                "ANI-ID-017");
        public static readonly ControlDefinition LessorsRisk =
            ControlDefinition.ByTestIdWithExactText(
                "Lessors risk exposure",
                "proposal.LessorsRiskExposure-chip-wrapper",
                "No");
        public static readonly ControlDefinition RatingState =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Proposal rating state",
                "proposal.ratingState",
                "proposal.ratingState",
                "ANI-ID-018");
        public static readonly ControlDefinition AgentCode =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Agent PC code",
                "proposal.agentPC",
                "proposal.agentPC",
                "ANI-ID-019");
        public static readonly ControlDefinition StartQuote =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Start quote",
                "startQuote",
                "startQuote",
                "ANI-ID-002");
        public static readonly ControlDefinition SocialSecurityNumber =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Insured SSN",
                "ssn",
                "ssn",
                "ANI-ID-020");
        public static readonly ControlDefinition Confirm =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Confirm",
                "btnConfirmYes",
                "btnConfirmYes",
                "ANI-ID-021");
        public static readonly ControlDefinition PreQualification =
            ControlDefinition.ByTestId(
                "PreQualification navigation",
                "PreQualification-nav");
        public static readonly ControlDefinition QuoteSearchInput =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Quote search input",
                "quoteSearchInput",
                "quoteSearchInput",
                "ANI-ID-022");
        public static readonly ControlDefinition QuoteSearchButton =
            ControlDefinition.WithDocumentedAniIdFallback(
                "Quote search button",
                "quoteSearchButton",
                "quoteSearchButton",
                "ANI-ID-023");

        public static IReadOnlyList<ControlDefinition> All { get; } =
        [
            NewQuote,
            ClientFirstName,
            ClientLastName,
            ClientDateOfBirth,
            CreateNewClient,
            Next,
            OwnerPhone,
            OwnerEmail,
            MaritalStatus,
            StreetAddress,
            City,
            State,
            Zip,
            ReceivesMail,
            IsResidence,
            Product,
            IndividuallyOwned,
            DbaName,
            EffectiveDate,
            AccountAddress,
            LessorsRisk,
            RatingState,
            AgentCode,
            StartQuote,
            SocialSecurityNumber,
            Confirm,
            PreQualification,
            QuoteSearchInput,
            QuoteSearchButton
        ];
    }

    public interface IExpertQuoteBopPilotRuntime
    {
        Task ApplyClientIdentityAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default);
        Task ApplyAccountAddressAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default);
        Task StartProposalAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default);
        Task<string> CaptureAndCloseQuoteAsync(
            CancellationToken cancellationToken = default);
        Task<string> RetrieveQuoteAsync(
            string quoteIdentity,
            CancellationToken cancellationToken = default);
        Task CaptureScreenshotAsync(
            string path,
            CancellationToken cancellationToken = default);
    }

    public sealed class ExpertQuoteBopPilotPage :
        IExpertQuoteBopPilotRuntime
    {
        private readonly Func<(
            IControlScopeResolver Resolver,
            ISemanticControlActions Actions)> _runtime;
        private readonly Func<string, CancellationToken, Task> _screenshot;

        public ExpertQuoteBopPilotPage(PlaywrightContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _runtime = () =>
            {
                var page = context.Page
                           ?? throw new InvalidOperationException(
                               "The scenario browser page is not initialized.");
                return (
                    new ControlScopeResolver(
                        new PlaywrightControlRuntime(page)),
                    new SemanticControlActions());
            };
            _screenshot = (path, _) =>
            {
                var page = context.Page
                           ?? throw new InvalidOperationException(
                               "The scenario browser page is not initialized.");
                return page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = path,
                    FullPage = true
                });
            };
        }

        public ExpertQuoteBopPilotPage(
            IControlScopeResolver resolver,
            ISemanticControlActions actions,
            Func<string, CancellationToken, Task> screenshot)
        {
            ArgumentNullException.ThrowIfNull(resolver);
            ArgumentNullException.ThrowIfNull(actions);
            ArgumentNullException.ThrowIfNull(screenshot);
            _runtime = () => (resolver, actions);
            _screenshot = screenshot;
        }

        public async Task ApplyClientIdentityAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default)
        {
            var (resolver, actions) = _runtime();
            await actions.ClickAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.NewQuote,
                    cancellationToken: cancellationToken),
                cancellationToken: cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.ClientFirstName,
                data.FirstName,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.ClientLastName,
                data.LastName,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.ClientDateOfBirth,
                data.DateOfBirth,
                cancellationToken);
            throw Blocked("client-info-search");
        }

        public async Task ApplyAccountAddressAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default)
        {
            var (resolver, actions) = _runtime();
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.OwnerPhone,
                data.Phone,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.OwnerEmail,
                data.Email,
                cancellationToken);
            await ClickSelectedAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.MaritalStatus,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.StreetAddress,
                data.AddressLine1,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.City,
                data.City,
                cancellationToken);
            await SelectAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.State,
                data.StateName,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.Zip,
                data.Zip,
                cancellationToken);
            await ClickSelectedAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.ReceivesMail,
                cancellationToken);
            await ClickSelectedAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.IsResidence,
                cancellationToken);
            await actions.ClickAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.Next,
                    cancellationToken: cancellationToken),
                cancellationToken: cancellationToken);
        }

        public async Task StartProposalAsync(
            ExpertQuoteBopPilotData data,
            CancellationToken cancellationToken = default)
        {
            var (resolver, actions) = _runtime();
            await ClickSelectedAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.Product,
                cancellationToken);
            await actions.ToggleAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.IndividuallyOwned,
                    cancellationToken: cancellationToken),
                true,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.DbaName,
                data.DbaName,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.EffectiveDate,
                data.EffectiveDate,
                cancellationToken);
            await actions.ToggleAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.AccountAddress,
                    cancellationToken: cancellationToken),
                data.UseAccountAddress,
                cancellationToken);
            await ClickSelectedAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.LessorsRisk,
                cancellationToken);
            await SelectAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.RatingState,
                data.RatingState,
                cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.AgentCode,
                data.AgentCode,
                cancellationToken);
            await actions.ClickAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.StartQuote,
                    cancellationToken: cancellationToken),
                cancellationToken: cancellationToken);
            await FillAsync(
                resolver,
                actions,
                ExpertQuoteBopPilotControls.SocialSecurityNumber,
                data.SocialSecurityNumber,
                cancellationToken);
            await actions.ClickAsync(
                await resolver.ResolveAsync(
                    ExpertQuoteBopPilotControls.Confirm,
                    cancellationToken: cancellationToken),
                cancellationToken: cancellationToken);
            throw Blocked("prefill-result");
        }

        public Task<string> CaptureAndCloseQuoteAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromException<string>(Blocked(
                "active-quote-identity and close-quote"));

        public Task<string> RetrieveQuoteAsync(
            string quoteIdentity,
            CancellationToken cancellationToken = default) =>
            Task.FromException<string>(Blocked("retrieved-quote-result"));

        public Task CaptureScreenshotAsync(
            string path,
            CancellationToken cancellationToken = default) =>
            _screenshot(path, cancellationToken);

        private static PilotWorkflowBlockedException Blocked(string control) =>
            new(
                $"The EQ BOP pilot control '{control}' is not approved. " +
                "The product module must remain non-runnable.");

        private static async Task FillAsync(
            IControlScopeResolver resolver,
            ISemanticControlActions actions,
            ControlDefinition definition,
            string value,
            CancellationToken cancellationToken) =>
            await actions.FillAsync(
                await resolver.ResolveAsync(
                    definition,
                    cancellationToken: cancellationToken),
                value,
                cancellationToken);

        private static async Task SelectAsync(
            IControlScopeResolver resolver,
            ISemanticControlActions actions,
            ControlDefinition definition,
            string value,
            CancellationToken cancellationToken) =>
            await actions.SelectAsync(
                await resolver.ResolveAsync(
                    definition,
                    cancellationToken: cancellationToken),
                value,
                cancellationToken);

        private static async Task ClickSelectedAsync(
            IControlScopeResolver resolver,
            ISemanticControlActions actions,
            ControlDefinition definition,
            CancellationToken cancellationToken) =>
            await actions.ClickAsync(
                await resolver.ResolveAsync(
                    definition,
                    cancellationToken: cancellationToken),
                ControlExpectation.Selected(),
                cancellationToken);
    }

    public sealed class PilotWorkflowBlockedException : Exception
    {
        public PilotWorkflowBlockedException(string message)
            : base(message)
        {
        }
    }
}
