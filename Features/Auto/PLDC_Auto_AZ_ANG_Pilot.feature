@PersonalDuckCreek @PA @AUTO @Pilot @PersonalDuckCreekPilot @PldcAutoAzAngPilot @NonRunnable @NoRetry @AutomationId-PLDC-AUTO-SMOKE
Feature: Personal DuckCreek Auto Arizona ANG pilot

  Source-traceable adaptation of the SGS 211 Personal Auto smoke workflow.
  The pilot remains non-runnable until safe data, deterministic proposal
  outcomes, exact controls, credentials, and quote expectations are approved.

  Scenario Outline: Create, capture, search, and reopen the Arizona ANG quote
    Given the approved Personal DuckCreek Auto smoke profile for Arizona
    When I apply the approved Arizona policy and ANG selections
    And I resolve the approved conditional proposal outcomes
    And I save the Personal Auto quote and capture its identity
    Then searching and reopening the Personal Auto quote returns the same identity

    Examples:
      | State |
      | AZ    |
