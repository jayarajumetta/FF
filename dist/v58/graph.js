"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.buildWorkspaceGraph = buildWorkspaceGraph;
const model_1 = require("./model");
const ID_KEYS = ['guid', 'uniqueid', 'id', 'nodeid', 'objectid', 'entityid', 'xid', 'key'];
const TYPE_KEYS = ['type', '$type', 'objecttype', 'nodetype', 'nodeclass', 'class', 'classid', 'kind', 'entitytype', 'itemtype', 'typename', 'objectclass'];
const NAME_KEYS = ['name', 'displayname', 'caption', 'title', 'label', 'technicalname', 'objectname', 'longname', 'shortname'];
const PARENT_KEYS = ['parentid', 'parentguid', 'parentuniqueid', 'parentnodeid', 'parent', 'ownerid', 'ownerguid', 'containerid', 'containerguid'];
const DERIVED_KEYS = ['derivedfrom', 'derivedfromid', 'derivedfromguid', 'derivedobject', 'baseid', 'baseguid', 'prototypeid', 'prototypeguid'];
const GUID_PATTERN = /\{?[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}\}?/i;
function scalar(value) {
    return value === null || ['string', 'number', 'boolean'].includes(typeof value);
}
function canonicalId(value) {
    const match = value.match(GUID_PATTERN);
    return (match?.[0] ?? value).replace(/[{}]/g, '').trim().toLowerCase();
}
function firstByKeys(record, keys) {
    const wanted = new Set(keys.map(model_1.normalizeKey));
    for (const [key, value] of Object.entries(record)) {
        if (!wanted.has((0, model_1.normalizeKey)(key)))
            continue;
        const result = (0, model_1.asString)(value);
        if (result)
            return result;
    }
    return undefined;
}
function strongType(value) {
    return /(tosca|testcase|teststep|module|control|attribute|reusable|execution|condition|folder|instance|class)/i.test(value);
}
function flattenPropertyCollections(record, target) {
    for (const [key, value] of Object.entries(record)) {
        if (scalar(value)) {
            target[key] = value;
            continue;
        }
        if (Array.isArray(value) && value.every(scalar)) {
            target[key] = value;
            continue;
        }
        if (!value || typeof value !== 'object')
            continue;
        const normalized = (0, model_1.normalizeKey)(key);
        if (['properties', 'property', 'attributes', 'attribute', 'params', 'param', 'parameters', 'values', 'customproperties'].includes(normalized)) {
            const entries = Array.isArray(value) ? value : Object.entries(value).map(([name, child]) => ({ name, value: child }));
            for (const entry of entries) {
                if (!entry || typeof entry !== 'object')
                    continue;
                const item = entry;
                const name = firstByKeys(item, ['name', 'key', 'property', 'attribute', 'parameter']);
                const itemValue = firstByKeys(item, ['value', 'text', 'content', 'data']);
                if (name && itemValue !== undefined)
                    target[name] = itemValue;
            }
        }
    }
}
function xmlRecord(node) {
    const attributes = (node.attributes && typeof node.attributes === 'object') ? node.attributes : {};
    const record = { ...attributes, _tag: node.tag, _text: node.text };
    const children = Array.isArray(node.children) ? node.children : [];
    for (const child of children) {
        if (!child || typeof child !== 'object')
            continue;
        const childRecord = child;
        const tag = String(childRecord.tag ?? 'child');
        const existing = record[tag];
        if (existing === undefined)
            record[tag] = child;
        else if (Array.isArray(existing))
            existing.push(child);
        else
            record[tag] = [existing, child];
    }
    return record;
}
function extractReferences(record) {
    const result = {};
    for (const [key, value] of Object.entries(record)) {
        const normalized = (0, model_1.normalizeKey)(key);
        if (!/(guid|ref|reference|parent|owner|module|testcase|derived|base|prototype|target|child|children|items|nodes|members|steps|content|contained)/.test(normalized))
            continue;
        const values = Array.isArray(value) ? value : [value];
        const ids = [];
        for (const item of values) {
            if (typeof item !== 'string' && typeof item !== 'number')
                continue;
            const text = String(item);
            const matches = text.match(new RegExp(GUID_PATTERN.source, 'ig')) ?? (text.length < 256 ? [text] : []);
            for (const match of matches) {
                const id = canonicalId(match);
                if (id && !ids.includes(id))
                    ids.push(id);
            }
        }
        if (ids.length)
            result[key] = ids;
    }
    return result;
}
function buildWorkspaceGraph(documents) {
    const entities = [];
    const warnings = [];
    let ordinal = 0;
    const walk = (value, document, objectPath, inheritedParent) => {
        if (Array.isArray(value)) {
            value.forEach((child, index) => walk(child, document, `${objectPath}[${index}]`, inheritedParent));
            return;
        }
        if (!value || typeof value !== 'object')
            return;
        const raw = value;
        const record = typeof raw.tag === 'string' && raw.attributes ? xmlRecord(raw) : raw;
        const properties = {};
        flattenPropertyCollections(record, properties);
        const propertyRecord = properties;
        const type = firstByKeys(record, TYPE_KEYS) ?? firstByKeys(propertyRecord, TYPE_KEYS) ?? (0, model_1.asString)(record._tag) ?? '';
        const name = firstByKeys(record, NAME_KEYS) ?? firstByKeys(propertyRecord, NAME_KEYS) ?? (0, model_1.asString)(record._text) ?? type;
        const pathGuid = objectPath.match(GUID_PATTERN)?.[0];
        const rawId = firstByKeys(record, ID_KEYS) ?? firstByKeys(propertyRecord, ID_KEYS) ?? pathGuid;
        const hasGuid = Boolean(rawId && GUID_PATTERN.test(rawId));
        const hasIdentity = Boolean(rawId && (hasGuid || strongType(type))) || strongType(type) && Boolean(name);
        let currentParent = inheritedParent;
        if (hasIdentity) {
            const id = rawId ? canonicalId(rawId) : `synthetic-${(0, model_1.fnv1a)(`${document.sha256}:${objectPath}:${type}:${name}`)}`;
            const parentRaw = firstByKeys(record, PARENT_KEYS) ?? firstByKeys(propertyRecord, PARENT_KEYS);
            const derivedRaw = firstByKeys(record, DERIVED_KEYS) ?? firstByKeys(propertyRecord, DERIVED_KEYS);
            const source = { document: document.name, ordinal: ordinal++, path: objectPath, entityId: id };
            entities.push({
                id, type: type || 'Unknown', name: name || id, parentId: parentRaw ? canonicalId(parentRaw) : inheritedParent,
                childIds: [], derivedFrom: derivedRaw ? canonicalId(derivedRaw) : undefined,
                references: { ...extractReferences(record), ...extractReferences(propertyRecord) }, properties, source,
            });
            currentParent = id;
        }
        for (const [key, child] of Object.entries(record)) {
            if (scalar(child))
                continue;
            if (['attributes'].includes((0, model_1.normalizeKey)(key)) && typeof raw.tag === 'string')
                continue;
            walk(child, document, `${objectPath}.${key}`, currentParent);
        }
    };
    for (const document of documents) {
        if (document.kind === 'json' || document.kind === 'xml')
            walk(document.payload, document, '$');
    }
    const byId = new Map();
    for (const entity of entities) {
        const existing = byId.get(entity.id);
        if (!existing) {
            byId.set(entity.id, entity);
            continue;
        }
        warnings.push(`Duplicate entity id ${entity.id} in ${entity.source.document}; evidence merged`);
        existing.properties = { ...existing.properties, ...entity.properties };
        existing.references = { ...existing.references, ...entity.references };
        if (!existing.parentId)
            existing.parentId = entity.parentId;
        if (!existing.derivedFrom)
            existing.derivedFrom = entity.derivedFrom;
    }
    const unique = [...byId.values()].sort((a, b) => a.source.ordinal - b.source.ordinal);
    // Native Tosca exports may store hierarchy as GUID arrays instead of a ParentGuid property.
    for (const entity of unique) {
        for (const [relation, ids] of Object.entries(entity.references)) {
            const key = (0, model_1.normalizeKey)(relation);
            if (/(parent|owner|container)/.test(key) && !entity.parentId) {
                const parent = ids.find((id) => byId.has(id) && id !== entity.id);
                if (parent)
                    entity.parentId = parent;
            }
            if (/(child|children|items|nodes|members|steps|content|contained)/.test(key)) {
                for (const id of ids) {
                    const child = byId.get(id);
                    if (child && child.id !== entity.id && !child.parentId)
                        child.parentId = entity.id;
                }
            }
        }
    }
    const childrenByParent = new Map();
    for (const entity of unique) {
        if (!entity.parentId || !byId.has(entity.parentId))
            continue;
        const children = childrenByParent.get(entity.parentId) ?? [];
        children.push(entity);
        childrenByParent.set(entity.parentId, children);
    }
    for (const [parentId, children] of childrenByParent) {
        children.sort((a, b) => a.source.ordinal - b.source.ordinal);
        const parent = byId.get(parentId);
        if (parent)
            parent.childIds = children.map((child) => child.id);
    }
    const resolving = new Set();
    const resolveInheritance = (entity) => {
        if (entity.mergedProperties)
            return entity.mergedProperties;
        if (resolving.has(entity.id)) {
            warnings.push(`DerivedFrom cycle detected at ${entity.id}`);
            return entity.properties;
        }
        resolving.add(entity.id);
        let merged = {};
        const chain = [];
        if (entity.derivedFrom) {
            const base = byId.get(entity.derivedFrom);
            if (base) {
                merged = { ...resolveInheritance(base) };
                chain.push(...(base.inheritanceChain ?? []), base.id);
            }
            else
                warnings.push(`DerivedFrom target ${entity.derivedFrom} not found for ${entity.id}`);
        }
        entity.mergedProperties = { ...merged, ...entity.properties };
        entity.inheritanceChain = [...new Set(chain)];
        resolving.delete(entity.id);
        return entity.mergedProperties;
    };
    for (const entity of unique)
        resolveInheritance(entity);
    return { entities: unique, byId, childrenByParent, warnings, documents };
}
//# sourceMappingURL=graph.js.map