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
/**
 * Moves safe data.set calls to the footer. A write remains immediate when a
 * later action reads that key; this prevents the cosmetic cleanup from
 * changing Tosca semantics.
 */
export declare function planDataSetFooter(actions: readonly ScenarioAction[]): DataFooterPlan;
//# sourceMappingURL=data-footer.d.ts.map