import type { LocatorSpec, RawLocatorEvidence } from '../locator/model.js';

export interface RawActionEvidence {
  sourceFile?: string;
  entityGuid?: string;
  stepName?: string;
  controlName?: string;
  actionMode?: string;
  value?: string;
  condition?: string;
  order?: number;
  properties: Readonly<Record<string, string>>;
}

export interface RawToscaEvidence {
  locators: readonly RawLocatorEvidence[];
  actions: readonly RawActionEvidence[];
}

function decodeXml(value: string): string {
  const entities: Record<string, string> = {
    amp: '&',
    lt: '<',
    gt: '>',
    quot: '"',
    apos: "'",
  };
  return value.replace(/&(#x[0-9a-f]+|#\d+|amp|lt|gt|quot|apos);/gi, (whole, entity: string) => {
    if (entity.startsWith('#x')) return String.fromCodePoint(Number.parseInt(entity.slice(2), 16));
    if (entity.startsWith('#')) return String.fromCodePoint(Number.parseInt(entity.slice(1), 10));
    return entities[entity.toLowerCase()] ?? whole;
  });
}

function parseAttributes(source: string): Record<string, string> {
  const output: Record<string, string> = {};
  const pattern = /([:\w.-]+)\s*=\s*(?:"([^"]*)"|'([^']*)')/g;
  for (const match of source.matchAll(pattern)) {
    const key = match[1];
    if (!key) continue;
    output[key] = decodeXml(match[2] ?? match[3] ?? '');
  }
  return output;
}

function setCaseInsensitive(
  target: Record<string, string>,
  key: string | undefined,
  value: string | undefined,
): void {
  if (!key || value === undefined) return;
  const existing = Object.keys(target).find((item) => item.toLowerCase() === key.toLowerCase());
  if (existing) {
    if (!target[existing] && value) target[existing] = value;
    return;
  }
  target[key] = value;
}

function valueByNames(properties: Readonly<Record<string, string>>, names: readonly string[]): string | undefined {
  for (const name of names) {
    const key = Object.keys(properties).find((item) => item.toLowerCase() === name.toLowerCase());
    const value = key ? properties[key]?.trim() : undefined;
    if (value) return value;
  }
  return undefined;
}

function integerByNames(properties: Readonly<Record<string, string>>, names: readonly string[]): number | undefined {
  const raw = valueByNames(properties, names);
  if (!raw) return undefined;
  const parsed = Number.parseInt(raw, 10);
  return Number.isFinite(parsed) && parsed > 0 ? parsed : undefined;
}

function collectProperties(attributes: string, body: string): Record<string, string> {
  const output = parseAttributes(attributes);

  // Tosca exports vary by version: property name/value can be attributes,
  // nested Value nodes, or direct scalar elements. Read all three forms.
  const propertyTag = /<(?:Param|Parameter|Property|Attribute|IdentificationParameter)\b([^>]*?)(?:\/>|>([\s\S]*?)<\/(?:Param|Parameter|Property|Attribute|IdentificationParameter)>)/gi;
  for (const match of body.matchAll(propertyTag)) {
    const attrs = parseAttributes(match[1] ?? '');
    const key = valueByNames(attrs, ['Name', 'Key', 'Property', 'ParameterName', 'TechnicalName']);
    const value = valueByNames(attrs, ['Value', 'Data', 'Content']) ?? decodeXml((match[2] ?? '').replace(/<[^>]+>/g, '').trim());
    setCaseInsensitive(output, key, value);
  }

  const namedValue = /<Value\b([^>]*)>([\s\S]*?)<\/Value>/gi;
  for (const match of body.matchAll(namedValue)) {
    const attrs = parseAttributes(match[1] ?? '');
    const key = valueByNames(attrs, ['Name', 'Key', 'Property']);
    const value = decodeXml((match[2] ?? '').replace(/<[^>]+>/g, '').trim());
    setCaseInsensitive(output, key, value);
  }

  const scalarTags = [
    'Name', 'Id', 'ID', 'FieldRef', 'FieldReference', 'BusinessFieldRef',
    'ControlType', 'Tag', 'TagName', 'Occurrence', 'Index', 'XPath', 'CustomXPath',
    'CSS', 'CssSelector', 'Role', 'Label', 'ActionMode', 'Value', 'Condition',
    'Order', 'Position', 'Surrogate', 'Guid', 'GUID', 'ModuleGuid', 'ModuleName',
  ];
  for (const tag of scalarTags) {
    const pattern = new RegExp(`<${tag}\\b[^>]*>([\\s\\S]*?)<\\/${tag}>`, 'i');
    const match = body.match(pattern);
    if (match?.[1] !== undefined) {
      setCaseInsensitive(output, tag, decodeXml(match[1].replace(/<[^>]+>/g, '').trim()));
    }
  }
  return output;
}

function locatorFromProperties(
  properties: Readonly<Record<string, string>>,
  sourceFile?: string,
): RawLocatorEvidence | undefined {
  const controlName = valueByNames(properties, ['Name', 'ControlName', 'TechnicalName', 'Caption']);
  const fieldRef = valueByNames(properties, ['FieldRef', 'FieldReference', 'BusinessFieldRef', 'Field Ref']);
  const id = valueByNames(properties, ['Id', 'ID', 'HtmlId', 'AutomationId']);
  const controlType = valueByNames(properties, ['ControlType', 'Type', 'ClassName']);
  const tag = valueByNames(properties, ['Tag', 'TagName', 'HtmlTag']);
  const customXPath = valueByNames(properties, ['CustomXPath', 'XPath', 'Path']);
  const occurrence = integerByNames(properties, ['Occurrence', 'Index', 'Instance', 'Ordinal']);
  const order = integerByNames(properties, ['Order', 'Position', 'Sequence']);

  if (!controlName && !fieldRef && !id && !customXPath) return undefined;
  return {
    ...(sourceFile === undefined ? {} : { sourceFile }),
    ...(valueByNames(properties, ['Surrogate', 'Guid', 'GUID', 'UniqueId'])
      ? { entityGuid: valueByNames(properties, ['Surrogate', 'Guid', 'GUID', 'UniqueId']) as string }
      : {}),
    ...(valueByNames(properties, ['ModuleGuid', 'ReferencedModule', 'ModuleId'])
      ? { moduleGuid: valueByNames(properties, ['ModuleGuid', 'ReferencedModule', 'ModuleId']) as string }
      : {}),
    ...(valueByNames(properties, ['ModuleName', 'ParentModule'])
      ? { moduleName: valueByNames(properties, ['ModuleName', 'ParentModule']) as string }
      : {}),
    ...(controlName === undefined ? {} : { controlName }),
    ...(fieldRef === undefined ? {} : { fieldRef }),
    ...(id === undefined ? {} : { id }),
    ...(tag === undefined ? {} : { tag }),
    ...(controlType === undefined ? {} : { controlType }),
    ...(occurrence === undefined ? {} : { occurrence }),
    ...(order === undefined ? {} : { order }),
    ...(customXPath === undefined ? {} : { customXPath }),
    rawProperties: properties,
  };
}

function actionFromProperties(
  properties: Readonly<Record<string, string>>,
  sourceFile?: string,
): RawActionEvidence | undefined {
  const actionMode = valueByNames(properties, ['ActionMode', 'Mode']);
  const value = valueByNames(properties, ['Value', 'TestValue', 'InputValue']);
  const condition = valueByNames(properties, ['Condition', 'Constraint', 'Expression']);
  if (!actionMode && value === undefined && !condition) return undefined;
  return {
    ...(sourceFile === undefined ? {} : { sourceFile }),
    ...(valueByNames(properties, ['Surrogate', 'Guid', 'GUID', 'UniqueId'])
      ? { entityGuid: valueByNames(properties, ['Surrogate', 'Guid', 'GUID', 'UniqueId']) as string }
      : {}),
    ...(valueByNames(properties, ['StepName', 'TestStepName'])
      ? { stepName: valueByNames(properties, ['StepName', 'TestStepName']) as string }
      : {}),
    ...(valueByNames(properties, ['Name', 'ControlName', 'TechnicalName'])
      ? { controlName: valueByNames(properties, ['Name', 'ControlName', 'TechnicalName']) as string }
      : {}),
    ...(actionMode === undefined ? {} : { actionMode }),
    ...(value === undefined ? {} : { value }),
    ...(condition === undefined ? {} : { condition }),
    ...(integerByNames(properties, ['Order', 'Position', 'Sequence']) === undefined
      ? {}
      : { order: integerByNames(properties, ['Order', 'Position', 'Sequence']) as number }),
    properties,
  };
}

export function extractRawToscaEvidence(xml: string, sourceFile?: string): RawToscaEvidence {
  const locators: RawLocatorEvidence[] = [];
  const actions: RawActionEvidence[] = [];
  const seenLocator = new Set<string>();
  const seenAction = new Set<string>();

  const blockPattern = /<(XModuleAttribute|ModuleAttribute|TBoxObject|Control|XTestStepValue|TestStepValue)\b([^>]*)>([\s\S]*?)<\/\1>/gi;
  for (const match of xml.matchAll(blockPattern)) {
    const tag = (match[1] ?? '').toLowerCase();
    const properties = collectProperties(match[2] ?? '', match[3] ?? '');
    if (tag.includes('moduleattribute') || tag === 'tboxobject' || tag === 'control') {
      const locator = locatorFromProperties(properties, sourceFile);
      if (locator) {
        const identity = JSON.stringify(locator);
        if (!seenLocator.has(identity)) {
          seenLocator.add(identity);
          locators.push(locator);
        }
      }
    }
    if (tag.includes('teststepvalue')) {
      const action = actionFromProperties(properties, sourceFile);
      if (action) {
        const identity = JSON.stringify(action);
        if (!seenAction.has(identity)) {
          seenAction.add(identity);
          actions.push(action);
        }
      }
    }
  }

  return { locators, actions };
}

function flattenObject(
  value: unknown,
  output: Array<Readonly<Record<string, string>>>,
  seen: Set<object>,
): void {
  if (!value || typeof value !== 'object') return;
  if (seen.has(value as object)) return;
  seen.add(value as object);

  if (Array.isArray(value)) {
    value.forEach((item) => flattenObject(item, output, seen));
    return;
  }

  const object = value as Record<string, unknown>;
  const scalar: Record<string, string> = {};
  for (const [key, item] of Object.entries(object)) {
    if (typeof item === 'string' || typeof item === 'number' || typeof item === 'boolean') {
      scalar[key] = String(item);
    }
  }
  if (Object.keys(scalar).length > 0) output.push(scalar);
  Object.values(object).forEach((item) => flattenObject(item, output, seen));
}

export function extractRawToscaEvidenceFromObject(
  value: unknown,
  sourceFile?: string,
): RawToscaEvidence {
  const objects: Array<Readonly<Record<string, string>>> = [];
  flattenObject(value, objects, new Set<object>());
  const locators: RawLocatorEvidence[] = [];
  const actions: RawActionEvidence[] = [];
  for (const properties of objects) {
    const locator = locatorFromProperties(properties, sourceFile);
    if (locator) locators.push(locator);
    const action = actionFromProperties(properties, sourceFile);
    if (action) actions.push(action);
  }
  return { locators, actions };
}

export function locatorSpecFromRawEvidence(
  evidence: RawLocatorEvidence,
  app: string,
  key = evidence.controlName ?? evidence.fieldRef ?? evidence.id ?? 'toscaControl',
): LocatorSpec {
  const properties = evidence.rawProperties ?? {};
  const role = valueByNames(properties, ['Role', 'AriaRole']);
  const label = valueByNames(properties, ['Label', 'Caption', 'AriaLabel']);
  const name = valueByNames(properties, ['HtmlName', 'NameAttribute']);
  const formControlName = valueByNames(properties, ['FormControlName', 'formcontrolname']);
  const css = valueByNames(properties, ['CSS', 'CssSelector', 'Selector']);
  const testId = valueByNames(properties, ['TestId', 'data-testid', 'DataTestId']);

  return {
    key,
    app,
    ...(evidence.controlType === undefined ? {} : { controlType: evidence.controlType }),
    ...(evidence.fieldRef === undefined ? {} : { fieldRef: evidence.fieldRef }),
    ...(evidence.id === undefined ? {} : { id: evidence.id }),
    ...(testId === undefined ? {} : { testId }),
    ...(name === undefined ? {} : { name }),
    ...(formControlName === undefined ? {} : { formControlName }),
    ...(label === undefined ? {} : { label }),
    ...(role === undefined ? {} : { role: { role, ...(label ? { name: label } : {}) } }),
    ...(css === undefined ? {} : { css }),
    ...(evidence.customXPath === undefined ? {} : { xpath: evidence.customXPath }),
    ...(evidence.occurrence === undefined ? {} : { occurrence: evidence.occurrence }),
    raw: [evidence],
  };
}
