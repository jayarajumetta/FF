using Microsoft.Playwright;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    [Binding]
    public class SFP_LocationPropertySteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _contextData;
        private readonly ScenarioContext _scenarioContext;

        public SFP_LocationPropertySteps(PlaywrightContext context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
            _contextData = _scenarioContext["ContextData"] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it.");
        }

        [When("user provides location information and continues")]
        public async Task UserProvidesLocationInformationAndContinues(Table table)
        {
            TableMappingHelpers.LocationInformationFields(table, _contextData);

            var locationPage = new LocationPage(_context.Page, _contextData);
            await locationPage.EnterLocationInformationAsync();
            await locationPage.OrderWildfireRiskScoreIfAvailableAsync();

            // Wind/Hail deductible is not available in ID, MS, NH, OR, UT, WA
            // Don't expect a value for these states - validation will confirm field is absent
            var statesWithoutWindHail = new[] { "Idaho", "Mississippi", "New Hampshire", "Oregon", "Utah", "Washington" };
            var windHailDeductible = statesWithoutWindHail.Contains(_contextData.State)
                ? null
                : _contextData.WindHailDeductible;

            await locationPage.VerifyWindHailDeductibleOptionsAsync(_contextData.ZipCode, windHailDeductible);
            await locationPage.SelectWindHailDeductibleAsync(windHailDeductible, _contextData.ZipCode);
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
            await locPage.AddResidenceButton().ClickAsync();
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

            // Resolve row index dynamically by scanning DOM text — avoids positional index
            // assumptions that break when states omit certain coverage categories
            var rowIndex = await fppPage.FindRowByCodeAsync(_contextData.FarmPropertyCode, _contextData.FarmPropertyDescription);

            if (rowIndex < 0)
            {
                Console.WriteLine($"WARNING: FPP code '{_contextData.FarmPropertyCode}' not mapped - skipping");
                return;
            }

            var checkbox = fppPage.CoverageCheckbox(rowIndex);
            if (await checkbox.CountAsync() == 0 || !await checkbox.IsVisibleAsync())
            {
                Console.WriteLine($"WARNING: FPP coverage checkbox row {rowIndex} (code '{_contextData.FarmPropertyCode}') not visible for this state - skipping FPP");
                await fppPage.ClickNextAsync();
                await fppPage.WaitForSpinnerAsync();
                return;
            }

            await checkbox.ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            // Click Add Coverage using dynamic locator
            await fppPage.ClickAddCoverageButtonAsync();
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

            await fppPage.ClickNextAsync();
            await fppPage.WaitForSpinnerAsync();

            Console.WriteLine($"Selected FPP coverage code '{_contextData.FarmPropertyCode}'");
        }
    }
}
