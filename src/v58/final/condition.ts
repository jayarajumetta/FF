import { normalizeKey } from './model';

export type ConditionNode =
  | { type: 'literal'; value: unknown }
  | { type: 'symbol'; name: string }
  | { type: 'unary'; operator: 'not' | 'empty' | 'notEmpty'; operand: ConditionNode }
  | { type: 'binary'; operator: string; left: ConditionNode; right: ConditionNode }
  | { type: 'list'; values: ConditionNode[] };

type TokenKind = 'string' | 'number' | 'symbol' | 'operator' | 'lparen' | 'rparen' | 'comma' | 'eof';
interface Token { kind: TokenKind; value: string; position: number }

const WORD_OPERATORS = new Set([
  'and', 'or', 'not', 'contains', 'startswith', 'endswith', 'matches', 'in', 'is', 'empty', 'equals',
]);

function normalizeOperator(value: string): string {
  const key = value.toLowerCase().replace(/[\s_-]/g, '');
  const aliases: Record<string, string> = {
    '&&': 'and', '||': 'or', '!': 'not', '=': 'eq', '==': 'eq', '===': 'eq',
    '!=': 'ne', '<>': 'ne', '!==': 'ne', '>': 'gt', '<': 'lt', '>=': 'gte', '<=': 'lte',
    equals: 'eq', notequals: 'ne', contains: 'contains', startswith: 'startsWith',
    endswith: 'endsWith', matches: 'matches', in: 'in', and: 'and', or: 'or', not: 'not',
  };
  return aliases[key] ?? value;
}

function tokenize(input: string): Token[] {
  const tokens: Token[] = [];
  let index = 0;
  const push = (kind: TokenKind, value: string, position: number) => tokens.push({ kind, value, position });
  while (index < input.length) {
    const char = input[index];
    if (/\s/.test(char)) { index += 1; continue; }
    if (char === '(') { push('lparen', char, index++); continue; }
    if (char === ')') { push('rparen', char, index++); continue; }
    if (char === ',') { push('comma', char, index++); continue; }
    if (char === '"' || char === "'") {
      const quote = char; const start = index; index += 1; let value = '';
      while (index < input.length) {
        const current = input[index++];
        if (current === '\\' && index < input.length) { value += input[index++]; continue; }
        if (current === quote) break;
        value += current;
      }
      push('string', value, start); continue;
    }
    if (char === '{') {
      const start = index; let depth = 0; let value = '';
      while (index < input.length) {
        const current = input[index++]; value += current;
        if (current === '{') depth += 1;
        if (current === '}') { depth -= 1; if (depth === 0) break; }
      }
      push('symbol', value, start); continue;
    }
    const two = input.slice(index, index + 2);
    const three = input.slice(index, index + 3);
    if (['===', '!=='].includes(three)) { push('operator', three, index); index += 3; continue; }
    if (['&&', '||', '==', '!=', '<=', '>=', '<>'].includes(two)) { push('operator', two, index); index += 2; continue; }
    if (['!', '=', '<', '>'].includes(char)) { push('operator', char, index++); continue; }
    const number = input.slice(index).match(/^-?\d+(?:\.\d+)?/);
    if (number) { push('number', number[0], index); index += number[0].length; continue; }
    const start = index;
    while (index < input.length && !/[\s(),=!<>|&]/.test(input[index])) index += 1;
    const value = input.slice(start, index);
    if (!value) { index += 1; continue; }
    const lower = value.toLowerCase();
    push(WORD_OPERATORS.has(lower) ? 'operator' : 'symbol', value, start);
  }
  tokens.push({ kind: 'eof', value: '', position: input.length });
  return tokens;
}

class Parser {
  private readonly tokens: Token[];
  private index = 0;
  constructor(input: string) { this.tokens = tokenize(input); }
  private current(): Token { return this.tokens[this.index]; }
  private consume(): Token { return this.tokens[this.index++]; }
  private accept(kind: TokenKind, value?: string): Token | undefined {
    const token = this.current();
    if (token.kind !== kind) return undefined;
    if (value !== undefined && token.value.toLowerCase() !== value.toLowerCase()) return undefined;
    this.index += 1; return token;
  }
  parse(): ConditionNode {
    if (this.current().kind === 'eof') return { type: 'literal', value: true };
    const node = this.parseOr();
    return node;
  }
  private parseOr(): ConditionNode {
    let node = this.parseAnd();
    while (this.current().kind === 'operator' && normalizeOperator(this.current().value) === 'or') {
      this.consume(); node = { type: 'binary', operator: 'or', left: node, right: this.parseAnd() };
    }
    return node;
  }
  private parseAnd(): ConditionNode {
    let node = this.parseComparison();
    while (this.current().kind === 'operator' && normalizeOperator(this.current().value) === 'and') {
      this.consume(); node = { type: 'binary', operator: 'and', left: node, right: this.parseComparison() };
    }
    return node;
  }
  private parseComparison(): ConditionNode {
    let node = this.parseUnary();
    const token = this.current();
    if (token.kind !== 'operator') return node;
    let operator = normalizeOperator(token.value);
    if (operator === 'is') {
      this.consume();
      let negated = false;
      if (this.current().kind === 'operator' && normalizeOperator(this.current().value) === 'not') {
        this.consume(); negated = true;
      }
      if (this.current().value.toLowerCase() === 'empty') {
        this.consume(); return { type: 'unary', operator: negated ? 'notEmpty' : 'empty', operand: node };
      }
      return node;
    }
    if (!['eq', 'ne', 'gt', 'lt', 'gte', 'lte', 'contains', 'startsWith', 'endsWith', 'matches', 'in'].includes(operator)) return node;
    this.consume();
    let right: ConditionNode;
    if (operator === 'in' && this.accept('lparen')) {
      const values: ConditionNode[] = [];
      while (this.current().kind !== 'rparen' && this.current().kind !== 'eof') {
        values.push(this.parseUnary());
        if (!this.accept('comma')) break;
      }
      this.accept('rparen'); right = { type: 'list', values };
    } else {
      right = this.parseUnary();
    }
    return { type: 'binary', operator, left: node, right };
  }
  private parseUnary(): ConditionNode {
    const token = this.current();
    if (token.kind === 'operator' && normalizeOperator(token.value) === 'not') {
      this.consume(); return { type: 'unary', operator: 'not', operand: this.parseUnary() };
    }
    if (this.accept('lparen')) {
      const node = this.parseOr(); this.accept('rparen'); return node;
    }
    return this.parsePrimary();
  }
  private parsePrimary(): ConditionNode {
    const token = this.consume();
    if (token.kind === 'string') return { type: 'literal', value: token.value };
    if (token.kind === 'number') return { type: 'literal', value: Number(token.value) };
    if (token.kind === 'symbol') {
      const lower = token.value.toLowerCase();
      if (lower === 'true') return { type: 'literal', value: true };
      if (lower === 'false') return { type: 'literal', value: false };
      if (['null', 'undefined'].includes(lower)) return { type: 'literal', value: null };
      return { type: 'symbol', name: token.value };
    }
    return { type: 'literal', value: token.value };
  }
}

function unwrapToscaSymbol(symbol: string): string {
  const trimmed = symbol.trim();
  const buffer = trimmed.match(/^\{\s*(?:B|BUFFER)\s*\[([^\]]+)\]\s*\}$/i);
  if (buffer) return buffer[1].trim();
  const excel = trimmed.match(/^\{\s*(?:XL|CP|TD|TCD)\s*\[([^\]]+)\]\s*\}$/i);
  if (excel) return excel[1].trim();
  const template = trimmed.match(/^\$\{([^}]+)\}$/);
  if (template) return template[1].trim();
  const moustache = trimmed.match(/^\{\{([^}]+)\}\}$/);
  if (moustache) return moustache[1].trim();
  return trimmed.replace(/^data\./i, '');
}

export class DataContext {
  private readonly values = new Map<string, unknown>();
  private readonly originalKeys = new Map<string, string>();
  readonly writes: Array<{ key: string; value: unknown; actionId?: string; ordinal?: number }> = [];
  constructor(initial: Record<string, unknown> = {}) { this.merge(initial); }
  merge(values: Record<string, unknown>): void {
    for (const [key, value] of Object.entries(values)) this.set(key, value);
  }
  set(key: string, value: unknown, actionId?: string, ordinal?: number): void {
    const normalized = normalizeKey(key);
    this.values.set(normalized, value); this.originalKeys.set(normalized, key);
    this.writes.push({ key, value, actionId, ordinal });
  }
  has(key: string): boolean { return this.lookup(key).found; }
  get(key: string): unknown { return this.lookup(key).value; }
  private lookup(key: string): { found: boolean; value: unknown } {
    const path = unwrapToscaSymbol(key).split(/[./]/).filter(Boolean);
    if (!path.length) return { found: false, value: undefined };
    const firstKey = normalizeKey(path[0]);
    if (!this.values.has(firstKey)) return { found: false, value: undefined };
    let value = this.values.get(firstKey);
    for (const segment of path.slice(1)) {
      if (!value || typeof value !== 'object') return { found: false, value: undefined };
      const record = value as Record<string, unknown>;
      const actual = Object.keys(record).find((candidate) => normalizeKey(candidate) === normalizeKey(segment));
      if (!actual) return { found: false, value: undefined };
      value = record[actual];
    }
    return { found: true, value };
  }
  snapshot(): Record<string, unknown> {
    const result: Record<string, unknown> = {};
    for (const [normalized, value] of this.values) result[this.originalKeys.get(normalized) ?? normalized] = value;
    return result;
  }
  expand(value: string): string {
    return value.replace(/\{(?:B|BUFFER|XL|CP|TD|TCD)\[([^\]]+)\]\}|\$\{([^}]+)\}|\{\{([^}]+)\}\}/gi,
      (match, a, b, c) => {
        const key = a ?? b ?? c; const found = this.lookup(key);
        return found.found ? String(found.value ?? '') : match;
      });
  }
}

function truthy(value: unknown): boolean {
  if (typeof value === 'string') {
    const normalized = value.trim().toLowerCase();
    if (['', 'false', '0', 'no', 'n', 'null', 'undefined'].includes(normalized)) return false;
    if (['true', '1', 'yes', 'y'].includes(normalized)) return true;
  }
  return Boolean(value);
}

function comparable(value: unknown): unknown {
  if (typeof value !== 'string') return value;
  const trimmed = value.trim();
  if (/^-?\d+(?:\.\d+)?$/.test(trimmed)) return Number(trimmed);
  return trimmed.toLocaleLowerCase();
}

function resolve(node: ConditionNode, data: DataContext): unknown {
  switch (node.type) {
    case 'literal': return node.value;
    case 'symbol': {
      const found = data.has(node.name);
      return found ? data.get(node.name) : unwrapToscaSymbol(node.name);
    }
    case 'list': return node.values.map((entry) => resolve(entry, data));
    case 'unary': {
      const value = resolve(node.operand, data);
      if (node.operator === 'not') return !truthy(value);
      const isEmpty = value === undefined || value === null || String(value).trim() === '' || (Array.isArray(value) && value.length === 0);
      return node.operator === 'empty' ? isEmpty : !isEmpty;
    }
    case 'binary': {
      if (node.operator === 'and') return truthy(resolve(node.left, data)) && truthy(resolve(node.right, data));
      if (node.operator === 'or') return truthy(resolve(node.left, data)) || truthy(resolve(node.right, data));
      const left = resolve(node.left, data); const right = resolve(node.right, data);
      const l = comparable(left); const r = comparable(right);
      switch (node.operator) {
        case 'eq': return l === r;
        case 'ne': return l !== r;
        case 'gt': return (l as number) > (r as number);
        case 'lt': return (l as number) < (r as number);
        case 'gte': return (l as number) >= (r as number);
        case 'lte': return (l as number) <= (r as number);
        case 'contains': return String(left ?? '').toLocaleLowerCase().includes(String(right ?? '').toLocaleLowerCase());
        case 'startsWith': return String(left ?? '').toLocaleLowerCase().startsWith(String(right ?? '').toLocaleLowerCase());
        case 'endsWith': return String(left ?? '').toLocaleLowerCase().endsWith(String(right ?? '').toLocaleLowerCase());
        case 'matches': {
          try { return new RegExp(String(right), 'i').test(String(left ?? '')); } catch { return false; }
        }
        case 'in': return Array.isArray(right) && right.some((entry) => comparable(entry) === l);
        default: return false;
      }
    }
  }
}

export function parseCondition(expression: string): ConditionNode {
  return new Parser(expression.trim()).parse();
}

export function evaluateCondition(expression: string | undefined, data: DataContext): boolean {
  if (!expression || !expression.trim()) return true;
  try { return truthy(resolve(parseCondition(data.expand(expression)), data)); }
  catch { return false; }
}
