# Test-data layering

The original Tosca-derived `TestData/Scenarios/*.json` files are retained. For maintainability, every application also has a generated layered representation:

```text
TestData/Layered/manifest.json
TestData/Layered/<feature>/Base.json
TestData/Layered/<feature>/StateOverrides.json
```

`Base.json` contains common flow data. `StateOverrides.json` contains an RFC 7396 JSON Merge Patch keyed by the original scenario filename. `manifest.json` maps the requested source scenario to its base, override file, override key and source SHA-256.

At runtime, `ScenarioData.Load` reconstructs the requested record from these files. It falls back to the original scenario file only when no layered mapping is available. A malformed mapped record fails explicitly rather than silently using different data.

The package gate reconstructs every scenario and requires exact semantic equality with the original JSON. Current package totals are recorded in `Artifacts/Validation/package-gate-result.json`.
