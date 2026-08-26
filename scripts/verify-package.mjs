#!/usr/bin/env node
import {
  existsSync,
  mkdirSync,
  readFileSync,
  readdirSync,
  statSync,
  writeFileSync,
} from 'node:fs';
import { dirname, join, relative, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { generatePlaywrightScenario } from '../dist/src/index.js';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const required = [
  'package.json',
  'tsconfig.json',
  'README.md',
  'src/index.ts',
  'src/runtime/resilient-actions.ts',
  'src/runtime/dom-fallback.ts',
  'src/tosca/tsu-reader.ts',
  'src/tosca/scenario-builder.ts',
  'scripts/apply-v57-to-v56.mjs',
  'scripts/convert-tsu-to-playwright.mjs',
  'examples/normalized-scenario.json',
  'dist/src/index.js',
];

function filesBelow(directory, output = []) {
  for (const entry of readdirSync(directory)) {
    if (['dist', 'node_modules'].includes(entry)) continue;
    const path = join(directory, entry);
    const stat = statSync(path);
    if (stat.isDirectory()) filesBelow(path, output);
    else output.push(path);
  }
  return output;
}

const sourceFiles = filesBelow(join(root, 'src')).filter((path) => path.endsWith('.ts'));
const sourceText = sourceFiles.map((path) => readFileSync(path, 'utf8')).join('\n');
const runtimeText = [
  join(root, 'src/runtime/resilient-actions.ts'),
  join(root, 'src/runtime/resolver.ts'),
  join(root, 'src/runtime/dom-fallback.ts'),
].map((path) => readFileSync(path, 'utf8')).join('\n');

const generated = generatePlaywrightScenario({
  name: 'verification repeated branches',
  initialData: { LOB: 'PLDC', STATE: 'CA' },
  actions: [
    { id: 'one', order: 1, kind: 'click', target: { key: 'x', id: 'x.y' }, condition: '{LOB} == "PLDC"' },
    { id: 'two', order: 2, kind: 'fill', target: { key: 'x', id: 'x.y' }, value: { kind: 'literal', value: 'A' }, condition: '{LOB} == "PLDC"' },
    { id: 'tab', order: 3, kind: 'press', target: { key: 'x', id: 'x.y' }, value: { kind: 'literal', value: 'Tab' }, origin: 'generated', metadata: { autoInserted: true } },
    { id: 'footer', order: 4, kind: 'dataSet', dataKey: 'RESULT', value: { kind: 'literal', value: 'ok' } },
  ],
});

const checks = {
  requiredFilesPresent: required.every((item) => existsSync(join(root, item))),
  noFixedWaitForTimeoutInSource: !/waitForTimeout\s*\(/.test(sourceText),
  noRuntimeAutomaticTab: !/await\s+[^;\n]*\.press\s*\(\s*['"]Tab['"]/.test(runtimeText),
  noTopPageKeyboardFallback: !/page\.keyboard\./.test(runtimeText),
  frameEvaluateFallbackPresent: /frameRecord\.frame\.evaluate/.test(runtimeText),
  strictAmbiguityGuardPresent: /DOM fallback remained ambiguous/.test(runtimeText),
  repeatedConditionsRemainIndependent: (generated.code.match(/if \(evaluateCondition/g) ?? []).length === 2 && !generated.code.includes('else if'),
  generatedTabRemoved: !generated.code.includes("String(resolveRuntimeValue({\n  \"kind\": \"literal\",\n  \"value\": \"Tab\""),
  safeDataSetAtFooter: generated.code.lastIndexOf('data.set("RESULT"') > generated.code.lastIndexOf('await ui.fill'),
};

const report = {
  version: '57.0.0',
  generatedAt: new Date().toISOString(),
  checks,
  passed: Object.values(checks).every(Boolean),
  sourceFiles: sourceFiles.map((path) => relative(root, path)),
  generatedScenarioAudit: generated.audit,
};
mkdirSync(join(root, 'reports'), { recursive: true });
writeFileSync(join(root, 'reports/v57-verification.json'), JSON.stringify(report, null, 2) + '\n');
console.log(JSON.stringify(report, null, 2));
if (!report.passed) process.exit(1);
