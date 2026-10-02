using Microsoft.Playwright;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
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
            _contextData = scenarioContext[ScenarioContextData.ContextKey] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
        }

        internal SFP_CoverageSteps(PlaywrightContext context, ScenarioContextData contextData)
        {
            _context = context;
            _contextData = contextData;
            _scenarioContext = null;
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

        [When("user adds and verifies Country Estate Scheduled Personal Property")]
        public async Task UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(Table table)
        {
            if (_contextData.ProductSelection != "CE")
                throw new ArgumentException("Country Estate scheduled property requires CE product context.");
            var items = TableMappingHelpers.CountryEstateScheduledPropertyFields(table, _contextData);
            var page = new SFP_ScheduledPersonalPropertyPage(_context.Page);
            await page.WaitForSpinnerAsync();
            var nav = _context.Page.Locator("[data-testid='ScheduledPersonalProperty-nav'], #ScheduledPersonalProperty-nav");
            await Microsoft.Playwright.Assertions.Expect(nav).ToHaveCountAsync(1);
            await nav.ClickAsync();
            foreach (var item in items)
                await page.AddAndVerifyCountryEstateItemAsync(item);
        }

        [When("user adds Scheduled Personal Property")]
        public async Task UserAddsScheduledPersonalProperty(Table table)
        {
            TableMappingHelpers.ScheduledPersonalPropertyFields(table, _contextData);

            var sppPage = new SFP_ScheduledPersonalPropertyPage(_context.Page);
            await sppPage.WaitForSpinnerAsync();
            var sideNav = new SideMenuNavigation(_context.Page);
            await sideNav.GoToScheduledPersonalPropertyAsync();

            // Resolve row index — dynamic DOM scan first (state-safe), then name heuristic
            var rowIndex = await sppPage.FindRowByCodeAsync(_contextData.SPPCategory);
            if (rowIndex < 0)
                rowIndex = sppPage.GetCategoryRowIndex(_contextData.SPPCategory);

            if (rowIndex < 0)
            {
                throw new PlaywrightException(
                    $"Required SPP category '{_contextData.SPPCategory}' was not found. The scheduled item cannot be skipped.");
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
        public Task UserAddsLiabilityCoverage(Table table) => AddLiabilityCoverageAsync(table, continueToMortgagee: true);

        [When("user adds Liability coverage and stays")]
        public Task UserAddsLiabilityCoverageAndStays(Table table) => AddLiabilityCoverageAsync(table, continueToMortgagee: false);

        private async Task AddLiabilityCoverageAsync(Table table, bool continueToMortgagee)
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
                await liabilityPage.SelectLimitAsync(_contextData.LiabilityLimit);

            // Some states (e.g. NH) require filling the Workers' Compensation - Residence Employees
            // optional coverage before proceeding. The page shows "Required Info Missing" and surfaces
            // an Edit Coverage button that navigates to a full edit page (not a popup).
            // Use explicit NH check so Angular rendering delay doesn't cause IsVisibleAsync to miss it.
            var ratingState = (_contextData?.Address?.State ?? string.Empty).Trim();
            var isNH = ratingState.Equals("NH", StringComparison.OrdinalIgnoreCase)
                    || ratingState.Equals("New Hampshire", StringComparison.OrdinalIgnoreCase);
            var isWorkersCompVisible = isNH || await liabilityPage.WorkersCompEditCoverageButton.IsVisibleAsync();

            if (isWorkersCompVisible)
            {
                await liabilityPage.EditWorkersCompCoverageAsync(
                    _contextData.WorkersCompFullTimeInServants ?? "1",
                    _contextData.WorkersCompPartTimeInServants ?? "1",
                    _contextData.WorkersCompFullTimeOutServants ?? "0",
                    _contextData.WorkersCompPartTimeOutServants ?? "0");
            }

            if (continueToMortgagee)
                await liabilityPage.NextMortgageeLossPayeeButton.ClickAsync();
        }

        [When("user edits liability optional coverage and continues")]
        public async Task UserEditsLiabilityOptionalCoverageAndContinues(Table table)
        {
            TableMappingHelpers.LimitedFarmPollutionFields(table, _contextData);

            var liabilityPage = new SFP_LiabilityPage(_context.Page);
            var isApplicable = _scenarioContext?.ScenarioInfo.Tags.Any(
                tag => tag.Equals("Pollution146", StringComparison.OrdinalIgnoreCase)) == true;

            if (isApplicable)
            {
                await liabilityPage.SelectLimitAsync(
                    _contextData.Farm.LimitedFarmPollutionRequiredBaseLiabilityLimit);
                await liabilityPage.EditLimitedFarmPollutionAsync(_contextData.Farm);
                await liabilityPage.ContinueAfterLimitedFarmPollutionAsync(_contextData.Farm);
            }
            else
            {
                await liabilityPage.VerifyLimitedFarmPollutionUnavailableAsync(_contextData.Farm);
                await liabilityPage.NextMortgageeLossPayeeButton.ClickAsync();
            }
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
