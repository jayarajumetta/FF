# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@PL_DC @AUTO @smoke_test @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 4 | Locator Confidence Average: 83/100 | Review-required operations: 0
# Locator Review Items: 8 source-derived locator(s) remain below high confidence.

Feature: Smoke Test Auto
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Auto workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given the Personal Lines Duck Creek browser session is ready

  Scenario Outline: Smoke Test Auto - <stateCode> <stateVariant>
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
      | TestData/Scenarios/211_smoke_test_auto_al.json | AL | AL | Alabama |
      | TestData/Scenarios/211_smoke_test_auto_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/211_smoke_test_auto_az_ang.json | AZ | AZ ANG | Arizona |
      | TestData/Scenarios/211_smoke_test_auto_az_anp.json | AZ | AZ ANP | Arizona |
      | TestData/Scenarios/211_smoke_test_auto_ca.json | CA | CA | California |
      | TestData/Scenarios/211_smoke_test_auto_co.json | CO | CO | Colorado |
      | TestData/Scenarios/211_smoke_test_auto_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/211_smoke_test_auto_de.json | DE | DE | Delaware |
      | TestData/Scenarios/211_smoke_test_auto_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/211_smoke_test_auto_id.json | ID | ID | Idaho |
      | TestData/Scenarios/211_smoke_test_auto_il.json | IL | IL | Illinois |
      | TestData/Scenarios/211_smoke_test_auto_in.json | IN | IN | Indiana |
      | TestData/Scenarios/211_smoke_test_auto_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/211_smoke_test_auto_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/211_smoke_test_auto_me.json | ME | ME | Maine |
      | TestData/Scenarios/211_smoke_test_auto_md.json | MD | MD | Maryland |
      | TestData/Scenarios/211_smoke_test_auto_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/211_smoke_test_auto_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/211_smoke_test_auto_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/211_smoke_test_auto_mt.json | MT | MT | Montana |
      | TestData/Scenarios/211_smoke_test_auto_nd.json | ND | ND | North Dakota |
      | TestData/Scenarios/211_smoke_test_auto_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/211_smoke_test_auto_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/211_smoke_test_auto_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/211_smoke_test_auto_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/211_smoke_test_auto_ny_ffcic.json | NY | NY FFCIC | New York |
      | TestData/Scenarios/211_smoke_test_auto_ny_uffic.json | NY | NY UFFIC | New York |
      | TestData/Scenarios/211_smoke_test_auto_oh_ang.json | OH | OH ANG | Ohio |
      | TestData/Scenarios/211_smoke_test_auto_oh_anp.json | OH | OH ANP | Ohio |
      | TestData/Scenarios/211_smoke_test_auto_ok_ang.json | OK | OK ANG | Oklahoma |
      | TestData/Scenarios/211_smoke_test_auto_ok_anp.json | OK | OK ANP | Oklahoma |
      | TestData/Scenarios/211_smoke_test_auto_or.json | OR | OR | Oregon |
      | TestData/Scenarios/211_smoke_test_auto_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/211_smoke_test_auto_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/211_smoke_test_auto_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/211_smoke_test_auto_sd_ang.json | SD | SD ANG | South Dakota |
      | TestData/Scenarios/211_smoke_test_auto_sd_anp.json | SD | SD ANP | South Dakota |
      | TestData/Scenarios/211_smoke_test_auto_tn_ang.json | TN | TN ANG | Tennessee |
      | TestData/Scenarios/211_smoke_test_auto_tn_anp.json | TN | TN ANP | Tennessee |
      | TestData/Scenarios/211_smoke_test_auto_tx.json | TX | TX | Texas |
      | TestData/Scenarios/211_smoke_test_auto_ut_ang.json | UT | UT ANG | Utah |
      | TestData/Scenarios/211_smoke_test_auto_ut_anp.json | UT | UT ANP | Utah |
      | TestData/Scenarios/211_smoke_test_auto_va.json | VA | VA | Virginia |
      | TestData/Scenarios/211_smoke_test_auto_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/211_smoke_test_auto_wi.json | WI | WI | Wisconsin |
      | TestData/Scenarios/211_smoke_test_auto_wv.json | WV | WV | West Virginia |
      | TestData/Scenarios/211_smoke_test_auto_wy.json | WY | WY | Wyoming |
