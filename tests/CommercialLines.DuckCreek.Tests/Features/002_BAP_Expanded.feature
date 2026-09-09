@CL_DC @BAP @expanded_new_business

Feature: BAP Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the BAP Expanded workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: BAP Expanded - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I add Third Party Designee
    And I add Additional Named Insured
    And I complete required policy information
    And I complete Business Auto policy-specific fields
    And I run insurance score
    And I complete underwriting information from the policy information screen
    And I navigate to policy coverages
    Then I complete cT StraightThrough Liability Limit to 1M
    And I add NonOwnership Liability
    And I add Business Interruption
    And I complete required location information
    And I add UM/UIM Coverage
    And I add Policy Level Coverages
    And I add a Risk
    And I add Risk Level Interest
    And I verify Risk Level Coverages
    And I add Risk Level Coverages
    And I complete driver information
    And I verify Mandatory Endorsements
    And I add endorsement
    And I add Addl Interest
    And I complete required underwriting question information
    And I complete required billing information
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I complete forms verification
    And I complete save for Later/Return to Admin

    Examples:
      | stateCode | dataFile                                    | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Extended/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Extended/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Extended/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Extended/CA.json | CA           | California     | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Extended/CT.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Extended/CO.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Extended/DE.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Extended/GA.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Extended/IA.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Extended/ID.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Extended/IL.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Extended/IN.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Extended/KS.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Extended/KY.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Extended/LA.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Extended/MD.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Extended/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Extended/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Extended/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Extended/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Extended/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Extended/ND.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Extended/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Extended/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Extended/NJ.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Extended/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Extended/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Extended/NY.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Extended/OH.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Extended/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Extended/OR.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Extended/PA.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Extended/RI.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Extended/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Extended/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Extended/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Extended/TX.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Extended/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Extended/VA.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Extended/VT.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Extended/WA.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Extended/WI.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Extended/WV.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Extended/WY.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

