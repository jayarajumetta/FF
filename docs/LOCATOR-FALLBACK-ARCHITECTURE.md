# Deterministic Tosca Locator Fallback Architecture — v54

## Principle

A readable primary Page locator remains the default. Raw Tosca ModuleAttribute/XParam evidence is compiled into typed per-application fallback views and a machine-readable sidecar catalog. Alternatives are used only after the primary operation fails after the configured readiness wait.

## Runtime chain

`primary → cached successful source candidate → ranked deterministic Tosca candidates → AI healing → failure`

The same failed action is retried; the BDD step/scenario is not restarted.

## Safety

A deterministic candidate must satisfy source confidence, page/control intent, visibility and action compatibility. It must be unique unless Tosca supplied a literal source occurrence/index. The framework does not invent `.First`/`.Nth` to defeat strict mode.

## Source strategies

The v54 raw catalog derives candidates from evidence such as HTML Id, Name, DuckCreekId, data-testid, label/associated label, BusinessType/role, text, stable class/tag combinations, RelativeId where translatable, and exact source XPath as a late deterministic option.

## Layout

Primary:

`tests/<app>/Pages/Locators/*.cs`

Fallback:

`tests/<app>/Pages/FallbackLocators/*.cs`

Raw catalog:

`Artifacts/ToscaLocatorPropertyCatalog.v54.raw.json`

Coverage:

`Artifacts/LocatorFallbackCatalogs/LocatorFallbackCoverage.json`

Current canonical fallback maturity exceeds 95% independently for all three applications and is about 98.75% overall.

## Observability

Every fallback attempt is logged. A recovered operation records page/control intent, strategy/value, source metadata, attempt and success in the execution log and HTML report. A working fallback may be preferred for the remainder of the process, but runtime recovery does not rewrite Page source code.
