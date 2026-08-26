import { ToscaPlan } from './model';
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
/**
 * v58 optimization is intentionally non-destructive. Raw Tosca actions are source evidence and are never
 * removed merely because they look repetitive. Only converter-generated artifacts can be eliminated.
 */
export declare function optimizePlan(input: ToscaPlan): OptimizedPlan;
export declare function assertSourceOrder(before: ToscaPlan, after: ToscaPlan): void;
