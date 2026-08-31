@CL_EQ @SFP @smoke_test

Feature: EQ SFP Smoke Test
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ SFP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ SFP Smoke Test - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete quote Identifying and Close Quote
    And I search by QuoteNum
    And I navigate to the required policy screen for screen
    Then I complete verifying Quote

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/04_eq_sfp_smoke_test_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/04_eq_sfp_smoke_test_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/04_eq_sfp_smoke_test_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/04_eq_sfp_smoke_test_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
