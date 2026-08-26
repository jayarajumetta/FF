import { LocatorCandidate, LocatorDescriptor, RuntimeOptions } from './model';
export interface FrameContext {
    frame: any;
    depth: number;
    index: number;
    url: string;
    name: string;
    score: number;
    visible: boolean;
    explicitHint: boolean;
}
export interface ResolvedTarget {
    frameContext: FrameContext;
    locator: any;
    candidate: LocatorCandidate;
    candidateIndex: number;
    count: number;
    usedOccurrence?: number;
}
export interface DomAction {
    kind: string;
    value?: string;
    key?: string;
}
export interface DomFallbackResult {
    ok: boolean;
    matched: number;
    detail: string;
    candidate?: LocatorCandidate;
    frameContext?: FrameContext;
}
export declare class FrameRuntime {
    readonly options: Required<RuntimeOptions>;
    constructor(options?: RuntimeOptions);
    collectFrames(page: any, hints?: string[]): Promise<FrameContext[]>;
    private locatorFor;
    private applyAttributeFilter;
    private visibleLocators;
    resolveTargets(page: any, descriptor: LocatorDescriptor): Promise<ResolvedTarget[]>;
    domFallback(page: any, descriptor: LocatorDescriptor, action: DomAction): Promise<DomFallbackResult>;
}
