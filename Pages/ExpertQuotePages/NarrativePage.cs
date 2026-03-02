using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class NarrativePage : BasePage
    {
        public NarrativePage(IPage page) : base(page) { }

        #region Locators
        private ILocator AddNarrativeButton => _page.GetByTestId("fields.data.notes.addNarrative");
        private ILocator AddNarrativeButtonAlt => _page.GetByRole(AriaRole.Button, new() { Name = "Add Narrative" });
        private ILocator NarrativeInput => _page.Locator("textarea[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");
        private ILocator NarrativeInputAlt => _page.Locator("input[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");
        private ILocator SaveNarrativeButton => _page.Locator("button[data-testid^='fields.data.notes.rows'][data-testid$='.save']");
        #endregion

        public async Task<bool> IsOnNarrativePageAsync()
        {
            return await AddNarrativeButton.CountAsync() > 0 || await AddNarrativeButtonAlt.CountAsync() > 0;
        }

        public async Task ClickAddNarrativeButtonAsync()
        {
            if (await AddNarrativeButton.CountAsync() > 0)
                await AddNarrativeButton.ClickAsync();
            else
                await AddNarrativeButtonAlt.ClickAsync();
            
            await WaitForSpinnerAsync();
        }

        public async Task EnterNarrativeAndClickSaveAsync(string narrative)
        {
            var narrativeInput = NarrativeInput.Or(NarrativeInputAlt);
            await narrativeInput.First.FillAsync(narrative?.Trim() ?? string.Empty);
            await SaveNarrativeButton.First.ClickAsync();
            await WaitForSpinnerAsync();
        }
    }
}