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

export type LocatorCandidateKind =
  | 'fieldRef'
  | 'id'
  | 'testId'
  | 'labelAndAttribute'
  | 'label'
  | 'role'
  | 'name'
  | 'css'
  | 'text'
  | 'xpath';

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

export type ActionKind =
  | 'click'
  | 'fill'
  | 'select'
  | 'press'
  | 'check'
  | 'uncheck'
  | 'hover'
  | 'verify'
  | 'navigate'
  | 'setData'
  | 'ifStart'
  | 'else'
  | 'ifEnd'
  | 'comment'
  | 'noop';

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

export const DEFAULT_RUNTIME_OPTIONS: Required<RuntimeOptions> = {
  candidateTimeoutMs: 900,
  actionTimeoutMs: 8_000,
  navigationTimeoutMs: 15_000,
  maxFrameDepth: 12,
  maxFrames: 96,
  enableDomFallback: true,
  diagnostics: true,
};

export function asString(value: unknown): string | undefined {
  if (value === undefined || value === null) return undefined;
  if (Array.isArray(value)) {
    const first = value.find((entry) => entry !== undefined && entry !== null);
    return first === undefined ? undefined : String(first);
  }
  if (typeof value === 'object') return undefined;
  return String(value);
}

export function normalizeKey(value: string): string {
  return value.toLowerCase().replace(/[^a-z0-9]/g, '');
}

export function stableSlug(value: string): string {
  const slug = value
    .normalize('NFKD')
    .replace(/[\u0300-\u036f]/g, '')
    .replace(/[^A-Za-z0-9]+/g, '-')
    .replace(/^-+|-+$/g, '')
    .toLowerCase();
  return slug || 'unnamed';
}

export function stableIdentifier(value: string, fallback = 'item'): string {
  const words = value
    .normalize('NFKD')
    .replace(/[\u0300-\u036f]/g, '')
    .split(/[^A-Za-z0-9]+/)
    .filter(Boolean);
  const joined = words.map((word, index) => {
    const clean = word.replace(/^[^A-Za-z_$]+/, '');
    if (!clean) return '';
    return index === 0
      ? clean.charAt(0).toLowerCase() + clean.slice(1)
      : clean.charAt(0).toUpperCase() + clean.slice(1);
  }).join('');
  const result = joined || fallback;
  return /^[A-Za-z_$]/.test(result) ? result : `_${result}`;
}

export function canonicalJson(value: unknown): string {
  if (Array.isArray(value)) return `[${value.map(canonicalJson).join(',')}]`;
  if (value && typeof value === 'object') {
    const record = value as Record<string, unknown>;
    return `{${Object.keys(record).sort().map((key) => `${JSON.stringify(key)}:${canonicalJson(record[key])}`).join(',')}}`;
  }
  return JSON.stringify(value);
}

export function fnv1a(value: string): string {
  let hash = 0x811c9dc5;
  for (let index = 0; index < value.length; index += 1) {
    hash ^= value.charCodeAt(index);
    hash = Math.imul(hash, 0x01000193);
  }
  return (hash >>> 0).toString(16).padStart(8, '0');
}
