@bop-eq
@generated @eq-bop-smoke-test
Feature: EQ BOP Smoke Test


  Scenario: MO
    Given test data file "TestData/mo-2.json" is loaded
    And I open EQ in the browser
    And I sign in to EQ
    And I start a new quote


    # PreCondition

    # Policy Data Entry
    When I enter client search information
    And I create a new client
    And I enter account information
    And I complete the proposal start
    And I enter the insured social security number
    And I navigate to the prequalification screen
    And I capture the quote identity
    And I close the current quote
    And I search by quote number
    And I return to the prequalification screen
    And I verify the retrieved quote

    # Post Condition
    Then I complete the business postcondition
