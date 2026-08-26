import type { LocatorSpec } from '../locator/model.js';
import type { ConditionNode } from './condition.js';
export type RuntimeValueExpression = {
    kind: 'literal';
    value: unknown;
} | {
    kind: 'data';
    key: string;
    required?: boolean;
} | {
    kind: 'template';
    template: string;
} | {
    kind: 'randomText';
    length: number;
    alphabet?: string;
};
export type ActionKind = 'click' | 'fill' | 'select' | 'press' | 'check' | 'uncheck' | 'waitVisible' | 'verifyText' | 'verifyValue' | 'dataSet' | 'comment';
export interface ActionMetadata {
    actionMode?: string;
    sourceFile?: string;
    sourceGuid?: string;
    sourceStepId?: string;
    rawOrder?: number;
    autoInserted?: boolean;
    deduplicateSafe?: boolean;
    keep?: boolean;
    deferToFooter?: boolean;
    notes?: readonly string[];
}
export interface ScenarioAction {
    id: string;
    order: number;
    kind: ActionKind;
    target?: LocatorSpec;
    value?: RuntimeValueExpression;
    dataKey?: string;
    condition?: string | ConditionNode;
    origin?: 'raw' | 'generated' | 'manual';
    metadata?: ActionMetadata;
}
export interface ScenarioModel {
    name: string;
    app?: string;
    sourceFiles?: readonly string[];
    initialData?: Readonly<Record<string, unknown>>;
    actions: readonly ScenarioAction[];
    tags?: readonly string[];
}
export interface NormalizationAuditEntry {
    actionId: string;
    decision: 'kept' | 'removed' | 'deferred' | 'immediate';
    rule: string;
    detail: string;
}
export interface NormalizedScenario extends Omit<ScenarioModel, 'actions'> {
    actions: readonly ScenarioAction[];
    audit: readonly NormalizationAuditEntry[];
}
//# sourceMappingURL=model.d.ts.map