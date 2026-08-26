import type { NormalizedScenario, ScenarioModel } from './model.js';
/**
 * Conservative normalization: raw Tosca order and repeated conditional
 * branches are retained. Only actions with explicit evidence of being
 * converter-generated/redundant are removed.
 */
export declare function normalizeScenario(model: ScenarioModel): NormalizedScenario;
//# sourceMappingURL=action-normalizer.d.ts.map