using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.StepDefinitions.SFPSteps
{
    [Binding]
    public class SFP_RatePolicySteps
    {
        private readonly PlaywrightContext _context;
        private readonly ScenarioContextData _data;
        private readonly IConfiguration _configuration;
        private readonly HashSet<string> _buildingDescriptions = new(StringComparer.OrdinalIgnoreCase);
        private SFP_LiabilityOptionalCoveragePage _liabilityPage;

        public SFP_RatePolicySteps(PlaywrightContext context, ScenarioContextData data, IConfiguration configuration)
        {
            _context = context;
            _data = data;
            _configuration = configuration;
        }

        [BeforeScenario("RatePolicy", Order = -100)]
        public void RequireNonProductionEnvironment()
        {
            var environment = _configuration["Environment"]?.ToUpperInvariant();
            var key = environment switch
            {
                "DEV" => "Playwright:ExpertQuoteDev",
                "QA" => "Playwright:ExpertQuote",
                _ => throw new InvalidOperationException("Rate Policy quote creation requires an explicit non-production DEV or QA environment.")
            };
            if (!Uri.TryCreate(_configuration[key], UriKind.Absolute, out var endpoint)
                || endpoint.Scheme != Uri.UriSchemeHttps
                || !endpoint.Host.Contains($"-{environment.ToLowerInvariant()}.", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Rate Policy requires the configured non-production {environment} ExpertQuote endpoint.");
        }

        [When("user adds Residence Coverage and stays on the property")]
        public async Task UserAddsResidenceCoverageAndStays(Table table)
        {
            SfpRequiredTable.Read(table, SfpRatePolicyInputs.ResidenceCoverageFields);
            TableMappingHelpers.ResidenceCoverageFields(table, _data);
            await new SFP_ResidenceCoveragePage(_context.Page).FillRatePolicyResidenceCoverageAsync(_data);
        }

        [When("user adds Residence Contents and saves the property")]
        public async Task UserAddsResidenceContentsAndSaves(Table table)
        {
            var values = SfpRequiredTable.Read(table, SfpRatePolicyInputs.ResidenceContentsFields);
            await new SFP_AddResidencePage(_context.Page).AddRatePolicyContentsAndSaveAsync(_data, values);
        }

        [When("user adds a building with coverage and contents")]
        public async Task UserAddsBuildingWithCoverageAndContents(Table table)
        {
            var values = SfpRequiredTable.Read(table, SfpRatePolicyInputs.BuildingFields);
            if (!_buildingDescriptions.Add(values["AdditionalDesc"]))
                throw new ArgumentException($"Building '{values["AdditionalDesc"]}' was already added; each table must create a distinct building.");
            await new SFP_BuildingPage(_context.Page).AddWithCoverageAndContentsAsync(values);
        }

        [When("user finishes adding locations residences and buildings")]
        public async Task UserFinishesAddingProperties()
        {
            var locations = new SFP_LocationsResidencesBuildingsPage(_context.Page);
            await locations.WaitUntilReadyAsync();
            await Expect(locations.EditResidenceButton()).ToHaveCountAsync(1);
            await Expect(locations.EditBuildingButtons).ToHaveCountAsync(2);
            await locations.NextButton.ClickAsync();
            await locations.WaitForSpinnerAsync();
            await locations.ContinuePastReviewRequiredIfPresentAsync();
        }

        [When("user adds detailed Farm Personal Property and continues")]
        public async Task UserAddsDetailedFarmPersonalProperty(Table table)
        {
            var values = SfpRequiredTable.Read(table, SfpRatePolicyInputs.MachineryFields);
            await new SFP_FarmPersonalPropertyPage(_context.Page).AddDetailedMachineryAsync(values);
        }

        [When("user adds Scheduled Personal Property item and stays")]
        public Task UserAddsScheduledPersonalPropertyItemAndStays(Table table) =>
            AddScheduledItemAsync(table, continueToLiability: false);

        [When("user adds Scheduled Personal Property item and continues")]
        public Task UserAddsScheduledPersonalPropertyItemAndContinues(Table table) =>
            AddScheduledItemAsync(table, continueToLiability: true);

        private async Task AddScheduledItemAsync(Table table, bool continueToLiability)
        {
            var values = SfpRatePolicyInputs.ScheduledProperty(table);
            var page = new SFP_ScheduledPersonalPropertyPage(_context.Page);
            await page.AddAndVerifyRatePolicyItemAsync(values);
            if (continueToLiability)
            {
                await page.NextLiabilityButton.ClickAsync();
                await page.WaitForSpinnerAsync();
            }
        }

        [When("user edits liability optional coverage and stays")]
        public async Task UserEditsLiabilityOptionalCoverageAndStays(Table table) =>
            await (_liabilityPage ??= new SFP_LiabilityOptionalCoveragePage(_context.Page))
                .EditAsync(SfpRatePolicyInputs.Liability(table));
    }
}
