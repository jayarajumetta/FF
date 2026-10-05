@SFP @ExpertQuote @Regression
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
      | Territory               | <Territory>              |
      | AllPerilDeductible      | <AllPerilDeductible>     |
      | WindHailDeductible      | <WindHailDeductible>     |
      | HurricaneDeductible     | <HurricaneDeductible>    |
      | HurricaneOptional       | <HurricaneOptional>      |

    # Step 18: Add a Residence
    When user adds and verifies a Basic Residence to the Location
      | Question          | Answer        |
      | AdditionalDesc    | Main House    |
      | YearBuilt         | 2024          |
      | NumberOfFamilies  | Single Family |
      | RateType          | Frame         |
      | ConditionRating   | 1             |
      | RoofYear          | 2024          |
      | RoofType          | Slate         |
      | RoofImpact        | UL 2          |
      | HeatingYear       | 2026          |
      | PlumbingYear      | 2025          |
      | WiringYear        | 2026          |
      | SeasonalOrVacant  | No            |
      | SolidFuelQuestion | No            |

    # Step 19: Add Residence Coverage
    When user adds and verifies Basic Residence Coverage
      | Question           | Answer           |
      | InsuranceAmount    | 550000           |
      | SquareFeet         | 1800             |
      | Perils             | 5                |
      | ThermostatQuestion | Yes              |
      | ActualCashValue    | Replacement Cost |
      | RCTOption          | Standard         |
      | UseDefaults        | Yes              |

    # Step 20: Skip Optional Coverages
    When user skips Optional Coverages and continues

    # Step 21: Add Farm Personal Property
    When user adds and verifies Basic Farm Personal Property
      | Question    | Answer          |
      | Code        | 464             |
      | Description | Bose Sound Bars |
      | Limit       | 101500          |
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
    When user adds Liability coverage and stays
      | Question          | Answer            |
      | LiabilityLimit    | $100,000/$100,000 |
      | LivestockHorses   |                 0 |
      | LivestockSmall    |                 2 |
      | LivestockLarge    |                 3 |
      | NumberOfEmployees |                 0 |
      | UnlistedAcreage   |                 0 |

    # Step 24A: Add Limited Farm Pollution where coverage 146 is offered
    When user edits liability optional coverage and continues
      | Question                   | Answer                           |
      | CoverageCode               | 146                              |
      | CoverageName               | Limited Farm Pollution Liability |
      | RequiredBaseLiabilityLimit | $100,000/$300,000                |
      | OccurrenceAggregate        | 50000/300000                     |
      | TotalOnsiteCapacity        | 8000000                          |
      | FurthestLocationMiles      | 23                               |
      | WasteTripsPerYear          | 550                              |
      | AboveGroundTanks           | Yes                              |
      | TankCapacity               | 10000                            |
      | TankConstructionDate       | 2024-03-31                       |
      | EligibilityQuestions       | None Of The Above                |
      | ExpectedReferralRule       | 11125                            |

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
      | State   | StateAbbv | Address         | AddressLine2 | City          | Zip   | County  | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Alabama | AL        | 1918 Avalon Ave |          111 | Muscle Shoals | 35661 | Colbert |           |                    | 1%                 |                     |                   |

    @Shard1
    Examples:
      | State     | StateAbbv | Address             | AddressLine2 | City          | Zip   | County       | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Arkansas  | AR        | 3998 Harrison St    |          111 | Batesville    | 72503 | Independence |           |                    | 1%                 |                     |                   |
      | Arizona   | AZ        | 4201 N 24th St      |          111 | Phoenix       | 85016 | Maricopa     |           |                    | 1%                 |                     |                   |
      | Colorado  | CO        | 231 Main St         |          111 | Fort Morgan   | 80701 | Morgan       |           |                    | 1%                 |                     |                   |
      | Idaho     | ID        | 1221 W Ironwood Dr  |          111 | Coeur D Alene | 83814 | Kootenai     |           |                    | 1%                 |                     |                   |
      | Illinois  | IL        | 2576 Charles St     |          111 | Rockford      | 61108 | Winnebago    |           |                    | 1%                 |                     |                   |
      | Indiana   | IN        | 5518 Calumet Ave    |          111 | Hammond       | 46320 | Lake         |           |                    | 1%                 |                     |                   |
      | Iowa      | IA        | 808 River St        |          111 | Decorah       | 52101 | Winneshiek   |           |                    | 1%                 |                     |                   |
      | Kansas    | KS        | 9400 State Ave      |          111 | Kansas City   | 66112 | Wyandotte    |           |                    | 1%                 |                     |                   |
      | Kentucky  | KY        | 1002 Medical Dr     |          111 | Mayfield      | 42066 | Graves       |           |                    | 1%                 |                     |                   |
      | Louisiana | LA        | 218 Meadow Dr       |          111 | Oakdale       | 71463 | Allen        |           |                    | 1%                 |                     |                   |

    @Shard1 @Pollution146
    Examples:
      | State    | StateAbbv | Address             | AddressLine2 | City       | Zip   | County     | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Delaware | DE        | 424 Delaware St     |          111 | New Castle | 19720 | New Castle |           |                    | 1%                 |                     |                   |
      | Georgia  | GA        | 3715 Northside Pkwy |          111 | Atlanta    | 30327 | Fulton     |           |                    | 1%                 |                     |                   |

    @Shard1 @Connecticut @Pollution146
    Examples:
      | State       | StateAbbv | Address           | AddressLine2 | City    | Zip   | County  | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Connecticut | CT        | 391 Old Post Road |          111 | Tolland | 06084 | Tolland |           |                    | 1%                 |                     |                   |

    @Shard2 @Debug
    Examples:
      | State       | StateAbbv | Address             | AddressLine2 | City     | Zip   | County   | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Mississippi | MS        | 4105 Washington Ave |          111 | Gulfport | 39507 | Harrison |           |                    | 1%                 |                     |                   |

    @Shard2
    Examples:
      | State         | StateAbbv | Address                       | AddressLine2 | City         | Zip   | County       | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Missouri      | MO        | 1895 S Forrest Heights Avenue |          111 | Springfield  | 65809 | Greene       |           |                    | 1%                 |                     |                   |
      | Minnesota     | MN        | 115 S Main ST                 |          111 | Warren       | 56762 | Marshall     |           |                    | 1%                 |                     |                   |
      | Montana       | MT        | 1202 3rd St W                 |           11 | Roundup      | 59072 | Musselshell  |           |                    | 1%                 |                     |                   |
      | Nebraska      | NE        | 1517 Broadway                 |          111 | Scottsbluff  | 69361 | Scotts Bluff |           |                    | 1%                 |                     |                   |
      | Nevada        | NV        | 340 N 11th St                 |          111 | Las Vegas    | 89101 | Clark        |           |                    | 1%                 |                     |                   |
      | New Mexico    | NM        | 901 West 13th St              |          111 | Clovis       | 88101 | Curry        |           |                    | 1%                 |                     |                   |
      | North Dakota  | ND        | 600 S 2nd St                  |          111 | Bismarck     | 58504 | Burleigh     |           |                    | 1%                 |                     |                   |
      | Oklahoma      | OK        | 436255 E 330 Rd               |          111 | Big Cabin    | 74332 | Craig        |           |                    | 1%                 |                     |                   |

    @Shard2 @Pollution146
    Examples:
      | State         | StateAbbv | Address          | AddressLine2 | City         | Zip   | County    | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Massachusetts | MA        | 66 Wendell Ave   |          111 | Pittsfield   | 01201 | Berkshire |           |                    | 1%                 |                     |                   |
      | Maine         | ME        | 33 Davis St      |          111 | Presque Isle | 04769 | Aroostook |           |                    | 1%                 |                     |                   |
      | New Hampshire | NH        | 67 Comstock Road |          111 | Alstead      | 03602 | Cheshire  |           |                    | 1%                 |                     |                   |

    @Shard2 @DevOnly
    Examples:
      | State    | StateAbbv | Address              | AddressLine2 | City    | Zip   | County     | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Maryland | MD        | 18400 Muncaster Road |              | Derwood | 20855 | Montgomery |       007 | $1,000             | 2%                 | 2%                  | Yes               |

    @Shard2 @NewJersey
    Examples:
      | State      | StateAbbv | Address    | AddressLine2 | City       | Zip   | County    | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | New Jersey | NJ        | 27 West St |          111 | Bloomsbury | 08804 | Hunterdon |           |                    | 1%                 |                     |                   |

    @Shard3 @Debug
    Examples:
      | State | StateAbbv | Address            | AddressLine2 | City      | Zip   | County | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Ohio  | OH        | 1566 Northeast Ave |          111 | Tallmadge | 44278 | Summit |           |                    | 1%                 |                     |                   |

    @Shard3
    Examples:
      | State          | StateAbbv | Address          | AddressLine2 | City          | Zip   | County     | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Oregon         | OR        | 661 SW 26TH ST   |          111 | Corvallis     | 97331 | Benton     |           |                    | 1%                 |                     |                   |
      | South Carolina | SC        | 3009 Augusta Hwy |          111 | Allendale     | 29810 | Allendale  |           |                    | 1%                 |                     |                   |
      | South Dakota   | SD        | 700 Governors Dr |          111 | Pierre        | 57501 | Hughes     |           |                    | 1%                 |                     |                   |
      | Tennessee      | TN        | 207 N Boone St   |          111 | Johnson City  | 37604 | Washington |           |                    | 1%                 |                     |                   |
      | Texas          | TX        | 118 Broadway     |          111 | San Antonio   | 78205 | Bexar      |           |                    | 1%                 |                     |                   |
      | Utah           | UT        | 170 N Main       |          111 | Logan         | 84321 | Cache      |           |                    | 1%                 |                     |                   |
      | Washington     | WA        | 834 Sheridan St  |          111 | Port Townsend | 98368 | Jefferson  |           |                    | 1%                 |                     |                   |
      | Wisconsin      | WI        | 3601 Memorial Dr |          111 | Madison       | 53704 | Dane       |           |                    | 1%                 |                     |                   |
      | Wyoming        | WY        | 100 E B St       |          111 | Casper        | 82601 | Natrona    |           |                    | 1%                 |                     |                   |

    @Shard3 @DevOnly
    Examples:
      | State        | StateAbbv | Address               | AddressLine2 | City      | Zip   | County    | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Pennsylvania | PA        | 2451 Kissel Hill Road |              | Lancaster | 17601 | Lancaster |       001 | $2,000             | None               | None                | No                |
      | Vermont      | VT        | 69 Old River Road     |              | Woodstock | 05091 | Windsor   |       031 | $2,500             | 1%                 | None                | No                |

    @Shard3 @RhodeIsland @Pollution146
    Examples:
      | State        | StateAbbv | Address     | AddressLine2 | City       | Zip   | County     | Territory | AllPerilDeductible | WindHailDeductible | HurricaneDeductible | HurricaneOptional |
      | Rhode Island | RI        | 160 Pine St |          111 | Providence | 02903 | Providence |           |                    | 1%                 |                     |                   |
