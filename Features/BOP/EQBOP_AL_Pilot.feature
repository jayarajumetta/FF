@ExpertQuote @BOP @Pilot @EqBopAlPilot @NonRunnable @NoRetry @AutomationId-EQ-BOP-SMOKE
Feature: ExpertQuote BOP Alabama pilot

  Source-traceable adaptation of the approved SGS 03 EQ BOP smoke workflow.
  The pilot remains non-runnable until its QA-owned data and selector evidence
  are approved.

  Scenario Outline: Create, close, and retrieve the Alabama BOP quote
    Given the approved ExpertQuote BOP pilot profile for Alabama
    And I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn
    And I create and search for the ExpertQuote BOP pilot client
    And I apply the approved Alabama account and address values
    And I start the Business Owners proposal with approved selections
    And I capture the quote identity and close the quote
    Then searching by the captured quote returns the exact same identity

    Examples:
      | State |
      | AL    |
