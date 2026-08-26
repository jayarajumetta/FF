import { MappingResult, PlanAction, ToscaPlan, canonicalJson } from './model';

export interface ValidationIssue { severity: 'error' | 'warning' | 'info'; code: string; message: string; planId?: string; actionId?: string; }
export interface MappingAudit {
  passed: boolean;
  generatedAt: string;
  metrics: Record<string, number>;
  issues: ValidationIssue[];
  coverage: Record<string, number>;
  repeatedConditionGroups: Array<{ planId: string; expression: string; occurrences: number; actionSequences: string[][] }>;
  dataSetOrder: Array<{ planId: string; actionId: string; sourceOrdinal: number; planIndex: number; key?: string }>;
  locatorStrategyCounts: Record<string, number>;
}

function elementAction(action: PlanAction): boolean {
  if (action.kind === 'press' && action.metadata?.globalKeyboard) return false;
  return ['click', 'fill', 'select', 'press', 'check', 'uncheck', 'hover', 'verify'].includes(action.kind);
}


function repeatedConditions(plan: ToscaPlan): MappingAudit['repeatedConditionGroups'] {
  const groups = new Map<string, Array<{ index: number; actions: string[] }>>();
  const stack: Array<{ expression: string; start: number; actions: string[] }> = [];
  plan.actions.forEach((action, index) => {
    if (action.kind === 'ifStart') stack.push({ expression: action.condition ?? action.value ?? action.name, start: index, actions: [] });
    else if (action.kind === 'ifEnd') {
      const branch = stack.pop(); if (branch) { const entries = groups.get(branch.expression) ?? []; entries.push({ index: branch.start, actions: branch.actions }); groups.set(branch.expression, entries); }
    } else for (const branch of stack) branch.actions.push(`${action.kind}:${action.locatorId ?? action.name}`);
  });
  return [...groups.entries()].filter(([, entries]) => entries.length > 1).map(([expression, entries]) => ({ planId: plan.id, expression, occurrences: entries.length, actionSequences: entries.map((entry) => entry.actions) }));
}

export function auditMapping(mapping: MappingResult): MappingAudit {
  const issues: ValidationIssue[] = [];
  const allActions = mapping.plans.flatMap((plan) => plan.actions.map((action) => ({ plan, action })));
  for (const { plan, action } of allActions) {
    if (elementAction(action) && !action.locator) issues.push({ severity: 'error', code: 'ELEMENT_ACTION_WITHOUT_LOCATOR', message: `${action.kind} has no locator evidence`, planId: plan.id, actionId: action.id });
    if (action.kind === 'setData' && !action.key) issues.push({ severity: 'error', code: 'DATA_SET_WITHOUT_KEY', message: 'data.set has no target key', planId: plan.id, actionId: action.id });
    if (action.metadata?.unresolvedElement) issues.push({ severity: 'warning', code: 'UNRESOLVED_TECHNICAL_ACTION', message: 'raw technical action retained as non-executable metadata because no UI control evidence was linked', planId: plan.id, actionId: action.id });
    if (action.kind === 'select' && action.value === undefined) issues.push({ severity: 'warning', code: 'DROPDOWN_WITHOUT_VALUE', message: 'dropdown selection has no value', planId: plan.id, actionId: action.id });
    if (action.locator && action.locator.candidates.length === 0) issues.push({ severity: 'error', code: 'LOCATOR_WITHOUT_CANDIDATES', message: 'locator descriptor has no candidates', planId: plan.id, actionId: action.id });
  }
  for (const plan of mapping.plans) {
    const ids = plan.actions.map((action) => action.id);
    if (new Set(ids).size !== ids.length) issues.push({ severity: 'error', code: 'DUPLICATE_ACTION_ID', message: 'plan contains duplicate action ids', planId: plan.id });
    const sourceSetPositions = plan.actions.filter((action) => action.kind === 'setData').map((action) => action.source.ordinal);
    const sorted = [...sourceSetPositions].sort((a, b) => a - b);
    if (canonicalJson(sourceSetPositions) !== canonicalJson(sorted)) issues.push({ severity: 'error', code: 'DATA_SET_REORDERED', message: 'data.set source ordinals are not preserved', planId: plan.id });
    let depth = 0;
    for (const action of plan.actions) {
      if (action.kind === 'ifStart') depth += 1;
      if (action.kind === 'ifEnd') depth -= 1;
      if (depth < 0) issues.push({ severity: 'warning', code: 'UNBALANCED_IF_END', message: 'ifEnd appeared without an open condition', planId: plan.id, actionId: action.id });
    }
    if (depth !== 0) issues.push({ severity: 'warning', code: 'UNBALANCED_IF', message: `condition depth ended at ${depth}`, planId: plan.id });
  }
  const strategyCounts: Record<string, number> = {};
  for (const locator of mapping.locators) for (const candidate of locator.candidates) strategyCounts[candidate.kind] = (strategyCounts[candidate.kind] ?? 0) + 1;
  const elementActions = allActions.filter(({ action }) => elementAction(action));
  const coverage = {
    elementActions: elementActions.length,
    locatedElementActions: elementActions.filter(({ action }) => Boolean(action.locator)).length,
    fieldRefElementActions: elementActions.filter(({ action }) => Boolean(action.locator?.evidence.fieldRef)).length,
    labeledElementActions: elementActions.filter(({ action }) => Boolean(action.locator?.evidence.label || action.locator?.evidence.accessibleName)).length,
    iframeHintedElementActions: elementActions.filter(({ action }) => Boolean(action.locator?.frameHints.length)).length,
    roleAliasLinkButtonLocators: mapping.locators.filter((locator) => {
      const roles = locator.candidates.filter((candidate) => candidate.kind === 'role').map((candidate) => candidate.role);
      return roles.includes('button') && roles.includes('link');
    }).length,
  };
  const dataSetOrder = mapping.plans.flatMap((plan) => plan.actions.map((action, planIndex) => ({ plan, action, planIndex })))
    .filter(({ action }) => action.kind === 'setData')
    .map(({ plan, action, planIndex }) => ({ planId: plan.id, actionId: action.id, sourceOrdinal: action.source.ordinal, planIndex, key: action.key }));
  const repeatedConditionGroups = mapping.plans.flatMap(repeatedConditions);
  const metrics = { ...mapping.metrics, errors: issues.filter((issue) => issue.severity === 'error').length, warnings: issues.filter((issue) => issue.severity === 'warning').length, repeatedConditionGroups: repeatedConditionGroups.length, duplicateLocatorAliasesCollapsed: Math.max(0, mapping.metrics.locatorAliases - mapping.metrics.locators) };
  return { passed: metrics.errors === 0, generatedAt: new Date().toISOString(), metrics, issues, coverage, repeatedConditionGroups, dataSetOrder, locatorStrategyCounts: strategyCounts };
}
