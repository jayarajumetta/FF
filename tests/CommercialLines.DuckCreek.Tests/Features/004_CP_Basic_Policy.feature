@CL_DC @basic_new_business_policy

Feature: CP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

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
      | AZ        | TestData/Scenarios/004_cp_basic_policy_az.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/004_cp_basic_policy_ct.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/004_cp_basic_policy_de.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/004_cp_basic_policy_ma.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/004_cp_basic_policy_md.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/004_cp_basic_policy_me.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/004_cp_basic_policy_nh.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/004_cp_basic_policy_nj.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/004_cp_basic_policy_ny.json | NY           | New York      | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/004_cp_basic_policy_or.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/004_cp_basic_policy_pa.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/004_cp_basic_policy_ri.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/004_cp_basic_policy_va.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/004_cp_basic_policy_vt.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/004_cp_basic_policy_wa.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/004_cp_basic_policy_wv.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |

