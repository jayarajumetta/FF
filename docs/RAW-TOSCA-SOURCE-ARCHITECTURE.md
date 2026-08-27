# v54 Raw Tosca Source Architecture

v54 deliberately removes manual CSV/XLSX/HTML from the automation-generation authority chain.

## Authority chain

1. TestCase Template / TemplateInstance
2. concrete TestCase derived from the TemplateInstance
3. ordered TestCase Items
4. reusable TestStepBlock references expanded recursively
5. XTestStep in Tosca Items order
6. XTestStepValue in source TestStepValues order
7. ModuleAttribute/XParam technical properties and source test data
8. generated Feature / StepDefinition / Page method / Page locator

Names are presentation metadata; Tosca `Surrogate` GUIDs and associations are the identity graph.

## Why this matters

A flattened intermediate representation can reorder reusable block internals or incorrectly promote implementation details to business steps. Two defects caught by the raw graph were:

- ExpertQuote Map/Satellite verification emitted before address input;
- Commercial Duck Creek reusable login internals emitted as repeated Sign In/Sign Out Feature steps.

The v54 raw contract tool prevents those classes of regression by preserving recursive association order and by treating reusable-block internals as implementation details unless the source execution graph invokes a separate business transition.

## Provenance

`Artifacts/RawToscaSourceManifest.json` contains the raw TSU hashes used by the contract snapshot. `Artifacts/V54RawToscaContract.json` records the selected raw TestCase, TemplateInstance, concrete example count and expanded source-step counts for all 32 flows.
