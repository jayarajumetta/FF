using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages
{
    /// <summary>
    /// Base class for all Page Objects providing common functionality.
    ///
    /// Selector strategy:
    ///   - DuckCreek form engine fields use <c>GetByTestId("fields.data.*")</c> — those test IDs
    ///     are owned by DuckCreek and are not being migrated.
    ///   - ANi-built UI components (nav, dashboard, landing page) are migrating from
    ///     <c>data-testid</c> attributes to standard HTML <c>id</c> attributes as part of the
    ///     internal library migration (INC0183313 and subsequent rollout).
    ///     Use <c>GetById(id)</c> for <c>#id</c> lookups, or the dual-selector helper
    ///     <c>_page.Locator($"[data-testid='{x}'], #{x}")</c> for elements currently in
    ///     transition so they work whether or not the attribute has been migrated yet.
    ///
    /// Locator Rescue:
    ///   When a locator fails to find an element, <see cref="RescueAsync"/> runs a lightweight
    ///   DOM scan to find similar elements by partial test-id, text, or aria-label.
    ///   Controlled by appsettings <c>LocatorRescue:Enabled</c> and <c>LocatorRescue:AutoHeal</c>.
    /// </summary>
    public abstract class BasePage
    {
        protected readonly IPage _page;

        /// <summary>
        /// Global rescue options, initialized once from appsettings by TestHooks.
        /// All page objects inherit these unless overridden.
        /// </summary>
        private static LocatorRescueOptions _globalRescueOptions = LocatorRescueOptions.Default;

        /// <summary>
        /// Called once at test run start (from TestHooks) to configure rescue behavior.
        /// </summary>
        public static void ConfigureRescue(bool enabled, bool autoHeal)
        {
            _globalRescueOptions = enabled
                ? new LocatorRescueOptions { AutoHeal = autoHeal }
                : LocatorRescueOptions.Disabled;
        }

        /// <summary>
        /// Rescue options for this page instance. Defaults to global config.
        /// Override per-page if needed.
        /// </summary>
        protected LocatorRescueOptions RescueOptions { get; set; }

        protected BasePage(IPage page)
        {
            _page = page;
            RescueOptions = _globalRescueOptions;
        }

        /// <summary>
        /// Locate an element by standard HTML <c>id</c> attribute.
        /// Use this for ANi-built components that have been migrated away from <c>data-testid</c>.
        /// </summary>
        protected ILocator GetById(string id) => _page.Locator($"#{id}");

        /// <summary>
        /// Rescue-aware locator resolution. If the locator finds 0 elements and rescue is enabled,
        /// runs a targeted DOM scan to find candidates. Returns the healed locator if auto-heal is
        /// on, otherwise returns the original locator (which will fail with Playwright's normal error
        /// plus rescue candidates logged to output).
        /// </summary>
        /// <param name="locator">The original locator to try.</param>
        /// <param name="selectorHint">
        /// A human-readable description of what was being looked for (e.g. the test-id string).
        /// Used by the rescue scanner to find similar elements.
        /// </param>
        protected async Task<ILocator> RescueAsync(ILocator locator, string selectorHint)
        {
            return await LocatorRescueService.ResolveLocatorAsync(
                _page, locator, selectorHint, RescueOptions);
        }

        /// <summary>
        /// GetByTestId with rescue fallback. If the test-id isn't found, runs rescue scan.
        /// </summary>
        protected async Task<ILocator> GetByTestIdRescueAsync(string testId)
        {
            var locator = _page.GetByTestId(testId);
            return await RescueAsync(locator, testId);
        }

        /// <summary>
        /// Default window for the spinner to render before we conclude the action did not
        /// trigger one. Angular usually renders the overlay in the same change-detection pass
        /// that dispatches the HTTP call, but DuckCreek has been measured at roughly 200ms on
        /// some XHR-backed controls, so this leaves headroom over that.
        /// </summary>
        private const int DefaultSpinnerGraceMs = 500;

        /// <summary>
        /// How long a Next/Save button is allowed to take to appear before we give up on it.
        /// </summary>
        private const int ButtonVisibleTimeoutMs = 10000;

        /// <summary>
        /// Wait for the page-specific loading indicator to appear and then clear.
        /// </summary>
        /// <param name="timeoutMs">How long to wait for the spinner to clear once it has appeared.</param>
        /// <param name="appearanceGraceMs">
        /// How long to wait for the spinner to show up in the first place. Raise this on controls
        /// known to be slow to fire their XHR; if the spinner has not appeared within the window
        /// we assume there is nothing to wait for and return.
        /// </param>
        /// <remarks>
        /// This used to check <c>CountAsync() &gt; 0</c> and return when the count was zero.
        /// Called immediately after a click — which is how nearly all 160+ call sites use it —
        /// the overlay had not rendered yet, so the method returned having waited for nothing
        /// and the next action raced the spinner. Waiting briefly for the spinner to *appear*
        /// before waiting for it to clear is what makes the wait meaningful.
        /// </remarks>
        public async Task WaitForSpinnerAsync(int timeoutMs = 60000, int appearanceGraceMs = DefaultSpinnerGraceMs)
        {
            var overlay = _page.Locator(".ngx-spinner-overlay").First;

            try
            {
                await overlay.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = appearanceGraceMs
                });
            }
            catch (TimeoutException)
            {
                // No spinner for this action — either it never showed one, or the response
                // came back faster than the grace window. Either way there is nothing to wait on.
                // NB: Playwright surfaces waiter timeouts as System.TimeoutException, not
                // PlaywrightException. Catching the latter here silently breaks every call site.
                return;
            }

            await overlay.WaitForAsync(new()
            {
                State = WaitForSelectorState.Hidden,
                Timeout = timeoutMs
            });
        }

        public async Task ThrowIfQuoteErrorAsync(string action)
        {
            var visibleErrorText = string.Join(
                " ",
                await _page
                    .Locator("[role='alert']:visible, .alert:visible, .error:visible, .validation-message:visible")
                    .AllTextContentsAsync());
            var errorCodes = Regex.Matches(visibleErrorText, @"\bDC-\d{3,}\b", RegexOptions.IgnoreCase)
                .Select(match => match.Value.ToUpperInvariant())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
            var quoteErrorRoute = _page.Url.Contains("quoteError", StringComparison.OrdinalIgnoreCase);

            if (!quoteErrorRoute && errorCodes.Length == 0)
                return;

            throw new PlaywrightException(
                $"Duck Creek quote error while {action}. {await BuildPageDiagnosticsAsync(errorCodes)}");
        }

        public async Task<string> BuildPageDiagnosticsAsync(params string[] knownErrorCodes)
        {
            var title = await _page.TitleAsync();
            var visibleMessages = await _page
                .Locator("[role='alert']:visible, .alert:visible, .error:visible, .validation-message:visible")
                .AllTextContentsAsync();
            var headings = await _page.Locator("h1:visible, h2:visible, h3:visible")
                .AllTextContentsAsync();

            static string Normalize(string value)
            {
                var normalized = string.Join(
                    " ",
                    (value ?? string.Empty)
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    .Trim();
                return normalized.Length <= 300 ? normalized : normalized[..300] + "...";
            }

            var codes = knownErrorCodes?
                .Where(code => !string.IsNullOrWhiteSpace(code))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray() ?? Array.Empty<string>();

            return string.Join(
                " | ",
                $"URL={_page.Url}",
                $"Title={Normalize(title)}",
                $"ErrorCodes={(codes.Length == 0 ? "<none>" : string.Join(",", codes))}",
                $"Headings={(headings.Count == 0 ? "<none>" : string.Join(" / ", headings.Select(Normalize)))}",
                $"Messages={(visibleMessages.Count == 0 ? "<none>" : string.Join(" / ", visibleMessages.Select(Normalize)))}");
        }

        /// <summary>
        /// Click the standard Next button
        /// </summary>
        /// <param name="spinnerTimeoutMs">How long to wait for the spinner to clear after clicking. Defaults to 60s.</param>
        public async Task ClickNextAsync(int spinnerTimeoutMs = 60000)
        {
            // Ordered most-specific first; the generic role lookup is the last resort.
            var candidates = new[]
            {
                _page.GetByTestId("fields.data.next"),
                _page.GetByTestId("fields.data-Next.next"),
                _page.GetByTestId("fields.data_Next.next"),
                _page.GetByTestId("fields.data_Rules.next"),
                _page.GetByTestId("fields.data_Rules.nextEB"),
                _page.GetByTestId("next"),
                _page.GetByRole(AriaRole.Button, new() { Name = "Next" })
            };

            await ClickFirstVisibleAsync(candidates, "Next", spinnerTimeoutMs);
        }

        /// <summary>
        /// Waits for any one of several interchangeable buttons to become visible, clicks the
        /// highest-priority one that is on screen, then lets the resulting spinner clear.
        /// </summary>
        /// <remarks>
        /// The variants are combined with <see cref="ILocator.Or"/> so the wait is a single
        /// server-side operation rather than a client-side poll over every variant. The
        /// <c>Visible</c> filter is load-bearing: some DuckCreek pages render a hidden Next
        /// button earlier in the DOM, and waiting on the first raw match would block until
        /// timeout while the real button sat there ready to click.
        /// </remarks>
        private async Task ClickFirstVisibleAsync(ILocator[] candidates, string label, int spinnerTimeoutMs)
        {
            var anyVisible = candidates
                .Aggregate((combined, candidate) => combined.Or(candidate))
                .Filter(new() { Visible = true });

            try
            {
                // Generous, because on slower agents the button may not render immediately
                // after the previous step settles.
                await anyVisible.First.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = ButtonVisibleTimeoutMs
                });
            }
            catch (TimeoutException ex)
            {
                throw new PlaywrightException(
                    $"{label} button not found using any known data-testid.", ex);
            }

            // Something is on screen; now honour the caller's ordering rather than DOM order.
            // Falls back to whatever the union matched if the DOM shifted under us.
            var target = anyVisible.First;
            foreach (var candidate in candidates)
            {
                var visible = candidate.Filter(new() { Visible = true });
                if (await visible.CountAsync() > 0)
                {
                    target = visible.First;
                    break;
                }
            }

            await target.ClickAsync();
            await WaitForSpinnerAsync(spinnerTimeoutMs);
        }

        /// <summary>
        /// Click the standard Save button (tries multiple known data-testids)
        /// </summary>
        public async Task ClickSaveAsync()
        {
            var candidates = new[]
            {
                _page.GetByTestId("fields.data.save"),
                _page.GetByTestId("fields.data_Actions.save"),
                _page.GetByTestId("fields.line.save"),
                _page.GetByRole(AriaRole.Button, new() { Name = "Save" })
            };

            await ClickFirstVisibleAsync(candidates, "Save", 60000);
        }

        /// <summary>
        /// Click Save and Continue button
        /// </summary>
        public async Task ClickSaveAndContinueAsync()
        {
            await _page.GetByTestId("fields.line.save_and_Continue").ClickAsync();
            await WaitForSpinnerAsync();
        }

        /// <summary>
        /// Click an Angular Material toggle button only if not already selected
        /// </summary>
        public async Task ClickIfNotSelectedAsync(ILocator locator)
        {
            bool isSelected = await locator.EvaluateAsync<bool>(
                "el => el.classList.contains('mat-button-toggle-checked')"
            );

            if (!isSelected)
                await locator.ClickAsync();
        }
    }
}
