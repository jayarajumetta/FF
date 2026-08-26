# Integrating v57 with v56

## Recommended path

1. Unpack v56 into a clean working directory.
2. Commit or copy that directory before migration.
3. Run `node scripts/apply-v57-to-v56.mjs <v56-root>`.
4. Review `V57-MIGRATION-REPORT.json`.
5. Run `npm install`, then `npm run v57:verify-runtime`.
6. Import `createUi` from `src/v57-bridge.ts` in one generated suite first.
7. Convert legacy helper calls incrementally.

## Legacy bridge

```ts
import { createUi } from './v57-bridge.js';

const { safeClick, safeFill, chooseDropdownOption } = createUi(page);
await safeFill('#accountNumber', accountNumber, 'accountNumber', 'BOP');
await chooseDropdownOption({ id: 'cmbState', occurrence: 2 }, state, 'siteState', 'PLDC');
await safeClick({ id: 'cl.dc.login.submit', role: 'link', text: 'Login' }, 'cldcLogin', 'CLDC');
```

String locators remain accepted during transition, but supplying FieldRef/ID/role/occurrence evidence unlocks the v57 recovery logic.

## Do not bulk-delete repeated actions

Two adjacent clicks can be necessary when the first opens a menu and the second selects or confirms. v57 removes a duplicate click only when source IDs match or generated-safe metadata is present. The migration installer reports suspected patterns rather than rewriting them.
