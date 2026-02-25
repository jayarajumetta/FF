@UI
Feature: SFP Basic Policy

  @ExpertQuote @Smoke
  Scenario: Create a SFP Quote with Full Coverage and Submit for Issuance
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
      | MiddleName         | {{stateAbbr}}  |
      | MaritalStatus      | Married        |
      | StreetAddress      | 1206 Conway St |
      | AptNumber          |                |
      | City               | Saint Paul     |
      | State              | Minnesota      |
      | ZipCode            | 55106          |
      | ReceivedMail       | Yes            |
      | WhereClientResides | Yes            |

    # Step 7: Select Special Farm Package and quote details
    And user selects Special Farm Package and inputs Quote Details
      | Question         | Answer                                      |
      | EffectiveDate    | {{tomorrow}}                                |
      | PolicyTerm       | 12 months                                   |
      | AgentCode        | D2102                                       |
      | RatingState      | Minnesota                                   |
      | OwnershipType    | Individually Owned                          |
      | WritingCompany   | American National Property And Casualty Co. |
      | RiskAddress      | 1206 Conway St, Saint Paul, MN 55106        |
      | LessorRisk       | No                                          |

    # Step 8: Answer SSN Popup
    When user handles SSN popup and enters SSN
      | Question | Answer            |
      | SSN      | {{randomSSN}}     |

    # Step 9: Enter SFP policy details
    And user enters SFP policy details and clicks Next button
      | Question           | Answer  |
      | PrimaryFarmType    | Animals |
      | LivestockType      | Beef    |
      | SecondaryFarmType  | Grain   |
      | GrossFarmIncome    | 75000   |
      | GrowIndustrialHemp | No      |

    # Step 10: Navigate to Prequalification and answer General Eligibility
    When user enters Pre-Qualification information and continues
      | Question                | Answer            |
      | EligibilityRestrictions | None Of The Above |

    # Step 11: Enter Primary Insured Info
    When user selects Primary Insured and continues

    When user Validates Primary Insured Information for SFP and continues
      | Question       | Answer                    |
      | EntityType     | Individual/Sole Proprietor|
      | Phone          | {{randomPhone}}           |

    When user answers UW Questions and continues
      | Question             | Answer |
      | ConvictionFelony     | No     |
      | PolicyDeclined5Years | No     |
      | AlcoholOnPremises    | No     |
      | NoneOfTheAbove       | Yes    |

    # Step 12: Edit Client Role on Client Details page
    When user validates Client Details and selects Inspection Contact

    # Step 13: Add a Narrative
    When user Adds Narrative and continues
      | Question  | Answer        |
      | Narrative | Raises Cattle |

    # Step 14: Add Claims/Prior Insurance
    When user enters Claims and Prior Insurance Information and continues
      | Question                | Answer     |
      | PriorFFANPolicy         | No         |
      | YearsInBusiness         | 5          |
      | YearsContinuousCoverage | 3+ Years   |
      | PriorInsuranceExpDate   | {{today}}  |
      | PriorInsuranceCarrier   | State Farm |

    # Step 15: Add a Primary Location
    When user provides location information and continues
      | Question                | Answer  |
      | LocationNickname        | Farm 1  |
      | LocationType            | Both    |
      | MilesFromFireDepartment | 5       |
      | FeetFromHydrant         | 501-750 |
      | PPC                     | 5       |
      | TotalAcreage            | 300     |
      | WindHailDeductible      | 2%      |

    # Step 16: Add a Residence
    When user adds a Residence to the Location
      | Question          | Answer       |
      | AdditionalDesc    | Main House   |
      | YearBuilt         | 2000         |
      | RateType          | Frame        |
      | RoofYear          | 2015         |
      | RoofType          | Composition  |
      | RoofImpact        | Class 3      |
      | SeasonalOrVacant  | No           |
      | SolidFuelQuestion | No           |

    # Step 17: Add Residence Coverage
    When user adds Residence Coverage
      | Question                | Answer           |
      | InsuranceAmount         | 250000           |
      | SquareFeet              | 2500             |
      | Perils                  | Basic            |
      | ThermostatQuestion      | Yes              |
      | ActualCashValue         | Replacement Cost |
      | RCTOption               | Standard         |
      | UseDefaults             | Yes              |

    # Step 18: Add Farm Personal Property
    When user adds Farm Personal Property
      | Question    | Answer                |
      | Code        | 464                   |
      | Description | Farm Equipment        |
      | Limit       | 10000                 |
      | Deductible  | 500                   |

    # Step 19: Add Equipment Breakdown
    When user adds Equipment Breakdown information
      | Question              | Answer |
      | PowerGreaterThan250kw | No     |
      | TwoOrMoreLosses       | No     |
      | GreaterThan25000      | No     |
      | FarmImplements        | No     |

    # Step 20: Add Div 4 Scheduled Personal Property
    When user adds Scheduled Personal Property
      | Question          | Answer    |
      | Category          | 401       |
      | ItemType          | Bicycles  |
      | Description       | Road Bike |
      | Limit             | 750       |
      | YearOfAppraisal   | 2025      |

    # Step 21: Add Liability
    When user adds Liability coverage
      | Question          | Answer       |
      | LiabilityLimit    | 300000       |
      | LivestockHorses   | 5            |
      | LivestockSmall    | 10           |
      | LivestockLarge    | 20           |
      | UnlistedAcreage   | 50           |

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

    # Step 24: Verify Premium on Pricing Screen
    Then user verifies Premium on Pricing screen

    # Step 25: Validate Forms attachment via Duckcreek
    When user validates Forms via Duckcreek
      | Question     | Answer              |
      | ClientName   | {{fullName}}        |
      | State        | MN                  |

    And user clicks Save for Later

    # Step 26: Re-Log back in to EQ and Search by Quote Number
    When user navigates to Expert Quote and searches by Quote Number

    # Step 27: Visit the Checklist page
    When user navigates to Submission and opens Checklist
    Then user verifies no referrals are needed

    # Step 28: Enter required information for Checklist (Residence Photo #1)
    When user completes Checklist item
      | Question     | Answer              |
      | ItemName     | Residence Photo #1  |
      | Action       | Exception           |
      | Note         | Photo not available |

    # Step 29: Enter required information for Checklist (UL Roof Type)
    When user completes Checklist item
      | Question     | Answer                  |
      | ItemName     | UL Roof Type            |
      | Action       | Exception               |
      | Note         | Roof type confirmed     |

    # Step 30: Enter required information for Checklist (Loss Runs)
    When user completes Checklist item
      | Question     | Answer               |
      | ItemName     | Loss Runs            |
      | Action       | Exception            |
      | Note         | Loss runs on file    |

    # Step 31: Enter required information for Checklist (Signature Page)
    When user completes Checklist item
      | Question     | Answer                 |
      | ItemName     | Signature Page         |
      | Action       | Exception              |
      | Note         | Signature obtained     |

    # Step 32: Close Checklist and Click OK to Update
    When user closes Checklist and confirms Update

    # Step 33: Verify Transmit button is Enabled
    Then user verifies Transmit button is enabled on Submission page
