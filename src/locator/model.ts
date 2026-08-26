export type ApplicationFamily = 'PLDC' | 'CLDC' | 'BOP' | 'EQ' | 'UNKNOWN' | string;

export interface RoleEvidence {
  role: string;
  name?: string;
  exact?: boolean;
}

export interface FrameHint {
  /** Exact or partial frame name/id from Tosca metadata. */
  name?: string;
  /** String substring or regular expression source matched against frame URL. */
  url?: string;
  /** Optional iframe element selector. Used for diagnostics and future direct routing. */
  selector?: string;
  /** Known zero-based path through childFrames(). */
  path?: readonly number[];
}

export interface ScopeEvidence {
  /** Preferred stable scope selector. */
  css?: string;
  /** XPath scope retained only as a lower-confidence fallback. */
  xpath?: string;
  /** Human-readable anchor text when no stable scope attribute exists. */
  text?: string;
}

export interface RawLocatorEvidence {
  sourceFile?: string;
  entityGuid?: string;
  moduleGuid?: string;
  moduleName?: string;
  controlName?: string;
  fieldRef?: string;
  id?: string;
  tag?: string;
  controlType?: string;
  occurrence?: number;
  order?: number;
  customXPath?: string;
  rawProperties?: Readonly<Record<string, string>>;
}

export interface LocatorSpec {
  /** Stable semantic key used for registry deduplication and diagnostics. */
  key: string;
  app?: ApplicationFamily;
  controlType?: string;
  fieldRef?: string | readonly string[];
  id?: string;
  testId?: string;
  name?: string;
  formControlName?: string;
  label?: string;
  placeholder?: string;
  title?: string;
  text?: string;
  role?: RoleEvidence;
  /** Explicit role alternatives. CLDC link/button mismatches are added automatically. */
  roleAlternates?: readonly RoleEvidence[];
  css?: string;
  xpath?: string;
  /** Tosca occurrence is one-based. It is used only when raw evidence is explicit. */
  occurrence?: number;
  frame?: FrameHint;
  scope?: ScopeEvidence;
  aliases?: readonly string[];
  raw?: readonly RawLocatorEvidence[];
}

export type CandidateKind =
  | 'fieldRef'
  | 'testId'
  | 'id'
  | 'role'
  | 'label'
  | 'placeholder'
  | 'name'
  | 'formControlName'
  | 'title'
  | 'text'
  | 'css'
  | 'xpath';

export interface LocatorCandidate {
  kind: CandidateKind;
  score: number;
  source: string;
  selector?: string;
  value?: string;
  role?: RoleEvidence;
  occurrence?: number;
  scope?: ScopeEvidence;
  /** Descriptor used by the final in-frame DOM fallback. */
  dom: DomCandidate;
}

export interface DomCandidate {
  kind: CandidateKind;
  selector?: string;
  value?: string;
  role?: string;
  accessibleName?: string;
  exact?: boolean;
  occurrence?: number;
  scopeSelector?: string;
  scopeXPath?: string;
}

export interface CandidateBuildOptions {
  fieldRefAttributes?: readonly string[];
  testIdAttribute?: string;
  includeTextFallback?: boolean;
  includeXPathFallback?: boolean;
}

export const DEFAULT_FIELD_REF_ATTRIBUTES = Object.freeze([
  'data-fieldref',
  'data-field-ref',
  'fieldref',
  'data-field-reference',
  'data-automation-fieldref',
]);
