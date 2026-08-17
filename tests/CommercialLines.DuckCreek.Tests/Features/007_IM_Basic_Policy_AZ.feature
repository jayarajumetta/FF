# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_DC @basic_new_business_policy @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 97/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 18/20 | Test Data: 10/10
# Page Objects Used: 8 | Locator Confidence Average: 90/100 | Review-required operations: 0
# Locator Review Items: 18 source-derived locator(s) remain below high confidence.

Feature: IM Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the IM Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given the Commercial Lines Duck Creek browser session is ready

  Scenario Outline: IM Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
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
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/007_im_basic_policy_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/007_im_basic_policy_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/007_im_basic_policy_de.json | DE | DE | Delaware |
      | TestData/Scenarios/007_im_basic_policy_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/007_im_basic_policy_md.json | MD | MD | Maryland |
      | TestData/Scenarios/007_im_basic_policy_me.json | ME | ME | Maine |
      | TestData/Scenarios/007_im_basic_policy_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/007_im_basic_policy_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/007_im_basic_policy_ny.json | NY | NY | New York |
      | TestData/Scenarios/007_im_basic_policy_or.json | OR | OR | Oregon |
      | TestData/Scenarios/007_im_basic_policy_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/007_im_basic_policy_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/007_im_basic_policy_va.json | VA | VA | Virginia |
      | TestData/Scenarios/007_im_basic_policy_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/007_im_basic_policy_wa.json | WA | WA | Washington |
      | TestData/Scenarios/007_im_basic_policy_wv.json | WV | WV | West Virginia |
