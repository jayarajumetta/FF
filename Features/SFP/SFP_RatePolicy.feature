@SFP @RatePolicy @ExpertQuote @Regression
Feature: SFP Rate Policy

  Scenario Outline: SFP Rate Policy - <State>
    Given I navigate to the Expert Quote login page
    When I enter valid credentials and Click LogIn
    And user enters a Random Name in the search field and clicks search
      | Question  | Answer        |
      | FirstName | {{firstName}} |
      | LastName  | {{lastName}}  |
    And user clicks New Quote button
    And user enters client information and clicks search
      | Question     | Answer          |
      | DOB          | {{randomDOB}}   |
      | BestPhone    | {{randomPhone}} |
      | EmailAddress | {{randomEmail}} |
    And user selects Create New Client and clicks the Next button
    And user enters account owner information and clicks Next
      | Question           | Answer         |
      | MiddleName         | Rate           |
      | MaritalStatus      | Married        |
      | StreetAddress      | <Address>      |
      | AptNumber          | <AddressLine2> |
      | City               | <City>         |
      | State              | <State>        |
      | ZipCode            | <Zip>          |
      | ReceivedMail       | Yes            |
      | WhereClientResides | Yes            |
    And user selects Special Farm Package and inputs Quote Details
      | Question       | Answer                                     |
      | EffectiveDate  | {{laterOfTomorrow:03/21/2027}}             |
      | PolicyTerm     | 12 months                                  |
      | AgentCode      | D2102                                      |
      | RatingState    | <State>                                    |
      | OwnershipType  | Individually Owned                         |
      | WritingCompany | American National Property And Casualty Co. |
      | RiskAddress    | <Address>, <City>, <StateAbbv> <Zip>         |
      | LessorRisk     | No                                         |
    When user handles SSN popup and enters SSN
      | Question | Answer        |
      | SSN      | {{randomSSN}} |
    And user enters SFP policy details and clicks Next button
      | Question             | Answer    |
      | PrimaryFarmType      | Animals   |
      | LivestockType        | Beef      |
      | SecondaryFarmType    | Crops     |
      | SecondaryFarmSubType | Blueberry |
      | GrossFarmIncome      | 1250      |
      | GrowIndustrialHemp   | No        |
    When user enters Pre-Qualification information and continues
      | Question                | Answer            |
      | EligibilityRestrictions | None Of The Above |
    When user selects Primary Insured and continues
    When user answers UW Questions and continues
      | Question       | Answer |
      | NoneOfTheAbove | Yes    |
    When user enters Claims and Prior Insurance Information and continues
      | Question                | Answer   |
      | PriorFFANPolicy         | No       |
      | YearsInBusiness         | 5        |
      | YearsContinuousCoverage | 3+ Years |
      | PriorInsuranceExpDate   | 1/1/2025 |
      | PriorInsuranceCarrier   | GEICO    |
    When user validates Client Details and selects Inspection Contact
    When user Adds Narrative and continues
      | Question  | Answer                  |
      | Narrative | November 2026 Rate Test |
    When user skips Policy Wide and Division Specific Coverages and continues

    When user provides location information and continues
      | Question                | Answer           |
      | LocationNickname        | Primary Location |
      | LocationType            | Both             |
      | MilesFromFireDepartment | 3                |
      | FeetFromHydrant         | 101-250          |
      | TotalAcreage            | 200              |
      | WindHailDeductible      | 1%               |

    When user adds a Residence to the Location
      | Question          | Answer        |
      | AdditionalDesc    | Main House    |
      | YearBuilt         | 1995          |
      | NumberOfFamilies  | Single Family |
      | RateType          | Mobile Home   |
      | ConditionRating   | 2             |
      | RoofYear          | 2016          |
      | RoofType          | Asphalt       |
      | RoofImpact        | Not Listed    |
      | SeasonalOrVacant  | No            |
      | SolidFuelQuestion | No            |
      | HeatingYear       | 2022          |
      | PlumbingYear      | 2020          |
      | WiringYear        | 2017          |
    When user adds Residence Coverage and stays on the property
      | Question               | Answer                    |
      | InsuranceAmount        | 250000                    |
      | SquareFeet             | 1200                      |
      | Perils                 | 5                         |
      | ThermostatQuestion     | Yes                       |
      | ActualCashValue        | Actual Cash Value         |
      | EstimatorType          | RCT                       |
      | RCTOption              | Mobile / Manufactured RCT |
      | UseDefaults            | Yes                       |
      | DepreciationPercentage | 10                        |
    When user adds Residence Contents and saves the property
      | Question        | Answer               |
      | CoverageType    | Mobile Home Contents |
      | InsuranceAmount | 100000               |
      | Perils          | 5                    |
      | ReplacementCost | Yes                  |

    When user adds a building with coverage and contents
      | Question                | Answer                           |
      | AdditionalDesc          | Storage Building                 |
      | Construction            | Brick                            |
      | RateType                | 1                                |
      | YearBuilt               | 2023                             |
      | WiringYear              | 2025                             |
      | HeatingYear             | 2025                             |
      | PlumbingYear            | 2025                             |
      | RoofYear                | 2025                             |
      | RoofType                | Concrete                         |
      | SolidFuelQuestion       | No                               |
      | CoverageType            | Farm Building                    |
      | InsuranceAmount         | 1200000                          |
      | Perils                  | 5                                |
      | ReplacementCost         | Yes                              |
      | DescriptionCode         | Storage Building                 |
      | SquareFeet              | 800                              |
      | Estimator               | BVS                              |
      | Valuation               | Agricultural Valuation           |
      | Occupancy               | Cattle                           |
      | SearchResult            | 120 - Hay Storage, Open One Side |
      | ThermostatQuestion      | No                               |
      | ContentsType            | Farm Contents                    |
      | ContentsAmount          | 750000                           |
      | ContentsPerils          | 5                                |
      | ContentsReplacementCost | Yes                              |
      | ContentsDescriptionCode | Storage Building                 |

    When user adds a building with coverage and contents
      | Question                | Answer                    |
      | AdditionalDesc          | Tractor Barn              |
      | Construction            | Metal                     |
      | RateType                | 2                         |
      | YearBuilt               | 1985                      |
      | WiringYear              | 2018                      |
      | HeatingYear             | 2025                      |
      | PlumbingYear            | 2024                      |
      | RoofYear                | 2026                      |
      | RoofType                | Metal                     |
      | SolidFuelQuestion       | No                        |
      | CoverageType            | Private Structure         |
      | InsuranceAmount         | 325000                    |
      | Perils                  | 5                         |
      | ReplacementCost         | Yes                       |
      | DescriptionCode         | Equipment Shed            |
      | SquareFeet              | 1500                      |
      | Estimator               | BVS                       |
      | Valuation               | Agricultural Valuation    |
      | Occupancy               | General                   |
      | SearchResult            | 601 - Farm Implement Shed |
      | ThermostatQuestion      | No                        |
      | ContentsType            | Private Contents          |
      | ContentsAmount          | 200000                    |
      | ContentsPerils          | 5                         |
      | ContentsReplacementCost | Yes                       |
      | ContentsDescriptionCode | Equipment Shed            |

    When user finishes adding locations residences and buildings
    When user skips Optional Coverages and continues
    When user adds detailed Farm Personal Property and continues
      | Question     | Answer     |
      | Code         | 472        |
      | Limit        | 120000     |
      | Deductible   | $1,000     |
      | SpecialUse   | No         |
      | CabGlass     | Yes        |
      | Year         | 2012       |
      | Make         | John Deere |
      | Model        | 420HD      |
      | SerialNumber | 123465AB   |
    When user adds Equipment Breakdown information
      | Question             | Answer |
      | PowerGreaterThan250kw | No     |
      | TwoOrMoreLosses       | No     |
      | GreaterThan25000      | No     |
      | FarmImplements       | No     |

    When user adds Scheduled Personal Property item and stays
      | Question      | Answer  |
      | Category      | 407     |
      | ItemType      | Jewelry |
      | Description   | Ring    |
      | Limit         | 1250    |
      | AppraisalYear | 2025    |
      | TypeOfStone   | Diamond |
      | Carat         | 1       |
      | Cut           | Oval    |
      | TypeOfJewelry | Ring    |
      | KeptInAVault  | Yes     |
      | GemPrint      | Yes     |
    When user adds Scheduled Personal Property item and stays
      | Question          | Answer              |
      | Category          | 409                 |
      | ItemType          | Stamp Collection    |
      | Amount            | 1250                |
      | AppraisalYear     | 2018                |
      | KeptInVault       | Yes                 |
      | UnattendedVehicle | Yes                 |
      | Description       | US Stamp Collection |
    When user adds Scheduled Personal Property item and continues
      | Question                | Answer                             |
      | Category                | 411                                |
      | ItemType                | Auto Trailer Home Personal Effects |
      | Amount                  | 5000                               |
      | LimitPeril              | No                                 |
      | UnattendedVehicles      | Yes                                |
      | ProfessionalEntertainer | No                                 |
      | Name                    | Joe Smith                          |
      | Description             | Contents of Trailer                |

    When user adds Liability coverage and stays
      | Question          | Answer            |
      | LiabilityLimit    | $100,000/$100,000 |
      | LivestockHorses   | 0                 |
      | LivestockSmall    | 2                 |
      | LivestockLarge    | 3                 |
      | NumberOfEmployees | 0                 |
      | UnlistedAcreage   | 0                 |
    When user edits liability optional coverage and stays
      | Question         | Answer        |
      | CoverageName     | Lessors Risk  |
      | DwellingSelected | Select        |
      | DwellingLocation | Location #1   |
      | Residence        | Residence #1  |
      | OnFarm           | Yes           |
      | BuildingSelected | Select        |
      | BuildingLocation | Location #1   |
      | Building         | Building #1   |
      | SquareFeet       | 800           |
      | LandSelected     | Select        |
      | LandLocation     | Location #1   |
      | Acres            | 200           |
    When user edits liability optional coverage and stays
      | Question         | Answer                   |
      | CoverageName     | Retail Sales On Premises |
      | TotalSales       | 15000                    |
      | Location         | Location #1              |
      | ProducedByOthers | Yes                      |
      | Description      | Clothing                 |
      | Percent          | 20                       |
    When user edits liability optional coverage and stays
      | Question         | Answer                    |
      | CoverageName     | Retail Sales Off Premises |
      | TotalSales       | 5000                      |
      | ProducedByOthers | Yes                       |
      | Description      | Clothing                  |
      | Percent          | 10                        |
    When user edits liability optional coverage and stays
      | Question            | Answer                 |
      | CoverageName        | Special Farm Pollution |
      | OccurrenceAggregate | 50000/600000           |
      | Acres               | 200                    |
      | OnsiteManureStorage | Yes                    |
      | TotalOnsiteCapacity | 7500000                |
      | MaximumMiles        | 20                     |
      | Trips               | 50                     |
    When user edits liability optional coverage and continues
      | Question            | Answer                                            |
      | CoverageName        | Chemical Drift and Transportation Increased Limits |
      | OccurrenceAggregate | 50000/100000                                      |
      | Acres               | 200                                               |

    When user adds Additional Interest Mortgagee
      | Question              | Answer           |
      | SearchName            | Connect One Bank |
      | Location              | Primary          |
      | Residence             | Main House       |
      | CopyOfDEC             | No               |
      | AccountNumber         | 123456789        |
      | DescriptionOfInterest | Mortgage Lender  |
      | EscrowBilled          | Yes              |
    When user runs Insurance Score
      | Question              | Answer          |
      | EntityType            | Primary Insured |
      | InsuranceScoreConsent | Accept          |
    Then user verifies Premium on Pricing screen
    When user navigates to the "Billing" page via the left menu
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
    When user navigates to Submission and opens Checklist
    Then user verifies no referrals are needed
    When user completes Checklist item
      | Question      | Answer              |
      | ItemName      | Residence Photo #1  |
      | Action        | Exception           |
      | ExceptionNote | Photo not available |
      | Note          | Photo not available |
    When user completes Checklist item
      | Question      | Answer                                            |
      | ItemName      | Loss Runs (Tiered - 5 Years; Not tiered - 3 years) |
      | Action        | Exception                                         |
      | ExceptionNote | Loss runs on file                                 |
      | Note          | Loss runs on file                                 |
    When user completes Checklist item
      | Question      | Answer      |
      | ItemName      | Easy Pay    |
      | Action        | Exception   |
      | ExceptionNote | EasyPay set |
      | Note          | EasyPay set |
      | Optional      | Yes         |
    When user closes Checklist and confirms Update
    Then user verifies Transmit button is enabled on Submission page
    When user validates Forms via Duckcreek for state "<StateAbbv>"

    @Shard1
    Examples:
      | State     | StateAbbv | Address       | AddressLine2 | City        | Zip   | County    |
      | Minnesota | MN        | 401 S 4th St  | 111          | Minneapolis | 55415 | Hennepin  |
      | Nebraska  | NE        | 555 S 10th St | 111          | Lincoln     | 68508 | Lancaster |

    @Shard2
    Examples:
      | State        | StateAbbv | Address    | AddressLine2 | City       | Zip   | County     |
      | South Dakota | SD        | 300 6th St | 111          | Rapid City | 57701 | Pennington |

    @Shard3
    Examples:
      | State     | StateAbbv | Address            | AddressLine2 | City      | Zip   | County |
      | Wisconsin | WI        | 100 N Jefferson St | 111          | Green Bay | 54301 | Brown  |
