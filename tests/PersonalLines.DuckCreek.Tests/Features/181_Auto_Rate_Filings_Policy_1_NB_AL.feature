# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@PL_DC @AUTO @rate_filing_new_business @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 94/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 14/15 | Locator Quality: 16/20 | Test Data: 10/10
# Page Objects Used: 16 | Locator Confidence Average: 79/100 | Review-required operations: 0
# Locator Review Items: 51 source-derived locator(s) remain below high confidence.

Feature: Auto Rate Filings Policy 1 NB
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Auto Rate Filings Policy 1 NB workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given the Personal Lines Duck Creek browser session is ready

  Scenario Outline: Auto Rate Filings Policy 1 NB - <stateCode> <stateVariant>
    Given test data file "<dataFile>" is loaded
    And I open the configured Personal Lines Duck Creek application
    And I sign in to Personal Lines Duck Creek using configured credentials
    When I start New Quote
    And I select or create the policy client
    And I enter account details
    And I start the policy proposal
    And I complete prequalification
    And I capture the proposal number
    And I complete driver information
    And I open the configured policy application
    And I approve Level 9B
    And I complete driver information for txt quote policy search
    And I complete driver information for existing client 1
    And I review the driver information summary
    And I review household-driver prefill results
    And I navigate using the policy side menu
    And I complete vehicle Summary Automobile Rate Filing
    And I complete driver Assignment
    And I complete multiple Driver Assignment
    And I complete claims/Violations
    And I complete editClaimsViolations
    And I complete discount 1
    And I complete coverages
    And I complete auto AddlCov policy coveragess
    And I complete auto AddlCov PIP
    And I complete auto AddlCov Vehicle Coverages
    And I complete auto AddlCov Next
    And I complete pricing and verify the premium
    And I complete underwriting Page Auto
    And I complete additional Interest Page
    And I configure direct-pay billing
    And I complete the Level 9 underwriting bypass
    And I open the configured policy application for openurl
    And I approve the underwriting referral in Express
    And I complete the Level 9 underwriting bypass for txt quote policy search
    And I complete submission underwriting comments and review
    And I open the configured policy application for 15 submission
    And I complete the Express underwriting review
    And I recall the quote in ExpertQuote
    And I complete the submission checklist
    And I transmit the policy
    And I verify policy transmission confirmation

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_al.json | AL | AL | Alabama |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_az_ang.json | AZ | AZ ANG | Arizona |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_az_anp.json | AZ | AZ ANP | Arizona |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ca.json | CA | CA | California |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_co.json | CO | CO | Colorado |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_de.json | DE | DE | Delaware |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ga.json | GA | GA | Georgia |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_id.json | ID | ID | Idaho |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_il.json | IL | IL | Illinois |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_in.json | IN | IN | Indiana |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_md.json | MD | MD | Maryland |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_me.json | ME | ME | Maine |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mt.json | MT | MT | Montana |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nd.json | ND | ND | North Dakota |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nv.json | NV | NV | Nevada |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ny_ffcic.json | NY | NY FFCIC | New York |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ny_uffic.json | NY | NY UFFIC | New York |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_oh_ang.json | OH | OH ANG | Ohio |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_oh_anp.json | OH | OH ANP | Ohio |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ok_ang.json | OK | OK ANG | Oklahoma |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ok_anp.json | OK | OK ANP | Oklahoma |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_or.json | OR | OR | Oregon |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sd_ang.json | SD | SD ANG | South Dakota |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sd_anp.json | SD | SD ANP | South Dakota |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tn_ang.json | TN | TN ANG | Tennessee |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tn_anp.json | TN | TN ANP | Tennessee |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tx.json | TX | TX | Texas |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ut_ang.json | UT | UT ANG | Utah |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ut_anp.json | UT | UT ANP | Utah |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_va.json | VA | VA | Virginia |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wa.json | WA | WA | Washington |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wi.json | WI | WI | Wisconsin |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wv.json | WV | WV | West Virginia |
      | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wy.json | WY | WY | Wyoming |
