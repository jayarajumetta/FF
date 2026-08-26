import { ArrayDiagnosticSink, ResilientActionError, errorMessage, nowIso, } from './diagnostics.js';
import { performDomFallback } from './dom-fallback.js';
import { performAcrossLocatorCandidates, resolveLocator } from './resolver.js';
class FanoutSink {
    sinks;
    constructor(sinks) {
        this.sinks = sinks;
    }
    emit(event) {
        for (const sink of this.sinks)
            sink.emit(event);
    }
}
function requiredMethod(locator, method) {
    const value = locator[method];
    if (typeof value !== 'function') {
        throw new Error(`Locator adapter does not implement ${String(method)}().`);
    }
    return value.bind(locator);
}
function inspectionFromSpec(spec) {
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
async function inspectControl(locator, spec) {
    if (!locator.evaluate)
        return inspectionFromSpec(spec);
    try {
        return await locator.evaluate((element) => ({
            tag: element.tagName.toLowerCase(),
            role: (element.getAttribute('role') ?? '').toLowerCase(),
            type: (element.getAttribute('type') ?? '').toLowerCase(),
            ariaHasPopup: (element.getAttribute('aria-haspopup') ?? '').toLowerCase(),
            contentEditable: element instanceof HTMLElement && element.isContentEditable,
            className: element.getAttribute('class') ?? '',
        }));
    }
    catch {
        return inspectionFromSpec(spec);
    }
}
function isNativeSelect(control) {
    return control.tag === 'select';
}
function isInputBackedCombo(control) {
    return control.tag === 'input' ||
        control.tag === 'textarea' ||
        control.contentEditable ||
        (control.role === 'combobox' && control.tag !== 'mat-select');
}
function isCustomDropdown(control, spec) {
    const controlType = (spec.controlType ?? '').toLowerCase();
    return control.tag === 'mat-select' ||
        control.role === 'combobox' ||
        control.ariaHasPopup === 'listbox' ||
        controlType.includes('combo') ||
        controlType.includes('dropdown') ||
        controlType.includes('select');
}
export class ResilientActions {
    page;
    config;
    constructor(page, options = {}) {
        if (!page || typeof page !== 'object' || typeof page.mainFrame !== 'function') {
            throw new TypeError('ResilientActions requires a Playwright Page-compatible object.');
        }
        this.page = page;
        this.config = {
            actionTimeoutMs: options.actionTimeoutMs ?? 5_000,
            maxPasses: options.maxPasses ?? 2,
            retryDelayMs: options.retryDelayMs ?? 75,
            allowDomFallback: options.allowDomFallback ?? true,
            ...(options.candidateOptions === undefined ? {} : { candidateOptions: options.candidateOptions }),
            ...(options.sink === undefined ? {} : { sink: options.sink }),
        };
    }
    async locate(spec) {
        const local = new ArrayDiagnosticSink();
        const sink = this.combinedSink(local);
        const result = await resolveLocator(this.page, spec, {
            maxPasses: this.config.maxPasses,
            retryDelayMs: this.config.retryDelayMs,
            ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
            sink,
        });
        if (result.resolved)
            return result.resolved.locator;
        throw new ResilientActionError('locate', spec, local.events);
    }
    async click(spec) {
        return this.performSimple(spec, 'click', undefined, async ({ locator }) => {
            const click = requiredMethod(locator, 'click');
            await click({ timeout: this.config.actionTimeoutMs });
        });
    }
    async fill(spec, value) {
        const text = String(value ?? '');
        return this.performSimple(spec, 'fill', text, async ({ locator }) => {
            const fill = requiredMethod(locator, 'fill');
            await fill(text, { timeout: this.config.actionTimeoutMs });
        });
    }
    async press(spec, key) {
        return this.performSimple(spec, 'press', key, async ({ locator }) => {
            const press = requiredMethod(locator, 'press');
            await press(key, { timeout: this.config.actionTimeoutMs });
        });
    }
    async check(spec) {
        return this.performSimple(spec, 'check', undefined, async ({ locator }) => {
            const check = requiredMethod(locator, 'check');
            await check({ timeout: this.config.actionTimeoutMs });
        });
    }
    async uncheck(spec) {
        return this.performSimple(spec, 'uncheck', undefined, async ({ locator }) => {
            const uncheck = requiredMethod(locator, 'uncheck');
            await uncheck({ timeout: this.config.actionTimeoutMs });
        });
    }
    async waitVisible(spec) {
        return this.performSimple(spec, 'wait visible', undefined, async ({ locator }) => {
            if (locator.waitFor) {
                await locator.waitFor({ state: 'visible', timeout: this.config.actionTimeoutMs });
                return;
            }
            if (locator.isVisible && await locator.isVisible({ timeout: this.config.actionTimeoutMs }))
                return;
            throw new Error('Locator did not become visible.');
        }, false);
    }
    /**
     * Selects native HTML selects, Angular Material controls, and input-backed
     * comboboxes. It never appends an unconditional Tab after selection.
     */
    async select(spec, value) {
        const text = String(value ?? '');
        const local = new ArrayDiagnosticSink();
        const sink = this.combinedSink(local);
        const normal = await performAcrossLocatorCandidates(this.page, spec, async (context) => {
            const control = await inspectControl(context.locator, spec);
            if (isNativeSelect(control)) {
                await this.selectNative(context.locator, text);
                return;
            }
            if (isInputBackedCombo(control)) {
                await this.fillComboInput(context.locator, text);
                if (await this.chooseOpenOption(spec, context, text, sink))
                    return;
                await this.keyboardDropdownFallback(context.locator);
                return;
            }
            if (isCustomDropdown(control, spec)) {
                const click = requiredMethod(context.locator, 'click');
                await click({ timeout: this.config.actionTimeoutMs });
                if (await this.chooseOpenOption(spec, context, text, sink))
                    return;
                await this.keyboardDropdownFallback(context.locator);
                return;
            }
            // Unknown controls get a conservative custom-dropdown attempt before
            // falling through to the next locator candidate.
            const click = requiredMethod(context.locator, 'click');
            await click({ timeout: this.config.actionTimeoutMs });
            if (!(await this.chooseOpenOption(spec, context, text, sink))) {
                throw new Error(`No visible option matched "${text}".`);
            }
        }, {
            maxPasses: this.config.maxPasses,
            retryDelayMs: this.config.retryDelayMs,
            ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
            sink,
        });
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
    combinedSink(local) {
        return this.config.sink ? new FanoutSink([local, this.config.sink]) : local;
    }
    async performSimple(spec, actionLabel, fallbackValue, operation, allowDomFallback = this.config.allowDomFallback) {
        const local = new ArrayDiagnosticSink();
        const sink = this.combinedSink(local);
        const result = await performAcrossLocatorCandidates(this.page, spec, operation, {
            maxPasses: this.config.maxPasses,
            retryDelayMs: this.config.retryDelayMs,
            ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
            sink,
        });
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
    domActionFor(action) {
        if (action === 'click' || action === 'fill' || action === 'press' || action === 'check' || action === 'uncheck') {
            return action;
        }
        return undefined;
    }
    async selectNative(locator, value) {
        const selectOption = requiredMethod(locator, 'selectOption');
        try {
            await selectOption({ label: value }, { timeout: this.config.actionTimeoutMs });
        }
        catch (labelError) {
            try {
                await selectOption({ value }, { timeout: this.config.actionTimeoutMs });
            }
            catch (valueError) {
                throw new Error(`Native select could not choose label/value "${value}". Label attempt: ${errorMessage(labelError)}; value attempt: ${errorMessage(valueError)}`);
            }
        }
    }
    async fillComboInput(locator, value) {
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
    async keyboardDropdownFallback(locator) {
        const press = requiredMethod(locator, 'press');
        await press('ArrowDown', { timeout: this.config.actionTimeoutMs });
        await press('Enter', { timeout: this.config.actionTimeoutMs });
        // Intentionally no Tab. Focus movement is generated only when raw Tosca
        // contains an explicit Tab action with independent evidence.
    }
    optionSpec(source, value, framePath) {
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
    async chooseOpenOption(source, context, value, sink) {
        const optionSpec = this.optionSpec(source, value, context.frame.path);
        const result = await performAcrossLocatorCandidates(this.page, optionSpec, async ({ locator }) => {
            const click = requiredMethod(locator, 'click');
            await click({ timeout: this.config.actionTimeoutMs });
        }, {
            maxPasses: 2,
            retryDelayMs: this.config.retryDelayMs,
            ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
            sink,
        });
        if ('value' in result)
            return true;
        if (!this.config.allowDomFallback)
            return false;
        const fallback = await performDomFallback(this.page, optionSpec, 'click', undefined, {
            ...(this.config.candidateOptions === undefined ? {} : { candidateOptions: this.config.candidateOptions }),
            sink,
        });
        return fallback.succeeded;
    }
}
/** Drop-in helper for generated tests that prefer functions over a class. */
export function createResilientActions(page, options = {}) {
    return new ResilientActions(page, options);
}
//# sourceMappingURL=resilient-actions.js.map