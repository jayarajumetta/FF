import test from 'node:test';
import assert from 'node:assert/strict';
import { gzipSync } from 'node:zlib';
import {
  buildLocatorCandidates,
  buildScenarioFromEvidence,
  locatorSpecFromRawEvidence,
  readTsuBuffer,
} from '../dist/src/index.js';

test('TSU reader expands outer gzip and nested H4sI XML evidence', () => {
  const xml = `
  <Root>
    <XModuleAttribute Surrogate="control-guid">
      <Property Name="Name" Value="txtCribCircumference" />
      <Property Name="ControlType" Value="TextBox" />
      <Property Name="Id" Value="txtCribCircumference" />
      <Property Name="FieldRef" Value="PLDC.Crib.Circumference" />
      <Property Name="Tag" Value="INPUT" />
      <Property Name="Occurrence" Value="2" />
    </XModuleAttribute>
    <XTestStepValue Surrogate="action-guid">
      <Property Name="Name" Value="cmbState" />
      <Property Name="ActionMode" Value="Input" />
      <Property Name="Value" Value="{STATE}" />
      <Property Name="Condition" Value="{LOB} == &quot;PLDC&quot;" />
      <Property Name="Order" Value="14" />
    </XTestStepValue>
  </Root>`;
  const nested = gzipSync(Buffer.from(xml)).toString('base64');
  assert.ok(nested.startsWith('H4sI'));
  const root = {
    Surrogate: 'root-guid',
    Payload: nested,
    Duplicate: { Surrogate: 'root-guid' },
  };
  const tsu = gzipSync(Buffer.from(JSON.stringify(root)));
  const result = readTsuBuffer(tsu, 'FF-bop2.tsu');
  assert.equal(result.entitiesByGuid.size, 1);
  assert.ok(result.warnings.some((item) => item.includes('Duplicate Tosca entity GUID')));
  const locator = result.evidence.locators.find((item) => item.controlName === 'txtCribCircumference');
  assert.ok(locator);
  assert.equal(locator.id, 'txtCribCircumference');
  assert.equal(locator.fieldRef, 'PLDC.Crib.Circumference');
  assert.equal(locator.occurrence, 2);
  const action = result.evidence.actions.find((item) => item.controlName === 'cmbState');
  assert.equal(action?.actionMode, 'Input');
  assert.equal(action?.value, '{STATE}');
  assert.equal(action?.order, 14);

  const spec = locatorSpecFromRawEvidence(locator, 'PLDC');
  assert.equal(buildLocatorCandidates(spec)[0].kind, 'fieldRef');
});

test('raw evidence maps to ordered scenario actions without collapsing conditions', () => {
  const scenario = buildScenarioFromEvidence({
    locators: [{
      controlName: 'cmbState',
      fieldRef: 'PLDC.Site.State',
      id: 'cmbState',
      controlType: 'ComboBox',
      occurrence: 2,
      rawProperties: {},
    }],
    actions: [
      { controlName: 'cmbState', actionMode: 'Select', value: '', order: 10, condition: '{LOB} == "PLDC"', properties: {} },
      { controlName: 'cmbState', actionMode: 'Input', value: '{STATE}', order: 11, condition: '{LOB} == "PLDC"', properties: {} },
      { controlName: 'cmbState', actionMode: 'Click', order: 12, condition: '{LOB} == "PLDC"', properties: {} },
    ],
  }, { app: 'PLDC', name: 'raw map' });
  assert.deepEqual(scenario.actions.map((item) => item.order), [10, 11, 12]);
  assert.deepEqual(scenario.actions.map((item) => item.kind), ['select', 'select', 'click']);
  assert.equal(scenario.actions[0].condition, '{LOB} == "PLDC"');
  assert.equal(scenario.actions[1].condition, '{LOB} == "PLDC"');
  assert.equal(scenario.actions[2].condition, '{LOB} == "PLDC"');
  assert.equal(scenario.actions[1].target.fieldRef, 'PLDC.Site.State');
  assert.equal(scenario.actions[1].target.occurrence, 2);
});
