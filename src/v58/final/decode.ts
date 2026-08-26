declare const require: any;
const fs = require('node:fs');
const path = require('node:path');
const zlib = require('node:zlib');
const crypto = require('node:crypto');
const NodeBuffer = require('node:buffer').Buffer;

import { DecodedDocument } from './model';

interface XmlNode {
  tag: string;
  attributes: Record<string, string>;
  children: XmlNode[];
  text: string;
}

export interface WorkspaceLoad {
  sourcePath: string;
  sourceSha256: string;
  documents: DecodedDocument[];
  warnings: string[];
}

function hash(buffer: any): string {
  return crypto.createHash('sha256').update(buffer).digest('hex');
}

function decodeXmlEntities(value: string): string {
  return value
    .replace(/&quot;/g, '"').replace(/&apos;/g, "'").replace(/&lt;/g, '<').replace(/&gt;/g, '>')
    .replace(/&amp;/g, '&').replace(/&#(\d+);/g, (_: string, code: string) => String.fromCodePoint(Number(code)))
    .replace(/&#x([a-f0-9]+);/gi, (_: string, code: string) => String.fromCodePoint(parseInt(code, 16)));
}

function parseAttributes(source: string): Record<string, string> {
  const result: Record<string, string> = {};
  const pattern = /([^\s=/>]+)\s*=\s*(?:"([^"]*)"|'([^']*)')/g;
  let match: RegExpExecArray | null;
  while ((match = pattern.exec(source))) result[match[1]] = decodeXmlEntities(match[2] ?? match[3] ?? '');
  return result;
}

export function parseXml(text: string): XmlNode {
  const root: XmlNode = { tag: '#document', attributes: {}, children: [], text: '' };
  const stack: XmlNode[] = [root];
  const tokenPattern = /<!--[\s\S]*?-->|<\?[^>]*\?>|<!\[CDATA\[[\s\S]*?\]\]>|<![^>]*>|<[^>]+>|[^<]+/g;
  let tokenMatch: RegExpExecArray | null;
  while ((tokenMatch = tokenPattern.exec(text))) {
    const token = tokenMatch[0];
    if (token.startsWith('<!--') || token.startsWith('<?') || (token.startsWith('<!') && !token.startsWith('<![CDATA['))) continue;
    if (token.startsWith('<![CDATA[')) {
      stack[stack.length - 1].text += token.slice(9, -3); continue;
    }
    if (token.startsWith('</')) { if (stack.length > 1) stack.pop(); continue; }
    if (token.startsWith('<')) {
      const selfClosing = /\/\s*>$/.test(token);
      const body = token.slice(1, selfClosing ? token.lastIndexOf('/') : -1).trim();
      const nameMatch = body.match(/^([^\s/>]+)/);
      if (!nameMatch) continue;
      const node: XmlNode = { tag: nameMatch[1], attributes: parseAttributes(body.slice(nameMatch[1].length)), children: [], text: '' };
      stack[stack.length - 1].children.push(node);
      if (!selfClosing) stack.push(node);
      continue;
    }
    const cleaned = decodeXmlEntities(token).replace(/\s+/g, ' ').trim();
    if (cleaned) stack[stack.length - 1].text += `${stack[stack.length - 1].text ? ' ' : ''}${cleaned}`;
  }
  return root;
}

function isZip(buffer: any): boolean {
  return buffer.length >= 4 && buffer.readUInt32LE(0) === 0x04034b50;
}
function isGzip(buffer: any): boolean { return buffer.length >= 2 && buffer[0] === 0x1f && buffer[1] === 0x8b; }
function likelyText(buffer: any): boolean {
  const sample = buffer.subarray(0, Math.min(buffer.length, 8192));
  let printable = 0;
  for (const byte of sample) if (byte === 9 || byte === 10 || byte === 13 || (byte >= 32 && byte < 127) || byte >= 0xc2) printable += 1;
  return sample.length === 0 || printable / sample.length > 0.82;
}

interface ZipEntry { name: string; data: any; }
function findEocd(buffer: any): number {
  const start = Math.max(0, buffer.length - 65_557);
  for (let offset = buffer.length - 22; offset >= start; offset -= 1) if (buffer.readUInt32LE(offset) === 0x06054b50) return offset;
  return -1;
}
function unzip(buffer: any, warnings: string[]): ZipEntry[] {
  const eocd = findEocd(buffer);
  if (eocd < 0) { warnings.push('ZIP EOCD not found'); return []; }
  const entryCount = buffer.readUInt16LE(eocd + 10);
  let offset = buffer.readUInt32LE(eocd + 16);
  const entries: ZipEntry[] = [];
  for (let index = 0; index < entryCount && offset + 46 <= buffer.length; index += 1) {
    if (buffer.readUInt32LE(offset) !== 0x02014b50) { warnings.push(`Invalid central directory entry at ${offset}`); break; }
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
    if (name.endsWith('/')) continue;
    if ((flags & 1) !== 0) { warnings.push(`Encrypted ZIP entry skipped: ${name}`); continue; }
    if (localOffset + 30 > buffer.length || buffer.readUInt32LE(localOffset) !== 0x04034b50) { warnings.push(`Invalid local header: ${name}`); continue; }
    const localNameLength = buffer.readUInt16LE(localOffset + 26);
    const localExtraLength = buffer.readUInt16LE(localOffset + 28);
    const dataStart = localOffset + 30 + localNameLength + localExtraLength;
    const compressed = buffer.subarray(dataStart, dataStart + compressedSize);
    try {
      let data: any;
      if (method === 0) data = NodeBuffer.from(compressed);
      else if (method === 8) data = zlib.inflateRawSync(compressed);
      else { warnings.push(`Unsupported ZIP compression ${method}: ${name}`); continue; }
      if (uncompressedSize && data.length !== uncompressedSize) warnings.push(`ZIP size mismatch for ${name}: expected ${uncompressedSize}, got ${data.length}`);
      entries.push({ name, data });
    } catch (error) { warnings.push(`Failed to decompress ZIP entry ${name}: ${String(error)}`); }
  }
  return entries;
}

function nestedEncodedStrings(value: unknown, found: Array<{ name: string; data: any }>, prefix: string, budget: { count: number }): void {
  if (budget.count > 10_000) return;
  if (typeof value === 'string') {
    const compact = value.replace(/\s+/g, '');
    if (compact.length >= 40 && compact.length <= 100_000_000 && (/^H4sI/.test(compact) || /^UEsDB/.test(compact))) {
      try { found.push({ name: `${prefix}.embedded-${budget.count++}`, data: NodeBuffer.from(compact, 'base64') }); } catch { /* ignored */ }
    }
    return;
  }
  if (Array.isArray(value)) {
    for (let index = 0; index < value.length; index += 1) nestedEncodedStrings(value[index], found, `${prefix}[${index}]`, budget);
    return;
  }
  if (value && typeof value === 'object') {
    for (const [key, child] of Object.entries(value as Record<string, unknown>)) nestedEncodedStrings(child, found, `${prefix}.${key}`, budget);
  }
}

export function loadWorkspace(sourcePath: string, maxDepth = 12): WorkspaceLoad {
  const source = fs.readFileSync(sourcePath);
  const documents: DecodedDocument[] = [];
  const warnings: string[] = [];
  const seen = new Set<string>();
  const decode = (name: string, buffer: any, depth: number): void => {
    if (depth > maxDepth) { warnings.push(`Maximum nested payload depth reached at ${name}`); return; }
    const signature = hash(buffer);
    const seenKey = `${signature}:${name.split('!').pop()}`;
    if (seen.has(seenKey)) return;
    seen.add(seenKey);
    if (isZip(buffer)) {
      const entries = unzip(buffer, warnings);
      for (const entry of entries) decode(`${name}!${entry.name}`, entry.data, depth + 1);
      return;
    }
    if (isGzip(buffer)) {
      try { decode(`${name}!gunzip`, zlib.gunzipSync(buffer), depth + 1); }
      catch (error) { warnings.push(`GZip decode failed at ${name}: ${String(error)}`); }
      return;
    }
    if (!likelyText(buffer)) {
      documents.push({ name, kind: 'binary', payload: null, sha256: signature, byteLength: buffer.length, depth }); return;
    }
    const text = buffer.toString('utf8').replace(/^\uFEFF/, '').trim();
    if (!text) return;
    if ((text.startsWith('{') && text.endsWith('}')) || (text.startsWith('[') && text.endsWith(']'))) {
      try {
        const payload = JSON.parse(text);
        documents.push({ name, kind: 'json', payload, sha256: signature, byteLength: buffer.length, depth });
        const nested: Array<{ name: string; data: any }> = [];
        nestedEncodedStrings(payload, nested, name, { count: 0 });
        for (const item of nested) decode(item.name, item.data, depth + 1);
        return;
      } catch (error) { warnings.push(`JSON parse failed at ${name}: ${String(error)}`); }
    }
    if (/^<\?xml|^<[A-Za-z_:][^>]*>/.test(text)) {
      try {
        documents.push({ name, kind: 'xml', payload: parseXml(text), sha256: signature, byteLength: buffer.length, depth }); return;
      } catch (error) { warnings.push(`XML parse failed at ${name}: ${String(error)}`); }
    }
    // Some Tosca payloads prepend a short transport header before JSON/XML/GZip Base64.
    const gzipBase64 = text.match(/H4sI[A-Za-z0-9+/=]{32,}/g) ?? [];
    const zipBase64 = text.match(/UEsDB[A-Za-z0-9+/=]{32,}/g) ?? [];
    for (const [index, encoded] of [...gzipBase64, ...zipBase64].entries()) {
      try { decode(`${name}!text-embedded-${index}`, NodeBuffer.from(encoded, 'base64'), depth + 1); } catch { /* ignored */ }
    }
    documents.push({ name, kind: 'text', payload: text.length > 5_000_000 ? text.slice(0, 5_000_000) : text, sha256: signature, byteLength: buffer.length, depth });
  };
  decode(path.basename(sourcePath), source, 0);
  return { sourcePath, sourceSha256: hash(source), documents, warnings };
}
