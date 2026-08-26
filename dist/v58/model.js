"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DEFAULT_RUNTIME_OPTIONS = void 0;
exports.asString = asString;
exports.normalizeKey = normalizeKey;
exports.stableSlug = stableSlug;
exports.stableIdentifier = stableIdentifier;
exports.canonicalJson = canonicalJson;
exports.fnv1a = fnv1a;
exports.DEFAULT_RUNTIME_OPTIONS = {
    candidateTimeoutMs: 900,
    actionTimeoutMs: 8000,
    navigationTimeoutMs: 15000,
    maxFrameDepth: 12,
    maxFrames: 96,
    enableDomFallback: true,
    diagnostics: true,
};
function asString(value) {
    if (value === undefined || value === null)
        return undefined;
    if (Array.isArray(value)) {
        const first = value.find((entry) => entry !== undefined && entry !== null);
        return first === undefined ? undefined : String(first);
    }
    if (typeof value === 'object')
        return undefined;
    return String(value);
}
function normalizeKey(value) {
    return value.toLowerCase().replace(/[^a-z0-9]/g, '');
}
function stableSlug(value) {
    const slug = value
        .normalize('NFKD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/[^A-Za-z0-9]+/g, '-')
        .replace(/^-+|-+$/g, '')
        .toLowerCase();
    return slug || 'unnamed';
}
function stableIdentifier(value, fallback = 'item') {
    const words = value
        .normalize('NFKD')
        .replace(/[\u0300-\u036f]/g, '')
        .split(/[^A-Za-z0-9]+/)
        .filter(Boolean);
    const joined = words.map((word, index) => {
        const clean = word.replace(/^[^A-Za-z_$]+/, '');
        if (!clean)
            return '';
        return index === 0
            ? clean.charAt(0).toLowerCase() + clean.slice(1)
            : clean.charAt(0).toUpperCase() + clean.slice(1);
    }).join('');
    const result = joined || fallback;
    return /^[A-Za-z_$]/.test(result) ? result : `_${result}`;
}
function canonicalJson(value) {
    if (Array.isArray(value))
        return `[${value.map(canonicalJson).join(',')}]`;
    if (value && typeof value === 'object') {
        const record = value;
        return `{${Object.keys(record).sort().map((key) => `${JSON.stringify(key)}:${canonicalJson(record[key])}`).join(',')}}`;
    }
    return JSON.stringify(value);
}
function fnv1a(value) {
    let hash = 0x811c9dc5;
    for (let index = 0; index < value.length; index += 1) {
        hash ^= value.charCodeAt(index);
        hash = Math.imul(hash, 0x01000193);
    }
    return (hash >>> 0).toString(16).padStart(8, '0');
}
//# sourceMappingURL=model.js.map