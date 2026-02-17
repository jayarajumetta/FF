@UI,
Feature: SFP Happy Path 

  @ExpertQuote
  Scenario: Create a SFP Quote and Submit for Issuance
    Given I navigate to the Expert Quote login page

    When I enter valid credentials and Click LogIn

    And user enters a Random Name in the search field and clicks search
    | Question  |  Answer        |
    | FirstName | {{firstName}}  |
    | LastName  | {{lastName}}   |

    And user clicks New Quote button
   
    And user enters client information and clicks search
    | Question     | Answer         |
    | DOB          |  {{randomDOB}}  |
    | BestPhone    | {{randomPhone}} |
    | EmailAddress | {{randomEmail}} |

    
    And user selects Create New Client and clicks the Next button

    And user enters account owner information and clicks Next
    | Question           | Answer           |
    | MaritalStatus      | Single           |
    | StreetAddress      | 1206 Conway St   |
    | AptNumber          |                  |
    | City               |   Saint Paul     |
    | State              |   Minnesota      |
    | ZipCode            |     55106        |
    | ReceivedMail       |     Yes          |
    | WhereClientResides |     Yes          |

    And user selects Special Farm Package and inputs Quote Details
    | Question       | Answer                                      |
	| EffectiveDate  | {{tomorrow}}                                |
	| PolicyTerm     | 12 months                                   |
	| AgentCode      | D2102                                       |
	| RatingState    | Minnesota                                   |
	| SSN            |                                             |
	| WritingCompany | American National Property And Casualty Co. |
	| RiskAddress    | 1206 Conway St, Saint Paul, MN 55106        |

    And user enters SFP policy details and clicks Next button
		| Question            | Answer  |
		| PrimaryFarmType     | Animals |
		| LivestockType       | Beef    |
		| GrossFarmIncome     | 75000   |
		| GrowIndustrialHemp  | No      |


    When user enters Pre-Qualification information and continues
	    | Question                | Answer            |
        | EligibilityRestrictions | None Of The Above |

    When user selects Primary Insured and continues

    When user Validates Primary Insured Information for SFP and continues

    When user answers UW Questions and continues
    | Question               | Answer |
    | ConvictionFelony       | No    |
    | PolicyDeclined5Years   | No     |
    | AlcoholOnPremises      | No    |
    | NoneOfTheAbove         | Yes     |

    When user enters Claims and Prior Insurance Information and continues
		| Question                 | Answer |
		| PriorFFANPolicy          | No     |
		| YearsInBusiness          |      5 |
		| YearsContinuousCoverage  |      5 |

    When user validates Client Details and continues

    When user Adds Narrative and continues
		| Question  | Answer        |
		| Narrative | Raises Cattle |

    When user selects Policy Wide or Division Specific Coverages and continues
     | CoverageType | CoverageName         | Select |
     | Policy       | Agribusiness         | No     |
     | Division I   | Excess Debris Removal | Yes    |
     | Division II  | Excess Debris Removal | Yes    |