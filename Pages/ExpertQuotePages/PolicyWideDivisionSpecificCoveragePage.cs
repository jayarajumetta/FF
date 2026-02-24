using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reqnroll;
using System.Runtime.InteropServices;

namespace Playwright_POC.Pages
{
    public class PolicyWideDivisionSpecificCoveragePage
    {
        private readonly IPage _page;
        public PolicyWideDivisionSpecificCoveragePage(IPage page)
        {
            _page = page;
        }
        // -----Column Selectors-----
        private const string RowSelector = "tr.mat-row, mat-row.mat-row";
        private const string CoverageTypeSelector = "td.cdk-column-column1 span.readonly-value-no-label, mat-cell.cdk-column-column1 span.readonly-value-no-label";
        private const string CoverageNameSelector = "td.cdk-column-column2 span.readonly-value-no-label, mat-cell.cdk-column-column2 span.readonly-value-no-label";
        private const string CheckboxInputSelector = "td.cdk-column-select input[type='checkbox'], mat-cell.cdk-column-select input[type='checkbox']";
        private const string CheckboxClickableSelector = "td.cdk-column-select label.mat-checkbox-layout, mat-cell.cdk-column-select label.mat-checkbox-layout";
        private const string AddCoverageButtonSelector =
                                        "button[data-testid^='fields.data.CoverageSections'][data-testid*='.addEdit'], " +
                                        "button[data-testid^='fields.data.CoverageSections']:has-text('Add Coverage'), " +
                                        "button:has-text('ADD COVERAGE'), button:has-text('Add Coverage')";


        public async Task SetCoverageSelectedAsync(string coverageType, string coverageName, bool selected)
        {
            var row = await FindUniqueRowAsync(coverageType, coverageName);

            // Always READ state from the real checkbox input (even though it's hidden)
            var input = row.Locator(CheckboxInputSelector).First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Attached });

            var isChecked = await input.IsCheckedAsync();
            if (isChecked == selected)
                return;

            // Always CLICK the label/layout (this is what receives clicks in the DOM)
            var clickable = row.Locator(CheckboxClickableSelector).First;
            await clickable.ScrollIntoViewIfNeededAsync();

            await clickable.ClickAsync(new() { Force = true });

            // Re-check to ensure it toggled
            var nowChecked = await input.IsCheckedAsync();
            if (nowChecked != selected)
            {
                // one more forced click if Angular swallowed first click
                await clickable.ClickAsync(new() { Force = true });
            }

            await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);
        }

        public Task CheckCoverageAsync(string coverageType, string coverageName) => SetCoverageSelectedAsync(coverageType, coverageName, selected: true);

        public Task UncheckCoverageAsync(string coverageType, string coverageName) => SetCoverageSelectedAsync(coverageType, coverageName, selected: false);



        /// <summary>
        /// Apply a SpecFlow/ReqnRoll table like:
        /// | CoverageType | CoverageName          | Select |
        /// | Policy       | Agribusiness          | Yes    |
        /// | Division II  | Excess Debris Removal | No     |
        /// </summary>

        public async Task ApplyCoverageSelectionsAsync(Table table)
        {
            foreach (var row in table.Rows)
            {
                var type = row["CoverageType"]?.Trim() ?? "";
                var name = row["CoverageName"]?.Trim() ?? "";
                var selecRaw = row["Select"]?.Trim() ?? "No";

                var selected = ParseYesNo(selecRaw);
                await SetCoverageSelectedAsync(type, name, selected);
            }
        }

        public async Task VerifyCoverageSelectedAsync(string coverageType, string coverageName, bool expectedSelected)
        {
            var row = await FindUniqueRowAsync(coverageType, coverageName);

            var checkbox = row.Locator(CheckboxInputSelector).First;
            await checkbox.WaitForAsync(new() {  State = WaitForSelectorState.Attached });

            var actual = await checkbox.IsCheckedAsync();

            Assert.That(actual, Is.EqualTo(expectedSelected), $"Coverage selection mismatch for [{coverageType}] [{coverageName}]. Expected: {expectedSelected}, Actual: {actual}");

        }

        private static string Normalize(string s)
        {
            return (s ?? string.Empty)
                .Replace('\u00A0', ' ')
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }

        private async Task<ILocator> FindUniqueRowAsync(string coverageType, string coverageName)
        {
            coverageType = Normalize(coverageType);
            coverageName = Normalize(coverageName);

            if (string.IsNullOrWhiteSpace(coverageType))
                throw new ArgumentException("coverageType cannot be null/empty.");
            if (string.IsNullOrWhiteSpace(coverageName))
                throw new ArgumentException("coverageName cannot be null/empty.");

            // Wait for the table to render at least one row
            var allRows = _page.Locator(RowSelector);
            await allRows.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            var rowCount = await allRows.CountAsync();

            var matches = new List<int>();

            for (int i = 0; i < rowCount; i++)
            {
                var row = allRows.Nth(i);

                // Pull type/name text from their specific columns
                var typeLoc = row.Locator(CoverageTypeSelector).First;
                var nameLoc = row.Locator(CoverageNameSelector).First;

                // Some rows might not have spans yet; skip safely
                if (await typeLoc.CountAsync() == 0 || await nameLoc.CountAsync() == 0)
                    continue;

                var actualType = Normalize(await typeLoc.InnerTextAsync());
                var actualName = Normalize(await nameLoc.InnerTextAsync());

                if (actualType.Equals(coverageType, StringComparison.OrdinalIgnoreCase) && actualName.Equals(coverageName, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(i);
                }
            }

            if (matches.Count == 1)
            {
                var match = allRows.Nth(matches[0]);
                await match.ScrollIntoViewIfNeededAsync();
                return match;
            }

            if (matches.Count > 1)
            {
                throw new ArgumentException(
                    $"Multiple coverage rows matched CoverageType='{coverageType}' AND CoverageName='{coverageName}'." + $"Matched row indexes: {string.Join(", ", matches)}");
            }

            // Diagnostics: dump the first several rows so you see exactly what Playwright sees
            var diagnostics = new List<string>();
            var diagLimit = Math.Min(rowCount, 10);

            for (int i = 0; i<diagLimit; i++)
            {
                var r = allRows.Nth(i);
                var t = await r.Locator(CoverageTypeSelector).First.InnerTextAsync();
                var n = await r.Locator(CoverageNameSelector).First.InnerTextAsync();
                diagnostics.Add($"[{i}] Type='{Normalize(t)}' Name='{Normalize(n)}'");
            }

            throw new ArgumentException(
                $"No coverage row found for CoverageType='{coverageType}' AND CoverageName='{coverageName}'.\n +" +
                $"First {diagLimit} rows seen by Playwright:\n" +
                string.Join("\n", diagnostics));

        }
        private static bool ParseYesNo(string value)
        {
            var v = (value ?? string.Empty).Trim();

            return v.Equals("Yes", StringComparison.OrdinalIgnoreCase)
                || v.Equals("Y", StringComparison.OrdinalIgnoreCase)
                || v.Equals("True", StringComparison.OrdinalIgnoreCase)
                || v.Equals("1");

        }

        public async Task ClickAllAddCoverageButtonsAsync()
        {
            var buttons = _page.Locator(AddCoverageButtonSelector);
            var count = await buttons.CountAsync();

            for (int i = 0; i < count; i++)
            {
                var btn = buttons.Nth(i);

                if (!await btn.IsVisibleAsync())
                    continue;

                await btn.ScrollIntoViewIfNeededAsync();
                await btn.ClickAsync(new() { Force = true });

                await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);
            }
        }

        public async Task ClickAddCoverageForSelectionAsync(string coverageType, string coverageName)
        {
            coverageType = coverageType.Trim();
            coverageName = coverageName.Trim();

            var cardTitle = coverageType.Equals("Policy", StringComparison.OrdinalIgnoreCase) ? coverageName : $"{coverageName} - {coverageType}";

            var card = _page.Locator($"text={cardTitle}").Locator("xpath=ancestor::*[self::div or self::mat-card][1]");

            var addBtn = card.Locator("button:has-text('ADD COVERAGE'), button:has-text('Add Coverage')").First;

            await addBtn.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await addBtn.ScrollIntoViewIfNeededAsync();
            await addBtn.ClickAsync(new() { Force = true });

            await Helpers.Helpers.WaitForSpinnerToClearAsync(_page);
        }

        public async Task ApplySelectionsAndAddCoveragesAsync(Table table)
        {
            await ApplyCoverageSelectionsAsync(table);

            foreach (var row in table.Rows)
            {
                var type = row["CoverageType"].Trim();
                var name = row["CoverageName"].Trim();
                var selected = ParseYesNo(row["Select"]);

                if (selected)
                    await ClickAddCoverageForSelectionAsync(type, name);
            }
        }
    }
   
}
