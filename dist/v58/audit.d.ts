import { MappingResult } from './model';
export interface ValidationIssue {
    severity: 'error' | 'warning' | 'info';
    code: string;
    message: string;
    planId?: string;
    actionId?: string;
}
export interface MappingAudit {
    passed: boolean;
    generatedAt: string;
    metrics: Record<string, number>;
    issues: ValidationIssue[];
    coverage: Record<string, number>;
    repeatedConditionGroups: Array<{
        planId: string;
        expression: string;
        occurrences: number;
        actionSequences: string[][];
    }>;
    dataSetOrder: Array<{
        planId: string;
        actionId: string;
        sourceOrdinal: number;
        planIndex: number;
        key?: string;
    }>;
    locatorStrategyCounts: Record<string, number>;
}
export declare function auditMapping(mapping: MappingResult): MappingAudit;
