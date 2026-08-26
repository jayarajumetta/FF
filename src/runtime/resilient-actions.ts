import type { LocatorLike, PageLike } from '../contracts/playwright.js';
import type { CandidateBuildOptions, LocatorSpec } from '../locator/model.js';
import {
  ArrayDiagnosticSink,
  type ActionTrace,
  type AttemptDiagnostic,
  type DiagnosticSink,
  ResilientActionError,
  errorMessage,
  nowIso,
} from './diagnostics.js';
import { performDomFallback, type DomActionKind } from './dom-fallback.js';
import { performAcrossLocatorCandidates, resolveLocator, type LocatorAttemptContext } from './resolver.js';

export interface ResilientActionOptions {
  actionTimeoutMs?: number;
  maxPasses?: number;
  retryDelayMs?: number;
  allowDomFallback?: boolean;
  candidateOptions?: CandidateBuildOptions;
  sink?: DiagnosticSink;
}

interface ControlInspection {
  tag: string;
  role: string;
  type: string;
  ariaHasPopup: string;
  contentEditable: boolean;
  className: string;
}

class FanoutSink implements DiagnosticSink {
  constructor(private readonly sinks: readonly DiagnosticSink[]) {}

  emit(event: AttemptDiagnostic): void {
    for (const sink of this.sinks) sink.emit(event);
  }
}

function requiredMethod<T extends keyof LocatorLike>(
  locator: LocatorLike,
  method: T,
): NonNullable<LocatorLike[T]> {
  const value = locator[method];
  if (typeof value !== 'function') {
    throw new Error(`Locator adapter does not implement ${String(method)}().`);
  }
  return value.bind(locator) as NonNullable<LocatorLike[T]>;
}

function inspectionFromSpec(spec: LocatorSpec): ControlInspection {
  const rawTag = spec.raw?.find((item) => item.tag)?.tag ?? '';
  const controlType = (spec.controlType ?? '').toLowerCase();
  const tag = rawTag.toLowerCase();
  return {
    tag,
    role: spec.role?.role?.toLowerCase() ?? (controlType.includes('combo') ? 'combobox' : ''),
    type: '',
    ariaHasPopup: controlType.includes('combo') ? 'listbox' : '',
    contentEditable: false,
    className: '',
  };
}

async function inspectControl(locator: LocatorLike, spec: LocatorSpec): Promise<ControlInspection> {
  if (!locator.evaluate) return inspectionFromSpec(spec);
  try {
    return await locator.evaluate<ControlInspection>((element) => ({
      tag: element.tagName.toLowerCase(),
      role: (element.getAttribute('role') ?? '').toLowerCase(),
      type: (element.getAttribute('type') ?? '').toLowerCase(),
      ariaHasPopup: (element.getAttribute('aria-haspopup') ?? '').toLowerCase(),
      contentEditable: element instanceof HTMLElement && element.isContentEditable,
      className: element.getAttribute('class') ?? '',
    }));
  } catch {
    return inspectionFromSpec(spec);
  }
}

function isNativeSelect(control: ControlInspection): boolean {
  return control.tag === 'select';
}

function isInputBackedCombo(control: ControlInspection): boolean {
  return control.tag === 'input' ||
    control.tag === 'textarea' ||
    control.contentEditable ||
    (control.role === 'combobox' && control.tag !== 'mat-select');
}

function isCustomDropdown(control: ControlInspection, spec: LocatorSpec): boolean {
  const controlType = (spec.controlType ?? '').toLowerCase();
  return control.tag === 'mat-select' ||
    control.role === 'combobox' ||
    control.ariaHasPopup === 'listbox' ||
    controlType.includes('combo') ||
    controlType.includes('dropdown') ||
    controlType.includes('select');
}

export class ResilientActions {
  private readonly page: PageLike;
  private readonly config: Required<Omit<ResilientActionOptions, 'candidateOptions' | 'sink'>> &
    Pick<ResilientActionOptions, 'candidateOptions' | 'sink'>;

  constructor(
    page: PageLike | unknown,
    options: ResilientActionOptions = {},
  ) {
    if (!page || typeof page !== 'object' || typeof (page as PageLike).mainFrame !== 'function') {
      throw new TypeError('ResilientActions requires a Playwright Page-compatible object.');
    }
    this.page = page as PageLike;
    this.config = {
      actionTimeoutMs: options.actionTimeoutMs ?? 5_000,
      maxPasses: options.maxPasses ?? 2,
      retryDelayMs: options.retryDelayMs ?? 75,
      allowDomFallback: options.allowDomFallback ?? true,
      ...(options.candidateOptions === undefined ? {} : { candidateOptions: options.candidateOptions }),
      ...(options.sink === undefined ? {} : { sink: options.sink }),
    };
  }

  async locate(spec: LocatorSpec): Promise<LocatorLike> {
    const local = new ArrayDiagnosticSink();
    const sink = this.combinedSink(local);
    const result = await resolveLocator(this.page, spec, {
      maxPasses: this.config.maxPasses,
      retryDelayMs: this.config.retryDelayMs,
      ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
      sink,
    });
    if (result.resolved) return result.resolved.locator;
    throw new ResilientActionError('locate', spec, local.events);
  }

  async click(spec: LocatorSpec): Promise<ActionTrace> {
    return this.performSimple(spec, 'click', undefined, async ({ locator }) => {
      const click = requiredMethod(locator, 'click') as (options?: unknown) => Promise<void>;
      await click({ timeout: this.config.actionTimeoutMs });
    });
  }

  async fill(spec: LocatorSpec, value: unknown): Promise<ActionTrace> {
    const text = String(value ?? '');
    return this.performSimple(spec, 'fill', text, async ({ locator }) => {
      const fill = requiredMethod(locator, 'fill') as (value: string, options?: unknown) => Promise<void>;
      await fill(text, { timeout: this.config.actionTimeoutMs });
    });
  }

  async press(spec: LocatorSpec, key: string): Promise<ActionTrace> {
    return this.performSimple(spec, 'press', key, async ({ locator }) => {
      const press = requiredMethod(locator, 'press') as (key: string, options?: unknown) => Promise<void>;
      await press(key, { timeout: this.config.actionTimeoutMs });
    });
  }

  async check(spec: LocatorSpec): Promise<ActionTrace> {
    return this.performSimple(spec, 'check', undefined, async ({ locator }) => {
      const check = requiredMethod(locator, 'check') as (options?: unknown) => Promise<void>;
      await check({ timeout: this.config.actionTimeoutMs });
    });
  }

  async uncheck(spec: LocatorSpec): Promise<ActionTrace> {
    return this.performSimple(spec, 'uncheck', undefined, async ({ locator }) => {
      const uncheck = requiredMethod(locator, 'uncheck') as (options?: unknown) => Promise<void>;
      await uncheck({ timeout: this.config.actionTimeoutMs });
    });
  }

  async waitVisible(spec: LocatorSpec): Promise<ActionTrace> {
    return this.performSimple(spec, 'wait visible', undefined, async ({ locator }) => {
      if (locator.waitFor) {
        await locator.waitFor({ state: 'visible', timeout: this.config.actionTimeoutMs });
        return;
      }
      if (locator.isVisible && await locator.isVisible({ timeout: this.config.actionTimeoutMs })) return;
      throw new Error('Locator did not become visible.');
    }, false);
  }

  /**
   * Selects native HTML selects, Angular Material controls, and input-backed
   * comboboxes. It never appends an unconditional Tab after selection.
   */
  async select(spec: LocatorSpec, value: unknown): Promise<ActionTrace> {
    const text = String(value ?? '');
    const local = new ArrayDiagnosticSink();
    const sink = this.combinedSink(local);

    const normal = await performAcrossLocatorCandidates(
      this.page,
      spec,
      async (context) => {
        const control = await inspectControl(context.locator, spec);
        if (isNativeSelect(control)) {
          await this.selectNative(context.locator, text);
          return;
        }

        if (isInputBackedCombo(control)) {
          await this.fillComboInput(context.locator, text);
          if (await this.chooseOpenOption(spec, context, text, sink)) return;
          await this.keyboardDropdownFallback(context.locator);
          return;
        }

        if (isCustomDropdown(control, spec)) {
          const click = requiredMethod(context.locator, 'click') as (options?: unknown) => Promise<void>;
          await click({ timeout: this.config.actionTimeoutMs });
          if (await this.chooseOpenOption(spec, context, text, sink)) return;
          await this.keyboardDropdownFallback(context.locator);
          return;
        }

        // Unknown controls get a conservative custom-dropdown attempt before
        // falling through to the next locator candidate.
        const click = requiredMethod(context.locator, 'click') as (options?: unknown) => Promise<void>;
        await click({ timeout: this.config.actionTimeoutMs });
        if (!(await this.chooseOpenOption(spec, context, text, sink))) {
          throw new Error(`No visible option matched "${text}".`);
        }
      },
      {
        maxPasses: this.config.maxPasses,
        retryDelayMs: this.config.retryDelayMs,
        ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
        sink,
      },
    );

    if ('value' in normal) {
      return {
        locator: spec,
        action: 'select',
        diagnostics: local.events,
        usedDomFallback: false,
      };
    }

    if (this.config.allowDomFallback) {
      // Native select final fallback.
      const native = await performDomFallback(this.page, spec, 'select', text, {
        ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
        sink,
      });
      if (native.succeeded) {
        return {
          locator: spec,
          action: 'select',
          diagnostics: local.events,
          usedDomFallback: true,
        };
      }

      // Custom dropdown final fallback: click trigger inside its frame, then
      // locate/click the option across the refreshed frame tree.
      const trigger = await performDomFallback(this.page, spec, 'click', undefined, {
        ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
        sink,
      });
      if (trigger.succeeded) {
        const optionSpec = this.optionSpec(spec, text);
        const option = await performDomFallback(this.page, optionSpec, 'click', undefined, {
          ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
          sink,
        });
        if (option.succeeded) {
          return {
            locator: spec,
            action: 'select',
            diagnostics: local.events,
            usedDomFallback: true,
          };
        }
      }
    }

    throw new ResilientActionError('select', spec, local.events);
  }

  private combinedSink(local: ArrayDiagnosticSink): DiagnosticSink {
    return this.config.sink ? new FanoutSink([local, this.config.sink]) : local;
  }

  private async performSimple(
    spec: LocatorSpec,
    actionLabel: string,
    fallbackValue: string | undefined,
    operation: (context: LocatorAttemptContext) => Promise<void>,
    allowDomFallback = this.config.allowDomFallback,
  ): Promise<ActionTrace> {
    const local = new ArrayDiagnosticSink();
    const sink = this.combinedSink(local);
    const result = await performAcrossLocatorCandidates(
      this.page,
      spec,
      operation,
      {
        maxPasses: this.config.maxPasses,
        retryDelayMs: this.config.retryDelayMs,
        ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
        sink,
      },
    );
    if ('value' in result) {
      return {
        locator: spec,
        action: actionLabel,
        diagnostics: local.events,
        usedDomFallback: false,
      };
    }

    if (allowDomFallback) {
      const domAction = this.domActionFor(actionLabel);
      if (domAction) {
        const fallback = await performDomFallback(this.page, spec, domAction, fallbackValue, {
          ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
          sink,
        });
        if (fallback.succeeded) {
          return {
            locator: spec,
            action: actionLabel,
            diagnostics: local.events,
            usedDomFallback: true,
          };
        }
      }
    }

    throw new ResilientActionError(actionLabel, spec, local.events);
  }

  private domActionFor(action: string): DomActionKind | undefined {
    if (action === 'click' || action === 'fill' || action === 'press' || action === 'check' || action === 'uncheck') {
      return action;
    }
    return undefined;
  }

  private async selectNative(locator: LocatorLike, value: string): Promise<void> {
    const selectOption = requiredMethod(locator, 'selectOption') as (
      values: unknown,
      options?: unknown,
    ) => Promise<string[]>;
    try {
      await selectOption({ label: value }, { timeout: this.config.actionTimeoutMs });
    } catch (labelError) {
      try {
        await selectOption({ value }, { timeout: this.config.actionTimeoutMs });
      } catch (valueError) {
        throw new Error(
          `Native select could not choose label/value "${value}". Label attempt: ${errorMessage(labelError)}; value attempt: ${errorMessage(valueError)}`,
        );
      }
    }
  }

  private async fillComboInput(locator: LocatorLike, value: string): Promise<void> {
    if (locator.fill) {
      await locator.fill(value, { timeout: this.config.actionTimeoutMs });
      return;
    }
    if (locator.pressSequentially) {
      await locator.pressSequentially(value, { timeout: this.config.actionTimeoutMs });
      return;
    }
    throw new Error('Input-backed combobox exposes neither fill() nor pressSequentially().');
  }

  private async keyboardDropdownFallback(locator: LocatorLike): Promise<void> {
    const press = requiredMethod(locator, 'press') as (key: string, options?: unknown) => Promise<void>;
    await press('ArrowDown', { timeout: this.config.actionTimeoutMs });
    await press('Enter', { timeout: this.config.actionTimeoutMs });
    // Intentionally no Tab. Focus movement is generated only when raw Tosca
    // contains an explicit Tab action with independent evidence.
  }

  private optionSpec(
    source: LocatorSpec,
    value: string,
    framePath?: readonly number[],
  ): LocatorSpec {
    return {
      key: `${source.key}::option::${value}`,
      ...(source.app === undefined ? {} : { app: source.app }),
      controlType: 'Option',
      role: { role: 'option', name: value, exact: true },
      text: value,
      css: '[role="option"], mat-option, option',
      ...(framePath === undefined ? {} : { frame: { path: framePath } }),
    };
  }

  private async chooseOpenOption(
    source: LocatorSpec,
    context: LocatorAttemptContext,
    value: string,
    sink: DiagnosticSink,
  ): Promise<boolean> {
    const optionSpec = this.optionSpec(source, value, context.frame.path);
    const result = await performAcrossLocatorCandidates(
      this.page,
      optionSpec,
      async ({ locator }) => {
        const click = requiredMethod(locator, 'click') as (options?: unknown) => Promise<void>;
        await click({ timeout: this.config.actionTimeoutMs });
      },
      {
        maxPasses: 2,
        retryDelayMs: this.config.retryDelayMs,
        ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
        sink,
      },
    );
    if ('value' in result) return true;

    if (!this.config.allowDomFallback) return false;
    const fallback = await performDomFallback(this.page, optionSpec, 'click', undefined, {
      ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
      sink,
    });
    return fallback.succeeded;
  }
}

/** Drop-in helper for generated tests that prefer functions over a class. */
export function createResilientActions(
  page: PageLike,
  options: ResilientActionOptions = {},
): ResilientActions {
  return new ResilientActions(page, options);
}
