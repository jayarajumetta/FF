# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 44
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@CL_DC @BAP @expanded_new_business

Feature: BAP Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the BAP Expanded workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: BAP Expanded - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I add Third Party Designee
    And I add Additional Named Insured
    And I complete required policy information
    And I complete Business Auto policy-specific fields
    And I run insurance score
    And I complete underwriting information from the policy information screen
    And I navigate to policy coverages
    Then I complete cT StraightThrough Liability Limit to 1M
    And I add NonOwnership Liability
    And I add Business Interruption
    And I complete required location information
    And I add UM/UIM Coverage
    And I add Policy Level Coverages
    And I add a Risk
    And I add Risk Level Interest
    And I verify Risk Level Coverages
    And I add Risk Level Coverages
    And I complete driver information
    And I verify Mandatory Endorsements
    And I add endorsement
    And I add Addl Interest
    And I complete required underwriting question information
    And I complete required billing information
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I complete forms verification
    And I complete save for Later/Return to Admin

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/002_bap_expanded_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_la.json | LA | LA | Louisiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_oh.json | OH | OH | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ok.json | OK | OK | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_tn.json | TN | TN | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_ut.json | UT | UT | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/002_bap_expanded_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
