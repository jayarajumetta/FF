import type { ConditionNode } from './condition.js';
import { parseCondition } from './condition.js';
import { normalizeScenario } from './action-normalizer.js';
import { planDataSetFooter, type DeferredDataSet } from './data-footer.js';
import type {
  NormalizationAuditEntry,
  RuntimeValueExpression,
  ScenarioAction,
  ScenarioModel,
} from './model.js';
import { LocatorRegistry, type LocatorRegistryEntry } from '../locator/registry.js';

export interface GeneratorOptions {
  runtimeImport?: string;
  playwrightImport?: string;
  includeAuditComments?: boolean;
  testFunctionName?: string;
}

export interface GeneratedScenario {
  code: string;
  locatorManifest: readonly LocatorRegistryEntry[];
  audit: readonly NormalizationAuditEntry[];
  deferredDataSets: readonly DeferredDataSet[];
}

function json(value: unknown): string {
  return JSON.stringify(value, null, 2);
}

function indentBlock(lines: readonly string[], spaces: number): string[] {
  const prefix = ' '.repeat(spaces);
  return lines.map((line) => line ? `${prefix}${line}` : line);
}

function conditionNode(action: ScenarioAction): ConditionNode | undefined {
  if (!action.condition) return undefined;
  return typeof action.condition === 'string' ? parseCondition(action.condition) : action.condition;
}

function valueExpression(action: ScenarioAction): RuntimeValueExpression {
  return action.value ?? { kind: 'literal', value: '' };
}

function valueCode(action: ScenarioAction): string {
  return `resolveRuntimeValue(${json(valueExpression(action))} as RuntimeValueExpression, data)`;
}

function conditionCode(action: ScenarioAction): string | undefined {
  const condition = conditionNode(action);
  return condition
    ? `evaluateCondition(${json(condition)} as ConditionNode, data)`
    : undefined;
}

function actionLines(
  action: ScenarioAction,
  locatorName: string | undefined,
): string[] {
  switch (action.kind) {
    case 'click':
      return [`await ui.click(${locatorName});`];
    case 'fill':
      return [`await ui.fill(${locatorName}, ${valueCode(action)});`];
    case 'select':
      return [`await ui.select(${locatorName}, ${valueCode(action)});`];
    case 'press':
      return [`await ui.press(${locatorName}, String(${valueCode(action)} ?? ''));`];
    case 'check':
      return [`await ui.check(${locatorName});`];
    case 'uncheck':
      return [`await ui.uncheck(${locatorName});`];
    case 'waitVisible':
      return [`await ui.waitVisible(${locatorName});`];
    case 'verifyText':
      return [
        `{`,
        `  const locator = await ui.locate(${locatorName});`,
        `  await expect(locator).toHaveText(String(${valueCode(action)} ?? ''));`,
        `}`,
      ];
    case 'verifyValue':
      return [
        `{`,
        `  const locator = await ui.locate(${locatorName});`,
        `  await expect(locator).toHaveValue(String(${valueCode(action)} ?? ''));`,
        `}`,
      ];
    case 'dataSet':
      if (!action.dataKey) throw new Error(`dataSet action ${action.id} has no dataKey.`);
      return [`data.set(${JSON.stringify(action.dataKey)}, ${valueCode(action)});`];
    case 'comment':
      return [`// ${String(action.value?.kind === 'literal' ? action.value.value : action.id).replace(/\r?\n/g, ' ')}`];
  }
}

function renderAction(
  action: ScenarioAction,
  locatorName: string | undefined,
  includeAuditComments: boolean,
): string[] {
  if (action.kind !== 'dataSet' && action.kind !== 'comment' && !locatorName) {
    throw new Error(`UI action ${action.id} (${action.kind}) has no target locator.`);
  }
  const lines: string[] = [];
  if (includeAuditComments) {
    const source = action.metadata?.sourceGuid ?? action.metadata?.sourceStepId ?? action.id;
    lines.push(`// v57 source=${source} order=${action.order} kind=${action.kind}`);
  }
  const body = actionLines(action, locatorName);
  const condition = conditionCode(action);
  if (!condition) return [...lines, ...body];
  return [
    ...lines,
    `if (${condition}) {`,
    ...indentBlock(body, 2),
    `}`,
  ];
}

function captureLines(deferred: DeferredDataSet): string[] {
  const action = deferred.action;
  const condition = conditionCode(action) ?? 'true';
  return [
    `const ${deferred.captureName} = ${condition}`,
    `  ? { apply: true as const, value: ${valueCode(action)} }`,
    `  : { apply: false as const, value: undefined };`,
  ];
}

function footerLines(deferred: DeferredDataSet): string[] {
  const key = deferred.action.dataKey;
  if (!key) return [];
  return [
    `if (${deferred.captureName}.apply) {`,
    `  data.set(${JSON.stringify(key)}, ${deferred.captureName}.value);`,
    `}`,
  ];
}

function formatObjectConstant(name: string, value: unknown, typeName: string): string[] {
  const serialized = json(value).split('\n');
  if (serialized.length === 1) return [`const ${name} = ${serialized[0]} satisfies ${typeName};`];
  return [
    `const ${name} = ${serialized[0]}`,
    ...serialized.slice(1, -1),
    `${serialized.at(-1)} satisfies ${typeName};`,
  ];
}

/**
 * Generates one independent if block per raw conditional action. It never
 * merges equal LOB/state/data expressions into else-if or drops later actions.
 */
export function generatePlaywrightScenario(
  model: ScenarioModel,
  options: GeneratorOptions = {},
): GeneratedScenario {
  const normalized = normalizeScenario(model);
  const footerPlan = planDataSetFooter(normalized.actions);
  const deferredById = new Map(footerPlan.deferred.map((item) => [item.action.id, item]));
  const bodyIds = new Set(footerPlan.body.map((action) => action.id));
  const registry = new LocatorRegistry();
  const locatorByAction = new Map<string, string>();

  for (const action of normalized.actions) {
    if (!action.target) continue;
    const name = registry.register(action.target, action.target.key);
    locatorByAction.set(action.id, name);
  }

  const runtimeImport = options.runtimeImport ?? 'ff-bop-complete-e2e-v57';
  const playwrightImport = options.playwrightImport ?? '@playwright/test';
  const testFunctionName = options.testFunctionName ?? 'test';
  const includeAuditComments = options.includeAuditComments ?? true;
  const lines: string[] = [
    `import { ${testFunctionName}, expect } from ${JSON.stringify(playwrightImport)};`,
    `import {`,
    `  ResilientActions,`,
    `  evaluateCondition,`,
    `  resolveRuntimeValue,`,
    `  type ConditionNode,`,
    `  type LocatorSpec,`,
    `  type RuntimeValueExpression,`,
    `} from ${JSON.stringify(runtimeImport)};`,
    '',
  ];

  for (const entry of registry.entries()) {
    lines.push(...formatObjectConstant(entry.name, entry.spec, 'LocatorSpec'));
    if (entry.keys.length > 1) {
      lines.push(`// Deduplicated locator aliases: ${entry.keys.join(', ')}`);
    }
    lines.push('');
  }

  lines.push(`${testFunctionName}(${JSON.stringify(model.name)}, async ({ page }) => {`);
  lines.push(`  const data = new Map<string, unknown>(Object.entries(${json(model.initialData ?? {})}));`);
  lines.push(`  const ui = new ResilientActions(page);`);
  lines.push('');

  for (const action of normalized.actions) {
    const deferred = deferredById.get(action.id);
    if (deferred) {
      lines.push(...indentBlock(captureLines(deferred), 2));
      lines.push('');
      continue;
    }
    if (!bodyIds.has(action.id)) continue;
    lines.push(...indentBlock(
      renderAction(action, locatorByAction.get(action.id), includeAuditComments),
      2,
    ));
    lines.push('');
  }

  if (footerPlan.deferred.length > 0) {
    lines.push('  // v57 data footer: safe writes only; dependency-sensitive writes stay in place.');
    for (const deferred of footerPlan.deferred) {
      lines.push(...indentBlock(footerLines(deferred), 2));
    }
  }
  lines.push('});');
  lines.push('');

  return {
    code: lines.join('\n'),
    locatorManifest: registry.entries(),
    audit: [...normalized.audit, ...footerPlan.audit],
    deferredDataSets: footerPlan.deferred,
  };
}
