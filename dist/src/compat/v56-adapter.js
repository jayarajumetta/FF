import { ResilientActions, } from '../runtime/resilient-actions.js';
export function toV57Locator(input, key = 'legacyLocator', app = 'UNKNOWN') {
    if (typeof input === 'string') {
        const selector = input.trim();
        if (selector.startsWith('xpath=') || selector.startsWith('//') || selector.startsWith('(//')) {
            return { key, app, xpath: selector.replace(/^xpath=/, '') };
        }
        return { key, app, css: selector };
    }
    const raw = input;
    const roleValue = raw.role;
    const roleName = typeof roleValue === 'string' ? roleValue : undefined;
    const roleObject = roleValue && typeof roleValue === 'object'
        ? roleValue
        : undefined;
    const selector = typeof raw.selector === 'string' ? raw.selector : undefined;
    const css = typeof raw.css === 'string' ? raw.css : selector;
    const xpath = typeof raw.xpath === 'string' ? raw.xpath.replace(/^xpath=/, '') : undefined;
    const targetKey = typeof raw.key === 'string' ? raw.key : key;
    const text = typeof raw.text === 'string' ? raw.text : undefined;
    return {
        key: targetKey,
        app: typeof raw.app === 'string' ? raw.app : app,
        ...(typeof raw.controlType === 'string' ? { controlType: raw.controlType } : {}),
        ...(typeof raw.fieldRef === 'string' || Array.isArray(raw.fieldRef)
            ? { fieldRef: raw.fieldRef }
            : {}),
        ...(typeof raw.id === 'string' ? { id: raw.id } : {}),
        ...(typeof raw.testId === 'string' ? { testId: raw.testId } : {}),
        ...(typeof raw.name === 'string' ? { name: raw.name } : {}),
        ...(typeof raw.formControlName === 'string' ? { formControlName: raw.formControlName } : {}),
        ...(typeof raw.label === 'string' ? { label: raw.label } : {}),
        ...(text === undefined ? {} : { text }),
        ...(roleObject
            ? { role: roleObject }
            : roleName
                ? { role: { role: roleName, ...(text ? { name: text } : {}) } }
                : {}),
        ...(css === undefined ? {} : { css }),
        ...(xpath === undefined ? {} : { xpath }),
        ...(typeof raw.occurrence === 'number' ? { occurrence: raw.occurrence } : {}),
        ...(raw.frame && typeof raw.frame === 'object' ? { frame: raw.frame } : {}),
        ...(raw.scope && typeof raw.scope === 'object' ? { scope: raw.scope } : {}),
        ...(Array.isArray(raw.raw) ? { raw: raw.raw } : {}),
    };
}
export function createV57CompatibilityLayer(page, options = {}) {
    const ui = new ResilientActions(page, options);
    return {
        ui,
        safeClick: (target, key, app) => ui.click(toV57Locator(target, key, app)),
        safeFill: (target, value, key, app) => ui.fill(toV57Locator(target, key, app), value),
        chooseDropdownOption: (target, value, key, app) => ui.select(toV57Locator(target, key, app), value),
        safePress: (target, keyName, key, app) => ui.press(toV57Locator(target, key, app), keyName),
    };
}
export function cldcLoginLocator(input) {
    return {
        key: 'cldcLogin',
        app: 'CLDC',
        controlType: 'Link',
        ...(input.fieldRef === undefined ? {} : { fieldRef: input.fieldRef }),
        ...(input.id === undefined ? {} : { id: input.id }),
        ...(input.accessibleName === undefined
            ? { roleAlternates: [{ role: 'link' }, { role: 'button' }] }
            : {
                text: input.accessibleName,
                role: { role: 'link', name: input.accessibleName, exact: true },
                roleAlternates: [{ role: 'button', name: input.accessibleName, exact: true }],
            }),
    };
}
export function pldcFieldLocator(key, fieldRef, fallback = {}) {
    return {
        key,
        app: 'PLDC',
        ...(fieldRef === undefined ? {} : { fieldRef }),
        ...fallback,
    };
}
//# sourceMappingURL=v56-adapter.js.map