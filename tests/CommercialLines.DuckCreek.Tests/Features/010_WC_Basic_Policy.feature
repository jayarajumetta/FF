@CL_DC @basic_new_business_policy

Feature: WC Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Basic Policy workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: WC Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I navigate to Underwriting Info Screen
    And I complete required policy information
    And I complete WC Specific Fields
    Then I complete Estimated premium
    And I complete coverage Information
    And I complete Address 1
    And I complete rating Information
    And I add Class Codes
    And I navigate to Entity Schedule
    And I complete endorsements
    And I complete WC UW Questions
    And I navigate to Pricing Screen
    Then I verify Class Codes on Policy are Valid
    And I verify premium
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | stateCode | dataFile                                       | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Basic/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Basic/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Basic/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
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
      | MA        | TestData/Basic/MA.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Basic/MD.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Basic/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Basic/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Basic/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Basic/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Basic/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Basic/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Basic/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Basic/NJ.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Basic/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Basic/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Basic/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Basic/PA.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Basic/RI.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Basic/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Basic/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Basic/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Basic/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Basic/VA.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Basic/VT.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Basic/WV.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |

