@SFP @CE @ExpertQuote
Feature: SFP Country Estate Policy

  @Regression
  Scenario Outline: SFP Country Estate Policy - <State>

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
      | MiddleName         | <StateAbbv>    |
      | MaritalStatus      | Married        |
      | StreetAddress      | <Address>      |
      | AptNumber          | <AddressLine2> |
      | City               | <City>         |
      | State              | <State>        |
      | ZipCode            | <Zip>          |
      | ReceivedMail       | Yes            |
      | WhereClientResides | Yes            |

    # Step 7: Select SFP Country Estate and quote details
    And user selects Special Farm Package and inputs Quote Details
      | Question         | Answer                                      |
      | ProductSelection | CE                                          |
      | EffectiveDate    | {{tomorrow}}                                |
      | PolicyTerm       | 12 months                                   |
      | AgentCode        | D2102                                       |
      | RatingState      | <State>                                     |
      | OwnershipType    | Individually Owned                          |
      | WritingCompany   | American National Property And Casualty Co. |
      | RiskAddress      | <Address>, <City>, <StateAbbv> <Zip>        |
      | LessorRisk       | No                                          |

    # Step 8: Answer SSN Popup
    When user handles SSN popup and enters SSN
      | Question | Answer        |
      | SSN      | {{randomSSN}} |

    # Step 9: Enter SFP policy details
    And user enters SFP policy details and clicks Next button
      | Question           | Answer |
      | PrimaryFarmType    | Crops  |
      | LivestockType      | Berry  |
      | GrossFarmIncome    | 500    |
      | GrowIndustrialHemp | No     |

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

    # Step 14: Add Claims/Prior Insurance
    When user enters Claims and Prior Insurance Information and continues
      | Question                | Answer   |
      | PriorFFANPolicy         | No       |
      | YearsInBusiness         | 5        |
      | YearsContinuousCoverage | 3+ Years |
      | PriorInsuranceExpDate   | 1/1/2025 |
      | PriorInsuranceCarrier   | GEICO    |

    # Step 15: Edit Client Role on Client Details page
    When user validates Client Details and selects Inspection Contact

    # Step 16: Add a Narrative
    When user Adds Narrative and continues
      | Question  | Answer           |
      | Narrative | Test Narrative 1 |

    # Step 17: Add Policy Wide Coverages
    When user selects Policy Wide or Division Specific Coverages
      | CoverageType | CoverageName               | Select |
      | Policy       | Country Estate Endorsement | Yes    |

    # Step 17A: Edit Coverage - Country Estate
    When user edits Country Estate coverage and continues
      | Question                          | Answer              |
      | CEDivisionIWaterDamage            | $5,000              |
      | CEDivisionIIUnscheduledStructures | $5,000              |
      | CEDivisionIIIBlanketFppSublimit   |               31000 |
      | CEDivisionIIIBlanketFppDeductible | $1,000              |
      | CEDivisionVLiabilityLimit         | $500,000/$1,000,000 |


    # Step 18: Add a Primary Location
    # Wind/Hail deductible verification and selection are performed within this step based on zip code and state
    When user provides location information and continues
      | Question                | Answer           |
      | LocationNickname        | Primary Location |
      | LocationType            | Both             |
      | MilesFromFireDepartment | 3                |
      | FeetFromHydrant         | 101-250          |
      | TotalAcreage            | 6                |
      | WindHailDeductible      | 1%               |

    # Step 19: Add a Residence
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

    # Step 20: Add Residence Coverage
    When user adds Residence Coverage
      | Question           | Answer                    |
      | InsuranceAmount    | 375000                    |
      | SquareFeet         | 1800                      |
      | Perils             | 3                         |
      | ThermostatQuestion | Yes                       |
      | ActualCashValue    | Expanded Replacement Cost |
      | RCTOption          | Standard                  |
      | UseDefaults        | Yes                       |

    # Step 21: Skip Optional Coverages
    When user skips Optional Coverages and continues

    # Step 22: Run the Insurance Score
    When user runs Insurance Score
      | Question              | Answer          |
      | EntityType            | Primary Insured |
      | InsuranceScoreConsent | Accept          |

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

    # Step 23: Verify Premium on Pricing Screen
    Then user verifies Premium on Pricing screen

    # Step 24: Validate Forms via Duckcreek
    When user validates Forms via Duckcreek for state "<StateAbbv>"

    # Step 25: Save for Later and re-open by quote number
    When user clicks Save for Later
    And user navigates to Expert Quote and searches by Quote Number

    # Step 25: Navigate to Submission and open Checklist
    When user navigates to Submission and opens Checklist
    Then user verifies no referrals are needed

    # Step 26: Enter required information for Checklist (Residence Photo #1)
    When user completes Checklist item
      | Question      | Answer              |
      | ItemName      | Residence Photo #1  |
      | Action        | Exception           |
      | ExceptionNote | Photo not available |
      | Note          | Photo not available |

    # Step 27: Enter required information for Checklist (UL Roof Type)
    When user completes Checklist item
      | Question      | Answer              |
      | ItemName      | UL Roof Type        |
      | Action        | Exception           |
      | ExceptionNote | Roof type confirmed |
      | Note          | Roof type confirmed |

    # Step 28: Enter required information for Checklist (Loss Runs)
    When user completes Checklist item
      | Question      | Answer                                             |
      | ItemName      | Loss Runs (Tiered - 5 Years; Not tiered - 3 years) |
      | Action        | Exception                                          |
      | ExceptionNote | Loss runs on file                                  |
      | Note          | Loss runs on file                                  |

    # Step 29: Enter required information for Checklist (Signature Page)
    When user completes Checklist item
      | Question      | Answer                 |
      | ItemName      | Signature Page         |
      | Action        | Exception              |
      | ExceptionNote | Signature page on file |
      | Note          | Signature page on file |
      | Optional      | Yes                    |

    # Step 30: Close Checklist and confirm Update
    When user closes Checklist and confirms Update

    # Step 31: Verify Transmit button is enabled
    Then user verifies Transmit button is enabled on Submission page

    @Shard1 @Smoke
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Alabama        | AL        | 1918 Avalon Ave               |          111 | Muscle Shoals | 35661 | Colbert      |

    @Shard1
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Arkansas       | AR        | 3998 Harrison St              |          111 | Batesville    | 72503 | Independence |
      | Arizona        | AZ        | 4201 N 24th St                |          111 | Phoenix       | 85016 | Maricopa     |
      | Colorado       | CO        | 231 Main St                   |          111 | Fort Morgan   | 80701 | Morgan       |
      | Idaho          | ID        | 1221 W Ironwood Dr            |          111 | Coeur D Alene | 83814 | Kootenai     |
      | Illinois       | IL        | 2576 Charles St               |          111 | Rockford      | 61108 | Winnebago    |
      | Indiana        | IN        | 5518 Calumet Ave              |          111 | Hammond       | 46320 | Lake         |
      | Iowa           | IA        | 808 River St                  |          111 | Decorah       | 52101 | Winneshiek   |
      | Kansas         | KS        | 9400 State Ave                |          111 | Kansas City   | 66112 | Wyandotte    |
      | Kentucky       | KY        | 1002 Medical Dr               |          111 | Mayfield      | 42066 | Graves       |
      | Louisiana      | LA        | 218 Meadow Dr                 |          111 | Oakdale       | 71463 | Allen        |

    @Shard2 @Smoke
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Mississippi    | MS        | 4105 Washington Ave           |          111 | Gulfport      | 39507 | Harrison     |

    @Shard2
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Missouri       | MO        | 1895 S Forrest Heights Avenue |          111 | Springfield   | 65809 | Greene       |
      | Minnesota      | MN        | 115 S Main ST                 |          111 | Warren        | 56762 | Marshall     |
      | Montana        | MT        | 1202 3rd St W                 |           11 | Roundup       | 59072 | Musselshell  |
      | Nebraska       | NE        | 1517 Broadway                 |          111 | Scottsbluff   | 69361 | Scotts Bluff |
      | Nevada         | NV        | 340 N 11th St                 |          111 | Las Vegas     | 89101 | Clark        |
      | New Hampshire  | NH        | 67 Comstock Road              |          111 | Alstead       | 03602 | Cheshire     |
      | New Mexico     | NM        | 901 West 13th St              |          111 | Clovis        | 88101 | Curry        |
      | North Dakota   | ND        | 600 S 2nd St                  |          111 | Bismarck      | 58504 | Burleigh     |
      | Oklahoma       | OK        | 436255 E 330 Rd               |          111 | Big Cabin     | 74332 | Craig        |

    @Shard3 @Smoke
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Ohio           | OH        | 1566 Northeast Ave            |          111 | Tallmadge     | 44278 | Summit       |

    @Shard3
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Oregon         | OR        | 661 SW 26TH ST                |          111 | Corvallis     | 97331 | Benton       |
      | South Carolina | SC        | 3009 Augusta Hwy              |          111 | Allendale     | 29810 | Allendale    |
      | South Dakota   | SD        | 700 Governors Dr              |          111 | Pierre        | 57501 | Hughes       |
      | Tennessee      | TN        | 207 N Boone St                |          111 | Johnson City  | 37604 | Washington   |
      | Texas          | TX        | 118 Broadway                  |          111 | San Antonio   | 78205 | Bexar        |
      | Utah           | UT        | 170 N Main                    |          111 | Logan         | 84321 | Cache        |
      | Washington     | WA        | 834 Sheridan St               |          111 | Port Townsend | 98368 | Jefferson    |
      | Wisconsin      | WI        | 3601 Memorial Dr              |          111 | Madison       | 53704 | Dane         |
      | Wyoming        | WY        | 100 E B St                    |          111 | Casper        | 82601 | Natrona      |
