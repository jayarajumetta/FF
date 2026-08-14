@CL_DC @GL @owners_and_contractors_protective_new_business @AZ @automated @canonical @artifact_v38 @regression
Feature: Commercial Lines Duck Creek - GL OCP Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the attached General Liability owners and contractors protective new business workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines Duck Creek session
    Given the "CL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_DC" session is available

  Scenario Outline: Create and verify a General Liability owners and contractors protective new business for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    Then I establish the application, policy, rating-state, and effective-date information

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 006_gl_ocp_policy_az | Arizona | AZ | General Liability | Owners and Contractors Protective New Business | Current |
