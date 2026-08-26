import { readFileSync } from 'node:fs';
import { gunzipSync } from 'node:zlib';
import { extractRawToscaEvidence, extractRawToscaEvidenceFromObject, } from './raw-evidence.js';
function isGzip(buffer) {
    return buffer.length >= 2 && buffer[0] === 0x1f && buffer[1] === 0x8b;
}
function stripBom(text) {
    return text.charCodeAt(0) === 0xfeff ? text.slice(1) : text;
}
function parseText(text) {
    const trimmed = stripBom(text).trim();
    if (trimmed.startsWith('{') || trimmed.startsWith('[')) {
        try {
            return { format: 'json', value: JSON.parse(trimmed) };
        }
        catch {
            // Preserve malformed JSON as text so evidence extraction can still run.
        }
    }
    if (trimmed.startsWith('<'))
        return { format: 'xml', value: trimmed };
    return { format: 'text', value: text };
}
function tryDecodeBase64Gzip(value, maxBytes) {
    const compact = value.replace(/\s+/g, '');
    if (!compact.startsWith('H4sI') || compact.length < 12)
        return undefined;
    try {
        const compressed = Buffer.from(compact, 'base64');
        if (!isGzip(compressed))
            return undefined;
        const inflated = gunzipSync(compressed);
        if (inflated.length > maxBytes)
            return undefined;
        return parseText(inflated.toString('utf8'));
    }
    catch {
        return undefined;
    }
}
function entityGuid(object) {
    const names = ['Surrogate', 'surrogate', 'Guid', 'GUID', 'guid', 'UniqueId', 'uniqueId'];
    for (const name of names) {
        const value = object[name];
        if (typeof value === 'string' && value.trim())
            return value.trim();
    }
    return undefined;
}
function mergeEvidence(parts) {
    const locators = parts.flatMap((part) => part.locators);
    const actions = parts.flatMap((part) => part.actions);
    const unique = (items) => {
        const seen = new Set();
        const output = [];
        for (const item of items) {
            const key = JSON.stringify(item);
            if (!seen.has(key)) {
                seen.add(key);
                output.push(item);
            }
        }
        return output;
    };
    return { locators: unique(locators), actions: unique(actions) };
}
export function readTsuBuffer(input, sourceFile, options = {}) {
    const maxEmbeddedDepth = options.maxEmbeddedDepth ?? 8;
    const maxEmbeddedBytes = options.maxEmbeddedBytes ?? 64 * 1024 * 1024;
    const warnings = [];
    let buffer = Buffer.from(input);
    if (isGzip(buffer)) {
        try {
            buffer = gunzipSync(buffer);
        }
        catch (error) {
            throw new Error(`Unable to gunzip TSU${sourceFile ? ` ${sourceFile}` : ''}: ${String(error)}`);
        }
    }
    else if (buffer[0] === 0x50 && buffer[1] === 0x4b) {
        throw new Error('This TSU is a ZIP container. v57 intentionally does not guess an entry; extract it first or pass the embedded JSON/XML payload.');
    }
    const parsed = parseText(buffer.toString('utf8'));
    const root = parsed.value;
    const embedded = [];
    const entities = new Map();
    const evidenceParts = [];
    const visited = new Set();
    if (parsed.format === 'xml' && typeof root === 'string') {
        evidenceParts.push(extractRawToscaEvidence(root, sourceFile));
    }
    else {
        evidenceParts.push(extractRawToscaEvidenceFromObject(root, sourceFile));
    }
    const walk = (value, path, depth) => {
        if (depth > maxEmbeddedDepth) {
            warnings.push(`Embedded traversal depth exceeded at ${path}.`);
            return;
        }
        if (typeof value === 'string') {
            const decoded = tryDecodeBase64Gzip(value, maxEmbeddedBytes);
            if (decoded) {
                embedded.push({ path, format: decoded.format, value: decoded.value });
                if (decoded.format === 'xml' && typeof decoded.value === 'string') {
                    evidenceParts.push(extractRawToscaEvidence(decoded.value, sourceFile));
                }
                else {
                    evidenceParts.push(extractRawToscaEvidenceFromObject(decoded.value, sourceFile));
                }
                walk(decoded.value, `${path}::<gzip>`, depth + 1);
            }
            else if (value.trim().startsWith('<') && value.includes('>')) {
                embedded.push({ path, format: 'xml', value });
                evidenceParts.push(extractRawToscaEvidence(value, sourceFile));
            }
            return;
        }
        if (!value || typeof value !== 'object')
            return;
        if (visited.has(value))
            return;
        visited.add(value);
        if (Array.isArray(value)) {
            value.forEach((item, index) => walk(item, `${path}[${index}]`, depth));
            return;
        }
        const object = value;
        const guid = entityGuid(object);
        if (guid) {
            if (!entities.has(guid))
                entities.set(guid, value);
            else if (entities.get(guid) !== value)
                warnings.push(`Duplicate Tosca entity GUID retained once: ${guid}`);
        }
        for (const [key, item] of Object.entries(object)) {
            walk(item, path ? `${path}.${key}` : key, depth);
        }
    };
    walk(root, '$', 0);
    return {
        ...(sourceFile === undefined ? {} : { sourceFile }),
        root,
        entitiesByGuid: entities,
        embedded,
        evidence: mergeEvidence(evidenceParts),
        warnings,
    };
}
export function readTsuFile(path, options = {}) {
    return readTsuBuffer(readFileSync(path), path, options);
}
//# sourceMappingURL=tsu-reader.js.map