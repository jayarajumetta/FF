@CL_DC @BAP @basic_new_business_policy @AL @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines Duck Creek - BAP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the attached Business Auto basic new business policy workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines Duck Creek session
    Given the "CL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_DC" session is available

  Scenario Outline: Create and verify a Business Auto basic new business policy for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I establish the application, policy, rating-state, and effective-date information
    And I select and verify the required policy and risk coverages
    And I add and complete all required locations, risks, classes, buildings, or scheduled items
    And I add the applicable interests and endorsements
    And I complete underwriting questions and resolve decision checks
    And I calculate and verify the policy premium
    Then I submit the application and complete the bind, issue, or transmit workflow

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 001_bap_basic_policy_al | Alabama | AL | Business Auto | Basic New Business Policy | Current |
