@CL_EQ @SFP @country_estate_new_business_policy

Feature: EQ SFP Country Estate Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ SFP Country Estate Policy workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ SFP Country Estate Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete policy Details (Optimized)
    And I navigate to the required policy screen for screen
    And I verify None of the Above
    And I navigate to the required policy screen for navigate to screen
    And I enter Required Info
    And I navigate to the required policy screen for navigate to correct screen
    And I complete edit Client Roles
    And I navigate to the required policy screen for policy data entry
    And I add/Edit a Narrative and Verify Timestamp
    And I navigate to the required policy screen for subsequent screen 0118
    And I enter Required
    And I add a Location
    And I add a Residence
    And I add Residence Covg
    And I navigate to the required policy screen for subsequent screen 0174
    And I complete policy-wide
    And I navigate to the required policy screen for subsequent screen 0184
    And I complete insurance Score
    And I navigate to the required policy screen for subsequent screen 0198
    And I complete mortgagee/Loss Payee Information
    And I navigate to the required policy screen for subsequent screen 0221
    And I verify premium
    And I navigate to the required policy screen for subsequent screen 0230
    And I open a CLAS Browser and Search for EQ by Description 1
    And I complete restart Edge Popup
    Then I open a CLAS Browser and Search for EQ by Description 1 for username
    And I sign out of the application
    And I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1
    And I complete forms verification for EQ in CLAS
    And I complete save for Later/Return to Admin

    Examples:
      | stateCode | dataFile                                                   | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Basic/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      #| AR        | TestData/Basic/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      #| AZ        | TestData/Basic/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      #| CO        | TestData/Basic/CO.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      #| DE        | TestData/Basic/DE.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      #| GA        | TestData/Basic/GA.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      #| IA        | TestData/Basic/IA.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      #| ID        | TestData/Basic/ID.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      #| IL        | TestData/Basic/IL.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      #| IN        | TestData/Basic/IN.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      #| KS        | TestData/Basic/KS.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      #| KY        | TestData/Basic/KY.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      #| LA        | TestData/Basic/LA.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      #| MA        | TestData/Basic/MA.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      #| ME        | TestData/Basic/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      #| MN        | TestData/Basic/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      #| MO        | TestData/Basic/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      #| MS        | TestData/Basic/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      #| MT        | TestData/Basic/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      #| ND        | TestData/Basic/ND.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      #| NE        | TestData/Basic/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      #| NH        | TestData/Basic/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      #| NM        | TestData/Basic/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      #| NV        | TestData/Basic/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      #| OH        | TestData/Basic/OH.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      #| OK        | TestData/Basic/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      #| OR        | TestData/Basic/OR.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      #| SC        | TestData/Basic/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      #| SD        | TestData/Basic/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      #| TN        | TestData/Basic/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      #| TX        | TestData/Basic/TX.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      #| UT        | TestData/Basic/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      #| WA        | TestData/Basic/WA.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      #| WI        | TestData/Basic/WI.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      #| WY        | TestData/Basic/WY.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

