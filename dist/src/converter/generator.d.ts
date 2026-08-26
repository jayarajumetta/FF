import { type DeferredDataSet } from './data-footer.js';
import type { NormalizationAuditEntry, ScenarioModel } from './model.js';
import { type LocatorRegistryEntry } from '../locator/registry.js';
export interface GeneratorOptions {
    runtimeImport?: string;
    playwrightImport?: string;
    includeAuditComments?: boolean;
    testFunctionName?: string;
}
export interface GeneratedScenario {
    code: string;
    locatorManifest: readonly LocatorRegistryEntry[];
    audit: readonly NormalizationAuditEntry[];
    deferredDataSets: readonly DeferredDataSet[];
}
/**
 * Generates one independent if block per raw conditional action. It never
 * merges equal LOB/state/data expressions into else-if or drops later actions.
 */
export declare function generatePlaywrightScenario(model: ScenarioModel, options?: GeneratorOptions): GeneratedScenario;
//# sourceMappingURL=generator.d.ts.map