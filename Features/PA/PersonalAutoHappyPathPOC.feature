@UI,
Feature: Personal Auto Happy Path POC

  @ExpertQuote
  Scenario: Create a Personal Auto Quote and Submit for Issuance
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

    Then user selects Personal Auto and inputs Quote Details
	| Question       | Answer                                      |
	| EffectiveDate  | 2/15/2026                                  |
	| PolicyTerm     | 6 months                                    |
	| AgentCode      | D2102                                       |
	| RatingState    | Missouri                                    |
	| SSN            |                                    |
	| WritingCompany | American National Property And Casualty Co. |
	| RiskAddress    | 6 Patriot Ln, Buffalo, MO 65622      |
    

    Then user enters Pre-Qualification information and continues
	| Question                | Answer            |
    | EligibilityRestrictions | None Of The Above |
    

    Then user selects existing Driver

    Then user enters Driver information and continues
	| Question                       | Answer                |
    | PhoneType                      | Cell                  |
    | Gender                         | Male                  |
    | EmailType                      | Home                  |
    | NamedInsured                   | Primary Named Insured |
    | OperatorStatus                 | Assigned              |
    | DLState                        | MO                    |
    | DLNumber                       | D79774321            |
    | YearsLicensed                  |                    30 |
    | MonthsLicensed                 |                     0 |
    | RequireFinancialResponsibility | No                    |
    | PriorInsurance                 | Yes                   |
    | PriorCarrier                   | Geico                 |
    | PriorPolicyNumber              |             123456789 |
    | YearsWithPriorCarrier          |                     5 |
    | MonthsWithPriorCarrier         |                     2 |
	
	
    Then user enters vehicle information and continues
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
    
	
    Then user assigns a vehicle to the driver
	| Question     | Answer    |
    | Vehicle      | Chevrolet |
    | DriverStatus | Principal |
    

    Then user verifies there are no claims or violations

    Then user selects discounts and clicks Next

    Then user selects Policy Coverages
	| Question       | Answer  |
    | PolicyCoverage | 300,000 |
    | CompCollOnly   | No      |
    | CompDeductible |   1,000 |
    | CollDeductible |   1,000 |
    

    Then user selects Additional Coverages
	| Question                        | Answer        |
    | AccidentalDeathAndDismemberment | $5,000        |
    | LossOfIncomeCoverage            | {{male}} {{random}} |
    | RentalReimbursement             | $50 Per Day   |
    | RoadsideAssistance              | No Coverage   |
   

    Then user verifies Pricing Details

    Then user verifies eligibility and clicks Next

    Then user adds an Additional Interest
	| Question                   | Answer         |
    | AddInterestType            | Joint Owner    |
    | AddInterestName            | {{female}} {{random}} |
    | AddInterestAddress         | 6 Patriot Ln  |
    | AddInterestCity            | Buffalo        |
    | AddInterestState           | MO             |
    | AddInterestZip             |          65622 |
    | AddInterestPhone           | (417) 733-6789 |
    | DoesJointOwnerDrive        | Yes            |
    | RelationshipToAccountOwner | Spouse         |
    | AddInterestDOB             | 03/24/1964     |
    | AddInterestDLNumber        | S064184013     |
    | AddInterestLicenseState    | MO             |
    

    Then user creates a new Billing Account and Submits payment
	| Question       | Answer        |
	| PrimaryPayer   | {{male}} {{random}} |
	| PaymentType    | Direct Bill   |
	| PaymentPlan    | 1 Payment     |
	| PaymentDueDate |            29 |
	| PaymentAmount  | Full Balance  |
	| PaymentMethod  | Check         |
	| CheckNumber    |           473 |
	| Paperless      | Yes           |
    
    Then user switches to QAExpress
    Then user enters QAExpress credentials and Clicks LogIn
    Then user selects search type from dropdown and enters quote number and clicks search
    |   Question |        Answer       |
    | SearchType | Quote |
    