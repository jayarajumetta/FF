import { LocatorDescriptor, PlanAction, ToscaPlan } from './model';

export type SerializedPlanAction = Omit<PlanAction, 'locator'>;
export type SerializedToscaPlan = Omit<ToscaPlan, 'actions'> & { actions: SerializedPlanAction[] };

export function serializePlan(plan: ToscaPlan): SerializedToscaPlan {
  return {
    ...plan,
    actions: plan.actions.map(({ locator: _locator, ...action }) => action),
  };
}

export function hydratePlan(plan: SerializedToscaPlan, locators: Iterable<LocatorDescriptor>): ToscaPlan {
  const byId = new Map([...locators].map((locator) => [locator.id, locator]));
  return {
    ...plan,
    actions: plan.actions.map((action) => ({
      ...action,
      locator: action.locatorId ? byId.get(action.locatorId) : undefined,
    })),
  };
}

export function locatorRegistryById(locators: Iterable<LocatorDescriptor>): Record<string, LocatorDescriptor> {
  return Object.fromEntries([...locators].map((locator) => [locator.id, locator]));
}
