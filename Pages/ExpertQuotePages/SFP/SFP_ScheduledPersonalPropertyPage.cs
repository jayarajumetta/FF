using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Scheduled Personal Property page - select SPP categories with limits.
    /// </summary>
    public class SFP_ScheduledPersonalPropertyPage : BasePage
    {
        public SFP_ScheduledPersonalPropertyPage(IPage page) : base(page) { }

        #region Locators
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTableSPP");

        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value");

        public ILocator CoverageLimit(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$limit.value");

        public ILocator CoverageValue(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$amount.value");

        public ILocator NextLiabilityButton => _page.GetByTestId("fields.data-Next.next");

        // Add Coverage button for Bicycles (code 401) - appears after checking checkbox
        public ILocator AddCoverageButton => _page.GetByTestId("fields.line.covBicycles.addBicycles");

        // Item entry fields (appear after clicking Add Coverage)
        public ILocator ItemDescription(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$description.value");

        public ILocator ItemLimit(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$limit.value");

        public ILocator ItemYearOfAppraisal(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$yearOfLastAppraisal.value");

        public ILocator SaveItemButton => _page.GetByTestId("fields.data.save");
        #endregion

        #region Coverage Mapping
        // Maps SPP coverage codes to their fixed row index in the catalog table
        private static readonly System.Collections.Generic.Dictionary<string, int> _codeToRow = new()
        {
            { "401", 1 }, // Bicycles
        };

        /// <summary>
        /// Get the row index for an SPP category by its catalog code (e.g. "401"). Returns -1 if not found.
        /// </summary>
        public int GetCategoryRowIndexByCode(string code) =>
            !string.IsNullOrEmpty(code) && _codeToRow.TryGetValue(code.Trim(), out var idx) ? idx : -1;
        /// <summary>
        /// Get the row index for an SPP category by name. Returns -1 if not found.
        /// </summary>
        public int GetCategoryRowIndex(string categoryName) => categoryName?.ToLower() switch
        {
            var s when s?.Contains("auto") == true || s?.Contains("trailer") == true || s?.Contains("home") == true => 0,
            var s when s?.Contains("bicycle") == true => 1,
            var s when s?.Contains("coin") == true => 2,
            var s when s?.Contains("fine art") == true || s?.Contains("fineart") == true => 3,
            var s when s?.Contains("fur") == true => 4,
            var s when s?.Contains("golf") == true => 5,
            var s when s?.Contains("gun") == true || s?.Contains("firearm") == true => 6,
            var s when s?.Contains("jewelry") == true => 7,
            var s when s?.Contains("musical") == true && s?.Contains("non") == true => 8,
            var s when s?.Contains("musical") == true && s?.Contains("professional") == true => 9,
            var s when s?.Contains("photography") == true => 10,
            var s when s?.Contains("sign") == true => 11,
            var s when s?.Contains("silver") == true => 12,
            var s when s?.Contains("stamp") == true => 13,
            var s when s?.Contains("tourist") == true || s?.Contains("traveler") == true => 14,
            var s when s?.Contains("watercraft") == true || s?.Contains("boat") == true => 15,
            _ => -1
        };
        #endregion

        #region Actions
        /// <summary>
        /// Select an SPP category by name and optionally set limit
        /// </summary>
        public async Task SelectCategoryAsync(string categoryName, string limit = null)
        {
            var rowIndex = GetCategoryRowIndex(categoryName);
            if (rowIndex < 0)
            {
                System.Console.WriteLine($"WARNING: SPP category '{categoryName}' not matched - no checkbox selected");
                return;
            }

            await CoverageCheckbox(rowIndex).SetCheckedAsync(true);
            await WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(limit))
            {
                var limitInput = CoverageLimit(rowIndex);
                if (await limitInput.CountAsync() > 0)
                    await limitInput.FillAsync(limit);
            }

            System.Console.WriteLine($"Selected SPP category '{categoryName}' with limit '{limit}'");
        }
        #endregion
    }
}
