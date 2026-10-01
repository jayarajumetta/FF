# Test Tagging Convention

This document defines the standard tagging structure for all Reqnroll feature files and scenarios
in the PnC Test Automation framework. Tags are used to filter test runs via `.runsettings` or
`dotnet test --filter`.

---

## Tag Structure

A fully-tagged scenario has this shape:

```gherkin
@<RunType> @<LOB> @<App> @<Env?>
Scenario: ...
```

Scenarios inherit feature-level tags. Avoid duplicating feature-level tags on individual scenarios
unless the scenario has a *different* value for that tag.

---

## Tag Definitions

### 1. Run Type (required on every scenario or its parent feature)

| Tag | Meaning |
|-----|---------|
| `@Smoke` | Quick pass/fail verification — single happy path per LOB per state. Target: < 5 min per scenario. Run before every deployment. |
| `@Regression` | Full end-to-end workflow including edge cases and multi-state coverage. Run nightly or before releases. |
| `@Forms` | Forms-only validation scenarios (no UI navigation). Run via `FormsValidationSmoke.feature`. |
| `@API` | API-only scenarios. Triggers headless path in `TestHooks.IsApiScenario()`. |
| `@Manual` | Scenarios not yet automated. Tracked in the repo as documentation; never executed in CI. |
| `@Ignore` | Temporarily disabled. Must include a comment with the reason and a tracking ticket reference. |

### 2. Line of Business (required on every scenario or its parent feature)

| Tag | Meaning |
|-----|---------|
| `@SFP` | Special Farm Package |
| `@BOP` | Business Owners Policy |
| `@PA` | Personal Auto |
| `@CE` | Country Estate (subset of SFP) |

### 3. Application (required on every scenario or its parent feature)

| Tag | Meaning |
|-----|---------|
| `@ExpertQuote` | Runs against the ExpertQuote web application |
| `@ExpertService` | Runs against ExpertService |
| `@Express` | Runs against the Express (CLAS) application |

### 4. Environment Restriction (optional — omit for tests that run in all environments)

| Tag | Meaning |
|-----|---------|
| `@DevOnly` | Runs only against the Dev environment |
| `@QAOnly` | Runs only against the QA environment |

`TestHooks` enforces these tags for direct/local runs. QA shard pipelines also
exclude `TestCategory=DevOnly` at discovery so DEV-only examples cannot enter
ordinary QA runs.

---

## Feature File Layout

Apply LOB and App tags at the **feature level** so they don't need to be repeated per scenario:

```gherkin
@SFP @ExpertQuote
Feature: SFP Basic Policy

  @Smoke
  Scenario Outline: SFP Smoke - <State>
    ...

  @Regression
  Scenario Outline: SFP Full Workflow - <State>
    ...
```

---

## Filter Examples (for `.runsettings` or CLI)

```
# Run Smoke tests only
dotnet test --filter "TestCategory=Smoke"

# Run SFP Regression tests
dotnet test --filter "TestCategory=SFP&TestCategory=Regression"

# Run everything except Ignore and Manual
dotnet test --filter "TestCategory!=Ignore&TestCategory!=Manual"

# Run ExpertQuote Smoke in CI
dotnet test --filter "TestCategory=ExpertQuote&TestCategory=Smoke"
```

---

## Rules

1. **Every runnable scenario must have exactly one Run Type tag** (`@Smoke`, `@Regression`, `@Forms`, or `@API`).
2. **Every runnable scenario must have a LOB tag and an App tag** (can be at feature level).
3. **`@Ignore` requires a comment** on the line immediately above the tag explaining why and referencing a ticket:
   ```gherkin
   # TODO: Nebraska wind/hail deductible lookup broken — tracked in AB#4521
   @Ignore @SFP @Smoke @ExpertQuote
   Scenario Outline: SFP Smoke - Nebraska
   ```
4. **`@Manual` scenarios stay in the repo** as living documentation but are never executed. They document what still needs to be automated.
5. **Do not add environment tags** (`@DevOnly`, `@QAOnly`) unless the scenario is genuinely environment-specific. The Dev state filter in `TestHooks` handles most environment routing programmatically.
6. **No trailing commas** — `@UI,` is not valid Gherkin. Use `@UI` only.

---

## Migration: Current Tags → Convention

| Current Tag | Action |
|-------------|--------|
| `@UI` | **Remove** — replaced by `@ExpertQuote` / `@ExpertService` / `@Express` |
| `@ExpertQuote` | **Keep** — already correct application tag |
| `@Smoke` | **Keep** — already correct run type |
| `@Regression` | **Keep** — already correct run type |
| `@API` | **Keep** — already correct run type |
| (missing LOB tag) | **Add** `@SFP`, `@BOP`, or `@PA` as appropriate |
| (missing Run Type) | **Add** `@Smoke` or `@Regression` as appropriate |
