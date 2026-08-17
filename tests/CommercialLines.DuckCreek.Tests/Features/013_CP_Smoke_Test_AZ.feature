# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_DC @smoke_test @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 5 | Locator Confidence Average: 87/100 | Review-required operations: 0
# Locator Review Items: 6 source-derived locator(s) remain below high confidence.

Feature: CP Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given the Commercial Lines Duck Creek browser session is ready

  Scenario Outline: CP Smoke Test - <stateCode>
    Given test data file "<dataFile>" is loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I sign in to Duck Creek
    And I complete restart Edge Popup
    Then I sign in to Duck Creek for logged in user
    And I sign out of the application
    And I sign in to Duck Creek for username
    And I start a new quote
    And I enter individual client information
    And I complete required policy information
    And I navigate to Policy Info and Verify Desc
    And I sign out of the application for logged in user

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/013_cp_smoke_test_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/013_cp_smoke_test_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/013_cp_smoke_test_de.json | DE | DE | Delaware |
      | TestData/Scenarios/013_cp_smoke_test_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/013_cp_smoke_test_md.json | MD | MD | Maryland |
      | TestData/Scenarios/013_cp_smoke_test_me.json | ME | ME | Maine |
      | TestData/Scenarios/013_cp_smoke_test_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/013_cp_smoke_test_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/013_cp_smoke_test_ny.json | NY | NY | New York |
      | TestData/Scenarios/013_cp_smoke_test_or.json | OR | OR | Oregon |
      | TestData/Scenarios/013_cp_smoke_test_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/013_cp_smoke_test_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/013_cp_smoke_test_va.json | VA | VA | Virginia |
      | TestData/Scenarios/013_cp_smoke_test_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/013_cp_smoke_test_wa.json | WA | WA | Washington |
      | TestData/Scenarios/013_cp_smoke_test_wv.json | WV | WV | West Virginia |
