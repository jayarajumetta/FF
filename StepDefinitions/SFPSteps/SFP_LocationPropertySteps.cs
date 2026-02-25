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
    /// Steps for SFP Location, Residence, Buildings, and Farm Personal Property
    /// </summary>
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

            // TODO: Implement when SFP_LocationsResidencesBuildingsPage methods are mapped
            Console.WriteLine("STUB: Add Residence to Location - page methods need implementation");
            Console.WriteLine($"  Description: {_contextData.ResidenceAdditionalDesc}");
            Console.WriteLine($"  Year Built: {_contextData.ResidenceYearBuilt}");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [When("user adds Residence Coverage")]
        public async Task UserAddsResidenceCoverage(Table table)
        {
            TableMappingHelpers.ResidenceCoverageFields(table, _contextData);

            // TODO: Implement when SFP_LocationsResidencesBuildingsPage methods are mapped
            Console.WriteLine("STUB: Add Residence Coverage - page methods need implementation");
            Console.WriteLine($"  Insurance Amount: {_contextData.ResidenceInsuranceAmount}");
            Console.WriteLine($"  Perils: {_contextData.ResidencePerils}");
            await _context.Page.WaitForTimeoutAsync(500);
        }

        [When("user adds Farm Personal Property")]
        public async Task UserAddsFarmPersonalProperty(Table table)
        {
            TableMappingHelpers.FarmPersonalPropertyFields(table, _contextData);

            // TODO: Implement when SFP_FarmPersonalPropertyPage methods are mapped
            Console.WriteLine("STUB: Add Farm Personal Property - page methods need implementation");
            Console.WriteLine($"  Code: {_contextData.FarmPropertyCode}");
            Console.WriteLine($"  Limit: {_contextData.FarmPropertyLimit}");
            await _context.Page.WaitForTimeoutAsync(500);
        }
    }
}
