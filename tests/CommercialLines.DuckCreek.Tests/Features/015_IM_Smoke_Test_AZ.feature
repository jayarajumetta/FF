@CL_DC @IM @smoke_test @AZ @automated @canonical @artifact_v38 @smoke
Feature: Commercial Lines Duck Creek - IM Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the attached Inland Marine smoke test workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Commercial Lines Duck Creek session
    Given the "CL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "CL_DC" session is available

  Scenario Outline: Create and verify a Inland Marine smoke test for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I establish the application, policy, rating-state, and effective-date information

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 015_im_smoke_test_az | Arizona | AZ | Inland Marine | Smoke Test | Current |
