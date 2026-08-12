@pl-dc
@obsolete @legacy
@generated @smoke-test-sh3-all
Feature: Smoke Test SH3 - ALL - OBSOLETE

  Scenario Outline: Smoke Test SH3 - ALL - <example>
    Given test data file "<dataFile>" is loaded

    # Precondition

    # Process
    When I enter Sign On Credentials
    And I start a new quote in EQ
    And I client Selection-Enter Client Info of New or Existing clients
    And I account Details-Enter new Account Information
    And I complete the proposal start
    And I complete the proposal start for an invalid address, social security number, or existing client
    And I pre-Qualification-Select Client and Property Eligibility Restrictions(Getting LN and Quote#)
    And I named Insureds Summary-Client Suggestions
    And I add or Edit Named Insured-Existing Client
    And I named Insureds Summary-Review details or Add Named Insured
    And I location - save and exit quote at this page
    And I search for the Quote in EQ
    And I side Menu-Navigate to Pre-Qualification page
    And I pre-Qualification-Getting LN and Quote# after Recall

    # Postcondition
    Then I log Out- Exist from the Quote/Policy


    Examples:
      | example | dataFile |
      | Smoke Test SH3 - NM | TestData/smoke-test-sh3-nm.json |
      | Smoke Test SH3 - PA | TestData/smoke-test-sh3-pa.json |
      | Smoke Test SH3 - AZ | TestData/smoke-test-sh3-az.json |
      | Smoke Test SH3 - OH | TestData/smoke-test-sh3-oh.json |
      | Smoke Test SH3 - MD | TestData/smoke-test-sh3-md.json |
