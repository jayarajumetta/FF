@UI
Feature: EQ SFP Smoke

  @ExpertQuote @Smoke
  Scenario Outline: SFP Smoke Test - <State>
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn

    Then user enters a Random Name in the search field and clicks search
      | Question  | Answer     |
      | FirstName | {{male}}   |
      | LastName  | {{random}} |

    Then user clicks New Quote button

    Then user enters client information and clicks search
      | Question     | Answer         |
      | DOB          | 08/08/1944     |
      | BestPhone    | (907) 227-0664 |
      | EmailAddress | fake@email.com |

    Then user selects Create New Client and clicks the Next button

    Then user enters account owner information and clicks Next
      | Question           | Answer           |
      | MaritalStatus      | Single           |
      | StreetAddress      | <Address>        |
      | AptNumber          | <AddressLine2>   |
      | City               | <City>           |
      | State              | <StateFull>      |
      | ZipCode            | <Zip>            |
      | ReceivedMail       | Yes              |
      | WhereClientResides | Yes              |

    Then user selects Special Farm Package and inputs Quote Details
      | Question       | Answer                                      |
      | PolicyTerm     | 12 months                                   |
      | AgentCode      | D2102                                       |
      | RatingState    | <StateFull>                                 |
      | SSN            |                                             |
      | WritingCompany | American National Property And Casualty Co. |
      | RiskAddress    | <Address>, <City>, <StateAbbv> <Zip>        |

    Then user enters SFP policy details and clicks Next button
      | Question           | Answer  |
      | PrimaryFarmType    | Animals |
      | LivestockType      | Beef    |
      | GrossFarmIncome    | 75000   |
      | GrowIndustrialHemp | No      |

    Examples:
      | State        | StateAbbv | StateFull    | Address          | AddressLine2 | City        | Zip   |
      | Minnesota    | MN        | Minnesota    | 115 S Main ST    | 111          | Warren      | 56762 |
      | Nebraska     | NE        | Nebraska     | 1517 Broadway    | 111          | Scottsbluff | 69361 |
      | South Dakota | SD        | South Dakota | 700 Governors Dr | 111          | Pierre      | 57501 |
      | Wisconsin    | WI        | Wisconsin    | 3601 Memorial Dr | 111          | Madison     | 53704 |
