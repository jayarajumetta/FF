import type { DataSource } from './condition.js';
import { resolveDataValue } from './condition.js';
import type { RuntimeValueExpression } from './model.js';

export function resolveRuntimeValue(
  expression: RuntimeValueExpression | undefined,
  data: DataSource,
): unknown {
  if (!expression) return undefined;
  switch (expression.kind) {
    case 'literal':
      return expression.value;
    case 'data': {
      const value = resolveDataValue(data, expression.key);
      if (value === undefined && expression.required !== false) {
        throw new Error(`Required test data key was not resolved: ${expression.key}`);
      }
      return value;
    }
    case 'template':
      return interpolateTemplate(expression.template, data);
    case 'randomText': {
      const alphabet = expression.alphabet ?? 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
      if (expression.length < 0 || !Number.isInteger(expression.length)) {
        throw new Error(`randomText length must be a non-negative integer: ${expression.length}`);
      }
      let output = '';
      for (let index = 0; index < expression.length; index += 1) {
        output += alphabet[Math.floor(Math.random() * alphabet.length)] ?? '';
      }
      return output;
    }
  }
}

export function interpolateTemplate(template: string, data: DataSource): string {
  const patterns = [
    /\{\{\s*(?:data|buffer|env)\s*:\s*([^}]+)}}/gi,
    /\{([^{}]+)}/g,
  ];
  let output = template;
  for (const pattern of patterns) {
    output = output.replace(pattern, (whole, rawKey: string) => {
      const key = rawKey.trim();
      const value = resolveDataValue(data, key);
      return value === undefined || value === null ? whole : String(value);
    });
  }
  return output;
}

export function collectValueDependencies(
  expression: RuntimeValueExpression | undefined,
): Set<string> {
  const output = new Set<string>();
  if (!expression) return output;
  if (expression.kind === 'data') output.add(expression.key);
  if (expression.kind === 'template') {
    for (const match of expression.template.matchAll(/\{\{\s*(?:data|buffer|env)\s*:\s*([^}]+)}}|\{([^{}]+)}/gi)) {
      const key = (match[1] ?? match[2])?.trim();
      if (key) output.add(key);
    }
  }
  return output;
}
