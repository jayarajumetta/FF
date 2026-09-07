@PL_DC @AUTO @rate_filing_new_business

Feature: Auto Rate Filings Policy 1 NB
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Auto Rate Filings Policy 1 NB workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: Auto Rate Filings Policy 1 NB - <stateCode> <stateVariant>
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
      | stateCode | dataFile                                                           | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_al.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ar.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_az_ang.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_az_anp.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ca.json       | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_co.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ct.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_de.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ga.json       | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ia.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_id.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_il.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_in.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ks.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ky.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_md.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_me.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mn.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mo.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ms.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_mt.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nd.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ne.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nh.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nj.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nm.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_nv.json       | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ny_ffcic.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ny_uffic.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_oh_ang.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_oh_anp.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ok_ang.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ok_anp.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_or.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_pa.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ri.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sc.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sd_ang.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_sd_anp.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tn_ang.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tn_anp.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_tx.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ut_ang.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_ut_anp.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_va.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_vt.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wa.json       | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wi.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wv.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/181_auto_rate_filings_policy_1_nb_wy.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

