@CL_DC @expanded_new_business

Feature: WC Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Expanded workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: WC Expanded - <stateCode>
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
    And I add Designated Workplaces Exclusion
    And I add Partners, Officers And Others Exclusion
    And I add Sole Proprietors, Partners, Officers And Others Coverage
    And I complete WC UW Questions
    And I navigate to Pricing Screen
    Then I verify Class Codes on Policy are Valid
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | stateCode | dataFile                                   | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Extended/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Extended/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Extended/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Extended/CO.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Extended/CT.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Extended/DE.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Extended/GA.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Extended/IA.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Extended/ID.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Extended/IL.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Extended/IN.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Extended/KS.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Extended/KY.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Extended/MA.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Extended/MD.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Extended/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Extended/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Extended/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Extended/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Extended/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Extended/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Extended/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Extended/NJ.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Extended/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Extended/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Extended/NY.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Extended/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Extended/PA.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Extended/RI.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Extended/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Extended/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Extended/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Extended/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Extended/VA.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Extended/VT.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Extended/WV.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |

