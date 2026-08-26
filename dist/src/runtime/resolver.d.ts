import type { LocatorLike, PageLike } from '../contracts/playwright.js';
import type { CandidateBuildOptions, LocatorCandidate, LocatorSpec } from '../locator/model.js';
import { type FrameRecord } from './frame-search.js';
import { type AttemptDiagnostic, type DiagnosticSink } from './diagnostics.js';
export interface ResolvedLocator {
    locator: LocatorLike;
    frame: FrameRecord;
    candidate: LocatorCandidate;
    selectedIndex: number;
    count: number;
}
export interface ResolveOptions {
    candidateOptions?: CandidateBuildOptions;
    maxPasses?: number;
    retryDelayMs?: number;
    sink?: DiagnosticSink;
}
export declare function selectStrictLocator(locator: LocatorLike, candidate: LocatorCandidate): Promise<{
    locator: LocatorLike;
    index: number;
    count: number;
} | undefined>;
/** Resolves the first strict, stable locator without performing an action. */
export declare function resolveLocator(page: PageLike, spec: LocatorSpec, options?: ResolveOptions): Promise<{
    resolved?: ResolvedLocator;
    diagnostics: readonly AttemptDiagnostic[];
}>;
export interface LocatorAttemptContext {
    frame: FrameRecord;
    candidate: LocatorCandidate;
    locator: LocatorLike;
    selectedIndex: number;
    count: number;
}
/**
 * Runs an operation against every strict candidate/frame combination until it
 * succeeds. Action failures do not pin the runtime to a bad first locator.
 */
export declare function performAcrossLocatorCandidates<T>(page: PageLike, spec: LocatorSpec, operation: (context: LocatorAttemptContext) => Promise<T>, options?: ResolveOptions): Promise<{
    value?: T;
    diagnostics: readonly AttemptDiagnostic[];
}>;
//# sourceMappingURL=resolver.d.ts.map