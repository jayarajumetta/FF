using Microsoft.Playwright;
using Playwright_POC.Context;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;
using Playwright_POC.Pages.ExpertQuotePages;
using Playwright_POC.Pages.ExpertQuotePages.SFP;
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

            // Navigate back to the Locations/Residences/Buildings list page
            var navButton = _context.Page.GetByTestId("LocationsBuildings-nav");
            await navButton.ClickAsync();

            var locPage = new SFP_LocationsResidencesBuildingsPage(_context.Page);
            await locPage.WaitForSpinnerAsync();

            // Click the "Add Residence" button
            await locPage.AddResidenceButtonByRole.ClickAsync();
            await locPage.WaitForSpinnerAsync();

            // Fill residence form using page object method
            var residencePage = new SFP_AddResidencePage(_context.Page);
            await residencePage.FillResidenceFormAsync(_contextData);

            // Select Residence Coverage checkbox — coverage detail section expands inline
            await residencePage.ResidenceCoverageCheckbox.ClickAsync();
            await residencePage.WaitForSpinnerAsync();

            // NOTE: Do NOT click Save here — coverage detail fields must be filled first (UserAddsResidenceCoverage step)
            Console.WriteLine($"Added Residence: {_contextData.ResidenceAdditionalDesc}, Year: {_contextData.ResidenceYearBuilt}");
        }

        [When("user adds Residence Coverage")]
        public async Task UserAddsResidenceCoverage(Table table)
        {
            TableMappingHelpers.ResidenceCoverageFields(table, _contextData);

            var residenceCovPage = new SFP_ResidenceCoveragePage(_context.Page);
            await residenceCovPage.FillResidenceCoverageAsync(_contextData);
            await residenceCovPage.WaitForSpinnerAsync();
            await residenceCovPage.ClickSaveAsync();

            var locationsPage = new SFP_LocationsResidencesBuildingsPage(_context.Page);
            await locationsPage.NextButton.ClickAsync();
            await locationsPage.WaitForSpinnerAsync();

            Console.WriteLine($"Residence Coverage: Amount={_contextData.ResidenceInsuranceAmount}, Perils={_contextData.ResidencePerils}");
        }

        [When("user adds Farm Personal Property")]
        public async Task UserAddsFarmPersonalProperty(Table table)
        {
            TableMappingHelpers.FarmPersonalPropertyFields(table, _contextData);

            var fppPage = new SFP_FarmPersonalPropertyPage(_context.Page);
            await fppPage.WaitForSpinnerAsync();

            // Resolve row index by code first, then fall back to name-based lookup
            var rowIndex = fppPage.GetCoverageRowIndexByCode(_contextData.FarmPropertyCode);
            if (rowIndex < 0)
                rowIndex = fppPage.GetCoverageRowIndex(_contextData.FarmPropertyDescription);

            if (rowIndex < 0)
            {
                Console.WriteLine($"WARNING: FPP code '{_contextData.FarmPropertyCode}' not mapped - skipping");
                return;
            }

            await fppPage.CoverageCheckbox(rowIndex).ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            // Click Add Coverage and fill item details
            await fppPage.AddCoverageButton.ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(_contextData.FarmPropertyDescription))
                await fppPage.ItemDescription().FillAsync(_contextData.FarmPropertyDescription);

            if (!string.IsNullOrEmpty(_contextData.FarmPropertyLimit))
                await fppPage.ItemLimit().FillAsync(_contextData.FarmPropertyLimit);

            if (!string.IsNullOrEmpty(_contextData.FarmPropertyDeductible))
            {
                await fppPage.ItemDeductible().ClickAsync();
                await _context.Page.GetByRole(AriaRole.Option, new() { Name = _contextData.FarmPropertyDeductible }).ClickAsync();
            }

            await fppPage.SaveItemButton.ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            await fppPage.NextButton.ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            Console.WriteLine($"Selected FPP coverage code '{_contextData.FarmPropertyCode}'");
        }
    }
}
