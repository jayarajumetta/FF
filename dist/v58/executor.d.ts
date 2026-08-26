import { DataContext } from './condition';
import { InteractionTrace, ToscaPlan } from './model';
import { ResilientInteractionEngine } from './interactions';
export interface ExecutionResult {
    planId: string;
    passed: boolean;
    executed: string[];
    skipped: string[];
    data: Record<string, unknown>;
    traces: InteractionTrace[];
    error?: string;
}
export declare class PlanExecutor {
    readonly engine: ResilientInteractionEngine;
    readonly data: DataContext;
    constructor(engine: ResilientInteractionEngine, data?: DataContext);
    private actionActive;
    execute(plan: ToscaPlan, example?: Record<string, string>): Promise<ExecutionResult>;
}
