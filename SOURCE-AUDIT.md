# v58 Source Audit

Generated: 2026-08-26T21:41:02.478343+00:00

## Local source inputs

| Purpose | File | Size | SHA-256 |
|---|---|---:|---|
| v57 baseline | `FF-bop-complete-e2e-v57.zip` | 188.9 KiB | `ce1434f26ebfe1f6febdd3c34dd9acb477418c911337bdb6579b5c0f1e4fa560` |
| CL-DC export | `CL-DC.zip` | 22.8 MiB | `5cc5e272d407c6dc610a9e865e30c9720be11d2cfc9818b8e059122c42d648a7` |
| PL-DC export | `PL_DC.zip` | 67.2 MiB | `25b53ee846099fe8bc186d9151f73f5bad2cddb26c928be65926b58f43b4c658` |
| CL_EQ export | `CL_EQ.zip` | 21.1 MiB | `e11d5389cda086d65394a72b21dd6220984cd4821fc6a48d453117fb876218c8` |

The v57 archive was used as the filesystem baseline. v58 source, tests, reports and scripts were added non-destructively.

## Shared-thread context

The three supplied ChatGPT share URLs were requested during the build. Their public responses did not reliably expose the complete transcript or downloadable attachments in this execution environment. Consequently, no unseen message or attachment was treated as verified evidence. Requirements were taken from the current conversation, the supplied v57 package, and the three attached export archives.

## Export validation

Structural gate: **REVIEW REQUIRED**

| Export | Entities | Test cases | Ordered actions | Controls | Unique locators | FieldRef locators | Audit errors | Audit warnings |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| CL-DC | 189861 | 1950 | 0 | 12823 | 3185 | 0 | 0 | 0 |
| PL-DC | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| CL-EQ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

Critical findings:
- CL-DC: no actions reconstructed
- PL-DC: mapping metrics missing
- CL-EQ: no entities reconstructed

Validation includes archive integrity, nested payload decoding, GUID graph creation, inheritance, testcase/action ordering, locator deduplication, condition/data ordering, generated artifact coverage, TypeScript build, Node syntax checks, automated unit/integration tests and npm package dry-run.

## Boundaries

- No live Duck Creek environment, URL, credentials or authenticated browser session was supplied.
- Structural FieldRef/ID/label/role evidence was cross-checked against Tosca exports; live DOM uniqueness and business completion still require execution in the target environment.
- The direct-DOM fallback is intentionally last. It is logged and never replaces Playwright's normal actionability path by default.
- Unresolved UI evidence is reported and configured to fail explicitly; the converter does not fabricate a broad selector.
