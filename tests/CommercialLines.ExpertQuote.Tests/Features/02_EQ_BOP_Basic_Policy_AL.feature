@CL_EQ @BOP @basic_new_business_policy @AL @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines ExpertQuote - EQ BOP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the attached Business Owners basic new business policy workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines ExpertQuote session
    Given the "CL_EQ" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_EQ" session is available

  Scenario Outline: Create and verify a Business Owners basic new business policy for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I start the proposal using the selected product, state, effective date, and producer
    And I complete insured identity validation and handle any prefill result
    And I complete the required policy-level business information
    And I select and verify the required policy and risk coverages
    And I verify pricing and complete billing or payment selections
    And I submit the application and complete the bind, issue, or transmit workflow
    Then I retrieve and verify the resulting quote, policy, and transaction status

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 02_eq_bop_basic_policy_al | Alabama | AL | Business Owners | Basic New Business Policy | Current |
