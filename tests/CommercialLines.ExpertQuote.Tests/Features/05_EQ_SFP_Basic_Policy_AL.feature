# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_EQ @SFP @basic_new_business_policy @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 84/100
# Business Flow: 19/20 | Canonical Mapping: 10/20 | StepDefinitions: 15/15 | Page Model: 14/15 | Locator Quality: 16/20 | Test Data: 10/10
# Page Objects Used: 16 | Locator Confidence Average: 81/100 | Review-required operations: 9
# Locator Review Items: 31 source-derived locator(s) remain below high confidence.

Feature: EQ SFP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ SFP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given the Commercial Lines ExpertQuote browser session is ready

  Scenario Outline: EQ SFP Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete policy Details (Optimized)
    And I navigate to the required policy screen for screen
    And I verify None of the Above
    And I navigate to the required policy screen for navigate to screen
    And I enter Required Info
    And I navigate to the required policy screen for navigate to correct screen
    And I complete edit Client Roles
    And I navigate to the required policy screen for policy data entry
    And I add/Edit a Narrative and Verify Timestamp
    And I navigate to the required policy screen for subsequent screen 0118
    And I enter Required
    And I add a Location
    And I add a Residence
    And I add Residence Covg
    And I navigate to the required policy screen for subsequent screen 0174
    And I enter FPP
    And I navigate to the required policy screen for subsequent screen 0184
    And I complete equipment Breakdown and Implements Coverage
    And I navigate to the required policy screen for subsequent screen 0201
    And I add bicycle
    And I navigate to the required policy screen for subsequent screen 0215
    And I complete nOT CE
    And I navigate to the required policy screen for subsequent screen 0236
    And I complete insurance Score
    And I navigate to the required policy screen for subsequent screen 0250
    And I complete mortgagee/Loss Payee Information
    And I navigate to the required policy screen for subsequent screen 0273
    And I verify premium
    And I navigate to the required policy screen for subsequent screen 0282
    And I open a CLAS Browser and Search for EQ by Description 1
    And I complete restart Edge Popup
    Then I open a CLAS Browser and Search for EQ by Description 1 for username
    And I sign out of the application
    And I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1
    And I complete forms verification Retrieve QuoteID & SessionID by Browser Console
    And I complete save for Later/Return to Admin

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/05_eq_sfp_basic_policy_al.json | AL | AL | Alabama |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/05_eq_sfp_basic_policy_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/05_eq_sfp_basic_policy_co.json | CO | CO | Colorado |
      | TestData/Scenarios/05_eq_sfp_basic_policy_de.json | DE | DE | Delaware |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ga.json | GA | GA | Georgia |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/05_eq_sfp_basic_policy_id.json | ID | ID | Idaho |
      | TestData/Scenarios/05_eq_sfp_basic_policy_il.json | IL | IL | Illinois |
      | TestData/Scenarios/05_eq_sfp_basic_policy_in.json | IN | IN | Indiana |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/05_eq_sfp_basic_policy_la.json | LA | LA | Louisiana |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/05_eq_sfp_basic_policy_me.json | ME | ME | Maine |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mt.json | MT | MT | Montana |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nd.json | ND | ND | North Dakota |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nv.json | NV | NV | Nevada |
      | TestData/Scenarios/05_eq_sfp_basic_policy_oh.json | OH | OH | Ohio |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ok.json | OK | OK | Oklahoma |
      | TestData/Scenarios/05_eq_sfp_basic_policy_or.json | OR | OR | Oregon |
      | TestData/Scenarios/05_eq_sfp_basic_policy_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/05_eq_sfp_basic_policy_sd.json | SD | SD | South Dakota |
      | TestData/Scenarios/05_eq_sfp_basic_policy_tn.json | TN | TN | Tennessee |
      | TestData/Scenarios/05_eq_sfp_basic_policy_tx.json | TX | TX | Texas |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ut.json | UT | UT | Utah |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wa.json | WA | WA | Washington |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wi.json | WI | WI | Wisconsin |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wy.json | WY | WY | Wyoming |
