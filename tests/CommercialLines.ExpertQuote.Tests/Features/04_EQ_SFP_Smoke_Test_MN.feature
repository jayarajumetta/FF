@CL_EQ @SFP @smoke_test @MN @automated @canonical @artifact_v38 @smoke
Feature: Commercial Lines ExpertQuote - EQ SFP Smoke Test
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the attached Special Farm Package smoke test workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines ExpertQuote session
    Given the "CL_EQ" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_EQ" session is available

  Scenario Outline: Create and verify a Special Farm Package smoke test for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I start the proposal using the selected product, state, effective date, and producer
    And I complete insured identity validation and handle any prefill result
    And I complete the required policy-level business information
    Then I retrieve and verify the resulting quote, policy, and transaction status

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 04_eq_sfp_smoke_test_mn | Minnesota | MN | Special Farm Package | Smoke Test | Current |
