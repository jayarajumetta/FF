import type { PageLike } from '../contracts/playwright.js';
import { buildLocatorCandidates } from '../locator/candidate-builder.js';
import type { CandidateBuildOptions, DomCandidate, LocatorSpec } from '../locator/model.js';
import {
  ArrayDiagnosticSink,
  type AttemptDiagnostic,
  type DiagnosticSink,
  errorMessage,
  nowIso,
} from './diagnostics.js';
import { enumerateFrames } from './frame-search.js';

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

interface DomActionRequest {
  candidate: DomCandidate;
  action: DomActionKind;
  value?: string;
}

interface DomEvaluationResult {
  ok: boolean;
  count: number;
  selectedIndex?: number;
  detail: string;
}

function emit(
  sink: DiagnosticSink,
  event: Omit<AttemptDiagnostic, 'timestamp'>,
): void {
  sink.emit({ ...event, timestamp: nowIso() });
}

/**
 * Final audited fallback. It runs inside each Playwright Frame execution
 * context; it never tries to cross a same-origin boundary with top.document.
 */
export async function performDomFallback(
  page: PageLike,
  spec: LocatorSpec,
  action: DomActionKind,
  value: string | undefined,
  options: DomFallbackOptions = {},
): Promise<DomFallbackResult> {
  const sink = options.sink ?? new ArrayDiagnosticSink();
  const candidates = buildLocatorCandidates(spec, options.candidateOptions);

  for (const frameRecord of enumerateFrames(page, spec.frame)) {
    if (!frameRecord.frame.evaluate) {
      emit(sink, {
        phase: 'dom-fallback',
        locatorKey: spec.key,
        frame: frameRecord.label,
        status: 'skipped',
        message: 'Frame adapter does not expose evaluate().',
      });
      continue;
    }

    for (const candidate of candidates) {
      const request: DomActionRequest = {
        candidate: candidate.dom,
        action,
        ...(value === undefined ? {} : { value }),
      };
      try {
        const result = await frameRecord.frame.evaluate<DomEvaluationResult, DomActionRequest>(
          (payload) => {
            const normalize = (input: string | null | undefined): string =>
              (input ?? '').replace(/\s+/g, ' ').trim();

            const isVisible = (element: Element): boolean => {
              if (!(element instanceof HTMLElement || element instanceof SVGElement)) return true;
              const style = globalThis.getComputedStyle(element);
              const rect = element.getBoundingClientRect();
              return style.display !== 'none' &&
                style.visibility !== 'hidden' &&
                style.visibility !== 'collapse' &&
                rect.width > 0 &&
                rect.height > 0;
            };

            const allRoots = (root: Document | ShadowRoot | Element): Array<Document | ShadowRoot | Element> => {
              const roots: Array<Document | ShadowRoot | Element> = [root];
              const stack: Array<Document | ShadowRoot | Element> = [root];
              const seen = new Set<Node>([root]);
              while (stack.length > 0) {
                const current = stack.pop();
                if (!current || !('querySelectorAll' in current)) continue;
                for (const element of Array.from(current.querySelectorAll('*'))) {
                  if (element.shadowRoot && !seen.has(element.shadowRoot)) {
                    seen.add(element.shadowRoot);
                    roots.push(element.shadowRoot);
                    stack.push(element.shadowRoot);
                  }
                }
              }
              return roots;
            };

            const queryCss = (
              root: Document | ShadowRoot | Element,
              selector: string,
            ): Element[] => {
              const output: Element[] = [];
              const seen = new Set<Element>();
              for (const queryRoot of allRoots(root)) {
                try {
                  for (const element of Array.from(queryRoot.querySelectorAll(selector))) {
                    if (!seen.has(element)) {
                      seen.add(element);
                      output.push(element);
                    }
                  }
                } catch {
                  return [];
                }
              }
              return output;
            };

            const queryXPath = (
              root: Document | Element,
              xpath: string,
            ): Element[] => {
              const documentNode = root instanceof Document ? root : root.ownerDocument;
              if (!documentNode) return [];
              const output: Element[] = [];
              try {
                const result = documentNode.evaluate(
                  xpath,
                  root,
                  null,
                  XPathResult.ORDERED_NODE_SNAPSHOT_TYPE,
                  null,
                );
                for (let index = 0; index < result.snapshotLength; index += 1) {
                  const node = result.snapshotItem(index);
                  if (node instanceof Element) output.push(node);
                }
              } catch {
                return [];
              }
              return output;
            };

            const accessibleName = (element: Element): string => {
              const labelledBy = element.getAttribute('aria-labelledby');
              if (labelledBy) {
                const labels = labelledBy
                  .split(/\s+/)
                  .map((id) => document.getElementById(id)?.textContent ?? '')
                  .join(' ');
                if (normalize(labels)) return normalize(labels);
              }
              const ariaLabel = element.getAttribute('aria-label');
              if (normalize(ariaLabel)) return normalize(ariaLabel);
              if (element instanceof HTMLInputElement && normalize(element.value)) {
                return normalize(element.value);
              }
              return normalize(element.textContent ?? element.getAttribute('title'));
            };

            const implicitRole = (element: Element): string => {
              const explicit = normalize(element.getAttribute('role')).toLowerCase();
              if (explicit) return explicit;
              const tag = element.tagName.toLowerCase();
              if (tag === 'button') return 'button';
              if (tag === 'a' && element.hasAttribute('href')) return 'link';
              if (tag === 'select') return 'combobox';
              if (tag === 'textarea') return 'textbox';
              if (tag === 'option' || tag === 'mat-option') return 'option';
              if (tag === 'input') {
                const type = (element.getAttribute('type') ?? 'text').toLowerCase();
                if (['button', 'submit', 'reset', 'image'].includes(type)) return 'button';
                if (type === 'checkbox') return 'checkbox';
                if (type === 'radio') return 'radio';
                if (['text', 'email', 'password', 'search', 'tel', 'url', 'number'].includes(type)) {
                  return type === 'search' ? 'searchbox' : 'textbox';
                }
              }
              if (tag === 'mat-select') return 'combobox';
              return '';
            };

            const resolveScopes = (): Array<Document | Element | ShadowRoot> => {
              if (payload.candidate.scopeSelector) {
                return queryCss(document, payload.candidate.scopeSelector);
              }
              if (payload.candidate.scopeXPath) {
                return queryXPath(document, payload.candidate.scopeXPath);
              }
              return [document];
            };

            const findWithin = (scope: Document | Element | ShadowRoot): Element[] => {
              const descriptor = payload.candidate;
              if (descriptor.kind === 'xpath' && descriptor.selector) {
                if (scope instanceof ShadowRoot) return [];
                return queryXPath(scope, descriptor.selector.replace(/^xpath=/, ''));
              }
              if (descriptor.selector) return queryCss(scope, descriptor.selector);

              if (descriptor.kind === 'label' && descriptor.value) {
                const expected = normalize(descriptor.value);
                const output: Element[] = [];
                for (const label of queryCss(scope, 'label')) {
                  if (normalize(label.textContent) !== expected) continue;
                  const htmlFor = label.getAttribute('for');
                  const target = htmlFor ? document.getElementById(htmlFor) : label.querySelector('input,textarea,select,[role]');
                  if (target) output.push(target);
                }
                for (const element of queryCss(scope, '[aria-label]')) {
                  if (normalize(element.getAttribute('aria-label')) === expected) output.push(element);
                }
                return output;
              }

              if (descriptor.kind === 'role' && descriptor.role) {
                const expectedName = normalize(descriptor.accessibleName);
                const candidates = queryCss(
                  scope,
                  '[role],button,a[href],input,select,textarea,option,mat-select,mat-option',
                );
                return candidates.filter((element) => {
                  if (implicitRole(element) !== descriptor.role) return false;
                  if (!expectedName) return true;
                  const actual = accessibleName(element);
                  return descriptor.exact === false
                    ? actual.toLowerCase().includes(expectedName.toLowerCase())
                    : actual === expectedName;
                });
              }

              if (descriptor.kind === 'text' && descriptor.value) {
                const expected = normalize(descriptor.value);
                return queryCss(
                  scope,
                  'button,a,input,option,mat-option,[role],label,span,div',
                ).filter((element) => {
                  const actual = accessibleName(element);
                  return descriptor.exact === false
                    ? actual.toLowerCase().includes(expected.toLowerCase())
                    : actual === expected;
                });
              }

              return [];
            };

            const matches: Element[] = [];
            const seen = new Set<Element>();
            for (const scope of resolveScopes()) {
              for (const match of findWithin(scope)) {
                if (!seen.has(match) && isVisible(match)) {
                  seen.add(match);
                  matches.push(match);
                }
              }
            }

            let index = 0;
            if (matches.length > 1) {
              if (payload.candidate.occurrence !== undefined) {
                index = payload.candidate.occurrence - 1;
              } else {
                return {
                  ok: false,
                  count: matches.length,
                  detail: 'DOM fallback remained ambiguous; no raw Tosca occurrence was available.',
                };
              }
            }
            const element = matches[index];
            if (!element) {
              return {
                ok: false,
                count: matches.length,
                detail: payload.candidate.occurrence !== undefined
                  ? `Requested occurrence ${payload.candidate.occurrence} is outside ${matches.length} matches.`
                  : 'No visible element matched.',
              };
            }

            const dispatchValueEvents = (target: Element): void => {
              target.dispatchEvent(new Event('input', { bubbles: true, composed: true }));
              target.dispatchEvent(new Event('change', { bubbles: true, composed: true }));
            };

            const setNativeValue = (target: Element, nextValue: string): boolean => {
              if (target instanceof HTMLInputElement) {
                const setter = Object.getOwnPropertyDescriptor(HTMLInputElement.prototype, 'value')?.set;
                setter?.call(target, nextValue);
                dispatchValueEvents(target);
                return true;
              }
              if (target instanceof HTMLTextAreaElement) {
                const setter = Object.getOwnPropertyDescriptor(HTMLTextAreaElement.prototype, 'value')?.set;
                setter?.call(target, nextValue);
                dispatchValueEvents(target);
                return true;
              }
              if (target instanceof HTMLElement && target.isContentEditable) {
                target.focus();
                target.textContent = nextValue;
                dispatchValueEvents(target);
                return true;
              }
              return false;
            };

            const actionValue = payload.value ?? '';
            switch (payload.action) {
              case 'click': {
                if (element instanceof HTMLElement || element instanceof SVGElement) {
                  element.dispatchEvent(new MouseEvent('mousedown', { bubbles: true, composed: true }));
                  element.dispatchEvent(new MouseEvent('mouseup', { bubbles: true, composed: true }));
                  if ('click' in element && typeof element.click === 'function') element.click();
                  else element.dispatchEvent(new MouseEvent('click', { bubbles: true, composed: true }));
                  return { ok: true, count: matches.length, selectedIndex: index, detail: 'DOM click dispatched.' };
                }
                return { ok: false, count: matches.length, selectedIndex: index, detail: 'Matched node is not clickable.' };
              }
              case 'fill': {
                if (element instanceof HTMLElement) element.focus();
                const ok = setNativeValue(element, actionValue);
                return { ok, count: matches.length, selectedIndex: index, detail: ok ? 'Native value setter and input/change events dispatched.' : 'Matched element does not support fill.' };
              }
              case 'select': {
                if (element instanceof HTMLSelectElement) {
                  const option = Array.from(element.options).find(
                    (item) => item.value === actionValue || normalize(item.textContent) === normalize(actionValue),
                  );
                  if (!option) return { ok: false, count: matches.length, selectedIndex: index, detail: `Native option not found: ${actionValue}` };
                  element.value = option.value;
                  dispatchValueEvents(element);
                  return { ok: true, count: matches.length, selectedIndex: index, detail: 'Native select option assigned.' };
                }
                return { ok: false, count: matches.length, selectedIndex: index, detail: 'Custom dropdown requires trigger/option fallback.' };
              }
              case 'check':
              case 'uncheck': {
                if (element instanceof HTMLInputElement && ['checkbox', 'radio'].includes(element.type)) {
                  const checked = payload.action === 'check';
                  const setter = Object.getOwnPropertyDescriptor(HTMLInputElement.prototype, 'checked')?.set;
                  setter?.call(element, checked);
                  dispatchValueEvents(element);
                  return { ok: true, count: matches.length, selectedIndex: index, detail: `Native checked=${checked} assigned.` };
                }
                return { ok: false, count: matches.length, selectedIndex: index, detail: 'Matched element is not a checkbox/radio input.' };
              }
              case 'press': {
                if (element instanceof HTMLElement) element.focus();
                const init: KeyboardEventInit = { key: actionValue, bubbles: true, composed: true };
                element.dispatchEvent(new KeyboardEvent('keydown', init));
                element.dispatchEvent(new KeyboardEvent('keypress', init));
                element.dispatchEvent(new KeyboardEvent('keyup', init));
                return { ok: true, count: matches.length, selectedIndex: index, detail: `Keyboard events dispatched for ${actionValue}.` };
              }
              default:
                return { ok: false, count: matches.length, selectedIndex: index, detail: 'Unsupported fallback action.' };
            }
          },
          request,
        );

        emit(sink, {
          phase: 'dom-fallback',
          locatorKey: spec.key,
          frame: frameRecord.label,
          candidate,
          count: result.count,
          ...(result.selectedIndex === undefined ? {} : { selectedIndex: result.selectedIndex }),
          status: result.ok ? 'succeeded' : result.count > 1 ? 'ambiguous' : 'miss',
          message: result.detail,
        });
        if (result.ok) {
          return {
            succeeded: true,
            diagnostics: sink instanceof ArrayDiagnosticSink ? sink.events : [],
            frame: frameRecord.label,
            candidateSource: candidate.source,
            detail: result.detail,
          };
        }
      } catch (error) {
        emit(sink, {
          phase: 'dom-fallback',
          locatorKey: spec.key,
          frame: frameRecord.label,
          candidate,
          status: 'failed',
          message: errorMessage(error),
        });
      }
    }
  }

  return {
    succeeded: false,
    diagnostics: sink instanceof ArrayDiagnosticSink ? sink.events : [],
  };
}
