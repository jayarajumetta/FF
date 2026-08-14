@PL_DC @AUTO @new_business_with_prior_effective_date @AL @automated @canonical @artifact_v38 @regression
Feature: Personal Lines Duck Creek - Auto Rate Filings Policy 3 NB Prior Eff Date
  As a Personal Lines Duck Creek policy processing user
  I want to complete the attached Personal Auto new business with prior effective date workflow
  So that the migrated automation preserves business intent, source order, test data, and verification evidence

  Background: Establish a clean and authenticated Personal Lines Duck Creek session
    Given the "PL_DC" application is configured for browser "Microsoft Edge"
    And an authenticated "PL_DC" session is available

  Scenario Outline: Create and verify a Personal Auto new business with prior effective date for <state>
    Given scenario data "<dataSet>" is loaded
    And RANDOM scenario values are generated from the canonical Tosca patterns
    When I create the insured client and establish the account
    And I start the proposal using the selected product, state, effective date, and producer
    And I complete prequalification and resolve eligibility messages
    And I add and validate the required driver information
    And I add and validate the required vehicle or unit information
    And I assign each driver to the applicable vehicle
    And I complete claims, violations, and prior-insurance information
    And I apply and validate the eligible discounts
    And I select and verify the required policy and risk coverages
    And I verify pricing and complete billing or payment selections
    And I submit the application and complete the bind, issue, or transmit workflow
    Then I retrieve and verify the resulting quote, policy, and transaction status

    Examples:
      | dataSet | state | stateCode | product | transaction | effectiveDateMode |
      | 182_auto_rate_filings_policy_3_nb_prior_eff_date_al | Alabama | AL | Personal Auto | New Business with Prior Effective Date | Prior |
