import type { LocatorCandidate, LocatorSpec } from '../locator/model.js';
export type AttemptPhase = 'resolve' | 'action' | 'dropdown' | 'dom-fallback' | 'frame-discovery';
export interface AttemptDiagnostic {
    timestamp: string;
    phase: AttemptPhase;
    locatorKey: string;
    frame: string;
    candidate?: Pick<LocatorCandidate, 'kind' | 'source' | 'selector' | 'value' | 'score'>;
    count?: number;
    selectedIndex?: number;
    status: 'matched' | 'miss' | 'ambiguous' | 'failed' | 'succeeded' | 'skipped';
    message?: string;
}
export interface ActionTrace {
    locator: LocatorSpec;
    action: string;
    diagnostics: AttemptDiagnostic[];
    usedDomFallback: boolean;
}
export interface DiagnosticSink {
    emit(event: AttemptDiagnostic): void;
}
export declare class ArrayDiagnosticSink implements DiagnosticSink {
    readonly events: AttemptDiagnostic[];
    emit(event: AttemptDiagnostic): void;
}
export declare function nowIso(): string;
export declare function errorMessage(error: unknown): string;
export declare class ResilientActionError extends Error {
    readonly locator: LocatorSpec;
    readonly action: string;
    readonly diagnostics: readonly AttemptDiagnostic[];
    constructor(action: string, locator: LocatorSpec, diagnostics: readonly AttemptDiagnostic[]);
}
//# sourceMappingURL=diagnostics.d.ts.map