@CL_DC @basic_new_business_policy

Feature: IM Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the IM Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: IM Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I complete Underwring Questions from Client Screen
    And I complete required policy information
    And I run insurance score
    And I add Accounts Receivable Coverage
    And I add Bailees Customers Coverage
    And I add Contractors Equipment
    And I add Computer Systems
    And I add Motor Truck Cargo
    And I add Signs
    And I add Accounts Receivable
    And I add Bailees Customers
    And I add Computer Systems for risk
    And I add Signs for risk
    And I add CM 66 01 Exclude Named Customer
    And I add IF 00 02 Waterborne Equipment
    And I complete Accounts Receivable Questions
    And I complete Bailees Customers Questions
    And I complete Computer Systems Questions
    And I complete Contractors Equipment Questions
    And I complete Motor Truck Cargo Questions (Owner)
    And I complete Signs Questions
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification

    Examples:
      | stateCode | dataFile                                       | stateVariant | stateName     | externalDataFile                    |
      | AZ        | TestData/Scenarios/007_im_basic_policy_az.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/007_im_basic_policy_ct.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/007_im_basic_policy_de.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/007_im_basic_policy_ma.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/007_im_basic_policy_md.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/007_im_basic_policy_me.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/007_im_basic_policy_nh.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/007_im_basic_policy_nj.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/007_im_basic_policy_ny.json | NY           | New York      | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/007_im_basic_policy_or.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/007_im_basic_policy_pa.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/007_im_basic_policy_ri.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/007_im_basic_policy_va.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/007_im_basic_policy_vt.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/007_im_basic_policy_wa.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/007_im_basic_policy_wv.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |

