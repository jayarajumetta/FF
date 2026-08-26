import type { LocatorSpec, RawLocatorEvidence } from '../locator/model.js';
export interface RawActionEvidence {
    sourceFile?: string;
    entityGuid?: string;
    stepName?: string;
    controlName?: string;
    actionMode?: string;
    value?: string;
    condition?: string;
    order?: number;
    properties: Readonly<Record<string, string>>;
}
export interface RawToscaEvidence {
    locators: readonly RawLocatorEvidence[];
    actions: readonly RawActionEvidence[];
}
export declare function extractRawToscaEvidence(xml: string, sourceFile?: string): RawToscaEvidence;
export declare function extractRawToscaEvidenceFromObject(value: unknown, sourceFile?: string): RawToscaEvidence;
export declare function locatorSpecFromRawEvidence(evidence: RawLocatorEvidence, app: string, key?: string): LocatorSpec;
//# sourceMappingURL=raw-evidence.d.ts.map