import type { PageLike } from '../contracts/playwright.js';
import type { LocatorSpec } from '../locator/model.js';
import {
  ResilientActions,
  type ResilientActionOptions,
} from '../runtime/resilient-actions.js';

export type V56LocatorInput = string | LocatorSpec | {
  key?: string;
  selector?: string;
  css?: string;
  xpath?: string;
  id?: string;
  fieldRef?: string;
  name?: string;
  label?: string;
  text?: string;
  role?: string;
  controlType?: string;
  occurrence?: number;
};

export function toV57Locator(
  input: V56LocatorInput,
  key = 'legacyLocator',
  app = 'UNKNOWN',
): LocatorSpec {
  if (typeof input === 'string') {
    const selector = input.trim();
    if (selector.startsWith('xpath=') || selector.startsWith('//') || selector.startsWith('(//')) {
      return { key, app, xpath: selector.replace(/^xpath=/, '') };
    }
    return { key, app, css: selector };
  }

  const raw = input as Record<string, unknown>;
  const roleValue = raw.role;
  const roleName = typeof roleValue === 'string' ? roleValue : undefined;
  const roleObject = roleValue && typeof roleValue === 'object'
    ? roleValue as LocatorSpec['role']
    : undefined;
  const selector = typeof raw.selector === 'string' ? raw.selector : undefined;
  const css = typeof raw.css === 'string' ? raw.css : selector;
  const xpath = typeof raw.xpath === 'string' ? raw.xpath.replace(/^xpath=/, '') : undefined;
  const targetKey = typeof raw.key === 'string' ? raw.key : key;
  const text = typeof raw.text === 'string' ? raw.text : undefined;

  return {
    key: targetKey,
    app: typeof raw.app === 'string' ? raw.app : app,
    ...(typeof raw.controlType === 'string' ? { controlType: raw.controlType } : {}),
    ...(typeof raw.fieldRef === 'string' || Array.isArray(raw.fieldRef)
      ? { fieldRef: raw.fieldRef as string | readonly string[] }
      : {}),
    ...(typeof raw.id === 'string' ? { id: raw.id } : {}),
    ...(typeof raw.testId === 'string' ? { testId: raw.testId } : {}),
    ...(typeof raw.name === 'string' ? { name: raw.name } : {}),
    ...(typeof raw.formControlName === 'string' ? { formControlName: raw.formControlName } : {}),
    ...(typeof raw.label === 'string' ? { label: raw.label } : {}),
    ...(text === undefined ? {} : { text }),
    ...(roleObject
      ? { role: roleObject }
      : roleName
        ? { role: { role: roleName, ...(text ? { name: text } : {}) } }
        : {}),
    ...(css === undefined ? {} : { css }),
    ...(xpath === undefined ? {} : { xpath }),
    ...(typeof raw.occurrence === 'number' ? { occurrence: raw.occurrence } : {}),
    ...(raw.frame && typeof raw.frame === 'object' ? { frame: raw.frame as NonNullable<LocatorSpec['frame']> } : {}),
    ...(raw.scope && typeof raw.scope === 'object' ? { scope: raw.scope as NonNullable<LocatorSpec['scope']> } : {}),
    ...(Array.isArray(raw.raw) ? { raw: raw.raw as NonNullable<LocatorSpec['raw']> } : {}),
  };
}

export function createV57CompatibilityLayer(
  page: PageLike,
  options: ResilientActionOptions = {},
) {
  const ui = new ResilientActions(page, options);
  return {
    ui,
    safeClick: (target: V56LocatorInput, key?: string, app?: string) =>
      ui.click(toV57Locator(target, key, app)),
    safeFill: (target: V56LocatorInput, value: unknown, key?: string, app?: string) =>
      ui.fill(toV57Locator(target, key, app), value),
    chooseDropdownOption: (target: V56LocatorInput, value: unknown, key?: string, app?: string) =>
      ui.select(toV57Locator(target, key, app), value),
    safePress: (target: V56LocatorInput, keyName: string, key?: string, app?: string) =>
      ui.press(toV57Locator(target, key, app), keyName),
  };
}

export function cldcLoginLocator(input: {
  id?: string;
  fieldRef?: string;
  accessibleName?: string;
}): LocatorSpec {
  return {
    key: 'cldcLogin',
    app: 'CLDC',
    controlType: 'Link',
    ...(input.fieldRef === undefined ? {} : { fieldRef: input.fieldRef }),
    ...(input.id === undefined ? {} : { id: input.id }),
    ...(input.accessibleName === undefined
      ? { roleAlternates: [{ role: 'link' }, { role: 'button' }] }
      : {
          text: input.accessibleName,
          role: { role: 'link', name: input.accessibleName, exact: true },
          roleAlternates: [{ role: 'button', name: input.accessibleName, exact: true }],
        }),
  };
}

export function pldcFieldLocator(
  key: string,
  fieldRef: string | undefined,
  fallback: Omit<LocatorSpec, 'key' | 'app' | 'fieldRef'> = {},
): LocatorSpec {
  return {
    key,
    app: 'PLDC',
    ...(fieldRef === undefined ? {} : { fieldRef }),
    ...fallback,
  };
}
