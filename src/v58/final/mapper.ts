import {
  LocatorEvidence, MappingResult, PlanAction, ScalarMap, TestExample, ToscaEntity, ToscaPlan, WorkspaceGraph,
  asString, fnv1a, normalizeKey,
} from './model';
import { LocatorRegistry, inferLob, propertyValue } from './locators';
import { assertSourceOrder, optimizePlan } from './optimizer';

function props(entity: ToscaEntity): Record<string, unknown> { return (entity.mergedProperties ?? entity.properties) as Record<string, unknown>; }
function typeKey(entity: ToscaEntity): string { return normalizeKey(entity.type); }
function nameKey(entity: ToscaEntity): string { return normalizeKey(entity.name); }
function numericProperty(entity: ToscaEntity, ...names: string[]): number | undefined {
  const value = propertyValue(props(entity), ...names); if (!value) return undefined;
  const number = Number(value); return Number.isFinite(number) ? number : undefined;
}
function entityOrder(entity: ToscaEntity): number {
  return numericProperty(entity, 'Position', 'Order', 'Sequence', 'ExecutionOrder', 'Index', 'SortOrder') ?? entity.source.ordinal;
}
function isModule(entity: ToscaEntity): boolean {
  const type = typeKey(entity); return type.includes('module') && !/(attribute|control|parameter|folder)/.test(type);
}
function isControl(entity: ToscaEntity): boolean {
  const type = typeKey(entity); const name = nameKey(entity);
  return /(moduleattribute|modulecontrol|control|htmlcontrol|guicontrol|steeringparameter)/.test(type)
    || Boolean(propertyValue(props(entity), 'FieldRef', 'ControlType', 'XPath', 'CssSelector', 'TechnicalId'))
    && !/(teststepvalue|testcase|execution)/.test(type + name);
}
function isTestCase(entity: ToscaEntity): boolean {
  const type = typeKey(entity);
  return type.includes('testcase') && !/(folder|design|instance|template|execution|parameter|value)/.test(type);
}
function isExecutableEntity(entity: ToscaEntity): boolean {
  const type = typeKey(entity); const name = nameKey(entity); const properties = props(entity);
  return /(teststep|teststepvalue|reusableblock|condition|ifstatement|else|endcondition|tbox)/.test(type)
    || Boolean(propertyValue(properties, 'ActionMode', 'Action', 'Input', 'TestStepValue', 'Expression', 'Condition'))
    || /(tboxif|tboxsetbuffer|setbuffer|openurl|click|select|dropdown)/.test(name);
}

function ancestor(graph: WorkspaceGraph, entity: ToscaEntity, predicate: (candidate: ToscaEntity) => boolean): ToscaEntity | undefined {
  const visited = new Set<string>(); let current: ToscaEntity | undefined = entity;
  while (current?.parentId && !visited.has(current.parentId)) {
    visited.add(current.parentId); current = graph.byId.get(current.parentId);
    if (current && predicate(current)) return current;
  }
  return undefined;
}

function referenceIds(entity: ToscaEntity): string[] {
  const result = new Set<string>();
  if (entity.derivedFrom) result.add(entity.derivedFrom);
  for (const ids of Object.values(entity.references)) for (const id of ids) result.add(id);
  return [...result];
}

function findControl(graph: WorkspaceGraph, entity: ToscaEntity, controls: Map<string, ToscaEntity>): ToscaEntity | undefined {
  const visited = new Set<string>(); const queue: string[] = [entity.id, ...referenceIds(entity)];
  const names = new Set([
    entity.name,
    propertyValue(props(entity), 'ControlName', 'ModuleAttributeName', 'AttributeName', 'TechnicalName', 'TargetName'),
  ].filter((value): value is string => Boolean(value)).map(normalizeKey));
  let current: ToscaEntity | undefined = entity;
  while (current?.parentId) {
    queue.push(current.parentId);
    if (current.name) names.add(normalizeKey(current.name));
    current = graph.byId.get(current.parentId);
  }
  while (queue.length) {
    const id = queue.shift()!; if (visited.has(id)) continue; visited.add(id);
    const direct = controls.get(id); if (direct) return direct;
    const candidate = graph.byId.get(id); if (!candidate) continue;
    if (isModule(candidate)) {
      const moduleControls = [...controls.values()].filter((control) => ancestor(graph, control, isModule)?.id === candidate.id);
      const exact = moduleControls.filter((control) => names.has(normalizeKey(control.name))
        || names.has(normalizeKey(propertyValue(props(control), 'Name', 'ControlName', 'TechnicalName', 'FieldRef') ?? '')));
      if (exact.length === 1) return exact[0];
    }
    if (candidate.derivedFrom) queue.push(candidate.derivedFrom);
    for (const ids of Object.values(candidate.references)) queue.push(...ids);
  }
  return undefined;
}

function stringAttributes(properties: ScalarMap): Record<string, string> {
  const result: Record<string, string> = {};
  for (const [key, value] of Object.entries(properties)) {
    const selected = Array.isArray(value) ? value[0] : value;
    if (selected !== undefined && selected !== null) result[key] = String(selected);
  }
  return result;
}

function controlEvidence(graph: WorkspaceGraph, control: ToscaEntity, sourceName: string): LocatorEvidence {
  const properties = props(control);
  const module = ancestor(graph, control, isModule);
  const lob = inferLob(sourceName, module?.name, control.name, propertyValue(properties, 'LOB', 'LineOfBusiness'));
  const frameHints = [
    propertyValue(properties, 'Frame', 'FrameName', 'IFrame', 'IFrameName', 'WindowName', 'Context'),
    module ? propertyValue(props(module), 'Frame', 'FrameName', 'IFrame', 'IFrameName') : undefined,
  ].filter((value): value is string => Boolean(value));
  const occurrence = numericProperty(control, 'Occurrence', 'Index', 'ControlOccurrence');
  return {
    controlId: control.id, moduleId: module?.id, lob, name: control.name,
    fieldRef: propertyValue(properties, 'FieldRef', 'FieldReference', 'DCFieldRef', 'data-field-ref', 'data-fieldref'),
    id: propertyValue(properties, 'Id', 'HtmlId', 'ControlId', 'AutomationId', 'TechnicalId'),
    testId: propertyValue(properties, 'TestId', 'data-testid', 'AutomationTestId'),
    label: propertyValue(properties, 'Label', 'Caption', 'DisplayName', 'AssociatedLabel'),
    accessibleName: propertyValue(properties, 'AccessibleName', 'AriaLabel', 'aria-label', 'Text', 'Title') ?? control.name,
    role: propertyValue(properties, 'Role', 'AriaRole', 'ControlRole'),
    tag: propertyValue(properties, 'Tag', 'TagName', 'HtmlTag', 'NodeName'),
    controlName: propertyValue(properties, 'Name', 'HtmlName', 'ControlName'),
    css: propertyValue(properties, 'Css', 'CssSelector', 'Selector'),
    xpath: propertyValue(properties, 'XPath', 'Path', 'RelativeXPath'),
    occurrence: occurrence && occurrence > 0 ? occurrence : undefined,
    frameHints, source: control.source, inheritedFrom: control.inheritanceChain ?? [], attributes: stringAttributes(control.mergedProperties ?? control.properties),
  };
}

function controlKind(control: ToscaEntity | undefined): string {
  if (!control) return '';
  return [control.type, control.name, ...Object.values(stringAttributes(control.mergedProperties ?? control.properties))].join(' ').toLowerCase();
}

function deriveActionKind(entity: ToscaEntity, control: ToscaEntity | undefined): PlanAction['kind'] {
  const properties = props(entity);
  const mode = (propertyValue(properties, 'ActionMode', 'Mode', 'Action', 'Operation') ?? '').toLowerCase();
  const value = (propertyValue(properties, 'Value', 'Input', 'TestStepValue', 'Data', 'Text') ?? '').trim();
  const combined = `${entity.type} ${entity.name} ${mode} ${value}`.toLowerCase();
  const ckind = controlKind(control);
  if (/\belse\b/.test(combined) && !/if/.test(combined)) return 'else';
  if (/(endif|end if|endcondition|end condition)/.test(combined)) return 'ifEnd';
  if (/(tbox if|ifstatement|^if\b|\bcondition\b)/.test(combined) && !/(verify|constraintvalue)/.test(mode)) return 'ifStart';
  if (/(set buffer|setbuffer|data\.set|tbox set buffer)/.test(combined) || mode === 'buffer') return 'setData';
  if (/(openurl|navigate|goto|start browser)/.test(combined) || /^https?:\/\//i.test(value)) return 'navigate';
  if (/\{\s*click\s*\}|\bclick\b/.test(combined) || mode === 'select' && !/(select|combo|dropdown|listbox)/.test(ckind)) return 'click';
  if (/\{\s*tab\s*\}/i.test(value)) return 'press';
  if (/\{\s*enter\s*\}/i.test(value)) return 'press';
  if (/(uncheck|clear check)/.test(combined)) return 'uncheck';
  if (/(check box|checkbox)/.test(ckind) && /^(true|x|1|yes|checked)$/i.test(value)) return 'check';
  if (/(dropdown|combobox|combo box|select|listbox|mat-select)/.test(ckind) || /(selectoption|select option|dropdown)/.test(combined)) return 'select';
  if (mode === 'verify' || /\bverify\b|assert|check value/.test(combined)) return 'verify';
  if (/hover|mouseover/.test(combined)) return 'hover';
  if (/press|keystroke|sendkey/.test(combined)) return 'press';
  if (mode === 'input' || /input|enter value|set value|fill/.test(combined)) return 'fill';
  if (mode === 'constraint') return 'ifStart';
  return 'noop';
}

function actionValue(entity: ToscaEntity, kind: PlanAction['kind']): string | undefined {
  const properties = props(entity);
  let value = propertyValue(properties, 'Value', 'Input', 'TestStepValue', 'Data', 'Text', 'Expression', 'Condition', 'ExpectedValue');
  if (!value) return undefined;
  if (kind === 'press') {
    const key = value.match(/\{\s*(TAB|ENTER|ESC|ESCAPE|SPACE|ARROWDOWN|ARROWUP)\s*\}/i)?.[1];
    if (key) return key.toLowerCase() === 'tab' ? 'Tab' : key.toLowerCase() === 'enter' ? 'Enter' : key;
  }
  if (kind === 'click' && /^\{\s*click\s*\}$/i.test(value)) return undefined;
  return value;
}

function dataKey(entity: ToscaEntity): string | undefined {
  return propertyValue(props(entity), 'BufferName', 'Key', 'Name', 'Variable', 'DataKey', 'Target')
    ?? entity.name.match(/(?:set\s+buffer|data\.set)\s*[:=-]?\s*(.+)$/i)?.[1]?.trim();
}

function conditionExpression(entity: ToscaEntity): string | undefined {
  return propertyValue(props(entity), 'Condition', 'Expression', 'Value', 'Input', 'TestStepValue', 'Constraint');
}

function descendantSequence(graph: WorkspaceGraph, root: ToscaEntity): ToscaEntity[] {
  const result: ToscaEntity[] = []; const visited = new Set<string>();
  const visit = (entity: ToscaEntity): void => {
    if (visited.has(entity.id)) return; visited.add(entity.id);
    const children = [...(graph.childrenByParent.get(entity.id) ?? [])].sort((a, b) => entityOrder(a) - entityOrder(b) || a.source.ordinal - b.source.ordinal);
    for (const child of children) { result.push(child); visit(child); }
    // Expand referenced reusable blocks only when the relation is explicit and the block is outside this subtree.
    for (const [key, ids] of Object.entries(entity.references)) {
      if (!/(reusable|block|teststep|template)/i.test(key)) continue;
      for (const id of ids) {
        const referenced = graph.byId.get(id); if (!referenced || visited.has(id)) continue;
        result.push(referenced); visit(referenced);
      }
    }
  };
  visit(root); return result;
}

function examplesFor(graph: WorkspaceGraph, testCase: ToscaEntity): TestExample[] {
  const candidates = descendantSequence(graph, testCase).filter((entity) => /(instance|example|testdata|dataset|testsheet)/.test(typeKey(entity)));
  return candidates.map((entity) => {
    const values: Record<string, string> = {};
    for (const [key, value] of Object.entries(entity.mergedProperties ?? entity.properties)) {
      if (/^(id|guid|name|type|position|order|parent|derived)/i.test(key)) continue;
      const selected = Array.isArray(value) ? value[0] : value;
      if (selected !== undefined && selected !== null && typeof selected !== 'object') values[key] = String(selected);
    }
    return { name: entity.name, values, source: entity.source };
  }).filter((example) => Object.keys(example.values).length > 0);
}

export function mapWorkspace(graph: WorkspaceGraph, sourceName: string): MappingResult {
  const controls = new Map(graph.entities.filter(isControl).map((entity) => [entity.id, entity]));
  const locatorRegistry = new LocatorRegistry();
  const descriptorByControl = new Map<string, ReturnType<LocatorRegistry['register']>>();
  for (const control of controls.values()) {
    const evidence = controlEvidence(graph, control, sourceName);
    if (![evidence.fieldRef, evidence.id, evidence.testId, evidence.label, evidence.accessibleName, evidence.css, evidence.xpath].some(Boolean)) continue;
    descriptorByControl.set(control.id, locatorRegistry.register(evidence));
  }
  const plans: ToscaPlan[] = [];
  const warnings: string[] = [...graph.warnings];
  for (const testCase of graph.entities.filter(isTestCase)) {
    const conditionStack: string[] = [];
    const rawActions: PlanAction[] = [];
    for (const entity of descendantSequence(graph, testCase)) {
      if (!isExecutableEntity(entity)) continue;
      const control = findControl(graph, entity, controls);
      const descriptor = control ? descriptorByControl.get(control.id) ?? locatorRegistry.register(controlEvidence(graph, control, sourceName)) : undefined;
      let kind = deriveActionKind(entity, control);
      const unresolvedElement = !control && ['click', 'fill', 'select', 'check', 'uncheck', 'hover'].includes(kind);
      if (unresolvedElement && /(tbox|buffer|expression|evaluation|file|folder|wait|process|program|database|xml|json|api)/i.test(`${entity.type} ${entity.name}`)) kind = 'noop';
      if (!control && kind === 'verify' && /(tbox|buffer|expression|evaluation|constraint|data)/i.test(`${entity.type} ${entity.name}`)) kind = 'comment';
      const expression = conditionExpression(entity);
      const id = `act-${fnv1a(`${testCase.id}:${entity.id}:${entity.source.ordinal}:${kind}`)}`;
      const action: PlanAction = {
        id, kind, name: entity.name || control?.name || kind, value: actionValue(entity, kind),
        key: kind === 'setData' ? dataKey(entity) : undefined,
        condition: !['ifStart', 'ifEnd', 'else'].includes(kind) ? propertyValue(props(entity), 'Condition', 'Constraint') : expression,
        conditionPath: [...conditionStack], locatorId: descriptor?.id, locator: descriptor,
        source: entity.source, rawActionMode: propertyValue(props(entity), 'ActionMode', 'Mode', 'Action'), generated: false,
        navigationExpected: Boolean(propertyValue(props(entity), 'Navigation', 'NavigationExpected', 'PageTransition')) || /next|continue|submit|login|save|finish/i.test(entity.name),
        explicitOccurrence: Boolean(descriptor?.occurrence), metadata: { entityId: entity.id, entityType: entity.type, controlId: control?.id, moduleId: descriptor?.moduleId, globalKeyboard: kind === 'press' && !descriptor, unresolvedElement: unresolvedElement && kind === 'noop' },
      };
      rawActions.push(action);
      if (kind === 'ifStart') conditionStack.push(expression ?? entity.name);
      else if (kind === 'else' && conditionStack.length) conditionStack[conditionStack.length - 1] = `ELSE(${conditionStack[conditionStack.length - 1]})`;
      else if (kind === 'ifEnd' && conditionStack.length) conditionStack.pop();
    }
    const lob = inferLob(sourceName, testCase.name, propertyValue(props(testCase), 'LOB', 'LineOfBusiness'));
    const rawPlan: ToscaPlan = { id: testCase.id, name: testCase.name, lob, source: testCase.source, actions: rawActions, examples: examplesFor(graph, testCase), tags: [lob.toLowerCase(), 'tosca-v58'], warnings: [] };
    const optimized = optimizePlan(rawPlan); assertSourceOrder(rawPlan, optimized.plan);
    plans.push(optimized.plan);
  }
  const locators = locatorRegistry.values();
  const metrics: Record<string, number> = {
    documents: graph.documents.length, entities: graph.entities.length, modules: graph.entities.filter(isModule).length,
    controls: controls.size, locators: locators.length, locatorAliases: Object.keys(locatorRegistry.aliases()).length,
    testCases: plans.length, actions: plans.reduce((sum, plan) => sum + plan.actions.length, 0),
    fieldRefLocators: locators.filter((locator) => Boolean(locator.evidence.fieldRef)).length,
    inheritedLocators: locators.filter((locator) => locator.evidence.inheritedFrom.length > 0).length,
    dataSets: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'setData').length, 0),
    conditions: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'ifStart').length, 0),
    explicitTabs: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'press' && action.value === 'Tab' && !action.generated).length, 0),
    dropdownActions: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'select').length, 0),
  };
  if (!plans.length) warnings.push(`No native TestCase entities were reconstructed from ${sourceName}`);
  return { graph, plans: plans.sort((a, b) => a.source.ordinal - b.source.ordinal), locators, locatorAliases: locatorRegistry.aliases(), warnings, metrics };
}
