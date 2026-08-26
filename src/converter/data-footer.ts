import { collectConditionVariables, parseCondition } from './condition.js';
import { collectValueDependencies } from './value.js';
import type { NormalizationAuditEntry, ScenarioAction } from './model.js';

export interface DeferredDataSet {
  action: ScenarioAction;
  captureName: string;
  originalIndex: number;
}

export interface DataFooterPlan {
  body: readonly ScenarioAction[];
  deferred: readonly DeferredDataSet[];
  audit: readonly NormalizationAuditEntry[];
}

function actionReads(action: ScenarioAction): Set<string> {
  const keys = collectValueDependencies(action.value);
  if (action.condition) {
    const condition = typeof action.condition === 'string'
      ? parseCondition(action.condition)
      : action.condition;
    for (const key of collectConditionVariables(condition)) keys.add(key);
  }
  return keys;
}

function sanitizedCaptureName(action: ScenarioAction, index: number): string {
  const base = (action.dataKey ?? action.id)
    .replace(/[^A-Za-z0-9_$]+/g, '_')
    .replace(/^([^A-Za-z_$])/, '_$1');
  return `__v57_deferred_${base}_${index}`;
}

/**
 * Moves safe data.set calls to the footer. A write remains immediate when a
 * later action reads that key; this prevents the cosmetic cleanup from
 * changing Tosca semantics.
 */
export function planDataSetFooter(actions: readonly ScenarioAction[]): DataFooterPlan {
  const body: ScenarioAction[] = [];
  const deferred: DeferredDataSet[] = [];
  const audit: NormalizationAuditEntry[] = [];

  for (let index = 0; index < actions.length; index += 1) {
    const action = actions[index];
    if (!action) continue;
    if (action.kind !== 'dataSet' || !action.dataKey) {
      body.push(action);
      continue;
    }

    const laterReadsKey = actions
      .slice(index + 1)
      .some((later) => actionReads(later).has(action.dataKey ?? ''));
    const explicitlyImmediate = action.metadata?.deferToFooter === false;

    if (laterReadsKey || explicitlyImmediate) {
      body.push(action);
      audit.push({
        actionId: action.id,
        decision: 'immediate',
        rule: laterReadsKey ? 'data-dependency' : 'explicit-immediate-data-set',
        detail: laterReadsKey
          ? `Kept data.set("${action.dataKey}") in place because a later action reads it.`
          : `Kept data.set("${action.dataKey}") in place by explicit metadata.`,
      });
      continue;
    }

    deferred.push({
      action,
      captureName: sanitizedCaptureName(action, index),
      originalIndex: index,
    });
    audit.push({
      actionId: action.id,
      decision: 'deferred',
      rule: 'safe-data-footer',
      detail: `Moved data.set("${action.dataKey}") to the footer; no later action reads the key.`,
    });
  }

  return { body, deferred, audit };
}
