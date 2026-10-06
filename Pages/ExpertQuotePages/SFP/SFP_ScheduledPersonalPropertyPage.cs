using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Models;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Scheduled Personal Property page - select SPP categories with limits.
    /// </summary>
    public class SFP_ScheduledPersonalPropertyPage : BasePage
    {
        public SFP_ScheduledPersonalPropertyPage(IPage page) : base(page) { }

        public async Task AddAndVerifyRatePolicyItemAsync(IReadOnlyDictionary<string, string> values)
        {
            var code = values["Category"];
            var action = code switch
            {
                "407" => "Jewelry",
                "409" => "Stamp",
                "411" => "AutoTrailer",
                _ => throw new ArgumentException($"Unsupported Rate Policy SPP category '{code}'.")
            };
            var form = new SFP_NativeFormPage(_page);
            await Expect(CoverageTable).ToBeVisibleAsync();
            await FilterInput.FillAsync(code);
            await Expect(CoverageTable.Locator("th.mat-column-column1, mat-header-cell.mat-column-column1"))
                .ToHaveTextAsync("Coverage Code");
            var row = await form.SelectCatalogCoverageAsync(CoverageTable, "column1", code);
            var caption = code switch
            {
                "407" => @"\bJewelry\b",
                "409" => @"\bStamp\s+Collections?\b",
                "411" => @"\bAuto\W+Trailer\W+Home\W+Personal\s+Effects\b",
                _ => throw new ArgumentException($"Unsupported Rate Policy SPP category '{code}'.")
            };
            await Expect(row).ToContainTextAsync(new Regex(caption, RegexOptions.IgnoreCase));
            await ClickRequiredActionAsync("Add" + action);
            await ApplyRatePolicyItemAsync(values, verifyOnly: false);
            await ClickRequiredActionAsync("Save");
            await form.RequireReadyAsync(CoverageTable);
            await ClickRequiredActionAsync("Edit" + action);
            await ApplyRatePolicyItemAsync(values, verifyOnly: true);
            var nav = _page.Locator("[data-testid='ScheduledPersonalProperty-nav'], #ScheduledPersonalProperty-nav");
            await Expect(nav).ToHaveCountAsync(1);
            await nav.ClickAsync();
            await WaitForSpinnerAsync();
            await form.RequireReadyAsync(CoverageTable);
        }

        internal async Task ApplyRatePolicyItemAsync(IReadOnlyDictionary<string, string> values, bool verifyOnly)
        {
            var form = new SFP_NativeFormPage(_page);
            var code = values["Category"];
            var nativeFields = new List<(string Field, string Value, bool Number)>
            {
                ("CovEndorsementsInput.Description", values["Description"], false),
                ("CovEndorsementsInput.Limit", values[code == "407" ? "Limit" : "Amount"], true)
            };
            if (code is "407" or "409")
                nativeFields.Add(("CovEndorsementsInput.YearOfLastAppraisal", values["AppraisalYear"], true));
            switch (code)
            {
                case "407":
                    nativeFields.Add(("CovJewelryInput.TypeOfStone", values["TypeOfStone"], false));
                    nativeFields.Add(("CovJewelryInput.Carat", values["Carat"], false));
                    nativeFields.Add(("CovJewelryInput.Cut", values["Cut"], false));
                    nativeFields.Add(("CovJewelryInput.TypeOfJewelry", values["TypeOfJewelry"], false));
                    nativeFields.Add(("CovJewelryInput.VaultCredit", values["KeptInAVault"], false));
                    nativeFields.Add(("CovJewelryInput.GemPrint", values["GemPrint"], false));
                    break;
                case "409":
                    nativeFields.Add(("CovStampCollectionsInput.VaultCredit", values["KeptInVault"], false));
                    nativeFields.Add(("CovStampCollectionsInput.UnattendedVehicle", values["UnattendedVehicle"], false));
                    break;
                case "411":
                    nativeFields.Add(("CovAutoTrailerHomePersonalEffectsInput.LimitPeril", values["LimitPeril"], false));
                    nativeFields.Add(("CovAutoTrailerHomePersonalEffectsInput.ProfessionalEntertainer", values["ProfessionalEntertainer"], false));
                    nativeFields.Add(("CovAutoTrailerHomePersonalEffectsInput.UnattendedVehicles", values["UnattendedVehicles"], false));
                    // One supplied person's name requires one named-person slot in the native editor.
                    nativeFields.Add(("CovAutoTrailerHomePersonalEffectsInput.NamedPerson", "1", false));
                    nativeFields.Add(("CovAutoTrailerHomePersonalEffectsInput.Name", values["Name"], false));
                    break;
                default:
                    throw new ArgumentException($"Unsupported Rate Policy SPP category '{code}'.");
            }
            foreach (var (field, value, number) in nativeFields)
            {
                if (verifyOnly)
                    await form.VerifyAsync(field, value, number);
                else
                    await form.SetAsync(field, value, number);
            }
        }

        public async Task AddAndVerifyCountryEstateItemAsync(SfpScheduledPropertyItem item)
        {
            var action = item.Code switch
            {
                "409" => "Stamp",
                "411" => "AutoTrailer",
                _ => throw new ArgumentException($"Unsupported CE scheduled-property code '{item.Code}'.")
            };
            await WaitForSpinnerAsync();
            await Expect(CoverageTable).ToBeVisibleAsync();
            await Expect(FilterInput).ToHaveCountAsync(1);
            await FilterInput.FillAsync(item.Code);
            await Expect(CoverageTable.Locator("th.mat-column-column1, mat-header-cell.mat-column-column1"))
                .ToHaveTextAsync("Coverage Code");
            var codeCell = _page.Locator("td.mat-column-column1, mat-cell.mat-column-column1")
                .Filter(new() { HasTextRegex = new Regex(@"^\s*" + Regex.Escape(item.Code) + @"\s*$") });
            var row = CoverageTable.Locator("tr, mat-row").Filter(new() { Has = codeCell });
            await Expect(row).ToHaveCountAsync(1);
            var checkbox = row.GetByTestId(new Regex(@"\.covCatEntryInput\$selected\.value$", RegexOptions.IgnoreCase))
                .And(_page.Locator("input[type='checkbox']"));
            await Expect(checkbox).ToHaveCountAsync(1);
            await Expect(checkbox).ToBeEnabledAsync();
            var label = row.GetByTestId(new Regex(@"\.covCatEntryInput\$selected\.value$", RegexOptions.IgnoreCase))
                .And(_page.Locator("label"));
            await Expect(label).ToHaveCountAsync(1);
            if (!await checkbox.IsCheckedAsync())
                await label.ClickAsync();
            await Expect(checkbox).ToBeCheckedAsync();
            await WaitForSpinnerAsync();

            await ClickRequiredActionAsync("add" + action);
            await FillCountryEstateItemAsync(item);
            await VerifyCountryEstateItemAsync(item);
            await ClickRequiredActionAsync("save");
            await Expect(CoverageTable).ToBeVisibleAsync();

            // Reopen by the category-specific action, never a generic first Edit button.
            await ClickRequiredActionAsync("edit" + action);
            await VerifyCountryEstateItemAsync(item);
            var nav = _page.Locator("[data-testid='ScheduledPersonalProperty-nav'], #ScheduledPersonalProperty-nav");
            await Expect(nav).ToHaveCountAsync(1);
            await nav.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(CoverageTable).ToBeVisibleAsync();
        }

        private ILocator RequiredItemField(string name) =>
            _page.GetByTestId(new Regex(@"\.covEndorsementsInput\$" + Regex.Escape(name) + @"\.value$", RegexOptions.IgnoreCase))
                .And(_page.Locator("input:visible, textarea:visible"));

        private ILocator NamedPersonCount =>
            _page.GetByTestId(new Regex(@"\.covAutoTrailerHomePersonalEffectsInput\$namedPerson\.value$", RegexOptions.IgnoreCase))
                .And(_page.Locator(":visible"));

        private ILocator NamedPersonNames =>
            _page.GetByTestId(new Regex(@"\.covAutoTrailerHomePersonalEffectsInput\$name\.value$", RegexOptions.IgnoreCase))
                .And(_page.Locator("input:visible, textarea:visible"));

        private static string NamedPersonCaption(SfpScheduledPropertyItem item) =>
            item.NamedPersonCount == 0 ? "None" : item.NamedPersonCount?.ToString(CultureInfo.InvariantCulture)
                ?? throw new ArgumentException("Coverage 411 requires an explicit NamedPersonCount.");

        private ILocator UnattendedChips(string code)
        {
            var field = code switch
            {
                "409" => @"covStampCollectionsInput\$unattendedVehicle",
                "411" => @"covAutoTrailerHomePersonalEffectsInput\$unattendedVehicles",
                _ => throw new ArgumentException($"Unsupported CE scheduled-property code '{code}'.")
            };
            return _page.GetByTestId(new Regex(@"\." + field + @"\.value-chip-item-wrapper$", RegexOptions.IgnoreCase))
                .And(_page.Locator(":visible"));
        }

        private async Task FillCountryEstateItemAsync(SfpScheduledPropertyItem item)
        {
            // Requiring both exact options also establishes the intended category's editor.
            var chips = UnattendedChips(item.Code);
            await Expect(chips).ToHaveCountAsync(2);
            foreach (var value in new[] { "Yes", "No" })
                await Expect(chips.Filter(new() { HasTextRegex = new Regex(@"^\s*" + value + @"\s*$") })).ToHaveCountAsync(1);

            await FillRequiredItemFieldAsync("description", item.Description);
            await FillRequiredItemFieldAsync("limit", item.Amount.ToString(CultureInfo.InvariantCulture));
            if (item.Code == "411")
            {
                await Expect(NamedPersonCount).ToHaveCountAsync(1);
                await Expect(NamedPersonCount).ToBeEnabledAsync();
                await NamedPersonCount.ClickAsync();
                var option = _page.GetByRole(AriaRole.Listbox).And(_page.Locator(":visible"))
                    .GetByRole(AriaRole.Option, new() { Name = NamedPersonCaption(item), Exact = true });
                await Expect(option).ToHaveCountAsync(1);
                await option.ClickAsync();
                await WaitForSpinnerAsync();
                await Expect(NamedPersonNames).ToHaveCountAsync(1);
                await NamedPersonNames.FillAsync(item.NamedPersonNames);
                await NamedPersonNames.PressAsync("Tab");
                await WaitForSpinnerAsync();
            }
            if (item.YearOfAppraisal.HasValue)
                await FillRequiredItemFieldAsync("yearOfLastAppraisal", item.YearOfAppraisal.Value.ToString(CultureInfo.InvariantCulture));
            await chips.Filter(new() { HasTextRegex = new Regex(item.UnattendedVehicle ? @"^\s*Yes\s*$" : @"^\s*No\s*$") }).ClickAsync();
            await WaitForSpinnerAsync();
        }

        private async Task FillRequiredItemFieldAsync(string name, string value)
        {
            var input = RequiredItemField(name);
            await Expect(input).ToHaveCountAsync(1);
            await input.FillAsync(value);
            await input.PressAsync("Tab");
            await WaitForSpinnerAsync();
        }

        public async Task VerifyCountryEstateItemAsync(SfpScheduledPropertyItem item)
        {
            var description = RequiredItemField("description");
            await Expect(description).ToHaveCountAsync(1);
            await Expect(description).ToHaveValueAsync(new Regex(
                "^(?:" + Regex.Escape(item.Description) + "|" + Regex.Escape(item.Description.ToUpperInvariant()) + ")$"));
            var limit = RequiredItemField("limit");
            await Expect(limit).ToHaveCountAsync(1);
            await SfpFieldAssertions.NumberAsync(limit, item.Amount.ToString(CultureInfo.InvariantCulture));
            if (item.Code == "411")
            {
                await Expect(NamedPersonCount).ToHaveCountAsync(1);
                await SfpFieldAssertions.SelectionAsync(NamedPersonCount, NamedPersonCaption(item));
                await Expect(NamedPersonNames).ToHaveCountAsync(1);
                await Expect(NamedPersonNames).ToHaveValueAsync(new Regex(
                    "^(?:" + Regex.Escape(item.NamedPersonNames) + "|" + Regex.Escape(item.NamedPersonNames.ToUpperInvariant()) + ")$"));
            }
            if (item.YearOfAppraisal.HasValue)
            {
                var year = RequiredItemField("yearOfLastAppraisal");
                await Expect(year).ToHaveCountAsync(1);
                await Expect(year).ToHaveValueAsync(item.YearOfAppraisal.Value.ToString(CultureInfo.InvariantCulture));
            }
            var chips = UnattendedChips(item.Code);
            await Expect(chips).ToHaveCountAsync(2);
            var selected = chips.Filter(new() { HasTextRegex = new Regex(item.UnattendedVehicle ? @"^\s*Yes\s*$" : @"^\s*No\s*$") });
            await Expect(selected).ToHaveCountAsync(1);
            await Expect(selected.Locator(".chip-wrapper-selected")).ToBeVisibleAsync();
            var unselected = chips.Filter(new() { HasTextRegex = new Regex(item.UnattendedVehicle ? @"^\s*No\s*$" : @"^\s*Yes\s*$") });
            await Expect(unselected).ToHaveCountAsync(1);
            await Expect(unselected.Locator(".chip-wrapper-selected")).ToHaveCountAsync(0);
        }

        private async Task ClickRequiredActionAsync(string name)
        {
            var action = _page.GetByTestId(new Regex(@"\." + Regex.Escape(name) + "$", RegexOptions.IgnoreCase))
                .And(_page.Locator("button:visible"));
            await Expect(action).ToHaveCountAsync(1);
            await Expect(action).ToBeEnabledAsync();
            await action.ClickAsync();
            await WaitForSpinnerAsync();
        }

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
