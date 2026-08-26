import type { ScenarioModel } from '../converter/model.js';
import type { RawToscaEvidence } from './raw-evidence.js';
import type { TsuReadResult } from './tsu-reader.js';
export interface ScenarioBuildOptions {
    name?: string;
    app?: string;
    initialData?: Readonly<Record<string, unknown>>;
    includeUnmatchedActions?: boolean;
}
export declare function buildScenarioFromEvidence(evidence: RawToscaEvidence, options?: ScenarioBuildOptions): ScenarioModel;
export declare function buildScenarioFromTsu(result: TsuReadResult, options?: ScenarioBuildOptions): ScenarioModel;
//# sourceMappingURL=scenario-builder.d.ts.map