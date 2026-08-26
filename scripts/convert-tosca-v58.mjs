import { createRequire } from 'node:module';
import { existsSync } from 'node:fs';
import { spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { dirname, join } from 'node:path';
const here = dirname(fileURLToPath(import.meta.url));
const root = join(here, '..');
const cliPath = join(root, 'dist', 'v58', 'cli.js');
if (!existsSync(cliPath)) {
  const build = spawnSync(process.platform === 'win32' ? 'npm.cmd' : 'npm', ['run', 'v58:build'], { cwd: root, stdio: 'inherit' });
  if (build.status !== 0) process.exit(build.status ?? 1);
}
const require = createRequire(import.meta.url);
const { main } = require(cliPath);
const forwarded = process.argv.slice(2);
const command = forwarded[0] === 'audit' || forwarded[0] === 'convert' ? forwarded : ['convert', ...forwarded];
main(command);
