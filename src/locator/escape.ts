/** Escapes a value placed inside a double-quoted CSS attribute selector. */
export function escapeCssAttributeValue(value: string): string {
  return value
    .replace(/\\/g, '\\\\')
    .replace(/"/g, '\\"')
    .replace(/\r/g, '\\d ')
    .replace(/\n/g, '\\a ')
    .replace(/\f/g, '\\c ');
}

export function exactAttributeSelector(attribute: string, value: string): string {
  const safeAttribute = attribute.replace(/[^a-zA-Z0-9_:-]/g, '');
  if (!safeAttribute) {
    throw new Error(`Unsafe/empty attribute name: ${attribute}`);
  }
  return `[${safeAttribute}="${escapeCssAttributeValue(value)}"]`;
}

export function quoteXPathLiteral(value: string): string {
  if (!value.includes("'")) return `'${value}'`;
  if (!value.includes('"')) return `"${value}"`;

  const pieces = value.split("'");
  const args: string[] = [];
  for (let index = 0; index < pieces.length; index += 1) {
    const piece = pieces[index] ?? '';
    if (piece) args.push(`'${piece}'`);
    if (index < pieces.length - 1) args.push('"\'"');
  }
  return `concat(${args.join(', ')})`;
}

export function normalizeWhitespace(value: string): string {
  return value.replace(/\s+/g, ' ').trim();
}
