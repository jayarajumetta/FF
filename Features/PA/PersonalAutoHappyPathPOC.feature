@PA @ExpertQuote
Feature: Personal Auto Happy Path POC

  @Regression
  Scenario: Create a Personal Auto Quote and Submit for Issuance
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

    And user selects Personal Auto and inputs Quote Details
	| Question       | Answer                                      |
	| EffectiveDate  | {{tomorrow}}                                |
	| PolicyTerm     | 6 months                                    |
	| AgentCode      | D2102                                       |
	| RatingState    | Missouri                                    |
	| SSN            |                                             |
	| WritingCompany | American National Property And Casualty Co. |
	| RiskAddress    | 6 Patriot Ln, Buffalo, MO 65622             |


    And user enters Pre-Qualification information and continues
	| Question                | Answer            |
    | EligibilityRestrictions | None Of The Above |


    And user selects existing Driver

    And user enters Driver information and continues
	| Question                       | Answer                |
	| PhoneType                      | Cell                  |
	| Gender                         | Male                  |
	| EmailType                      | Home                  |
	| NamedInsured                   | Primary Named Insured |
	| OperatorStatus                 | Assigned              |
	| DLState                        | MO                    |
	| DLNumber                       | D79774321             |
	| YearsLicensed                  |                    30 |
	| MonthsLicensed                 |                     0 |
	| RequireFinancialResponsibility | No                    |
	| PriorInsurance                 | Yes                   |
	| PriorCarrier                   | Geico                 |
	| PriorPolicyNumber              |             123456789 |
	| YearsWithPriorCarrier          |                     5 |
	| MonthsWithPriorCarrier         |                     2 |


    And user enters vehicle information and continues
	| Question            | Answer                                         |
    | VIN                 |              1GNSKCKD2MR134828                 |
    | VehicleType         |                  Automobile                    |
    | ModelYear           |                   2021                         |
    | Make                |                 Chevrolet                      |
    | Model               |                 Suburban 1500                  |
    | Trim                | SUBURBAN 1500 4D LT ETHAN 4WD 6 SPD AUTO 8 CYL |
    | OwnedFinanced       |                     Own                        |
    | CustomizedEquipment |                     No                         |
    | VehicleUse          |                   Pleasure                     |
    | PurchaseDate        |                  01/15/2021                    |
    | OdometerReading     |                    150000                      |
    | AnnualMileage       |                    20000                       |


    And user assigns a vehicle to the driver
	| Question     | Answer    |
    | Vehicle      | Chevrolet |
    | DriverStatus | Principal |


    And user verifies there are no claims or violations

    And user selects discounts and clicks Next

    And user selects Policy Coverages
	| Question       | Answer  |
    | PolicyCoverage | 300,000 |
    | CompCollOnly   | No      |
    | CompDeductible |   1,000 |
    | CollDeductible |   1,000 |


    And user selects Additional Coverages
	| Question                        | Answer                          |
    | AccidentalDeathAndDismemberment | $5,000                          |
    | LossOfIncomeCoverage            | {{firstName}} {{lastName}}      |
    | RentalReimbursement             | $50 Per Day                     |
    | RoadsideAssistance              | No Coverage                     |


    And user verifies Pricing Details

    And user verifies eligibility and clicks Next

    And user adds an Additional Interest
	| Question                   | Answer                     |
    | AddInterestType            | Joint Owner                |
    | AddInterestName            | {{firstName}} {{lastName}} |
    | AddInterestAddress         | 6 Patriot Ln               |
    | AddInterestCity            | Buffalo                    |
    | AddInterestState           | MO                         |
    | AddInterestZip             |          65622             |
    | AddInterestPhone           | (417) 733-6789             |
    | DoesJointOwnerDrive        | Yes                        |
    | RelationshipToAccountOwner | Spouse                     |
    | AddInterestDOB             | 03/24/1964                 |
    | AddInterestDLNumber        | S064184013                 |
    | AddInterestLicenseState    | MO                         |


    And user creates a new Billing Account and Submits payment
	| Question       | Answer                     |
	| PrimaryPayer   | {{firstName}} {{lastName}} |
	| PaymentType    | Direct Bill                |
	| PaymentPlan    | 1 Payment                  |
	| PaymentDueDate |            29              |
	| PaymentAmount  | Full Balance               |
	| PaymentMethod  | Check                      |
	| CheckNumber    |           473              |
	| Paperless      | Yes                        |

    And user switches to QAExpress
    And user enters QAExpress credentials and Clicks LogIn
    Then user selects search type from dropdown and enters quote number and clicks search
    |   Question |        Answer       |
    | SearchType | Quote |
