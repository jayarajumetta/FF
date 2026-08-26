"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ResilientInteractionEngine = void 0;
const frame_runtime_1 = require("./frame-runtime");
function now() { return Date.now(); }
class ResilientInteractionEngine {
    constructor(page, options = {}) {
        this.page = page;
        this.traces = [];
        this.frames = new frame_runtime_1.FrameRuntime(options);
    }
    trace(action, started, status, strategy, detail, target) {
        this.traces.push({
            actionId: action.id, action: action.kind, locatorId: action.locatorId, candidate: target?.candidate,
            frameUrl: target?.frameContext.url, frameName: target?.frameContext.name, frameDepth: target?.frameContext.depth,
            strategy, status, detail, durationMs: Date.now() - started,
        });
    }
    async click(target, action) {
        await target.locator.click({ timeout: this.frames.options.actionTimeoutMs });
    }
    async fill(target, action) {
        await target.locator.fill(String(action.value ?? ''), { timeout: this.frames.options.actionTimeoutMs });
    }
    async press(target, action) {
        await target.locator.press(String(action.value ?? action.key ?? 'Enter'), { timeout: this.frames.options.actionTimeoutMs });
    }
    async check(target, checked) {
        if (checked)
            await target.locator.check({ timeout: this.frames.options.actionTimeoutMs });
        else
            await target.locator.uncheck({ timeout: this.frames.options.actionTimeoutMs });
    }
    async optionInFrame(frame, value) {
        const exactRole = frame.getByRole?.('option', { name: value, exact: true });
        if (exactRole && await exactRole.count().catch(() => 0) === 1)
            return exactRole;
        const selectors = [
            `mat-option`, `[role="option"]`, `.mat-option`, `.mat-mdc-option`, `option`,
            `[data-value]`, `[aria-label]`, `.dropdown-item`, `.select-option`,
        ];
        for (const selector of selectors) {
            const options = frame.locator(selector).filter({ hasText: value });
            const count = await options.count().catch(() => 0);
            if (count === 1)
                return options;
            if (count > 1) {
                const exact = [];
                for (let index = 0; index < count; index += 1) {
                    const item = options.nth(index);
                    const text = String(await item.innerText().catch(() => '')).replace(/\s+/g, ' ').trim();
                    const aria = String(await item.getAttribute('aria-label').catch(() => '')).trim();
                    const dataValue = String(await item.getAttribute('data-value').catch(() => '')).trim();
                    if ([text, aria, dataValue].some((candidate) => candidate.toLowerCase() === value.trim().toLowerCase()))
                        exact.push(item);
                }
                if (exact.length === 1)
                    return exact[0];
            }
        }
        return undefined;
    }
    async select(target, action) {
        const value = String(action.value ?? '');
        const tag = String(await target.locator.evaluate((element) => element.tagName.toLowerCase()).catch(() => ''));
        if (tag === 'select') {
            const attempts = [{ label: value }, { value }];
            for (const attempt of attempts) {
                try {
                    const selected = await target.locator.selectOption(attempt, { timeout: this.frames.options.actionTimeoutMs });
                    if (selected?.length)
                        return;
                }
                catch { /* next native option contract */ }
            }
            throw new Error(`Native select option not found: ${value}`);
        }
        const editable = await target.locator.evaluate((element) => {
            const tagName = element.tagName.toLowerCase();
            return tagName === 'input' || tagName === 'textarea' || element.getAttribute('contenteditable') === 'true';
        }).catch(() => false);
        if (editable) {
            await target.locator.fill(value, { timeout: this.frames.options.actionTimeoutMs }).catch(async () => {
                await target.locator.click({ timeout: this.frames.options.actionTimeoutMs });
            });
        }
        else {
            await target.locator.click({ timeout: this.frames.options.actionTimeoutMs });
        }
        // Duck Creek/Angular overlays normally live in the control's frame, but the main frame is also checked.
        const frameContexts = await this.frames.collectFrames(this.page, target.frameContext.explicitHint ? [target.frameContext.name, target.frameContext.url] : []);
        const ordered = [target.frameContext, ...frameContexts.filter((entry) => entry.frame !== target.frameContext.frame)];
        for (const context of ordered) {
            const option = await this.optionInFrame(context.frame, value);
            if (!option)
                continue;
            await option.click({ timeout: this.frames.options.actionTimeoutMs });
            return;
        }
        if (editable) {
            // Keyboard fallback is intentionally last and does not add an automatic Tab.
            await target.locator.press('ArrowDown', { timeout: this.frames.options.actionTimeoutMs });
            await target.locator.press('Enter', { timeout: this.frames.options.actionTimeoutMs });
            return;
        }
        throw new Error(`Combobox option not found: ${value}`);
    }
    async performOnTarget(target, action) {
        switch (action.kind) {
            case 'click': return this.click(target, action);
            case 'fill': return this.fill(target, action);
            case 'select': return this.select(target, action);
            case 'press': return this.press(target, action);
            case 'check': return this.check(target, true);
            case 'uncheck': return this.check(target, false);
            case 'hover': return target.locator.hover({ timeout: this.frames.options.actionTimeoutMs });
            case 'verify': {
                const expected = String(action.value ?? '');
                const actual = String(await target.locator.innerText({ timeout: this.frames.options.actionTimeoutMs }).catch(() => target.locator.inputValue({ timeout: this.frames.options.actionTimeoutMs })));
                if (!actual.includes(expected))
                    throw new Error(`Verification failed. Expected ${JSON.stringify(expected)} in ${JSON.stringify(actual)}`);
                return;
            }
            default: throw new Error(`Unsupported element action: ${action.kind}`);
        }
    }
    async perform(action) {
        const started = now();
        if (action.kind === 'navigate') {
            const target = String(action.value ?? '');
            await this.page.goto(target, { waitUntil: 'domcontentloaded', timeout: this.frames.options.navigationTimeoutMs });
            this.trace(action, started, 'passed', 'navigation', target);
            return;
        }
        const descriptor = action.locator;
        if (!descriptor && action.kind === 'press' && action.metadata?.globalKeyboard) {
            await this.page.keyboard.press(String(action.value ?? action.key ?? 'Enter'));
            this.trace(action, started, 'passed', 'playwright', 'explicit page-level keyboard action');
            return;
        }
        if (!descriptor) {
            this.trace(action, started, 'failed', 'playwright', 'No locator descriptor');
            throw new Error(`No locator for action ${action.id}`);
        }
        const targets = await this.frames.resolveTargets(this.page, descriptor);
        const failures = [];
        for (const target of targets) {
            let navigationPromise;
            const previousUrl = String(this.page.url?.() ?? '');
            if (action.kind === 'click' && action.navigationExpected) {
                navigationPromise = this.page.waitForURL((url) => String(url) !== previousUrl, { timeout: this.frames.options.navigationTimeoutMs }).catch(() => undefined);
            }
            try {
                await this.performOnTarget(target, action);
                if (navigationPromise) {
                    await navigationPromise;
                    if (String(this.page.url?.() ?? '') !== previousUrl)
                        await this.page.waitForLoadState('domcontentloaded', { timeout: this.frames.options.navigationTimeoutMs }).catch(() => undefined);
                }
                this.trace(action, started, 'passed', 'playwright', undefined, target);
                return;
            }
            catch (error) {
                failures.push(`${target.candidate.kind}@${target.frameContext.url}: ${String(error)}`);
            }
        }
        if (this.frames.options.enableDomFallback && ['click', 'fill', 'select', 'press', 'check', 'uncheck'].includes(action.kind)) {
            const fallback = await this.frames.domFallback(this.page, descriptor, { kind: action.kind, value: action.value, key: action.key });
            if (fallback.ok) {
                this.traces.push({
                    actionId: action.id, action: action.kind, locatorId: action.locatorId, candidate: fallback.candidate,
                    frameUrl: fallback.frameContext?.url, frameName: fallback.frameContext?.name, frameDepth: fallback.frameContext?.depth,
                    strategy: 'dom-fallback', status: 'passed', detail: fallback.detail, durationMs: Date.now() - started,
                });
                return;
            }
            failures.push(`DOM fallback: ${fallback.detail}`);
        }
        const detail = failures.length ? failures.join('\n') : 'No unambiguous locator candidate found';
        this.trace(action, started, 'failed', 'playwright', detail);
        throw new Error(`Action ${action.id} failed:\n${detail}`);
    }
}
exports.ResilientInteractionEngine = ResilientInteractionEngine;
//# sourceMappingURL=interactions.js.map