using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Farm Personal Property page - select FPP coverages with limits and deductibles.
    /// </summary>
    public class SFP_FarmPersonalPropertyPage : BasePage
    {
        public SFP_FarmPersonalPropertyPage(IPage page) : base(page) { }

        #region Locators
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTable");

        // Coverage Checkboxes (by row index)
        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value");

        public ILocator CoverageLimit(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$limit.value");

        public ILocator CoverageDeductible(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$deductible.value");

        public ILocator NextButton => _page.GetByTestId("fields.data_Rules.nextEB");

        // Add Coverage button (appears after checking code 464 checkbox)
        public ILocator AddCoverageButton =>
            _page.GetByTestId("fields.line.covAudioVisualDataElectronicEquipment.addAudioVisualDataElectronicEquipment");

        // Item entry fields (appear after clicking Add Coverage, row 0 = first/new item)
        public ILocator ItemDescription(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$description.value");

        public ILocator ItemLimit(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$limit.value");

        public ILocator ItemDeductible(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$deductible.value");

        public ILocator SaveItemButton => _page.GetByTestId("fields.covEndorsements.save");
        #endregion

        #region Coverage Mapping
        // Maps FPP coverage codes to their fixed row index in the catalog table
        private static readonly System.Collections.Generic.Dictionary<string, int> _codeToRow = new()
        {
            { "464", 1 }, // Audio, Visual and Data Electronic Equipment
        };

        /// <summary>
        /// Get the row index for a coverage by its catalog code (e.g. "464"). Returns -1 if not found.
        /// </summary>
        public int GetCoverageRowIndexByCode(string code) =>
            !string.IsNullOrEmpty(code) && _codeToRow.TryGetValue(code.Trim(), out var idx) ? idx : -1;

        /// <summary>
        /// Get the row index for a coverage by name/code. Returns -1 if not found.
        /// </summary>
        public int GetCoverageRowIndex(string coverageName) => coverageName?.ToLower() switch
        {
            var s when s?.Contains("rental") == true => 0,
            var s when s?.Contains("audio") == true || s?.Contains("electronic") == true => 1,
            var s when s?.Contains("silo") == true || s?.Contains("unloader") == true => 2,
            var s when s?.Contains("borrowed") == true || s?.Contains("rented") == true => 3,
            var s when s?.Contains("multifunctional") == true || s?.Contains("multi-functional") == true => 4,
            var s when s?.Contains("livestock specific") == true => 5,
            var s when s?.Contains("livestock blanket") == true => 6,
            var s when s?.Contains("machinery specific") == true || s?.Contains("farm machinery specific") == true => 7,
            var s when s?.Contains("machinery blanket") == true || s?.Contains("farm machinery blanket") == true => 8,
            var s when s?.Contains("products") == true && s?.Contains("specific") == true => 9,
            var s when s?.Contains("products") == true && s?.Contains("blanket") == true => 10,
            var s when s?.Contains("nursery") == true || s?.Contains("greenhouse") == true => 11,
            var s when s?.Contains("pacc crop") == true || s?.Contains("crops feed") == true => 12,
            var s when s?.Contains("hay") == true || s?.Contains("grain") == true || s?.Contains("fodder") == true => 13,
            var s when s?.Contains("livestock freezing") == true || s?.Contains("freezing") == true => 14,
            var s when s?.Contains("trellis") == true || s?.Contains("growers") == true => 15,
            _ => -1
        };
        #endregion

        #region Actions
        /// <summary>
        /// Select a coverage by name and optionally set limit/deductible
        /// </summary>
        public async Task SelectCoverageAsync(string coverageName, string limit = null, string deductible = null)
        {
            var rowIndex = GetCoverageRowIndex(coverageName);
            if (rowIndex < 0)
            {
                System.Console.WriteLine($"WARNING: FPP coverage '{coverageName}' not matched - no checkbox selected");
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

            if (!string.IsNullOrEmpty(deductible))
            {
                var deductibleSelect = CoverageDeductible(rowIndex);
                if (await deductibleSelect.CountAsync() > 0)
                {
                    await deductibleSelect.ClickAsync();
                    await _page.GetByRole(AriaRole.Option, new() { Name = deductible }).ClickAsync();
                }
            }

            System.Console.WriteLine($"Selected FPP coverage '{coverageName}' with limit '{limit}'");
        }
        #endregion
    }
}
