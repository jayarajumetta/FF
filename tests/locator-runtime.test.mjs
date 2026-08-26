import test from 'node:test';
import assert from 'node:assert/strict';
import {
  buildLocatorCandidates,
  resolveLocator,
  ResilientActions,
} from '../dist/src/index.js';
import { FakeFrame, FakeNode, FakePage } from './fakes.mjs';

test('PLDC/CLDC FieldRef is first and dotted IDs use exact attribute CSS', () => {
  const candidates = buildLocatorCandidates({
    key: 'cldcLogin',
    app: 'CLDC',
    fieldRef: 'Login.Submit',
    id: 'login.button.primary',
    controlType: 'Link',
    role: { role: 'link', name: 'Login' },
  });
  assert.equal(candidates[0].kind, 'fieldRef');
  const id = candidates.find((item) => item.kind === 'id');
  assert.equal(id.selector, '[id="login.button.primary"]');
  assert.ok(!id.selector.startsWith('#'));
  const roles = candidates.filter((item) => item.kind === 'role').map((item) => item.role.role);
  assert.deepEqual(new Set(roles), new Set(['link', 'button']));
});

test('raw Tosca occurrence selects nth(occurrence - 1)', async () => {
  const page = new FakePage();
  const first = new FakeNode();
  const second = new FakeNode();
  page.registerSelector('[id="txtCribCircumference"]', first, second);
  const result = await resolveLocator(page, {
    key: 'cribCircumference',
    id: 'txtCribCircumference',
    occurrence: 2,
  });
  assert.ok(result.resolved);
  assert.equal(result.resolved.selectedIndex, 1);
  await result.resolved.locator.click();
  assert.equal(first.clicks, 0);
  assert.equal(second.clicks, 1);
});

test('ambiguous high-priority selector falls through to unique semantic locator', async () => {
  const page = new FakePage();
  page.registerSelector('[id="duplicate"]', new FakeNode(), new FakeNode());
  const unique = new FakeNode();
  page.registerLabel('Policy state', unique);
  const result = await resolveLocator(page, {
    key: 'state',
    id: 'duplicate',
    label: 'Policy state',
  });
  assert.equal(result.resolved?.candidate.kind, 'label');
});

test('nested iframe is searched deterministically when main frame has no match', async () => {
  const page = new FakePage();
  const child = page.addChild(new FakeFrame('policy-frame', 'https://app.test/policy'));
  const node = new FakeNode();
  child.registerSelector('[id="insideFrame"]', node);
  const result = await resolveLocator(page, {
    key: 'insideFrame',
    id: 'insideFrame',
  });
  assert.deepEqual(result.resolved?.frame.path, [0]);
});

test('failed interaction continues into another frame/candidate', async () => {
  const page = new FakePage();
  const broken = new FakeNode({ clickError: new Error('covered') });
  const working = new FakeNode();
  page.registerSelector('[id="submit"]', broken);
  page.addChild(new FakeFrame('retry')).registerSelector('[id="submit"]', working);
  const trace = await new ResilientActions(page, { allowDomFallback: false }).click({
    key: 'submit',
    id: 'submit',
  });
  assert.equal(working.clicks, 1);
  assert.equal(trace.usedDomFallback, false);
});

test('final DOM fallback executes inside a nested frame', async () => {
  const page = new FakePage();
  const child = page.addChild(new FakeFrame('cross-origin', 'https://other.example/frame'));
  child.evaluateHandler = (payload) => ({
    ok: payload.candidate.kind === 'id' && payload.action === 'click',
    count: 1,
    selectedIndex: 0,
    detail: 'fake in-frame document action',
  });
  page.evaluateHandler = () => ({ ok: false, count: 0, detail: 'not in main' });
  const trace = await new ResilientActions(page, { maxPasses: 1 }).click({
    key: 'fallbackTarget',
    id: 'fallbackTarget',
  });
  assert.equal(trace.usedDomFallback, true);
  assert.ok(trace.diagnostics.some((item) => item.frame.includes('cross-origin') && item.status === 'succeeded'));
});
