# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@CL_DC @basic_new_business_policy @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 96/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 15/15 | Locator Quality: 17/20 | Test Data: 10/10
# Page Objects Used: 7 | Locator Confidence Average: 85/100 | Review-required operations: 0
# Locator Review Items: 21 source-derived locator(s) remain below high confidence.

Feature: GL Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given the Commercial Lines Duck Creek browser session is ready

  Scenario Outline: GL Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I complete Underwriting Info from Client Screen
    And I complete required policy information
    And I complete CGL Fields
    And I add Class
    And I add [CG0435] Employee Benefits Liability Endorsement
    And I add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations)
    And I add [CG 2149] Total Pollution Exclusion Endorsement
    And I verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement
    And I add Addl Interest [CG2007] - Engineers
    And I add Addl Interest [CG2020] Add'l Insured-Charitable Institution
    And I add Addl Interest [CG2023] Add'l Insured-Executors
    And I add Addl Interest [CG2025] Add'l Insured-Executive Officers
    And I add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic
    And I add notepad comment
    And I answer GL UW Questions OR & WA
    And I complete required billing information
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/005_gl_basic_policy_az.json | AZ | AZ | Arizona |
      | TestData/Scenarios/005_gl_basic_policy_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/005_gl_basic_policy_de.json | DE | DE | Delaware |
      | TestData/Scenarios/005_gl_basic_policy_ma.json | MA | MA | Massachusetts |
      | TestData/Scenarios/005_gl_basic_policy_md.json | MD | MD | Maryland |
      | TestData/Scenarios/005_gl_basic_policy_me.json | ME | ME | Maine |
      | TestData/Scenarios/005_gl_basic_policy_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/005_gl_basic_policy_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/005_gl_basic_policy_ny.json | NY | NY | New York |
      | TestData/Scenarios/005_gl_basic_policy_or.json | OR | OR | Oregon |
      | TestData/Scenarios/005_gl_basic_policy_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/005_gl_basic_policy_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/005_gl_basic_policy_va.json | VA | VA | Virginia |
      | TestData/Scenarios/005_gl_basic_policy_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/005_gl_basic_policy_wa.json | WA | WA | Washington |
      | TestData/Scenarios/005_gl_basic_policy_wv.json | WV | WV | West Virginia |
