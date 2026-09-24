using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Checklist — opens as a popup window from the Submission page.
    /// Use the static OpenChecklistAsync to capture the popup IPage, then pass that
    /// popup IPage to the constructor for all subsequent item operations.
    /// </summary>
    public class SFP_ChecklistPage : BasePage
    {
        public SFP_ChecklistPage(IPage page) : base(page) { }

        #region EChecklist popup locators

        /// <summary>
        /// Summary table link for an item — always visible regardless of accordion state.
        /// Clicking this loads the detail panel with Exception/Note controls.
        /// </summary>
        public ILocator ItemRow(string itemName) =>
            _page.Locator("a.js-checklist-summary-item").Filter(new() { HasText = itemName });

        // Exception flow
        public ILocator ExceptionButton => _page.Locator("button.js-exception");
        public ILocator ExceptionNoteTextarea => _page.Locator(".js-exception-note-text textarea");
        public ILocator ExceptionNoteConfirm => _page.Locator("#exception-note-confirm");

        // Main note + Add Note
        public ILocator MainNoteTextarea => _page.Locator("textarea.js-note");
        public ILocator AddNoteButton => _page.Locator("button.js-add-note");

        #endregion

        #region Actions

        /// <summary>
        /// Clicks the Checklist button on the EQ Submission page and captures the popup window.
        /// Returns the popup IPage — store it in _context.ChecklistPage.
        /// Handles SSO redirects that may occur when opening the checklist in a new tab.
        /// </summary>
        public static async Task<IPage> OpenChecklistAsync(IPage eqPage)
        {
            var openBtn = eqPage.GetByRole(AriaRole.Button, new() { Name = "Checklist" });
            await openBtn.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await EnsureSubmissionReadyAsync(eqPage);

            // Use Context.WaitForPageAsync so we capture both true popups (window.open)
            // and plain new-tab navigations (target="_blank" links).
            var newPageTask = eqPage.Context.WaitForPageAsync();
            await openBtn.ClickAsync();
            var checklistPage = await newPageTask;

            // Wait for initial load
            await checklistPage.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 60000 });
            Console.WriteLine($"[Checklist] New tab opened: {checklistPage.Url}");

            // Handle SSO redirect - wait for SSO flow to complete if we're on an SSO page
            await WaitForSsoRedirectAsync(checklistPage, timeoutMs: 60000);
            await ThrowIfChecklistApplicationErrorAsync(checklistPage);

            return checklistPage;
        }

        internal static async Task EnsureSubmissionReadyAsync(IPage page)
        {
            var incomplete = page.GetByText("Required fields are incomplete.", new() { Exact = false });
            if (await incomplete.IsVisibleAsync())
                throw new PlaywrightException(
                    "Submission has incomplete required fields. Resolve the Required Fields list before opening Checklist; " +
                    "an incomplete quote may have no valid Checklist ID.");
        }

        private static async Task ThrowIfChecklistApplicationErrorAsync(IPage page)
        {
            if (!page.Url.Contains("/EChecklist/Error/", StringComparison.OrdinalIgnoreCase))
                return;

            var bodyText = (await page.Locator("body").InnerTextAsync())
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();

            while (bodyText.Contains("  ", StringComparison.Ordinal))
                bodyText = bodyText.Replace("  ", " ");

            if (bodyText.Length > 600)
                bodyText = bodyText[..600] + "...";

            throw new PlaywrightException(
                "EChecklist returned an application error after SSO completed. " +
                $"URL: {page.Url}. Response: {bodyText}");
        }

        /// <summary>
        /// Waits for SSO redirect to complete if the page is currently on an SSO URL.
        /// This handles cases where the session has expired and needs re-authentication.
        /// </summary>
        private static async Task WaitForSsoRedirectAsync(IPage page, int timeoutMs = 60000)
        {
            var startTime = DateTime.UtcNow;
            var timeout = TimeSpan.FromMilliseconds(timeoutMs);

            while (DateTime.UtcNow - startTime < timeout)
            {
                var currentUrl = page.Url;

                // Check if we're on an SSO page
                if (currentUrl.Contains("ssoqa.anico.com", StringComparison.OrdinalIgnoreCase) ||
                    currentUrl.Contains("/idp/SSO", StringComparison.OrdinalIgnoreCase) ||
                    currentUrl.Contains("/ACS.saml2", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[Checklist] SSO redirect detected: {currentUrl}");

                    // Wait for navigation to complete
                    try
                    {
                        await page.WaitForURLAsync(
                            url => !url.Contains("ssoqa.anico.com", StringComparison.OrdinalIgnoreCase) &&
                                   !url.Contains("/idp/SSO", StringComparison.OrdinalIgnoreCase) &&
                                   !url.Contains("/ACS.saml2", StringComparison.OrdinalIgnoreCase),
                            new() { Timeout = 30000 });

                        Console.WriteLine($"[Checklist] SSO redirect completed. Now at: {page.Url}");
                        await page.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 30000 });
                        break;
                    }
                    catch (TimeoutException)
                    {
                        Console.WriteLine($"[Checklist] SSO redirect timed out, retrying...");
                    }
                }
                else if (currentUrl.Contains("echecklist", StringComparison.OrdinalIgnoreCase) ||
                         currentUrl.Contains("checklist", StringComparison.OrdinalIgnoreCase))
                {
                    // We're on the checklist page, SSO flow complete
                    Console.WriteLine($"[Checklist] Checklist page loaded: {currentUrl}");
                    break;
                }

                await page.WaitForTimeoutAsync(500);
            }
        }

        /// <summary>
        /// Full interaction for a single checklist item:
        /// 1. Click the item row.
        /// 2. If action == "Exception": click Exception → fill modal note → click OK.
        /// 3. Fill the main note field.
        /// 4. Click Add Note.
        /// Includes SSO redirect handling for session timeout scenarios.
        /// </summary>
        public async Task CompleteChecklistItemAsync(string itemName, string action, string exceptionNote, string note, bool skipIfNotFound = false)
        {
            var itemVisibilityTimeoutMs = skipIfNotFound ? 12000 : 60000;
            var retryVisibilityTimeoutMs = skipIfNotFound ? 8000 : 30000;

            // Ensure we're not on an SSO page before starting — SSO may have been triggered
            // by the previous step's reload or by session expiry mid-flow.
            await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
            await ThrowIfChecklistApplicationErrorAsync(_page);
            await _page.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 30000 });

            // 1. Click the item row in the accordion.
            // Use a generous timeout (60 s) so that if SSO fires during the wait the
            // page has time to complete the redirect and reload the checklist.
            var row = ItemRow(itemName);
            try
            {
                await row.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = itemVisibilityTimeoutMs });
            }
            catch (TimeoutException)
            {
                // SSO may have occurred during the wait — handle redirect and retry once.
                Console.WriteLine($"[Checklist] Item '{itemName}' not visible — handling possible SSO redirect and retrying.");
                await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
                await ThrowIfChecklistApplicationErrorAsync(_page);
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
                try
                {
                    await row.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = retryVisibilityTimeoutMs });
                }
                catch (TimeoutException) when (skipIfNotFound)
                {
                    Console.WriteLine($"[Checklist] Item '{itemName}' not found on checklist (optional) — skipping.");
                    return;
                }
            }
            await row.First.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });

            // 2. Handle action — Exception button may not exist for all item types (e.g. Attachment Not Required)
            if (string.Equals(action, "Exception", StringComparison.OrdinalIgnoreCase))
            {
                var exceptionBtnVisible = await ExceptionButton.IsVisibleAsync();
                if (!exceptionBtnVisible)
                {
                    try { await ExceptionButton.WaitForAsync(new() { Timeout = 5000 }); exceptionBtnVisible = true; }
                    catch (TimeoutException) { Console.WriteLine($"[Checklist] No Exception button for '{itemName}' — skipping exception flow"); }
                }

                if (exceptionBtnVisible)
                {
                    await ExceptionButton.ClickAsync();

                    // Fill the exception modal note via JS — single clean event, no multi-keyup noise
                    await ExceptionNoteTextarea.WaitForAsync(new() { Timeout = 10000 });
                    await ExceptionNoteTextarea.EvaluateAsync(@"(el, text) => {
                        el.value = text;
                        el.dispatchEvent(new Event('input', { bubbles: true }));
                        el.dispatchEvent(new KeyboardEvent('keyup', { bubbles: true }));
                    }", exceptionNote ?? note);

                    // Confirm
                    await ExceptionNoteConfirm.ClickAsync();
                    await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 15000 });
                }
            }

            // 3. Fill main note field via JS — fires a single keyup to enable Add Note
            await MainNoteTextarea.WaitForAsync(new() { Timeout = 10000 });
            await MainNoteTextarea.EvaluateAsync(@"(el, text) => {
                el.value = text;
                el.dispatchEvent(new Event('input', { bubbles: true }));
                el.dispatchEvent(new KeyboardEvent('keyup', { bubbles: true }));
            }", note);

            // 4. Verify Add Note is enabled, then force-click to bypass CSS transition stability check
            await Assertions.Expect(AddNoteButton).ToBeEnabledAsync(new() { Timeout = 10000 });
            await AddNoteButton.ClickAsync(new() { Force = true });
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 15000 });

            // 5. Reload to return to the summary table view so the next item's link is visible.
            // Use a generous timeout — the checklist server can be slow after saving a note.
            await _page.ReloadAsync(new PageReloadOptions { Timeout = 60000 });
            await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
            await ThrowIfChecklistApplicationErrorAsync(_page);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
        }

        /// <summary>Closes the checklist popup tab — no Submit needed to enable Transmit.</summary>
        public async Task CloseAsync()
        {
            await _page.CloseAsync();
        }

        #endregion
    }
}
