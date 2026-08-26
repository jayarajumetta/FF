"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FrameRuntime = void 0;
const model_1 = require("./model");
function quoteCssAttribute(value) {
    return `"${value.replace(/\\/g, '\\\\').replace(/"/g, '\\"').replace(/[\r\n\f]/g, ' ')}"`;
}
function hintScore(contextText, hints) {
    let score = 0;
    let explicit = false;
    const normalized = contextText.toLowerCase();
    for (const hint of hints) {
        const candidate = hint.trim().toLowerCase();
        if (!candidate)
            continue;
        if (normalized.includes(candidate)) {
            score += 500;
            explicit = true;
        }
    }
    return { score, explicit };
}
function suspiciousFrame(url, name) {
    const text = `${url} ${name}`.toLowerCase();
    return /(doubleclick|google-analytics|googletagmanager|recaptcha|intercom|hotjar|segment|adservice|about:blank$)/.test(text);
}
class FrameRuntime {
    constructor(options = {}) { this.options = { ...model_1.DEFAULT_RUNTIME_OPTIONS, ...options }; }
    async collectFrames(page, hints = []) {
        const contexts = [];
        const seen = new Set();
        const visit = async (frame, depth) => {
            if (!frame || seen.has(frame) || depth > this.options.maxFrameDepth || contexts.length >= this.options.maxFrames)
                return;
            seen.add(frame);
            let url = '';
            let name = '';
            let visible = true;
            try {
                url = String(frame.url?.() ?? '');
            }
            catch { /* ignored */ }
            try {
                name = String(frame.name?.() ?? '');
            }
            catch { /* ignored */ }
            if (depth > 0) {
                try {
                    const element = await frame.frameElement();
                    visible = await element.isVisible({ timeout: Math.min(300, this.options.candidateTimeoutMs) }).catch(() => false);
                }
                catch {
                    visible = false;
                }
            }
            const hint = hintScore(`${url} ${name}`, hints);
            let score = 1000 - depth * 15 + hint.score;
            if (!visible && !hint.explicit)
                score -= 300;
            if (suspiciousFrame(url, name) && !hint.explicit)
                score -= 450;
            if (depth === 0)
                score += 120;
            contexts.push({ frame, depth, index: contexts.length, url, name, score, visible, explicitHint: hint.explicit });
            let children = [];
            try {
                children = frame.childFrames?.() ?? [];
            }
            catch {
                children = [];
            }
            for (const child of children)
                await visit(child, depth + 1);
        };
        await visit(page.mainFrame(), 0);
        return contexts.sort((a, b) => b.score - a.score || a.depth - b.depth || a.index - b.index);
    }
    locatorFor(frame, candidate) {
        const exact = candidate.exact !== false;
        switch (candidate.kind) {
            case 'fieldRef': {
                const value = quoteCssAttribute(candidate.value);
                return frame.locator(`[FieldRef=${value}], [fieldref=${value}], [data-field-ref=${value}], [data-fieldref=${value}], [data-dc-fieldref=${value}]`);
            }
            case 'id': return frame.locator(`[id=${quoteCssAttribute(candidate.value)}]`);
            case 'testId': return typeof frame.getByTestId === 'function' ? frame.getByTestId(candidate.value) : frame.locator(`[data-testid=${quoteCssAttribute(candidate.value)}]`);
            case 'label': return frame.getByLabel(candidate.value, { exact });
            case 'role': return frame.getByRole(candidate.role, { name: candidate.value, exact });
            case 'name': return frame.locator(`[name=${quoteCssAttribute(candidate.value)}]`);
            case 'css': return frame.locator(candidate.value);
            case 'xpath': return frame.locator(candidate.value.startsWith('xpath=') ? candidate.value : `xpath=${candidate.value}`);
            case 'text': {
                if (candidate.tag)
                    return frame.locator(candidate.tag).filter({ hasText: candidate.value });
                return frame.getByText(candidate.value, { exact });
            }
            case 'labelAndAttribute': return frame.getByLabel(candidate.label ?? candidate.value, { exact });
            default: return frame.locator(candidate.value);
        }
    }
    async applyAttributeFilter(locator, candidate) {
        const count = await locator.count();
        const matches = [];
        for (let index = 0; index < count; index += 1) {
            const item = locator.nth(index);
            if (!candidate.attribute || candidate.attributeValue === undefined) {
                matches.push(item);
                continue;
            }
            const value = await item.getAttribute(candidate.attribute).catch(() => null)
                ?? await item.getAttribute(candidate.attribute.toLowerCase()).catch(() => null)
                ?? await item.getAttribute(candidate.attribute.toUpperCase()).catch(() => null);
            if (value === candidate.attributeValue)
                matches.push(item);
        }
        return matches;
    }
    async visibleLocators(locator, count) {
        const visible = [];
        for (let index = 0; index < count; index += 1) {
            const item = locator.nth(index);
            if (await item.isVisible({ timeout: Math.min(300, this.options.candidateTimeoutMs) }).catch(() => false))
                visible.push(item);
        }
        return visible;
    }
    async resolveTargets(page, descriptor) {
        const frames = await this.collectFrames(page, descriptor.frameHints);
        const orderedCandidates = [...descriptor.candidates].sort((a, b) => b.score - a.score);
        const resolved = [];
        for (let candidateIndex = 0; candidateIndex < orderedCandidates.length; candidateIndex += 1) {
            const candidate = orderedCandidates[candidateIndex];
            const candidateMatches = [];
            for (const frameContext of frames) {
                try {
                    const base = this.locatorFor(frameContext.frame, candidate);
                    if (candidate.kind === 'labelAndAttribute') {
                        const filtered = await this.applyAttributeFilter(base, candidate);
                        if (filtered.length === 1)
                            candidateMatches.push({ frameContext, locator: filtered[0], candidate, candidateIndex, count: 1 });
                        else if (filtered.length > 1 && descriptor.occurrence && descriptor.occurrence <= filtered.length) {
                            candidateMatches.push({ frameContext, locator: filtered[descriptor.occurrence - 1], candidate, candidateIndex, count: filtered.length, usedOccurrence: descriptor.occurrence });
                        }
                        continue;
                    }
                    const count = await base.count();
                    if (count === 0)
                        continue;
                    if (count === 1) {
                        candidateMatches.push({ frameContext, locator: base, candidate, candidateIndex, count });
                        continue;
                    }
                    if (descriptor.occurrence && descriptor.occurrence > 0 && descriptor.occurrence <= count) {
                        candidateMatches.push({ frameContext, locator: base.nth(descriptor.occurrence - 1), candidate, candidateIndex, count, usedOccurrence: descriptor.occurrence });
                        continue;
                    }
                    const visible = await this.visibleLocators(base, count);
                    if (visible.length === 1)
                        candidateMatches.push({ frameContext, locator: visible[0], candidate, candidateIndex, count });
                }
                catch { /* candidate absent or invalid in this frame */ }
            }
            if (candidateMatches.length === 1)
                resolved.push(candidateMatches[0]);
            else if (candidateMatches.length > 1) {
                const explicit = candidateMatches.filter((match) => match.frameContext.explicitHint);
                if (explicit.length === 1)
                    resolved.push(explicit[0]);
                else {
                    const visibleFrames = candidateMatches.filter((match) => match.frameContext.visible);
                    if (visibleFrames.length === 1)
                        resolved.push(visibleFrames[0]);
                    // Ambiguous candidates are deliberately not collapsed with a first-match shortcut. Try the next locator contract.
                }
            }
        }
        return resolved;
    }
    async domFallback(page, descriptor, action) {
        const frames = await this.collectFrames(page, descriptor.frameHints);
        const candidates = [...descriptor.candidates].sort((a, b) => b.score - a.score);
        for (const candidate of candidates) {
            for (const frameContext of frames) {
                try {
                    const result = await frameContext.frame.evaluate(({ candidate: c, occurrence, action: requested }) => {
                        const normalize = (value) => String(value ?? '').replace(/\s+/g, ' ').trim();
                        const exact = (left, right) => normalize(left) === normalize(right);
                        const allElements = () => {
                            const result = [];
                            const visit = (root) => {
                                const elements = Array.from(root.querySelectorAll('*'));
                                for (const element of elements) {
                                    result.push(element);
                                    const shadow = element.shadowRoot;
                                    if (shadow)
                                        visit(shadow);
                                }
                            };
                            visit(document);
                            return result;
                        };
                        const elements = allElements();
                        const attrCaseInsensitive = (element, name) => {
                            const attribute = Array.from(element.attributes).find((item) => item.name.toLowerCase() === name.toLowerCase());
                            return attribute?.value ?? null;
                        };
                        const labelsFor = (element) => {
                            const values = [];
                            const id = element.getAttribute('id');
                            if (id)
                                for (const label of elements.filter((item) => item.tagName.toLowerCase() === 'label' && item.getAttribute('for') === id))
                                    values.push(normalize(label.textContent));
                            const parent = element.closest('label');
                            if (parent)
                                values.push(normalize(parent.textContent));
                            const aria = element.getAttribute('aria-label');
                            if (aria)
                                values.push(normalize(aria));
                            const labelledBy = element.getAttribute('aria-labelledby');
                            if (labelledBy)
                                for (const ref of labelledBy.split(/\s+/)) {
                                    const label = document.getElementById(ref);
                                    if (label)
                                        values.push(normalize(label.textContent));
                                }
                            return values.filter(Boolean);
                        };
                        const roleOf = (element) => {
                            const explicitRole = element.getAttribute('role');
                            if (explicitRole)
                                return explicitRole.toLowerCase();
                            const tag = element.tagName.toLowerCase();
                            if (tag === 'a' && element.hasAttribute('href'))
                                return 'link';
                            if (tag === 'button')
                                return 'button';
                            if (tag === 'select')
                                return 'combobox';
                            if (tag === 'option')
                                return 'option';
                            if (tag === 'input') {
                                const type = (element.getAttribute('type') ?? 'text').toLowerCase();
                                if (['button', 'submit', 'reset', 'image'].includes(type))
                                    return 'button';
                                if (type === 'checkbox')
                                    return 'checkbox';
                                if (type === 'radio')
                                    return 'radio';
                                return element.getAttribute('list') ? 'combobox' : 'textbox';
                            }
                            return '';
                        };
                        const accessibleName = (element) => {
                            const aria = element.getAttribute('aria-label');
                            if (aria)
                                return normalize(aria);
                            const labels = labelsFor(element);
                            if (labels.length)
                                return labels[0];
                            const title = element.getAttribute('title');
                            if (title)
                                return normalize(title);
                            const value = element.value;
                            if (value && ['button', 'submit', 'reset'].includes((element.getAttribute('type') ?? '').toLowerCase()))
                                return normalize(value);
                            return normalize(element.textContent);
                        };
                        const query = () => {
                            let found = [];
                            if (c.kind === 'id')
                                found = elements.filter((element) => element.getAttribute('id') === c.value);
                            else if (c.kind === 'fieldRef')
                                found = elements.filter((element) => ['fieldref', 'data-field-ref', 'data-fieldref', 'data-dc-fieldref'].some((name) => attrCaseInsensitive(element, name) === c.value));
                            else if (c.kind === 'testId')
                                found = elements.filter((element) => attrCaseInsensitive(element, 'data-testid') === c.value);
                            else if (c.kind === 'name')
                                found = elements.filter((element) => element.getAttribute('name') === c.value);
                            else if (c.kind === 'label')
                                found = elements.filter((element) => labelsFor(element).some((label) => exact(label, c.value)));
                            else if (c.kind === 'labelAndAttribute')
                                found = elements.filter((element) => labelsFor(element).some((label) => exact(label, c.label ?? c.value)) && attrCaseInsensitive(element, c.attribute ?? '') === c.attributeValue);
                            else if (c.kind === 'role')
                                found = elements.filter((element) => roleOf(element) === String(c.role ?? '').toLowerCase() && exact(accessibleName(element), c.value));
                            else if (c.kind === 'text')
                                found = elements.filter((element) => (!c.tag || element.tagName.toLowerCase() === String(c.tag).toLowerCase()) && exact(element.textContent, c.value));
                            else if (c.kind === 'css') {
                                try {
                                    found = Array.from(document.querySelectorAll(c.value));
                                }
                                catch {
                                    found = [];
                                }
                            }
                            else if (c.kind === 'xpath') {
                                try {
                                    const expression = String(c.value).replace(/^xpath=/, '');
                                    const snapshot = document.evaluate(expression, document, null, XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null);
                                    for (let index = 0; index < snapshot.snapshotLength; index += 1) {
                                        const item = snapshot.snapshotItem(index);
                                        if (item instanceof Element)
                                            found.push(item);
                                    }
                                }
                                catch {
                                    found = [];
                                }
                            }
                            return found;
                        };
                        const matches = query();
                        if (!matches.length)
                            return { ok: false, matched: 0, detail: 'not found' };
                        let element;
                        if (occurrence && occurrence > 0 && occurrence <= matches.length)
                            element = matches[occurrence - 1];
                        else if (matches.length === 1)
                            element = matches[0];
                        else {
                            const visible = matches.filter((item) => {
                                const html = item;
                                const style = getComputedStyle(html);
                                return style.display !== 'none' && style.visibility !== 'hidden' && style.opacity !== '0' && html.getClientRects().length > 0;
                            });
                            if (visible.length === 1)
                                element = visible[0];
                        }
                        if (!element)
                            return { ok: false, matched: matches.length, detail: 'ambiguous' };
                        const html = element;
                        html.scrollIntoView({ block: 'center', inline: 'center' });
                        const dispatch = (name) => element.dispatchEvent(new Event(name, { bubbles: true, composed: true }));
                        const setNativeValue = (target, value) => {
                            const proto = target instanceof HTMLTextAreaElement ? HTMLTextAreaElement.prototype
                                : target instanceof HTMLSelectElement ? HTMLSelectElement.prototype : HTMLInputElement.prototype;
                            const setter = Object.getOwnPropertyDescriptor(proto, 'value')?.set;
                            if (setter)
                                setter.call(target, value);
                            else
                                target.value = value;
                        };
                        try {
                            html.focus?.();
                            switch (requested.kind) {
                                case 'click':
                                    html.click();
                                    break;
                                case 'fill':
                                    setNativeValue(element, String(requested.value ?? ''));
                                    dispatch('input');
                                    dispatch('change');
                                    break;
                                case 'select': {
                                    if (element instanceof HTMLSelectElement) {
                                        const wanted = normalize(requested.value).toLowerCase();
                                        const option = Array.from(element.options).find((entry) => normalize(entry.label).toLowerCase() === wanted || normalize(entry.textContent).toLowerCase() === wanted || normalize(entry.value).toLowerCase() === wanted);
                                        if (!option)
                                            return { ok: false, matched: matches.length, detail: 'native option not found' };
                                        setNativeValue(element, option.value);
                                        dispatch('input');
                                        dispatch('change');
                                    }
                                    else {
                                        html.click();
                                        const wanted = normalize(requested.value).toLowerCase();
                                        const option = allElements().find((entry) => ['option', 'mat-option'].includes(entry.tagName.toLowerCase()) || entry.getAttribute('role') === 'option');
                                        const exactOption = allElements().filter((entry) => ['option', 'mat-option'].includes(entry.tagName.toLowerCase()) || entry.getAttribute('role') === 'option')
                                            .find((entry) => normalize(entry.textContent).toLowerCase() === wanted || normalize(entry.getAttribute('aria-label')).toLowerCase() === wanted);
                                        const selected = exactOption ?? option;
                                        if (!selected)
                                            return { ok: false, matched: matches.length, detail: 'custom option not found' };
                                        selected.click();
                                    }
                                    break;
                                }
                                case 'check':
                                    if ('checked' in element) {
                                        element.checked = true;
                                        dispatch('input');
                                        dispatch('change');
                                    }
                                    else
                                        html.click();
                                    break;
                                case 'uncheck':
                                    if ('checked' in element) {
                                        element.checked = false;
                                        dispatch('input');
                                        dispatch('change');
                                    }
                                    else
                                        html.click();
                                    break;
                                case 'press': {
                                    const key = String(requested.value ?? requested.key ?? 'Enter');
                                    element.dispatchEvent(new KeyboardEvent('keydown', { key, bubbles: true, composed: true }));
                                    element.dispatchEvent(new KeyboardEvent('keyup', { key, bubbles: true, composed: true }));
                                    break;
                                }
                                default: return { ok: false, matched: matches.length, detail: `unsupported ${requested.kind}` };
                            }
                            return { ok: true, matched: matches.length, detail: 'DOM action completed' };
                        }
                        catch (error) {
                            return { ok: false, matched: matches.length, detail: String(error) };
                        }
                    }, { candidate, occurrence: descriptor.occurrence, action });
                    if (result?.ok)
                        return { ...result, candidate, frameContext };
                }
                catch { /* continue through frame tree */ }
            }
        }
        return { ok: false, matched: 0, detail: 'No unambiguous DOM target in any frame' };
    }
}
exports.FrameRuntime = FrameRuntime;
//# sourceMappingURL=frame-runtime.js.map