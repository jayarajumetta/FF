"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.serializePlan = serializePlan;
exports.hydratePlan = hydratePlan;
exports.locatorRegistryById = locatorRegistryById;
function serializePlan(plan) {
    return {
        ...plan,
        actions: plan.actions.map(({ locator: _locator, ...action }) => action),
    };
}
function hydratePlan(plan, locators) {
    const byId = new Map([...locators].map((locator) => [locator.id, locator]));
    return {
        ...plan,
        actions: plan.actions.map((action) => ({
            ...action,
            locator: action.locatorId ? byId.get(action.locatorId) : undefined,
        })),
    };
}
function locatorRegistryById(locators) {
    return Object.fromEntries([...locators].map((locator) => [locator.id, locator]));
}
//# sourceMappingURL=plan-codec.js.map