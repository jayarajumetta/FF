import { mkdir, writeFile } from 'node:fs/promises';
await mkdir(new URL('../dist/v58/', import.meta.url), { recursive: true });
await writeFile(new URL('../dist/v58/package.json', import.meta.url), '{"type":"commonjs"}\n');
