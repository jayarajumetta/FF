@PL_DC @AUTO @rate_filing_new_business

Feature: Auto Rate Filings Policy 1 NB
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Auto Rate Filings Policy 1 NB workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: Auto Rate Filings Policy 1 NB - <stateCode> <stateVariant>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Personal Lines Duck Creek application
    And I sign in to Personal Lines Duck Creek using configured credentials
    When I start New Quote
    And I select or create the policy client
    And I enter account details
    And I start the policy proposal
    And I complete prequalification
    And I capture the proposal number
    And I complete driver information
    And I open the configured policy application
    And I approve Level 9B
    And I complete driver information for txt quote policy search
    And I complete driver information for existing client 1
    And I review the driver information summary
    And I review household-driver prefill results
    And I navigate using the policy side menu
    And I complete vehicle Summary Automobile Rate Filing
    And I complete driver Assignment
    And I complete multiple Driver Assignment
    And I complete claims/Violations
    And I complete editClaimsViolations
    And I complete discount 1
    And I complete coverages
    And I complete auto AddlCov policy coveragess
    And I complete auto AddlCov PIP
    And I complete auto AddlCov Vehicle Coverages
    And I complete auto AddlCov Next
    And I complete pricing and verify the premium
    And I complete underwriting Page Auto
    And I complete additional Interest Page
    And I configure direct-pay billing
    And I complete the Level 9 underwriting bypass
    And I open the configured policy application for openurl
    And I approve the underwriting referral in Express
    And I complete the Level 9 underwriting bypass for txt quote policy search
    And I complete submission underwriting comments and review
    And I open the configured policy application for 15 submission
    And I complete the Express underwriting review
    And I recall the quote in ExpertQuote
    And I complete the submission checklist
    And I transmit the policy
    And I verify policy transmission confirmation

    Examples:
      | stateCode | dataFile                                                           | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Basic/AL.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Basic/AR.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Basic/AZ_ANG.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Basic/AZ_ANP.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Basic/CA.json       | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Basic/CO.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Basic/CT.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Basic/DE.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Basic/GA.json       | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Basic/IA.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Basic/ID.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Basic/IL.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Basic/IN.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Basic/KS.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Basic/KY.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Basic/MD.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Basic/ME.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Basic/MN.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Basic/MO.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Basic/MS.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Basic/MT.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Basic/ND.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Basic/NE.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Basic/NH.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Basic/NJ.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Basic/NM.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Basic/NV.json       | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY_FFCIC.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY_UFFIC.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Basic/OH_ANG.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Basic/OH_ANP.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Basic/OK_ANG.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Basic/OK_ANP.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Basic/OR.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Basic/PA.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Basic/RI.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Basic/SC.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Basic/SD_ANG.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Basic/SD_ANP.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Basic/TN_ANG.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Basic/TN_ANP.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Basic/TX.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Basic/UT_ANG.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Basic/UT_ANP.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Basic/VA.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Basic/VT.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Basic/WA.json       | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Basic/WI.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Basic/WV.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Basic/WY.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

