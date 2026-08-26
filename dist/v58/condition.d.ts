export type ConditionNode = {
    type: 'literal';
    value: unknown;
} | {
    type: 'symbol';
    name: string;
} | {
    type: 'unary';
    operator: 'not' | 'empty' | 'notEmpty';
    operand: ConditionNode;
} | {
    type: 'binary';
    operator: string;
    left: ConditionNode;
    right: ConditionNode;
} | {
    type: 'list';
    values: ConditionNode[];
};
export declare class DataContext {
    private readonly values;
    private readonly originalKeys;
    readonly writes: Array<{
        key: string;
        value: unknown;
        actionId?: string;
        ordinal?: number;
    }>;
    constructor(initial?: Record<string, unknown>);
    merge(values: Record<string, unknown>): void;
    set(key: string, value: unknown, actionId?: string, ordinal?: number): void;
    has(key: string): boolean;
    get(key: string): unknown;
    private lookup;
    snapshot(): Record<string, unknown>;
    expand(value: string): string;
}
export declare function parseCondition(expression: string): ConditionNode;
export declare function evaluateCondition(expression: string | undefined, data: DataContext): boolean;
