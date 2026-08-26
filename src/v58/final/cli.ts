declare const require: any;
declare const module: any;
declare const process: any;
declare const __dirname: string;
const fs = require('node:fs');
const path = require('node:path');
const os = require('node:os');
const childProcess = require('node:child_process');

import { auditMapping } from './audit';
import { loadWorkspace } from './decode';
import { generateProject } from './generator';
import { buildWorkspaceGraph } from './graph';
import { mapWorkspace } from './mapper';

function args(argv: string[]): Record<string, string | boolean> {
  const result: Record<string, string | boolean> = { command: argv[0] ?? 'convert' };
  for (let index = 1; index < argv.length; index += 1) {
    const token = argv[index];
    if (!token.startsWith('--')) continue;
    const key = token.slice(2); const next = argv[index + 1];
    if (!next || next.startsWith('--')) result[key] = true;
    else { result[key] = next; index += 1; }
  }
  return result;
}

function mappingScore(mapping: ReturnType<typeof mapWorkspace>): number {
  return (mapping.metrics.testCases ?? 0) * 1_000_000
    + (mapping.metrics.actions ?? 0) * 1_000
    + (mapping.metrics.controls ?? 0) * 10
    + (mapping.metrics.locators ?? 0);
}

function normalizedFallback(input: string): { loaded: ReturnType<typeof loadWorkspace>; graph: ReturnType<typeof buildWorkspaceGraph>; mapping: ReturnType<typeof mapWorkspace>; command: string; stderr: string } | undefined {
  const script = path.resolve(__dirname, '..', '..', 'tools', 'normalize_tosca_export.py');
  if (!fs.existsSync(script)) return undefined;
  const temporary = path.join(os.tmpdir(), `tosca-v58-normalized-${process.pid}-${Date.now()}.json`);
  const commands = [process.env.PYTHON, 'python3', 'python'].filter(Boolean);
  for (const command of commands) {
    const result = childProcess.spawnSync(command, [script, '--input', input, '--output', temporary], {
      encoding: 'utf8', maxBuffer: 16 * 1024 * 1024, timeout: 20 * 60 * 1000,
    });
    if (result.status !== 0 || !fs.existsSync(temporary)) continue;
    try {
      const loaded = loadWorkspace(temporary);
      const graph = buildWorkspaceGraph(loaded.documents);
      const mapping = mapWorkspace(graph, path.basename(input));
      fs.rmSync(temporary, { force: true });
      return { loaded, graph, mapping, command: String(command), stderr: String(result.stderr ?? '') };
    } catch { fs.rmSync(temporary, { force: true }); }
  }
  return undefined;
}

export function convert(input: string, output: string): Record<string, unknown> {
  const nativeLoaded = loadWorkspace(input);
  const nativeGraph = buildWorkspaceGraph(nativeLoaded.documents);
  const nativeMapping = mapWorkspace(nativeGraph, path.basename(input));
  const fallback = normalizedFallback(input);
  const selected = fallback && mappingScore(fallback.mapping) > mappingScore(nativeMapping)
    ? { loaded: fallback.loaded, graph: fallback.graph, mapping: fallback.mapping, mapper: 'python-normalized-guid-graph', fallback }
    : { loaded: nativeLoaded, graph: nativeGraph, mapping: nativeMapping, mapper: 'native-typescript-guid-graph', fallback: undefined };
  const generation = generateProject(selected.mapping, output);
  const audit = auditMapping(selected.mapping);
  fs.mkdirSync(path.join(output, 'reports'), { recursive: true });
  fs.writeFileSync(path.join(output, 'reports', 'v58-mapping-audit.json'), JSON.stringify({
    source: {
      path: input, sha256: nativeLoaded.sourceSha256,
      selectedMapper: selected.mapper,
      nativeMetrics: nativeMapping.metrics,
      normalizedMetrics: fallback?.mapping.metrics,
      documents: selected.loaded.documents.map((doc) => ({ name: doc.name, kind: doc.kind, sha256: doc.sha256, bytes: doc.byteLength, depth: doc.depth })),
      warnings: [...nativeLoaded.warnings, ...(selected.loaded === nativeLoaded ? [] : selected.loaded.warnings)],
    }, audit,
  }, null, 2));
  return {
    input, output, sourceSha256: nativeLoaded.sourceSha256, selectedMapper: selected.mapper,
    decodeWarnings: selected.loaded.warnings.length, graphWarnings: selected.graph.warnings.length,
    nativeMetrics: nativeMapping.metrics, normalizedMetrics: fallback?.mapping.metrics,
    metrics: selected.mapping.metrics, generation, auditPassed: audit.passed,
    auditErrors: audit.issues.filter((issue) => issue.severity === 'error').length,
  };
}

export function main(argv = process.argv.slice(2)): void {
  const options = args(argv); const command = String(options.command);
  if (!['convert', 'audit'].includes(command)) throw new Error(`Unknown command ${command}`);
  const input = String(options.input ?? ''); if (!input) throw new Error('--input is required');
  const output = String(options.output ?? path.resolve(process.cwd(), 'generated-v58'));
  const result = convert(path.resolve(input), path.resolve(output));
  process.stdout.write(`${JSON.stringify(result, null, 2)}\n`);
  if (command === 'audit' && !result.auditPassed) process.exitCode = 2;
}

if (typeof require !== 'undefined' && require.main === module) {
  try { main(); } catch (error) { process.stderr.write(`${String(error)}\n`); process.exitCode = 1; }
}
