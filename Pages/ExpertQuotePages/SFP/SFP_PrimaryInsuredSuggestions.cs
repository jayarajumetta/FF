using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages
{
    /// <summary>
    /// Page Object for Primary Insured Suggestions popup/modal for SFP
    /// Used when searching for existing clients to link as primary insured
    /// </summary>
    public class SFP_PrimaryInsuredSuggestionsPage : BasePage
    {
        public SFP_PrimaryInsuredSuggestionsPage(IPage page) : base(page) { }

        // ══════════════════════════════════════════════════════════════════
        // LOCATORS
        // ══════════════════════════════════════════════════════════════════

        private ILocator FirstNameInput => _page.GetByTestId("temp.clientSearchFirstName");
        private ILocator LastNameInput => _page.GetByTestId("temp.clientSearchLastName");
        private ILocator BusinessNameInput => _page.GetByTestId("temp.clientSearchBusinessName");
        private ILocator SearchButton => _page.GetByTestId("temp.clientSearchButton");
        private ILocator CancelButton => _page.GetByTestId("fields.data.cancel");

        // ══════════════════════════════════════════════════════════════════
        // PUBLIC METHODS
        // ══════════════════════════════════════════════════════════════════

        public async Task SearchByNameAsync(string firstName, string lastName)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await SearchButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task SearchByBusinessNameAsync(string businessName)
        {
            await BusinessNameInput.FillAsync(businessName);
            await SearchButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        public async Task ClickCancelAsync()
        {
            await CancelButton.ClickAsync();
        }
    }
}
