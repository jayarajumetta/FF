import { readFile, writeFile, readdir, stat, access } from 'node:fs/promises';
import { constants } from 'node:fs';
import { resolve, dirname, join, relative } from 'node:path';
import { fileURLToPath } from 'node:url';
import { spawnSync } from 'node:child_process';
import { createHash } from 'node:crypto';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const checks = [];
const add = (name, passed, detail = '') => checks.push({ name, passed: Boolean(passed), detail });
const required = [
  'src/v58/final/index.ts', 'src/v58/final/mapper.ts', 'src/v58/final/frame-runtime.ts',
  'src/v58/final/interactions.ts', 'src/v58/final/condition.ts', 'src/v58/final/generator.ts',
  'dist/v58/index.js', 'tools/normalize_tosca_export.py', 'reports/full-export-validation.json',
];
for (const item of required) {
  try { await access(join(root, item), constants.R_OK); add(`required:${item}`, true); }
  catch { add(`required:${item}`, false, 'missing'); }
}

async function files(directory) {
  const output = [];
  for (const entry of await readdir(directory, { withFileTypes: true })) {
    const full = join(directory, entry.name);
    if (entry.isDirectory()) output.push(...await files(full)); else output.push(full);
  }
  return output;
}
const sources = (await files(join(root, 'src', 'v58', 'final'))).filter((file) => file.endsWith('.ts'));
const sourceText = (await Promise.all(sources.map(async (file) => `\n// ${relative(root, file)}\n${await readFile(file, 'utf8')}`))).join('\n');
add('no-fixed-waitForTimeout', !sourceText.includes('waitForTimeout('));
add('no-silent-locator-first', !sourceText.includes('.first()'));
add('fieldref-priority', sourceText.includes("kind: 'fieldRef'") && sourceText.includes('Tosca FieldRef'));
add('iframe-tree-fallback', sourceText.includes('childFrames') && sourceText.includes('maxFrameDepth'));
add('dom-query-fallback', sourceText.includes('document.querySelectorAll') && sourceText.includes('shadowRoot'));
add('button-link-role-alias', sourceText.includes("aliases.push('link', 'button')") && sourceText.includes("aliases.push('button', 'link')"));
add('data-set-source-position', sourceText.includes('data.set stays exactly where Tosca placed it'));
add('condition-ast-no-eval', sourceText.includes('class Parser') && !sourceText.includes('eval('));
add('serialized-locator-registry', sourceText.includes('serializePlan') && sourceText.includes('locatorRegistryById'));

let exportValidation;
try {
  exportValidation = JSON.parse(await readFile(join(root, 'reports', 'full-export-validation.json'), 'utf8'));
  add('full-export-validation', exportValidation.passed === true, (exportValidation.criticalIssues ?? []).join('; '));
  add('three-distinct-exports', Array.isArray(exportValidation.exports) && exportValidation.exports.length === 3);
  for (const item of exportValidation.exports ?? []) {
    add(`${item.name}:testcases`, (item.metrics?.testCases ?? 0) > 0, String(item.metrics?.testCases ?? 0));
    add(`${item.name}:actions`, (item.metrics?.actions ?? 0) > 0, String(item.metrics?.actions ?? 0));
    add(`${item.name}:locators`, (item.metrics?.locators ?? 0) > 0, String(item.metrics?.locators ?? 0));
    add(`${item.name}:audit-errors`, (item.audit?.metrics?.errors ?? 0) === 0, String(item.audit?.metrics?.errors ?? 0));
  }
} catch (error) { add('full-export-validation', false, String(error)); }

for (const file of (await files(join(root, 'dist', 'v58'))).filter((item) => item.endsWith('.js'))) {
  const checked = spawnSync(process.execPath, ['--check', file], { encoding: 'utf8' });
  add(`node-check:${relative(root, file)}`, checked.status === 0, checked.stderr?.trim() ?? '');
}

const pack = spawnSync(process.platform === 'win32' ? 'npm.cmd' : 'npm', ['pack', '--dry-run', '--json', '--ignore-scripts'], { cwd: root, encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 });
add('npm-pack-dry-run', pack.status === 0, pack.stderr?.trim() ?? '');
let packSummary;
try { packSummary = JSON.parse(pack.stdout); } catch { packSummary = undefined; }

const passed = checks.every((check) => check.passed);
const report = {
  version: '58.0.0', generatedAt: new Date().toISOString(), passed, checks,
  counts: { total: checks.length, passed: checks.filter((check) => check.passed).length, failed: checks.filter((check) => !check.passed).length },
  packageDryRun: packSummary,
};
await writeFile(join(root, 'reports', 'v58-verification.json'), `${JSON.stringify(report, null, 2)}\n`);
const digest = createHash('sha256').update(JSON.stringify(report)).digest('hex');
await writeFile(join(root, 'reports', 'v58-verification.sha256'), `${digest}  v58-verification.json\n`);
console.log(JSON.stringify(report, null, 2));
if (!passed) process.exitCode = 1;
