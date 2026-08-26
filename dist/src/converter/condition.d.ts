export type DataSource = ReadonlyMap<string, unknown> | Readonly<Record<string, unknown>>;
export type ValueNode = {
    kind: 'literal';
    value: unknown;
} | {
    kind: 'variable';
    path: string;
} | {
    kind: 'array';
    items: readonly ValueNode[];
};
export type ComparisonOperator = 'eq' | 'ne' | 'gt' | 'gte' | 'lt' | 'lte';
export type PredicateOperator = 'contains' | 'startsWith' | 'endsWith' | 'matches' | 'in';
export type ConditionNode = {
    kind: 'literal';
    value: boolean;
} | {
    kind: 'truthy';
    value: ValueNode;
} | {
    kind: 'not';
    operand: ConditionNode;
} | {
    kind: 'logical';
    operator: 'and' | 'or';
    left: ConditionNode;
    right: ConditionNode;
} | {
    kind: 'comparison';
    operator: ComparisonOperator;
    left: ValueNode;
    right: ValueNode;
} | {
    kind: 'predicate';
    operator: PredicateOperator;
    left: ValueNode;
    right: ValueNode;
} | {
    kind: 'empty';
    value: ValueNode;
    negate: boolean;
};
export declare class ConditionSyntaxError extends Error {
    readonly position: number;
    readonly input: string;
    constructor(message: string, position: number, input: string);
}
export declare function parseCondition(input: string): ConditionNode;
export declare function resolveDataValue(data: DataSource, path: string): unknown;
export declare function evaluateValue(node: ValueNode, data: DataSource): unknown;
export interface ConditionEvaluationOptions {
    caseInsensitivePredicates?: boolean;
}
export declare function evaluateCondition(node: ConditionNode, data: DataSource, options?: ConditionEvaluationOptions): boolean;
export declare function collectConditionVariables(node: ConditionNode): Set<string>;
//# sourceMappingURL=condition.d.ts.map