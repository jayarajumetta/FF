using Microsoft.Playwright;
using System;
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

        // DuckCreek checkboxes have both <label> and <input> with the same data-testid.
        // Target the label specifically to avoid strict mode violations.
        public ILocator CoverageCheckbox(int row) =>
            _page.Locator($"label[data-testid='fields.page.covCatEntry.rows[{row}].covCatEntryInput$selected.value']");

        // Fallback for states/pages where the testid path prefix differs.
        public ILocator CoverageCheckboxByIndex(int row) =>
            _page.Locator("label[data-testid*='covCatEntryInput$selected.value']").Nth(row);

        public ILocator CoverageLimit(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$limit.value");

        public ILocator CoverageValue(int row) =>
            _page.GetByTestId($"fields.page.covCatEntry.rows[{row}].covCatEntryInput$amount.value");

        public ILocator NextLiabilityButton => _page.GetByTestId("fields.data-Next.next");

        // Add Coverage button — testid varies by coverage type.
        // Strategy 1: covEndorsements add — standard DuckCreek SFP SPP pattern
        public ILocator AddCoverageButton =>
            _page.Locator("[data-testid*='covEndorsements'][data-testid*='add']").First;

        // Strategy 2: any button whose testid contains "fields.line." and ".add"
        public ILocator AddCoverageButtonByLineTestId =>
            _page.Locator("button[data-testid*='fields.line.'][data-testid*='.add']").First;

        // Strategy 3: any button whose accessible name contains "ADD COVERAGE" or "+ ADD"
        public ILocator AddCoverageButtonByRole =>
            _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("add", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

        // Item entry fields (appear after clicking Add Coverage)
        public ILocator ItemDescription(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$description.value");

        public ILocator ItemLimit(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$limit.value");

        public ILocator ItemYearOfAppraisal(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$yearOfLastAppraisal.value");

        public ILocator SaveItemButton => _page.GetByTestId("fields.data.save");

        /// <summary>
        /// Clicks the Add Coverage button. Tries multiple locator strategies, logs available
        /// button testids on failure to aid diagnosis.
        /// </summary>
        public async Task ClickAddCoverageButtonAsync()
        {
            await WaitForSpinnerAsync();

            // Strategy 1: covEndorsements add — standard DuckCreek SFP SPP pattern
            if (await AddCoverageButton.CountAsync() > 0 && await AddCoverageButton.IsVisibleAsync())
            {
                await AddCoverageButton.ScrollIntoViewIfNeededAsync();
                await AddCoverageButton.ClickAsync();
                return;
            }

            // Strategy 2: partial testid match on "fields.line." + ".add"
            if (await AddCoverageButtonByLineTestId.CountAsync() > 0 && await AddCoverageButtonByLineTestId.IsVisibleAsync())
            {
                await AddCoverageButtonByLineTestId.ScrollIntoViewIfNeededAsync();
                await AddCoverageButtonByLineTestId.ClickAsync();
                return;
            }

            // Strategy 3: any visible button whose accessible name contains "ADD"
            var count = await AddCoverageButtonByRole.CountAsync();
            for (var i = 0; i < count; i++)
            {
                var btn = AddCoverageButtonByRole.Nth(i);
                if (await btn.IsVisibleAsync())
                {
                    await btn.ScrollIntoViewIfNeededAsync();
                    await btn.ClickAsync();
                    return;
                }
            }

            // Diagnostic: log all button testids so we know what is on the page
            var testIds = await _page.EvaluateAsync<string[]>(@"
                () => Array.from(document.querySelectorAll('button[data-testid]'))
                          .map(b => b.getAttribute('data-testid'))");
            Console.WriteLine($"[SPP] Available button testids: {string.Join(", ", testIds ?? System.Array.Empty<string>())}");

            throw new PlaywrightException(
                "SPP Add Coverage button not found. Tried covEndorsements+add, fields.line.+.add, and role-based 'ADD'. See console for available testids.");
        }

        /// <summary>
        /// Attempts to select an SPP checkbox for the given row using exact and fallback locators.
        /// Returns true if a checkbox was clicked/checked; false if no viable checkbox was found.
        /// </summary>
        public async Task<bool> TrySelectCoverageCheckboxAsync(int rowIndex)
        {
            // 1) Exact locator path used by most states.
            var exact = CoverageCheckbox(rowIndex);
            if (await exact.CountAsync() > 0)
            {
                await exact.First.ScrollIntoViewIfNeededAsync();
                await exact.First.ClickAsync();
                return true;
            }

            // 2) Generic label list fallback (DOM variant-safe).
            var labels = _page.Locator("label[data-testid*='covCatEntryInput$selected.value']");
            var labelCount = await labels.CountAsync();
            if (labelCount > rowIndex)
            {
                var label = labels.Nth(rowIndex);
                await label.ScrollIntoViewIfNeededAsync();
                await label.ClickAsync();
                return true;
            }

            // 3) Input fallback for cases where label is not rendered/clickable.
            var inputs = _page.Locator("input[data-testid*='covCatEntryInput$selected.value']");
            var inputCount = await inputs.CountAsync();
            if (inputCount > rowIndex)
            {
                var input = inputs.Nth(rowIndex);
                await input.ScrollIntoViewIfNeededAsync();
                await input.CheckAsync();
                return true;
            }

            Console.WriteLine($"[SPP] No selectable checkbox found for row index {rowIndex}. labelCount={labelCount}, inputCount={inputCount}");
            return false;
        }
        #endregion

        #region Coverage Mapping
        /// <summary>
        /// Scans the live DOM for the coverage code cell and returns the row index.
        /// Uses <c>id="CovCatEntryOutput.CoverageID-{N}-layout"</c> cells.
        /// Returns -1 if the code is not found.
        /// </summary>
        public async Task<int> FindRowByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return -1;
            var target = code.Trim();

            // Wait for SPP content to attach before scanning rows.
            try
            {
                await _page
                    .Locator("[id*='CovCatEntryOutput.CoverageID-'][id$='-layout'], [data-testid*='covCatEntryInput$selected.value']")
                    .First
                    .WaitForAsync(new LocatorWaitForOptions
                    {
                        State = WaitForSelectorState.Attached,
                        Timeout = 10000
                    });
            }
            catch
            {
                // Continue to diagnostics below.
            }

            // Strategy 1: id-based cells (standard DuckCreek SPP layout)
            var cells = _page.Locator("[id*='CovCatEntryOutput.CoverageID-'][id$='-layout']");
            var count = await cells.CountAsync();
            for (var i = 0; i < count; i++)
            {
                var cell = cells.Nth(i);
                var text = (await cell.InnerTextAsync()).Trim();
                if (text == target)
                {
                    var id = await cell.GetAttributeAsync("id") ?? string.Empty;
                    var m = System.Text.RegularExpressions.Regex.Match(id, @"CoverageID-(\d+)-layout");
                    if (m.Success && int.TryParse(m.Groups[1].Value, out var parsedRow))
                        return parsedRow;

                    return i;
                }
            }

            // Strategy 2: testid-based rows (some states use a different DOM — e.g. WA)
            // Scan all covCatEntry rows for a cell whose text matches the code.
            if (count == 0)
            {
                var rows = _page.Locator("[data-testid*='covCatEntry.rows']");
                var rowCount = await rows.CountAsync();
                for (var i = 0; i < rowCount; i++)
                {
                    var text = (await rows.Nth(i).InnerTextAsync()).Trim();
                    if (text.Contains(target, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"[SPP] Code '{target}' found via testid rows at index {i}.");
                        return i;
                    }
                }
                Console.WriteLine($"[SPP] Code '{target}' not found in {rowCount} testid rows either.");
            }
            else
            {
                Console.WriteLine($"[SPP] Code '{target}' not found in {count} coverage rows.");
            }
            return -1;
        }

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
