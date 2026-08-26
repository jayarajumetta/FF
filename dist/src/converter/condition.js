export class ConditionSyntaxError extends Error {
    position;
    input;
    constructor(message, position, input) {
        super(`${message} at position ${position}: ${input}`);
        this.position = position;
        this.input = input;
        this.name = 'ConditionSyntaxError';
    }
}
function isIdentifierStart(character) {
    return /[A-Za-z_$]/.test(character);
}
function isIdentifierPart(character) {
    return /[A-Za-z0-9_.$:\-/]/.test(character);
}
function tokenize(input) {
    const tokens = [];
    let index = 0;
    while (index < input.length) {
        const character = input[index] ?? '';
        if (/\s/.test(character)) {
            index += 1;
            continue;
        }
        if (character === '(') {
            tokens.push({ kind: 'lparen', value: character, position: index });
            index += 1;
            continue;
        }
        if (character === ')') {
            tokens.push({ kind: 'rparen', value: character, position: index });
            index += 1;
            continue;
        }
        if (character === '[') {
            tokens.push({ kind: 'lbracket', value: character, position: index });
            index += 1;
            continue;
        }
        if (character === ']') {
            tokens.push({ kind: 'rbracket', value: character, position: index });
            index += 1;
            continue;
        }
        if (character === ',') {
            tokens.push({ kind: 'comma', value: character, position: index });
            index += 1;
            continue;
        }
        if (character === '{') {
            const start = index;
            let depth = 1;
            index += 1;
            let body = '';
            while (index < input.length && depth > 0) {
                const current = input[index] ?? '';
                if (current === '{')
                    depth += 1;
                else if (current === '}') {
                    depth -= 1;
                    if (depth === 0) {
                        index += 1;
                        break;
                    }
                }
                if (depth > 0)
                    body += current;
                index += 1;
            }
            if (depth !== 0)
                throw new ConditionSyntaxError('Unclosed variable expression', start, input);
            tokens.push({ kind: 'variable', value: body.trim(), position: start });
            continue;
        }
        if (character === '"' || character === "'") {
            const quote = character;
            const start = index;
            index += 1;
            let value = '';
            let closed = false;
            while (index < input.length) {
                const current = input[index] ?? '';
                if (current === '\\') {
                    const next = input[index + 1] ?? '';
                    const escapes = {
                        n: '\n',
                        r: '\r',
                        t: '\t',
                        '\\': '\\',
                        '"': '"',
                        "'": "'",
                    };
                    value += escapes[next] ?? next;
                    index += 2;
                    continue;
                }
                if (current === quote) {
                    closed = true;
                    index += 1;
                    break;
                }
                value += current;
                index += 1;
            }
            if (!closed)
                throw new ConditionSyntaxError('Unclosed string literal', start, input);
            tokens.push({ kind: 'string', value, position: start });
            continue;
        }
        const two = input.slice(index, index + 2);
        const three = input.slice(index, index + 3);
        if (['===', '!=='].includes(three)) {
            tokens.push({ kind: 'operator', value: three, position: index });
            index += 3;
            continue;
        }
        if (['==', '!=', '<>', '>=', '<=', '&&', '||'].includes(two)) {
            tokens.push({ kind: 'operator', value: two, position: index });
            index += 2;
            continue;
        }
        if (['=', '>', '<', '!'].includes(character)) {
            tokens.push({ kind: 'operator', value: character, position: index });
            index += 1;
            continue;
        }
        if (/[-0-9]/.test(character)) {
            const start = index;
            const match = input.slice(index).match(/^-?(?:\d+\.?\d*|\.\d+)(?:[eE][+-]?\d+)?/);
            if (match?.[0]) {
                tokens.push({ kind: 'number', value: match[0], position: start });
                index += match[0].length;
                continue;
            }
        }
        if (isIdentifierStart(character)) {
            const start = index;
            let value = character;
            index += 1;
            while (index < input.length && isIdentifierPart(input[index] ?? '')) {
                value += input[index] ?? '';
                index += 1;
            }
            tokens.push({ kind: 'identifier', value, position: start });
            continue;
        }
        throw new ConditionSyntaxError(`Unexpected character "${character}"`, index, input);
    }
    tokens.push({ kind: 'eof', value: '', position: input.length });
    return tokens;
}
class Parser {
    tokens;
    input;
    index = 0;
    constructor(tokens, input) {
        this.tokens = tokens;
        this.input = input;
    }
    parse() {
        if (this.peek().kind === 'eof')
            return { kind: 'literal', value: true };
        const result = this.parseOr();
        this.expect('eof');
        return result;
    }
    peek(offset = 0) {
        return this.tokens[this.index + offset] ?? this.tokens[this.tokens.length - 1] ?? {
            kind: 'eof',
            value: '',
            position: this.input.length,
        };
    }
    consume() {
        const token = this.peek();
        this.index += 1;
        return token;
    }
    expect(kind, value) {
        const token = this.peek();
        if (token.kind !== kind || (value !== undefined && token.value.toUpperCase() !== value.toUpperCase())) {
            throw new ConditionSyntaxError(`Expected ${value ?? kind}, found ${token.value || token.kind}`, token.position, this.input);
        }
        return this.consume();
    }
    isKeyword(keyword) {
        const token = this.peek();
        return token.kind === 'identifier' && token.value.toUpperCase() === keyword;
    }
    isOperator(...operators) {
        const token = this.peek();
        return token.kind === 'operator' && operators.includes(token.value);
    }
    parseOr() {
        let left = this.parseAnd();
        while (this.isKeyword('OR') || this.isOperator('||')) {
            this.consume();
            left = { kind: 'logical', operator: 'or', left, right: this.parseAnd() };
        }
        return left;
    }
    parseAnd() {
        let left = this.parseUnary();
        while (this.isKeyword('AND') || this.isOperator('&&')) {
            this.consume();
            left = { kind: 'logical', operator: 'and', left, right: this.parseUnary() };
        }
        return left;
    }
    parseUnary() {
        if (this.isKeyword('NOT') || this.isOperator('!')) {
            this.consume();
            return { kind: 'not', operand: this.parseUnary() };
        }
        if (this.peek().kind === 'lparen') {
            this.consume();
            const expression = this.parseOr();
            this.expect('rparen');
            return expression;
        }
        return this.parseComparison();
    }
    parseComparison() {
        const left = this.parseValue();
        if (this.isKeyword('IS')) {
            this.consume();
            const negate = this.isKeyword('NOT');
            if (negate)
                this.consume();
            this.expect('identifier', 'EMPTY');
            return { kind: 'empty', value: left, negate };
        }
        if (this.isKeyword('CONTAINS')) {
            this.consume();
            return { kind: 'predicate', operator: 'contains', left, right: this.parseValue() };
        }
        if (this.isKeyword('STARTSWITH') || this.isKeyword('STARTS_WITH')) {
            this.consume();
            return { kind: 'predicate', operator: 'startsWith', left, right: this.parseValue() };
        }
        if (this.isKeyword('ENDSWITH') || this.isKeyword('ENDS_WITH')) {
            this.consume();
            return { kind: 'predicate', operator: 'endsWith', left, right: this.parseValue() };
        }
        if (this.isKeyword('MATCHES')) {
            this.consume();
            return { kind: 'predicate', operator: 'matches', left, right: this.parseValue() };
        }
        if (this.isKeyword('IN')) {
            this.consume();
            return { kind: 'predicate', operator: 'in', left, right: this.parseValue() };
        }
        const operator = this.peek();
        if (operator.kind === 'operator' && ['=', '==', '===', '!=', '!==', '<>', '>', '>=', '<', '<='].includes(operator.value)) {
            this.consume();
            const mapping = {
                '=': 'eq',
                '==': 'eq',
                '===': 'eq',
                '!=': 'ne',
                '!==': 'ne',
                '<>': 'ne',
                '>': 'gt',
                '>=': 'gte',
                '<': 'lt',
                '<=': 'lte',
            };
            const mapped = mapping[operator.value];
            if (!mapped)
                throw new ConditionSyntaxError('Unsupported comparison operator', operator.position, this.input);
            return { kind: 'comparison', operator: mapped, left, right: this.parseValue() };
        }
        return { kind: 'truthy', value: left };
    }
    parseValue() {
        const token = this.peek();
        if (token.kind === 'string') {
            this.consume();
            const embeddedVariable = token.value.match(/^\{(.+)}$/);
            return embeddedVariable?.[1]
                ? { kind: 'variable', path: embeddedVariable[1].trim() }
                : { kind: 'literal', value: token.value };
        }
        if (token.kind === 'number') {
            this.consume();
            return { kind: 'literal', value: Number(token.value) };
        }
        if (token.kind === 'variable') {
            this.consume();
            return { kind: 'variable', path: token.value };
        }
        if (token.kind === 'lbracket') {
            this.consume();
            const items = [];
            while (this.peek().kind !== 'rbracket') {
                items.push(this.parseValue());
                if (this.peek().kind === 'comma')
                    this.consume();
                else
                    break;
            }
            this.expect('rbracket');
            return { kind: 'array', items };
        }
        if (token.kind === 'identifier') {
            this.consume();
            const keyword = token.value.toUpperCase();
            if (keyword === 'TRUE')
                return { kind: 'literal', value: true };
            if (keyword === 'FALSE')
                return { kind: 'literal', value: false };
            if (keyword === 'NULL' || keyword === 'UNDEFINED')
                return { kind: 'literal', value: null };
            if (keyword === 'EMPTY')
                return { kind: 'literal', value: '' };
            return { kind: 'variable', path: token.value };
        }
        throw new ConditionSyntaxError(`Expected a literal or variable, found ${token.value || token.kind}`, token.position, this.input);
    }
}
export function parseCondition(input) {
    return new Parser(tokenize(input.trim()), input).parse();
}
function getCaseInsensitive(object, key) {
    if (Object.prototype.hasOwnProperty.call(object, key))
        return object[key];
    const actual = Object.keys(object).find((candidate) => candidate.toLowerCase() === key.toLowerCase());
    return actual === undefined ? undefined : object[actual];
}
function normalizeVariablePath(path) {
    let value = path.trim();
    value = value.replace(/^data\./i, '');
    value = value.replace(/^data\[['"](.+?)['"]\]$/i, '$1');
    value = value.replace(/^data\.get\(['"](.+?)['"]\)$/i, '$1');
    return value;
}
function isReadonlyMap(value) {
    return Boolean(value &&
        typeof value === 'object' &&
        'get' in value &&
        'has' in value &&
        'keys' in value &&
        typeof value.get === 'function' &&
        typeof value.has === 'function');
}
export function resolveDataValue(data, path) {
    const normalized = normalizeVariablePath(path);
    if (isReadonlyMap(data)) {
        if (data.has(path))
            return data.get(path);
        if (data.has(normalized))
            return data.get(normalized);
        const key = [...data.keys()].find((candidate) => candidate.toLowerCase() === normalized.toLowerCase());
        if (key !== undefined)
            return data.get(key);
    }
    else {
        const direct = getCaseInsensitive(data, path);
        if (direct !== undefined)
            return direct;
        const normalizedDirect = getCaseInsensitive(data, normalized);
        if (normalizedDirect !== undefined)
            return normalizedDirect;
    }
    const candidatePaths = [...new Set([path.trim(), normalized].filter(Boolean))];
    for (const candidatePath of candidatePaths) {
        const segments = candidatePath
            .replace(/\[\s*['"]?([^\]'".]+)['"]?\s*]/g, '.$1')
            .split('.')
            .map((segment) => segment.trim())
            .filter(Boolean);
        let current = isReadonlyMap(data) ? Object.fromEntries(data.entries()) : data;
        let resolved = true;
        for (const segment of segments) {
            if (!current || typeof current !== 'object') {
                resolved = false;
                break;
            }
            if (isReadonlyMap(current)) {
                if (!current.has(segment)) {
                    const mapKey = [...current.keys()].find((key) => key.toLowerCase() === segment.toLowerCase());
                    if (mapKey === undefined) {
                        resolved = false;
                        break;
                    }
                    current = current.get(mapKey);
                }
                else {
                    current = current.get(segment);
                }
                continue;
            }
            const object = current;
            const directKey = Object.keys(object).find((key) => key.toLowerCase() === segment.toLowerCase());
            if (directKey === undefined) {
                resolved = false;
                break;
            }
            current = object[directKey];
        }
        if (resolved)
            return current;
    }
    return undefined;
}
export function evaluateValue(node, data) {
    switch (node.kind) {
        case 'literal':
            return node.value;
        case 'variable':
            return resolveDataValue(data, node.path);
        case 'array':
            return node.items.map((item) => evaluateValue(item, data));
    }
}
function isEmpty(value) {
    if (value === null || value === undefined)
        return true;
    if (typeof value === 'string')
        return value.trim().length === 0;
    if (Array.isArray(value))
        return value.length === 0;
    if (value instanceof Map || value instanceof Set)
        return value.size === 0;
    return false;
}
function comparable(value) {
    if (typeof value === 'number' || typeof value === 'boolean' || value === null || value === undefined)
        return value;
    if (typeof value === 'string') {
        const trimmed = value.trim();
        if (trimmed !== '' && /^-?(?:\d+\.?\d*|\.\d+)$/.test(trimmed))
            return Number(trimmed);
        return value;
    }
    return String(value);
}
function equals(left, right) {
    const normalizedLeft = comparable(left);
    const normalizedRight = comparable(right);
    return normalizedLeft === normalizedRight;
}
export function evaluateCondition(node, data, options = {}) {
    switch (node.kind) {
        case 'literal':
            return node.value;
        case 'truthy':
            return Boolean(evaluateValue(node.value, data));
        case 'not':
            return !evaluateCondition(node.operand, data, options);
        case 'logical':
            return node.operator === 'and'
                ? evaluateCondition(node.left, data, options) && evaluateCondition(node.right, data, options)
                : evaluateCondition(node.left, data, options) || evaluateCondition(node.right, data, options);
        case 'empty': {
            const result = isEmpty(evaluateValue(node.value, data));
            return node.negate ? !result : result;
        }
        case 'comparison': {
            const left = comparable(evaluateValue(node.left, data));
            const right = comparable(evaluateValue(node.right, data));
            switch (node.operator) {
                case 'eq': return equals(left, right);
                case 'ne': return !equals(left, right);
                case 'gt': return left !== null && left !== undefined && right !== null && right !== undefined && left > right;
                case 'gte': return left !== null && left !== undefined && right !== null && right !== undefined && left >= right;
                case 'lt': return left !== null && left !== undefined && right !== null && right !== undefined && left < right;
                case 'lte': return left !== null && left !== undefined && right !== null && right !== undefined && left <= right;
            }
        }
        case 'predicate': {
            const leftValue = evaluateValue(node.left, data);
            const rightValue = evaluateValue(node.right, data);
            const insensitive = options.caseInsensitivePredicates ?? false;
            const leftText = String(leftValue ?? '');
            const rightText = String(rightValue ?? '');
            const normalizedLeft = insensitive ? leftText.toLowerCase() : leftText;
            const normalizedRight = insensitive ? rightText.toLowerCase() : rightText;
            switch (node.operator) {
                case 'contains':
                    return Array.isArray(leftValue)
                        ? leftValue.some((item) => equals(item, rightValue))
                        : normalizedLeft.includes(normalizedRight);
                case 'startsWith':
                    return normalizedLeft.startsWith(normalizedRight);
                case 'endsWith':
                    return normalizedLeft.endsWith(normalizedRight);
                case 'matches':
                    try {
                        return new RegExp(rightText, insensitive ? 'i' : undefined).test(leftText);
                    }
                    catch {
                        return false;
                    }
                case 'in':
                    return Array.isArray(rightValue)
                        ? rightValue.some((item) => equals(leftValue, item))
                        : normalizedRight.split(',').map((item) => item.trim()).includes(normalizedLeft);
            }
        }
    }
}
export function collectConditionVariables(node) {
    const output = new Set();
    const visitValue = (value) => {
        if (value.kind === 'variable')
            output.add(normalizeVariablePath(value.path));
        else if (value.kind === 'array')
            value.items.forEach(visitValue);
    };
    const visit = (condition) => {
        switch (condition.kind) {
            case 'literal':
                break;
            case 'truthy':
                visitValue(condition.value);
                break;
            case 'not':
                visit(condition.operand);
                break;
            case 'logical':
                visit(condition.left);
                visit(condition.right);
                break;
            case 'comparison':
            case 'predicate':
                visitValue(condition.left);
                visitValue(condition.right);
                break;
            case 'empty':
                visitValue(condition.value);
                break;
        }
    };
    visit(node);
    return output;
}
//# sourceMappingURL=condition.js.map