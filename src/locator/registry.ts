import type { LocatorSpec } from './model.js';

export interface LocatorRegistryEntry {
  name: string;
  spec: LocatorSpec;
  keys: readonly string[];
  identity: string;
}

function stable(value: unknown): unknown {
  if (Array.isArray(value)) return value.map(stable);
  if (value && typeof value === 'object') {
    return Object.fromEntries(
      Object.entries(value as Record<string, unknown>)
        .filter(([, item]) => item !== undefined)
        .sort(([left], [right]) => left.localeCompare(right))
        .map(([key, item]) => [key, stable(item)]),
    );
  }
  return value;
}

function executableIdentity(spec: LocatorSpec): string {
  const { key: _key, raw: _raw, ...executable } = spec;
  return JSON.stringify(stable(executable));
}

function fnv1a(value: string): string {
  let hash = 0x811c9dc5;
  for (let index = 0; index < value.length; index += 1) {
    hash ^= value.charCodeAt(index);
    hash = Math.imul(hash, 0x01000193);
  }
  return (hash >>> 0).toString(16).padStart(8, '0');
}

const RESERVED = new Set([
  'await', 'break', 'case', 'catch', 'class', 'const', 'continue', 'debugger',
  'default', 'delete', 'do', 'else', 'enum', 'export', 'extends', 'false',
  'finally', 'for', 'function', 'if', 'implements', 'import', 'in', 'instanceof',
  'interface', 'let', 'new', 'null', 'package', 'private', 'protected', 'public',
  'return', 'static', 'super', 'switch', 'this', 'throw', 'true', 'try', 'typeof',
  'var', 'void', 'while', 'with', 'yield',
]);

export function locatorConstantName(value: string): string {
  const words = value
    .replace(/([a-z0-9])([A-Z])/g, '$1 $2')
    .split(/[^A-Za-z0-9_$]+/)
    .filter(Boolean);
  let name = words
    .map((word, index) => index === 0
      ? word.charAt(0).toLowerCase() + word.slice(1)
      : word.charAt(0).toUpperCase() + word.slice(1))
    .join('');
  if (!name) name = 'locator';
  if (!/^[A-Za-z_$]/.test(name)) name = `locator_${name}`;
  if (RESERVED.has(name)) name = `${name}Locator`;
  return name;
}

export class LocatorRegistry {
  private readonly byIdentity = new Map<string, { name: string; spec: LocatorSpec; keys: Set<string> }>();
  private readonly identitiesByName = new Map<string, string>();

  register(spec: LocatorSpec, suggestedName = spec.key): string {
    const identity = executableIdentity(spec);
    const existing = this.byIdentity.get(identity);
    if (existing) {
      existing.keys.add(spec.key);
      return existing.name;
    }

    const base = locatorConstantName(suggestedName);
    let name = base;
    const collision = this.identitiesByName.get(name);
    if (collision && collision !== identity) name = `${base}_${fnv1a(identity).slice(0, 6)}`;
    let suffix = 2;
    while (this.identitiesByName.has(name) && this.identitiesByName.get(name) !== identity) {
      name = `${base}_${suffix}`;
      suffix += 1;
    }

    this.byIdentity.set(identity, { name, spec, keys: new Set([spec.key]) });
    this.identitiesByName.set(name, identity);
    return name;
  }

  entries(): LocatorRegistryEntry[] {
    return [...this.byIdentity.entries()]
      .map(([identity, entry]) => ({
        name: entry.name,
        spec: entry.spec,
        keys: [...entry.keys].sort(),
        identity,
      }))
      .sort((left, right) => left.name.localeCompare(right.name));
  }

  get size(): number {
    return this.byIdentity.size;
  }
}
