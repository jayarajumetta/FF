import { locatorSpecFromRawEvidence } from './raw-evidence.js';
function valueByNames(properties, names) {
    for (const name of names) {
        const key = Object.keys(properties).find((candidate) => candidate.toLowerCase() === name.toLowerCase());
        const value = key ? properties[key]?.trim() : undefined;
        if (value)
            return value;
    }
    return undefined;
}
function inferApp(locator, fallback = 'UNKNOWN') {
    const text = `${locator?.fieldRef ?? ''} ${locator?.moduleName ?? ''}`.toUpperCase();
    if (/\bPL[._ -]?DC\b/.test(text) || text.startsWith('PLDC.'))
        return 'PLDC';
    if (/\bCL[._ -]?DC\b/.test(text) || text.startsWith('CLDC.'))
        return 'CLDC';
    if (/\bBOP\b/.test(text))
        return 'BOP';
    if (/\bEQ\b/.test(text))
        return 'EQ';
    return fallback;
}
function valueExpression(value) {
    if (value === undefined)
        return { kind: 'literal', value: '' };
    const exact = value.match(/^\{([^{}]+)}$/);
    if (exact?.[1])
        return { kind: 'data', key: exact[1].trim() };
    if (/\{\{[^}]+}}|\{[^{}]+}/.test(value))
        return { kind: 'template', template: value };
    if (/^(true|false)$/i.test(value))
        return { kind: 'literal', value: value.toLowerCase() === 'true' };
    if (/^-?(?:\d+\.?\d*|\.\d+)$/.test(value.trim()))
        return { kind: 'literal', value: Number(value) };
    return { kind: 'literal', value };
}
function actionKind(action, locator) {
    const mode = (action.actionMode ?? '').trim().toLowerCase();
    const controlType = (locator?.controlType ?? '').toLowerCase();
    if (['click', 'tap', 'doubleclick'].includes(mode))
        return 'click';
    if (['select', 'choose'].includes(mode))
        return 'select';
    if (['input', 'set', 'type'].includes(mode)) {
        if (controlType.includes('combo') || controlType.includes('select') || controlType.includes('dropdown'))
            return 'select';
        if (controlType.includes('check') || controlType.includes('radio')) {
            const rawValue = (action.value ?? '').toLowerCase();
            return ['false', '0', 'off', 'unchecked'].includes(rawValue) ? 'uncheck' : 'check';
        }
        return 'fill';
    }
    if (['sendkeys', 'press', 'key'].includes(mode))
        return 'press';
    if (['waiton', 'wait', 'exists'].includes(mode))
        return 'waitVisible';
    if (['verify', 'assert', 'compare'].includes(mode)) {
        return controlType.includes('text') || controlType.includes('input') ? 'verifyValue' : 'verifyText';
    }
    if (['buffer', 'setbuffer', 'store'].includes(mode))
        return 'dataSet';
    return 'comment';
}
function normalizedKey(value) {
    const key = value.trim().toLowerCase().replace(/[^a-z0-9]+/g, '');
    return key;
}
function locatorForAction(action, evidence, fallbackApp) {
    const actionName = action.controlName ?? action.stepName;
    if (!actionName)
        return {};
    const normalized = normalizedKey(actionName);
    const candidates = evidence.locators.filter((locator) => {
        const values = [locator.controlName, locator.fieldRef, locator.id].filter((item) => Boolean(item));
        return values.some((value) => normalizedKey(value) === normalized || normalizedKey(value).endsWith(normalized));
    });
    const raw = candidates[0];
    if (!raw) {
        return {
            spec: {
                key: actionName,
                app: fallbackApp,
                text: actionName,
                aliases: action.stepName && action.stepName !== actionName ? [action.stepName] : [],
            },
        };
    }
    const app = inferApp(raw, fallbackApp);
    return { raw, spec: locatorSpecFromRawEvidence(raw, app, actionName) };
}
function actionId(action, index) {
    const value = action.entityGuid ?? `${action.controlName ?? action.stepName ?? 'action'}-${index + 1}`;
    return value.replace(/[^A-Za-z0-9_.-]+/g, '-');
}
export function buildScenarioFromEvidence(evidence, options = {}) {
    const fallbackApp = options.app ?? 'UNKNOWN';
    const includeUnmatched = options.includeUnmatchedActions ?? true;
    const actions = [];
    evidence.actions.forEach((rawAction, index) => {
        const { raw: rawLocator, spec } = locatorForAction(rawAction, evidence, fallbackApp);
        const kind = actionKind(rawAction, rawLocator);
        if (!spec && !includeUnmatched && kind !== 'dataSet' && kind !== 'comment')
            return;
        const dataKey = kind === 'dataSet'
            ? valueByNames(rawAction.properties, ['BufferName', 'DataKey', 'Target']) ?? rawAction.controlName ?? `BUFFER_${index + 1}`
            : undefined;
        actions.push({
            id: actionId(rawAction, index),
            order: rawAction.order ?? index + 1,
            kind,
            ...(spec === undefined || kind === 'dataSet' || kind === 'comment' ? {} : { target: spec }),
            ...(kind === 'click' || kind === 'check' || kind === 'uncheck' || kind === 'waitVisible'
                ? {}
                : { value: valueExpression(rawAction.value) }),
            ...(dataKey === undefined ? {} : { dataKey }),
            ...(rawAction.condition === undefined ? {} : { condition: rawAction.condition }),
            origin: 'raw',
            metadata: {
                ...(rawAction.actionMode === undefined ? {} : { actionMode: rawAction.actionMode }),
                ...(rawAction.sourceFile === undefined ? {} : { sourceFile: rawAction.sourceFile }),
                ...(rawAction.entityGuid === undefined ? {} : { sourceGuid: rawAction.entityGuid }),
                ...(rawAction.order === undefined ? {} : { rawOrder: rawAction.order }),
                ...(spec === undefined ? { notes: ['No matching raw locator evidence was found.'] } : {}),
            },
        });
    });
    return {
        name: options.name ?? 'Tosca converted scenario',
        app: fallbackApp,
        ...(options.initialData === undefined ? {} : { initialData: options.initialData }),
        actions,
    };
}
export function buildScenarioFromTsu(result, options = {}) {
    const scenario = buildScenarioFromEvidence(result.evidence, options);
    return {
        ...scenario,
        ...(result.sourceFile === undefined ? {} : { sourceFiles: [result.sourceFile] }),
    };
}
//# sourceMappingURL=scenario-builder.js.map