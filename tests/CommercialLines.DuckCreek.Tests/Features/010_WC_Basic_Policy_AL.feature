# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_DC @basic_new_business_policy @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 7 | Locator Confidence Average: 84/100 | Review-required operations: 0
# Locator Review Items: 21 source-derived locator(s) remain below high confidence.

Feature: WC Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given the Commercial Lines Duck Creek browser session is ready

  Scenario Outline: WC Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
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
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/010_wc_basic_policy_al.json | AL | AL | Alabama |
      | TestData/Scenarios/010_wc_basic_policy_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/010_wc_basic_policy_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/010_wc_basic_policy_co.json | CO | CO | Colorado |
      | TestData/Scenarios/010_wc_basic_policy_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/010_wc_basic_policy_de.json | DE | DE | Delaware |
      | TestData/Scenarios/010_wc_basic_policy_ga.json | GA | GA | Georgia |
      | TestData/Scenarios/010_wc_basic_policy_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/010_wc_basic_policy_id.json | ID | ID | Idaho |
      | TestData/Scenarios/010_wc_basic_policy_il.json | IL | IL | Illinois |
      | TestData/Scenarios/010_wc_basic_policy_in.json | IN | IN | Indiana |
      | TestData/Scenarios/010_wc_basic_policy_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/010_wc_basic_policy_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/010_wc_basic_policy_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/010_wc_basic_policy_md.json | MD | MD | Maryland |
      | TestData/Scenarios/010_wc_basic_policy_me.json | ME | ME | Maine |
      | TestData/Scenarios/010_wc_basic_policy_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/010_wc_basic_policy_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/010_wc_basic_policy_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/010_wc_basic_policy_mt.json | MT | MT | Montana |
      | TestData/Scenarios/010_wc_basic_policy_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/010_wc_basic_policy_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/010_wc_basic_policy_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/010_wc_basic_policy_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/010_wc_basic_policy_nv.json | NV | NV | Nevada |
      | TestData/Scenarios/010_wc_basic_policy_ny.json | NY | NY | New York |
      | TestData/Scenarios/010_wc_basic_policy_ok.json | OK | OK | Oklahoma |
      | TestData/Scenarios/010_wc_basic_policy_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/010_wc_basic_policy_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/010_wc_basic_policy_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/010_wc_basic_policy_sd.json | SD | SD | South Dakota |
      | TestData/Scenarios/010_wc_basic_policy_tn.json | TN | TN | Tennessee |
      | TestData/Scenarios/010_wc_basic_policy_ut.json | UT | UT | Utah |
      | TestData/Scenarios/010_wc_basic_policy_va.json | VA | VA | Virginia |
      | TestData/Scenarios/010_wc_basic_policy_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/010_wc_basic_policy_wv.json | WV | WV | West Virginia |
