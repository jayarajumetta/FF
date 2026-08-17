# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@PL_DC @CYCLE @smoke_test @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 4 | Locator Confidence Average: 83/100 | Review-required operations: 0
# Locator Review Items: 8 source-derived locator(s) remain below high confidence.

Feature: Smoke Test Cycle
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Cycle workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given the Personal Lines Duck Creek browser session is ready

  Scenario Outline: Smoke Test Cycle - <stateCode> <stateVariant>
    Given test data file "<dataFile>" is loaded
    And I open the configured Personal Lines Duck Creek application
    And I sign in to Personal Lines Duck Creek using configured credentials
    When I start New Quote
    And I select or create the policy client
    And I enter account details
    And I start the policy proposal
    And I capture the proposal number
    And I complete tabs

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/212_smoke_test_cycle_al.json | AL | AL | Alabama |
      | TestData/Scenarios/212_smoke_test_cycle_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/212_smoke_test_cycle_az_ang.json | AZ | AZ ANG | Arizona |
      | TestData/Scenarios/212_smoke_test_cycle_az_anp.json | AZ | AZ ANP | Arizona |
      | TestData/Scenarios/212_smoke_test_cycle_ca.json | CA | CA | California |
      | TestData/Scenarios/212_smoke_test_cycle_co.json | CO | CO | Colorado |
      | TestData/Scenarios/212_smoke_test_cycle_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/212_smoke_test_cycle_de.json | DE | DE | Delaware |
      | TestData/Scenarios/212_smoke_test_cycle_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/212_smoke_test_cycle_id.json | ID | ID | Idaho |
      | TestData/Scenarios/212_smoke_test_cycle_il.json | IL | IL | Illinois |
      | TestData/Scenarios/212_smoke_test_cycle_in.json | IN | IN | Indiana |
      | TestData/Scenarios/212_smoke_test_cycle_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/212_smoke_test_cycle_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/212_smoke_test_cycle_me.json | ME | ME | Maine |
      | TestData/Scenarios/212_smoke_test_cycle_md.json | MD | MD | Maryland |
      | TestData/Scenarios/212_smoke_test_cycle_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/212_smoke_test_cycle_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/212_smoke_test_cycle_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/212_smoke_test_cycle_mt.json | MT | MT | Montana |
      | TestData/Scenarios/212_smoke_test_cycle_nd.json | ND | ND | North Dakota |
      | TestData/Scenarios/212_smoke_test_cycle_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/212_smoke_test_cycle_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/212_smoke_test_cycle_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/212_smoke_test_cycle_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/212_smoke_test_cycle_ny_ffcic.json | NY | NY FFCIC | New York |
      | TestData/Scenarios/212_smoke_test_cycle_ny_uffic.json | NY | NY UFFIC | New York |
      | TestData/Scenarios/212_smoke_test_cycle_oh_ang.json | OH | OH ANG | Ohio |
      | TestData/Scenarios/212_smoke_test_cycle_oh_anp.json | OH | OH ANP | Ohio |
      | TestData/Scenarios/212_smoke_test_cycle_ok_ang.json | OK | OK ANG | Oklahoma |
      | TestData/Scenarios/212_smoke_test_cycle_ok_anp.json | OK | OK ANP | Oklahoma |
      | TestData/Scenarios/212_smoke_test_cycle_or.json | OR | OR | Oregon |
      | TestData/Scenarios/212_smoke_test_cycle_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/212_smoke_test_cycle_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/212_smoke_test_cycle_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/212_smoke_test_cycle_sd_ang.json | SD | SD ANG | South Dakota |
      | TestData/Scenarios/212_smoke_test_cycle_sd_anp.json | SD | SD ANP | South Dakota |
      | TestData/Scenarios/212_smoke_test_cycle_tn_ang.json | TN | TN ANG | Tennessee |
      | TestData/Scenarios/212_smoke_test_cycle_tn_anp.json | TN | TN ANP | Tennessee |
      | TestData/Scenarios/212_smoke_test_cycle_tx.json | TX | TX | Texas |
      | TestData/Scenarios/212_smoke_test_cycle_ut_ang.json | UT | UT ANG | Utah |
      | TestData/Scenarios/212_smoke_test_cycle_ut_anp.json | UT | UT ANP | Utah |
      | TestData/Scenarios/212_smoke_test_cycle_va.json | VA | VA | Virginia |
      | TestData/Scenarios/212_smoke_test_cycle_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/212_smoke_test_cycle_wi.json | WI | WI | Wisconsin |
      | TestData/Scenarios/212_smoke_test_cycle_wv.json | WV | WV | West Virginia |
      | TestData/Scenarios/212_smoke_test_cycle_wy.json | WY | WY | Wyoming |
