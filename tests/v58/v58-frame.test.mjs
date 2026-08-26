import test from 'node:test';
import assert from 'node:assert/strict';
import { createRequire } from 'node:module';
const require = createRequire(import.meta.url);
const { FrameRuntime, buildLocatorDescriptor, ResilientInteractionEngine } = require('../../dist/v58/index.js');

class FakeLocator {
  constructor({ count = 0, visible = true, attrs = {}, tag = 'input', text = '', onSelect, onPress, onClick } = {}) {
    this._count = count; this.visible = visible; this.attrs = attrs; this.tag = tag; this.text = text;
    this.onSelect = onSelect; this.onPress = onPress; this.onClick = onClick;
  }
  async count() { return this._count; }
  nth() { return new FakeLocator({ count: 1, visible: this.visible, attrs: this.attrs, tag: this.tag, text: this.text, onSelect: this.onSelect, onPress: this.onPress, onClick: this.onClick }); }
  async isVisible() { return this.visible; }
  async getAttribute(name) { return this.attrs[name] ?? null; }
  async click() { this.onClick?.(); }
  async fill(value) { this.value = value; }
  async press(key) { this.onPress?.(key); }
  async check() { this.checked = true; }
  async uncheck() { this.checked = false; }
  async hover() {}
  async innerText() { return this.text; }
  async inputValue() { return this.value ?? ''; }
  async evaluate() { return this.tag; }
  async selectOption(value) { this.onSelect?.(value); return ['selected']; }
  filter() { return this; }
}

class FakeFrame {
  constructor(url, name, matches = {}, children = [], visible = true) { this._url = url; this._name = name; this.matches = matches; this.children = children; this.visible = visible; }
  url() { return this._url; }
  name() { return this._name; }
  childFrames() { return this.children; }
  async frameElement() { return { isVisible: async () => this.visible }; }
  locator(selector) {
    if (selector.includes('FieldRef') || selector.includes('fieldref')) return this.matches.fieldRef ?? new FakeLocator();
    if (selector.includes('[id=')) return this.matches.id ?? new FakeLocator();
    if (selector === 'select') return this.matches.select ?? new FakeLocator();
    return this.matches.css ?? new FakeLocator();
  }
  getByLabel() { return this.matches.label ?? new FakeLocator(); }
  getByRole(role) { return this.matches[role] ?? new FakeLocator(); }
  getByText() { return this.matches.text ?? new FakeLocator(); }
  getByTestId() { return this.matches.testId ?? new FakeLocator(); }
  async evaluate() { return { ok: false, matched: 0, detail: 'mock' }; }
}

function descriptor(extra = {}) {
  return buildLocatorDescriptor({
    controlId: 'c1', moduleId: 'm1', lob: 'CLDC', name: 'Policy Type', fieldRef: 'Policy.Type', id: 'dc.policy.type',
    label: 'Policy Type', accessibleName: 'Policy Type', role: 'combobox', tag: 'select', frameHints: ['duck-app'],
    source: { document: 'x', ordinal: 1 }, inheritedFrom: [], attributes: {}, ...extra,
  });
}

test('strong FieldRef is resolved in the real application frame before weaker main-frame text', async () => {
  const app = new FakeFrame('https://duck.example/app', 'duck-app', { fieldRef: new FakeLocator({ count: 1 }), id: new FakeLocator({ count: 1 }) });
  const analytics = new FakeFrame('https://google-analytics.example/frame', 'analytics', { text: new FakeLocator({ count: 1 }) }, [], false);
  const main = new FakeFrame('https://duck.example/', '', { text: new FakeLocator({ count: 1 }) }, [analytics, app]);
  const page = { mainFrame: () => main };
  const runtime = new FrameRuntime();
  const targets = await runtime.resolveTargets(page, descriptor());
  assert.ok(targets.length >= 1);
  assert.equal(targets[0].candidate.kind, 'fieldRef');
  assert.equal(targets[0].frameContext.name, 'duck-app');
});

test('ambiguous locator is not silently reduced with first()', async () => {
  const app = new FakeFrame('https://duck.example/app', 'duck-app', { fieldRef: new FakeLocator({ count: 2 }), id: new FakeLocator({ count: 2 }) });
  const main = new FakeFrame('https://duck.example/', '', {}, [app]);
  const runtime = new FrameRuntime();
  const targets = await runtime.resolveTargets({ mainFrame: () => main }, descriptor({ occurrence: undefined }));
  assert.equal(targets.length, 0);
});

test('native select uses selectOption and never injects a redundant Tab', async () => {
  const pressed = []; const selections = [];
  const select = new FakeLocator({ count: 1, tag: 'select', onSelect: (value) => selections.push(value), onPress: (key) => pressed.push(key) });
  const app = new FakeFrame('https://duck.example/app', 'duck-app', { fieldRef: select });
  const main = new FakeFrame('https://duck.example/', '', {}, [app]);
  const page = { mainFrame: () => main, url: () => 'https://duck.example/app' };
  const engine = new ResilientInteractionEngine(page);
  const loc = descriptor();
  await engine.perform({ id: 'select1', kind: 'select', name: 'Policy Type', value: 'Commercial', conditionPath: [], locatorId: loc.id, locator: loc, source: { document: 'x', ordinal: 1 }, metadata: {} });
  assert.equal(selections.length, 1);
  assert.equal(pressed.includes('Tab'), false);
});

test('explicit raw Tab without a control uses page keyboard exactly once', async () => {
  const keys = [];
  const main = new FakeFrame('https://duck.example/', '', {});
  const page = { mainFrame: () => main, url: () => 'https://duck.example/', keyboard: { press: async (key) => keys.push(key) } };
  const engine = new ResilientInteractionEngine(page);
  await engine.perform({ id: 'tab1', kind: 'press', name: 'Explicit Tab', value: 'Tab', conditionPath: [], source: { document: 'x', ordinal: 1 }, metadata: { globalKeyboard: true } });
  assert.deepEqual(keys, ['Tab']);
});
