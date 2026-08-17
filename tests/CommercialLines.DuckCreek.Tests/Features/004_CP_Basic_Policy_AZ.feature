# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_DC @basic_new_business_policy @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 10 | Locator Confidence Average: 87/100 | Review-required operations: 0
# Locator Review Items: 20 source-derived locator(s) remain below high confidence.

Feature: CP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given the Commercial Lines Duck Creek browser session is ready

  Scenario Outline: CP Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
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
    And I sign in to Duck Creek
    And I complete restart Edge Popup
    Then I sign in to Duck Creek for logged in user
    And I sign out of the application
    And I sign in to Duck Creek for username
    And I search by Desc
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/004_cp_basic_policy_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/004_cp_basic_policy_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/004_cp_basic_policy_de.json | DE | DE | Delaware |
      | TestData/Scenarios/004_cp_basic_policy_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/004_cp_basic_policy_md.json | MD | MD | Maryland |
      | TestData/Scenarios/004_cp_basic_policy_me.json | ME | ME | Maine |
      | TestData/Scenarios/004_cp_basic_policy_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/004_cp_basic_policy_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/004_cp_basic_policy_ny.json | NY | NY | New York |
      | TestData/Scenarios/004_cp_basic_policy_or.json | OR | OR | Oregon |
      | TestData/Scenarios/004_cp_basic_policy_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/004_cp_basic_policy_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/004_cp_basic_policy_va.json | VA | VA | Virginia |
      | TestData/Scenarios/004_cp_basic_policy_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/004_cp_basic_policy_wa.json | WA | WA | Washington |
      | TestData/Scenarios/004_cp_basic_policy_wv.json | WV | WV | West Virginia |
