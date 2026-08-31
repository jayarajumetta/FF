@SFP @ExpertQuote
Feature: SFP Basic Policy


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
      | State              | <State>        |
      | ZipCode            | <Zip>          |
      | ReceivedMail       | Yes            |
      | WhereClientResides | Yes            |

    # Step 7: Select Special Farm Package and quote details
    And user selects Special Farm Package and inputs Quote Details
      | Question       | Answer                                      |
      | EffectiveDate  | {{tomorrow}}                                |
      | PolicyTerm     | 12 months                                   |
      | AgentCode      | D2102                                       |
      | RatingState    | <State>                                     |
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

    # Step 13: Answer UW Questions
    When user answers UW Questions and continues
      | Question       | Answer |
      | NoneOfTheAbove | Yes    |

    # Step 14: Enter Claims and Prior Insurance
    When user enters Claims and Prior Insurance Information and continues
      | Question                | Answer   |
      | PriorFFANPolicy         | No       |
      | YearsInBusiness         | 5        |
      | YearsContinuousCoverage | 3+ Years |
      | PriorInsuranceExpDate   | 1/1/2025 |
      | PriorInsuranceCarrier   | GEICO    |

    # Step 15: Navigate to Client Details - Set Inspection Contact
    When user validates Client Details and selects Inspection Contact

    # Step 16: Add Narrative
    When user Adds Narrative and continues
      | Question  | Answer           |
      | Narrative | Test Narrative 1 |

    # Step 16: Policy Wide or Division Specific Coverages
    When user skips Policy Wide and Division Specific Coverages and continues

    # Step 17: Add a Primary Location
    When user provides location information and continues
      | Question                | Answer           |
      | LocationNickname        | Primary Location |
      | LocationType            | Both             |
      | MilesFromFireDepartment | 3                |
      | FeetFromHydrant         | 101-250          |
      | TotalAcreage            | 6                |
      | WindHailDeductible      | 1%               |

    # Step 18: Add a Residence
    When user adds a Residence to the Location
      | Question          | Answer        |
      | AdditionalDesc    | Main House    |
      | YearBuilt         | 2022          |
      | NumberOfFamilies  | Single Family |
      | RateType          | Frame         |
      | ConditionRating   | 1             |
      | RoofYear          | 2022          |
      | RoofType          | Asphalt       |
      | RoofImpact        | UL 2          |
      | SeasonalOrVacant  | No            |
      | SolidFuelQuestion | No            |

    # Step 19: Add Residence Coverage
    When user adds Residence Coverage
      | Question           | Answer           |
      | InsuranceAmount    | 375000           |
      | SquareFeet         | 1800             |
      | Perils             | 3                |
      | ThermostatQuestion | Yes              |
      | ActualCashValue    | Replacement Cost |
      | RCTOption          | Standard         |
      | UseDefaults        | Yes              |

    # Step 20: Skip Optional Coverages
    When user skips Optional Coverages and continues

    # Step 21: Add Farm Personal Property
    When user adds Farm Personal Property
      | Question    | Answer          |
      | Code        | 464             |
      | Description | Bose Sound Bars |
      | Limit       | 15000           |
      | Deductible  | $1,000          |

    # Step 22: Add Equipment Breakdown
    When user adds Equipment Breakdown information
      | Question              | Answer |
      | PowerGreaterThan250kw | No     |
      | TwoOrMoreLosses       | No     |
      | GreaterThan25000      | No     |
      | FarmImplements        | No     |

    # Step 23: Add Div 4 Scheduled Personal Property
    When user adds Scheduled Personal Property
      | Question        | Answer    |
      | Category        | 401       |
      | ItemType        | Bicycles  |
      | Description     | Road Bike |
      | Limit           | 750       |
      | YearOfAppraisal | 2025      |

    # Step 24: Add Liability
    When user adds Liability coverage
      | Question          | Answer            |
      | LiabilityLimit    | $100,000/$100,000 |
      | LivestockHorses   |                 0 |
      | LivestockSmall    |                 2 |
      | LivestockLarge    |                 3 |
      | NumberOfEmployees |                 0 |
      | UnlistedAcreage   |                 0 |

    # Step 25: Add a Mortgagee
    When user adds Additional Interest Mortgagee
      | Question              | Answer           |
      | SearchName            | Connect One Bank |
      | Location              | Primary          |
      | Residence             | Main House       |
      | CopyOfDEC             | No               |
      | AccountNumber         | 123456789        |
      | DescriptionOfInterest | Mortgage Lender  |
      | EscrowBilled          | Yes              |

    # Step 26: Run the Insurance Score
    When user runs Insurance Score
      | Question              | Answer          |
      | EntityType            | Primary Insured |
      | InsuranceScoreConsent | Accept          |

    # Step 27: Verify Premium on Pricing Screen
    Then user verifies Premium on Pricing screen

    # Step 28: Navigate to Billing via left menu
    When user navigates to the "Billing" page via the left menu

    # Step 29: Complete Billing Information
    When user completes Billing Information
      | Question       | Answer          |
      | BillingAccount | Create New      |
      | PrimaryPayer   | Primary Insured |
      | PaymentType    | Easy Pay        |
      | RoutingNumber  | 021000021       |
      | AccountNumber  | 123456789       |
      | BankName       | Test Bank       |
      | PaymentPlan    | 12 Payments     |
      | PaymentDueDate | 01              |
      | PaymentAmount  | Minimum         |
      | PaymentMethod  | Check           |

    # Step 30: Visit the Checklist page
    When user navigates to Submission and opens Checklist
    Then user verifies no referrals are needed

    # Step 31: Enter required information for Checklist (Residence Photo #1)
    When user completes Checklist item
      | Question      | Answer              |
      | ItemName      | Residence Photo #1  |
      | Action        | Exception           |
      | ExceptionNote | Photo not available |
      | Note          | Photo not available |

    # Step 32: Enter required information for Checklist (UL Roof Type Credit)
    When user completes Checklist item
      | Question      | Answer              |
      | ItemName      | UL Roof Type Credit |
      | Action        | Exception           |
      | ExceptionNote | Roof type confirmed |
      | Note          | Roof type confirmed |

    # Step 33: Enter required information for Checklist (Easy Pay)
    When user completes Checklist item
      | Question      | Answer      |
      | ItemName      | Easy Pay    |
      | Action        | Exception   |
      | ExceptionNote | EasyPay set |
      | Note          | EasyPay set |
      | Optional      | Yes         |

    # Step 34: Enter required information for Checklist (Loss Runs)
    When user completes Checklist item
      | Question      | Answer                                               |
      | ItemName      | Loss Runs (Tiered - 5 Years; Not tiered - 3 years)   |
      | Action        | Exception                                            |
      | ExceptionNote | Loss runs on file                                    |
      | Note          | Loss runs on file                                    |

    # Step 35: Close Checklist and Click OK to Update
    When user closes Checklist and confirms Update

    # Step 36: Transmit and Verify Premium
    Then user verifies Transmit button is enabled on Submission page

    # Step 37: Validate Forms attachment via Duckcreek
    When user validates Forms via Duckcreek for state "<StateAbbv>"

    @Shard1 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Alabama        | AL        | 1918 Avalon Ave               |          111 | Muscle Shoals | 35661 | Colbert      |

    @Shard1
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Arkansas       | AR        | 3998 Harrison St              |          111 | Batesville    | 72503 | Independence |
      | Arizona        | AZ        | 4201 N 24th St                |          111 | Phoenix       | 85016 | Maricopa     |
      | Colorado       | CO        | 231 Main St                   |          111 | Fort Morgan   | 80701 | Morgan       |
      | Connecticut    | CT        | 605 New England Rd            |          111 | Guilford      | 06437 | New Haven    |
      | Delaware       | DE        | 424 Delaware St               |          111 | New Castle    | 19720 | New Castle   |
      | Georgia        | GA        | 3715 Northside Pkwy           |          111 | Atlanta       | 30327 | Fulton       |
      | Idaho          | ID        | 1221 W Ironwood Dr            |          111 | Coeur D Alene | 83814 | Kootenai     |
      | Illinois       | IL        | 2576 Charles St               |          111 | Rockford      | 61108 | Winnebago    |
      | Indiana        | IN        | 5518 Calumet Ave              |          111 | Hammond       | 46320 | Lake         |
      | Iowa           | IA        | 808 River St                  |          111 | Decorah       | 52101 | Winneshiek   |
      | Kansas         | KS        | 9400 State Ave                |          111 | Kansas City   | 66112 | Wyandotte    |
      | Kentucky       | KY        | 1002 Medical Dr               |          111 | Mayfield      | 42066 | Graves       |
      | Louisiana      | LA        | 218 Meadow Dr                 |          111 | Oakdale       | 71463 | Allen        |

    @Shard2 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Mississippi    | MS        | 4105 Washington Ave           |          111 | Gulfport      | 39507 | Harrison     |

    @Shard2
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Missouri       | MO        | 1895 S Forrest Heights Avenue |          111 | Springfield   | 65809 | Greene       |
      | Massachusetts  | MA        | 66 Wendell Ave                |          111 | Pittsfield    | 01201 | Berkshire    |
      | Maine          | ME        | 33 Davis St                   |          111 | Presque Isle  | 04769 | Aroostook    |
      | Minnesota      | MN        | 115 S Main ST                 |          111 | Warren        | 56762 | Marshall     |
      | Montana        | MT        | 1202 3rd St W                 |           11 | Roundup       | 59072 | Musselshell  |
      | Nebraska       | NE        | 1517 Broadway                 |          111 | Scottsbluff   | 69361 | Scotts Bluff |
      | Nevada         | NV        | 340 N 11th St                 |          111 | Las Vegas     | 89101 | Clark        |
      | New Hampshire  | NH        | 67 Comstock Road              |          111 | Alstead       | 03602 | Cheshire     |
      | New Jersey     | NJ        | 344 Rt 9w                     |          111 | Bloomsbury    | 08804 | Hunterdon    |
      | New Mexico     | NM        | 901 West 13th St              |          111 | Clovis        | 88101 | Curry        |
      | North Dakota   | ND        | 600 S 2nd St                  |          111 | Bismarck      | 58504 | Burleigh     |
      | Oklahoma       | OK        | 436255 E 330 Rd               |          111 | Big Cabin     | 74332 | Craig        |

    @Shard3 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Ohio           | OH        | 1566 Northeast Ave            |          111 | Tallmadge     | 44278 | Summit       |

    @Shard3
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Oregon         | OR        | 661 SW 26TH ST                |          111 | Corvallis     | 97331 | Benton       |
      | Rhode Island   | RI        | 160 Pine St                   |          111 | Providence    | 02903 | Providence   |
      | South Carolina | SC        | 3009 Augusta Hwy              |          111 | Allendale     | 29810 | Allendale    |
      | South Dakota   | SD        | 700 Governors Dr              |          111 | Pierre        | 57501 | Hughes       |
      | Tennessee      | TN        | 207 N Boone St                |          111 | Johnson City  | 37604 | Washington   |
      | Texas          | TX        | 118 Broadway                  |          111 | San Antonio   | 78205 | Bexar        |
      | Utah           | UT        | 170 N Main                    |          111 | Logan         | 84321 | Cache        |
      | Washington     | WA        | 834 Sheridan St               |          111 | Port Townsend | 98368 | Jefferson    |
      | Wisconsin      | WI        | 3601 Memorial Dr              |          111 | Madison       | 53704 | Dane         |
      | Wyoming        | WY        | 100 E B St                    |          111 | Casper        | 82601 | Natrona      |
