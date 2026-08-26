#!/usr/bin/env node
import { mkdirSync, readFileSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { generatePlaywrightScenario } from '../dist/src/index.js';

const input = process.argv[2];
const output = process.argv[3];
if (!input || !output) {
  console.error('Usage: node scripts/generate-v57.mjs <normalized-scenario.json> <output.spec.ts> [runtime-import]');
  process.exit(2);
}
const model = JSON.parse(readFileSync(resolve(input), 'utf8'));
const generated = generatePlaywrightScenario(model, {
  runtimeImport: process.argv[4] ?? 'ff-bop-complete-e2e-v57',
});
const outputPath = resolve(output);
mkdirSync(dirname(outputPath), { recursive: true });
writeFileSync(outputPath, generated.code);
writeFileSync(`${outputPath}.audit.json`, JSON.stringify({
  locatorManifest: generated.locatorManifest,
  audit: generated.audit,
  deferredDataSets: generated.deferredDataSets,
}, null, 2) + '\n');
console.log(JSON.stringify({
  output: outputPath,
  locators: generated.locatorManifest.length,
  auditEntries: generated.audit.length,
  deferredDataSets: generated.deferredDataSets.length,
}, null, 2));
