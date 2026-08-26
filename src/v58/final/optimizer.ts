import { PlanAction, ToscaPlan, canonicalJson } from './model';

export interface OptimizationDecision {
  actionId: string;
  decision: 'kept' | 'removed';
  reason: string;
  sourceOrdinal: number;
}

export interface OptimizedPlan {
  plan: ToscaPlan;
  decisions: OptimizationDecision[];
}

function sameSemanticAction(left: PlanAction, right: PlanAction): boolean {
  return canonicalJson({
    kind: left.kind, value: left.value, key: left.key, condition: left.condition,
    conditionPath: left.conditionPath, locator: left.locatorId,
  }) === canonicalJson({
    kind: right.kind, value: right.value, key: right.key, condition: right.condition,
    conditionPath: right.conditionPath, locator: right.locatorId,
  });
}

/**
 * v58 optimization is intentionally non-destructive. Raw Tosca actions are source evidence and are never
 * removed merely because they look repetitive. Only converter-generated artifacts can be eliminated.
 */
export function optimizePlan(input: ToscaPlan): OptimizedPlan {
  const output: PlanAction[] = [];
  const decisions: OptimizationDecision[] = [];
  for (const action of input.actions) {
    const previous = output[output.length - 1];
    if (action.generated && action.kind === 'press' && String(action.value).toLowerCase() === 'tab'
      && previous?.kind === 'select' && canonicalJson(action.conditionPath) === canonicalJson(previous.conditionPath)) {
      decisions.push({ actionId: action.id, decision: 'removed', reason: 'converter-generated Tab immediately after a dropdown selection', sourceOrdinal: action.source.ordinal });
      continue;
    }
    if (action.generated && action.kind === 'click' && previous?.generated && previous.kind === 'click'
      && sameSemanticAction(previous, action) && !action.navigationExpected && !previous.navigationExpected) {
      decisions.push({ actionId: action.id, decision: 'removed', reason: 'adjacent converter-generated duplicate click with no navigation contract', sourceOrdinal: action.source.ordinal });
      continue;
    }
    if (action.generated && action.kind === 'noop') {
      decisions.push({ actionId: action.id, decision: 'removed', reason: 'converter-generated no-op metadata', sourceOrdinal: action.source.ordinal });
      continue;
    }
    output.push(action);
    decisions.push({ actionId: action.id, decision: 'kept', reason: action.generated ? 'generated action retained because semantics are not provably redundant' : 'raw Tosca action retained', sourceOrdinal: action.source.ordinal });
  }
  // No action is sorted here. In particular, data.set stays exactly where Tosca placed it.
  return { plan: { ...input, actions: output }, decisions };
}

export function assertSourceOrder(before: ToscaPlan, after: ToscaPlan): void {
  const retained = new Set(after.actions.map((action) => action.id));
  const beforeOrder = before.actions.filter((action) => retained.has(action.id)).map((action) => action.id);
  const afterOrder = after.actions.map((action) => action.id);
  if (canonicalJson(beforeOrder) !== canonicalJson(afterOrder)) throw new Error(`Plan order changed for ${before.id}`);
  const beforeData = before.actions.filter((action) => action.kind === 'setData' && retained.has(action.id)).map((action) => action.id);
  const afterData = after.actions.filter((action) => action.kind === 'setData').map((action) => action.id);
  if (canonicalJson(beforeData) !== canonicalJson(afterData)) throw new Error(`data.set order changed for ${before.id}`);
}
