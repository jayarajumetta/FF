using Microsoft.Playwright;
using PnCTestAutomation.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages
{
    public class SFP_InsuranceScorePage : BasePage
    {
        private static readonly ControlDefinition ConsentControl =
            ControlDefinition.ByTestId(
                "Insurance Score Consent",
                "fields.data.insuranceScoreConsen_1");

        public SFP_InsuranceScorePage(IPage page) : base(page) { }

        public ILocator EntityTypeSelect => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$entityType.value");
        public ILocator PrimaryInsuredButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-0");
        public ILocator IndividualNotListedButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-1");
        public ILocator InsuranceScoreConsentButton => _page.GetByTestId("fields.data.insuranceScoreConsen_1");

        public async Task ApplyConsentDecisionAsync(string decision)
        {
            var normalizedDecision = decision?.Trim().ToLowerInvariant();
            var decisionTestId = normalizedDecision switch
            {
                "accept" => "fields.policy.accept_1",
                "decline" => "fields.policy.decline_1",
                _ => throw new ArgumentException(
                    $"Insurance Score consent must be 'Accept' or 'Decline', but was '{decision}'.",
                    nameof(decision))
            };

            var consentControl = await ControlResolver.TryResolveAsync(
                ConsentControl,
                TimeSpan.FromSeconds(10));
            if (consentControl == null)
            {
                Console.WriteLine(
                    "[InsuranceScore] Consent button not present for this state - skipping consent/accept flow");
                return;
            }

            try
            {
                // Focus changes can move this button between pointerdown and pointerup.
                // Native keyboard activation avoids losing the click during that reflow.
                await ActivateWithApplicationResponseAsync(
                    consentControl,
                    "Insurance Score Consent",
                    () => SemanticControls.ActivateAsync(consentControl));

                var decisionDefinition = ControlDefinition.ByTestId(
                    $"Insurance Score Consent {normalizedDecision}",
                    decisionTestId);
                var decisionControl = await ControlResolver.ResolveAsync(
                    decisionDefinition,
                    TimeSpan.FromSeconds(8));
                Console.WriteLine(
                    $"[InsuranceScore] Found {normalizedDecision} control in {decisionControl.Scope.Description}.");

                await ActivateWithApplicationResponseAsync(
                    decisionControl,
                    $"Insurance Score Consent {normalizedDecision}",
                    () => SemanticControls.ClickAsync(decisionControl));

                await WaitForSpinnerAsync();
                // Accept/Decline are modal actions, not selectable toggles.
                await SemanticControls.AssertAsync(
                    decisionControl,
                    ControlExpectation.Visible(false));
            }
            catch (Exception ex) when (
                ex is TimeoutException or
                PlaywrightException or
                ControlResolutionException or
                ControlPostconditionException)
            {
                throw new PlaywrightException(
                    $"{ex.Message}{Environment.NewLine}{await BuildConsentDiagnosticsAsync(decisionTestId)}",
                    ex);
            }
        }

        private async Task ActivateWithApplicationResponseAsync(
            ResolvedControl control,
            string controlName,
            Func<Task> activate)
        {
            var request = await TryActivateAndWaitForRequestAsync(
                control,
                activate,
                timeoutMs: 5000);

            if (request == null)
            {
                throw new PlaywrightException(
                    $"{controlName} dispatched no Duck Creek request.");
            }

            var response = await request.ResponseAsync().WaitAsync(TimeSpan.FromSeconds(8));
            if (response == null)
                throw new PlaywrightException($"{controlName} request completed without an application response.");

            if (response.Status >= 400)
            {
                var responseBody = NormalizeDiagnosticText(await response.TextAsync());
                throw new PlaywrightException(
                    $"{controlName} returned HTTP {response.Status}. Response: {responseBody}");
            }
        }

        private async Task<IRequest> TryActivateAndWaitForRequestAsync(
            ResolvedControl control,
            Func<Task> activate,
            int timeoutMs)
        {
            var pages = _page.Context.Pages;
            if (control.Scope.PageIndex < 0 || control.Scope.PageIndex >= pages.Count)
            {
                throw new PlaywrightException(
                    $"{control.Definition.Name} resolved to a page that is no longer available.");
            }

            try
            {
                return await pages[control.Scope.PageIndex].RunAndWaitForRequestAsync(
                    activate,
                    request => IsDuckCreekProductRequest(request.Url),
                    new() { Timeout = timeoutMs });
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        private async Task<string> BuildConsentDiagnosticsAsync(string decisionTestId)
        {
            var pageAndFrameState = _page.Context.Pages
                .SelectMany((page, pageIndex) => page.Frames.Select(frame =>
                    $"page {pageIndex + 1}, frame '{(string.IsNullOrWhiteSpace(frame.Name) ? "<unnamed>" : frame.Name)}': {frame.Url}"))
                .ToArray();

            var consentState = await DescribeControlStateAsync(ConsentControl);
            var decisionState = await DescribeControlStateAsync(
                ControlDefinition.ByTestId(
                    "Insurance Score Consent Decision",
                    decisionTestId));

            var visibleMessages = await _page
                .Locator("[role='alert']:visible, .alert:visible, .error:visible, .validation-message:visible")
                .AllTextContentsAsync();

            return string.Join(
                Environment.NewLine,
                $"Page URL: {_page.Url}",
                $"Consent button: {consentState}",
                $"Decision control '{decisionTestId}': {decisionState}",
                $"Pages/frames: {(pageAndFrameState.Length == 0 ? "<none>" : string.Join(" | ", pageAndFrameState))}",
                $"Visible application messages: {(visibleMessages.Count == 0 ? "<none>" : string.Join(" | ", visibleMessages.Select(NormalizeDiagnosticText)))}");
        }

        private async Task<string> DescribeControlStateAsync(ControlDefinition definition)
        {
            try
            {
                var control = await ControlResolver.TryResolveAsync(
                    definition,
                    TimeSpan.Zero);
                if (control == null)
                    return "not found";

                var enabled = await control.Element.IsEnabledAsync();
                return $"visible, enabled={enabled}, scope={control.Scope.Description}";
            }
            catch (ControlResolutionException exception)
            {
                return exception.Message;
            }
        }

        private static bool IsDuckCreekProductRequest(string url) =>
            url.EndsWith("/api/duckcreek/product", StringComparison.OrdinalIgnoreCase);

        private static string NormalizeDiagnosticText(string value)
        {
            var normalized = string.Join(
                " ",
                value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                .Trim();

            return normalized.Length <= 300 ? normalized : normalized[..300] + "...";
        }
    }
}
