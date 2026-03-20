using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
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
        public ILocator ExceptionButton      => _page.Locator("button.js-exception");
        public ILocator ExceptionNoteTextarea => _page.Locator(".js-exception-note-text textarea");
        public ILocator ExceptionNoteConfirm => _page.Locator("#exception-note-confirm");

        // Main note + Add Note
        public ILocator MainNoteTextarea => _page.Locator("textarea.js-note");
        public ILocator AddNoteButton    => _page.Locator("button.js-add-note");

        /// <summary>Submit button to finalise and close the checklist popup.</summary>
        public ILocator SubmitButton =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Submit" });

        #endregion

        #region Actions

        /// <summary>
        /// Clicks the Checklist button on the EQ Submission page and captures the popup window.
        /// Returns the popup IPage — store it in _context.ChecklistPage.
        /// </summary>
        public static async Task<IPage> OpenChecklistAsync(IPage eqPage)
        {
            var openBtn = eqPage.GetByRole(AriaRole.Button, new() { Name = "Checklist" });

            // Use Context.WaitForPageAsync so we capture both true popups (window.open)
            // and plain new-tab navigations (target="_blank" links).
            var newPageTask = eqPage.Context.WaitForPageAsync();
            await openBtn.ClickAsync();
            var checklistPage = await newPageTask;
            await checklistPage.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
            Console.WriteLine($"[Checklist] New tab opened: {checklistPage.Url}");
            return checklistPage;
        }

        /// <summary>
        /// Full interaction for a single checklist item:
        /// 1. Click the item row.
        /// 2. If action == "Exception": click Exception → fill modal note → click OK.
        /// 3. Fill the main note field.
        /// 4. Click Add Note.
        /// </summary>
        public async Task CompleteChecklistItemAsync(string itemName, string action, string exceptionNote, string note)
        {
            // 1. Click the item row in the accordion
            var row = ItemRow(itemName);
            await row.First.WaitForAsync(new() { Timeout = 15000 });
            await row.First.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 15000 });

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

            // 5. Reload to return to the summary table view so the next item's link is visible
            await _page.ReloadAsync();
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
