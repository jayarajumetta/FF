using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Context;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.StepDefinitions.SFPSteps;
using Reqnroll;

namespace PnCTestAutomation.Tests
{
    public partial class SfpCountryEstateTests
    {
        [Test]
        public void ScheduledPropertyMapping_PreservesBothApprovedItemsWithoutInventingAppraisals()
        {
            var items = TableMappingHelpers.CountryEstateScheduledPropertyFields(ScheduledPropertyTable());
            Assert.Multiple(() =>
            {
                Assert.That(items.Select(item => item.Code), Is.EqualTo(new[] { "409", "411" }));
                Assert.That(items.Select(item => item.Description), Is.EqualTo(new[] { "Stamp Collections", "Auto Trailer Home Personal Effects" }));
                Assert.That(items.Select(item => item.Amount), Is.EqualTo(new[] { 5000, 10000 }));
                Assert.That(items.All(item => item.UnattendedVehicle), Is.True);
                Assert.That(items.All(item => item.YearOfAppraisal == null), Is.True);
            });
        }

        [TestCase("AmountOfInsurance", "")]
        [TestCase("AmountOfInsurance", "0")]
        [TestCase("AmountOfInsurance", "-1")]
        [TestCase("AmountOfInsurance", "10000.50")]
        [TestCase("AmountOfInsurance", "2147483648")]
        [TestCase("Description", " ")]
        [TestCase("UnattendedVehicle", "")]
        [TestCase("UnattendedVehicle", "Maybe")]
        [TestCase("Code", "409")]
        [TestCase("Code", "1411")]
        public void ScheduledPropertyBinding_ValidatesEntireTableBeforeNavigating(string field, string value)
        {
            var table = ScheduledPropertyTable();
            table.Rows[1][field] = value;
            Assert.ThrowsAsync<ArgumentException>(() => ScheduledPropertySteps()
                .UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(table));
        }

        [TestCase("Code")]
        [TestCase("Description")]
        [TestCase("AmountOfInsurance")]
        [TestCase("UnattendedVehicle")]
        public void ScheduledPropertyMapping_RejectsMissingRequiredColumn(string missing)
        {
            var table = new Table(ScheduledPropertyTable().Header.Where(column => column != missing).ToArray());
            Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
        }

        [Test]
        public void ScheduledPropertyMapping_RejectsUnknownColumnOrMissingCoverage()
        {
            Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(
                new Table("Code", "Description", "AmountOfInsurance", "UnattendedVehicle", "Perils")));
            var table = new Table("Code", "Description", "AmountOfInsurance", "UnattendedVehicle");
            table.AddRow("409", "Stamp Collections", "5000", "Yes");
            Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
        }

        [TestCase("24999", null, true)]
        [TestCase("25000", null, true)]
        [TestCase("25001", null, false)]
        [TestCase("25001", "2024", true)]
        public void ScheduledPropertyMapping_EnforcesAppraisalThresholdNotAmountCap(string amount, string year, bool accepted)
        {
            var table = ScheduledPropertyTable();
            table.Rows[0]["AmountOfInsurance"] = amount;
            table.Rows[0]["YearOfAppraisal"] = year;
            if (accepted)
                Assert.DoesNotThrow(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
            else
                Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
        }

        [Test]
        public void ScheduledPropertyMapping_RejectsFutureOrInapplicableAppraisal()
        {
            var table = ScheduledPropertyTable();
            table.Rows[0]["YearOfAppraisal"] = (DateTime.Today.Year + 1).ToString();
            Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
            table.Rows[0]["YearOfAppraisal"] = "";
            table.Rows[1]["YearOfAppraisal"] = "2024";
            Assert.Throws<ArgumentException>(() => TableMappingHelpers.CountryEstateScheduledPropertyFields(table));
        }

        [TestCase(null)]
        [TestCase("BasicPolicy")]
        public void ScheduledPropertyBinding_RejectsNonCeContext(string product)
        {
            var steps = new SFP_CoverageSteps(new PlaywrightContext { Page = _page }, new ScenarioContextData { ProductSelection = product });
            Assert.ThrowsAsync<ArgumentException>(() => steps.UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable()));
        }

        [Test]
        public async Task ScheduledPropertyBinding_SelectsExactCodesAndVerifiesBothSavedItems()
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            await ScheduledPropertySteps().UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable());
            var actions = await _page.EvaluateAsync<string[]>("window.actions");
            var saved = await _page.EvaluateAsync<string>("JSON.stringify(window.saved)");
            Assert.Multiple(() =>
            {
                Assert.That(actions,
                    Is.EqualTo(new[] { "catalog", "select409", "add409", "save409", "edit409", "catalog",
                        "select411", "add411", "save411", "edit411", "catalog" }));
                Assert.That(saved,
                    Is.EqualTo("{\"409\":{\"description\":\"STAMP COLLECTIONS\",\"amount\":\"5000\",\"unattended\":\"Yes\",\"year\":\"\"}," +
                        "\"411\":{\"description\":\"AUTO TRAILER HOME PERSONAL EFFECTS\",\"amount\":\"10000\",\"unattended\":\"Yes\",\"year\":\"\"}}"));
            });
        }

        [TestCase("missing409")]
        [TestCase("duplicate409")]
        [TestCase("disabled409")]
        [TestCase("duplicateAdd")]
        [TestCase("missingAdd")]
        public async Task ScheduledPropertyBinding_RejectsMissingAmbiguousOrDisabledIdentity(string failure)
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            await _page.EvaluateAsync("failure => window.failure = failure", failure);
            Assert.ThrowsAsync<PlaywrightException>(() => ScheduledPropertySteps()
                .UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable()));
            Assert.That(await _page.EvaluateAsync<string[]>("Object.keys(window.saved)"), Is.Empty);
            Assert.That(await _page.EvaluateAsync<bool>("window.actions.some(a => a.startsWith('add'))"), Is.False);
        }

        [TestCase("wrongDescription")]
        [TestCase("wrongAmount")]
        [TestCase("wrongUnattended")]
        [TestCase("missingEdit")]
        [TestCase("duplicateEdit")]
        public async Task ScheduledPropertyBinding_FailsSavedReadbackInsteadOfContinuing(string failure)
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            await _page.EvaluateAsync("failure => window.failure = failure", failure);
            Assert.ThrowsAsync<PlaywrightException>(() => ScheduledPropertySteps()
                .UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable()));
            Assert.That(await _page.EvaluateAsync<bool>("window.actions.includes('save409')"), Is.True);
            Assert.That(await _page.EvaluateAsync<bool>("window.actions.includes('add411')"), Is.False);
        }

        [TestCase("missingDescription")]
        [TestCase("duplicateLimit")]
        [TestCase("wrong409Plural")]
        public async Task ScheduledPropertyBinding_FailsBeforeSavingIncompleteEditor(string failure)
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            await _page.EvaluateAsync("failure => window.failure = failure", failure);
            Assert.ThrowsAsync<PlaywrightException>(() => ScheduledPropertySteps()
                .UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable()));
            Assert.That(await _page.EvaluateAsync<string[]>("Object.keys(window.saved)"), Is.Empty);
        }

        [Test]
        public async Task ScheduledPropertyBinding_RejectsSingularUnattendedPathFor411()
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            await _page.EvaluateAsync("window.failure = 'wrong411Singular'");
            Assert.ThrowsAsync<PlaywrightException>(() => ScheduledPropertySteps()
                .UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(ScheduledPropertyTable()));
            Assert.That(await _page.EvaluateAsync<string[]>("Object.keys(window.saved)"), Is.EqualTo(new[] { "409" }));
        }

        [Test]
        public async Task ScheduledPropertyBinding_SelectsNoAndPersistsSuppliedAppraisalWithoutGuessing()
        {
            await _page.SetContentAsync(ScheduledPropertyHtml);
            var table = ScheduledPropertyTable();
            table.Rows[0]["AmountOfInsurance"] = "25001";
            table.Rows[0]["YearOfAppraisal"] = "2024";
            table.Rows[0]["UnattendedVehicle"] = "No";
            await ScheduledPropertySteps().UserAddsAndVerifiesCountryEstateScheduledPersonalProperty(table);
            Assert.That(await _page.EvaluateAsync<string>("window.saved['409'].year"), Is.EqualTo("2024"));
            Assert.That(await _page.EvaluateAsync<string>("window.saved['409'].unattended"), Is.EqualTo("No"));
        }

        private SFP_CoverageSteps ScheduledPropertySteps() =>
            new(new PlaywrightContext { Page = _page }, new ScenarioContextData { ProductSelection = "CE" });

        private static Table ScheduledPropertyTable()
        {
            var table = new Table("Code", "Description", "AmountOfInsurance", "UnattendedVehicle", "YearOfAppraisal");
            table.AddRow("409", "Stamp Collections", "5000", "Yes", "");
            table.AddRow("411", "Auto Trailer Home Personal Effects", "10000", "Yes", "");
            return table;
        }

        // Offline metadata-contract fixture, not a claim of captured/deployed HD4 markup.
        private const string ScheduledPropertyHtml = """
            <button id="ScheduledPersonalProperty-nav" onclick="window.actions.push('catalog'); catalog()">Scheduled Property</button>
            <main id="screen"></main>
            <script>
              window.actions = []; window.saved = {}; window.selected = {}; window.failure = '';
              const screen = document.getElementById('screen');
              function button(action, code, text, handler) {
                const id = `fields.page.coverages.rows[7].${action}`;
                return `<button data-testid="${id}" onclick="${handler}"><div data-testid="${id}">${text}</div></button>`;
              }
              function catalog() {
                let rows = ['1411', '411', '999', '409'];
                if (failure === 'missing409') rows = rows.filter(x => x !== '409');
                if (failure === 'duplicate409') rows.push('409');
                screen.innerHTML = `<input data-testid="temp.filter">
                  <table data-testid="coverageTableSPP"><thead><tr><th></th><th class="mat-column-column1">Coverage Code</th><th>Name</th></tr></thead>
                  <tbody>${rows.map((code, i) => {
                    const id = `fields.page.covCatEntry.rows[${i + 4}].covCatEntryInput$selected.value`;
                    return `<tr><td><label for="c${i}" data-testid="${id}">Select</label>
                      <input id="c${i}" type="checkbox" data-testid="${id}" ${selected[code] ? 'checked' : ''}
                        ${failure === 'disabled409' && code === '409' ? 'disabled' : ''}
                        onchange="selected['${code}']=this.checked; actions.push('select${code}'); catalog()"></td>
                      <td class="mat-column-column1">${code}</td><td>Unrelated text 409 411</td></tr>`;
                  }).join('')}</tbody></table>`;
                for (const code of ['409', '411']) {
                  if (!selected[code]) continue;
                  const action = (saved[code] ? 'edit' : 'add') + (code === '409' ? 'Stamp' : 'AutoTrailer');
                  const phase = saved[code] ? 'Edit' : 'Add';
                  if (failure === 'missing' + phase) continue;
                  const html = button(action, code, phase + ' Coverage', `actions.push('${saved[code] ? 'edit' : 'add'}${code}'); editor('${code}', ${!!saved[code]})`);
                  screen.innerHTML += html + (failure === 'duplicate' + phase ? html : '');
                }
              }
              function editor(code, reopen) {
                let item = {...(saved[code] || {description:'', amount:'', unattended:'No', year:''})};
                if (reopen && failure === 'wrongDescription') item.description = 'WRONG ITEM';
                if (reopen && failure === 'wrongAmount') item.amount = '1';
                if (reopen && failure === 'wrongUnattended') item.unattended = 'No';
                let field = code === '409' ? 'covStampCollectionsInput$unattendedVehicle' : 'covAutoTrailerHomePersonalEffectsInput$unattendedVehicles';
                if (failure === 'wrong409Plural' && code === '409') field += 's';
                if (failure === 'wrong411Singular' && code === '411') field = field.slice(0, -1);
                const input = (name, value) => `<input data-testid="fields.covEndorsements.rows[0].covEndorsementsInput$${name}.value" value="${value}">`;
                screen.innerHTML = (failure === 'missingDescription' ? '' : input('description', item.description)) +
                    input('limit', item.amount) + (failure === 'duplicateLimit' ? input('limit', item.amount) : '') +
                    (code === '409' ? input('yearOfLastAppraisal', item.year) : '') +
                    ['Yes', 'No'].map(value => `<div data-testid="fields.covEndorsements.rows[0].${field}.value-chip-item-wrapper"
                      onclick="document.querySelectorAll('.choice').forEach(x => x.classList.remove('chip-wrapper-selected')); this.firstElementChild.classList.add('chip-wrapper-selected')">
                      <span class="choice ${item.unattended === value ? 'chip-wrapper-selected' : ''}">${value}</span></div>`).join('') +
                    button('save', code, 'Save', `saveItem('${code}')`);
              }
              function saveItem(code) {
                const read = field => screen.querySelector(`[data-testid$="$${field}.value"]`)?.value || '';
                saved[code] = {description:read('description').toUpperCase(), amount:read('limit'),
                  unattended:screen.querySelector('.chip-wrapper-selected').textContent, year:read('yearOfLastAppraisal')};
                actions.push('save' + code); catalog();
              }
              catalog();
            </script>
            """;
    }
}
