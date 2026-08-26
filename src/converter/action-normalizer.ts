import { parseCondition, type ConditionNode } from './condition.js';
import type {
  NormalizationAuditEntry,
  NormalizedScenario,
  RuntimeValueExpression,
  ScenarioAction,
  ScenarioModel,
} from './model.js';

function literalString(value: RuntimeValueExpression | undefined): string | undefined {
  if (value?.kind !== 'literal') return undefined;
  return value.value === null || value.value === undefined ? '' : String(value.value);
}

function normalizedCondition(action: ScenarioAction): ConditionNode | undefined {
  if (!action.condition) return undefined;
  return typeof action.condition === 'string' ? parseCondition(action.condition) : action.condition;
}

function conditionIdentity(action: ScenarioAction): string {
  const condition = normalizedCondition(action);
  return condition ? JSON.stringify(condition) : '';
}

function sameTarget(left: ScenarioAction, right: ScenarioAction): boolean {
  if (!left.target || !right.target) return false;
  return left.target.key === right.target.key;
}

function isGeneratedTab(action: ScenarioAction): boolean {
  return action.kind === 'press' &&
    literalString(action.value)?.toLowerCase() === 'tab' &&
    action.metadata?.keep !== true &&
    (action.origin === 'generated' || action.metadata?.autoInserted === true);
}

function isRedundantBlankDropdownPriming(
  current: ScenarioAction,
  next: ScenarioAction | undefined,
): boolean {
  if (!next || current.kind !== 'select' || next.kind !== 'select') return false;
  if (!sameTarget(current, next) || conditionIdentity(current) !== conditionIdentity(next)) return false;
  const currentValue = literalString(current.value);
  const nextValue = literalString(next.value);
  return currentValue !== undefined && currentValue.trim() === '' &&
    nextValue !== undefined && nextValue.trim() !== '' &&
    current.metadata?.keep !== true;
}

function isSafelyDuplicateClick(previous: ScenarioAction | undefined, current: ScenarioAction): boolean {
  if (!previous || previous.kind !== 'click' || current.kind !== 'click') return false;
  if (!sameTarget(previous, current) || conditionIdentity(previous) !== conditionIdentity(current)) return false;
  if (current.metadata?.keep === true) return false;

  const sameRawStep = Boolean(
    previous.metadata?.sourceStepId &&
      current.metadata?.sourceStepId &&
      previous.metadata.sourceStepId === current.metadata.sourceStepId,
  );
  const generatedDuplicate = current.metadata?.autoInserted === true ||
    current.metadata?.deduplicateSafe === true ||
    (current.origin === 'generated' && previous.origin === 'generated');
  return sameRawStep || generatedDuplicate;
}

/**
 * Conservative normalization: raw Tosca order and repeated conditional
 * branches are retained. Only actions with explicit evidence of being
 * converter-generated/redundant are removed.
 */
export function normalizeScenario(model: ScenarioModel): NormalizedScenario {
  const ordered = model.actions
    .map((action, index) => ({ action, index }))
    .sort((left, right) => left.action.order - right.action.order || left.index - right.index)
    .map(({ action }) => ({
      ...action,
      ...(action.condition === undefined
        ? {}
        : { condition: typeof action.condition === 'string' ? parseCondition(action.condition) : action.condition }),
    }));

  const output: ScenarioAction[] = [];
  const audit: NormalizationAuditEntry[] = [];

  for (let index = 0; index < ordered.length; index += 1) {
    const action = ordered[index];
    if (!action) continue;
    const next = ordered[index + 1];

    if (isGeneratedTab(action)) {
      audit.push({
        actionId: action.id,
        decision: 'removed',
        rule: 'generated-tab',
        detail: 'Removed converter-inserted Tab. Raw/explicit Tab actions remain intact.',
      });
      continue;
    }

    if (isRedundantBlankDropdownPriming(action, next)) {
      audit.push({
        actionId: action.id,
        decision: 'removed',
        rule: 'blank-dropdown-priming',
        detail: 'Removed empty Select immediately superseded by a non-empty selection on the same control and condition.',
      });
      continue;
    }

    const previous = output[output.length - 1];
    if (isSafelyDuplicateClick(previous, action)) {
      audit.push({
        actionId: action.id,
        decision: 'removed',
        rule: 'duplicate-generated-click',
        detail: 'Removed adjacent duplicate click with the same locator/condition and duplicate-generation evidence.',
      });
      continue;
    }

    output.push(action);
    audit.push({
      actionId: action.id,
      decision: 'kept',
      rule: 'preserve-raw-order',
      detail: 'Action retained in stable raw order; repeated LOB/state/data conditions are not collapsed.',
    });
  }

  return {
    ...model,
    actions: output,
    audit,
  };
}
