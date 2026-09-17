@CommercialDuckCreek @BAP @Pilot @CommercialDuckCreekPilot @CldcBapAlPilot @NonRunnable @NoRetry @AutomationId-CLDC-BAP-SMOKE
Feature: Commercial DuckCreek BAP Alabama pilot

  Source-traceable adaptation of the approved SGS 012 BAP smoke workflow.
  The pilot remains non-runnable until QA-owned data, test IDs, frame paths,
  credentials, and quote round-trip expectations are approved.

  Scenario Outline: Create, save, and reopen the Alabama BAP quote
    Given the approved Commercial DuckCreek BAP pilot profile for Alabama
    When I start the BAP quote and apply the approved Alabama selections
    And I verify the returned insured identity is masked
    And I capture a valid quote description and insurance score reference
    And I save the quote and capture its authoritative identity
    Then searching and reopening the quote preserves its identity and description

    Examples:
      | State |
      | AL    |
