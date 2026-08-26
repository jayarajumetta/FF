import test from 'node:test';
import assert from 'node:assert/strict';
import {
  existsSync,
  mkdirSync,
  mkdtempSync,
  readFileSync,
  rmSync,
  writeFileSync,
} from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve } from 'node:path';
import { spawnSync } from 'node:child_process';

test('v56 installer is non-destructive and writes a migration scan report', () => {
  const root = mkdtempSync(join(tmpdir(), 'v56-mock-'));
  try {
    mkdirSync(join(root, 'src'), { recursive: true });
    writeFileSync(join(root, 'package.json'), JSON.stringify({
      name: 'mock-v56',
      private: true,
      scripts: { test: 'echo old' },
    }, null, 2));
    writeFileSync(join(root, 'src/legacy.ts'), `
      await page.waitForTimeout(300);
      await page.keyboard.press('Tab');
      await chooseDropdownOption(page, state);
    `);

    const script = resolve('scripts/apply-v57-to-v56.mjs');
    const result = spawnSync(process.execPath, [script, root], {
      cwd: resolve('.'),
      encoding: 'utf8',
      timeout: 60_000,
    });
    assert.equal(result.status, 0, result.stderr || result.stdout);
    assert.ok(existsSync(join(root, 'package.json.v56-backup')));
    assert.ok(existsSync(join(root, 'src/v57-bridge.ts')));
    assert.ok(existsSync(join(root, 'vendor/ff-bop-complete-e2e-v57/dist/src/index.js')));
    assert.ok(existsSync(join(root, 'V57-MIGRATION-REPORT.json')));

    const packageJson = JSON.parse(readFileSync(join(root, 'package.json'), 'utf8'));
    assert.equal(packageJson.dependencies['ff-bop-complete-e2e-v57'], 'file:vendor/ff-bop-complete-e2e-v57');
    assert.ok(packageJson.scripts['v57:verify-runtime']);

    const report = JSON.parse(readFileSync(join(root, 'V57-MIGRATION-REPORT.json'), 'utf8'));
    const legacy = report.scanFindings.find((item) => item.file === 'src/legacy.ts');
    assert.equal(legacy.fixedWaits, 1);
    assert.equal(legacy.unconditionalTabs, 1);
    assert.equal(legacy.legacyDropdownHelpers, 1);
  } finally {
    rmSync(root, { recursive: true, force: true });
  }
});
