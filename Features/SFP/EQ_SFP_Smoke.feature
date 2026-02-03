@UI
Feature: EQ SFP Smoke

  @ExpertQuote @Smoke
  Scenario Outline: SFP Smoke Test - <State>
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn

    And user enters a Random Name in the search field and clicks search
      | Question  | Answer         |
      | FirstName | {{firstName}}  |
      | LastName  | {{lastName}}   |

    And user clicks New Quote button

    And user enters client information and clicks search
      | Question     | Answer          |
      | DOB          | {{randomDOB}}   |
      | BestPhone    | {{randomPhone}} |
      | EmailAddress | {{randomEmail}} |

    And user selects Create New Client and clicks the Next button

    And user enters account owner information and clicks Next
      | Question           | Answer           |
      | MaritalStatus      | Single           |
      | StreetAddress      | <Address>        |
      | AptNumber          | <AddressLine2>   |
      | City               | <City>           |
      | State              | <StateFull>      |
      | ZipCode            | <Zip>            |
      | ReceivedMail       | Yes              |
      | WhereClientResides | Yes              |

    And user selects Special Farm Package and inputs Quote Details
      | Question       | Answer                                      |
      | PolicyTerm     | 12 months                                   |
      | AgentCode      | D2102                                       |
      | RatingState    | <StateFull>                                 |
      | SSN            |                                             |
      | WritingCompany | American National Property And Casualty Co. |
      | RiskAddress    | <Address>, <City>, <StateAbbv> <Zip>        |

    And user enters SFP policy details and clicks Next button
      | Question           | Answer  |
      | PrimaryFarmType    | Animals |
      | LivestockType      | Beef    |
      | GrossFarmIncome    | 75000   |
      | GrowIndustrialHemp | No      |

    And user captures the quote number
    And user closes the browser
    And user launches a new browser and logs in to Expert Quote
    Then user verifies the quote exists in search results

    Examples:
      | State        | StateAbbv | StateFull    | Address          | AddressLine2 | City        | Zip   |
      | Minnesota    | MN        | Minnesota    | 115 S Main ST    | 111          | Warren      | 56762 |
      #| Nebraska     | NE        | Nebraska     | 1517 Broadway    | 111          | Scottsbluff | 69361 |
      #| South Dakota | SD        | South Dakota | 700 Governors Dr | 111          | Pierre      | 57501 |
      #| Wisconsin    | WI        | Wisconsin    | 3601 Memorial Dr | 111          | Madison     | 53704 |
