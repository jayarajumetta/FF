# Runtime: Background opens one browser session; Feature data flows through StepDefinitions to PageMethods
# Locator self-heal: enabled by default on locator/actionability failures


@CL_EQ @BOP @smoke_test @automated @canonical_simple_v44 @state_data_driven
# Automation Maturity: 95/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 16/20 | Test Data: 10/10
# Page Objects Used: 6 | Locator Confidence Average: 80/100 | Review-required operations: 0
# Locator Review Items: 8 source-derived locator(s) remain below high confidence.

Feature: EQ BOP Smoke Test
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ BOP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ BOP Smoke Test - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I create a new client and begin the quote
    And I enter the client account and address information
    And I start the configured policy proposal
    And I enter the insured social security number and handle any prefill result
    And I navigate to the required policy screen
    And I capture the quote identity and close the current quote
    And I retrieve the quote and verify its identity

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/03_eq_bop_smoke_test_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
