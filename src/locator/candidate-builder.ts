import {
  DEFAULT_FIELD_REF_ATTRIBUTES,
  type CandidateBuildOptions,
  type LocatorCandidate,
  type LocatorSpec,
  type RoleEvidence,
  type ScopeEvidence,
} from './model.js';
import { exactAttributeSelector } from './escape.js';

const DEFAULT_OPTIONS: Required<CandidateBuildOptions> = {
  fieldRefAttributes: DEFAULT_FIELD_REF_ATTRIBUTES,
  testIdAttribute: 'data-testid',
  includeTextFallback: true,
  includeXPathFallback: true,
};

function uniqueNonEmpty(values: readonly (string | undefined)[]): string[] {
  const output: string[] = [];
  const seen = new Set<string>();
  for (const value of values) {
    const normalized = value?.trim();
    if (!normalized || seen.has(normalized)) continue;
    seen.add(normalized);
    output.push(normalized);
  }
  return output;
}

function effectiveOccurrence(spec: LocatorSpec): number | undefined {
  if (Number.isInteger(spec.occurrence) && (spec.occurrence ?? 0) > 0) {
    return spec.occurrence;
  }
  const rawOccurrence = spec.raw
    ?.map((item) => item.occurrence)
    .find((value): value is number => Number.isInteger(value) && (value ?? 0) > 0);
  return rawOccurrence;
}

function withCommon(
  candidate: Omit<LocatorCandidate, 'occurrence' | 'scope'>,
  occurrence: number | undefined,
  scope: ScopeEvidence | undefined,
): LocatorCandidate {
  return {
    ...candidate,
    ...(occurrence === undefined ? {} : { occurrence }),
    ...(scope === undefined ? {} : { scope }),
    dom: {
      ...candidate.dom,
      ...(occurrence === undefined ? {} : { occurrence }),
      ...(scope?.css ? { scopeSelector: scope.css } : {}),
      ...(scope?.xpath ? { scopeXPath: scope.xpath } : {}),
    },
  };
}

function roleKey(role: RoleEvidence): string {
  return `${role.role.toLowerCase()}|${role.name ?? ''}|${role.exact === false ? '0' : '1'}`;
}

function addRole(
  roles: RoleEvidence[],
  seen: Set<string>,
  role: RoleEvidence | undefined,
): void {
  if (!role?.role.trim()) return;
  const normalized: RoleEvidence = {
    role: role.role.trim().toLowerCase(),
    ...(role.name?.trim() ? { name: role.name.trim() } : {}),
    ...(role.exact === undefined ? { exact: true } : { exact: role.exact }),
  };
  const key = roleKey(normalized);
  if (seen.has(key)) return;
  seen.add(key);
  roles.push(normalized);
}

function collectRoles(spec: LocatorSpec): RoleEvidence[] {
  const roles: RoleEvidence[] = [];
  const seen = new Set<string>();
  addRole(roles, seen, spec.role);
  for (const role of spec.roleAlternates ?? []) addRole(roles, seen, role);

  const controlType = `${spec.controlType ?? ''} ${spec.raw?.map((item) => item.controlType ?? '').join(' ') ?? ''}`
    .toLowerCase();
  const accessibleName = spec.role?.name ?? spec.label ?? spec.text ?? spec.aliases?.[0];

  // Tosca frequently models a clickable login control as Link even when the
  // rendered element is a <button>, and the reverse also occurs in CLDC.
  if (controlType.includes('link') || controlType.includes('button')) {
    addRole(roles, seen, {
      role: 'link',
      ...(accessibleName ? { name: accessibleName } : {}),
      exact: true,
    });
    addRole(roles, seen, {
      role: 'button',
      ...(accessibleName ? { name: accessibleName } : {}),
      exact: true,
    });
  }

  return roles;
}

function candidateIdentity(candidate: LocatorCandidate): string {
  return JSON.stringify({
    kind: candidate.kind,
    selector: candidate.selector,
    value: candidate.value,
    role: candidate.role,
    scope: candidate.scope,
    occurrence: candidate.occurrence,
  });
}

export function buildLocatorCandidates(
  spec: LocatorSpec,
  options: CandidateBuildOptions = {},
): LocatorCandidate[] {
  const config: Required<CandidateBuildOptions> = {
    fieldRefAttributes: options.fieldRefAttributes ?? DEFAULT_OPTIONS.fieldRefAttributes,
    testIdAttribute: options.testIdAttribute ?? DEFAULT_OPTIONS.testIdAttribute,
    includeTextFallback: options.includeTextFallback ?? DEFAULT_OPTIONS.includeTextFallback,
    includeXPathFallback: options.includeXPathFallback ?? DEFAULT_OPTIONS.includeXPathFallback,
  };

  const candidates: LocatorCandidate[] = [];
  const occurrence = effectiveOccurrence(spec);
  const app = (spec.app ?? 'UNKNOWN').toUpperCase();
  const fieldRefScore = app === 'PLDC' || app === 'CLDC' ? 1_200 : 1_040;

  const explicitFieldRefs = Array.isArray(spec.fieldRef)
    ? [...spec.fieldRef]
    : [spec.fieldRef];
  const fieldRefs = uniqueNonEmpty([
    ...explicitFieldRefs,
    ...(spec.raw?.map((item) => item.fieldRef) ?? []),
  ]);

  for (const fieldRef of fieldRefs) {
    for (let index = 0; index < config.fieldRefAttributes.length; index += 1) {
      const attribute = config.fieldRefAttributes[index];
      if (!attribute) continue;
      const selector = exactAttributeSelector(attribute, fieldRef);
      candidates.push(
        withCommon(
          {
            kind: 'fieldRef',
            score: fieldRefScore - index,
            source: `FieldRef:${attribute}`,
            selector,
            value: fieldRef,
            dom: { kind: 'fieldRef', selector, value: fieldRef, exact: true },
          },
          occurrence,
          spec.scope,
        ),
      );
    }
  }

  if (spec.testId?.trim()) {
    const value = spec.testId.trim();
    const selector = exactAttributeSelector(config.testIdAttribute, value);
    candidates.push(
      withCommon(
        {
          kind: 'testId',
          score: 1_100,
          source: 'explicit test id',
          selector,
          value,
          dom: { kind: 'testId', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  const ids = uniqueNonEmpty([
    spec.id,
    ...(spec.raw?.map((item) => item.id) ?? []),
  ]);
  for (let index = 0; index < ids.length; index += 1) {
    const value = ids[index];
    if (!value) continue;
    // Attribute form is deliberate: IDs containing '.', ':', '[', etc. stay
    // valid CSS without relying on error-prone CSS identifier escaping.
    const selector = exactAttributeSelector('id', value);
    candidates.push(
      withCommon(
        {
          kind: 'id',
          score: 1_080 - index,
          source: index === 0 ? 'explicit id' : 'raw Tosca id',
          selector,
          value,
          dom: { kind: 'id', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  for (const role of collectRoles(spec)) {
    candidates.push(
      withCommon(
        {
          kind: 'role',
          score: role.role === spec.role?.role?.toLowerCase() ? 1_020 : 1_005,
          source: `ARIA role:${role.role}`,
          role,
          ...(role.name ? { value: role.name } : {}),
          dom: {
            kind: 'role',
            role: role.role,
            ...(role.name ? { accessibleName: role.name } : {}),
            exact: role.exact ?? true,
          },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.label?.trim()) {
    const value = spec.label.trim();
    candidates.push(
      withCommon(
        {
          kind: 'label',
          score: 1_000,
          source: 'associated label/aria-label',
          value,
          dom: { kind: 'label', value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.placeholder?.trim()) {
    const value = spec.placeholder.trim();
    const selector = exactAttributeSelector('placeholder', value);
    candidates.push(
      withCommon(
        {
          kind: 'placeholder',
          score: 970,
          source: 'placeholder',
          selector,
          value,
          dom: { kind: 'placeholder', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.name?.trim()) {
    const value = spec.name.trim();
    const selector = exactAttributeSelector('name', value);
    candidates.push(
      withCommon(
        {
          kind: 'name',
          score: 960,
          source: 'name attribute',
          selector,
          value,
          dom: { kind: 'name', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.formControlName?.trim()) {
    const value = spec.formControlName.trim();
    const selector = exactAttributeSelector('formcontrolname', value);
    candidates.push(
      withCommon(
        {
          kind: 'formControlName',
          score: 950,
          source: 'Angular formcontrolname',
          selector,
          value,
          dom: { kind: 'formControlName', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.title?.trim()) {
    const value = spec.title.trim();
    const selector = exactAttributeSelector('title', value);
    candidates.push(
      withCommon(
        {
          kind: 'title',
          score: 930,
          source: 'title attribute',
          selector,
          value,
          dom: { kind: 'title', selector, value, exact: true },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  if (spec.css?.trim()) {
    const selector = spec.css.trim();
    candidates.push(
      withCommon(
        {
          kind: 'css',
          score: 700,
          source: 'explicit CSS fallback',
          selector,
          dom: { kind: 'css', selector },
        },
        occurrence,
        spec.scope,
      ),
    );
  }

  const textValues = uniqueNonEmpty([spec.text, ...(spec.aliases ?? [])]);
  if (config.includeTextFallback) {
    for (let index = 0; index < textValues.length; index += 1) {
      const value = textValues[index];
      if (!value) continue;
      candidates.push(
        withCommon(
          {
            kind: 'text',
            score: 620 - index,
            source: index === 0 ? 'visible text fallback' : 'visible text alias',
            value,
            dom: { kind: 'text', value, exact: true },
          },
          occurrence,
          spec.scope,
        ),
      );
    }
  }

  const xpaths = uniqueNonEmpty([
    spec.xpath,
    ...(spec.raw?.map((item) => item.customXPath) ?? []),
  ]);
  if (config.includeXPathFallback) {
    for (let index = 0; index < xpaths.length; index += 1) {
      const selector = xpaths[index];
      if (!selector) continue;
      candidates.push(
        withCommon(
          {
            kind: 'xpath',
            score: 420 - index,
            source: index === 0 ? 'explicit XPath fallback' : 'raw Tosca XPath',
            selector,
            dom: { kind: 'xpath', selector },
          },
          occurrence,
          spec.scope,
        ),
      );
    }
  }

  const deduped = new Map<string, LocatorCandidate>();
  for (const candidate of candidates.sort((left, right) => right.score - left.score)) {
    const identity = candidateIdentity(candidate);
    if (!deduped.has(identity)) deduped.set(identity, candidate);
  }
  return [...deduped.values()];
}
