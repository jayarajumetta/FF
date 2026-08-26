"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.parseXml = parseXml;
exports.loadWorkspace = loadWorkspace;
const fs = require('node:fs');
const path = require('node:path');
const zlib = require('node:zlib');
const crypto = require('node:crypto');
const NodeBuffer = require('node:buffer').Buffer;
function hash(buffer) {
    return crypto.createHash('sha256').update(buffer).digest('hex');
}
function decodeXmlEntities(value) {
    return value
        .replace(/&quot;/g, '"').replace(/&apos;/g, "'").replace(/&lt;/g, '<').replace(/&gt;/g, '>')
        .replace(/&amp;/g, '&').replace(/&#(\d+);/g, (_, code) => String.fromCodePoint(Number(code)))
        .replace(/&#x([a-f0-9]+);/gi, (_, code) => String.fromCodePoint(parseInt(code, 16)));
}
function parseAttributes(source) {
    const result = {};
    const pattern = /([^\s=/>]+)\s*=\s*(?:"([^"]*)"|'([^']*)')/g;
    let match;
    while ((match = pattern.exec(source)))
        result[match[1]] = decodeXmlEntities(match[2] ?? match[3] ?? '');
    return result;
}
function parseXml(text) {
    const root = { tag: '#document', attributes: {}, children: [], text: '' };
    const stack = [root];
    const tokenPattern = /<!--[\s\S]*?-->|<\?[^>]*\?>|<!\[CDATA\[[\s\S]*?\]\]>|<![^>]*>|<[^>]+>|[^<]+/g;
    let tokenMatch;
    while ((tokenMatch = tokenPattern.exec(text))) {
        const token = tokenMatch[0];
        if (token.startsWith('<!--') || token.startsWith('<?') || (token.startsWith('<!') && !token.startsWith('<![CDATA[')))
            continue;
        if (token.startsWith('<![CDATA[')) {
            stack[stack.length - 1].text += token.slice(9, -3);
            continue;
        }
        if (token.startsWith('</')) {
            if (stack.length > 1)
                stack.pop();
            continue;
        }
        if (token.startsWith('<')) {
            const selfClosing = /\/\s*>$/.test(token);
            const body = token.slice(1, selfClosing ? token.lastIndexOf('/') : -1).trim();
            const nameMatch = body.match(/^([^\s/>]+)/);
            if (!nameMatch)
                continue;
            const node = { tag: nameMatch[1], attributes: parseAttributes(body.slice(nameMatch[1].length)), children: [], text: '' };
            stack[stack.length - 1].children.push(node);
            if (!selfClosing)
                stack.push(node);
            continue;
        }
        const cleaned = decodeXmlEntities(token).replace(/\s+/g, ' ').trim();
        if (cleaned)
            stack[stack.length - 1].text += `${stack[stack.length - 1].text ? ' ' : ''}${cleaned}`;
    }
    return root;
}
function isZip(buffer) {
    return buffer.length >= 4 && buffer.readUInt32LE(0) === 0x04034b50;
}
function isGzip(buffer) { return buffer.length >= 2 && buffer[0] === 0x1f && buffer[1] === 0x8b; }
function likelyText(buffer) {
    const sample = buffer.subarray(0, Math.min(buffer.length, 8192));
    let printable = 0;
    for (const byte of sample)
        if (byte === 9 || byte === 10 || byte === 13 || (byte >= 32 && byte < 127) || byte >= 0xc2)
            printable += 1;
    return sample.length === 0 || printable / sample.length > 0.82;
}
function findEocd(buffer) {
    const start = Math.max(0, buffer.length - 65557);
    for (let offset = buffer.length - 22; offset >= start; offset -= 1)
        if (buffer.readUInt32LE(offset) === 0x06054b50)
            return offset;
    return -1;
}
function unzip(buffer, warnings) {
    const eocd = findEocd(buffer);
    if (eocd < 0) {
        warnings.push('ZIP EOCD not found');
        return [];
    }
    const entryCount = buffer.readUInt16LE(eocd + 10);
    let offset = buffer.readUInt32LE(eocd + 16);
    const entries = [];
    for (let index = 0; index < entryCount && offset + 46 <= buffer.length; index += 1) {
        if (buffer.readUInt32LE(offset) !== 0x02014b50) {
            warnings.push(`Invalid central directory entry at ${offset}`);
            break;
        }
        const flags = buffer.readUInt16LE(offset + 8);
        const method = buffer.readUInt16LE(offset + 10);
        const compressedSize = buffer.readUInt32LE(offset + 20);
        const uncompressedSize = buffer.readUInt32LE(offset + 24);
        const nameLength = buffer.readUInt16LE(offset + 28);
        const extraLength = buffer.readUInt16LE(offset + 30);
        const commentLength = buffer.readUInt16LE(offset + 32);
        const localOffset = buffer.readUInt32LE(offset + 42);
        const name = buffer.subarray(offset + 46, offset + 46 + nameLength).toString((flags & 0x800) ? 'utf8' : 'latin1');
        offset += 46 + nameLength + extraLength + commentLength;
        if (name.endsWith('/'))
            continue;
        if ((flags & 1) !== 0) {
            warnings.push(`Encrypted ZIP entry skipped: ${name}`);
            continue;
        }
        if (localOffset + 30 > buffer.length || buffer.readUInt32LE(localOffset) !== 0x04034b50) {
            warnings.push(`Invalid local header: ${name}`);
            continue;
        }
        const localNameLength = buffer.readUInt16LE(localOffset + 26);
        const localExtraLength = buffer.readUInt16LE(localOffset + 28);
        const dataStart = localOffset + 30 + localNameLength + localExtraLength;
        const compressed = buffer.subarray(dataStart, dataStart + compressedSize);
        try {
            let data;
            if (method === 0)
                data = NodeBuffer.from(compressed);
            else if (method === 8)
                data = zlib.inflateRawSync(compressed);
            else {
                warnings.push(`Unsupported ZIP compression ${method}: ${name}`);
                continue;
            }
            if (uncompressedSize && data.length !== uncompressedSize)
                warnings.push(`ZIP size mismatch for ${name}: expected ${uncompressedSize}, got ${data.length}`);
            entries.push({ name, data });
        }
        catch (error) {
            warnings.push(`Failed to decompress ZIP entry ${name}: ${String(error)}`);
        }
    }
    return entries;
}
function nestedEncodedStrings(value, found, prefix, budget) {
    if (budget.count > 10000)
        return;
    if (typeof value === 'string') {
        const compact = value.replace(/\s+/g, '');
        if (compact.length >= 40 && compact.length <= 100000000 && (/^H4sI/.test(compact) || /^UEsDB/.test(compact))) {
            try {
                found.push({ name: `${prefix}.embedded-${budget.count++}`, data: NodeBuffer.from(compact, 'base64') });
            }
            catch { /* ignored */ }
        }
        return;
    }
    if (Array.isArray(value)) {
        for (let index = 0; index < value.length; index += 1)
            nestedEncodedStrings(value[index], found, `${prefix}[${index}]`, budget);
        return;
    }
    if (value && typeof value === 'object') {
        for (const [key, child] of Object.entries(value))
            nestedEncodedStrings(child, found, `${prefix}.${key}`, budget);
    }
}
function loadWorkspace(sourcePath, maxDepth = 12) {
    const source = fs.readFileSync(sourcePath);
    const documents = [];
    const warnings = [];
    const seen = new Set();
    const decode = (name, buffer, depth) => {
        if (depth > maxDepth) {
            warnings.push(`Maximum nested payload depth reached at ${name}`);
            return;
        }
        const signature = hash(buffer);
        const seenKey = `${signature}:${name.split('!').pop()}`;
        if (seen.has(seenKey))
            return;
        seen.add(seenKey);
        if (isZip(buffer)) {
            const entries = unzip(buffer, warnings);
            for (const entry of entries)
                decode(`${name}!${entry.name}`, entry.data, depth + 1);
            return;
        }
        if (isGzip(buffer)) {
            try {
                decode(`${name}!gunzip`, zlib.gunzipSync(buffer), depth + 1);
            }
            catch (error) {
                warnings.push(`GZip decode failed at ${name}: ${String(error)}`);
            }
            return;
        }
        if (!likelyText(buffer)) {
            documents.push({ name, kind: 'binary', payload: null, sha256: signature, byteLength: buffer.length, depth });
            return;
        }
        const text = buffer.toString('utf8').replace(/^\uFEFF/, '').trim();
        if (!text)
            return;
        if ((text.startsWith('{') && text.endsWith('}')) || (text.startsWith('[') && text.endsWith(']'))) {
            try {
                const payload = JSON.parse(text);
                documents.push({ name, kind: 'json', payload, sha256: signature, byteLength: buffer.length, depth });
                const nested = [];
                nestedEncodedStrings(payload, nested, name, { count: 0 });
                for (const item of nested)
                    decode(item.name, item.data, depth + 1);
                return;
            }
            catch (error) {
                warnings.push(`JSON parse failed at ${name}: ${String(error)}`);
            }
        }
        if (/^<\?xml|^<[A-Za-z_:][^>]*>/.test(text)) {
            try {
                documents.push({ name, kind: 'xml', payload: parseXml(text), sha256: signature, byteLength: buffer.length, depth });
                return;
            }
            catch (error) {
                warnings.push(`XML parse failed at ${name}: ${String(error)}`);
            }
        }
        // Some Tosca payloads prepend a short transport header before JSON/XML/GZip Base64.
        const gzipBase64 = text.match(/H4sI[A-Za-z0-9+/=]{32,}/g) ?? [];
        const zipBase64 = text.match(/UEsDB[A-Za-z0-9+/=]{32,}/g) ?? [];
        for (const [index, encoded] of [...gzipBase64, ...zipBase64].entries()) {
            try {
                decode(`${name}!text-embedded-${index}`, NodeBuffer.from(encoded, 'base64'), depth + 1);
            }
            catch { /* ignored */ }
        }
        documents.push({ name, kind: 'text', payload: text.length > 5000000 ? text.slice(0, 5000000) : text, sha256: signature, byteLength: buffer.length, depth });
    };
    decode(path.basename(sourcePath), source, 0);
    return { sourcePath, sourceSha256: hash(source), documents, warnings };
}
//# sourceMappingURL=decode.js.map