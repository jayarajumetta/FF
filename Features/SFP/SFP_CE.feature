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
    When user adds a Country Estate Residence to the Location
      | Question          | Answer        |
      | AdditionalDesc    | Main House    |
      | YearBuilt         | 2022          |
      | NumberOfFamilies  | Single Family |
      | RateType          | Frame         |
      | ConditionRating   | 1             |
      | RoofYear          | 2022          |
      | RoofType          | Asphalt       |
      | RoofImpact        | UL 2          |
      | SolidFuelQuestion | No            |

    # Step 20: Add Residence Coverage
    When user adds and verifies Country Estate Residence Coverage
      | Question                | Answer                    |
      | InsuranceAmount         | 375000                    |
      | HouseholdContentsAmount | 187500                    |
      | SquareFeet              | 1800                      |
      | Perils                  | 6                         |
      | ThermostatQuestion      | Yes                       |
      | ActualCashValue         | Expanded Replacement Cost |
      | RCTOption               | Standard                  |
      | UseDefaults             | Yes                       |

    # Step 21: Skip Optional Coverages
    When user skips Optional Coverages and continues

    # Step 21A: Add and verify the approved Division IV items
    When user adds and verifies Country Estate Scheduled Personal Property
      | Code | Description                        | AmountOfInsurance | UnattendedVehicle |
      | 409  | Stamp Collections                  | 5000              | Yes               |
      | 411  | Auto Trailer Home Personal Effects | 10000             | Yes               |

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

    @Shard4 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Alabama        | AL        | 2210 Wood Ave                 |          111 | Florence      | 35630 | Lauderdale   |

    @Shard4
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Arkansas       | AR        | 2400 Harrison St              |          111 | Batesville    | 72502 | Independence |
      | Arizona        | AZ        | 11811 N Tatum Blvd            |          111 | Phoenix       | 85028 | Maricopa     |
      | Colorado       | CO        | 19592 E 8th Ave                |          111 | Aurora        | 80011 | Adams        |
      | Connecticut    | CT        | 50 Columbus Blvd              |          111 | Hartford      | 06106 | Hartford     |
      | Delaware       | DE        | 40 E Main St                  |          111 | Newark        | 19711 | New Castle   |
      | Georgia        | GA        | 1250 Caroline St NE           |          111 | Atlanta       | 30307 | Fulton       |
      | Idaho          | ID        | 915 W Appleway Ave            |          111 | Coeur D Alene | 83815 | Kootenai     |
      | Illinois       | IL        | 4601 E State St               |          111 | Rockford      | 61109 | Winnebago    |
      | Indiana        | IN        | 6935 Indianapolis Blvd        |          111 | Hammond       | 46323 | Lake         |
      | Iowa           | IA        | 900 Montgomery St             |          111 | Decorah       | 52144 | Winneshiek   |
      | Kansas         | KS        | 10900 Parallel Pkwy           |          111 | Kansas City   | 66109 | Wyandotte    |
      | Kentucky       | KY        | 201 Clinic Dr                 |          111 | Paducah       | 42003 | McCracken    |
      | Louisiana      | LA        | 401 N Parkerson Ave           |          111 | Crowley       | 70526 | Acadia       |

    @Shard5 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Mississippi    | MS        | 15190 Community Rd            |          111 | Gulfport      | 39503 | Harrison     |

    @Shard5
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Missouri       | MO        | 4141 S Fremont Ave            |          111 | Springfield   | 65804 | Greene       |
      | Massachusetts  | MA        | 75 Tyler St                   |          111 | Pittsfield    | 01202 | Berkshire    |
      | Maine          | ME        | 21 Main St                    |          111 | Caribou       | 04736 | Aroostook    |
      | Minnesota      | MN        | 1800 University Ave SE        |          111 | Minneapolis   | 55414 | Hennepin     |
      | Montana        | MT        | 307 W Front St                |          111 | Missoula      | 59802 | Missoula     |
      | Nebraska       | NE        | 2502 1st Ave                  |          111 | Scottsbluff   | 69363 | Scotts Bluff |
      | Nevada         | NV        | 4850 W Flamingo Rd            |          111 | Las Vegas     | 89103 | Clark        |
      | New Hampshire  | NH        | 149 Emerald St                |          111 | Keene         | 03431 | Cheshire     |
      | New Jersey     | NJ        | 120 Albany St                 |          111 | New Brunswick | 08901 | Middlesex    |
      | New Mexico     | NM        | 2501 N Prince St              |          111 | Clovis        | 88103 | Curry        |
      | North Dakota   | ND        | 4204 Ottawa St                |          111 | Bismarck      | 58503 | Burleigh     |
      | Oklahoma       | OK        | 621 W Broadway Ave            |          111 | Enid          | 73701 | Garfield     |

    @Shard6 @Debug
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Ohio           | OH        | 433 N Main St                 |          111 | Akron         | 44310 | Summit       |

    @Shard6
    Examples:
      | State          | StateAbbv | Address                       | AddressLine2 | City          | Zip   | County       |
      | Oregon         | OR        | 1111 NW 9th St                |          111 | Corvallis     | 97330 | Benton       |
      | Rhode Island   | RI        | 790 N Main St                 |          111 | Providence    | 02904 | Providence   |
      | South Carolina | SC        | 100 Laurens St SW             |          111 | Aiken         | 29801 | Aiken        |
      | South Dakota   | SD        | 1616 N Harrison Ave           |          111 | Pierre        | 57532 | Hughes       |
      | Tennessee      | TN        | 100 W Martin Luther King Blvd |          111 | Chattanooga   | 37402 | Hamilton     |
      | Texas          | TX        | 6100 Camp Bowie Blvd          |          111 | Fort Worth    | 76116 | Tarrant      |
      | Utah           | UT        | 1380 N Main St                |          111 | Logan         | 84341 | Cache        |
      | Washington     | WA        | 505 W Riverside Ave           |          111 | Spokane       | 99201 | Spokane      |
      | Wisconsin      | WI        | 4502 Regent St                |          111 | Madison       | 53705 | Dane         |
      | Wyoming        | WY        | 730 E 2nd St                  |          111 | Casper        | 82609 | Natrona      |
