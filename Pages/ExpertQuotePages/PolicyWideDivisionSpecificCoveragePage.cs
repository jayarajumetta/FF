using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class PolicyWideDivisionSpecificCoveragePage : BasePage
    {
        public PolicyWideDivisionSpecificCoveragePage(IPage page) : base(page)
        {
        }

        private const string RowSelector = "tr.mat-row, mat-row.mat-row, table tbody tr, table tr";
        private const string CoverageTypeSelector = "td.cdk-column-column1 span.readonly-value-no-label, mat-cell.cdk-column-column1 span.readonly-value-no-label, td:nth-child(2), mat-cell:nth-child(2)";
        private const string CoverageNameSelector = "td.cdk-column-column2 span.readonly-value-no-label, mat-cell.cdk-column-column2 span.readonly-value-no-label, td:nth-child(3), mat-cell:nth-child(3)";
        private const string CheckboxInputSelector = "td.cdk-column-select input[type='checkbox'], mat-cell.cdk-column-select input[type='checkbox'], input[type='checkbox']";
        private const string CheckboxClickableSelector = "td.cdk-column-select label.mat-checkbox-layout, mat-cell.cdk-column-select label.mat-checkbox-layout, td.cdk-column-select, mat-cell.cdk-column-select, td:nth-child(1), mat-cell:nth-child(1)";
        private const string AddCoverageButtonSelector =
            "button[data-testid^='fields.data.CoverageSections'][data-testid*='.addEdit'], " +
            "button[data-testid^='fields.data.CoverageSections']:has-text('Add Coverage'), " +
            "button:has-text('ADD COVERAGE'), button:has-text('Add Coverage')";

        public async Task SetCoverageSelectedAsync(string coverageType, string coverageName, bool selected)
        {
            var row = await FindUniqueRowAsync(coverageType, coverageName);

            var input = row.Locator(CheckboxInputSelector).First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Attached });

            var isChecked = await input.IsCheckedAsync();
            if (isChecked == selected)
                return;

            var clickable = row.Locator(CheckboxClickableSelector).First;
            await clickable.ScrollIntoViewIfNeededAsync();
            await clickable.ClickAsync(new() { Force = true });

            var nowChecked = await input.IsCheckedAsync();
            if (nowChecked != selected)
                await clickable.ClickAsync(new() { Force = true });

            await WaitForSpinnerAsync();
        }

        public Task CheckCoverageAsync(string coverageType, string coverageName) =>
            SetCoverageSelectedAsync(coverageType, coverageName, selected: true);

        public Task UncheckCoverageAsync(string coverageType, string coverageName) =>
            SetCoverageSelectedAsync(coverageType, coverageName, selected: false);

        public async Task ApplyCoverageSelectionsAsync(Table table)
        {
            foreach (var row in table.Rows)
            {
                var type = row["CoverageType"]?.Trim() ?? string.Empty;
                var name = row["CoverageName"]?.Trim() ?? string.Empty;
                var selectRaw = row["Select"]?.Trim() ?? "No";

                await SetCoverageSelectedAsync(type, name, ParseYesNo(selectRaw));
            }
        }

        public async Task VerifyCoverageSelectedAsync(string coverageType, string coverageName, bool expectedSelected)
        {
            var row = await FindUniqueRowAsync(coverageType, coverageName);

            var checkbox = row.Locator(CheckboxInputSelector).First;
            await checkbox.WaitForAsync(new() { State = WaitForSelectorState.Attached });

            var actual = await checkbox.IsCheckedAsync();
            Assert.That(actual, Is.EqualTo(expectedSelected),
                $"Coverage selection mismatch for [{coverageType}] [{coverageName}]. Expected: {expectedSelected}, Actual: {actual}");
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
                await WaitForSpinnerAsync();
            }
        }

        public async Task ClickAddCoverageForSelectionAsync(string coverageType, string coverageName)
        {
            coverageType = coverageType.Trim();
            coverageName = coverageName.Trim();

            var normalizedCoverage = NormalizeCoverageKey(coverageName);
            var coverageSectionButtons = new[]
            {
                _page.Locator($"[data-testid*='CoverageSections'][data-testid*='line_{normalizedCoverage}'][data-testid*='addEdit']").First,
                _page.Locator($"[data-testid*='CoverageSections'][data-testid*='{normalizedCoverage}'][data-testid*='addEdit']").First,
                _page.Locator($"[data-testid*='CoverageSections'][data-testid*='{normalizedCoverage}'] button").First,
            };

            foreach (var candidate in coverageSectionButtons)
            {
                if (await candidate.CountAsync() > 0)
                {
                    try
                    {
                        await candidate.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                        await candidate.ScrollIntoViewIfNeededAsync();
                        await candidate.ClickAsync(new() { Force = true });
                        await WaitForSpinnerAsync();
                        Console.WriteLine($"[Coverage] Clicked Add/Edit for '{coverageName}' using CoverageSections test id pattern.");
                        return;
                    }
                    catch (TimeoutException)
                    {
                        // Keep trying fallbacks below.
                    }
                }
            }

            var cardTitle = coverageType.Equals("Policy", StringComparison.OrdinalIgnoreCase)
                ? coverageName
                : $"{coverageName} - {coverageType}";

            var card = _page.Locator($"text={cardTitle}").Locator("xpath=ancestor::*[self::div or self::mat-card][1]");
            var addBtn = card.Locator("button:has-text('ADD COVERAGE'), button:has-text('Add Coverage')").First;

            try
            {
                await addBtn.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
                await addBtn.ScrollIntoViewIfNeededAsync();
                await addBtn.ClickAsync(new() { Force = true });
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[Coverage] No Add Coverage button for '{coverageName}' ({coverageType}) - continuing.");
                return;
            }

            await WaitForSpinnerAsync();
        }

        private static string NormalizeCoverageKey(string coverageName)
        {
            var chars = (coverageName ?? string.Empty).ToCharArray();
            var buffer = new List<char>(chars.Length);

            foreach (var ch in chars)
            {
                if (char.IsLetterOrDigit(ch))
                    buffer.Add(ch);
            }

            return new string(buffer.ToArray());
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

        public async Task EditCountryEstateCoverageAsync(Table table)
        {
            if (table is null || table.Rows.Count == 0)
                throw new ArgumentException("Country Estate coverage edit table must contain at least one row.");

            var row = table.Rows[0];
            var countryEstateAddButton = _page.GetByTestId(
                "fields.data_CoverageSections.policy_PolicyWideSection.line_CountryEstate.addEditCountryEstate-button-label");

            if (await countryEstateAddButton.CountAsync() == 0)
                throw new InvalidOperationException("Country Estate Endorsement Add Coverage button was not found.");

            await countryEstateAddButton.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await countryEstateAddButton.First.ScrollIntoViewIfNeededAsync();
            await countryEstateAddButton.First.ClickAsync(new() { Force = true });
            await WaitForSpinnerAsync();

            var countryEstatePage = new SFP_AddCountryEstateCoveragePage(_page);
            var ceSelection = BuildCountryEstateSelection(table, row);
            await countryEstatePage.AddCoverageAsync(ceSelection);

            Console.WriteLine("[Coverage] Edited Country Estate Endorsement via dedicated CE edit step.");
        }

        private static SFP_AddCountryEstateCoveragePage.CountryEstateCoverageSelection BuildCountryEstateSelection(Table table, DataTableRow row)
        {
            return new SFP_AddCountryEstateCoveragePage.CountryEstateCoverageSelection
            {
                DivisionIWaterDamage = GetCountryEstateValue(table, row, "CEDivisionIWaterDamage", "$5,000"),
                DivisionIIUnscheduledStructures = GetCountryEstateValue(table, row, "CEDivisionIIUnscheduledStructures", "$5,000"),
                DivisionIIIBlanketFppSublimit = GetCountryEstateValue(table, row, "CEDivisionIIIBlanketFppSublimit", "5000"),
                DivisionIIIBlanketFppDeductible = GetCountryEstateValue(table, row, "CEDivisionIIIBlanketFppDeductible", "$1,000"),
                DivisionVLiabilityLimit = GetCountryEstateValue(table, row, "CEDivisionVLiabilityLimit", "$500,000/$1,000,000"),
            };
        }

        private static string GetCountryEstateValue(Table table, DataTableRow row, string key, string fallback)
        {
            // Backward compatible path: original wide one-row table with CE keys as columns.
            var wideValue = GetOptionalCell(table, row, key, fallback);
            if (!string.Equals(wideValue, fallback, StringComparison.Ordinal))
                return wideValue;

            // Preferred path: vertical Question/Answer table.
            var hasQuestionAnswerSchema = table.Header.Any(h => h.Equals("Question", StringComparison.OrdinalIgnoreCase))
                                        && table.Header.Any(h => h.Equals("Answer", StringComparison.OrdinalIgnoreCase));

            if (!hasQuestionAnswerSchema)
                return wideValue;

            var qaRow = table.Rows.FirstOrDefault(r =>
                r["Question"].Equals(key, StringComparison.OrdinalIgnoreCase));

            if (qaRow == null)
                return fallback;

            var value = qaRow["Answer"]?.Trim();
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        private static string GetOptionalCell(Table table, DataTableRow row, string columnName, string fallback)
        {
            if (table is null || row is null)
                return fallback;

            var hasColumn = table.Header.Any(h => h.Equals(columnName, StringComparison.OrdinalIgnoreCase));
            if (!hasColumn)
                return fallback;

            var value = row[columnName]?.Trim();
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        public async Task HandleReviewRequiredModalIfPresentAsync()
        {
            var modal = _page.GetByText("Review Required", new() { Exact = true }).First;

            if (await modal.CountAsync() == 0 || !await modal.IsVisibleAsync())
                return;

            var keepGoing = _page.GetByRole(AriaRole.Button, new() { Name = "KEEP GOING" }).First;

            if (await keepGoing.CountAsync() > 0 && await keepGoing.IsVisibleAsync())
            {
                await keepGoing.ClickAsync(new() { Force = true });
                await WaitForSpinnerAsync();
                Console.WriteLine("[Coverage] Review Required modal detected - clicked KEEP GOING.");
            }
        }

        private static bool ParseYesNo(string value)
        {
            var v = (value ?? string.Empty).Trim();
            return v.Equals("Yes", StringComparison.OrdinalIgnoreCase)
                || v.Equals("Y", StringComparison.OrdinalIgnoreCase)
                || v.Equals("True", StringComparison.OrdinalIgnoreCase)
                || v.Equals("1", StringComparison.OrdinalIgnoreCase);
        }

        private static string Normalize(string s)
        {
            return (s ?? string.Empty)
                .Replace('\u00A0', ' ')
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }

        private static async Task<string> ExtractCellTextAsync(ILocator row, string primarySelector, int fallbackCellIndex)
        {
            var primary = row.Locator(primarySelector).First;
            if (await primary.CountAsync() > 0)
            {
                var text = Normalize(await primary.InnerTextAsync());
                if (!string.IsNullOrWhiteSpace(text))
                    return text;
            }

            var cells = row.Locator("td, mat-cell");
            if (await cells.CountAsync() > fallbackCellIndex)
            {
                var cell = cells.Nth(fallbackCellIndex);

                // Try direct text extraction first
                var directText = Normalize(await cell.InnerTextAsync());
                if (!string.IsNullOrWhiteSpace(directText))
                    return directText;

                // For nested ng-component structures, dig into readonly-value-no-label spans
                var nestedSpans = cell.Locator("span.readonly-value-no-label");
                if (await nestedSpans.CountAsync() > 0)
                {
                    var nestedText = Normalize(await nestedSpans.First.InnerTextAsync());
                    if (!string.IsNullOrWhiteSpace(nestedText))
                        return nestedText;
                }
            }

            return string.Empty;
        }

        private async Task<ILocator> FindUniqueRowAsync(string coverageType, string coverageName)
        {
            coverageType = Normalize(coverageType);
            coverageName = Normalize(coverageName);

            if (string.IsNullOrWhiteSpace(coverageType))
                throw new ArgumentException("coverageType cannot be null/empty.");
            if (string.IsNullOrWhiteSpace(coverageName))
                throw new ArgumentException("coverageName cannot be null/empty.");

            var allRows = _page.Locator(RowSelector);
            await allRows.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            var maxScrollPasses = 12;
            var viewportSignatures = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int pass = 0; pass <= maxScrollPasses; pass++)
            {
                var matches = new List<ILocator>();
                var currentRows = _page.Locator(RowSelector);
                var currentCount = await currentRows.CountAsync();

                for (int i = 0; i < currentCount; i++)
                {
                    var row = currentRows.Nth(i);

                    if (await row.Locator(CheckboxInputSelector).CountAsync() == 0)
                        continue;

                    var actualType = await ExtractCellTextAsync(row, CoverageTypeSelector, 1);
                    var actualName = await ExtractCellTextAsync(row, CoverageNameSelector, 2);

                    if (actualType.Equals(coverageType, StringComparison.OrdinalIgnoreCase)
                        && actualName.Equals(coverageName, StringComparison.OrdinalIgnoreCase))
                    {
                        matches.Add(row);
                    }

                    if (!string.IsNullOrEmpty(actualType) || !string.IsNullOrEmpty(actualName))
                        viewportSignatures.Add($"{actualType}|{actualName}");
                }

                if (matches.Count == 1)
                    return matches[0];

                if (matches.Count > 1)
                {
                    throw new InvalidOperationException(
                        $"Coverage row is not unique for CoverageType='{coverageType}', CoverageName='{coverageName}'. Matches found: {matches.Count}.");
                }

                if (pass == maxScrollPasses)
                    break;

                await currentRows.First.HoverAsync();
                await _page.Mouse.WheelAsync(0, 900);
                await _page.WaitForTimeoutAsync(200);
            }

            var diagnostics = new List<string>();
            var diagLimit = Math.Min(6, await allRows.CountAsync());
            for (int i = 0; i < diagLimit; i++)
            {
                var r = allRows.Nth(i);
                var t = await ExtractCellTextAsync(r, CoverageTypeSelector, 1);
                var n = await ExtractCellTextAsync(r, CoverageNameSelector, 2);
                diagnostics.Add($"[{i}] Type='{t}' Name='{n}'");
            }

            throw new ArgumentException(
                $"No coverage row found for CoverageType='{coverageType}' AND CoverageName='{coverageName}'.\n" +
                $"Rows observed while scrolling: {viewportSignatures.Count}.\n" +
                "First 6 rows seen by Playwright:\n" +
                string.Join("\n", diagnostics));
        }
    }
}
