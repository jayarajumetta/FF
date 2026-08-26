import { LocatorDescriptor, LocatorEvidence, Lob } from './model';
export declare function buildLocatorDescriptor(evidence: LocatorEvidence): LocatorDescriptor;
export declare class LocatorRegistry {
    private readonly byFingerprint;
    private readonly aliasToId;
    register(evidence: LocatorEvidence): LocatorDescriptor;
    getByAlias(moduleId: string | undefined, controlId: string): LocatorDescriptor | undefined;
    values(): LocatorDescriptor[];
    aliases(): Record<string, string>;
}
export declare function inferLob(...values: Array<string | undefined>): Lob;
export declare function propertyValue(properties: Record<string, unknown>, ...names: string[]): string | undefined;
