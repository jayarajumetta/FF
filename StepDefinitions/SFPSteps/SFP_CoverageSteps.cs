using Microsoft.Playwright;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Reqnroll;
using System;
using System.Threading.Tasks;
using ReqContext = Playwright_POC.Context.TestContext;

namespace Playwright_POC.StepDefinitions.SFPSteps
{
    /// <summary>
    /// Steps for SFP Coverage selections - Equipment Breakdown, Scheduled Personal Property, Liability, Division Coverages
    /// </summary>
    [Binding]
    public class SFP_CoverageSteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_CoverageSteps(ReqContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
        }

        [When("user selects Policy Wide or Division Specific Coverages and continues")]
        public async Task UserselectsPolicyWideDivisionSpecificCoveragesAndContinues(Table table)
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.ApplySelectionsAndAddCoveragesAsync(table);
            await coverageCatalogPage.ClickNextAsync();
        }

        [When("user skips Policy Wide and Division Specific Coverages and continues")]
        public async Task UserSkipsPolicyWideDivisionSpecificCoveragesAndContinues()
        {
            var coverageCatalogPage = new PolicyWideDivisionSpecificCoveragePage(_context.Page);
            await coverageCatalogPage.WaitForSpinnerAsync();
            Console.WriteLine("No policy-wide or division-specific coverages selected - continuing to next page");
            await coverageCatalogPage.ClickNextAsync();
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
                    case "powergeneration":
                        await (value ? equipmentPage.PowerGenerationYesButton : equipmentPage.PowerGenerationNoButton).ClickAsync();
                        break;
                    case "twoormoreloss":
                        await (value ? equipmentPage.TwoOrMoreLossIn24MonthYesButton : equipmentPage.TwoOrMoreLossIn24MonthNoButton).ClickAsync();
                        break;
                    case "lossgreaterthan24k":
                        await (value ? equipmentPage.LossGreaterThan24KEverYesButton : equipmentPage.LossGreaterThan24KEverNoButton).ClickAsync();
                        break;
                    case "farmimplement":
                        await (value ? equipmentPage.FarmImplementYesButton : equipmentPage.FarmImplementNoButton).ClickAsync();
                        break;
                }
            }

            await equipmentPage.ClickNextAsync();
        }

        [When("user adds Scheduled Personal Property")]
        public async Task UserAddsScheduledPersonalProperty(Table table)
        {
            TableMappingHelpers.ScheduledPersonalPropertyFields(table, _contextData);

            var sppPage = new SFP_ScheduledPersonalPropertyPage(_context.Page);

            // Filter if category specified
            if (!string.IsNullOrEmpty(_contextData.SPPCategory))
            {
                await sppPage.FilterInput.FillAsync(_contextData.SPPCategory);
                await _context.Page.WaitForTimeoutAsync(500);
            }

            // TODO: Add logic to select coverage checkbox by category name
            // For now, navigate to next step
            Console.WriteLine($"STUB: Select SPP category '{_contextData.SPPCategory}' with value '{_contextData.SPPValue}'");
            
            await sppPage.NextLiabilityButton.ClickAsync();
        }

        [When("user adds Liability coverage")]
        public async Task UserAddsLiabilityCoverage(Table table)
        {
            TableMappingHelpers.LiabilityFields(table, _contextData);

            var liabilityPage = new SFP_LiabilityPage(_context.Page);

            // Enter livestock counts if provided
            if (!string.IsNullOrEmpty(_contextData.LivestockHorses))
                await liabilityPage.LivestockHorsesInput.FillAsync(_contextData.LivestockHorses);
            if (!string.IsNullOrEmpty(_contextData.LivestockSmall))
                await liabilityPage.LivestockSmallInput.FillAsync(_contextData.LivestockSmall);
            if (!string.IsNullOrEmpty(_contextData.LivestockLarge))
                await liabilityPage.LivestockLargeInput.FillAsync(_contextData.LivestockLarge);
            if (!string.IsNullOrEmpty(_contextData.NumberOfEmployees))
                await liabilityPage.NumberOfEmployeesInput.FillAsync(_contextData.NumberOfEmployees);
            if (!string.IsNullOrEmpty(_contextData.UnlistedAcreage))
                await liabilityPage.UnlistedAcreageInput.FillAsync(_contextData.UnlistedAcreage);

            // Select liability limit if provided
            if (!string.IsNullOrEmpty(_contextData.LiabilityLimit))
            {
                await liabilityPage.LimitSelect.ClickAsync();
                await _context.Page.GetByRole(AriaRole.Option, new() { Name = _contextData.LiabilityLimit }).ClickAsync();
            }

            await liabilityPage.ClickSaveAsync();
        }
    }
}
