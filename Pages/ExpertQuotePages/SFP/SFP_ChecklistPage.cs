using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Checklist page/panel - opened from the Submission page to complete underwriting checklist items.
    /// </summary>
    public class SFP_ChecklistPage : BasePage
    {
        public SFP_ChecklistPage(IPage page) : base(page) { }

        #region Locators
        /// <summary>Button to open the checklist panel on the Submission page</summary>
        public ILocator OpenChecklistButton =>
            _page.GetByTestId("fields.data.submission.openChecklist"); // TODO: Verify testId

        public ILocator OpenChecklistButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Checklist" });

        /// <summary>Checklist item row by item name</summary>
        public ILocator ChecklistItemRow(string itemName) =>
            _page.GetByRole(AriaRole.Row, new() { Name = itemName });

        /// <summary>Action dropdown for a specific checklist item row</summary>
        public ILocator ActionSelect(string itemName) =>
            ChecklistItemRow(itemName).GetByRole(AriaRole.Combobox); // TODO: May need testId approach

        /// <summary>Note input for a checklist item</summary>
        public ILocator NoteInput =>
            _page.GetByTestId("fields.data.checklist.checklistInput$note.value"); // TODO: Verify testId

        public ILocator NoteInputAlt =>
            _page.GetByLabel("Note");

        /// <summary>Save/Complete button for checklist item</summary>
        public ILocator SaveChecklistItemButton =>
            _page.GetByTestId("fields.data.checklist.saveChecklistItem"); // TODO: Verify testId

        public ILocator SaveChecklistItemButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Save" });

        /// <summary>Close checklist panel</summary>
        public ILocator CloseChecklistButton =>
            _page.GetByTestId("fields.data.checklist.closeChecklist"); // TODO: Verify testId

        public ILocator CloseChecklistButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Close" });

        /// <summary>Confirm Update dialog button</summary>
        public ILocator ConfirmUpdateButton =>
            _page.GetByTestId("btnConfirmYes"); // Reuses existing pattern

        public ILocator ConfirmUpdateButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Update" });
        #endregion

        #region Actions
        public async Task OpenChecklistAsync()
        {
            var btn = await OpenChecklistButton.CountAsync() > 0 ? OpenChecklistButton : OpenChecklistButtonAlt;
            await btn.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task CompleteChecklistItemAsync(string itemName, string action, string note)
        {
            await WaitForSpinnerAsync();

            // Click on the checklist item to expand/select it
            if (!string.IsNullOrEmpty(itemName))
            {
                var itemRow = ChecklistItemRow(itemName);
                if (await itemRow.CountAsync() > 0)
                    await itemRow.ClickAsync();
            }

            // Select action
            if (!string.IsNullOrEmpty(action))
            {
                var actionSelect = string.IsNullOrEmpty(itemName)
                    ? _page.GetByRole(AriaRole.Combobox).Last
                    : ActionSelect(itemName);
                await actionSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Option, new() { Name = action }).ClickAsync();
            }

            // Enter note
            if (!string.IsNullOrEmpty(note))
            {
                var noteInput = await NoteInput.CountAsync() > 0 ? NoteInput : NoteInputAlt;
                await noteInput.FillAsync(note);
            }

            // Save checklist item
            var saveBtn = await SaveChecklistItemButton.CountAsync() > 0 ? SaveChecklistItemButton : SaveChecklistItemButtonAlt;
            await saveBtn.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task CloseChecklistAsync()
        {
            var closeBtn = await CloseChecklistButton.CountAsync() > 0 ? CloseChecklistButton : CloseChecklistButtonAlt;
            await closeBtn.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task ConfirmUpdateAsync()
        {
            var confirmBtn = await ConfirmUpdateButton.CountAsync() > 0 ? ConfirmUpdateButton : ConfirmUpdateButtonAlt;
            await confirmBtn.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion
    }
}
