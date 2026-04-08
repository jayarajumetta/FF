---
name: add-feature-scenario
description: Write a new Reqnroll Gherkin feature file or scenario for this framework, using correct syntax, table formatting, token generators, and product tags.
---

# Add Feature Scenario

When asked to write a new feature file or scenario, follow these rules exactly.

## File Location
- SFP: `Features/SFP/`
- PA: `Features/PA/`
- BOP: `Features/BOP/`

## Feature File Template

```gherkin
Feature: {Feature Name}

Background:
    Given I am logged into the application

@{Product} @{ScenarioType}
Scenario: {Scenario Name}
    Given I navigate to the {product} quote page
    When I fill in the client details
        | Field       | Value             |
        | First Name  | {{firstName}}     |
        | Last Name   | {{lastName}}      |
        | Phone       | {{randomPhone}}   |
        | Email       | {{randomEmail}}   |
    And I fill in the address details
        | Field   | Value         |
        | Street  | 123 Main St   |
        | City    | Houston       |
        | State   | TX            |
        | Zip     | 77001         |
    Then the quote should be created successfully
```

## Rules
- Feature file name matches the Feature name in kebab-case: `PersonalAutoHappyPath.feature`
- NEVER edit the auto-generated `.feature.cs` file — it is regenerated automatically
- Use `Background:` for steps shared by all scenarios in the feature
- Tag every scenario with the product tag: `@SFP`, `@PA`, `@BOP`
- Tag API-only scenarios with `@API` — this skips browser launch
- Data tables always use `| Field | Value |` two-column format
- Use token generators in Value column for PII data (never hardcode real names/SSNs/emails)
- Keep scenario names in plain business language — no technical terms

## Available Token Generators
| Token | Generates |
|-------|-----------|
| `{{firstName}}` | Random first name |
| `{{lastName}}` | Random last name |
| `{{randomPhone}}` | Random US phone number |
| `{{randomEmail}}` | Random email address |
| `{{randomDOB}}` | Random date of birth |
| `{{randomSSN}}` | Random SSN |

## Common Step Patterns Already Available (SharedSteps)
- `Given I am logged into the application`
- `Given I navigate to the {product} quote page`
- `When I fill in the client details` (with table)
- `When I fill in the address details` (with table)
- `Then the quote should be created successfully`
- `Then the quote number should be captured`
