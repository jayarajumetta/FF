#!/usr/bin/env node
import { mkdirSync, writeFileSync } from 'node:fs';
import { basename, dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { readTsuFile } from '../dist/src/index.js';

const input = process.argv[2];
if (!input) {
  console.error('Usage: node scripts/audit-tsu.mjs <raw.tsu|raw.xml|raw.json> [output.json]');
  process.exit(2);
}
const packageRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const source = resolve(input);
const output = resolve(process.argv[3] ?? `${packageRoot}/reports/${basename(source)}.v57-evidence.json`);
const result = readTsuFile(source);
const serializable = {
  sourceFile: result.sourceFile,
  entityGuids: [...result.entitiesByGuid.keys()],
  embedded: result.embedded.map((item) => ({ path: item.path, format: item.format })),
  evidence: result.evidence,
  warnings: result.warnings,
};
mkdirSync(dirname(output), { recursive: true });
writeFileSync(output, JSON.stringify(serializable, null, 2) + '\n');
console.log(JSON.stringify({
  output,
  entities: result.entitiesByGuid.size,
  locators: result.evidence.locators.length,
  actions: result.evidence.actions.length,
  warnings: result.warnings.length,
}, null, 2));
