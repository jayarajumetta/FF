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
    public class SfpBasicPageTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

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

        [TestCase("550000")]
        [TestCase("$550,000.00")]
        public async Task AmountAssertion_AcceptsEquivalentNumericFormatting(string value)
        {
            await _page.SetContentAsync($"<input value='{value}'>");
            await SfpFieldAssertions.NumberAsync(_page.Locator("input"), "550000");
        }

        [Test]
        public async Task AmountAssertion_RejectsChangedRctAmount()
        {
            await _page.SetContentAsync("<input value='375000'>");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                SfpFieldAssertions.NumberAsync(_page.Locator("input"), "550000"));
        }

        [Test]
        public async Task DisabledPerils_MustContainRequestedValue()
        {
            await _page.SetContentAsync("<div data-testid='perils' aria-disabled='true'>5</div>");
            await SfpFieldAssertions.SelectionAsync(_page.GetByTestId("perils"), "5");
            await _page.GetByTestId("perils").EvaluateAsync("el => el.textContent = '3'");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                SfpFieldAssertions.SelectionAsync(_page.GetByTestId("perils"), "5"));
        }

        [Test]
        public async Task RoofImpact_MustMatchSelectedClassNotJustNonemptyText()
        {
            await _page.SetContentAsync("<div data-testid='roof'><span class='mat-select-value-text'>UL 4</span></div>");
            await SfpFieldAssertions.SelectionAsync(_page.GetByTestId("roof"), "UL 4");
            await _page.Locator("span").EvaluateAsync("el => el.textContent = 'UL 2'");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                SfpFieldAssertions.SelectionAsync(_page.GetByTestId("roof"), "UL 4"));
        }

        [Test]
        public async Task MissingRequiredControl_Fails()
        {
            await _page.SetContentAsync("<div>No coverage fields</div>");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                SfpFieldAssertions.NumberAsync(_page.GetByTestId("missing"), "101500"));
        }

        [Test]
        public async Task RenovationInputs_UseExistingWiringHeatingPlumbingControls()
        {
            await _page.SetContentAsync(
                "<div data-testid='fields.building.rows[0].buildingInput$occupancy.value-chip-item-wrapper'>Owner</div>"
                + Input("heatingYear") + Input("plumbingYear") + Input("wiringYear"));
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(SfpBasicInputTests.TableOf(
                ("HeatingYear", "2026"), ("PlumbingYear", "2025"), ("ElectricalYear", "2026")), data);
            var page = new SFP_AddResidencePage(_page);
            await page.FillResidenceFormAsync(data);
            var heatingYear = await page.HeatingYearInput.InputValueAsync();
            var plumbingYear = await page.PlumbingYearInput.InputValueAsync();
            var wiringYear = await page.WiringYearInput.InputValueAsync();
            Assert.Multiple(() =>
            {
                Assert.That(heatingYear, Is.EqualTo("2026"));
                Assert.That(plumbingYear, Is.EqualTo("2025"));
                Assert.That(wiringYear, Is.EqualTo("2026"));
            });
        }

        [Test]
        public async Task RequiredFpp_UsesExactCodeAndResponseRowIndex()
        {
            await _page.SetContentAsync(FppTable(FppRow("1464", 0) + FppRow("464", 7)));
            var page = new SFP_FarmPersonalPropertyPage(_page);
            Assert.That(await page.FindRequiredRowByCodeAsync("464"), Is.EqualTo(7));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task RequiredFpp_MissingOrAmbiguousCodeFails(bool duplicate)
        {
            await _page.SetContentAsync(FppTable(
                duplicate ? FppRow("464", 0) + FppRow("464", 1) : FppRow("1464", 0)));
            var page = new SFP_FarmPersonalPropertyPage(_page);
            Assert.ThrowsAsync<PlaywrightException>(() => page.FindRequiredRowByCodeAsync("464"));
        }

        [Test]
        public async Task BasicFppBinding_FailsMissingCoverageWhileLegacyBindingRetainsBehavior()
        {
            await _page.SetContentAsync(FppTable(""));
            var data = new ScenarioContextData();
            var steps = new SFP_LocationPropertySteps(new PlaywrightContext { Page = _page }, data);
            var table = SfpBasicInputTests.TableOf(("Code", "464"), ("Description", "Bose Sound Bars"),
                ("Limit", "101500"), ("Deductible", "$1,000"));
            Assert.ThrowsAsync<PlaywrightException>(() => steps.UserAddsAndVerifiesBasicFarmPersonalProperty(table));
            Assert.That(data.Farm.FarmPropertyCode, Is.EqualTo("464"));
            Assert.That(data.Farm.FarmPropertyLimit, Is.EqualTo("101500"));
            await steps.UserAddsFarmPersonalProperty(table);
        }

        [Test]
        public async Task RequiredFpp_VerifiesUppercasedDescriptionAndExactAmount()
        {
            await _page.SetContentAsync("""
                <input data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$description.value" value="BOSE SOUND BARS">
                <input data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$limit.value" value="101,500">
                <div data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$deductible.value">$1,000</div>
                """);
            var data = new ScenarioContextData();
            TableMappingHelpers.FarmPersonalPropertyFields(SfpBasicInputTests.TableOf(
                ("Description", "Bose Sound Bars"), ("Limit", "101500"), ("Deductible", "$1,000")), data);
            var page = new SFP_FarmPersonalPropertyPage(_page);
            await page.VerifyItemAsync(data);
            await page.ItemLimit().FillAsync("15000");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyItemAsync(data));
        }

        [Test]
        public async Task ResidenceReadback_RejectsLostRoofYear()
        {
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceFields(SfpBasicInputTests.TableOf(
                ("AdditionalDesc", "Main House"), ("YearBuilt", "2024"),
                ("NumberOfFamilies", "Single Family"), ("RateType", "Frame"), ("ConditionRating", "1"),
                ("RoofYear", "CURRENT YEAR"), ("RoofType", "Slate"), ("RoofImpact", "UL 4"),
                ("HeatingYear", "2026"), ("PlumbingYear", "2025"), ("ElectricalYear", "2026"),
                ("SeasonalOrVacant", "No"), ("SolidFuelQuestion", "No")), data);
            await _page.SetContentAsync(
                Input("additionalDescription", "Main House") + Input("yearBuilt", "2024")
                + Input("roofYear", data.ResidenceRoofYear) + Input("heatingYear", "2026")
                + Input("plumbingYear", "2025") + Input("wiringYear", "2026")
                + Select("fields.building.rows[0].buildingInput$constructionCode.value", "Frame")
                + Select("fields.building.rows[0].buildingInput$roofType.value", "Slate")
                + Select("fields.building.rows[0].buildingInput$roofImpactResistance.value", "UL 4")
                + Chip("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value", "Single Family")
                + Chip("fields.building.rows[0].buildingInput$rateType.value", "1")
                + Chip("fields.building.rows[0].buildingInput$eQVacantSeasonal.value", "No")
                + Chip("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value", "No"));
            var page = new SFP_AddResidencePage(_page);
            await page.VerifyResidenceFormAsync(data);
            await page.RoofYearInput.FillAsync("2022");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceFormAsync(data));
        }

        [Test]
        public async Task ResidenceCoverageReadback_ChecksDisabledPerilsAndAmount()
        {
            const string prefix = "fields.risk.rows[0].residenceCoverage.rows[0].";
            var data = new ScenarioContextData();
            TableMappingHelpers.ResidenceCoverageFields(SfpBasicInputTests.TableOf(
                ("InsuranceAmount", "550000"), ("SquareFeet", "1800"), ("Perils", "5"),
                ("ThermostatQuestion", "Yes"), ("ActualCashValue", "Replacement Cost"),
                ("RCTOption", "Standard"), ("UseDefaults", "Yes")), data);
            await _page.SetContentAsync(
                $"<input data-testid='{prefix}coverageInput$limit.value' value='550,000'>"
                + $"<input data-testid='{prefix}buildingInput$squareFt.value' value='1,800'>"
                + Select(prefix + "coverageInput$perilGroup.value", "5")
                + Select(prefix + "coverageInput$replacementCost.value", "Replacement Cost")
                + Chip(prefix + "buildingInput$buildingThermostatQuestion.value", "Yes")
                + Chip(prefix + "buildingValuatioinInput$estimatorType.value", "RCT")
                + Chip(prefix + "buildingValuatioinInput$valuationType.value", "Standard"));
            var page = new SFP_ResidenceCoveragePage(_page);
            await page.PerilsSelect.EvaluateAsync("el => el.setAttribute('aria-disabled', 'true')");
            await page.VerifyResidenceCoverageAsync(data);
            await page.PerilsSelect.EvaluateAsync("el => el.textContent = '3'");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyResidenceCoverageAsync(data));
        }

        private static string Input(string field, string value = "") =>
            $"<input data-testid='fields.building.rows[0].buildingInput${field}.value' value='{value}'>";

        private static string Select(string testId, string value) =>
            $"<div data-testid='{testId}'>{value}</div>";

        private static string Chip(string testId, string value) =>
            $"<div data-testid='{testId}-chip-item-wrapper'><span class='chip-wrapper-selected'>{value}</span></div>";

        private static string FppTable(string rows) =>
            "<table data-testid='coverageTable'><thead><tr><th></th><th class='mat-column-column1'>Coverage Code</th>"
            + "<th>Coverage Name</th><th>Coverage Description</th></tr></thead><tbody>"
            + rows + "</tbody></table>";

        private static string FppRow(string code, int index, string description = "") =>
            $"<tr><td><label data-testid='fields.page.covCatEntry.rows[{index}].covCatEntryInput$selected.value'>Select</label></td>"
            + $"<td class='mat-column-column1'>{code}</td><td>Equipment</td><td>{description}</td></tr>";

        [TestCase(false)]
        [TestCase(true)]
        public async Task RequiredFpp_IgnoresMatchingNonCodeCell(bool includeRealCode)
        {
            await _page.SetContentAsync(FppTable(FppRow("463", 8, "464")
                + (includeRealCode ? FppRow("464", 12) : "")));
            var page = new SFP_FarmPersonalPropertyPage(_page);
            if (includeRealCode)
                Assert.That(await page.FindRequiredRowByCodeAsync("464"), Is.EqualTo(12));
            else
                Assert.ThrowsAsync<PlaywrightException>(() => page.FindRequiredRowByCodeAsync("464"));
        }

        [Test]
        public async Task RequiredFpp_UsesColumnIdentityNotCellPosition()
        {
            await _page.SetContentAsync("""
                <table data-testid="coverageTable">
                  <thead><tr><th>Coverage Description</th><th>Selected</th><th class="mat-column-column1">Coverage Code</th></tr></thead>
                  <tbody>
                    <tr><td>464</td><td><label data-testid="fields.page.covCatEntry.rows[8].covCatEntryInput$selected.value">Select</label></td>
                        <td class="mat-column-column1">463</td></tr>
                    <tr><td>Audio equipment</td><td><label data-testid="fields.page.covCatEntry.rows[12].covCatEntryInput$selected.value">Select</label></td>
                        <td class="mat-column-column1"> 464 </td></tr>
                  </tbody>
                </table>
                """);
            var page = new SFP_FarmPersonalPropertyPage(_page);
            Assert.That(await page.FindRequiredRowByCodeAsync("464"), Is.EqualTo(12));
        }

        [Test]
        public async Task RequiredFpp_RejectsChangedCodeColumnSchema()
        {
            await _page.SetContentAsync(FppTable(FppRow("464", 7)));
            await _page.Locator("th.mat-column-column1").EvaluateAsync("el => el.textContent = 'Coverage Description'");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                new SFP_FarmPersonalPropertyPage(_page).FindRequiredRowByCodeAsync("464"));
        }

        [Test]
        public async Task ReopenResidence_ClicksNativeButtonWhenNestedIconSharesTestId()
        {
            const string testId = "fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editResidence";
            await _page.SetContentAsync($"""
                <aa-button-icon-action>
                  <button data-testid="{testId}" onclick="document.body.dataset.opened='R1L1'">
                    <aa-icons>
                      <div data-testid="{testId}"><mat-icon>edit</mat-icon></div>
                    </aa-icons>
                  </button>
                </aa-button-icon-action>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[1].building.rows[0].editResidence"
                        onclick="document.body.dataset.opened='wrong-location'">edit</button>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[0].building.rows[1].editResidence"
                        onclick="document.body.dataset.opened='wrong-residence'">edit</button>
                """);
            Assert.That(await _page.GetByTestId(testId).CountAsync(), Is.EqualTo(2));
            Assert.ThrowsAsync<PlaywrightException>(() =>
                Microsoft.Playwright.Assertions.Expect(_page.GetByTestId(testId)).ToHaveCountAsync(1));

            var page = new SFP_LocationsResidencesBuildingsPage(_page);
            Assert.That(await page.EditResidenceButton().EvaluateAsync<string>("el => el.tagName"), Is.EqualTo("BUTTON"));
            await page.OpenResidenceAsync();
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-opened"), Is.EqualTo("R1L1"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ReopenResidence_RejectsTwoMatchingNativeButtons(bool nestedIcon)
        {
            const string testId = "fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editResidence";
            var content = nestedIcon
                ? $"<aa-icons><div data-testid='{testId}'><mat-icon>edit</mat-icon></div></aa-icons>"
                : "edit";
            var button = $"<button data-testid='{testId}' onclick=\"document.body.dataset.opened='unexpected'\">{content}</button>";
            await _page.SetContentAsync(button + button);
            Assert.ThrowsAsync<PlaywrightException>(() =>
                new SFP_LocationsResidencesBuildingsPage(_page).OpenResidenceAsync());
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-opened"), Is.Null);
        }

        [Test]
        public async Task ReopenResidence_TargetsFirstResidenceAtFirstLocation()
        {
            await _page.SetContentAsync("""
                <button data-testid="fields.data.accountDetail.locationDetail.rows[1].building.rows[0].editResidence"
                        onclick="document.body.dataset.opened='wrong-location'">edit</button>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[0].building.rows[1].editResidence"
                        onclick="document.body.dataset.opened='wrong-residence'">edit</button>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editResidence"
                        onclick="document.body.dataset.opened='R1L1'">edit</button>
                """);
            await new SFP_LocationsResidencesBuildingsPage(_page).OpenResidenceAsync();
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-opened"), Is.EqualTo("R1L1"));
        }
    }
}
