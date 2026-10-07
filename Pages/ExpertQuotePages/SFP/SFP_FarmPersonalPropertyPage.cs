using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
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

        public async Task AddDetailedMachineryAsync(IReadOnlyDictionary<string, string> values)
        {
            SfpRequiredTable.RequireValue("Code", values["Code"], "472");
            SfpRequiredTable.RequireValue("SpecialUse", values["SpecialUse"], "No");
            var form = new SFP_NativeFormPage(_page);
            await Expect(CoverageTable.Locator("th.mat-column-column1, mat-header-cell.mat-column-column1"))
                .ToHaveTextAsync("Coverage Code");
            var row = await form.SelectCatalogCoverageAsync(CoverageTable, "column1", values["Code"]);
            await Expect(row.Locator("td.mat-column-column2, mat-cell.mat-column-column2"))
                .ToHaveTextAsync("Farm Machinery - Specific");
            await form.ClickActionAsync("AddFarmMachinerySpecific");
            await ApplyMachineryAsync(values, verifyOnly: false);
            await form.ClickActionAsync("Save");
            await form.RequireReadyAsync(CoverageTable);
            await form.ClickActionAsync("EditFarmMachinerySpecific");
            await ApplyMachineryAsync(values, verifyOnly: true);
            await form.ClickActionAsync("Cancel");
            await form.RequireReadyAsync(CoverageTable);

            var nextEb = form.Action("NextEB");
            var nextSpp = form.Action("NextSPP");
            await nextEb.Or(nextSpp).First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            if (!await nextEb.IsVisibleAsync())
                await form.ClickActionAsync("NextSPP");
            await form.ClickActionAsync("NextEB");
        }

        internal async Task ApplyMachineryAsync(IReadOnlyDictionary<string, string> values, bool verifyOnly)
        {
            SfpRequiredTable.RequireValue("SpecialUse", values["SpecialUse"], "No");
            var form = new SFP_NativeFormPage(_page);
            foreach (var (question, logical, number) in new[]
            {
                ("Limit", "CovSpecificFarmMachineryInput.Limit", true),
                ("Deductible", "CovSpecificFarmMachineryInput.Deductible", false),
                ("SpecialUse", "CovSpecificFarmMachineryInput.SpecialUse", false),
                ("CabGlass", "CovSpecificFarmMachineryInput.TractorGlass", false),
                ("Year", "CovSpecificFarmMachineryInput.Year", true),
                ("Make", "CovSpecificFarmMachineryInput.Make", false),
                ("Model", "CovSpecificFarmMachineryInput.Model", false),
                ("SerialNumber", "CovSpecificFarmMachineryInput.SerialNumber", false)
            })
            {
                var value = question == "SpecialUse" ? "None" : values[question];
                if (verifyOnly)
                    await form.VerifyAsync(logical, value, number);
                else
                    await form.SetAsync(logical, value, number);
            }
        }

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

        // Add Coverage button — appears after checking a coverage checkbox.
        // Strategy 1: covEndorsements add button (DuckCreek SFP FPP standard pattern)
        public ILocator AddCoverageButton =>
            _page.Locator("[data-testid*='covEndorsements'][data-testid*='add']").First;

        // Strategy 2: any button whose testid contains "fields.line." and ".add"
        public ILocator AddCoverageButtonByLineTestId =>
            _page.Locator("button[data-testid*='fields.line.'][data-testid*='.add']").First;

        // Strategy 3: any button whose accessible name contains "ADD" (case-insensitive)
        public ILocator AddCoverageButtonByRole =>
            _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("add", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

        // Item entry fields (appear after clicking Add Coverage)
        public ILocator ItemDescription(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$description.value");

        public ILocator ItemLimit(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$limit.value");

        public ILocator ItemDeductible(int row = 0) =>
            _page.GetByTestId($"fields.covEndorsements.rows[{row}].covEndorsementsInput$deductible.value");

        public ILocator SaveItemButton => _page.GetByTestId("fields.covEndorsements.save");

        public async Task VerifyItemAsync(ScenarioContextData data)
        {
            // QA can retain entered casing before Save; CLAS also supports uppercase normalization.
            var description = data.FarmPropertyDescription;
            await Expect(ItemDescription()).ToHaveValueAsync(new Regex(
                "^(?:" + Regex.Escape(description) + "|" + Regex.Escape(description.ToUpperInvariant()) + ")$"));
            await SfpFieldAssertions.NumberAsync(ItemLimit(), data.FarmPropertyLimit);
            await SfpFieldAssertions.SelectionAsync(ItemDeductible(), data.FarmPropertyDeductible);
        }

        /// <summary>
        /// Clicks the Add Coverage button. Tries multiple locator strategies, logs available
        /// button testids on failure to aid diagnosis.
        /// </summary>
        public async System.Threading.Tasks.Task ClickAddCoverageButtonAsync()
        {
            await WaitForSpinnerAsync();

            // Strategy 1: covEndorsements add — standard DuckCreek SFP FPP pattern
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
            Console.WriteLine($"[FPP] Available button testids: {string.Join(", ", testIds ?? System.Array.Empty<string>())}");

            throw new Microsoft.Playwright.PlaywrightException(
                "Add Coverage button not found. Tried covEndorsements+add, fields.line.+.add, and role-based 'ADD'. See console for available testids.");
        }
        #endregion

        #region Dynamic Row Lookup
        public async Task<int> FindRequiredRowByCodeAsync(string code)
        {
            // TableBuilder assigns CoverageID to column1; verify the schema before matching.
            await Expect(CoverageTable.Locator("th.mat-column-column1, mat-header-cell.mat-column-column1"))
                .ToHaveTextAsync("Coverage Code");
            var codeCell = _page.Locator("td.mat-column-column1, mat-cell.mat-column-column1")
                .Filter(new() { HasTextRegex = new Regex(@"^\s*" + Regex.Escape(code) + @"\s*$") });
            var row = CoverageTable.Locator("tr, mat-row").Filter(new() { Has = codeCell });
            await Expect(row).ToHaveCountAsync(1);
            var checkbox = row.Locator("label[data-testid*='covCatEntry.rows'][data-testid$='selected.value']");
            await Expect(checkbox).ToHaveCountAsync(1);
            var testId = await checkbox.GetAttributeAsync("data-testid");
            var match = Regex.Match(testId ?? "", @"^fields\.page\.covCatEntry\.rows\[(\d+)\]\.covCatEntryInput\$selected\.value$");
            if (!match.Success)
                throw new PlaywrightException($"Required FPP coverage '{code}' has no recognized row identifier.");

            return int.Parse(match.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
        }

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
