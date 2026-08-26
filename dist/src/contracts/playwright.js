/**
 * Structural Playwright contracts.
 *
 * v57 intentionally does not import @playwright/test in the runtime. Real
 * Playwright Page/Frame/Locator objects satisfy these contracts, while the
 * converter can be compiled and unit-tested without downloading browsers.
 */
export function isFrameLike(value) {
    return Boolean(value &&
        typeof value === 'object' &&
        'locator' in value &&
        typeof value.locator === 'function');
}
//# sourceMappingURL=playwright.js.map