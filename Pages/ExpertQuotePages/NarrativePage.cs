using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using Playwright_POC.Locators;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class NarrativePage
    {
        private readonly IPage _page;
        public NarrativePage(IPage page)
        {
            _page = page;
        }

        public async Task ClickAddNarrativeButtonAsync()
        {
            var addNarrativeButton = _page.GetByTestId("fields.data.notes.addNarrative");

            await addNarrativeButton.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            await addNarrativeButton.ClickAsync();

        }

        public async Task EnterNarrativeAndClickSaveAsync(string narrative)
        {

            var text = narrative?.Trim() ?? string.Empty;

            // Wait for the Narrative section to be open
            await _page.Locator("text=Create Narrative").First
                .WaitForAsync(new() { State = WaitForSelectorState.Visible });

            // Match textarea by testid for either remarks OR note (covers both implementations)
            var narrativeField = _page.Locator(
                "textarea[data-testid^='fields.data.notes.rows']" +
                "[data-testid*='notesInput$'][data-testid$='.value']"
            ).First;

            // Don't use CountAsync branching (it can evaluate too early and send you down the wrong path)
            await narrativeField.WaitForAsync(new() { State = WaitForSelectorState.Attached });
            await narrativeField.ScrollIntoViewIfNeededAsync();
            await narrativeField.FillAsync(text);

            var saveButton = _page.Locator("button[data-testid^='fields.data.notes.rows'][data-testid$='.save']").First;
            await saveButton.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await saveButton.ClickAsync();

            await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);

        }

    }
}