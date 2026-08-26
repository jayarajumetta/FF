export class FakeNode {
  constructor(options = {}) {
    this.visible = options.visible ?? true;
    this.clickError = options.clickError;
    this.fillError = options.fillError;
    this.inspection = options.inspection ?? {
      tag: 'input',
      role: '',
      type: 'text',
      ariaHasPopup: '',
      contentEditable: false,
      className: '',
    };
    this.clicks = 0;
    this.fills = [];
    this.presses = [];
    this.selections = [];
    this.checked = false;
  }
}

export class FakeLocator {
  constructor(nodes = []) {
    this.nodes = nodes;
  }

  count = async () => this.nodes.length;
  nth = (index) => new FakeLocator(this.nodes[index] ? [this.nodes[index]] : []);
  first = () => this.nth(0);
  isVisible = async () => this.nodes[0]?.visible ?? false;

  click = async () => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    if (node.clickError) throw node.clickError;
    node.clicks += 1;
  };

  fill = async (value) => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    if (node.fillError) throw node.fillError;
    node.fills.push(value);
  };

  press = async (key) => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    node.presses.push(key);
  };

  pressSequentially = async (text) => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    node.fills.push(text);
  };

  selectOption = async (value) => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    node.selections.push(value);
    return [typeof value === 'string' ? value : value.value ?? value.label ?? ''];
  };

  check = async () => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    node.checked = true;
  };

  uncheck = async () => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    node.checked = false;
  };

  waitFor = async () => {
    if (!this.nodes[0]?.visible) throw new Error('not visible');
  };

  evaluate = async () => {
    const node = this.nodes[0];
    if (!node) throw new Error('no node');
    return node.inspection;
  };
}

function keyForRole(role, options) {
  return `${String(role).toLowerCase()}|${String(options?.name ?? '')}`;
}

export class FakeFrame {
  constructor(name = '', url = 'about:blank') {
    this._name = name;
    this._url = url;
    this.children = [];
    this.selectors = new Map();
    this.roles = new Map();
    this.labels = new Map();
    this.texts = new Map();
    this.placeholders = new Map();
    this.testIds = new Map();
    this.evaluateHandler = undefined;
  }

  addChild(frame) {
    this.children.push(frame);
    return frame;
  }

  registerSelector(selector, ...nodes) {
    this.selectors.set(selector, nodes);
    return this;
  }

  registerRole(role, name, ...nodes) {
    this.roles.set(`${role.toLowerCase()}|${name ?? ''}`, nodes);
    return this;
  }

  registerLabel(label, ...nodes) {
    this.labels.set(label, nodes);
    return this;
  }

  registerText(text, ...nodes) {
    this.texts.set(text, nodes);
    return this;
  }

  registerPlaceholder(text, ...nodes) {
    this.placeholders.set(text, nodes);
    return this;
  }

  registerTestId(text, ...nodes) {
    this.testIds.set(text, nodes);
    return this;
  }

  locator = (selector) => new FakeLocator(this.selectors.get(selector) ?? []);
  getByRole = (role, options) => new FakeLocator(this.roles.get(keyForRole(role, options)) ?? []);
  getByLabel = (text) => new FakeLocator(this.labels.get(String(text)) ?? []);
  getByText = (text) => new FakeLocator(this.texts.get(String(text)) ?? []);
  getByPlaceholder = (text) => new FakeLocator(this.placeholders.get(String(text)) ?? []);
  getByTestId = (text) => new FakeLocator(this.testIds.get(String(text)) ?? []);
  childFrames = () => this.children;
  name = () => this._name;
  url = () => this._url;
  isDetached = () => false;

  evaluate = async (_fn, payload) => {
    if (!this.evaluateHandler) throw new Error('DOM fallback not configured');
    return this.evaluateHandler(payload);
  };
}

export class FakePage extends FakeFrame {
  constructor(name = 'main', url = 'https://example.test') {
    super(name, url);
    this.keyboard = { press: async () => {} };
  }

  mainFrame = () => this;
  frames = () => {
    const output = [];
    const visit = (frame) => {
      output.push(frame);
      for (const child of frame.children) visit(child);
    };
    visit(this);
    return output;
  };
}
