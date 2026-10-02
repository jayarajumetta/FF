using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
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

        [TestCase(true)]
        [TestCase(false)]
        public async Task BasicSppBinding_NavigatesAndRequiresRequestedCategory(bool categoryPresent)
        {
            await _page.SetContentAsync("""
                <button data-testid="ScheduledPersonalProperty-nav" onclick="catalog()">Scheduled Property</button>
                <main>Previous coverage page</main>
                <script>
                    window.actions = [];
                    function catalog() {
                        actions.push('navigate');
                        document.querySelector('main').innerHTML = `
                            <table><tr><td id="CovCatEntryOutput.CoverageID-3-layout">COVERAGE_CODE</td>
                            <td><label data-testid="fields.page.covCatEntry.rows[3].covCatEntryInput$selected.value">
                                <input type="checkbox" onchange="actions.push('select')">Bicycles</label></td></tr></table>
                            <button data-testid="fields.covEndorsements.add" onclick="edit()">Add Coverage</button>
                            <button data-testid="fields.data-Next.next" onclick="actions.push('next')">Next</button>`;
                    }
                    function edit() {
                        actions.push('add');
                        document.querySelector('main').innerHTML = `
                            <input id="description" data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$description.value">
                            <input id="limit" data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$limit.value">
                            <input id="year" data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$yearOfLastAppraisal.value">
                            <button data-testid="fields.data.save" onclick="save()">Save</button>
                            <button data-testid="fields.data-Next.next" onclick="actions.push('next')">Next</button>`;
                    }
                    function save() {
                        actions.push('save');
                        window.saved = ['description', 'limit', 'year'].map(id => document.getElementById(id).value);
                    }
                </script>
                """.Replace("COVERAGE_CODE", categoryPresent ? "401" : "402"));
            var steps = new SFP_CoverageSteps(new PlaywrightContext { Page = _page }, new ScenarioContextData());
            var table = SfpBasicInputTests.TableOf(("Category", "401"), ("ItemType", "Bicycles"),
                ("Description", "Road Bike"), ("Limit", "750"), ("YearOfAppraisal", "2025"));

            if (!categoryPresent)
            {
                var error = Assert.ThrowsAsync<PlaywrightException>(() => steps.UserAddsScheduledPersonalProperty(table));
                Assert.That(error.Message, Does.Contain("Required SPP category '401'"));
                Assert.That(await _page.EvaluateAsync<string[]>("window.actions"), Is.EqualTo(new[] { "navigate" }));
                return;
            }

            await steps.UserAddsScheduledPersonalProperty(table);
            Assert.That(await _page.EvaluateAsync<string[]>("window.actions"),
                Is.EqualTo(new[] { "navigate", "select", "add", "save", "next" }));
            Assert.That(await _page.EvaluateAsync<string[]>("window.saved"),
                Is.EqualTo(new[] { "Road Bike", "750", "2025" }));
        }

        [TestCase("BOSE SOUND BARS")]
        [TestCase("Bose Sound Bars")]
        public async Task RequiredFpp_VerifiesEnteredOrUppercasedDescriptionAndExactAmount(string description)
        {
            await _page.SetContentAsync("""
                <input type="search" data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$description.value">
                <input data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$limit.value" value="101,500">
                <div data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$deductible.value">$1,000</div>
                """);
            var data = new ScenarioContextData();
            TableMappingHelpers.FarmPersonalPropertyFields(SfpBasicInputTests.TableOf(
                ("Description", "Bose Sound Bars"), ("Limit", "101500"), ("Deductible", "$1,000")), data);
            var page = new SFP_FarmPersonalPropertyPage(_page);
            await page.ItemDescription().FillAsync(description);
            await page.VerifyItemAsync(data);
            await page.ItemLimit().FillAsync("15000");
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyItemAsync(data));
        }

        [TestCase("")]
        [TestCase("Bose Sound Bar")]
        [TestCase("Bose Sound Bars extra")]
        [TestCase("Extra BOSE SOUND BARS")]
        public async Task RequiredFpp_RejectsMissingOrChangedDescription(string description)
        {
            await _page.SetContentAsync("""
                <input type="search" data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$description.value">
                <input data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$limit.value" value="101500">
                <div data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$deductible.value">$1,000</div>
                """);
            var data = new ScenarioContextData();
            TableMappingHelpers.FarmPersonalPropertyFields(SfpBasicInputTests.TableOf(
                ("Description", "Bose Sound Bars"), ("Limit", "101500"), ("Deductible", "$1,000")), data);
            var page = new SFP_FarmPersonalPropertyPage(_page);
            await page.ItemDescription().FillAsync(description);
            Assert.ThrowsAsync<PlaywrightException>(() => page.VerifyItemAsync(data));
        }

        [Test]
        public async Task LimitedFarmPollutionEditor_SelectsCoverageAndFillsRequiredFields()
        {
            await _page.SetContentAsync("""
                <table data-testid="coverageTableLiability">
                    <tr role="row">
                        <td>
                            <label data-testid="fields.liability.rows[37].selected.value">
                                <input type="checkbox" onchange="window.coverageSelected = this.checked">
                            </label>
                        </td>
                        <td>146</td>
                        <td>Limited Farm Pollution Liability</td>
                        <td><button aria-label="Edit Coverage" onclick="window.editorOpened = true">Edit Coverage</button></td>
                    </tr>
                </table>
                <input data-testid="fields.pollution.occurrenceAggregateLimit.value">
                <input data-testid="fields.pollution.totalCapacityOfManureStorage.value">
                <input data-testid="fields.pollution.maximumNumberOfMiles.value">
                <input data-testid="fields.pollution.numberOfTrips.value">
                <button aria-label="Add Tank" onclick="window.tankAdded = true">Add Tank</button>
                <input data-testid="fields.pollution.limitedPollutionTankInput$capacity.value">
                <input id="fields_pollution_limitedPollutionTankInput_constructionDate_value"
                       name="fields.pollution.limitedPollutionTankInput$constructionDate.value">
                <input type="checkbox"
                       data-testid="fields.pollution.limitedFarmPollutionLiabilityQuestionsInput$eqNoneAbove.value"
                       onchange="window.noneAbove = this.checked">
                <button data-testid="fields.data.save" onclick="window.saved = true">Save</button>
                """);
            var data = new ScenarioContextData();
            TableMappingHelpers.LimitedFarmPollutionFields(SfpBasicInputTests.TableOf(
                ("CoverageCode", "146"),
                ("CoverageName", "Limited Farm Pollution Liability"),
                ("RequiredBaseLiabilityLimit", "$100,000/$300,000"),
                ("OccurrenceAggregate", "50000/300000"),
                ("TotalOnsiteCapacity", "8000000"),
                ("FurthestLocationMiles", "23"),
                ("WasteTripsPerYear", "550"),
                ("AboveGroundTanks", "Yes"),
                ("TankCapacity", "10000"),
                ("TankConstructionDate", "2024-03-31"),
                ("EligibilityQuestions", "None Of The Above"),
                ("ExpectedReferralRule", "11125")), data);

            var page = new SFP_LiabilityPage(_page);
            await page.EditLimitedFarmPollutionAsync(data.Farm);

            var coverageSelected = await _page.EvaluateAsync<bool>("window.coverageSelected");
            var editorOpened = await _page.EvaluateAsync<bool>("window.editorOpened");
            var occurrenceAggregate = await _page.GetByTestId("fields.pollution.occurrenceAggregateLimit.value").InputValueAsync();
            var totalOnsiteCapacity = await _page.GetByTestId("fields.pollution.totalCapacityOfManureStorage.value").InputValueAsync();
            var furthestLocationMiles = await _page.GetByTestId("fields.pollution.maximumNumberOfMiles.value").InputValueAsync();
            var wasteTripsPerYear = await _page.GetByTestId("fields.pollution.numberOfTrips.value").InputValueAsync();
            var tankAdded = await _page.EvaluateAsync<bool>("window.tankAdded");
            var tankCapacity = await _page.GetByTestId("fields.pollution.limitedPollutionTankInput$capacity.value").InputValueAsync();
            var tankConstructionDate = await _page.Locator("input[name*='constructionDate' i]").InputValueAsync();
            var noneAbove = await _page.EvaluateAsync<bool>("window.noneAbove");
            var saved = await _page.EvaluateAsync<bool>("window.saved");
            Assert.Multiple(() =>
            {
                Assert.That(coverageSelected, Is.True);
                Assert.That(editorOpened, Is.True);
                Assert.That(occurrenceAggregate, Is.EqualTo("50000/300000"));
                Assert.That(totalOnsiteCapacity, Is.EqualTo("8000000"));
                Assert.That(furthestLocationMiles, Is.EqualTo("23"));
                Assert.That(wasteTripsPerYear, Is.EqualTo("550"));
                Assert.That(tankAdded, Is.True);
                Assert.That(tankCapacity, Is.EqualTo("10000"));
                Assert.That(tankConstructionDate, Is.EqualTo("03/31/2024"));
                Assert.That(noneAbove, Is.True);
                Assert.That(saved, Is.True);
            });
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

        [Test]
        public async Task EditLocation_UsesDedicatedSaveLocationAction()
        {
            await _page.SetContentAsync("""
                <input data-testid="fields.data.account.location.rows[0].locationInput$additionalDescription.value">
                <button data-testid="fields.data_Next.saveLocation"
                        onclick="document.body.dataset.action='saveLocation'">Save Location</button>
                """);
            var page = new SFP_EditLocationPage(_page);

            Assert.That(await page.IsCurrentAsync(), Is.True);
            await page.SaveLocationAsync();
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-action"), Is.EqualTo("saveLocation"));
        }

        [Test]
        public async Task SourceBackedAllPeril_SelectsExactRequestedValue()
        {
            await _page.SetContentAsync("""
                <div>
                  <button data-testid="fields.locationInput$allPeril.value-0"
                          onclick="document.body.dataset.allPeril='$1,000'">$1,000</button>
                  <button data-testid="fields.locationInput$allPeril.value-1"
                          onclick="document.body.dataset.allPeril='$2,500'">$2,500</button>
                </div>
                """);
            var data = new ScenarioContextData
            {
                RatingState = "Vermont",
                ZipCode = "05091",
                Territory = "031",
                AllPerilDeductible = "$2,500"
            };
            var page = new LocationPage(_page, data);

            await page.ConfigureSourceBackedCoverageAsync();
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-all-peril"), Is.EqualTo("$2,500"));
        }

        [Test]
        public void SourceBackedAllPeril_AllowsTheSfpViewToLeaveControlUnexposed()
        {
            _page.SetContentAsync("<main>SFP location without an all-peril control</main>")
                .GetAwaiter().GetResult();
            var data = new ScenarioContextData
            {
                RatingState = "Vermont",
                ZipCode = "05091",
                Territory = "031",
                AllPerilDeductible = "$2,500"
            };
            var page = new LocationPage(_page, data);

            Assert.DoesNotThrowAsync(() => page.ConfigureSourceBackedCoverageAsync());
        }

        [Test]
        public async Task SourceBackedWindHail_SelectsExactValueInsteadOfNextHigherOption()
        {
            await _page.SetContentAsync("""
                <div id="wind-hail">
                  <button data-testid="fields.locationInput$windHailDeductible.value-0"
                          onclick="document.body.dataset.windHail='1%'">1%</button>
                  <button data-testid="fields.locationInput$windHailDeductible.value-1"
                          onclick="document.body.dataset.windHail='2%'">2%</button>
                  <button data-testid="fields.locationInput$windHailDeductible.value-2"
                          onclick="document.body.dataset.windHail='5%'">5%</button>
                </div>
                """);
            var page = new LocationPage(_page, new ScenarioContextData());

            await page.SelectWindHailDeductibleAsync("2%", "20855", selectExactRequestedValue: true);
            Assert.That(await _page.Locator("body").GetAttributeAsync("data-wind-hail"), Is.EqualTo("2%"));
        }

        [Test]
        public async Task PennsylvaniaWindHail_WhenPresent_SelectsAndPersistsNA()
        {
            await SetWindHailOptionsAsync("DEV SFP Location", "N/A", "1%", "2%", "5%");
            var page = new LocationPage(_page, new ScenarioContextData { RatingState = "Pennsylvania" });

            await page.VerifyWindHailDeductibleOptionsAsync("17601", "None");
            await page.SelectWindHailDeductibleAsync("None", "17601", selectExactRequestedValue: true);

            Assert.That(await SelectedWindHailOptionAsync(), Is.EqualTo("N/A"));
        }

        [Test]
        public async Task PennsylvaniaWindHail_WhenAbsent_RecordsAcceptedDeploymentShape()
        {
            await _page.SetContentAsync("<title>DEV SFP Location</title><main>No Wind/Hail field</main>");
            var page = new LocationPage(_page, new ScenarioContextData { RatingState = "Pennsylvania" });

            Assert.DoesNotThrowAsync(async () =>
            {
                await page.VerifyWindHailDeductibleOptionsAsync("17601", "None");
                await page.SelectWindHailDeductibleAsync("None", "17601", selectExactRequestedValue: true);
            });
        }

        [Test]
        public async Task VermontWindHail_WhenPresent_SelectsAndPersistsOnePercent()
        {
            await SetWindHailOptionsAsync("DEV SFP Location", "N/A", "1%", "2%", "5%");
            var page = new LocationPage(_page, new ScenarioContextData { RatingState = "Vermont" });

            await page.VerifyWindHailDeductibleOptionsAsync("05091", "1%");
            await page.SelectWindHailDeductibleAsync("1%", "05091", selectExactRequestedValue: true);

            Assert.That(await SelectedWindHailOptionAsync(), Is.EqualTo("1%"));
        }

        [Test]
        public async Task VermontWindHail_WhenAbsent_RecordsDeploymentDriftAndContinues()
        {
            await _page.SetContentAsync("<title>DEV SFP Location</title><main>No Wind/Hail field</main>");
            var page = new LocationPage(_page, new ScenarioContextData { RatingState = "Vermont" });

            Assert.DoesNotThrowAsync(async () =>
            {
                await page.VerifyWindHailDeductibleOptionsAsync("05091", "1%");
                await page.SelectWindHailDeductibleAsync("1%", "05091", selectExactRequestedValue: true);
            });
        }

        [TestCase("Pennsylvania", "17601", "None", new[] { "1%", "2%", "5%" }, "N/A")]
        [TestCase("Vermont", "05091", "1%", new[] { "N/A", "2%", "5%" }, "1%")]
        public async Task DevWindHailContract_RejectsUnexpectedOptionState(
            string state,
            string zip,
            string requested,
            string[] offered,
            string required)
        {
            await SetWindHailOptionsAsync("DEV SFP Location", offered);
            var page = new LocationPage(_page, new ScenarioContextData { RatingState = state });

            var error = Assert.ThrowsAsync<AssertionException>(
                () => page.VerifyWindHailDeductibleOptionsAsync(zip, requested));
            Assert.That(error.Message,
                Does.Contain($"State={state}")
                    .And.Contain($"ZIP={zip}")
                    .And.Contain($"required option '{required}'")
                    .And.Contain("Offered=")
                    .And.Contain("Page=Title='DEV SFP Location'"));
        }

        [Test]
        public void ClientDetails_ReportsDuckCreekQuoteErrorBeforeGenericNavigationFailure()
        {
            _page.SetContentAsync("<main><h1>Quote Error</h1><div class='error'>DC-500 Internal Server Error</div></main>")
                .GetAwaiter().GetResult();
            var page = new SFP_ClientDetailsPage(_page);

            var error = Assert.ThrowsAsync<PlaywrightException>(() =>
                page.SelectContactRoleAsync("Inspection Contact"));
            Assert.That(error.Message, Does.Contain("DC-500").And.Contain("Client Details"));
        }

        private static string Input(string field, string value = "") =>
            $"<input data-testid='fields.building.rows[0].buildingInput${field}.value' value='{value}'>";

        private async Task SetWindHailOptionsAsync(string title, params string[] options)
        {
            var chips = string.Join(
                "",
                Array.ConvertAll(options, option =>
                {
                    var index = Array.IndexOf(options, option);
                    return
                    $"<div class='chip-item-wrapper' data-testid='fields.locationInput$windHailDeductible.value-chip-item-wrapper-{index}' " +
                    "onclick=\"document.querySelectorAll('.chip-wrapper-selected').forEach(x => x.className='chip-wrapper'); this.querySelector('.chip-wrapper').className='chip-wrapper-selected'\">" +
                    $"<div class='chip-wrapper' data-testid='fields.locationInput$windHailDeductible.value-chip-wrapper-{index}'>{option}</div></div>";
                }));
            await _page.SetContentAsync(
                $"<title>{title}</title><div id='wind-hail'><div class='regular-chip-container' " +
                $"data-testid='fields.locationInput$windHailDeductible.value'>{chips}</div></div>");
        }

        private async Task<string> SelectedWindHailOptionAsync()
        {
            var selected = _page.Locator("[data-testid*='windHailDeductible'].chip-wrapper-selected");
            return await selected.InnerTextAsync();
        }

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
