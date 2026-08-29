# README_V60

V60 keeps the V59 Duck Creek fieldref DOM contract and consolidates CLDC smoke test data.

The previous runtime model had 186 full JSON files for seven smoke flows. The raw values show that CP, IM and CPP are identical across their entire state matrices apart from state identity; BAP, GL, WC and UMB each have only two non-state value profiles. V60 therefore uses one base file per LOB under `tests/CommercialLines.DuckCreek.Tests/TestData/Smoke`, one central `StateOverrides.json`, and the Scenario Outline for state identity.

Runtime smoke files: `BAP.json`, `CP.json`, `GL.json`, `IM.json`, `WC.json`, `CPP.json`, `UMB.json`, and `StateOverrides.json`. The existing `ExternalDataOverrides.json` remains shared. Full source lineage, original file hashes, and exact base/override equivalence results are recorded in `Artifacts/V60SmokeDataConsolidation.json`.

`ScenarioData.LoadSmoke` loads the LOB base, applies the Scenario Outline state aliases, then applies only the rare state-specific value differences. No state-specific full smoke JSON is required. Basic and expanded scenario data are unchanged.
