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

            var narrativeInput = _page.Locator("textarea[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");

            if (await narrativeInput.CountAsync() == 0)
            {
                narrativeInput = _page.Locator("input[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");
            }

            await narrativeInput.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await narrativeInput.First.FillAsync(text);

            var saveButton = _page.Locator("button[data-testid^='fields.data.notes.rows'][data-testid$='.save']");

            await saveButton.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await saveButton.First.ClickAsync();
        }

    }
}