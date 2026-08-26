import { DataContext, evaluateCondition } from './condition';
import { InteractionTrace, PlanAction, ToscaPlan } from './model';
import { ResilientInteractionEngine } from './interactions';

interface BranchState { parentActive: boolean; conditionResult: boolean; inElse: boolean; expression: string; }

export interface ExecutionResult {
  planId: string;
  passed: boolean;
  executed: string[];
  skipped: string[];
  data: Record<string, unknown>;
  traces: InteractionTrace[];
  error?: string;
}

export class PlanExecutor {
  constructor(readonly engine: ResilientInteractionEngine, readonly data = new DataContext()) {}
  private actionActive(stack: BranchState[], action: PlanAction): boolean {
    const branchActive = stack.every((entry) => entry.parentActive && (entry.inElse ? !entry.conditionResult : entry.conditionResult));
    return branchActive && evaluateCondition(action.condition, this.data);
  }
  async execute(plan: ToscaPlan, example: Record<string, string> = {}): Promise<ExecutionResult> {
    this.data.merge(example);
    const stack: BranchState[] = []; const executed: string[] = []; const skipped: string[] = [];
    try {
      for (const action of plan.actions) {
        if (action.kind === 'ifStart') {
          const parentActive = stack.every((entry) => entry.parentActive && (entry.inElse ? !entry.conditionResult : entry.conditionResult));
          const result = parentActive && evaluateCondition(action.condition ?? action.value ?? action.name, this.data);
          stack.push({ parentActive, conditionResult: result, inElse: false, expression: action.condition ?? action.value ?? action.name });
          executed.push(action.id); continue;
        }
        if (action.kind === 'else') {
          const current = stack[stack.length - 1]; if (current) current.inElse = !current.inElse;
          executed.push(action.id); continue;
        }
        if (action.kind === 'ifEnd') { stack.pop(); executed.push(action.id); continue; }
        if (!this.actionActive(stack, action)) { skipped.push(action.id); continue; }
        if (action.kind === 'setData') {
          if (!action.key) throw new Error(`data.set action ${action.id} has no key`);
          this.data.set(action.key, this.data.expand(String(action.value ?? '')), action.id, action.source.ordinal);
          executed.push(action.id); continue;
        }
        if (['comment', 'noop'].includes(action.kind)) { skipped.push(action.id); continue; }
        const expanded: PlanAction = { ...action, value: action.value === undefined ? undefined : this.data.expand(action.value) };
        await this.engine.perform(expanded); executed.push(action.id);
      }
      return { planId: plan.id, passed: true, executed, skipped, data: this.data.snapshot(), traces: [...this.engine.traces] };
    } catch (error) {
      return { planId: plan.id, passed: false, executed, skipped, data: this.data.snapshot(), traces: [...this.engine.traces], error: String(error) };
    }
  }
}
