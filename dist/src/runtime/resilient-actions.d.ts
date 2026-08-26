import type { LocatorLike, PageLike } from '../contracts/playwright.js';
import type { CandidateBuildOptions, LocatorSpec } from '../locator/model.js';
import { type ActionTrace, type DiagnosticSink } from './diagnostics.js';
export interface ResilientActionOptions {
    actionTimeoutMs?: number;
    maxPasses?: number;
    retryDelayMs?: number;
    allowDomFallback?: boolean;
    candidateOptions?: CandidateBuildOptions;
    sink?: DiagnosticSink;
}
export declare class ResilientActions {
    private readonly page;
    private readonly config;
    constructor(page: PageLike | unknown, options?: ResilientActionOptions);
    locate(spec: LocatorSpec): Promise<LocatorLike>;
    click(spec: LocatorSpec): Promise<ActionTrace>;
    fill(spec: LocatorSpec, value: unknown): Promise<ActionTrace>;
    press(spec: LocatorSpec, key: string): Promise<ActionTrace>;
    check(spec: LocatorSpec): Promise<ActionTrace>;
    uncheck(spec: LocatorSpec): Promise<ActionTrace>;
    waitVisible(spec: LocatorSpec): Promise<ActionTrace>;
    /**
     * Selects native HTML selects, Angular Material controls, and input-backed
     * comboboxes. It never appends an unconditional Tab after selection.
     */
    select(spec: LocatorSpec, value: unknown): Promise<ActionTrace>;
    private combinedSink;
    private performSimple;
    private domActionFor;
    private selectNative;
    private fillComboInput;
    private keyboardDropdownFallback;
    private optionSpec;
    private chooseOpenOption;
}
/** Drop-in helper for generated tests that prefer functions over a class. */
export declare function createResilientActions(page: PageLike, options?: ResilientActionOptions): ResilientActions;
//# sourceMappingURL=resilient-actions.d.ts.map