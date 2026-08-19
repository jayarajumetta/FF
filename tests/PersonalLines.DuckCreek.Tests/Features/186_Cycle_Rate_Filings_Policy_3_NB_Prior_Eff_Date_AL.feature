# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 49
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 49
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@PL_DC @CYCLE @new_business_with_prior_effective_date

Feature: Cycle Rate Filings Policy 3 NB Prior Eff Date
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Cycle Rate Filings Policy 3 NB Prior Eff Date workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: Cycle Rate Filings Policy 3 NB Prior Eff Date - <stateCode> <stateVariant>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
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
    And I complete underwriting Page Cycle
    And I complete additional Interest Page
    And I configure direct-pay billing
    And I complete submission underwriting comments and review
    And I open the configured policy application for openurl
    And I complete the Express underwriting review
    And I recall the quote in ExpertQuote
    And I complete the submission checklist
    And I transmit the policy
    And I verify policy transmission confirmation

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_az_ang.json | AZ | AZ ANG | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_az_anp.json | AZ | AZ ANP | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ny_ffcic.json | NY | NY FFCIC | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ny_uffic.json | NY | NY UFFIC | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_oh_ang.json | OH | OH ANG | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_oh_anp.json | OH | OH ANP | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ok_ang.json | OK | OK ANG | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ok_anp.json | OK | OK ANP | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_sd_ang.json | SD | SD ANG | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_sd_anp.json | SD | SD ANP | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_tn_ang.json | TN | TN ANG | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_tn_anp.json | TN | TN ANP | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ut_ang.json | UT | UT ANG | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_ut_anp.json | UT | UT ANP | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/186_cycle_rate_filings_policy_3_nb_prior_eff_date_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
