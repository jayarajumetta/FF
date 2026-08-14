@CL_DC @UMB @basic_new_business_policy @AL @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines Duck Creek - UMB Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the attached Commercial Umbrella basic new business policy workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines Duck Creek session
    Given the "CL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_DC" session is available

  Scenario Outline: Create and verify a Commercial Umbrella basic new business policy for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    Then I establish the application, policy, rating-state, and effective-date information

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 008_umb_basic_policy_al | Alabama | AL | Commercial Umbrella | Basic New Business Policy | Current |
