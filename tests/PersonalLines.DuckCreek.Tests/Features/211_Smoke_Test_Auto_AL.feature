# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 47
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 47
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@PL_DC @AUTO @smoke_test

Feature: Smoke Test Auto
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Auto workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Personal Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: Smoke Test Auto - <stateCode> <stateVariant>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Personal Lines Duck Creek application
    And I sign in to Personal Lines Duck Creek using configured credentials
    When I start New Quote
    And I select or create the policy client
    And I enter account details
    And I start the policy proposal
    And I capture the proposal number
    And I complete tabs

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/211_smoke_test_auto_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_az_ang.json | AZ | AZ ANG | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_az_anp.json | AZ | AZ ANP | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ny_ffcic.json | NY | NY FFCIC | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ny_uffic.json | NY | NY UFFIC | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_oh_ang.json | OH | OH ANG | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_oh_anp.json | OH | OH ANP | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ok_ang.json | OK | OK ANG | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ok_anp.json | OK | OK ANP | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_sd_ang.json | SD | SD ANG | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_sd_anp.json | SD | SD ANP | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_tn_ang.json | TN | TN ANG | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_tn_anp.json | TN | TN ANP | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ut_ang.json | UT | UT ANG | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_ut_anp.json | UT | UT ANP | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/211_smoke_test_auto_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
