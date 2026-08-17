# Locator Resilience: direct Playwright locator -> validated cache -> deterministic DOM -> GitHub Copilot proposal
# Copilot Healing: opt-in with COPILOT_SELF_HEAL=true; business action and expected result never change

@PL_DC @CYCLE @rate_filing_new_business @automated @canonical_simple_v39 @state_data_driven
# Automation Maturity: 94/100
# Business Flow: 19/20 | Canonical Mapping: 20/20 | StepDefinitions: 15/15 | Page Model: 14/15 | Locator Quality: 16/20 | Test Data: 10/10
# Page Objects Used: 16 | Locator Confidence Average: 78/100 | Review-required operations: 0
# Locator Review Items: 52 source-derived locator(s) remain below high confidence.

Feature: Cycle Rate Filings Policy 1 NB 1
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Cycle Rate Filings Policy 1 NB 1 workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given the Personal Lines Duck Creek browser session is ready

  Scenario Outline: Cycle Rate Filings Policy 1 NB 1 - <stateCode> <stateVariant>
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
    And I complete vehicle Summary 1st Cycle Summary
    And I complete vehicle Summary Add Cycle/Next
    And I complete vehicle Summary Vintage Cycle
    And I complete vehicle Summary Add Cycle/Next for add additional vehicle
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
    And I complete underwriting Page Cycle
    And I complete additional Interest Page
    And I configure direct-pay billing
    And I complete submission underwriting comments and review
    And I open the configured policy application for openurl
    And I complete the Express underwriting review
    And I recall the quote in ExpertQuote
    And I complete the Level 9 underwriting bypass
    And I open the configured policy application for approve in express ui
    And I approve the underwriting referral in Express
    And I complete the Level 9 underwriting bypass for txt quote policy search
    And I complete the submission checklist
    And I transmit the policy
    And I verify policy transmission confirmation

    Examples:
      | dataFile | stateCode | stateVariant | stateName |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_al.json | AL | AL | Alabama |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ar.json | AR | AR | Arkansas |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_az_ang.json | AZ | AZ ANG | Arizona |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_az_anp.json | AZ | AZ ANP | Arizona |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ca.json | CA | CA | California |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_co.json | CO | CO | Colorado |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ct.json | CT | CT | Connecticut |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_de.json | DE | DE | Delaware |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ga.json | GA | GA | Georgia |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ia.json | IA | IA | Iowa |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_id.json | ID | ID | Idaho |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_il.json | IL | IL | Illinois |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_in.json | IN | IN | Indiana |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ks.json | KS | KS | Kansas |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ky.json | KY | KY | Kentucky |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_md.json | MD | MD | Maryland |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_me.json | ME | ME | Maine |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mn.json | MN | MN | Minnesota |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mo.json | MO | MO | Missouri |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ms.json | MS | MS | Mississippi |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mt.json | MT | MT | Montana |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nd.json | ND | ND | North Dakota |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ne.json | NE | NE | Nebraska |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nh.json | NH | NH | New Hampshire |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nj.json | NJ | NJ | New Jersey |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nm.json | NM | NM | New Mexico |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nv.json | NV | NV | Nevada |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ny_ffcic.json | NY | NY FFCIC | New York |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ny_uffic.json | NY | NY UFFIC | New York |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_oh_ang.json | OH | OH ANG | Ohio |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_oh_anp.json | OH | OH ANP | Ohio |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ok_ang.json | OK | OK ANG | Oklahoma |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ok_anp.json | OK | OK ANP | Oklahoma |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_or.json | OR | OR | Oregon |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_pa.json | PA | PA | Pennsylvania |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ri.json | RI | RI | Rhode Island |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sc.json | SC | SC | South Carolina |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sd_ang.json | SD | SD ANG | South Dakota |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sd_anp.json | SD | SD ANP | South Dakota |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tn_ang.json | TN | TN ANG | Tennessee |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tn_anp.json | TN | TN ANP | Tennessee |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tx.json | TX | TX | Texas |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ut_ang.json | UT | UT ANG | Utah |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ut_anp.json | UT | UT ANP | Utah |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_va.json | VA | VA | Virginia |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_vt.json | VT | VT | Vermont |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wi.json | WI | WI | Wisconsin |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wv.json | WV | WV | West Virginia |
      | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wy.json | WY | WY | Wyoming |
