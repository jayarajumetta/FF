@PersonalDuckCreek @PA @AUTO @Pilot @PersonalDuckCreekPilot @PldcAutoStateMaritalPilot @NonRunnable @NoRetry @AutomationId-PLDC-AUTO-STATE-MARITAL
Feature: Personal DuckCreek account state and marital targeting

  Source-traceable microcase derived from the Alabama Policy 1 NB account
  prefix. No audited source row selects Married, so this proof remains
  non-runnable until QA supplies an approved sanitized Married row.

  Scenario Outline: Select Alabama and Married on Account Information
    Given the approved Personal DuckCreek state and marital profile for Alabama
    When I select Alabama and Married on the actual Account Information controls
    Then both exact selections remain applied before account navigation

    Examples:
      | State |
      | AL    |
