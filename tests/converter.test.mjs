import test from 'node:test';
import assert from 'node:assert/strict';
import {
  evaluateCondition,
  generatePlaywrightScenario,
  LocatorRegistry,
  normalizeScenario,
  parseCondition,
  planDataSetFooter,
} from '../dist/src/index.js';

test('condition parser handles LOB, state, data predicates, and parentheses', () => {
  const condition = parseCondition('{LOB} == "PLDC" AND ({STATE} != "" OR DATA.Plan contains "Gold")');
  assert.equal(evaluateCondition(condition, new Map([
    ['LOB', 'PLDC'],
    ['STATE', ''],
    ['DATA', { Plan: 'Gold Plus' }],
  ])), true);
  assert.equal(evaluateCondition(condition, new Map([
    ['LOB', 'CLDC'],
    ['STATE', 'CA'],
    ['DATA', { Plan: 'Gold Plus' }],
  ])), false);
});

test('normalizer removes generated Tab, blank dropdown priming, and safe generated duplicate click only', () => {
  const locator = { key: 'state', id: 'cmbState' };
  const scenario = normalizeScenario({
    name: 'normalize',
    actions: [
      { id: 'empty', order: 1, kind: 'select', target: locator, value: { kind: 'literal', value: '' }, origin: 'raw' },
      { id: 'actual', order: 2, kind: 'select', target: locator, value: { kind: 'literal', value: 'CA' }, origin: 'raw' },
      { id: 'tab', order: 3, kind: 'press', target: locator, value: { kind: 'literal', value: 'Tab' }, origin: 'generated', metadata: { autoInserted: true } },
      { id: 'click1', order: 4, kind: 'click', target: locator, origin: 'generated', metadata: { sourceStepId: 'same' } },
      { id: 'click2', order: 5, kind: 'click', target: locator, origin: 'generated', metadata: { sourceStepId: 'same' } },
      { id: 'rawClick1', order: 6, kind: 'click', target: locator, origin: 'raw', metadata: { sourceStepId: 'raw-1' } },
      { id: 'rawClick2', order: 7, kind: 'click', target: locator, origin: 'raw', metadata: { sourceStepId: 'raw-2' } },
    ],
  });
  assert.deepEqual(scenario.actions.map((item) => item.id), ['actual', 'click1', 'rawClick1', 'rawClick2']);
});

test('data footer defers only writes not read later', () => {
  const actions = [
    { id: 'needed', order: 1, kind: 'dataSet', dataKey: 'STATE', value: { kind: 'literal', value: 'CA' } },
    { id: 'use', order: 2, kind: 'fill', target: { key: 'state', id: 'state' }, value: { kind: 'data', key: 'STATE' } },
    { id: 'safe', order: 3, kind: 'dataSet', dataKey: 'RESULT', value: { kind: 'literal', value: 'done' } },
  ];
  const plan = planDataSetFooter(actions);
  assert.deepEqual(plan.body.map((item) => item.id), ['needed', 'use']);
  assert.deepEqual(plan.deferred.map((item) => item.action.id), ['safe']);
});

test('generator preserves repeated identical LOB/state conditions as independent if blocks', () => {
  const locator = { key: 'policyAction', id: 'policy.action' };
  const generated = generatePlaywrightScenario({
    name: 'Repeated conditions',
    initialData: { LOB: 'PLDC', STATE: 'CA' },
    actions: [
      { id: 'a1', order: 1, kind: 'click', target: locator, condition: '{LOB} == "PLDC"', origin: 'raw' },
      { id: 'a2', order: 2, kind: 'fill', target: locator, value: { kind: 'literal', value: 'one' }, condition: '{LOB} == "PLDC"', origin: 'raw' },
      { id: 'a3', order: 3, kind: 'click', target: locator, condition: '{STATE} == "CA"', origin: 'raw' },
      { id: 'a4', order: 4, kind: 'fill', target: locator, value: { kind: 'literal', value: 'two' }, condition: '{STATE} == "CA"', origin: 'raw' },
      { id: 'footer', order: 5, kind: 'dataSet', dataKey: 'RESULT', value: { kind: 'literal', value: 'ok' }, origin: 'raw' },
    ],
  }, { runtimeImport: '../src/index.js' });
  assert.equal((generated.code.match(/if \(evaluateCondition/g) ?? []).length, 4);
  assert.ok(!generated.code.includes('else if'));
  assert.ok(generated.code.lastIndexOf('data.set("RESULT"') > generated.code.lastIndexOf('await ui.fill'));
  assert.equal(generated.locatorManifest.length, 1);
});

test('locator registry deduplicates executable locator definitions', () => {
  const registry = new LocatorRegistry();
  const one = registry.register({ key: 'firstName', id: 'customer.name' });
  const two = registry.register({ key: 'insuredName', id: 'customer.name' });
  assert.equal(one, two);
  assert.equal(registry.size, 1);
  assert.deepEqual(registry.entries()[0].keys, ['firstName', 'insuredName']);
});
