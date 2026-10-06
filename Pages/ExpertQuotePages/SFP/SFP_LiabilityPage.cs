using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Models;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;

namespace PnCTestAutomation.Pages
{
    public class SFP_LiabilityPage : BasePage
    {
        public SFP_LiabilityPage(IPage page) : base(page) { }

        public async Task FillRatePolicyBaseCoverageAsync(ScenarioContextData data)
        {
            var form = new SFP_NativeFormPage(_page);
            await form.SelectChipAsync(form.Chips("LineCoverages.IsBaseLiability"), "Yes");
            foreach (var (input, value) in new[]
            {
                (LivestockHorsesInput, data.LivestockHorses), (LivestockSmallInput, data.LivestockSmall),
                (LivestockLargeInput, data.LivestockLarge), (NumberOfEmployeesInput, data.NumberOfEmployees),
                (UnlistedAcreageInput, data.UnlistedAcreage)
            })
                await form.SetControlAsync(input, value, number: true);
            await form.SelectAsync(LimitSelect, data.LiabilityLimit, moneyOption: true);
        }

        // Form Fields
        public ILocator LivestockHorsesInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockHorses.value");
        public ILocator LivestockSmallInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockSmall.value");
        public ILocator LivestockLargeInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$livestockLarge.value");
        public ILocator NumberOfEmployeesInput => _page.GetByTestId("fields.policy.line.liability.liabilityInput$numberOfEmployees.value");
        public ILocator UnlistedAcreageInput => _page.GetByTestId("fields.policy.line.liability.lineInput$unlistedAcreage.value");
        public ILocator LimitSelect => _page.GetByTestId("fields.policy.line.liability.liabilityInput$limit.value");

        public async Task SelectLimitAsync(string limit)
        {
            var expected = limit?.Trim();
            if (string.IsNullOrEmpty(expected))
                throw new ArgumentException("A liability limit is required.", nameof(limit));

            await LimitSelect.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 10000
            });

            var option = _page.GetByRole(
                AriaRole.Option,
                new() { Name = expected, Exact = true });

            for (var attempt = 1; attempt <= 2; attempt++)
            {
                await LimitSelect.ClickAsync();

                try
                {
                    await option.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 2000
                    });
                }
                catch (TimeoutException)
                {
                    var isExpanded = await LimitSelect.GetAttributeAsync("aria-expanded");
                    if (attempt == 1 && !string.Equals(isExpanded, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            "[Liability] Limit dropdown did not open; retrying once after the pending field update.");
                        await Task.Delay(100);
                        continue;
                    }

                    break;
                }

                // Native click avoids Playwright rejecting visible Material overlay options
                // whose bounding box is reported outside the viewport.
                await option.EvaluateAsync("element => element.click()");
                await WaitForSpinnerAsync();

                var selectedText = (await LimitSelect.InnerTextAsync()).Trim();
                if (selectedText.Contains(expected, StringComparison.Ordinal))
                    return;

                throw new PlaywrightException(
                    $"Liability limit selection returned without displaying '{expected}'. Current value: '{selectedText}'.");
            }

            var expanded = await LimitSelect.GetAttributeAsync("aria-expanded") ?? "<missing>";
            var availableOptions = await _page
                .GetByRole(AriaRole.Option)
                .Filter(new() { Visible = true })
                .AllTextContentsAsync();

            throw new PlaywrightException(
                $"Liability limit dropdown did not expose option '{expected}' after two state-checked clicks. " +
                $"aria-expanded={expanded}; visible options=" +
                $"{(availableOptions.Count == 0 ? "<none>" : string.Join(" | ", availableOptions))}.");
        }

        // Search/Filter
        public ILocator FilterInput => _page.GetByTestId("temp.filter");
        public ILocator CoverageTable => _page.GetByTestId("coverageTableLiability");

        // Base Liability Toggle
        public ILocator BaseLiabilityYesButton =>
            _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;
        public ILocator BaseLiabilityNoButton =>
            _page.GetByTestId("fields.policy.line.lineCoverages$isBaseLiability.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        // Coverage Checkboxes (by row index for flexibility)
        public ILocator CoverageCheckbox(int row) =>
            _page.GetByTestId($"fields.policy.line.liabilityCovCat.liabilityCovCatEntry.rows[{row}].liabilityCovCatEntryInput$selected.value");

        // Business Liability Coverages
        public ILocator AgriculturalProductsProcessingCheckbox => CoverageCheckbox(0);
        public ILocator RetailSalesFarmStandsCheckbox => CoverageCheckbox(1);
        public ILocator EquineOperationsCheckbox => CoverageCheckbox(2);
        public ILocator AnimalCareServicesForOthersCheckbox => CoverageCheckbox(3);
        public ILocator LivestockServicesCheckbox => CoverageCheckbox(4);
        public ILocator LessorsRiskCheckbox => CoverageCheckbox(5);
        public ILocator FarmingAndRanchSupplyCheckbox => CoverageCheckbox(6);
        public ILocator LimitedCustomFarmingCheckbox => CoverageCheckbox(7);
        public ILocator IncidentalBusinessPursuitsCheckbox => CoverageCheckbox(8);
        public ILocator AgritainmentCheckbox => CoverageCheckbox(9);
        public ILocator HarvestYourOwnCheckbox => CoverageCheckbox(10);
        public ILocator StorageBoatsCarsCampersCheckbox => CoverageCheckbox(11);
        public ILocator OilGasWellsOperatedByOthersCheckbox => CoverageCheckbox(12);

        // Optional Liability Coverages
        public ILocator NamedInsuredMedicalExpensesCheckbox => CoverageCheckbox(13);
        public ILocator AdditionalResidenceOwnerOccupiedCheckbox => CoverageCheckbox(14);
        public ILocator ExcessMedicalExpensesCheckbox => CoverageCheckbox(15);
        public ILocator FarmEmployeeCoverageCheckbox => CoverageCheckbox(16);
        public ILocator SnowmobileATVGolfCartOffPremiseCheckbox => CoverageCheckbox(17);
        public ILocator WatercraftCheckbox => CoverageCheckbox(18);
        public ILocator SeasonalLaborHousingCheckbox => CoverageCheckbox(19);
        public ILocator ExcessFireLegalLiabilityCheckbox => CoverageCheckbox(20);
        public ILocator ImplementsDrawnCheckbox => CoverageCheckbox(21);
        public ILocator CareCustodyControlCheckbox => CoverageCheckbox(22);
        public ILocator AdditionalInsuredsCheckbox => CoverageCheckbox(23);
        public ILocator EmployeeBenefitsLiabilityCheckbox => CoverageCheckbox(24);
        public ILocator EmploymentPracticesLiabilityCheckbox => CoverageCheckbox(25);

        // Exclusion Coverages
        public ILocator DesignatedServicesActivitiesExclusionCheckbox => CoverageCheckbox(26);
        public ILocator DesignatedAnimalsExclusionCheckbox => CoverageCheckbox(27);
        public ILocator DesignatedPremiseExclusionCheckbox => CoverageCheckbox(28);
        public ILocator DesignatedWorkExclusionCheckbox => CoverageCheckbox(29);
        public ILocator HazardsDesignatedFarmTypesExclusionCheckbox => CoverageCheckbox(30);
        public ILocator PersonalAdvertisingInjuryExclusionCheckbox => CoverageCheckbox(31);

        // Limitation Coverages
        public ILocator ContractualLiabilityLimitationCheckbox => CoverageCheckbox(32);
        public ILocator SpecificProductsExclusionCheckbox => CoverageCheckbox(33);
        public ILocator SpecificProductsPropertyDamageExclusionCheckbox => CoverageCheckbox(34);
        public ILocator DamageForMilkSpecialDeductibleCheckbox => CoverageCheckbox(35);
        public ILocator FailureToSupplyExclusionCheckbox => CoverageCheckbox(36);

        // Navigation
        public ILocator BackButton => _page.GetByTestId("fields.data.back");
        public ILocator NextMortgageeLossPayeeButton => _page.GetByTestId("fields.data.next");

        public async Task EditLimitedFarmPollutionAsync(FarmData data)
        {
            await OpenOptionalCoverageEditorAsync(data);
            await SetRequiredEditorFieldAsync(
                "OccurrenceAggregate",
                data.LimitedFarmPollutionOccurrenceAggregate,
                "occurrenceAggregateLimit",
                "occurrenceAggregate",
                "occurrenceAndAggregate");
            await SetRequiredEditorFieldAsync(
                "TotalOnsiteCapacity",
                data.LimitedFarmPollutionTotalOnsiteCapacity,
                "totalCapacityOfManureStorage",
                "totalOnsite",
                "totalCapacity");
            await SetRequiredEditorFieldAsync(
                "FurthestLocationMiles",
                data.LimitedFarmPollutionFurthestLocationMiles,
                "maximumMiles",
                "maximumNumberOfMiles");
            await SetRequiredEditorFieldAsync(
                "WasteTripsPerYear",
                data.LimitedFarmPollutionWasteTripsPerYear,
                "numberOfTrips",
                "wasteTrips");

            if (!string.Equals(
                    data.LimitedFarmPollutionAboveGroundTanks?.Trim(),
                    "Yes",
                    StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    "AboveGroundTanks must be Yes when a LimitedPollutionTank is required.",
                    nameof(data));

            await AddLimitedPollutionTankAsync();
            await SetRequiredEditorFieldAsync(
                "TankCapacity",
                data.LimitedFarmPollutionTankCapacity,
                "limitedPollutionTankInput$capacity",
                "tankCapacity");
            await SetRequiredEditorFieldAsync(
                "TankConstructionDate",
                data.LimitedFarmPollutionTankConstructionDate,
                "limitedPollutionTankInput$constructionDate",
                "tankConstructionDate",
                "constructionDate");

            if (string.Equals(
                    data.LimitedFarmPollutionEligibilityQuestions?.Trim(),
                    "None Of The Above",
                    StringComparison.OrdinalIgnoreCase))
                await SetRequiredEditorFieldAsync(
                    "EligibilityQuestions",
                    "Yes",
                    "limitedFarmPollutionLiabilityQuestionsInput$eqNoneAbove",
                    "eqNoneAbove");

            await ClickSaveAsync();
            await HandleReviewRequiredAsync(
                data.LimitedFarmPollutionExpectedReferralRule,
                CoverageTable);
        }

        public async Task ContinueAfterLimitedFarmPollutionAsync(FarmData data)
        {
            var mortgageePage = new SFP_MortgageeLossPayeePage(_page);
            var mortgageeReady = mortgageePage.AddMortgageeButton
                .Or(mortgageePage.AddMortgageeButtonByTestId)
                .First;

            await NextMortgageeLossPayeeButton.ClickAsync();
            await WaitForSpinnerAsync();
            await HandleReviewRequiredAsync(
                data.LimitedFarmPollutionExpectedReferralRule,
                mortgageeReady);

            await mortgageeReady.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 30000
            });
        }

        public async Task VerifyLimitedFarmPollutionUnavailableAsync(FarmData data)
        {
            await CoverageTable.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 30000
            });

            var row = await FindCoverageRowAsync(data, required: false);
            if (row == null)
            {
                Console.WriteLine($"[Liability] Source-inapplicable coverage {CoverageIdentity(data)} is absent.");
                return;
            }

            var action = row.GetByRole(AriaRole.Button, new()
            {
                NameRegex = new Regex("add coverage|edit coverage", RegexOptions.IgnoreCase)
            }).First;
            if (await action.CountAsync() > 0 && await action.IsVisibleAsync())
                throw new PlaywrightException(
                    $"Coverage {CoverageIdentity(data)} is source-inapplicable for this scenario, " +
                    "but the deployed runtime returned an actionable editor.");

            Console.WriteLine(
                $"[Liability] Runtime exposed source-inapplicable coverage {CoverageIdentity(data)} without an actionable editor; left unselected.");
        }

        private async Task OpenOptionalCoverageEditorAsync(FarmData data)
        {
            var row = await FindCoverageRowAsync(data, required: true);
            var checkbox = row.Locator(
                "label[data-testid$='selected.value'], input[type='checkbox'][data-testid$='selected.value']").First;
            if (await checkbox.CountAsync() == 0)
                throw new PlaywrightException($"Coverage {CoverageIdentity(data)} has no selectable checkbox.");

            var tagName = await checkbox.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            if (tagName == "input")
                await checkbox.CheckAsync();
            else
                await checkbox.ClickAsync();
            await WaitForSpinnerAsync();

            var editButton = await FindCoverageActionAsync(data);
            if (editButton == null)
                throw new PlaywrightException(
                    $"Coverage {CoverageIdentity(data)} was selected, but its Add/Edit Coverage action was not found.");

            await editButton.ClickAsync();
            await WaitForSpinnerAsync();

            await _page.Locator("#page-LimitedFarmPollutionLiability")
                .Or(_page.GetByTestId("fields.data.save"))
                .First
                .WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 30000
                });
        }

        private async Task<ILocator> FindCoverageRowAsync(FarmData data, bool required)
        {
            var coverageCode = data.LimitedFarmPollutionCoverageCode?.Trim();
            var coverageName = data.LimitedFarmPollutionCoverageName?.Trim();
            if (string.IsNullOrWhiteSpace(coverageCode) || string.IsNullOrWhiteSpace(coverageName))
                throw new ArgumentException("CoverageCode and CoverageName are required.", nameof(data));

            foreach (var rows in new[]
            {
                CoverageTable.Locator("tr"),
                CoverageTable.Locator("[role='row']")
            })
            {
                var count = await rows.CountAsync();
                for (var index = 0; index < count; index++)
                {
                    var row = rows.Nth(index);
                    if (!await row.IsVisibleAsync())
                        continue;

                    var text = await row.InnerTextAsync();
                    if (text.Contains(coverageName, StringComparison.OrdinalIgnoreCase) &&
                        Regex.IsMatch(text, $@"(^|\D){Regex.Escape(coverageCode)}(\D|$)"))
                        return row;
                }
            }

            if (required)
                throw new PlaywrightException(
                    $"Required liability coverage row {CoverageIdentity(data)} was not found.");

            return null;
        }

        private async Task<ILocator> FindCoverageActionAsync(FarmData data)
        {
            var coverageName = data.LimitedFarmPollutionCoverageName.Trim();
            foreach (var rows in new[] { _page.Locator("tr"), _page.Locator("[role='row']") })
            {
                var count = await rows.CountAsync();
                for (var index = 0; index < count; index++)
                {
                    var row = rows.Nth(index);
                    if (!await row.IsVisibleAsync())
                        continue;

                    var text = await row.InnerTextAsync();
                    if (!text.Contains(coverageName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    foreach (var action in new[]
                    {
                        row.GetByRole(AriaRole.Button, new()
                        {
                            NameRegex = new Regex(@"\b(add|edit)\b", RegexOptions.IgnoreCase)
                        }).First,
                        row.GetByRole(AriaRole.Link, new()
                        {
                            NameRegex = new Regex(@"\b(add|edit)\b", RegexOptions.IgnoreCase)
                        }).First
                    })
                    {
                        if (await action.CountAsync() > 0 && await action.IsVisibleAsync())
                            return action;
                    }
                }
            }

            return null;
        }

        private async Task AddLimitedPollutionTankAsync()
        {
            var editor = _page.Locator("#page-LimitedFarmPollutionLiability");
            var root = await editor.CountAsync() > 0 ? editor : _page.Locator("body");
            var buttons = root.GetByRole(AriaRole.Button).Filter(new() { Visible = true });
            var addButtons = new List<ILocator>();
            ILocator tankButton = null;
            var count = await buttons.CountAsync();
            for (var index = 0; index < count; index++)
            {
                var button = buttons.Nth(index);
                var metadata = string.Join(" ", new[]
                {
                    await button.InnerTextAsync(),
                    await button.GetAttributeAsync("aria-label"),
                    await button.GetAttributeAsync("data-testid")
                }.Where(value => !string.IsNullOrWhiteSpace(value)));

                var isTankAction =
                    metadata.Contains("tank", StringComparison.OrdinalIgnoreCase) ||
                    metadata.Contains("scheduled above ground", StringComparison.OrdinalIgnoreCase);
                var isAddAction = Regex.IsMatch(metadata, @"\badd\b", RegexOptions.IgnoreCase) ||
                                  metadata.TrimStart().StartsWith("+", StringComparison.Ordinal);
                if (!isTankAction && !isAddAction)
                    continue;

                addButtons.Add(button);
                if (isTankAction)
                {
                    tankButton = button;
                    break;
                }
            }

            tankButton ??= addButtons.Count == 1 ? addButtons[0] : null;
            if (tankButton == null)
                throw new PlaywrightException(
                    "Limited Farm Pollution requested an above-ground tank, but the editor exposed no Add Tank action.");

            await tankButton.ClickAsync();
            await WaitForSpinnerAsync();
        }

        private async Task HandleReviewRequiredAsync(string expectedRule, ILocator destination)
        {
            var dialog = _page.Locator("[role='dialog']")
                .Filter(new() { HasText = "Review Required" })
                .First;
            var hardStop = _page.Locator("[role='dialog']")
                .Filter(new() { HasText = "Ineligible Quote" })
                .First;

            await dialog.Or(hardStop).Or(destination).First.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 30000
            });

            if (await hardStop.IsVisibleAsync())
                throw new PlaywrightException(
                    $"Pollution data unexpectedly produced an Ineligible Quote while expecting referral rule '{expectedRule}'.");

            if (await dialog.CountAsync() == 0 || !await dialog.IsVisibleAsync())
                return;

            var keepGoing = dialog.GetByTestId("btnConfirmYes").First;
            if (await keepGoing.CountAsync() == 0 || !await keepGoing.IsVisibleAsync())
                throw new PlaywrightException(
                    $"Review Required for expected rule '{expectedRule}' did not expose Keep Going.");

            await keepGoing.ClickAsync(new() { Force = true });
            await dialog.WaitForAsync(new()
            {
                State = WaitForSelectorState.Detached,
                Timeout = 30000
            });
            await WaitForSpinnerAsync();
            Console.WriteLine(
                $"[Liability] Acknowledged source-supported pollution referral rule '{expectedRule}'.");
        }

        private static string CoverageIdentity(FarmData data) =>
            $"{data.LimitedFarmPollutionCoverageCode} '{data.LimitedFarmPollutionCoverageName}'";

        private async Task SetRequiredEditorFieldAsync(string fieldName, string value, params string[] testIdTokens)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"A value is required for '{fieldName}'.", nameof(value));

            var tokens = testIdTokens
                .Where(token => !string.IsNullOrWhiteSpace(token))
                .Distinct()
                .ToArray();
            var chip = await FirstVisibleAsync(tokens.Select(token =>
                _page.Locator($"[data-testid*='{EscapeCss(token)}'][data-testid*='chip-item-wrapper']")
                    .Filter(new() { HasText = value })));
            if (chip != null)
            {
                await chip.ClickAsync();
                await WaitForSpinnerAsync();
                return;
            }

            var candidates = new List<ILocator>();
            foreach (var token in tokens)
            {
                var escaped = EscapeCss(token);
                candidates.Add(_page.Locator(
                    $"input[data-testid*='{escaped}'], textarea[data-testid*='{escaped}'], " +
                    $"select[data-testid*='{escaped}'], mat-select[data-testid*='{escaped}'], " +
                    $"[role='combobox'][data-testid*='{escaped}'], " +
                    $"input[id*='{escaped}' i], input[name*='{escaped}' i]"));
            }

            var spacedName = Regex.Replace(fieldName, "([a-z])([A-Z])", "$1 $2");
            var labelPattern = string.Join(
                @"\W*",
                spacedName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Regex.Escape));
            candidates.Add(_page.GetByLabel(new Regex(labelPattern, RegexOptions.IgnoreCase)));

            var control = await FirstVisibleAsync(candidates);
            if (control == null)
                throw new PlaywrightException(
                    $"Required Limited Farm Pollution field '{fieldName}' was not found. " +
                    $"Tokens=[{string.Join(", ", tokens)}].");

            await SetEditorControlValueAsync(control, fieldName, value);
        }

        private async Task SetEditorControlValueAsync(ILocator control, string fieldName, string value)
        {
            await control.ScrollIntoViewIfNeededAsync();
            var tagName = await control.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            var role = await control.GetAttributeAsync("role");
            var inputType = await control.GetAttributeAsync("type");

            if (tagName == "input" &&
                string.Equals(inputType, "checkbox", StringComparison.OrdinalIgnoreCase))
            {
                var shouldBeChecked =
                    value.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("True", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("1", StringComparison.OrdinalIgnoreCase);
                if (shouldBeChecked)
                    await control.CheckAsync();
                else
                    await control.UncheckAsync();
                await WaitForSpinnerAsync();
                return;
            }

            if (tagName == "select")
            {
                await control.SelectOptionAsync(new SelectOptionValue { Label = value });
                await WaitForSpinnerAsync();
                return;
            }

            if (tagName == "mat-select" || string.Equals(role, "combobox", StringComparison.OrdinalIgnoreCase))
            {
                await control.ClickAsync();
                var options = _page.GetByRole(AriaRole.Option).Filter(new() { Visible = true });
                try
                {
                    await options.First.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 10000
                    });
                }
                catch (TimeoutException ex)
                {
                    throw new PlaywrightException(
                        $"Limited Farm Pollution field '{fieldName}' did not expose options for '{value}'.", ex);
                }

                var expected = NormalizeOption(value);
                var optionCount = await options.CountAsync();
                for (var index = 0; index < optionCount; index++)
                {
                    var option = options.Nth(index);
                    if (NormalizeOption(await option.InnerTextAsync()) != expected)
                        continue;

                    await option.ClickAsync();
                    await WaitForSpinnerAsync();
                    return;
                }

                var available = await options.AllTextContentsAsync();
                throw new PlaywrightException(
                    $"Limited Farm Pollution field '{fieldName}' did not expose option '{value}'. " +
                    $"Available=[{string.Join(" | ", available)}].");
            }

            var displayValue = value;
            if (fieldName.Contains("ConstructionDate", StringComparison.OrdinalIgnoreCase) &&
                DateTime.TryParseExact(
                    value,
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var date))
                displayValue = date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            await control.ClickAsync();
            await control.FillAsync(displayValue);
            await control.PressAsync("Tab");
            await WaitForSpinnerAsync();
        }

        private static string NormalizeOption(string value) =>
            new(value.Where(char.IsLetterOrDigit).Select(char.ToUpperInvariant).ToArray());

        private static string EscapeCss(string value) =>
            value.Replace("\\", "\\\\").Replace("'", "\\'");

        private static async Task<ILocator> FirstVisibleAsync(IEnumerable<ILocator> candidates)
        {
            foreach (var candidate in candidates)
            {
                var count = await candidate.CountAsync();
                for (var index = 0; index < count; index++)
                {
                    var item = candidate.Nth(index);
                    if (await item.IsVisibleAsync())
                        return item;
                }
            }

            return null;
        }

        // Workers' Compensation - Residence Employees optional coverage (NH and similar states).
        // Clicking this button navigates to a dedicated full Edit Coverage page (not a popup).
        public ILocator WorkersCompEditCoverageButton =>
            _page.GetByTestId("fields.policy_Optional.wCResidenceEmployees.addEditWCResidenceEmployees");

        // Fields on the Edit Coverage: Workers' Compensation full page.
        // These inputs are the only four inputs on that page and appear in a fixed order.
        // Using a plain input selector because the Angular custom components do not expose
        // Spinbutton or Textbox ARIA roles.
        private ILocator WorkersCompServantInput(int index) =>
            _page.Locator("input").Nth(index);

        public ILocator WorkersCompFullTimeInInput  => WorkersCompServantInput(0);
        public ILocator WorkersCompPartTimeInInput  => WorkersCompServantInput(1);
        public ILocator WorkersCompFullTimeOutInput => WorkersCompServantInput(2);
        public ILocator WorkersCompPartTimeOutInput => WorkersCompServantInput(3);

        public ILocator WorkersCompSaveButton =>
            _page.Locator("button").Filter(new() { HasText = "Save" });

        private async Task<bool> IsWorkersCompEditorVisibleAsync()
        {
            try
            {
                await WorkersCompEditCoverageButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Hidden,
                    Timeout = 3000
                });
                await WorkersCompSaveButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 3000
                });
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks Edit Coverage for Workers' Compensation - Residence Employees (navigates to a full
        /// edit page), fills servant counts, then clicks Save to return to the Liability page.
        /// </summary>
        public async Task EditWorkersCompCoverageAsync(
            string fullTimeIn  = "1",
            string partTimeIn  = "1",
            string fullTimeOut = "0",
            string partTimeOut = "0")
        {
            // Wait for the Edit Coverage button to be rendered before clicking
            await WorkersCompEditCoverageButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await WorkersCompEditCoverageButton.ClickAsync();
            await WaitForSpinnerAsync();

            if (!await IsWorkersCompEditorVisibleAsync())
            {
                Console.WriteLine("[WorkersComp] Trusted click did not open the editor; retrying with DOM click.");
                await WorkersCompEditCoverageButton.EvaluateAsync("element => element.click()");
                await WaitForSpinnerAsync();
            }

            if (!await IsWorkersCompEditorVisibleAsync())
                throw new PlaywrightException("Workers' Compensation Edit Coverage action did not open its editor.");

            // Fill all four servant count fields on the dedicated Edit Coverage page
            await WorkersCompFullTimeInInput.FillAsync(fullTimeIn);
            await WorkersCompPartTimeInInput.FillAsync(partTimeIn);
            await WorkersCompFullTimeOutInput.FillAsync(fullTimeOut);
            await WorkersCompPartTimeOutInput.FillAsync(partTimeOut);

            await WorkersCompSaveButton.ClickAsync();
            await WaitForSpinnerAsync();

            Console.WriteLine($"[WorkersComp] Saved: FullTimeIn={fullTimeIn}, PartTimeIn={partTimeIn}, FullTimeOut={fullTimeOut}, PartTimeOut={partTimeOut}");
        }
    }
}
