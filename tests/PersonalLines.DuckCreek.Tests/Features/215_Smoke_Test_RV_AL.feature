@PL_DC @RV @smoke_test @AL @automated @canonical @artifact_v38 @smoke
Feature: Personal Lines Duck Creek - Smoke Test RV
  As a Personal Lines Duck Creek policy processing user
  I want to complete the attached Recreational Vehicle smoke test workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Personal Lines Duck Creek session
    Given the "PL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "PL_DC" session is available

  Scenario Outline: Create and verify a Recreational Vehicle smoke test for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I start the proposal using the selected product, state, effective date, and producer
    Then I retrieve and verify the resulting quote, policy, and transaction status

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 215_smoke_test_rv_al | Alabama | AL | Recreational Vehicle | Smoke Test | Current |
