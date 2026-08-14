@CL_EQ @SFP @basic_new_business_policy @AL @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines ExpertQuote - EQ SFP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the attached Special Farm Package basic new business policy workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines ExpertQuote session
    Given the "CL_EQ" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_EQ" session is available

  Scenario Outline: Create and verify a Special Farm Package basic new business policy for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I start the proposal using the selected product, state, effective date, and producer
    And I complete insured identity validation and handle any prefill result
    And I complete the required policy-level business information
    And I add and complete all required locations, risks, classes, buildings, or scheduled items
    And I select and verify the required policy and risk coverages
    And I verify pricing and complete billing or payment selections
    Then I submit the application and complete the bind, issue, or transmit workflow

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 05_eq_sfp_basic_policy_al | Alabama | AL | Special Farm Package | Basic New Business Policy | Current |
