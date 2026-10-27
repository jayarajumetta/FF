using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using PnCTestAutomation.Pages.ExpertQuotePages;
using PnCTestAutomation.Pages.ExpertQuotePages.SFP;

namespace PnCTestAutomation.Tests
{
    [TestFixture]
    public class SfpRatePolicyPageTests
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

        [Test]
        public async Task Contents_UsesTheReturnedSectionAndDoesNotOverwriteResidenceCoverage()
        {
            await _page.SetContentAsync("""
                <input data-testid="fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value" value="250000">
                """);
            var form = new SFP_NativeFormPage(_page);
            var before = await form.FieldIdsAsync("CoverageInput.Limit");
            await _page.Locator("body").EvaluateAsync("""
                element => element.insertAdjacentHTML('beforeend', `
                  <input data-testid="fields.returnedByServer.rows[7].coverageInput$limit.value" value="0">
                  <select data-testid="fields.returnedByServer.rows[7].coverageInput$perilGroup.value"><option>3</option><option>5</option></select>
                  <select data-testid="fields.returnedByServer.rows[7].coverageInput$replacementCost.value"><option>No</option><option>Yes</option></select>`)
                """);
            var section = await form.AdditionalSectionAsync("CoverageInput.Limit", before);
            Assert.That(section, Is.EqualTo("fields.returnedByServer.rows[7]"));
            await form.SetSectionAsync(section, "CoverageInput.Limit", "100000", number: true);
            await form.SetSectionAsync(section, "CoverageInput.PerilGroup", "5");
            await form.SetSectionAsync(section, "CoverageInput.ReplacementCost", "Yes");
            Assert.That(await _page.GetByTestId(before[0]).InputValueAsync(), Is.EqualTo("250000"));
            Assert.That(await form.SectionField(section, "CoverageInput.Limit").InputValueAsync(), Is.EqualTo("100000"));
        }

        [Test]
        public async Task ResidenceContents_ValidatesReadOnlyCoverageTypeAndHandlesKeyboardOpenedPerils()
        {
            const string section = "fields.contents.rows[7]";
            await _page.SetContentAsync(
                "<fieldset><div class='readonly-field readonly readonly-chips'>"
                + "<span class='readonly-label'>Coverage Type::</span>"
                + "<span class='readonly-value'>Mobile Home Contents</span></div>"
                + $"<input data-testid='{section}.coverageInput$limit.value' value='0'>"
                + $"<mat-select id='contents-perils' role='combobox' tabindex='0' aria-expanded='false' aria-disabled='false' "
                + "style='display:block;width:100px;height:30px' "
                + $"data-testid='{section}.coverageInput$perilGroup.value'></mat-select>"
                + Chips(section + ".coverageInput$replacementCost", "No")
                + Chips(section + ".coverageInput$replacementCost", "Yes", selected: false)
                + """
                  <script>
                    const peril = document.getElementById('contents-perils');
                    peril.addEventListener('keydown', event => {
                      if (event.code !== 'Space')
                        return;
                      event.preventDefault();
                      peril.setAttribute('aria-expanded', 'true');
                      document.body.insertAdjacentHTML('beforeend',
                        '<div id="peril-options" role="listbox"><div role="option">3</div><div role="option">5</div></div>');
                      document.querySelectorAll('#peril-options [role="option"]').forEach(option =>
                        option.addEventListener('click', () => {
                          peril.textContent = option.textContent;
                          peril.setAttribute('aria-expanded', 'false');
                          document.getElementById('peril-options').remove();
                        }));
                    });
                  </script>
                  </fieldset>
                  """);
            var values = ScenarioValues("CoverageType", "Mobile Home Contents");
            var residence = new SFP_AddResidencePage(_page);

            await residence.FillRatePolicyContentsSectionAsync(section, values);

            var form = new SFP_NativeFormPage(_page);
            await form.VerifySectionAsync(
                section, "CoverageInput.Type", "Mobile Home Contents", readOnlyCaption: "Coverage Type");
            await form.VerifySectionAsync(section, "CoverageInput.Limit", "100000", number: true);
            await form.VerifySectionAsync(section, "CoverageInput.PerilGroup", "5");
            await form.VerifySectionAsync(section, "CoverageInput.ReplacementCost", "Yes");
        }

        [Test]
        public async Task NativeMaterialSelect_CentersBelowFoldControlBeforeOpeningItsOverlay()
        {
            await _page.SetContentAsync("""
                <div style="height:1200px"></div>
                <mat-select data-testid="fields.building.rows[0].covBuildingInput$coverageType.value"
                            role="combobox" aria-expanded="false" tabindex="0"
                            style="display:block;width:200px;height:30px"></mat-select>
                <div style="height:1200px"></div>
                <script>
                  const select = document.querySelector('mat-select');
                  select.addEventListener('click', () => {
                    const rect = select.getBoundingClientRect();
                    document.body.insertAdjacentHTML('beforeend',
                      `<div id="coverage-options" role="listbox"
                            style="position:fixed;left:${rect.left}px;top:${rect.bottom}px">
                         <div role="option">Farm Building</div>
                         <div role="option">Private Structure</div>
                       </div>`);
                    select.setAttribute('aria-expanded', 'true');
                    document.querySelectorAll('#coverage-options [role="option"]').forEach(option =>
                      option.addEventListener('click', () => {
                        select.textContent = option.textContent;
                        select.setAttribute('aria-expanded', 'false');
                        document.getElementById('coverage-options').remove();
                      }));
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("CovBuildingInput.CoverageType", "Farm Building");

            await form.VerifyAsync("CovBuildingInput.CoverageType", "Farm Building");
        }

        [Test]
        public async Task NativeMaterialSelect_UsesExactActiveOptionWhenOverlayIsOutsideViewport()
        {
            await _page.SetContentAsync("""
                <mat-select data-testid="fields.building.rows[0].covBuildingInput$coverageType.value"
                            role="combobox" aria-expanded="false" tabindex="0"
                            style="display:block;width:200px;height:30px"></mat-select>
                <script>
                  const select = document.querySelector('mat-select');
                  let panelOpened = false;
                  select.addEventListener('click', () => {
                    if (panelOpened)
                      return;
                    panelOpened = true;
                    document.body.insertAdjacentHTML('beforeend',
                      `<div id="offscreen-options" role="listbox"
                            style="position:fixed;left:0;top:2000px;width:200px;height:50px">
                         <div id="farm-building-option" role="option">Farm Building</div>
                       </div>`);
                    select.setAttribute('aria-expanded', 'true');
                    select.setAttribute('aria-controls', 'offscreen-options');
                    select.setAttribute('aria-activedescendant', 'farm-building-option');
                  });
                  select.addEventListener('keydown', event => {
                    if (event.key !== 'Enter'
                        || select.getAttribute('aria-activedescendant') !== 'farm-building-option')
                      return;
                    select.textContent = 'Farm Building';
                    select.setAttribute('aria-expanded', 'false');
                    document.getElementById('offscreen-options').remove();
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("CovBuildingInput.CoverageType", "Farm Building");

            await form.VerifyAsync("CovBuildingInput.CoverageType", "Farm Building");
        }

        [Test]
        public async Task BuildingContents_ScopesDuplicateLabelsToTheReturnedCoverageSection()
        {
            await _page.SetContentAsync("""
                <label>Replacement Cost<select data-testid="fields.building.rows[0].covBuildingInput$replacementCost.value"><option>No</option><option>Yes</option></select></label>
                <input data-testid="fields.contents.rows[3].covBuildingContentsInput$limit.value" value="3000">
                <label>Replacement Cost<select data-testid="fields.contents.rows[3].covBuildingContentsInput$replacementCost.value"><option>No</option><option>Yes</option></select></label>
                """);
            var form = new SFP_NativeFormPage(_page);
            var section = await form.SectionAsync("CovBuildingContentsInput.Limit");
            Assert.That(section, Is.EqualTo("fields.contents.rows[3]"));
            await form.SetSectionAsync(section, "CovBuildingContentsInput.ReplacementCost", "Yes");
            await form.VerifyControlAsync(
                form.SectionField(section, "CovBuildingContentsInput.ReplacementCost"), "Yes");
            Assert.That(await form.Field("CovBuildingInput.ReplacementCost").InputValueAsync(), Is.EqualTo("No"));
        }

        [Test]
        public async Task BuildingContents_VerifiesReplacementCostChipAfterReopen()
        {
            const string section = "fields.contents.rows[3]";
            await _page.SetContentAsync(
                $"<input data-testid='{section}.covBuildingContentsInput$limit.value' value='750000'>"
                + Chips(section + ".covBuildingContentsInput$replacementCost", "No", selected: false)
                + Chips(section + ".covBuildingContentsInput$replacementCost", "Yes"));
            var form = new SFP_NativeFormPage(_page);

            await form.VerifySectionAsync(
                section, "CovBuildingContentsInput.ReplacementCost", "Yes");
        }

        [Test]
        public async Task BuildingCoverage_SelectsReplacementCostByLogicalFieldWithoutLabelAssociation()
        {
            const string section = "fields.building.rows[0]";
            await _page.SetContentAsync(
                Chips(section + ".covBuildingInput$replacementCost", "No")
                + Chips(section + ".covBuildingInput$replacementCost", "Yes", selected: false));
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("CovBuildingInput.ReplacementCost", "Yes");

            await form.VerifyAsync("CovBuildingInput.ReplacementCost", "Yes");
        }

        [Test]
        public async Task ChipSelection_IgnoresTooltipTextThatDuplicatesTheCaption()
        {
            const string field = "fields.building.rows[0].buildingValuatioinInput$valuationType";
            await _page.SetContentAsync(
                Chips(field, "Commercial Valuation")
                + Chips(field, "Agricultural Valuation", selected: false, tooltipOnClick: true));
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("BuildingValuatioinInput.ValuationType", "Agricultural Valuation");

            await form.VerifyAsync("BuildingValuatioinInput.ValuationType", "Agricultural Valuation");
        }

        [Test]
        public async Task ChipSelection_ClicksTheInteractiveChipInsteadOfItsOuterLayoutWrapper()
        {
            const string field = "fields.contents.rows[0].covBuildingContentsInput$coverageType";
            await _page.SetContentAsync($"""
                <div data-testid="{field}.value-chip-item-wrapper">
                  <div data-testid="{field}.value-chip-wrapper" class="chip-wrapper"
                       onclick="this.className='chip-wrapper-selected'">
                    <span data-testid="{field}.value-chip-label" class="chip-label">Farm Contents</span>
                  </div>
                </div>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("CovBuildingContentsInput.CoverageType", "Farm Contents");

            await form.VerifyAsync("CovBuildingContentsInput.CoverageType", "Farm Contents");
        }

        [Test]
        public async Task NativeTypeahead_SelectsAnExactOptionAndVerifiesThePersistedValue()
        {
            await _page.SetContentAsync("""
                <input data-testid="_temp.fields.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value"
                       role="combobox" aria-autocomplete="list" aria-expanded="false">
                <script>
                  const input = document.querySelector('input');
                  input.addEventListener('input', () => {
                    document.getElementById('occupancy-options')?.remove();
                    document.body.insertAdjacentHTML('beforeend',
                      '<div id="occupancy-options" role="listbox"><div role="option">Cattle</div><div role="option">General</div></div>');
                    document.querySelectorAll('#occupancy-options [role="option"]').forEach(option =>
                      option.addEventListener('click', () => {
                        input.value = option.textContent;
                        input.setAttribute('aria-expanded', 'false');
                        document.getElementById('occupancy-options').remove();
                      }));
                    input.setAttribute('aria-expanded', 'true');
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync("BuildingValuatioinInput.BVSOccupancyGroup", "Cattle");

            await form.VerifyAsync("BuildingValuatioinInput.BVSOccupancyGroup", "Cattle");
        }

        [Test]
        public async Task RefreshingTypeahead_BlursAfterOffscreenKeyboardSelectionBeforeWaitingForDuckCreek()
        {
            await _context.RouteAsync(
                "**/api/duckcreek/product",
                route => route.FulfillAsync(new() { Status = 200, ContentType = "application/json", Body = "{}" }));
            await _page.SetContentAsync("""
                <input data-testid="_temp.fields.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value"
                       role="combobox" aria-autocomplete="list" aria-expanded="false">
                <button id="next-field">Next field</button>
                <script>
                  const input = document.querySelector('input');
                  input.addEventListener('input', () => {
                    document.body.insertAdjacentHTML('beforeend',
                      `<div id="occupancy-options" role="listbox"
                            style="position:fixed;left:343px;bottom:-120px;width:900px;height:50px">
                         <div id="general-option" role="option">General</div>
                       </div>`);
                    input.setAttribute('aria-controls', 'occupancy-options');
                    input.setAttribute('aria-expanded', 'true');
                  });
                  input.addEventListener('keydown', event => {
                    if (event.key === 'ArrowDown') {
                      input.setAttribute('aria-activedescendant', 'general-option');
                      window.usedArrowDown = true;
                    }
                    if (event.key === 'Enter'
                        && input.getAttribute('aria-activedescendant') === 'general-option') {
                      input.value = document.getElementById('general-option').textContent;
                      input.setAttribute('aria-expanded', 'false');
                      document.getElementById('occupancy-options').remove();
                      window.usedEnter = true;
                    }
                  });
                  input.addEventListener('blur', () => {
                    window.blurCompleted = true;
                    setTimeout(async () => {
                      await fetch('https://duckcreek.test/api/duckcreek/product', { method: 'POST' });
                      window.refreshCompleted = true;
                    }, 750);
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetRefreshingTypeaheadAsync(
                "BuildingValuatioinInput.BVSOccupancyGroup", "General");

            Assert.That(
                await _page.EvaluateAsync<bool>("() => window.refreshCompleted === true"),
                Is.True);
            Assert.That(await _page.EvaluateAsync<bool>("window.usedArrowDown === true"), Is.True);
            Assert.That(await _page.EvaluateAsync<bool>("window.usedEnter === true"), Is.True);
            Assert.That(await _page.EvaluateAsync<bool>("window.blurCompleted === true"), Is.True);
            Assert.That(
                await _page.EvaluateAsync<string>("() => document.activeElement.id"),
                Is.EqualTo("next-field"));
        }

        [Test]
        public async Task CatalogAndEditorSelection_RetryLostClicksAndWaitForDuckCreekResponses()
        {
            await _context.RouteAsync(
                "**/api/duckcreek/product",
                route => route.FulfillAsync(new() { Status = 200, ContentType = "application/json", Body = "{}" }));
            await _page.SetContentAsync("""
                <table data-testid="coverageTableLiability">
                  <tr>
                    <td>Lessors Risk</td>
                    <td>
                      <input id="lessors" type="checkbox"
                             data-testid="fields.coverages.rows[0].lessorsInput$selected.value">
                      <label for="lessors"
                             data-testid="fields.coverages.rows[0].lessorsInput$selected.value">Select</label>
                    </td>
                  </tr>
                </table>
                <button data-testid="fields.coverages.rows[0].AddEditSpecialFarmPollution"
                        onclick="openEditor()">Add Coverage</button>
                <div id="editor" hidden>
                  Special Farm Pollution editor
                  <button data-testid="fields.coverages.Save">Save</button>
                </div>
                <script>
                  window.catalogClickCount = 0;
                  window.editorClickCount = 0;
                  document.querySelector('label').addEventListener('click', event => {
                    window.catalogClickCount++;
                    if (window.catalogClickCount === 1) {
                      event.preventDefault();
                      return;
                    }
                    setTimeout(async () => {
                      await fetch('https://duckcreek.test/api/duckcreek/product', { method: 'POST' });
                      window.refreshCompleted = true;
                    }, 750);
                  });
                  async function openEditor() {
                    window.editorClickCount++;
                    if (window.editorClickCount === 1) return;
                    await fetch('https://duckcreek.test/api/duckcreek/product', { method: 'POST' });
                    document.getElementById('editor').hidden = false;
                  }
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SelectNamedCatalogCoverageAsync(
                _page.GetByTestId("coverageTableLiability"),
                SFP_NativeFormPage.Caption("Lessors Risk"));

            Assert.That(
                await _page.EvaluateAsync<bool>("() => window.refreshCompleted === true"),
                Is.True);
            Assert.That(
                await _page.EvaluateAsync<int>("() => window.catalogClickCount"),
                Is.EqualTo(2));
            await form.ClickActionAndRequireReadyAsync(
                "AddEditSpecialFarmPollution",
                _page.Locator("#editor").Or(form.Action("Save")));
            Assert.That(
                await _page.EvaluateAsync<int>("() => window.editorClickCount"),
                Is.EqualTo(2));
        }

        [Test]
        public async Task EditorSelection_DoesNotRetryWhenTheFirstDuckCreekRequestIsSlow()
        {
            await _context.RouteAsync(
                "**/api/duckcreek/product",
                async route =>
                {
                    await Task.Delay(5500);
                    await route.FulfillAsync(new()
                    {
                        Status = 200,
                        ContentType = "application/json",
                        Body = "{}"
                    });
                });
            await _page.SetContentAsync("""
                <button data-testid="fields.coverages.rows[0].AddEditSpecialFarmPollution"
                        onclick="openEditor()">Add Coverage</button>
                <div id="editor" hidden>
                  Special Farm Pollution editor
                  <button data-testid="fields.coverages.Save">Save</button>
                </div>
                <script>
                  window.editorClickCount = 0;
                  async function openEditor() {
                    window.editorClickCount++;
                    await fetch('https://duckcreek.test/api/duckcreek/product', { method: 'POST' });
                    document.getElementById('editor').hidden = false;
                  }
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.ClickActionAndRequireReadyAsync(
                "AddEditSpecialFarmPollution",
                _page.Locator("#editor").Or(form.Action("Save")));

            Assert.That(
                await _page.EvaluateAsync<int>("() => window.editorClickCount"),
                Is.EqualTo(1));
            Assert.That(await _page.Locator("#editor").IsVisibleAsync(), Is.True);
        }

        [Test]
        public async Task NativeTypeahead_UsesItsAriaControlledPanelAndClosesItWhenAnotherListboxIsVisible()
        {
            await _page.SetContentAsync("""
                <div id="stale-options" role="listbox"><div role="option">Cattle</div></div>
                <input data-testid="_temp.fields.building.rows[0].buildingValuatioinInput$bVSSearchResult.value"
                       role="combobox" aria-autocomplete="list" aria-expanded="false">
                <script>
                  const input = document.querySelector('input');
                  input.addEventListener('input', () => {
                    document.getElementById('search-options')?.remove();
                    document.body.insertAdjacentHTML('beforeend',
                      '<div id="search-options" role="listbox"><div role="option">120 - Hay Storage, Open One Side</div></div>');
                    input.setAttribute('aria-controls', 'search-options');
                    input.setAttribute('aria-expanded', 'true');
                    document.querySelector('#search-options [role="option"]').addEventListener('click', event => {
                      input.value = event.target.textContent;
                    });
                  });
                  input.addEventListener('keydown', event => {
                    if (event.key !== 'Escape')
                      return;
                    document.getElementById('search-options')?.remove();
                    input.setAttribute('aria-expanded', 'false');
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync(
                "BuildingValuatioinInput.BVSSearchResult", "120 - Hay Storage, Open One Side");

            await form.VerifyAsync(
                "BuildingValuatioinInput.BVSSearchResult", "120 - Hay Storage, Open One Side");
            Assert.That(await _page.Locator("#stale-options").IsVisibleAsync(), Is.True);
            Assert.That(await _page.Locator("#search-options").CountAsync(), Is.Zero);
        }

        [Test]
        public async Task NativeTypeahead_CentersControlBeforeClickingExactOption()
        {
            await _page.SetContentAsync("""
                <div style="height: 2000px"></div>
                <input data-testid="_temp.fields.building.rows[0].buildingValuatioinInput$bVSSearchResult.value"
                       role="combobox" aria-autocomplete="list" aria-expanded="false">
                <div style="height: 1000px"></div>
                <script>
                  const input = document.querySelector('input');
                  input.addEventListener('input', () => {
                    document.getElementById('search-options')?.remove();
                    const bounds = input.getBoundingClientRect();
                    document.body.insertAdjacentHTML('beforeend',
                      `<div id="search-options" role="listbox"
                            style="position:fixed;left:0;top:${bounds.bottom + 4}px;width:250px;height:50px">
                         <div id="implement-shed-option" role="option">601 - Farm Implement Shed</div>
                       </div>`);
                    input.setAttribute('aria-controls', 'search-options');
                    input.setAttribute('aria-expanded', 'true');
                    document.getElementById('implement-shed-option').addEventListener('click', event => {
                      input.value = event.target.textContent;
                      input.setAttribute('aria-expanded', 'false');
                      document.getElementById('search-options').remove();
                    });
                  });
                  input.addEventListener('blur', () => window.typeaheadCommitted = input.value);
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync(
                "BuildingValuatioinInput.BVSSearchResult", "601 - Farm Implement Shed");

            await form.VerifyAsync(
                "BuildingValuatioinInput.BVSSearchResult", "601 - Farm Implement Shed");
            Assert.That(
                await _page.EvaluateAsync<string>("() => window.typeaheadCommitted"),
                Is.EqualTo("601 - Farm Implement Shed"));
        }

        [Test]
        public async Task NativeTypeahead_UsesKeyboardWhenExactOptionIsRenderedOutsideTheViewport()
        {
            await _page.SetContentAsync("""
                <input data-testid="_temp.fields.building.rows[0].buildingValuatioinInput$bVSSearchResult.value"
                       role="combobox" aria-autocomplete="list" aria-expanded="false">
                <script>
                  const input = document.querySelector('input');
                  input.addEventListener('input', () => {
                    document.getElementById('search-options')?.remove();
                    document.body.insertAdjacentHTML('beforeend',
                      `<div id="search-options" role="listbox"
                            style="position:fixed;left:343px;bottom:-120px;width:900px;height:50px">
                         <div id="hay-storage-option" role="option">120 - Hay Storage, Open One Side</div>
                       </div>`);
                    input.setAttribute('aria-controls', 'search-options');
                    input.setAttribute('aria-expanded', 'true');
                  });
                  input.addEventListener('keydown', event => {
                    if (event.key === 'ArrowDown') {
                      input.setAttribute('aria-activedescendant', 'hay-storage-option');
                      window.usedArrowDown = true;
                    }
                    if (event.key === 'Enter'
                        && input.getAttribute('aria-activedescendant') === 'hay-storage-option') {
                      input.value = document.getElementById('hay-storage-option').textContent;
                      input.setAttribute('aria-expanded', 'false');
                      document.getElementById('search-options').remove();
                      window.usedEnter = true;
                    }
                  });
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);

            await form.SetAsync(
                "BuildingValuatioinInput.BVSSearchResult", "120 - Hay Storage, Open One Side");

            await form.VerifyAsync(
                "BuildingValuatioinInput.BVSSearchResult", "120 - Hay Storage, Open One Side");
            Assert.That(await _page.EvaluateAsync<bool>("window.usedArrowDown === true"), Is.True);
            Assert.That(await _page.EvaluateAsync<bool>("window.usedEnter === true"), Is.True);
        }

        [Test]
        public async Task BuildingBvsSearchResult_UsesCurrentNativeSelectWithoutLegacySearchTable()
        {
            await _page.SetContentAsync("""
                <select data-testid="fields.building.rows[0].buildingValuatioinInput$bVSSearchResult.value">
                  <option value="">Select</option>
                  <option value="120">120 - Hay Storage, Open One Side</option>
                  <option value="601">601 - Farm Implement Shed</option>
                </select>
                """);
            var building = new SFP_BuildingPage(_page);

            await building.SelectBvsSearchResultAsync("120 - Hay Storage, Open One Side");

            Assert.That(await _page.Locator("select").InputValueAsync(), Is.EqualTo("120"));
        }

        [Test]
        public async Task BuildingBvsGetValuation_UsesCurrentDevAction()
        {
            await _page.SetContentAsync("""
                <button data-testid="fields.risk.rows[0].covBuilding.rows[0].completeBVSProcess3">
                  Get Valuation
                </button>
                <script>
                  document.querySelector('button').addEventListener('click', () => window.valuationRequested = true);
                </script>
                """);
            var building = new SFP_BuildingPage(_page);

            await building.GetValuationAsync();

            Assert.That(await _page.EvaluateAsync<bool>("window.valuationRequested"), Is.True);
        }

        [Test]
        public async Task BuildingBvsCalculatedValues_RequirePositiveCurrentDevAcvAndRcOutputs()
        {
            await SetBvsCalculatedValuesAsync("35337", "35337");
            var form = new SFP_NativeFormPage(_page);

            await SFP_BuildingPage.RequireCalculatedValuesAsync(form);
        }

        [TestCase("0", "35337")]
        [TestCase("35337", "0")]
        public async Task BuildingBvsCalculatedValues_RejectZeroAcvOrRc(string acv, string rc)
        {
            await SetBvsCalculatedValuesAsync(acv, rc);
            var form = new SFP_NativeFormPage(_page);

            Assert.ThrowsAsync<PlaywrightException>(
                () => SFP_BuildingPage.RequireCalculatedValuesAsync(form));
        }

        [Test]
        public async Task SavedBuilding_ReopensTheButtonWhenItsNestedIconDuplicatesTheTestId()
        {
            const string testId =
                "fields.data.accountDetail.locationDetail.rows[0].building.rows[1].editBuilding";
            await _page.SetContentAsync($"""
                <button data-testid="{testId}" onclick="window.buildingOpened = true">
                  <div data-testid="{testId}">pen icon</div>
                </button>
                """);
            var locations = new SFP_LocationsResidencesBuildingsPage(_page);

            await locations.OpenBuildingAsync(testId);

            Assert.That(await _page.EvaluateAsync<bool>("window.buildingOpened"), Is.True);
        }

        [Test]
        public async Task BuildingSave_ContinuesMetalRoofReviewAndReopensTheNewBuilding()
        {
            const string existingTestId =
                "fields.data.accountDetail.locationDetail.rows[0].building.rows[0].editBuilding";
            const string addedTestId =
                "fields.data.accountDetail.locationDetail.rows[0].building.rows[1].editBuilding";
            await _page.SetContentAsync($"""
                <div role="dialog">
                  <h2>Review Required</h2>
                  <p>11045: Building with Metal Roof requires underwriting review. Location 1 Building 2</p>
                  <button disabled>Review Now</button>
                  <button data-testid="btnConfirmYes" onclick="
                    this.closest('[role=dialog]').remove();
                    document.getElementById('add-building').style.display = 'block';
                    document.body.insertAdjacentHTML('beforeend',
                      '<button data-testid=&quot;{addedTestId}&quot; onclick=&quot;window.openedBuilding = this.dataset.testid&quot;>Edit Building 2</button>');
                  ">Keep Going</button>
                </div>
                <button id="add-building"
                        data-testid="fields.data.accountDetail.locationDetail.rows[0].addBuildingButton"
                        style="display:none">Add Building</button>
                <button data-testid="{existingTestId}">Edit Building 1</button>
                """);
            var locations = new SFP_LocationsResidencesBuildingsPage(_page);
            await locations.ContinueExpectedReviewUntilReadyAsync();
            var buildingCount = await locations.EditBuildingButtons.CountAsync();
            await locations.OpenBuildingAsync(addedTestId);
            var browserOpenedTestId = await _page.EvaluateAsync<string>("window.openedBuilding");
            var dialogCount = await _page.GetByRole(AriaRole.Dialog).CountAsync();

            Assert.Multiple(() =>
            {
                Assert.That(buildingCount, Is.EqualTo(2));
                Assert.That(browserOpenedTestId, Is.EqualTo(addedTestId));
                Assert.That(dialogCount, Is.Zero);
            });
        }

        [TestCase("Farm Contents", "FarmContents")]
        [TestCase("Poultry Contents", "PoultryContents")]
        [TestCase("Private Contents", "PrivateContents")]
        public async Task BuildingContents_SelectsAndVerifiesTheIndependentRequiredType(string caption, string nativeValue)
        {
            await _page.SetContentAsync("""
                <label><input type="checkbox" checked>Building Contents</label>
                <label>Content Type
                  <select data-testid="fields.contents.rows[7].covBuildingContentsInput$coverageType.value" required>
                    <option value="">Select</option><option value="FarmContents">Farm Contents</option>
                    <option value="PoultryContents">Poultry Contents</option><option value="PrivateContents">Private Contents</option>
                  </select>
                </label>
                """);
            var building = new SFP_BuildingPage(_page);
            await building.SelectContentsTypeAsync(caption);
            Assert.That(await _page.Locator("select").InputValueAsync(), Is.EqualTo(nativeValue));
            await building.VerifyContentsTypeAsync(caption);
        }

        [TestCase("PrivateContents")]
        [TestCase("")]
        [TestCase(null)]
        public async Task BuildingContents_RejectsWrongEmptyOrMissingPersistedTypeDespiteTheCheckboxCaption(string actual)
        {
            await _page.SetContentAsync("""
                <label><input type="checkbox" checked>Farm Contents</label>
                <label>Content Type<select data-testid="fields.contents.rows[7].covBuildingContentsInput$coverageType.value">
                  <option value="">Select</option><option value="FarmContents">Farm Contents</option>
                  <option value="PrivateContents">Private Contents</option>
                </select></label>
                """);
            if (actual == null)
                await _page.Locator("select").EvaluateAsync("element => element.remove()");
            else
                await _page.Locator("select").SelectOptionAsync(actual);
            Assert.ThrowsAsync<PlaywrightException>(() => new SFP_BuildingPage(_page).VerifyContentsTypeAsync("Farm Contents"));
        }

        [TestCase("Brick", "Brick/Stone/Masonry")]
        [TestCase("Metal", "Aluminum/Steel/Engineered Steel/All Metal")]
        public void BuildingConstruction_UsesCurrentDevCaption(string scenarioValue, string nativeCaption) =>
            Assert.That(SFP_BuildingPage.NativeConstructionCaption(scenarioValue), Is.EqualTo(nativeCaption));

        [TestCase("Concrete", "Concrete, Composition Wood Fiber/Cement")]
        [TestCase("Metal", "Metal")]
        public void BuildingRoof_UsesCurrentDevCaption(string scenarioValue, string nativeCaption) =>
            Assert.That(SFP_BuildingPage.NativeRoofCaption(scenarioValue), Is.EqualTo(nativeCaption));

        [TestCase("Storage Building", "712 - Storage Building")]
        [TestCase("Equipment Shed", "160 - Equipment Shed")]
        public void BuildingDescriptionCode_UsesCurrentDevCaption(string scenarioValue, string nativeCaption) =>
            Assert.That(SFP_BuildingPage.NativeDescriptionCodeCaption(scenarioValue), Is.EqualTo(nativeCaption));

        [Test]
        public async Task RetailCoverage_SavesAndReopensDistinctOnOffRecordsWithoutOverwritingOnPremises()
        {
            await CreateRetailEditorAsync();
            var liability = new SFP_LiabilityOptionalCoveragePage(_page);
            await liability.EditAsync(ScenarioValues("CoverageName", "Retail Sales On Premises"));
            await liability.EditAsync(ScenarioValues("CoverageName", "Retail Sales Off Premises"));
            Assert.That(await _page.EvaluateAsync<string[]>("""
                [records.on.total, records.on.percent, records.on.others, records.on.description, records.on.location,
                 records.off.total, records.off.percent, records.off.others, records.off.description]
                """), Is.EqualTo(new[] { "15000", "20", "1", "CLOTHING", "location-node-18", "5000", "10", "1", "CLOTHING" }));
            Assert.That(await _page.EvaluateAsync<int>("saveCount"), Is.EqualTo(4));
            Assert.That(await _page.EvaluateAsync<int>("reviewCount"), Is.EqualTo(4));
            Assert.That(await _page.GetByTestId("coverageTableLiability").IsVisibleAsync(), Is.True);
        }

        [TestCase("class", "Off-Premises")]
        [TestCase("overwrite", "TotalSalesOnPremise")]
        [TestCase("computed", "499")]
        public async Task RetailCoverage_RejectsIncorrectPersistedCodesValuesOrComputedSales(string failure, string field)
        {
            await CreateRetailEditorAsync();
            await _page.EvaluateAsync("failure => window.retailFailure = failure", failure);
            var liability = new SFP_LiabilityOptionalCoveragePage(_page);
            await liability.EditAsync(ScenarioValues("CoverageName", "Retail Sales On Premises"));
            var error = Assert.ThrowsAsync<PlaywrightException>(() =>
                liability.EditAsync(ScenarioValues("CoverageName", "Retail Sales Off Premises")));
            Assert.That(error!.Message, Does.Contain(field));
            if (failure == "class")
                Assert.That(error.Message, Does.Contain("10010").And.Contain("10030"));
            Assert.That(await _page.EvaluateAsync<int>("saveCount"),
                Is.EqualTo(failure == "class" ? 2 : 3));
        }

        [Test]
        public async Task Machinery_UsesNativeFieldsAndMapsNoSpecialUseToNone()
        {
            const string path = "fields.machinery.rows[4].";
            await _page.SetContentAsync("""
                <input data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$limit.value">
                <select data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$deductible.value"><option value="1000">$1,000</option></select>
                <label>Year<input type="number" data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$year.value"></label>
                <label>Make<input data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$make.value"></label>
                <label>Model<input data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$model.value"></label>
                <label>Serial Number<input data-testid="fields.machinery.rows[4].covSpecificFarmMachineryInput$serialNumber.value"></label>
                <p>Special Use Percentage of Equipment</p>
                """ + Chips(path + "covSpecificFarmMachineryInput$specialUse", "100%")
                + Chips(path + "covSpecificFarmMachineryInput$specialUse", "None", selected: false)
                + "<p>Cab Glass</p>" + Chips(path + "covSpecificFarmMachineryInput$tractorGlass", "No")
                + Chips(path + "covSpecificFarmMachineryInput$tractorGlass", "Yes", selected: false));
            var values = ScenarioValues("Code", "472");
            var machinery = new SFP_FarmPersonalPropertyPage(_page);
            await machinery.ApplyMachineryAsync(values, verifyOnly: false);
            await machinery.ApplyMachineryAsync(values, verifyOnly: true);
            await new SFP_NativeFormPage(_page).VerifyAsync("CovSpecificFarmMachineryInput.SpecialUse", "None");
            values["SpecialUse"] = "Yes";
            Assert.ThrowsAsync<ArgumentException>(() => machinery.ApplyMachineryAsync(values, verifyOnly: false));
        }

        [Test]
        public async Task Jewelry_SelectsNativeStoneBeforeTheConditionalCaratAndCutDropdowns()
        {
            const string path = "fields.jewelry.rows[2].";
            await _page.SetContentAsync("""
                <input data-testid="fields.jewelry.rows[2].covEndorsementsInput$description.value">
                <input data-testid="fields.jewelry.rows[2].covEndorsementsInput$limit.value">
                <input type="number" data-testid="fields.jewelry.rows[2].covEndorsementsInput$yearOfLastAppraisal.value">
                <label>Type of Stone<select data-testid="fields.jewelry.rows[2].covJewelryInput$typeOfStone.value"
                  onchange="document.getElementById('stone-details').hidden=this.value==='Pearl'">
                  <option>Pearl</option><option>Diamond</option></select></label>
                <div id="stone-details" hidden>
                  <label>Carat<select data-testid="fields.jewelry.rows[2].covJewelryInput$carat.value"><option>1</option></select></label>
                  <label>Cut<select data-testid="fields.jewelry.rows[2].covJewelryInput$cut.value"><option>Oval</option></select></label>
                </div>
                <select data-testid="fields.jewelry.rows[2].covJewelryInput$typeOfJewelry.value"><option>Ring</option></select>
                """ + Chips(path + "covJewelryInput$vaultCredit", "No")
                + Chips(path + "covJewelryInput$vaultCredit", "Yes", selected: false)
                + Chips(path + "covJewelryInput$gemPrint", "Yes"));
            var jewelry = new SFP_ScheduledPersonalPropertyPage(_page);
            var values = ScenarioValues("Category", "407");
            await jewelry.ApplyRatePolicyItemAsync(values, verifyOnly: false);
            await jewelry.ApplyRatePolicyItemAsync(values, verifyOnly: true);
            Assert.That(await _page.Locator("#stone-details").IsVisibleAsync(), Is.True);
        }

        [Test]
        public async Task AutoTrailer_UsesNativeIdsWithTheActualLongQuestionCaptions()
        {
            const string path = "fields.trailer.rows[6].";
            await _page.SetContentAsync("""
                <input data-testid="fields.trailer.rows[6].covEndorsementsInput$description.value">
                <input data-testid="fields.trailer.rows[6].covEndorsementsInput$limit.value">
                <label>To extend coverage to a named person who permanently resides with the insured, select the number of named persons.
                  <select data-testid="fields.trailer.rows[6].covAutoTrailerHomePersonalEffectsInput$namedPerson.value">
                    <option>None</option><option>1</option></select>
                </label>
                <label>Please list all Named Persons this coverage will apply to.
                  <input data-testid="fields.trailer.rows[6].covAutoTrailerHomePersonalEffectsInput$name.value">
                </label>
                <p>Would the client like a Limited Peril applied to this coverage?</p>
                """ + Chips(path + "covAutoTrailerHomePersonalEffectsInput$limitPeril", "No")
                + "<p>Would the client like to extend coverage to Professional Entertainers?</p>"
                + Chips(path + "covAutoTrailerHomePersonalEffectsInput$professionalEntertainer", "No")
                + "<p>Would the client like to extend this coverage for theft of property from an unattended vehicle?</p>"
                + Chips(path + "covAutoTrailerHomePersonalEffectsInput$unattendedVehicles", "Yes"));
            var trailer = new SFP_ScheduledPersonalPropertyPage(_page);
            var values = ScenarioValues("Category", "411");
            await trailer.ApplyRatePolicyItemAsync(values, verifyOnly: false);
            await trailer.ApplyRatePolicyItemAsync(values, verifyOnly: true);
        }

        [TestCase(
            "Special Farm Pollution",
            "Livestock Operations Special Farm Pollution Liability",
            "CovLivestockOperationsSpecialFarmPollutionInput",
            "100")]
        [TestCase(
            "Chemical Drift and Transportation Increased Limits",
            "Farm Chemical Transportation/Farm Chemical Drift",
            "CovFarmChemTransportationDriftInput",
            "75")]
        public async Task LiabilityAcreage_VerifiesTheSharedComputedValueAndRejectsTheOriginalConflictingExpectation(
            string coverage, string catalogCaption, string entity, string conflictingAcres)
        {
            Assert.That(
                SFP_LiabilityOptionalCoveragePage.CatalogCaption(coverage).IsMatch(catalogCaption),
                Is.True);
            var values = ScenarioValues("CoverageName", coverage);
            const string options = "$50,000 / $100,000";
            await _page.SetContentAsync($"""
                <label>Occurrence/Aggregate Limit<select data-testid="fields.optional.rows[5].{entity}$OccurrenceAggregateLimit.value">
                  <option value="native-limit">{options}</option></select></label>
                <div id="{entity}.NumberOfAcresUsed-0-layout" class="readonly-field">
                  <span class="readonly-label">Number of acres used in operation (owned &amp; leased):</span>
                  <span class="readonly-value">200.00</span>
                </div>
                <label>On site (liquid or solid) manure storage
                  <select data-testid="fields.optional.rows[5].{entity}$OnSiteManureStorage.value"
                    onchange="document.getElementById('manure-capacity').hidden=this.value!=='1'">
                    <option value="0">No</option><option value="1">Yes</option></select>
                </label>
                <label>Total capacity (# of gallons) of all on-site liquid manure storage
                  <input id="manure-capacity" hidden type="number"
                    data-testid="fields.optional.rows[5].{entity}$TotalCapacityOfManureStorage.value">
                </label>
                <label>Maximum Number of Miles between your facility and the furthest insured location
                  <input type="number" data-testid="fields.optional.rows[5].{entity}$MaximumNumberOfMiles.value">
                </label>
                <label>Number of trips transporting waste per year
                  <input type="number" data-testid="fields.optional.rows[5].{entity}$NumberOfTrips.value">
                </label>
                <select data-testid="fields.questions.SpecialFarmPollutionQuestionsInput$PriorIncidencesOfPollutionClaims.value">
                  <option value="1">Yes</option><option value="0">No</option>
                </select>
                <select data-testid="fields.questions.SpecialFarmPollutionQuestionsInput$ClientAppliesHumanWaste.value">
                  <option value="1">Yes</option><option value="0">No</option>
                </select>
                <select data-testid="fields.questions.SpecialFarmPollutionQuestionsInput$RiskWithin1_2Mile.value">
                  <option value="1">Yes</option><option value="0">No</option>
                </select>
                <select data-testid="fields.questions.SpecialFarmPollutionQuestionsInput$RiskWithin1_4Mile.value">
                  <option value="1">Yes</option><option value="0">No</option>
                </select>
                <input id="chemical-none-above" type="checkbox"
                  data-testid="fields.questions.FarmChemTransportationDriftQuestionsInput$EqNoneAbove.value">
                <label for="chemical-none-above"
                  data-testid="fields.questions.FarmChemTransportationDriftQuestionsInput$EqNoneAbove.value">
                  None of the Above
                </label>
                """);
            var liability = new SFP_LiabilityOptionalCoveragePage(_page);
            await liability.ApplyAcreageCoverageAsync(values);
            values["Acres"] = conflictingAcres;
            var error = Assert.ThrowsAsync<PlaywrightException>(() => liability.ApplyAcreageCoverageAsync(values));
            Assert.That(error!.Message, Does.Contain("read-only").And.Contain(conflictingAcres));
            Assert.That(
                (await new SFP_NativeFormPage(_page)
                    .ReadOnlyValue(entity + ".NumberOfAcresUsed").InnerTextAsync()).Trim(),
                Is.EqualTo("200.00"));
            if (coverage == "Chemical Drift and Transportation Increased Limits")
                Assert.That(await _page.Locator("#chemical-none-above").IsCheckedAsync(), Is.True);
        }

        [Test]
        public async Task RetailLocation_SelectsExactlyTheRequestedLocationAndClosesTheMultiselect()
        {
            await _page.SetContentAsync("""
                <mat-select tabindex="0" data-testid="fields.sales.rows[0].salesLocationInput$location.value"
                  onclick="document.getElementById('choices').hidden=false"
                  onkeydown="if(event.key==='Escape') document.getElementById('choices').hidden=true">
                  <span class="mat-select-value-text">2</span>
                </mat-select>
                <div id="choices" role="listbox" aria-multiselectable="true" hidden>
                  <div role="option" aria-selected="false" onclick="choose(this)">1</div>
                  <div role="option" aria-selected="true" onclick="choose(this)">2</div>
                </div>
                <script>
                  function choose(option) {
                    option.setAttribute('aria-selected', option.getAttribute('aria-selected') === 'true' ? 'false' : 'true');
                    document.querySelector('.mat-select-value-text').textContent =
                      [...document.querySelectorAll('[role=option][aria-selected=true]')].map(item => item.textContent).join(', ');
                  }
                </script>
                """);
            var form = new SFP_NativeFormPage(_page);
            await form.SetAsync("SalesLocationInput.Location", "1");
            await form.SetAsync("SalesLocationInput.Location", "1");
            Assert.That(await _page.Locator("#choices").IsVisibleAsync(), Is.False);
            Assert.That(await _page.GetByRole(AriaRole.Option, new() { IncludeHidden = true, Name = "1", Exact = true })
                .GetAttributeAsync("aria-selected"), Is.EqualTo("true"));
            Assert.That(await _page.GetByRole(AriaRole.Option, new() { IncludeHidden = true, Name = "2", Exact = true })
                .GetAttributeAsync("aria-selected"), Is.EqualTo("false"));
        }

        [Test]
        public async Task LiabilityLimit_MatchesTheFormattedCaptionWithoutAssumingAnOptionValue()
        {
            await _page.SetContentAsync("""
                <select><option value="unrelated">$100,000 / $300,000</option>
                <option value="returned-by-server">$100,000 / $100,000</option></select>
                """);
            await new SFP_NativeFormPage(_page).SelectAsync(_page.Locator("select"), "100000/100000", moneyOption: true);
            Assert.That(await _page.Locator("select").InputValueAsync(), Is.EqualTo("returned-by-server"));
        }

        [Test]
        public async Task NativeSelect_MatchesAnIndexedCaptionWithAServerAppendedDescription()
        {
            await _page.SetContentAsync("""
                <select>
                  <option value="location-10">Location #10 - Secondary Location</option>
                  <option value="location-1">Location #1 - Primary Location</option>
                </select>
                """);
            var caption = new System.Text.RegularExpressions.Regex(
                @"^\s*Location\s+\#1(?:\s+-\s+.*)?\s*$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            await new SFP_NativeFormPage(_page).SelectAsync(_page.Locator("select"), caption);

            Assert.That(await _page.Locator("select").InputValueAsync(), Is.EqualTo("location-1"));
        }

        [Test]
        public async Task AmbiguousFields_AreNotResolvedByTheirOrderOrMatchingBodyText()
        {
            await _page.SetContentAsync("""
                <p>100000</p>
                <input data-testid="fields.one.coverageInput$limit.value" value="0">
                <input data-testid="fields.two.coverageInput$limit.value" value="0">
                """);
            var form = new SFP_NativeFormPage(_page);
            Assert.ThrowsAsync<PlaywrightException>(() => form.SetAsync("CoverageInput.Limit", "100000", number: true));
            Assert.That(await _page.GetByTestId("fields.one.coverageInput$limit.value").InputValueAsync(), Is.EqualTo("0"));
            Assert.That(await _page.GetByTestId("fields.two.coverageInput$limit.value").InputValueAsync(), Is.EqualTo("0"));
        }

        [Test]
        public async Task MissingFields_DoNotPassJustBecauseTheRequestedValueIsDisplayedElsewhere()
        {
            await _page.SetContentAsync("<p>100000</p>");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                new SFP_NativeFormPage(_page).SetAsync("CoverageInput.Limit", "100000", number: true));
        }

        [TestCase("0")]
        [TestCase("")]
        public async Task CalculatedValuation_RejectsZeroOrEmptyEvenWhenTheButtonCompleted(string value)
        {
            await _page.SetContentAsync($"<input value='{value}'>");
            Assert.ThrowsAsync<PlaywrightException>(() =>
                SfpFieldAssertions.PositiveAmountAsync(_page.Locator("input"), "ACV", timeoutMs: 200));
        }

        [Test]
        public async Task Category411_UnattendedVehiclesCannotUpdateCategory409()
        {
            await _page.SetContentAsync(
                Chips("fields.stamps.rows[0].covStampCollectionsInput$unattendedVehicle", "No")
                + Chips("fields.trailer.rows[0].covAutoTrailerHomePersonalEffectsInput$unattendedVehicles", "Yes"));
            var form = new SFP_NativeFormPage(_page);
            await form.SetAsync("CovAutoTrailerHomePersonalEffectsInput.UnattendedVehicles", "Yes");
            await form.VerifyAsync("CovStampCollectionsInput.UnattendedVehicle", "No");
            await form.VerifyAsync("CovAutoTrailerHomePersonalEffectsInput.UnattendedVehicles", "Yes");
        }

        [Test]
        public async Task Billing_CompletesTheLiveRatePolicyControlContract()
        {
            await _page.SetContentAsync("""
                <div data-testid="fields.payment._PolicyPaymentInputDoc$BillingCenterAccount.value">
                  <div data-testid="fields.payment._PolicyPaymentInputDoc$BillingCenterAccount.value-new-account-chip-wrapper"
                       onclick="this.querySelector('.chip-wrapper').className='chip-wrapper-selected'">
                    <div class="chip-wrapper"><span class="chip-label">Create New Billing Account</span></div>
                  </div>
                </div>
                <button data-testid="fields.payment.subsequentPaymentData$payerID.value-0"
                        onclick="this.setAttribute('aria-checked','true')">PWJOSHUA RATE RATETAYLOR<br>1993-01-19</button>
                <div data-testid="fields.payment.subsequentPaymentData$paymentMethod.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">Easy Pay</span></div>
                </div>
                <div data-testid="fields.payment.subsequentBankData$existingDraftAccount.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">New Account</span></div>
                </div>
                <div data-testid="fields.payment.subsequentBankData$accountUse.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">Personal</span></div>
                </div>
                <div data-testid="fields.payment.subsequentBankData$accountType.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">Checking</span></div>
                </div>
                <button data-testid="fields.payment.subsequentBankData$accountOwnerSelect.value-0"
                        onclick="this.setAttribute('aria-checked','true')">PWJOSHUA RATE RATETAYLOR<br>1993-01-19</button>
                <input data-testid="fields.payment.subsequentBankData$routingNumber.value">
                <input data-testid="fields.payment.subsequentBankData$accountNumber.value">
                <input data-testid="fields.payment.subsequentBankData$name.value">
                <div data-testid="fields.payment.subsequentPaymentData$paymentPlan.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">12 Payments</span></div>
                </div>
                <input data-testid="fields.payment.subsequentPaymentData$dueDate.value">
                <mat-radio-button data-testid="fields.payment.initialPaymentData$amountSelection.value-0"
                                  onclick="this.querySelector('input').checked=true">
                  <input type="radio" value="Min">
                  <label>$1,731.03 (Minimum Payment)</label>
                </mat-radio-button>
                <div data-testid="fields.payment.initialPaymentData$paymentMethod.value-chip-item-wrapper"
                     onclick="this.firstElementChild.className='chip-wrapper-selected'">
                  <div class="chip-wrapper"><span class="chip-label">Check</span></div>
                </div>
                <input data-testid="fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value">
                <button data-testid="fields.data-Next.next"
                        onclick="document.body.dataset.nextClicked='true'">Next: Submission</button>
                """);

            var values = new Dictionary<string, string>
            {
                ["BillingAccount"] = "Create New",
                ["PrimaryPayer"] = "Primary Insured",
                ["PaymentType"] = "Easy Pay",
                ["RoutingNumber"] = "021000021",
                ["AccountNumber"] = "123456789",
                ["BankName"] = "Test Bank",
                ["PaymentPlan"] = "12 Payments",
                ["PaymentDueDate"] = "01",
                ["PaymentAmount"] = "Minimum",
                ["PaymentMethod"] = "Check"
            };
            var data = new ScenarioContextData
            {
                ClientFirstName = "PW Joshua",
                ClientMiddleName = "Rate",
                ClientLastName = "Rate Taylor"
            };

            await new SFP_BillingInformationPage(_page).CompleteRatePolicyBillingAsync(data, values);

            Assert.That(await _page.GetByTestId(
                "fields.payment._PolicyPaymentInputDoc$BillingCenterAccount.value-new-account-chip-wrapper")
                .Locator(".chip-wrapper-selected").CountAsync(), Is.EqualTo(1));
            Assert.That(await _page.GetByTestId("fields.payment.subsequentPaymentData$payerID.value-0")
                .GetAttributeAsync("aria-checked"), Is.EqualTo("true"));
            Assert.That(await _page.GetByTestId("fields.payment.subsequentBankData$routingNumber.value")
                .InputValueAsync(), Is.EqualTo("021000021"));
            Assert.That(await _page.GetByTestId("fields.payment.subsequentBankData$accountNumber.value")
                .InputValueAsync(), Is.EqualTo("123456789"));
            Assert.That(await _page.GetByTestId("fields.payment.subsequentBankData$name.value")
                .InputValueAsync(), Is.EqualTo("Test Bank"));
            Assert.That(await _page.GetByTestId("fields.payment.initialPaymentData$amountSelection.value-0")
                .Locator("input").IsCheckedAsync(), Is.True);
            Assert.That(await _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value")
                .InputValueAsync(), Is.Not.Empty);
            Assert.That(await _page.GetAttributeAsync("body", "data-next-clicked"), Is.EqualTo("true"));
        }

        [Test]
        public async Task Submission_ChecklistAcknowledgement_PreservesExpectedReferralState()
        {
            await _page.SetContentAsync("""
                <div role="dialog">
                  <p>Checklist Opened</p>
                  <button onclick="this.parentElement.remove()">Update</button>
                </div>
                <div>STATUS: REFERRAL NEEDED</div>
                """);

            await new SubmissionPage(_page).AcknowledgeChecklistUpdateAsync(expectReferralRequired: true);

            Assert.That(await _page.GetByText("STATUS: REFERRAL NEEDED").CountAsync(), Is.EqualTo(1));
            Assert.That(await _page.GetByRole(AriaRole.Dialog).CountAsync(), Is.Zero);
        }

        [Test]
        public async Task ChecklistException_WaitsForApplyChangesAndDoesNotAddDuplicateGeneralNote()
        {
            const string html = """
                <!doctype html>
                <html>
                <body>
                  <a href="#" class="js-checklist-summary-item">Residence Photo #1</a>
                  <ul>
                    <li class="js-current-item">
                      <span>Residence Photo #1</span>
                      <span class="icons"></span>
                    </li>
                    <li class="js-current-item">
                      <span>Loss Runs (Tiered - 5 Years; Not tiered - 3 years)</span>
                    </li>
                  </ul>
                  <div id="checklist-details" style="display:none">
                    <button class="js-exception">Exception</button>
                    <textarea class="js-note"></textarea>
                    <button class="js-add-note">Add Note</button>

                    <div id="exception-note" class="modal fade" aria-hidden="true" style="display:none">
                      <div class="js-exception-note-text">
                        <textarea></textarea>
                      </div>
                      <button id="exception-note-confirm" disabled>OK</button>
                    </div>
                  </div>

                  <div id="apply-changes-modal" class="modal fade" aria-hidden="true" style="display:none">
                    Applying Changes...
                  </div>

                  <script>
                    const row = document.querySelector('.js-checklist-summary-item');
                    const details = document.getElementById('checklist-details');
                    const exceptionButton = document.querySelector('.js-exception');
                    const exceptionModal = document.getElementById('exception-note');
                    const exceptionNote = document.querySelector('.js-exception-note-text textarea');
                    const exceptionConfirm = document.getElementById('exception-note-confirm');
                    const applyChanges = document.getElementById('apply-changes-modal');
                    const addNote = document.querySelector('.js-add-note');
                    const savedItem = document.querySelector('li.js-current-item');

                    window.generalNoteClicks = 0;

                    row.addEventListener('click', event => {
                      event.preventDefault();
                      details.style.display = 'block';
                    });

                    exceptionButton.addEventListener('click', () => {
                      document.body.classList.add('modal-open');
                      exceptionModal.className = 'modal fade in';
                      exceptionModal.style.display = 'block';
                      exceptionModal.setAttribute('aria-hidden', 'false');
                    });

                    const enableExceptionConfirm = () => {
                      exceptionConfirm.disabled = exceptionNote.value.trim().length === 0;
                    };
                    exceptionNote.addEventListener('input', enableExceptionConfirm);
                    exceptionNote.addEventListener('keyup', enableExceptionConfirm);

                    exceptionConfirm.addEventListener('click', () => {
                      row.dataset.exceptionNote = exceptionNote.value;
                      exceptionModal.className = 'modal fade';
                      exceptionModal.setAttribute('aria-hidden', 'true');
                      applyChanges.className = 'modal fade in';
                      applyChanges.style.display = 'block';
                      applyChanges.setAttribute('aria-hidden', 'false');

                      setTimeout(() => {
                        exceptionModal.style.display = 'none';
                      }, 25);

                      setTimeout(() => {
                        applyChanges.className = 'modal fade';
                        applyChanges.style.display = 'none';
                        applyChanges.setAttribute('aria-hidden', 'true');
                        document.body.classList.remove('modal-open');
                        savedItem.querySelector('.icons').innerHTML =
                          '<i data-original-title="Document Attached" style="display:inline-block;width:10px;height:10px"></i>' +
                          '<i data-original-title="Notes" style="display:inline-block;width:10px;height:10px"></i>';
                        details.dataset.autoAdvanced = 'true';
                        row.dataset.applyFinished = 'true';
                      }, 200);
                    });

                    addNote.addEventListener('click', () => {
                      window.generalNoteClicks += 1;
                    });
                  </script>
                </body>
                </html>
                """;

            await _page.RouteAsync("https://test.anpac.info/EChecklist/**", route =>
                route.FulfillAsync(new() { Body = html, ContentType = "text/html" }));
            await _page.GotoAsync("https://test.anpac.info/EChecklist/Viewing/offline-test");

            await new SFP_ChecklistPage(_page).CompleteChecklistItemAsync(
                "Residence Photo #1",
                "Exception",
                "Photo not available",
                "Photo not available");

            var row = _page.Locator("a.js-checklist-summary-item");
            Assert.That(await row.GetAttributeAsync("data-exception-note"), Is.EqualTo("Photo not available"));
            Assert.That(await row.GetAttributeAsync("data-apply-finished"), Is.EqualTo("true"));
            Assert.That(await _page.EvaluateAsync<int>("window.generalNoteClicks"), Is.Zero);
            Assert.That(await _page.Locator("#apply-changes-modal").IsVisibleAsync(), Is.False);
            Assert.That(await _page.Locator("#checklist-details").IsVisibleAsync(), Is.True);
            Assert.That(await _page.Locator("#checklist-details")
                .GetAttributeAsync("data-auto-advanced"), Is.EqualTo("true"));
            Assert.That(await _page.Locator("li.js-current-item")
                .Filter(new() { HasText = "Residence Photo #1" })
                .Locator("i[data-original-title='Notes']").CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task ReviewRequired_IsReportedInsteadOfClickingKeepGoing()
        {
            await _page.SetContentAsync("""
                <div role="dialog"><h2>Review Required</h2>
                <p>10943: Calculated Value must be greater than zero.</p>
                <button onclick="window.bypassed=true">KEEP GOING</button></div>
                """);
            var error = Assert.ThrowsAsync<PlaywrightException>(() =>
                new SFP_NativeFormPage(_page).RequireReadyAsync(_page.GetByRole(AriaRole.Button, new() { Name = "Add Building" })));
            Assert.That(error!.Message, Does.Contain("10943"));
            Assert.That(await _page.EvaluateAsync<bool>("window.bypassed === true"), Is.False);
        }

        [Test]
        public async Task ReviewRequired_ContinuesToExpectedDestinationWhenAngularLayerOccludesKeepGoing()
        {
            await _page.SetContentAsync("""
                <div role="dialog" style="position:relative;width:500px;height:200px">
                  <h2>Review Required</h2>
                  <button data-testid="btnConfirmYes"
                          style="position:absolute;left:300px;top:120px"
                          onclick="
                            this.closest('[role=dialog]').remove();
                            document.getElementById('coverage-table').style.display = 'block';
                          ">Keep Going</button>
                  <ng-component style="position:absolute;inset:0;z-index:2"></ng-component>
                </div>
                <div id="coverage-table" style="display:none">Liability coverages</div>
                """);

            var destination = _page.Locator("#coverage-table");
            await new SFP_NativeFormPage(_page)
                .ContinueReviewAndRequireReadyAsync(destination);

            var dialogCount = await _page.GetByRole(AriaRole.Dialog).CountAsync();
            var destinationVisible = await destination.IsVisibleAsync();
            Assert.Multiple(() =>
            {
                Assert.That(dialogCount, Is.Zero);
                Assert.That(destinationVisible, Is.True);
            });
        }

        [Test]
        public async Task ReviewRequired_DoesNotBypassAnEnabledReviewNowCorrection()
        {
            await _page.SetContentAsync("""
                <div role="dialog">
                  <h2>Review Required</h2>
                  <p>10943: Calculated Value must be greater than zero.</p>
                  <button>Review Now</button>
                  <button data-testid="btnConfirmYes"
                          onclick="window.bypassed=true">Keep Going</button>
                </div>
                <div id="coverage-table" style="display:none">Liability coverages</div>
                """);

            var error = Assert.ThrowsAsync<PlaywrightException>(() =>
                new SFP_NativeFormPage(_page)
                    .ContinueReviewAndRequireReadyAsync(_page.Locator("#coverage-table")));

            Assert.That(error!.Message, Does.Contain("10943"));
            Assert.That(await _page.EvaluateAsync<bool>("window.bypassed === true"), Is.False);
            Assert.That(await _page.GetByRole(AriaRole.Dialog).IsVisibleAsync(), Is.True);
        }

        [Test]
        public async Task ResidenceContentsSave_ContinuesExpectedReviewToLocations()
        {
            await _page.SetContentAsync("""
                <div role="dialog" style="position:relative;width:500px;height:200px">
                  <h2>Review Required</h2>
                  <p>Some fields require your attention before you can transmit this quote.</p>
                  <button disabled>Review Now</button>
                  <button data-testid="btnConfirmYes"
                          onclick="
                            this.closest('[role=dialog]').remove();
                            document.querySelector('button[data-testid]').style.display = 'block';
                          ">Keep Going</button>
                </div>
                <button data-testid="fields.data.accountDetail.locationDetail.rows[0].addBuildingButton"
                        style="display:none">Add Building</button>
                """);

            var locations = new SFP_LocationsResidencesBuildingsPage(_page);
            await locations.ContinueExpectedReviewUntilReadyAsync();

            var dialogCount = await _page.GetByRole(AriaRole.Dialog).CountAsync();
            var addBuildingVisible = await locations.AddBuildingButton().IsVisibleAsync();
            Assert.Multiple(() =>
            {
                Assert.That(dialogCount, Is.Zero);
                Assert.That(addBuildingVisible, Is.True);
            });
        }

        [Test]
        public async Task PriorInsurance_EntersTheSuppliedDateWithoutMovingItToTheEffectiveDate()
        {
            await _page.SetContentAsync("""
                <input id="fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value">
                """);
            await new ClaimsPriorInsurancePage(_page).EnterPriorInsuranceExpirationAsync("1/1/2025");
            Assert.That(await _page.Locator("input").InputValueAsync(), Is.EqualTo("01/01/2025"));
        }

        [Test]
        public async Task PriorInsurance_WaitsForCarrierRefreshBeforeEnteringExpirationDate()
        {
            await _page.SetContentAsync("""
                <div class="ngx-spinner-overlay" style="display: none"></div>
                <input data-testid="fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value"
                       onblur="
                         const spinner = document.querySelector('.ngx-spinner-overlay');
                         spinner.style.display = 'block';
                         window.carrierSettled = false;
                         setTimeout(() => {
                           window.carrierSettled = true;
                           spinner.style.display = 'none';
                         }, 100);">
                <input id="fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value"
                       onblur="if (!window.carrierSettled) this.value = '';">
                """);
            var page = new ClaimsPriorInsurancePage(_page);
            await page.EnterPriorInsuranceCarrierAsync("GEICO");
            await page.EnterPriorInsuranceExpirationAsync("1/1/2025");

            Assert.That(
                await _page.Locator("[id$='priorInsuranceLatestExpirationDate.value']").InputValueAsync(),
                Is.EqualTo("01/01/2025"));
        }

        [Test]
        public async Task Location_UsesCurrentRegularChipsControlForLocationType()
        {
            await _page.SetContentAsync("""
                <input data-testid="fields.data.account.location.rows[0].locationInput$additionalDescription.value">
                <div data-testid="fields.data.account.location.rows[0].locationOutput$locationType.value">
                  <div data-testid="fields.data.account.location.rows[0].locationOutput$locationType.value-chip-item-wrapper"
                       onclick="selectLocationType(this)"><div class="chip-wrapper-selected">Property</div></div>
                  <div data-testid="fields.data.account.location.rows[0].locationOutput$locationType.value-chip-item-wrapper"
                       onclick="selectLocationType(this)"><div class="chip-wrapper">Liability</div></div>
                  <div data-testid="fields.data.account.location.rows[0].locationOutput$locationType.value-chip-item-wrapper"
                       onclick="selectLocationType(this)"><div class="chip-wrapper">Both</div></div>
                </div>
                <input data-testid="fields.data.account.location.rows[0].locationInput$milesFromFireDepartment.value">
                <select data-testid="fields.data.account.location.rows[0].locationInput$feetFromHydrant.value">
                  <option>0-100</option><option>101-250</option>
                </select>
                <input data-testid="fields.data.account.location.rows[0].locationInput$acreage.value">
                <script>
                  function selectLocationType(choice) {
                    document.querySelectorAll("[data-testid$='.LocationOutput$LocationType.value-chip-item-wrapper' i] > div")
                      .forEach(item => item.className = 'chip-wrapper');
                    choice.firstElementChild.className = 'chip-wrapper-selected';
                  }
                </script>
                """);
            var context = new ScenarioContextData
            {
                LocationNickname = "Primary Location",
                LocationType = "Both",
                MilesFromFireDepartment = "3",
                FeetFromHydrant = "101-250",
                TotalAcreage = "200"
            };

            await new LocationPage(_page, context).EnterRequiredRatePolicyLocationAsync();

            var selected = _page.Locator(".chip-wrapper-selected");
            Assert.That(await selected.CountAsync(), Is.EqualTo(1));
            Assert.That((await selected.InnerTextAsync()).Trim(), Is.EqualTo("Both"));
            Assert.That(await _page.Locator("[data-testid$='.LocationInput$Acreage.value' i]").InputValueAsync(),
                Is.EqualTo("200"));
        }

        [Test]
        public async Task Login_ReportsTheActualSsoFailureInsteadOfWaitingForTheDashboard()
        {
            await _page.SetContentAsync("""
                <input placeholder="Username"><input placeholder="Password">
                <button title="Sign On" onclick="document.body.textContent='Invalid State value presented. Please contact your administrator'">Sign On</button>
                """);
            var error = Assert.ThrowsAsync<PlaywrightException>(() =>
                new ExpertQuoteLoginPage(_page).LoginAsync("offline", "offline"));
            Assert.That(error!.Message, Does.Contain("SSO rejected the login").And.Contain("Invalid State value"));
        }

        [Test]
        public async Task StartQuote_WaitsForDelayedDevSsnDialogAndCompletesBothPrompts()
        {
            await _page.SetContentAsync("""
                <button id="startQuote">Start Quote</button>
                <script>
                  window.events = [];
                  setTimeout(() => {
                    document.body.insertAdjacentHTML('beforeend', `
                      <div role="dialog" id="ssn-dialog">
                        <h2>Enter the Client's Full SSN#</h2>
                        <input data-testid="ssn">
                        <button data-testid="btnConfirmYes">Submit</button>
                      </div>`);
                    const dialog = document.getElementById('ssn-dialog');
                    dialog.querySelector('[data-testid=btnConfirmYes]').addEventListener('click', () => {
                      events.push('ssn:' + dialog.querySelector('[data-testid=ssn]').value);
                      dialog.innerHTML = `
                        <h2>Confirm Client</h2>
                        <button data-testid="btnConfirmYes">Submit</button>`;
                      dialog.querySelector('[data-testid=btnConfirmYes]').addEventListener('click', () => {
                        events.push('confirm');
                        dialog.remove();
                        document.getElementById('startQuote').remove();
                      });
                    });
                  }, 200);
                </script>
                """);
            var data = new ScenarioContextData { SSN = "123-45-6789" };

            await new QuoteDetailsPage(_page).HandleSSNPopupsAsync(data);

            Assert.That(await _page.EvaluateAsync<string[]>("window.events"),
                Is.EqualTo(new[] { "ssn:123456789", "confirm" }));
        }

        [Test]
        public async Task StartQuote_ReturnsWhenQuoteTransitionsWithoutSsnDialog()
        {
            await _page.SetContentAsync("""
                <button id="startQuote">Start Quote</button>
                <script>
                  setTimeout(() => document.getElementById('startQuote').remove(), 200);
                </script>
                """);

            await new QuoteDetailsPage(_page).HandleSSNPopupsAsync(new ScenarioContextData());

            Assert.That(await _page.Locator("#startQuote").CountAsync(), Is.Zero);
        }

        [TestCase(false, false)]
        [TestCase(true, true)]
        public async Task MobileRct_UsesDefaultsAndAppliesDepreciationEvenWhenInitialAcvIsPositive(
            bool readOnlySettlement,
            bool usesCompletionPage)
        {
            const string prefix = "fields.risk.rows[0].residenceCoverage.rows[0].";
            await _page.SetContentAsync(
                $"<input data-testid='{prefix}coverageInput$limit.value' value='0'>"
                + $"<input data-testid='{prefix}buildingInput$squareFt.value' value='0'>"
                + $"<select data-testid='{prefix}coverageInput$perilGroup.value'><option>5</option></select>"
                + (readOnlySettlement
                    ? "<div id='CoverageInput.ReplacementCost-0-layout' class='readonly-field'>"
                      + "<span class='readonly-label'>Settlement Option:</span>"
                      + "<span class='readonly-value'>Actual Cash Value</span></div>"
                    : $"<select data-testid='{prefix}coverageInput$replacementCost.value'>"
                      + "<option>Actual Cash Value</option></select>")
                + Chips(prefix + "buildingInput$buildingThermostatQuestion", "Yes")
                + Chips(prefix + "buildingValuatioinInput$estimatorType", "RCT")
                + Chips(prefix + "buildingValuatioinInput$valuationType", "Mobile / Manufactured RCT - Use Defaults", selected: false)
                + Chips(prefix + "buildingValuatioinInput$valuationType", "Mobile / Manufactured RCT - No Defaults")
                + $"<input id='acv' data-testid='{prefix}buildingValuationOutput$aCVValue.value' value='200000'>"
                + $"<button data-testid='{prefix}completeRCTProcess1' onclick=\"window.events=['initial'];\">Get Valuation</button>"
                + $"<button hidden data-testid='{prefix}completeRCTProcess3' onclick=\"events.push('recalculate'); document.getElementById('acv').value='225000'\">Recalculate</button>"
                + $"<script>window.usesCompletionPage = {(usesCompletionPage ? "true" : "false")};</script>"
                + """
                  <button data-testid="editRtcButton" onclick="editRct()">Edit RCT</button>
                  <script>
                    function editRct() {
                      events.push('edit');
                      const popup = window.open('about:blank');
                      popup.document.write(`
                        <div id="rct-topToolBarMenu">
                          <ul id="corelogic-menu" class="sf-menu">
                            <li id="menu_options">
                              <a href="#">Options(*)</a>
                              <ul id="options-submenu" hidden>
                                <li><a id="AddMarkupsAndAdjustmentsLink" href="#" onclick="openAdjustments()">Markups and Adjustments</a></li>
                              </ul>
                            </li>
                          </ul>
                        </div>
                        <input class="recalc-valuation-totals" type="button" value="Calculate" hidden
                          onclick="window.opener.events.push('calculate'); this.hidden = true">
                        <input class="save-or-discard-valuation" type="button" value="Finish" onclick="finishValuation()">
                        <div class="t-widget t-window" id="ConfirmationWindow" style="display: none">
                          <div class="t-window-content t-content">
                            <div id="ConfirmationDiv">
                              <p>Click <span>Save</span> to save your changes.</p>
                              <p>Click <span>Discard</span> to discard your changes and return to the dashboard.</p>
                              <p>Click <span>Close</span> to return to the valuation and continue editing.</p>
                            </div>
                            <div class="button-container">
                              <button id="SaveValuationButton" onclick="saveValuation()">Save</button>
                              <button id="DiscardValuationButton">Discard</button>
                              <button id="CloseConfirmationButton">Close</button>
                            </div>
                          </div>
                        </div>
                        <script>
                          setTimeout(() => {
                            document.getElementById('corelogic-menu').classList.add('sf-js-enabled');
                            document.getElementById('menu_options').addEventListener('mouseenter', () => {
                              document.getElementById('options-submenu').hidden = false;
                            });
                          }, 500);
                          function openAdjustments() {
                            document.body.insertAdjacentHTML('beforeend', \`
                              <div class="t-widget t-window" id="AddMarkupsAndAdjustmentsWindow">
                                <div class="t-window-content t-content">Please wait.</div>
                              </div>\`);
                            setTimeout(() => {
                              document.querySelector('#AddMarkupsAndAdjustmentsWindow .t-window-content').innerHTML = \`
                                <div id="CreateAdjustmentDiv">
                                  <form onsubmit="event.preventDefault(); saveAdjustment()">
                                    <input type="radio" name="depreciation"> None
                                    <input id="UseDepreciationPercentage" type="radio" name="depreciation"
                                      onclick="document.getElementById('ViewModel_DepreciationPercent').disabled = false">
                                    Use Depreciation Percentage
                                    <input id="ViewModel_DepreciationPercent" type="text" value="5" disabled>
                                    <input type="submit" value="Save">
                                  </form>
                                </div>\`;
                            }, 100);
                          }
                          function saveAdjustment() {
                            window.opener.events.push('depreciation:' + document.getElementById('ViewModel_DepreciationPercent').value);
                            document.getElementById('AddMarkupsAndAdjustmentsWindow').remove();
                            document.querySelector('.recalc-valuation-totals').hidden = false;
                          }
                          function finishValuation() {
                            window.opener.events.push('finish');
                            document.getElementById('ConfirmationWindow').style.display = 'block';
                          }
                          function saveValuation() {
                            const opener = window.opener;
                            opener.events.push('save');
                            opener.document.querySelector('[data-testid$=completeRCTProcess3]').hidden = false;
                            if (opener.usesCompletionPage) {
                              document.open();
                              document.write(\`
                                <span id="lblResult">Complete!</span>
                                <span id="lblMessage">You may now close this window. This valuation is being processed.</span>\`);
                              document.close();
                              return;
                            }
                            setTimeout(() => window.close(), 50);
                          }
                        <\/script>`);
                      popup.document.close();
                    }
                  </script>
                  """);
            var data = new ScenarioContextData
            {
                ResidenceRateType = "Mobile Home", ResidenceInsuranceAmount = "250000", ResidenceSquareFeet = "1200",
                ResidencePerils = "5", ResidenceThermostatQuestion = "Yes", ResidenceActualCashValue = "Actual Cash Value",
                ResidenceRCTOption = "Mobile / Manufactured RCT", ResidenceUseDefaults = "Yes"
            };
            data.Farm.ResidenceEstimatorType = "RCT";
            data.Farm.ResidenceDepreciationPercentage = "10";
            await new SFP_ResidenceCoveragePage(_page).FillRatePolicyResidenceCoverageAsync(data);
            Assert.That(await _page.EvaluateAsync<string[]>("window.events"),
                Is.EqualTo(new[] { "initial", "edit", "depreciation:10", "calculate", "finish", "save", "recalculate" }));
            Assert.That(await _page.GetByTestId(prefix + "coverageInput$limit.value").InputValueAsync(), Is.EqualTo("250000"));
        }

        [TestCase("Mobile / Manufactured RCT - Use Defaults", true)]
        [TestCase("Mobile / Manufactured RCT - No Defaults", false)]
        [TestCase("Standard RCT - Use Defaults", false)]
        [TestCase("High Value RCT - Use Defaults", false)]
        public void MobileDefaults_CannotMatchStandardOrNoDefaults(string caption, bool expected) =>
            Assert.That(SFP_ResidenceCoveragePage.MobileDefaultsCaption.IsMatch(caption), Is.EqualTo(expected));

        private Task SetBvsCalculatedValuesAsync(string acv, string rc) =>
            _page.SetContentAsync($"""
                <input data-testid="fields.building.rows[0].buildingValuationOutput$aCVValue.value"
                       value="{acv}" readonly>
                <input data-testid="fields.building.rows[0].buildingValuationOutput$rCValue.value"
                       value="{rc}" readonly>
                """);

        private static Dictionary<string, string> ScenarioValues(string question, string answer) =>
            new Gherkin.Parser().Parse(SfpRatePolicyFeatureTests.FeaturePath())
                .Feature.Children.OfType<Gherkin.Ast.Scenario>().Single().Steps.Select(step => step.Argument)
                .OfType<Gherkin.Ast.DataTable>().Select(SfpRatePolicyFeatureTests.ToTable)
                .Single(table => table.Rows.Any(row => row["Question"] == question && row["Answer"] == answer))
                .Rows.ToDictionary(row => row["Question"], row => row["Answer"]);

        private async Task CreateRetailEditorAsync()
        {
            await _context.RouteAsync(
                "**/api/duckcreek/product",
                route => route.FulfillAsync(new() { Status = 200, ContentType = "application/json", Body = "{}" }));
            await _page.SetContentAsync("""
                <script>
                  window.records = { on: null, off: null };
                  window.saveCount = 0;
                  window.reviewCount = 0;
                  window.retailFailure = '';
                  window.retailSelected = false;
                  const entity = side => side === 'on' ? 'CovRetailSalesOnPremises' : 'CovRetailSalesOffPremises';
                  const totalField = side => side === 'on' ? 'TotalSalesOnPremise' : 'TotalSalesOffPremise';
                  const toggleField = side => 'RetailSaleOfGoodsInput.' + (side === 'on' ? 'RetailSalesOnPremise' : 'RetailSalesOffPremise');
                  const path = (side, field) => `fields.retail.${side}.rows[${saveCount}].`
                    + (field === 'SalesLocationInput.Location' ? 'saleslocation.rows[7].' : '') + field.replace('.', '$') + '.value';
                  function input(side, field, value, readonly = false) {
                    return `<input data-field="${field}" data-testid="${path(side, field)}" value="${value ?? ''}" ${readonly ? 'readonly' : ''}>`;
                  }
                  function select(side, field, choices, selected, multiple = false) {
                    return `<select data-field="${field}" data-testid="${path(side, field)}" ${multiple ? 'multiple' : ''}>`
                      + choices.map(([value, caption]) => `<option value="${value}" ${value === selected ? 'selected' : ''}>${caption}</option>`).join('')
                      + '</select>';
                  }
                  function editorGroup(side) {
                    const record = records[side], name = entity(side);
                    const total = Number(record?.total ?? 0), percent = Number(record?.percent ?? 0);
                    const others = record?.others === '1' ? total * percent / 100 : 0;
                    const selectorId = 'fields.retail.' + toggleField(side).replace('.', '$') + '.value';
                    const caption = side === 'on'
                      ? 'On-Premises (171-10020)'
                      : `Off-Premises (171-${retailFailure === 'class' ? '10010' : '10030'})`;
                    return `<input id="${side}-toggle" type="checkbox" data-testid="${selectorId}" ${record ? 'checked' : ''}
                              onchange="document.getElementById('${side}-fields').hidden=!this.checked">
                            <label for="${side}-toggle" data-testid="${selectorId}">${caption}</label>
                            <fieldset id="${side}-fields" ${record ? '' : 'hidden'}>`
                      + input(side, name + 'Input.' + totalField(side), record?.total)
                      + (side === 'on' ? select(side, 'SalesLocationInput.Location',
                          [['location-node-18', 'Location #1 - 401 4TH ST SE # 111 MINNEAPOLIS, MN 55414-1769 (Primary Location)'],
                           ['location-node-91', 'Location #2 - Secondary Location']],
                          record?.location ?? 'location-node-91', true) : '')
                      + select(side, name + 'Input.OthersGoods', [['0', 'No'], ['1', 'Yes']], record?.others ?? '0')
                      + input(side, name + 'Input.Description', record?.description)
                      + input(side, name + 'Input.PercentOfTotalSalesOthersGoods', record?.percent)
                      + `<div class="readonly-field">
                           <span class="readonly-label">Revenue Generated from Goods produced by Others:</span>
                           <span class="readonly-value">${side === 'off' && retailFailure === 'computed' ? 499 : others}</span>
                         </div></fieldset>`;
                  }
                  function edit() {
                    document.body.innerHTML = editorGroup('on') + editorGroup('off')
                      + `<select data-testid="fields.unrelated.salesLocationInput$location.value"><option value="unrelated">Location #2</option></select>`
                      + `<button data-testid="fields.retail.Save" onclick="save()">Save</button>`;
                  }
                  function save() {
                    for (const side of ['on', 'off']) {
                      if (!document.getElementById(side + '-toggle').checked) { records[side] = null; continue; }
                      const read = field => document.getElementById(side + '-fields').querySelector(`[data-field="${field}"]`).value;
                      const name = entity(side);
                      records[side] = {
                        total: read(name + 'Input.' + totalField(side)), others: read(name + 'Input.OthersGoods'),
                        description: read(name + 'Input.Description').toUpperCase(), percent: read(name + 'Input.PercentOfTotalSalesOthersGoods'),
                        location: side === 'on' ? read('SalesLocationInput.Location') : null
                      };
                    }
                    if (records.off && records.on && retailFailure === 'overwrite') records.on.total = records.off.total;
                    if (document.querySelector('[data-testid="fields.unrelated.salesLocationInput$location.value"]').value !== 'unrelated')
                      throw new Error('An unrelated location was changed');
                    saveCount++;
                    reviewCount++;
                    document.body.innerHTML = `<div role="dialog">
                        <h2>Review Required</h2>
                        <button data-testid="btnConfirmYes" onclick="catalog()">Keep Going</button>
                      </div>`;
                  }
                  function catalog() {
                    document.body.innerHTML = `<table data-testid="coverageTableLiability"><tr>
                        <td>Retail Sales and Farm Stands, Product Sales</td>
                        <td><input id="retail-selected" type="checkbox"
                          data-testid="fields.liability.retailSalesInput$selected.value"
                          ${retailSelected ? 'checked' : ''}>
                        <label for="retail-selected"
                          data-testid="fields.liability.retailSalesInput$selected.value"
                          onclick="selectRetail()">Select</label></td>
                      </tr></table>`
                      + (retailSelected
                        ? `<button data-testid="fields.liability.AddEditRetailSales" onclick="edit()">${records.on || records.off ? 'Edit Coverage' : 'Add Coverage'}</button>`
                        : '');
                  }
                  async function selectRetail() {
                    retailSelected = true;
                    await fetch('https://duckcreek.test/api/duckcreek/product', { method: 'POST' });
                    catalog();
                  }
                </script>
                <table data-testid="coverageTableLiability"><tr>
                  <td>Retail Sales and Farm Stands, Product Sales</td>
                  <td>
                    <input id="retail-selected" type="checkbox"
                           data-testid="fields.liability.retailSalesInput$selected.value">
                    <label for="retail-selected"
                           data-testid="fields.liability.retailSalesInput$selected.value"
                           onclick="selectRetail()">Select</label>
                  </td>
                </tr></table>
                """);
        }

        private static string Chips(
            string path, string value, bool selected = true, bool tooltipOnClick = false) =>
            $"<div data-testid='{path}.value-chip-item-wrapper' onclick=\""
            + "document.querySelectorAll('[data-testid]').forEach(item => {"
            + "if(item.dataset.testid===this.dataset.testid) item.querySelector('.chip-wrapper, .chip-wrapper-selected').className='chip-wrapper'; });"
            + "this.querySelector('.chip-wrapper').className='chip-wrapper-selected';"
            + (tooltipOnClick
                ? $"this.insertAdjacentHTML('beforeend','<div class=&quot;custom-tooltip&quot;>{value}</div>');"
                : "")
            + "\">"
            + $"<div data-testid='{path}.value-chip-wrapper' class='{(selected ? "chip-wrapper-selected" : "chip-wrapper")}'>"
            + $"<span data-testid='{path}.value-chip-label' class='chip-label'>{value}</span></div></div>";
    }
}
