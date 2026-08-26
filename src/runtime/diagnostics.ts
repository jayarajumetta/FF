import type { LocatorCandidate, LocatorSpec } from '../locator/model.js';

export type AttemptPhase =
  | 'resolve'
  | 'action'
  | 'dropdown'
  | 'dom-fallback'
  | 'frame-discovery';

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

export class ArrayDiagnosticSink implements DiagnosticSink {
  readonly events: AttemptDiagnostic[] = [];

  emit(event: AttemptDiagnostic): void {
    this.events.push(event);
  }
}

export function nowIso(): string {
  return new Date().toISOString();
}

export function errorMessage(error: unknown): string {
  if (error instanceof Error) return `${error.name}: ${error.message}`;
  return String(error);
}

export class ResilientActionError extends Error {
  readonly locator: LocatorSpec;
  readonly action: string;
  readonly diagnostics: readonly AttemptDiagnostic[];

  constructor(
    action: string,
    locator: LocatorSpec,
    diagnostics: readonly AttemptDiagnostic[],
  ) {
    const compact = diagnostics
      .slice(-8)
      .map((entry) => `${entry.frame}/${entry.candidate?.kind ?? 'n/a'}:${entry.status}${entry.message ? `(${entry.message})` : ''}`)
      .join(' | ');
    super(
      `v57 could not ${action} locator "${locator.key}" after Playwright and in-frame DOM fallbacks.${compact ? ` Attempts: ${compact}` : ''}`,
    );
    this.name = 'ResilientActionError';
    this.action = action;
    this.locator = locator;
    this.diagnostics = diagnostics;
  }
}
