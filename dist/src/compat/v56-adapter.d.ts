import type { PageLike } from '../contracts/playwright.js';
import type { LocatorSpec } from '../locator/model.js';
import { ResilientActions, type ResilientActionOptions } from '../runtime/resilient-actions.js';
export type V56LocatorInput = string | LocatorSpec | {
    key?: string;
    selector?: string;
    css?: string;
    xpath?: string;
    id?: string;
    fieldRef?: string;
    name?: string;
    label?: string;
    text?: string;
    role?: string;
    controlType?: string;
    occurrence?: number;
};
export declare function toV57Locator(input: V56LocatorInput, key?: string, app?: string): LocatorSpec;
export declare function createV57CompatibilityLayer(page: PageLike, options?: ResilientActionOptions): {
    ui: ResilientActions;
    safeClick: (target: V56LocatorInput, key?: string, app?: string) => Promise<import("../index.js").ActionTrace>;
    safeFill: (target: V56LocatorInput, value: unknown, key?: string, app?: string) => Promise<import("../index.js").ActionTrace>;
    chooseDropdownOption: (target: V56LocatorInput, value: unknown, key?: string, app?: string) => Promise<import("../index.js").ActionTrace>;
    safePress: (target: V56LocatorInput, keyName: string, key?: string, app?: string) => Promise<import("../index.js").ActionTrace>;
};
export declare function cldcLoginLocator(input: {
    id?: string;
    fieldRef?: string;
    accessibleName?: string;
}): LocatorSpec;
export declare function pldcFieldLocator(key: string, fieldRef: string | undefined, fallback?: Omit<LocatorSpec, 'key' | 'app' | 'fieldRef'>): LocatorSpec;
//# sourceMappingURL=v56-adapter.d.ts.map