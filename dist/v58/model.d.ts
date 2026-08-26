export type Lob = 'PLDC' | 'CLDC' | 'CLEQ' | 'UNKNOWN';
export type Scalar = string | number | boolean | null;
export type ScalarMap = Record<string, Scalar | Scalar[] | undefined>;
export interface SourceRef {
    document: string;
    ordinal: number;
    path?: string;
    line?: number;
    entityId?: string;
}
export interface ToscaEntity {
    id: string;
    type: string;
    name: string;
    parentId?: string;
    childIds: string[];
    derivedFrom?: string;
    references: Record<string, string[]>;
    properties: ScalarMap;
    source: SourceRef;
    mergedProperties?: ScalarMap;
    inheritanceChain?: string[];
}
export interface DecodedDocument {
    name: string;
    kind: 'json' | 'xml' | 'text' | 'binary';
    payload: unknown;
    sha256: string;
    byteLength: number;
    depth: number;
}
export interface WorkspaceGraph {
    entities: ToscaEntity[];
    byId: Map<string, ToscaEntity>;
    childrenByParent: Map<string, ToscaEntity[]>;
    warnings: string[];
    documents: DecodedDocument[];
}
export type LocatorCandidateKind = 'fieldRef' | 'id' | 'testId' | 'labelAndAttribute' | 'label' | 'role' | 'name' | 'css' | 'text' | 'xpath';
export interface LocatorCandidate {
    kind: LocatorCandidateKind;
    value: string;
    score: number;
    exact?: boolean;
    role?: string;
    tag?: string;
    attribute?: string;
    attributeValue?: string;
    label?: string;
    source?: string;
}
export interface LocatorEvidence {
    controlId: string;
    moduleId?: string;
    lob: Lob;
    name: string;
    fieldRef?: string;
    id?: string;
    testId?: string;
    label?: string;
    accessibleName?: string;
    role?: string;
    tag?: string;
    controlName?: string;
    css?: string;
    xpath?: string;
    occurrence?: number;
    frameHints: string[];
    source: SourceRef;
    inheritedFrom: string[];
    attributes: Record<string, string>;
}
export interface LocatorDescriptor {
    id: string;
    name: string;
    lob: Lob;
    moduleId?: string;
    aliases: string[];
    candidates: LocatorCandidate[];
    occurrence?: number;
    frameHints: string[];
    fingerprint: string;
    evidence: LocatorEvidence;
}
export type ActionKind = 'click' | 'fill' | 'select' | 'press' | 'check' | 'uncheck' | 'hover' | 'verify' | 'navigate' | 'setData' | 'ifStart' | 'else' | 'ifEnd' | 'comment' | 'noop';
export interface PlanAction {
    id: string;
    kind: ActionKind;
    name: string;
    value?: string;
    key?: string;
    condition?: string;
    conditionPath: string[];
    locatorId?: string;
    locator?: LocatorDescriptor;
    source: SourceRef;
    rawActionMode?: string;
    generated?: boolean;
    navigationExpected?: boolean;
    explicitOccurrence?: boolean;
    metadata: Record<string, unknown>;
}
export interface TestExample {
    name: string;
    values: Record<string, string>;
    source?: SourceRef;
}
export interface ToscaPlan {
    id: string;
    name: string;
    lob: Lob;
    source: SourceRef;
    actions: PlanAction[];
    examples: TestExample[];
    tags: string[];
    warnings: string[];
}
export interface MappingResult {
    graph: WorkspaceGraph;
    plans: ToscaPlan[];
    locators: LocatorDescriptor[];
    locatorAliases: Record<string, string>;
    warnings: string[];
    metrics: Record<string, number>;
}
export interface InteractionTrace {
    actionId: string;
    action: ActionKind;
    locatorId?: string;
    candidate?: LocatorCandidate;
    frameUrl?: string;
    frameName?: string;
    frameDepth?: number;
    strategy: 'playwright' | 'dom-fallback' | 'navigation' | 'data' | 'condition';
    status: 'passed' | 'failed' | 'skipped';
    detail?: string;
    durationMs: number;
}
export interface RuntimeOptions {
    candidateTimeoutMs?: number;
    actionTimeoutMs?: number;
    navigationTimeoutMs?: number;
    maxFrameDepth?: number;
    maxFrames?: number;
    enableDomFallback?: boolean;
    diagnostics?: boolean;
}
export declare const DEFAULT_RUNTIME_OPTIONS: Required<RuntimeOptions>;
export declare function asString(value: unknown): string | undefined;
export declare function normalizeKey(value: string): string;
export declare function stableSlug(value: string): string;
export declare function stableIdentifier(value: string, fallback?: string): string;
export declare function canonicalJson(value: unknown): string;
export declare function fnv1a(value: string): string;
