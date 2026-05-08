@BOP @ExpertQuote
Feature: BOP Happy Path

  @Regression
  Scenario: Create a BOP Quote and Submit for Issuance
    Given I navigate to the Expert Quote login page

    When I enter valid credentials and Click LogIn

    And user enters a Random Name in the search field and clicks search
    | Question  | Answer         |
    | FirstName | {{firstName}}  |
    | LastName  | {{lastName}}   |

    And user clicks New Quote button

    And user enters client information and clicks search
    | Question     | Answer         |
    | DOB          |  08/08/1944    |
    | BestPhone    | (907) 227-0664 |
    | EmailAddress | fake@email.com |


    And user selects Create New Client and clicks the Next button

    And user enters account owner information and clicks Next
    | Question           | Answer        |
    | MaritalStatus      | Single        |
    | StreetAddress      | 6 Patriot Ln  |
    | AptNumber          |               |
    | City               |   Buffalo     |
    | State              |   Missouri    |
    | ZipCode            |     65622     |
    | ReceivedMail       |     Yes       |
    | WhereClientResides |     Yes       |

    And user selects Business Owners and inputs Quote Details
	| Question           | Answer                                      |
	| EffectiveDate      | {{tomorrow}}                                |
	| PolicyTerm         | 12 months                                   |
	| AgentCode          | D2102                                       |
	| RatingState        | Missouri                                    |
	| SSN                |                                             |
	| LessorRiskExposure | No                                          |
	| BusinessEntity     | Individually Owned                          |
	| DBAName            | Testing BOP Workflow                        |
	| WritingCompany     | American National Property And Casualty Co. |
	| RiskAddress        | 6 Patriot Ln, Buffalo, MO 65622             |


	And user selects class codes and continues
		| Question        | Answer            |
		| ClassCodeNumber |             63611 |
		| Restrictions    | None Of The Above |

	And user selects Primary Insured and continues

    And user Enters Primary Insured Information and continues
		| Question   | Answer     |
		| EntityType | Individual |
		| BusinessPhone | (907) 227-0664 |
		| FEIN       | 12-3456789 |
