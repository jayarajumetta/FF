@UI
Feature: EQ SFP Smoke

  @ExpertQuote
  Scenario: Converted EQ SFP Smoke Test from Tosca
    Given I navigate to the Expert Quote login page

    When I enter valid credentials and Click LogIn

    Then user enters a Random Name in the search field and clicks search
    | Question  | Answer     |
    | FirstName | {{male}}   |
    | LastName  | {{random}} |

    Then user clicks New Quote button
   
    Then user enters client information and clicks search
    | Question     | Answer         |
    | DOB          |  08/08/1944    |
    | BestPhone    | (907) 227-0664 |
    | EmailAddress | fake@email.com |



