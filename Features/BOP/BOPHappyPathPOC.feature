@UI, 
Feature: BOP Happy Path

  @ExpertQuote
  Scenario: Create a BOP Quote and Submit for Issuance
    Given I navigate to the Expert Quote login page

    When I enter valid credentials and Click LogIn

    Then user enters a Random Name in the search field and clicks search
    | Question  | Answer   |
    | FirstName | {{male}}   |
    | LastName  | {{random}}  |

    Then user clicks New Quote button
   
    Then user enters client information and clicks search
    | Question     | Answer         |
    | DOB          |  08/08/1944    |
    | BestPhone    | (907) 227-0664 |
    | EmailAddress | fake@email.com |

    
    Then user selects Create New Client and clicks the Next button

    Then user enters account owner information and clicks Next
    | Question           | Answer        |
    | MaritalStatus      | Single        |
    | StreetAddress      | 6 Patriot Ln  |
    | AptNumber          |               |
    | City               |   Buffalo     |
    | State              |   Missouri    |
    | ZipCode            |     65622     |
    | ReceivedMail       |     Yes       |
    | WhereClientResides |     Yes       |

    Then user selects Business Owners and inputs Quote Details
	| Question           | Answer                                      |
	| EffectiveDate      | 2/15/2026                                  |
	| PolicyTerm         | 12 months                                   |
	| AgentCode          | D2102                                       |
	| RatingState        | Missouri                                    |
	| SSN                |                                             |
	| LessorRiskExposure | No                                          |
	| BusinessEntity     | Individually Owned                          |
	| DBAName            | Testing BOP Workflow                        |
	| WritingCompany     | American National Property And Casualty Co. |
	| RiskAddress        | 6 Patriot Ln, Buffalo, MO 65622             |
  

	Then user selects class codes and continues
		| Question        | Answer            |
		| ClassCodeNumber |             63611 |
		| Restrictions    | None Of The Above |

	Then user selects Primary Insured and continues

    Then user Enters Primary Insured Information for BOP and continues
		| Question   | Answer     |
		| EntityType | Individual |
		| BusinessPhone | (907) 227-0664 |
		| FEIN       | 12-3456789 |
