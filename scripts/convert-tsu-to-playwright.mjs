#!/usr/bin/env node
import { mkdirSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import {
  buildScenarioFromTsu,
  generatePlaywrightScenario,
  readTsuFile,
} from '../dist/src/index.js';

const input = process.argv[2];
const output = process.argv[3];
if (!input || !output) {
  console.error('Usage: node scripts/convert-tsu-to-playwright.mjs <raw.tsu|xml|json> <output.spec.ts> [app] [scenario-name] [runtime-import]');
  process.exit(2);
}
const source = resolve(input);
const outputPath = resolve(output);
const result = readTsuFile(source);
const scenario = buildScenarioFromTsu(result, {
  app: process.argv[4] ?? 'UNKNOWN',
  name: process.argv[5] ?? `Converted ${source.split(/[\\/]/).at(-1)}`,
});
const generated = generatePlaywrightScenario(scenario, { runtimeImport: process.argv[6] ?? 'ff-bop-complete-e2e-v57' });
mkdirSync(dirname(outputPath), { recursive: true });
writeFileSync(outputPath, generated.code);
writeFileSync(`${outputPath}.audit.json`, JSON.stringify({
  source,
  warnings: result.warnings,
  rawEvidence: result.evidence,
  normalizedScenario: scenario,
  locatorManifest: generated.locatorManifest,
  decisions: generated.audit,
}, null, 2) + '\n');
console.log(JSON.stringify({
  output: outputPath,
  rawLocators: result.evidence.locators.length,
  rawActions: result.evidence.actions.length,
  generatedActions: scenario.actions.length,
  locatorConstants: generated.locatorManifest.length,
  warnings: result.warnings.length,
}, null, 2));
