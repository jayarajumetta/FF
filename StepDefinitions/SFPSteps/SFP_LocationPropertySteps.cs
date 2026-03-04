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
    [Binding]
    public class SFP_LocationPropertySteps
    {
        private readonly ReqContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_LocationPropertySteps(ReqContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData;
        }

        [When("user provides location information and continues")]
        public async Task UserProvidesLocationInformationAndContinues(Table table)
        {
            TableMappingHelpers.LocationInformationFields(table, _contextData);

            var locationPage = new LocationPage(_context.Page, _contextData);
            await locationPage.EnterLocationInformationAsync();
            await locationPage.SelectWindHailDeductibleAsync(_contextData.WindHailDeductible);
            await locationPage.ClickSaveAsync();
        }

        [When("user adds a Residence to the Location")]
        public async Task UserAddsResidenceToLocation(Table table)
        {
            TableMappingHelpers.ResidenceFields(table, _contextData);

            // TODO: Implement residence creation via Add Residence button + form
            Console.WriteLine($"STUB: Add Residence - Description: {_contextData.ResidenceAdditionalDesc}, Year: {_contextData.ResidenceYearBuilt}");

            // Navigate to Locations/Buildings list so downstream steps can continue
            var nav = new SideMenuNavigation(_context.Page);
            await nav.GoToLocationsBuildingsAsync();

            // Click Next to advance past Locations page
            var locPage = new SFP_LocationsResidencesBuildingsPage(_context.Page);
            await locPage.WaitForSpinnerAsync();
            await locPage.ClickNextAsync();
        }

        [When("user adds Residence Coverage")]
        public async Task UserAddsResidenceCoverage(Table table)
        {
            TableMappingHelpers.ResidenceCoverageFields(table, _contextData);

            // TODO: Implement residence coverage entry
            Console.WriteLine($"STUB: Residence Coverage - Amount: {_contextData.ResidenceInsuranceAmount}, Perils: {_contextData.ResidencePerils}");

            // We should now be on Optional Coverages — click Next to advance
            var optCov = new SFP_OptionalCoveragesPage(_context.Page);
            await optCov.WaitForSpinnerAsync();
            await optCov.ClickNextAsync();
        }

        [When("user adds Farm Personal Property")]
        public async Task UserAddsFarmPersonalProperty(Table table)
        {
            TableMappingHelpers.FarmPersonalPropertyFields(table, _contextData);

            // TODO: Implement FPP coverage selection
            Console.WriteLine($"STUB: Farm Personal Property - Code: {_contextData.FarmPropertyCode}, Limit: {_contextData.FarmPropertyLimit}");

            // We should now be on Farm Personal Property page — click Next to advance to Equipment Breakdown
            var fppPage = new SFP_FarmPersonalPropertyPage(_context.Page);
            await fppPage.WaitForSpinnerAsync();
            await fppPage.NextButton.ClickAsync();
            await fppPage.WaitForSpinnerAsync();
        }
    }
}
