@UI,
Feature: SFP Happy Path 

  @ExpertQuote
  Scenario: Create a SFP Quote and Submit for Issuance
    Given I navigate to the Expert Quote login page

    When I enter valid credentials and Click LogIn

    Then user enters a Random Name in the search field and clicks search
    | Question  |  Answer    |
    | FirstName | {{male}}   |
    | LastName  | {{random}} |

    Then user clicks New Quote button
   
    Then user enters client information and clicks search
    | Question     | Answer         |
    | DOB          |  08/08/1944    |
    | BestPhone    | (907) 227-0664 |
    | EmailAddress | fake@email.com |

    
    Then user selects Create New Client and clicks the Next button

    Then user enters account owner information and clicks Next
    | Question           | Answer           |
    | MaritalStatus      | Single           |
    | StreetAddress      | 1206 Conway St   |
    | AptNumber          |                  |
    | City               |   Saint Paul     |
    | State              |   Minnesota      |
    | ZipCode            |     55106        |
    | ReceivedMail       |     Yes          |
    | WhereClientResides |     Yes          |

    Then user selects Special Farm Package and inputs Quote Details
    | Question       | Answer                                      |
	| EffectiveDate  | 2/15/2026                                   |
	| PolicyTerm     | 12 months                                   |
	| AgentCode      | D2102                                       |
	| RatingState    | Minnesota                                   |
	| SSN            |                                             |
	| WritingCompany | American National Property And Casualty Co. |
	| RiskAddress    | 1206 Conway St, Saint Paul, MN 55106        |

    Then user enters SFP policy details and clicks Next button
		| Question            | Answer  |
		| PrimaryFarmType     | Animals |
		| LivestockType       | Beef    |
		| GrossFarmIncome     | 75000   |
		| GrowIndustrialHemp  | No      |


    Then user enters Pre-Qualification information and continues
	    | Question                | Answer            |
        | EligibilityRestrictions | None Of The Above |

    Then user selects Primary Insured and continues

    Then user Validates Primary Insured Information for SFP and continues


