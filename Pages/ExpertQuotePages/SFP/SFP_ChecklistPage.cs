using Microsoft.Playwright;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

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
        /// Selectable item in either the summary grid or sidebar. EChecklist auto-advances
        /// after saving, so subsequent items may need to be selected from the sidebar.
        /// </summary>
        public ILocator ItemRow(string itemName) =>
            _page.Locator("a.js-checklist-summary-item, li.js-current-item")
                .Filter(new() { HasText = itemName, Visible = true });

        // Exception flow
        public ILocator ExceptionButton => _page
            .Locator("button.js-exception:visible")
            .Or(_page.GetByRole(
                AriaRole.Button,
                new() { Name = "Take Action other than Cancel", Exact = true }));
        public ILocator ExceptionNoteModal => _page.Locator("#exception-note:visible, #takeAction-note:visible");
        public ILocator LegacyExceptionNoteModal => _page.Locator("#exception-note");
        public ILocator TakeActionNoteModal => _page.Locator("#takeAction-note");
        public ILocator ApplyChangesModal => _page.Locator("#apply-changes-modal");

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
            try
            {
                await openBtn.ClickAsync(new() { Timeout = 10000 });
            }
            catch (TimeoutException)
            {
                await openBtn.DispatchEventAsync("click");
            }
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
        /// 2. If action == "Exception": click Exception → fill modal note → click OK
        ///    and wait for the Checklist application to finish applying the change.
        /// 3. For non-exception actions, fill the main note field and click Add Note.
        /// Includes SSO redirect handling for session timeout scenarios.
        /// </summary>
        public async Task CompleteChecklistItemAsync(string itemName, string action, string exceptionNote, string note,
            bool skipIfNotFound = false)
        {
            var isException = string.Equals(action, "Exception", StringComparison.OrdinalIgnoreCase);
            if (isException && string.IsNullOrWhiteSpace(exceptionNote) && string.IsNullOrWhiteSpace(note))
                throw new ArgumentException("Checklist exception items require an ExceptionNote or Note.");

            var itemVisibilityTimeoutMs = skipIfNotFound ? 12000 : 60000;
            var retryVisibilityTimeoutMs = skipIfNotFound ? 8000 : 30000;
            var diagnostics = RetryDiagnostics.For(_page);
            var itemCategory = string.Equals(itemName, "Easy Pay", StringComparison.OrdinalIgnoreCase)
                ? "easy-pay" : "other";

            // Ensure we're not on an SSO page before starting — SSO may have been triggered
            // by the previous step's reload or by session expiry mid-flow.
            diagnostics?.Mark($"checklist item={itemCategory} action=initial-ready-start");
            await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
            await ThrowIfChecklistApplicationErrorAsync(_page);
            await _page.WaitForLoadStateAsync(LoadState.Load, new() { Timeout = 30000 });
            diagnostics?.Mark($"checklist item={itemCategory} action=initial-ready-end");

            // 1. Click the item row in the accordion.
            // Use a generous timeout (60 s) so that if SSO fires during the wait the
            // page has time to complete the redirect and reload the checklist.
            var row = ItemRow(itemName);
            diagnostics?.Mark($"checklist item={itemCategory} action=first-wait-start optional={skipIfNotFound}");
            try
            {
                await row.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = itemVisibilityTimeoutMs });
                diagnostics?.Mark($"checklist item={itemCategory} action=first-wait-visible");
            }
            catch (TimeoutException)
            {
                diagnostics?.Mark($"checklist item={itemCategory} action=first-wait-timeout");
                // SSO may have occurred during the wait — handle redirect and retry once.
                Console.WriteLine($"[Checklist] Item '{itemName}' not visible — handling possible SSO redirect and retrying.");
                if (diagnostics != null)
                {
                    var ssoAtRetry = _page.Url.Contains("ssoqa.anico.com", StringComparison.OrdinalIgnoreCase) ||
                        _page.Url.Contains("/idp/SSO", StringComparison.OrdinalIgnoreCase) ||
                        _page.Url.Contains("/ACS.saml2", StringComparison.OrdinalIgnoreCase);
                    diagnostics.Mark($"checklist item={itemCategory} action=retry-ready-start ssoAtStart={ssoAtRetry}");
                }
                await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
                await ThrowIfChecklistApplicationErrorAsync(_page);
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
                diagnostics?.Mark($"checklist item={itemCategory} action=retry-wait-start");
                try
                {
                    await row.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = retryVisibilityTimeoutMs });
                    diagnostics?.Mark($"checklist item={itemCategory} action=retry-wait-visible");
                }
                catch (TimeoutException) when (skipIfNotFound)
                {
                    diagnostics?.Mark($"checklist item={itemCategory} action=retry-wait-timeout-skipped");
                    Console.WriteLine($"[Checklist] Item '{itemName}' not found on checklist (optional) — skipping.");
                    return;
                }
            }
            await row.First.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });

            // 2. Handle action — Exception button may not exist for all item types (e.g. Attachment Not Required)
            if (isException)
            {
                var exceptionBtnVisible = await ExceptionButton.IsVisibleAsync();
                if (!exceptionBtnVisible)
                {
                    try
                    {
                        await ExceptionButton.WaitForAsync(new() { Timeout = 5000 });
                        exceptionBtnVisible = true;
                    }
                    catch (TimeoutException) when (skipIfNotFound)
                    {
                        Console.WriteLine($"[Checklist] No Exception button for optional item '{itemName}' — skipping.");
                        return;
                    }
                }

                if (!exceptionBtnVisible)
                    throw new PlaywrightException(
                        $"Checklist item '{itemName}' requires an Exception action, but the Exception button was not available.");

                await ExceptionButton.ClickAsync();

                await ExceptionNoteModal.WaitForAsync(new() { Timeout = 10000 });
                var usesTakeAction = await TakeActionNoteModal.IsVisibleAsync();
                var noteModal = usesTakeAction ? TakeActionNoteModal : LegacyExceptionNoteModal;
                var noteTextarea = noteModal.Locator("textarea");
                var noteConfirm = noteModal.GetByRole(
                    AriaRole.Button,
                    new() { Name = "OK", Exact = true });
                var requestPath = usesTakeAction
                    ? "/EChecklist/ChecklistDetails/TakeAction"
                    : "/EChecklist/ChecklistDetails/RequestException";

                // EChecklist enables OK from its keyup handler.
                await noteTextarea.WaitForAsync(new() { Timeout = 10000 });
                await noteTextarea.EvaluateAsync(@"(el, text) => {
                    el.value = text;
                    el.dispatchEvent(new Event('input', { bubbles: true }));
                    el.dispatchEvent(new KeyboardEvent('keyup', { bubbles: true }));
                }", string.IsNullOrWhiteSpace(exceptionNote) ? note : exceptionNote);

                await Assertions.Expect(noteConfirm).ToBeEnabledAsync(new() { Timeout = 10000 });
                var response = await _page.RunAndWaitForResponseAsync(
                    () => noteConfirm.ClickAsync(),
                    candidate =>
                        candidate.Request.Method == "POST"
                        && candidate.Url.Contains(requestPath, StringComparison.OrdinalIgnoreCase),
                    new() { Timeout = 120000 });
                await RequireSuccessfulExceptionResponseAsync(response, itemName);

                // Saving an exception is the complete item action. EChecklist first fades
                // the note modal, then displays a blocking "Applying Changes..." overlay
                // while it refreshes the menu and automatically opens the next item.
                await noteModal.WaitForAsync(
                    new() { State = WaitForSelectorState.Hidden, Timeout = 15000 });
                try
                {
                    await ApplyChangesModal.WaitForAsync(
                        new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                }
                catch (TimeoutException)
                {
                    // A fast response can display and remove the overlay between polls.
                }

                await ApplyChangesModal.WaitForAsync(
                    new() { State = WaitForSelectorState.Hidden, Timeout = 120000 });
                return;
            }

            // 3. A standalone note is a separate action from requesting an exception.
            await MainNoteTextarea.WaitForAsync(new() { Timeout = 10000 });
            await MainNoteTextarea.EvaluateAsync(@"(el, text) => {
                el.value = text;
                el.dispatchEvent(new Event('input', { bubbles: true }));
                el.dispatchEvent(new KeyboardEvent('keyup', { bubbles: true }));
            }", note);

            // 4. Verify Add Note is enabled and unobstructed before clicking.
            await Assertions.Expect(AddNoteButton).ToBeEnabledAsync(new() { Timeout = 10000 });
            await AddNoteButton.ClickAsync();
            try
            {
                await ApplyChangesModal.WaitForAsync(
                    new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
            }
            catch (TimeoutException)
            {
                // A fast response can display and remove the overlay between polls.
            }
            await ApplyChangesModal.WaitForAsync(
                new() { State = WaitForSelectorState.Hidden, Timeout = 60000 });

            // 5. Reload to return to the summary table view so the next item's link is visible.
            // Use a generous timeout — the checklist server can be slow after saving a note.
            await _page.ReloadAsync(new PageReloadOptions { Timeout = 60000 });
            await WaitForSsoRedirectAsync(_page, timeoutMs: 60000);
            await ThrowIfChecklistApplicationErrorAsync(_page);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
        }

        private static async Task RequireSuccessfulExceptionResponseAsync(
            IResponse response,
            string itemName)
        {
            var responseBody = await response.TextAsync();
            if (response.Status >= 400)
                throw new PlaywrightException(
                    $"Checklist exception for '{itemName}' returned HTTP {response.Status}. Response: {responseBody}");

            try
            {
                using var json = JsonDocument.Parse(responseBody);
                var root = json.RootElement;
                var succeeded = root.TryGetProperty("Success", out var success)
                                && success.ValueKind == JsonValueKind.True;
                if (succeeded)
                    return;

                var message = root.TryGetProperty("Message", out var responseMessage)
                    ? responseMessage.GetString()
                    : null;
                throw new PlaywrightException(
                    $"Checklist exception for '{itemName}' was rejected by eChecklist"
                    + (string.IsNullOrWhiteSpace(message) ? "." : $": {message}"));
            }
            catch (JsonException)
            {
                throw new PlaywrightException(
                    $"Checklist exception for '{itemName}' returned invalid JSON: {responseBody}");
            }
        }

        /// <summary>Closes the checklist popup tab — no Submit needed to enable Transmit.</summary>
        public async Task CloseAsync()
        {
            await _page.CloseAsync();
        }

        #endregion
    }
}
