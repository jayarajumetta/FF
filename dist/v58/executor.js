"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PlanExecutor = void 0;
const condition_1 = require("./condition");
class PlanExecutor {
    constructor(engine, data = new condition_1.DataContext()) {
        this.engine = engine;
        this.data = data;
    }
    actionActive(stack, action) {
        const branchActive = stack.every((entry) => entry.parentActive && (entry.inElse ? !entry.conditionResult : entry.conditionResult));
        return branchActive && (0, condition_1.evaluateCondition)(action.condition, this.data);
    }
    async execute(plan, example = {}) {
        this.data.merge(example);
        const stack = [];
        const executed = [];
        const skipped = [];
        try {
            for (const action of plan.actions) {
                if (action.kind === 'ifStart') {
                    const parentActive = stack.every((entry) => entry.parentActive && (entry.inElse ? !entry.conditionResult : entry.conditionResult));
                    const result = parentActive && (0, condition_1.evaluateCondition)(action.condition ?? action.value ?? action.name, this.data);
                    stack.push({ parentActive, conditionResult: result, inElse: false, expression: action.condition ?? action.value ?? action.name });
                    executed.push(action.id);
                    continue;
                }
                if (action.kind === 'else') {
                    const current = stack[stack.length - 1];
                    if (current)
                        current.inElse = !current.inElse;
                    executed.push(action.id);
                    continue;
                }
                if (action.kind === 'ifEnd') {
                    stack.pop();
                    executed.push(action.id);
                    continue;
                }
                if (!this.actionActive(stack, action)) {
                    skipped.push(action.id);
                    continue;
                }
                if (action.kind === 'setData') {
                    if (!action.key)
                        throw new Error(`data.set action ${action.id} has no key`);
                    this.data.set(action.key, this.data.expand(String(action.value ?? '')), action.id, action.source.ordinal);
                    executed.push(action.id);
                    continue;
                }
                if (['comment', 'noop'].includes(action.kind)) {
                    skipped.push(action.id);
                    continue;
                }
                const expanded = { ...action, value: action.value === undefined ? undefined : this.data.expand(action.value) };
                await this.engine.perform(expanded);
                executed.push(action.id);
            }
            return { planId: plan.id, passed: true, executed, skipped, data: this.data.snapshot(), traces: [...this.engine.traces] };
        }
        catch (error) {
            return { planId: plan.id, passed: false, executed, skipped, data: this.data.snapshot(), traces: [...this.engine.traces], error: String(error) };
        }
    }
}
exports.PlanExecutor = PlanExecutor;
//# sourceMappingURL=executor.js.map