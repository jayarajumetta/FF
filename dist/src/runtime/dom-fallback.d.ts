import type { PageLike } from '../contracts/playwright.js';
import type { CandidateBuildOptions, LocatorSpec } from '../locator/model.js';
import { type AttemptDiagnostic, type DiagnosticSink } from './diagnostics.js';
export type DomActionKind = 'click' | 'fill' | 'select' | 'check' | 'uncheck' | 'press';
export interface DomFallbackOptions {
    candidateOptions?: CandidateBuildOptions;
    sink?: DiagnosticSink;
}
export interface DomFallbackResult {
    succeeded: boolean;
    diagnostics: readonly AttemptDiagnostic[];
    frame?: string;
    candidateSource?: string;
    detail?: string;
}
/**
 * Final audited fallback. It runs inside each Playwright Frame execution
 * context; it never tries to cross a same-origin boundary with top.document.
 */
export declare function performDomFallback(page: PageLike, spec: LocatorSpec, action: DomActionKind, value: string | undefined, options?: DomFallbackOptions): Promise<DomFallbackResult>;
//# sourceMappingURL=dom-fallback.d.ts.map