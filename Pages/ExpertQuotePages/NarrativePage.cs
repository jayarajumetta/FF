using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class NarrativePage : BasePage
    {
        public NarrativePage(IPage page) : base(page) { }

        #region Locators
        private ILocator AddNarrativeButton => _page.GetByTestId("fields.data.notes.addNarrative");
        private ILocator NarrativeInput => _page.Locator("textarea[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");
        private ILocator NarrativeInputAlt => _page.Locator("input[data-testid^='fields.data.notes.rows'][data-testid*='notesInput$remarks.value']");
        private ILocator SaveNarrativeButton => _page.Locator("button[data-testid^='fields.data.notes.rows'][data-testid$='.save']");
        #endregion

        public async Task ClickAddNarrativeButtonAsync()
        {
            await AddNarrativeButton.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await AddNarrativeButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task EnterNarrativeAndClickSaveAsync(string narrative)
        {
            var text = narrative?.Trim() ?? string.Empty;

            // Wait for either textarea or input to appear (Angular may render either)
            var narrativeInput = NarrativeInput.Or(NarrativeInputAlt);
            
            await narrativeInput.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await narrativeInput.First.FillAsync(text);

            await SaveNarrativeButton.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await SaveNarrativeButton.First.ClickAsync();
            await WaitForSpinnerAsync();
        }
    }
}