import type { DataSource } from './condition.js';
import type { RuntimeValueExpression } from './model.js';
export declare function resolveRuntimeValue(expression: RuntimeValueExpression | undefined, data: DataSource): unknown;
export declare function interpolateTemplate(template: string, data: DataSource): string;
export declare function collectValueDependencies(expression: RuntimeValueExpression | undefined): Set<string>;
//# sourceMappingURL=value.d.ts.map