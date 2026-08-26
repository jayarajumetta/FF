import { cp, mkdir, readFile, writeFile, access } from 'node:fs/promises';
import { constants } from 'node:fs';
import { resolve, dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const sourceRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const targetRoot = resolve(process.argv[2] ?? '');
if (!process.argv[2]) throw new Error('Usage: node scripts/apply-v58-to-v57.mjs /absolute/path/to/v57');
await access(join(targetRoot, 'package.json'), constants.R_OK | constants.W_OK);

const packagePath = join(targetRoot, 'package.json');
const backupPath = join(targetRoot, 'package.json.v57-backup');
try { await access(backupPath); } catch { await cp(packagePath, backupPath); }

await mkdir(join(targetRoot, 'src', 'v58', 'final'), { recursive: true });
await cp(join(sourceRoot, 'src', 'v58', 'final'), join(targetRoot, 'src', 'v58', 'final'), { recursive: true, force: true });
await cp(join(sourceRoot, 'tsconfig.v58.json'), join(targetRoot, 'tsconfig.v58.json'), { force: true });
await mkdir(join(targetRoot, 'tools'), { recursive: true });
for (const name of ['normalize_tosca_export.py', 'real_export_probe.py', 'build_real_gate.py']) {
  await cp(join(sourceRoot, 'tools', name), join(targetRoot, 'tools', name), { force: true });
}
await mkdir(join(targetRoot, 'scripts'), { recursive: true });
for (const name of ['convert-tosca-v58.mjs', 'v58-postbuild.mjs', 'verify-v58.mjs']) {
  await cp(join(sourceRoot, 'scripts', name), join(targetRoot, 'scripts', name), { force: true });
}

const pkg = JSON.parse(await readFile(packagePath, 'utf8'));
pkg.scripts = {
  ...(pkg.scripts ?? {}),
  'v58:build': 'tsc -p tsconfig.v58.json && node scripts/v58-postbuild.mjs',
  'v58:test': 'node --test tests/v58/*.test.mjs',
  'v58:convert': 'node scripts/convert-tosca-v58.mjs',
  'v58:audit': 'node scripts/convert-tosca-v58.mjs audit',
  'v58:verify': 'npm run v58:build && npm run v58:test && node scripts/verify-v58.mjs',
};
pkg.exports = {
  ...(typeof pkg.exports === 'object' && pkg.exports ? pkg.exports : {}),
  './v58': { types: './dist/v58/index.d.ts', require: './dist/v58/index.js', default: './dist/v58/index.js' },
};
await writeFile(packagePath, `${JSON.stringify(pkg, null, 2)}\n`);
await writeFile(join(targetRoot, 'src', 'v58-bridge.ts'), "export * from './v58/final/index';\n");
const report = {
  version: '58.0.0',
  appliedAt: new Date().toISOString(),
  source: sourceRoot,
  target: targetRoot,
  packageBackup: backupPath,
  behavior: 'non-destructive overlay; existing business features and tests were not rewritten',
};
await writeFile(join(targetRoot, 'V58-MIGRATION-REPORT.json'), `${JSON.stringify(report, null, 2)}\n`);
console.log(JSON.stringify(report, null, 2));
