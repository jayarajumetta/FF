import { LocatorDescriptor, PlanAction, ToscaPlan } from './model';
export type SerializedPlanAction = Omit<PlanAction, 'locator'>;
export type SerializedToscaPlan = Omit<ToscaPlan, 'actions'> & {
    actions: SerializedPlanAction[];
};
export declare function serializePlan(plan: ToscaPlan): SerializedToscaPlan;
export declare function hydratePlan(plan: SerializedToscaPlan, locators: Iterable<LocatorDescriptor>): ToscaPlan;
export declare function locatorRegistryById(locators: Iterable<LocatorDescriptor>): Record<string, LocatorDescriptor>;
