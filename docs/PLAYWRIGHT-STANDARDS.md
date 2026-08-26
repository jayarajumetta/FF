# Playwright standards used by v57

- Locators remain the primary abstraction because they re-resolve the DOM and participate in auto-waiting.
- Role, label, and explicit test contracts are favored over long DOM-structure selectors.
- Strictness is preserved. `.first()`/`.nth()` is not used to hide ambiguity without raw occurrence evidence.
- Click, fill, check, and select actions run through normal Playwright actionability first.
- Frame and FrameLocator concepts are respected; page-level selectors are not assumed to see iframe content.
- Native `<select>` controls use `selectOption`.
- Direct DOM actions are last-resort fallbacks and are exposed in diagnostics.
- Fixed `waitForTimeout` sleeps are absent from the v57 runtime.
