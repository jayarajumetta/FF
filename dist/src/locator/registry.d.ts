import type { LocatorSpec } from './model.js';
export interface LocatorRegistryEntry {
    name: string;
    spec: LocatorSpec;
    keys: readonly string[];
    identity: string;
}
export declare function locatorConstantName(value: string): string;
export declare class LocatorRegistry {
    private readonly byIdentity;
    private readonly identitiesByName;
    register(spec: LocatorSpec, suggestedName?: string): string;
    entries(): LocatorRegistryEntry[];
    get size(): number;
}
//# sourceMappingURL=registry.d.ts.map