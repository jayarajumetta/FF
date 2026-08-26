# v57 to v58 Migration

1. Back up or commit the v57 checkout.
2. Run `node scripts/apply-v58-to-v57.mjs <v57-root>`.
3. Run `npm install` using the existing lock policy.
4. Run `npm run v58:verify`.
5. Convert one export into a new output directory and review `reports/v58-mapping-audit.json` before replacing business tests.
6. Execute against the Duck Creek QA environment with tracing enabled. Resolve any `UNRESOLVED_LOCATOR_EVIDENCE` finding by adding raw module evidence or a reviewed locator override; do not replace it with a broad text selector.

The overlay does not rewrite existing v57 business features, page objects or test data. `package.json.v57-backup` and `V58-MIGRATION-REPORT.json` support rollback and audit.
