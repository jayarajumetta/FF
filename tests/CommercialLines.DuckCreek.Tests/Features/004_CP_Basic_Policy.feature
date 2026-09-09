@CL_DC @basic_new_business_policy

Feature: CP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CP Basic Policy workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: CP Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I complete Underwriting Info from Client Screen
    And I complete required policy information
    And I run insurance score
    And I complete CP Fields
    And I complete mask Error Recovery
    And I complete CP Fields for policy coverage
    And I complete CP Fields for location
    And I complete CP Fields for building
    And I add a Rating Group
    And I complete Structure Questions
    And I add Addl Interests
    And I complete required billing information for billing
    And I add notepad comment
    And I complete Property UW Questions
    And I refresh the authenticated Duck Creek session
    And I search by Desc
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification

    Examples:
      | stateCode | dataFile                                       | stateVariant | stateName     | externalDataFile                    |
      | AZ        | TestData/Basic/AZ.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Basic/CT.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Basic/DE.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Basic/MA.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Basic/MD.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Basic/ME.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Basic/NH.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Basic/NJ.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY.json | NY           | New York      | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Basic/OR.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Basic/PA.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Basic/RI.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Basic/VA.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Basic/VT.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Basic/WA.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Basic/WV.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |

