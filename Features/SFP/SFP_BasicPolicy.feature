@UI
Feature: SFP Basic Policy

  @ExpertQuote @Smoke
  Scenario Outline: SFP Basic Policy - <State>
    # Step 1: Log into Expert Quote
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn

    # Step 2: Perform client search
    And user enters a Random Name in the search field and clicks search
      | Question  | Answer        |
      | FirstName | {{firstName}} |
      | LastName  | {{lastName}}  |

    # Step 3: Start a new quote
    And user clicks New Quote button

    # Step 4: Enter client information and search
    And user enters client information and clicks search
      | Question     | Answer          |
      | DOB          | {{randomDOB}}   |
      | BestPhone    | {{randomPhone}} |
      | EmailAddress | {{randomEmail}} |

    # Step 5: Create a new client
    And user selects Create New Client and clicks the Next button

    # Step 6: Enter account owner details
    And user enters account owner information and clicks Next
      | Question           | Answer         |
      | MiddleName         | midname        |
      | MaritalStatus      | Married        |
      | StreetAddress      | <Address>      |
      | AptNumber          | <AddressLine2> |
      | City               | <City>         |
      | State              | <StateFull>    |
      | ZipCode            | <Zip>          |
      | ReceivedMail       | Yes            |
      | WhereClientResides | Yes            |

    # Step 7: Select Special Farm Package and quote details
    And user selects Special Farm Package and inputs Quote Details
      | Question       | Answer                                      |
      | EffectiveDate  | {{tomorrow}}                                |
      | PolicyTerm     | 12 months                                   |
      | AgentCode      | D2102                                       |
      | RatingState    | <StateFull>                                 |
      | OwnershipType  | Individually Owned                          |
      | WritingCompany | American National Property And Casualty Co. |
      | RiskAddress    | <Address>, <City>, <StateAbbv> <Zip>        |
      | LessorRisk     | No                                          |

    # Step 8: Answer SSN Popup
    When user handles SSN popup and enters SSN
      | Question | Answer        |
      | SSN      | {{randomSSN}} |

    # Step 9: Enter SFP policy details
    And user enters SFP policy details and clicks Next button
      | Question             | Answer    |
      | PrimaryFarmType      | Animals   |
      | LivestockType        | Beef      |
      | SecondaryFarmType    | Crops     |
      | SecondaryFarmSubType | Blueberry |
      | GrossFarmIncome      | 1250      |
      | GrowIndustrialHemp   | No        |

    # Step 10: Navigate to Prequalification and answer General Eligibility
    When user enters Pre-Qualification information and continues
      | Question                | Answer            |
      | EligibilityRestrictions | None Of The Above |

    # Step 11: Navigate to Primary Insured
    When user selects Primary Insured and continues

    # Step 12: Answer UW Questions
    When user answers UW Questions and continues
      | Question       | Answer |
      | NoneOfTheAbove | Yes    |

    # Step 13: Enter Claims and Prior Insurance
    When user enters Claims and Prior Insurance Information and continues
      | Question                | Answer   |
      | PriorFFANPolicy         | No       |
      | YearsInBusiness         | 5        |
      | YearsContinuousCoverage | 3+ Years |
      | PriorInsuranceExpDate   | 1/1/2025 |
      | PriorInsuranceCarrier   | GEICO    |

    # Step 13: Navigate to Client Details - Set Inspection Contact
    When user validates Client Details and selects Inspection Contact

    # Step 14: Add Narrative
    When user Adds Narrative and continues
      | Question  | Answer           |
      | Narrative | Test Narrative 1 |

    # Step 15: Policy Wide or Division Specific Coverages
    When user selects Policy Wide or Division Specific Coverages and continues
      | CoverageType | CoverageName          | Select |
      | Policy       | Agribusiness          | No     |
      | Division I   | Excess Debris Removal | Yes    |
      | Division II  | Excess Debris Removal | Yes    |

    # Step 16: Add a Primary Location
    When user provides location information and continues
      | Question                | Answer           |
      | LocationNickname        | Primary Location |
      | LocationType            | Both             |
      | MilesFromFireDepartment | 5                |
      | FeetFromHydrant         | 501-750          |
      | PPC                     | 5                |
      | TotalAcreage            | 300              |
      | WindHailDeductible      | 1%               |

    # Step 17: Add a Residence
    When user adds a Residence to the Location
      | Question          | Answer       |
      | AdditionalDesc    | Main House   |
      | YearBuilt         | 2020         |
      | NumberOfFamilies  | Single Family|
      | RateType          | Frame        |
      | ConditionRating   | 1            |
      | RoofYear          | 2015         |
      | RoofType          | Composition  |
      | RoofImpact        | UL 3         |
      | SeasonalOrVacant  | No           |
      | SolidFuelQuestion | No           |

    # Step 18: Add Residence Coverage
    When user adds Residence Coverage
      | Question           | Answer           |
      | InsuranceAmount    | 250000           |
      | SquareFeet         | 2500             |
      | Perils             | 1                |
      | ThermostatQuestion | Yes              |
      | ActualCashValue    | Replacement Cost |
      | RCTOption          | Standard         |
      | UseDefaults        | Yes              |

    # Step 19: Skip Optional Coverages
    When user skips Optional Coverages and continues

    # Step 20: Add Farm Personal Property
    When user adds Farm Personal Property
      | Question    | Answer          |
      | Code        | 464             |
      | Description | Bose Sound Bars |
      | Limit       | 15000           |
      | Deductible  | $1,000          |

    # Step 20: Add Equipment Breakdown
    When user adds Equipment Breakdown information
      | Question              | Answer |
      | PowerGreaterThan250kw | No     |
      | TwoOrMoreLosses       | No     |
      | GreaterThan25000      | No     |
      | FarmImplements        | No     |

    # Step 21: Add Div 4 Scheduled Personal Property
    When user adds Scheduled Personal Property
      | Question        | Answer    |
      | Category        | 401       |
      | ItemType        | Bicycles  |
      | Description     | Road Bike |
      | Limit           | 750       |
      | YearOfAppraisal | 2025      |

    # Step 22: Add Liability
    When user adds Liability coverage
      | Question          | Answer            |
      | LiabilityLimit    | $100,000/$100,000 |
      | LivestockHorses   |                 0 |
      | LivestockSmall    |                 2 |
      | LivestockLarge    |                 3 |
      | NumberOfEmployees |                 1 |
      | UnlistedAcreage   |                 0 |

    # Step 23: Add a Mortgagee
    When user adds Additional Interest Mortgagee
      | Question              | Answer           |
      | SearchName            | Connect One Bank |
      | Location              | Primary          |
      | Residence             | Main House       |
      | CopyOfDEC             | No               |
      | AccountNumber         | 123456789        |
      | DescriptionOfInterest | Mortgage Lender  |
      | EscrowBilled          | Yes              |

    # Step 24: Run the Insurance Score
    When user runs Insurance Score
      | Question              | Answer          |
      | EntityType            | Primary Insured |
      | InsuranceScoreConsent | Accept          |

    # Step 25: Verify Premium on Pricing Screen
    Then user verifies Premium on Pricing screen

    # Step 26: Navigate to Submission
    When user navigates to Submission page

    # Step 27: Validate Forms attachment via Duckcreek
    When user validates Forms via Duckcreek
      | Question   | Answer       |
      | ClientName | {{fullName}} |
      | State      | <StateAbbv>  |

    # Step 28: Save for Later
    And user clicks Save for Later

    # Step 29: Re-Log back in to EQ and Search by Quote Number
    When user navigates to Expert Quote and searches by Quote Number

    # Step 30: Complete Billing Information
    When user completes Billing Information
      | Question       | Answer           |
      | BillingAccount | Create New       |
      | AccountName    | Tommy Automation |
      | CompanyName    | Auto Corp        |
      | StreetAddress  | 9 Center Road    |
      | City           | Mahopac          |
      | State          | NY               |
      | ZipCode        | 10541            |
      | PaymentDueDate | 01               |
      | PaymentMethod  | Check            |

    # Step 31: Visit the Checklist page
    When user navigates to Submission and opens Checklist
    Then user verifies no referrals are needed

    # Step 32: Enter required information for Checklist (Residence Photo #1)
    When user completes Checklist item
      | Question | Answer             |
      | ItemName | Residence Photo #1 |
      | Action   | Exception          |
      | Note     | Photo not available|

    # Step 33: Enter required information for Checklist (UL Roof Type)
    When user completes Checklist item
      | Question | Answer              |
      | ItemName | UL Roof Type        |
      | Action   | Exception           |
      | Note     | Roof type confirmed |

    # Step 34: Enter required information for Checklist (Loss Runs)
    When user completes Checklist item
      | Question | Answer            |
      | ItemName | Loss Runs         |
      | Action   | Exception         |
      | Note     | Loss runs on file |

    # Step 35: Enter required information for Checklist (Signature Page)
    When user completes Checklist item
      | Question | Answer             |
      | ItemName | Signature Page     |
      | Action   | Exception          |
      | Note     | Signature obtained |

    # Step 36: Close Checklist and Click OK to Update
    When user closes Checklist and confirms Update

    # Step 37: Transmit and Verify Premium
    Then user verifies Transmit button is enabled on Submission page

    Examples:
      | State          | StateAbbv | StateFull      | Address            | AddressLine2 | City           | Zip   | County       |
      | Alabama        | AL        | Alabama        | 1918 Avalon Ave    | 111          | Muscle Shoals  | 35661 | Colbert      |
      | Arkansas       | AR        | Arkansas       | 3998 Harrison St   | 111          | Batesville     | 72503 | Independence |
      | Arizona        | AZ        | Arizona        | 4201 N 24th St     | 111          | Phoenix        | 85016 | Maricopa     |
      | Colorado       | CO        | Colorado       | 231 Main St        | 111          | Fort Morgan    | 80701 | Morgan       |
      | Idaho          | ID        | Idaho          | 1221 W Ironwood Dr | 111          | Coeur D Alene  | 83814 | Kootenai     |
      | Illinois       | IL        | Illinois       | 2576 Charles St    | 111          | Rockford       | 61108 | Winnebago    |
      | Kansas         | KS        | Kansas         | 9400 State Ave     | 111          | Kansas City    | 66112 | Wyandotte    |
      | Kentucky       | KY        | Kentucky       | 1002 Medical Dr    | 111          | Mayfield       | 42066 | Graves       |
      | Louisiana      | LA        | Louisiana      | 218 Meadow Dr      | 111          | Oakdale        | 71463 | Allen        |
      | Minnesota      | MN        | Minnesota      | 115 S Main ST      | 111          | Warren         | 56762 | Marshall     |
      | Montana        | MT        | Montana        | 1202 3rd St W      | 11           | Roundup        | 59072 | Musselshell  |
      | Nebraska       | NE        | Nebraska       | 1517 Broadway      | 111          | Scottsbluff    | 69361 | Scotts Bluff |
      | Nevada         | NV        | Nevada         | 340 N 11th St      | 111          | Las Vegas      | 89101 | Clark        |
      | North Dakota   | ND        | North Dakota   | 600 S 2nd St       | 111          | Bismarck       | 58504 | Burleigh     |
      | Oregon         | OR        | Oregon         | 661 SW 26TH ST     | 111          | Corvallis      | 97331 | Benton       |
      | South Carolina | SC        | South Carolina | 3009 Augusta Hwy   | 111          | Allendale      | 29810 | Allendale    |
      | South Dakota   | SD        | South Dakota   | 700 Governors Dr   | 111          | Pierre         | 57501 | Hughes       |
      | Tennessee      | TN        | Tennessee      | 207 N Boone St     | 111          | Johnson City   | 37604 | Washington   |
      | Texas          | TX        | Texas          | 118 Broadway       | 111          | San Antonio    | 78205 | Bexar        |
      | Utah           | UT        | Utah           | 170 N Main         | 111          | Logan          | 84321 | Cache        |
      | Washington     | WA        | Washington     | 834 Sheridan St    | 111          | Port Townsend  | 98368 | Jefferson    |
      | Wisconsin      | WI        | Wisconsin      | 3601 Memorial Dr   | 111          | Madison        | 53704 | Dane         |
      | Wyoming        | WY        | Wyoming        | 100 E B St         | 111          | Casper         | 82601 | Natrona      |
