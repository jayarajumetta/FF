#!/usr/bin/env node
import {
  cpSync,
  existsSync,
  mkdirSync,
  readFileSync,
  readdirSync,
  statSync,
  writeFileSync,
} from 'node:fs';
import { dirname, join, relative, resolve, sep } from 'node:path';
import { fileURLToPath } from 'node:url';

const packageRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const requestedTarget = process.argv[2];
const dryRun = process.argv.includes('--dry-run');

if (!requestedTarget) {
  console.error('Usage: node scripts/apply-v57-to-v56.mjs <unpacked-v56-root> [--dry-run]');
  process.exit(2);
}

const targetRoot = resolve(requestedTarget);
const targetPackagePath = join(targetRoot, 'package.json');
if (!existsSync(targetPackagePath)) {
  console.error(`No package.json found at v56 root: ${targetRoot}`);
  process.exit(2);
}
if (targetRoot === packageRoot || targetRoot.startsWith(`${packageRoot}${sep}`)) {
  console.error('Target must be a separate unpacked v56 project, not the v57 package itself.');
  process.exit(2);
}

const vendorRelative = 'vendor/ff-bop-complete-e2e-v57';
const vendorTarget = join(targetRoot, vendorRelative);
const bridgePath = join(targetRoot, 'src', 'v57-bridge.ts');
const backupPackagePath = join(targetRoot, 'package.json.v56-backup');

const targetPackage = JSON.parse(readFileSync(targetPackagePath, 'utf8'));
const originalPackageText = JSON.stringify(targetPackage, null, 2) + '\n';
targetPackage.dependencies = {
  ...(targetPackage.dependencies ?? {}),
  'ff-bop-complete-e2e-v57': `file:${vendorRelative}`,
};
targetPackage.scripts = {
  ...(targetPackage.scripts ?? {}),
  'v57:build-runtime': `npm --prefix ${vendorRelative} run build`,
  'v57:test-runtime': `npm --prefix ${vendorRelative} test`,
  'v57:verify-runtime': `npm --prefix ${vendorRelative} run verify`,
};

const ignoredSegments = new Set(['node_modules', '.git']);
function shouldCopy(source) {
  const rel = relative(packageRoot, source);
  return !rel.split(sep).some((part) => ignoredSegments.has(part)) && !rel.endsWith('.zip');
}

function walkFiles(root, output = []) {
  if (!existsSync(root)) return output;
  for (const entry of readdirSync(root)) {
    if (['node_modules', '.git', 'dist', 'vendor'].includes(entry)) continue;
    const absolute = join(root, entry);
    const stat = statSync(absolute);
    if (stat.isDirectory()) walkFiles(absolute, output);
    else if (/\.(?:ts|tsx|js|mjs|cjs)$/.test(entry)) output.push(absolute);
  }
  return output;
}

const scanPatterns = {
  fixedWaits: /waitForTimeout\s*\(/g,
  unconditionalTabs: /(?:keyboard\.)?press\s*\(\s*['"]Tab['"]/g,
  directDocumentQuery: /document\.(?:querySelector|evaluate)\s*\(/g,
  nthLocators: /\.nth\s*\(/g,
  legacyDropdownHelpers: /chooseDropdownOption\s*\(/g,
};
const findings = [];
for (const file of walkFiles(targetRoot)) {
  const text = readFileSync(file, 'utf8');
  const counts = Object.fromEntries(
    Object.entries(scanPatterns).map(([name, pattern]) => [name, [...text.matchAll(pattern)].length]),
  );
  if (Object.values(counts).some((count) => count > 0)) {
    findings.push({ file: relative(targetRoot, file), ...counts });
  }
}

const bridge = `// v57 compatibility bridge installed over the v56 project.\n` +
  `export * from 'ff-bop-complete-e2e-v57';\n` +
  `export { createV57CompatibilityLayer as createUi } from 'ff-bop-complete-e2e-v57/compat/v56';\n`;

const report = {
  generatedAt: new Date().toISOString(),
  targetRoot,
  dryRun,
  vendorTarget: relative(targetRoot, vendorTarget),
  bridge: relative(targetRoot, bridgePath),
  changes: [
    'Vendored the compiled and source v57 package.',
    'Added a local file dependency for ff-bop-complete-e2e-v57.',
    'Added runtime build/test/verify scripts.',
    'Added src/v57-bridge.ts for incremental migration.',
    'Did not rewrite business tests automatically; scan findings are listed below to prevent semantic loss.',
  ],
  scanFindings: findings,
};

if (!dryRun) {
  mkdirSync(targetRoot, { recursive: true });
  if (!existsSync(backupPackagePath)) writeFileSync(backupPackagePath, originalPackageText);
  cpSync(packageRoot, vendorTarget, { recursive: true, force: true, filter: shouldCopy });
  writeFileSync(targetPackagePath, JSON.stringify(targetPackage, null, 2) + '\n');
  mkdirSync(dirname(bridgePath), { recursive: true });
  if (existsSync(bridgePath) && !existsSync(`${bridgePath}.v56-backup`)) {
    writeFileSync(`${bridgePath}.v56-backup`, readFileSync(bridgePath));
  }
  writeFileSync(bridgePath, bridge);
  writeFileSync(join(targetRoot, 'V57-MIGRATION-REPORT.json'), JSON.stringify(report, null, 2) + '\n');
}

console.log(JSON.stringify(report, null, 2));
