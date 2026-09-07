@PL_DC @CYCLE @rate_filing_new_business

Feature: Cycle Rate Filings Policy 1 NB 1
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Cycle Rate Filings Policy 1 NB 1 workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: Cycle Rate Filings Policy 1 NB 1 - <stateCode> <stateVariant>
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
      | stateCode | dataFile                                                              | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_al.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ar.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_az_ang.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_az_anp.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ca.json       | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_co.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ct.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_de.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ga.json       | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ia.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_id.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_il.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_in.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ks.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ky.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_md.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_me.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mn.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mo.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ms.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_mt.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nd.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ne.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nh.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nj.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nm.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_nv.json       | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ny_ffcic.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ny_uffic.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_oh_ang.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_oh_anp.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ok_ang.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ok_anp.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_or.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_pa.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ri.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sc.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sd_ang.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_sd_anp.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tn_ang.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tn_anp.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_tx.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ut_ang.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_ut_anp.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_va.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_vt.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wi.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wv.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/185_cycle_rate_filings_policy_1_nb_1_wy.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

