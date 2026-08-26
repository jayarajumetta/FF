"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LocatorRegistry = void 0;
exports.buildLocatorDescriptor = buildLocatorDescriptor;
exports.inferLob = inferLob;
exports.propertyValue = propertyValue;
const model_1 = require("./model");
function clean(value) {
    const result = value?.trim();
    return result ? result : undefined;
}
function isDynamicId(value) {
    return /(^|[-_:])(\d{5,}|[a-f0-9]{8,})([-_:]|$)/i.test(value)
        || /^(ember|react|ng|mat|cdk|ext)-?\d+/i.test(value)
        || /\{.+\}|\[.+\]/.test(value);
}
function isUsefulText(value) {
    const trimmed = value.trim();
    return trimmed.length >= 2 && trimmed.length <= 160 && !/^\d+$/.test(trimmed);
}
function roleAliases(evidence) {
    const role = clean(evidence.role)?.toLowerCase();
    const tag = clean(evidence.tag)?.toLowerCase();
    const aliases = [];
    if (tag === 'a')
        aliases.push('link', 'button');
    else if (tag === 'button')
        aliases.push('button', 'link');
    else if (role === 'button' || role === 'link')
        aliases.push(role, role === 'button' ? 'link' : 'button');
    else if (role)
        aliases.push(role);
    if (!aliases.length && /button|continue|next|submit|login|save|cancel/i.test(evidence.name))
        aliases.push('button', 'link');
    return [...new Set(aliases)];
}
function candidateKey(candidate) {
    return (0, model_1.canonicalJson)({
        kind: candidate.kind, value: candidate.value, exact: candidate.exact ?? true, role: candidate.role,
        tag: candidate.tag, attribute: candidate.attribute, attributeValue: candidate.attributeValue, label: candidate.label,
    });
}
function addCandidate(target, candidate) {
    if (!candidate.value.trim())
        return;
    if (!target.some((entry) => candidateKey(entry) === candidateKey(candidate)))
        target.push(candidate);
}
function buildLocatorDescriptor(evidence) {
    const candidates = [];
    const fieldRef = clean(evidence.fieldRef);
    const id = clean(evidence.id);
    const label = clean(evidence.label ?? evidence.accessibleName);
    const controlName = clean(evidence.controlName);
    const tag = clean(evidence.tag)?.toLowerCase();
    // Duck Creek FieldRef is an application contract and is deliberately first for PLDC/CLDC.
    if (fieldRef)
        addCandidate(candidates, { kind: 'fieldRef', value: fieldRef, exact: true, score: 1000, source: 'Tosca FieldRef' });
    if (id && !isDynamicId(id))
        addCandidate(candidates, { kind: 'id', value: id, exact: true, score: 970, source: 'stable DOM id' });
    if (clean(evidence.testId))
        addCandidate(candidates, { kind: 'testId', value: clean(evidence.testId), exact: true, score: 950, source: 'test id' });
    if (label && fieldRef)
        addCandidate(candidates, {
            kind: 'labelAndAttribute', value: label, label, attribute: 'fieldref', attributeValue: fieldRef,
            exact: true, tag, score: 940, source: 'label + FieldRef',
        });
    if (label && id)
        addCandidate(candidates, {
            kind: 'labelAndAttribute', value: label, label, attribute: 'id', attributeValue: id,
            exact: true, tag, score: 930, source: 'label + id',
        });
    if (label)
        addCandidate(candidates, { kind: 'label', value: label, exact: true, tag, score: 900, source: 'associated label' });
    const accessibleName = clean(evidence.accessibleName ?? evidence.label ?? evidence.name);
    if (accessibleName && isUsefulText(accessibleName)) {
        for (const role of roleAliases(evidence)) {
            addCandidate(candidates, { kind: 'role', value: accessibleName, role, exact: true, tag, score: role === 'link' && tag === 'a' ? 895 : 890, source: 'ARIA role/name' });
        }
    }
    if (controlName)
        addCandidate(candidates, { kind: 'name', value: controlName, exact: true, tag, score: 850, source: 'form control name' });
    if (clean(evidence.css))
        addCandidate(candidates, { kind: 'css', value: clean(evidence.css), exact: true, score: 620, source: 'Tosca CSS' });
    if (accessibleName && isUsefulText(accessibleName))
        addCandidate(candidates, { kind: 'text', value: accessibleName, exact: true, tag, score: 500, source: 'visible text fallback' });
    if (clean(evidence.xpath))
        addCandidate(candidates, { kind: 'xpath', value: clean(evidence.xpath), exact: true, score: 350, source: 'Tosca XPath last resort' });
    candidates.sort((a, b) => b.score - a.score || candidateKey(a).localeCompare(candidateKey(b)));
    const canonical = (0, model_1.canonicalJson)({ lob: evidence.lob, moduleId: evidence.moduleId, candidates: candidates.map(candidateKey), occurrence: evidence.occurrence, frameHints: [...evidence.frameHints].sort() });
    const fingerprint = (0, model_1.fnv1a)(canonical);
    return {
        id: `loc-${(0, model_1.stableSlug)(evidence.lob)}-${(0, model_1.stableSlug)(evidence.name)}-${fingerprint}`,
        name: evidence.name,
        lob: evidence.lob,
        moduleId: evidence.moduleId,
        aliases: [],
        candidates,
        occurrence: evidence.occurrence && evidence.occurrence > 0 ? evidence.occurrence : undefined,
        frameHints: [...new Set(evidence.frameHints.filter(Boolean))],
        fingerprint,
        evidence,
    };
}
class LocatorRegistry {
    constructor() {
        this.byFingerprint = new Map();
        this.aliasToId = new Map();
    }
    register(evidence) {
        const descriptor = buildLocatorDescriptor(evidence);
        const existing = this.byFingerprint.get(descriptor.fingerprint);
        const alias = `${evidence.moduleId ?? 'global'}:${evidence.controlId}`;
        if (existing) {
            if (!existing.aliases.includes(alias))
                existing.aliases.push(alias);
            this.aliasToId.set(alias, existing.id);
            return existing;
        }
        descriptor.aliases.push(alias);
        this.byFingerprint.set(descriptor.fingerprint, descriptor);
        this.aliasToId.set(alias, descriptor.id);
        return descriptor;
    }
    getByAlias(moduleId, controlId) {
        const id = this.aliasToId.get(`${moduleId ?? 'global'}:${controlId}`);
        return id ? this.values().find((entry) => entry.id === id) : undefined;
    }
    values() { return [...this.byFingerprint.values()].sort((a, b) => a.id.localeCompare(b.id)); }
    aliases() { return Object.fromEntries([...this.aliasToId.entries()].sort(([a], [b]) => a.localeCompare(b))); }
}
exports.LocatorRegistry = LocatorRegistry;
function inferLob(...values) {
    const text = values.filter(Boolean).join(' ').toUpperCase();
    if (/\bPL[-_ ]?DC\b|PERSONAL\s+LINES/.test(text))
        return 'PLDC';
    if (/\bCL[-_ ]?DC\b|COMMERCIAL\s+LINES/.test(text))
        return 'CLDC';
    if (/\bCL[-_ ]?EQ\b|COMMERCIAL.*EARTHQUAKE/.test(text))
        return 'CLEQ';
    return 'UNKNOWN';
}
function propertyValue(properties, ...names) {
    const wanted = new Set(names.map(model_1.normalizeKey));
    for (const [key, value] of Object.entries(properties)) {
        if (!wanted.has((0, model_1.normalizeKey)(key)) || value === undefined || value === null)
            continue;
        const selected = Array.isArray(value) ? value.find((item) => item !== undefined && item !== null) : value;
        if (selected !== undefined && selected !== null && typeof selected !== 'object')
            return String(selected).trim() || undefined;
    }
    return undefined;
}
//# sourceMappingURL=locators.js.map