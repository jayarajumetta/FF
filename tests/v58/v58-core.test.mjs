import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, readFileSync, writeFileSync, existsSync, readdirSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { gzipSync } from 'node:zlib';
import { createRequire } from 'node:module';

const require = createRequire(import.meta.url);
const v58 = require('../../dist/v58/index.js');

const guid = (n) => `00000000-0000-0000-0000-${String(n).padStart(12, '0')}`;

function syntheticDocument() {
  const moduleId = guid(1), baseField = guid(2), derivedField = guid(3), anchor = guid(4), testcase = guid(10);
  return {
    name: 'synthetic-cldc.json', kind: 'json', sha256: 'synthetic', byteLength: 1, depth: 0,
    payload: { Entities: [
      { Id: moduleId, Type: 'Module', Name: 'CLDC Login Module' },
      { Id: baseField, Type: 'ModuleAttribute', Name: 'User Name', ParentId: moduleId,
        Properties: [ { Name: 'FieldRef', Value: 'Login.UserName' }, { Name: 'Id', Value: 'cl.dc.login.user' }, { Name: 'TagName', Value: 'input' }, { Name: 'Role', Value: 'textbox' } ] },
      { Id: derivedField, Type: 'ModuleAttribute', Name: 'User Name Labelled', ParentId: moduleId, DerivedFrom: baseField,
        Properties: [ { Name: 'Label', Value: 'User Name' } ] },
      { Id: anchor, Type: 'ModuleAttribute', Name: 'Login', ParentId: moduleId,
        Properties: [ { Name: 'FieldRef', Value: 'Login.Submit' }, { Name: 'Id', Value: 'cl.dc.login.submit' }, { Name: 'TagName', Value: 'a' }, { Name: 'Role', Value: 'button' }, { Name: 'Label', Value: 'Log In' } ] },
      { Id: testcase, Type: 'TestCase', Name: 'CLDC Login and repeated conditions' },
      { Id: guid(11), Type: 'TestStepValue', Name: 'Open login', ParentId: testcase, ActionMode: 'Input', Value: 'https://example.invalid/login', Operation: 'OpenUrl' },
      { Id: guid(12), Type: 'TestStepValue', Name: 'Enter user', ParentId: testcase, DerivedFrom: derivedField, ActionMode: 'Input', Value: '{B[UserName]}' },
      { Id: guid(13), Type: 'TestStep', Name: 'TBox If', ParentId: testcase, ActionMode: 'Constraint', Condition: 'LOB = CLDC' },
      { Id: guid(14), Type: 'TestStepValue', Name: 'First login click', ParentId: testcase, DerivedFrom: anchor, ActionMode: 'Input', Value: '{CLICK}' },
      { Id: guid(15), Type: 'TestStep', Name: 'End If', ParentId: testcase },
      { Id: guid(16), Type: 'TestStep', Name: 'TBox If', ParentId: testcase, ActionMode: 'Constraint', Condition: 'LOB = CLDC' },
      { Id: guid(17), Type: 'TestStepValue', Name: 'Explicit tab', ParentId: testcase, DerivedFrom: derivedField, ActionMode: 'Input', Value: '{TAB}' },
      { Id: guid(18), Type: 'TestStepValue', Name: 'Set Buffer', ParentId: testcase, ActionMode: 'Buffer', BufferName: 'LoginDone', Value: 'true' },
      { Id: guid(19), Type: 'TestStepValue', Name: 'Second login click', ParentId: testcase, DerivedFrom: anchor, ActionMode: 'Input', Value: '{CLICK}' },
      { Id: guid(20), Type: 'TestStep', Name: 'End If', ParentId: testcase },
    ] }
  };
}

test('native graph resolves DerivedFrom before locator scoring and preserves repeated branches', () => {
  const graph = v58.buildWorkspaceGraph([syntheticDocument()]);
  const mapping = v58.mapWorkspace(graph, 'CL-DC.zip');
  assert.equal(mapping.plans.length, 1);
  const plan = mapping.plans[0];
  const userAction = plan.actions.find((a) => a.name === 'Enter user');
  assert.equal(userAction.kind, 'fill');
  assert.equal(userAction.locator.evidence.fieldRef, 'Login.UserName');
  assert.ok(userAction.locator.evidence.inheritedFrom.length >= 1);
  const ifs = plan.actions.filter((a) => a.kind === 'ifStart');
  assert.equal(ifs.length, 2);
  assert.equal(ifs[0].condition, ifs[1].condition);
  assert.notEqual(ifs[0].id, ifs[1].id);
  const rawTab = plan.actions.find((a) => a.name === 'Explicit tab');
  assert.equal(rawTab.kind, 'press');
  assert.equal(rawTab.value, 'Tab');
  assert.equal(rawTab.generated, false);
  const setIndex = plan.actions.findIndex((a) => a.kind === 'setData');
  const secondClick = plan.actions.findIndex((a) => a.name === 'Second login click');
  assert.ok(setIndex >= 0 && setIndex < secondClick, 'data.set must stay at source position');
});

test('FieldRef leads locator chain, dotted IDs stay exact attributes, and anchor buttons get link fallback', () => {
  const graph = v58.buildWorkspaceGraph([syntheticDocument()]);
  const mapping = v58.mapWorkspace(graph, 'CL-DC.zip');
  const login = mapping.locators.find((l) => l.evidence.fieldRef === 'Login.Submit');
  assert.equal(login.candidates[0].kind, 'fieldRef');
  const id = login.candidates.find((c) => c.kind === 'id');
  assert.equal(id.value, 'cl.dc.login.submit');
  const roles = login.candidates.filter((c) => c.kind === 'role').map((c) => c.role);
  assert.ok(roles.includes('link'));
  assert.ok(roles.includes('button'));
  assert.ok(login.candidates.some((c) => c.kind === 'labelAndAttribute'));
});

test('optimizer removes only generated redundancies and never raw clicks or source data writes', () => {
  const source = { document: 'x', ordinal: 1 };
  const base = { id: 'p', name: 'p', lob: 'CLDC', source, examples: [], tags: [], warnings: [] };
  const actions = [
    { id: 'raw1', kind: 'click', name: 'raw', conditionPath: [], source: { ...source, ordinal: 1 }, generated: false, metadata: {} },
    { id: 'raw2', kind: 'click', name: 'raw', conditionPath: [], source: { ...source, ordinal: 2 }, generated: false, metadata: {} },
    { id: 'set', kind: 'setData', name: 'set', key: 'X', value: '1', conditionPath: [], source: { ...source, ordinal: 3 }, generated: false, metadata: {} },
    { id: 'select', kind: 'select', name: 's', conditionPath: [], source: { ...source, ordinal: 4 }, generated: true, metadata: {} },
    { id: 'tab', kind: 'press', name: 'tab', value: 'Tab', conditionPath: [], source: { ...source, ordinal: 5 }, generated: true, metadata: {} },
  ];
  const result = v58.optimizePlan({ ...base, actions });
  assert.deepEqual(result.plan.actions.map((a) => a.id), ['raw1', 'raw2', 'set', 'select']);
  v58.assertSourceOrder({ ...base, actions }, result.plan);
});

test('condition AST supports Tosca buffers, nested boolean logic, string operators and in lists', () => {
  const data = new v58.DataContext({ LOB: 'CLDC', State: 'CA', Action: 'Quote', EmptyValue: '' });
  assert.equal(v58.evaluateCondition('(LOB = CLDC AND State in (CA, NY)) OR Action = Bind', data), true);
  assert.equal(v58.evaluateCondition('{B[Action]} startsWith Qu AND NOT (State = TX)', data), true);
  assert.equal(v58.evaluateCondition('EmptyValue is empty', data), true);
  assert.equal(v58.evaluateCondition('LOB = PLDC', data), false);
});

test('nested GZip Tosca payload is decoded without flattening transport metadata into actions', () => {
  const directory = mkdtempSync(join(tmpdir(), 'v58-decode-'));
  const input = join(directory, 'workspace.tsu');
  writeFileSync(input, gzipSync(Buffer.from(JSON.stringify(syntheticDocument().payload))));
  const loaded = v58.loadWorkspace(input);
  assert.ok(loaded.documents.some((d) => d.kind === 'json'));
  const graph = v58.buildWorkspaceGraph(loaded.documents);
  const mapping = v58.mapWorkspace(graph, 'CL-DC.tsu');
  assert.equal(mapping.plans.length, 1);
  assert.equal(mapping.plans[0].actions.some((a) => /module/i.test(a.name) && a.kind !== 'noop'), false);
});

test('generator emits feature, outline examples, machine plan, step definition, page methods and deduplicated locator class', () => {
  const graph = v58.buildWorkspaceGraph([syntheticDocument()]);
  const mapping = v58.mapWorkspace(graph, 'CL-DC.zip');
  mapping.plans[0].examples = [{ name: 'row1', values: { UserName: 'qa.user', LOB: 'CLDC' } }];
  const directory = mkdtempSync(join(tmpdir(), 'v58-generate-'));
  const summary = v58.generateProject(mapping, directory);
  assert.equal(summary.featureFiles, 1);
  assert.ok(existsSync(join(directory, 'mapping-index.json')));
  assert.ok(existsSync(join(directory, 'step-definitions', 'tosca-v58.steps.ts')));
  const featureDir = join(directory, 'features', 'cldc');
  const text = readFileSync(join(featureDir, readdirSync(featureDir)[0]), 'utf8');
  assert.match(text, /Scenario Outline:/);
  assert.match(text, /Examples:/);
  assert.match(text, /# STEP .*act-/);
  assert.ok(readdirSync(join(directory, 'page-locators')).length >= 1);
  assert.ok(readdirSync(join(directory, 'pages')).length >= 1);
  assert.ok(existsSync(join(directory, 'locator-registry.json')));
  const planDir = join(directory, 'plans', 'cldc');
  const planText = readFileSync(join(planDir, readdirSync(planDir).find((name) => name.endsWith('.plan.json'))), 'utf8');
  assert.equal(planText.includes('\"locator\"'), false, 'serialized plans must reference the unique locator registry by id');
});

test('audit reports full locator evidence and independent repeated conditions', () => {
  const graph = v58.buildWorkspaceGraph([syntheticDocument()]);
  const mapping = v58.mapWorkspace(graph, 'CL-DC.zip');
  const audit = v58.auditMapping(mapping);
  assert.equal(audit.passed, true);
  assert.ok(audit.coverage.fieldRefElementActions >= 1);
  assert.ok(audit.coverage.roleAliasLinkButtonLocators >= 1);
  assert.equal(audit.repeatedConditionGroups.length, 1);
});
