using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Farm Personal Property page - select FPP coverages with limits and deductibles.
    /// Row indices in DuckCreek testIds are positional and vary by state — always resolve
    /// the row index dynamically from the DOM using FindRowByCodeAsync() rather than
    /// hardcoding indices.
    /// </summary>
    public class SFP_FarmPersonalPropertyPage : BasePage
    {
        public SFP_FarmPersonalPropertyPage(IPage page) : base(page) { }

        #region Locators
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTable");

        // Coverage controls by row index (resolved dynamically — do not hardcode)
        // DuckCreek checkboxes have both <label> and <input> with the same data-testid.
        // Target the label specifically to avoid strict mode violations.
        public ILocator CoverageCheckbox(int row) =>
            _page.Locator($"label[data-testid='fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value']");

        public ILocator CoverageLimit(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$limit.value");

        public ILocator CoverageDeductible(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$deductible.value");

        public ILocator NextButton => _page.GetByTestId("fields.data_Rules.nextEB");

        // Add Coverage button - appears after checking a coverage checkbox.
        // The testid varies by coverage type, so we use multiple locator strategies.
        // Primary: Find any button with testid containing "add" in the fields.line section
        public ILocator AddCoverageButton =>
            _page.Locator("button[data-testid*='fields.line.'][data-testid*='.add']").First;

        // Fallback: Find by role with common button text patterns
        public ILocator AddCoverageButtonByRole =>
            _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("^\\+ ADD", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

        // Item entry fields (appear after clicking Add Coverage)
        public ILocator ItemDescription(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$description.value");

        public ILocator ItemLimit(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$limit.value");

        public ILocator ItemDeductible(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$deductible.value");

        public ILocator SaveItemButton => _page.GetByTestId("fields.covEndorsements.save");

        /// <summary>
        /// Clicks the Add Coverage button. The testid varies by coverage type so we use a partial
        /// data-testid match; if that misses, fall back to the button's ARIA role and "+ ADD" label.
        /// </summary>
        public async System.Threading.Tasks.Task ClickAddCoverageButtonAsync()
        {
            await WaitForSpinnerAsync();

            // Primary: partial testid match catches all coverage types
            // (e.g. covAudioVisualDataElectronicEquipment, covFarmTools, etc.)
            if (await AddCoverageButton.CountAsync() > 0 && await AddCoverageButton.IsVisibleAsync())
            {
                await AddCoverageButton.ScrollIntoViewIfNeededAsync();
                await AddCoverageButton.ClickAsync();
                return;
            }

            // Try role-based locator for "+ ADD" buttons
            if (await AddCoverageButtonByRole.CountAsync() > 0 && await AddCoverageButtonByRole.First.IsVisibleAsync())
            {
                await AddCoverageButtonByRole.First.ScrollIntoViewIfNeededAsync();
                await AddCoverageButtonByRole.First.ClickAsync();
                return;
            }

            throw new Microsoft.Playwright.PlaywrightException(
                "Add Coverage button not found. Expected button[data-testid*='fields.line.'][data-testid*='.add'] or a '+ ADD' button.");
        }
        #endregion

        #region Dynamic Row Lookup
        /// <summary>
        /// Finds the DuckCreek row index for a coverage by scanning the visible table rows for
        /// a cell whose text matches <paramref name="code"/> (exact) or <paramref name="descriptionFragment"/>
        /// (partial, case-insensitive). Returns -1 when no match is found.
        ///
        /// This avoids hardcoded positional indices that shift when a state omits certain coverages.
        /// </summary>
        public async Task<int> FindRowByCodeAsync(string code, string descriptionFragment = null)
        {
            // Scan all covCatEntry checkbox testIds present on the page and check sibling text
            var rowCount = await _page.Locator("[data-testid*='covCatEntry.rows'][data-testid$='selected.value']").CountAsync();
            for (var i = 0; i < rowCount; i++)
            {
                // The row container sits above the checkbox — walk up to tr-level via JS
                var rowText = await _page.EvaluateAsync<string>($@"
                    () => {{
                        const cb = document.querySelector(
                            '[data-testid=""fields.page.covCatEntry.rows[{i}].covCatEntryInput$selected.value""]');
                        if (!cb) return '';
                        const row = cb.closest('tr') ?? cb.closest('[class*=""row""]') ?? cb.parentElement;
                        return row ? row.textContent.trim() : '';
                    }}");

                if (string.IsNullOrEmpty(rowText)) continue;

                // Match by exact code number (e.g. "464")
                if (!string.IsNullOrEmpty(code) && rowText.Contains(code, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[FPP] Matched code '{code}' at row {i}: {rowText.Substring(0, Math.Min(80, rowText.Length))}");
                    return i;
                }

                // Match by description fragment (e.g. "electronic", "audio")
                if (!string.IsNullOrEmpty(descriptionFragment) && rowText.Contains(descriptionFragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[FPP] Matched description '{descriptionFragment}' at row {i}: {rowText.Substring(0, Math.Min(80, rowText.Length))}");
                    return i;
                }
            }

            Console.WriteLine($"[FPP] No row found for code='{code}' description='{descriptionFragment}' (scanned {rowCount} rows)");
            return -1;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Select a coverage by name and optionally set limit/deductible
        /// </summary>
        public async Task SelectCoverageAsync(string coverageName, string limit = null, string deductible = null)
        {
            var rowIndex = await FindRowByCodeAsync(null, coverageName);
            if (rowIndex < 0)
            {
                Console.WriteLine($"WARNING: FPP coverage '{coverageName}' not found in table");
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

            Console.WriteLine($"Selected FPP coverage '{coverageName}' with limit '{limit}'");
        }
        #endregion
    }
}
