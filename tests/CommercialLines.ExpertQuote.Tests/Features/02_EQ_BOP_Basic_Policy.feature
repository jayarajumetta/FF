@CL_EQ @BOP @basic_new_business_policy

Feature: EQ BOP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ BOP Basic Policy workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ BOP Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete industry Class Code Restrictions
    And I navigate to the required policy screen for screen
    And I enter Required Info
    And I complete general UW Questions
    And I complete industry Class Code Questions
    And I navigate to the required policy screen for navigate to screen
    And I complete edit Client Roles
    And I navigate to the required policy screen for navigate to correct screen
    And I add/Edit a Narrative and Verify Timestamp
    And I navigate to the required policy screen for policy data entry
    And I enter Required
    And I add/Verify/Delete Claims
    And I navigate to the required policy screen for subsequent screen 0143
    And I complete edit a Location
    And I add a Building Button
    And I select Own or rent and Building SQ Footage Basic
    And I select Additional Coverages - Building, Functional Personal Property or Habitational
    And I select Occupancy SQ Footage
    And I enter supplimental data- for class
    And I select Cost Estimator & Calculate Valuations
    And I select Building Detail Fields
    And I select Heating Sources
    And I complete extra Property Risk
    And I answer Building Eligibility Questions
    And I navigate to the required policy screen for subsequent screen 0266
    And I answer EPLI Questions
    And I navigate to the required policy screen for subsequent screen 0285
    And I complete billing Account Setup
    And I complete future Payment Plan 1
    And I complete initial Payment
    And I navigate to the required policy screen for subsequent screen 0310
    And I complete insurance Score and premium Verification
    And I navigate to the required policy screen for subsequent screen 0336
    And I open EQ in Browser
    And I complete restart Edge Popup
    And I open EQ in Browser for logout
    And I sign in to ExpertQuote
    And I search by QuoteNum
    And I search Results Table
    And I open a CLAS Browser and Search for EQ by Description
    And I sign out of the application
    And I open a CLAS Browser and Search for EQ by Description for cl dc
    And I search by Desc in DC
    And I open a CLAS Browser and Search for EQ by Description for view policy
    And I complete forms verification Retrieve QuoteID & SessionID by Browser Console
    And I complete save for Later/Return to Admin
    And I open EQ in Browser for body
    And I complete restart Edge Popup for ok
    And I open EQ in Browser for open eq in browser
    And I sign in to ExpertQuote for username
    And I search by QuoteNum for quotesearchinput
    And I search Results Table for results table
    And I navigate to the required policy screen for subsequent screen 0502
    And I complete checklist and Esign
    And I complete eChecklist - Building Photo1
    And I complete eChecklist - Building Photo2
    And I complete eChecklist - Building Photo3
    And I complete eChecklist - Building Photo4
    And I complete eChecklist - Loss Runs - 3 Years
    And I select OK
    And I navigate to the required policy screen for refer to uw in eq
    And I refer to UW
    And I open a CLAS Browser and Search for EQ by Description for body
    And I sign out of the application for logged in user
    And I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description
    And I search by Desc in DC for search text
    And I open a CLAS Browser and Search for EQ by Description for verify view policy
    And I navigate to Submission Screen
    And I run Stoplight
    And I refer Application/Policy
    And I complete alert Error Check
    Then I refer Application/Policy for table row cell link
    And I complete save for Later/Return to Admin for save for later
    And I complete retreive Policy Number After Referral
    And I open EQ in Browser for open a browser
    And I complete restart Edge Popup for restart edge popup
    And I open EQ in Browser for check if logout exists
    And I sign in to ExpertQuote for login to eq sso
    And I search by QuoteNum for search by quotenum
    And I navigate to the required policy screen for subsequent screen 0827
    And I transmit to DC
    Then I verify premium on DC
    And I sign in to Duck Creek
    And I complete restart Edge Popup for restart microsoft edge message exists
    Then I sign in to Duck Creek for logged in user
    And I sign out of the application for logout
    And I sign in to Duck Creek for cl dc
    And I perform Quick Search and Open Policy
    And I verify for Policy Packet

    Examples:
      | stateCode | dataFile                                          | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Basic/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Basic/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Basic/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Basic/CA.json | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Basic/CO.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Basic/CT.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Basic/DE.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Basic/GA.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Basic/IA.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Basic/ID.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Basic/IL.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Basic/IN.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Basic/KS.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Basic/KY.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Basic/LA.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Basic/MA.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Basic/MD.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Basic/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Basic/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Basic/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Basic/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Basic/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Basic/ND.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Basic/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Basic/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Basic/NJ.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Basic/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Basic/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Basic/OH.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Basic/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Basic/OR.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Basic/PA.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Basic/RI.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Basic/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Basic/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Basic/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Basic/TX.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Basic/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Basic/VA.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Basic/VT.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Basic/WA.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Basic/WI.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Basic/WV.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Basic/WY.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

