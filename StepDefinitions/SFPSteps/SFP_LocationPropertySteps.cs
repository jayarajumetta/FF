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
        public SFP_LocationPropertySteps(PlaywrightContext context, ScenarioContext scenarioContext)
            : this(context, scenarioContext[ScenarioContextData.ContextKey] as ScenarioContextData
                ?? throw new InvalidOperationException("ScenarioContextData not found. Ensure TestHooks.BeforeTestRun registered it."))
        {
        }

        internal SFP_LocationPropertySteps(PlaywrightContext context, ScenarioContextData contextData)
        {
            _context = context;
            _contextData = contextData;
        }

        [When("user provides location information and continues")]
        public async Task UserProvidesLocationInformationAndContinues(Table table)
        {
            TableMappingHelpers.LocationInformationFields(table, _contextData);

            var locationPage = new LocationPage(_context.Page, _contextData);
            await locationPage.EnterLocationInformationAsync();
            await locationPage.OrderWildfireRiskScoreIfAvailableAsync();

            var hasSourceBackedCoverageInputs =
                !string.IsNullOrWhiteSpace(_contextData.AllPerilDeductible);
            if (hasSourceBackedCoverageInputs)
                await locationPage.ConfigureSourceBackedCoverageAsync();

            await locationPage.VerifyWindHailDeductibleOptionsAsync(
                _contextData.ZipCode,
                _contextData.WindHailDeductible);
            await locationPage.SelectWindHailDeductibleAsync(
                _contextData.WindHailDeductible,
                _contextData.ZipCode,
                selectExactRequestedValue: hasSourceBackedCoverageInputs);

            if (hasSourceBackedCoverageInputs)
                await locationPage.ConfigureHurricaneDeductibleAsync();

            var editLocationPage = new SFP_EditLocationPage(_context.Page);
            if (await editLocationPage.IsCurrentAsync())
                await editLocationPage.SaveLocationAsync();
            else
                await locationPage.ClickSaveAsync();
        }

        [When("user adds a Residence to the Location")]
        public Task UserAddsResidenceToLocation(Table table) => AddResidenceAsync(table, verify: false);

        [When("user adds and verifies a Basic Residence to the Location")]
        public Task UserAddsAndVerifiesBasicResidenceToLocation(Table table) => AddResidenceAsync(table, verify: true);

        [When("user adds a Country Estate Residence to the Location")]
        public Task UserAddsCountryEstateResidenceToLocation(Table table)
        {
            foreach (var row in table.Rows)
                if (row["Question"].Trim() == "SeasonalOrVacant")
                    throw new ArgumentException("SeasonalOrVacant is not applicable or readable in the Country Estate residence editor.");

            return AddResidenceAsync(table, verify: false);
        }

        private async Task AddResidenceAsync(Table table, bool verify)
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
            if (verify)
                await residencePage.VerifyResidenceFormAsync(_contextData);

            // Select Residence Coverage checkbox — coverage detail section expands inline
            await residencePage.ResidenceCoverageCheckbox.ClickAsync();
            await residencePage.WaitForSpinnerAsync();

            // NOTE: Do NOT click Save here — coverage detail fields must be filled first (UserAddsResidenceCoverage step)
            Console.WriteLine($"Added Residence: {_contextData.ResidenceAdditionalDesc}, Year: {_contextData.ResidenceYearBuilt}");
        }

        [When("user adds Residence Coverage")]
        public Task UserAddsResidenceCoverage(Table table) => AddResidenceCoverageAsync(table, verify: false);

        [When("user adds and verifies Basic Residence Coverage")]
        public Task UserAddsAndVerifiesBasicResidenceCoverage(Table table) => AddResidenceCoverageAsync(table, verify: true);

        [When("user adds and verifies Country Estate Residence Coverage")]
        public Task UserAddsAndVerifiesCountryEstateResidenceCoverage(Table table) =>
            AddResidenceCoverageAsync(table, verify: true, countryEstate: true);

        private async Task AddResidenceCoverageAsync(Table table, bool verify, bool countryEstate = false)
        {
            if (countryEstate && _contextData.ResidenceSeasonalOrVacant != null)
                throw new ArgumentException("Country Estate cannot verify a supplied SeasonalOrVacant value.");

            TableMappingHelpers.ResidenceCoverageFields(table, _contextData);

            var residenceCovPage = new SFP_ResidenceCoveragePage(_context.Page);
            if (countryEstate)
                await residenceCovPage.FillCountryEstateResidenceCoverageAsync(_contextData);
            else
                await residenceCovPage.FillResidenceCoverageAsync(_contextData);
            await residenceCovPage.WaitForSpinnerAsync();
            if (verify)
            {
                if (countryEstate)
                    await residenceCovPage.VerifyCountryEstateResidenceCoverageAsync(_contextData);
                else
                    await residenceCovPage.VerifyResidenceCoverageAsync(_contextData);
                if (countryEstate)
                    await new SFP_AddResidencePage(_context.Page).VerifyCountryEstateResidenceFormAsync(_contextData);
                else
                    await new SFP_AddResidencePage(_context.Page).VerifyResidenceFormAsync(_contextData);
            }
            await residenceCovPage.ClickSaveAsync();

            var locationsPage = new SFP_LocationsResidencesBuildingsPage(_context.Page);
            if (verify)
            {
                await locationsPage.OpenResidenceAsync();
                if (countryEstate)
                    await new SFP_AddResidencePage(_context.Page).VerifyCountryEstateResidenceFormAsync(_contextData);
                else
                    await new SFP_AddResidencePage(_context.Page).VerifyResidenceFormAsync(_contextData);
                if (countryEstate)
                    await residenceCovPage.VerifyCountryEstateResidenceCoverageAsync(_contextData);
                else
                    await residenceCovPage.VerifyResidenceCoverageAsync(_contextData);
                await locationsPage.LocationsNavigation.ClickAsync();
                await locationsPage.WaitForSpinnerAsync();
            }
            await locationsPage.NextButton.ClickAsync();
            await locationsPage.WaitForSpinnerAsync();

            Console.WriteLine($"Residence Coverage: Amount={_contextData.ResidenceInsuranceAmount}, Perils={_contextData.ResidencePerils}");
        }

        [When("user adds Farm Personal Property")]
        public Task UserAddsFarmPersonalProperty(Table table) => AddFarmPersonalPropertyAsync(table, verify: false);

        [When("user adds and verifies Basic Farm Personal Property")]
        public Task UserAddsAndVerifiesBasicFarmPersonalProperty(Table table) => AddFarmPersonalPropertyAsync(table, verify: true);

        private async Task AddFarmPersonalPropertyAsync(Table table, bool verify)
        {
            TableMappingHelpers.FarmPersonalPropertyFields(table, _contextData);

            var fppPage = new SFP_FarmPersonalPropertyPage(_context.Page);
            await fppPage.WaitForSpinnerAsync();

            // Resolve row index dynamically by scanning DOM text — avoids positional index
            // assumptions that break when states omit certain coverage categories
            var rowIndex = verify
                ? await fppPage.FindRequiredRowByCodeAsync(_contextData.FarmPropertyCode)
                : await fppPage.FindRowByCodeAsync(_contextData.FarmPropertyCode, _contextData.FarmPropertyDescription);

            if (rowIndex < 0)
            {
                if (verify)
                    throw new PlaywrightException($"Required Basic FPP coverage '{_contextData.FarmPropertyCode}' was not found.");
                Console.WriteLine($"WARNING: FPP code '{_contextData.FarmPropertyCode}' not mapped - skipping");
                return;
            }

            var checkbox = fppPage.CoverageCheckbox(rowIndex);
            if (await checkbox.CountAsync() == 0 || !await checkbox.IsVisibleAsync())
            {
                if (verify)
                    throw new PlaywrightException($"Required Basic FPP coverage '{_contextData.FarmPropertyCode}' is not selectable.");
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

            if (verify)
                await fppPage.VerifyItemAsync(_contextData);

            await fppPage.SaveItemButton.ClickAsync();
            await fppPage.WaitForSpinnerAsync();

            await fppPage.ClickNextAsync();
            await fppPage.WaitForSpinnerAsync();

            Console.WriteLine($"Selected FPP coverage code '{_contextData.FarmPropertyCode}'");
        }
    }
}
