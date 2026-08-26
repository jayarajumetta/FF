import test from 'node:test';
import assert from 'node:assert/strict';
import { ResilientActions } from '../dist/src/index.js';
import { FakeNode, FakePage } from './fakes.mjs';

test('native select uses selectOption without Tab', async () => {
  const page = new FakePage();
  const select = new FakeNode({
    inspection: { tag: 'select', role: 'combobox', type: '', ariaHasPopup: '', contentEditable: false, className: '' },
  });
  page.registerSelector('[id="state"]', select);
  await new ResilientActions(page, { allowDomFallback: false }).select({ key: 'state', id: 'state' }, 'CA');
  assert.deepEqual(select.selections, [{ label: 'CA' }]);
  assert.deepEqual(select.presses, []);
});

test('Angular Material select clicks exact role option and does not press Tab', async () => {
  const page = new FakePage();
  const trigger = new FakeNode({
    inspection: { tag: 'mat-select', role: 'combobox', type: '', ariaHasPopup: 'listbox', contentEditable: false, className: 'mat-mdc-select' },
  });
  const option = new FakeNode({ inspection: { tag: 'mat-option', role: 'option', type: '', ariaHasPopup: '', contentEditable: false, className: '' } });
  page.registerSelector('[id="cmbState"]', trigger);
  page.registerRole('option', 'TX', option);
  await new ResilientActions(page, { allowDomFallback: false }).select({
    key: 'state',
    id: 'cmbState',
    controlType: 'ComboBox',
  }, 'TX');
  assert.equal(trigger.clicks, 1);
  assert.equal(option.clicks, 1);
  assert.deepEqual(trigger.presses, []);
});

test('input-backed combobox fills then clicks option', async () => {
  const page = new FakePage();
  const input = new FakeNode({
    inspection: { tag: 'input', role: 'combobox', type: 'text', ariaHasPopup: 'listbox', contentEditable: false, className: '' },
  });
  const option = new FakeNode();
  page.registerSelector('[id="siteValue"]', input);
  page.registerRole('option', 'Primary', option);
  await new ResilientActions(page, { allowDomFallback: false }).select({
    key: 'siteValue',
    id: 'siteValue',
    controlType: 'ComboBox',
  }, 'Primary');
  assert.deepEqual(input.fills, ['Primary']);
  assert.equal(option.clicks, 1);
  assert.deepEqual(input.presses, []);
});
