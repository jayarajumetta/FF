using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;
using PnCTestAutomation.StepDefinitions.SFPSteps;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public partial class SfpCountryEstateTests
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
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("6"), data);
            Assert.Multiple(() =>
            {
                Assert.That(data.ResidenceYearBuilt, Is.EqualTo("2022"));
                Assert.That(data.ResidenceRoofYear, Is.EqualTo("2022"));
                Assert.That(data.ResidenceRoofType, Is.EqualTo("Asphalt"));
                Assert.That(data.ResidenceRoofImpact, Is.EqualTo("UL 2"));
                Assert.That(data.Farm.ResidenceHeatingYear, Is.Null);
                Assert.That(data.Farm.ResidencePlumbingYear, Is.Null);
                Assert.That(data.Farm.ResidenceElectricalYear, Is.Null);
                Assert.That(data.ResidenceSeasonalOrVacant, Is.Null);
                Assert.That(data.ResidenceInsuranceAmount, Is.EqualTo("375000"));
                Assert.That(data.ResidencePerils, Is.EqualTo("6"));
                Assert.That(data.ResidenceActualCashValue, Is.EqualTo("Expanded Replacement Cost"));
                Assert.That(data.Farm.CountryEstateHouseholdContentsAmount, Is.EqualTo("187500"));
                Assert.That(SFP_ResidenceCoveragePage.GetCountryEstateContentsPercent(data), Is.EqualTo("50%"));
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
            await page.VerifyCountryEstateResidenceFormAsync(data);
            await page.RoofYearInput.FillAsync("2026");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyCountryEstateResidenceFormAsync(data));
        }

        [TestCase("187500", "50%")]
        [TestCase("225000", "60%")]
        [TestCase("262500", "70%")]
        [TestCase("300000", "80%")]
        [TestCase("337500", "90%")]
        [TestCase("375000", "100%")]
        public void HouseholdContents_RequiresAnExactlySupportedPercentage(string amount, string percentage)
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("6"), data);
            data.Farm.CountryEstateHouseholdContentsAmount = amount;
            Assert.That(SFP_ResidenceCoveragePage.GetCountryEstateContentsPercent(data), Is.EqualTo(percentage));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("120000")]
        [TestCase("190000")]
        public void HouseholdContentsBinding_RejectsMissingOrUnsupportedAmountBeforeEntry(string amount)
        {
            var table = CoverageTable("6");
            foreach (var row in table.Rows)
                if (row["Question"] == "HouseholdContentsAmount")
                    row["Answer"] = amount;
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<ArgumentException>(() => steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(table));
        }

        [TestCase("missing before save")]
        [TestCase("missing after save")]
        [TestCase("wrong after save")]
        public async Task HouseholdContentsBinding_RequiresControlAndSavedPercentage(string failure)
        {
            await _page.SetContentAsync(BindingHtml());
            if (failure == "missing before save")
                await new SFP_ResidenceCoveragePage(_page).HouseholdContentsPercentSelect.EvaluateAsync("el => el.remove()");
            else
                await _page.EvaluateAsync(@"failure =>
                    document.querySelector('button[data-testid$=""editResidence""]').addEventListener('click', () => {
                        const field = document.querySelector('[data-testid$=""coverageInput$householdContentReplacementCost.value""]');
                        if (failure === 'missing after save') field.remove();
                        else field.textContent = '60%';
                    })", failure);
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<PlaywrightException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"),
                Is.EqualTo(failure == "missing before save" ? Array.Empty<string>() : new[] { "save", "reopen" }));
        }

        [Test]
        public void NonCeBinding_CannotSilentlyIgnoreHouseholdContentsAmount()
        {
            var data = ResidenceData();
            TableMappingHelpers.ResidenceCoverageFields(CoverageTable("6"), data);
            Assert.ThrowsAsync<ArgumentException>(() => new SFP_ResidenceCoveragePage(_page).FillResidenceCoverageAsync(data));
        }

        [Test]
        public async Task ResidenceReadback_StillRequiresExplicitRenovationControls()
        {
            var data = ResidenceData();
            data.Farm.ResidenceHeatingYear = "2026";
            await _page.SetContentAsync(ResidenceHtml());
            Assert.ThrowsAsync<PlaywrightException>(() => new SFP_AddResidencePage(_page).VerifyCountryEstateResidenceFormAsync(data));
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

        [TestCase("3")]
        [TestCase("5")]
        public async Task CountryEstateBinding_RejectsUnsupportedRequestedPerilsBeforeEntry(string requested)
        {
            await _page.SetContentAsync(CoverageHtml());
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<ArgumentException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable(requested)));
        }

        [TestCase("No")]
        [TestCase("Seasonal")]
        [TestCase("Vacant")]
        [TestCase("")]
        public void CountryEstateResidenceBinding_RejectsInapplicableTableInput(string value)
        {
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, new ScenarioContextData());
            Assert.Throws<ArgumentException>(() =>
                steps.UserAddsCountryEstateResidenceToLocation(SfpBasicInputTests.TableOf(("SeasonalOrVacant", value))));
        }

        [Test]
        public void CountryEstateCoverageBinding_RejectsSeasonalValueCarriedFromAnotherBinding()
        {
            var data = ResidenceData();
            data.ResidenceSeasonalOrVacant = "No";
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, data);
            Assert.ThrowsAsync<ArgumentException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task CountryEstateBinding_RejectsUnexpectedApplicableSeasonalControl(bool dropdown, bool afterSave)
        {
            var control = dropdown
                ? "<div data-testid='fields.building.rows[0].buildingInput$eqVacantSeasonal.value'>No</div>"
                : Chip("fields.building.rows[0].buildingInput$eQVacantSeasonal.value", "No");
            await _page.SetContentAsync(BindingHtml());
            if (afterSave)
                await _page.EvaluateAsync(@"html =>
                    document.querySelector('button[data-testid$=""editResidence""]').addEventListener('click',
                        () => document.body.insertAdjacentHTML('beforeend', html))", control);
            else
                await _page.EvaluateAsync("html => document.body.insertAdjacentHTML('beforeend', html)", control);
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<PlaywrightException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"),
                Is.EqualTo(afterSave ? new[] { "save", "reopen" } : Array.Empty<string>()));
        }

        [Test]
        public async Task CountryEstateNonApplicability_DoesNotClaimHiddenSeasonalValueIsNo()
        {
            var data = ResidenceData();
            await _page.SetContentAsync(ResidenceHtml()
                + "<div hidden data-testid='fields.building.rows[0].buildingInput$eQVacantSeasonal.value'>Seasonal</div>");
            await new SFP_AddResidencePage(_page).VerifyCountryEstateResidenceFormAsync(data);
            Assert.That(data.ResidenceSeasonalOrVacant, Is.Null);
        }

        [Test]
        public async Task NonCeResidence_StillRequiresVisibleSeasonalValue()
        {
            var data = ResidenceData();
            data.ResidenceSeasonalOrVacant = "No";
            await _page.SetContentAsync(ResidenceHtml()
                + Chip("fields.building.rows[0].buildingInput$eQVacantSeasonal.value", "No"));
            var page = new SFP_AddResidencePage(_page);
            await page.VerifyResidenceFormAsync(data);
            await page.GetVacantSeasonalButton("No").EvaluateAsync("el => el.remove()");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceFormAsync(data));
        }

        [TestCase("3")]
        [TestCase("5")]
        [TestCase("enabled")]
        [TestCase("missing")]
        public async Task CountryEstateBinding_RejectsInitialContractViolationBeforeEntry(string violation)
        {
            await _page.SetContentAsync(CoverageHtml("1"));
            await AlterPerilsAsync(violation);
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<PlaywrightException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
            Assert.That(await new SFP_ResidenceCoveragePage(_page).InsuranceAmountInput.InputValueAsync(), Is.EqualTo("1"));
        }

        [Test]
        public async Task CountryEstateBinding_VerifiesSavedResidenceWithoutSelectingDisabledPerils()
        {
            await _page.SetContentAsync(BindingHtml());
            var data = ResidenceData();
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, data);
            await steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6"));
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"),
                Is.EqualTo(new[] { "save", "reopen", "locations", "next" }));
            Assert.That(await _page.EvaluateAsync<int>("window.perilsClicks"), Is.Zero);
            Assert.That(data.ResidencePerils, Is.EqualTo("6"));
            Assert.That(await new SFP_ResidenceCoveragePage(_page).HouseholdContentsPercentSelect.InnerTextAsync(), Is.EqualTo("50%"));
            Assert.That(data.Farm.CountryEstateHouseholdContentsAmount, Is.EqualTo("187500"));
        }

        [TestCase("3")]
        [TestCase("5")]
        [TestCase("enabled")]
        [TestCase("missing")]
        [TestCase("missing edit")]
        public async Task CountryEstateBinding_RejectsInvalidOrUnavailableSavedReadback(string violation)
        {
            await _page.SetContentAsync(BindingHtml());
            if (violation == "missing edit")
                await new SFP_LocationsResidencesBuildingsPage(_page).EditResidenceButton().EvaluateAsync("el => el.remove()");
            else
                await _page.EvaluateAsync(@"violation => {
                    document.querySelector('button[data-testid$=""editResidence""]').addEventListener('click', () => {
                        const field = document.querySelector('[data-testid$=""coverageInput$perilGroup.value""]');
                        if (violation === 'missing') field.remove();
                        else if (violation === 'enabled') field.setAttribute('aria-disabled', 'false');
                        else field.textContent = violation;
                    });
                }", violation);

            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<PlaywrightException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
            var actions = await _page.EvaluateAsync<string[]>("window.actions");
            Assert.That(actions, Is.EqualTo(violation == "missing edit" ? new[] { "save" } : new[] { "save", "reopen" }));
            Assert.That(await _page.EvaluateAsync<int>("window.perilsClicks"), Is.Zero);
        }

        private async Task AlterPerilsAsync(string violation)
        {
            await new SFP_ResidenceCoveragePage(_page).PerilsSelect.EvaluateAsync(@"(field, violation) => {
                if (violation === 'missing') field.remove();
                else if (violation === 'enabled') field.setAttribute('aria-disabled', 'false');
                else field.textContent = violation;
            }", violation);
        }

        [Test]
        public async Task CountryEstateBinding_SelectsExactSettlementNotAcvRoofPrefixCollision()
        {
            await _page.SetContentAsync(BindingHtml(
                SettlementOption("Expanded Replacement Cost w/ACV Roof") + SettlementOption("Expanded Replacement Cost")));
            var prefixMatch = _page.GetByRole(AriaRole.Listbox).GetByRole(AriaRole.Option,
                new() { Name = "Expanded Replacement Cost" });
            Assert.That(await prefixMatch.CountAsync(), Is.EqualTo(2), "Captured QA option order exposes the old partial-match defect");
            Assert.That(await prefixMatch.First.InnerTextAsync(), Is.EqualTo("Expanded Replacement Cost w/ACV Roof"));
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            await steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6"));
            Assert.That(await new SFP_ResidenceCoveragePage(_page).ReplacementCostSelect.InnerTextAsync(),
                Is.EqualTo("Expanded Replacement Cost"));
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"),
                Is.EqualTo(new[] { "save", "reopen", "locations", "next" }));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CountryEstateBinding_RejectsMissingOrAmbiguousExactSettlement(bool duplicate)
        {
            var options = duplicate
                ? SettlementOption("Expanded Replacement Cost") + SettlementOption("Expanded Replacement Cost")
                : SettlementOption("Expanded Replacement Cost w/ACV Roof");
            await _page.SetContentAsync(BindingHtml(options));
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, ResidenceData());
            Assert.ThrowsAsync<PlaywrightException>(() =>
                steps.UserAddsAndVerifiesCountryEstateResidenceCoverage(CoverageTable("6")));
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"), Is.Empty);
        }

        private static string SettlementOption(string caption) =>
            $"<div role='option' onclick=\"document.querySelector('[data-testid$=&quot;coverageInput$replacementCost.value&quot;]').textContent = this.textContent\">{caption}</div>";

        private static string BindingHtml(string options = null) =>
            ResidenceHtml() + CoverageHtml(householdPercent: "60%")
            + "<div role='listbox'>" + (options ?? SettlementOption("Expanded Replacement Cost"))
            + "<div role='option' onclick=\"document.querySelector('[data-testid$=&quot;coverageInput$householdContentReplacementCost.value&quot;]').textContent = this.textContent\">50%</div></div>"
            + """
                <script>
                  window.actions = [];
                  window.perilsClicks = 0;
                  document.querySelector('[data-testid$="coverageInput$perilGroup.value"]')
                    .addEventListener('click', () => window.perilsClicks++);
                </script>
                <button data-testid="fields.risk.rows[0].residenceCoverage.rows[0].completeRCTProcess1">Get Valuation</button>
                <button data-testid="fields.data.save" onclick="window.actions.push('save')">Save</button>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editResidence"
                        onclick="window.actions.push('reopen')">
                  <div data-testid="fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editResidence">Edit</div>
                </button>
                <button data-testid="LocationsBuildings-nav" onclick="window.actions.push('locations')">Locations</button>
                <button data-testid="fields.data_Rules.next" onclick="window.actions.push('next')">Next</button>
                """;

        private static ScenarioContextData ResidenceData()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(SfpBasicInputTests.TableOf(
                ("AdditionalDesc", "Main House"), ("YearBuilt", "2022"),
                ("NumberOfFamilies", "Single Family"), ("RateType", "Frame"), ("ConditionRating", "1"),
                ("RoofYear", "2022"), ("RoofType", "Asphalt"), ("RoofImpact", "UL 2"),
                ("SolidFuelQuestion", "No")), data);
            return data;
        }

        private static Reqnroll.Table CoverageTable(string perils) => SfpBasicInputTests.TableOf(
            ("InsuranceAmount", "375000"), ("SquareFeet", "1800"), ("Perils", perils),
            ("ThermostatQuestion", "Yes"), ("ActualCashValue", "Expanded Replacement Cost"),
            ("RCTOption", "Standard"), ("UseDefaults", "Yes"), ("HouseholdContentsAmount", "187500"));

        private static string ResidenceHtml() =>
            Input("additionalDescription", "Main House") + Input("yearBuilt", "2022") + Input("roofYear", "2022")
            + "<div data-testid='fields.building.rows[0].buildingInput$constructionCode.value'>Frame</div>"
            + "<div data-testid='fields.building.rows[0].buildingInput$roofType.value'>Asphalt</div>"
            + "<div data-testid='fields.building.rows[0].buildingInput$roofImpactResistance.value'>UL 2</div>"
            + Chip("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value", "Single Family")
            + Chip("fields.building.rows[0].buildingInput$rateType.value", "1")
            + Chip("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value", "No");

        private static string CoverageHtml(string amount = "375000", string settlement = "Expanded Replacement Cost", string householdPercent = "50%") =>
            $"<input data-testid='{CoveragePrefix}coverageInput$limit.value' value='{amount}'>"
            + $"<input data-testid='{CoveragePrefix}buildingInput$squareFt.value' value='1800'>"
            + $"<div data-testid='{CoveragePrefix}coverageInput$perilGroup.value' aria-disabled='true'>6</div>"
            + $"<div data-testid='{CoveragePrefix}coverageInput$replacementCost.value'>{settlement}</div>"
            + $"<div data-testid='{CoveragePrefix}coverageInput$householdContentReplacementCost.value'>{householdPercent}</div>"
            + Chip(CoveragePrefix + "buildingInput$buildingThermostatQuestion.value", "Yes")
            + Chip(CoveragePrefix + "buildingValuatioinInput$estimatorType.value", "RCT")
            + Chip(CoveragePrefix + "buildingValuatioinInput$valuationType.value", "Standard");

        private static string Input(string field, string value) =>
            $"<input data-testid='fields.building.rows[0].buildingInput${field}.value' value='{value}'>";

        private static string Chip(string testId, string value) =>
            $"<div data-testid='{testId}-chip-item-wrapper'><span class='chip-wrapper-selected'>{value}</span></div>";
    }
}
