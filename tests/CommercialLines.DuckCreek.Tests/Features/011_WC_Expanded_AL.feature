@CL_DC @WC @expanded_new_business @AL @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines Duck Creek - WC Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the attached Workers Compensation expanded new business workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines Duck Creek session
    Given the "CL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_DC" session is available

  Scenario Outline: Create and verify a Workers Compensation expanded new business for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    Then I establish the application, policy, rating-state, and effective-date information

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 011_wc_expanded_al | Alabama | AL | Workers Compensation | Expanded New Business | Current |
