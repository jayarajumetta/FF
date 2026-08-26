import type { LocatorContainer, LocatorLike } from '../contracts/playwright.js';
import type { LocatorCandidate, ScopeEvidence } from './model.js';

function scopedContainer(
  container: LocatorContainer,
  scope: ScopeEvidence | undefined,
): LocatorContainer {
  if (!scope) return container;
  if (scope.css) return container.locator?.(scope.css) ?? container;
  if (scope.xpath) return container.locator?.(`xpath=${scope.xpath}`) ?? container;
  if (scope.text && container.getByText) {
    return container.getByText(scope.text, { exact: true });
  }
  return container;
}

export function createLocator(
  container: LocatorContainer,
  candidate: LocatorCandidate,
): LocatorLike {
  const scope = scopedContainer(container, candidate.scope);

  switch (candidate.kind) {
    case 'role': {
      if (scope.getByRole && candidate.role) {
        const options = candidate.role.name
          ? { name: candidate.role.name, exact: candidate.role.exact ?? true }
          : undefined;
        return scope.getByRole(candidate.role.role, options);
      }
      break;
    }
    case 'label':
      if (scope.getByLabel && candidate.value) {
        return scope.getByLabel(candidate.value, { exact: true });
      }
      break;
    case 'text':
      if (scope.getByText && candidate.value) {
        return scope.getByText(candidate.value, { exact: true });
      }
      break;
    case 'placeholder':
      if (scope.getByPlaceholder && candidate.value) {
        return scope.getByPlaceholder(candidate.value, { exact: true });
      }
      break;
    case 'testId':
      if (scope.getByTestId && candidate.value) {
        return scope.getByTestId(candidate.value);
      }
      break;
    default:
      break;
  }

  if (!candidate.selector) {
    throw new Error(`Candidate ${candidate.kind} has no executable selector.`);
  }
  const selector = candidate.kind === 'xpath' && !candidate.selector.startsWith('xpath=')
    ? `xpath=${candidate.selector}`
    : candidate.selector;
  if (!scope.locator) {
    throw new Error(`Locator container cannot execute selector: ${selector}`);
  }
  return scope.locator(selector);
}
