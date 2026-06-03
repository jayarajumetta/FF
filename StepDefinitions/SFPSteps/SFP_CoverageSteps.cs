using Microsoft.Playwright;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Coverage selections - Equipment Breakdown, Scheduled Personal Property, Liability, Division Coverages
    /// </summary>
    [Binding]
    public class SFP_CoverageSteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_CoverageSteps(PlaywrightContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
        }

        [When("user selects Policy Wide or Division Specific Coverages and continues")]
        public async Task UserselectsPolicyWideDivisionSpecificCoveragesAndContinues(Table table)
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.ApplySelectionsAndAddCoveragesAsync(table);
            await coverageCatalogPage.ClickNextAsync();
            await coverageCatalogPage.HandleReviewRequiredModalIfPresentAsync();
        }

        [When("user selects Policy Wide or Division Specific Coverages")]
        public async Task UserSelectsPolicyWideDivisionSpecificCoverages(Table table)
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.ApplyCoverageSelectionsAsync(table);
        }

        [When("user edits Country Estate coverage and continues")]
        public async Task UserEditsCountryEstateCoverageAndContinues(Table table)
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.EditCountryEstateCoverageAsync(table);
            await coverageCatalogPage.ClickNextAsync();
            await coverageCatalogPage.HandleReviewRequiredModalIfPresentAsync();
        }

        [When("user skips Policy Wide and Division Specific Coverages and continues")]
        public async Task UserSkipsPolicyWideDivisionSpecificCoveragesAndContinues()
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.WaitForSpinnerAsync();
            Console.WriteLine("No policy-wide or division-specific coverages selected - continuing to next page");
            await coverageCatalogPage.ClickNextAsync();
        }

        [When("user skips Optional Coverages and continues")]
        public async Task UserSkipsOptionalCoveragesAndContinues()
        {
            var optionalPage = new SFP_OptionalCoveragesPage(_context.Page);
            await optionalPage.WaitForSpinnerAsync();
            await optionalPage.NextButton.ClickAsync();
            await optionalPage.WaitForSpinnerAsync();
            Console.WriteLine("Optional Coverages page - no selections, continuing");
        }

        [When("user adds Equipment Breakdown information")]
        public async Task UserAddsEquipmentBreakdownInformation(Table table)
        {
            var states = TableMappingHelpers.MapYesNoTableToBool(table);
            var equipmentPage = new SFP_EquipmentBreakdownPage(_context.Page);

            // Click Yes/No for each question based on table values
            foreach (var kvp in states)
            {
                var fieldName = kvp.Key;
                var value = kvp.Value;

                switch (fieldName.ToLower())
                {
                    case "powergreaterthan250kw":
                    case "powergeneration":
                        {
                            var btn = value ? equipmentPage.PowerGenerationYesButton : equipmentPage.PowerGenerationNoButton;
                            if (await btn.IsVisibleAsync())
                                await btn.ClickAsync();
                            else
                                Console.WriteLine($"[EquipmentBreakdown] PowerGeneration button not visible for this state - skipping");
                            break;
                        }
                    case "twoormorelosses":
                    case "twoormoreloss":
                        {
                            var btn = value ? equipmentPage.TwoOrMoreLossIn24MonthYesButton : equipmentPage.TwoOrMoreLossIn24MonthNoButton;
                            if (await btn.IsVisibleAsync())
                                await btn.ClickAsync();
                            else
                                Console.WriteLine($"[EquipmentBreakdown] TwoOrMoreLoss button not visible for this state - skipping");
                            break;
                        }
                    case "greaterthan25000":
                    case "lossgreaterthan24k":
                        {
                            var btn = value ? equipmentPage.LossGreaterThan24KEverYesButton : equipmentPage.LossGreaterThan24KEverNoButton;
                            if (await btn.IsVisibleAsync())
                                await btn.ClickAsync();
                            else
                                Console.WriteLine($"[EquipmentBreakdown] LossGreaterThan24K button not visible for this state - skipping");
                            break;
                        }
                    case "farmimplements":
                    case "farmimplement":
                        {
                            var btn = value ? equipmentPage.FarmImplementYesButton : equipmentPage.FarmImplementNoButton;
                            if (await btn.IsVisibleAsync())
                                await btn.ClickAsync();
                            else
                                Console.WriteLine($"[EquipmentBreakdown] FarmImplement button not visible for this state - skipping");
                            break;
                        }
                }
            }

            await equipmentPage.ClickNextAsync();
        }

        [When("user adds Scheduled Personal Property")]
        public async Task UserAddsScheduledPersonalProperty(Table table)
        {
            TableMappingHelpers.ScheduledPersonalPropertyFields(table, _contextData);

            var sppPage = new SFP_ScheduledPersonalPropertyPage(_context.Page);
            await sppPage.WaitForSpinnerAsync();

            // Resolve row index — dynamic DOM scan first (state-safe), then name heuristic
            var rowIndex = await sppPage.FindRowByCodeAsync(_contextData.SPPCategory);
            if (rowIndex < 0)
                rowIndex = sppPage.GetCategoryRowIndex(_contextData.SPPCategory);

            if (rowIndex < 0)
            {
                Console.WriteLine($"WARNING: SPP category '{_contextData.SPPCategory}' not mapped - checking if Next button exists");

                // Check if the Next button exists before deciding how to proceed.
                var nextButtonCount = await sppPage.NextLiabilityButton.CountAsync();
                if (nextButtonCount > 0 && await sppPage.NextLiabilityButton.IsVisibleAsync())
                {
                    Console.WriteLine($"[SPP] Next button found - clicking to proceed to Liability");
                    await sppPage.NextLiabilityButton.ClickAsync();
                    await sppPage.WaitForSpinnerAsync();
                }
                else
                {
                    Console.WriteLine($"[SPP] Next button not found - SPP page may not be available in current flow. Continuing to next step.");
                }
                return;
            }

            var checkboxSelected = await sppPage.TrySelectCoverageCheckboxAsync(rowIndex);
            if (!checkboxSelected)
            {
                throw new PlaywrightException(
                    $"SPP category '{_contextData.SPPCategory}' resolved to row {rowIndex}, but no selectable checkbox was found on the page.");
            }
            await sppPage.WaitForSpinnerAsync();

            await sppPage.ClickAddCoverageButtonAsync();
            await sppPage.WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(_contextData.SPPDescription))
            {
                await sppPage.ItemDescription().ClickAsync();
                await sppPage.ItemDescription().FillAsync(_contextData.SPPDescription);
                await sppPage.ItemDescription().PressAsync("Tab");
            }

            if (!string.IsNullOrEmpty(_contextData.SPPLimit))
            {
                await sppPage.ItemLimit().ClickAsync();
                await sppPage.ItemLimit().FillAsync(_contextData.SPPLimit);
                await sppPage.ItemLimit().PressAsync("Tab");
            }

            if (!string.IsNullOrEmpty(_contextData.SPPYearOfAppraisal))
            {
                await sppPage.ItemYearOfAppraisal().ClickAsync();
                await sppPage.ItemYearOfAppraisal().FillAsync(_contextData.SPPYearOfAppraisal);
                await sppPage.ItemYearOfAppraisal().PressAsync("Tab");
            }

            await sppPage.SaveItemButton.ClickAsync();
            await sppPage.WaitForSpinnerAsync();

            await sppPage.NextLiabilityButton.ClickAsync();

            Console.WriteLine($"Selected SPP category '{_contextData.SPPCategory}', item '{_contextData.SPPDescription}'");
        }

        [When("user adds Liability coverage")]
        public async Task UserAddsLiabilityCoverage(Table table)
        {
            TableMappingHelpers.LiabilityFields(table, _contextData);

            var liabilityPage = new SFP_LiabilityPage(_context.Page);
            await liabilityPage.WaitForSpinnerAsync();

            // Select Yes to enable liability coverage and reveal remaining fields
            await liabilityPage.BaseLiabilityYesButton.ClickAsync();
            await liabilityPage.WaitForSpinnerAsync();

            // Enter livestock counts and employee/acreage fields.
            // These are Angular masked inputs (type="search" with ng-mask). FillAsync bypasses
            // the mask directive, so we use TripleClick + PressSequentiallyAsync to type
            // character-by-character and properly trigger Angular change detection.
            if (!string.IsNullOrEmpty(_contextData.LivestockHorses))
                await FillMaskedInputAsync(liabilityPage.LivestockHorsesInput, _contextData.LivestockHorses);
            if (!string.IsNullOrEmpty(_contextData.LivestockSmall))
                await FillMaskedInputAsync(liabilityPage.LivestockSmallInput, _contextData.LivestockSmall);
            if (!string.IsNullOrEmpty(_contextData.LivestockLarge))
                await FillMaskedInputAsync(liabilityPage.LivestockLargeInput, _contextData.LivestockLarge);
            if (!string.IsNullOrEmpty(_contextData.NumberOfEmployees))
                await FillMaskedInputAsync(liabilityPage.NumberOfEmployeesInput, _contextData.NumberOfEmployees);
            if (!string.IsNullOrEmpty(_contextData.UnlistedAcreage))
                await FillMaskedInputAsync(liabilityPage.UnlistedAcreageInput, _contextData.UnlistedAcreage);

            // Select liability limit if provided
            if (!string.IsNullOrEmpty(_contextData.LiabilityLimit))
            {
                await liabilityPage.LimitSelect.ClickAsync();
                await _context.Page.GetByRole(AriaRole.Option, new() { Name = _contextData.LiabilityLimit }).ClickAsync();
            }

            await liabilityPage.NextMortgageeLossPayeeButton.ClickAsync();
        }

        /// <summary>
        /// Properly fills an Angular masked numeric input by clicking to focus,
        /// selecting all existing content, then typing character-by-character
        /// to trigger Angular's mask directive and change detection correctly.
        /// </summary>
        private static async Task FillMaskedInputAsync(ILocator locator, string value)
        {
            await locator.ClickAsync();
            await locator.PressAsync("Control+A");
            await locator.PressSequentiallyAsync(value);
            await locator.PressAsync("Tab");
        }
    }
}
