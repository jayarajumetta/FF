using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpCountryEstateTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private const string CoveragePrefix = "fields.risk.rows[0].residenceCoverage.rows[0].";

        [OneTimeSetUp]
        public async Task StartBrowser()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = true });
        }

        [SetUp]
        public async Task CreateOfflinePage()
        {
            _context = await _browser.NewContextAsync();
            await _context.RouteAsync("**/*", route => route.AbortAsync());
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task ClosePage() => await _context.DisposeAsync();

        [OneTimeTearDown]
        public async Task CloseBrowser()
        {
            if (_browser != null)
                await _browser.DisposeAsync();
            _playwright?.Dispose();
        }

        [Test]
        public void ResidenceMapping_DoesNotInheritBasicYearsOrCoverage()
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("5"), data);
            Assert.Multiple(() =>
            {
                Assert.That(data.ResidenceYearBuilt, Is.EqualTo("2022"));
                Assert.That(data.ResidenceRoofYear, Is.EqualTo("2022"));
                Assert.That(data.ResidenceRoofType, Is.EqualTo("Asphalt"));
                Assert.That(data.ResidenceRoofImpact, Is.EqualTo("UL 2"));
                Assert.That(data.Farm.ResidenceHeatingYear, Is.Null);
                Assert.That(data.Farm.ResidencePlumbingYear, Is.Null);
                Assert.That(data.Farm.ResidenceElectricalYear, Is.Null);
                Assert.That(data.ResidenceInsuranceAmount, Is.EqualTo("375000"));
                Assert.That(data.ResidencePerils, Is.EqualTo("5"));
                Assert.That(data.ResidenceActualCashValue, Is.EqualTo("Expanded Replacement Cost"));
                Assert.That(DateTime.FromOADate(45772), Is.EqualTo(new DateTime(2025, 4, 25)));
                Assert.That(DateHelpers.ResolveDateToken("04/25/2025"), Is.EqualTo("04/25/2025"));
            });
        }

        [Test]
        public async Task ResidenceReadback_VerifiesCeValuesWithoutRequiringUnspecifiedRenovations()
        {
            var data = ResidenceData();
            await _page.SetContentAsync(ResidenceHtml());
            var page = new SFP_AddResidencePage(_page);
            await page.VerifyResidenceFormAsync(data);
            await page.RoofYearInput.FillAsync("2026");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceFormAsync(data));
        }

        [Test]
        public async Task ResidenceReadback_StillRequiresExplicitRenovationControls()
        {
            var data = ResidenceData();
            data.Farm.ResidenceHeatingYear = "2026";
            await _page.SetContentAsync(ResidenceHtml());
            Assert.ThrowsAsync<PlaywrightException>(() => new SFP_AddResidencePage(_page).VerifyResidenceFormAsync(data));
        }

        [TestCase("3")]
        [TestCase("5")]
        public async Task CoverageReadback_RejectsRequestedPerilsThatConflictWithDisabledCeDefault(string requested)
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable(requested), data);
            await _page.SetContentAsync(CoverageHtml());
            var page = new SFP_ResidenceCoveragePage(_page);
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceCoverageAsync(data));
            Assert.That(await page.PerilsSelect.InnerTextAsync(), Is.EqualTo("6"));
            Assert.That(await page.PerilsSelect.GetAttributeAsync("aria-disabled"), Is.EqualTo("true"));
        }

        [TestCase("375000", "Expanded Replacement Cost", true)]
        [TestCase("550000", "Expanded Replacement Cost", false)]
        [TestCase("375000", "Replacement Cost", false)]
        public async Task CoverageReadback_RequiresExactCeAmountAndSettlement(string amount, string settlement, bool valid)
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("6"), data);
            await _page.SetContentAsync(CoverageHtml(amount, settlement));
            var page = new SFP_ResidenceCoveragePage(_page);
            if (valid)
                await page.VerifyResidenceCoverageAsync(data);
            else
                Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceCoverageAsync(data));
        }

        [Test]
        public async Task CoverageReadback_RejectsMissingRequiredPerilsControl()
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("6"), data);
            await _page.SetContentAsync(CoverageHtml());
            var page = new SFP_ResidenceCoveragePage(_page);
            await page.PerilsSelect.EvaluateAsync("element => element.remove()");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceCoverageAsync(data));
        }

        private static ScenarioContextData ResidenceData()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(SfpBasicInputTests.TableOf(
                ("AdditionalDesc", "Main House"), ("YearBuilt", "2022"),
                ("NumberOfFamilies", "Single Family"), ("RateType", "Frame"), ("ConditionRating", "1"),
                ("RoofYear", "2022"), ("RoofType", "Asphalt"), ("RoofImpact", "UL 2"),
                ("SeasonalOrVacant", "No"), ("SolidFuelQuestion", "No")), data);
            return data;
        }

        private static Reqnroll.Table CoverageTable(string perils) => SfpBasicInputTests.TableOf(
            ("InsuranceAmount", "375000"), ("SquareFeet", "1800"), ("Perils", perils),
            ("ThermostatQuestion", "Yes"), ("ActualCashValue", "Expanded Replacement Cost"),
            ("RCTOption", "Standard"), ("UseDefaults", "Yes"));

        private static string ResidenceHtml() =>
            Input("additionalDescription", "Main House") + Input("yearBuilt", "2022") + Input("roofYear", "2022")
            + "<div data-testid='fields.building.rows[0].buildingInput$constructionCode.value'>Frame</div>"
            + "<div data-testid='fields.building.rows[0].buildingInput$roofType.value'>Asphalt</div>"
            + "<div data-testid='fields.building.rows[0].buildingInput$roofImpactResistance.value'>UL 2</div>"
            + Chip("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value", "Single Family")
            + Chip("fields.building.rows[0].buildingInput$rateType.value", "1")
            + Chip("fields.building.rows[0].buildingInput$eQVacantSeasonal.value", "No")
            + Chip("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value", "No");

        private static string CoverageHtml(string amount = "375000", string settlement = "Expanded Replacement Cost") =>
            $"<input data-testid='{CoveragePrefix}coverageInput$limit.value' value='{amount}'>"
            + $"<input data-testid='{CoveragePrefix}buildingInput$squareFt.value' value='1800'>"
            + $"<div data-testid='{CoveragePrefix}coverageInput$perilGroup.value' aria-disabled='true'>6</div>"
            + $"<div data-testid='{CoveragePrefix}coverageInput$replacementCost.value'>{settlement}</div>"
            + Chip(CoveragePrefix + "buildingInput$buildingThermostatQuestion.value", "Yes")
            + Chip(CoveragePrefix + "buildingValuatioinInput$estimatorType.value", "RCT")
            + Chip(CoveragePrefix + "buildingValuatioinInput$valuationType.value", "Standard");

        private static string Input(string field, string value) =>
            $"<input data-testid='fields.building.rows[0].buildingInput${field}.value' value='{value}'>";

        private static string Chip(string testId, string value) =>
            $"<div data-testid='{testId}-chip-item-wrapper'><span class='chip-wrapper-selected'>{value}</span></div>";
    }
}
