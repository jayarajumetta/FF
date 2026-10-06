using Microsoft.Playwright;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages
{
    public class SFP_InsuranceScorePage : BasePage
    {
        public SFP_InsuranceScorePage(IPage page) : base(page) { }

        public ILocator EntityTypeSelect => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$entityType.value");
        public ILocator PrimaryInsuredButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-0");
        public ILocator IndividualNotListedButton => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-1");
        public ILocator InsuranceScoreConsentButton => _page.GetByTestId("fields.data.insuranceScoreConsen_1");

        public async Task SelectRequiredPrimaryInsuredAsync(string entityType)
        {
            SfpRequiredTable.RequireValue("EntityType", entityType, "Primary Insured");
            var form = new SFP_NativeFormPage(_page);
            if (await EntityTypeSelect.IsVisibleAsync())
                await form.SelectAsync(EntityTypeSelect, entityType);
            else
                await form.SelectChoiceAsync("SFPInsuranceScoreDesigneeInput.HeadlessSelectionOption",
                    SFP_NativeFormPage.Caption(entityType));
        }

        public async Task ApplyConsentDecisionAsync(string decision, bool required = false)
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

            try
            {
                await InsuranceScoreConsentButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
            }
            catch (TimeoutException ex)
            {
                if (required)
                    throw new PlaywrightException("The requested Insurance Score consent action is not available.", ex);
                Console.WriteLine(
                    "[InsuranceScore] Consent button not present for this state - skipping consent/accept flow");
                return;
            }

            try
            {
                await ClickWithApplicationResponseAsync(
                    InsuranceScoreConsentButton,
                    "Insurance Score Consent");

                var decisionControl = await WaitForVisibleControlAsync(decisionTestId, timeoutMs: 8000);
                if (decisionControl == null)
                {
                    throw new PlaywrightException(
                        $"The {normalizedDecision} control did not appear after the consent action completed.");
                }

                Console.WriteLine(
                    $"[InsuranceScore] Found {normalizedDecision} control in {decisionControl.Value.Scope}.");

                await ClickWithApplicationResponseAsync(
                    decisionControl.Value.Locator,
                    $"Insurance Score Consent {normalizedDecision}");

                await WaitForSpinnerAsync();
            }
            catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
            {
                throw new PlaywrightException(
                    $"{ex.Message}{Environment.NewLine}{await BuildConsentDiagnosticsAsync(decisionTestId)}",
                    ex);
            }
        }

        private async Task ClickWithApplicationResponseAsync(
            ILocator locator,
            string controlName)
        {
            await locator.ScrollIntoViewIfNeededAsync();

            var request = await TryClickAndWaitForRequestAsync(
                () => locator.ClickAsync(),
                timeoutMs: 1500);

            if (request == null)
            {
                Console.WriteLine(
                    $"[InsuranceScore] {controlName} received a trusted Playwright click but dispatched no Duck Creek request; retrying once with the element's DOM click.");

                request = await TryClickAndWaitForRequestAsync(
                    () => locator.EvaluateAsync("element => element.click()"),
                    timeoutMs: 5000);
            }

            if (request == null)
            {
                throw new PlaywrightException(
                    $"{controlName} dispatched no Duck Creek request after either a trusted click or a DOM click.");
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

        private async Task<IRequest> TryClickAndWaitForRequestAsync(
            Func<Task> click,
            int timeoutMs)
        {
            try
            {
                return await _page.RunAndWaitForRequestAsync(
                    click,
                    request => IsDuckCreekProductRequest(request.Url),
                    new() { Timeout = timeoutMs });
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        private async Task<(ILocator Locator, string Scope)?> WaitForVisibleControlAsync(
            string testId,
            int timeoutMs)
        {
            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < timeoutMs)
            {
                var match = await FindVisibleControlAsync(testId);
                if (match != null)
                    return match;

                await Task.Delay(100);
            }

            return null;
        }

        private async Task<(ILocator Locator, string Scope)?> FindVisibleControlAsync(string testId)
        {
            var pages = _page.Context.Pages;

            for (var pageIndex = 0; pageIndex < pages.Count; pageIndex++)
            {
                var page = pages[pageIndex];
                if (page.IsClosed)
                    continue;

                foreach (var frame in page.Frames)
                {
                    var visibleControl = frame.GetByTestId(testId).Filter(new() { Visible = true });
                    if (await visibleControl.CountAsync() > 0)
                    {
                        var frameName = string.IsNullOrWhiteSpace(frame.Name) ? "<unnamed>" : frame.Name;
                        return (
                            visibleControl.First,
                            $"page {pageIndex + 1}, frame '{frameName}' ({frame.Url})");
                    }
                }
            }

            return null;
        }

        private async Task<string> BuildConsentDiagnosticsAsync(string decisionTestId)
        {
            var pageAndFrameState = _page.Context.Pages
                .SelectMany((page, pageIndex) => page.Frames.Select(frame =>
                    $"page {pageIndex + 1}, frame '{(string.IsNullOrWhiteSpace(frame.Name) ? "<unnamed>" : frame.Name)}': {frame.Url}"))
                .ToArray();

            var consentCount = await InsuranceScoreConsentButton.CountAsync();
            var consentVisible = consentCount > 0 && await InsuranceScoreConsentButton.First.IsVisibleAsync();
            var consentEnabled = consentVisible && await InsuranceScoreConsentButton.First.IsEnabledAsync();
            var decisionVisible = await FindVisibleControlAsync(decisionTestId) != null;

            var visibleMessages = await _page
                .Locator("[role='alert']:visible, .alert:visible, .error:visible, .validation-message:visible")
                .AllTextContentsAsync();

            return string.Join(
                Environment.NewLine,
                $"Page URL: {_page.Url}",
                $"Consent button: count={consentCount}, visible={consentVisible}, enabled={consentEnabled}",
                $"Decision control '{decisionTestId}' visible in any page/frame: {decisionVisible}",
                $"Pages/frames: {(pageAndFrameState.Length == 0 ? "<none>" : string.Join(" | ", pageAndFrameState))}",
                $"Visible application messages: {(visibleMessages.Count == 0 ? "<none>" : string.Join(" | ", visibleMessages.Select(NormalizeDiagnosticText)))}");
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
